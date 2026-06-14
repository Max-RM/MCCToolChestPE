using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.MCSBCode;
using MCCToolChest.Properties;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;
using zQq6f9juX6ulvXHQek2;

namespace MCCToolChest.forms;

public class ChangeBlockStateFormat : Form
{
	private BackgroundWorker o5TYImKZJC;

	private IContainer HIcYzmPKkb;

	private RadioButton TlO3TCVnEE;

	private RadioButton h4V3S1EAEN;

	private Button BwB3GIDw3N;

	private ProgressBar sqy3b0Fbmd;

	private Label VNi3v6ae5j;

	private Button jaS3w8Cbot;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ChangeBlockStateFormat()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		o5TYImKZJC = new BackgroundWorker();
		dviY91X3jB();
		cLCYAb1boF();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void xplYCfpZWd(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.Icon = Resources.usMSrbJo37S();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SQRY73amog(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TlO3TCVnEE.Visible = false;
		h4V3S1EAEN.Visible = false;
		BwB3GIDw3N.Visible = false;
		VNi3v6ae5j.Text = "";
		VNi3v6ae5j.Visible = true;
		sqy3b0Fbmd.Visible = true;
		x0mYd4bA2g();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void cLCYAb1boF()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		o5TYImKZJC.DoWork += iU6YHbfo7k;
		o5TYImKZJC.ProgressChanged += ci4YFNY3MF;
		o5TYImKZJC.RunWorkerCompleted += ib9YjpoYRc;
		o5TYImKZJC.WorkerReportsProgress = true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void x0mYd4bA2g()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		zxfLQ1jjjfM29YhQYjf zxfLQ1jjjfM29YhQYjf2 = new zxfLQ1jjjfM29YhQYjf();
		zxfLQ1jjjfM29YhQYjf2.ju79q1pKHq = ((!TlO3TCVnEE.Checked) ? BlockStateFormatType.FORMAT_113 : BlockStateFormatType.FORMAT_112);
		zxfLQ1jjjfM29YhQYjf argument = zxfLQ1jjjfM29YhQYjf2;
		o5TYImKZJC.RunWorkerAsync(argument);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void iU6YHbfo7k(object P_0, DoWorkEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		zxfLQ1jjjfM29YhQYjf zxfLQ1jjjfM29YhQYjf2 = P_1.Argument as zxfLQ1jjjfM29YhQYjf;
		BackgroundWorker backgroundWorker = P_0 as BackgroundWorker;
		ChangeBlockStateWorkerPE changeBlockStateWorkerPE = new ChangeBlockStateWorkerPE(backgroundWorker);
		changeBlockStateWorkerPE.DoBlockStateFormatChange(zxfLQ1jjjfM29YhQYjf2.ju79q1pKHq);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ci4YFNY3MF(object P_0, ProgressChangedEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		VNi3v6ae5j.Text = P_1.UserState as string;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ib9YjpoYRc(object P_0, RunWorkerCompletedEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		VNi3v6ae5j.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38200);
		sqy3b0Fbmd.Visible = false;
		jaS3w8Cbot.Visible = true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void zixY8fFAnk(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.DialogResult = DialogResult.OK;
		Close();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && HIcYzmPKkb != null)
		{
			HIcYzmPKkb.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void dviY91X3jB()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TlO3TCVnEE = new RadioButton();
		h4V3S1EAEN = new RadioButton();
		BwB3GIDw3N = new Button();
		sqy3b0Fbmd = new ProgressBar();
		VNi3v6ae5j = new Label();
		jaS3w8Cbot = new Button();
		SuspendLayout();
		TlO3TCVnEE.AutoSize = true;
		TlO3TCVnEE.Checked = true;
		TlO3TCVnEE.Location = new Point(27, 13);
		TlO3TCVnEE.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38276);
		TlO3TCVnEE.Size = new Size(130, 17);
		TlO3TCVnEE.TabIndex = 0;
		TlO3TCVnEE.TabStop = true;
		TlO3TCVnEE.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38302);
		TlO3TCVnEE.UseVisualStyleBackColor = true;
		h4V3S1EAEN.AutoSize = true;
		h4V3S1EAEN.Location = new Point(187, 13);
		h4V3S1EAEN.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38348);
		h4V3S1EAEN.Size = new Size(130, 17);
		h4V3S1EAEN.TabIndex = 1;
		h4V3S1EAEN.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38374);
		h4V3S1EAEN.UseVisualStyleBackColor = true;
		BwB3GIDw3N.Anchor = AnchorStyles.Bottom;
		BwB3GIDw3N.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		BwB3GIDw3N.Location = new Point(85, 34);
		BwB3GIDw3N.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38420);
		BwB3GIDw3N.Size = new Size(174, 22);
		BwB3GIDw3N.TabIndex = 2;
		BwB3GIDw3N.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38454);
		BwB3GIDw3N.UseVisualStyleBackColor = true;
		BwB3GIDw3N.Click += SQRY73amog;
		sqy3b0Fbmd.Location = new Point(10, 11);
		sqy3b0Fbmd.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21270);
		sqy3b0Fbmd.Size = new Size(325, 23);
		sqy3b0Fbmd.Style = ProgressBarStyle.Marquee;
		sqy3b0Fbmd.TabIndex = 3;
		sqy3b0Fbmd.Visible = false;
		VNi3v6ae5j.AutoSize = true;
		VNi3v6ae5j.Location = new Point(11, 39);
		VNi3v6ae5j.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37114);
		VNi3v6ae5j.Size = new Size(35, 13);
		VNi3v6ae5j.TabIndex = 4;
		VNi3v6ae5j.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		VNi3v6ae5j.Visible = false;
		jaS3w8Cbot.Location = new Point(135, 11);
		jaS3w8Cbot.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38508);
		jaS3w8Cbot.Size = new Size(75, 23);
		jaS3w8Cbot.TabIndex = 5;
		jaS3w8Cbot.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38528);
		jaS3w8Cbot.UseVisualStyleBackColor = true;
		jaS3w8Cbot.Visible = false;
		jaS3w8Cbot.Click += zixY8fFAnk;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(344, 63);
		base.Controls.Add(jaS3w8Cbot);
		base.Controls.Add(VNi3v6ae5j);
		base.Controls.Add(BwB3GIDw3N);
		base.Controls.Add(h4V3S1EAEN);
		base.Controls.Add(TlO3TCVnEE);
		base.Controls.Add(sqy3b0Fbmd);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38542);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38454);
		base.Load += xplYCfpZWd;
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
