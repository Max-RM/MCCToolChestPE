using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.MCSBCode.Workers;
using MCCToolChest.model.Parameter;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.forms;

public class MapWorkerStatus : Form
{
	private MapConverterParameters zRpHSiKsSZ;

	private BackgroundWorker gnvHGGJrHk;

	private IContainer AclHbNMMmD;

	private ProgressBar g2yHvPp4UK;

	private Label p6pHwo92VM;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MapWorkerStatus(MapConverterParameters parms)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		gnvHGGJrHk = new BackgroundWorker();
		cGfHTSQYh5();
		hKQdjnMWba();
		zRpHSiKsSZ = parms;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void kEZdFJqAro(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		IoJd811wMr();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hKQdjnMWba()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		gnvHGGJrHk.DoWork += sUYd9626ut;
		gnvHGGJrHk.ProgressChanged += XsddIEEVZb;
		gnvHGGJrHk.RunWorkerCompleted += zFRdzxtIsq;
		gnvHGGJrHk.WorkerReportsProgress = true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void IoJd811wMr()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		gnvHGGJrHk.RunWorkerAsync(zRpHSiKsSZ);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void sUYd9626ut(object P_0, DoWorkEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BackgroundWorker backgroundWorker = P_0 as BackgroundWorker;
		MapConverterParameters mapConverterParameters = P_1.Argument as MapConverterParameters;
		MapConverterWorker mapConverterWorker = new MapConverterWorker(backgroundWorker);
		mapConverterWorker.ConvertImage(mapConverterParameters.Width, mapConverterParameters.Height, mapConverterParameters.Image, mapConverterParameters.MapList, mapConverterParameters.Index, mapConverterParameters.RetainPerspective, mapConverterParameters.Interpolate);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void XsddIEEVZb(object P_0, ProgressChangedEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		p6pHwo92VM.Text = P_1.UserState as string;
		if (P_1.ProgressPercentage > 0)
		{
			g2yHvPp4UK.Value = P_1.ProgressPercentage;
		}
		p6pHwo92VM.Refresh();
		g2yHvPp4UK.Refresh();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void zFRdzxtIsq(object P_0, RunWorkerCompletedEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Close();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && AclHbNMMmD != null)
		{
			AclHbNMMmD.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void cGfHTSQYh5()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		g2yHvPp4UK = new ProgressBar();
		p6pHwo92VM = new Label();
		SuspendLayout();
		g2yHvPp4UK.BackColor = Color.White;
		g2yHvPp4UK.Location = new Point(12, 26);
		g2yHvPp4UK.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60218);
		g2yHvPp4UK.Size = new Size(426, 23);
		g2yHvPp4UK.TabIndex = 0;
		p6pHwo92VM.AutoSize = true;
		p6pHwo92VM.Location = new Point(15, 11);
		p6pHwo92VM.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37114);
		p6pHwo92VM.Size = new Size(35, 13);
		p6pHwo92VM.TabIndex = 1;
		p6pHwo92VM.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(451, 66);
		base.ControlBox = false;
		base.Controls.Add(p6pHwo92VM);
		base.Controls.Add(g2yHvPp4UK);
		base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60256);
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60290);
		base.Load += kEZdFJqAro;
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
