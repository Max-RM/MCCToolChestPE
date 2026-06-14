using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.Properties;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.forms;

public class FlatWorldPresets : Form
{
	private string R4fN6Mpt8m;

	private string[] TSSNNfcNOD;

	private IContainer fRCND7rDeq;

	private Button OAmNcviHog;

	private Button hIuNJDwRI7;

	private ListBox yn6NuLsrhX;

	public string FlatWorldLayers
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return R4fN6Mpt8m;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			R4fN6Mpt8m = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public FlatWorldPresets()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		R4fN6Mpt8m = "";
		TSSNNfcNOD = new string[9]
		{
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(46150),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(46178),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(46214),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28692),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(46240),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(46270),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(46302),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(46318),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(46350)
		};
		xvPN5AXbLk();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DPxNkGFDUG(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.Icon = Resources.usMSrbJo37S();
		yn6NuLsrhX.Items.AddRange(TSSNNfcNOD);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YsBNYmKt7I(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string itemText = yn6NuLsrhX.GetItemText(yn6NuLsrhX.SelectedItem);
		if (!string.IsNullOrWhiteSpace(itemText))
		{
			KGDN3XrFIG(itemText);
			base.DialogResult = DialogResult.OK;
			Close();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void KGDN3XrFIG(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string key;
		if ((key = P_0) == null)
		{
			return;
		}
		if (CompilerSwitchMaps.FlatWorldPresetMap == null)
		{
			CompilerSwitchMaps.FlatWorldPresetMap = new Dictionary<string, int>(9)
			{
				{
					Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(46150),
					0
				},
				{
					Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(46178),
					1
				},
				{
					Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(46214),
					2
				},
				{
					Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28692),
					3
				},
				{
					Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(46240),
					4
				},
				{
					Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(46270),
					5
				},
				{
					Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(46302),
					6
				},
				{
					Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(46318),
					7
				},
				{
					Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(46350),
					8
				}
			};
		}
		if (CompilerSwitchMaps.FlatWorldPresetMap.TryGetValue(key, out var value))
		{
			switch (value)
			{
			case 0:
				R4fN6Mpt8m = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(46370);
				break;
			case 1:
				R4fN6Mpt8m = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(46960);
				break;
			case 2:
				R4fN6Mpt8m = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(47686);
				break;
			case 3:
				R4fN6Mpt8m = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(48544);
				break;
			case 4:
				R4fN6Mpt8m = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(49268);
				break;
			case 5:
				R4fN6Mpt8m = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(49994);
				break;
			case 6:
				R4fN6Mpt8m = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(50590);
				break;
			case 7:
				R4fN6Mpt8m = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(51322);
				break;
			case 8:
				R4fN6Mpt8m = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(51922);
				break;
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YOuN16NA6C(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		YsBNYmKt7I(P_0, P_1);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Fm2NEcyCqj(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void qRUNrLQUWI(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && fRCND7rDeq != null)
		{
			fRCND7rDeq.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void xvPN5AXbLk()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		OAmNcviHog = new Button();
		hIuNJDwRI7 = new Button();
		yn6NuLsrhX = new ListBox();
		SuspendLayout();
		OAmNcviHog.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		OAmNcviHog.DialogResult = DialogResult.Cancel;
		OAmNcviHog.Location = new Point(155, 348);
		OAmNcviHog.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34610);
		OAmNcviHog.Size = new Size(50, 23);
		OAmNcviHog.TabIndex = 8;
		OAmNcviHog.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20198);
		OAmNcviHog.UseVisualStyleBackColor = true;
		OAmNcviHog.Click += Fm2NEcyCqj;
		hIuNJDwRI7.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		hIuNJDwRI7.Location = new Point(96, 348);
		hIuNJDwRI7.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34632);
		hIuNJDwRI7.Size = new Size(50, 23);
		hIuNJDwRI7.TabIndex = 7;
		hIuNJDwRI7.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34646);
		hIuNJDwRI7.UseVisualStyleBackColor = true;
		hIuNJDwRI7.Click += YsBNYmKt7I;
		yn6NuLsrhX.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
		yn6NuLsrhX.FormattingEnabled = true;
		yn6NuLsrhX.ItemHeight = 16;
		yn6NuLsrhX.Location = new Point(13, 13);
		yn6NuLsrhX.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(52240);
		yn6NuLsrhX.Size = new Size(192, 324);
		yn6NuLsrhX.TabIndex = 9;
		yn6NuLsrhX.SelectedIndexChanged += qRUNrLQUWI;
		yn6NuLsrhX.DoubleClick += YOuN16NA6C;
		base.AcceptButton = hIuNJDwRI7;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = OAmNcviHog;
		base.ClientSize = new Size(217, 380);
		base.Controls.Add(yn6NuLsrhX);
		base.Controls.Add(OAmNcviHog);
		base.Controls.Add(hIuNJDwRI7);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(52260);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(52296);
		base.Load += DPxNkGFDUG;
		ResumeLayout(performLayout: false);
	}
}
