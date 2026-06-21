using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.Properties;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.Forms;

public class FolderNameEntry : Form
{
	private string BPXA3WDNRW;

	private IContainer rPjA1HlDY1;

	private TextBox FwxAEP3jPu;

	private Label xgDArHOcVP;

	private Button XCMA5lVuS6;

	private Button vTnA6s8ZS2;

	public string FolderName
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return BPXA3WDNRW;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			BPXA3WDNRW = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public FolderNameEntry()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		NKNAYb0WD2();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void koAARYavRI(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = FwxAEP3jPu.Text;
		if (!string.IsNullOrWhiteSpace(text))
		{
			BPXA3WDNRW = text.Trim();
			base.DialogResult = DialogResult.OK;
			Close();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ASmAkK7KnC(object P_0, EventArgs P_1)
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
		if (disposing && rPjA1HlDY1 != null)
		{
			rPjA1HlDY1.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void NKNAYb0WD2()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		FwxAEP3jPu = new TextBox();
		xgDArHOcVP = new Label();
		XCMA5lVuS6 = new Button();
		vTnA6s8ZS2 = new Button();
		SuspendLayout();
		FwxAEP3jPu.Location = new Point(13, 36);
		FwxAEP3jPu.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(59052);
		FwxAEP3jPu.Size = new Size(330, 20);
		FwxAEP3jPu.TabIndex = 0;
		xgDArHOcVP.AutoSize = true;
		xgDArHOcVP.Location = new Point(13, 19);
		xgDArHOcVP.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		xgDArHOcVP.Size = new Size(95, 13);
		xgDArHOcVP.TabIndex = 1;
		xgDArHOcVP.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(59080);
		XCMA5lVuS6.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		XCMA5lVuS6.DialogResult = DialogResult.Cancel;
		XCMA5lVuS6.Location = new Point(272, 68);
		XCMA5lVuS6.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34610);
		XCMA5lVuS6.Size = new Size(71, 23);
		XCMA5lVuS6.TabIndex = 15;
		XCMA5lVuS6.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20198);
		XCMA5lVuS6.UseVisualStyleBackColor = true;
		vTnA6s8ZS2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		vTnA6s8ZS2.Location = new Point(195, 68);
		vTnA6s8ZS2.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34632);
		vTnA6s8ZS2.Size = new Size(71, 23);
		vTnA6s8ZS2.TabIndex = 14;
		vTnA6s8ZS2.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34646);
		vTnA6s8ZS2.UseVisualStyleBackColor = true;
		vTnA6s8ZS2.Click += koAARYavRI;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(355, 100);
		base.Controls.Add(XCMA5lVuS6);
		base.Controls.Add(vTnA6s8ZS2);
		base.Controls.Add(xgDArHOcVP);
		base.Controls.Add(FwxAEP3jPu);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(59116);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(59150);
		base.Load += ASmAkK7KnC;
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
