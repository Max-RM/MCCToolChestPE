using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.forms;

public class PosOut : Form
{
	private IContainer iilj6nY4N4;

	private TextBox JtFjN7pXZr;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PosOut()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		i8wj5wtbJj();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearTB()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		JtFjN7pXZr.Text = "";
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddTB(string text)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		JtFjN7pXZr.Text = text + Environment.NewLine + JtFjN7pXZr.Text;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && iilj6nY4N4 != null)
		{
			iilj6nY4N4.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void i8wj5wtbJj()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		JtFjN7pXZr = new TextBox();
		SuspendLayout();
		JtFjN7pXZr.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		JtFjN7pXZr.Location = new Point(13, 13);
		JtFjN7pXZr.Multiline = true;
		JtFjN7pXZr.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11856);
		JtFjN7pXZr.Size = new Size(515, 429);
		JtFjN7pXZr.TabIndex = 0;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(540, 454);
		base.Controls.Add(JtFjN7pXZr);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(62138);
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(62138);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
