using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using MCCToolChest.events;
using MCCToolChest.model;
using mLQMRIMFOvpjLbxR07;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls;

public class BiomeSelector : UserControl
{
	private EventHandler ttxbUePf2W;

	private List<DropDownItem> YOybLkilSF;

	private IContainer tc4bgkeM9H;

	private IBe8LoH64FQ11CRIs2 vucbPaoctK;

	public int Biome
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			int.TryParse(vucbPaoctK.SelectedValue.ToString(), out var result);
			return result;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			vucbPaoctK.SelectedValue = value.ToString();
		}
	}

	public event EventHandler BiomeChanged
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = ttxbUePf2W;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref ttxbUePf2W, value2, eventHandler2);
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
			EventHandler eventHandler = ttxbUePf2W;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref ttxbUePf2W, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasValue()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return vucbPaoctK.SelectedValue != null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BiomeSelector()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		YOybLkilSF = new List<DropDownItem>();
		z60bMY1sHv();
		xWlbx2V83v();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void xWlbx2V83v()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<Biome> list = BiomeLookup.bedrockId.Values.ToList();
		for (int i = 0; i < list.Count; i++)
		{
			Biome biome = list[i];
			DropDownItem item = new DropDownItem(biome.BedrockId, (int)biome.Color, biome.Label);
			YOybLkilSF.Add(item);
		}
		vucbPaoctK.ValueMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10936);
		vucbPaoctK.DisplayMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10946);
		vucbPaoctK.DataSource = YOybLkilSF;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnBiomeChanged(object sender, BiomeChangedEventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ttxbUePf2W?.Invoke(this, e);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void iUGbeNdfLS(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (vucbPaoctK.SelectedValue != null)
		{
			int.TryParse(vucbPaoctK.SelectedValue.ToString(), out var result);
			OnBiomeChanged(this, new BiomeChangedEventArgs(result));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && tc4bgkeM9H != null)
		{
			tc4bgkeM9H.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void z60bMY1sHv()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		vucbPaoctK = new IBe8LoH64FQ11CRIs2();
		SuspendLayout();
		vucbPaoctK.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		vucbPaoctK.DrawMode = DrawMode.OwnerDrawFixed;
		vucbPaoctK.DropDownStyle = ComboBoxStyle.DropDownList;
		vucbPaoctK.FormattingEnabled = true;
		vucbPaoctK.Location = new Point(0, 3);
		vucbPaoctK.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10958);
		vucbPaoctK.Size = new Size(184, 21);
		vucbPaoctK.TabIndex = 3;
		vucbPaoctK.SelectedIndexChanged += iUGbeNdfLS;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(vucbPaoctK);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10976);
		base.Size = new Size(187, 28);
		ResumeLayout(performLayout: false);
	}
}
