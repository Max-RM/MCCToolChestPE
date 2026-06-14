using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using MCCToolChest.model;
using MCCToolChest.PECode;
using MCPELevelDBI.workers;
using Substrate.Nbt;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.scripting;

public class ScriptDBWorker
{
	private static List<byte[]> WuVSgVg0ktP;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptDBWorker()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		if (WuVSgVg0ktP == null)
		{
			WuVSgVg0ktP = new List<byte[]>();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void HBwSgwv7Fhe()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LevelDBWorker levelDBWorker = PEUtility.OpenDBWorker(Working.T92StMGt1p4());
		IntPtr batch = levelDBWorker.CreateWriteBatch();
		for (int i = 0; i < WuVSgVg0ktP.Count; i += 2)
		{
			levelDBWorker.WriteBatchPut(batch, WuVSgVg0ktP[i], WuVSgVg0ktP[i + 1]);
		}
		levelDBWorker.WriteBatch(batch);
		levelDBWorker.DestroyWriteBatch(batch);
		WuVSgVg0ktP.Clear();
		levelDBWorker.CloseDB();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CheckBatch(bool force = false)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (WuVSgVg0ktP != null && (WuVSgVg0ktP.Count > 1000 || force))
		{
			HBwSgwv7Fhe();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void WriteTileEntities(int dimension, int chunkX, int chunkZ, TagNodeList tileEntities)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MemoryStream memoryStream = new MemoryStream();
		for (int i = 0; i < tileEntities.Count; i++)
		{
			MemoryStream memoryStream2 = new MemoryStream();
			TagNodeCompound tree = tileEntities[i] as TagNodeCompound;
			NbtTree nbtTree = new NbtTree(tree);
			nbtTree.WriteTo(memoryStream2);
			memoryStream.Write(memoryStream2.ToArray(), 0, (int)memoryStream2.Length);
		}
		if (memoryStream.Length > 0)
		{
			byte[] array = PEUtility.BuildChunkKey(dimension, chunkX, chunkZ, 49);
			PEuSg4wiRpX(array, memoryStream.ToArray());
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void WriteEntities(int dimension, int chunkX, int chunkZ, TagNodeList entities)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MemoryStream memoryStream = new MemoryStream();
		for (int i = 0; i < entities.Count; i++)
		{
			MemoryStream memoryStream2 = new MemoryStream();
			TagNodeCompound tree = entities[i] as TagNodeCompound;
			NbtTree nbtTree = new NbtTree(tree);
			nbtTree.WriteTo(memoryStream2);
			memoryStream.Write(memoryStream2.ToArray(), 0, (int)memoryStream2.Length);
		}
		if (memoryStream.Length > 0)
		{
			byte[] array = PEUtility.BuildChunkKey(dimension, chunkX, chunkZ, 50);
			PEuSg4wiRpX(array, memoryStream.ToArray());
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PEuSg4wiRpX(byte[] P_0, byte[] P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		WuVSgVg0ktP.Add(P_0);
		WuVSgVg0ktP.Add(P_1);
		CheckBatch();
	}
}
