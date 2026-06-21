using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.model;
using MCCToolChest.Properties;
using NBTExplorer.Model;
using NBTExplorer.Windows;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.forms;

public class MCFindBlock : Form
{
	public class FindBlockData
	{
		public int x;

		public int z;

		public int dimension;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public FindBlockData()
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		}
	}

	private class id8IfMeT4D8e9JJq6S
	{
		public int? BmKFWfhYtY;

		public int? cUEFpYF4Xd;

		public WatermarkTextBox oIRFZduAQp;

		public WatermarkTextBox ePvFfxMynt;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public id8IfMeT4D8e9JJq6S()
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		}
	}

	private bool gZBHo9FwLn;

	private id8IfMeT4D8e9JJq6S WiLHQraSOs;

	private id8IfMeT4D8e9JJq6S jxxHOklgkf;

	private FindBlockData O72HC9Pjlv;

	private ChunkLookup JFLH7qMDkT;

	private string[] wUpHA2YogJ;

	private IContainer clOHdw3WA8;

	private TableLayoutPanel zicHHKvvWo;

	private GroupBox Uv5HFElDeR;

	private GroupBox KpvHjQ1MZX;

	private Label feCH8PUWAm;

	private Label MjIH9WTyg9;

	private WatermarkTextBox ljAHIP04kd;

	private WatermarkTextBox zeOHz9Zyi0;

	private Label dL4FT0qInI;

	private Label FvoFSaqmQO;

	private WatermarkTextBox XS4FGLP1Uc;

	private WatermarkTextBox UFVFbqjeFS;

	private Button sGFFvKU8qN;

	private Button CcyFwPIAYH;

	private ComboBox NJAF4CwjNi;

	private Label pxpFVUTb4g;

	public FindBlockData SearchData
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return O72HC9Pjlv;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MCFindBlock(ChunkLookup chunkLookups)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		BPqHuUEFnw();
		PopulateDimensionCombo();
		WiLHQraSOs = new id8IfMeT4D8e9JJq6S
		{
			oIRFZduAQp = UFVFbqjeFS,
			ePvFfxMynt = zeOHz9Zyi0
		};
		jxxHOklgkf = new id8IfMeT4D8e9JJq6S
		{
			oIRFZduAQp = XS4FGLP1Uc,
			ePvFfxMynt = ljAHIP04kd
		};
		hdpH395jFq();
		JFLH7qMDkT = chunkLookups;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private DataNode IVEH4emoPo(DataNode P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0 is DirectoryDataNode)
		{
			DirectoryDataNode directoryDataNode = P_0 as DirectoryDataNode;
			if (!directoryDataNode.IsExpanded)
			{
				directoryDataNode.Expand();
			}
			foreach (DataNode node in directoryDataNode.Nodes)
			{
				DataNode dataNode = IVEH4emoPo(node);
				if (dataNode != null)
				{
					return dataNode;
				}
			}
			return null;
		}
		if (P_0 is RegionFileDataNode)
		{
			RegionFileDataNode regionFileDataNode = P_0 as RegionFileDataNode;
			if (!RegionFileDataNode.RegionCoordinates(regionFileDataNode.NodePathName, out var _, out var _))
			{
				return null;
			}
			if (!regionFileDataNode.IsExpanded)
			{
				regionFileDataNode.Expand();
			}
			foreach (DataNode node2 in regionFileDataNode.Nodes)
			{
				DataNode dataNode2 = IVEH4emoPo(node2);
				if (dataNode2 != null)
				{
					return dataNode2;
				}
			}
			return null;
		}
		if (P_0 is RegionChunkDataNode)
		{
			return P_0 as RegionChunkDataNode;
		}
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int VmOHVuU93k(int P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return (P_0 % P_1 + P_1) % P_1;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string qwsHWBKnAn(int P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return (P_0 >> 4 >> 5).ToString();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string KFWHpnxeI4(int P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return (P_0 >> 4).ToString();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string GaFHZbkf0N(int P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return VmOHVuU93k(P_0 >> 4, 32).ToString();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string VGaHflYf5H(int P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return VmOHVuU93k(P_0, 16).ToString();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string zjpHi3iLIo(int P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return (P_0 >> 5).ToString();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string pP9HsLtt8D(int P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = P_0 * 16;
		int num2 = (P_0 + 1) * 16 - 1;
		return string.Format(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60362), num, num2);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string sOKHqAtsmc(int P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return (P_0 * 16 + P_1).ToString();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string Rg0HK8K47l(int P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return VmOHVuU93k(P_0, 32).ToString();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string hBdHh8Vnn1(int P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60390);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string CjXHm01RiW(int P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = P_0 * 32;
		int num2 = (P_0 + 1) * 32 - 1;
		return string.Format(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60362), num, num2);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string IwBHnfiZrP(int P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = P_0 * 32 * 16;
		int num2 = (P_0 + 1) * 32 * 16 - 1;
		return string.Format(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60362), num, num2);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string fNCHlTpvVa(int P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60412);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string qQWH2nRiml(int P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60390);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string C5YHywMONS(int P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60434);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string hvUH0HL9Hy(int P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60434);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string lnxHBsO1bx(int P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return (P_0 * 32 + P_1).ToString();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string glVHt7p8ZG(int P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60434);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string NXxHarSOwM(int P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return pP9HsLtt8D(P_0 * 32 + P_1);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string nGWHXkAyXm(int P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60390);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string QkdHxEAHSQ(int P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60390);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string xVXHe5XqjO(int P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60434);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string FRQHMPgd3L(int P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60434);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string DFkHUEDLLp(int P_0, int P_1, int P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return (P_0 * 32 + P_1).ToString();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string TSVHLXrteo(int P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60434);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string zWMHguVBxU(int P_0, int P_1, int P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return (P_0 * 32 * 16 + P_1 * 16 + P_2).ToString();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int? bkCHPkSEme(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (int.TryParse(P_0, out var result))
		{
			return result;
		}
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void w7xHRXYUPN(WatermarkTextBox P_0, string P_1, bool P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_2)
		{
			P_0.ApplyText(P_1);
		}
		else
		{
			P_0.ApplyWatermark(P_1);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GqPHkDJOGn(id8IfMeT4D8e9JJq6S P_0, string P_1, bool P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_0.BmKFWfhYtY = bkCHPkSEme(P_1);
		w7xHRXYUPN(P_0.oIRFZduAQp, P_1, P_2);
		if (P_2 && P_0.BmKFWfhYtY.HasValue)
		{
			QL7HYmP0rB(P_0, pP9HsLtt8D(P_0.BmKFWfhYtY.Value), false);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void QL7HYmP0rB(id8IfMeT4D8e9JJq6S P_0, string P_1, bool P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_0.cUEFpYF4Xd = bkCHPkSEme(P_1);
		w7xHRXYUPN(P_0.ePvFfxMynt, P_1, P_2);
		if (P_2 && P_0.cUEFpYF4Xd.HasValue)
		{
			GqPHkDJOGn(P_0, KFWHpnxeI4(P_0.cUEFpYF4Xd.Value), false);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PopulateDimensionCombo()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		NJAF4CwjNi.Items.Clear();
		foreach (DimensionListItem dimensionListItem in Constants.GetDimensionListItems())
		{
			NJAF4CwjNi.Items.Add(dimensionListItem);
		}
		if (NJAF4CwjNi.Items.Count > 0)
		{
			NJAF4CwjNi.SelectedIndex = 0;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hdpH395jFq()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (WiLHQraSOs.BmKFWfhYtY.HasValue && jxxHOklgkf.BmKFWfhYtY.HasValue)
		{
			sGFFvKU8qN.Enabled = true;
		}
		else
		{
			sGFFvKU8qN.Enabled = false;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void avXH1b9gn9(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int result = 0;
		if (!gZBHo9FwLn && int.TryParse(UFVFbqjeFS.Text, out result))
		{
			gZBHo9FwLn = true;
			GqPHkDJOGn(WiLHQraSOs, UFVFbqjeFS.Text, true);
			gZBHo9FwLn = false;
			hdpH395jFq();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void zwNHEWqg1Z(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int result = 0;
		if (!gZBHo9FwLn && int.TryParse(XS4FGLP1Uc.Text, out result))
		{
			gZBHo9FwLn = true;
			GqPHkDJOGn(jxxHOklgkf, XS4FGLP1Uc.Text, true);
			gZBHo9FwLn = false;
			hdpH395jFq();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void U1hHrNjQHd(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int result = 0;
		if (!gZBHo9FwLn && int.TryParse(zeOHz9Zyi0.Text, out result))
		{
			gZBHo9FwLn = true;
			QL7HYmP0rB(WiLHQraSOs, zeOHz9Zyi0.Text, true);
			gZBHo9FwLn = false;
			hdpH395jFq();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hjQH5L1n6w(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int result = 0;
		if (!gZBHo9FwLn && int.TryParse(ljAHIP04kd.Text, out result))
		{
			gZBHo9FwLn = true;
			QL7HYmP0rB(jxxHOklgkf, ljAHIP04kd.Text, true);
			gZBHo9FwLn = false;
			hdpH395jFq();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EjjH6OJL9i(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		FindBlockData findBlockData = new FindBlockData();
		int.TryParse(UFVFbqjeFS.Text, out findBlockData.x);
		int.TryParse(XS4FGLP1Uc.Text, out findBlockData.z);
		findBlockData.dimension = (NJAF4CwjNi.SelectedItem as DimensionListItem)?.DimensionId ?? NJAF4CwjNi.SelectedIndex;
		if (aXAHNnWK2N(findBlockData))
		{
			O72HC9Pjlv = findBlockData;
			base.DialogResult = DialogResult.OK;
			Close();
		}
		else
		{
			MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60448), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60492));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool aXAHNnWK2N(FindBlockData P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return JFLH7qMDkT.DoesChunkExist(P_0.dimension, P_0.x, P_0.z);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void pG9HDTUuha(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YiuHccCO9h(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		zeOHz9Zyi0.Focus();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void zP6HJudeCJ(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.Icon = Resources.usMSrbJo37S();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && clOHdw3WA8 != null)
		{
			clOHdw3WA8.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BPqHuUEFnw()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		zicHHKvvWo = new TableLayoutPanel();
		Uv5HFElDeR = new GroupBox();
		feCH8PUWAm = new Label();
		MjIH9WTyg9 = new Label();
		ljAHIP04kd = new WatermarkTextBox();
		zeOHz9Zyi0 = new WatermarkTextBox();
		KpvHjQ1MZX = new GroupBox();
		dL4FT0qInI = new Label();
		FvoFSaqmQO = new Label();
		XS4FGLP1Uc = new WatermarkTextBox();
		UFVFbqjeFS = new WatermarkTextBox();
		sGFFvKU8qN = new Button();
		CcyFwPIAYH = new Button();
		NJAF4CwjNi = new ComboBox();
		pxpFVUTb4g = new Label();
		zicHHKvvWo.SuspendLayout();
		Uv5HFElDeR.SuspendLayout();
		KpvHjQ1MZX.SuspendLayout();
		SuspendLayout();
		zicHHKvvWo.ColumnCount = 2;
		zicHHKvvWo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		zicHHKvvWo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.00001f));
		zicHHKvvWo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20f));
		zicHHKvvWo.Controls.Add(Uv5HFElDeR, 1, 0);
		zicHHKvvWo.Controls.Add(KpvHjQ1MZX, 0, 0);
		zicHHKvvWo.Location = new Point(7, 50);
		zicHHKvvWo.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10826);
		zicHHKvvWo.RowCount = 1;
		zicHHKvvWo.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		zicHHKvvWo.Size = new Size(276, 80);
		zicHHKvvWo.TabIndex = 1;
		Uv5HFElDeR.Controls.Add(feCH8PUWAm);
		Uv5HFElDeR.Controls.Add(MjIH9WTyg9);
		Uv5HFElDeR.Controls.Add(ljAHIP04kd);
		Uv5HFElDeR.Controls.Add(zeOHz9Zyi0);
		Uv5HFElDeR.Location = new Point(140, 3);
		Uv5HFElDeR.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42342);
		Uv5HFElDeR.Size = new Size(133, 70);
		Uv5HFElDeR.TabIndex = 2;
		Uv5HFElDeR.TabStop = false;
		Uv5HFElDeR.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11032);
		feCH8PUWAm.AutoSize = true;
		feCH8PUWAm.Location = new Point(6, 48);
		feCH8PUWAm.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11162);
		feCH8PUWAm.Size = new Size(17, 13);
		feCH8PUWAm.TabIndex = 7;
		feCH8PUWAm.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60528);
		MjIH9WTyg9.AutoSize = true;
		MjIH9WTyg9.Location = new Point(6, 22);
		MjIH9WTyg9.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11298);
		MjIH9WTyg9.Size = new Size(17, 13);
		MjIH9WTyg9.TabIndex = 6;
		MjIH9WTyg9.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60536);
		ljAHIP04kd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		ljAHIP04kd.ForeColor = Color.Gray;
		ljAHIP04kd.Location = new Point(27, 45);
		ljAHIP04kd.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60544);
		ljAHIP04kd.Size = new Size(100, 20);
		ljAHIP04kd.TabIndex = 1;
		ljAHIP04kd.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60576);
		ljAHIP04kd.WatermarkActive = true;
		ljAHIP04kd.WatermarkText = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60576);
		ljAHIP04kd.TextChanged += hjQH5L1n6w;
		zeOHz9Zyi0.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		zeOHz9Zyi0.ForeColor = Color.Gray;
		zeOHz9Zyi0.Location = new Point(27, 19);
		zeOHz9Zyi0.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60598);
		zeOHz9Zyi0.Size = new Size(100, 20);
		zeOHz9Zyi0.TabIndex = 0;
		zeOHz9Zyi0.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60576);
		zeOHz9Zyi0.WatermarkActive = true;
		zeOHz9Zyi0.WatermarkText = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60576);
		zeOHz9Zyi0.TextChanged += U1hHrNjQHd;
		KpvHjQ1MZX.Controls.Add(dL4FT0qInI);
		KpvHjQ1MZX.Controls.Add(FvoFSaqmQO);
		KpvHjQ1MZX.Controls.Add(XS4FGLP1Uc);
		KpvHjQ1MZX.Controls.Add(UFVFbqjeFS);
		KpvHjQ1MZX.Dock = DockStyle.Fill;
		KpvHjQ1MZX.Location = new Point(3, 3);
		KpvHjQ1MZX.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42144);
		KpvHjQ1MZX.Size = new Size(131, 74);
		KpvHjQ1MZX.TabIndex = 2;
		KpvHjQ1MZX.TabStop = false;
		KpvHjQ1MZX.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21078);
		dL4FT0qInI.AutoSize = true;
		dL4FT0qInI.Location = new Point(6, 48);
		dL4FT0qInI.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10482);
		dL4FT0qInI.Size = new Size(17, 13);
		dL4FT0qInI.TabIndex = 5;
		dL4FT0qInI.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60528);
		FvoFSaqmQO.AutoSize = true;
		FvoFSaqmQO.Location = new Point(6, 22);
		FvoFSaqmQO.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12846);
		FvoFSaqmQO.Size = new Size(17, 13);
		FvoFSaqmQO.TabIndex = 4;
		FvoFSaqmQO.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60536);
		XS4FGLP1Uc.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		XS4FGLP1Uc.ForeColor = Color.Gray;
		XS4FGLP1Uc.Location = new Point(25, 45);
		XS4FGLP1Uc.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60630);
		XS4FGLP1Uc.Size = new Size(100, 20);
		XS4FGLP1Uc.TabIndex = 1;
		XS4FGLP1Uc.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60576);
		XS4FGLP1Uc.WatermarkActive = true;
		XS4FGLP1Uc.WatermarkText = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60576);
		XS4FGLP1Uc.TextChanged += zwNHEWqg1Z;
		UFVFbqjeFS.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		UFVFbqjeFS.ForeColor = Color.Gray;
		UFVFbqjeFS.Location = new Point(25, 19);
		UFVFbqjeFS.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60662);
		UFVFbqjeFS.Size = new Size(100, 20);
		UFVFbqjeFS.TabIndex = 0;
		UFVFbqjeFS.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60576);
		UFVFbqjeFS.WatermarkActive = true;
		UFVFbqjeFS.WatermarkText = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60576);
		UFVFbqjeFS.TextChanged += avXH1b9gn9;
		sGFFvKU8qN.Location = new Point(121, 141);
		sGFFvKU8qN.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60694);
		sGFFvKU8qN.Size = new Size(75, 23);
		sGFFvKU8qN.TabIndex = 2;
		sGFFvKU8qN.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(54488);
		sGFFvKU8qN.UseVisualStyleBackColor = true;
		sGFFvKU8qN.Click += EjjH6OJL9i;
		CcyFwPIAYH.DialogResult = DialogResult.Cancel;
		CcyFwPIAYH.Location = new Point(205, 141);
		CcyFwPIAYH.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60720);
		CcyFwPIAYH.Size = new Size(75, 23);
		CcyFwPIAYH.TabIndex = 3;
		CcyFwPIAYH.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20198);
		CcyFwPIAYH.UseVisualStyleBackColor = true;
		CcyFwPIAYH.Click += pG9HDTUuha;
		NJAF4CwjNi.FormattingEnabled = true;
		NJAF4CwjNi.Location = new Point(9, 23);
		NJAF4CwjNi.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60750);
		NJAF4CwjNi.Size = new Size(132, 21);
		NJAF4CwjNi.TabIndex = 4;
		NJAF4CwjNi.SelectedIndexChanged += YiuHccCO9h;
		pxpFVUTb4g.AutoSize = true;
		pxpFVUTb4g.Location = new Point(9, 6);
		pxpFVUTb4g.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		pxpFVUTb4g.Size = new Size(41, 13);
		pxpFVUTb4g.TabIndex = 5;
		pxpFVUTb4g.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21126);
		base.AcceptButton = sGFFvKU8qN;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = CcyFwPIAYH;
		base.ClientSize = new Size(291, 173);
		base.Controls.Add(pxpFVUTb4g);
		base.Controls.Add(NJAF4CwjNi);
		base.Controls.Add(CcyFwPIAYH);
		base.Controls.Add(sGFFvKU8qN);
		base.Controls.Add(zicHHKvvWo);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60772);
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60798);
		base.Load += zP6HJudeCJ;
		zicHHKvvWo.ResumeLayout(performLayout: false);
		Uv5HFElDeR.ResumeLayout(performLayout: false);
		Uv5HFElDeR.PerformLayout();
		KpvHjQ1MZX.ResumeLayout(performLayout: false);
		KpvHjQ1MZX.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
