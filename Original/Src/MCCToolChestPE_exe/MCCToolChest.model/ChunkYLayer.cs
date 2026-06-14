using System;
using System.Runtime.CompilerServices;
using Substrate.Nbt;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.model;

[Serializable]
public class ChunkYLayer
{
	private int QubSnrQR6Yf;

	private Block[] gykSn5BkX8p;

	private TagNodeList tkmSn6fAwFY;

	public int Layer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return QubSnrQR6Yf;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			QubSnrQR6Yf = value;
		}
	}

	internal Block[] Blocks
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return gykSn5BkX8p;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			gykSn5BkX8p = value;
		}
	}

	public TagNodeList TileEntities
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return tkmSn6fAwFY;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			tkmSn6fAwFY = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ChunkYLayer()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		gykSn5BkX8p = new Block[256];
		tkmSn6fAwFY = new TagNodeList(TagType.TAG_COMPOUND);
		for (int i = 0; i < 256; i++)
		{
			gykSn5BkX8p[i] = new Block();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ChunkYLayer(int level)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		QubSnrQR6Yf = level;
	}
}
