using System;
using System.Runtime.CompilerServices;
using MCCToolChest.model;
using NBTModel.Interop;
using Substrate.Nbt;
using YBh7EaXMWmkFRJOX37M;

namespace FRf36gucTeRIo5eJcof;

[Serializable]
internal class Ib8r6ijzN8XDyCxCIdE
{
	private int MZcSlVmny7u;

	private Block[] pBlSlWp4bYd;

	private byte[] PfVSlpYlYUJ;

	public int Layer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return MZcSlVmny7u;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			MZcSlVmny7u = value;
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
			return pBlSlWp4bYd;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			pBlSlWp4bYd = value;
		}
	}

	public byte[] TileEntities
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return PfVSlpYlYUJ;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			PfVSlpYlYUJ = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Ib8r6ijzN8XDyCxCIdE()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		pBlSlWp4bYd = new Block[256];
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Ib8r6ijzN8XDyCxCIdE(ChunkYLayer P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		pBlSlWp4bYd = new Block[256];
		MZcSlVmny7u = P_0.Layer;
		pBlSlWp4bYd = P_0.Blocks;
		PfVSlpYlYUJ = jfCSnzTcOMu(P_0.TileEntities);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private byte[] jfCSnzTcOMu(TagNodeList P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return NbtClipboardData.SerializeNode(P_0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ChunkYLayer XBlSlTloAAP()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ChunkYLayer chunkYLayer = new ChunkYLayer();
		chunkYLayer.Layer = MZcSlVmny7u;
		chunkYLayer.Blocks = pBlSlWp4bYd;
		TagNode tagNode = NbtClipboardData.DeserializeNode(TileEntities);
		chunkYLayer.TileEntities = tagNode as TagNodeList;
		return chunkYLayer;
	}
}
