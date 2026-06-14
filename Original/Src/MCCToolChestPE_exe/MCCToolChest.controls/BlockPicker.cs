using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using jWBDofdcGMieH0qfdS;
using MCCToolChest.events;
using uL2B6CXB2hZQU16Di7r;
using uP7B13T5waxVpI3AEv;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls;

public class BlockPicker : UserControl
{
	private static string SwDbrMgkyR;

	private EventHandler LDib55ffWR;

	private IContainer eN6b6YvsVQ;

	private ListView reCbNCVwhH;

	private ColumnHeader QdAbDglPsb;

	private ColumnHeader nXBbcORiYN;

	private TextBox iuYbJooEFR;

	public event EventHandler BlockSelected
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = LDib55ffWR;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref LDib55ffWR, value2, eventHandler2);
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
			EventHandler eventHandler = LDib55ffWR;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref LDib55ffWR, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BlockPicker()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		zqRbEjG0oD();
		iuYbJooEFR.Text = SwDbrMgkyR;
		x1mbYkON8E();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DY9bRJc4W7(ListView P_0, List<jLK03d0ZSlci2XsVe6> P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_0.Items.Clear();
		P_0.LargeImageList = BFRL2f2UoG7tBGIHJF.fyLSLwvej3();
		P_0.SmallImageList = BFRL2f2UoG7tBGIHJF.fyLSLwvej3();
		foreach (jLK03d0ZSlci2XsVe6 item in P_1)
		{
			ListViewItem listViewItem = new ListViewItem();
			listViewItem.ImageKey = item.Name;
			string text = item.Description;
			listViewItem.SubItems.Add(text);
			listViewItem.Tag = item;
			P_0.Items.Add(listViewItem);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void noVbkfjRSc(object P_0, KeyEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		x1mbYkON8E();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void x1mbYkON8E()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string value = (SwDbrMgkyR = iuYbJooEFR.Text.Trim());
		if (string.IsNullOrWhiteSpace(value))
		{
			DY9bRJc4W7(reCbNCVwhH, BFRL2f2UoG7tBGIHJF.mAVSRPT1qd().Values.ToList());
			return;
		}
		List<jLK03d0ZSlci2XsVe6> list = new List<jLK03d0ZSlci2XsVe6>();
		foreach (jLK03d0ZSlci2XsVe6 value2 in BFRL2f2UoG7tBGIHJF.mAVSRPT1qd().Values)
		{
			if (value2.Description.IndexOf(value, StringComparison.OrdinalIgnoreCase) >= 0)
			{
				list.Add(value2);
			}
		}
		DY9bRJc4W7(reCbNCVwhH, list);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void kNUb35dcr3(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (reCbNCVwhH.SelectedItems.Count > 0)
		{
			jLK03d0ZSlci2XsVe6 jLK03d0ZSlci2XsVe7 = reCbNCVwhH.SelectedItems[0].Tag as jLK03d0ZSlci2XsVe6;
			OnBlockSelected(this, new BlockSelectedEventArgs(jLK03d0ZSlci2XsVe7.Name));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnBlockSelected(object sender, BlockSelectedEventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LDib55ffWR?.Invoke(this, e);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void VbRb1ttbYe(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && eN6b6YvsVQ != null)
		{
			eN6b6YvsVQ.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void zqRbEjG0oD()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		reCbNCVwhH = new ListView();
		QdAbDglPsb = new ColumnHeader();
		nXBbcORiYN = new ColumnHeader();
		iuYbJooEFR = new TextBox();
		SuspendLayout();
		reCbNCVwhH.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		reCbNCVwhH.Columns.AddRange(new ColumnHeader[2] { QdAbDglPsb, nXBbcORiYN });
		reCbNCVwhH.FullRowSelect = true;
		reCbNCVwhH.Location = new Point(3, 19);
		reCbNCVwhH.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11006);
		reCbNCVwhH.Size = new Size(357, 271);
		reCbNCVwhH.TabIndex = 1;
		reCbNCVwhH.UseCompatibleStateImageBehavior = false;
		reCbNCVwhH.View = View.Details;
		reCbNCVwhH.SelectedIndexChanged += VbRb1ttbYe;
		reCbNCVwhH.DoubleClick += kNUb35dcr3;
		QdAbDglPsb.Text = "";
		QdAbDglPsb.Width = 39;
		nXBbcORiYN.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11032);
		nXBbcORiYN.Width = 278;
		iuYbJooEFR.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		iuYbJooEFR.BackColor = SystemColors.Info;
		iuYbJooEFR.BorderStyle = BorderStyle.FixedSingle;
		iuYbJooEFR.Location = new Point(3, 0);
		iuYbJooEFR.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11046);
		iuYbJooEFR.Size = new Size(357, 20);
		iuYbJooEFR.TabIndex = 2;
		iuYbJooEFR.KeyUp += noVbkfjRSc;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(reCbNCVwhH);
		base.Controls.Add(iuYbJooEFR);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11076);
		base.Size = new Size(363, 292);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
