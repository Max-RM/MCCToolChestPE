using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Save_Manager.events;
using Save_Manager.model;
using Save_Manager.workers;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace Save_Manager.controls;

public class PEWorldListUI : UserControl
{
	private EventHandler mALSXL1xFyq;

	private EventHandler zhHSXgBOftX;

	private PEFileWorker vIrSXPA5k3F;

	private IContainer C5VSXRfQR7X;

	private FlowLayoutPanel d2ySXkfWOwO;

	public event EventHandler SaveSelected
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = mALSXL1xFyq;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref mALSXL1xFyq, value2, eventHandler2);
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
			EventHandler eventHandler = mALSXL1xFyq;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref mALSXL1xFyq, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler SaveOpen
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = zhHSXgBOftX;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref zhHSXgBOftX, value2, eventHandler2);
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
			EventHandler eventHandler = zhHSXgBOftX;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref zhHSXgBOftX, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PEWorldListUI()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		vIrSXPA5k3F = new PEFileWorker();
		opkSXUATBf4();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OSeSXtDnFiW()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		h8dSXagr4IX();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void h8dSXagr4IX()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<PEWorldFolder> list = vIrSXPA5k3F.LoadFileList();
		foreach (PEWorldFolder item in list)
		{
			PEWorldUI value = new PEWorldUI(tAaSXxNxniK, ImYSXXFu0UP, item);
			d2ySXkfWOwO.Controls.Add(value);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ImYSXXFu0UP(PEWorldUI P_0, PEWorldFolder P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		N4GSXM4BL7p(P_0, P_1);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void tAaSXxNxniK(PEWorldUI P_0, PEWorldFolder P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		foreach (object control in d2ySXkfWOwO.Controls)
		{
			PEWorldUI pEWorldUI = control as PEWorldUI;
			pEWorldUI.WorldActive = false;
		}
		P_0.WorldActive = true;
		WAsSXe0bF2Y(P_0, P_1);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void WAsSXe0bF2Y(PEWorldUI P_0, PEWorldFolder P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (mALSXL1xFyq != null)
		{
			SaveSelectedEventArgs e = new SaveSelectedEventArgs();
			e.Name = P_1.Name;
			e.Path = P_1.Path;
			mALSXL1xFyq(this, e);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void N4GSXM4BL7p(PEWorldUI P_0, PEWorldFolder P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (mALSXL1xFyq != null)
		{
			SaveSelectedEventArgs e = new SaveSelectedEventArgs();
			e.Name = P_1.Name;
			e.Path = P_1.Path;
			zhHSXgBOftX(this, e);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RedoSelect()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		foreach (object control in d2ySXkfWOwO.Controls)
		{
			PEWorldUI pEWorldUI = control as PEWorldUI;
			if (pEWorldUI.WorldActive)
			{
				WAsSXe0bF2Y(pEWorldUI, pEWorldUI.SaveDef);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && C5VSXRfQR7X != null)
		{
			C5VSXRfQR7X.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void opkSXUATBf4()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		d2ySXkfWOwO = new FlowLayoutPanel();
		SuspendLayout();
		d2ySXkfWOwO.AutoScroll = true;
		d2ySXkfWOwO.BackColor = Color.White;
		d2ySXkfWOwO.BorderStyle = BorderStyle.FixedSingle;
		d2ySXkfWOwO.Dock = DockStyle.Fill;
		d2ySXkfWOwO.Location = new Point(0, 0);
		d2ySXkfWOwO.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20342);
		d2ySXkfWOwO.Padding = new Padding(0, 3, 0, 0);
		d2ySXkfWOwO.Size = new Size(260, 371);
		d2ySXkfWOwO.TabIndex = 3;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(d2ySXkfWOwO);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(208500);
		base.Size = new Size(260, 371);
		ResumeLayout(performLayout: false);
	}
}
