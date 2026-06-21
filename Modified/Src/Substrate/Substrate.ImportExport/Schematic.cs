using System.IO;
using Substrate.Core;
using Substrate.Nbt;

namespace Substrate.ImportExport;

public class Schematic
{
	private static SchemaNodeCompound _schema = new SchemaNodeCompound
	{
		new SchemaNodeScaler("Width", TagType.TAG_SHORT),
		new SchemaNodeScaler("Length", TagType.TAG_SHORT),
		new SchemaNodeScaler("Height", TagType.TAG_SHORT),
		new SchemaNodeString("Materials", "Alpha"),
		new SchemaNodeArray("Blocks"),
		new SchemaNodeArray("Data"),
		new SchemaNodeList("Entities", TagType.TAG_COMPOUND, Entity.Schema),
		new SchemaNodeList("TileEntities", TagType.TAG_COMPOUND, TileEntity.Schema)
	};

	private XZYByteArray _blocks;

	private XZYNibbleArray _data;

	private XZYNibbleArray _blockLight;

	private XZYNibbleArray _skyLight;

	private ZXByteArray _heightMap;

	private TagNodeList _entities;

	private TagNodeList _tileEntities;

	private AlphaBlockCollection _blockset;

	private EntityCollection _entityset;

	public AlphaBlockCollection Blocks
	{
		get
		{
			return _blockset;
		}
		set
		{
			_blockset = value;
		}
	}

	public EntityCollection Entities
	{
		get
		{
			return _entityset;
		}
		set
		{
			_entityset = value;
		}
	}

	private Schematic()
	{
	}

	public Schematic(AlphaBlockCollection blocks, EntityCollection entities)
	{
		_blockset = blocks;
		_entityset = entities;
	}

	public Schematic(int xdim, int ydim, int zdim)
	{
		_blocks = new XZYByteArray(xdim, ydim, zdim);
		_data = new XZYNibbleArray(xdim, ydim, zdim);
		_blockLight = new XZYNibbleArray(xdim, ydim, zdim);
		_skyLight = new XZYNibbleArray(xdim, ydim, zdim);
		_heightMap = new ZXByteArray(xdim, zdim);
		_entities = new TagNodeList(TagType.TAG_COMPOUND);
		_tileEntities = new TagNodeList(TagType.TAG_COMPOUND);
		_blockset = new AlphaBlockCollection(_blocks, _data, _blockLight, _skyLight, _heightMap, _tileEntities);
		_entityset = new EntityCollection(_entities);
	}

	public static Schematic Import(string path)
	{
		NBTFile nBTFile = new NBTFile(path);
		if (!nBTFile.Exists())
		{
			return null;
		}
		Stream dataInputStream = nBTFile.GetDataInputStream();
		if (dataInputStream == null)
		{
			return null;
		}
		NbtTree nbtTree = new NbtTree(dataInputStream);
		NbtVerifier nbtVerifier = new NbtVerifier(nbtTree.Root, _schema);
		if (!nbtVerifier.Verify())
		{
			return null;
		}
		TagNodeCompound root = nbtTree.Root;
		int num = root["Width"].ToTagShort();
		int num2 = root["Length"].ToTagShort();
		int num3 = root["Height"].ToTagShort();
		Schematic schematic = new Schematic(num, num3, num2);
		YZXByteArray yZXByteArray = new YZXByteArray(num, num3, num2, root["Blocks"].ToTagByteArray());
		YZXByteArray yZXByteArray2 = new YZXByteArray(num, num3, num2, root["Data"].ToTagByteArray());
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < num3; j++)
			{
				for (int k = 0; k < num2; k++)
				{
					schematic._blocks[i, j, k] = yZXByteArray[i, j, k];
					schematic._data[i, j, k] = yZXByteArray2[i, j, k];
				}
			}
		}
		TagNodeList tagNodeList = root["Entities"] as TagNodeList;
		foreach (TagNode item in tagNodeList)
		{
			schematic._entities.Add(item);
		}
		TagNodeList tagNodeList2 = root["TileEntities"] as TagNodeList;
		foreach (TagNode item2 in tagNodeList2)
		{
			schematic._tileEntities.Add(item2);
		}
		schematic._blockset.Refresh();
		return schematic;
	}

	public void Export(string path)
	{
		int xDim = _blockset.XDim;
		int yDim = _blockset.YDim;
		int zDim = _blockset.ZDim;
		byte[] array = new byte[xDim * yDim * zDim];
		byte[] array2 = new byte[xDim * yDim * zDim];
		YZXByteArray yZXByteArray = new YZXByteArray(_blockset.XDim, _blockset.YDim, _blockset.ZDim, array);
		YZXByteArray yZXByteArray2 = new YZXByteArray(_blockset.XDim, _blockset.YDim, _blockset.ZDim, array2);
		TagNodeList tagNodeList = new TagNodeList(TagType.TAG_COMPOUND);
		TagNodeList tagNodeList2 = new TagNodeList(TagType.TAG_COMPOUND);
		for (int i = 0; i < xDim; i++)
		{
			for (int j = 0; j < zDim; j++)
			{
				for (int k = 0; k < yDim; k++)
				{
					AlphaBlock block = _blockset.GetBlock(i, k, j);
					yZXByteArray[i, k, j] = (byte)block.ID;
					yZXByteArray2[i, k, j] = (byte)block.Data;
					TileEntity tileEntity = block.GetTileEntity();
					if (tileEntity != null)
					{
						tileEntity.X = i;
						tileEntity.Y = k;
						tileEntity.Z = j;
						tagNodeList2.Add(tileEntity.BuildTree());
					}
				}
			}
		}
		foreach (TypedEntity item in _entityset)
		{
			tagNodeList.Add(item.BuildTree());
		}
		TagNodeCompound tagNodeCompound = new TagNodeCompound();
		tagNodeCompound["Width"] = new TagNodeShort((short)xDim);
		tagNodeCompound["Length"] = new TagNodeShort((short)zDim);
		tagNodeCompound["Height"] = new TagNodeShort((short)yDim);
		tagNodeCompound["Entities"] = tagNodeList;
		tagNodeCompound["TileEntities"] = tagNodeList2;
		tagNodeCompound["Materials"] = new TagNodeString("Alpha");
		tagNodeCompound["Blocks"] = new TagNodeByteArray(array);
		tagNodeCompound["Data"] = new TagNodeByteArray(array2);
		NBTFile nBTFile = new NBTFile(path);
		Stream dataOutputStream = nBTFile.GetDataOutputStream();
		if (dataOutputStream != null)
		{
			NbtTree nbtTree = new NbtTree(tagNodeCompound, "Schematic");
			nbtTree.WriteTo(dataOutputStream);
			dataOutputStream.Close();
		}
	}
}
