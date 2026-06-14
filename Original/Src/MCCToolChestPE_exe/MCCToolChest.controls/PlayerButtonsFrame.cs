using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls;

public class PlayerButtonsFrame : UserControl
{
	private EventHandler wq7wBmM05x;

	private EventHandler aZywtJ0xZZ;

	private IContainer xw5waygkKg;

	private Button XrUwXNkOyr;

	private Button rG1wxt6O4J;

	public event EventHandler InventoryEditor
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = wq7wBmM05x;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref wq7wBmM05x, value2, eventHandler2);
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
			EventHandler eventHandler = wq7wBmM05x;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref wq7wBmM05x, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler EnderInventoryEditor
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = aZywtJ0xZZ;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref aZywtJ0xZZ, value2, eventHandler2);
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
			EventHandler eventHandler = aZywtJ0xZZ;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref aZywtJ0xZZ, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PlayerButtonsFrame()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		eJKw0Jil7B();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnInventoryEditor()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (wq7wBmM05x != null)
		{
			wq7wBmM05x(this, EventArgs.Empty);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnEnderInventoryEditor()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (aZywtJ0xZZ != null)
		{
			aZywtJ0xZZ(this, EventArgs.Empty);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Uttw2sQKxM(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		OnEnderInventoryEditor();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void VtswyDg4j7(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		OnInventoryEditor();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && xw5waygkKg != null)
		{
			xw5waygkKg.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void eJKw0Jil7B()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(PlayerButtonsFrame));
		XrUwXNkOyr = new Button();
		rG1wxt6O4J = new Button();
		SuspendLayout();
		XrUwXNkOyr.BackColor = Color.LightGray;
		XrUwXNkOyr.BackgroundImage = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12370));
		XrUwXNkOyr.BackgroundImageLayout = ImageLayout.None;
		XrUwXNkOyr.FlatStyle = FlatStyle.Popup;
		XrUwXNkOyr.Location = new Point(4, 26);
		XrUwXNkOyr.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12442);
		XrUwXNkOyr.Size = new Size(64, 64);
		XrUwXNkOyr.TabIndex = 1;
		XrUwXNkOyr.UseVisualStyleBackColor = false;
		XrUwXNkOyr.Click += VtswyDg4j7;
		rG1wxt6O4J.BackColor = Color.LightGray;
		rG1wxt6O4J.BackgroundImage = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12482));
		rG1wxt6O4J.BackgroundImageLayout = ImageLayout.None;
		rG1wxt6O4J.FlatStyle = FlatStyle.Popup;
		rG1wxt6O4J.Location = new Point(4, 101);
		rG1wxt6O4J.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12564);
		rG1wxt6O4J.Size = new Size(64, 64);
		rG1wxt6O4J.TabIndex = 3;
		rG1wxt6O4J.UseVisualStyleBackColor = false;
		rG1wxt6O4J.Click += Uttw2sQKxM;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.Gainsboro;
		base.Controls.Add(rG1wxt6O4J);
		base.Controls.Add(XrUwXNkOyr);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12614);
		base.Size = new Size(72, 470);
		ResumeLayout(performLayout: false);
	}
}
