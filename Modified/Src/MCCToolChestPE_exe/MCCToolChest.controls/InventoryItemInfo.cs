using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls;

public class InventoryItemInfo : Form
{
	private IContainer pRTPMqtlCt;

	private Label doVPUFYePN;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public InventoryItemInfo()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		QrTPeRUR6a();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void showInfo(string info)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = string.IsNullOrWhiteSpace(info) ? Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714) : info;
		doVPUFYePN.Text = text;
		doVPUFYePN.AutoSize = true;
		Size textSize = TextRenderer.MeasureText(text, doVPUFYePN.Font, new Size(int.MaxValue, int.MaxValue), TextFormatFlags.NoPadding);
		int padding = 8;
		ClientSize = new Size(Math.Max(textSize.Width + padding, 48), Math.Max(doVPUFYePN.Height + padding, 22));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int p3kPxqqRR4(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		IntPtr handle = base.Handle;
		Graphics graphics = Graphics.FromHwnd(handle);
		new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12898), 16f);
		SizeF sizeF = default(SizeF);
		double num = graphics.MeasureString(P_0, doVPUFYePN.Font).Width;
		return (int)num;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && pRTPMqtlCt != null)
		{
			pRTPMqtlCt.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void QrTPeRUR6a()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		doVPUFYePN = new Label();
		SuspendLayout();
		doVPUFYePN.AutoSize = true;
		doVPUFYePN.BackColor = Color.White;
		doVPUFYePN.BorderStyle = BorderStyle.FixedSingle;
		doVPUFYePN.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
		doVPUFYePN.Location = new Point(0, 0);
		doVPUFYePN.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34554);
		doVPUFYePN.Size = new Size(48, 19);
		doVPUFYePN.TabIndex = 0;
		doVPUFYePN.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		AutoSize = true;
		BackColor = Color.Linen;
		base.ClientSize = new Size(57, 15);
		base.Controls.Add(doVPUFYePN);
		base.FormBorderStyle = FormBorderStyle.None;
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34572);
		base.ShowInTaskbar = false;
		base.SizeGripStyle = SizeGripStyle.Hide;
		base.StartPosition = FormStartPosition.Manual;
		base.TopMost = true;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34572);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
