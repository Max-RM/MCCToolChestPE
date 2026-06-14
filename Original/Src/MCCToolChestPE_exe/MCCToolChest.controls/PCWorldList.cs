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

public class PCWorldList : UserControl
{
	private bool Oy6BkjXQG5;

	private EventHandler qbyBY85uFg;

	private EventHandler URLB3vAxNV;

	private EventHandler LcOB1mxTle;

	private IContainer zSeBEmM3cu;

	private Button C1kBrPxC1E;

	private Button le8B5RZVQo;

	private Label OiTB6XTSq2;

	private Button QEvBNwSQJH;

	private FlowLayoutPanel ylaBDdwMAm;

	public event EventHandler WorldSelected
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = qbyBY85uFg;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref qbyBY85uFg, value2, eventHandler2);
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
			EventHandler eventHandler = qbyBY85uFg;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref qbyBY85uFg, value2, eventHandler2);
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
			EventHandler eventHandler = URLB3vAxNV;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref URLB3vAxNV, value2, eventHandler2);
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
			EventHandler eventHandler = URLB3vAxNV;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref URLB3vAxNV, value2, eventHandler2);
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
			EventHandler eventHandler = LcOB1mxTle;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref LcOB1mxTle, value2, eventHandler2);
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
			EventHandler eventHandler = LcOB1mxTle;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref LcOB1mxTle, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PCWorldList()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		y1BBR4gkfx();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDisplayType(PCSelectDisplayType displayType)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		QEvBNwSQJH.Visible = displayType == PCSelectDisplayType.Destination;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void LoadWorldList()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PCFileWorker pCFileWorker = new PCFileWorker();
		List<PCWorldFolder> list = pCFileWorker.LoadFileList();
		foreach (PCWorldFolder item in list)
		{
			PCWorldUI value = new PCWorldUI(TpRBxhhOBB, BCsBesfgmZ, item);
			ylaBDdwMAm.Controls.Add(value);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TpRBxhhOBB(PCWorldUI P_0, PCWorldFolder P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		OnWorldSelected(this, new PCWorldEventArgs(P_1.Name, P_1.Path));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BCsBesfgmZ(PCWorldUI P_0, PCWorldFolder P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		OnWorldSelected(this, new PCWorldEventArgs(P_1.Name, P_1.Path));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnWorldSelected(object sender, PCWorldEventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		qbyBY85uFg?.Invoke(this, e);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnCancelClicked(object sender, EventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		URLB3vAxNV?.Invoke(this, e);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnFolderClicked(object sender, EventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LcOB1mxTle?.Invoke(this, e);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void o8wBM1x4I3(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		OnFolderClicked(this, new EventArgs());
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void w6nBUBgsFO(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		OnCancelClicked(this, new EventArgs());
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void KUHBLyjv5P(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		FolderNameEntry folderNameEntry = new FolderNameEntry();
		DialogResult dialogResult = folderNameEntry.ShowDialog(this);
		if (dialogResult == DialogResult.OK)
		{
			string folder = Utils.GetGetMCPCSaveFolder() + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20100) + folderNameEntry.FolderName;
			OnWorldSelected(this, new PCWorldEventArgs(folderNameEntry.FolderName, folder));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void JNSBgx04FZ(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ylaBDdwMAm.Focus();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void VDwBPs3Djm()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ylaBDdwMAm.Focus();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && zSeBEmM3cu != null)
		{
			zSeBEmM3cu.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void y1BBR4gkfx()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		C1kBrPxC1E = new Button();
		le8B5RZVQo = new Button();
		OiTB6XTSq2 = new Label();
		QEvBNwSQJH = new Button();
		ylaBDdwMAm = new FlowLayoutPanel();
		SuspendLayout();
		C1kBrPxC1E.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		C1kBrPxC1E.Location = new Point(5, 417);
		C1kBrPxC1E.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20106);
		C1kBrPxC1E.Size = new Size(90, 23);
		C1kBrPxC1E.TabIndex = 1;
		C1kBrPxC1E.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20132);
		C1kBrPxC1E.UseVisualStyleBackColor = true;
		C1kBrPxC1E.Click += o8wBM1x4I3;
		le8B5RZVQo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		le8B5RZVQo.Location = new Point(312, 417);
		le8B5RZVQo.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20162);
		le8B5RZVQo.Size = new Size(75, 23);
		le8B5RZVQo.TabIndex = 2;
		le8B5RZVQo.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20198);
		le8B5RZVQo.UseVisualStyleBackColor = true;
		le8B5RZVQo.Click += w6nBUBgsFO;
		OiTB6XTSq2.AutoSize = true;
		OiTB6XTSq2.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20214), 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		OiTB6XTSq2.Location = new Point(5, 5);
		OiTB6XTSq2.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		OiTB6XTSq2.Size = new Size(98, 17);
		OiTB6XTSq2.TabIndex = 3;
		OiTB6XTSq2.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23650);
		OiTB6XTSq2.TextAlign = ContentAlignment.MiddleCenter;
		QEvBNwSQJH.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		QEvBNwSQJH.Location = new Point(101, 417);
		QEvBNwSQJH.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20292);
		QEvBNwSQJH.Size = new Size(90, 23);
		QEvBNwSQJH.TabIndex = 4;
		QEvBNwSQJH.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20320);
		QEvBNwSQJH.UseVisualStyleBackColor = true;
		QEvBNwSQJH.Click += KUHBLyjv5P;
		ylaBDdwMAm.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		ylaBDdwMAm.AutoScroll = true;
		ylaBDdwMAm.BackColor = Color.White;
		ylaBDdwMAm.BorderStyle = BorderStyle.FixedSingle;
		ylaBDdwMAm.Location = new Point(0, 29);
		ylaBDdwMAm.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20342);
		ylaBDdwMAm.Padding = new Padding(0, 3, 0, 0);
		ylaBDdwMAm.Size = new Size(392, 386);
		ylaBDdwMAm.TabIndex = 6;
		ylaBDdwMAm.MouseEnter += JNSBgx04FZ;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.White;
		base.Controls.Add(ylaBDdwMAm);
		base.Controls.Add(QEvBNwSQJH);
		base.Controls.Add(OiTB6XTSq2);
		base.Controls.Add(le8B5RZVQo);
		base.Controls.Add(C1kBrPxC1E);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23676);
		base.Size = new Size(392, 444);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
