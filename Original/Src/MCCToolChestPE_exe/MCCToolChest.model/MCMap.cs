using System.Runtime.CompilerServices;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.model;

public class MCMap
{
	private string xrpSfT0PB0W;

	private TagNodeCompound B5uSfSVQgs9;

	private long yY1SfGtc3gg;

	private MapStatusType iNQSfbLlHKY;

	public string Name
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return xrpSfT0PB0W;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			xrpSfT0PB0W = value;
		}
	}

	public TagNodeCompound Map
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return B5uSfSVQgs9;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			B5uSfSVQgs9 = value;
		}
	}

	public long Index
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return yY1SfGtc3gg;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			yY1SfGtc3gg = value;
		}
	}

	public MapStatusType MapStatus
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return iNQSfbLlHKY;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			iNQSfbLlHKY = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MCMap()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MCMap(long index)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		yY1SfGtc3gg = index;
		xrpSfT0PB0W = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88438) + index;
		B5uSfSVQgs9 = GenerateMapNode(index);
		iNQSfbLlHKY = MapStatusType.New;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MCMap(long index, string name, TagNodeCompound map)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		yY1SfGtc3gg = index;
		xrpSfT0PB0W = name;
		B5uSfSVQgs9 = map;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TagNodeCompound GenerateMapNode(long index)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound tagNodeCompound = new TagNodeCompound();
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(73586)] = new TagNodeByte(byte.MaxValue);
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88450)] = new TagNodeShort(1);
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(73624)] = new TagNodeShort(128);
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88480)] = new TagNodeLong(index);
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88494)] = new TagNodeLong(-1L);
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88520)] = new TagNodeByte(4);
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88534)] = new TagNodeShort(128);
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88548)] = new TagNodeInt(0);
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88566)] = new TagNodeInt(0);
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(73608)] = new TagNodeByteArray(new byte[65536]);
		return tagNodeCompound;
	}
}
