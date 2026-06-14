using System;
using System.Collections.Generic;
using Substrate.Core;
using Substrate.Nbt;

namespace Substrate;

public class AnvilSection : INbtObject<AnvilSection>, ICopyable<AnvilSection>
{
	private const int XDIM = 16;

	private const int YDIM = 16;

	private const int ZDIM = 16;

	private const int MIN_Y = 0;

	private const int MAX_Y = 15;

	public static SchemaNodeCompound SectionSchema = new SchemaNodeCompound
	{
		new SchemaNodeArray("Blocks", 4096),
		new SchemaNodeArray("Data", 2048),
		new SchemaNodeArray("SkyLight", 2048),
		new SchemaNodeArray("BlockLight", 2048),
		new SchemaNodeScaler("Y", TagType.TAG_BYTE),
		new SchemaNodeArray("Add", 2048, SchemaOptions.OPTIONAL)
	};

	private TagNodeCompound _tree;

	private byte _y;

	private YZXByteArray _blocks;

	private YZXNibbleArray _data;

	private YZXNibbleArray _blockLight;

	private YZXNibbleArray _skyLight;

	private YZXNibbleArray _addBlocks;

	public int Y
	{
		get
		{
			return _y;
		}
		set
		{
			if (value < 0 || value > 15)
			{
				throw new ArgumentOutOfRangeException();
			}
			_y = (byte)value;
			_tree["Y"].ToTagByte().Data = _y;
		}
	}

	public YZXByteArray Blocks => _blocks;

	public YZXNibbleArray Data => _data;

	public YZXNibbleArray BlockLight => _blockLight;

	public YZXNibbleArray SkyLight => _skyLight;

	public YZXNibbleArray AddBlocks => _addBlocks;

	private AnvilSection()
	{
	}

	public AnvilSection(int y)
	{
		if (y < 0 || y > 15)
		{
			throw new ArgumentOutOfRangeException();
		}
		_y = (byte)y;
		BuildNbtTree();
	}

	public AnvilSection(TagNodeCompound tree)
	{
		LoadTree(tree);
	}

	public bool CheckEmpty()
	{
		if (CheckBlocksEmpty())
		{
			return CheckAddBlocksEmpty();
		}
		return false;
	}

	private bool CheckBlocksEmpty()
	{
		for (int i = 0; i < _blocks.Length; i++)
		{
			if (_blocks[i] != 0)
			{
				return false;
			}
		}
		return true;
	}

	private bool CheckAddBlocksEmpty()
	{
		if (_addBlocks != null)
		{
			for (int i = 0; i < _addBlocks.Length; i++)
			{
				if (_addBlocks[i] != 0)
				{
					return false;
				}
			}
		}
		return true;
	}

	public AnvilSection LoadTree(TagNode tree)
	{
		if (!(tree is TagNodeCompound tagNodeCompound))
		{
			return null;
		}
		_y = tagNodeCompound["Y"] as TagNodeByte;
		_blocks = new YZXByteArray(16, 16, 16, tagNodeCompound["Blocks"] as TagNodeByteArray);
		_data = new YZXNibbleArray(16, 16, 16, tagNodeCompound["Data"] as TagNodeByteArray);
		_skyLight = new YZXNibbleArray(16, 16, 16, tagNodeCompound["SkyLight"] as TagNodeByteArray);
		_blockLight = new YZXNibbleArray(16, 16, 16, tagNodeCompound["BlockLight"] as TagNodeByteArray);
		if (!tagNodeCompound.ContainsKey("Add"))
		{
			tagNodeCompound["Add"] = new TagNodeByteArray(new byte[2048]);
		}
		_addBlocks = new YZXNibbleArray(16, 16, 16, tagNodeCompound["Add"] as TagNodeByteArray);
		_tree = tagNodeCompound;
		return this;
	}

	public AnvilSection LoadTreeSafe(TagNode tree)
	{
		if (!ValidateTree(tree))
		{
			return null;
		}
		return LoadTree(tree);
	}

	public TagNode BuildTree()
	{
		TagNodeCompound tagNodeCompound = new TagNodeCompound();
		foreach (KeyValuePair<string, TagNode> item in _tree)
		{
			tagNodeCompound.Add(item.Key, item.Value);
		}
		if (CheckAddBlocksEmpty())
		{
			tagNodeCompound.Remove("Add");
		}
		return tagNodeCompound;
	}

	public bool ValidateTree(TagNode tree)
	{
		NbtVerifier nbtVerifier = new NbtVerifier(tree, SectionSchema);
		return nbtVerifier.Verify();
	}

	public AnvilSection Copy()
	{
		return new AnvilSection().LoadTree(_tree.Copy());
	}

	private void BuildNbtTree()
	{
		int num = 4096;
		TagNodeByteArray tagNodeByteArray = new TagNodeByteArray(new byte[num]);
		TagNodeByteArray tagNodeByteArray2 = new TagNodeByteArray(new byte[num >> 1]);
		TagNodeByteArray tagNodeByteArray3 = new TagNodeByteArray(new byte[num >> 1]);
		TagNodeByteArray tagNodeByteArray4 = new TagNodeByteArray(new byte[num >> 1]);
		TagNodeByteArray tagNodeByteArray5 = new TagNodeByteArray(new byte[num >> 1]);
		_blocks = new YZXByteArray(16, 16, 16, tagNodeByteArray);
		_data = new YZXNibbleArray(16, 16, 16, tagNodeByteArray2);
		_skyLight = new YZXNibbleArray(16, 16, 16, tagNodeByteArray3);
		_blockLight = new YZXNibbleArray(16, 16, 16, tagNodeByteArray4);
		_addBlocks = new YZXNibbleArray(16, 16, 16, tagNodeByteArray5);
		TagNodeCompound tagNodeCompound = new TagNodeCompound();
		tagNodeCompound.Add("Y", new TagNodeByte(_y));
		tagNodeCompound.Add("Blocks", tagNodeByteArray);
		tagNodeCompound.Add("Data", tagNodeByteArray2);
		tagNodeCompound.Add("SkyLight", tagNodeByteArray3);
		tagNodeCompound.Add("BlockLight", tagNodeByteArray4);
		tagNodeCompound.Add("Add", tagNodeByteArray5);
		_tree = tagNodeCompound;
	}
}
