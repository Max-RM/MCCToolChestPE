using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.model;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using uP7B13T5waxVpI3AEv;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls.EntityHelpers;

public class PositionUI : UserControl
{
	private int tMYfCJtuvb;

	private int xKEf7gTuxY;

	private int jBkfAcKlmS;

	private int JnxfdXFjKP;

	private int EjhfHXNR38;

	private List<ChunkYLayer> NZEfFOYUXd;

	private TagNodeCompound dRvfjlrfrw;

	private IContainer nC7f8I6Xwp;

	private EntityHelperHeader Ktqf9egACR;

	private Label v7nfI8c1o6;

	private TrackBar TCAfzZjS9G;

	private TextBox wdpiTvSabH;

	public float YLayer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			TagNodeList tagNodeList = dRvfjlrfrw[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17418)] as TagNodeList;
			return tagNodeList[1] as TagNodeFloat;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			TagNodeList tagNodeList = dRvfjlrfrw[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17418)] as TagNodeList;
			tagNodeList[1] = new TagNodeFloat(value);
			Invalidate();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PositionUI()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		bO8fOxGnwu();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PositionUI(TagNodeCompound entity, List<ChunkYLayer> layers, int chunkx, int chunkz)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		bO8fOxGnwu();
		InitUI(entity, layers, chunkx, chunkz);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitUI(TagNodeCompound entity, List<ChunkYLayer> layers, int chunkx, int chunkz)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		xKEf7gTuxY = chunkx;
		JnxfdXFjKP = ((chunkx >= 0) ? (chunkx * 16) : ((chunkx + 1) * 16));
		jBkfAcKlmS = chunkz;
		EjhfHXNR38 = ((chunkz >= 0) ? (chunkz * 16) : ((chunkz + 1) * 16));
		NZEfFOYUXd = layers;
		dRvfjlrfrw = entity;
		v7nfI8c1o6.Left = 330 - v7nfI8c1o6.Width;
		v7nfI8c1o6.Top = 370;
		TagNodeList tagNodeList = entity[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17418)] as TagNodeList;
		wdpiTvSabH.Text = (tagNodeList[1] as TagNodeFloat).ToString();
		TCAfzZjS9G.Value = (int)(float)(tagNodeList[1] as TagNodeFloat);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnPaint(PaintEventArgs pe)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.OnPaint(pe);
		pa2fUBOYp0(pe);
		Mi9fLURyOp(pe);
		GpgfgQwivg(pe);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void pa2fUBOYp0(PaintEventArgs P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Brush brush = new SolidBrush(Color.White);
		P_0.Graphics.FillRectangle(brush, 10, 50, 320, 320);
		Pen pen = new Pen(Color.LightGray);
		Point pt = new Point(10, 50);
		Point pt2 = new Point(330, 50);
		for (int i = 0; i < 17; i++)
		{
			int num = i * 20;
			pt.Y = 50 + num;
			pt2.Y = 50 + num;
			P_0.Graphics.DrawLine(pen, pt, pt2);
		}
		pt.Y = 50;
		pt2.Y = 370;
		for (int j = 0; j < 17; j++)
		{
			int num2 = j * 20;
			pt.X = 10 + num2;
			pt2.X = 10 + num2;
			P_0.Graphics.DrawLine(pen, pt, pt2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Mi9fLURyOp(PaintEventArgs P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (NZEfFOYUXd == null)
		{
			return;
		}
		int index = (int)YLayer;
		ChunkYLayer chunkYLayer = NZEfFOYUXd[index];
		for (int i = 0; i < 16; i++)
		{
			for (int j = 0; j < 16; j++)
			{
				Point point = new Point(i * 20 + 11, j * 20 + 51);
				int num = j * 16 + i;
				Image image = BFRL2f2UoG7tBGIHJF.xRoSMGJq48(chunkYLayer.Blocks[num].Id, chunkYLayer.Blocks[num].Data);
				if (image != null)
				{
					P_0.Graphics.DrawImage(image, point.X, point.Y, 18, 18);
				}
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GpgfgQwivg(PaintEventArgs P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (dRvfjlrfrw != null)
		{
			TagNodeList tagNodeList = dRvfjlrfrw[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17418)] as TagNodeList;
			float num = tagNodeList[0] as TagNodeFloat;
			float num2 = tagNodeList[2] as TagNodeFloat;
			int num3 = wQwfD3mwRP((int)num);
			int num4 = wQwfD3mwRP((int)num2);
			int num5 = (int)(((double)num - Math.Truncate(num)) * 100.0 / 5.0);
			int num6 = (int)(((double)num2 - Math.Truncate(num2)) * 100.0 / 5.0);
			if (xKEf7gTuxY < 0)
			{
				num5 = 20 + num5;
			}
			if (jBkfAcKlmS < 0)
			{
				num6 = 20 + num6;
			}
			num3 = num3 * 20 + 11 + num5;
			num4 = num4 * 20 + 51 + num6;
			Point point = new Point(num3, num4);
			Brush brush = new SolidBrush(Color.Red);
			Pen pen = new Pen(Color.Black);
			P_0.Graphics.FillEllipse(brush, point.X - 4, point.Y - 4, 7, 7);
			P_0.Graphics.DrawEllipse(pen, point.X - 5, point.Y - 5, 9, 9);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Q13fPpN6KO(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Ktqf9egACR.ViewState == EntityHelperViewState.Contracted)
		{
			tMYfCJtuvb = base.Height;
			base.Height = Ktqf9egACR.Top + Ktqf9egACR.Height;
		}
		else
		{
			base.Height = tMYfCJtuvb;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LWOfROGmSB(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		v7nfI8c1o6.Visible = false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ck3fk2KjNE(object P_0, MouseEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Ki2fERRhr7(P_1);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void nIafYQT8FO(object P_0, MouseEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		hkmf1kt6Nk(P_1);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Cw1f3Wosi4(object P_0, MouseEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hkmf1kt6Nk(MouseEventArgs P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (zHufQpXj4Q(P_0.X, P_0.Y))
		{
			int num = P_0.X;
			int num2 = P_0.Y;
			num -= 10;
			num2 -= 50;
			float num3 = (float)num % 20f * 5f / 100f;
			float num4 = (float)num2 % 20f * 5f / 100f;
			num /= 20;
			num2 /= 20;
			int num5 = SXxfrgy5kO(num, JnxfdXFjKP, xKEf7gTuxY);
			int num6 = SXxfrgy5kO(num2, EjhfHXNR38, jBkfAcKlmS);
			if (xKEf7gTuxY < 0)
			{
				num3 -= 1f;
			}
			if (jBkfAcKlmS < 0)
			{
				num4 -= 1f;
			}
			TagNodeList tagNodeList = dRvfjlrfrw[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17418)] as TagNodeList;
			tagNodeList[0] = new TagNodeFloat((float)num5 + num3);
			tagNodeList[2] = new TagNodeFloat((float)num6 + num4);
			Invalidate();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Ki2fERRhr7(MouseEventArgs P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (zHufQpXj4Q(P_0.X, P_0.Y))
		{
			v7nfI8c1o6.Visible = true;
			v7nfI8c1o6.Text = L2Xf6rv3eq(P_0.X, P_0.Y);
			v7nfI8c1o6.Left = 330 - v7nfI8c1o6.Width;
		}
		else
		{
			v7nfI8c1o6.Visible = false;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int SXxfrgy5kO(int P_0, int P_1, int P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_1 + ((P_2 >= 0) ? P_0 : ((16 - P_0) * -1));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int k2Ff5XfRAE(int P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_0 -= 10;
		P_1 -= 50;
		return P_1 / 20 * 16 + P_0 / 20;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string L2Xf6rv3eq(int P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_0 -= 10;
		P_1 -= 50;
		float num = (float)P_0 % 20f * 5f / 100f;
		float num2 = (float)P_1 % 20f * 5f / 100f;
		P_0 /= 20;
		P_1 /= 20;
		int num3 = SXxfrgy5kO(P_0, JnxfdXFjKP, xKEf7gTuxY);
		int num4 = SXxfrgy5kO(P_1, EjhfHXNR38, jBkfAcKlmS);
		if (xKEf7gTuxY < 0)
		{
			num -= 1f;
		}
		if (jBkfAcKlmS < 0)
		{
			num2 -= 1f;
		}
		return (float)num3 + num + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11952) + YLayer + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11952) + ((float)num4 + num2);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int PskfNruJaM(int P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return (P_0 % P_1 + P_1) % P_1;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int wQwfD3mwRP(int P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return PskfNruJaM(P_0, 16);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void oYffcRDnaL(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		wdpiTvSabH.Text = TCAfzZjS9G.Value.ToString();
		YLayer = TCAfzZjS9G.Value;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void eQmfJkoiGf(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		hY5fokTOOp();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EPHfuuYcYV(object P_0, KeyPressEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		hY5fokTOOp();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hY5fokTOOp()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		float result = 0f;
		if (float.TryParse(wdpiTvSabH.Text, out result))
		{
			if (result > 255f)
			{
				result = 255f;
			}
			YLayer = result;
			TCAfzZjS9G.Value = (int)result;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool zHufQpXj4Q(int P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if ((xKEf7gTuxY >= 0 && P_0 >= 10 && P_0 < 330) || (xKEf7gTuxY < 0 && P_0 > 10 && P_0 <= 330))
		{
			if (jBkfAcKlmS < 0 || P_1 < 50 || P_1 >= 370)
			{
				if (jBkfAcKlmS < 0 && P_1 > 50)
				{
					return P_1 <= 370;
				}
				return false;
			}
			return true;
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && nC7f8I6Xwp != null)
		{
			nC7f8I6Xwp.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void bO8fOxGnwu()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		v7nfI8c1o6 = new Label();
		TCAfzZjS9G = new TrackBar();
		wdpiTvSabH = new TextBox();
		Ktqf9egACR = new EntityHelperHeader();
		((ISupportInitialize)TCAfzZjS9G).BeginInit();
		SuspendLayout();
		v7nfI8c1o6.AutoSize = true;
		v7nfI8c1o6.BorderStyle = BorderStyle.FixedSingle;
		v7nfI8c1o6.Location = new Point(3, 342);
		v7nfI8c1o6.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12688);
		v7nfI8c1o6.Padding = new Padding(4);
		v7nfI8c1o6.Size = new Size(10, 23);
		v7nfI8c1o6.TabIndex = 2;
		v7nfI8c1o6.TextAlign = ContentAlignment.MiddleRight;
		v7nfI8c1o6.Visible = false;
		TCAfzZjS9G.LargeChange = 1;
		TCAfzZjS9G.Location = new Point(427, 51);
		TCAfzZjS9G.Maximum = 255;
		TCAfzZjS9G.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17428);
		TCAfzZjS9G.Orientation = Orientation.Vertical;
		TCAfzZjS9G.Size = new Size(45, 320);
		TCAfzZjS9G.TabIndex = 3;
		TCAfzZjS9G.TickFrequency = 500;
		TCAfzZjS9G.TickStyle = TickStyle.Both;
		TCAfzZjS9G.Scroll += oYffcRDnaL;
		wdpiTvSabH.Location = new Point(425, 369);
		wdpiTvSabH.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17450);
		wdpiTvSabH.Size = new Size(45, 20);
		wdpiTvSabH.TabIndex = 4;
		wdpiTvSabH.TextAlign = HorizontalAlignment.Right;
		wdpiTvSabH.TextChanged += eQmfJkoiGf;
		wdpiTvSabH.KeyPress += EPHfuuYcYV;
		Ktqf9egACR.BackColor = Color.Silver;
		Ktqf9egACR.Dock = DockStyle.Top;
		Ktqf9egACR.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		Ktqf9egACR.ForeColor = Color.Black;
		Ktqf9egACR.Location = new Point(0, 0);
		Ktqf9egACR.Margin = new Padding(4);
		Ktqf9egACR.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14148);
		Ktqf9egACR.Size = new Size(543, 35);
		Ktqf9egACR.TabIndex = 1;
		Ktqf9egACR.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17470);
		Ktqf9egACR.ViewState = EntityHelperViewState.Expanded;
		Ktqf9egACR.ChangeViewState += Q13fPpN6KO;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(wdpiTvSabH);
		base.Controls.Add(TCAfzZjS9G);
		base.Controls.Add(v7nfI8c1o6);
		base.Controls.Add(Ktqf9egACR);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17490);
		base.Size = new Size(543, 434);
		base.MouseDown += nIafYQT8FO;
		base.MouseLeave += LWOfROGmSB;
		base.MouseMove += ck3fk2KjNE;
		base.MouseUp += Cw1f3Wosi4;
		((ISupportInitialize)TCAfzZjS9G).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
