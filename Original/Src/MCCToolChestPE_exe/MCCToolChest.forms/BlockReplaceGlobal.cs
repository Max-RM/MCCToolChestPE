using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.controls;
using MCCToolChest.MCSBCode;
using MCCToolChest.model;
using MCCToolChest.Properties;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.forms;

public class BlockReplaceGlobal : Form
{
	private string q6qRH8eiYo;

	private bool E0yRFX77P2;

	private BackgroundWorker ohlRjrwkdK;

	private IContainer HoqR8m9NC6;

	private TableLayoutPanel vkRR90ndcn;

	private ReplaceBlockConfigII hNmRIEjg7s;

	private Panel wkVRzkn58J;

	private Button NBGkT07gxO;

	private ComboBox FYAkS4RYZP;

	private ProgressBar y48kGBvuwm;

	private Label LaykbSfv2L;

	private Label wkTkvS1fUT;

	public bool ChangesMade
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return E0yRFX77P2;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			E0yRFX77P2 = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BlockReplaceGlobal(string workingFolder)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		ohlRjrwkdK = new BackgroundWorker();
		q6qRH8eiYo = workingFolder;
		lHBRdMS9jy();
		sNNRJOpV9K();
		We4RolMeD8();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void sNNRJOpV9K()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		FYAkS4RYZP.ValueMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10936);
		FYAkS4RYZP.DisplayMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11118);
		FYAkS4RYZP.DataSource = new BindingSource(Constants.dimensionNames, null);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ImhRuvnuvA(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!ohlRjrwkdK.IsBusy)
		{
			YolRQKjPSR();
			E0yRFX77P2 = true;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void We4RolMeD8()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ohlRjrwkdK.DoWork += gCKRO9BHOP;
		ohlRjrwkdK.ProgressChanged += T4dRCn0G1o;
		ohlRjrwkdK.RunWorkerCompleted += ROxR7mWws4;
		ohlRjrwkdK.WorkerReportsProgress = true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YolRQKjPSR()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<BlockChange> replacementBlockList = hNmRIEjg7s.BuildBlockChangeList();
		string dimension = (string)FYAkS4RYZP.SelectedValue;
		ReplaceBlockGlobalParameter argument = new ReplaceBlockGlobalParameter(dimension, replacementBlockList, q6qRH8eiYo);
		ohlRjrwkdK.RunWorkerAsync(argument);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void gCKRO9BHOP(object P_0, DoWorkEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BackgroundWorker backgroundWorker = P_0 as BackgroundWorker;
		ReplaceBlockGlobalParameter replaceBlockGlobalParameter = P_1.Argument as ReplaceBlockGlobalParameter;
		ReplaceBlockGlobalWorkerPE replaceBlockGlobalWorkerPE = new ReplaceBlockGlobalWorkerPE(backgroundWorker);
		replaceBlockGlobalWorkerPE.DoReplace(replaceBlockGlobalParameter.Dimension, replaceBlockGlobalParameter.ReplacementBlockList, replaceBlockGlobalParameter.OutFolderPath);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void T4dRCn0G1o(object P_0, ProgressChangedEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LaykbSfv2L.Text = P_1.UserState as string;
		if (P_1.ProgressPercentage > 0)
		{
			y48kGBvuwm.Value = P_1.ProgressPercentage;
		}
		y48kGBvuwm.Refresh();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ROxR7mWws4(object P_0, RunWorkerCompletedEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		y48kGBvuwm.Value = 0;
		LaykbSfv2L.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37010);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SuERAhNLkb(object P_0, EventArgs P_1)
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
		if (disposing && HoqR8m9NC6 != null)
		{
			HoqR8m9NC6.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void lHBRdMS9jy()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		vkRR90ndcn = new TableLayoutPanel();
		hNmRIEjg7s = new ReplaceBlockConfigII();
		wkVRzkn58J = new Panel();
		wkTkvS1fUT = new Label();
		LaykbSfv2L = new Label();
		y48kGBvuwm = new ProgressBar();
		FYAkS4RYZP = new ComboBox();
		NBGkT07gxO = new Button();
		vkRR90ndcn.SuspendLayout();
		wkVRzkn58J.SuspendLayout();
		SuspendLayout();
		vkRR90ndcn.ColumnCount = 1;
		vkRR90ndcn.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		vkRR90ndcn.Controls.Add(hNmRIEjg7s, 0, 0);
		vkRR90ndcn.Controls.Add(wkVRzkn58J, 0, 1);
		vkRR90ndcn.Dock = DockStyle.Fill;
		vkRR90ndcn.Location = new Point(0, 0);
		vkRR90ndcn.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10826);
		vkRR90ndcn.RowCount = 2;
		vkRR90ndcn.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		vkRR90ndcn.RowStyles.Add(new RowStyle(SizeType.Absolute, 40f));
		vkRR90ndcn.Size = new Size(822, 557);
		vkRR90ndcn.TabIndex = 0;
		hNmRIEjg7s.ConvertType = ConvertType.Other;
		hNmRIEjg7s.Dock = DockStyle.Fill;
		hNmRIEjg7s.Location = new Point(3, 3);
		hNmRIEjg7s.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37050);
		hNmRIEjg7s.Size = new Size(816, 511);
		hNmRIEjg7s.TabIndex = 0;
		wkVRzkn58J.Controls.Add(wkTkvS1fUT);
		wkVRzkn58J.Controls.Add(LaykbSfv2L);
		wkVRzkn58J.Controls.Add(y48kGBvuwm);
		wkVRzkn58J.Controls.Add(FYAkS4RYZP);
		wkVRzkn58J.Controls.Add(NBGkT07gxO);
		wkVRzkn58J.Dock = DockStyle.Fill;
		wkVRzkn58J.Location = new Point(3, 520);
		wkVRzkn58J.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10398);
		wkVRzkn58J.Size = new Size(816, 34);
		wkVRzkn58J.TabIndex = 1;
		wkTkvS1fUT.AutoSize = true;
		wkTkvS1fUT.Location = new Point(574, 11);
		wkTkvS1fUT.Margin = new Padding(0);
		wkTkvS1fUT.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		wkTkvS1fUT.Size = new Size(56, 13);
		wkTkvS1fUT.TabIndex = 4;
		wkTkvS1fUT.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37092);
		wkTkvS1fUT.TextAlign = ContentAlignment.MiddleRight;
		LaykbSfv2L.AutoSize = true;
		LaykbSfv2L.Location = new Point(282, 13);
		LaykbSfv2L.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37114);
		LaykbSfv2L.Size = new Size(19, 13);
		LaykbSfv2L.TabIndex = 3;
		LaykbSfv2L.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28858);
		y48kGBvuwm.Location = new Point(10, 6);
		y48kGBvuwm.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37136);
		y48kGBvuwm.Size = new Size(265, 23);
		y48kGBvuwm.TabIndex = 2;
		FYAkS4RYZP.DropDownStyle = ComboBoxStyle.DropDownList;
		FYAkS4RYZP.FormattingEnabled = true;
		FYAkS4RYZP.Location = new Point(631, 6);
		FYAkS4RYZP.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37176);
		FYAkS4RYZP.Size = new Size(89, 21);
		FYAkS4RYZP.TabIndex = 1;
		NBGkT07gxO.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		NBGkT07gxO.Location = new Point(728, 6);
		NBGkT07gxO.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37196);
		NBGkT07gxO.Size = new Size(75, 23);
		NBGkT07gxO.TabIndex = 0;
		NBGkT07gxO.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37220);
		NBGkT07gxO.UseVisualStyleBackColor = true;
		NBGkT07gxO.Click += ImhRuvnuvA;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(822, 557);
		base.Controls.Add(vkRR90ndcn);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37238);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37278);
		base.Load += SuERAhNLkb;
		vkRR90ndcn.ResumeLayout(performLayout: false);
		wkVRzkn58J.ResumeLayout(performLayout: false);
		wkVRzkn58J.PerformLayout();
		ResumeLayout(performLayout: false);
	}
}
