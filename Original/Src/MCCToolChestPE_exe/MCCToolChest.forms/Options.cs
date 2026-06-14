using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.Properties;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.forms;

public class Options : Form
{
	private IContainer Rhajqix4xg;

	private Button UFUjKdMpsA;

	private Button f79jhHT1Hg;

	private CheckBox PgnjmCtPrH;

	private CheckBox yR7jndGx5y;

	private CheckBox qO3jlNmBvX;

	private CheckBox hrFj2QZBVZ;

	private CheckBox FHJjysNG50;

	private CheckBox kafj0tpGch;

	private Label C1BjBTN9vR;

	private Label uBYjtMHlV4;

	private TrackBar BuLjaPa8Ml;

	private CheckBox TKHjXtDlXa;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Options()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		CdtjsDeIyL();
		PgnjmCtPrH.Checked = Settings.Default.ArchiveWorld;
		yR7jndGx5y.Checked = Settings.Default.VerifyOnDelete;
		qO3jlNmBvX.Checked = Settings.Default.AllowTelemetry;
		hrFj2QZBVZ.Checked = Settings.Default.AutoCheckUpdates;
		FHJjysNG50.Checked = Settings.Default.UseFileExplorer;
		kafj0tpGch.Checked = Settings.Default.UseTestVersion;
		TKHjXtDlXa.Checked = Settings.Default.ShowSplashScreen;
		BuLjaPa8Ml.Value = Settings.Default.HrybridOpacity;
		C1BjBTN9vR.Text = Settings.Default.HrybridOpacity.ToString();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void uuEjZ3S4VA(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Settings.Default.VerifyOnDelete = yR7jndGx5y.Checked;
		Settings.Default.AllowTelemetry = qO3jlNmBvX.Checked;
		Settings.Default.AutoCheckUpdates = hrFj2QZBVZ.Checked;
		Settings.Default.UseFileExplorer = FHJjysNG50.Checked;
		Settings.Default.UseTestVersion = kafj0tpGch.Checked;
		Settings.Default.ArchiveGameFile = PgnjmCtPrH.Checked;
		Settings.Default.HrybridOpacity = BuLjaPa8Ml.Value;
		Settings.Default.ShowSplashScreen = TKHjXtDlXa.Checked;
		Settings.Default.Save();
		base.DialogResult = DialogResult.OK;
		Close();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void tSTjfOlyop(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.Icon = Resources.usMSrbJo37S();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AuRjirWEiH(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		C1BjBTN9vR.Text = BuLjaPa8Ml.Value.ToString();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && Rhajqix4xg != null)
		{
			Rhajqix4xg.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CdtjsDeIyL()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		UFUjKdMpsA = new Button();
		f79jhHT1Hg = new Button();
		PgnjmCtPrH = new CheckBox();
		yR7jndGx5y = new CheckBox();
		qO3jlNmBvX = new CheckBox();
		hrFj2QZBVZ = new CheckBox();
		FHJjysNG50 = new CheckBox();
		kafj0tpGch = new CheckBox();
		C1BjBTN9vR = new Label();
		uBYjtMHlV4 = new Label();
		BuLjaPa8Ml = new TrackBar();
		TKHjXtDlXa = new CheckBox();
		((ISupportInitialize)BuLjaPa8Ml).BeginInit();
		SuspendLayout();
		UFUjKdMpsA.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		UFUjKdMpsA.DialogResult = DialogResult.Cancel;
		UFUjKdMpsA.Location = new Point(146, 288);
		UFUjKdMpsA.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(35742);
		UFUjKdMpsA.Size = new Size(75, 23);
		UFUjKdMpsA.TabIndex = 25;
		UFUjKdMpsA.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(53536);
		UFUjKdMpsA.Click += uuEjZ3S4VA;
		f79jhHT1Hg.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		f79jhHT1Hg.DialogResult = DialogResult.Cancel;
		f79jhHT1Hg.Location = new Point(229, 288);
		f79jhHT1Hg.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34610);
		f79jhHT1Hg.Size = new Size(75, 23);
		f79jhHT1Hg.TabIndex = 27;
		f79jhHT1Hg.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20198);
		f79jhHT1Hg.UseVisualStyleBackColor = true;
		PgnjmCtPrH.AutoSize = true;
		PgnjmCtPrH.Location = new Point(10, 157);
		PgnjmCtPrH.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(61396);
		PgnjmCtPrH.Size = new Size(160, 17);
		PgnjmCtPrH.TabIndex = 33;
		PgnjmCtPrH.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(61418);
		PgnjmCtPrH.UseVisualStyleBackColor = true;
		yR7jndGx5y.AutoSize = true;
		yR7jndGx5y.Location = new Point(10, 18);
		yR7jndGx5y.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(61478);
		yR7jndGx5y.Size = new Size(103, 17);
		yR7jndGx5y.TabIndex = 34;
		yR7jndGx5y.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(61514);
		yR7jndGx5y.UseVisualStyleBackColor = true;
		qO3jlNmBvX.AutoSize = true;
		qO3jlNmBvX.Location = new Point(10, 46);
		qO3jlNmBvX.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(61550);
		qO3jlNmBvX.Size = new Size(100, 17);
		qO3jlNmBvX.TabIndex = 35;
		qO3jlNmBvX.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(61586);
		qO3jlNmBvX.UseVisualStyleBackColor = true;
		hrFj2QZBVZ.AutoSize = true;
		hrFj2QZBVZ.Location = new Point(10, 74);
		hrFj2QZBVZ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(61620);
		hrFj2QZBVZ.Size = new Size(146, 17);
		hrFj2QZBVZ.TabIndex = 36;
		hrFj2QZBVZ.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(61650);
		hrFj2QZBVZ.UseVisualStyleBackColor = true;
		FHJjysNG50.AutoSize = true;
		FHJjysNG50.Location = new Point(10, 102);
		FHJjysNG50.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(61704);
		FHJjysNG50.Size = new Size(234, 17);
		FHJjysNG50.TabIndex = 37;
		FHJjysNG50.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(61742);
		FHJjysNG50.UseVisualStyleBackColor = true;
		kafj0tpGch.AutoSize = true;
		kafj0tpGch.Location = new Point(10, 130);
		kafj0tpGch.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(61832);
		kafj0tpGch.Size = new Size(102, 17);
		kafj0tpGch.TabIndex = 38;
		kafj0tpGch.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(61868);
		kafj0tpGch.UseVisualStyleBackColor = true;
		C1BjBTN9vR.AutoSize = true;
		C1BjBTN9vR.Location = new Point(112, 216);
		C1BjBTN9vR.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(61904);
		C1BjBTN9vR.Size = new Size(13, 13);
		C1BjBTN9vR.TabIndex = 49;
		C1BjBTN9vR.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10708);
		uBYjtMHlV4.AutoSize = true;
		uBYjtMHlV4.Location = new Point(12, 216);
		uBYjtMHlV4.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11298);
		uBYjtMHlV4.Size = new Size(102, 13);
		uBYjtMHlV4.TabIndex = 47;
		uBYjtMHlV4.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(61928);
		BuLjaPa8Ml.Location = new Point(10, 233);
		BuLjaPa8Ml.Maximum = 100;
		BuLjaPa8Ml.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(61970);
		BuLjaPa8Ml.Size = new Size(292, 45);
		BuLjaPa8Ml.TabIndex = 48;
		BuLjaPa8Ml.ValueChanged += AuRjirWEiH;
		TKHjXtDlXa.AutoSize = true;
		TKHjXtDlXa.Location = new Point(10, 183);
		TKHjXtDlXa.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(61992);
		TKHjXtDlXa.Size = new Size(125, 17);
		TKHjXtDlXa.TabIndex = 50;
		TKHjXtDlXa.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(62032);
		TKHjXtDlXa.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = SystemColors.Control;
		base.ClientSize = new Size(316, 319);
		base.Controls.Add(TKHjXtDlXa);
		base.Controls.Add(C1BjBTN9vR);
		base.Controls.Add(uBYjtMHlV4);
		base.Controls.Add(kafj0tpGch);
		base.Controls.Add(FHJjysNG50);
		base.Controls.Add(hrFj2QZBVZ);
		base.Controls.Add(qO3jlNmBvX);
		base.Controls.Add(yR7jndGx5y);
		base.Controls.Add(PgnjmCtPrH);
		base.Controls.Add(f79jhHT1Hg);
		base.Controls.Add(UFUjKdMpsA);
		base.Controls.Add(BuLjaPa8Ml);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(62072);
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(62072);
		base.Load += tSTjfOlyop;
		((ISupportInitialize)BuLjaPa8Ml).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
