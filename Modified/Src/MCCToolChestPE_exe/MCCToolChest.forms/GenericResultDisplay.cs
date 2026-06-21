using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.Properties;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.forms;

public class GenericResultDisplay : Form
{
	private IContainer C7PNO66cBj;

	private TextBox LpRNCdMun0;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GenericResultDisplay(string result)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		RoZNQM3w6w();
		LpRNCdMun0.Text = result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void JuVNoPM1HX(object P_0, EventArgs P_1)
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
		if (disposing && C7PNO66cBj != null)
		{
			C7PNO66cBj.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RoZNQM3w6w()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LpRNCdMun0 = new TextBox();
		SuspendLayout();
		LpRNCdMun0.Location = new Point(13, 13);
		LpRNCdMun0.Multiline = true;
		LpRNCdMun0.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(52336);
		LpRNCdMun0.ScrollBars = ScrollBars.Vertical;
		LpRNCdMun0.Size = new Size(780, 547);
		LpRNCdMun0.TabIndex = 0;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(805, 572);
		base.Controls.Add(LpRNCdMun0);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(52358);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(52402);
		base.Load += JuVNoPM1HX;
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
