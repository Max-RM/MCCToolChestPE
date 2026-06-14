using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.model;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls;

public class BiomeReplace : UserControl
{
	private BiomeChange quab24UFdo;

	private IContainer CjKbyuucx0;

	private ComboBox kdPb0YSIZw;

	private ComboBox SRNbBCMFZB;

	private TableLayoutPanel aYybtFxP4O;

	private Label VQ6baA3Pny;

	private Label TpGbXftnya;

	public BiomeChange BiomeChange
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			if (kdPb0YSIZw.SelectedValue is Biome biome)
			{
				quab24UFdo.FromBiome = biome.BedrockId;
			}
			if (SRNbBCMFZB.SelectedValue is Biome biome2)
			{
				quab24UFdo.ToBiome = biome2.BedrockId;
			}
			return quab24UFdo;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			quab24UFdo = value;
			kdPb0YSIZw.SelectedValue = quab24UFdo.FromBiome;
			SRNbBCMFZB.SelectedValue = quab24UFdo.ToBiome;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BiomeReplace()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		IsBbld7bMR();
		LjtbnCm5Rb();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LjtbnCm5Rb()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		kdPb0YSIZw.ValueMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10770);
		kdPb0YSIZw.DisplayMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10196);
		kdPb0YSIZw.DataSource = BiomeLookup.list.Values.ToList();
		SRNbBCMFZB.ValueMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10770);
		SRNbBCMFZB.DisplayMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10196);
		SRNbBCMFZB.DataSource = BiomeLookup.bedrockId.Values.ToList();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && CjKbyuucx0 != null)
		{
			CjKbyuucx0.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void IsBbld7bMR()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		kdPb0YSIZw = new ComboBox();
		SRNbBCMFZB = new ComboBox();
		aYybtFxP4O = new TableLayoutPanel();
		VQ6baA3Pny = new Label();
		TpGbXftnya = new Label();
		aYybtFxP4O.SuspendLayout();
		SuspendLayout();
		kdPb0YSIZw.Dock = DockStyle.Fill;
		kdPb0YSIZw.DropDownStyle = ComboBoxStyle.DropDownList;
		kdPb0YSIZw.FormattingEnabled = true;
		kdPb0YSIZw.Location = new Point(3, 15);
		kdPb0YSIZw.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10778);
		kdPb0YSIZw.Size = new Size(74, 21);
		kdPb0YSIZw.TabIndex = 1;
		SRNbBCMFZB.Dock = DockStyle.Fill;
		SRNbBCMFZB.DropDownStyle = ComboBoxStyle.DropDownList;
		SRNbBCMFZB.FormattingEnabled = true;
		SRNbBCMFZB.Location = new Point(83, 15);
		SRNbBCMFZB.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10804);
		SRNbBCMFZB.Size = new Size(75, 21);
		SRNbBCMFZB.TabIndex = 3;
		aYybtFxP4O.ColumnCount = 2;
		aYybtFxP4O.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		aYybtFxP4O.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		aYybtFxP4O.Controls.Add(SRNbBCMFZB, 1, 1);
		aYybtFxP4O.Controls.Add(kdPb0YSIZw, 0, 1);
		aYybtFxP4O.Controls.Add(VQ6baA3Pny, 0, 0);
		aYybtFxP4O.Controls.Add(TpGbXftnya, 1, 0);
		aYybtFxP4O.Dock = DockStyle.Fill;
		aYybtFxP4O.Location = new Point(0, 0);
		aYybtFxP4O.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10826);
		aYybtFxP4O.RowCount = 2;
		aYybtFxP4O.RowStyles.Add(new RowStyle(SizeType.Absolute, 12f));
		aYybtFxP4O.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		aYybtFxP4O.Size = new Size(161, 41);
		aYybtFxP4O.TabIndex = 2;
		VQ6baA3Pny.AutoSize = true;
		VQ6baA3Pny.Dock = DockStyle.Fill;
		VQ6baA3Pny.Location = new Point(3, 0);
		VQ6baA3Pny.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		VQ6baA3Pny.Size = new Size(74, 12);
		VQ6baA3Pny.TabIndex = 0;
		VQ6baA3Pny.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10864);
		TpGbXftnya.AutoSize = true;
		TpGbXftnya.Dock = DockStyle.Fill;
		TpGbXftnya.Location = new Point(83, 0);
		TpGbXftnya.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10582);
		TpGbXftnya.Size = new Size(75, 12);
		TpGbXftnya.TabIndex = 2;
		TpGbXftnya.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10888);
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(aYybtFxP4O);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10908);
		base.Size = new Size(161, 41);
		aYybtFxP4O.ResumeLayout(performLayout: false);
		aYybtFxP4O.PerformLayout();
		ResumeLayout(performLayout: false);
	}
}
