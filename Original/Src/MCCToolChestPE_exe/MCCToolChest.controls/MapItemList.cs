using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using MCCToolChest.events;
using MCCToolChest.model;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls;

public class MapItemList : UserControl
{
	private EventHandler DLcBBx75Zv;

	private MapItem VEMBtW8GmC;

	private IContainer uLjBaRHEoe;

	private FlowLayoutPanel u2rBXX6wSj;

	public event EventHandler MapActive
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = DLcBBx75Zv;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref DLcBBx75Zv, value2, eventHandler2);
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
			EventHandler eventHandler = DLcBBx75Zv;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref DLcBBx75Zv, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MapItemList()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		lY5B0shlG2();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void LoadList(List<MCMap> mapList)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		u2rBXX6wSj.Controls.Clear();
		foreach (MCMap map in mapList)
		{
			AddMap(map);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void L8FBl2xnQW(MapItem P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0 != null)
		{
			if (VEMBtW8GmC != null)
			{
				VEMBtW8GmC.SetActive(isActive: false);
			}
			VEMBtW8GmC = P_0;
			OnMapActive(this, new MapActiveEventArgs(P_0.MapData));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddMap(MCMap map)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MapItem value = new MapItem(map, L8FBl2xnQW);
		u2rBXX6wSj.Controls.Add(value);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Check()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (keyData == Keys.Up || keyData == Keys.Down)
		{
			JTLB2ULRtI((keyData != Keys.Up) ? DirType.Down : DirType.Up);
			return true;
		}
		return base.ProcessCmdKey(ref msg, keyData);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void JTLB2ULRtI(DirType P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (u2rBXX6wSj.Controls.Count <= 0 || VEMBtW8GmC == null)
		{
			return;
		}
		int num = BpiByfvCP0();
		if (num >= 0)
		{
			if (P_0 == DirType.Up && num > 0)
			{
				((MapItem)u2rBXX6wSj.Controls[num]).SetActive(isActive: false);
				((MapItem)u2rBXX6wSj.Controls[num - 1]).SetActive(isActive: true);
				VEMBtW8GmC = (MapItem)u2rBXX6wSj.Controls[num - 1];
				num--;
			}
			else if (P_0 == DirType.Down && num < u2rBXX6wSj.Controls.Count - 1)
			{
				((MapItem)u2rBXX6wSj.Controls[num]).SetActive(isActive: false);
				((MapItem)u2rBXX6wSj.Controls[num + 1]).SetActive(isActive: true);
				VEMBtW8GmC = (MapItem)u2rBXX6wSj.Controls[num + 1];
				num++;
			}
			u2rBXX6wSj.VerticalScroll.Value = num * 162;
			u2rBXX6wSj.PerformLayout();
			OnMapActive(this, new MapActiveEventArgs(VEMBtW8GmC.MapData));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int BpiByfvCP0()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int result = -1;
		for (int i = 0; i < u2rBXX6wSj.Controls.Count; i++)
		{
			if (VEMBtW8GmC == u2rBXX6wSj.Controls[i])
			{
				result = i;
			}
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnMapActive(object sender, MapActiveEventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		DLcBBx75Zv?.Invoke(this, e);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && uLjBaRHEoe != null)
		{
			uLjBaRHEoe.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void lY5B0shlG2()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		u2rBXX6wSj = new FlowLayoutPanel();
		SuspendLayout();
		u2rBXX6wSj.AutoScroll = true;
		u2rBXX6wSj.Dock = DockStyle.Fill;
		u2rBXX6wSj.Location = new Point(0, 0);
		u2rBXX6wSj.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23600);
		u2rBXX6wSj.Padding = new Padding(0, 6, 0, 0);
		u2rBXX6wSj.Size = new Size(276, 204);
		u2rBXX6wSj.TabIndex = 0;
		u2rBXX6wSj.WrapContents = false;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(u2rBXX6wSj);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23624);
		base.Size = new Size(276, 204);
		ResumeLayout(performLayout: false);
	}
}
