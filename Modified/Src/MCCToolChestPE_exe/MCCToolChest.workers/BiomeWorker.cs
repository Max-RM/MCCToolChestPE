using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using MCCToolChest.events;
using MCCToolChest.PECode;
using MCPELevelDBI.workers;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.workers;

public class BiomeWorker
{
	private BackgroundWorker yLCSR7inurW;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BiomeWorker()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BiomeWorker(BackgroundWorker backgroundWorker)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		yLCSR7inurW = backgroundWorker;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DoBiomeFillArea(AreaActionEventArgs args, string path)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = (args.X2 - args.X1 + ((args.X1 <= 0 && args.X2 >= 0) ? 1 : 0)) * (args.Z2 - args.Z1 + ((args.Z1 <= 0 && args.Z2 >= 0) ? 1 : 0));
		int num2 = 0;
		LevelDBWorker levelDBWorker = PEUtility.OpenDBWorker(path);
		for (int i = args.X1; i <= args.X2; i++)
		{
			for (int j = args.Z1; j <= args.Z2; j++)
			{
				gSFSROwqf7N(args.Dimension, args.Biome, i, j, levelDBWorker);
				if (yLCSR7inurW != null)
				{
					num2++;
					int num3 = (int)((float)num2 / (float)num * 100f);
					if (num3 > 100)
					{
						num3 = 100;
					}
					string userState = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(243178) + num2 + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(71754) + num;
					yLCSR7inurW.ReportProgress(num3, userState);
				}
			}
		}
		levelDBWorker.CloseDB();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool gSFSROwqf7N(int P_0, int P_1, int P_2, int P_3, LevelDBWorker P_4)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bool result = false;
		byte[] key = PEUtility.BuildChunkKey(P_0, P_2, P_3, 45);
		byte[] array = P_4.ReadDbValue(key);
		if (array != null)
		{
			byte[] array2 = array.Skip(512).Take(256).ToArray();
			m9kSRCXueCt(array2, P_1);
			MemoryStream memoryStream = new MemoryStream();
			memoryStream.Write(array, 0, 512);
			memoryStream.Write(array2, 0, 256);
			P_4.Put(key, memoryStream.ToArray());
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void m9kSRCXueCt(byte[] P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0 != null)
		{
			for (int i = 0; i < P_0.Length; i++)
			{
				P_0[i] = (byte)P_1;
			}
		}
	}
}
