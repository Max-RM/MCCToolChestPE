using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using MCCToolChest.ConfigData;
using MCCToolChest.model;
using MCCToolChest.Properties;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls.EntityHelpers;

public class SignUI : UserControl
{
	private bool zxwisoktvU;

	private int zngiq2Zbfm;

	private TagNodeCompound HxGiKA5JvA;

	private Dictionary<string, TextColorFormatCode> AhlihmlovA;

	private Dictionary<string, TextColorFormatCode> mAnimRLmsK;

	private string lm0inuSn7G;

	private string BdYilbrP4e;

	private Dictionary<string, FontStyle> xLHi2OAILk;

	private Dictionary<FontStyle, string> Quniy066jy;

	private IContainer nXYi0EYI2a;

	private EntityHelperHeader TXqiBnvWJN;

	private TransparentRTB hI1itThZ9t;

	private TranslucentPanel tbQiaetGyP;

	private Panel ONViX35BKI;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SignUI(TagNodeCompound entity)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		AhlihmlovA = new Dictionary<string, TextColorFormatCode>();
		mAnimRLmsK = new Dictionary<string, TextColorFormatCode>();
		lm0inuSn7G = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(3436);
		BdYilbrP4e = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17514);
		xLHi2OAILk = new Dictionary<string, FontStyle>
		{
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17522),
				FontStyle.Bold
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17530),
				FontStyle.Italic
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17538),
				FontStyle.Underline
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17546),
				FontStyle.Strikeout
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17514),
				FontStyle.Regular
			}
		};
		Quniy066jy = new Dictionary<FontStyle, string>
		{
			{
				FontStyle.Bold,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17522)
			},
			{
				FontStyle.Italic,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17530)
			},
			{
				FontStyle.Underline,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17538)
			},
			{
				FontStyle.Strikeout,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17546)
			},
			{
				FontStyle.Regular,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17514)
			}
		};
		Mutii1t7st();
		HxGiKA5JvA = entity;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void WftiSHkj08(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		zxwisoktvU = true;
		O8diG4H9Ib();
		zxwisoktvU = false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void O8diG4H9Ib()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17554);
		if (HxGiKA5JvA.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10946)))
		{
			text = HxGiKA5JvA[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10946)] as TagNodeString;
		}
		jbBi4VL254(text);
		int num = 0;
		int num2 = 0;
		foreach (TextColorFormatCode value in ColorConstants.textColorFormatCodes.Values)
		{
			int argb = int.Parse(value.Color, NumberStyles.HexNumber);
			TextColorButton textColorButton = new TextColorButton(value.Key, argb, FKdiVv6drW);
			textColorButton.Size = new Size(25, 25);
			textColorButton.Location = new Point(num, num2 * 30);
			textColorButton.Visible = true;
			ONViX35BKI.Controls.Add(textColorButton);
			num2++;
			if (num2 == 8)
			{
				num = 30;
				num2 = 0;
			}
		}
		num = 60;
		num2 = 0;
		foreach (string key in xLHi2OAILk.Keys)
		{
			FontStyle fontStyle = xLHi2OAILk[key];
			TextFormatButton textFormatButton = new TextFormatButton(key, fontStyle, seSiWjBULK);
			textFormatButton.Size = new Size(25, 25);
			textFormatButton.Location = new Point(num, num2 * 30);
			textFormatButton.Visible = true;
			ONViX35BKI.Controls.Add(textFormatButton);
			num2++;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Dndib1m5f2(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (TXqiBnvWJN.ViewState == EntityHelperViewState.Contracted)
		{
			zngiq2Zbfm = base.Height;
			base.Height = TXqiBnvWJN.Top + TXqiBnvWJN.Height;
		}
		else
		{
			base.Height = zngiq2Zbfm;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UTZivIi9kQ(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!zxwisoktvU)
		{
			string d = uSPiw139fH();
			HxGiKA5JvA[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10946)] = new TagNodeString(d);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string uSPiw139fH()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int selectionStart = hI1itThZ9t.SelectionStart;
		int argb = int.Parse(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(3458), NumberStyles.HexNumber);
		StringBuilder stringBuilder = new StringBuilder();
		Color color = Color.FromName(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(3458));
		FontStyle fontStyle = FontStyle.Regular;
		int textLength = hI1itThZ9t.TextLength;
		for (int i = 0; i < textLength; i++)
		{
			hI1itThZ9t.SelectionStart = i;
			hI1itThZ9t.SelectionLength = 1;
			Color color2 = Color.FromArgb(argb);
			char c = hI1itThZ9t.Text[i];
			color2 = hI1itThZ9t.SelectionColor;
			FontStyle style = hI1itThZ9t.SelectionFont.Style;
			if (color2 != color)
			{
				color = Color.FromName(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(3458));
				string key = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17564) + ColorTranslator.ToHtml(Color.FromArgb(color2.ToArgb())).Substring(1).ToUpper();
				if (ColorConstants.textColorCodes.ContainsKey(key))
				{
					stringBuilder.Append(ColorConstants.textColorCodes[key]);
					color = color2;
					if (fontStyle != FontStyle.Regular)
					{
						stringBuilder.Append(Quniy066jy[style]);
					}
				}
			}
			if (style != fontStyle)
			{
				stringBuilder.Append(Quniy066jy[style]);
				fontStyle = style;
			}
			stringBuilder.Append(c);
			if (c == '\n')
			{
				color = Color.FromName(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(3444));
				fontStyle = FontStyle.Regular;
			}
		}
		hI1itThZ9t.SelectionStart = selectionStart;
		hI1itThZ9t.SelectionLength = 0;
		return RAVipbPWoF(stringBuilder.ToString());
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void jbBi4VL254(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0 == null)
		{
			return;
		}
		bool flag = false;
		string text = "";
		Color selectionColor = Color.FromName(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(3458));
		hI1itThZ9t.Clear();
		hI1itThZ9t.SelectionColor = selectionColor;
		hI1itThZ9t.SelectionAlignment = HorizontalAlignment.Center;
		for (int i = 0; i < P_0.Length; i++)
		{
			char c = P_0[i];
			if (c == '§')
			{
				flag = true;
			}
			else if (flag)
			{
				text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17572) + c;
				if (ColorConstants.textColorFormatCodes.ContainsKey(text))
				{
					int argb = int.Parse(ColorConstants.textColorFormatCodes[text].Color, NumberStyles.HexNumber);
					hI1itThZ9t.SelectionColor = Color.FromArgb(argb);
				}
				else if (xLHi2OAILk.ContainsKey(text))
				{
					hI1itThZ9t.SelectionFont = new Font(hI1itThZ9t.SelectionFont, xLHi2OAILk[text]);
				}
				flag = false;
			}
			else
			{
				hI1itThZ9t.AppendText(c.ToString());
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FKdiVv6drW(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		lm0inuSn7G = P_0;
		int argb = int.Parse(ColorConstants.textColorFormatCodes[P_0].Color, NumberStyles.HexNumber);
		hI1itThZ9t.SelectionColor = Color.FromArgb(argb);
		hI1itThZ9t.Focus();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void seSiWjBULK(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BdYilbrP4e = P_0;
		FontStyle newStyle = xLHi2OAILk[P_0];
		hI1itThZ9t.SelectionFont = new Font(hI1itThZ9t.SelectionFont, newStyle);
		hI1itThZ9t.Focus();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string RAVipbPWoF(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void WgCiZGPMfd(object P_0, KeyEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SfCifD54FA(object P_0, KeyEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (hI1itThZ9t.Lines.Length >= 4 && P_1.KeyValue == 13)
		{
			P_1.Handled = true;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && nXYi0EYI2a != null)
		{
			nXYi0EYI2a.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Mutii1t7st()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ONViX35BKI = new Panel();
		tbQiaetGyP = new TranslucentPanel();
		hI1itThZ9t = new TransparentRTB();
		TXqiBnvWJN = new EntityHelperHeader();
		tbQiaetGyP.SuspendLayout();
		SuspendLayout();
		ONViX35BKI.Location = new Point(361, 61);
		ONViX35BKI.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17578);
		ONViX35BKI.Size = new Size(154, 244);
		ONViX35BKI.TabIndex = 4;
		tbQiaetGyP.BackColor = Color.Transparent;
		tbQiaetGyP.BackgroundImage = Resources.Qb6SEHD1AjC();
		tbQiaetGyP.BackgroundImageLayout = ImageLayout.Stretch;
		tbQiaetGyP.BorderStyle = BorderStyle.FixedSingle;
		tbQiaetGyP.Controls.Add(hI1itThZ9t);
		tbQiaetGyP.Location = new Point(24, 61);
		tbQiaetGyP.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17602);
		tbQiaetGyP.Padding = new Padding(10);
		tbQiaetGyP.Size = new Size(301, 163);
		tbQiaetGyP.TabIndex = 3;
		hI1itThZ9t.BorderStyle = BorderStyle.None;
		hI1itThZ9t.Dock = DockStyle.Fill;
		hI1itThZ9t.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 23f, FontStyle.Regular, GraphicsUnit.Point, 0);
		hI1itThZ9t.Location = new Point(10, 10);
		hI1itThZ9t.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17640);
		hI1itThZ9t.ScrollBars = RichTextBoxScrollBars.None;
		hI1itThZ9t.Size = new Size(279, 141);
		hI1itThZ9t.TabIndex = 1;
		hI1itThZ9t.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17660);
		hI1itThZ9t.TextChanged += UTZivIi9kQ;
		hI1itThZ9t.KeyDown += SfCifD54FA;
		hI1itThZ9t.KeyUp += WgCiZGPMfd;
		TXqiBnvWJN.BackColor = Color.Silver;
		TXqiBnvWJN.Dock = DockStyle.Top;
		TXqiBnvWJN.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TXqiBnvWJN.ForeColor = Color.Black;
		TXqiBnvWJN.Location = new Point(0, 0);
		TXqiBnvWJN.Margin = new Padding(4);
		TXqiBnvWJN.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14148);
		TXqiBnvWJN.Size = new Size(553, 35);
		TXqiBnvWJN.TabIndex = 0;
		TXqiBnvWJN.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15604);
		TXqiBnvWJN.ViewState = EntityHelperViewState.Expanded;
		TXqiBnvWJN.ChangeViewState += Dndib1m5f2;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(ONViX35BKI);
		base.Controls.Add(tbQiaetGyP);
		base.Controls.Add(TXqiBnvWJN);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17702);
		base.Size = new Size(553, 322);
		base.Load += WftiSHkj08;
		tbQiaetGyP.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
	}
}
