using System;
using System.Collections.Generic;
using System.IO;
using Substrate.Core;
using Substrate.Nbt;

namespace Substrate;

public class AnvilChunk : IChunk, INbtObject<AnvilChunk>, ICopyable<AnvilChunk>
{
	private const int XDIM = 16;

	private const int YDIM = 256;

	private const int ZDIM = 16;

	public static SchemaNodeCompound LevelSchema = new SchemaNodeCompound
	{
		new SchemaNodeCompound("Level")
		{
			new SchemaNodeList("Sections", TagType.TAG_COMPOUND, new SchemaNodeCompound
			{
				new SchemaNodeArray("Blocks", 4096),
				new SchemaNodeArray("Data", 2048),
				new SchemaNodeArray("SkyLight", 2048),
				new SchemaNodeArray("BlockLight", 2048),
				new SchemaNodeScaler("Y", TagType.TAG_BYTE),
				new SchemaNodeArray("Add", 2048, SchemaOptions.OPTIONAL)
			}),
			new SchemaNodeArray("Biomes", 256, SchemaOptions.OPTIONAL),
			new SchemaNodeIntArray("HeightMap", 256),
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

	private AnvilSection[] _sections;

	private IDataArray3 _blocks;

	private IDataArray3 _data;

	private IDataArray3 _blockLight;

	private IDataArray3 _skyLight;

	private ZXIntArray _heightMap;

	private ZXByteArray _biomes;

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

	private AnvilChunk()
	{
		_sections = new AnvilSection[16];
	}

	public static AnvilChunk Create(int x, int z)
	{
		AnvilChunk anvilChunk = new AnvilChunk();
		anvilChunk._cx = x;
		anvilChunk._cz = z;
		anvilChunk.BuildNBTTree();
		return anvilChunk;
	}

	public static AnvilChunk Create(NbtTree tree)
	{
		AnvilChunk anvilChunk = new AnvilChunk();
		return anvilChunk.LoadTree(tree.Root);
	}

	public static AnvilChunk CreateVerified(NbtTree tree)
	{
		AnvilChunk anvilChunk = new AnvilChunk();
		return anvilChunk.LoadTreeSafe(tree.Root);
	}

	public virtual void SetLocation(int x, int z)
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
		NbtTree nbtTree = new NbtTree();
		nbtTree.Root["Level"] = BuildTree();
		nbtTree.WriteTo(outStream);
		outStream.Close();
		return true;
	}

	public AnvilChunk LoadTree(TagNode tree)
	{
		if (!(tree is TagNodeCompound tree2))
		{
			return null;
		}
		_tree = new NbtTree(tree2);
		TagNodeCompound tagNodeCompound = _tree.Root["Level"] as TagNodeCompound;
		TagNodeList tagNodeList = tagNodeCompound["Sections"] as TagNodeList;
		foreach (TagNodeCompound item in tagNodeList)
		{
			AnvilSection anvilSection = new AnvilSection(item);
			if (anvilSection.Y >= 0 && anvilSection.Y < _sections.Length)
			{
				_sections[anvilSection.Y] = anvilSection;
			}
		}
		FusedDataArray3[] array = new FusedDataArray3[_sections.Length];
		YZXNibbleArray[] array2 = new YZXNibbleArray[_sections.Length];
		YZXNibbleArray[] array3 = new YZXNibbleArray[_sections.Length];
		YZXNibbleArray[] array4 = new YZXNibbleArray[_sections.Length];
		for (int i = 0; i < _sections.Length; i++)
		{
			if (_sections[i] == null)
			{
				_sections[i] = new AnvilSection(i);
			}
			array[i] = new FusedDataArray3(_sections[i].AddBlocks, _sections[i].Blocks);
			array2[i] = _sections[i].Data;
			array3[i] = _sections[i].SkyLight;
			array4[i] = _sections[i].BlockLight;
		}
		_blocks = new CompositeDataArray3(array);
		_data = new CompositeDataArray3(array2);
		_skyLight = new CompositeDataArray3(array3);
		_blockLight = new CompositeDataArray3(array4);
		_heightMap = new ZXIntArray(16, 16, tagNodeCompound["HeightMap"] as TagNodeIntArray);
		if (tagNodeCompound.ContainsKey("Biomes"))
		{
			_biomes = new ZXByteArray(16, 16, tagNodeCompound["Biomes"] as TagNodeByteArray);
		}
		else
		{
			tagNodeCompound["Biomes"] = new TagNodeByteArray(new byte[256]);
			_biomes = new ZXByteArray(16, 16, tagNodeCompound["Biomes"] as TagNodeByteArray);
			for (int j = 0; j < 16; j++)
			{
				for (int k = 0; k < 16; k++)
				{
					_biomes[j, k] = 255;
				}
			}
		}
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

	public AnvilChunk LoadTreeSafe(TagNode tree)
	{
		if (!ValidateTree(tree))
		{
			return null;
		}
		return LoadTree(tree);
	}

	private bool ShouldIncludeSection(AnvilSection section)
	{
		int num = (section.Y + 1) * section.Blocks.YDim;
		for (int i = 0; i < _heightMap.Length; i++)
		{
			if (_heightMap[i] > num)
			{
				return true;
			}
		}
		return !section.CheckEmpty();
	}

	public TagNode BuildTree()
	{
		TagNodeCompound tagNodeCompound = _tree.Root["Level"] as TagNodeCompound;
		TagNodeCompound tagNodeCompound2 = new TagNodeCompound();
		foreach (KeyValuePair<string, TagNode> item in tagNodeCompound)
		{
			tagNodeCompound2.Add(item.Key, item.Value);
		}
		TagNodeList tagNodeList = new TagNodeList(TagType.TAG_COMPOUND);
		for (int i = 0; i < _sections.Length; i++)
		{
			if (ShouldIncludeSection(_sections[i]))
			{
				tagNodeList.Add(_sections[i].BuildTree());
			}
		}
		tagNodeCompound2["Sections"] = tagNodeList;
		if (_tileTicks.Count == 0)
		{
			tagNodeCompound2.Remove("TileTicks");
		}
		return tagNodeCompound2;
	}

	public bool ValidateTree(TagNode tree)
	{
		NbtVerifier nbtVerifier = new NbtVerifier(tree, LevelSchema);
		return nbtVerifier.Verify();
	}

	public AnvilChunk Copy()
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
		_sections = new AnvilSection[16];
		TagNodeList tagNodeList = new TagNodeList(TagType.TAG_COMPOUND);
		for (int i = 0; i < _sections.Length; i++)
		{
			_sections[i] = new AnvilSection(i);
			tagNodeList.Add(_sections[i].BuildTree());
		}
		FusedDataArray3[] array = new FusedDataArray3[_sections.Length];
		YZXNibbleArray[] array2 = new YZXNibbleArray[_sections.Length];
		YZXNibbleArray[] array3 = new YZXNibbleArray[_sections.Length];
		YZXNibbleArray[] array4 = new YZXNibbleArray[_sections.Length];
		for (int j = 0; j < _sections.Length; j++)
		{
			array[j] = new FusedDataArray3(_sections[j].AddBlocks, _sections[j].Blocks);
			array2[j] = _sections[j].Data;
			array3[j] = _sections[j].SkyLight;
			array4[j] = _sections[j].BlockLight;
		}
		_blocks = new CompositeDataArray3(array);
		_data = new CompositeDataArray3(array2);
		_skyLight = new CompositeDataArray3(array3);
		_blockLight = new CompositeDataArray3(array4);
		TagNodeIntArray tagNodeIntArray = new TagNodeIntArray(new int[num]);
		_heightMap = new ZXIntArray(16, 16, tagNodeIntArray);
		TagNodeByteArray tagNodeByteArray = new TagNodeByteArray(new byte[num]);
		_biomes = new ZXByteArray(16, 16, tagNodeByteArray);
		for (int k = 0; k < 16; k++)
		{
			for (int l = 0; l < 16; l++)
			{
				_biomes[k, l] = 255;
			}
		}
		_entities = new TagNodeList(TagType.TAG_COMPOUND);
		_tileEntities = new TagNodeList(TagType.TAG_COMPOUND);
		_tileTicks = new TagNodeList(TagType.TAG_COMPOUND);
		TagNodeCompound tagNodeCompound = new TagNodeCompound();
		tagNodeCompound.Add("Sections", tagNodeList);
		tagNodeCompound.Add("HeightMap", tagNodeIntArray);
		tagNodeCompound.Add("Biomes", tagNodeByteArray);
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
