using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.events;
using MCCToolChest.model;
using MCCToolChest.Properties;
using MCCToolChest.workers;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.forms;

public class AreaActionDialog : Form
{
	private BackgroundWorker d5vNp4D7PE;

	private AreaActionEventArgs IpINZdKqCt;

	private IContainer HhKNf1nfm1;

	private Label sNfNimo6FJ;

	private ProgressBar S4mNsGGe51;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AreaActionDialog(AreaActionEventArgs args)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		d5vNp4D7PE = new BackgroundWorker();
		K8nNWK5XlN();
		Xv2NGvoxqL();
		IpINZdKqCt = args;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void eRgNSnT8km(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.Icon = Resources.usMSrbJo37S();
		tI2Nb8f4ra(IpINZdKqCt);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Xv2NGvoxqL()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		d5vNp4D7PE.DoWork += zriNvKoEm5;
		d5vNp4D7PE.ProgressChanged += qHRNwPrrcP;
		d5vNp4D7PE.RunWorkerCompleted += zddN4n0qPS;
		d5vNp4D7PE.WorkerReportsProgress = true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void tI2Nb8f4ra(AreaActionEventArgs P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		d5vNp4D7PE.RunWorkerAsync(P_0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void zriNvKoEm5(object P_0, DoWorkEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BackgroundWorker backgroundWorker = P_0 as BackgroundWorker;
		AreaActionEventArgs e = P_1.Argument as AreaActionEventArgs;
		ChunkWorker chunkWorker = new ChunkWorker(backgroundWorker);
		if (e.AreaAction == AreaActionType.AREACOPY)
		{
			chunkWorker.CopyAreaChunks(e);
		}
		else if (e.AreaAction == AreaActionType.AREAFILL)
		{
			chunkWorker.FillAreaWithArea(e);
		}
		else if (e.AreaAction == AreaActionType.CHUNKFILL)
		{
			chunkWorker.FillAreaWithChunk(e);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void qHRNwPrrcP(object P_0, ProgressChangedEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		sNfNimo6FJ.Text = P_1.UserState as string;
		if (P_1.ProgressPercentage > 0)
		{
			S4mNsGGe51.Value = P_1.ProgressPercentage;
		}
		S4mNsGGe51.Refresh();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void zddN4n0qPS(object P_0, RunWorkerCompletedEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		S4mNsGGe51.Value = 0;
		sNfNimo6FJ.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(45480);
		Close();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void aM7NVACgFj(object P_0, FormClosingEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (d5vNp4D7PE.IsBusy)
		{
			P_1.Cancel = true;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && HhKNf1nfm1 != null)
		{
			HhKNf1nfm1.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void K8nNWK5XlN()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		sNfNimo6FJ = new Label();
		S4mNsGGe51 = new ProgressBar();
		SuspendLayout();
		sNfNimo6FJ.AutoSize = true;
		sNfNimo6FJ.Location = new Point(14, 57);
		sNfNimo6FJ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37114);
		sNfNimo6FJ.Size = new Size(19, 13);
		sNfNimo6FJ.TabIndex = 5;
		sNfNimo6FJ.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28858);
		S4mNsGGe51.Location = new Point(11, 25);
		S4mNsGGe51.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37136);
		S4mNsGGe51.Size = new Size(275, 23);
		S4mNsGGe51.TabIndex = 4;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(294, 96);
		base.Controls.Add(sNfNimo6FJ);
		base.Controls.Add(S4mNsGGe51);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(45536);
		base.SizeGripStyle = SizeGripStyle.Hide;
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(45568);
		base.FormClosing += aM7NVACgFj;
		base.Load += eRgNSnT8km;
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
