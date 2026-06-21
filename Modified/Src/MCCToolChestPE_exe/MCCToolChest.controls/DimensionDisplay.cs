using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using afNMf7uWOyq6L7IHxiu;
using MCCToolChest.events;
using MCCToolChest.model;
using MCCToolChest.utils;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls;

public class DimensionDisplay : UserControl
{
	private int XgmynC1eSJ;

	private int n3Ryl2M03M;

	private int OWgy2R5QIb;

	private int hbVyy9vswQ;

	private int LKDy0Hm27q;

	private SolidBrush sf4yB4br1w;

	private SolidBrush LreytGuV7H;

	private SolidBrush zdSyanSDgs;

	private EventHandler EG6yXt1dO9;

	private DimensionWorkingData dmmyxCaqMZ;

	private List<RegionDisplayChunk[]> W1wyevoEBJ;

	private IContainer mDWyMDIImT;

	private Label M1dyUOkqgW;

	private Label D3FyLJ7UI3;

	public DimensionWorkingData DimensionData
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return dmmyxCaqMZ;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			dmmyxCaqMZ = value;
			W1wyevoEBJ = null;
			M1dyUOkqgW.Text = "";
			hbVyy9vswQ = 0;
			LKDy0Hm27q = 0;
			if (value != null)
			{
				string text = Constants.dimensionNames[value.Dimension];
				M1dyUOkqgW.Text = text;
				if (value.Dimension == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21936))
				{
					XgmynC1eSJ = 27;
				}
				else
				{
					XgmynC1eSJ = 9;
				}
				eYhybFEjKo(dmmyxCaqMZ);
				eO3yVQjt3o();
			}
		}
	}

	public List<RegionDisplayChunk[]> ChunkEntries
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return W1wyevoEBJ;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			W1wyevoEBJ = value;
		}
	}

	public event EventHandler ChunkSelected
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = EG6yXt1dO9;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref EG6yXt1dO9, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		remove
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = EG6yXt1dO9;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref EG6yXt1dO9, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DimensionDisplay()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		XgmynC1eSJ = 27;
		n3Ryl2M03M = 25;
		OWgy2R5QIb = 800;
		sf4yB4br1w = new SolidBrush(Color.LightGray);
		LreytGuV7H = new SolidBrush(Color.Red);
		zdSyanSDgs = new SolidBrush(Color.White);
		m8Uym7bMWS();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnPaint(PaintEventArgs pe)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.OnPaint(pe);
		WcpySMbDdO(pe);
		H1lyGe9SYd(pe);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void WcpySMbDdO(PaintEventArgs P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Brush brush = new SolidBrush(Color.White);
		P_0.Graphics.FillRectangle(brush, 10, 20, OWgy2R5QIb, OWgy2R5QIb);
		Pen pen = new Pen(Color.LightGray);
		Point pt = new Point(10, 20);
		Point pt2 = new Point(10 + OWgy2R5QIb, 20);
		for (int i = 0; i < XgmynC1eSJ * 2 + 1; i++)
		{
			int num = i * n3Ryl2M03M;
			pt.Y = 20 + num;
			pt2.Y = 20 + num;
			P_0.Graphics.DrawLine(pen, pt, pt2);
		}
		pt.Y = 20;
		pt2.Y = 20 + OWgy2R5QIb;
		for (int j = 0; j < XgmynC1eSJ * 2 + 1; j++)
		{
			int num2 = j * n3Ryl2M03M;
			pt.X = 10 + num2;
			pt2.X = 10 + num2;
			P_0.Graphics.DrawLine(pen, pt, pt2);
		}
		Pen pen2 = new Pen(Color.Red);
		pt.X = 10;
		pt2.X = 10 + OWgy2R5QIb;
		pt.Y = 20 + OWgy2R5QIb / 2;
		pt2.Y = 20 + OWgy2R5QIb / 2;
		P_0.Graphics.DrawLine(pen2, pt, pt2);
		pt.Y = 20;
		pt2.Y = 20 + OWgy2R5QIb;
		pt.X = 10 + OWgy2R5QIb / 2;
		pt2.X = 10 + OWgy2R5QIb / 2;
		P_0.Graphics.DrawLine(pen2, pt, pt2);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void H1lyGe9SYd(PaintEventArgs P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (ChunkEntries == null)
		{
			return;
		}
		for (int i = 0; i < XgmynC1eSJ * 2; i++)
		{
			for (int j = 0; j < XgmynC1eSJ * 2; j++)
			{
				Point point = new Point(i * n3Ryl2M03M + 11, j * n3Ryl2M03M + 21);
				if (ChunkEntries[i][j].IsPresent)
				{
					Brush brush = new SolidBrush(Color.LightGray);
					P_0.Graphics.FillRectangle(brush, point.X, point.Y, n3Ryl2M03M - 2, n3Ryl2M03M - 2);
				}
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void eYhybFEjKo(DimensionWorkingData P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		W1wyevoEBJ = new List<RegionDisplayChunk[]>();
		for (int i = 0; i < XgmynC1eSJ * 2; i++)
		{
			RegionDisplayChunk[] item = new RegionDisplayChunk[XgmynC1eSJ * 2];
			W1wyevoEBJ.Add(item);
		}
		ORLyvtAQwo(P_0.Dimension, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21952), -1, -1, 0, 0, FileUtils.CheckFolderSep(P_0.Path) + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21970));
		ORLyvtAQwo(P_0.Dimension, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21996), 0, -1, XgmynC1eSJ, 0, FileUtils.CheckFolderSep(P_0.Path) + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22012));
		ORLyvtAQwo(P_0.Dimension, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22036), -1, 0, 0, XgmynC1eSJ, FileUtils.CheckFolderSep(P_0.Path) + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22052));
		ORLyvtAQwo(P_0.Dimension, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22076), 0, 0, XgmynC1eSJ, XgmynC1eSJ, FileUtils.CheckFolderSep(P_0.Path) + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22090));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<RegionDisplayChunk[]> ORLyvtAQwo(string P_0, string P_1, int P_2, int P_3, int P_4, int P_5, string P_6)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<ChunkIndexEntry> list = lxe7hMuSirBXGUQugsD.kM7SgjjqASt(P_6);
		if (list == null)
		{
			list = lxe7hMuSirBXGUQugsD.gCmSg9Efe8W();
		}
		int num = 32 - XgmynC1eSJ;
		if (P_2 >= 0)
		{
			for (int i = 0; i < XgmynC1eSJ; i++)
			{
				if (P_3 >= 0)
				{
					for (int j = 0; j < XgmynC1eSJ; j++)
					{
						CvnywDsyV3(P_0, P_1, P_2, P_3, W1wyevoEBJ, list, i, j, i + P_4, j + P_5);
					}
					continue;
				}
				for (int num2 = XgmynC1eSJ - 1; num2 >= 0; num2--)
				{
					CvnywDsyV3(P_0, P_1, P_2, P_3, W1wyevoEBJ, list, i, num2 + num, i + P_4, num2 + P_5);
				}
			}
		}
		else
		{
			for (int num3 = XgmynC1eSJ - 1; num3 >= 0; num3--)
			{
				if (P_3 >= 0)
				{
					for (int k = 0; k < XgmynC1eSJ; k++)
					{
						CvnywDsyV3(P_0, P_1, P_2, P_3, W1wyevoEBJ, list, num3 + num, k, num3 + P_4, k + P_5);
					}
				}
				else
				{
					for (int num4 = XgmynC1eSJ - 1; num4 >= 0; num4--)
					{
						CvnywDsyV3(P_0, P_1, P_2, P_3, W1wyevoEBJ, list, num3 + num, num4 + num, num3 + P_4, num4 + P_5);
					}
				}
			}
		}
		return W1wyevoEBJ;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CvnywDsyV3(string P_0, string P_1, int P_2, int P_3, List<RegionDisplayChunk[]> P_4, List<ChunkIndexEntry> P_5, int P_6, int P_7, int P_8, int P_9)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ChunkIndexEntry chunkIndexEntry = lxe7hMuSirBXGUQugsD.XnuSPVkd0a5(P_5, P_6, P_7);
		bool isPresent = lxe7hMuSirBXGUQugsD.gMiSP4Al2WT(P_5, P_6, P_7);
		RegionDisplayChunk regionDisplayChunk = new RegionDisplayChunk();
		regionDisplayChunk.Region = P_1;
		regionDisplayChunk.ChunkIndex = chunkIndexEntry.ChunkIndex;
		regionDisplayChunk.IsPresent = isPresent;
		regionDisplayChunk.RX = P_2;
		regionDisplayChunk.RZ = P_3;
		RegionDisplayChunk regionDisplayChunk2 = regionDisplayChunk;
		P_4[P_8][P_9] = regionDisplayChunk2;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void zsty46n78U(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		eO3yVQjt3o();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void eO3yVQjt3o()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = (base.Width - 14) / (XgmynC1eSJ * 2);
		int num2 = (base.Height - 24) / (XgmynC1eSJ * 2);
		n3Ryl2M03M = ((num < num2) ? num : num2);
		OWgy2R5QIb = XgmynC1eSJ * 2 * n3Ryl2M03M;
		D3FyLJ7UI3.Left = 10 + M1dyUOkqgW.Left + M1dyUOkqgW.Width;
		D3FyLJ7UI3.Top = 5;
		Invalidate();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TboyWvZwkT(object P_0, MouseEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		NqRyZUXU92(P_1);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void VjYypipUQp(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		D3FyLJ7UI3.Visible = false;
		Graphics graphics = CreateGraphics();
		RqGyhZ7Bqe(hbVyy9vswQ, LKDy0Hm27q, JXkyKaoFfa(hbVyy9vswQ, LKDy0Hm27q), graphics);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void NqRyZUXU92(MouseEventArgs P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (W1wyevoEBJ == null)
		{
			D3FyLJ7UI3.Visible = false;
			return;
		}
		Graphics graphics = CreateGraphics();
		RqGyhZ7Bqe(hbVyy9vswQ, LKDy0Hm27q, JXkyKaoFfa(hbVyy9vswQ, LKDy0Hm27q), graphics);
		int num = XgmynC1eSJ * 2;
		int num2 = P_0.X;
		int num3 = P_0.Y;
		if (num2 > 10 && num3 > 20)
		{
			num2 -= 10;
			num3 -= 20;
			num2 /= OWgy2R5QIb / num;
			num3 /= OWgy2R5QIb / num;
			if (num2 < num && num3 < num)
			{
				hbVyy9vswQ = num2;
				LKDy0Hm27q = num3;
				RqGyhZ7Bqe(num2, num3, LreytGuV7H, graphics);
				RegionDisplayChunk regionDisplayChunk = W1wyevoEBJ[num2][num3];
				num2 = ((num2 < XgmynC1eSJ) ? num2 : (num2 - XgmynC1eSJ));
				num3 = ((num3 < XgmynC1eSJ) ? num3 : (num3 - XgmynC1eSJ));
				int num4 = OJKyf8jQZW(num2, regionDisplayChunk.RX);
				int num5 = LuPyi7Y2GI(num3, regionDisplayChunk.RZ);
				D3FyLJ7UI3.Visible = true;
				D3FyLJ7UI3.Text = regionDisplayChunk.Region + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20514) + num4 + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11952) + num5 + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20542);
			}
			else
			{
				D3FyLJ7UI3.Visible = false;
			}
		}
		else
		{
			D3FyLJ7UI3.Visible = false;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int OJKyf8jQZW(int P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_1 < 0)
		{
			return (XgmynC1eSJ - P_0) * -1;
		}
		return P_0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int LuPyi7Y2GI(int P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_1 < 0)
		{
			return (XgmynC1eSJ - P_0) * -1;
		}
		return P_0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LUsystG7W8(MouseEventArgs P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = P_0.X;
		int num2 = P_0.Y;
		int num3 = XgmynC1eSJ * 2;
		if (num > 10 && num2 > 20)
		{
			num -= 10;
			num2 -= 20;
			num /= OWgy2R5QIb / num3;
			num2 /= OWgy2R5QIb / num3;
			if (num < num3 && num2 < num3 && W1wyevoEBJ[num][num2].IsPresent)
			{
				RegionDisplayChunk regionDisplayChunk = W1wyevoEBJ[num][num2];
				_ = regionDisplayChunk.ChunkIndex;
				_ = regionDisplayChunk.Region;
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnChunkSelected(object sender, ChunkSelectedEventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		EG6yXt1dO9?.Invoke(this, e);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void rVPyqSsOo6(object P_0, MouseEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_1.Button == MouseButtons.Left)
		{
			LUsystG7W8(P_1);
		}
		_ = P_1.Button;
		_ = 2097152;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private SolidBrush JXkyKaoFfa(int P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!ChunkEntries[P_0][P_1].IsPresent)
		{
			return zdSyanSDgs;
		}
		return sf4yB4br1w;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RqGyhZ7Bqe(int P_0, int P_1, SolidBrush P_2, Graphics P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Point point = new Point(P_0 * n3Ryl2M03M + 11, P_1 * n3Ryl2M03M + 21);
		P_3.FillRectangle(P_2, point.X, point.Y, n3Ryl2M03M - 2, n3Ryl2M03M - 2);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && mDWyMDIImT != null)
		{
			mDWyMDIImT.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void m8Uym7bMWS()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		M1dyUOkqgW = new Label();
		D3FyLJ7UI3 = new Label();
		SuspendLayout();
		M1dyUOkqgW.AutoSize = true;
		M1dyUOkqgW.Location = new Point(10, 5);
		M1dyUOkqgW.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14610);
		M1dyUOkqgW.Size = new Size(35, 13);
		M1dyUOkqgW.TabIndex = 2;
		M1dyUOkqgW.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		D3FyLJ7UI3.Anchor = AnchorStyles.None;
		D3FyLJ7UI3.AutoSize = true;
		D3FyLJ7UI3.Location = new Point(80, 291);
		D3FyLJ7UI3.MinimumSize = new Size(2, 0);
		D3FyLJ7UI3.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20616);
		D3FyLJ7UI3.Size = new Size(2, 13);
		D3FyLJ7UI3.TabIndex = 3;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(D3FyLJ7UI3);
		base.Controls.Add(M1dyUOkqgW);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22112);
		base.Size = new Size(471, 389);
		base.MouseDown += rVPyqSsOo6;
		base.MouseLeave += VjYypipUQp;
		base.MouseMove += TboyWvZwkT;
		base.Resize += zsty46n78U;
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
