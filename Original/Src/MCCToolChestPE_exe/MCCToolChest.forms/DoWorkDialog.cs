using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.MCSBCode;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.forms;

public class DoWorkDialog : Form
{
	private IContainer T4CutgFpUu;

	private ProgressBar Yt2uad87RC;

	private BackgroundWorker a7SuXUf7Tv;

	private Label CGouxsuYbK;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DoWorkDialog()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		VMiuBJAMiM();
		a7SuXUf7Tv.WorkerReportsProgress = true;
		a7SuXUf7Tv.WorkerSupportsCancellation = true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void fc5uliOWIw(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		a7SuXUf7Tv.RunWorkerAsync();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void baFu2dnTaY(object P_0, DoWorkEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BackgroundWorker backgroundWorker = P_0 as BackgroundWorker;
		backgroundWorker.WorkerReportsProgress = true;
		LogicCleanupAquatic logicCleanupAquatic = new LogicCleanupAquatic(backgroundWorker);
		logicCleanupAquatic.DoSearchReplace();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void egRuyEeDby(object P_0, ProgressChangedEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		CGouxsuYbK.Text = P_1.UserState as string;
		CGouxsuYbK.Refresh();
		if (P_1.ProgressPercentage > 0 && P_1.ProgressPercentage < 101)
		{
			Yt2uad87RC.Value = P_1.ProgressPercentage;
		}
		Yt2uad87RC.Refresh();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void dEvu0nvqOE(object P_0, RunWorkerCompletedEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.Visible = false;
		Close();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && T4CutgFpUu != null)
		{
			T4CutgFpUu.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void VMiuBJAMiM()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Yt2uad87RC = new ProgressBar();
		a7SuXUf7Tv = new BackgroundWorker();
		CGouxsuYbK = new Label();
		SuspendLayout();
		Yt2uad87RC.Location = new Point(12, 21);
		Yt2uad87RC.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21270);
		Yt2uad87RC.Size = new Size(563, 23);
		Yt2uad87RC.TabIndex = 0;
		a7SuXUf7Tv.DoWork += baFu2dnTaY;
		a7SuXUf7Tv.ProgressChanged += egRuyEeDby;
		a7SuXUf7Tv.RunWorkerCompleted += dEvu0nvqOE;
		CGouxsuYbK.AutoSize = true;
		CGouxsuYbK.Location = new Point(14, 47);
		CGouxsuYbK.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(53914);
		CGouxsuYbK.Size = new Size(35, 13);
		CGouxsuYbK.TabIndex = 1;
		CGouxsuYbK.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(588, 80);
		base.Controls.Add(CGouxsuYbK);
		base.Controls.Add(Yt2uad87RC);
		base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(53940);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(53940);
		base.Shown += fc5uliOWIw;
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
