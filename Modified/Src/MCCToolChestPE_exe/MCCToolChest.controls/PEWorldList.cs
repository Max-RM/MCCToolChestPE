using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using MCCToolChest.Events;
using MCCToolChest.Forms;
using MCCToolChest.model;
using MCCToolChest.utils;
using Save_Manager.controls;
using Save_Manager.model;
using Save_Manager.workers;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.Controls;

public class PEWorldList : UserControl
{
	private bool WyOhuLw42C;

	private EventHandler P0lhoSCvsb;

	private EventHandler Ap2hQvI0ls;

	private EventHandler IRuhOQOCt2;

	private IContainer A9thCHwjnd;

	private Button iPwh7LKFXp;

	private Button pG9hAbbie8;

	private Label XCChdtVBqh;

	private Button dNuhH5hhxJ;

	private FlowLayoutPanel W9UhFuTjSP;

	private ComboBox _savePathCombo;

	private Button _addCustomPathButton;

	private Button _removeCustomPathButton;

	private string _currentWorldsRoot;

	public event EventHandler WorldSelected
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = P0lhoSCvsb;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref P0lhoSCvsb, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		remove
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = P0lhoSCvsb;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref P0lhoSCvsb, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler CancelClick
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = Ap2hQvI0ls;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref Ap2hQvI0ls, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		remove
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = Ap2hQvI0ls;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref Ap2hQvI0ls, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler FolderClick
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = IRuhOQOCt2;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref IRuhOQOCt2, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		remove
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = IRuhOQOCt2;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref IRuhOQOCt2, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PEWorldList()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		WmIhJijZmf();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDisplayType(PCSelectDisplayType displayType)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		dNuhH5hhxJ.Visible = displayType == PCSelectDisplayType.Destination;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void LoadWorldList()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LoadPEWorldList();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void LoadPEWorldList()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (string.IsNullOrWhiteSpace(_currentWorldsRoot))
		{
			_currentWorldsRoot = Utils.GetGetMCPESaveFolder();
		}
		W9UhFuTjSP.Controls.Clear();
		PEFileWorker pEFileWorker = new PEFileWorker();
		List<PEWorldFolder> list = pEFileWorker.LoadFileList(_currentWorldsRoot);
		foreach (PEWorldFolder item in list)
		{
			PEWorldUI value = new PEWorldUI(lS3hE3XDSh, p8bhrKLDNF, item);
			W9UhFuTjSP.Controls.Add(value);
		}
	}

	public void InitializeSavePathSelector()
	{
		if (_savePathCombo == null)
		{
			return;
		}
		_savePathCombo.Items.Clear();
		foreach (PeWorldSavePathItem availablePath in PeWorldSavePathRegistry.GetAvailablePaths())
		{
			_savePathCombo.Items.Add(availablePath);
		}
		if (_savePathCombo.Items.Count > 0)
		{
			_savePathCombo.SelectedIndex = 0;
		}
	}

	private void ReloadSelectedSavePath()
	{
		if (_savePathCombo?.SelectedItem is PeWorldSavePathItem peWorldSavePathItem)
		{
			_currentWorldsRoot = peWorldSavePathItem.Path;
			LoadPEWorldList();
		}
	}

	private void SavePathComboSelectedIndexChanged(object sender, EventArgs e)
	{
		ReloadSelectedSavePath();
	}

	private void AddCustomPathClick(object sender, EventArgs e)
	{
		using FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
		{
			Description = "Select a custom Minecraft worlds folder"
		};
		if (folderBrowserDialog.ShowDialog(this) != DialogResult.OK)
		{
			return;
		}
		string text = PromptForText("Display name for this save location:", "Custom Save Path", "Custom Worlds");
		if (string.IsNullOrWhiteSpace(text))
		{
			text = "Custom Worlds";
		}
		PeWorldSavePathRegistry.AddCustomPath(text, folderBrowserDialog.SelectedPath);
		InitializeSavePathSelector();
		for (int i = 0; i < _savePathCombo.Items.Count; i++)
		{
			if (_savePathCombo.Items[i] is PeWorldSavePathItem peWorldSavePathItem && string.Equals(peWorldSavePathItem.Path, folderBrowserDialog.SelectedPath, StringComparison.OrdinalIgnoreCase))
			{
				_savePathCombo.SelectedIndex = i;
				break;
			}
		}
	}

	private void RemoveCustomPathClick(object sender, EventArgs e)
	{
		if (!(_savePathCombo?.SelectedItem is PeWorldSavePathItem peWorldSavePathItem) || !peWorldSavePathItem.IsCustom)
		{
			MessageBox.Show(this, "Select a custom save path to remove.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
			return;
		}
		if (MessageBox.Show(this, "Remove custom save path:\n" + peWorldSavePathItem.Label, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
		{
			return;
		}
		PeWorldSavePathRegistry.RemoveCustomPath(peWorldSavePathItem.Label);
		InitializeSavePathSelector();
	}

	private static string PromptForText(string prompt, string title, string defaultValue)
	{
		using Form form = new Form
		{
			Text = title,
			FormBorderStyle = FormBorderStyle.FixedDialog,
			StartPosition = FormStartPosition.CenterParent,
			ClientSize = new Size(360, 120),
			MaximizeBox = false,
			MinimizeBox = false
		};
		Label label = new Label
		{
			Text = prompt,
			Location = new Point(12, 12),
			AutoSize = true
		};
		TextBox textBox = new TextBox
		{
			Location = new Point(12, 36),
			Width = 330,
			Text = defaultValue
		};
		Button ok = new Button
		{
			Text = "OK",
			DialogResult = DialogResult.OK,
			Location = new Point(184, 72),
			Size = new Size(75, 28)
		};
		Button cancel = new Button
		{
			Text = "Cancel",
			DialogResult = DialogResult.Cancel,
			Location = new Point(267, 72),
			Size = new Size(75, 28)
		};
		form.Controls.Add(label);
		form.Controls.Add(textBox);
		form.Controls.Add(ok);
		form.Controls.Add(cancel);
		form.AcceptButton = ok;
		form.CancelButton = cancel;
		return form.ShowDialog() == DialogResult.OK ? textBox.Text : null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void LoadWPDWorldList()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		WPDPEFileWorker wPDPEFileWorker = new WPDPEFileWorker();
		List<PEWorldFolder> list = wPDPEFileWorker.LoadFileList();
		foreach (PEWorldFolder item in list)
		{
			PEWorldUI pEWorldUI = new PEWorldUI(lS3hE3XDSh, p8bhrKLDNF, item);
			pEWorldUI.SetIconVisibility(visible: true);
			W9UhFuTjSP.Controls.Add(pEWorldUI);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void lS3hE3XDSh(PEWorldUI P_0, PEWorldFolder P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		OnWorldSelected(this, new PEWorldEventArgs(P_1));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void p8bhrKLDNF(PEWorldUI P_0, PEWorldFolder P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		OnWorldSelected(this, new PEWorldEventArgs(P_1));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnWorldSelected(object sender, PEWorldEventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P0lhoSCvsb?.Invoke(this, e);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnCancelClicked(object sender, EventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Ap2hQvI0ls?.Invoke(this, e);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnFolderClicked(object sender, EventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		IRuhOQOCt2?.Invoke(this, e);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BM5h5bG3V2(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		OnFolderClicked(this, new EventArgs());
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void mbCh6SxBDI(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		OnCancelClicked(this, new EventArgs());
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UvwhNSuxUF(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		FolderNameEntry folderNameEntry = new FolderNameEntry();
		DialogResult dialogResult = folderNameEntry.ShowDialog(this);
		if (dialogResult == DialogResult.OK)
		{
			string root = string.IsNullOrWhiteSpace(_currentWorldsRoot) ? Utils.GetGetMCPESaveFolder() : _currentWorldsRoot;
			string path = root + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20100) + folderNameEntry.FolderName;
			PEWorldFolder pEWorldFolder = new PEWorldFolder();
			pEWorldFolder.Name = folderNameEntry.FolderName;
			pEWorldFolder.Path = path;
			OnWorldSelected(this, new PEWorldEventArgs(pEWorldFolder));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Iy2hDUYt6G(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		W9UhFuTjSP.Focus();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void T7yhcd5sTq()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		W9UhFuTjSP.Focus();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && A9thCHwjnd != null)
		{
			A9thCHwjnd.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void WmIhJijZmf()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		iPwh7LKFXp = new Button();
		pG9hAbbie8 = new Button();
		XCChdtVBqh = new Label();
		dNuhH5hhxJ = new Button();
		_savePathCombo = new ComboBox();
		_addCustomPathButton = new Button();
		_removeCustomPathButton = new Button();
		W9UhFuTjSP = new FlowLayoutPanel();
		SuspendLayout();
		iPwh7LKFXp.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		iPwh7LKFXp.Location = new Point(5, 417);
		iPwh7LKFXp.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20106);
		iPwh7LKFXp.Size = new Size(90, 23);
		iPwh7LKFXp.TabIndex = 1;
		iPwh7LKFXp.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20132);
		iPwh7LKFXp.UseVisualStyleBackColor = true;
		iPwh7LKFXp.Click += BM5h5bG3V2;
		pG9hAbbie8.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		pG9hAbbie8.Location = new Point(312, 417);
		pG9hAbbie8.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20162);
		pG9hAbbie8.Size = new Size(75, 23);
		pG9hAbbie8.TabIndex = 2;
		pG9hAbbie8.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20198);
		pG9hAbbie8.UseVisualStyleBackColor = true;
		pG9hAbbie8.Click += mbCh6SxBDI;
		XCChdtVBqh.AutoSize = true;
		XCChdtVBqh.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20214), 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		XCChdtVBqh.Location = new Point(5, 5);
		XCChdtVBqh.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		XCChdtVBqh.Size = new Size(126, 17);
		XCChdtVBqh.TabIndex = 3;
		XCChdtVBqh.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20260);
		XCChdtVBqh.TextAlign = ContentAlignment.MiddleCenter;
		dNuhH5hhxJ.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		dNuhH5hhxJ.Location = new Point(101, 417);
		dNuhH5hhxJ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20292);
		dNuhH5hhxJ.Size = new Size(90, 23);
		dNuhH5hhxJ.TabIndex = 4;
		dNuhH5hhxJ.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20320);
		dNuhH5hhxJ.UseVisualStyleBackColor = true;
		dNuhH5hhxJ.Click += UvwhNSuxUF;
		_savePathCombo.DropDownStyle = ComboBoxStyle.DropDownList;
		_savePathCombo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		_savePathCombo.Location = new Point(5, 28);
		_savePathCombo.Size = new Size(260, 21);
		_savePathCombo.SelectedIndexChanged += SavePathComboSelectedIndexChanged;
		_addCustomPathButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		_addCustomPathButton.Location = new Point(272, 27);
		_addCustomPathButton.Size = new Size(56, 23);
		_addCustomPathButton.Text = "Add";
		_addCustomPathButton.UseVisualStyleBackColor = true;
		_addCustomPathButton.Click += AddCustomPathClick;
		_removeCustomPathButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		_removeCustomPathButton.Location = new Point(331, 27);
		_removeCustomPathButton.Size = new Size(56, 23);
		_removeCustomPathButton.Text = "Remove";
		_removeCustomPathButton.UseVisualStyleBackColor = true;
		_removeCustomPathButton.Click += RemoveCustomPathClick;
		W9UhFuTjSP.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		W9UhFuTjSP.AutoScroll = true;
		W9UhFuTjSP.BackColor = Color.White;
		W9UhFuTjSP.BorderStyle = BorderStyle.FixedSingle;
		W9UhFuTjSP.Location = new Point(0, 56);
		W9UhFuTjSP.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20342);
		W9UhFuTjSP.Padding = new Padding(0, 3, 0, 0);
		W9UhFuTjSP.Size = new Size(392, 355);
		W9UhFuTjSP.TabIndex = 5;
		W9UhFuTjSP.MouseEnter += Iy2hDUYt6G;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.White;
		base.Controls.Add(_removeCustomPathButton);
		base.Controls.Add(_addCustomPathButton);
		base.Controls.Add(_savePathCombo);
		base.Controls.Add(W9UhFuTjSP);
		base.Controls.Add(dNuhH5hhxJ);
		base.Controls.Add(XCChdtVBqh);
		base.Controls.Add(pG9hAbbie8);
		base.Controls.Add(iPwh7LKFXp);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20372);
		base.Size = new Size(392, 444);
		ResumeLayout(performLayout: false);
		PerformLayout();
		InitializeSavePathSelector();
	}
}
