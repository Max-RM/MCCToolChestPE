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

public class PCConvertOffsetDisplay : Form
{
	private string FPIJO1dUrZ;

	private List<RegionEntry> MD9JCrlM6p;

	private List<RegionEntry> ypdJ7SHWR8;

	private int sbBJAAVmsT;

	private int nLHJd8vNsF;

	private int Iv7JHBrKdc;

	private bool JfcJFhpNlc;

	private Color u05JjvJDLx;

	private Color o2QJ8CGk9H;

	private int bgKJ9I7fSY;

	private int Ck9JIlhNVM;

	private IContainer sslJzSJsbo;

	private DoubleBufferPanel ijouT81Sse;

	private FlowLayoutPanel NwduSAI8PE;

	private Panel wlTuGiuJOX;

	private Label aTGubFQVLs;

	private Label fkTuvhUrBX;

	private Label uKWuweNHGj;

	private Label OR9u4Tg8Cx;

	private Label apiuV5SJJI;

	private CheckBox kRFuWUrjlC;

	private CheckBox MnnupATtdh;

	private Label d7MuZLISmU;

	private Label T4BufAHei8;

	private NumericUpDown OGcuiwysgL;

	private NumericUpDown zDvus1TNFn;

	private Button qdquqbYC69;

	private Button nLsuKmBfWH;

	private Button Kw9uhvVjbT;

	[CompilerGenerated]
	private static Func<RegionEntry, int> jFJum4d7ka;

	[CompilerGenerated]
	private static Func<RegionEntry, int> m7vunewFN1;

	public int RxOffset
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return bgKJ9I7fSY;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			bgKJ9I7fSY = value;
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
			return Ck9JIlhNVM;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			Ck9JIlhNVM = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PCConvertOffsetDisplay(string javaPath, int rxOffset, int rzOffset)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		FPIJO1dUrZ = string.Empty;
		sbBJAAVmsT = 10;
		nLHJd8vNsF = 500;
		Iv7JHBrKdc = 20;
		u05JjvJDLx = Color.LightBlue;
		o2QJ8CGk9H = Color.LightGreen;
		o9tJuD9BB1();
		JfcJFhpNlc = true;
		bgKJ9I7fSY = rxOffset;
		Ck9JIlhNVM = rzOffset;
		zDvus1TNFn.Value = rxOffset;
		OGcuiwysgL.Value = rzOffset;
		int num = nLHJd8vNsF * Iv7JHBrKdc;
		ijouT81Sse.Width = sbBJAAVmsT + num + sbBJAAVmsT;
		ijouT81Sse.Height = sbBJAAVmsT + num + sbBJAAVmsT;
		ijouT81Sse.Paint += OnPanelPaint;
		FPIJO1dUrZ = javaPath;
		fkTuvhUrBX.BackColor = o2QJ8CGk9H;
		aTGubFQVLs.BackColor = u05JjvJDLx;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PUrJBnE9QA(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.Icon = Resources.usMSrbJo37S();
		JfcJFhpNlc = true;
		MD9JCrlM6p = XEPJxcUk3u(FPIJO1dUrZ);
		ypdJ7SHWR8 = qZRJeOxis0();
		OR9u4Tg8Cx.Text = ypdJ7SHWR8.Count + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40662);
		uKWuweNHGj.Text = MD9JCrlM6p.Count + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40662);
		UgPJLAZtPu(rhAJ3LXfKH(ypdJ7SHWR8), bgKJ9I7fSY, Ck9JIlhNVM);
		ijouT81Sse.MouseMove += spiJgVsya7;
		ijouT81Sse.MouseLeave += Lv1JPXrKDA;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void OnPanelPaint(object sender, PaintEventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Graphics graphics = e.Graphics;
		JfcJFhpNlc = true;
		vvBJt0aEok(graphics);
		zm4JacaW4a(graphics);
		JfcJFhpNlc = false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void vvBJt0aEok(Graphics P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int iv7JHBrKdc = Iv7JHBrKdc;
		Pen pen = new Pen(Color.LightGray);
		Point pt = new Point(sbBJAAVmsT, sbBJAAVmsT);
		Point pt2 = new Point(sbBJAAVmsT + nLHJd8vNsF * iv7JHBrKdc, sbBJAAVmsT);
		int num = 0;
		for (int i = 0; i < nLHJd8vNsF + 1; i++)
		{
			num = i * iv7JHBrKdc;
			pt.Y = sbBJAAVmsT + num;
			pt2.Y = sbBJAAVmsT + num;
			P_0.DrawLine(pen, pt, pt2);
		}
		pt.Y = sbBJAAVmsT;
		pt2.Y = sbBJAAVmsT + nLHJd8vNsF * iv7JHBrKdc;
		for (int j = 0; j < nLHJd8vNsF + 1; j++)
		{
			num = j * iv7JHBrKdc;
			pt.X = sbBJAAVmsT + num;
			pt2.X = sbBJAAVmsT + num;
			P_0.DrawLine(pen, pt, pt2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void zm4JacaW4a(Graphics P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = 10;
		int num2 = 500;
		int num3 = 20;
		int num4 = num + num2 * num3 / 2;
		if (MnnupATtdh.Checked)
		{
			xBOJXwXNAp(num4, MD9JCrlM6p, u05JjvJDLx, P_0);
		}
		if (kRFuWUrjlC.Checked)
		{
			xBOJXwXNAp(num4, ypdJ7SHWR8, o2QJ8CGk9H, P_0, bgKJ9I7fSY, Ck9JIlhNVM);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void xBOJXwXNAp(int P_0, List<RegionEntry> P_1, Color P_2, Graphics P_3, int P_4 = 0, int P_5 = 0)
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
			int num = (item.RX + P_4) * Iv7JHBrKdc + P_0;
			int num2 = (item.RZ + P_5) * Iv7JHBrKdc + P_0;
			Point point = new Point(num, num2);
			P_3.FillRectangle(brush, point.X + 1, point.Y + 1, Iv7JHBrKdc - 1, Iv7JHBrKdc - 1);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<RegionEntry> XEPJxcUk3u(string P_0)
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
	private List<RegionEntry> qZRJeOxis0()
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
	private void f7EJMjGHiM(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		RegionEntry regionEntry = rhAJ3LXfKH(ypdJ7SHWR8);
		UgPJLAZtPu(regionEntry, bgKJ9I7fSY, Ck9JIlhNVM);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void k7kJUl2xMH(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		RegionEntry regionEntry = rhAJ3LXfKH(MD9JCrlM6p);
		UgPJLAZtPu(regionEntry);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UgPJLAZtPu(RegionEntry P_0, int P_1 = 0, int P_2 = 0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0 != null)
		{
			int num = sbBJAAVmsT + nLHJd8vNsF * Iv7JHBrKdc / 2;
			int num2 = (P_0.RX + P_1) * Iv7JHBrKdc + num;
			int num3 = (P_0.RZ + P_2) * Iv7JHBrKdc + num;
			NwduSAI8PE.AutoScrollPosition = new Point(num2 - NwduSAI8PE.ClientRectangle.Width / 2, num3 - NwduSAI8PE.ClientRectangle.Height / 2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void spiJgVsya7(object P_0, MouseEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!JfcJFhpNlc)
		{
			apiuV5SJJI.Visible = true;
			int num = sbBJAAVmsT + nLHJd8vNsF * Iv7JHBrKdc / 2;
			Point point = ijouT81Sse.PointToClient(Cursor.Position);
			int num2 = (point.X - num) / Iv7JHBrKdc;
			int num3 = (point.Y - num) / Iv7JHBrKdc;
			if (point.X < num)
			{
				num2 += -1;
			}
			if (point.Y < num)
			{
				num3 += -1;
			}
			apiuV5SJJI.Text = num2 + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40710) + num3;
			apiuV5SJJI.Left = P_1.X - apiuV5SJJI.Width / 2;
			apiuV5SJJI.Top = P_1.Y + apiuV5SJJI.Height * 2;
			if (P_1.Button == MouseButtons.Left)
			{
				LeGJYuM7fm();
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Lv1JPXrKDA(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		apiuV5SJJI.Visible = false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void WQGJRkPEXY(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ijouT81Sse.Invalidate();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void yQWJkvTu5W(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ijouT81Sse.Invalidate();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LeGJYuM7fm()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = sbBJAAVmsT + nLHJd8vNsF * Iv7JHBrKdc / 2;
		Point point = ijouT81Sse.PointToClient(Cursor.Position);
		int num2 = (point.X - num) / Iv7JHBrKdc;
		int num3 = (point.Y - num) / Iv7JHBrKdc;
		if (point.X < num)
		{
			num2 += -1;
		}
		if (point.Y < num)
		{
			num3 += -1;
		}
		RegionEntry regionEntry = rhAJ3LXfKH(MD9JCrlM6p);
		bgKJ9I7fSY = ((regionEntry.RX < num2) ? Math.Abs(num2 - regionEntry.RX) : (Math.Abs(regionEntry.RX - num2) * -1));
		Ck9JIlhNVM = ((regionEntry.RZ < num3) ? Math.Abs(num3 - regionEntry.RZ) : (Math.Abs(regionEntry.RZ - num3) * -1));
		zDvus1TNFn.Value = bgKJ9I7fSY;
		OGcuiwysgL.Value = Ck9JIlhNVM;
		ijouT81Sse.Invalidate();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private RegionEntry rhAJ3LXfKH(List<RegionEntry> P_0)
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
	private void IrpJ1N2Ji3(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bgKJ9I7fSY = (int)zDvus1TNFn.Value;
		ijouT81Sse.Invalidate();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void H6KJEJgGu6(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Ck9JIlhNVM = (int)OGcuiwysgL.Value;
		ijouT81Sse.Invalidate();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void zwVJrp0yXp(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.DialogResult = DialogResult.OK;
		Close();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void t8UJ5CV8aL(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Cursor = Cursors.Hand;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void bgTJ6Yyii7(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Cursor = Cursors.Default;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UtUJNOyr0e(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Cursor = Cursors.Hand;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void kj8JD8Xn2j(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Cursor = Cursors.Default;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YQCJcRl5pn(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bgKJ9I7fSY = 0;
		Ck9JIlhNVM = 0;
		zDvus1TNFn.Value = bgKJ9I7fSY;
		OGcuiwysgL.Value = Ck9JIlhNVM;
		UgPJLAZtPu(rhAJ3LXfKH(ypdJ7SHWR8), bgKJ9I7fSY, Ck9JIlhNVM);
		ijouT81Sse.Invalidate();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OiqJJVAXoN(object P_0, MouseEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LeGJYuM7fm();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && sslJzSJsbo != null)
		{
			sslJzSJsbo.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void o9tJuD9BB1()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		NwduSAI8PE = new FlowLayoutPanel();
		ijouT81Sse = new DoubleBufferPanel();
		apiuV5SJJI = new Label();
		wlTuGiuJOX = new Panel();
		Kw9uhvVjbT = new Button();
		d7MuZLISmU = new Label();
		T4BufAHei8 = new Label();
		OGcuiwysgL = new NumericUpDown();
		zDvus1TNFn = new NumericUpDown();
		kRFuWUrjlC = new CheckBox();
		MnnupATtdh = new CheckBox();
		uKWuweNHGj = new Label();
		OR9u4Tg8Cx = new Label();
		aTGubFQVLs = new Label();
		fkTuvhUrBX = new Label();
		qdquqbYC69 = new Button();
		nLsuKmBfWH = new Button();
		NwduSAI8PE.SuspendLayout();
		ijouT81Sse.SuspendLayout();
		wlTuGiuJOX.SuspendLayout();
		((ISupportInitialize)OGcuiwysgL).BeginInit();
		((ISupportInitialize)zDvus1TNFn).BeginInit();
		SuspendLayout();
		NwduSAI8PE.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		NwduSAI8PE.AutoScroll = true;
		NwduSAI8PE.BorderStyle = BorderStyle.FixedSingle;
		NwduSAI8PE.Controls.Add(ijouT81Sse);
		NwduSAI8PE.Location = new Point(247, 12);
		NwduSAI8PE.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40716);
		NwduSAI8PE.Size = new Size(577, 486);
		NwduSAI8PE.TabIndex = 1;
		ijouT81Sse.Anchor = AnchorStyles.None;
		ijouT81Sse.Controls.Add(apiuV5SJJI);
		ijouT81Sse.Location = new Point(3, 3);
		ijouT81Sse.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41292);
		ijouT81Sse.Size = new Size(487, 417);
		ijouT81Sse.TabIndex = 0;
		ijouT81Sse.MouseDown += OiqJJVAXoN;
		apiuV5SJJI.AutoSize = true;
		apiuV5SJJI.BackColor = Color.Transparent;
		apiuV5SJJI.Location = new Point(48, 350);
		apiuV5SJJI.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20616);
		apiuV5SJJI.Size = new Size(35, 13);
		apiuV5SJJI.TabIndex = 0;
		apiuV5SJJI.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		apiuV5SJJI.Visible = false;
		wlTuGiuJOX.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		wlTuGiuJOX.BorderStyle = BorderStyle.FixedSingle;
		wlTuGiuJOX.Controls.Add(Kw9uhvVjbT);
		wlTuGiuJOX.Controls.Add(d7MuZLISmU);
		wlTuGiuJOX.Controls.Add(T4BufAHei8);
		wlTuGiuJOX.Controls.Add(OGcuiwysgL);
		wlTuGiuJOX.Controls.Add(zDvus1TNFn);
		wlTuGiuJOX.Controls.Add(kRFuWUrjlC);
		wlTuGiuJOX.Controls.Add(MnnupATtdh);
		wlTuGiuJOX.Controls.Add(uKWuweNHGj);
		wlTuGiuJOX.Controls.Add(OR9u4Tg8Cx);
		wlTuGiuJOX.Controls.Add(aTGubFQVLs);
		wlTuGiuJOX.Controls.Add(fkTuvhUrBX);
		wlTuGiuJOX.Location = new Point(12, 12);
		wlTuGiuJOX.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10398);
		wlTuGiuJOX.Size = new Size(229, 486);
		wlTuGiuJOX.TabIndex = 2;
		Kw9uhvVjbT.Location = new Point(17, 306);
		Kw9uhvVjbT.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40758);
		Kw9uhvVjbT.Size = new Size(120, 23);
		Kw9uhvVjbT.TabIndex = 10;
		Kw9uhvVjbT.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40792);
		Kw9uhvVjbT.UseVisualStyleBackColor = true;
		Kw9uhvVjbT.Click += YQCJcRl5pn;
		d7MuZLISmU.AutoSize = true;
		d7MuZLISmU.Location = new Point(69, 284);
		d7MuZLISmU.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10582);
		d7MuZLISmU.Size = new Size(45, 13);
		d7MuZLISmU.TabIndex = 9;
		d7MuZLISmU.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40822);
		T4BufAHei8.AutoSize = true;
		T4BufAHei8.Location = new Point(69, 257);
		T4BufAHei8.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		T4BufAHei8.Size = new Size(45, 13);
		T4BufAHei8.TabIndex = 8;
		T4BufAHei8.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40842);
		OGcuiwysgL.Location = new Point(17, 280);
		OGcuiwysgL.Maximum = new decimal(new int[4] { 500, 0, 0, 0 });
		OGcuiwysgL.Minimum = new decimal(new int[4] { 500, 0, 0, -2147483648 });
		OGcuiwysgL.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40862);
		OGcuiwysgL.Size = new Size(46, 20);
		OGcuiwysgL.TabIndex = 7;
		OGcuiwysgL.ValueChanged += H6KJEJgGu6;
		zDvus1TNFn.Location = new Point(17, 253);
		zDvus1TNFn.Maximum = new decimal(new int[4] { 500, 0, 0, 0 });
		zDvus1TNFn.Minimum = new decimal(new int[4] { 500, 0, 0, -2147483648 });
		zDvus1TNFn.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40886);
		zDvus1TNFn.Size = new Size(46, 20);
		zDvus1TNFn.TabIndex = 6;
		zDvus1TNFn.ValueChanged += IrpJ1N2Ji3;
		kRFuWUrjlC.AutoSize = true;
		kRFuWUrjlC.Checked = true;
		kRFuWUrjlC.CheckState = CheckState.Checked;
		kRFuWUrjlC.Location = new Point(16, 231);
		kRFuWUrjlC.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40910);
		kRFuWUrjlC.Size = new Size(138, 17);
		kRFuWUrjlC.TabIndex = 5;
		kRFuWUrjlC.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40954);
		kRFuWUrjlC.UseVisualStyleBackColor = true;
		kRFuWUrjlC.CheckedChanged += yQWJkvTu5W;
		MnnupATtdh.AutoSize = true;
		MnnupATtdh.Checked = true;
		MnnupATtdh.CheckState = CheckState.Checked;
		MnnupATtdh.Location = new Point(16, 45);
		MnnupATtdh.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40998);
		MnnupATtdh.Size = new Size(121, 17);
		MnnupATtdh.TabIndex = 4;
		MnnupATtdh.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41036);
		MnnupATtdh.UseVisualStyleBackColor = true;
		MnnupATtdh.CheckedChanged += WQGJRkPEXY;
		uKWuweNHGj.AutoSize = true;
		uKWuweNHGj.Location = new Point(13, 25);
		uKWuweNHGj.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41074);
		uKWuweNHGj.Size = new Size(106, 13);
		uKWuweNHGj.TabIndex = 3;
		uKWuweNHGj.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41074);
		OR9u4Tg8Cx.AutoSize = true;
		OR9u4Tg8Cx.Location = new Point(13, 212);
		OR9u4Tg8Cx.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41118);
		OR9u4Tg8Cx.Size = new Size(123, 13);
		OR9u4Tg8Cx.TabIndex = 2;
		OR9u4Tg8Cx.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41118);
		aTGubFQVLs.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
		aTGubFQVLs.Location = new Point(-1, -1);
		aTGubFQVLs.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41168);
		aTGubFQVLs.Padding = new Padding(6, 2, 0, 0);
		aTGubFQVLs.Size = new Size(229, 26);
		aTGubFQVLs.TabIndex = 1;
		aTGubFQVLs.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41196);
		aTGubFQVLs.Click += k7kJUl2xMH;
		aTGubFQVLs.MouseEnter += t8UJ5CV8aL;
		aTGubFQVLs.MouseLeave += bgTJ6Yyii7;
		fkTuvhUrBX.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
		fkTuvhUrBX.Location = new Point(-1, 186);
		fkTuvhUrBX.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41224);
		fkTuvhUrBX.Padding = new Padding(6, 2, 0, 0);
		fkTuvhUrBX.Size = new Size(229, 26);
		fkTuvhUrBX.TabIndex = 0;
		fkTuvhUrBX.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41258);
		fkTuvhUrBX.Click += f7EJMjGHiM;
		fkTuvhUrBX.MouseEnter += UtUJNOyr0e;
		fkTuvhUrBX.MouseLeave += kj8JD8Xn2j;
		qdquqbYC69.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		qdquqbYC69.DialogResult = DialogResult.Cancel;
		qdquqbYC69.Location = new Point(774, 515);
		qdquqbYC69.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34610);
		qdquqbYC69.Size = new Size(50, 23);
		qdquqbYC69.TabIndex = 4;
		qdquqbYC69.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20198);
		qdquqbYC69.UseVisualStyleBackColor = true;
		nLsuKmBfWH.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		nLsuKmBfWH.Location = new Point(715, 515);
		nLsuKmBfWH.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34632);
		nLsuKmBfWH.Size = new Size(50, 23);
		nLsuKmBfWH.TabIndex = 3;
		nLsuKmBfWH.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34646);
		nLsuKmBfWH.UseVisualStyleBackColor = true;
		nLsuKmBfWH.Click += zwVJrp0yXp;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = qdquqbYC69;
		base.ClientSize = new Size(836, 550);
		base.Controls.Add(qdquqbYC69);
		base.Controls.Add(nLsuKmBfWH);
		base.Controls.Add(wlTuGiuJOX);
		base.Controls.Add(NwduSAI8PE);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(53866);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41360);
		base.Load += PUrJBnE9QA;
		NwduSAI8PE.ResumeLayout(performLayout: false);
		ijouT81Sse.ResumeLayout(performLayout: false);
		ijouT81Sse.PerformLayout();
		wlTuGiuJOX.ResumeLayout(performLayout: false);
		wlTuGiuJOX.PerformLayout();
		((ISupportInitialize)OGcuiwysgL).EndInit();
		((ISupportInitialize)zDvus1TNFn).EndInit();
		ResumeLayout(performLayout: false);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static int D1SJoA8CiP(RegionEntry P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0.RX;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static int xM0JQ2KGGe(RegionEntry P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0.RZ;
	}
}
