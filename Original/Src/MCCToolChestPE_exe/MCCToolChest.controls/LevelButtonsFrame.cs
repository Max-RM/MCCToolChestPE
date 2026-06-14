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

public class LevelButtonsFrame : UserControl
{
	private EventHandler sXtwisBYgc;

	private IContainer QZTwsmlKc4;

	private Button ziywqVnVu7;

	public event EventHandler LayerEditor
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = sXtwisBYgc;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref sXtwisBYgc, value2, eventHandler2);
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
			EventHandler eventHandler = sXtwisBYgc;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref sXtwisBYgc, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LevelButtonsFrame()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		CUdwfs6lXM();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnLayerEditor()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (sXtwisBYgc != null)
		{
			sXtwisBYgc(this, EventArgs.Empty);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void wZswZ2rJaL(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		OnLayerEditor();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && QZTwsmlKc4 != null)
		{
			QZTwsmlKc4.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CUdwfs6lXM()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ziywqVnVu7 = new Button();
		SuspendLayout();
		ziywqVnVu7.BackColor = Color.LightGray;
		ziywqVnVu7.BackgroundImage = Resources.tmbSEYKxs9W();
		ziywqVnVu7.FlatStyle = FlatStyle.Popup;
		ziywqVnVu7.Location = new Point(4, 26);
		ziywqVnVu7.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12268);
		ziywqVnVu7.Size = new Size(64, 64);
		ziywqVnVu7.TabIndex = 3;
		ziywqVnVu7.UseVisualStyleBackColor = false;
		ziywqVnVu7.Click += wZswZ2rJaL;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.Gainsboro;
		base.Controls.Add(ziywqVnVu7);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12298);
		base.Size = new Size(72, 470);
		ResumeLayout(performLayout: false);
	}
}
