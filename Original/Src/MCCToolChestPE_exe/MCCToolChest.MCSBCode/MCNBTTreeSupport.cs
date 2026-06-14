using System;
using System.IO;
using System.Runtime.CompilerServices;
using afNMf7uWOyq6L7IHxiu;
using MCCToolChest.model;
using MCCToolChest.utils;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.MCSBCode;

public class MCNBTTreeSupport
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public MemoryStream ConvertChunk(ChunkData chunkData, string filepath)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound tree = null;
		if (Working.RXpStXcJiRk() == PlatformType.PC)
		{
			tree = lxe7hMuSirBXGUQugsD.VM0SPR2pYyo(chunkData.SQ7S0L9d7YF(), chunkData.Path);
		}
		else if (Working.RXpStXcJiRk() == PlatformType.PE)
		{
			tree = lxe7hMuSirBXGUQugsD.ypwSP3uBdKl(chunkData, filepath);
		}
		NbtTree nbtTree = new NbtTree(tree);
		MemoryStream memoryStream = new MemoryStream();
		nbtTree.WriteTo(memoryStream);
		return memoryStream;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void T4aSi2Hj9Xe(byte[] P_0, string P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string path = P_1 + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88600);
		FileUtils.TTSSgQ9uTyR(P_1);
		using BinaryWriter binaryWriter = new BinaryWriter(File.Open(path, FileMode.Create));
		binaryWriter.Write(P_0, 0, P_0.Length);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hp1SiyJ6nFP(byte[] P_0, string P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string path = P_1 + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88632);
		FileUtils.TTSSgQ9uTyR(P_1);
		using BinaryWriter binaryWriter = new BinaryWriter(File.Open(path, FileMode.Create));
		binaryWriter.Write(P_0, 0, P_0.Length);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNodeCompound PWeSi0mtu4w(MemoryStream P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound tagNodeCompound = null;
		return tGsSiBNXif4(P_0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNodeCompound tGsSiBNXif4(MemoryStream P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound result = null;
		if (P_0 != null)
		{
			try
			{
				NbtTree nbtTree = new NbtTree(P_0);
				result = nbtTree.Root;
			}
			catch (Exception)
			{
			}
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MCNBTTreeSupport()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}
}
