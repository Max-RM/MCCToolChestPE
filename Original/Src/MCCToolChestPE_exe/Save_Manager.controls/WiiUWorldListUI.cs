using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using MCCToolChest.Properties;
using Save_Manager.events;
using Save_Manager.model;
using Save_Manager.workers;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace Save_Manager.controls;

public class WiiUWorldListUI : UserControl
{
	private WiiUFileWorker UdLSxn9N1OP;

	private EventHandler v2nSxlWR9ua;

	private EventHandler dvTSx2G3rjF;

	private IContainer hHmSxyeYFKn;

	private FlowLayoutPanel mwBSx04ruf9;

	public event EventHandler SaveSelected
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = v2nSxlWR9ua;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref v2nSxlWR9ua, value2, eventHandler2);
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
			EventHandler eventHandler = v2nSxlWR9ua;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref v2nSxlWR9ua, value2, eventHandler2);
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
			EventHandler eventHandler = dvTSx2G3rjF;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref dvTSx2G3rjF, value2, eventHandler2);
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
			EventHandler eventHandler = dvTSx2G3rjF;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref dvTSx2G3rjF, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WiiUWorldListUI()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		UdLSxn9N1OP = new WiiUFileWorker();
		gUqSxmJec8y();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void Y42SxZlZMow()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		RXPSxfBbCHU();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RXPSxfBbCHU()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = Settings.Default.MCPESaveFolder;
		if (!text.EndsWith(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20100)))
		{
			text += Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20100);
		}
		if (!Directory.Exists(text))
		{
			return;
		}
		List<WiiUGameFile> list = UdLSxn9N1OP.LoadFileList(text, text);
		foreach (WiiUGameFile item in list)
		{
			WiiUWorldUI value = new WiiUWorldUI(j2FSxsdRqQM, tfsSxijs8WE, item);
			mwBSx04ruf9.Controls.Add(value);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void tfsSxijs8WE(WiiUWorldUI P_0, WiiUGameFile P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		HXtSxKng3dj(P_0, P_1);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void j2FSxsdRqQM(WiiUWorldUI P_0, WiiUGameFile P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		foreach (object control in mwBSx04ruf9.Controls)
		{
			WiiUWorldUI wiiUWorldUI = control as WiiUWorldUI;
			wiiUWorldUI.WorldActive = false;
		}
		P_0.WorldActive = true;
		FWuSxqZDPHZ(P_0, P_1);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FWuSxqZDPHZ(WiiUWorldUI P_0, WiiUGameFile P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (v2nSxlWR9ua != null)
		{
			SaveSelectedEventArgs e = new SaveSelectedEventArgs();
			e.Name = P_1.Name;
			e.Path = P_1.Path;
			v2nSxlWR9ua(this, e);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HXtSxKng3dj(WiiUWorldUI P_0, WiiUGameFile P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (v2nSxlWR9ua != null)
		{
			SaveSelectedEventArgs e = new SaveSelectedEventArgs();
			e.Name = P_1.Name;
			e.Path = P_1.Path;
			dvTSx2G3rjF(this, e);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void b9MSxhPfxf2()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		foreach (object control in mwBSx04ruf9.Controls)
		{
			WiiUWorldUI wiiUWorldUI = control as WiiUWorldUI;
			if (wiiUWorldUI.WorldActive)
			{
				FWuSxqZDPHZ(wiiUWorldUI, wiiUWorldUI.SaveDef);
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
		if (disposing && hHmSxyeYFKn != null)
		{
			hHmSxyeYFKn.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void gUqSxmJec8y()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		mwBSx04ruf9 = new FlowLayoutPanel();
		SuspendLayout();
		mwBSx04ruf9.AutoScroll = true;
		mwBSx04ruf9.BackColor = Color.White;
		mwBSx04ruf9.BorderStyle = BorderStyle.FixedSingle;
		mwBSx04ruf9.Dock = DockStyle.Fill;
		mwBSx04ruf9.Location = new Point(0, 0);
		mwBSx04ruf9.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20342);
		mwBSx04ruf9.Padding = new Padding(0, 3, 0, 0);
		mwBSx04ruf9.Size = new Size(260, 371);
		mwBSx04ruf9.TabIndex = 3;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(mwBSx04ruf9);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(208654);
		base.Size = new Size(260, 371);
		ResumeLayout(performLayout: false);
	}
}
