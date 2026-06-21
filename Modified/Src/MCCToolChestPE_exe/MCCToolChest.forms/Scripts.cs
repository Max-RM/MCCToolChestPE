using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.controls;
using MCCToolChest.Properties;
using MCCToolChest.scripting;
using MCCToolChest.utils;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.forms;

public class Scripts : Form
{
	private IContainer FkH8f3WgyC;

	private ListViewEx va38iigUCN;

	private ColumnHeader pHN8sex75R;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Scripts()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		ADU8ZrN7WF();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void xgB8VnyukA(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.Icon = Resources.usMSrbJo37S();
		drX8WVvKgh();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void drX8WVvKgh()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		DirectoryInfo directoryInfo = new DirectoryInfo(Utils.ScriptPath());
		FileInfo[] files = directoryInfo.GetFiles(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(62284));
		va38iigUCN.Items.Clear();
		FileInfo[] array = files;
		foreach (FileInfo fileInfo in array)
		{
			ListViewItem listViewItem = new ListViewItem(fileInfo.Name);
			listViewItem.Tag = fileInfo;
			va38iigUCN.Items.Add(listViewItem);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void idI8pkqvR2(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (va38iigUCN.SelectedItems.Count > 0)
		{
			_ = va38iigUCN.SelectedItems[0].Tag;
			CodeEditor codeEditor = new CodeEditor();
			codeEditor.ShowDialog(this);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && FkH8f3WgyC != null)
		{
			FkH8f3WgyC.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ADU8ZrN7WF()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		va38iigUCN = new ListViewEx();
		pHN8sex75R = new ColumnHeader();
		SuspendLayout();
		va38iigUCN.Columns.AddRange(new ColumnHeader[1] { pHN8sex75R });
		va38iigUCN.LineAfter = -1;
		va38iigUCN.LineBefore = -1;
		va38iigUCN.Location = new Point(13, 13);
		va38iigUCN.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(62296);
		va38iigUCN.Size = new Size(571, 492);
		va38iigUCN.TabIndex = 0;
		va38iigUCN.UseCompatibleStateImageBehavior = false;
		va38iigUCN.View = View.Details;
		va38iigUCN.SelectedIndexChanged += idI8pkqvR2;
		pHN8sex75R.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(62318);
		pHN8sex75R.Width = 500;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(596, 517);
		base.Controls.Add(va38iigUCN);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(62344);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(62344);
		base.Load += xgB8VnyukA;
		ResumeLayout(performLayout: false);
	}
}
