using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using afNMf7uWOyq6L7IHxiu;
using MCCToolChest.model;
using MCCToolChest.PECode;
using MCPELevelDBI.workers;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.MCSBCode;

public class LogicDeleteTickingAreas
{
	private StringBuilder VrLIEvwmYX;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string ProcessRegions()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PEDimension pEDimension = PEUtility.GetPEDimension(Constants.dimensionFolderNames[0]);
		VrLIEvwmYX.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64220));
		LevelDBWorker levelDBWorker = new LevelDBWorker();
		levelDBWorker.OpenDB(Path.Combine(Working.T92StMGt1p4(), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64270)));
		foreach (PERegion value in pEDimension.Region.Values)
		{
			ProcessRegion(value, levelDBWorker);
		}
		levelDBWorker.CloseDB();
		return VrLIEvwmYX.ToString();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ProcessRegion(PERegion peRegion, LevelDBWorker dbWorker)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		for (int i = 0; i < 32; i++)
		{
			for (int j = 0; j < 32; j++)
			{
				kddI1LO48B(peRegion, lxe7hMuSirBXGUQugsD.QdsSP76hcgY(i, peRegion.RX), lxe7hMuSirBXGUQugsD.QdsSP76hcgY(j, peRegion.RZ), dbWorker);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void kddI1LO48B(PERegion P_0, int P_1, int P_2, LevelDBWorker P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = lxe7hMuSirBXGUQugsD.e1cSPCO6PUl(P_1, P_0.RX);
		int num2 = lxe7hMuSirBXGUQugsD.e1cSPCO6PUl(P_2, P_0.RZ);
		int num3 = lxe7hMuSirBXGUQugsD.rMDSPOktq2F(num, num2);
		if (P_0.Chunks[num3] == 1)
		{
			byte[] key = PEUtility.BuildChunkKey(P_0.Dimension, num, num2, 51);
			byte[] array = P_3.ReadDbValue(key);
			if (array != null)
			{
				VrLIEvwmYX.AppendLine(string.Format(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64278), num, num2));
				P_3.Delete(key);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LogicDeleteTickingAreas()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		VrLIEvwmYX = new StringBuilder();
	}
}
