using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using afNMf7uWOyq6L7IHxiu;
using MCCToolChest.constants;
using MCCToolChest.MCSBCode.JSONParser;
using MCCToolChest.model;
using MCCToolChest.PECode;
using MCCToolChest.scripting;
using MCCToolChest.utils;
using MCCToolChest.workers;
using MCPELevelDBI.workers;
using OAxWrWumnobfHyEL9yr;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.MCSBCode;

public class ConvertToPEFromPC
{
	private delegate void pR72jojXaHtLDyIfVDV(string javaBlockName, BlockState bs, Dictionary<string, BlockStateProperty> properties);

	private Dictionary<string, pR72jojXaHtLDyIfVDV> CFlSTlFH3XY;

	private int ScjST2tVKaB;

	private int PCTSTy7tZy3;

	private int LC2ST0kjKot;

	private int TXtSTBfRA4B;

	public static Dictionary<string, short> BannerXRef;

	public static Dictionary<string, FlowerPotContent> FlowerPotXRef;

	private static Dictionary<string, int> ShrSTt2r2aD;

	public static Dictionary<string, int> facingIndex;

	public static Dictionary<string, short> LeverXRef;

	public static Dictionary<string, short> buttonPoweredXRef;

	public static Dictionary<string, short> ButtonFaceFCXRef;

	public static List<ConversionChest> activeChests;

	private List<byte[]> wBISTaxkeuN;

	private Dictionary<int, List<int>> IteSTXI2wW1;

	private BedrockFromJavaItemConverter IRGSTxndelo;

	private ConvertToPEParameters icbSTevXVuM;

	private EntityLookup cxsSTMTc21b;

	private PETileEntityConverters yP8STUKkFKA;

	private bool[] QKgSTL0SUiA;

	private int yhQSTgRCgZG;

	private int HlqSTPgtL0K;

	private BlockChange tT6STRkPhx6;

	private int AwYSTk0o3nf;

	private byte[] mS9STYBkPbk;

	private byte[] H21ST3UiYHv;

	private List<BlockState> pqdST1vdGSd;

	private FlowerPotContent[] xqpSTEGKBJs;

	private int qxSSTrREcB7;

	private int hCQST5i5bdq;

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MFVzhpvXhp(int P_0, int P_1, int P_2, int P_3, Dictionary<string, BlockStateProperty> P_4, TagNodeList P_5)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MCCoordinate coord = new MCCoordinate(P_0, P_1, P_2, P_3);
		MCCoordinate link = null;
		if (P_3 == ScjST2tVKaB)
		{
			link = new MCCoordinate(P_0 + 1, P_1, P_2, P_3);
		}
		else if (P_3 == PCTSTy7tZy3)
		{
			link = new MCCoordinate(P_0 - 1, P_1, P_2, P_3);
		}
		else if (P_3 == TXtSTBfRA4B)
		{
			link = new MCCoordinate(P_0, P_1, P_2 - 1, P_3);
		}
		else if (P_3 == LC2ST0kjKot)
		{
			link = new MCCoordinate(P_0, P_1, P_2 + 1, P_3);
		}
		activeChests.Add(new ConversionChest(coord, link));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void badzmlcRtB(int P_0, int P_1, int P_2, int P_3, Dictionary<string, BlockStateProperty> P_4, TagNodeList P_5)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MCCoordinate coord = new MCCoordinate(P_0, P_1, P_2, P_3);
		MCCoordinate link = null;
		if (P_3 == ScjST2tVKaB)
		{
			link = new MCCoordinate(P_0 - 1, P_1, P_2, P_3);
		}
		else if (P_3 == PCTSTy7tZy3)
		{
			link = new MCCoordinate(P_0 + 1, P_1, P_2, P_3);
		}
		else if (P_3 == TXtSTBfRA4B)
		{
			link = new MCCoordinate(P_0, P_1, P_2 + 1, P_3);
		}
		else if (P_3 == LC2ST0kjKot)
		{
			link = new MCCoordinate(P_0, P_1, P_2 - 1, P_3);
		}
		activeChests.Add(new ConversionChest(coord, link));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DK4znlPdl0(int P_0, int P_1, int P_2, int P_3, TagNodeList P_4)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		activeChests.Add(new ConversionChest(new MCCoordinate(P_0, P_1, P_2, P_3), null));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void VW9zlF6BrZ(int P_0, int P_1, int P_2, int P_3, Dictionary<string, BlockStateProperty> P_4, TagNodeList P_5)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string value = P_4[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64470)].Value;
		if (!AquaticConversionData.skullXRef.ContainsKey(value))
		{
			return;
		}
		TagNodeCompound tagNodeCompound = KvxSTn0E7yi(P_0, P_1, P_2, P_5);
		if (tagNodeCompound != null)
		{
			tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17354)] = new TagNodeByte((byte)AquaticConversionData.skullXRef[value].Data);
			if (P_4.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64500)))
			{
				int result = 0;
				int.TryParse(P_4[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64500)].Value, out result);
				tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64520)] = new TagNodeByte((byte)result);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Wyjz2qbrGL(int P_0, int P_1, int P_2, int P_3, Dictionary<string, BlockStateProperty> P_4, TagNodeList P_5)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound tagNodeCompound = KvxSTn0E7yi(P_0, P_1, P_2, P_5);
		if (tagNodeCompound == null)
		{
			tagNodeCompound = TileEntityConversion.CreatePEBlockEntityFromPC(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14546), P_0, P_1, P_2);
			P_5.Add(tagNodeCompound);
		}
		string value = P_4[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64470)].Value;
		if (AquaticConversionData.bedColorXRef.ContainsKey(value))
		{
			int num = AquaticConversionData.bedColorXRef[value];
			tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14532)] = new TagNodeByte((byte)num);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void qMRzyON41w(int P_0, int P_1, int P_2, int P_3, Dictionary<string, BlockStateProperty> P_4, TagNodeList P_5)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound tagNodeCompound = KvxSTn0E7yi(P_0, P_1, P_2, P_5);
		if (tagNodeCompound == null)
		{
			tagNodeCompound = TileEntityConversion.CreatePEBlockEntityFromPC(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64530), P_0, P_1, P_2);
			P_5.Add(tagNodeCompound);
		}
		if (P_4[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64470)].Value == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64552))
		{
			tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64582)] = new TagNodeByte(1);
		}
		if (P_4.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64598)) && P_4[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64598)].Value == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31650))
		{
			tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64618)] = new TagNodeByte(2);
			tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64632)] = new TagNodeByte(2);
			tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64652)] = new TagNodeFloat(1f);
			tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64672)] = new TagNodeFloat(1f);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void bhSz0OgLBa(int P_0, int P_1, int P_2, int P_3, Dictionary<string, BlockStateProperty> P_4, TagNodeList P_5)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound tagNodeCompound = KvxSTn0E7yi(P_0, P_1, P_2, P_5);
		if (tagNodeCompound != null)
		{
			int d = 0;
			string value = P_4[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64470)].Value;
			if (BannerXRef.ContainsKey(value))
			{
				d = BannerXRef[value];
			}
			tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(0)] = new TagNodeInt(d);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PZczBOKXky(int P_0, int P_1, int P_2, int P_3, Dictionary<string, BlockStateProperty> P_4, TagNodeList P_5)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound tagNodeCompound = KvxSTn0E7yi(P_0, P_1, P_2, P_5, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64700));
		if (tagNodeCompound == null)
		{
			tagNodeCompound = TileEntityConversion.CreatePEBlockEntityFromPC(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64700), P_0, P_1, P_2);
			P_5.Add(tagNodeCompound);
		}
		if (tagNodeCompound == null)
		{
			return;
		}
		string value = P_4[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64470)].Value;
		string text = "";
		string text2 = "";
		if (FlowerPotXRef.ContainsKey(value))
		{
			text = FlowerPotXRef[value].name;
			text2 = FlowerPotXRef[value].flowerType;
			TagNodeCompound tagNodeCompound2 = null;
			if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64722)))
			{
				tagNodeCompound2 = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64722)] as TagNodeCompound;
			}
			else
			{
				tagNodeCompound2 = new TagNodeCompound();
				tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19892)] = new TagNodeCompound();
				tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64722)] = tagNodeCompound2;
			}
			tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19862)] = new TagNodeString(text);
			TagNodeCompound tagNodeCompound3 = tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19892)] as TagNodeCompound;
			if (!string.IsNullOrWhiteSpace(text2))
			{
				tagNodeCompound3[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64746)] = new TagNodeString(text2);
			}
			else
			{
				tagNodeCompound3.Remove(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64746));
			}
		}
		else
		{
			tagNodeCompound.Remove(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64722));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void dVOztjjYUp(string P_0, BlockState P_1, Dictionary<string, BlockStateProperty> P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bool[] array = new bool[6];
		int num = 0;
		foreach (string key in P_2.Keys)
		{
			if (ShrSTt2r2aD.ContainsKey(key))
			{
				BlockStateProperty blockStateProperty = P_2[key];
				array[ShrSTt2r2aD[blockStateProperty.Name]] = bool.Parse(blockStateProperty.Value);
			}
		}
		if (!array[0] && !array[2] && !array[3] && !array[4] && !array[5] && !array[4] && !array[1])
		{
			num = 0;
		}
		else if (!array[0] && array[2] && !array[3] && array[5])
		{
			num = 1;
		}
		else if (!array[0] && array[2] && !array[3] && !array[5])
		{
			num = 2;
		}
		else if (array[0] && array[2] && !array[3] && !array[5])
		{
			num = 3;
		}
		else if (!array[0] && !array[2] && !array[3] && array[5])
		{
			num = 4;
		}
		else if (!array[0] && !array[2] && !array[3] && !array[5])
		{
			num = 5;
		}
		else if (array[0] && !array[2] && !array[3] && !array[5])
		{
			num = 6;
		}
		else if (!array[0] && !array[2] && array[3] && array[5])
		{
			num = 7;
		}
		else if (!array[0] && !array[2] && array[3] && !array[5])
		{
			num = 8;
		}
		else if (array[0] && !array[2] && array[3] && !array[5])
		{
			num = 9;
		}
		else if (array[0] && array[2] && array[3] && array[5] && !array[4] && !array[1])
		{
			num = 10;
		}
		else if (array[0] && array[2] && array[3] && array[5])
		{
			num = 14;
		}
		else if (array[0] && array[2] && array[3] && array[5])
		{
			num = 15;
		}
		P_1.data = (short)num;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void EUdza875Kc(string P_0, BlockState P_1, Dictionary<string, BlockStateProperty> P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = hmozQVFf66(P_2, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31412), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64772));
		if (text == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31616))
		{
			P_1.name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64788) + P_1.name.Replace(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9974), "");
			P_1.data &= 7;
		}
		else if (P_1.name == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64826))
		{
			if (P_1.data == 14)
			{
				P_1.data = 15;
			}
			else if (P_1.data == 15)
			{
				P_1.data = 14;
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void tAUzXCqrYB(string P_0, BlockState P_1, Dictionary<string, BlockStateProperty> P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		short num = 0;
		string text = hmozQVFf66(P_2, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64870), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64882));
		string text2 = hmozQVFf66(P_2, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64894), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64176));
		string key = hmozQVFf66(P_2, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64910), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31662));
		string key2 = text + text2;
		short num2 = 0;
		if (LeverXRef.ContainsKey(key2))
		{
			num2 = LeverXRef[key2];
		}
		num = (short)(num2 | buttonPoweredXRef[key]);
		P_1.data = num;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void wrPzxmecys(string P_0, BlockState P_1, Dictionary<string, BlockStateProperty> P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		short num = 0;
		string text = hmozQVFf66(P_2, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64870), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64882));
		string text2 = hmozQVFf66(P_2, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64894), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64176));
		string key = hmozQVFf66(P_2, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64910), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31662));
		string key2 = text + text2;
		short num2 = 0;
		if (ButtonFaceFCXRef.ContainsKey(key2))
		{
			num2 = ButtonFaceFCXRef[key2];
		}
		num = (short)(num2 | buttonPoweredXRef[key]);
		P_1.data = num;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExtractPCRegion(object threadContext)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (threadContext is ConvertToPEParameters convertToPEParameters)
		{
			icbSTevXVuM = convertToPEParameters;
			try
			{
				ExtractPCRegion(convertToPEParameters.PEDimension, convertToPEParameters.RegionName, convertToPEParameters.DimensionName, convertToPEParameters.PCRegionFolder, convertToPEParameters.WorkingFolder, convertToPEParameters.ConvertParameters);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63960));
			}
			convertToPEParameters.Records = wBISTaxkeuN;
			convertToPEParameters.DoneEvent.Set();
			convertToPEParameters.Done = true;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void WritePEBatch(object threadContext)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!(threadContext is ConvertToPEParameters convertToPEParameters))
		{
			return;
		}
		try
		{
			LevelDBWorker dbWorker = convertToPEParameters.DbWorker;
			if (convertToPEParameters.Records.Count > 0)
			{
				IntPtr batch = dbWorker.CreateWriteBatch();
				for (int i = 0; i < convertToPEParameters.Records.Count; i += 2)
				{
					dbWorker.WriteBatchPut(batch, convertToPEParameters.Records[i], convertToPEParameters.Records[i + 1]);
				}
				dbWorker.WriteBatch(batch);
				dbWorker.DestroyWriteBatch(batch);
				convertToPEParameters.Records.Clear();
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63960));
		}
		convertToPEParameters.Done = true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExtractPCRegion(int dimension, string regionName, string regionfolder, string pcRegionFolder, string workingFolder, ConvertParameters convertParameters)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (FileUtils.CheckFolderExists(pcRegionFolder))
		{
			if (!(regionfolder.ToLower() == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21936)))
			{
				_ = regionfolder + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64928);
			}
			string text = FileUtils.CheckFolderSep(pcRegionFolder) + regionName + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64946);
			if (File.Exists(text))
			{
				l9czexcK84(dimension, regionName, regionfolder, text, workingFolder, convertParameters);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void l9czexcK84(int P_0, string P_1, string P_2, string P_3, string P_4, ConvertParameters P_5)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		new MemoryStream();
		List<ChunkIndexEntry> list = null;
		list = lxe7hMuSirBXGUQugsD.kM7SgjjqASt(P_3);
		QKgSTL0SUiA = Utils.GetQuickBlocksLookup(P_5);
		tT6STRkPhx6 = DJSz9CE6gG(P_5);
		yhQSTgRCgZG = Working.rvNSt1TVRGQ();
		HlqSTPgtL0K = Working.P5gSt5TkeBq();
		if (list == null || list.Count <= 0)
		{
			return;
		}
		using (BinaryReader binaryReader = new BinaryReader(File.Open(P_3, FileMode.Open)))
		{
			for (int i = 0; i < list.Count; i++)
			{
				ChunkData chunkData = new ChunkData();
				chunkData.WxMS0gYhqtY(list[i]);
				try
				{
					H8pzMK2bjR(P_0, chunkData, binaryReader, P_5);
				}
				catch (Exception)
				{
				}
			}
		}
		if (icbSTevXVuM != null)
		{
			icbSTevXVuM.ProcessingCompleted = true;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private byte[] H8pzMK2bjR(int P_0, ChunkData P_1, BinaryReader P_2, ConvertParameters P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] array = null;
		if (P_1.SQ7S0L9d7YF().OldChunkOffset != 0)
		{
			P_2.BaseStream.Position = P_1.SQ7S0L9d7YF().OldChunkOffset * 4096;
			byte[] array2 = new byte[4];
			P_2.Read(array2, 0, array2.Length);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(array2);
			}
			int num = BitConverter.ToInt32(array2, 0);
			byte b = P_2.ReadByte();
			array = new byte[num - 1];
			P_2.Read(array, 0, array.Length);
			array = ((b != 1) ? lxe7hMuSirBXGUQugsD.KpwSP5kgJSU(array) : lxe7hMuSirBXGUQugsD.RacSP6aHwsa(array));
			bool flag = qJIzUWmHK3(P_0, P_1, array, P_3);
			if (icbSTevXVuM != null && flag)
			{
				icbSTevXVuM.ProcessedChunkCount++;
			}
			else
			{
				icbSTevXVuM.InvalidChunkCount++;
			}
		}
		return array;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal bool qJIzUWmHK3(int P_0, ChunkData P_1, byte[] P_2, ConvertParameters P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bool result = true;
		MemoryStream memoryStream = new MemoryStream();
		memoryStream.Write(P_2, 0, P_2.Length);
		memoryStream.WriteByte(0);
		memoryStream.Seek(0L, SeekOrigin.Begin);
		NbtTree nbtTree = new NbtTree();
		nbtTree.UseBigEndian = true;
		nbtTree.ReadFrom(memoryStream);
		int num = 65536;
		TagNodeCompound root = nbtTree.Root;
		AwYSTk0o3nf = 0;
		if (root.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64958)))
		{
			AwYSTk0o3nf = root[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64958)] as TagNodeInt;
		}
		if (AwYSTk0o3nf < 1444)
		{
			rwhzL40QmW(P_0, nbtTree.Root, num, P_3);
		}
		else
		{
			result = zWLzgKDGF9(P_0, nbtTree.Root, num, P_3);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void rwhzL40QmW(int P_0, TagNodeCompound P_1, int P_2, ConvertParameters P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		new NibbleSetters();
		TagNodeCompound tagNodeCompound = P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18204)] as TagNodeCompound;
		int num = (TagNodeInt)tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64984)];
		int num2 = (TagNodeInt)tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64996)];
		TagNodeByteArray tagNodeByteArray = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41992)] as TagNodeByteArray;
		TagNodeIntArray tagNodeIntArray = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65008)] as TagNodeIntArray;
		hB2zExgCZO(P_0, num, num2, tagNodeByteArray, tagNodeIntArray, P_3);
		List<BlockItemInject> list = new List<BlockItemInject>();
		TagNodeList tagNodeList = new TagNodeList(TagType.TAG_COMPOUND);
		if (P_3.ConvertTileEntities)
		{
			tagNodeList = KwEzIY3GQD(tagNodeCompound, P_3);
			TagNodeList tagNodeList2 = (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42124)) ? (tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42124)] as TagNodeList) : new TagNodeList(TagType.TAG_COMPOUND));
			xfwzRyToXa(list, tagNodeList, tagNodeList2, 1443);
		}
		if (P_3.ConvertEntities)
		{
			TagNodeList tagNodeList3 = PpsSTsNS3ne(tagNodeCompound, P_3);
			skJz3VMArM(P_0, num, num2, tagNodeList3);
		}
		TagNodeList tagNodeList4 = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20548)] as TagNodeList;
		pLvz6QZZKl(P_0, num, num2, tagNodeList4, tagNodeList, list, P_3);
		if (P_3.ConvertTileEntities)
		{
			TH7zkrEnst(P_0, num, num2, tagNodeList);
		}
		Qowz1TIMc2(P_0, num, num2, 7);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool zWLzgKDGF9(int P_0, TagNodeCompound P_1, int P_2, ConvertParameters P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		new NibbleSetters();
		TagNodeCompound tagNodeCompound = P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18204)] as TagNodeCompound;
		if (!tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20548)) || ((TagNodeList)tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20548)]).Count == 0)
		{
			return false;
		}
		int num = (TagNodeInt)tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64984)];
		int num2 = (TagNodeInt)tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64996)];
		TagNodeIntArray tagNodeIntArray = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41992)] as TagNodeIntArray;
		TagNodeLongArray tagNodeLongArray = null;
		TagNodeLongArray tagNodeLongArray2 = null;
		if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65030)))
		{
			TagNodeCompound tagNodeCompound2 = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65030)] as TagNodeCompound;
			if (tagNodeCompound2.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65054)))
			{
				_ = tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65054)];
			}
			if (tagNodeCompound2.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65086)))
			{
				_ = tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65086)];
			}
			if (tagNodeCompound2.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65120)))
			{
				_ = tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65120)];
			}
			if (tagNodeCompound2.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65174)))
			{
				_ = tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65174)];
			}
			if (tagNodeCompound2.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65200)))
			{
				_ = tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65200)];
			}
			if (tagNodeCompound2.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65232)))
			{
				tagNodeLongArray = tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65232)] as TagNodeLongArray;
			}
			if (tagNodeCompound2.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65262)))
			{
				tagNodeLongArray2 = tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65262)] as TagNodeLongArray;
			}
		}
		int[] d = new int[256];
		if (tagNodeLongArray != null || tagNodeLongArray2 != null)
		{
			d = P2CzPI2Sua((tagNodeLongArray != null) ? tagNodeLongArray : tagNodeLongArray2, 9);
		}
		TagNodeIntArray tagNodeIntArray2 = new TagNodeIntArray(d);
		byte[] array = new byte[256];
		if (tagNodeIntArray != null && tagNodeIntArray.Length >= 256)
		{
			for (int i = 0; i < 256; i++)
			{
				array[i] = (byte)tagNodeIntArray[i];
			}
		}
		TagNodeByteArray tagNodeByteArray = new TagNodeByteArray(array);
		hB2zExgCZO(P_0, num, num2, tagNodeByteArray, tagNodeIntArray2, P_3);
		List<BlockItemInject> list = new List<BlockItemInject>();
		TagNodeList tagNodeList = new TagNodeList(TagType.TAG_COMPOUND);
		if (P_3.ConvertTileEntities)
		{
			tagNodeList = KwEzIY3GQD(tagNodeCompound, P_3);
			TagNodeList tagNodeList2 = (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42124)) ? (tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42124)] as TagNodeList) : new TagNodeList(TagType.TAG_COMPOUND));
			xfwzRyToXa(list, tagNodeList, tagNodeList2, 1444);
		}
		if (P_3.ConvertEntities)
		{
			TagNodeList tagNodeList3 = PpsSTsNS3ne(tagNodeCompound, P_3);
			skJz3VMArM(P_0, num, num2, tagNodeList3);
		}
		TagNodeList tagNodeList4 = null;
		tagNodeList4 = ((!tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20548))) ? new TagNodeList(TagType.TAG_COMPOUND) : (tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20548)] as TagNodeList));
		iFCz53rM5W(P_0, num, num2, tagNodeList4, tagNodeList, list, P_3);
		if (P_3.ConvertTileEntities)
		{
			TH7zkrEnst(P_0, num, num2, tagNodeList);
		}
		Qowz1TIMc2(P_0, num, num2, 15);
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int[] P2CzPI2Sua(long[] P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<int> list = new List<int>();
		int num = 0;
		int num2 = 0;
		uint num3 = (uint)((1 << P_1) - 1);
		int num4 = 0;
		for (int i = 0; i < P_0.Length * 64 / P_1; i++)
		{
			if (num + P_1 <= 64)
			{
				num4 = (int)((P_0[num2] >> num) & num3);
				num += P_1;
				if (num >= 64)
				{
					num = 0;
					num2++;
				}
			}
			else
			{
				int num5 = 64 - num;
				uint num6 = (uint)((1 << num5) - 1);
				int num7 = (int)((P_0[num2] >> num) & num6);
				int num8 = num + P_1 - 64;
				num = 0;
				num2++;
				uint num9 = (uint)((1 << num8) - 1);
				int num10 = (int)((P_0[num2] >> num) & num9);
				num4 = (num10 << num5) + num7;
				num = num8;
			}
			list.Add(num4);
		}
		return list.ToArray();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void xfwzRyToXa(List<BlockItemInject> P_0, TagNodeList P_1, TagNodeList P_2, int P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		for (int num = P_2.Count - 1; num >= 0; num--)
		{
			if (P_2[num] is TagNodeCompound && P_2[num] is TagNodeCompound tagNodeCompound)
			{
				try
				{
					string text = (TagNodeString)tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)];
					if (text == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65298))
					{
						TagNodeList tagNodeList = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17418)] as TagNodeList;
						double num2 = tagNodeList[0] as TagNodeDouble;
						double num3 = tagNodeList[1] as TagNodeDouble;
						double num4 = tagNodeList[2] as TagNodeDouble;
						if (num2 < 0.0)
						{
							num2 -= 1.0;
						}
						if (num4 < 0.0)
						{
							num4 -= 1.0;
						}
						if (icbSTevXVuM.ConvertParameters.UseConvertOffsets)
						{
							num2 = (double)lxe7hMuSirBXGUQugsD.KmDSPjYqJTp((int)num2, icbSTevXVuM.ConvertParameters.XRegionOffset) + (num2 - (double)(int)num2);
							num4 = (double)lxe7hMuSirBXGUQugsD.KmDSPjYqJTp((int)num4, icbSTevXVuM.ConvertParameters.ZRegionOffset) + (num4 - (double)(int)num4);
						}
						TagNodeCompound tagNodeCompound2 = TileEntityConversion.CreatePEBlockEntityFromPC(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(5366), (int)num2, (int)num3, (int)num4);
						if (tagNodeCompound2 != null)
						{
							if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65342)))
							{
								tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65342)] = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65342)];
							}
							if (!dDHSTfS6pok(tagNodeCompound, tagNodeCompound2))
							{
								tagNodeCompound2.Remove(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(4702));
							}
							P_1.Add(tagNodeCompound2);
							byte data = 0;
							if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65370)))
							{
								byte b = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65370)] as TagNodeByte;
								data = ((P_3 < 1444) ? mS9STYBkPbk[b] : H21ST3UiYHv[b]);
							}
							BlockItemInject blockItemInject = new BlockItemInject();
							blockItemInject.X = (int)num2;
							blockItemInject.Y = (int)num3;
							blockItemInject.Z = (int)num4;
							blockItemInject.Id = 199;
							blockItemInject.Data = data;
							blockItemInject.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65386);
							BlockItemInject item = blockItemInject;
							P_0.Add(item);
						}
					}
				}
				catch (Exception)
				{
					throw;
				}
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TH7zkrEnst(int P_0, int P_1, int P_2, TagNodeList P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MemoryStream memoryStream = new MemoryStream();
		for (int i = 0; i < P_3.Count; i++)
		{
			MemoryStream memoryStream2 = new MemoryStream();
			TagNodeCompound tree = P_3[i] as TagNodeCompound;
			NbtTree nbtTree = new NbtTree(tree);
			nbtTree.WriteTo(memoryStream2);
			memoryStream.Write(memoryStream2.ToArray(), 0, (int)memoryStream2.Length);
		}
		if (memoryStream.Length > 0)
		{
			byte[] array = PWQzYt99rn(P_0, P_1, P_2, 49);
			MDvzj3x75g(array, memoryStream.ToArray());
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private byte[] PWQzYt99rn(int P_0, int P_1, int P_2, byte P_3, byte? P_4 = null)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] array = null;
		if (icbSTevXVuM.ConvertParameters.UseConvertOffsets)
		{
			P_1 = lxe7hMuSirBXGUQugsD.vADSPFUS622(P_1, icbSTevXVuM.ConvertParameters.XRegionOffset);
			P_2 = lxe7hMuSirBXGUQugsD.vADSPFUS622(P_2, icbSTevXVuM.ConvertParameters.ZRegionOffset);
		}
		return PEUtility.BuildChunkKey(P_0, P_1, P_2, P_3, P_4);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void skJz3VMArM(int P_0, int P_1, int P_2, TagNodeList P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MemoryStream memoryStream = new MemoryStream();
		for (int i = 0; i < P_3.Count; i++)
		{
			MemoryStream memoryStream2 = new MemoryStream();
			TagNodeCompound tree = P_3[i] as TagNodeCompound;
			NbtTree nbtTree = new NbtTree(tree);
			nbtTree.WriteTo(memoryStream2);
			memoryStream.Write(memoryStream2.ToArray(), 0, (int)memoryStream2.Length);
		}
		if (memoryStream.Length > 0)
		{
			byte[] array = PWQzYt99rn(P_0, P_1, P_2, 50);
			MDvzj3x75g(array, memoryStream.ToArray());
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Qowz1TIMc2(int P_0, int P_1, int P_2, byte P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] array = new byte[1] { P_3 };
		byte[] array2 = PWQzYt99rn(P_0, P_1, P_2, 118);
		MDvzj3x75g(array2, array);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hB2zExgCZO(int P_0, int P_1, int P_2, byte[] P_3, int[] P_4, ConvertParameters P_5)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		NJVJiCuZKORGPYB1Y4v nJVJiCuZKORGPYB1Y4v = new NJVJiCuZKORGPYB1Y4v(false);
		byte[] array = new byte[256];
		for (int i = 0; i < 16; i++)
		{
			for (int j = 0; j < 16; j++)
			{
				int num = (j << 4) | i;
				int num2 = (j << 4) | i;
				byte b = P_3[num];
				if (b >= 44 && b <= 50)
				{
					b -= 4;
				}
				if (P_5.ReplaceBiomes)
				{
					for (int k = 0; k < P_5.BiomeChanges.Count; k++)
					{
						if (P_5.BiomeChanges[k].FromBiome == 1000 || P_5.BiomeChanges[k].FromBiome == b)
						{
							b = (byte)P_5.BiomeChanges[k].ToBiome;
							break;
						}
					}
				}
				array[num2] = b;
			}
		}
		MemoryStream memoryStream = new MemoryStream();
		for (int l = 0; l < 256; l++)
		{
			nJVJiCuZKORGPYB1Y4v.CyBSRMDUOvV((short)P_4[l], memoryStream);
		}
		memoryStream.Write(array, 0, array.Length);
		byte[] array2 = PWQzYt99rn(P_0, P_1, P_2, 45);
		MDvzj3x75g(array2, memoryStream.ToArray());
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SqEzrqB4py(int P_0, int P_1, int P_2, TagNodeList P_3, TagNodeList P_4, List<BlockItemInject> P_5, ConvertParameters P_6)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Dictionary<int, TagNodeCompound> dictionary = new Dictionary<int, TagNodeCompound>();
		int num = 0;
		for (int i = 0; i < P_3.Count; i++)
		{
			TagNodeCompound tagNodeCompound = P_3[i] as TagNodeCompound;
			byte b = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38782)] as TagNodeByte;
			dictionary.Add(b, tagNodeCompound);
			if (b > num)
			{
				num = b;
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void iFCz53rM5W(int P_0, int P_1, int P_2, TagNodeList P_3, TagNodeList P_4, List<BlockItemInject> P_5, ConvertParameters P_6)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<MCCoordinate> list = new List<MCCoordinate>();
		Dictionary<int, TagNodeCompound> dictionary = new Dictionary<int, TagNodeCompound>();
		int num = Q6uzD20SUh(P_3, dictionary);
		for (byte b = 0; b <= num; b++)
		{
			byte[] array = null;
			array = ((!dictionary.ContainsKey(b)) ? f6kzNcjuCu(b) : aD9zu37Ccf(P_1, P_2, dictionary[b], P_4, P_5, list));
			if (array != null && array.Length > 0)
			{
				byte[] array2 = PWQzYt99rn(P_0, P_1, P_2, 47, b);
				MDvzj3x75g(array2, array);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void pLvz6QZZKl(int P_0, int P_1, int P_2, TagNodeList P_3, TagNodeList P_4, List<BlockItemInject> P_5, ConvertParameters P_6)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<MCCoordinate> list = new List<MCCoordinate>();
		Dictionary<int, TagNodeCompound> dictionary = new Dictionary<int, TagNodeCompound>();
		int num = Q6uzD20SUh(P_3, dictionary);
		for (byte b = 0; b <= num; b++)
		{
			byte[] array = null;
			array = (dictionary.ContainsKey(b) ? ((P_6.ConvertToFormat != ConversionFormat.PreAquatic) ? hhyzCQC7qd(P_1, P_2, dictionary[b], P_4, P_5, list) : YVtzc2NuL0(P_1, P_2, dictionary[b], P_4, P_5, list)) : ((P_6.ConvertToFormat == ConversionFormat.PreAquatic) ? Un8zF0mjhM() : f6kzNcjuCu(b)));
			if (array != null && array.Length > 0)
			{
				byte[] array2 = PWQzYt99rn(P_0, P_1, P_2, 47, b);
				MDvzj3x75g(array2, array);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private byte[] f6kzNcjuCu(int P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound tagNodeCompound = null;
		tagNodeCompound = new TagNodeCompound();
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38782)] = new TagNodeByte((byte)P_0);
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(35604)] = new TagNodeByte(8);
		TagNodeList tagNodeList = new TagNodeList(TagType.TAG_COMPOUND);
		TagNodeCompound tagNodeCompound2 = new TagNodeCompound();
		tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38858)] = PEUtility.BuildNBTPalette(pqdST1vdGSd, icbSTevXVuM.ConvertParameters.ConvertToFormat);
		tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38832)] = new TagNodeIntArray(new int[4096]);
		tagNodeList.Add(tagNodeCompound2);
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38804)] = tagNodeList;
		return PEUtility.BuildBlockStateChunk(tagNodeCompound);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int Q6uzD20SUh(TagNodeList P_0, Dictionary<int, TagNodeCompound> P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = -1;
		for (int i = 0; i < P_0.Count; i++)
		{
			TagNodeCompound tagNodeCompound = P_0[i] as TagNodeCompound;
			byte b = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38782)] as TagNodeByte;
			if (b >= 0 && b <= 15)
			{
				P_1.Add(b, tagNodeCompound);
				if (b > num)
				{
					num = b;
				}
			}
		}
		return num;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private byte[] YVtzc2NuL0(int P_0, int P_1, TagNodeCompound P_2, TagNodeList P_3, List<BlockItemInject> P_4, List<MCCoordinate> P_5)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = ((P_0 >= 0) ? (P_0 * 16) : ((P_0 + 1) * 16));
		int num2 = ((P_1 >= 0) ? (P_1 * 16) : ((P_1 + 1) * 16));
		_ = icbSTevXVuM.ConvertParameters;
		NibbleSetters nibbleSetters = new NibbleSetters();
		if (((TagNodeByteArray)P_2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11178)]).Data.Length == 0)
		{
			P_2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11178)] = new TagNodeByteArray(new byte[2048]);
		}
		int num3 = P_2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38782)] as TagNodeByte;
		byte[] array = new byte[4096];
		byte[] array2 = new byte[2048];
		byte[] array3 = P_2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38788)] as TagNodeByteArray;
		byte[] data = P_2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11178)] as TagNodeByteArray;
		for (int i = 0; i < 16; i++)
		{
			for (int j = 0; j < 16; j++)
			{
				for (int k = 0; k < 16; k++)
				{
					int num4 = i * 256 + j * 16 + k;
					int num5 = k * 256 + j * 16 + i;
					byte b = array3[num5];
					int num6 = nibbleSetters.TU17GetFast(data, num5);
					byte b2 = 0;
					byte b3 = 0;
					BlockConversionDefinition blockConversionDefinition = BlockMaster.BedrockFromJavaBlock(b, num6);
					if (blockConversionDefinition.id < 256)
					{
						b2 = (byte)blockConversionDefinition.id;
						b3 = (byte)blockConversionDefinition.data;
					}
					if (b2 == 175)
					{
						b3 = Jtiz78h0jk(b3, i, k, j, P_5);
					}
					array[num4] = b2;
					nibbleSetters.TU17SetFast(array2, num4, b3);
					if (b2 == 118 || b2 == 33 || b2 == 29)
					{
						int num7 = num + ((P_0 >= 0) ? i : ((16 - i) * -1));
						int num8 = num2 + ((P_1 >= 0) ? j : ((16 - j) * -1));
						num7 = lxe7hMuSirBXGUQugsD.KmDSPjYqJTp(num7, icbSTevXVuM.ConvertParameters.XRegionOffset);
						num8 = lxe7hMuSirBXGUQugsD.KmDSPjYqJTp(num8, icbSTevXVuM.ConvertParameters.ZRegionOffset);
						int num9 = num3 * 16 + k;
						TagNodeCompound tagNodeCompound = lxe7hMuSirBXGUQugsD.kxISPapgZlQ(P_3, num7, num9, num8);
						if (tagNodeCompound == null)
						{
							tagNodeCompound = TileEntityConversion.CreatePEBlockEntityFromPC(Constants.BEDROCK_ENTITY_BLOCKS[b2], num7, num9, num8);
							P_3.Add(tagNodeCompound);
						}
						if (b2 == 33 || b2 == 29)
						{
							IOkzANnKhf(tagNodeCompound, b, num6);
						}
					}
					if (b2 == 54 || b2 == 130 || b2 == 146)
					{
						int num10 = num + ((P_0 >= 0) ? i : ((16 - i) * -1));
						int num11 = num2 + ((P_1 >= 0) ? j : ((16 - j) * -1));
						DK4znlPdl0(num10, num3 * 16 + k, num11, b3, P_3);
					}
					if (b2 == 218)
					{
						int num12 = num + ((P_0 >= 0) ? i : ((16 - i) * -1));
						int num13 = num2 + ((P_1 >= 0) ? j : ((16 - j) * -1));
						num12 = lxe7hMuSirBXGUQugsD.KmDSPjYqJTp(num12, icbSTevXVuM.ConvertParameters.XRegionOffset);
						num13 = lxe7hMuSirBXGUQugsD.KmDSPjYqJTp(num13, icbSTevXVuM.ConvertParameters.ZRegionOffset);
						int num14 = num3 * 16 + k;
						TagNodeCompound tagNodeCompound2 = lxe7hMuSirBXGUQugsD.kxISPapgZlQ(P_3, num12, num14, num13);
					}
					if (b2 == 140)
					{
						int num15 = num + ((P_0 >= 0) ? i : ((16 - i) * -1));
						int num16 = num2 + ((P_1 >= 0) ? j : ((16 - j) * -1));
						num15 = lxe7hMuSirBXGUQugsD.KmDSPjYqJTp(num15, icbSTevXVuM.ConvertParameters.XRegionOffset);
						num16 = lxe7hMuSirBXGUQugsD.KmDSPjYqJTp(num16, icbSTevXVuM.ConvertParameters.ZRegionOffset);
						int num17 = num3 * 16 + k;
						TagNodeCompound tagNodeCompound3 = lxe7hMuSirBXGUQugsD.kxISPapgZlQ(P_3, num15, num17, num16);
						if (tagNodeCompound3 == null)
						{
							TagNodeCompound tagNodeCompound4 = TileEntityConversion.CreatePEBlockEntityFromPC(Constants.BEDROCK_ENTITY_BLOCKS[b2], num15, num17, num16);
							RFxzJ4pCGN(tagNodeCompound4, num6);
							P_3.Add(tagNodeCompound4);
						}
					}
				}
			}
		}
		foreach (BlockItemInject item in P_4)
		{
			if (item.Y >= num3 * 16 && item.Y < num3 * 16 + 16)
			{
				try
				{
					int num18 = w5GzH5oyN0(item.X) * 256 + w5GzH5oyN0(item.Z) * 16 + (item.Y - num3 * 16);
					array[num18] = item.Id;
					nibbleSetters.TU17SetFast(array2, num18, item.Data);
				}
				catch (Exception)
				{
				}
			}
		}
		MemoryStream memoryStream = new MemoryStream();
		memoryStream.WriteByte(0);
		memoryStream.Write(array, 0, array.Length);
		memoryStream.Write(array2, 0, array2.Length);
		return memoryStream.ToArray();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RFxzJ4pCGN(TagNodeCompound P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		_ = 0;
		string text = "";
		short d = 0;
		if (P_1 >= 0 && P_1 <= 15)
		{
			text = xqpSTEGKBJs[P_1].name;
			d = xqpSTEGKBJs[P_1].val;
		}
		TagNodeCompound tagNodeCompound = new TagNodeCompound();
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19862)] = new TagNodeString(text);
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38876)] = new TagNodeShort(d);
		if (!string.IsNullOrEmpty(text))
		{
			P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64722)] = tagNodeCompound;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private byte[] aD9zu37Ccf(int P_0, int P_1, TagNodeCompound P_2, TagNodeList P_3, List<BlockItemInject> P_4, List<MCCoordinate> P_5)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = ((P_0 >= 0) ? (P_0 * 16) : ((P_0 + 1) * 16));
		int num2 = ((P_1 >= 0) ? (P_1 * 16) : ((P_1 + 1) * 16));
		PaletteIndexWorker paletteIndexWorker = new PaletteIndexWorker();
		int num3 = P_2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38782)] as TagNodeByte;
		if (!P_2.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38858)))
		{
			TagNodeList tagNodeList = new TagNodeList(TagType.TAG_COMPOUND);
			TagNodeCompound tagNodeCompound = new TagNodeCompound();
			tagNodeCompound.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10196), new TagNodeString(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9944)));
			tagNodeList.Add(tagNodeCompound);
			P_2.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38858), tagNodeList);
		}
		if (!P_2.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38832)))
		{
			P_2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38832)] = new TagNodeLongArray(new long[256]);
		}
		JavaPaletteConversionResults javaPaletteConversionResults = rf2zoi32oj(P_2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38858)] as TagNodeList);
		List<BlockState> dataStates = javaPaletteConversionResults.dataStates;
		List<int> waterIndexes = javaPaletteConversionResults.waterIndexes;
		Dictionary<int, BlockHandlerDataJavaToBedrock> blockHandlers = javaPaletteConversionResults.blockHandlers;
		List<BlockState> list = new List<BlockState>();
		list.Add(BlockMaster.GetBedrockBlockState(0, 0));
		list.Add(BlockMaster.GetBedrockBlockState(9, 0));
		bool flag = false;
		long[] array = P_2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38832)] as TagNodeLongArray;
		byte b = (byte)(array.Length / 64);
		int[] array2 = new int[4096];
		int[] array3 = new int[4096];
		int num4 = 0;
		int num5 = 0;
		uint num6 = (uint)((1 << (int)b) - 1);
		for (int i = 0; i < 4096; i++)
		{
			int num7 = 0;
			if (num5 + b > 64 && AwYSTk0o3nf >= 2556)
			{
				num5 = 0;
				num4++;
			}
			if (num5 + b <= 64)
			{
				num7 = (int)((array[num4] >> num5) & num6);
				num5 += b;
				if (num5 >= 64)
				{
					num5 = 0;
					num4++;
				}
			}
			else
			{
				int num8 = 64 - num5;
				uint num9 = (uint)((1 << num8) - 1);
				int num10 = (int)((array[num4] >> num5) & num9);
				int num11 = num5 + b - 64;
				num5 = 0;
				num4++;
				uint num12 = (uint)((1 << num11) - 1);
				int num13 = (int)((array[num4] >> num5) & num12);
				num7 = (num13 << num8) + num10;
				num5 = num11;
			}
			int num14 = (i >> 8) & 0xF;
			int num15 = i & 0xF;
			int num16 = (i >> 4) & 0xF;
			int num17 = num15 * 256 + num16 * 16 + num14;
			array2[num17] = num7;
			int? id = dataStates[num7].id;
			int data = dataStates[num7].data;
			if (waterIndexes.Contains(num7))
			{
				flag = true;
				array3[num17] = 1;
			}
			if (blockHandlers.ContainsKey(num7))
			{
				int x = num + ((P_0 >= 0) ? num15 : ((16 - num15) * -1));
				int z = num2 + ((P_1 >= 0) ? num16 : ((16 - num16) * -1));
				try
				{
					blockHandlers[num7].blockHandler(x, num3 * 16 + num14, z, data, blockHandlers[num7].properties, P_3);
				}
				catch (Exception)
				{
				}
			}
			if (id.HasValue && id == 118)
			{
				int num18 = num + ((P_0 >= 0) ? num15 : ((16 - num15) * -1));
				int num19 = num2 + ((P_1 >= 0) ? num16 : ((16 - num16) * -1));
				num18 = lxe7hMuSirBXGUQugsD.KmDSPjYqJTp(num18, icbSTevXVuM.ConvertParameters.XRegionOffset);
				num19 = lxe7hMuSirBXGUQugsD.KmDSPjYqJTp(num19, icbSTevXVuM.ConvertParameters.ZRegionOffset);
				TagNodeCompound tagNodeCompound2 = TileEntityConversion.CreatePEBlockEntityFromPC(Constants.BEDROCK_ENTITY_BLOCKS[id.Value], num18, num3 * 16 + num14, num19);
				P_3.Add(tagNodeCompound2);
				if (id == 33 || id == 29)
				{
					IOkzANnKhf(tagNodeCompound2, id.Value, data);
				}
			}
		}
		foreach (BlockItemInject item in P_4)
		{
			if (item.Y >= num3 * 16 && item.Y < num3 * 16 + 16)
			{
				try
				{
					int num20 = w5GzH5oyN0(item.X) * 256 + w5GzH5oyN0(item.Z) * 16 + (item.Y - num3 * 16);
					string name = item.Name;
					int num21 = paletteIndexWorker.JGcSpBeAOws(dataStates, name, item.Data);
					array2[num20] = num21;
				}
				catch (Exception)
				{
				}
			}
		}
		TagNodeCompound tagNodeCompound3 = null;
		tagNodeCompound3 = new TagNodeCompound();
		tagNodeCompound3[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38782)] = new TagNodeByte((byte)num3);
		tagNodeCompound3[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(35604)] = new TagNodeByte(8);
		TagNodeList tagNodeList2 = new TagNodeList(TagType.TAG_COMPOUND);
		TagNodeCompound tagNodeCompound4 = new TagNodeCompound();
		tagNodeCompound4[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38858)] = PEUtility.BuildNBTPalette(dataStates, icbSTevXVuM.ConvertParameters.ConvertToFormat);
		tagNodeCompound4[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38832)] = new TagNodeIntArray(array2);
		tagNodeList2.Add(tagNodeCompound4);
		if (flag)
		{
			TagNodeCompound tagNodeCompound5 = new TagNodeCompound();
			tagNodeCompound5[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38858)] = PEUtility.BuildNBTPalette(list, icbSTevXVuM.ConvertParameters.ConvertToFormat);
			tagNodeCompound5[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38832)] = new TagNodeIntArray(array3);
			tagNodeList2.Add(tagNodeCompound5);
		}
		tagNodeCompound3[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38804)] = tagNodeList2;
		return PEUtility.BuildBlockStateChunk(tagNodeCompound3);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private JavaPaletteConversionResults rf2zoi32oj(TagNodeList P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<BlockState> list = new List<BlockState>();
		List<int> list2 = new List<int>();
		Dictionary<int, BlockHandlerDataJavaToBedrock> dictionary = new Dictionary<int, BlockHandlerDataJavaToBedrock>();
		try
		{
			for (int i = 0; i < P_0.Count; i++)
			{
				TagNodeCompound tagNodeCompound = P_0[i] as TagNodeCompound;
				string text = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10196)] as TagNodeString;
				string text2 = text.Remove(0, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9974).Length);
				Dictionary<string, BlockStateProperty> dictionary2 = new Dictionary<string, BlockStateProperty>();
				dictionary2.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64470), new BlockStateProperty(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64470), text2));
				bool flag = false;
				string text3 = "";
				if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65420)))
				{
					TagNodeCompound tagNodeCompound2 = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65420)] as TagNodeCompound;
					foreach (string key in tagNodeCompound2.Keys)
					{
						dictionary2.Add(key, new BlockStateProperty(key, tagNodeCompound2[key] as TagNodeString));
					}
					if (tagNodeCompound2.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65444)))
					{
						string text4 = tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65444)] as TagNodeString;
						flag = text4 == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31650);
					}
					if (tagNodeCompound2.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31412)))
					{
						text3 = tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31412)] as TagNodeString;
					}
				}
				BlockState blockState = null;
				int hashCode = text.GetHashCode();
				if (BlockMaster.MasterBlocksByHash.ContainsKey(hashCode) && BlockMaster.MasterBlocksByHash[hashCode].bedrock.name != null)
				{
					blockState = new BlockState();
					MasterBlock masterBlock = BlockMaster.MasterBlocksByHash[hashCode];
					blockState.name = masterBlock.bedrock.name;
					blockState.id = masterBlock.bedrock.id;
					blockState.data = (short)(masterBlock.bedrock.data.HasValue ? masterBlock.bedrock.data.Value : 0);
					blockState.properties = masterBlock.bedrock.properties;
					blockState.useProperties = true;
					blockState.masterBlock = masterBlock;
					if (!string.IsNullOrWhiteSpace(masterBlock.blockStates) && BlockMaster.DataStates.ContainsKey(masterBlock.blockStates))
					{
						string text5 = masterBlock.blockStates;
						if (text5 == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65470) && dictionary2.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65492)) && dictionary2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65492)].Value == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65504))
						{
							text5 = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65518);
						}
						qHizOO0wl3(blockState, dictionary2, BlockMaster.DataStates[text5].blockStates);
					}
					if (!string.IsNullOrWhiteSpace(masterBlock.blockStates) && CFlSTlFH3XY.ContainsKey(masterBlock.blockStates))
					{
						CFlSTlFH3XY[masterBlock.blockStates](text, blockState, dictionary2);
					}
				}
				else
				{
					blockState = BlockMaster.GetBedrockBlockState(0, 0);
					if (text2 != Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65540) && text2 != Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65560))
					{
						Telemetry.AddJavaMissingBlockState(text2);
					}
				}
				if (flag || AquaticConversionData.waterBlocks.Contains(blockState.name))
				{
					list2.Add(i);
				}
				if (blockState.name == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15188) || blockState.name == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65580) || blockState.name == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15246))
				{
					if (text3 == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65630))
					{
						dictionary.Add(i, new BlockHandlerDataJavaToBedrock(dictionary2, MFVzhpvXhp));
					}
					else if (text3 == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65642))
					{
						dictionary.Add(i, new BlockHandlerDataJavaToBedrock(dictionary2, badzmlcRtB));
					}
				}
				else if (FlowerPotXRef.ContainsKey(text2))
				{
					dictionary.Add(i, new BlockHandlerDataJavaToBedrock(dictionary2, PZczBOKXky));
				}
				else if (blockState.name == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65656))
				{
					dictionary.Add(i, new BlockHandlerDataJavaToBedrock(dictionary2, PZczBOKXky));
				}
				else if (blockState.name == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15648))
				{
					dictionary.Add(i, new BlockHandlerDataJavaToBedrock(dictionary2, VW9zlF6BrZ));
				}
				else if (blockState.name == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15574))
				{
					dictionary.Add(i, new BlockHandlerDataJavaToBedrock(dictionary2, Wyjz2qbrGL));
				}
				else if (blockState.name == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65700) || blockState.name == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65736))
				{
					dictionary.Add(i, new BlockHandlerDataJavaToBedrock(dictionary2, qMRzyON41w));
				}
				else if (BannerXRef.ContainsKey(text2))
				{
					dictionary.Add(i, new BlockHandlerDataJavaToBedrock(dictionary2, bhSz0OgLBa));
				}
				list.Add(blockState);
			}
		}
		catch (Exception)
		{
		}
		JavaPaletteConversionResults javaPaletteConversionResults = new JavaPaletteConversionResults();
		javaPaletteConversionResults.dataStates = list;
		javaPaletteConversionResults.waterIndexes = list2;
		javaPaletteConversionResults.blockHandlers = dictionary;
		return javaPaletteConversionResults;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static string hmozQVFf66(Dictionary<string, BlockStateProperty> P_0, string P_1, string P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string result = P_2;
		if (P_0.ContainsKey(P_1))
		{
			result = P_0[P_1].Value;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void qHizOO0wl3(BlockState P_0, Dictionary<string, BlockStateProperty> P_1, List<BlockStateDefinition> P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		foreach (string key in P_1.Keys)
		{
			string value = P_1[key].Value;
			for (int i = 0; i < P_2.Count; i++)
			{
				if (!(P_2[i].name == key))
				{
					continue;
				}
				BlockStateDefinition blockStateDefinition = P_2[i];
				for (int j = 0; j < blockStateDefinition.states.Length; j++)
				{
					if (value == blockStateDefinition.states[j].javaPropertyValue)
					{
						short num = (short)blockStateDefinition.states[j].bedrock;
						P_0.data |= num;
						break;
					}
				}
				break;
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private byte[] hhyzCQC7qd(int P_0, int P_1, TagNodeCompound P_2, TagNodeList P_3, List<BlockItemInject> P_4, List<MCCoordinate> P_5)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = ((P_0 >= 0) ? (P_0 * 16) : ((P_0 + 1) * 16));
		int num2 = ((P_1 >= 0) ? (P_1 * 16) : ((P_1 + 1) * 16));
		_ = icbSTevXVuM.ConvertParameters;
		NibbleSetters nibbleSetters = new NibbleSetters();
		Dictionary<string, Dictionary<short, BlockState>> dictionary = new Dictionary<string, Dictionary<short, BlockState>>();
		PaletteIndexWorker paletteIndexWorker = new PaletteIndexWorker();
		if (((TagNodeByteArray)P_2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11178)]).Data.Length == 0)
		{
			P_2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11178)] = new TagNodeByteArray(new byte[2048]);
		}
		int num3 = P_2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38782)] as TagNodeByte;
		int[] array = new int[4096];
		byte[] array2 = P_2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38788)] as TagNodeByteArray;
		byte[] data = P_2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11178)] as TagNodeByteArray;
		for (int i = 0; i < 16; i++)
		{
			for (int j = 0; j < 16; j++)
			{
				for (int k = 0; k < 16; k++)
				{
					int num4 = i * 256 + j * 16 + k;
					int num5 = k * 256 + j * 16 + i;
					byte b = array2[num5];
					int num6 = nibbleSetters.TU17GetFast(data, num5);
					BlockConversionDefinition blockConversionDefinition = BlockMaster.BedrockFromJavaBlock(b, num6);
					int id = blockConversionDefinition.id;
					short num7 = (short)blockConversionDefinition.data;
					string name = blockConversionDefinition.name;
					if (id == 175)
					{
						num7 = Jtiz78h0jk((byte)num7, i, k, j, P_5);
					}
					int paletteIndex = paletteIndexWorker.GetPaletteIndex(dictionary, name, num7);
					array[num4] = paletteIndex;
					if (id == 118 || id == 33 || id == 29)
					{
						int num8 = num + ((P_0 >= 0) ? i : ((16 - i) * -1));
						int num9 = num2 + ((P_1 >= 0) ? j : ((16 - j) * -1));
						num8 = lxe7hMuSirBXGUQugsD.KmDSPjYqJTp(num8, icbSTevXVuM.ConvertParameters.XRegionOffset);
						num9 = lxe7hMuSirBXGUQugsD.KmDSPjYqJTp(num9, icbSTevXVuM.ConvertParameters.ZRegionOffset);
						int num10 = num3 * 16 + k;
						TagNodeCompound tagNodeCompound = lxe7hMuSirBXGUQugsD.kxISPapgZlQ(P_3, num8, num10, num9);
						if (tagNodeCompound == null)
						{
							tagNodeCompound = TileEntityConversion.CreatePEBlockEntityFromPC(Constants.BEDROCK_ENTITY_BLOCKS[id], num8, num10, num9);
							P_3.Add(tagNodeCompound);
						}
						if (id == 33 || id == 29)
						{
							IOkzANnKhf(tagNodeCompound, b, num6);
						}
					}
					if (id == 54 || id == 130 || id == 146)
					{
						int num11 = num + ((P_0 >= 0) ? i : ((16 - i) * -1));
						int num12 = num2 + ((P_1 >= 0) ? j : ((16 - j) * -1));
						DK4znlPdl0(num11, num3 * 16 + k, num12, num7, P_3);
					}
					if (id == 140)
					{
						int num13 = num + ((P_0 >= 0) ? i : ((16 - i) * -1));
						int num14 = num2 + ((P_1 >= 0) ? j : ((16 - j) * -1));
						num13 = lxe7hMuSirBXGUQugsD.KmDSPjYqJTp(num13, icbSTevXVuM.ConvertParameters.XRegionOffset);
						num14 = lxe7hMuSirBXGUQugsD.KmDSPjYqJTp(num14, icbSTevXVuM.ConvertParameters.ZRegionOffset);
						int num15 = num3 * 16 + k;
						TagNodeCompound tagNodeCompound2 = lxe7hMuSirBXGUQugsD.kxISPapgZlQ(P_3, num13, num15, num14);
						if (tagNodeCompound2 == null)
						{
							TagNodeCompound tagNodeCompound3 = TileEntityConversion.CreatePEBlockEntityFromPC(Constants.BEDROCK_ENTITY_BLOCKS[id], num13, num15, num14);
							RFxzJ4pCGN(tagNodeCompound3, num6);
							P_3.Add(tagNodeCompound3);
						}
					}
				}
			}
		}
		foreach (BlockItemInject item in P_4)
		{
			if (item.Y >= num3 * 16 && item.Y < num3 * 16 + 16)
			{
				try
				{
					int num16 = w5GzH5oyN0(item.X) * 256 + w5GzH5oyN0(item.Z) * 16 + (item.Y - num3 * 16);
					string name2 = item.Name;
					int paletteIndex2 = paletteIndexWorker.GetPaletteIndex(dictionary, name2, item.Data);
					array[num16] = paletteIndex2;
				}
				catch (Exception)
				{
				}
			}
		}
		TagNodeCompound tagNodeCompound4 = null;
		tagNodeCompound4 = new TagNodeCompound();
		tagNodeCompound4[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38782)] = new TagNodeByte((byte)num3);
		tagNodeCompound4[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(35604)] = new TagNodeByte(8);
		TagNodeList tagNodeList = new TagNodeList(TagType.TAG_COMPOUND);
		TagNodeCompound tagNodeCompound5 = new TagNodeCompound();
		tagNodeCompound5[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38858)] = PEUtility.BuildNBTPalette(dictionary, icbSTevXVuM.ConvertParameters.ConvertToFormat);
		tagNodeCompound5[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38832)] = new TagNodeIntArray(array);
		tagNodeList.Add(tagNodeCompound5);
		tagNodeCompound4[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38804)] = tagNodeList;
		return PEUtility.BuildBlockStateChunk(tagNodeCompound4);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private byte Jtiz78h0jk(byte P_0, int P_1, int P_2, int P_3, List<MCCoordinate> P_4)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bool flag = false;
		for (int i = 0; i < P_4.Count; i++)
		{
			if (P_4[i].ax9Sw78H4rf(P_1, P_2, P_3))
			{
				P_0 = (byte)(P_4[i].val | 8);
				flag = true;
				P_4.Remove(P_4[i]);
				break;
			}
		}
		if (!flag)
		{
			int num = P_2 + 1;
			if (num >= 16)
			{
				num = 0;
			}
			P_4.Add(new MCCoordinate(P_1, P_2 + 1, P_3, P_0));
		}
		return P_0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void IOkzANnKhf(TagNodeCompound P_0, int P_1, int P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_1 == 29)
		{
			P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64582)] = new TagNodeByte(1);
		}
		if (P_2 > 7)
		{
			P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64618)] = new TagNodeByte(2);
			P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64632)] = new TagNodeByte(2);
			P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64652)] = new TagNodeFloat(1f);
			P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64672)] = new TagNodeFloat(1f);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int bO0zd9xy2d(int P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return (P_0 % P_1 + P_1) % P_1;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int w5GzH5oyN0(int P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return bO0zd9xy2d(P_0, 16);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private byte[] Un8zF0mjhM()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return new byte[10241];
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MDvzj3x75g(byte[] P_0, byte[] P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		wBISTaxkeuN.Add(P_0);
		wBISTaxkeuN.Add(P_1);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void la0z8a3t5U(TagNodeByteArray P_0, ConvertParameters P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!P_1.ReplaceBiomes)
		{
			return;
		}
		for (int i = 0; i < P_0.Length; i++)
		{
			for (int j = 0; j < P_1.BiomeChanges.Count; j++)
			{
				if (P_1.BiomeChanges[j].FromBiome == 1000 || P_0[i] == P_1.BiomeChanges[j].FromBiome)
				{
					P_0[i] = (byte)P_1.BiomeChanges[j].ToBiome;
					break;
				}
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private BlockChange DJSz9CE6gG(ConvertParameters P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		_ = P_0.BlockChanges;
		return new BlockChange();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNodeList KwEzIY3GQD(TagNodeCompound P_0, ConvertParameters P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeList tagNodeList = (P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63796)) ? (P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63796)].Copy() as TagNodeList) : new TagNodeList(TagType.TAG_COMPOUND));
		TagNodeList tagNodeList2 = new TagNodeList(TagType.TAG_COMPOUND);
		int num = 0;
		int num2 = 0;
		for (int num3 = tagNodeList.Count - 1; num3 >= 0; num3--)
		{
			TagNodeCompound tagNodeCompound = tagNodeList[num3] as TagNodeCompound;
			if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)) && tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] is TagNodeString)
			{
				string text = (TagNodeString)tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)];
				Console.WriteLine(num3 + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12654) + text);
				if (TileEntityLookup.Names.ContainsKey(text))
				{
					text = TileEntityLookup.BedrockNames[TileEntityLookup.Names[text]];
					int num4 = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65786)] as TagNodeInt;
					int y = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38886)] as TagNodeInt;
					int num5 = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65792)] as TagNodeInt;
					if (icbSTevXVuM.ConvertParameters.UseConvertOffsets)
					{
						num4 = lxe7hMuSirBXGUQugsD.KmDSPjYqJTp(num4, icbSTevXVuM.ConvertParameters.XRegionOffset);
						num5 = lxe7hMuSirBXGUQugsD.KmDSPjYqJTp(num5, icbSTevXVuM.ConvertParameters.ZRegionOffset);
					}
					TagNodeCompound tagNodeCompound2 = TileEntityConversion.CreatePEBlockEntityFromPC(text, num4, y, num5);
					if (tagNodeCompound2 != null)
					{
						if (!(text == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15174)))
						{
							if (text == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15682))
							{
								yP8STUKkFKA.ProcessMobSpawner(tagNodeCompound, tagNodeCompound2);
								num++;
							}
							else if (text == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15604))
							{
								jtiSTp9SJeJ(tagNodeCompound, tagNodeCompound2);
							}
							else if (text == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14546))
							{
								VIWSTVm1WKP(tagNodeCompound, tagNodeCompound2);
							}
							else if (text == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14496))
							{
								kf0ST49vakA(tagNodeCompound, tagNodeCompound2);
							}
							else if (text == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65798))
							{
								fhKSTw4raE2(tagNodeCompound, tagNodeCompound2);
							}
							else if (text == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65826))
							{
								C0TSTvZPLw5(tagNodeCompound, tagNodeCompound2);
							}
							else if (text == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65840))
							{
								zL5STbOyky8(tagNodeCompound, tagNodeCompound2);
							}
							else if (text == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64700))
							{
								try
								{
									bwFSTWGf1k1(tagNodeCompound, tagNodeCompound2, P_1);
								}
								catch (Exception ex)
								{
									MessageBox.Show(ex.Message);
								}
							}
							else if (text == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15464))
							{
								tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65858)] = new TagNodeByte(0);
							}
							else if (text == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65878))
							{
								q7ISTG6r644(tagNodeCompound, tagNodeCompound2);
							}
							else if (text == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(2564))
							{
								dyNSTTXO4vQ(tagNodeCompound, tagNodeCompound2);
							}
							else if (text == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65902))
							{
								wuASTSSD2Gs(tagNodeCompound, tagNodeCompound2);
							}
						}
						if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(4702)) && tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(4702)] is TagNodeCompound)
						{
							dDHSTfS6pok(tagNodeCompound, tagNodeCompound2);
						}
						if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18438)))
						{
							T5FSTiDuts0(tagNodeCompound, tagNodeCompound2);
						}
						if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65920)))
						{
							LootTableLookup lootTableLookup = new LootTableLookup();
							string d = lootTableLookup.ConvertLootTable(tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65920)] as TagNodeString);
							tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65920)] = new TagNodeString(d);
							if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65942)) && tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65942)] is TagNodeLong)
							{
								tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65942)] = new TagNodeLong(tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65942)] as TagNodeLong);
							}
							else
							{
								tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65942)] = new TagNodeLong(0L);
							}
						}
						tagNodeList2.Add(tagNodeCompound2);
					}
				}
				else
				{
					num2++;
				}
			}
			else
			{
				num2++;
			}
		}
		return tagNodeList2;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void nGHzz04buw(string P_0, TagNodeCompound P_1, TagNodeList P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		NBT2TextWriter nBT2TextWriter = new NBT2TextWriter();
		string text = nBT2TextWriter.ProcessNBT(P_2);
		if (!string.IsNullOrWhiteSpace(text))
		{
			int num = P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64984)] as TagNodeInt;
			int num2 = P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64996)] as TagNodeInt;
			string path = string.Format(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63824), num, num2);
			string text2 = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65972) + Constants.scriptDimensionNames[icbSTevXVuM.PEDimension] + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20100) + P_0 + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20100);
			string path2 = Path.Combine(text2, path);
			Directory.CreateDirectory(text2);
			File.WriteAllText(path2, text);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void dyNSTTXO4vQ(TagNodeCompound P_0, TagNodeCompound P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64520)))
		{
			P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64520)] = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64520)].Copy();
		}
		if (P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17354)))
		{
			P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17354)] = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17354)].Copy();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void wuASTSSD2Gs(TagNodeCompound P_0, TagNodeCompound P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void q7ISTG6r644(TagNodeCompound P_0, TagNodeCompound P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66050)))
		{
			P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66050)] = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66050)].Copy();
		}
		if (P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66050)))
		{
			P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66050)] = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66050)].Copy();
		}
		if (P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66080)) && P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66080)] is TagNodeCompound)
		{
			TagNodeCompound tagNodeCompound = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66080)] as TagNodeCompound;
			TagNodeList tagNodeList = new TagNodeList(TagType.TAG_INT);
			if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(45624)))
			{
				tagNodeList.Add(tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(45624)].Copy());
			}
			else
			{
				tagNodeList.Add(new TagNodeInt(0));
			}
			if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38782)))
			{
				tagNodeList.Add(tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38782)].Copy());
			}
			else
			{
				tagNodeList.Add(new TagNodeInt(0));
			}
			if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(45618)))
			{
				tagNodeList.Add(tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(45618)].Copy());
			}
			else
			{
				tagNodeList.Add(new TagNodeInt(0));
			}
			P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66080)] = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66080)].Copy();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void zL5STbOyky8(TagNodeCompound P_0, TagNodeCompound P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66104)))
		{
			TagNodeCompound tagNodeCompound = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66104)] as TagNodeCompound;
			if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)) && IRGSTxndelo.ProcessItem(tagNodeCompound))
			{
				P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66104)] = tagNodeCompound;
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void C0TSTvZPLw5(TagNodeCompound P_0, TagNodeCompound P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66128)))
		{
			P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66128)] = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66128)];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void fhKSTw4raE2(TagNodeCompound P_0, TagNodeCompound P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66140)))
		{
			P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66140)] = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66140)];
		}
		if (P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66152)))
		{
			P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66152)] = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66152)];
		}
		if (P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66170)))
		{
			P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66170)] = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66170)];
		}
		if (P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64910)))
		{
			P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64910)] = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64910)];
		}
		if (P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66198)))
		{
			P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66198)] = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66198)];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void kf0ST49vakA(TagNodeCompound P_0, TagNodeCompound P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int d = 0;
		if (P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(0)))
		{
			d = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(0)] as TagNodeInt;
		}
		P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(0)] = new TagNodeInt(d);
		if (!P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14322)) || !(P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14322)] is TagNodeList))
		{
			return;
		}
		TagNodeList tagNodeList = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14322)] as TagNodeList;
		for (int i = 0; i < tagNodeList.Count; i++)
		{
			TagNodeCompound tagNodeCompound = tagNodeList[i] as TagNodeCompound;
			if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14360)))
			{
				int d2 = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14360)] as TagNodeInt;
				tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14360)] = new TagNodeInt(d2);
			}
		}
		P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14322)] = tagNodeList;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void VIWSTVm1WKP(TagNodeCompound P_0, TagNodeCompound P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte d = 0;
		if (P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14532)))
		{
			d = (byte)(int)(P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14532)] as TagNodeInt);
		}
		P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14532)] = new TagNodeByte(d);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void bwFSTWGf1k1(TagNodeCompound P_0, TagNodeCompound P_1, ConvertParameters P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = "";
		short d = 0;
		TagNodeCompound tagNodeCompound = new TagNodeCompound();
		if (P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(4702)) && P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(4702)] is TagNodeString)
		{
			text = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(4702)] as TagNodeString;
		}
		if (P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11178)))
		{
			d = (short)(int)(P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11178)] as TagNodeInt);
		}
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19862)] = new TagNodeString(text);
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38876)] = new TagNodeShort(d);
		if (!string.IsNullOrEmpty(text) && text != Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9944))
		{
			P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64722)] = tagNodeCompound;
		}
		else
		{
			P_1.Remove(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64722));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void jtiSTp9SJeJ(TagNodeCompound P_0, TagNodeCompound P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		try
		{
			string d = AbHSTZixcwQ(((TagNodeString)P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66224)]).Data) + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66238) + AbHSTZixcwQ(((TagNodeString)P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66244)]).Data) + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66238) + AbHSTZixcwQ(((TagNodeString)P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66258)]).Data) + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66238) + AbHSTZixcwQ(((TagNodeString)P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66272)]).Data);
			P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10946)] = new TagNodeString(d);
		}
		catch (Exception)
		{
			P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10946)] = new TagNodeString(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17554));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string AbHSTZixcwQ(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		try
		{
			if (P_0.Trim().StartsWith(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63862)))
			{
				JSONText jSONText = new JSONText();
				P_0 = jSONText.ParseJSONText(P_0);
			}
			P_0 = ((P_0.ToLower() == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31676)) ? "" : ((P_0 == null) ? "" : P_0.Replace(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63856), "")));
		}
		catch (Exception)
		{
			P_0 = "";
		}
		P_0 = IRGSTxndelo.CheckColorCodes(P_0);
		return P_0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool dDHSTfS6pok(TagNodeCompound P_0, TagNodeCompound P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bool flag = false;
		if (P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(4702)))
		{
			TagNodeCompound tagNodeCompound = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(4702)] as TagNodeCompound;
			flag = IRGSTxndelo.ProcessItem(tagNodeCompound);
			if (flag)
			{
				P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(4702)] = tagNodeCompound;
			}
		}
		return flag;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void T5FSTiDuts0(TagNodeCompound P_0, TagNodeCompound P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeList tagNodeList = (TagNodeList)(P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18438)] as TagNodeList).Copy();
		IRGSTxndelo.ProcessItems(tagNodeList);
		P_1[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18438)] = tagNodeList;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNodeList PpsSTsNS3ne(TagNodeCompound P_0, ConvertParameters P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return cuuSTqNNV75(P_0, P_1);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNodeList cuuSTqNNV75(TagNodeCompound P_0, ConvertParameters P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeList tagNodeList = (P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42124)) ? (P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42124)] as TagNodeList) : new TagNodeList(TagType.TAG_COMPOUND));
		TagNodeList tagNodeList2 = new TagNodeList(TagType.TAG_COMPOUND);
		for (int num = tagNodeList.Count - 1; num >= 0; num--)
		{
			if (tagNodeList[num] is TagNodeCompound && tagNodeList[num] is TagNodeCompound tagNodeCompound)
			{
				string text = string.Empty;
				if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)) && tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] is TagNodeString)
				{
					text = (TagNodeString)tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)];
				}
				if (IANSTKZjpxp(tagNodeCompound))
				{
					try
					{
						TagNodeCompound tagNodeCompound2 = null;
						try
						{
							tagNodeCompound2 = PEEntityConverters.EntityConverter(tagNodeCompound, P_1);
						}
						catch (Exception)
						{
						}
						if (tagNodeCompound2 != null)
						{
							if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(4702)))
							{
								dDHSTfS6pok(tagNodeCompound, tagNodeCompound2);
							}
							if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18438)))
							{
								T5FSTiDuts0(tagNodeCompound, tagNodeCompound2);
							}
							tagNodeList2.Add(tagNodeCompound2);
						}
						if (text == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15068) && tagNodeCompound2.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18438)))
						{
							TagNodeList value = tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18438)] as TagNodeList;
							tagNodeCompound2.Remove(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18438));
							tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66286)] = value;
						}
					}
					catch (Exception)
					{
					}
				}
			}
		}
		return tagNodeList2;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IANSTKZjpxp(TagNodeCompound P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bool result = false;
		if (P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)) && P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)] is TagNodeString)
		{
			string text = (TagNodeString)P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)];
			if (text != Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(4702) && text != Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66310))
			{
				if (cxsSTMTc21b.PCEntities.ContainsKey(text))
				{
					result = true;
				}
			}
			else
			{
				result = IRGSTxndelo.ProcessItem(P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(4702)] as TagNodeCompound);
			}
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void c9WSThDpt9L(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		qxSSTrREcB7++;
		int num = (int)((float)(qxSSTrREcB7 + 1) / (float)hCQST5i5bdq * 100f);
		By4STm73Knn(P_0, num);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void By4STm73Knn(string P_0, int P_1 = 0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (icbSTevXVuM != null)
		{
			icbSTevXVuM.Count = qxSSTrREcB7;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNodeCompound KvxSTn0E7yi(int P_0, int P_1, int P_2, TagNodeList P_3, string P_4 = null)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound result = null;
		for (int i = 0; i < P_3.Count; i++)
		{
			TagNodeCompound tagNodeCompound = P_3[i] as TagNodeCompound;
			int num = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65786)] as TagNodeInt;
			int num2 = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38886)] as TagNodeInt;
			int num3 = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65792)] as TagNodeInt;
			string text = null;
			if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)))
			{
				text = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)].ToString();
			}
			if (num == P_0 && num2 == P_1 && num3 == P_2 && (P_4 == null || P_4 == text))
			{
				result = tagNodeCompound;
				break;
			}
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ConvertToPEFromPC()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		CFlSTlFH3XY = new Dictionary<string, pR72jojXaHtLDyIfVDV>
		{
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66342),
				EUdza875Kc
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66354),
				dVOztjjYUp
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66374),
				tAUzXCqrYB
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66388),
				wrPzxmecys
			}
		};
		ScjST2tVKaB = 2;
		PCTSTy7tZy3 = 3;
		LC2ST0kjKot = 5;
		TXtSTBfRA4B = 4;
		wBISTaxkeuN = new List<byte[]>();
		IteSTXI2wW1 = new Dictionary<int, List<int>>();
		IRGSTxndelo = new BedrockFromJavaItemConverter();
		cxsSTMTc21b = new EntityLookup();
		yP8STUKkFKA = new PETileEntityConverters();
		mS9STYBkPbk = new byte[4] { 2, 1, 3, 0 };
		H21ST3UiYHv = new byte[6] { 0, 0, 3, 2, 1, 0 };
		pqdST1vdGSd = new List<BlockState> { BlockMaster.GetBedrockBlockState(0, 0) };
		xqpSTEGKBJs = new FlowerPotContent[16]
		{
			new FlowerPotContent
			{
				name = "",
				val = 0
			},
			new FlowerPotContent
			{
				name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66404),
				val = 0
			},
			new FlowerPotContent
			{
				name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66448),
				val = 0
			},
			new FlowerPotContent
			{
				name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66498),
				val = 0
			},
			new FlowerPotContent
			{
				name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66498),
				val = 1
			},
			new FlowerPotContent
			{
				name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66498),
				val = 2
			},
			new FlowerPotContent
			{
				name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66498),
				val = 3
			},
			new FlowerPotContent
			{
				name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66536),
				val = 0
			},
			new FlowerPotContent
			{
				name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66584),
				val = 0
			},
			new FlowerPotContent
			{
				name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66636),
				val = 0
			},
			new FlowerPotContent
			{
				name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66672),
				val = 0
			},
			new FlowerPotContent
			{
				name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66712),
				val = 2
			},
			new FlowerPotContent
			{
				name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66498),
				val = 4
			},
			new FlowerPotContent
			{
				name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66498),
				val = 5
			},
			new FlowerPotContent
			{
				name = "",
				val = 0
			},
			new FlowerPotContent
			{
				name = "",
				val = 0
			}
		};
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ConvertToPEFromPC()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		BannerXRef = new Dictionary<string, short>
		{
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66754),
				15
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66782),
				14
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66812),
				13
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66844),
				12
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66882),
				11
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66912),
				10
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66938),
				9
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66964),
				8
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66990),
				7
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(67028),
				6
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(67054),
				5
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(67084),
				4
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(67110),
				3
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(67138),
				2
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(67166),
				1
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(67190),
				0
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(67218),
				15
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(67256),
				14
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(67296),
				13
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(67338),
				12
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(67396),
				11
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(67436),
				10
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(67472),
				9
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(67508),
				8
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(67544),
				7
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(67602),
				6
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(67638),
				5
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(67678),
				4
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(67714),
				3
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(67752),
				2
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(67790),
				1
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(67824),
				0
			}
		};
		FlowerPotXRef = new Dictionary<string, FlowerPotContent>
		{
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(67862),
				new FlowerPotContent
				{
					name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66498),
					val = 4,
					flowerType = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(67908)
				}
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(67924),
				new FlowerPotContent
				{
					name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66404),
					val = 2,
					flowerType = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(67954)
				}
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(67970),
				new FlowerPotContent
				{
					name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66404),
					val = 3,
					flowerType = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(68010)
				}
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(68032),
				new FlowerPotContent
				{
					name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(68062),
					val = 0,
					flowerType = ""
				}
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(68098),
				new FlowerPotContent
				{
					name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66498),
					val = 2,
					flowerType = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(68142)
				}
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(68156),
				new FlowerPotContent
				{
					name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66404),
					val = 1,
					flowerType = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(68196)
				}
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(68212),
				new FlowerPotContent
				{
					name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66584),
					val = 0,
					flowerType = ""
				}
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(68258),
				new FlowerPotContent
				{
					name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66636),
					val = 0,
					flowerType = ""
				}
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(68288),
				new FlowerPotContent
				{
					name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66404),
					val = 9,
					flowerType = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(68326)
				}
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(68350),
				new FlowerPotContent
				{
					name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66448),
					val = 0,
					flowerType = ""
				}
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(68386),
				new FlowerPotContent
				{
					name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66498),
					val = 5,
					flowerType = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(68436)
				}
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(68456),
				new FlowerPotContent
				{
					name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66672),
					val = 0,
					flowerType = ""
				}
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(68492),
				new FlowerPotContent
				{
					name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66712),
					val = 2,
					flowerType = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(68518)
				}
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(68530),
				new FlowerPotContent
				{
					name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66404),
					val = 3,
					flowerType = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(68576)
				}
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(68592),
				new FlowerPotContent
				{
					name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66404),
					val = 10,
					flowerType = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(68646)
				}
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(68686),
				new FlowerPotContent
				{
					name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66498),
					val = 0,
					flowerType = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(68726)
				}
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(68736),
				new FlowerPotContent
				{
					name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66404),
					val = 5,
					flowerType = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(68778)
				}
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(68806),
				new FlowerPotContent
				{
					name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66404),
					val = 8,
					flowerType = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(68846)
				}
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(68860),
				new FlowerPotContent
				{
					name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66404),
					val = 7,
					flowerType = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(68898)
				}
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(68922),
				new FlowerPotContent
				{
					name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66404),
					val = 0,
					flowerType = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(68950)
				}
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(68964),
				new FlowerPotContent
				{
					name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66536),
					val = 0,
					flowerType = ""
				}
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69006),
				new FlowerPotContent
				{
					name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66404),
					val = 4,
					flowerType = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69042)
				}
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69064),
				new FlowerPotContent
				{
					name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66498),
					val = 1,
					flowerType = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69110)
				}
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69126),
				new FlowerPotContent
				{
					name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66404),
					val = 6,
					flowerType = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69166)
				}
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69192),
				new FlowerPotContent
				{
					name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69232),
					val = 0,
					flowerType = ""
				}
			}
		};
		ShrSTt2r2aD = new Dictionary<string, int>
		{
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64164),
				0
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69278),
				1
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64136),
				2
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64150),
				3
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69290),
				4
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64176),
				5
			}
		};
		facingIndex = new Dictionary<string, int>
		{
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64136),
				0
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64150),
				1
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64164),
				2
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64176),
				3
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69290),
				4
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69278),
				5
			}
		};
		LeverXRef = new Dictionary<string, short>
		{
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69298),
				0
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69324),
				0
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69350),
				1
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69370),
				2
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69390),
				3
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69412),
				4
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69434),
				5
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69458),
				5
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69482),
				6
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69504),
				6
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69526),
				7
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69554),
				7
			}
		};
		buttonPoweredXRef = new Dictionary<string, short>
		{
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31662),
				0
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31650),
				8
			}
		};
		ButtonFaceFCXRef = new Dictionary<string, short>
		{
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69526),
				0
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69554),
				0
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69298),
				0
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69324),
				0
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69350),
				5
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69370),
				4
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69390),
				3
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69412),
				2
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69434),
				1
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69458),
				1
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69482),
				1
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69504),
				1
			}
		};
		activeChests = null;
	}
}
