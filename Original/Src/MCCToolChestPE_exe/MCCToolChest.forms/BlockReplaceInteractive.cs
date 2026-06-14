using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using HiT3kduFNLtRQIR37JV;
using MCCToolChest.MCSBCode;
using MCCToolChest.model;
using MCCToolChest.Properties;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.forms;

public class BlockReplaceInteractive : Form
{
	private Timer MTpkj1Se5d;

	private string FNKk8h2V8X;

	private bool sW5k92xRq1;

	private BackgroundWorker qqqkIXDKgH;

	private BackgroundWorker vLHkzEiQhV;

	private IContainer CsBYTJA1n9;

	private TableLayoutPanel sDKYSbEt6L;

	private Panel OXjYGS9Rso;

	private Button bcfYbJKGAN;

	private TextBox joUYv2SNbr;

	private TextBox lGsYw5fe5K;

	private ListView YX2Y4kTMmn;

	private ColumnHeader IYTYV4axd1;

	private ColumnHeader kUGYWPCfBR;

	private ColumnHeader TAmYped0A0;

	private ColumnHeader AuUYZFk8Ah;

	private ColumnHeader AZJYfeBDQY;

	private ColumnHeader a5QYipwnbA;

	private StatusStrip rbcYsyvOK8;

	private ToolStripStatusLabel mE2Yqw9wtK;

	private Panel A8lYKmwkd3;

	private Button WCmYhZ46XD;

	private TextBox NMcYmCH3Ur;

	private TextBox aKtYnFmhIx;

	private ColumnHeader wyHYl28tw7;

	private ColumnHeader hSSY2djK74;

	private ComboBox m61YyBOxsm;

	private ComboBox en3Y0GxPRk;

	private ProgressBar mqmYBZPNaJ;

	private ProgressBar NkTYtddgAF;

	private ToolStripStatusLabel lnYYaN9AQe;

	private ToolStripStatusLabel oZMYXQNsMT;

	private Label auZYxLm9fd;

	private Label GX4Yeq74Ai;

	private Panel WGOYMaLlbV;

	private Label SIvYUqZZnD;

	private ComboBox X4FYLXch6S;

	private Label o2qYgFs4MY;

	private Label z03YP3xapC;

	private ImageList tKqYRE9k22;

	[CompilerGenerated]
	private static Func<BlockSearchResult, int> V4PYkDV4JM;

	[CompilerGenerated]
	private static Func<BlockSearchResult, int> yyVYY1bEaU;

	[CompilerGenerated]
	private static Func<BlockSearchResult, int> e5DY3PcRUu;

	[CompilerGenerated]
	private static Func<BlockSearchResult, int> VkUY1Lbvnh;

	[CompilerGenerated]
	private static Func<BlockSearchResult, int> QlFYE7f64Y;

	[CompilerGenerated]
	private static Func<BlockSearchResult, int> EBCYrgihcs;

	[CompilerGenerated]
	private static Func<BlockSearchResult, int> lTqY5cuubh;

	[CompilerGenerated]
	private static Func<BlockSearchResult, int> Kq4Y6cLErS;

	[CompilerGenerated]
	private static Func<BlockSearchResult, int> zVyYNWl9LS;

	[CompilerGenerated]
	private static Func<BlockSearchResult, int> guXYDFnGm4;

	[CompilerGenerated]
	private static Func<BlockSearchResult, int> GdLYcPBi6k;

	[CompilerGenerated]
	private static Func<BlockSearchResult, int> vvOYJsgW0T;

	public bool ChangesMade
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return sW5k92xRq1;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			sW5k92xRq1 = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BlockReplaceInteractive(string workingFolder)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		MTpkj1Se5d = new Timer();
		qqqkIXDKgH = new BackgroundWorker();
		vLHkzEiQhV = new BackgroundWorker();
		nEtkDOqy1S();
		FNKk8h2V8X = workingFolder;
		qNOkwt1vWg();
		qqukaZyqE9();
		dWFkRiPiEW();
		wcnkEkHgYP();
		sB3krTP2Ii();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void qNOkwt1vWg()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		m61YyBOxsm.ValueMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10770);
		m61YyBOxsm.DisplayMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11102);
		m61YyBOxsm.DataSource = INYifyudg3hCpcrleHt.GKBS0K4re36().ToList();
		en3Y0GxPRk.ValueMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10770);
		en3Y0GxPRk.DisplayMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11102);
		en3Y0GxPRk.DataSource = INYifyudg3hCpcrleHt.GKBS0K4re36().ToList();
		X4FYLXch6S.ValueMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10936);
		X4FYLXch6S.DisplayMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11118);
		X4FYLXch6S.DataSource = new BindingSource(Constants.dimensionNames, null);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int QWek42jHGt(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int result = 0;
		int.TryParse(P_0, out result);
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void K7TkVtGeVA(Dictionary<string, List<BlockSearchResult>> P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Lcok35DnW4();
		foreach (string key in P_0.Keys)
		{
			List<BlockSearchResult> list = p3ekWrQVD1(key, P_0[key]);
			if (list == null)
			{
				continue;
			}
			foreach (BlockSearchResult item in list)
			{
				BakkpQschx(item);
			}
		}
		wcnkEkHgYP();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<BlockSearchResult> p3ekWrQVD1(string P_0, List<BlockSearchResult> P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<BlockSearchResult> result = null;
		if (P_1 != null)
		{
			if (P_0 == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22076))
			{
				result = P_1.OrderBy([MethodImpl(MethodImplOptions.NoInlining)] (BlockSearchResult blockSearchResult) =>
				{
					while (false)
					{
						_ = ((object[])null)[0];
					}
					return blockSearchResult.ChunkX;
				}).ThenBy([MethodImpl(MethodImplOptions.NoInlining)] (BlockSearchResult blockSearchResult) =>
				{
					while (false)
					{
						_ = ((object[])null)[0];
					}
					return blockSearchResult.ChunkZ;
				}).ThenByDescending([MethodImpl(MethodImplOptions.NoInlining)] (BlockSearchResult blockSearchResult) =>
				{
					while (false)
					{
						_ = ((object[])null)[0];
					}
					return blockSearchResult.Y;
				})
					.ToList();
			}
			if (P_0 == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21996))
			{
				result = P_1.OrderBy([MethodImpl(MethodImplOptions.NoInlining)] (BlockSearchResult blockSearchResult) =>
				{
					while (false)
					{
						_ = ((object[])null)[0];
					}
					return blockSearchResult.ChunkX;
				}).ThenByDescending([MethodImpl(MethodImplOptions.NoInlining)] (BlockSearchResult blockSearchResult) =>
				{
					while (false)
					{
						_ = ((object[])null)[0];
					}
					return blockSearchResult.ChunkZ;
				}).ThenByDescending([MethodImpl(MethodImplOptions.NoInlining)] (BlockSearchResult blockSearchResult) =>
				{
					while (false)
					{
						_ = ((object[])null)[0];
					}
					return blockSearchResult.Y;
				})
					.ToList();
			}
			if (P_0 == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22036))
			{
				result = P_1.OrderByDescending([MethodImpl(MethodImplOptions.NoInlining)] (BlockSearchResult blockSearchResult) =>
				{
					while (false)
					{
						_ = ((object[])null)[0];
					}
					return blockSearchResult.ChunkX;
				}).ThenBy([MethodImpl(MethodImplOptions.NoInlining)] (BlockSearchResult blockSearchResult) =>
				{
					while (false)
					{
						_ = ((object[])null)[0];
					}
					return blockSearchResult.ChunkZ;
				}).ThenByDescending([MethodImpl(MethodImplOptions.NoInlining)] (BlockSearchResult blockSearchResult) =>
				{
					while (false)
					{
						_ = ((object[])null)[0];
					}
					return blockSearchResult.Y;
				})
					.ToList();
			}
			if (P_0 == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21952))
			{
				result = P_1.OrderByDescending([MethodImpl(MethodImplOptions.NoInlining)] (BlockSearchResult blockSearchResult) =>
				{
					while (false)
					{
						_ = ((object[])null)[0];
					}
					return blockSearchResult.ChunkX;
				}).ThenByDescending([MethodImpl(MethodImplOptions.NoInlining)] (BlockSearchResult blockSearchResult) =>
				{
					while (false)
					{
						_ = ((object[])null)[0];
					}
					return blockSearchResult.ChunkZ;
				}).ThenByDescending([MethodImpl(MethodImplOptions.NoInlining)] (BlockSearchResult blockSearchResult) =>
				{
					while (false)
					{
						_ = ((object[])null)[0];
					}
					return blockSearchResult.Y;
				})
					.ToList();
			}
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BakkpQschx(BlockSearchResult P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ListViewItem listViewItem = new ListViewItem();
		listViewItem.Text = "";
		listViewItem.SubItems.Add(P_0.Dimension);
		listViewItem.SubItems.Add(P_0.Region);
		listViewItem.SubItems.Add(P_0.ChunkString());
		listViewItem.SubItems.Add(P_0.BlockPositionString());
		listViewItem.SubItems.Add(INYifyudg3hCpcrleHt.zhkS0lPoAGR()[P_0.Id].IdName);
		listViewItem.SubItems.Add(P_0.Data.ToString());
		listViewItem.SubItems.Add(P_0.Light.ToString());
		listViewItem.Tag = P_0;
		YX2Y4kTMmn.Items.Add(listViewItem);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Qn0kZwauv4(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!qqqkIXDKgH.IsBusy && !vLHkzEiQhV.IsBusy)
		{
			metkXLWaEX();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void jDskfMuE9c(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!qqqkIXDKgH.IsBusy && !vLHkzEiQhV.IsBusy)
		{
			zF6kUe1Xcq();
			sW5k92xRq1 = true;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void NMCkiPsKat(object P_0, ListViewItemSelectionChangedEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void lu0ksUolYu(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void QkkkqKjvl5(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void u7tkKt4mvX(object P_0, MouseEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		EngkkUMRVN();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void oNTkh2fRtU(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (m61YyBOxsm.SelectedValue != null)
		{
			lGsYw5fe5K.Text = m61YyBOxsm.SelectedValue.ToString();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void xqWkmICwud(object P_0, KeyEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		m61YyBOxsm.SelectedValue = QWek42jHGt(lGsYw5fe5K.Text);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void bL9knNAAML(object P_0, KeyEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		en3Y0GxPRk.SelectedValue = QWek42jHGt(aKtYnFmhIx.Text);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void JrbklY4fy5(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (en3Y0GxPRk.SelectedValue != null)
		{
			aKtYnFmhIx.Text = en3Y0GxPRk.SelectedValue.ToString();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void jrfk2ukqQi(object P_0, FormClosingEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (qqqkIXDKgH.IsBusy || vLHkzEiQhV.IsBusy)
		{
			P_1.Cancel = true;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void bEbkyOKKac(object P_0, DrawListViewColumnHeaderEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_1.ColumnIndex == 0)
		{
			CheckBox checkBox = new CheckBox();
			Text = "";
			base.Visible = true;
			YX2Y4kTMmn.SuspendLayout();
			P_1.DrawBackground();
			checkBox.BackColor = Color.Transparent;
			checkBox.UseVisualStyleBackColor = true;
			checkBox.SetBounds(P_1.Bounds.X, P_1.Bounds.Y, checkBox.GetPreferredSize(new Size(P_1.Bounds.Width, P_1.Bounds.Height)).Width, checkBox.GetPreferredSize(new Size(P_1.Bounds.Width, P_1.Bounds.Height)).Width);
			checkBox.Size = new Size(checkBox.GetPreferredSize(new Size(P_1.Bounds.Width - 1, P_1.Bounds.Height)).Width + 1, P_1.Bounds.Height);
			checkBox.Location = new Point(3, 0);
			YX2Y4kTMmn.Controls.Add(checkBox);
			checkBox.Show();
			checkBox.BringToFront();
			P_1.DrawText(TextFormatFlags.VerticalCenter);
			checkBox.Click += daDktcWFpB;
			YX2Y4kTMmn.ResumeLayout(performLayout: true);
		}
		else
		{
			P_1.DrawDefault = true;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void g2fk0yiSR0(object P_0, DrawListViewItemEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_1.DrawDefault = true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SUbkBhK19t(object P_0, DrawListViewSubItemEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_1.DrawDefault = true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void daDktcWFpB(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		CheckBox checkBox = P_0 as CheckBox;
		for (int i = 0; i < YX2Y4kTMmn.Items.Count; i++)
		{
			YX2Y4kTMmn.Items[i].Checked = checkBox.Checked;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void qqukaZyqE9()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		qqqkIXDKgH.DoWork += edPkxGKXub;
		qqqkIXDKgH.ProgressChanged += ltxkeSWPvY;
		qqqkIXDKgH.RunWorkerCompleted += kIjkMA6vKx;
		qqqkIXDKgH.WorkerReportsProgress = true;
		vLHkzEiQhV.DoWork += e3ikLGvyQe;
		vLHkzEiQhV.ProgressChanged += LqLkgNukWP;
		vLHkzEiQhV.RunWorkerCompleted += TVAkPAGruU;
		vLHkzEiQhV.WorkerReportsProgress = true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void metkXLWaEX()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string dimension = (string)X4FYLXch6S.SelectedValue;
		Block block = new Block();
		block.Id = QWek42jHGt(lGsYw5fe5K.Text);
		block.Data = QWek42jHGt(joUYv2SNbr.Text);
		SearchBlockParameter searchBlockParameter = new SearchBlockParameter();
		searchBlockParameter.OutFolderPath = FNKk8h2V8X;
		searchBlockParameter.Dimension = dimension;
		searchBlockParameter.SearchBlock = block;
		qqqkIXDKgH.RunWorkerAsync(searchBlockParameter);
		Lcok35DnW4();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void edPkxGKXub(object P_0, DoWorkEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BackgroundWorker backgroundWorker = P_0 as BackgroundWorker;
		SearchBlockParameter searchBlockParameter = P_1.Argument as SearchBlockParameter;
		SearchBlockWorker searchBlockWorker = new SearchBlockWorker(backgroundWorker);
		Dictionary<string, List<BlockSearchResult>> result = searchBlockWorker.DoSearch(searchBlockParameter.SearchBlock, searchBlockParameter.Dimension, searchBlockParameter.OutFolderPath);
		P_1.Result = result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ltxkeSWPvY(object P_0, ProgressChangedEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		oZMYXQNsMT.Text = P_1.UserState as string;
		if (P_1.ProgressPercentage > 0)
		{
			mqmYBZPNaJ.Value = P_1.ProgressPercentage;
		}
		mqmYBZPNaJ.Refresh();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void kIjkMA6vKx(object P_0, RunWorkerCompletedEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		mqmYBZPNaJ.Value = 0;
		if (P_1.Result != null && P_1.Result is Dictionary<string, List<BlockSearchResult>>)
		{
			K7TkVtGeVA(P_1.Result as Dictionary<string, List<BlockSearchResult>>);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void zF6kUe1Xcq()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ListView.CheckedListViewItemCollection checkedItems = YX2Y4kTMmn.CheckedItems;
		List<BlockSearchResult> list = new List<BlockSearchResult>();
		foreach (ListViewItem item in checkedItems)
		{
			list.Add(item.Tag as BlockSearchResult);
		}
		Block block = new Block();
		block.Id = QWek42jHGt(aKtYnFmhIx.Text);
		block.Data = QWek42jHGt(NMcYmCH3Ur.Text);
		ReplaceBlockParameter argument = new ReplaceBlockParameter(block, list, FNKk8h2V8X);
		vLHkzEiQhV.RunWorkerAsync(argument);
		YX2Y4kTMmn.Enabled = false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void e3ikLGvyQe(object P_0, DoWorkEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BackgroundWorker backgroundWorker = P_0 as BackgroundWorker;
		ReplaceBlockParameter replaceBlockParameter = P_1.Argument as ReplaceBlockParameter;
		ReplaceBlockWorker replaceBlockWorker = new ReplaceBlockWorker(backgroundWorker);
		replaceBlockWorker.DoReplace(replaceBlockParameter.ReplacementBlock, replaceBlockParameter.ReplaceBlockList, replaceBlockParameter.OutFolderPath);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LqLkgNukWP(object P_0, ProgressChangedEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		oZMYXQNsMT.Text = P_1.UserState as string;
		if (P_1.ProgressPercentage > 0)
		{
			NkTYtddgAF.Value = P_1.ProgressPercentage;
		}
		NkTYtddgAF.Refresh();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TVAkPAGruU(object P_0, RunWorkerCompletedEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		NkTYtddgAF.Value = 0;
		ListView.CheckedListViewItemCollection checkedItems = YX2Y4kTMmn.CheckedItems;
		foreach (ListViewItem item in checkedItems)
		{
			YX2Y4kTMmn.Items.Remove(item);
		}
		YX2Y4kTMmn.Enabled = true;
		n73k1OR6Yi();
		oZMYXQNsMT.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37010);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void dWFkRiPiEW()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MTpkj1Se5d.Interval = 100;
		MTpkj1Se5d.Enabled = true;
		MTpkj1Se5d.Tick += xaRkYNMNpq;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EngkkUMRVN()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MTpkj1Se5d.Start();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void xaRkYNMNpq(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MTpkj1Se5d.Stop();
		sB3krTP2Ii();
		HyCk5O5IiZ();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Lcok35DnW4()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		YX2Y4kTMmn.Items.Clear();
		n73k1OR6Yi();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void n73k1OR6Yi()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		wcnkEkHgYP();
		sB3krTP2Ii();
		HyCk5O5IiZ();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void wcnkEkHgYP()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		mE2Yqw9wtK.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37322) + YX2Y4kTMmn.Items.Count;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void sB3krTP2Ii()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		lnYYaN9AQe.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37342) + YX2Y4kTMmn.CheckedItems.Count;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HyCk5O5IiZ()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (YX2Y4kTMmn.Items.Count > 0 && YX2Y4kTMmn.Items.Count == YX2Y4kTMmn.CheckedItems.Count)
		{
			YX2Y4kTMmn.Columns[0].ImageIndex = 1;
		}
		else
		{
			YX2Y4kTMmn.Columns[0].ImageIndex = 0;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EFik69PuET(object P_0, ColumnClickEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = 0;
		Point point = YX2Y4kTMmn.PointToClient(Control.MousePosition);
		ListViewHitTestInfo listViewHitTestInfo = YX2Y4kTMmn.HitTest(point);
		if (listViewHitTestInfo != null && listViewHitTestInfo.Item != null)
		{
			num = listViewHitTestInfo.Item.SubItems.IndexOf(listViewHitTestInfo.SubItem);
		}
		if (num != 0)
		{
			return;
		}
		bool flag = true;
		if (YX2Y4kTMmn.Items.Count == YX2Y4kTMmn.CheckedItems.Count)
		{
			flag = false;
		}
		foreach (ListViewItem item in YX2Y4kTMmn.Items)
		{
			item.Checked = flag;
		}
		sB3krTP2Ii();
		HyCk5O5IiZ();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LQQkN5jnt2(object P_0, EventArgs P_1)
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
		if (disposing && CsBYTJA1n9 != null)
		{
			CsBYTJA1n9.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void nEtkDOqy1S()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		CsBYTJA1n9 = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(BlockReplaceInteractive));
		sDKYSbEt6L = new TableLayoutPanel();
		OXjYGS9Rso = new Panel();
		o2qYgFs4MY = new Label();
		auZYxLm9fd = new Label();
		mqmYBZPNaJ = new ProgressBar();
		m61YyBOxsm = new ComboBox();
		bcfYbJKGAN = new Button();
		joUYv2SNbr = new TextBox();
		lGsYw5fe5K = new TextBox();
		YX2Y4kTMmn = new ListView();
		hSSY2djK74 = new ColumnHeader();
		IYTYV4axd1 = new ColumnHeader();
		kUGYWPCfBR = new ColumnHeader();
		TAmYped0A0 = new ColumnHeader();
		wyHYl28tw7 = new ColumnHeader();
		AuUYZFk8Ah = new ColumnHeader();
		AZJYfeBDQY = new ColumnHeader();
		a5QYipwnbA = new ColumnHeader();
		tKqYRE9k22 = new ImageList(CsBYTJA1n9);
		A8lYKmwkd3 = new Panel();
		z03YP3xapC = new Label();
		GX4Yeq74Ai = new Label();
		NkTYtddgAF = new ProgressBar();
		en3Y0GxPRk = new ComboBox();
		WCmYhZ46XD = new Button();
		NMcYmCH3Ur = new TextBox();
		aKtYnFmhIx = new TextBox();
		WGOYMaLlbV = new Panel();
		X4FYLXch6S = new ComboBox();
		SIvYUqZZnD = new Label();
		rbcYsyvOK8 = new StatusStrip();
		mE2Yqw9wtK = new ToolStripStatusLabel();
		lnYYaN9AQe = new ToolStripStatusLabel();
		oZMYXQNsMT = new ToolStripStatusLabel();
		sDKYSbEt6L.SuspendLayout();
		OXjYGS9Rso.SuspendLayout();
		A8lYKmwkd3.SuspendLayout();
		WGOYMaLlbV.SuspendLayout();
		rbcYsyvOK8.SuspendLayout();
		SuspendLayout();
		sDKYSbEt6L.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		sDKYSbEt6L.ColumnCount = 1;
		sDKYSbEt6L.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		sDKYSbEt6L.Controls.Add(OXjYGS9Rso, 0, 1);
		sDKYSbEt6L.Controls.Add(YX2Y4kTMmn, 0, 3);
		sDKYSbEt6L.Controls.Add(A8lYKmwkd3, 0, 2);
		sDKYSbEt6L.Controls.Add(WGOYMaLlbV, 0, 0);
		sDKYSbEt6L.Location = new Point(0, 0);
		sDKYSbEt6L.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10826);
		sDKYSbEt6L.RowCount = 4;
		sDKYSbEt6L.RowStyles.Add(new RowStyle(SizeType.Absolute, 40f));
		sDKYSbEt6L.RowStyles.Add(new RowStyle(SizeType.Absolute, 40f));
		sDKYSbEt6L.RowStyles.Add(new RowStyle(SizeType.Absolute, 40f));
		sDKYSbEt6L.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		sDKYSbEt6L.Size = new Size(685, 542);
		sDKYSbEt6L.TabIndex = 0;
		OXjYGS9Rso.Controls.Add(o2qYgFs4MY);
		OXjYGS9Rso.Controls.Add(auZYxLm9fd);
		OXjYGS9Rso.Controls.Add(mqmYBZPNaJ);
		OXjYGS9Rso.Controls.Add(m61YyBOxsm);
		OXjYGS9Rso.Controls.Add(bcfYbJKGAN);
		OXjYGS9Rso.Controls.Add(joUYv2SNbr);
		OXjYGS9Rso.Controls.Add(lGsYw5fe5K);
		OXjYGS9Rso.Dock = DockStyle.Fill;
		OXjYGS9Rso.Location = new Point(3, 43);
		OXjYGS9Rso.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10398);
		OXjYGS9Rso.Size = new Size(679, 34);
		OXjYGS9Rso.TabIndex = 0;
		o2qYgFs4MY.AutoSize = true;
		o2qYgFs4MY.Location = new Point(10, 11);
		o2qYgFs4MY.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12846);
		o2qYgFs4MY.Size = new Size(34, 13);
		o2qYgFs4MY.TabIndex = 6;
		o2qYgFs4MY.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11032);
		auZYxLm9fd.AutoSize = true;
		auZYxLm9fd.Location = new Point(275, 9);
		auZYxLm9fd.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		auZYxLm9fd.Size = new Size(30, 13);
		auZYxLm9fd.TabIndex = 5;
		auZYxLm9fd.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11178);
		mqmYBZPNaJ.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		mqmYBZPNaJ.Location = new Point(438, 5);
		mqmYBZPNaJ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37366);
		mqmYBZPNaJ.Size = new Size(232, 23);
		mqmYBZPNaJ.TabIndex = 4;
		m61YyBOxsm.DropDownStyle = ComboBoxStyle.DropDownList;
		m61YyBOxsm.FormattingEnabled = true;
		m61YyBOxsm.Location = new Point(94, 5);
		m61YyBOxsm.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37404);
		m61YyBOxsm.Size = new Size(174, 21);
		m61YyBOxsm.TabIndex = 3;
		m61YyBOxsm.SelectedIndexChanged += oNTkh2fRtU;
		bcfYbJKGAN.Location = new Point(371, 5);
		bcfYbJKGAN.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37432);
		bcfYbJKGAN.Size = new Size(60, 23);
		bcfYbJKGAN.TabIndex = 2;
		bcfYbJKGAN.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37454);
		bcfYbJKGAN.UseVisualStyleBackColor = true;
		bcfYbJKGAN.Click += Qn0kZwauv4;
		joUYv2SNbr.Location = new Point(307, 7);
		joUYv2SNbr.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37470);
		joUYv2SNbr.Size = new Size(56, 20);
		joUYv2SNbr.TabIndex = 1;
		joUYv2SNbr.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10708);
		lGsYw5fe5K.Location = new Point(47, 6);
		lGsYw5fe5K.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37498);
		lGsYw5fe5K.Size = new Size(45, 20);
		lGsYw5fe5K.TabIndex = 0;
		lGsYw5fe5K.KeyUp += xqWkmICwud;
		YX2Y4kTMmn.CheckBoxes = true;
		YX2Y4kTMmn.Columns.AddRange(new ColumnHeader[8] { hSSY2djK74, IYTYV4axd1, kUGYWPCfBR, TAmYped0A0, wyHYl28tw7, AuUYZFk8Ah, AZJYfeBDQY, a5QYipwnbA });
		YX2Y4kTMmn.Dock = DockStyle.Fill;
		YX2Y4kTMmn.FullRowSelect = true;
		YX2Y4kTMmn.HideSelection = false;
		YX2Y4kTMmn.LargeImageList = tKqYRE9k22;
		YX2Y4kTMmn.Location = new Point(3, 123);
		YX2Y4kTMmn.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37528);
		YX2Y4kTMmn.Size = new Size(679, 416);
		YX2Y4kTMmn.SmallImageList = tKqYRE9k22;
		YX2Y4kTMmn.TabIndex = 1;
		YX2Y4kTMmn.UseCompatibleStateImageBehavior = false;
		YX2Y4kTMmn.View = View.Details;
		YX2Y4kTMmn.ColumnClick += EFik69PuET;
		YX2Y4kTMmn.ItemSelectionChanged += NMCkiPsKat;
		YX2Y4kTMmn.SelectedIndexChanged += lu0ksUolYu;
		YX2Y4kTMmn.Click += QkkkqKjvl5;
		YX2Y4kTMmn.MouseUp += u7tkKt4mvX;
		hSSY2djK74.Text = "";
		hSSY2djK74.Width = 30;
		IYTYV4axd1.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37092);
		IYTYV4axd1.Width = 80;
		kUGYWPCfBR.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21126);
		kUGYWPCfBR.Width = 80;
		TAmYped0A0.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37572);
		TAmYped0A0.Width = 80;
		wyHYl28tw7.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37596);
		wyHYl28tw7.Width = 100;
		AuUYZFk8Ah.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11032);
		AuUYZFk8Ah.Width = 150;
		AZJYfeBDQY.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11178);
		a5QYipwnbA.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37626);
		a5QYipwnbA.Width = 59;
		tKqYRE9k22.ImageStream = (ImageListStreamer)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23886));
		tKqYRE9k22.TransparentColor = Color.Transparent;
		tKqYRE9k22.Images.SetKeyName(0, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37650));
		tKqYRE9k22.Images.SetKeyName(1, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37698));
		A8lYKmwkd3.Controls.Add(z03YP3xapC);
		A8lYKmwkd3.Controls.Add(GX4Yeq74Ai);
		A8lYKmwkd3.Controls.Add(NkTYtddgAF);
		A8lYKmwkd3.Controls.Add(en3Y0GxPRk);
		A8lYKmwkd3.Controls.Add(WCmYhZ46XD);
		A8lYKmwkd3.Controls.Add(NMcYmCH3Ur);
		A8lYKmwkd3.Controls.Add(aKtYnFmhIx);
		A8lYKmwkd3.Dock = DockStyle.Fill;
		A8lYKmwkd3.Location = new Point(3, 83);
		A8lYKmwkd3.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11356);
		A8lYKmwkd3.Size = new Size(679, 34);
		A8lYKmwkd3.TabIndex = 2;
		z03YP3xapC.AutoSize = true;
		z03YP3xapC.Location = new Point(10, 12);
		z03YP3xapC.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11162);
		z03YP3xapC.Size = new Size(34, 13);
		z03YP3xapC.TabIndex = 7;
		z03YP3xapC.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11032);
		GX4Yeq74Ai.AutoSize = true;
		GX4Yeq74Ai.Location = new Point(274, 10);
		GX4Yeq74Ai.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10582);
		GX4Yeq74Ai.Size = new Size(30, 13);
		GX4Yeq74Ai.TabIndex = 6;
		GX4Yeq74Ai.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11178);
		NkTYtddgAF.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		NkTYtddgAF.Location = new Point(439, 4);
		NkTYtddgAF.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37136);
		NkTYtddgAF.Size = new Size(231, 23);
		NkTYtddgAF.TabIndex = 5;
		en3Y0GxPRk.DropDownStyle = ComboBoxStyle.DropDownList;
		en3Y0GxPRk.FormattingEnabled = true;
		en3Y0GxPRk.Location = new Point(94, 6);
		en3Y0GxPRk.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37742);
		en3Y0GxPRk.Size = new Size(174, 21);
		en3Y0GxPRk.TabIndex = 4;
		en3Y0GxPRk.SelectedIndexChanged += JrbklY4fy5;
		WCmYhZ46XD.Location = new Point(371, 6);
		WCmYhZ46XD.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37196);
		WCmYhZ46XD.Size = new Size(61, 23);
		WCmYhZ46XD.TabIndex = 2;
		WCmYhZ46XD.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37220);
		WCmYhZ46XD.UseVisualStyleBackColor = true;
		WCmYhZ46XD.Click += jDskfMuE9c;
		NMcYmCH3Ur.Location = new Point(307, 7);
		NMcYmCH3Ur.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37774);
		NMcYmCH3Ur.Size = new Size(56, 20);
		NMcYmCH3Ur.TabIndex = 1;
		NMcYmCH3Ur.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10708);
		aKtYnFmhIx.Location = new Point(47, 7);
		aKtYnFmhIx.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37804);
		aKtYnFmhIx.Size = new Size(45, 20);
		aKtYnFmhIx.TabIndex = 0;
		aKtYnFmhIx.KeyUp += bL9knNAAML;
		WGOYMaLlbV.Controls.Add(X4FYLXch6S);
		WGOYMaLlbV.Controls.Add(SIvYUqZZnD);
		WGOYMaLlbV.Dock = DockStyle.Fill;
		WGOYMaLlbV.Location = new Point(3, 3);
		WGOYMaLlbV.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11404);
		WGOYMaLlbV.Size = new Size(679, 34);
		WGOYMaLlbV.TabIndex = 3;
		X4FYLXch6S.DropDownStyle = ComboBoxStyle.DropDownList;
		X4FYLXch6S.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
		X4FYLXch6S.FormattingEnabled = true;
		X4FYLXch6S.Location = new Point(94, 6);
		X4FYLXch6S.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37176);
		X4FYLXch6S.Size = new Size(101, 23);
		X4FYLXch6S.TabIndex = 2;
		SIvYUqZZnD.AutoSize = true;
		SIvYUqZZnD.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
		SIvYUqZZnD.Location = new Point(14, 10);
		SIvYUqZZnD.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10482);
		SIvYUqZZnD.Size = new Size(76, 15);
		SIvYUqZZnD.TabIndex = 0;
		SIvYUqZZnD.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37092);
		rbcYsyvOK8.Items.AddRange(new ToolStripItem[3] { mE2Yqw9wtK, lnYYaN9AQe, oZMYXQNsMT });
		rbcYsyvOK8.Location = new Point(0, 545);
		rbcYsyvOK8.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37836);
		rbcYsyvOK8.Size = new Size(685, 22);
		rbcYsyvOK8.TabIndex = 1;
		rbcYsyvOK8.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37836);
		mE2Yqw9wtK.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37864);
		mE2Yqw9wtK.Padding = new Padding(0, 0, 10, 0);
		mE2Yqw9wtK.Size = new Size(10, 17);
		lnYYaN9AQe.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37910);
		lnYYaN9AQe.Padding = new Padding(0, 0, 10, 0);
		lnYYaN9AQe.Size = new Size(10, 17);
		oZMYXQNsMT.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37960);
		oZMYXQNsMT.Padding = new Padding(0, 0, 10, 0);
		oZMYXQNsMT.Size = new Size(10, 17);
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(685, 567);
		base.Controls.Add(rbcYsyvOK8);
		base.Controls.Add(sDKYSbEt6L);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37988);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38038);
		base.FormClosing += jrfk2ukqQi;
		base.Load += LQQkN5jnt2;
		sDKYSbEt6L.ResumeLayout(performLayout: false);
		OXjYGS9Rso.ResumeLayout(performLayout: false);
		OXjYGS9Rso.PerformLayout();
		A8lYKmwkd3.ResumeLayout(performLayout: false);
		A8lYKmwkd3.PerformLayout();
		WGOYMaLlbV.ResumeLayout(performLayout: false);
		WGOYMaLlbV.PerformLayout();
		rbcYsyvOK8.ResumeLayout(performLayout: false);
		rbcYsyvOK8.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static int YI8kca4VPk(BlockSearchResult P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0.ChunkX;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static int O8BkJRfxXw(BlockSearchResult P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0.ChunkZ;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static int tNTkugb7aP(BlockSearchResult P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0.Y;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static int dpDkoYCruL(BlockSearchResult P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0.ChunkX;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static int TbvkQ3qmMY(BlockSearchResult P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0.ChunkZ;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static int NVPkOvRlCk(BlockSearchResult P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0.Y;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static int TqNkCKxFiP(BlockSearchResult P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0.ChunkX;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static int bY9k7FbOPs(BlockSearchResult P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0.ChunkZ;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static int yWekAneyV1(BlockSearchResult P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0.Y;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static int aqNkdM4joY(BlockSearchResult P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0.ChunkX;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static int BVHkHZMsSa(BlockSearchResult P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0.ChunkZ;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static int VADkFq8hH4(BlockSearchResult P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0.Y;
	}
}
