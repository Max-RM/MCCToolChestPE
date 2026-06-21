using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using afNMf7uWOyq6L7IHxiu;
using MCCToolChest.model;
using MCCToolChest.PECode;
using MCCToolChest.scripting;
using MCPELevelDBI.workers;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.MCSBCode;

public class DumpAsText
{
	private string U7w962j2PY;

	private Dictionary<int, TagNodeCompound> bR29Nd50Yc;

	private BackgroundWorker PWv9DIptag;

	public StringBuilder chunkChanges;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DumpAsText()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		bR29Nd50Yc = new Dictionary<int, TagNodeCompound>();
		chunkChanges = new StringBuilder();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DumpAsText(BackgroundWorker bw)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		bR29Nd50Yc = new Dictionary<int, TagNodeCompound>();
		chunkChanges = new StringBuilder();
		PWv9DIptag = bw;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DoDump(string path)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		U7w962j2PY = path;
		PEDimension pEDimension = PEUtility.GetPEDimension(Constants.dimensionFolderNames[0]);
		DoDump(pEDimension, Working.T92StMGt1p4());
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DoDump(PEDimension peDimension, string workingFolder)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		try
		{
			u7M9RhJXvG();
		}
		catch (Exception)
		{
		}
		LevelDBWorker levelDBWorker = PEUtility.OpenDBWorker(workingFolder);
		try
		{
			foreach (PERegion value in peDimension.Region.Values)
			{
				value.ToString();
				a8N9Ps4y4E(peDimension, value, levelDBWorker);
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			levelDBWorker.CloseDB();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void a8N9Ps4y4E(PEDimension P_0, PERegion P_1, LevelDBWorker P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		for (int i = 0; i < 32; i++)
		{
			for (int j = 0; j < 32; j++)
			{
				lQ19k1evKg(P_0, P_1, lxe7hMuSirBXGUQugsD.QdsSP76hcgY(i, P_1.RX), lxe7hMuSirBXGUQugsD.QdsSP76hcgY(j, P_1.RZ), P_2);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void u7M9RhJXvG()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound tagNodeCompound = null;
		tagNodeCompound = ((!Working.CLIActive) ? PEUtility.LoadPELevel(Working.T92StMGt1p4()) : PEUtility.LoadPELevelRaw(Working.T92StMGt1p4()));
		if (tagNodeCompound != null)
		{
			rRS9rRwjSb(U7w962j2PY, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63766), tagNodeCompound);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void lQ19k1evKg(PEDimension P_0, PERegion P_1, int P_2, int P_3, LevelDBWorker P_4)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = lxe7hMuSirBXGUQugsD.e1cSPCO6PUl(P_2, P_1.RX);
		int num2 = lxe7hMuSirBXGUQugsD.e1cSPCO6PUl(P_3, P_1.RZ);
		int num3 = lxe7hMuSirBXGUQugsD.rMDSPOktq2F(num, num2);
		if (P_1.Chunks[num3] == 1)
		{
			fn69Y14JNC(P_0.Dimension, num, num2, P_4);
			ztW93XNJCx(P_0.Dimension, num, num2, P_4);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void fn69Y14JNC(int P_0, int P_1, int P_2, LevelDBWorker P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] array = PEUtility.BuildChunkKey(P_0, P_1, P_2, 50);
		TagNodeList tagNodeList = N5t91uWnWu(array, P_3);
		nPk9ENoAh5(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42124), P_0, P_1, P_2, tagNodeList);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ztW93XNJCx(int P_0, int P_1, int P_2, LevelDBWorker P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] array = PEUtility.BuildChunkKey(P_0, P_1, P_2, 49);
		TagNodeList tagNodeList = N5t91uWnWu(array, P_3);
		nPk9ENoAh5(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63796), P_0, P_1, P_2, tagNodeList);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNodeList N5t91uWnWu(byte[] P_0, LevelDBWorker P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeList tagNodeList = null;
		byte[] blockEntity = P_1.ReadDbValue(P_0);
		return PEUtility.ExtractTileEntities(blockEntity);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void nPk9ENoAh5(string P_0, int P_1, int P_2, int P_3, TagNodeList P_4)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = string.Format(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63824), P_2, P_3);
		string text2 = Path.Combine(U7w962j2PY, Constants.scriptDimensionNames[P_1], P_0);
		rRS9rRwjSb(text2, text, P_4);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void rRS9rRwjSb(string P_0, string P_1, TagNode P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		NBT2TextWriter nBT2TextWriter = new NBT2TextWriter();
		string text = nBT2TextWriter.ProcessNBT(P_2);
		if (!string.IsNullOrWhiteSpace(text))
		{
			Directory.CreateDirectory(P_0);
			File.WriteAllText(Path.Combine(P_0, P_1), text);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void aQD9510sev(string P_0, int P_1 = 0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (PWv9DIptag != null)
		{
			PWv9DIptag.ReportProgress(P_1, P_0);
		}
	}
}
