using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.Properties;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.forms;

public class BlockReplaceResults : Form
{
	private IContainer akpYQms1LF;

	private TextBox aWEYO9vgC6;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BlockReplaceResults(string changedChunkList)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		khfYoolUjf();
		aWEYO9vgC6.Text = changedChunkList;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void yWCYuTYpfR(object P_0, EventArgs P_1)
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
		if (disposing && akpYQms1LF != null)
		{
			akpYQms1LF.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void khfYoolUjf()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		aWEYO9vgC6 = new TextBox();
		SuspendLayout();
		aWEYO9vgC6.Location = new Point(12, 12);
		aWEYO9vgC6.Multiline = true;
		aWEYO9vgC6.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38092);
		aWEYO9vgC6.ScrollBars = ScrollBars.Horizontal;
		aWEYO9vgC6.Size = new Size(229, 238);
		aWEYO9vgC6.TabIndex = 0;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(253, 262);
		base.Controls.Add(aWEYO9vgC6);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38126);
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38168);
		base.Load += yWCYuTYpfR;
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
