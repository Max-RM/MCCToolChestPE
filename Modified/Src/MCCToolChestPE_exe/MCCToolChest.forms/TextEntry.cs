using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.Properties;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.forms;

public class TextEntry : Form
{
	private IContainer Ana885QYnv;

	private Label E3389Fqxy8;

	private TextBox QwH8IoTZIq;

	private Button Eh98zaZN96;

	private Button X2v9TdVko7;

	public string EntryValue
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return QwH8IoTZIq.Text;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TextEntry(string label)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		e3B8jK9SfK();
		Text = label + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(62700);
		E3389Fqxy8.Text = label;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PG48FUU56B(object P_0, EventArgs P_1)
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
		if (disposing && Ana885QYnv != null)
		{
			Ana885QYnv.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void e3B8jK9SfK()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		E3389Fqxy8 = new Label();
		QwH8IoTZIq = new TextBox();
		Eh98zaZN96 = new Button();
		X2v9TdVko7 = new Button();
		SuspendLayout();
		E3389Fqxy8.AutoSize = true;
		E3389Fqxy8.Location = new Point(12, 9);
		E3389Fqxy8.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(62716);
		E3389Fqxy8.Size = new Size(35, 13);
		E3389Fqxy8.TabIndex = 0;
		E3389Fqxy8.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		QwH8IoTZIq.Location = new Point(15, 25);
		QwH8IoTZIq.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(62744);
		QwH8IoTZIq.Size = new Size(382, 20);
		QwH8IoTZIq.TabIndex = 1;
		Eh98zaZN96.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		Eh98zaZN96.DialogResult = DialogResult.Cancel;
		Eh98zaZN96.Location = new Point(322, 55);
		Eh98zaZN96.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34610);
		Eh98zaZN96.Size = new Size(75, 23);
		Eh98zaZN96.TabIndex = 29;
		Eh98zaZN96.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20198);
		Eh98zaZN96.UseVisualStyleBackColor = true;
		X2v9TdVko7.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		X2v9TdVko7.DialogResult = DialogResult.OK;
		X2v9TdVko7.Location = new Point(239, 55);
		X2v9TdVko7.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(35742);
		X2v9TdVko7.Size = new Size(75, 23);
		X2v9TdVko7.TabIndex = 28;
		X2v9TdVko7.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(53536);
		base.AcceptButton = X2v9TdVko7;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = Eh98zaZN96;
		base.ClientSize = new Size(409, 87);
		base.Controls.Add(Eh98zaZN96);
		base.Controls.Add(X2v9TdVko7);
		base.Controls.Add(QwH8IoTZIq);
		base.Controls.Add(E3389Fqxy8);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(62762);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(62762);
		base.Load += PG48FUU56B;
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
