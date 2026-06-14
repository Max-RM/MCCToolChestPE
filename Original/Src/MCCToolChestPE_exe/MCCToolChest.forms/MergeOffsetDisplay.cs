using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.controls;
using MCCToolChest.model;
using MCCToolChest.PECode;
using MCCToolChest.Properties;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.forms;

public class MergeOffsetDisplay : Form
{
	private List<RegionEntry> uu7c0ZVd3P;

	private List<RegionEntry> fHicBTK7TT;

	private List<PEDimension> S9HctffjjS;

	private int dU4caa5pFh;

	private int ojCcX5nc33;

	private int FXecxx1R98;

	private bool Kbiceta3Sb;

	private Color nrQcMFECxj;

	private Color BGkcUnTuiH;

	private int zEvcLTksnV;

	private int fYJcgNLlKj;

	private IContainer mONcPgTpXA;

	private DoubleBufferPanel hE3cRtaMBG;

	private FlowLayoutPanel sJPck7WS9Z;

	private Panel yKkcYZKP7P;

	private Label KO5c34yiyM;

	private Label csAc1PCVR2;

	private Label hqXcEniN7p;

	private Label q4UcrlEiZX;

	private Label FQ5c5sTg5k;

	private CheckBox nZ1c6EtAuW;

	private CheckBox W9ycNf0uZu;

	private Label xgtcDBS1tb;

	private Label pflcc4s4nB;

	private NumericUpDown sHLcJqgDb5;

	private NumericUpDown Kavcur3cbc;

	private Button ItKcokmSRc;

	private Button eaucQ52QM5;

	private Button WhfcOqET0v;

	[CompilerGenerated]
	private static Func<RegionEntry, int> k9EcCsOvRD;

	[CompilerGenerated]
	private static Func<RegionEntry, int> x6Cc7U9fFr;

	public int RxOffset
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return zEvcLTksnV;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			zEvcLTksnV = value;
		}
	}

	public int RzOffset
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return fYJcgNLlKj;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			fYJcgNLlKj = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MergeOffsetDisplay(List<PEDimension> mergeDims, int rxOffset, int rzOffset)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		dU4caa5pFh = 10;
		ojCcX5nc33 = 500;
		FXecxx1R98 = 20;
		nrQcMFECxj = Color.LightBlue;
		BGkcUnTuiH = Color.LightGreen;
		jfAclfnfUs();
		Kbiceta3Sb = true;
		zEvcLTksnV = rxOffset;
		fYJcgNLlKj = rzOffset;
		Kavcur3cbc.Value = rxOffset;
		sHLcJqgDb5.Value = rzOffset;
		int num = ojCcX5nc33 * FXecxx1R98;
		hE3cRtaMBG.Width = dU4caa5pFh + num + dU4caa5pFh;
		hE3cRtaMBG.Height = dU4caa5pFh + num + dU4caa5pFh;
		hE3cRtaMBG.Paint += OnPanelPaint;
		S9HctffjjS = mergeDims;
		csAc1PCVR2.BackColor = BGkcUnTuiH;
		KO5c34yiyM.BackColor = nrQcMFECxj;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YPYDjNctc9(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.Icon = Resources.usMSrbJo37S();
		Kbiceta3Sb = true;
		uu7c0ZVd3P = dQZDz9PDIB(S9HctffjjS);
		fHicBTK7TT = DvMcTCP3UT();
		q4UcrlEiZX.Text = fHicBTK7TT.Count + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40662);
		hqXcEniN7p.Text = uu7c0ZVd3P.Count + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40662);
		NbScbJji5t(aKicp01aCF(uu7c0ZVd3P), zEvcLTksnV, fYJcgNLlKj);
		hE3cRtaMBG.MouseMove += kcYcvyELvW;
		hE3cRtaMBG.MouseLeave += hbqcwH8KOR;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void OnPanelPaint(object sender, PaintEventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Graphics graphics = e.Graphics;
		Kbiceta3Sb = true;
		AuXD8kuQRM(graphics);
		onUD93Y7m8(graphics);
		Kbiceta3Sb = false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AuXD8kuQRM(Graphics P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int fXecxx1R = FXecxx1R98;
		Pen pen = new Pen(Color.LightGray);
		Point pt = new Point(dU4caa5pFh, dU4caa5pFh);
		Point pt2 = new Point(dU4caa5pFh + ojCcX5nc33 * fXecxx1R, dU4caa5pFh);
		int num = 0;
		for (int i = 0; i < ojCcX5nc33 + 1; i++)
		{
			num = i * fXecxx1R;
			pt.Y = dU4caa5pFh + num;
			pt2.Y = dU4caa5pFh + num;
			P_0.DrawLine(pen, pt, pt2);
		}
		pt.Y = dU4caa5pFh;
		pt2.Y = dU4caa5pFh + ojCcX5nc33 * fXecxx1R;
		for (int j = 0; j < ojCcX5nc33 + 1; j++)
		{
			num = j * fXecxx1R;
			pt.X = dU4caa5pFh + num;
			pt2.X = dU4caa5pFh + num;
			P_0.DrawLine(pen, pt, pt2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void onUD93Y7m8(Graphics P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = 10;
		int num2 = 500;
		int num3 = 20;
		int num4 = num + num2 * num3 / 2;
		if (W9ycNf0uZu.Checked)
		{
			BIZDIhbOWQ(num4, uu7c0ZVd3P, nrQcMFECxj, P_0, zEvcLTksnV, fYJcgNLlKj);
		}
		if (nZ1c6EtAuW.Checked)
		{
			BIZDIhbOWQ(num4, fHicBTK7TT, BGkcUnTuiH, P_0);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BIZDIhbOWQ(int P_0, List<RegionEntry> P_1, Color P_2, Graphics P_3, int P_4 = 0, int P_5 = 0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_1 == null)
		{
			return;
		}
		SolidBrush brush = new SolidBrush(Color.FromArgb(128, P_2.R, P_2.G, P_2.B));
		foreach (RegionEntry item in P_1)
		{
			int num = (item.RX + P_4) * FXecxx1R98 + P_0;
			int num2 = (item.RZ + P_5) * FXecxx1R98 + P_0;
			Point point = new Point(num, num2);
			P_3.FillRectangle(brush, point.X + 1, point.Y + 1, FXecxx1R98 - 1, FXecxx1R98 - 1);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<RegionEntry> dQZDz9PDIB(List<PEDimension> P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<RegionEntry> list = new List<RegionEntry>();
		PEDimension pEDimension = P_0[0];
		foreach (PERegion value in pEDimension.Region.Values)
		{
			RegionEntry item = new RegionEntry(value.RX, value.RZ);
			list.Add(item);
		}
		return list;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<RegionEntry> DvMcTCP3UT()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<RegionEntry> list = new List<RegionEntry>();
		PEDimension pEDimension = PEUtility.GetPEDimension(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21936));
		foreach (PERegion value in pEDimension.Region.Values)
		{
			RegionEntry item = new RegionEntry(value.RX, value.RZ);
			list.Add(item);
		}
		return list;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void XfmcS8R6Q8(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		RegionEntry regionEntry = aKicp01aCF(fHicBTK7TT);
		NbScbJji5t(regionEntry);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void JYUcGA8HeT(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		RegionEntry regionEntry = aKicp01aCF(uu7c0ZVd3P);
		NbScbJji5t(regionEntry, zEvcLTksnV, fYJcgNLlKj);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void NbScbJji5t(RegionEntry P_0, int P_1 = 0, int P_2 = 0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0 != null)
		{
			int num = dU4caa5pFh + ojCcX5nc33 * FXecxx1R98 / 2;
			int num2 = (P_0.RX + P_1) * FXecxx1R98 + num;
			int num3 = (P_0.RZ + P_2) * FXecxx1R98 + num;
			sJPck7WS9Z.AutoScrollPosition = new Point(num2 - sJPck7WS9Z.ClientRectangle.Width / 2, num3 - sJPck7WS9Z.ClientRectangle.Height / 2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void kcYcvyELvW(object P_0, MouseEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!Kbiceta3Sb)
		{
			FQ5c5sTg5k.Visible = true;
			int num = dU4caa5pFh + ojCcX5nc33 * FXecxx1R98 / 2;
			Point point = hE3cRtaMBG.PointToClient(Cursor.Position);
			int num2 = (point.X - num) / FXecxx1R98;
			int num3 = (point.Y - num) / FXecxx1R98;
			if (point.X < num)
			{
				num2 += -1;
			}
			if (point.Y < num)
			{
				num3 += -1;
			}
			FQ5c5sTg5k.Text = num2 + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40710) + num3;
			FQ5c5sTg5k.Left = P_1.X - FQ5c5sTg5k.Width / 2;
			FQ5c5sTg5k.Top = P_1.Y + FQ5c5sTg5k.Height * 2;
			if (P_1.Button == MouseButtons.Left)
			{
				DRdcWLtBA2();
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hbqcwH8KOR(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		FQ5c5sTg5k.Visible = false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void C70c4U9maW(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		hE3cRtaMBG.Invalidate();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void mR1cVpBOTj(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		hE3cRtaMBG.Invalidate();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DRdcWLtBA2()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = dU4caa5pFh + ojCcX5nc33 * FXecxx1R98 / 2;
		Point point = hE3cRtaMBG.PointToClient(Cursor.Position);
		int num2 = (point.X - num) / FXecxx1R98;
		int num3 = (point.Y - num) / FXecxx1R98;
		if (point.X < num)
		{
			num2 += -1;
		}
		if (point.Y < num)
		{
			num3 += -1;
		}
		RegionEntry regionEntry = aKicp01aCF(uu7c0ZVd3P);
		zEvcLTksnV = ((regionEntry.RX < num2) ? Math.Abs(num2 - regionEntry.RX) : (Math.Abs(regionEntry.RX - num2) * -1));
		fYJcgNLlKj = ((regionEntry.RZ < num3) ? Math.Abs(num3 - regionEntry.RZ) : (Math.Abs(regionEntry.RZ - num3) * -1));
		Kavcur3cbc.Value = zEvcLTksnV;
		sHLcJqgDb5.Value = fYJcgNLlKj;
		hE3cRtaMBG.Invalidate();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private RegionEntry aKicp01aCF(List<RegionEntry> P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		RegionEntry result = null;
		if (P_0 != null && P_0.Count > 0)
		{
			P_0 = P_0.OrderBy([MethodImpl(MethodImplOptions.NoInlining)] (RegionEntry regionEntry) =>
			{
				while (false)
				{
					_ = ((object[])null)[0];
				}
				return regionEntry.RX;
			}).ThenBy([MethodImpl(MethodImplOptions.NoInlining)] (RegionEntry regionEntry) =>
			{
				while (false)
				{
					_ = ((object[])null)[0];
				}
				return regionEntry.RZ;
			}).ToList();
			result = P_0[0];
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void dFMcZjR28x(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		zEvcLTksnV = (int)Kavcur3cbc.Value;
		hE3cRtaMBG.Invalidate();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Q2Jcfk34xV(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		fYJcgNLlKj = (int)sHLcJqgDb5.Value;
		hE3cRtaMBG.Invalidate();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void R9aciYBXDj(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.DialogResult = DialogResult.OK;
		Close();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LZicsPNHUc(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Cursor = Cursors.Hand;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void zwicqkfNmd(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Cursor = Cursors.Default;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void IMtcKQpSS4(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Cursor = Cursors.Hand;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ldjchnXIxH(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Cursor = Cursors.Default;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void VqqcmarlUt(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		zEvcLTksnV = 0;
		fYJcgNLlKj = 0;
		Kavcur3cbc.Value = zEvcLTksnV;
		sHLcJqgDb5.Value = fYJcgNLlKj;
		NbScbJji5t(aKicp01aCF(uu7c0ZVd3P), zEvcLTksnV, fYJcgNLlKj);
		hE3cRtaMBG.Invalidate();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void wAbcnYTJ0K(object P_0, MouseEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		DRdcWLtBA2();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && mONcPgTpXA != null)
		{
			mONcPgTpXA.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void jfAclfnfUs()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		sJPck7WS9Z = new FlowLayoutPanel();
		hE3cRtaMBG = new DoubleBufferPanel();
		FQ5c5sTg5k = new Label();
		yKkcYZKP7P = new Panel();
		WhfcOqET0v = new Button();
		xgtcDBS1tb = new Label();
		pflcc4s4nB = new Label();
		sHLcJqgDb5 = new NumericUpDown();
		Kavcur3cbc = new NumericUpDown();
		nZ1c6EtAuW = new CheckBox();
		W9ycNf0uZu = new CheckBox();
		hqXcEniN7p = new Label();
		q4UcrlEiZX = new Label();
		KO5c34yiyM = new Label();
		csAc1PCVR2 = new Label();
		ItKcokmSRc = new Button();
		eaucQ52QM5 = new Button();
		sJPck7WS9Z.SuspendLayout();
		hE3cRtaMBG.SuspendLayout();
		yKkcYZKP7P.SuspendLayout();
		((ISupportInitialize)sHLcJqgDb5).BeginInit();
		((ISupportInitialize)Kavcur3cbc).BeginInit();
		SuspendLayout();
		sJPck7WS9Z.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		sJPck7WS9Z.AutoScroll = true;
		sJPck7WS9Z.BorderStyle = BorderStyle.FixedSingle;
		sJPck7WS9Z.Controls.Add(hE3cRtaMBG);
		sJPck7WS9Z.Location = new Point(247, 12);
		sJPck7WS9Z.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40716);
		sJPck7WS9Z.Size = new Size(577, 486);
		sJPck7WS9Z.TabIndex = 1;
		hE3cRtaMBG.Anchor = AnchorStyles.None;
		hE3cRtaMBG.Controls.Add(FQ5c5sTg5k);
		hE3cRtaMBG.Location = new Point(3, 3);
		hE3cRtaMBG.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41292);
		hE3cRtaMBG.Size = new Size(487, 417);
		hE3cRtaMBG.TabIndex = 0;
		hE3cRtaMBG.MouseDown += wAbcnYTJ0K;
		FQ5c5sTg5k.AutoSize = true;
		FQ5c5sTg5k.BackColor = Color.Transparent;
		FQ5c5sTg5k.Location = new Point(48, 350);
		FQ5c5sTg5k.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20616);
		FQ5c5sTg5k.Size = new Size(35, 13);
		FQ5c5sTg5k.TabIndex = 0;
		FQ5c5sTg5k.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		FQ5c5sTg5k.Visible = false;
		yKkcYZKP7P.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		yKkcYZKP7P.BorderStyle = BorderStyle.FixedSingle;
		yKkcYZKP7P.Controls.Add(WhfcOqET0v);
		yKkcYZKP7P.Controls.Add(xgtcDBS1tb);
		yKkcYZKP7P.Controls.Add(pflcc4s4nB);
		yKkcYZKP7P.Controls.Add(sHLcJqgDb5);
		yKkcYZKP7P.Controls.Add(Kavcur3cbc);
		yKkcYZKP7P.Controls.Add(nZ1c6EtAuW);
		yKkcYZKP7P.Controls.Add(W9ycNf0uZu);
		yKkcYZKP7P.Controls.Add(hqXcEniN7p);
		yKkcYZKP7P.Controls.Add(q4UcrlEiZX);
		yKkcYZKP7P.Controls.Add(KO5c34yiyM);
		yKkcYZKP7P.Controls.Add(csAc1PCVR2);
		yKkcYZKP7P.Location = new Point(12, 12);
		yKkcYZKP7P.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10398);
		yKkcYZKP7P.Size = new Size(229, 486);
		yKkcYZKP7P.TabIndex = 2;
		WhfcOqET0v.Location = new Point(17, 306);
		WhfcOqET0v.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40758);
		WhfcOqET0v.Size = new Size(120, 23);
		WhfcOqET0v.TabIndex = 10;
		WhfcOqET0v.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40792);
		WhfcOqET0v.UseVisualStyleBackColor = true;
		WhfcOqET0v.Click += VqqcmarlUt;
		xgtcDBS1tb.AutoSize = true;
		xgtcDBS1tb.Location = new Point(69, 284);
		xgtcDBS1tb.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10582);
		xgtcDBS1tb.Size = new Size(45, 13);
		xgtcDBS1tb.TabIndex = 9;
		xgtcDBS1tb.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40822);
		pflcc4s4nB.AutoSize = true;
		pflcc4s4nB.Location = new Point(69, 257);
		pflcc4s4nB.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		pflcc4s4nB.Size = new Size(45, 13);
		pflcc4s4nB.TabIndex = 8;
		pflcc4s4nB.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40842);
		sHLcJqgDb5.Location = new Point(17, 280);
		sHLcJqgDb5.Maximum = new decimal(new int[4] { 500, 0, 0, 0 });
		sHLcJqgDb5.Minimum = new decimal(new int[4] { 500, 0, 0, -2147483648 });
		sHLcJqgDb5.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40862);
		sHLcJqgDb5.Size = new Size(46, 20);
		sHLcJqgDb5.TabIndex = 7;
		sHLcJqgDb5.ValueChanged += Q2Jcfk34xV;
		Kavcur3cbc.Location = new Point(17, 253);
		Kavcur3cbc.Maximum = new decimal(new int[4] { 500, 0, 0, 0 });
		Kavcur3cbc.Minimum = new decimal(new int[4] { 500, 0, 0, -2147483648 });
		Kavcur3cbc.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40886);
		Kavcur3cbc.Size = new Size(46, 20);
		Kavcur3cbc.TabIndex = 6;
		Kavcur3cbc.ValueChanged += dFMcZjR28x;
		nZ1c6EtAuW.AutoSize = true;
		nZ1c6EtAuW.Checked = true;
		nZ1c6EtAuW.CheckState = CheckState.Checked;
		nZ1c6EtAuW.Location = new Point(17, 45);
		nZ1c6EtAuW.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40910);
		nZ1c6EtAuW.Size = new Size(138, 17);
		nZ1c6EtAuW.TabIndex = 5;
		nZ1c6EtAuW.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40954);
		nZ1c6EtAuW.UseVisualStyleBackColor = true;
		nZ1c6EtAuW.CheckedChanged += mR1cVpBOTj;
		W9ycNf0uZu.AutoSize = true;
		W9ycNf0uZu.Checked = true;
		W9ycNf0uZu.CheckState = CheckState.Checked;
		W9ycNf0uZu.Location = new Point(17, 231);
		W9ycNf0uZu.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40998);
		W9ycNf0uZu.Size = new Size(128, 17);
		W9ycNf0uZu.TabIndex = 4;
		W9ycNf0uZu.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(53150);
		W9ycNf0uZu.UseVisualStyleBackColor = true;
		W9ycNf0uZu.CheckedChanged += C70c4U9maW;
		hqXcEniN7p.AutoSize = true;
		hqXcEniN7p.Location = new Point(14, 211);
		hqXcEniN7p.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41074);
		hqXcEniN7p.Size = new Size(106, 13);
		hqXcEniN7p.TabIndex = 3;
		hqXcEniN7p.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41074);
		q4UcrlEiZX.AutoSize = true;
		q4UcrlEiZX.Location = new Point(14, 26);
		q4UcrlEiZX.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41118);
		q4UcrlEiZX.Size = new Size(123, 13);
		q4UcrlEiZX.TabIndex = 2;
		q4UcrlEiZX.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41118);
		KO5c34yiyM.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
		KO5c34yiyM.Location = new Point(0, 185);
		KO5c34yiyM.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(53190);
		KO5c34yiyM.Padding = new Padding(6, 2, 0, 0);
		KO5c34yiyM.Size = new Size(229, 26);
		KO5c34yiyM.TabIndex = 1;
		KO5c34yiyM.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(53220);
		KO5c34yiyM.Click += JYUcGA8HeT;
		KO5c34yiyM.MouseEnter += LZicsPNHUc;
		KO5c34yiyM.MouseLeave += zwicqkfNmd;
		csAc1PCVR2.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
		csAc1PCVR2.Location = new Point(0, 0);
		csAc1PCVR2.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41224);
		csAc1PCVR2.Padding = new Padding(6, 2, 0, 0);
		csAc1PCVR2.Size = new Size(229, 26);
		csAc1PCVR2.TabIndex = 0;
		csAc1PCVR2.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41258);
		csAc1PCVR2.Click += XfmcS8R6Q8;
		csAc1PCVR2.MouseEnter += IMtcKQpSS4;
		csAc1PCVR2.MouseLeave += ldjchnXIxH;
		ItKcokmSRc.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		ItKcokmSRc.DialogResult = DialogResult.Cancel;
		ItKcokmSRc.Location = new Point(774, 515);
		ItKcokmSRc.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34610);
		ItKcokmSRc.Size = new Size(50, 23);
		ItKcokmSRc.TabIndex = 4;
		ItKcokmSRc.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20198);
		ItKcokmSRc.UseVisualStyleBackColor = true;
		eaucQ52QM5.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		eaucQ52QM5.Location = new Point(715, 515);
		eaucQ52QM5.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34632);
		eaucQ52QM5.Size = new Size(50, 23);
		eaucQ52QM5.TabIndex = 3;
		eaucQ52QM5.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34646);
		eaucQ52QM5.UseVisualStyleBackColor = true;
		eaucQ52QM5.Click += R9aciYBXDj;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = ItKcokmSRc;
		base.ClientSize = new Size(836, 550);
		base.Controls.Add(ItKcokmSRc);
		base.Controls.Add(eaucQ52QM5);
		base.Controls.Add(yKkcYZKP7P);
		base.Controls.Add(sJPck7WS9Z);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(53250);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41360);
		base.Load += YPYDjNctc9;
		sJPck7WS9Z.ResumeLayout(performLayout: false);
		hE3cRtaMBG.ResumeLayout(performLayout: false);
		hE3cRtaMBG.PerformLayout();
		yKkcYZKP7P.ResumeLayout(performLayout: false);
		yKkcYZKP7P.PerformLayout();
		((ISupportInitialize)sHLcJqgDb5).EndInit();
		((ISupportInitialize)Kavcur3cbc).EndInit();
		ResumeLayout(performLayout: false);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static int vymc2UuWuA(RegionEntry P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0.RX;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static int niocyUDO26(RegionEntry P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0.RZ;
	}
}
