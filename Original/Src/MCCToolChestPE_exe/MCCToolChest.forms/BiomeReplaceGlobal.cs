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

public class BiomeReplaceGlobal : Form
{
	private string CLM6Vt9CbP;

	private bool j1R6WPLPGJ;

	private BackgroundWorker y5u6paKGHV;

	private IContainer JrH6ZRtaR9;

	private TableLayoutPanel hta6f6lTuC;

	private Panel s226iIwN5V;

	private Button wDC6sq8Med;

	private ComboBox nJa6qDjQes;

	private ProgressBar swy6Kwyv4h;

	private Label FTo6hf4nKU;

	private Label eMr6mMufsJ;

	private ReplaceBiomeConfig vQF6nkpmx9;

	public bool ChangesMade
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return j1R6WPLPGJ;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			j1R6WPLPGJ = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BiomeReplaceGlobal(string workingFolder)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		y5u6paKGHV = new BackgroundWorker();
		CLM6Vt9CbP = workingFolder;
		Thh64llW5O();
		fGn5IygWkY();
		jw26TCfIRH();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void fGn5IygWkY()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		nJa6qDjQes.ValueMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10936);
		nJa6qDjQes.DisplayMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11118);
		nJa6qDjQes.DataSource = new BindingSource(Constants.dimensionNames, null);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void sEM5zmwwOX(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!y5u6paKGHV.IsBusy)
		{
			Smv6S841j5();
			j1R6WPLPGJ = true;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void jw26TCfIRH()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		y5u6paKGHV.DoWork += Ms76GkGhpj;
		y5u6paKGHV.ProgressChanged += xRk6bF8lvV;
		y5u6paKGHV.RunWorkerCompleted += c4K6vYbjNb;
		y5u6paKGHV.WorkerReportsProgress = true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Smv6S841j5()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<BiomeChange> replacementBiomeList = vQF6nkpmx9.BuildBiomeChangeList();
		string dimension = (string)nJa6qDjQes.SelectedValue;
		ReplaceBiomeGlobalParameter argument = new ReplaceBiomeGlobalParameter(dimension, replacementBiomeList, CLM6Vt9CbP);
		y5u6paKGHV.RunWorkerAsync(argument);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Ms76GkGhpj(object P_0, DoWorkEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BackgroundWorker backgroundWorker = P_0 as BackgroundWorker;
		ReplaceBiomeGlobalParameter replaceBiomeGlobalParameter = P_1.Argument as ReplaceBiomeGlobalParameter;
		ReplacePEBiomeGlobalWorker replacePEBiomeGlobalWorker = new ReplacePEBiomeGlobalWorker(backgroundWorker);
		replacePEBiomeGlobalWorker.DoReplace(replaceBiomeGlobalParameter.Dimension, replaceBiomeGlobalParameter.ReplacementBiomeList, replaceBiomeGlobalParameter.OutFolderPath);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void xRk6bF8lvV(object P_0, ProgressChangedEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		FTo6hf4nKU.Text = P_1.UserState as string;
		if (P_1.ProgressPercentage > 0)
		{
			swy6Kwyv4h.Value = P_1.ProgressPercentage;
		}
		swy6Kwyv4h.Refresh();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void c4K6vYbjNb(object P_0, RunWorkerCompletedEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		swy6Kwyv4h.Value = 0;
		FTo6hf4nKU.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37010);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void d5y6wTHZOv(object P_0, EventArgs P_1)
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
		if (disposing && JrH6ZRtaR9 != null)
		{
			JrH6ZRtaR9.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Thh64llW5O()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		hta6f6lTuC = new TableLayoutPanel();
		s226iIwN5V = new Panel();
		eMr6mMufsJ = new Label();
		FTo6hf4nKU = new Label();
		swy6Kwyv4h = new ProgressBar();
		nJa6qDjQes = new ComboBox();
		wDC6sq8Med = new Button();
		vQF6nkpmx9 = new ReplaceBiomeConfig();
		hta6f6lTuC.SuspendLayout();
		s226iIwN5V.SuspendLayout();
		SuspendLayout();
		hta6f6lTuC.ColumnCount = 1;
		hta6f6lTuC.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		hta6f6lTuC.Controls.Add(s226iIwN5V, 0, 1);
		hta6f6lTuC.Controls.Add(vQF6nkpmx9, 0, 0);
		hta6f6lTuC.Dock = DockStyle.Fill;
		hta6f6lTuC.Location = new Point(0, 0);
		hta6f6lTuC.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10826);
		hta6f6lTuC.RowCount = 2;
		hta6f6lTuC.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		hta6f6lTuC.RowStyles.Add(new RowStyle(SizeType.Absolute, 40f));
		hta6f6lTuC.Size = new Size(822, 557);
		hta6f6lTuC.TabIndex = 0;
		s226iIwN5V.Controls.Add(eMr6mMufsJ);
		s226iIwN5V.Controls.Add(FTo6hf4nKU);
		s226iIwN5V.Controls.Add(swy6Kwyv4h);
		s226iIwN5V.Controls.Add(nJa6qDjQes);
		s226iIwN5V.Controls.Add(wDC6sq8Med);
		s226iIwN5V.Dock = DockStyle.Fill;
		s226iIwN5V.Location = new Point(3, 520);
		s226iIwN5V.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10398);
		s226iIwN5V.Size = new Size(816, 34);
		s226iIwN5V.TabIndex = 1;
		eMr6mMufsJ.AutoSize = true;
		eMr6mMufsJ.Location = new Point(574, 11);
		eMr6mMufsJ.Margin = new Padding(0);
		eMr6mMufsJ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		eMr6mMufsJ.Size = new Size(56, 13);
		eMr6mMufsJ.TabIndex = 4;
		eMr6mMufsJ.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37092);
		eMr6mMufsJ.TextAlign = ContentAlignment.MiddleRight;
		FTo6hf4nKU.AutoSize = true;
		FTo6hf4nKU.Location = new Point(282, 13);
		FTo6hf4nKU.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37114);
		FTo6hf4nKU.Size = new Size(19, 13);
		FTo6hf4nKU.TabIndex = 3;
		FTo6hf4nKU.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28858);
		swy6Kwyv4h.Location = new Point(10, 6);
		swy6Kwyv4h.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37136);
		swy6Kwyv4h.Size = new Size(265, 23);
		swy6Kwyv4h.TabIndex = 2;
		nJa6qDjQes.DropDownStyle = ComboBoxStyle.DropDownList;
		nJa6qDjQes.FormattingEnabled = true;
		nJa6qDjQes.Location = new Point(631, 6);
		nJa6qDjQes.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37176);
		nJa6qDjQes.Size = new Size(89, 21);
		nJa6qDjQes.TabIndex = 1;
		wDC6sq8Med.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		wDC6sq8Med.Location = new Point(728, 6);
		wDC6sq8Med.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37196);
		wDC6sq8Med.Size = new Size(75, 23);
		wDC6sq8Med.TabIndex = 0;
		wDC6sq8Med.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37220);
		wDC6sq8Med.UseVisualStyleBackColor = true;
		wDC6sq8Med.Click += sEM5zmwwOX;
		vQF6nkpmx9.Dock = DockStyle.Fill;
		vQF6nkpmx9.Location = new Point(3, 3);
		vQF6nkpmx9.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(36498);
		vQF6nkpmx9.Size = new Size(816, 511);
		vQF6nkpmx9.TabIndex = 2;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(822, 557);
		base.Controls.Add(hta6f6lTuC);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(45094);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(45134);
		base.Load += d5y6wTHZOv;
		hta6f6lTuC.ResumeLayout(performLayout: false);
		s226iIwN5V.ResumeLayout(performLayout: false);
		s226iIwN5V.PerformLayout();
		ResumeLayout(performLayout: false);
	}
}
