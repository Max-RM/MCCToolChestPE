using System;
using System.Collections.Generic;
using System.IO;
using Substrate.Core;
using Substrate.Nbt;

namespace Substrate;

public class AlphaChunk : IChunk, INbtObject<AlphaChunk>, ICopyable<AlphaChunk>
{
	private const int XDIM = 16;

	private const int YDIM = 128;

	private const int ZDIM = 16;

	public static SchemaNodeCompound LevelSchema = new SchemaNodeCompound
	{
		new SchemaNodeCompound("Level")
		{
			new SchemaNodeArray("Blocks", 32768),
			new SchemaNodeArray("Data", 16384),
			new SchemaNodeArray("SkyLight", 16384),
			new SchemaNodeArray("BlockLight", 16384),
			new SchemaNodeArray("HeightMap", 256),
			new SchemaNodeList("Entities", TagType.TAG_COMPOUND, SchemaOptions.CREATE_ON_MISSING),
			new SchemaNodeList("TileEntities", TagType.TAG_COMPOUND, TileEntity.Schema, SchemaOptions.CREATE_ON_MISSING),
			new SchemaNodeList("TileTicks", TagType.TAG_COMPOUND, TileTick.Schema, SchemaOptions.OPTIONAL),
			new SchemaNodeScaler("LastUpdate", TagType.TAG_LONG, SchemaOptions.CREATE_ON_MISSING),
			new SchemaNodeScaler("xPos", TagType.TAG_INT),
			new SchemaNodeScaler("zPos", TagType.TAG_INT),
			new SchemaNodeScaler("TerrainPopulated", TagType.TAG_BYTE, SchemaOptions.CREATE_ON_MISSING)
		}
	};

	private NbtTree _tree;

	private int _cx;

	private int _cz;

	private XZYByteArray _blocks;

	private XZYNibbleArray _data;

	private XZYNibbleArray _blockLight;

	private XZYNibbleArray _skyLight;

	private ZXByteArray _heightMap;

	private TagNodeList _entities;

	private TagNodeList _tileEntities;

	private TagNodeList _tileTicks;

	private AlphaBlockCollection _blockManager;

	private EntityCollection _entityManager;

	public int X => _cx;

	public int Z => _cz;

	public AlphaBlockCollection Blocks => _blockManager;

	public EntityCollection Entities => _entityManager;

	public NbtTree Tree => _tree;

	public bool IsTerrainPopulated
	{
		get
		{
			return (int)_tree.Root["Level"].ToTagCompound()["TerrainPopulated"].ToTagByte() == 1;
		}
		set
		{
			_tree.Root["Level"].ToTagCompound()["TerrainPopulated"].ToTagByte().Data = (byte)(value ? 1u : 0u);
		}
	}

	private AlphaChunk()
	{
	}

	public static AlphaChunk Create(int x, int z)
	{
		AlphaChunk alphaChunk = new AlphaChunk();
		alphaChunk._cx = x;
		alphaChunk._cz = z;
		alphaChunk.BuildNBTTree();
		return alphaChunk;
	}

	public static AlphaChunk Create(NbtTree tree)
	{
		AlphaChunk alphaChunk = new AlphaChunk();
		return alphaChunk.LoadTree(tree.Root);
	}

	public static AlphaChunk CreateVerified(NbtTree tree)
	{
		AlphaChunk alphaChunk = new AlphaChunk();
		return alphaChunk.LoadTreeSafe(tree.Root);
	}

	public void SetLocation(int x, int z)
	{
		int diffX = (x - _cx) * 16;
		int diffZ = (z - _cz) * 16;
		_cx = x;
		_cz = z;
		_tree.Root["Level"].ToTagCompound()["xPos"].ToTagInt().Data = x;
		_tree.Root["Level"].ToTagCompound()["zPos"].ToTagInt().Data = z;
		List<TileEntity> list = new List<TileEntity>();
		foreach (TagNodeCompound tileEntity2 in _tileEntities)
		{
			TileEntity tileEntity = TileEntityFactory.Create(tileEntity2);
			if (tileEntity == null)
			{
				tileEntity = TileEntity.FromTreeSafe(tileEntity2);
			}
			if (tileEntity != null)
			{
				tileEntity.MoveBy(diffX, 0, diffZ);
				list.Add(tileEntity);
			}
		}
		_tileEntities.Clear();
		foreach (TileEntity item in list)
		{
			_tileEntities.Add(item.BuildTree());
		}
		if (_tileTicks != null)
		{
			List<TileTick> list2 = new List<TileTick>();
			foreach (TagNodeCompound tileTick2 in _tileTicks)
			{
				TileTick tileTick = TileTick.FromTreeSafe(tileTick2);
				if (tileTick != null)
				{
					tileTick.MoveBy(diffX, 0, diffZ);
					list2.Add(tileTick);
				}
			}
			_tileTicks.Clear();
			foreach (TileTick item2 in list2)
			{
				_tileTicks.Add(item2.BuildTree());
			}
		}
		List<TypedEntity> list3 = new List<TypedEntity>();
		foreach (TypedEntity item3 in _entityManager)
		{
			item3.MoveBy(diffX, 0, diffZ);
			list3.Add(item3);
		}
		_entities.Clear();
		foreach (TypedEntity item4 in list3)
		{
			_entityManager.Add(item4);
		}
	}

	public bool Save(Stream outStream)
	{
		if (outStream == null || !outStream.CanWrite)
		{
			return false;
		}
		BuildConditional();
		_tree.WriteTo(outStream);
		outStream.Close();
		return true;
	}

	public AlphaChunk LoadTree(TagNode tree)
	{
		if (!(tree is TagNodeCompound tree2))
		{
			return null;
		}
		_tree = new NbtTree(tree2);
		TagNodeCompound tagNodeCompound = _tree.Root["Level"] as TagNodeCompound;
		_blocks = new XZYByteArray(16, 128, 16, tagNodeCompound["Blocks"] as TagNodeByteArray);
		_data = new XZYNibbleArray(16, 128, 16, tagNodeCompound["Data"] as TagNodeByteArray);
		_blockLight = new XZYNibbleArray(16, 128, 16, tagNodeCompound["BlockLight"] as TagNodeByteArray);
		_skyLight = new XZYNibbleArray(16, 128, 16, tagNodeCompound["SkyLight"] as TagNodeByteArray);
		_heightMap = new ZXByteArray(16, 16, tagNodeCompound["HeightMap"] as TagNodeByteArray);
		_entities = tagNodeCompound["Entities"] as TagNodeList;
		_tileEntities = tagNodeCompound["TileEntities"] as TagNodeList;
		if (tagNodeCompound.ContainsKey("TileTicks"))
		{
			_tileTicks = tagNodeCompound["TileTicks"] as TagNodeList;
		}
		else
		{
			_tileTicks = new TagNodeList(TagType.TAG_COMPOUND);
		}
		if (_entities.Count == 0)
		{
			tagNodeCompound["Entities"] = new TagNodeList(TagType.TAG_COMPOUND);
			_entities = tagNodeCompound["Entities"] as TagNodeList;
		}
		if (_tileEntities.Count == 0)
		{
			tagNodeCompound["TileEntities"] = new TagNodeList(TagType.TAG_COMPOUND);
			_tileEntities = tagNodeCompound["TileEntities"] as TagNodeList;
		}
		if (_tileTicks.Count == 0)
		{
			tagNodeCompound["TileTicks"] = new TagNodeList(TagType.TAG_COMPOUND);
			_tileTicks = tagNodeCompound["TileTicks"] as TagNodeList;
		}
		_cx = tagNodeCompound["xPos"].ToTagInt();
		_cz = tagNodeCompound["zPos"].ToTagInt();
		_blockManager = new AlphaBlockCollection(_blocks, _data, _blockLight, _skyLight, _heightMap, _tileEntities, _tileTicks);
		_entityManager = new EntityCollection(_entities);
		return this;
	}

	public AlphaChunk LoadTreeSafe(TagNode tree)
	{
		if (!ValidateTree(tree))
		{
			return null;
		}
		return LoadTree(tree);
	}

	public TagNode BuildTree()
	{
		BuildConditional();
		return _tree.Root;
	}

	public bool ValidateTree(TagNode tree)
	{
		NbtVerifier nbtVerifier = new NbtVerifier(tree, LevelSchema);
		return nbtVerifier.Verify();
	}

	public AlphaChunk Copy()
	{
		return Create(_tree.Copy());
	}

	private void BuildConditional()
	{
		TagNodeCompound tagNodeCompound = _tree.Root["Level"] as TagNodeCompound;
		if (_tileTicks != _blockManager.TileTicks && _blockManager.TileTicks.Count > 0)
		{
			_tileTicks = _blockManager.TileTicks;
			tagNodeCompound["TileTicks"] = _tileTicks;
		}
	}

	private void BuildNBTTree()
	{
		int num = 256;
		int num2 = num * 128;
		TagNodeByteArray tagNodeByteArray = new TagNodeByteArray(new byte[num2]);
		TagNodeByteArray tagNodeByteArray2 = new TagNodeByteArray(new byte[num2 >> 1]);
		TagNodeByteArray tagNodeByteArray3 = new TagNodeByteArray(new byte[num2 >> 1]);
		TagNodeByteArray tagNodeByteArray4 = new TagNodeByteArray(new byte[num2 >> 1]);
		TagNodeByteArray tagNodeByteArray5 = new TagNodeByteArray(new byte[num]);
		_blocks = new XZYByteArray(16, 128, 16, tagNodeByteArray);
		_data = new XZYNibbleArray(16, 128, 16, tagNodeByteArray2);
		_blockLight = new XZYNibbleArray(16, 128, 16, tagNodeByteArray3);
		_skyLight = new XZYNibbleArray(16, 128, 16, tagNodeByteArray4);
		_heightMap = new ZXByteArray(16, 16, tagNodeByteArray5);
		_entities = new TagNodeList(TagType.TAG_COMPOUND);
		_tileEntities = new TagNodeList(TagType.TAG_COMPOUND);
		_tileTicks = new TagNodeList(TagType.TAG_COMPOUND);
		TagNodeCompound tagNodeCompound = new TagNodeCompound();
		tagNodeCompound.Add("Blocks", tagNodeByteArray);
		tagNodeCompound.Add("Data", tagNodeByteArray2);
		tagNodeCompound.Add("SkyLight", tagNodeByteArray3);
		tagNodeCompound.Add("BlockLight", tagNodeByteArray4);
		tagNodeCompound.Add("HeightMap", tagNodeByteArray5);
		tagNodeCompound.Add("Entities", _entities);
		tagNodeCompound.Add("TileEntities", _tileEntities);
		tagNodeCompound.Add("TileTicks", _tileTicks);
		tagNodeCompound.Add("LastUpdate", new TagNodeLong(Timestamp()));
		tagNodeCompound.Add("xPos", new TagNodeInt(_cx));
		tagNodeCompound.Add("zPos", new TagNodeInt(_cz));
		tagNodeCompound.Add("TerrainPopulated", new TagNodeByte());
		_tree = new NbtTree();
		_tree.Root.Add("Level", tagNodeCompound);
		_blockManager = new AlphaBlockCollection(_blocks, _data, _blockLight, _skyLight, _heightMap, _tileEntities);
		_entityManager = new EntityCollection(_entities);
	}

	private int Timestamp()
	{
		DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
		return (int)((DateTime.UtcNow - dateTime).Ticks / 10000000);
	}
}
