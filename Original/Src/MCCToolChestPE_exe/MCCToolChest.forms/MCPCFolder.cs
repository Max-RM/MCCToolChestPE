using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using JBZdo5brfGmVglXr4j;
using MCCToolChest.Controls;
using MCCToolChest.Events;
using MCCToolChest.model;
using MCCToolChest.Properties;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.Forms;

public class MCPCFolder : Form
{
	private string IU1j4bH9ZA;

	private mOOVKLKZLSottJeQ5a WScjVsAUfv;

	private IContainer oVJjWpuXPT;

	private PCWorldList I6RjpHr6th;

	public string PCWorldFolder
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return IU1j4bH9ZA;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			IU1j4bH9ZA = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MCPCFolder(PCSelectDisplayType displayType)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		IU1j4bH9ZA = "";
		NkWjGstUtn();
		I6RjpHr6th.SetDisplayType(displayType);
		I6RjpHr6th.LoadWorldList();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	internal mOOVKLKZLSottJeQ5a p6rjbal2h5()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return WScjVsAUfv;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	internal void sLijv5XIy3(mOOVKLKZLSottJeQ5a value)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		WScjVsAUfv = value;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Sy7F9xs0LT(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PCWorldFolder = (P_1 as PCWorldEventArgs).Folder;
		WScjVsAUfv = (mOOVKLKZLSottJeQ5a)0;
		base.DialogResult = DialogResult.OK;
		Close();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LAJFIHkj5W(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void nrvFze4jMa(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		WScjVsAUfv = (mOOVKLKZLSottJeQ5a)1;
		base.DialogResult = DialogResult.OK;
		Close();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void R1UjT0DAGf(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.Icon = Resources.usMSrbJo37S();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void cKnjSVnpw7(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		I6RjpHr6th.VDwBPs3Djm();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && oVJjWpuXPT != null)
		{
			oVJjWpuXPT.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void NkWjGstUtn()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		I6RjpHr6th = new PCWorldList();
		SuspendLayout();
		I6RjpHr6th.BackColor = Color.Transparent;
		I6RjpHr6th.Dock = DockStyle.Fill;
		I6RjpHr6th.Location = new Point(0, 0);
		I6RjpHr6th.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23676);
		I6RjpHr6th.Size = new Size(474, 443);
		I6RjpHr6th.TabIndex = 14;
		I6RjpHr6th.WorldSelected += Sy7F9xs0LT;
		I6RjpHr6th.CancelClick += LAJFIHkj5W;
		I6RjpHr6th.FolderClick += nrvFze4jMa;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(474, 443);
		base.Controls.Add(I6RjpHr6th);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(61372);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55324);
		base.Load += R1UjT0DAGf;
		base.Shown += cKnjSVnpw7;
		ResumeLayout(performLayout: false);
	}
}
