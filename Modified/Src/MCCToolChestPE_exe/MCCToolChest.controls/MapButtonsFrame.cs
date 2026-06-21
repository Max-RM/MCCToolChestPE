using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using MCCToolChest.Properties;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls;

public class MapButtonsFrame : UserControl
{
	private EventHandler MuPwmNfm1w;

	private IContainer CldwntETw9;

	private Button UjhwlKQ2TJ;

	public event EventHandler MapEditor
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = MuPwmNfm1w;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref MuPwmNfm1w, value2, eventHandler2);
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
			EventHandler eventHandler = MuPwmNfm1w;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref MuPwmNfm1w, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MapButtonsFrame()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		PfIwhxtbom();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnMapEditor()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (MuPwmNfm1w != null)
		{
			MuPwmNfm1w(this, EventArgs.Empty);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SiDwK4RNgH(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		OnMapEditor();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && CldwntETw9 != null)
		{
			CldwntETw9.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PfIwhxtbom()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		UjhwlKQ2TJ = new Button();
		SuspendLayout();
		UjhwlKQ2TJ.BackColor = Color.LightGray;
		UjhwlKQ2TJ.BackgroundImage = Resources.Rc5SEEMbn5E();
		UjhwlKQ2TJ.FlatStyle = FlatStyle.Popup;
		UjhwlKQ2TJ.Location = new Point(4, 26);
		UjhwlKQ2TJ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12268);
		UjhwlKQ2TJ.Size = new Size(64, 64);
		UjhwlKQ2TJ.TabIndex = 3;
		UjhwlKQ2TJ.UseVisualStyleBackColor = false;
		UjhwlKQ2TJ.Click += SiDwK4RNgH;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.Gainsboro;
		base.Controls.Add(UjhwlKQ2TJ);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12336);
		base.Size = new Size(72, 470);
		ResumeLayout(performLayout: false);
	}
}
