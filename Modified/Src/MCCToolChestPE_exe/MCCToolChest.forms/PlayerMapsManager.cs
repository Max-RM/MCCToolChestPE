using System;
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

public class PlayerMapsManager : Form
{
	private TreeView HUGQbKdqOp;

	private IContainer LyGQvF7Ua9;

	private MapManagerUI CdTQw1ygxG;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PlayerMapsManager(TreeView treeView)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		hwVQGqp6Z8();
		HUGQbKdqOp = treeView;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void NHxQTppIod(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.Icon = Resources.usMSrbJo37S();
		CdTQw1ygxG.LoadMaps();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ce7QSDaj5F(object P_0, FormClosedEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string folderPath = Working.T92StMGt1p4();
		PEFileTree pEFileTree = new PEFileTree();
		foreach (MCMap value in CdTQw1ygxG.MapList.Values)
		{
			if (value.MapStatus == MapStatusType.New)
			{
				IndexEntry indexEntry = new IndexEntry();
				indexEntry.FileName = value.Name;
				indexEntry.FilePath = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55192) + value.Name + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22554);
				indexEntry.ParentName = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55206);
				pEFileTree.DisplayFileItem(indexEntry, folderPath, HUGQbKdqOp);
			}
		}
		CdTQw1ygxG.SaveMaps();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && LyGQvF7Ua9 != null)
		{
			LyGQvF7Ua9.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hwVQGqp6Z8()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		CdTQw1ygxG = new MapManagerUI();
		SuspendLayout();
		CdTQw1ygxG.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		CdTQw1ygxG.Location = new Point(3, 2);
		CdTQw1ygxG.MapsChanged = false;
		CdTQw1ygxG.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55218);
		CdTQw1ygxG.Size = new Size(930, 656);
		CdTQw1ygxG.TabIndex = 0;
		CdTQw1ygxG.Load += NHxQTppIod;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(932, 658);
		base.Controls.Add(CdTQw1ygxG);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55248);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55274);
		base.FormClosed += ce7QSDaj5F;
		ResumeLayout(performLayout: false);
	}
}
