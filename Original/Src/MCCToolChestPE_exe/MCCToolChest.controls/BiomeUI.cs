using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using MCCToolChest.events;
using MCCToolChest.model;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls;

public class BiomeUI : UserControl
{
	private int iN94FA2f8y;

	private int Wb34jq753t;

	private int j5d48ds892;

	private int sqt49pQQvc;

	private byte[] cBY4Iv5HDW;

	private int gT24zAAm8u;

	private int IDKVTR9Nf0;

	private int CF2VSuru6A;

	private bool j5fVGupxKw;

	private EventHandler jHZVbwCr7n;

	private SolidBrush u2QVv9mGEC;

	private SolidBrush lttVwe82Yu;

	private IContainer mM0V4lxLEK;

	private Label k2vVVMRQjY;

	private Label S5UVWQJ00L;

	public int ChunkX
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return iN94FA2f8y;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			iN94FA2f8y = value;
			j5d48ds892 = ((iN94FA2f8y >= 0) ? (iN94FA2f8y * 16) : ((iN94FA2f8y + 1) * 16));
		}
	}

	public int ChunkZ
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return Wb34jq753t;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			Wb34jq753t = value;
			sqt49pQQvc = ((Wb34jq753t >= 0) ? (Wb34jq753t * 16) : ((Wb34jq753t + 1) * 16));
		}
	}

	public byte[] Biomes
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return cBY4Iv5HDW;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			cBY4Iv5HDW = value;
			Invalidate();
		}
	}

	public bool CopyBiomeActive
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return j5fVGupxKw;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			j5fVGupxKw = value;
		}
	}

	public event EventHandler BiomeCopied
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = jHZVbwCr7n;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref jHZVbwCr7n, value2, eventHandler2);
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
			EventHandler eventHandler = jHZVbwCr7n;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref jHZVbwCr7n, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BiomeUI()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		CF2VSuru6A = -1;
		u2QVv9mGEC = new SolidBrush(Color.White);
		lttVwe82Yu = new SolidBrush(Color.Black);
		nct4QpliXZ();
		WtS4LHvIt8();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void WtS4LHvIt8()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		k2vVVMRQjY.Left = 10;
		k2vVVMRQjY.Top = 442;
		S5UVWQJ00L.Left = 442 - S5UVWQJ00L.Width;
		S5UVWQJ00L.Top = 442;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	internal int Pws4O09IG5()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return IDKVTR9Nf0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	internal void BxU4CVmV62(int value)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		IDKVTR9Nf0 = value;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	internal int kwX4Aw6Cgx()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return gT24zAAm8u;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	internal void ICw4dInQyg(int value)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		gT24zAAm8u = value;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnPaint(PaintEventArgs pe)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.OnPaint(pe);
		LxE4gKBD0c(pe);
		uDZ4PhEi2j(pe);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LxE4gKBD0c(PaintEventArgs P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Brush brush = new SolidBrush(Color.White);
		P_0.Graphics.FillRectangle(brush, 10, 10, 432, 432);
		Pen pen = new Pen(Color.LightGray);
		Point pt = new Point(10, 10);
		Point pt2 = new Point(442, 10);
		for (int i = 0; i < 17; i++)
		{
			int num = i * 27;
			pt.Y = 10 + num;
			pt2.Y = 10 + num;
			P_0.Graphics.DrawLine(pen, pt, pt2);
		}
		pt.Y = 10;
		pt2.Y = 442;
		for (int j = 0; j < 17; j++)
		{
			int num2 = j * 27;
			pt.X = 10 + num2;
			pt2.X = 10 + num2;
			P_0.Graphics.DrawLine(pen, pt, pt2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void uDZ4PhEi2j(PaintEventArgs P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		new Pen(Color.White);
		if (Biomes == null)
		{
			return;
		}
		P_0.Graphics.InterpolationMode = InterpolationMode.High;
		P_0.Graphics.SmoothingMode = SmoothingMode.HighQuality;
		P_0.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
		P_0.Graphics.CompositingQuality = CompositingQuality.HighQuality;
		Font font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12898), 10f);
		StringFormat format = new StringFormat();
		SolidBrush solidBrush = new SolidBrush(Color.White);
		SolidBrush solidBrush2 = new SolidBrush(Color.Black);
		for (int i = 0; i < 16; i++)
		{
			for (int j = 0; j < 16; j++)
			{
				Point point = new Point(i * 27 + 13, j * 27 + 16);
				int num = j * 16 + i;
				Point location = new Point(i * 27 + 10, j * 27 + 10);
				Color color = rid4kHayrv(cBY4Iv5HDW[num]);
				Brush brush = new SolidBrush(color);
				Size size = new Size(27, 27);
				Rectangle rect = new Rectangle(location, size);
				P_0.Graphics.FillRectangle(brush, rect);
				string s = cBY4Iv5HDW[num].ToString(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12912));
				SolidBrush brush2 = ((n644RuiNAh(cBY4Iv5HDW[num]) == 0) ? solidBrush2 : solidBrush);
				P_0.Graphics.DrawString(s, font, brush2, point, format);
			}
		}
		font.Dispose();
		solidBrush.Dispose();
		solidBrush2.Dispose();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private uint n644RuiNAh(int P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		uint result = uint.MaxValue;
		if (BiomeLookup.bedrockId.ContainsKey(P_0))
		{
			result = BiomeLookup.bedrockId[P_0].TextColor;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Color rid4kHayrv(int P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		uint num = 16777215u;
		if (BiomeLookup.bedrockId.ContainsKey(P_0))
		{
			num = BiomeLookup.bedrockId[P_0].Color;
		}
		num += 4278190080u;
		return Color.FromArgb((int)num);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TbW4YZbqBi(object P_0, MouseEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Wjk4J5Rrue(P_1))
		{
			if (P_1.Button == MouseButtons.Left)
			{
				CF2VSuru6A = gT24zAAm8u;
			}
			else
			{
				CF2VSuru6A = IDKVTR9Nf0;
			}
			if (j5fVGupxKw)
			{
				oRY43fRMYx(P_1);
				return;
			}
			if (Control.ModifierKeys == Keys.Control)
			{
				MKh4ExfiD4();
				return;
			}
			if (Control.ModifierKeys == Keys.Alt)
			{
				i8j41lqB2X(P_1);
				return;
			}
			cxb4NEykK4(P_1);
			YHT46SlpsA(P_1);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void oRY43fRMYx(MouseEventArgs P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Biomes != null && P_0.X >= 10 && P_0.X <= 442 && P_0.Y >= 10 && P_0.Y <= 442)
		{
			int num = Q684DAHhEK(P_0.X, P_0.Y);
			if (num < 256)
			{
				CF2VSuru6A = cBY4Iv5HDW[num];
			}
			j5fVGupxKw = false;
			OnBiomeCopied(this, new BiomeCopiedEventArgs(CF2VSuru6A, P_0.Button));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void i8j41lqB2X(MouseEventArgs P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Biomes == null || P_0.X < 10 || P_0.X > 442 || P_0.Y < 10 || P_0.Y > 442)
		{
			return;
		}
		int num = Q684DAHhEK(P_0.X, P_0.Y);
		if (num >= 256)
		{
			return;
		}
		byte b = cBY4Iv5HDW[num];
		for (int i = 0; i < cBY4Iv5HDW.Length; i++)
		{
			if (cBY4Iv5HDW[i] == b)
			{
				cBY4Iv5HDW[i] = (byte)CF2VSuru6A;
			}
		}
		Invalidate();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MKh4ExfiD4()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (cBY4Iv5HDW != null)
		{
			for (int i = 0; i < cBY4Iv5HDW.Length; i++)
			{
				cBY4Iv5HDW[i] = (byte)CF2VSuru6A;
			}
			Invalidate();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void bBS4rFtONx(object P_0, MouseEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		CF2VSuru6A = -1;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void fE345ACTKA(object P_0, MouseEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		cxb4NEykK4(P_1);
		YHT46SlpsA(P_1);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YHT46SlpsA(MouseEventArgs P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!Wjk4J5Rrue(P_0))
		{
			k2vVVMRQjY.Visible = false;
			S5UVWQJ00L.Visible = false;
			return;
		}
		int num = Q684DAHhEK(P_0.X, P_0.Y);
		if (num < 256)
		{
			k2vVVMRQjY.Visible = true;
			S5UVWQJ00L.Visible = true;
			if (BiomeLookup.bedrockId.ContainsKey(cBY4Iv5HDW[num]))
			{
				k2vVVMRQjY.Text = cBY4Iv5HDW[num].ToString(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12920)) + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12928) + BiomeLookup.bedrockId[cBY4Iv5HDW[num]].Label;
			}
			else
			{
				k2vVVMRQjY.Text = cBY4Iv5HDW[num].ToString(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12920)) + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12934);
			}
			S5UVWQJ00L.Text = GFe4utnyVJ(P_0.X, P_0.Y);
			S5UVWQJ00L.Left = 442 - S5UVWQJ00L.Width;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void cxb4NEykK4(MouseEventArgs P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!Wjk4J5Rrue(P_0) || CF2VSuru6A < 0)
		{
			return;
		}
		int num = (P_0.X - 10) / 27 * 27 + 11;
		int num2 = (P_0.Y - 10) / 27 * 27 + 11;
		Point point = new Point(num, num2);
		if (Biomes != null)
		{
			int num3 = Q684DAHhEK(P_0.X, P_0.Y);
			if (num3 < 256)
			{
				Color color = rid4kHayrv(CF2VSuru6A);
				int num4 = (int)n644RuiNAh(CF2VSuru6A);
				Graphics graphics = CreateGraphics();
				Brush brush = new SolidBrush(color);
				graphics.FillRectangle(brush, point.X, point.Y, 25, 25);
				point.X += 2;
				point.Y += 5;
				Font font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12898), 10f);
				SolidBrush brush2 = ((num4 == 0) ? lttVwe82Yu : u2QVv9mGEC);
				StringFormat format = new StringFormat();
				string s = CF2VSuru6A.ToString(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12912));
				graphics.DrawString(s, font, brush2, point, format);
				cBY4Iv5HDW[num3] = (byte)CF2VSuru6A;
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int Q684DAHhEK(int P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_0 -= 10;
		P_1 -= 10;
		return P_1 / 27 * 16 + P_0 / 27;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Vmr4cCViHi(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		k2vVVMRQjY.Visible = false;
		S5UVWQJ00L.Visible = false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool Wjk4J5Rrue(MouseEventArgs P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0.X >= 10 && P_0.X <= 442 && P_0.Y >= 10)
		{
			return P_0.Y <= 441;
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string GFe4utnyVJ(int P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_0 -= 10;
		P_1 -= 10;
		P_0 /= 27;
		P_1 /= 27;
		int num = UQG4oJTiOv(P_0, j5d48ds892, iN94FA2f8y);
		int num2 = UQG4oJTiOv(P_1, sqt49pQQvc, Wb34jq753t);
		return num + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12954) + num2;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int UQG4oJTiOv(int P_0, int P_1, int P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_1 + ((P_2 >= 0) ? P_0 : ((16 - P_0) * -1));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnBiomeCopied(object sender, BiomeCopiedEventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		jHZVbwCr7n?.Invoke(this, e);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && mM0V4lxLEK != null)
		{
			mM0V4lxLEK.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void nct4QpliXZ()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		k2vVVMRQjY = new Label();
		S5UVWQJ00L = new Label();
		SuspendLayout();
		k2vVVMRQjY.AutoSize = true;
		k2vVVMRQjY.BorderStyle = BorderStyle.FixedSingle;
		k2vVVMRQjY.Location = new Point(3, 429);
		k2vVVMRQjY.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12968);
		k2vVVMRQjY.Padding = new Padding(4);
		k2vVVMRQjY.Size = new Size(10, 23);
		k2vVVMRQjY.TabIndex = 0;
		k2vVVMRQjY.Visible = false;
		S5UVWQJ00L.AutoSize = true;
		S5UVWQJ00L.BorderStyle = BorderStyle.FixedSingle;
		S5UVWQJ00L.Location = new Point(32, 429);
		S5UVWQJ00L.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12688);
		S5UVWQJ00L.Padding = new Padding(4);
		S5UVWQJ00L.Size = new Size(10, 23);
		S5UVWQJ00L.TabIndex = 2;
		S5UVWQJ00L.TextAlign = ContentAlignment.MiddleRight;
		S5UVWQJ00L.Visible = false;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(S5UVWQJ00L);
		base.Controls.Add(k2vVVMRQjY);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12996);
		base.Size = new Size(417, 452);
		base.MouseDown += TbW4YZbqBi;
		base.MouseLeave += Vmr4cCViHi;
		base.MouseMove += fE345ACTKA;
		base.MouseUp += bBS4rFtONx;
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
