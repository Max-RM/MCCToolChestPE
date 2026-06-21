using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Ipd9FQuHFywPC2qc3U0;
using MCCToolChest.model;
using MCCToolChest.Properties;
using MCCToolChest.utils;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.forms;

public class Library : Form
{
	private ListViewColumnSorter m7VFLWTF2t;

	private IContainer MJyFgH6oPc;

	private SplitContainer KvkFPgKRmw;

	private ListView yytFRBTfKg;

	private MenuStrip IJnFkR4yBY;

	private ToolStripMenuItem KQrFYWNArn;

	private ColumnHeader iAxF38xLXd;

	private TableLayoutPanel jEbF12wnRT;

	private Label Ro7FEEWjWk;

	private Label L0VFr4h7KB;

	private TextBox KnsF5C1E8q;

	private ContextMenuStrip mI9F6jkXVE;

	private ToolStripMenuItem DZfFNvlvnk;

	private ToolStripMenuItem CEMFDywyhD;

	private Label DL5Fca9P4D;

	private Label O3uFJQFvyg;

	private TableLayoutPanel w9XFuoaRXe;

	private ColumnHeader IhHFoyFPRr;

	private Label arGFQscptv;

	private ComboBox cUdFOxfs34;

	private TabControl MpyFCw9rSE;

	private TabPage rTwF7rPJR8;

	private TabPage wJlFACToX7;

	private TabPage GVoFd05unG;

	private Button JFfFH0g68O;

	private Panel QqjFFKoaFF;

	private TextBox bF4Fjy9DUg;

	private TextBox ExSF8TbWwg;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Library()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		cOXFUPPVnQ();
		Vu5Fi6Mtl0();
		Y0JFnbofEa();
		m7VFLWTF2t = new ListViewColumnSorter();
		yytFRBTfKg.ListViewItemSorter = m7VFLWTF2t;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Vu5Fi6Mtl0()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Utils.GetLibraryFolder();
		RjxtHpuJeeKUWTRviGE.NbSStZbS2Td();
		PHNFsU6umH();
		Fb2FqrGUwS();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PHNFsU6umH()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string[] array = RjxtHpuJeeKUWTRviGE.lZKStfRmi9D();
		cUdFOxfs34.Items.Clear();
		cUdFOxfs34.Items.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57302));
		string[] array2 = array;
		foreach (string item in array2)
		{
			cUdFOxfs34.Items.Add(item);
		}
		cUdFOxfs34.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57302);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Fb2FqrGUwS()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Y0JFnbofEa();
		yytFRBTfKg.Items.Clear();
		string text = cUdFOxfs34.Text;
		List<LibraryItem> list = RjxtHpuJeeKUWTRviGE.lcJStiZ18vl(text);
		foreach (LibraryItem item in list)
		{
			ListViewItem listViewItem = new ListViewItem(item.Name);
			listViewItem.SubItems.Add(item.Category);
			listViewItem.Tag = item;
			yytFRBTfKg.Items.Add(listViewItem);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FPNFKXHPds(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LibraryItemDlg libraryItemDlg = new LibraryItemDlg();
		if (libraryItemDlg.ShowDialog(this) == DialogResult.OK)
		{
			RjxtHpuJeeKUWTRviGE.AdgStq3SisE(libraryItemDlg.libraryItem);
			Fb2FqrGUwS();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PJhFhduia1(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ListView.SelectedListViewItemCollection selectedItems = yytFRBTfKg.SelectedItems;
		if (selectedItems != null && selectedItems.Count > 0)
		{
			GSkFmgxGf6(selectedItems[0].Tag as LibraryItem);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GSkFmgxGf6(LibraryItem P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0 != null)
		{
			L0VFr4h7KB.Text = P_0.Name;
			O3uFJQFvyg.Text = P_0.Author;
			bF4Fjy9DUg.Text = P_0.Description;
			ExSF8TbWwg.Text = P_0.Instructions;
			KnsF5C1E8q.Text = P_0.NBTString;
		}
		else
		{
			Y0JFnbofEa();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Y0JFnbofEa()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		L0VFr4h7KB.Text = "";
		O3uFJQFvyg.Text = "";
		bF4Fjy9DUg.Text = "";
		ExSF8TbWwg.Text = "";
		KnsF5C1E8q.Text = "";
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void KBeFllZ5Rp(object P_0, CancelEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ListView.SelectedListViewItemCollection selectedItems = yytFRBTfKg.SelectedItems;
		if (selectedItems == null || selectedItems.Count == 0)
		{
			P_1.Cancel = true;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ListViewItem OUhF24Y6w7()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ListView.SelectedListViewItemCollection selectedItems = yytFRBTfKg.SelectedItems;
		if (selectedItems != null || selectedItems.Count > 0)
		{
			return selectedItems[0];
		}
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void WWmFyZI4CY(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ListViewItem listViewItem = OUhF24Y6w7();
		if (listViewItem != null)
		{
			DialogResult dialogResult = MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60826), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10326), MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				LibraryItem libraryItem = listViewItem.Tag as LibraryItem;
				peqFtG4bn2(libraryItem);
				RjxtHpuJeeKUWTRviGE.la7Stsk9diD(libraryItem.Name);
				Fb2FqrGUwS();
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void wr4F0ZQJxA(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		vYwFBOu6Uh();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void vYwFBOu6Uh()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ListViewItem listViewItem = OUhF24Y6w7();
		if (listViewItem != null)
		{
			LibraryItem libraryItem = listViewItem.Tag as LibraryItem;
			LibraryItemDlg libraryItemDlg = new LibraryItemDlg(libraryItem);
			if (libraryItemDlg.ShowDialog(this) == DialogResult.OK)
			{
				listViewItem.SubItems[1].Text = libraryItem.Category;
				GSkFmgxGf6(libraryItem);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void peqFtG4bn2(LibraryItem P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0 != null)
		{
			new Settings();
			string path = Utils.LibraryPath();
			string path2 = Path.Combine(path, P_0.Name + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(59498));
			File.Delete(path2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void P5cFaPgt5P(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		try
		{
			Clipboard.SetText(KnsF5C1E8q.Text);
		}
		catch (Exception)
		{
			MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60870), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55870));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void dy6FXUZpDb(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Fb2FqrGUwS();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void aJOFxnDqIb(object P_0, MouseEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		vYwFBOu6Uh();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void kWmFej7O0y(object P_0, ColumnClickEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_1.Column == m7VFLWTF2t.SortColumn)
		{
			if (m7VFLWTF2t.Order == SortOrder.Ascending)
			{
				m7VFLWTF2t.Order = SortOrder.Descending;
			}
			else
			{
				m7VFLWTF2t.Order = SortOrder.Ascending;
			}
		}
		else
		{
			m7VFLWTF2t.SortColumn = P_1.Column;
			m7VFLWTF2t.Order = SortOrder.Ascending;
		}
		yytFRBTfKg.Sort();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void vFlFMLZZ2C(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.Icon = Resources.usMSrbJo37S();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && MJyFgH6oPc != null)
		{
			MJyFgH6oPc.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void cOXFUPPVnQ()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MJyFgH6oPc = new Container();
		KvkFPgKRmw = new SplitContainer();
		w9XFuoaRXe = new TableLayoutPanel();
		yytFRBTfKg = new ListView();
		iAxF38xLXd = new ColumnHeader();
		IhHFoyFPRr = new ColumnHeader();
		mI9F6jkXVE = new ContextMenuStrip(MJyFgH6oPc);
		DZfFNvlvnk = new ToolStripMenuItem();
		CEMFDywyhD = new ToolStripMenuItem();
		QqjFFKoaFF = new Panel();
		arGFQscptv = new Label();
		cUdFOxfs34 = new ComboBox();
		jEbF12wnRT = new TableLayoutPanel();
		Ro7FEEWjWk = new Label();
		L0VFr4h7KB = new Label();
		DL5Fca9P4D = new Label();
		O3uFJQFvyg = new Label();
		MpyFCw9rSE = new TabControl();
		rTwF7rPJR8 = new TabPage();
		bF4Fjy9DUg = new TextBox();
		wJlFACToX7 = new TabPage();
		ExSF8TbWwg = new TextBox();
		GVoFd05unG = new TabPage();
		KnsF5C1E8q = new TextBox();
		JFfFH0g68O = new Button();
		IJnFkR4yBY = new MenuStrip();
		KQrFYWNArn = new ToolStripMenuItem();
		((ISupportInitialize)KvkFPgKRmw).BeginInit();
		KvkFPgKRmw.Panel1.SuspendLayout();
		KvkFPgKRmw.Panel2.SuspendLayout();
		KvkFPgKRmw.SuspendLayout();
		w9XFuoaRXe.SuspendLayout();
		mI9F6jkXVE.SuspendLayout();
		QqjFFKoaFF.SuspendLayout();
		jEbF12wnRT.SuspendLayout();
		MpyFCw9rSE.SuspendLayout();
		rTwF7rPJR8.SuspendLayout();
		wJlFACToX7.SuspendLayout();
		GVoFd05unG.SuspendLayout();
		IJnFkR4yBY.SuspendLayout();
		SuspendLayout();
		KvkFPgKRmw.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		KvkFPgKRmw.Location = new Point(0, 27);
		KvkFPgKRmw.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13750);
		KvkFPgKRmw.Panel1.Controls.Add(w9XFuoaRXe);
		KvkFPgKRmw.Panel2.Controls.Add(jEbF12wnRT);
		KvkFPgKRmw.Size = new Size(830, 498);
		KvkFPgKRmw.SplitterDistance = 460;
		KvkFPgKRmw.TabIndex = 0;
		w9XFuoaRXe.ColumnCount = 1;
		w9XFuoaRXe.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		w9XFuoaRXe.Controls.Add(yytFRBTfKg, 0, 1);
		w9XFuoaRXe.Controls.Add(QqjFFKoaFF, 0, 0);
		w9XFuoaRXe.Dock = DockStyle.Fill;
		w9XFuoaRXe.Location = new Point(0, 0);
		w9XFuoaRXe.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(36460);
		w9XFuoaRXe.RowCount = 2;
		w9XFuoaRXe.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		w9XFuoaRXe.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		w9XFuoaRXe.Size = new Size(460, 498);
		w9XFuoaRXe.TabIndex = 0;
		yytFRBTfKg.Columns.AddRange(new ColumnHeader[2] { iAxF38xLXd, IhHFoyFPRr });
		yytFRBTfKg.ContextMenuStrip = mI9F6jkXVE;
		yytFRBTfKg.Dock = DockStyle.Fill;
		yytFRBTfKg.FullRowSelect = true;
		yytFRBTfKg.HideSelection = false;
		yytFRBTfKg.Location = new Point(3, 31);
		yytFRBTfKg.MultiSelect = false;
		yytFRBTfKg.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60938);
		yytFRBTfKg.Size = new Size(454, 464);
		yytFRBTfKg.Sorting = SortOrder.Descending;
		yytFRBTfKg.TabIndex = 0;
		yytFRBTfKg.UseCompatibleStateImageBehavior = false;
		yytFRBTfKg.View = View.Details;
		yytFRBTfKg.ColumnClick += kWmFej7O0y;
		yytFRBTfKg.SelectedIndexChanged += PJhFhduia1;
		yytFRBTfKg.MouseDoubleClick += aJOFxnDqIb;
		iAxF38xLXd.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10196);
		iAxF38xLXd.Width = 279;
		IhHFoyFPRr.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(59722);
		IhHFoyFPRr.Width = 147;
		mI9F6jkXVE.Items.AddRange(new ToolStripItem[2] { DZfFNvlvnk, CEMFDywyhD });
		mI9F6jkXVE.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28944);
		mI9F6jkXVE.Size = new Size(108, 48);
		mI9F6jkXVE.Opening += KBeFllZ5Rp;
		DZfFNvlvnk.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60970);
		DZfFNvlvnk.Size = new Size(107, 22);
		DZfFNvlvnk.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60992);
		DZfFNvlvnk.Click += wr4F0ZQJxA;
		CEMFDywyhD.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(61004);
		CEMFDywyhD.Size = new Size(107, 22);
		CEMFDywyhD.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10326);
		CEMFDywyhD.Click += WWmFyZI4CY;
		QqjFFKoaFF.Controls.Add(arGFQscptv);
		QqjFFKoaFF.Controls.Add(cUdFOxfs34);
		QqjFFKoaFF.Dock = DockStyle.Fill;
		QqjFFKoaFF.Location = new Point(3, 3);
		QqjFFKoaFF.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10398);
		QqjFFKoaFF.Size = new Size(454, 22);
		QqjFFKoaFF.TabIndex = 3;
		arGFQscptv.AutoSize = true;
		arGFQscptv.Location = new Point(3, 4);
		arGFQscptv.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11298);
		arGFQscptv.Size = new Size(49, 13);
		arGFQscptv.TabIndex = 1;
		arGFQscptv.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(59722);
		cUdFOxfs34.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		cUdFOxfs34.DropDownStyle = ComboBoxStyle.DropDownList;
		cUdFOxfs34.FormattingEnabled = true;
		cUdFOxfs34.Location = new Point(57, 0);
		cUdFOxfs34.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(59742);
		cUdFOxfs34.Size = new Size(396, 21);
		cUdFOxfs34.Sorted = true;
		cUdFOxfs34.TabIndex = 2;
		cUdFOxfs34.SelectedIndexChanged += dy6FXUZpDb;
		jEbF12wnRT.ColumnCount = 1;
		jEbF12wnRT.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		jEbF12wnRT.Controls.Add(Ro7FEEWjWk, 0, 0);
		jEbF12wnRT.Controls.Add(L0VFr4h7KB, 0, 1);
		jEbF12wnRT.Controls.Add(DL5Fca9P4D, 0, 2);
		jEbF12wnRT.Controls.Add(O3uFJQFvyg, 0, 3);
		jEbF12wnRT.Controls.Add(MpyFCw9rSE, 0, 4);
		jEbF12wnRT.Controls.Add(JFfFH0g68O, 0, 5);
		jEbF12wnRT.Dock = DockStyle.Fill;
		jEbF12wnRT.Location = new Point(0, 0);
		jEbF12wnRT.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10826);
		jEbF12wnRT.Padding = new Padding(0, 0, 4, 4);
		jEbF12wnRT.RowCount = 6;
		jEbF12wnRT.RowStyles.Add(new RowStyle(SizeType.Absolute, 14f));
		jEbF12wnRT.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
		jEbF12wnRT.RowStyles.Add(new RowStyle(SizeType.Absolute, 14f));
		jEbF12wnRT.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
		jEbF12wnRT.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		jEbF12wnRT.RowStyles.Add(new RowStyle(SizeType.Absolute, 30f));
		jEbF12wnRT.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
		jEbF12wnRT.Size = new Size(366, 498);
		jEbF12wnRT.TabIndex = 0;
		Ro7FEEWjWk.AutoSize = true;
		Ro7FEEWjWk.Dock = DockStyle.Fill;
		Ro7FEEWjWk.ForeColor = SystemColors.Highlight;
		Ro7FEEWjWk.Location = new Point(3, 0);
		Ro7FEEWjWk.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		Ro7FEEWjWk.Size = new Size(356, 14);
		Ro7FEEWjWk.TabIndex = 0;
		Ro7FEEWjWk.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10196);
		L0VFr4h7KB.AutoSize = true;
		L0VFr4h7KB.Dock = DockStyle.Fill;
		L0VFr4h7KB.Location = new Point(3, 14);
		L0VFr4h7KB.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(61030);
		L0VFr4h7KB.Size = new Size(356, 20);
		L0VFr4h7KB.TabIndex = 4;
		L0VFr4h7KB.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(61052);
		DL5Fca9P4D.AutoSize = true;
		DL5Fca9P4D.Dock = DockStyle.Fill;
		DL5Fca9P4D.ForeColor = SystemColors.Highlight;
		DL5Fca9P4D.Location = new Point(3, 34);
		DL5Fca9P4D.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11162);
		DL5Fca9P4D.Size = new Size(356, 14);
		DL5Fca9P4D.TabIndex = 8;
		DL5Fca9P4D.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12784);
		O3uFJQFvyg.AutoSize = true;
		O3uFJQFvyg.Dock = DockStyle.Fill;
		O3uFJQFvyg.Location = new Point(3, 48);
		O3uFJQFvyg.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(61090);
		O3uFJQFvyg.Size = new Size(356, 20);
		O3uFJQFvyg.TabIndex = 9;
		O3uFJQFvyg.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(61116);
		MpyFCw9rSE.Controls.Add(rTwF7rPJR8);
		MpyFCw9rSE.Controls.Add(wJlFACToX7);
		MpyFCw9rSE.Controls.Add(GVoFd05unG);
		MpyFCw9rSE.Dock = DockStyle.Fill;
		MpyFCw9rSE.Location = new Point(3, 71);
		MpyFCw9rSE.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(56510);
		MpyFCw9rSE.SelectedIndex = 0;
		MpyFCw9rSE.Size = new Size(356, 390);
		MpyFCw9rSE.TabIndex = 10;
		rTwF7rPJR8.Controls.Add(bF4Fjy9DUg);
		rTwF7rPJR8.Location = new Point(4, 22);
		rTwF7rPJR8.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(56536);
		rTwF7rPJR8.Padding = new Padding(3);
		rTwF7rPJR8.Size = new Size(348, 364);
		rTwF7rPJR8.TabIndex = 0;
		rTwF7rPJR8.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11830);
		rTwF7rPJR8.UseVisualStyleBackColor = true;
		bF4Fjy9DUg.BackColor = SystemColors.Window;
		bF4Fjy9DUg.Dock = DockStyle.Fill;
		bF4Fjy9DUg.Location = new Point(3, 3);
		bF4Fjy9DUg.Multiline = true;
		bF4Fjy9DUg.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(61158);
		bF4Fjy9DUg.ReadOnly = true;
		bF4Fjy9DUg.ScrollBars = ScrollBars.Vertical;
		bF4Fjy9DUg.Size = new Size(342, 358);
		bF4Fjy9DUg.TabIndex = 0;
		wJlFACToX7.Controls.Add(ExSF8TbWwg);
		wJlFACToX7.Location = new Point(4, 22);
		wJlFACToX7.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57098);
		wJlFACToX7.Padding = new Padding(3);
		wJlFACToX7.Size = new Size(348, 364);
		wJlFACToX7.TabIndex = 1;
		wJlFACToX7.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(59792);
		wJlFACToX7.UseVisualStyleBackColor = true;
		ExSF8TbWwg.BackColor = Color.White;
		ExSF8TbWwg.Dock = DockStyle.Fill;
		ExSF8TbWwg.Location = new Point(3, 3);
		ExSF8TbWwg.Multiline = true;
		ExSF8TbWwg.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(61192);
		ExSF8TbWwg.ReadOnly = true;
		ExSF8TbWwg.ScrollBars = ScrollBars.Vertical;
		ExSF8TbWwg.Size = new Size(342, 358);
		ExSF8TbWwg.TabIndex = 0;
		GVoFd05unG.Controls.Add(KnsF5C1E8q);
		GVoFd05unG.Location = new Point(4, 22);
		GVoFd05unG.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15898);
		GVoFd05unG.Padding = new Padding(3);
		GVoFd05unG.Size = new Size(348, 364);
		GVoFd05unG.TabIndex = 2;
		GVoFd05unG.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15976);
		GVoFd05unG.UseVisualStyleBackColor = true;
		KnsF5C1E8q.BackColor = Color.White;
		KnsF5C1E8q.Dock = DockStyle.Fill;
		KnsF5C1E8q.Location = new Point(3, 3);
		KnsF5C1E8q.Multiline = true;
		KnsF5C1E8q.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(61228);
		KnsF5C1E8q.ReadOnly = true;
		KnsF5C1E8q.ScrollBars = ScrollBars.Vertical;
		KnsF5C1E8q.Size = new Size(342, 358);
		KnsF5C1E8q.TabIndex = 7;
		JFfFH0g68O.Dock = DockStyle.Right;
		JFfFH0g68O.Location = new Point(213, 468);
		JFfFH0g68O.Margin = new Padding(0, 4, 6, 0);
		JFfFH0g68O.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(61246);
		JFfFH0g68O.Size = new Size(143, 26);
		JFfFH0g68O.TabIndex = 1;
		JFfFH0g68O.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(61270);
		JFfFH0g68O.UseVisualStyleBackColor = true;
		JFfFH0g68O.Click += P5cFaPgt5P;
		IJnFkR4yBY.Items.AddRange(new ToolStripItem[1] { KQrFYWNArn });
		IJnFkR4yBY.Location = new Point(0, 0);
		IJnFkR4yBY.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26656);
		IJnFkR4yBY.Size = new Size(830, 24);
		IJnFkR4yBY.TabIndex = 1;
		IJnFkR4yBY.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26656);
		KQrFYWNArn.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(61316);
		KQrFYWNArn.Size = new Size(41, 20);
		KQrFYWNArn.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28934);
		KQrFYWNArn.Click += FPNFKXHPds;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(830, 528);
		base.Controls.Add(KvkFPgKRmw);
		base.Controls.Add(IJnFkR4yBY);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(61354);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(61354);
		base.Load += vFlFMLZZ2C;
		KvkFPgKRmw.Panel1.ResumeLayout(performLayout: false);
		KvkFPgKRmw.Panel2.ResumeLayout(performLayout: false);
		((ISupportInitialize)KvkFPgKRmw).EndInit();
		KvkFPgKRmw.ResumeLayout(performLayout: false);
		w9XFuoaRXe.ResumeLayout(performLayout: false);
		mI9F6jkXVE.ResumeLayout(performLayout: false);
		QqjFFKoaFF.ResumeLayout(performLayout: false);
		QqjFFKoaFF.PerformLayout();
		jEbF12wnRT.ResumeLayout(performLayout: false);
		jEbF12wnRT.PerformLayout();
		MpyFCw9rSE.ResumeLayout(performLayout: false);
		rTwF7rPJR8.ResumeLayout(performLayout: false);
		rTwF7rPJR8.PerformLayout();
		wJlFACToX7.ResumeLayout(performLayout: false);
		wJlFACToX7.PerformLayout();
		GVoFd05unG.ResumeLayout(performLayout: false);
		GVoFd05unG.PerformLayout();
		IJnFkR4yBY.ResumeLayout(performLayout: false);
		IJnFkR4yBY.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
