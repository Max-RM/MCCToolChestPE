using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using KZR2jb4Jm3EKXx6h58;
using MCCToolChest.Controls;
using MCCToolChest.Events;
using MCCToolChest.model;
using MCCToolChest.Properties;
using Save_Manager.model;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.Forms;

public class MCPEFolder : Form
{
	private PEWorldFolder HK2QKgFCMW;

	private BUCE1Z1t57tWTV5OPi rQJQhegNsu;

	private IContainer K4JQm2Wff1;

	private PEWorldList Y2NQnTjrgJ;

	public PEWorldFolder PEWorldFolder
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return HK2QKgFCMW;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			HK2QKgFCMW = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MCPEFolder(PCSelectDisplayType displayType)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		vmLQf2ZQM1();
		Y2NQnTjrgJ.SetDisplayType(displayType);
		Y2NQnTjrgJ.LoadWorldList();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	internal BUCE1Z1t57tWTV5OPi q5UQiauCd2()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return rQJQhegNsu;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	internal void NRHQs39oQ8(BUCE1Z1t57tWTV5OPi value)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		rQJQhegNsu = value;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PmnQ4aEuu3(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PEWorldFolder = (P_1 as PEWorldEventArgs).Folder;
		rQJQhegNsu = (BUCE1Z1t57tWTV5OPi)0;
		base.DialogResult = DialogResult.OK;
		Close();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void l7TQVdpN4x(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void C9YQWmkxLp(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		rQJQhegNsu = (BUCE1Z1t57tWTV5OPi)1;
		base.DialogResult = DialogResult.OK;
		Close();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void qycQprbTht(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.Icon = Resources.usMSrbJo37S();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void mS2QZZ3Bb5(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Y2NQnTjrgJ.T7yhcd5sTq();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && K4JQm2Wff1 != null)
		{
			K4JQm2Wff1.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void vmLQf2ZQM1()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Y2NQnTjrgJ = new PEWorldList();
		SuspendLayout();
		Y2NQnTjrgJ.BackColor = Color.Transparent;
		Y2NQnTjrgJ.Dock = DockStyle.Fill;
		Y2NQnTjrgJ.Location = new Point(0, 0);
		Y2NQnTjrgJ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20372);
		Y2NQnTjrgJ.Size = new Size(474, 443);
		Y2NQnTjrgJ.TabIndex = 14;
		Y2NQnTjrgJ.WorldSelected += PmnQ4aEuu3;
		Y2NQnTjrgJ.CancelClick += l7TQVdpN4x;
		Y2NQnTjrgJ.FolderClick += C9YQWmkxLp;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(474, 443);
		base.Controls.Add(Y2NQnTjrgJ);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55300);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55324);
		base.Load += qycQprbTht;
		base.Shown += mS2QZZ3Bb5;
		ResumeLayout(performLayout: false);
	}
}
