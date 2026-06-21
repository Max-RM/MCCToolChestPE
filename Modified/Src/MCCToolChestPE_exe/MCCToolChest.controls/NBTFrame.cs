using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using ConfTkj5LbUck64WyxM;
using DekWW8jSE3fVOo1d5ao;
using dJ9gJMugJCIyCsx5I39;
using NBTExplorer.Controllers;
using NBTExplorer.Model;
using NBTExplorer.Vendor.MultiSelectTreeView;
using NBTExplorer.Windows;
using NBTModel.Interop;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls;

public class NBTFrame : UserControl
{
	private EventHandler Fc6tlqRUuh;

	private EventHandler GiTt2H27St;

	private EventHandler i10tycxZr6;

	private EventHandler CUit0tRQbi;

	private NodeTreeController egEtBhxNPh;

	private IContainer ERIttmcW5a;

	private TableLayoutPanel ch0ta7UDei;

	private ToolStrip Nk2tXJ7IGt;

	public ToolStripButton _buttonCut;

	public ToolStripButton _buttonCopy;

	public ToolStripButton _buttonPaste;

	private ToolStripSeparator HOttxgR1M1;

	public ToolStripButton _buttonRename;

	public ToolStripButton _buttonEdit;

	public ToolStripButton _buttonDelete;

	private ToolStripSeparator utyteTQLGT;

	private ToolStripButton wqxtMagxa3;

	private ToolStripButton eVZtUQMOGi;

	private ToolStripButton GWKtLqCoFy;

	private ToolStripButton qRetg1Qixx;

	private ToolStripButton JoOtPgJCa1;

	private ToolStripButton BZEtRZEOHE;

	private ToolStripButton SvmtkIA56b;

	private ToolStripButton IrftYfl84A;

	private ToolStripButton T51t3uqB5Z;

	private ToolStripButton kNOt1jLoq3;

	private ToolStripButton JWdtE4fVms;

	private ToolStripSeparator bJ1trLcwJG;

	private ToolStripButton LwAt58fsOI;

	public MultiSelectTreeView tvNBTEdit;

	private MenuStrip pF6t6iY3go;

	private ToolStripMenuItem K6TtN1xni0;

	private ToolStripMenuItem nc5tDGpvY3;

	private ToolStripMenuItem aWrtcdMexT;

	private ToolStripMenuItem wectJsHA2t;

	private ToolStripSeparator iH2tuGeiA5;

	private ToolStripMenuItem Ns2towMaAk;

	private ToolStripMenuItem r5KtQJDQyQ;

	private ToolStripMenuItem ibAtOAhbmX;

	private ToolStripSeparator X5etCSi2MD;

	private ToolStripMenuItem f0Zt7bMdX6;

	private ToolStripMenuItem xm6tANvGdL;

	private ImageList HrGtdnCy52;

	private ToolStripButton wkvtHvQOGj;

	public NodeTreeController Controller
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return egEtBhxNPh;
		}
	}

	public event EventHandler UIUpdated
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = Fc6tlqRUuh;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref Fc6tlqRUuh, value2, eventHandler2);
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
			EventHandler eventHandler = Fc6tlqRUuh;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref Fc6tlqRUuh, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler BlockEditor
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = GiTt2H27St;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref GiTt2H27St, value2, eventHandler2);
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
			EventHandler eventHandler = GiTt2H27St;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref GiTt2H27St, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler MapEditor
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = i10tycxZr6;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref i10tycxZr6, value2, eventHandler2);
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
			EventHandler eventHandler = i10tycxZr6;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref i10tycxZr6, value2, eventHandler2);
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
			EventHandler eventHandler = CUit0tRQbi;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref CUit0tRQbi, value2, eventHandler2);
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
			EventHandler eventHandler = CUit0tRQbi;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref CUit0tRQbi, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NBTFrame()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		WQ5tn8dCWo();
		if (ControlSupport.IsInRuntimeMode(this))
		{
			TVOBcDJZcg();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TVOBcDJZcg()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		FormHandlers.Register();
		NbtClipboardController.Initialize(new NbtClipboardControllerWin());
		egEtBhxNPh = new NodeTreeController(tvNBTEdit);
		egEtBhxNPh.SelectionInvalidated += RghBuRwbdC;
		_buttonEdit.Click += pvmBoWFukC;
		_buttonRename.Click += X95BQ6qKbP;
		_buttonDelete.Click += cBlBOxbpbH;
		_buttonCopy.Click += ytkBCA08oo;
		_buttonCut.Click += OimB77bTP2;
		_buttonPaste.Click += rr0BAif2CQ;
		wqxtMagxa3.Click += S6yBH2Q6KM;
		SvmtkIA56b.Click += p0yBdcPUIN;
		JWdtE4fVms.Click += O13BFsTNEE;
		BZEtRZEOHE.Click += ff5BjYEvsY;
		JoOtPgJCa1.Click += gHjB8Rswb8;
		GWKtLqCoFy.Click += SVNB9ol6J2;
		IrftYfl84A.Click += yhOBIOPAnv;
		wkvtHvQOGj.Click += O0TBz0R02d;
		kNOt1jLoq3.Click += Al4tTtxR2a;
		qRetg1Qixx.Click += WDMtSZT6u6;
		eVZtUQMOGi.Click += Je5tG1U85y;
		T51t3uqB5Z.Click += CcTtbOWAGU;
		LwAt58fsOI.Click += P9Ltvum4Th;
		r5KtQJDQyQ.Click += hVkt4fVwKX;
		Ns2towMaAk.Click += GRgtVdG1A9;
		ibAtOAhbmX.Click += l4BtWVni65;
		aWrtcdMexT.Click += x4HtpTgEjM;
		nc5tDGpvY3.Click += EiBtZHNbVE;
		wectJsHA2t.Click += uXstfhaM3G;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddIconImages()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Dictionary<string, Image> dictionary = bBZMC0uOW5A7L8yvqOi.gBgSkEDKNoT();
		foreach (string key in dictionary.Keys)
		{
			HrGtdnCy52.Images.Add(key, dictionary[key]);
		}
		Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
		foreach (NHRdVhjnRgobfuHvRk0 item in hvd0XujpavSpj5UhiI6.MaDSV0nae1F)
		{
			string value = item.Name;
			if (!dictionary2.ContainsKey(item.LZES4IdKb9J().ToString()))
			{
				dictionary2.Add(item.LZES4IdKb9J().ToString(), value);
			}
			if (!dictionary2.ContainsKey(item.YhxSVSwIOdw().ToString()))
			{
				dictionary2.Add(item.YhxSVSwIOdw().ToString(), value);
			}
		}
		NodeTreeController.entityLookups = dictionary2;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void E3BBJyo9B0(object P_0, MessageBoxEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (egEtBhxNPh.CheckModifications() && MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23702) + P_1.Message, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23780), MessageBoxButtons.OKCancel) != DialogResult.OK)
		{
			P_1.Cancel = true;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RghBuRwbdC(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		UpdateUI();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OpenExistingNode(DataNode node)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		egEtBhxNPh.OpenExistingNode(node);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DataNode GetExistingNode()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return egEtBhxNPh.GetExistingNode();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void pvmBoWFukC(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		egEtBhxNPh.EditSelection();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void X95BQ6qKbP(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		egEtBhxNPh.RenameSelection();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void cBlBOxbpbH(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		egEtBhxNPh.DeleteSelection();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ytkBCA08oo(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		egEtBhxNPh.CopySelection();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OimB77bTP2(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		egEtBhxNPh.CutSelection();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void rr0BAif2CQ(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		egEtBhxNPh.PasteIntoSelection();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void p0yBdcPUIN(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		egEtBhxNPh.CreateNode(TagType.TAG_BYTE_ARRAY);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void S6yBH2Q6KM(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		egEtBhxNPh.CreateNode(TagType.TAG_BYTE);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void O13BFsTNEE(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		egEtBhxNPh.CreateNode(TagType.TAG_COMPOUND);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ff5BjYEvsY(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		egEtBhxNPh.CreateNode(TagType.TAG_DOUBLE);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void gHjB8Rswb8(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		egEtBhxNPh.CreateNode(TagType.TAG_FLOAT);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SVNB9ol6J2(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		egEtBhxNPh.CreateNode(TagType.TAG_INT);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void yhOBIOPAnv(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		egEtBhxNPh.CreateNode(TagType.TAG_INT_ARRAY);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void O0TBz0R02d(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		egEtBhxNPh.CreateNode(TagType.TAG_LONG_ARRAY);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Al4tTtxR2a(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		egEtBhxNPh.CreateNode(TagType.TAG_LIST);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void WDMtSZT6u6(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		egEtBhxNPh.CreateNode(TagType.TAG_LONG);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Je5tG1U85y(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		egEtBhxNPh.CreateNode(TagType.TAG_SHORT);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CcTtbOWAGU(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		egEtBhxNPh.CreateNode(TagType.TAG_STRING);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void P9Ltvum4Th(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FHCtwffWwr(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		egEtBhxNPh.RefreshSelection();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hVkt4fVwKX(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		egEtBhxNPh.EditSelection();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GRgtVdG1A9(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		egEtBhxNPh.RenameSelection();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void l4BtWVni65(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		egEtBhxNPh.DeleteSelection();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void x4HtpTgEjM(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		egEtBhxNPh.CopySelection();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EiBtZHNbVE(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		egEtBhxNPh.CutSelection();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void uXstfhaM3G(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		egEtBhxNPh.PasteIntoSelection();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Qqfti40jeF(object P_0, TreeNodeMouseClickEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		egEtBhxNPh.EditNode(P_1.Node);
		UpdateUI();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GlctsENY1m(object P_0, TreeNodeMouseClickEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		UpdateUI();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearDisplay()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		tvNBTEdit.Nodes.Clear();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateUI()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TreeNode selectedNode = tvNBTEdit.SelectedNode;
		if (tvNBTEdit.SelectedNodes.Count > 1)
		{
			byhtmc0To4(tvNBTEdit.SelectedNodes);
		}
		else if (selectedNode != null && selectedNode.Tag is DataNode)
		{
			nr0thSb62R(selectedNode.Tag as DataNode);
		}
		else
		{
			BVVtqQnRLx(wqxtMagxa3, SvmtkIA56b, JWdtE4fVms, BZEtRZEOHE, JoOtPgJCa1, GWKtLqCoFy, IrftYfl84A, wkvtHvQOGj, kNOt1jLoq3, qRetg1Qixx, eVZtUQMOGi, T51t3uqB5Z, _buttonCopy, _buttonCut, _buttonDelete, _buttonEdit, _buttonPaste, LwAt58fsOI, _buttonRename);
			LwAt58fsOI.Enabled = false;
			BsmtKtJgEC(aWrtcdMexT, nc5tDGpvY3, ibAtOAhbmX, r5KtQJDQyQ, wectJsHA2t, Ns2towMaAk, f0Zt7bMdX6, xm6tANvGdL);
		}
		OnUIUpdate();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BVVtqQnRLx(params ToolStripButton[] buttons)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		foreach (ToolStripButton toolStripButton in buttons)
		{
			toolStripButton.Enabled = false;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BsmtKtJgEC(params ToolStripMenuItem[] buttons)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		foreach (ToolStripMenuItem toolStripMenuItem in buttons)
		{
			toolStripMenuItem.Enabled = false;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void nr0thSb62R(DataNode P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0 != null)
		{
			wqxtMagxa3.Enabled = P_0.CanCreateTag(TagType.TAG_BYTE);
			SvmtkIA56b.Enabled = P_0.CanCreateTag(TagType.TAG_BYTE_ARRAY);
			JWdtE4fVms.Enabled = P_0.CanCreateTag(TagType.TAG_COMPOUND);
			BZEtRZEOHE.Enabled = P_0.CanCreateTag(TagType.TAG_DOUBLE);
			JoOtPgJCa1.Enabled = P_0.CanCreateTag(TagType.TAG_FLOAT);
			GWKtLqCoFy.Enabled = P_0.CanCreateTag(TagType.TAG_INT);
			IrftYfl84A.Enabled = P_0.CanCreateTag(TagType.TAG_INT_ARRAY);
			wkvtHvQOGj.Enabled = P_0.CanCreateTag(TagType.TAG_LONG_ARRAY);
			kNOt1jLoq3.Enabled = P_0.CanCreateTag(TagType.TAG_LIST);
			qRetg1Qixx.Enabled = P_0.CanCreateTag(TagType.TAG_LONG);
			eVZtUQMOGi.Enabled = P_0.CanCreateTag(TagType.TAG_SHORT);
			T51t3uqB5Z.Enabled = P_0.CanCreateTag(TagType.TAG_STRING);
			_buttonCopy.Enabled = P_0.CanCopyNode && NbtClipboardController.IsInitialized;
			_buttonCut.Enabled = P_0.CanCutNode && NbtClipboardController.IsInitialized;
			_buttonDelete.Enabled = P_0.CanDeleteNode;
			_buttonEdit.Enabled = P_0.CanEditNode;
			_buttonPaste.Enabled = P_0.CanPasteIntoNode && NbtClipboardController.IsInitialized;
			_buttonRename.Enabled = P_0.CanRenameNode;
			LwAt58fsOI.Enabled = P_0.CanRefreshNode;
			aWrtcdMexT.Enabled = P_0.CanCopyNode && NbtClipboardController.IsInitialized;
			nc5tDGpvY3.Enabled = P_0.CanCutNode && NbtClipboardController.IsInitialized;
			ibAtOAhbmX.Enabled = P_0.CanDeleteNode;
			r5KtQJDQyQ.Enabled = P_0.CanEditNode;
			wectJsHA2t.Enabled = P_0.CanPasteIntoNode && NbtClipboardController.IsInitialized;
			Ns2towMaAk.Enabled = P_0.CanRenameNode;
			f0Zt7bMdX6.Enabled = P_0.CanMoveNodeUp;
			xm6tANvGdL.Enabled = P_0.CanMoveNodeDown;
			byhtmc0To4(tvNBTEdit.SelectedNodes);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void byhtmc0To4(IList<TreeNode> P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0 != null)
		{
			wqxtMagxa3.Enabled = egEtBhxNPh.CanOperateOnSelection(NodeTreeController.Predicates.CreateByteNodePred);
			eVZtUQMOGi.Enabled = egEtBhxNPh.CanOperateOnSelection(NodeTreeController.Predicates.CreateShortNodePred);
			GWKtLqCoFy.Enabled = egEtBhxNPh.CanOperateOnSelection(NodeTreeController.Predicates.CreateIntNodePred);
			qRetg1Qixx.Enabled = egEtBhxNPh.CanOperateOnSelection(NodeTreeController.Predicates.CreateLongNodePred);
			JoOtPgJCa1.Enabled = egEtBhxNPh.CanOperateOnSelection(NodeTreeController.Predicates.CreateFloatNodePred);
			BZEtRZEOHE.Enabled = egEtBhxNPh.CanOperateOnSelection(NodeTreeController.Predicates.CreateDoubleNodePred);
			SvmtkIA56b.Enabled = egEtBhxNPh.CanOperateOnSelection(NodeTreeController.Predicates.CreateByteArrayNodePred);
			IrftYfl84A.Enabled = egEtBhxNPh.CanOperateOnSelection(NodeTreeController.Predicates.CreateIntArrayNodePred);
			wkvtHvQOGj.Enabled = egEtBhxNPh.CanOperateOnSelection(NodeTreeController.Predicates.CreateLongArrayNodePred);
			T51t3uqB5Z.Enabled = egEtBhxNPh.CanOperateOnSelection(NodeTreeController.Predicates.CreateStringNodePred);
			kNOt1jLoq3.Enabled = egEtBhxNPh.CanOperateOnSelection(NodeTreeController.Predicates.CreateListNodePred);
			JWdtE4fVms.Enabled = egEtBhxNPh.CanOperateOnSelection(NodeTreeController.Predicates.CreateCompoundNodePred);
			_buttonRename.Enabled = egEtBhxNPh.CanOperateOnSelection(NodeTreeController.Predicates.RenameNodePred);
			_buttonEdit.Enabled = egEtBhxNPh.CanOperateOnSelection(NodeTreeController.Predicates.EditNodePred);
			_buttonDelete.Enabled = egEtBhxNPh.CanOperateOnSelection(NodeTreeController.Predicates.DeleteNodePred);
			_buttonCut.Enabled = egEtBhxNPh.CanOperateOnSelection(NodeTreeController.Predicates.CutNodePred) && NbtClipboardController.IsInitialized;
			_buttonCopy.Enabled = egEtBhxNPh.CanOperateOnSelection(NodeTreeController.Predicates.CopyNodePred) && NbtClipboardController.IsInitialized;
			_buttonPaste.Enabled = egEtBhxNPh.CanOperateOnSelection(NodeTreeController.Predicates.PasteIntoNodePred) && NbtClipboardController.IsInitialized;
			LwAt58fsOI.Enabled = egEtBhxNPh.CanOperateOnSelection(NodeTreeController.Predicates.RefreshNodePred);
			Ns2towMaAk.Enabled = _buttonRename.Enabled;
			r5KtQJDQyQ.Enabled = _buttonEdit.Enabled;
			ibAtOAhbmX.Enabled = _buttonDelete.Enabled;
			f0Zt7bMdX6.Enabled = egEtBhxNPh.CanOperateOnSelection(NodeTreeController.Predicates.MoveNodeUpPred);
			xm6tANvGdL.Enabled = egEtBhxNPh.CanOperateOnSelection(NodeTreeController.Predicates.MoveNodeDownPred);
			nc5tDGpvY3.Enabled = _buttonCut.Enabled;
			aWrtcdMexT.Enabled = _buttonCopy.Enabled;
			wectJsHA2t.Enabled = _buttonPaste.Enabled;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnUIUpdate()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Fc6tlqRUuh != null)
		{
			Fc6tlqRUuh(this, EventArgs.Empty);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && ERIttmcW5a != null)
		{
			ERIttmcW5a.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void WQ5tn8dCWo()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ERIttmcW5a = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(NBTFrame));
		ch0ta7UDei = new TableLayoutPanel();
		tvNBTEdit = new MultiSelectTreeView();
		HrGtdnCy52 = new ImageList(ERIttmcW5a);
		Nk2tXJ7IGt = new ToolStrip();
		_buttonCut = new ToolStripButton();
		_buttonCopy = new ToolStripButton();
		_buttonPaste = new ToolStripButton();
		HOttxgR1M1 = new ToolStripSeparator();
		_buttonRename = new ToolStripButton();
		_buttonEdit = new ToolStripButton();
		_buttonDelete = new ToolStripButton();
		utyteTQLGT = new ToolStripSeparator();
		wqxtMagxa3 = new ToolStripButton();
		eVZtUQMOGi = new ToolStripButton();
		GWKtLqCoFy = new ToolStripButton();
		qRetg1Qixx = new ToolStripButton();
		JoOtPgJCa1 = new ToolStripButton();
		BZEtRZEOHE = new ToolStripButton();
		SvmtkIA56b = new ToolStripButton();
		IrftYfl84A = new ToolStripButton();
		T51t3uqB5Z = new ToolStripButton();
		kNOt1jLoq3 = new ToolStripButton();
		JWdtE4fVms = new ToolStripButton();
		bJ1trLcwJG = new ToolStripSeparator();
		LwAt58fsOI = new ToolStripButton();
		pF6t6iY3go = new MenuStrip();
		K6TtN1xni0 = new ToolStripMenuItem();
		nc5tDGpvY3 = new ToolStripMenuItem();
		aWrtcdMexT = new ToolStripMenuItem();
		wectJsHA2t = new ToolStripMenuItem();
		iH2tuGeiA5 = new ToolStripSeparator();
		Ns2towMaAk = new ToolStripMenuItem();
		r5KtQJDQyQ = new ToolStripMenuItem();
		ibAtOAhbmX = new ToolStripMenuItem();
		X5etCSi2MD = new ToolStripSeparator();
		f0Zt7bMdX6 = new ToolStripMenuItem();
		xm6tANvGdL = new ToolStripMenuItem();
		wkvtHvQOGj = new ToolStripButton();
		ch0ta7UDei.SuspendLayout();
		Nk2tXJ7IGt.SuspendLayout();
		pF6t6iY3go.SuspendLayout();
		SuspendLayout();
		ch0ta7UDei.ColumnCount = 1;
		ch0ta7UDei.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		ch0ta7UDei.Controls.Add(tvNBTEdit, 0, 1);
		ch0ta7UDei.Controls.Add(Nk2tXJ7IGt, 0, 0);
		ch0ta7UDei.Dock = DockStyle.Fill;
		ch0ta7UDei.Location = new Point(0, 0);
		ch0ta7UDei.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10826);
		ch0ta7UDei.RowCount = 2;
		ch0ta7UDei.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
		ch0ta7UDei.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		ch0ta7UDei.Size = new Size(534, 511);
		ch0ta7UDei.TabIndex = 0;
		tvNBTEdit.BorderStyle = BorderStyle.None;
		tvNBTEdit.Dock = DockStyle.Fill;
		tvNBTEdit.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tvNBTEdit.ImageIndex = 0;
		tvNBTEdit.ImageList = HrGtdnCy52;
		tvNBTEdit.Location = new Point(3, 28);
		tvNBTEdit.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23814);
		tvNBTEdit.SelectedImageIndex = 0;
		tvNBTEdit.SelectedNodes = (List<TreeNode>)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23836));
		tvNBTEdit.Size = new Size(528, 480);
		tvNBTEdit.TabIndex = 7;
		tvNBTEdit.NodeMouseClick += GlctsENY1m;
		tvNBTEdit.NodeMouseDoubleClick += Qqfti40jeF;
		HrGtdnCy52.ImageStream = (ImageListStreamer)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23886));
		HrGtdnCy52.TransparentColor = Color.Transparent;
		HrGtdnCy52.Images.SetKeyName(0, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23934));
		HrGtdnCy52.Images.SetKeyName(1, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23986));
		HrGtdnCy52.Images.SetKeyName(2, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(24038));
		HrGtdnCy52.Images.SetKeyName(3, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(24090));
		HrGtdnCy52.Images.SetKeyName(4, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(24142));
		HrGtdnCy52.Images.SetKeyName(5, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(24194));
		HrGtdnCy52.Images.SetKeyName(6, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(24246));
		HrGtdnCy52.Images.SetKeyName(7, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(24276));
		HrGtdnCy52.Images.SetKeyName(8, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(24318));
		HrGtdnCy52.Images.SetKeyName(9, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(24348));
		HrGtdnCy52.Images.SetKeyName(10, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(24366));
		HrGtdnCy52.Images.SetKeyName(11, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(24390));
		HrGtdnCy52.Images.SetKeyName(12, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(24412));
		HrGtdnCy52.Images.SetKeyName(13, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(24444));
		HrGtdnCy52.Images.SetKeyName(14, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(24462));
		HrGtdnCy52.Images.SetKeyName(15, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(24496));
		Nk2tXJ7IGt.AutoSize = false;
		Nk2tXJ7IGt.Dock = DockStyle.Bottom;
		Nk2tXJ7IGt.GripStyle = ToolStripGripStyle.Hidden;
		Nk2tXJ7IGt.Items.AddRange(new ToolStripItem[22]
		{
			_buttonCut, _buttonCopy, _buttonPaste, HOttxgR1M1, _buttonRename, _buttonEdit, _buttonDelete, utyteTQLGT, wqxtMagxa3, eVZtUQMOGi,
			GWKtLqCoFy, qRetg1Qixx, JoOtPgJCa1, BZEtRZEOHE, SvmtkIA56b, IrftYfl84A, wkvtHvQOGj, T51t3uqB5Z, kNOt1jLoq3, JWdtE4fVms,
			bJ1trLcwJG, LwAt58fsOI
		});
		Nk2tXJ7IGt.Location = new Point(0, 0);
		Nk2tXJ7IGt.Margin = new Padding(0, 0, 0, 4);
		Nk2tXJ7IGt.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22784);
		Nk2tXJ7IGt.Padding = new Padding(10, 0, 1, 0);
		Nk2tXJ7IGt.Size = new Size(534, 21);
		Nk2tXJ7IGt.Stretch = true;
		Nk2tXJ7IGt.TabIndex = 6;
		_buttonCut.DisplayStyle = ToolStripItemDisplayStyle.Image;
		_buttonCut.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(24536));
		_buttonCut.ImageTransparentColor = Color.Magenta;
		_buttonCut.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(24572);
		_buttonCut.Size = new Size(23, 18);
		_buttonCut.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(24596);
		_buttonCopy.DisplayStyle = ToolStripItemDisplayStyle.Image;
		_buttonCopy.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(24606));
		_buttonCopy.ImageTransparentColor = Color.Magenta;
		_buttonCopy.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(24644);
		_buttonCopy.Size = new Size(23, 18);
		_buttonCopy.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20950);
		_buttonPaste.DisplayStyle = ToolStripItemDisplayStyle.Image;
		_buttonPaste.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(24670));
		_buttonPaste.ImageTransparentColor = Color.Magenta;
		_buttonPaste.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(24710);
		_buttonPaste.Size = new Size(23, 18);
		_buttonPaste.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20982);
		HOttxgR1M1.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(24738);
		HOttxgR1M1.Size = new Size(6, 21);
		_buttonRename.DisplayStyle = ToolStripItemDisplayStyle.Image;
		_buttonRename.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(24780));
		_buttonRename.ImageTransparentColor = Color.Magenta;
		_buttonRename.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(24822);
		_buttonRename.Size = new Size(23, 18);
		_buttonRename.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(24852);
		_buttonEdit.DisplayStyle = ToolStripItemDisplayStyle.Image;
		_buttonEdit.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(24876));
		_buttonEdit.ImageTransparentColor = Color.Magenta;
		_buttonEdit.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(24914);
		_buttonEdit.Size = new Size(23, 18);
		_buttonEdit.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(24940);
		_buttonDelete.DisplayStyle = ToolStripItemDisplayStyle.Image;
		_buttonDelete.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(24972));
		_buttonDelete.ImageTransparentColor = Color.Magenta;
		_buttonDelete.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(25014);
		_buttonDelete.Size = new Size(23, 18);
		_buttonDelete.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(25044);
		utyteTQLGT.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(25068);
		utyteTQLGT.Size = new Size(6, 21);
		wqxtMagxa3.DisplayStyle = ToolStripItemDisplayStyle.Image;
		wqxtMagxa3.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(25110));
		wqxtMagxa3.ImageTransparentColor = Color.Magenta;
		wqxtMagxa3.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(25160);
		wqxtMagxa3.Size = new Size(23, 18);
		wqxtMagxa3.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(25198);
		eVZtUQMOGi.DisplayStyle = ToolStripItemDisplayStyle.Image;
		eVZtUQMOGi.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(25226));
		eVZtUQMOGi.ImageTransparentColor = Color.Magenta;
		eVZtUQMOGi.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(25278);
		eVZtUQMOGi.Size = new Size(23, 18);
		eVZtUQMOGi.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(25318);
		GWKtLqCoFy.DisplayStyle = ToolStripItemDisplayStyle.Image;
		GWKtLqCoFy.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(25348));
		GWKtLqCoFy.ImageTransparentColor = Color.Magenta;
		GWKtLqCoFy.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(25396);
		GWKtLqCoFy.Size = new Size(23, 18);
		GWKtLqCoFy.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(25432);
		qRetg1Qixx.DisplayStyle = ToolStripItemDisplayStyle.Image;
		qRetg1Qixx.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(25458));
		qRetg1Qixx.ImageTransparentColor = Color.Magenta;
		qRetg1Qixx.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(25508);
		qRetg1Qixx.Size = new Size(23, 18);
		qRetg1Qixx.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(25546);
		JoOtPgJCa1.DisplayStyle = ToolStripItemDisplayStyle.Image;
		JoOtPgJCa1.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(25574));
		JoOtPgJCa1.ImageTransparentColor = Color.Magenta;
		JoOtPgJCa1.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(25626);
		JoOtPgJCa1.Size = new Size(23, 18);
		JoOtPgJCa1.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(25666);
		BZEtRZEOHE.DisplayStyle = ToolStripItemDisplayStyle.Image;
		BZEtRZEOHE.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(25696));
		BZEtRZEOHE.ImageTransparentColor = Color.Magenta;
		BZEtRZEOHE.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(25750);
		BZEtRZEOHE.Size = new Size(23, 18);
		BZEtRZEOHE.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(25792);
		SvmtkIA56b.DisplayStyle = ToolStripItemDisplayStyle.Image;
		SvmtkIA56b.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(25824));
		SvmtkIA56b.ImageTransparentColor = Color.Magenta;
		SvmtkIA56b.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(25884);
		SvmtkIA56b.Size = new Size(23, 18);
		SvmtkIA56b.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(25932);
		IrftYfl84A.DisplayStyle = ToolStripItemDisplayStyle.Image;
		IrftYfl84A.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(25972));
		IrftYfl84A.ImageScaling = ToolStripItemImageScaling.None;
		IrftYfl84A.ImageTransparentColor = Color.Magenta;
		IrftYfl84A.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26030);
		IrftYfl84A.Size = new Size(23, 18);
		IrftYfl84A.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26076);
		T51t3uqB5Z.DisplayStyle = ToolStripItemDisplayStyle.Image;
		T51t3uqB5Z.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26114));
		T51t3uqB5Z.ImageTransparentColor = Color.Magenta;
		T51t3uqB5Z.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26168);
		T51t3uqB5Z.Size = new Size(23, 18);
		T51t3uqB5Z.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26210);
		kNOt1jLoq3.DisplayStyle = ToolStripItemDisplayStyle.Image;
		kNOt1jLoq3.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26242));
		kNOt1jLoq3.ImageTransparentColor = Color.Magenta;
		kNOt1jLoq3.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26292);
		kNOt1jLoq3.Size = new Size(23, 18);
		kNOt1jLoq3.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26330);
		JWdtE4fVms.DisplayStyle = ToolStripItemDisplayStyle.Image;
		JWdtE4fVms.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26358));
		JWdtE4fVms.ImageTransparentColor = Color.Magenta;
		JWdtE4fVms.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26416);
		JWdtE4fVms.Size = new Size(23, 18);
		JWdtE4fVms.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26462);
		bJ1trLcwJG.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26498);
		bJ1trLcwJG.Size = new Size(6, 21);
		bJ1trLcwJG.Visible = false;
		LwAt58fsOI.DisplayStyle = ToolStripItemDisplayStyle.Image;
		LwAt58fsOI.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26540));
		LwAt58fsOI.ImageTransparentColor = Color.Magenta;
		LwAt58fsOI.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26586);
		LwAt58fsOI.Size = new Size(23, 18);
		LwAt58fsOI.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26620);
		LwAt58fsOI.Visible = false;
		pF6t6iY3go.Items.AddRange(new ToolStripItem[1] { K6TtN1xni0 });
		pF6t6iY3go.Location = new Point(0, 0);
		pF6t6iY3go.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26656);
		pF6t6iY3go.Size = new Size(534, 24);
		pF6t6iY3go.TabIndex = 1;
		pF6t6iY3go.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26656);
		pF6t6iY3go.Visible = false;
		K6TtN1xni0.DropDownItems.AddRange(new ToolStripItem[10] { nc5tDGpvY3, aWrtcdMexT, wectJsHA2t, iH2tuGeiA5, Ns2towMaAk, r5KtQJDQyQ, ibAtOAhbmX, X5etCSi2MD, f0Zt7bMdX6, xm6tANvGdL });
		K6TtN1xni0.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26680);
		K6TtN1xni0.ShortcutKeys = Keys.Up | Keys.Control;
		K6TtN1xni0.Size = new Size(39, 20);
		K6TtN1xni0.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26726);
		nc5tDGpvY3.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26740));
		nc5tDGpvY3.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26780);
		nc5tDGpvY3.ShortcutKeys = Keys.X | Keys.Control;
		nc5tDGpvY3.Size = new Size(203, 22);
		nc5tDGpvY3.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26808);
		aWrtcdMexT.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26820));
		aWrtcdMexT.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26862);
		aWrtcdMexT.ShortcutKeys = Keys.C | Keys.Control;
		aWrtcdMexT.Size = new Size(203, 22);
		aWrtcdMexT.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26892);
		wectJsHA2t.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26906));
		wectJsHA2t.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26950);
		wectJsHA2t.ShortcutKeys = Keys.V | Keys.Control;
		wectJsHA2t.Size = new Size(203, 22);
		wectJsHA2t.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26982);
		iH2tuGeiA5.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26998);
		iH2tuGeiA5.Size = new Size(200, 6);
		Ns2towMaAk.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(27040));
		Ns2towMaAk.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(27086);
		Ns2towMaAk.ShortcutKeys = Keys.R | Keys.Control;
		Ns2towMaAk.Size = new Size(203, 22);
		Ns2towMaAk.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(27120);
		r5KtQJDQyQ.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(27138));
		r5KtQJDQyQ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(27190);
		r5KtQJDQyQ.ShortcutKeys = Keys.E | Keys.Control;
		r5KtQJDQyQ.Size = new Size(203, 22);
		r5KtQJDQyQ.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(27230);
		ibAtOAhbmX.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(27256));
		ibAtOAhbmX.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(27302);
		ibAtOAhbmX.ShortcutKeys = Keys.Delete;
		ibAtOAhbmX.Size = new Size(203, 22);
		ibAtOAhbmX.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(27336);
		X5etCSi2MD.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(27354);
		X5etCSi2MD.Size = new Size(200, 6);
		f0Zt7bMdX6.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(27398));
		f0Zt7bMdX6.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(27444);
		f0Zt7bMdX6.ShortcutKeys = Keys.Up | Keys.Control;
		f0Zt7bMdX6.Size = new Size(203, 22);
		f0Zt7bMdX6.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(27478);
		xm6tANvGdL.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(27498));
		xm6tANvGdL.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(27548);
		xm6tANvGdL.ShortcutKeys = Keys.Down | Keys.Control;
		xm6tANvGdL.Size = new Size(203, 22);
		xm6tANvGdL.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(27586);
		wkvtHvQOGj.DisplayStyle = ToolStripItemDisplayStyle.Image;
		wkvtHvQOGj.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(27610));
		wkvtHvQOGj.ImageScaling = ToolStripItemImageScaling.None;
		wkvtHvQOGj.ImageTransparentColor = Color.Magenta;
		wkvtHvQOGj.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(27670);
		wkvtHvQOGj.Size = new Size(23, 18);
		wkvtHvQOGj.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(27718);
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(pF6t6iY3go);
		base.Controls.Add(ch0ta7UDei);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(27758);
		base.Size = new Size(534, 511);
		ch0ta7UDei.ResumeLayout(performLayout: false);
		Nk2tXJ7IGt.ResumeLayout(performLayout: false);
		Nk2tXJ7IGt.PerformLayout();
		pF6t6iY3go.ResumeLayout(performLayout: false);
		pF6t6iY3go.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
