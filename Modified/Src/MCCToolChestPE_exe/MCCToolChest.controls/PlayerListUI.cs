using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using MCCToolChest.events;
using MCCToolChest.model;
using MCCToolChest.utils;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls;

public class PlayerListUI : UserControl
{
	private EventHandler jT2aNxKGIJ;

	private EventHandler OK0aD4gbgb;

	private IContainer BdDackURbr;

	private FlowLayoutPanel bcdaJ7NIrM;

	public event EventHandler PlayerSelected
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = jT2aNxKGIJ;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref jT2aNxKGIJ, value2, eventHandler2);
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
			EventHandler eventHandler = jT2aNxKGIJ;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref jT2aNxKGIJ, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler PlayerDeleted
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = OK0aD4gbgb;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref OK0aD4gbgb, value2, eventHandler2);
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
			EventHandler eventHandler = OK0aD4gbgb;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref OK0aD4gbgb, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PlayerListUI()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		BvIa61IUqg();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateUI(Dictionary<string, ModifiedFile> modifiedFiles)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		try
		{
			List<PlayerDisplayData> list = LIVaYa0qi7(modifiedFiles);
			C87akTwCoM(list);
		}
		catch (Exception)
		{
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void C87akTwCoM(List<PlayerDisplayData> P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bcdaJ7NIrM.Controls.Clear();
		foreach (PlayerDisplayData item in P_0)
		{
			PlayerItemUI value = new PlayerItemUI(item, Y3da1Vr68B, bGIaErlcCq);
			bcdaJ7NIrM.Controls.Add(value);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<PlayerDisplayData> LIVaYa0qi7(Dictionary<string, ModifiedFile> P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		DirectoryInfo directoryInfo = new DirectoryInfo(Working.T92StMGt1p4() + Working.WorkFolder + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28436));
		FileInfo[] files = directoryInfo.GetFiles(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28454));
		List<PlayerDisplayData> list = new List<PlayerDisplayData>();
		FileInfo[] array = files;
		foreach (FileInfo fileInfo in array)
		{
			string fileName = Path.GetFileName(fileInfo.FullName);
			if (!P_0.ContainsKey(fileName) || P_0[fileName].FileState != FileStateType.DELETED)
			{
				TagNodeCompound player = wUKa3qj31i(fileInfo.FullName);
				PlayerDisplayData item = new PlayerDisplayData(player, fileInfo.FullName);
				list.Add(item);
			}
		}
		return list;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNodeCompound wUKa3qj31i(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Path.GetFileNameWithoutExtension(P_0);
		byte[] buffer = FileUtils.pURSg6Zk53A(P_0);
		MemoryStream s = new MemoryStream(buffer);
		NbtTree nbtTree = new NbtTree(s);
		return nbtTree.Root;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Y3da1Vr68B(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		OnPlayerSelected(this, new PlayerActionEventArgs(P_0));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void bGIaErlcCq(PlayerItemUI P_0, string P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		OnPlayerDeleted(this, new PlayerActionEventArgs(P_1));
		bcdaJ7NIrM.Controls.Remove(P_0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void sBsarc6s2E(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bcdaJ7NIrM.Focus();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<PlayerDisplayData> KpZa50cyKm(List<PlayerDisplayData> P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<PlayerDisplayData> list = new List<PlayerDisplayData>();
		Dictionary<string, List<PlayerDisplayData>> dictionary = new Dictionary<string, List<PlayerDisplayData>>();
		foreach (PlayerDisplayData item in P_0)
		{
			string key = "";
			if (item.Player.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28468)))
			{
				key = item.Player[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28468)] as TagNodeString;
			}
			if (!dictionary.ContainsKey(key))
			{
				dictionary[key] = new List<PlayerDisplayData>();
			}
			dictionary[key].Add(item);
		}
		List<string> list2 = dictionary.Keys.ToList();
		list2.Sort();
		foreach (string item2 in list2)
		{
			foreach (PlayerDisplayData item3 in dictionary[item2])
			{
				list.Add(item3);
			}
		}
		return list;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnPlayerSelected(object sender, PlayerActionEventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		jT2aNxKGIJ?.Invoke(this, e);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnPlayerDeleted(object sender, PlayerActionEventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		OK0aD4gbgb?.Invoke(this, e);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && BdDackURbr != null)
		{
			BdDackURbr.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BvIa61IUqg()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bcdaJ7NIrM = new FlowLayoutPanel();
		SuspendLayout();
		bcdaJ7NIrM.AutoScroll = true;
		bcdaJ7NIrM.Dock = DockStyle.Fill;
		bcdaJ7NIrM.Location = new Point(0, 0);
		bcdaJ7NIrM.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28480);
		bcdaJ7NIrM.Padding = new Padding(0, 6, 0, 0);
		bcdaJ7NIrM.Size = new Size(421, 333);
		bcdaJ7NIrM.TabIndex = 1;
		bcdaJ7NIrM.MouseEnter += sBsarc6s2E;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(bcdaJ7NIrM);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28510);
		base.Size = new Size(421, 333);
		ResumeLayout(performLayout: false);
	}
}
