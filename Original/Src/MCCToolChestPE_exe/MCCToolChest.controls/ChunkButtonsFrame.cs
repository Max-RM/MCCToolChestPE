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

public class ChunkButtonsFrame : UserControl
{
	private EventHandler OCJtIgl8Is;

	private EventHandler DeFtzPyC7i;

	private EventHandler El4aTt71qw;

	private IContainer PrmaSA46RL;

	private Button MK4aGdT3JZ;

	private Button uqPab3IKOI;

	private Button OjjavF5F0b;

	public event EventHandler BlockEditor
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = OCJtIgl8Is;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref OCJtIgl8Is, value2, eventHandler2);
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
			EventHandler eventHandler = OCJtIgl8Is;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref OCJtIgl8Is, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler BiomeEditor
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = DeFtzPyC7i;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref DeFtzPyC7i, value2, eventHandler2);
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
			EventHandler eventHandler = DeFtzPyC7i;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref DeFtzPyC7i, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler EntityEditor
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = El4aTt71qw;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref El4aTt71qw, value2, eventHandler2);
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
			EventHandler eventHandler = El4aTt71qw;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref El4aTt71qw, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ChunkButtonsFrame()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		Mr2t9eRdcH();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnBlockEditor()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (OCJtIgl8Is != null)
		{
			OCJtIgl8Is(this, EventArgs.Empty);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnEntityEditor()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (El4aTt71qw != null)
		{
			El4aTt71qw(this, EventArgs.Empty);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnBiomeEditor()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (DeFtzPyC7i != null)
		{
			DeFtzPyC7i(this, EventArgs.Empty);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UDntF21kZl(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		OnBlockEditor();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void au1tjcxkPv(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		OnBiomeEditor();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void j9pt8eUIfu(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		OnEntityEditor();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && PrmaSA46RL != null)
		{
			PrmaSA46RL.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Mr2t9eRdcH()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		OjjavF5F0b = new Button();
		uqPab3IKOI = new Button();
		MK4aGdT3JZ = new Button();
		SuspendLayout();
		OjjavF5F0b.BackColor = Color.LightGray;
		OjjavF5F0b.BackgroundImage = Resources.NKNS10Lb4se();
		OjjavF5F0b.FlatStyle = FlatStyle.Popup;
		OjjavF5F0b.Location = new Point(4, 26);
		OjjavF5F0b.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(27778);
		OjjavF5F0b.Size = new Size(64, 64);
		OjjavF5F0b.TabIndex = 3;
		OjjavF5F0b.UseVisualStyleBackColor = false;
		OjjavF5F0b.Click += UDntF21kZl;
		uqPab3IKOI.BackColor = Color.LightGray;
		uqPab3IKOI.BackgroundImage = Resources.d2rSEfIegO8();
		uqPab3IKOI.FlatStyle = FlatStyle.Popup;
		uqPab3IKOI.Location = new Point(4, 187);
		uqPab3IKOI.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(27810);
		uqPab3IKOI.Size = new Size(64, 64);
		uqPab3IKOI.TabIndex = 2;
		uqPab3IKOI.UseVisualStyleBackColor = false;
		uqPab3IKOI.Click += j9pt8eUIfu;
		MK4aGdT3JZ.BackColor = Color.LightGray;
		MK4aGdT3JZ.BackgroundImage = Resources.biome;
		MK4aGdT3JZ.FlatStyle = FlatStyle.Popup;
		MK4aGdT3JZ.Location = new Point(4, 106);
		MK4aGdT3JZ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(27844);
		MK4aGdT3JZ.Size = new Size(64, 64);
		MK4aGdT3JZ.TabIndex = 1;
		MK4aGdT3JZ.UseVisualStyleBackColor = false;
		MK4aGdT3JZ.Click += au1tjcxkPv;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.Gainsboro;
		base.Controls.Add(OjjavF5F0b);
		base.Controls.Add(uqPab3IKOI);
		base.Controls.Add(MK4aGdT3JZ);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(27876);
		base.Size = new Size(72, 470);
		ResumeLayout(performLayout: false);
	}
}
