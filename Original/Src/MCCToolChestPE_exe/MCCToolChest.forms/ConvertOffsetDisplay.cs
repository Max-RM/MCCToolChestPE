using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.controls;
using MCCToolChest.model;
using MCCToolChest.PECode;
using MCCToolChest.Properties;
using MCCToolChest.utils;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.forms;

public class ConvertOffsetDisplay : Form
{
	private string KLWEX2MJKX;

	private List<RegionEntry> uAbExEmJMx;

	private List<RegionEntry> dpKEejY4vO;

	private int AIIEMDJbe2;

	private int QXNEUGOKLx;

	private int I7sELnBtv4;

	private bool AyvEgd1Y8V;

	private Color CV7EP847yj;

	private Color N81ER1WLMK;

	private int UksEkOSDZy;

	private int WsjEYauAX6;

	private IContainer qEYE3OMECp;

	private DoubleBufferPanel IRNE1TCycl;

	private FlowLayoutPanel wcnEEoM5KL;

	private Panel pdhEr10Gjx;

	private Label lgbE5rRWwe;

	private Label PxDE6nPV1C;

	private Label r76ENTSO0K;

	private Label M99ED7Dt0S;

	private Label A4VEcNccml;

	private CheckBox vBaEJgZo1g;

	private CheckBox amFEuHbNO4;

	private Label PyOEoEFZmL;

	private Label DqUEQPDYPd;

	private NumericUpDown bwGEONVQA1;

	private NumericUpDown EHcECAlKLi;

	private Button dCvE7iR8fE;

	private Button hDxEA18vOJ;

	private Button vOnEdlJww6;

	[CompilerGenerated]
	private static Func<RegionEntry, int> u1WEHUeYeG;

	[CompilerGenerated]
	private static Func<RegionEntry, int> x7BEF29jn1;

	public int RxOffset
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return UksEkOSDZy;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			UksEkOSDZy = value;
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
			return WsjEYauAX6;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			WsjEYauAX6 = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ConvertOffsetDisplay(string javaPath, int rxOffset, int rzOffset)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		KLWEX2MJKX = string.Empty;
		AIIEMDJbe2 = 10;
		QXNEUGOKLx = 500;
		I7sELnBtv4 = 20;
		CV7EP847yj = Color.LightBlue;
		N81ER1WLMK = Color.LightGreen;
		URaEB5D1s2();
		AyvEgd1Y8V = true;
		UksEkOSDZy = rxOffset;
		WsjEYauAX6 = rzOffset;
		EHcECAlKLi.Value = rxOffset;
		bwGEONVQA1.Value = rzOffset;
		int num = QXNEUGOKLx * I7sELnBtv4;
		IRNE1TCycl.Width = AIIEMDJbe2 + num + AIIEMDJbe2;
		IRNE1TCycl.Height = AIIEMDJbe2 + num + AIIEMDJbe2;
		IRNE1TCycl.Paint += OnPanelPaint;
		KLWEX2MJKX = javaPath;
		PxDE6nPV1C.BackColor = N81ER1WLMK;
		lgbE5rRWwe.BackColor = CV7EP847yj;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hfu1zMkQ7m(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.Icon = Resources.usMSrbJo37S();
		AyvEgd1Y8V = true;
		uAbExEmJMx = VwKEbA3ucv(KLWEX2MJKX);
		dpKEejY4vO = Lb9Ev1rpyJ();
		M99ED7Dt0S.Text = dpKEejY4vO.Count + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40662);
		r76ENTSO0K.Text = uAbExEmJMx.Count + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40662);
		KnxEVTmwoK(B6aEsWejjo(uAbExEmJMx), UksEkOSDZy, WsjEYauAX6);
		IRNE1TCycl.MouseMove += GrXEWXsISQ;
		IRNE1TCycl.MouseLeave += JD1EpG5isY;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void OnPanelPaint(object sender, PaintEventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Graphics graphics = e.Graphics;
		AyvEgd1Y8V = true;
		mcBETZXP4g(graphics);
		WxpESOkS5j(graphics);
		AyvEgd1Y8V = false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void mcBETZXP4g(Graphics P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int i7sELnBtv = I7sELnBtv4;
		Pen pen = new Pen(Color.LightGray);
		Point pt = new Point(AIIEMDJbe2, AIIEMDJbe2);
		Point pt2 = new Point(AIIEMDJbe2 + QXNEUGOKLx * i7sELnBtv, AIIEMDJbe2);
		int num = 0;
		for (int i = 0; i < QXNEUGOKLx + 1; i++)
		{
			num = i * i7sELnBtv;
			pt.Y = AIIEMDJbe2 + num;
			pt2.Y = AIIEMDJbe2 + num;
			P_0.DrawLine(pen, pt, pt2);
		}
		pt.Y = AIIEMDJbe2;
		pt2.Y = AIIEMDJbe2 + QXNEUGOKLx * i7sELnBtv;
		for (int j = 0; j < QXNEUGOKLx + 1; j++)
		{
			num = j * i7sELnBtv;
			pt.X = AIIEMDJbe2 + num;
			pt2.X = AIIEMDJbe2 + num;
			P_0.DrawLine(pen, pt, pt2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void WxpESOkS5j(Graphics P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = 10;
		int num2 = 500;
		int num3 = 20;
		int num4 = num + num2 * num3 / 2;
		if (amFEuHbNO4.Checked)
		{
			gXxEGwW6Qc(num4, uAbExEmJMx, CV7EP847yj, P_0, UksEkOSDZy, WsjEYauAX6);
		}
		if (vBaEJgZo1g.Checked)
		{
			gXxEGwW6Qc(num4, dpKEejY4vO, N81ER1WLMK, P_0);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void gXxEGwW6Qc(int P_0, List<RegionEntry> P_1, Color P_2, Graphics P_3, int P_4 = 0, int P_5 = 0)
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
			int num = (item.RX + P_4) * I7sELnBtv4 + P_0;
			int num2 = (item.RZ + P_5) * I7sELnBtv4 + P_0;
			Point point = new Point(num, num2);
			P_3.FillRectangle(brush, point.X + 1, point.Y + 1, I7sELnBtv4 - 1, I7sELnBtv4 - 1);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<RegionEntry> VwKEbA3ucv(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<RegionEntry> list = new List<RegionEntry>();
		string text = Path.Combine(P_0, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21936));
		if (FileUtils.CheckFolderExists(text))
		{
			string[] files = Directory.GetFiles(text, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40696));
			for (int i = 0; i < files.Length; i++)
			{
				string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(files[i].ToString());
				string[] array = fileNameWithoutExtension.Split('.');
				if (array.Length == 3)
				{
					int rX = int.Parse(array[1]);
					int rZ = int.Parse(array[2]);
					RegionEntry item = new RegionEntry(rX, rZ);
					list.Add(item);
				}
			}
		}
		return list;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<RegionEntry> Lb9Ev1rpyJ()
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
	private void DplEw1xWxE(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		RegionEntry regionEntry = B6aEsWejjo(dpKEejY4vO);
		KnxEVTmwoK(regionEntry);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ysnE4DSG81(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		RegionEntry regionEntry = B6aEsWejjo(uAbExEmJMx);
		KnxEVTmwoK(regionEntry, UksEkOSDZy, WsjEYauAX6);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void KnxEVTmwoK(RegionEntry P_0, int P_1 = 0, int P_2 = 0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0 != null)
		{
			int num = AIIEMDJbe2 + QXNEUGOKLx * I7sELnBtv4 / 2;
			int num2 = (P_0.RX + P_1) * I7sELnBtv4 + num;
			int num3 = (P_0.RZ + P_2) * I7sELnBtv4 + num;
			wcnEEoM5KL.AutoScrollPosition = new Point(num2 - wcnEEoM5KL.ClientRectangle.Width / 2, num3 - wcnEEoM5KL.ClientRectangle.Height / 2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GrXEWXsISQ(object P_0, MouseEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!AyvEgd1Y8V)
		{
			A4VEcNccml.Visible = true;
			int num = AIIEMDJbe2 + QXNEUGOKLx * I7sELnBtv4 / 2;
			Point point = IRNE1TCycl.PointToClient(Cursor.Position);
			int num2 = (point.X - num) / I7sELnBtv4;
			int num3 = (point.Y - num) / I7sELnBtv4;
			if (point.X < num)
			{
				num2 += -1;
			}
			if (point.Y < num)
			{
				num3 += -1;
			}
			A4VEcNccml.Text = num2 + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40710) + num3;
			A4VEcNccml.Left = P_1.X - A4VEcNccml.Width / 2;
			A4VEcNccml.Top = P_1.Y + A4VEcNccml.Height * 2;
			if (P_1.Button == MouseButtons.Left)
			{
				MBjEikL2T6();
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void JD1EpG5isY(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		A4VEcNccml.Visible = false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ntNEZGa78y(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		IRNE1TCycl.Invalidate();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LdjEfRkZeI(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		IRNE1TCycl.Invalidate();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MBjEikL2T6()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = AIIEMDJbe2 + QXNEUGOKLx * I7sELnBtv4 / 2;
		Point point = IRNE1TCycl.PointToClient(Cursor.Position);
		int num2 = (point.X - num) / I7sELnBtv4;
		int num3 = (point.Y - num) / I7sELnBtv4;
		if (point.X < num)
		{
			num2 += -1;
		}
		if (point.Y < num)
		{
			num3 += -1;
		}
		RegionEntry regionEntry = B6aEsWejjo(uAbExEmJMx);
		UksEkOSDZy = ((regionEntry.RX < num2) ? Math.Abs(num2 - regionEntry.RX) : (Math.Abs(regionEntry.RX - num2) * -1));
		WsjEYauAX6 = ((regionEntry.RZ < num3) ? Math.Abs(num3 - regionEntry.RZ) : (Math.Abs(regionEntry.RZ - num3) * -1));
		EHcECAlKLi.Value = UksEkOSDZy;
		bwGEONVQA1.Value = WsjEYauAX6;
		IRNE1TCycl.Invalidate();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private RegionEntry B6aEsWejjo(List<RegionEntry> P_0)
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
	private void yGrEq7D2ei(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		UksEkOSDZy = (int)EHcECAlKLi.Value;
		IRNE1TCycl.Invalidate();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RdKEK5OaYg(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		WsjEYauAX6 = (int)bwGEONVQA1.Value;
		IRNE1TCycl.Invalidate();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void mmgEhuhbeh(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.DialogResult = DialogResult.OK;
		Close();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void sDAEmNQ1G6(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Cursor = Cursors.Hand;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void T8VEnmafLb(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Cursor = Cursors.Default;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void S3TElnIijn(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Cursor = Cursors.Hand;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void rfXE2daASG(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Cursor = Cursors.Default;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void gErEywyCOc(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		UksEkOSDZy = 0;
		WsjEYauAX6 = 0;
		EHcECAlKLi.Value = UksEkOSDZy;
		bwGEONVQA1.Value = WsjEYauAX6;
		KnxEVTmwoK(B6aEsWejjo(uAbExEmJMx), UksEkOSDZy, WsjEYauAX6);
		IRNE1TCycl.Invalidate();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void KblE0DjPqg(object P_0, MouseEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MBjEikL2T6();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && qEYE3OMECp != null)
		{
			qEYE3OMECp.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void URaEB5D1s2()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		wcnEEoM5KL = new FlowLayoutPanel();
		pdhEr10Gjx = new Panel();
		vOnEdlJww6 = new Button();
		PyOEoEFZmL = new Label();
		DqUEQPDYPd = new Label();
		bwGEONVQA1 = new NumericUpDown();
		EHcECAlKLi = new NumericUpDown();
		vBaEJgZo1g = new CheckBox();
		amFEuHbNO4 = new CheckBox();
		r76ENTSO0K = new Label();
		M99ED7Dt0S = new Label();
		lgbE5rRWwe = new Label();
		PxDE6nPV1C = new Label();
		dCvE7iR8fE = new Button();
		hDxEA18vOJ = new Button();
		IRNE1TCycl = new DoubleBufferPanel();
		A4VEcNccml = new Label();
		wcnEEoM5KL.SuspendLayout();
		pdhEr10Gjx.SuspendLayout();
		((ISupportInitialize)bwGEONVQA1).BeginInit();
		((ISupportInitialize)EHcECAlKLi).BeginInit();
		IRNE1TCycl.SuspendLayout();
		SuspendLayout();
		wcnEEoM5KL.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		wcnEEoM5KL.AutoScroll = true;
		wcnEEoM5KL.BorderStyle = BorderStyle.FixedSingle;
		wcnEEoM5KL.Controls.Add(IRNE1TCycl);
		wcnEEoM5KL.Location = new Point(247, 12);
		wcnEEoM5KL.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40716);
		wcnEEoM5KL.Size = new Size(577, 486);
		wcnEEoM5KL.TabIndex = 1;
		pdhEr10Gjx.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		pdhEr10Gjx.BorderStyle = BorderStyle.FixedSingle;
		pdhEr10Gjx.Controls.Add(vOnEdlJww6);
		pdhEr10Gjx.Controls.Add(PyOEoEFZmL);
		pdhEr10Gjx.Controls.Add(DqUEQPDYPd);
		pdhEr10Gjx.Controls.Add(bwGEONVQA1);
		pdhEr10Gjx.Controls.Add(EHcECAlKLi);
		pdhEr10Gjx.Controls.Add(vBaEJgZo1g);
		pdhEr10Gjx.Controls.Add(amFEuHbNO4);
		pdhEr10Gjx.Controls.Add(r76ENTSO0K);
		pdhEr10Gjx.Controls.Add(M99ED7Dt0S);
		pdhEr10Gjx.Controls.Add(lgbE5rRWwe);
		pdhEr10Gjx.Controls.Add(PxDE6nPV1C);
		pdhEr10Gjx.Location = new Point(12, 12);
		pdhEr10Gjx.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10398);
		pdhEr10Gjx.Size = new Size(229, 486);
		pdhEr10Gjx.TabIndex = 2;
		vOnEdlJww6.Location = new Point(17, 306);
		vOnEdlJww6.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40758);
		vOnEdlJww6.Size = new Size(120, 23);
		vOnEdlJww6.TabIndex = 10;
		vOnEdlJww6.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40792);
		vOnEdlJww6.UseVisualStyleBackColor = true;
		vOnEdlJww6.Click += gErEywyCOc;
		PyOEoEFZmL.AutoSize = true;
		PyOEoEFZmL.Location = new Point(69, 284);
		PyOEoEFZmL.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10582);
		PyOEoEFZmL.Size = new Size(45, 13);
		PyOEoEFZmL.TabIndex = 9;
		PyOEoEFZmL.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40822);
		DqUEQPDYPd.AutoSize = true;
		DqUEQPDYPd.Location = new Point(69, 257);
		DqUEQPDYPd.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		DqUEQPDYPd.Size = new Size(45, 13);
		DqUEQPDYPd.TabIndex = 8;
		DqUEQPDYPd.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40842);
		bwGEONVQA1.Location = new Point(17, 280);
		bwGEONVQA1.Maximum = new decimal(new int[4] { 500, 0, 0, 0 });
		bwGEONVQA1.Minimum = new decimal(new int[4] { 500, 0, 0, -2147483648 });
		bwGEONVQA1.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40862);
		bwGEONVQA1.Size = new Size(46, 20);
		bwGEONVQA1.TabIndex = 7;
		bwGEONVQA1.ValueChanged += RdKEK5OaYg;
		EHcECAlKLi.Location = new Point(17, 253);
		EHcECAlKLi.Maximum = new decimal(new int[4] { 500, 0, 0, 0 });
		EHcECAlKLi.Minimum = new decimal(new int[4] { 500, 0, 0, -2147483648 });
		EHcECAlKLi.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40886);
		EHcECAlKLi.Size = new Size(46, 20);
		EHcECAlKLi.TabIndex = 6;
		EHcECAlKLi.ValueChanged += yGrEq7D2ei;
		vBaEJgZo1g.AutoSize = true;
		vBaEJgZo1g.Checked = true;
		vBaEJgZo1g.CheckState = CheckState.Checked;
		vBaEJgZo1g.Location = new Point(17, 45);
		vBaEJgZo1g.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40910);
		vBaEJgZo1g.Size = new Size(138, 17);
		vBaEJgZo1g.TabIndex = 5;
		vBaEJgZo1g.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40954);
		vBaEJgZo1g.UseVisualStyleBackColor = true;
		vBaEJgZo1g.CheckedChanged += LdjEfRkZeI;
		amFEuHbNO4.AutoSize = true;
		amFEuHbNO4.Checked = true;
		amFEuHbNO4.CheckState = CheckState.Checked;
		amFEuHbNO4.Location = new Point(17, 231);
		amFEuHbNO4.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40998);
		amFEuHbNO4.Size = new Size(121, 17);
		amFEuHbNO4.TabIndex = 4;
		amFEuHbNO4.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41036);
		amFEuHbNO4.UseVisualStyleBackColor = true;
		amFEuHbNO4.CheckedChanged += ntNEZGa78y;
		r76ENTSO0K.AutoSize = true;
		r76ENTSO0K.Location = new Point(14, 211);
		r76ENTSO0K.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41074);
		r76ENTSO0K.Size = new Size(106, 13);
		r76ENTSO0K.TabIndex = 3;
		r76ENTSO0K.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41074);
		M99ED7Dt0S.AutoSize = true;
		M99ED7Dt0S.Location = new Point(14, 26);
		M99ED7Dt0S.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41118);
		M99ED7Dt0S.Size = new Size(123, 13);
		M99ED7Dt0S.TabIndex = 2;
		M99ED7Dt0S.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41118);
		lgbE5rRWwe.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
		lgbE5rRWwe.Location = new Point(0, 185);
		lgbE5rRWwe.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41168);
		lgbE5rRWwe.Padding = new Padding(6, 2, 0, 0);
		lgbE5rRWwe.Size = new Size(229, 26);
		lgbE5rRWwe.TabIndex = 1;
		lgbE5rRWwe.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41196);
		lgbE5rRWwe.Click += ysnE4DSG81;
		lgbE5rRWwe.MouseEnter += sDAEmNQ1G6;
		lgbE5rRWwe.MouseLeave += T8VEnmafLb;
		PxDE6nPV1C.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
		PxDE6nPV1C.Location = new Point(0, 0);
		PxDE6nPV1C.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41224);
		PxDE6nPV1C.Padding = new Padding(6, 2, 0, 0);
		PxDE6nPV1C.Size = new Size(229, 26);
		PxDE6nPV1C.TabIndex = 0;
		PxDE6nPV1C.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41258);
		PxDE6nPV1C.Click += DplEw1xWxE;
		PxDE6nPV1C.MouseEnter += S3TElnIijn;
		PxDE6nPV1C.MouseLeave += rfXE2daASG;
		dCvE7iR8fE.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		dCvE7iR8fE.DialogResult = DialogResult.Cancel;
		dCvE7iR8fE.Location = new Point(774, 515);
		dCvE7iR8fE.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34610);
		dCvE7iR8fE.Size = new Size(50, 23);
		dCvE7iR8fE.TabIndex = 4;
		dCvE7iR8fE.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20198);
		dCvE7iR8fE.UseVisualStyleBackColor = true;
		hDxEA18vOJ.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		hDxEA18vOJ.Location = new Point(715, 515);
		hDxEA18vOJ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34632);
		hDxEA18vOJ.Size = new Size(50, 23);
		hDxEA18vOJ.TabIndex = 3;
		hDxEA18vOJ.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34646);
		hDxEA18vOJ.UseVisualStyleBackColor = true;
		hDxEA18vOJ.Click += mmgEhuhbeh;
		IRNE1TCycl.Anchor = AnchorStyles.None;
		IRNE1TCycl.Controls.Add(A4VEcNccml);
		IRNE1TCycl.Location = new Point(3, 3);
		IRNE1TCycl.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41292);
		IRNE1TCycl.Size = new Size(487, 417);
		IRNE1TCycl.TabIndex = 0;
		IRNE1TCycl.MouseDown += KblE0DjPqg;
		A4VEcNccml.AutoSize = true;
		A4VEcNccml.BackColor = Color.Transparent;
		A4VEcNccml.Location = new Point(48, 350);
		A4VEcNccml.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20616);
		A4VEcNccml.Size = new Size(35, 13);
		A4VEcNccml.TabIndex = 0;
		A4VEcNccml.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		A4VEcNccml.Visible = false;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = dCvE7iR8fE;
		base.ClientSize = new Size(836, 550);
		base.Controls.Add(dCvE7iR8fE);
		base.Controls.Add(hDxEA18vOJ);
		base.Controls.Add(pdhEr10Gjx);
		base.Controls.Add(wcnEEoM5KL);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41316);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41360);
		base.Load += hfu1zMkQ7m;
		wcnEEoM5KL.ResumeLayout(performLayout: false);
		pdhEr10Gjx.ResumeLayout(performLayout: false);
		pdhEr10Gjx.PerformLayout();
		((ISupportInitialize)bwGEONVQA1).EndInit();
		((ISupportInitialize)EHcECAlKLi).EndInit();
		IRNE1TCycl.ResumeLayout(performLayout: false);
		IRNE1TCycl.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static int HU8Ety0VYu(RegionEntry P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0.RX;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static int ff1EaqxFwV(RegionEntry P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0.RZ;
	}
}
