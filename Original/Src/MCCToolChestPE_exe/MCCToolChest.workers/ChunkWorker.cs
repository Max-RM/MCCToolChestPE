using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using afNMf7uWOyq6L7IHxiu;
using MCCToolChest.events;
using MCCToolChest.MCSBCode;
using MCCToolChest.model;
using MCCToolChest.PECode;
using MCCToolChest.utils;
using MCPELevelDBI.workers;
using NBTExplorer.Model;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.workers;

public class ChunkWorker
{
	private BackgroundWorker eJHSYGhLCpp;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ChunkWorker()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ChunkWorker(BackgroundWorker backgroundWorker)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		eJHSYGhLCpp = backgroundWorker;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CopyChunk(TreeView tvMCFiles, TagCompoundDataNode pContainer)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (pContainer != null && pContainer.Tag is TagNodeCompound value)
		{
			MemoryStream memoryStream = new MemoryStream();
			NbtTree nbtTree = new NbtTree();
			nbtTree.UseBigEndian = true;
			nbtTree.Root.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18204), value);
			nbtTree.WriteTo(memoryStream);
			string text = Guid.NewGuid().ToString();
			byte[] bytes = lxe7hMuSirBXGUQugsD.byDSPrUjE5G(memoryStream.ToArray());
			string filename = Path.Combine(Utils.ChunkLibraryPath(), text + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(244146));
			FileUtils.WriteFile(bytes, filename);
			ChunkData chunkData = tvMCFiles.SelectedNode.Tag as ChunkData;
			MapBlockWorker mapBlockWorker = new MapBlockWorker();
			filename = Path.Combine(Utils.ChunkLibraryPath(), text + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12722));
			Bitmap chunkImage = mapBlockWorker.GetChunkImage(chunkData.Dimension, chunkData.XWorldCoords, chunkData.ZWorldCoords, Working.T92StMGt1p4());
			new ImageUtils();
			chunkImage = EnlargeImage(chunkImage, 96, 96);
			chunkImage.Save(filename, ImageFormat.Png);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Bitmap EnlargeImage(Bitmap original, int width, int height)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Bitmap bitmap = new Bitmap(width, height);
		using Graphics graphics = Graphics.FromImage(bitmap);
		graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
		graphics.DrawImage(original, new Rectangle(Point.Empty, bitmap.Size));
		return bitmap;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PasteChunk(TreeView tvMCFiles, ChunkPastedEventArgs args)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!File.Exists(args.Path))
		{
			return;
		}
		byte[] array = FileUtils.pURSg6Zk53A(args.Path);
		if (array != null)
		{
			array = lxe7hMuSirBXGUQugsD.KpwSP5kgJSU(array);
			MemoryStream s = new MemoryStream(array);
			NbtTree nbtTree = new NbtTree();
			nbtTree.UseBigEndian = true;
			nbtTree.ReadFrom(s);
			TagNodeCompound root = nbtTree.Root;
			if (root != null)
			{
				ChunkData chunkData = tvMCFiles.SelectedNode.Tag as ChunkData;
				TagNodeCompound tagNodeCompound = root[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18204)] as TagNodeCompound;
				tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64984)] = new TagNodeInt(chunkData.XWorldCoords);
				tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64996)] = new TagNodeInt(chunkData.ZWorldCoords);
				vfiSkIQVP0s(tagNodeCompound, chunkData.XWorldCoords, chunkData.ZWorldCoords);
				GWdSkzbMBFG(tagNodeCompound, chunkData.XWorldCoords, chunkData.ZWorldCoords);
				PEProcessWorker pEProcessWorker = new PEProcessWorker();
				pEProcessWorker.ProcessModifiedChunk(chunkData.Dimension, root, Working.T92StMGt1p4());
				string dimension = Constants.dimensionFolderNames[chunkData.Dimension];
				MapBlockWorker mapBlockWorker = new MapBlockWorker();
				mapBlockWorker.RegenRegionImage(dimension, chunkData.RegionIndex.ToString(), Working.T92StMGt1p4());
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CopyAreaChunks(AreaActionEventArgs args)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		UpgradeBedrockSections upgradeBedrockSections = new UpgradeBedrockSections();
		List<Bitmap> list = new List<Bitmap>();
		int num = args.X2 - args.X1 + 1;
		int num2 = args.Z2 - args.Z1 + 1;
		int num3 = num * num2;
		int num4 = 0;
		fphSk9mdotx(args.Dimension);
		int num5 = 0;
		int num6 = 0;
		MapBlockWorker mapBlockWorker = new MapBlockWorker();
		string path = Guid.NewGuid().ToString();
		string text = Path.Combine(Utils.AreaLibraryPath(), path);
		Directory.CreateDirectory(text);
		LevelDBWorker levelDBWorker = PEUtility.OpenDBWorker(text, createIfNotExist: true);
		for (int i = args.Z1; i <= args.Z2; i++)
		{
			for (int j = args.X1; j <= args.X2; j++)
			{
				PEProcessWorker pEProcessWorker = new PEProcessWorker();
				TagNodeCompound chunk = pEProcessWorker.GetChunk(Working.T92StMGt1p4(), 0, j, i);
				if (chunk != null && chunk.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18204)))
				{
					TagNodeCompound tagNodeCompound = chunk[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18204)] as TagNodeCompound;
					if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20548)))
					{
						tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20548)] = upgradeBedrockSections.ToBlockStateSections(tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20548)] as TagNodeList);
					}
					MemoryStream memoryStream = new MemoryStream();
					NbtTree nbtTree = new NbtTree();
					nbtTree.UseBigEndian = true;
					nbtTree.Root.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18204), tagNodeCompound);
					nbtTree.WriteTo(memoryStream);
					byte[] key = PEUtility.BuildChunkKey(num5, num6);
					levelDBWorker.Put(key, memoryStream.ToArray());
					Bitmap chunkImage = mapBlockWorker.GetChunkImage(args.Dimension, j, i, Working.T92StMGt1p4());
					list.Add(chunkImage);
					num4++;
					int num7 = (int)((float)num4 / (float)num3 * 100f);
					if (num7 > 100)
					{
						num7 = 100;
					}
					string text2 = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(244162) + num4 + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71754) + num3;
					gFHSYS7MDjy(text2, num7);
				}
				num6++;
			}
			num5++;
			num6 = 0;
		}
		levelDBWorker.CloseDB();
		gFHSYS7MDjy(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(244192), 100);
		TJMSkNyOsPq(list, num, num2, text);
		gFHSYS7MDjy(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(244234), 100);
		R8qSk64sGen(args.AreaName, num, num2, text);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void R8qSk64sGen(string P_0, int P_1, int P_2, string P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		AreaAttributes obj = new AreaAttributes(P_0, P_1, P_2);
		string contents = JsonDataConversion.Serialize(obj);
		File.WriteAllText(Path.Combine(P_3, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10096)), contents);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TJMSkNyOsPq(List<Bitmap> P_0, int P_1, int P_2, string P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Bitmap bitmap = new Bitmap(P_1 * 16, P_2 * 16);
		int num = 0;
		using (Graphics graphics = Graphics.FromImage(bitmap))
		{
			for (int i = 0; i < P_2; i++)
			{
				for (int j = 0; j < P_1; j++)
				{
					Image image = P_0[num];
					graphics.DrawImage(image, j * 16, i * 16, 16, 16);
					num++;
				}
			}
		}
		string filename = Path.Combine(P_3, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10076));
		bitmap.Save(filename);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FillAreaWithArea(AreaActionEventArgs args)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = 0;
		bool flag = Math.Abs(args.Rotation) == 90 || Math.Abs(args.Rotation) == 270;
		int num2 = ((!flag) ? (args.X2 - args.X1) : (args.Z2 - args.Z1));
		int num3 = ((!flag) ? (args.Z2 - args.Z1) : (args.X2 - args.X1));
		int num4 = (num2 + 1) * (num3 + 1);
		int num5 = 0;
		PEDimension pEDimension = fphSk9mdotx(args.Dimension);
		LevelDBWorker levelDBWorker = PEUtility.OpenDBWorker(Working.T92StMGt1p4());
		IntPtr intPtr = levelDBWorker.CreateWriteBatch();
		List<ChunkLink> list = GenChunkList(args);
		if (args.FlipLeftToRight || args.FlipTopToBottom)
		{
			list = FlipChunkList(args, list);
		}
		if (args.Rotation != 0)
		{
			list = RotateChunkList(args, list);
		}
		for (int i = 0; i <= num3; i++)
		{
			for (int j = 0; j <= num2; j++)
			{
				int index = i * (num2 + 1) + j;
				int num6 = args.X1 + j;
				int num7 = args.Z1 + i;
				i17SkJlTG5U(args, list[index].srcX, list[index].srcZ, num6, num7, pEDimension, levelDBWorker, intPtr);
				if (++num > 1024)
				{
					intPtr = VUHSkDlqPd4(intPtr, levelDBWorker);
					num = 0;
				}
				zU6Skc7CFnh(++num5, num4);
			}
		}
		if (num > 0)
		{
			levelDBWorker.WriteBatch(intPtr);
			levelDBWorker.DestroyWriteBatch(intPtr);
		}
		levelDBWorker.CloseDB();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<ChunkLink> GenChunkList(AreaActionEventArgs args)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = args.X2 - args.X1;
		int num2 = args.Z2 - args.Z1;
		int num3 = 0;
		int num4 = 0;
		_ = args.X1;
		_ = args.X1;
		_ = args.Z1;
		_ = args.Z1;
		List<ChunkLink> list = new List<ChunkLink>();
		for (int i = args.Z1; i <= args.Z2; i++)
		{
			num4 = 0;
			for (int j = args.X1; j <= args.X2; j++)
			{
				list.Add(new ChunkLink(num3, num4, 0, 0));
				num4++;
			}
			num3++;
		}
		return list;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<ChunkLink> FlipChunkList(AreaActionEventArgs args, List<ChunkLink> inChunkLinks)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ChunkLink[] array = new ChunkLink[inChunkLinks.Count];
		bool flag = Math.Abs(args.Rotation) == 90 || Math.Abs(args.Rotation) == 270;
		int num = args.X2 - args.X1;
		int num2 = args.Z2 - args.Z1;
		num++;
		num2++;
		for (int i = 0; i < inChunkLinks.Count; i++)
		{
			int num3 = i % num;
			int num4 = i / num;
			if ((!flag && args.FlipLeftToRight) || (flag && args.FlipTopToBottom))
			{
				num3 = num - 1 - num3;
			}
			if ((!flag && args.FlipTopToBottom) || (flag && args.FlipLeftToRight))
			{
				num4 = num2 - 1 - num4;
			}
			int num5 = num4 * num + num3;
			array[num5] = inChunkLinks[i];
		}
		return array.ToList();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<ChunkLink> RotateChunkList(AreaActionEventArgs args, List<ChunkLink> inChunkLinks)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = args.X2 - args.X1;
		int num2 = args.Z2 - args.Z1;
		ChunkLink[] array = new ChunkLink[inChunkLinks.Count];
		if (Math.Abs(args.Rotation) == 180)
		{
			for (int i = 0; i <= num2; i++)
			{
				for (int j = 0; j <= num; j++)
				{
					int index = i * (num + 1) + j;
					int num3 = (num2 - i) * (num + 1) + num - j;
					array[num3] = inChunkLinks[index];
				}
			}
		}
		else if (args.Rotation == -90 || args.Rotation == 270)
		{
			int num4 = 0;
			for (int k = 0; k <= num2; k++)
			{
				for (int l = 0; l <= num; l++)
				{
					int num5 = (num - l) * (num2 + 1) + k;
					array[num5] = inChunkLinks[num4++];
				}
			}
		}
		else if (args.Rotation == 90 || args.Rotation == -270)
		{
			int num6 = 0;
			for (int m = 0; m <= num2; m++)
			{
				for (int n = 0; n <= num; n++)
				{
					int num7 = n * (num2 + 1) + (num2 - m);
					array[num7] = inChunkLinks[num6++];
				}
			}
		}
		return array.ToList();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private IntPtr VUHSkDlqPd4(IntPtr P_0, LevelDBWorker P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_1.WriteBatch(P_0);
		P_1.DestroyWriteBatch(P_0);
		return P_1.CreateWriteBatch();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void zU6Skc7CFnh(int P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_0++;
		int num = (int)((float)P_0 / (float)P_1 * 100f);
		if (num > 100)
		{
			num = 100;
		}
		string text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(244162) + P_0 + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71754) + P_1;
		gFHSYS7MDjy(text, num);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void i17SkJlTG5U(AreaActionEventArgs P_0, int P_1, int P_2, int P_3, int P_4, PEDimension P_5, LevelDBWorker P_6, IntPtr P_7)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound tagNodeCompound = aRMSk8KVHtc(P_0.Path, P_1, P_2);
		if (tagNodeCompound == null)
		{
			return;
		}
		TagNodeCompound tagNodeCompound2 = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18204)] as TagNodeCompound;
		if (P_0.YOffset != 0 && tagNodeCompound2.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20548)))
		{
			TagNodeList tagNodeList = tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20548)] as TagNodeList;
			tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20548)] = hnHSkuh46IR(P_0, tagNodeList);
		}
		if (P_0.Rotation != 0 || P_0.FlipLeftToRight || P_0.FlipTopToBottom)
		{
			if (tagNodeCompound2.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20548)))
			{
				TagNodeList tagNodeList2 = tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20548)] as TagNodeList;
				D0TSkALN7Jd(P_0, tagNodeList2);
			}
			if (tagNodeCompound2.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65008)))
			{
				if (P_0.FlipLeftToRight || P_0.FlipTopToBottom)
				{
					TagNodeIntArray tagNodeIntArray = tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65008)] as TagNodeIntArray;
					tagNodeIntArray.Data = cxdSkFpETA5(P_0, tagNodeIntArray);
				}
				if (P_0.Rotation != 0)
				{
					TagNodeIntArray tagNodeIntArray2 = tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65008)] as TagNodeIntArray;
					tagNodeIntArray2.Data = PHfSkjaGlYW(P_0, tagNodeIntArray2);
				}
			}
		}
		tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64984)] = new TagNodeInt(P_3);
		tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64996)] = new TagNodeInt(P_4);
		vfiSkIQVP0s(tagNodeCompound2, P_3, P_4);
		GWdSkzbMBFG(tagNodeCompound2, P_3, P_4);
		PEChunkWorker pEChunkWorker = new PEChunkWorker(P_7);
		pEChunkWorker.WriteModifiedChunk(P_0.Dimension, tagNodeCompound, 256, P_6);
		P_5.AddChunkEntryToRegion(P_3, P_4);
		int num = (int)Math.Floor((double)P_3 / 32.0);
		int num2 = (int)Math.Floor((double)P_4 / 32.0);
		string item = num + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13710) + num2;
		if (!P_0.RegionEntries.Contains(item))
		{
			P_0.RegionEntries.Add(item);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNodeList hnHSkuh46IR(AreaActionEventArgs P_0, TagNodeList P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeList tagNodeList = new TagNodeList(TagType.TAG_COMPOUND);
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		int num = ((P_0.YOffset >= 0) ? (P_0.YOffset / 16) : 0);
		int num2 = ((P_0.YOffset >= 0) ? (P_0.YOffset % 16) : 0);
		int num3 = ((P_0.YOffset < 0) ? ((256 - (P_0.YOffset + 256)) / 16) : 0);
		int num4 = ((P_0.YOffset < 0) ? ((256 - (P_0.YOffset + 256)) % 16) : 0);
		Dictionary<int, TagNodeCompound> dictionary2 = new Dictionary<int, TagNodeCompound>();
		int[] array = null;
		int[] array2 = null;
		TagNodeList tagNodeList2 = new TagNodeList(TagType.TAG_COMPOUND);
		for (int i = 0; i < P_1.Count; i++)
		{
			TagNodeCompound tagNodeCompound = P_1[i] as TagNodeCompound;
			int key = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38782)].ToTagInt();
			dictionary2[key] = tagNodeCompound;
		}
		TagNodeCompound tagNodeCompound2 = null;
		if (dictionary2.ContainsKey(num3))
		{
			tagNodeCompound2 = dictionary2[num3];
			array = JpuSkoMMqhs(tagNodeCompound2);
			i5vSkQuGyNE(tagNodeCompound2, tagNodeList2, dictionary);
		}
		for (int j = num; j < 16; j++)
		{
			array2 = new int[4096];
			tagNodeList2 = new TagNodeList(TagType.TAG_COMPOUND);
			dictionary.Clear();
			if (tagNodeCompound2 != null)
			{
				i5vSkQuGyNE(tagNodeCompound2, tagNodeList2, dictionary);
			}
			for (int k = num2; k < 16; k++)
			{
				if (tagNodeCompound2 != null)
				{
					HpdSk7txSfo(P_0, array, array2, num4, k, dictionary);
				}
				num4++;
				if (num4 > 15)
				{
					num4 = 0;
					num3++;
					tagNodeCompound2 = null;
					dictionary.Clear();
					if (dictionary2.ContainsKey(num3))
					{
						tagNodeCompound2 = dictionary2[num3];
						array = JpuSkoMMqhs(tagNodeCompound2);
						i5vSkQuGyNE(tagNodeCompound2, tagNodeList2, dictionary);
					}
				}
			}
			if (tagNodeList2.Count > 0)
			{
				TagNodeCompound tagNodeCompound3 = wRDSkOXZvrO(j);
				P8gSkCGDN47(tagNodeCompound3, tagNodeList2, array2);
				tagNodeList.Add(tagNodeCompound3);
			}
			num2 = 0;
		}
		return tagNodeList;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int[] JpuSkoMMqhs(TagNodeCompound P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeList tagNodeList = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38804)] as TagNodeList;
		TagNodeCompound tagNodeCompound = tagNodeList[0] as TagNodeCompound;
		TagNodeIntArray tagNodeIntArray = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38832)] as TagNodeIntArray;
		_ = tagNodeIntArray.Data;
		return tagNodeIntArray;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void i5vSkQuGyNE(TagNodeCompound P_0, TagNodeList P_1, Dictionary<int, int> P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeList tagNodeList = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38804)] as TagNodeList;
		TagNodeCompound tagNodeCompound = tagNodeList[0] as TagNodeCompound;
		TagNodeList tagNodeList2 = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38858)] as TagNodeList;
		for (int i = 0; i < tagNodeList2.Count; i++)
		{
			P_2[i] = P_1.Count;
			P_1.Add(tagNodeList2[i]);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNodeCompound wRDSkOXZvrO(int P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound tagNodeCompound = new TagNodeCompound();
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38782)] = new TagNodeByte((byte)P_0);
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(35604)] = new TagNodeByte(8);
		TagNodeList value = new TagNodeList(TagType.TAG_COMPOUND);
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38804)] = value;
		return tagNodeCompound;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void P8gSkCGDN47(TagNodeCompound P_0, TagNodeList P_1, int[] P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound tagNodeCompound = new TagNodeCompound();
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38858)] = P_1;
		tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38832)] = new TagNodeIntArray(P_2);
		((TagNodeList)P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38804)]).Add(tagNodeCompound);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HpdSk7txSfo(AreaActionEventArgs P_0, int[] P_1, int[] P_2, int P_3, int P_4, Dictionary<int, int> P_5)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < 16; i++)
		{
			for (int j = 0; j < 16; j++)
			{
				num = i * 16 + j + P_3 * 256;
				num2 = i * 16 + j + P_4 * 256;
				P_2[num2] = P_5[P_1[num]];
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void D0TSkALN7Jd(AreaActionEventArgs P_0, TagNodeList P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		for (int i = 0; i < P_1.Count; i++)
		{
			TagNodeCompound tagNodeCompound = P_1[i] as TagNodeCompound;
			if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38788)) && tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38788)] is TagNodeByteArray)
			{
				TagNodeByteArray tagNodeByteArray = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38788)] as TagNodeByteArray;
				TagNodeByteArray tagNodeByteArray2 = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11178)] as TagNodeByteArray;
				_ = tagNodeByteArray.Data;
				_ = tagNodeByteArray2.Data;
				for (int j = 0; j < 16; j++)
				{
					for (int k = 0; k < 256; k++)
					{
					}
				}
			}
			else
			{
				if (!tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38804)) || !(tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38804)] is TagNodeList))
				{
					continue;
				}
				TagNodeList tagNodeList = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38804)] as TagNodeList;
				for (int l = 0; l < tagNodeList.Count; l++)
				{
					TagNodeCompound tagNodeCompound2 = tagNodeList[l] as TagNodeCompound;
					TagNodeIntArray tagNodeIntArray = tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38832)] as TagNodeIntArray;
					int[] array = tagNodeIntArray.Data;
					int[] array2 = new int[array.Length];
					if (P_0.FlipLeftToRight || P_0.FlipTopToBottom)
					{
						for (int m = 0; m < 16; m++)
						{
							huTSkdTMl0h(P_0, array, array2, m * 256);
						}
						array = array2.ToArray();
						tagNodeIntArray.Data = array2;
					}
					if (P_0.Rotation != 0)
					{
						for (int n = 0; n < 16; n++)
						{
							pceSkH6AcbX(P_0, array, array2, n * 256);
						}
						tagNodeIntArray.Data = array2;
					}
				}
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int[] huTSkdTMl0h(AreaActionEventArgs P_0, int[] P_1, int[] P_2, int P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bool flag = Math.Abs(P_0.Rotation) == 90 || Math.Abs(P_0.Rotation) == 270;
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < 16; i++)
		{
			for (int j = 0; j < 16; j++)
			{
				num = i;
				num2 = j;
				if ((!flag && P_0.FlipLeftToRight) || (flag && P_0.FlipTopToBottom))
				{
					num2 = 15 - j;
				}
				if ((!flag && P_0.FlipTopToBottom) || (flag && P_0.FlipLeftToRight))
				{
					num = 15 - i;
				}
				int num3 = i * 16 + j + P_3;
				int num4 = num * 16 + num2 + P_3;
				P_2[num4] = P_1[num3];
			}
		}
		return P_2;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int[] pceSkH6AcbX(AreaActionEventArgs P_0, int[] P_1, int[] P_2, int P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < 16; i++)
		{
			for (int j = 0; j < 16; j++)
			{
				if (P_0.Rotation == 90 || P_0.Rotation == -270)
				{
					num = j;
					num2 = 15 - i;
				}
				else if (P_0.Rotation == -90 || P_0.Rotation == 270)
				{
					num = 15 - j;
					num2 = i;
				}
				else if (P_0.Rotation == 180 || P_0.Rotation == -180)
				{
					num = 15 - i;
					num2 = 15 - j;
				}
				int num3 = i * 16 + j + P_3;
				int num4 = num * 16 + num2 + P_3;
				P_2[num4] = P_1[num3];
			}
		}
		return P_2;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int[] cxdSkFpETA5(AreaActionEventArgs P_0, int[] P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int[] array = new int[P_1.Length];
		int num = 0;
		int num2 = 0;
		bool flag = Math.Abs(P_0.Rotation) == 90 || Math.Abs(P_0.Rotation) == 270;
		for (int i = 0; i < 16; i++)
		{
			for (int j = 0; j < 16; j++)
			{
				num = i;
				num2 = j;
				if ((!flag && P_0.FlipLeftToRight) || (flag && P_0.FlipTopToBottom))
				{
					num2 = 15 - j;
				}
				if ((!flag && P_0.FlipTopToBottom) || (flag && P_0.FlipLeftToRight))
				{
					num = 15 - i;
				}
				int num3 = i * 16 + j;
				int num4 = num * 16 + num2;
				array[num4] = P_1[num3];
			}
		}
		return array;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int[] PHfSkjaGlYW(AreaActionEventArgs P_0, int[] P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int[] array = new int[P_1.Length];
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < 16; i++)
		{
			for (int j = 0; j < 16; j++)
			{
				if (P_0.Rotation == 90 || P_0.Rotation == -270)
				{
					num = j;
					num2 = 15 - i;
				}
				else if (P_0.Rotation == -90 || P_0.Rotation == 270)
				{
					num = 15 - j;
					num2 = i;
				}
				else if (P_0.Rotation == 180 || P_0.Rotation == -180)
				{
					num = 15 - i;
					num2 = 15 - j;
				}
				int num3 = i * 16 + j;
				int num4 = num * 16 + num2;
				array[num4] = P_1[num3];
			}
		}
		return array;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNodeCompound aRMSk8KVHtc(string P_0, int P_1, int P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LevelDBWorker levelDBWorker = PEUtility.OpenDBWorker(P_0);
		byte[] key = PEUtility.BuildChunkKey(P_1, P_2);
		byte[] array = levelDBWorker.ReadDbValue(key);
		levelDBWorker.CloseDB();
		if (array != null)
		{
			MemoryStream s = new MemoryStream(array);
			NbtTree nbtTree = new NbtTree();
			nbtTree.UseBigEndian = true;
			nbtTree.ReadFrom(s);
			return nbtTree.Root;
		}
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FillAreaWithChunk(AreaActionEventArgs args)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = 0;
		int num2 = args.X2 - args.X1 + 1;
		int num3 = args.Z2 - args.Z1 + 1;
		int num4 = num2 * num3;
		int num5 = 0;
		PEDimension pEDimension = fphSk9mdotx(args.Dimension);
		LevelDBWorker levelDBWorker = PEUtility.OpenDBWorker(Working.T92StMGt1p4());
		IntPtr batch = levelDBWorker.CreateWriteBatch();
		if (!File.Exists(args.Path))
		{
			return;
		}
		byte[] array = FileUtils.pURSg6Zk53A(args.Path);
		if (array != null)
		{
			array = lxe7hMuSirBXGUQugsD.KpwSP5kgJSU(array);
			MemoryStream s = new MemoryStream(array);
			NbtTree nbtTree = new NbtTree();
			nbtTree.UseBigEndian = true;
			nbtTree.ReadFrom(s);
			TagNodeCompound root = nbtTree.Root;
			if (root != null)
			{
				for (int i = args.X1; i <= args.X2; i++)
				{
					for (int j = args.Z1; j <= args.Z2; j++)
					{
						TagNodeCompound tagNodeCompound = root[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18204)] as TagNodeCompound;
						tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64984)] = new TagNodeInt(i);
						tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64996)] = new TagNodeInt(j);
						vfiSkIQVP0s(tagNodeCompound, i, j);
						GWdSkzbMBFG(tagNodeCompound, i, j);
						PEChunkWorker pEChunkWorker = new PEChunkWorker(batch);
						pEChunkWorker.WriteModifiedChunk(args.Dimension, root, 256, levelDBWorker);
						pEDimension.AddChunkEntryToRegion(i, j);
						int num6 = (int)Math.Floor((double)i / 32.0);
						int num7 = (int)Math.Floor((double)j / 32.0);
						string item = num6 + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13710) + num7;
						if (!args.RegionEntries.Contains(item))
						{
							args.RegionEntries.Add(item);
						}
						num++;
						if (num > 1024)
						{
							levelDBWorker.WriteBatch(batch);
							levelDBWorker.DestroyWriteBatch(batch);
							batch = levelDBWorker.CreateWriteBatch();
							num = 0;
						}
						num5++;
						int num8 = (int)((float)num5 / (float)num4 * 100f);
						if (num8 > 100)
						{
							num8 = 100;
						}
						string text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(243178) + num5 + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71754) + num4;
						gFHSYS7MDjy(text, num8);
					}
				}
			}
		}
		if (num > 0)
		{
			levelDBWorker.WriteBatch(batch);
			levelDBWorker.DestroyWriteBatch(batch);
		}
		levelDBWorker.CloseDB();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private PEDimension fphSk9mdotx(int P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Working.PEDimensions == null)
		{
			List<PEDimension> list = new List<PEDimension>();
			list.Add(new PEDimension(0));
			list.Add(new PEDimension(1));
			list.Add(new PEDimension(2));
			Working.PEDimensions = list;
		}
		return Working.PEDimensions[P_0];
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void vfiSkIQVP0s(TagNodeCompound P_0, int P_1, int P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42124)))
		{
			return;
		}
		TagNodeList tagNodeList = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42124)] as TagNodeList;
		for (int i = 0; i < tagNodeList.Count; i++)
		{
			TagNodeCompound tagNodeCompound = tagNodeList[i] as TagNodeCompound;
			if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17418)))
			{
				TagNodeList tagNodeList2 = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17418)] as TagNodeList;
				float num = tagNodeList2[0] as TagNodeFloat;
				float num2 = tagNodeList2[2] as TagNodeFloat;
				num = ChangeBlockCoord((int)num, P_1);
				num2 = ChangeBlockCoord((int)num2, P_2);
				tagNodeList2[0] = new TagNodeFloat(num);
				tagNodeList2[2] = new TagNodeFloat(num2);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GWdSkzbMBFG(TagNodeCompound P_0, int P_1, int P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63796)))
		{
			TagNodeList tagNodeList = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63796)] as TagNodeList;
			for (int i = 0; i < tagNodeList.Count; i++)
			{
				TagNodeCompound tagNodeCompound = tagNodeList[i] as TagNodeCompound;
				int coord = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65786)] as TagNodeInt;
				int coord2 = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65792)] as TagNodeInt;
				coord = ChangeBlockCoord(coord, P_1);
				coord2 = ChangeBlockCoord(coord2, P_2);
				tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65786)] = new TagNodeInt(coord);
				tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65792)] = new TagNodeInt(coord2);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int ChangeBlockCoord(int Coord, int chunk)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = sthSYTiXEFy(Coord, 16);
		int num2 = chunk * 16;
		return num2 + num;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int sthSYTiXEFy(int P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return (P_0 % P_1 + P_1) % P_1;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void gFHSYS7MDjy(string P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (eJHSYGhLCpp != null)
		{
			eJHSYGhLCpp.ReportProgress(P_1, P_0);
		}
	}
}
