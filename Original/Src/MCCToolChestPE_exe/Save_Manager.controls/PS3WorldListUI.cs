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

public class PS3WorldListUI : UserControl
{
	private EventHandler W21SXNlUGRR;

	private EventHandler bUwSXDRDmXS;

	private PS3FileWorker zHMSXcuqJw0;

	private IContainer poTSXJvXdoF;

	private FlowLayoutPanel CFBSXu89O7R;

	public event EventHandler SaveSelected
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = W21SXNlUGRR;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref W21SXNlUGRR, value2, eventHandler2);
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
			EventHandler eventHandler = W21SXNlUGRR;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref W21SXNlUGRR, value2, eventHandler2);
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
			EventHandler eventHandler = bUwSXDRDmXS;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref bUwSXDRDmXS, value2, eventHandler2);
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
			EventHandler eventHandler = bUwSXDRDmXS;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref bUwSXDRDmXS, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PS3WorldListUI()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		zHMSXcuqJw0 = new PS3FileWorker();
		lifSX69S9h7();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void NXfSXYehN9Z()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		x1ISX3OrV5l();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void x1ISX3OrV5l()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<PS3GameFile> list = zHMSXcuqJw0.LoadFileList();
		foreach (PS3GameFile item in list)
		{
			PS3WorldUI value = new PS3WorldUI(s0KSXECvAnt, JPYSX1KfAWJ, item);
			CFBSXu89O7R.Controls.Add(value);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void JPYSX1KfAWJ(PS3WorldUI P_0, PS3GameFile P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		t87SX5r8ucL(P_0, P_1);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void s0KSXECvAnt(PS3WorldUI P_0, PS3GameFile P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		foreach (object control in CFBSXu89O7R.Controls)
		{
			PS3WorldUI pS3WorldUI = control as PS3WorldUI;
			pS3WorldUI.WorldActive = false;
		}
		P_0.WorldActive = true;
		U0mSXrdoWq7(P_0, P_1);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void U0mSXrdoWq7(PS3WorldUI P_0, PS3GameFile P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (W21SXNlUGRR != null)
		{
			SaveSelectedEventArgs e = new SaveSelectedEventArgs();
			e.Name = P_1.Name;
			e.Path = P_1.Path;
			W21SXNlUGRR(this, e);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void t87SX5r8ucL(PS3WorldUI P_0, PS3GameFile P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (W21SXNlUGRR != null)
		{
			SaveSelectedEventArgs e = new SaveSelectedEventArgs();
			e.Name = P_1.Name;
			e.Path = P_1.Path;
			bUwSXDRDmXS(this, e);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RedoSelect()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		foreach (object control in CFBSXu89O7R.Controls)
		{
			PS3WorldUI pS3WorldUI = control as PS3WorldUI;
			if (pS3WorldUI.WorldActive)
			{
				U0mSXrdoWq7(pS3WorldUI, pS3WorldUI.SaveDef);
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
		if (disposing && poTSXJvXdoF != null)
		{
			poTSXJvXdoF.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void lifSX69S9h7()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		CFBSXu89O7R = new FlowLayoutPanel();
		SuspendLayout();
		CFBSXu89O7R.AutoScroll = true;
		CFBSXu89O7R.BackColor = Color.White;
		CFBSXu89O7R.BorderStyle = BorderStyle.FixedSingle;
		CFBSXu89O7R.Dock = DockStyle.Fill;
		CFBSXu89O7R.Location = new Point(0, 0);
		CFBSXu89O7R.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20342);
		CFBSXu89O7R.Padding = new Padding(0, 3, 0, 0);
		CFBSXu89O7R.Size = new Size(260, 371);
		CFBSXu89O7R.TabIndex = 3;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(CFBSXu89O7R);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(208530);
		base.Size = new Size(260, 371);
		ResumeLayout(performLayout: false);
	}
}
