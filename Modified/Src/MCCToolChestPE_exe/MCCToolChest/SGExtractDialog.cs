using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ceSmgmuGAR2IorKvvso;
using MCCToolChest.forms;
using MCCToolChest.MCSBCode;
using MCCToolChest.model;
using MCCToolChest.Properties;
using MCCToolChest.utils;
using MCCToolChestDB.Model;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest;

public class SGExtractDialog : Form
{
	private string QKgSMoJXacu;

	private string L3uSMQe5VqG;

	private string Mm6SMOcyUcD;

	private string rUrSMCnJ2Ii;

	private RunTypes UgXSM7LTm9D;

	private Dictionary<string, ModifiedFile> lUbSMAgmD7e;

	private ConvertParameters NpDSMdZTEHG;

	private MergeParameters CKhSMHGqxXQ;

	private string[] v5lSMFpJuwR;

	private ConvertStatus F2tSMjYwsKS;

	private IContainer imRSM87mBD9;

	private BackgroundWorker JJQSM9niwvH;

	private Label Gr6SMIUhGko;

	private ProgressBar TExSMz6Nj6p;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SGExtractDialog()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		InitForm();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SGExtractDialog(string folderPath, RunTypes runType)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		rUrSMCnJ2Ii = folderPath;
		UgXSM7LTm9D = runType;
		InitForm();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SGExtractDialog(string folderPath, ConvertParameters convertParameters, RunTypes runType)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		rUrSMCnJ2Ii = folderPath;
		NpDSMdZTEHG = convertParameters;
		UgXSM7LTm9D = runType;
		InitForm();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SGExtractDialog(string pcPath, string folderPath, ConvertParameters convertParameters, RunTypes runType)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		QKgSMoJXacu = pcPath;
		rUrSMCnJ2Ii = folderPath;
		NpDSMdZTEHG = convertParameters;
		UgXSM7LTm9D = runType;
		InitForm();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SGExtractDialog(string mergePath, string folderPath, MergeParameters mergeParameters, RunTypes runType)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		L3uSMQe5VqG = mergePath;
		rUrSMCnJ2Ii = folderPath;
		CKhSMHGqxXQ = mergeParameters;
		UgXSM7LTm9D = runType;
		InitForm();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SGExtractDialog(string filePath, string folderPath, RunTypes runType)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		Mm6SMOcyUcD = filePath;
		rUrSMCnJ2Ii = folderPath;
		UgXSM7LTm9D = runType;
		InitForm();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SGExtractDialog(string filePath, string folderPath, RunTypes runType, Dictionary<string, ModifiedFile> modifiedFiles) : this(filePath, folderPath, runType)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		lUbSMAgmD7e = modifiedFiles;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void NybSM1xYAIu(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Text = v5lSMFpJuwR[(int)UgXSM7LTm9D];
		RunArgs runArgs = new RunArgs();
		runArgs.RunType = UgXSM7LTm9D;
		runArgs.FilePath = Mm6SMOcyUcD;
		runArgs.FolderPath = rUrSMCnJ2Ii;
		runArgs.PcPath = QKgSMoJXacu;
		runArgs.ConvertParameters = NpDSMdZTEHG;
		runArgs.MergeParameters = CKhSMHGqxXQ;
		runArgs.ModifiedFiles = lUbSMAgmD7e;
		RunArgs argument = runArgs;
		JJQSM9niwvH.RunWorkerAsync(argument);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DESSMEW0UcZ(object P_0, DoWorkEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BackgroundWorker backgroundWorker = P_0 as BackgroundWorker;
		backgroundWorker.WorkerReportsProgress = true;
		RunArgs runArgs = P_1.Argument as RunArgs;
		MCSupport mCSupport = new MCSupport(backgroundWorker);
		if (runArgs.RunType == RunTypes.Create)
		{
			mCSupport.nWYSGhQ0PhI(runArgs.FolderPath);
		}
		else if (runArgs.RunType == RunTypes.Save)
		{
			mCSupport.SaveFiles(runArgs.FolderPath, runArgs.ModifiedFiles);
		}
		else if (runArgs.RunType == RunTypes.ConvertToPC)
		{
			F2tSMjYwsKS = mCSupport.aW2SGgNVxI5(runArgs.FolderPath, runArgs.ConvertParameters);
		}
		else if (runArgs.RunType == RunTypes.ConvertFromPC)
		{
			F2tSMjYwsKS = mCSupport.Dk6SGO7M1kw(runArgs.PcPath, runArgs.FolderPath, runArgs.ConvertParameters);
		}
		else if (runArgs.RunType == RunTypes.MergeWorlds)
		{
			F2tSMjYwsKS = mCSupport.qXfSG4PMkbM(runArgs.FolderPath, runArgs.MergeParameters);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void fyESMru35bq(object P_0, ProgressChangedEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Gr6SMIUhGko.Text = P_1.UserState as string;
		Gr6SMIUhGko.Refresh();
		if (P_1.ProgressPercentage > 0 && P_1.ProgressPercentage < 101)
		{
			TExSMz6Nj6p.Value = P_1.ProgressPercentage;
		}
		TExSMz6Nj6p.Refresh();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void VFtSM5hGiXZ(object P_0, RunWorkerCompletedEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_1.Error != null)
		{
			string errorText = P_1.Error.ToString();
			try
			{
				W7XEw1ukTn4yRrm2wV4.VrfLq3utcbtaHoMfeNR.LTsSYeXGHCA(errorText);
			}
			catch
			{
			}
			DiagnosticConsole.WriteException(P_1.Error, "SGExtractDialog operation failed");
			MessageBox.Show(this, errorText, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			Close();
			return;
		}
		base.Visible = false;
		if (F2tSMjYwsKS != null)
		{
			ConversionStatus conversionStatus = new ConversionStatus(F2tSMjYwsKS);
			conversionStatus.ShowDialog(this);
			ReeSM6R7ooc(F2tSMjYwsKS);
		}
		Close();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ReeSM6R7ooc(ConvertStatus P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!Settings.Default.AllowTelemetry)
		{
			return;
		}
		string destinationVersion = "";
		string destinationPlatform = "";
		string sourcePlatform = "";
		if (NpDSMdZTEHG != null)
		{
			if (NpDSMdZTEHG.ConvertToFormat == ConversionFormat.PreAquatic)
			{
				destinationVersion = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(210538);
			}
			else if (NpDSMdZTEHG.ConvertToFormat == ConversionFormat.Aquatic)
			{
				destinationVersion = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(210562);
			}
			else if (NpDSMdZTEHG.ConvertToFormat == ConversionFormat.Aquatic113)
			{
				destinationVersion = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(210580);
			}
			destinationPlatform = ((UgXSM7LTm9D == RunTypes.ConvertToPC) ? Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(210608) : Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(122548));
			sourcePlatform = ((UgXSM7LTm9D == RunTypes.ConvertToPC) ? Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(122548) : Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(210608));
		}
		else if (CKhSMHGqxXQ != null)
		{
			destinationPlatform = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(122548);
			sourcePlatform = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(122548);
		}
		ConversionCount conversionCount = new ConversionCount();
		conversionCount.chunksConverted = P_0.ProcessedChunkCount;
		conversionCount.destinationPlatform = destinationPlatform;
		conversionCount.sourcePlatform = sourcePlatform;
		conversionCount.destinationVersion = destinationVersion;
		conversionCount.program = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(210620);
		SNBte6usOpaAUe38VsS sNBte6usOpaAUe38VsS = new SNBte6usOpaAUe38VsS();
		sNBte6usOpaAUe38VsS.ad0SYoOd8A5(conversionCount);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void kHySMNcpUAv(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (JJQSM9niwvH.WorkerSupportsCancellation)
		{
			JJQSM9niwvH.CancelAsync();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void yq2SMDT4bF2(object P_0, FormClosingEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (JJQSM9niwvH.IsBusy)
		{
			P_1.Cancel = true;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void nIySMckAkMN()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void yBNSMJVOEGW(object P_0, EventArgs P_1)
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
		if (disposing && imRSM87mBD9 != null)
		{
			imRSM87mBD9.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitForm()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (JJQSM9niwvH != null)
		{
			return;
		}
		v5lSMFpJuwR = new string[7]
		{
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(94118),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(94064),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29604),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(210406),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(210436),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(210470),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(210510)
		};
		CFYSMuDksDU();
		JJQSM9niwvH.WorkerReportsProgress = true;
		JJQSM9niwvH.WorkerSupportsCancellation = true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CFYSMuDksDU()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		JJQSM9niwvH = new BackgroundWorker();
		Gr6SMIUhGko = new Label();
		TExSMz6Nj6p = new ProgressBar();
		SuspendLayout();
		JJQSM9niwvH.DoWork += DESSMEW0UcZ;
		JJQSM9niwvH.ProgressChanged += fyESMru35bq;
		JJQSM9niwvH.RunWorkerCompleted += VFtSM5hGiXZ;
		Gr6SMIUhGko.AutoSize = true;
		Gr6SMIUhGko.Location = new Point(12, 47);
		Gr6SMIUhGko.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(53914);
		Gr6SMIUhGko.Size = new Size(43, 13);
		Gr6SMIUhGko.TabIndex = 0;
		Gr6SMIUhGko.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(210652);
		TExSMz6Nj6p.Location = new Point(12, 12);
		TExSMz6Nj6p.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21270);
		TExSMz6Nj6p.Size = new Size(382, 23);
		TExSMz6Nj6p.Style = ProgressBarStyle.Marquee;
		TExSMz6Nj6p.TabIndex = 1;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(406, 79);
		base.ControlBox = false;
		base.Controls.Add(TExSMz6Nj6p);
		base.Controls.Add(Gr6SMIUhGko);
		base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(210670);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(94118);
		base.FormClosing += yq2SMDT4bF2;
		base.Load += yBNSMJVOEGW;
		base.Shown += NybSM1xYAIu;
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
