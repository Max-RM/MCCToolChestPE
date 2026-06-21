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
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls;

public class RegionDisplay : UserControl
{
	private int TKmXhZtYmd;

	private int nktXm5fVrk;

	private int hyhXnpT5Xe;

	private int D2KXlNjTXn;

	private int U5eX2mCLsg;

	private SolidBrush ykiXyh4xt1;

	private SolidBrush xrFX0S7hwy;

	private SolidBrush v1YXB9W4b6;

	private EventHandler ForXtkPNnw;

	private PERegion iPvXaJoxEh;

	private List<RegionDisplayChunk[]> dfNXXJ1M2k;

	private IContainer m9QXxIfY5T;

	private Label h4xXeLxhbE;

	private Label gMlXMHtb5r;

	public PERegion RegionEntry
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return iPvXaJoxEh;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			iPvXaJoxEh = value;
			dfNXXJ1M2k = null;
			gMlXMHtb5r.Text = "";
			D2KXlNjTXn = 0;
			U5eX2mCLsg = 0;
			if (value != null)
			{
				string text = Constants.GetDimensionDisplayName(iPvXaJoxEh.Dimension);
				string text2 = iPvXaJoxEh.RX + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13710) + iPvXaJoxEh.RZ;
				gMlXMHtb5r.Text = text + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28858) + text2;
				tsEXTES9bt(iPvXaJoxEh);
				aRDXbxWm4h();
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
			return dfNXXJ1M2k;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			dfNXXJ1M2k = value;
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
			EventHandler eventHandler = ForXtkPNnw;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref ForXtkPNnw, value2, eventHandler2);
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
			EventHandler eventHandler = ForXtkPNnw;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref ForXtkPNnw, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public RegionDisplay()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		TKmXhZtYmd = 32;
		nktXm5fVrk = 25;
		hyhXnpT5Xe = 800;
		ykiXyh4xt1 = new SolidBrush(Color.LightGray);
		xrFX0S7hwy = new SolidBrush(Color.Red);
		v1YXB9W4b6 = new SolidBrush(Color.White);
		PfsXKIxYEY();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnPaint(PaintEventArgs pe)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.OnPaint(pe);
		oo6aIPpeqN(pe);
		bBmazGFwC6(pe);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void oo6aIPpeqN(PaintEventArgs P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Brush brush = new SolidBrush(Color.White);
		P_0.Graphics.FillRectangle(brush, 10, 20, hyhXnpT5Xe, hyhXnpT5Xe);
		Pen pen = new Pen(Color.LightGray);
		Point pt = new Point(10, 20);
		Point pt2 = new Point(10 + hyhXnpT5Xe, 20);
		for (int i = 0; i < TKmXhZtYmd + 1; i++)
		{
			int num = i * nktXm5fVrk;
			pt.Y = 20 + num;
			pt2.Y = 20 + num;
			P_0.Graphics.DrawLine(pen, pt, pt2);
		}
		pt.Y = 20;
		pt2.Y = 20 + hyhXnpT5Xe;
		for (int j = 0; j < TKmXhZtYmd + 1; j++)
		{
			int num2 = j * nktXm5fVrk;
			pt.X = 10 + num2;
			pt2.X = 10 + num2;
			P_0.Graphics.DrawLine(pen, pt, pt2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void bBmazGFwC6(PaintEventArgs P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (ChunkEntries == null)
		{
			return;
		}
		for (int i = 0; i < TKmXhZtYmd; i++)
		{
			for (int j = 0; j < TKmXhZtYmd; j++)
			{
				Point point = new Point(i * nktXm5fVrk + 11, j * nktXm5fVrk + 21);
				if (ChunkEntries[i][j].IsPresent)
				{
					Brush brush = new SolidBrush(Color.LightGray);
					P_0.Graphics.FillRectangle(brush, point.X, point.Y, nktXm5fVrk - 2, nktXm5fVrk - 2);
				}
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<RegionDisplayChunk[]> tsEXTES9bt(PERegion P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		_ = P_0.RX;
		_ = P_0.RZ;
		dfNXXJ1M2k = new List<RegionDisplayChunk[]>();
		_ = P_0.Chunks;
		int num = 32 - TKmXhZtYmd;
		for (int i = 0; i < TKmXhZtYmd; i++)
		{
			RegionDisplayChunk[] item = new RegionDisplayChunk[TKmXhZtYmd];
			dfNXXJ1M2k.Add(item);
		}
		if (P_0.RX >= 0)
		{
			for (int j = 0; j < TKmXhZtYmd; j++)
			{
				if (P_0.RZ >= 0)
				{
					for (int k = 0; k < TKmXhZtYmd; k++)
					{
						ewFXSnFAod(P_0, j, k, j, k);
					}
					continue;
				}
				for (int num2 = TKmXhZtYmd - 1; num2 >= 0; num2--)
				{
					ewFXSnFAod(P_0, j, num2 + num, j, num2);
				}
			}
		}
		else
		{
			for (int num3 = TKmXhZtYmd - 1; num3 >= 0; num3--)
			{
				if (P_0.RZ >= 0)
				{
					for (int l = 0; l < TKmXhZtYmd; l++)
					{
						ewFXSnFAod(P_0, num3 + num, l, num3, l);
					}
				}
				else
				{
					for (int num4 = TKmXhZtYmd - 1; num4 >= 0; num4--)
					{
						ewFXSnFAod(P_0, num3 + num, num4 + num, num3, num4);
					}
				}
			}
		}
		return dfNXXJ1M2k;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ewFXSnFAod(PERegion P_0, int P_1, int P_2, int P_3, int P_4)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] chunks = P_0.Chunks;
		bool isPresent = CskXqVqQPD(chunks, P_1, P_2);
		RegionDisplayChunk regionDisplayChunk = new RegionDisplayChunk();
		regionDisplayChunk.IsPresent = isPresent;
		regionDisplayChunk.ChunkIndex = Q5gXscAeXr(P_1, P_2);
		RegionDisplayChunk regionDisplayChunk2 = regionDisplayChunk;
		dfNXXJ1M2k[P_3][P_4] = regionDisplayChunk2;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void zviXGh8CVU(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		aRDXbxWm4h();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void aRDXbxWm4h()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = (base.Width - 12) / TKmXhZtYmd;
		int num2 = (base.Height - 20) / TKmXhZtYmd;
		nktXm5fVrk = ((num < num2) ? num : num2);
		hyhXnpT5Xe = TKmXhZtYmd * nktXm5fVrk;
		h4xXeLxhbE.Left = 10 + gMlXMHtb5r.Left + gMlXMHtb5r.Width;
		h4xXeLxhbE.Top = 5;
		Invalidate();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void daqXvvnqed(object P_0, MouseEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		vYtX4kguun(P_1);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void b9PXwV0TmO(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		h4xXeLxhbE.Visible = false;
		Graphics graphics = CreateGraphics();
		e4kXiDVZBf(D2KXlNjTXn, U5eX2mCLsg, P7HXfBcCox(D2KXlNjTXn, U5eX2mCLsg), graphics);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void vYtX4kguun(MouseEventArgs P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (dfNXXJ1M2k == null)
		{
			h4xXeLxhbE.Visible = false;
			return;
		}
		Graphics graphics = CreateGraphics();
		e4kXiDVZBf(D2KXlNjTXn, U5eX2mCLsg, P7HXfBcCox(D2KXlNjTXn, U5eX2mCLsg), graphics);
		int num = P_0.X;
		int num2 = P_0.Y;
		if (num > 10 && num2 > 20)
		{
			num -= 10;
			num2 -= 20;
			num /= hyhXnpT5Xe / TKmXhZtYmd;
			num2 /= hyhXnpT5Xe / TKmXhZtYmd;
			if (num < TKmXhZtYmd && num2 < TKmXhZtYmd)
			{
				D2KXlNjTXn = num;
				U5eX2mCLsg = num2;
				e4kXiDVZBf(num, num2, xrFX0S7hwy, graphics);
				int num3 = dq7XVedoam(num, iPvXaJoxEh.RX);
				int num4 = bDuXWn9kkm(num2, iPvXaJoxEh.RZ);
				h4xXeLxhbE.Visible = true;
				h4xXeLxhbE.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28870) + num3 + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11952) + num4 + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20542);
			}
			else
			{
				h4xXeLxhbE.Visible = false;
			}
		}
		else
		{
			h4xXeLxhbE.Visible = false;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int dq7XVedoam(int P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = ((P_1 >= 0) ? P_0 : ((TKmXhZtYmd - P_0) * -1));
		return lxe7hMuSirBXGUQugsD.e1cSPCO6PUl(num, P_1);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int bDuXWn9kkm(int P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = ((P_1 >= 0) ? P_0 : ((TKmXhZtYmd - P_0) * -1));
		return lxe7hMuSirBXGUQugsD.e1cSPCO6PUl(num, P_1);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void G22Xp8mgbd(MouseEventArgs P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = P_0.X;
		int num2 = P_0.Y;
		if (num > 10 && num2 > 20)
		{
			num -= 10;
			num2 -= 20;
			num /= hyhXnpT5Xe / TKmXhZtYmd;
			num2 /= hyhXnpT5Xe / TKmXhZtYmd;
			if (num < TKmXhZtYmd && num2 < TKmXhZtYmd && dfNXXJ1M2k[num][num2].IsPresent)
			{
				int chunkIndex = dfNXXJ1M2k[num][num2].ChunkIndex;
				string dimension = Constants.GetDimensionFolderName(iPvXaJoxEh.Dimension);
				string region = iPvXaJoxEh.ToString();
				OnChunkSelected(this, new ChunkSelectedEventArgs(dimension, region, chunkIndex));
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
		ForXtkPNnw?.Invoke(this, e);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OUDXZ9L94o(object P_0, MouseEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_1.Button == MouseButtons.Left)
		{
			G22Xp8mgbd(P_1);
		}
		_ = P_1.Button;
		_ = 2097152;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private SolidBrush P7HXfBcCox(int P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!ChunkEntries[P_0][P_1].IsPresent)
		{
			return v1YXB9W4b6;
		}
		return ykiXyh4xt1;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void e4kXiDVZBf(int P_0, int P_1, SolidBrush P_2, Graphics P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Point point = new Point(P_0 * nktXm5fVrk + 11, P_1 * nktXm5fVrk + 21);
		P_3.FillRectangle(P_2, point.X, point.Y, nktXm5fVrk - 2, nktXm5fVrk - 2);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int Q5gXscAeXr(int P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return (P_0 & 0x1F) + (P_1 & 0x1F) * 32;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CskXqVqQPD(byte[] P_0, int P_1, int P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = Q5gXscAeXr(P_1, P_2);
		return P_0[num] != 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && m9QXxIfY5T != null)
		{
			m9QXxIfY5T.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PfsXKIxYEY()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		h4xXeLxhbE = new Label();
		gMlXMHtb5r = new Label();
		SuspendLayout();
		h4xXeLxhbE.Anchor = AnchorStyles.None;
		h4xXeLxhbE.AutoSize = true;
		h4xXeLxhbE.Location = new Point(3, 146);
		h4xXeLxhbE.MinimumSize = new Size(2, 0);
		h4xXeLxhbE.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20616);
		h4xXeLxhbE.Size = new Size(2, 13);
		h4xXeLxhbE.TabIndex = 0;
		gMlXMHtb5r.AutoSize = true;
		gMlXMHtb5r.Location = new Point(10, 5);
		gMlXMHtb5r.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14610);
		gMlXMHtb5r.Size = new Size(35, 13);
		gMlXMHtb5r.TabIndex = 1;
		gMlXMHtb5r.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(gMlXMHtb5r);
		base.Controls.Add(h4xXeLxhbE);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28888);
		base.Size = new Size(150, 165);
		base.MouseDown += OUDXZ9L94o;
		base.MouseLeave += b9PXwV0TmO;
		base.MouseMove += daqXvvnqed;
		base.Resize += zviXGh8CVU;
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
