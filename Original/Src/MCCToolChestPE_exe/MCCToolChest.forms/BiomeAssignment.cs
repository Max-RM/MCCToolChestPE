using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.controls;
using MCCToolChest.model;
using MCCToolChest.Properties;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.forms;

public class BiomeAssignment : Form
{
	private List<BiomeChange> FQ7Rilnmkh;

	private BiomeReplace AmdRsCgbCf;

	private IContainer A2SRqACBf1;

	private TableLayoutPanel lvpRKA4FtK;

	private Panel ycmRhpEvGg;

	private Button hn4RmI6qDJ;

	private Button sAZRnTGYQ5;

	private ReplaceBiomeConfig AyrRlueAJ6;

	public List<BiomeChange> BiomeList
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return FQ7Rilnmkh;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BiomeAssignment(List<BiomeChange> biomeList)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		Wf2Rf2k7HR();
		AyrRlueAJ6.DisplayBiomeChangeList(biomeList);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void J6qRp974Ds(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		FQ7Rilnmkh = AyrRlueAJ6.BuildBiomeChangeList();
		base.DialogResult = DialogResult.OK;
		Close();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void dnbRZeaW5K(object P_0, EventArgs P_1)
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
		if (disposing && A2SRqACBf1 != null)
		{
			A2SRqACBf1.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Wf2Rf2k7HR()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		lvpRKA4FtK = new TableLayoutPanel();
		ycmRhpEvGg = new Panel();
		hn4RmI6qDJ = new Button();
		sAZRnTGYQ5 = new Button();
		AyrRlueAJ6 = new ReplaceBiomeConfig();
		lvpRKA4FtK.SuspendLayout();
		ycmRhpEvGg.SuspendLayout();
		SuspendLayout();
		lvpRKA4FtK.AutoSize = true;
		lvpRKA4FtK.ColumnCount = 1;
		lvpRKA4FtK.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		lvpRKA4FtK.Controls.Add(ycmRhpEvGg, 0, 1);
		lvpRKA4FtK.Controls.Add(AyrRlueAJ6, 0, 0);
		lvpRKA4FtK.Dock = DockStyle.Fill;
		lvpRKA4FtK.Location = new Point(0, 0);
		lvpRKA4FtK.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(36460);
		lvpRKA4FtK.RowCount = 2;
		lvpRKA4FtK.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		lvpRKA4FtK.RowStyles.Add(new RowStyle(SizeType.Absolute, 35f));
		lvpRKA4FtK.Size = new Size(400, 374);
		lvpRKA4FtK.TabIndex = 2;
		ycmRhpEvGg.Controls.Add(hn4RmI6qDJ);
		ycmRhpEvGg.Controls.Add(sAZRnTGYQ5);
		ycmRhpEvGg.Dock = DockStyle.Fill;
		ycmRhpEvGg.Location = new Point(0, 339);
		ycmRhpEvGg.Margin = new Padding(0);
		ycmRhpEvGg.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10398);
		ycmRhpEvGg.Size = new Size(400, 35);
		ycmRhpEvGg.TabIndex = 5;
		hn4RmI6qDJ.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		hn4RmI6qDJ.DialogResult = DialogResult.Cancel;
		hn4RmI6qDJ.Location = new Point(344, 7);
		hn4RmI6qDJ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34610);
		hn4RmI6qDJ.Size = new Size(50, 23);
		hn4RmI6qDJ.TabIndex = 1;
		hn4RmI6qDJ.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20198);
		hn4RmI6qDJ.UseVisualStyleBackColor = true;
		sAZRnTGYQ5.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		sAZRnTGYQ5.Location = new Point(288, 7);
		sAZRnTGYQ5.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34632);
		sAZRnTGYQ5.Size = new Size(50, 23);
		sAZRnTGYQ5.TabIndex = 0;
		sAZRnTGYQ5.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34646);
		sAZRnTGYQ5.UseVisualStyleBackColor = true;
		sAZRnTGYQ5.Click += J6qRp974Ds;
		AyrRlueAJ6.Dock = DockStyle.Fill;
		AyrRlueAJ6.Location = new Point(3, 3);
		AyrRlueAJ6.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(36498);
		AyrRlueAJ6.Size = new Size(394, 333);
		AyrRlueAJ6.TabIndex = 6;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = hn4RmI6qDJ;
		base.ClientSize = new Size(400, 374);
		base.Controls.Add(lvpRKA4FtK);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(36540);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(36574);
		base.Load += dnbRZeaW5K;
		lvpRKA4FtK.ResumeLayout(performLayout: false);
		ycmRhpEvGg.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
