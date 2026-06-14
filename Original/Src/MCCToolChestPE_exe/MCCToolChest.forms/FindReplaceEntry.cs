using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using MCCToolChest.controls;
using MCCToolChest.MCSBCode;
using MCCToolChest.model;
using MCCToolChest.model.SearchReplace;
using MCCToolChest.Properties;
using MCCToolChest.utils;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.forms;

public class FindReplaceEntry : Form
{
	private string oniCNLBoHp;

	private SearchReplaceGroup bJECDF2ked;

	private SearchReplaceCriteria gstCclS5oA;

	private string APPCJMLsWE;

	private bool S40CufUFC6;

	public static Dictionary<string, string> matchCondition;

	private BackgroundWorker YwbCoNscLv;

	private bool EQ6CQ0PaRg;

	private bool XVwCOwMr1l;

	private Dictionary<string, List<EntitySearchResult>> A2cCCnJJlE;

	private IContainer fDwC7EILlL;

	private Panel omVCA757Dk;

	private Button eO7CdwRgkM;

	private Button GxZCHj9I9T;

	private ComboBox W5ICF6nnyx;

	private Label HLtCjdLFCO;

	private MatchList i6aC8kywcJ;

	private SplitContainer kPHC9OEpp6;

	private Label lP5CIpaaIi;

	private ComboBox a2XCzHrlxh;

	private Label t8V7TXt22I;

	private Button iab7SNXEpS;

	private ProgressBar d8B7GxO6Lq;

	private Label scd7bVswpT;

	private ReplaceList jum7vspi5r;

	private MenuStrip cD27wYBsG1;

	private ToolStripMenuItem zV374l3QSV;

	private ToolStripMenuItem Uxy7VXmV4W;

	private ToolStripSeparator IvG7Wx5wPC;

	private ToolStripMenuItem wP27pQHFvg;

	private Label nir7ZphfQA;

	private TextBox MXU7fKN1dd;

	private SplitContainer Jdh7imP1TP;

	private TreeView M4w7skLyM9;

	private Button bhW7q7Vaw2;

	private Button PUW7Kh8Ava;

	private ImageList OL87hnPo06;

	private Panel MkY7mLbAEF;

	private ToolStripMenuItem elC7nG9xRJ;

	private CheckBox wgn7lDbTd3;

	private TextBox FjT72guQhu;

	private Label fHR7ychvFb;

	private Button NaE70hEVhP;

	private Button oHn7BIV81U;

	private Panel oBN7t4gsRI;

	private TextBox H0i7atNPbF;

	private Label eLP7XBnuQS;

	private ToolStripMenuItem WFg7xBkOaM;

	private TabControl BN27eJ97yD;

	private TabPage OFi7MeQej6;

	private TextBox ctq7UGkXN2;

	private TabPage Tp97LPSjVe;

	private TabControl mN97gZctnn;

	private TabPage peG7PQAoQa;

	private TabPage ekT7R28Nof;

	private VariableList pMi7k5hbF0;

	private VariableList jqN7YfpEG7;

	private CheckBox eJG73gPjxK;

	public bool DataChanged
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return S40CufUFC6;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			S40CufUFC6 = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public FindReplaceEntry(string workingFolder)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		YwbCoNscLv = new BackgroundWorker();
		APPCJMLsWE = workingFolder;
		aGlC6BqI3x();
		mgjCTIukSe();
		bTwClg26qb();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void mgjCTIukSe()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		W5ICF6nnyx.ValueMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10936);
		W5ICF6nnyx.DisplayMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11118);
		W5ICF6nnyx.DataSource = new BindingSource(Constants.dimensionNames, null);
		a2XCzHrlxh.ValueMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10936);
		a2XCzHrlxh.DisplayMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11118);
		a2XCzHrlxh.DataSource = new BindingSource(matchCondition, null);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void lixCSqvJEP(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.Icon = Resources.usMSrbJo37S();
		QDPCGo6eLD();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void QDPCGo6eLD()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		SearchReplaceCriteria item = Ql1CbUeked();
		SearchReplaceGroup searchReplaceGroup = new SearchReplaceGroup();
		searchReplaceGroup.Items.Add(item);
		jFDCp4D2We(searchReplaceGroup);
		oniCNLBoHp = null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private SearchReplaceCriteria Ql1CbUeked()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		SearchReplaceCriteria searchReplaceCriteria = new SearchReplaceCriteria();
		searchReplaceCriteria.Conditions = new List<MatchCondition>
		{
			new MatchCondition("", Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57288), "")
		};
		searchReplaceCriteria.Values = new List<ReplaceValue>
		{
			new ReplaceValue("", Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9862), "")
		};
		return searchReplaceCriteria;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private SearchReplaceGroup td9CvcT22f()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bJECDF2ked.Variables = jqN7YfpEG7.GetVariables();
		t2VCwoW9U9();
		return bJECDF2ked;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void t2VCwoW9U9()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (gstCclS5oA != null)
		{
			SearchReplaceCriteria searchReplaceCriteria = gstCclS5oA;
			string text = a2XCzHrlxh.SelectedValue as string;
			searchReplaceCriteria.Name = FjT72guQhu.Text;
			searchReplaceCriteria.Active = wgn7lDbTd3.Checked;
			searchReplaceCriteria.NodeSelector = MXU7fKN1dd.Text;
			searchReplaceCriteria.MatchType = ((!(text == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57302))) ? ConditionMatchType.ANY : ConditionMatchType.ALL);
			searchReplaceCriteria.Conditions = i6aC8kywcJ.GetConditions();
			searchReplaceCriteria.Values = jum7vspi5r.GetReplacements();
			searchReplaceCriteria.Variables = pMi7k5hbF0.GetVariables();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ovhC4kOUdj(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TlmC2jiBm9();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BCqCVimSsR(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		QDPCGo6eLD();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PFECW0HluX(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		SearchReplaceGroup searchReplaceGroup = null;
		string text = Utils.SRGPath();
		string text2 = FileUtils.BugSgNoWh4E(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57312), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57324), text);
		if (!string.IsNullOrWhiteSpace(text2) && text2.ToLower().EndsWith(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57312)))
		{
			using (StreamReader streamReader = new StreamReader(text2))
			{
				string xml = streamReader.ReadToEnd();
				searchReplaceGroup = DataConversion.Deserialize<SearchReplaceGroup>(xml);
			}
			if (searchReplaceGroup != null)
			{
				jFDCp4D2We(searchReplaceGroup);
			}
			oniCNLBoHp = text2;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void jFDCp4D2We(SearchReplaceGroup P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bJECDF2ked = P_0;
		H0i7atNPbF.Text = P_0.Name;
		ctq7UGkXN2.Text = P_0.Description;
		jqN7YfpEG7.MmCe0gKP3a(P_0.Variables);
		ooUCZRIhkq(P_0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ooUCZRIhkq(SearchReplaceGroup P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		M4w7skLyM9.Nodes.Clear();
		TreeNode treeNode = M4w7skLyM9.Nodes.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57378), P_0.Name);
		treeNode.ImageIndex = 0;
		treeNode.Tag = P_0;
		foreach (SearchReplaceCriteria item in P_0.Items)
		{
			LZCCfihqoS(item, treeNode);
		}
		treeNode.ExpandAll();
		if (treeNode.Nodes.Count > 0)
		{
			M4w7skLyM9.SelectedNode = treeNode.Nodes[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TreeNode LZCCfihqoS(SearchReplaceCriteria P_0, TreeNode P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TreeNode treeNode = new TreeNode(P_0.Name);
		treeNode.ImageIndex = 1;
		treeNode.SelectedImageIndex = 2;
		treeNode.Tag = P_0;
		if (P_1 != null)
		{
			P_1.Nodes.Add(treeNode);
		}
		else
		{
			M4w7skLyM9.Nodes.Add(treeNode);
		}
		if (P_0.Children != null)
		{
			foreach (SearchReplaceCriteria child in P_0.Children)
			{
				LZCCfihqoS(child, treeNode);
			}
		}
		treeNode.ExpandAll();
		return treeNode;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void XvrCij806F(SearchReplaceCriteria P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		gstCclS5oA = P_0;
		FjT72guQhu.Text = P_0.Name;
		wgn7lDbTd3.Checked = P_0.Active;
		MXU7fKN1dd.Text = P_0.NodeSelector;
		a2XCzHrlxh.SelectedValue = ((P_0.MatchType == ConditionMatchType.ALL) ? Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57302) : Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57392));
		i6aC8kywcJ.YoJ0AfFc5q(P_0.Conditions);
		jum7vspi5r.gGtx6ZVyvW(P_0.Values);
		pMi7k5hbF0.MmCe0gKP3a(P_0.Variables);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void dxtCsOaet7(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = oniCNLBoHp;
		if (string.IsNullOrWhiteSpace(oniCNLBoHp))
		{
			text = VZxCKgDPBq();
		}
		bUbChBrETR(text);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void vN8CqhsQjk(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = VZxCKgDPBq();
		bUbChBrETR(text);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string VZxCKgDPBq()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string fileName = Path.GetFileName(oniCNLBoHp);
		string directoryName = Path.GetDirectoryName(oniCNLBoHp);
		string text = (string.IsNullOrWhiteSpace(oniCNLBoHp) ? Utils.SRGPath() : directoryName);
		return FileUtils.VXKSgcyptXi(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57312), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57324), text, fileName);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void bUbChBrETR(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!string.IsNullOrWhiteSpace(P_0) && P_0.ToLower().EndsWith(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57312)))
		{
			SearchReplaceGroup obj = td9CvcT22f();
			string value = DataConversion.Serialize(obj);
			Encoding encoding = Encoding.GetEncoding(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57402));
			using (StreamWriter streamWriter = new StreamWriter(P_0, append: false, encoding))
			{
				streamWriter.WriteLine(value);
			}
			oniCNLBoHp = P_0;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool n1vCm59Qss()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		new Settings();
		string value = Utils.SRGPath();
		bool result = false;
		if (string.IsNullOrWhiteSpace(value))
		{
			MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29208) + Environment.NewLine + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29326), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29454));
		}
		else
		{
			result = true;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Ri7CnEsnO2(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string target = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57426);
		CallBrowser callBrowser = new CallBrowser();
		callBrowser.Call(target);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void bTwClg26qb()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		YwbCoNscLv.DoWork += zEvCyUH7cB;
		YwbCoNscLv.ProgressChanged += DgLC0xLtUH;
		YwbCoNscLv.RunWorkerCompleted += eypCB0CE5v;
		YwbCoNscLv.WorkerReportsProgress = true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TlmC2jiBm9()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		SearchReplaceGroup searchReplaceGroup = td9CvcT22f();
		string dimension = (string)W5ICF6nnyx.SelectedValue;
		SearchReplaceParameter argument = new SearchReplaceParameter(dimension, searchReplaceGroup, APPCJMLsWE);
		YwbCoNscLv.RunWorkerAsync(argument);
		EQ6CQ0PaRg = omVCA757Dk.Visible;
		XVwCOwMr1l = oBN7t4gsRI.Visible;
		omVCA757Dk.Visible = false;
		oBN7t4gsRI.Visible = false;
		scd7bVswpT.Visible = true;
		d8B7GxO6Lq.Visible = true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void zEvCyUH7cB(object P_0, DoWorkEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BackgroundWorker backgroundWorker = P_0 as BackgroundWorker;
		SearchReplaceParameter searchReplaceParameter = P_1.Argument as SearchReplaceParameter;
		SearchReplaceWorkerPE searchReplaceWorkerPE = new SearchReplaceWorkerPE(backgroundWorker);
		Dictionary<string, SearchReplaceResult> result = searchReplaceWorkerPE.DoSearchReplace(searchReplaceParameter.Dimension, searchReplaceParameter.Group, searchReplaceParameter.OutFolderPath);
		P_1.Result = result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DgLC0xLtUH(object P_0, ProgressChangedEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		scd7bVswpT.Text = P_1.UserState as string;
		if (P_1.ProgressPercentage > 0)
		{
			d8B7GxO6Lq.Value = P_1.ProgressPercentage;
		}
		d8B7GxO6Lq.Refresh();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void eypCB0CE5v(object P_0, RunWorkerCompletedEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		omVCA757Dk.Visible = EQ6CQ0PaRg;
		oBN7t4gsRI.Visible = XVwCOwMr1l;
		scd7bVswpT.Visible = false;
		d8B7GxO6Lq.Visible = false;
		S40CufUFC6 = true;
		if (eJG73gPjxK.Checked)
		{
			Dictionary<string, SearchReplaceResult> dictionary = P_1.Result as Dictionary<string, SearchReplaceResult>;
			GUfCtdct0e(dictionary);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GUfCtdct0e(Dictionary<string, SearchReplaceResult> P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		FindReplaceResult findReplaceResult = new FindReplaceResult(P_0);
		findReplaceResult.ShowDialog(this);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ReYCau35SH(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		uZJCxW2xFD();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void iv9CX30bI2(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		vEPCeNZekk();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void uZJCxW2xFD()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (M4w7skLyM9.SelectedNode == null)
		{
			return;
		}
		SearchReplaceCriteria searchReplaceCriteria = Ql1CbUeked();
		if (M4w7skLyM9.SelectedNode.Tag is SearchReplaceCriteria)
		{
			if (gstCclS5oA.Children == null)
			{
				gstCclS5oA.Children = new List<SearchReplaceCriteria>();
			}
			gstCclS5oA.Children.Add(searchReplaceCriteria);
		}
		else
		{
			bJECDF2ked.Items.Add(searchReplaceCriteria);
		}
		LZCCfihqoS(searchReplaceCriteria, M4w7skLyM9.SelectedNode);
		M4w7skLyM9.SelectedNode.Expand();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void vEPCeNZekk()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (M4w7skLyM9.SelectedNode != null && M4w7skLyM9.SelectedNode.Tag is SearchReplaceCriteria)
		{
			TreeNode selectedNode = M4w7skLyM9.SelectedNode;
			SearchReplaceCriteria item = selectedNode.Tag as SearchReplaceCriteria;
			if (selectedNode.Parent.Tag is SearchReplaceCriteria)
			{
				SearchReplaceCriteria searchReplaceCriteria = selectedNode.Parent.Tag as SearchReplaceCriteria;
				searchReplaceCriteria.Children.Remove(item);
			}
			else
			{
				SearchReplaceGroup searchReplaceGroup = selectedNode.Parent.Tag as SearchReplaceGroup;
				searchReplaceGroup.Items.Remove(item);
			}
			TreeNode treeNode = selectedNode.NextNode;
			if (treeNode == null)
			{
				treeNode = selectedNode.PrevNode;
			}
			if (treeNode == null)
			{
				treeNode = selectedNode.Parent;
			}
			M4w7skLyM9.SelectedNode = treeNode;
			selectedNode.Remove();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ziACMxqLev(object P_0, TreeViewEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (M4w7skLyM9.SelectedNode.Tag is SearchReplaceCriteria)
		{
			omVCA757Dk.Visible = true;
			oBN7t4gsRI.Visible = false;
			t2VCwoW9U9();
			XvrCij806F(M4w7skLyM9.SelectedNode.Tag as SearchReplaceCriteria);
		}
		else
		{
			omVCA757Dk.Visible = false;
			oBN7t4gsRI.Visible = true;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void u8GCUgKrGG(object P_0, KeyEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (M4w7skLyM9.SelectedNode != null && M4w7skLyM9.SelectedNode.Tag is SearchReplaceCriteria)
		{
			M4w7skLyM9.SelectedNode.Text = FjT72guQhu.Text;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DV7CLNMMsH(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		OkLCPU69ur(M4w7skLyM9.SelectedNode);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void uGCCgCW3sw(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		kNMCRPHpha(M4w7skLyM9.SelectedNode);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OkLCPU69ur(TreeNode P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TreeNode treeNode = M4w7skLyM9.Nodes[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57378)];
		TreeNode treeNode2 = P_0.Parent;
		if (treeNode2 != null)
		{
			int num = treeNode2.Nodes.IndexOf(P_0);
			if (num > 0)
			{
				treeNode2.Nodes.RemoveAt(num);
				treeNode2.Nodes.Insert(num - 1, P_0);
				List<SearchReplaceCriteria> list = ((treeNode2 != treeNode) ? ((SearchReplaceCriteria)treeNode2.Tag).Children : ((SearchReplaceGroup)treeNode2.Tag).Items);
				SearchReplaceCriteria item = P_0.Tag as SearchReplaceCriteria;
				list.Remove(item);
				list.Insert(num - 1, item);
				P_0.TreeView.SelectedNode = P_0;
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void kNMCRPHpha(TreeNode P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TreeNode treeNode = M4w7skLyM9.Nodes[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57378)];
		TreeNode treeNode2 = P_0.Parent;
		if (treeNode2 != null)
		{
			int num = treeNode2.Nodes.IndexOf(P_0);
			if (num < treeNode2.Nodes.Count - 1)
			{
				treeNode2.Nodes.RemoveAt(num);
				treeNode2.Nodes.Insert(num + 1, P_0);
				List<SearchReplaceCriteria> list = ((treeNode2 != treeNode) ? ((SearchReplaceCriteria)treeNode2.Tag).Children : ((SearchReplaceGroup)treeNode2.Tag).Items);
				SearchReplaceCriteria item = P_0.Tag as SearchReplaceCriteria;
				list.Remove(item);
				list.Insert(num + 1, item);
				P_0.TreeView.SelectedNode = P_0;
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void JaqCkefpUA(object P_0, KeyEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_1.KeyCode == Keys.C && P_1.Control)
		{
			yBVCYsF337();
		}
		else if (P_1.KeyCode == Keys.V && P_1.Control)
		{
			R9MC3TofY2();
		}
		else if (P_1.KeyCode == Keys.X && P_1.Control)
		{
			yBVCYsF337();
			vEPCeNZekk();
		}
		else if (P_1.KeyCode == Keys.Delete)
		{
			vEPCeNZekk();
		}
		else if (P_1.KeyCode == Keys.Insert)
		{
			uZJCxW2xFD();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void yBVCYsF337()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (M4w7skLyM9.SelectedNode != null && M4w7skLyM9.SelectedNode.Tag is SearchReplaceCriteria)
		{
			SearchReplaceCriteria searchReplaceCriteria = M4w7skLyM9.SelectedNode.Tag as SearchReplaceCriteria;
			searchReplaceCriteria = searchReplaceCriteria.WdAS2hQgmhs();
			NZyC1JfBnL(searchReplaceCriteria);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void R9MC3TofY2()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (M4w7skLyM9.SelectedNode == null)
		{
			return;
		}
		SearchReplaceCriteria searchReplaceCriteria = PB3CEF0Brv();
		if (searchReplaceCriteria != null)
		{
			if (M4w7skLyM9.SelectedNode.Tag is SearchReplaceCriteria)
			{
				((SearchReplaceCriteria)M4w7skLyM9.SelectedNode.Tag).Children.Add(searchReplaceCriteria);
			}
			else if (M4w7skLyM9.SelectedNode.Tag is SearchReplaceGroup)
			{
				((SearchReplaceGroup)M4w7skLyM9.SelectedNode.Tag).Items.Add(searchReplaceCriteria);
			}
			LZCCfihqoS(searchReplaceCriteria, M4w7skLyM9.SelectedNode);
			M4w7skLyM9.SelectedNode.ExpandAll();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void NZyC1JfBnL(SearchReplaceCriteria P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		DataObject dataObject = new DataObject();
		dataObject.SetData(typeof(SearchReplaceCriteria).FullName, autoConvert: true, P_0);
		Clipboard.SetDataObject(dataObject);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private SearchReplaceCriteria PB3CEF0Brv()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return Clipboard.GetData(typeof(SearchReplaceCriteria).FullName) as SearchReplaceCriteria;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void C1qCr50ZyX(object P_0, KeyEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (bJECDF2ked != null)
		{
			bJECDF2ked.Name = H0i7atNPbF.Text;
			TreeNode treeNode = M4w7skLyM9.Nodes[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57378)];
			if (treeNode != null)
			{
				treeNode.Text = H0i7atNPbF.Text;
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void iPDC53Bq3t(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (bJECDF2ked != null)
		{
			bJECDF2ked.Description = ctq7UGkXN2.Text;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && fDwC7EILlL != null)
		{
			fDwC7EILlL.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void aGlC6BqI3x()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		fDwC7EILlL = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FindReplaceEntry));
		omVCA757Dk = new Panel();
		mN97gZctnn = new TabControl();
		peG7PQAoQa = new TabPage();
		a2XCzHrlxh = new ComboBox();
		kPHC9OEpp6 = new SplitContainer();
		MXU7fKN1dd = new TextBox();
		t8V7TXt22I = new Label();
		nir7ZphfQA = new Label();
		lP5CIpaaIi = new Label();
		ekT7R28Nof = new TabPage();
		wgn7lDbTd3 = new CheckBox();
		FjT72guQhu = new TextBox();
		fHR7ychvFb = new Label();
		W5ICF6nnyx = new ComboBox();
		HLtCjdLFCO = new Label();
		iab7SNXEpS = new Button();
		eO7CdwRgkM = new Button();
		GxZCHj9I9T = new Button();
		d8B7GxO6Lq = new ProgressBar();
		scd7bVswpT = new Label();
		cD27wYBsG1 = new MenuStrip();
		zV374l3QSV = new ToolStripMenuItem();
		elC7nG9xRJ = new ToolStripMenuItem();
		Uxy7VXmV4W = new ToolStripMenuItem();
		IvG7Wx5wPC = new ToolStripSeparator();
		wP27pQHFvg = new ToolStripMenuItem();
		WFg7xBkOaM = new ToolStripMenuItem();
		Jdh7imP1TP = new SplitContainer();
		MkY7mLbAEF = new Panel();
		oHn7BIV81U = new Button();
		NaE70hEVhP = new Button();
		bhW7q7Vaw2 = new Button();
		PUW7Kh8Ava = new Button();
		M4w7skLyM9 = new TreeView();
		OL87hnPo06 = new ImageList(fDwC7EILlL);
		oBN7t4gsRI = new Panel();
		BN27eJ97yD = new TabControl();
		OFi7MeQej6 = new TabPage();
		ctq7UGkXN2 = new TextBox();
		Tp97LPSjVe = new TabPage();
		H0i7atNPbF = new TextBox();
		eLP7XBnuQS = new Label();
		jqN7YfpEG7 = new VariableList();
		i6aC8kywcJ = new MatchList();
		jum7vspi5r = new ReplaceList();
		pMi7k5hbF0 = new VariableList();
		eJG73gPjxK = new CheckBox();
		omVCA757Dk.SuspendLayout();
		mN97gZctnn.SuspendLayout();
		peG7PQAoQa.SuspendLayout();
		((ISupportInitialize)kPHC9OEpp6).BeginInit();
		kPHC9OEpp6.Panel1.SuspendLayout();
		kPHC9OEpp6.Panel2.SuspendLayout();
		kPHC9OEpp6.SuspendLayout();
		ekT7R28Nof.SuspendLayout();
		cD27wYBsG1.SuspendLayout();
		((ISupportInitialize)Jdh7imP1TP).BeginInit();
		Jdh7imP1TP.Panel1.SuspendLayout();
		Jdh7imP1TP.Panel2.SuspendLayout();
		Jdh7imP1TP.SuspendLayout();
		MkY7mLbAEF.SuspendLayout();
		oBN7t4gsRI.SuspendLayout();
		BN27eJ97yD.SuspendLayout();
		OFi7MeQej6.SuspendLayout();
		Tp97LPSjVe.SuspendLayout();
		SuspendLayout();
		omVCA757Dk.BorderStyle = BorderStyle.FixedSingle;
		omVCA757Dk.Controls.Add(mN97gZctnn);
		omVCA757Dk.Controls.Add(wgn7lDbTd3);
		omVCA757Dk.Controls.Add(FjT72guQhu);
		omVCA757Dk.Controls.Add(fHR7ychvFb);
		omVCA757Dk.Dock = DockStyle.Fill;
		omVCA757Dk.Location = new Point(0, 0);
		omVCA757Dk.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57538);
		omVCA757Dk.Size = new Size(713, 537);
		omVCA757Dk.TabIndex = 1;
		mN97gZctnn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		mN97gZctnn.Controls.Add(peG7PQAoQa);
		mN97gZctnn.Controls.Add(ekT7R28Nof);
		mN97gZctnn.Location = new Point(10, 44);
		mN97gZctnn.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57564);
		mN97gZctnn.SelectedIndex = 0;
		mN97gZctnn.Size = new Size(695, 486);
		mN97gZctnn.TabIndex = 13;
		peG7PQAoQa.BackColor = SystemColors.Control;
		peG7PQAoQa.Controls.Add(a2XCzHrlxh);
		peG7PQAoQa.Controls.Add(kPHC9OEpp6);
		peG7PQAoQa.Controls.Add(MXU7fKN1dd);
		peG7PQAoQa.Controls.Add(t8V7TXt22I);
		peG7PQAoQa.Controls.Add(nir7ZphfQA);
		peG7PQAoQa.Controls.Add(lP5CIpaaIi);
		peG7PQAoQa.Location = new Point(4, 22);
		peG7PQAoQa.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15898);
		peG7PQAoQa.Padding = new Padding(3);
		peG7PQAoQa.Size = new Size(687, 460);
		peG7PQAoQa.TabIndex = 0;
		peG7PQAoQa.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57590);
		a2XCzHrlxh.DropDownStyle = ComboBoxStyle.DropDownList;
		a2XCzHrlxh.FormattingEnabled = true;
		a2XCzHrlxh.Location = new Point(155, 42);
		a2XCzHrlxh.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57604);
		a2XCzHrlxh.Size = new Size(41, 21);
		a2XCzHrlxh.TabIndex = 11;
		kPHC9OEpp6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		kPHC9OEpp6.Location = new Point(6, 69);
		kPHC9OEpp6.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13750);
		kPHC9OEpp6.Orientation = Orientation.Horizontal;
		kPHC9OEpp6.Panel1.Controls.Add(i6aC8kywcJ);
		kPHC9OEpp6.Panel2.Controls.Add(jum7vspi5r);
		kPHC9OEpp6.Size = new Size(675, 385);
		kPHC9OEpp6.SplitterDistance = 190;
		kPHC9OEpp6.TabIndex = 11;
		MXU7fKN1dd.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		MXU7fKN1dd.Location = new Point(84, 15);
		MXU7fKN1dd.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57632);
		MXU7fKN1dd.Size = new Size(597, 20);
		MXU7fKN1dd.TabIndex = 9;
		t8V7TXt22I.AutoSize = true;
		t8V7TXt22I.Location = new Point(5, 48);
		t8V7TXt22I.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		t8V7TXt22I.Size = new Size(153, 13);
		t8V7TXt22I.TabIndex = 10;
		t8V7TXt22I.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57664);
		nir7ZphfQA.AutoSize = true;
		nir7ZphfQA.Location = new Point(5, 18);
		nir7ZphfQA.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12846);
		nir7ZphfQA.Size = new Size(75, 13);
		nir7ZphfQA.TabIndex = 8;
		nir7ZphfQA.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57726);
		lP5CIpaaIi.AutoSize = true;
		lP5CIpaaIi.Location = new Point(198, 48);
		lP5CIpaaIi.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10482);
		lP5CIpaaIi.Size = new Size(184, 13);
		lP5CIpaaIi.TabIndex = 12;
		lP5CIpaaIi.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57756);
		ekT7R28Nof.BackColor = SystemColors.Control;
		ekT7R28Nof.Controls.Add(pMi7k5hbF0);
		ekT7R28Nof.Location = new Point(4, 22);
		ekT7R28Nof.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57162);
		ekT7R28Nof.Padding = new Padding(3);
		ekT7R28Nof.Size = new Size(687, 460);
		ekT7R28Nof.TabIndex = 1;
		ekT7R28Nof.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57836);
		wgn7lDbTd3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		wgn7lDbTd3.AutoSize = true;
		wgn7lDbTd3.Location = new Point(618, 13);
		wgn7lDbTd3.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57858);
		wgn7lDbTd3.Size = new Size(56, 17);
		wgn7lDbTd3.TabIndex = 7;
		wgn7lDbTd3.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11530);
		wgn7lDbTd3.UseVisualStyleBackColor = true;
		FjT72guQhu.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		FjT72guQhu.Location = new Point(48, 10);
		FjT72guQhu.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55110);
		FjT72guQhu.Size = new Size(555, 20);
		FjT72guQhu.TabIndex = 6;
		FjT72guQhu.KeyUp += u8GCUgKrGG;
		fHR7ychvFb.AutoSize = true;
		fHR7ychvFb.Location = new Point(10, 13);
		fHR7ychvFb.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11162);
		fHR7ychvFb.Size = new Size(35, 13);
		fHR7ychvFb.TabIndex = 5;
		fHR7ychvFb.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10196);
		W5ICF6nnyx.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		W5ICF6nnyx.DropDownStyle = ComboBoxStyle.DropDownList;
		W5ICF6nnyx.FormattingEnabled = true;
		W5ICF6nnyx.Location = new Point(674, 571);
		W5ICF6nnyx.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37176);
		W5ICF6nnyx.Size = new Size(89, 21);
		W5ICF6nnyx.TabIndex = 17;
		HLtCjdLFCO.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		HLtCjdLFCO.AutoSize = true;
		HLtCjdLFCO.Location = new Point(617, 575);
		HLtCjdLFCO.Margin = new Padding(0);
		HLtCjdLFCO.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10582);
		HLtCjdLFCO.Size = new Size(56, 13);
		HLtCjdLFCO.TabIndex = 16;
		HLtCjdLFCO.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37092);
		HLtCjdLFCO.TextAlign = ContentAlignment.MiddleRight;
		iab7SNXEpS.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		iab7SNXEpS.Location = new Point(5, 570);
		iab7SNXEpS.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40514);
		iab7SNXEpS.Size = new Size(50, 23);
		iab7SNXEpS.TabIndex = 15;
		iab7SNXEpS.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40532);
		iab7SNXEpS.UseVisualStyleBackColor = true;
		iab7SNXEpS.Click += Ri7CnEsnO2;
		eO7CdwRgkM.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		eO7CdwRgkM.Location = new Point(769, 570);
		eO7CdwRgkM.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57878);
		eO7CdwRgkM.Size = new Size(123, 23);
		eO7CdwRgkM.TabIndex = 18;
		eO7CdwRgkM.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57914);
		eO7CdwRgkM.UseVisualStyleBackColor = true;
		eO7CdwRgkM.Click += ovhC4kOUdj;
		GxZCHj9I9T.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		GxZCHj9I9T.DialogResult = DialogResult.Cancel;
		GxZCHj9I9T.Location = new Point(899, 570);
		GxZCHj9I9T.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34610);
		GxZCHj9I9T.Size = new Size(50, 23);
		GxZCHj9I9T.TabIndex = 19;
		GxZCHj9I9T.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38528);
		GxZCHj9I9T.UseVisualStyleBackColor = true;
		d8B7GxO6Lq.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		d8B7GxO6Lq.Location = new Point(61, 215);
		d8B7GxO6Lq.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37366);
		d8B7GxO6Lq.Size = new Size(599, 23);
		d8B7GxO6Lq.TabIndex = 2;
		d8B7GxO6Lq.Visible = false;
		scd7bVswpT.AutoSize = true;
		scd7bVswpT.Location = new Point(58, 241);
		scd7bVswpT.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37114);
		scd7bVswpT.Size = new Size(35, 13);
		scd7bVswpT.TabIndex = 3;
		scd7bVswpT.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12846);
		scd7bVswpT.Visible = false;
		cD27wYBsG1.Items.AddRange(new ToolStripItem[1] { zV374l3QSV });
		cD27wYBsG1.Location = new Point(0, 0);
		cD27wYBsG1.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26656);
		cD27wYBsG1.Size = new Size(955, 24);
		cD27wYBsG1.TabIndex = 0;
		cD27wYBsG1.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26656);
		zV374l3QSV.DropDownItems.AddRange(new ToolStripItem[5] { elC7nG9xRJ, Uxy7VXmV4W, IvG7Wx5wPC, wP27pQHFvg, WFg7xBkOaM });
		zV374l3QSV.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57954);
		zV374l3QSV.Size = new Size(37, 20);
		zV374l3QSV.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29532);
		elC7nG9xRJ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57976);
		elC7nG9xRJ.Size = new Size(152, 22);
		elC7nG9xRJ.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57992);
		elC7nG9xRJ.Click += BCqCVimSsR;
		Uxy7VXmV4W.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(58002);
		Uxy7VXmV4W.Size = new Size(152, 22);
		Uxy7VXmV4W.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29568);
		Uxy7VXmV4W.Click += PFECW0HluX;
		IvG7Wx5wPC.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20892);
		IvG7Wx5wPC.Size = new Size(149, 6);
		wP27pQHFvg.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(58020);
		wP27pQHFvg.Size = new Size(152, 22);
		wP27pQHFvg.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29604);
		wP27pQHFvg.Click += dxtCsOaet7;
		WFg7xBkOaM.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(58038);
		WFg7xBkOaM.Size = new Size(152, 22);
		WFg7xBkOaM.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(58088);
		WFg7xBkOaM.Click += vN8CqhsQjk;
		Jdh7imP1TP.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Jdh7imP1TP.Location = new Point(0, 27);
		Jdh7imP1TP.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13784);
		Jdh7imP1TP.Panel1.Controls.Add(MkY7mLbAEF);
		Jdh7imP1TP.Panel1.Controls.Add(M4w7skLyM9);
		Jdh7imP1TP.Panel2.Controls.Add(oBN7t4gsRI);
		Jdh7imP1TP.Panel2.Controls.Add(omVCA757Dk);
		Jdh7imP1TP.Panel2.Controls.Add(d8B7GxO6Lq);
		Jdh7imP1TP.Panel2.Controls.Add(scd7bVswpT);
		Jdh7imP1TP.Size = new Size(956, 537);
		Jdh7imP1TP.SplitterDistance = 239;
		Jdh7imP1TP.TabIndex = 5;
		MkY7mLbAEF.BackColor = SystemColors.ControlLight;
		MkY7mLbAEF.BorderStyle = BorderStyle.FixedSingle;
		MkY7mLbAEF.Controls.Add(oHn7BIV81U);
		MkY7mLbAEF.Controls.Add(NaE70hEVhP);
		MkY7mLbAEF.Controls.Add(bhW7q7Vaw2);
		MkY7mLbAEF.Controls.Add(PUW7Kh8Ava);
		MkY7mLbAEF.Dock = DockStyle.Top;
		MkY7mLbAEF.Location = new Point(0, 0);
		MkY7mLbAEF.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11356);
		MkY7mLbAEF.Size = new Size(239, 31);
		MkY7mLbAEF.TabIndex = 1;
		oHn7BIV81U.Image = Resources.h9TS1mr6yVy();
		oHn7BIV81U.Location = new Point(54, 2);
		oHn7BIV81U.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14482);
		oHn7BIV81U.Size = new Size(24, 24);
		oHn7BIV81U.TabIndex = 5;
		oHn7BIV81U.UseVisualStyleBackColor = true;
		oHn7BIV81U.Click += DV7CLNMMsH;
		NaE70hEVhP.Image = Resources.VIUS1sBuy0A();
		NaE70hEVhP.Location = new Point(79, 2);
		NaE70hEVhP.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14464);
		NaE70hEVhP.Size = new Size(24, 24);
		NaE70hEVhP.TabIndex = 4;
		NaE70hEVhP.UseVisualStyleBackColor = true;
		NaE70hEVhP.Click += uGCCgCW3sw;
		bhW7q7Vaw2.Image = Resources.GSfSEcQrVsG();
		bhW7q7Vaw2.Location = new Point(29, 3);
		bhW7q7Vaw2.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14426);
		bhW7q7Vaw2.Size = new Size(24, 24);
		bhW7q7Vaw2.TabIndex = 3;
		bhW7q7Vaw2.UseVisualStyleBackColor = true;
		bhW7q7Vaw2.Click += iv9CX30bI2;
		PUW7Kh8Ava.Image = Resources.C61S3HP5IFi();
		PUW7Kh8Ava.Location = new Point(4, 3);
		PUW7Kh8Ava.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14448);
		PUW7Kh8Ava.Size = new Size(24, 24);
		PUW7Kh8Ava.TabIndex = 2;
		PUW7Kh8Ava.UseVisualStyleBackColor = true;
		PUW7Kh8Ava.Click += ReYCau35SH;
		M4w7skLyM9.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		M4w7skLyM9.HideSelection = false;
		M4w7skLyM9.ImageIndex = 0;
		M4w7skLyM9.ImageList = OL87hnPo06;
		M4w7skLyM9.Location = new Point(0, 30);
		M4w7skLyM9.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(58106);
		M4w7skLyM9.SelectedImageIndex = 0;
		M4w7skLyM9.Size = new Size(227, 507);
		M4w7skLyM9.TabIndex = 4;
		M4w7skLyM9.AfterSelect += ziACMxqLev;
		M4w7skLyM9.KeyDown += JaqCkefpUA;
		OL87hnPo06.ImageStream = (ImageListStreamer)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23886));
		OL87hnPo06.TransparentColor = Color.Transparent;
		OL87hnPo06.Images.SetKeyName(0, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(58138));
		OL87hnPo06.Images.SetKeyName(1, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(58156));
		OL87hnPo06.Images.SetKeyName(2, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(58174));
		oBN7t4gsRI.BorderStyle = BorderStyle.FixedSingle;
		oBN7t4gsRI.Controls.Add(BN27eJ97yD);
		oBN7t4gsRI.Controls.Add(H0i7atNPbF);
		oBN7t4gsRI.Controls.Add(eLP7XBnuQS);
		oBN7t4gsRI.Dock = DockStyle.Fill;
		oBN7t4gsRI.Location = new Point(0, 0);
		oBN7t4gsRI.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(58210);
		oBN7t4gsRI.Size = new Size(713, 537);
		oBN7t4gsRI.TabIndex = 4;
		oBN7t4gsRI.Visible = false;
		BN27eJ97yD.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		BN27eJ97yD.Controls.Add(OFi7MeQej6);
		BN27eJ97yD.Controls.Add(Tp97LPSjVe);
		BN27eJ97yD.Location = new Point(13, 44);
		BN27eJ97yD.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(56510);
		BN27eJ97yD.SelectedIndex = 0;
		BN27eJ97yD.Size = new Size(686, 480);
		BN27eJ97yD.TabIndex = 11;
		OFi7MeQej6.BackColor = SystemColors.Control;
		OFi7MeQej6.Controls.Add(ctq7UGkXN2);
		OFi7MeQej6.Location = new Point(4, 22);
		OFi7MeQej6.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(56536);
		OFi7MeQej6.Padding = new Padding(3);
		OFi7MeQej6.Size = new Size(678, 454);
		OFi7MeQej6.TabIndex = 0;
		OFi7MeQej6.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11830);
		ctq7UGkXN2.Dock = DockStyle.Fill;
		ctq7UGkXN2.Location = new Point(3, 3);
		ctq7UGkXN2.Multiline = true;
		ctq7UGkXN2.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(58230);
		ctq7UGkXN2.Size = new Size(672, 448);
		ctq7UGkXN2.TabIndex = 10;
		ctq7UGkXN2.TextChanged += iPDC53Bq3t;
		Tp97LPSjVe.BackColor = SystemColors.Control;
		Tp97LPSjVe.Controls.Add(jqN7YfpEG7);
		Tp97LPSjVe.Location = new Point(4, 22);
		Tp97LPSjVe.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57098);
		Tp97LPSjVe.Padding = new Padding(3);
		Tp97LPSjVe.Size = new Size(678, 454);
		Tp97LPSjVe.TabIndex = 1;
		Tp97LPSjVe.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57836);
		H0i7atNPbF.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		H0i7atNPbF.Location = new Point(48, 10);
		H0i7atNPbF.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(58270);
		H0i7atNPbF.Size = new Size(645, 20);
		H0i7atNPbF.TabIndex = 8;
		H0i7atNPbF.KeyUp += C1qCr50ZyX;
		eLP7XBnuQS.AutoSize = true;
		eLP7XBnuQS.Location = new Point(10, 13);
		eLP7XBnuQS.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11298);
		eLP7XBnuQS.Size = new Size(35, 13);
		eLP7XBnuQS.TabIndex = 7;
		eLP7XBnuQS.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10196);
		jqN7YfpEG7.BackColor = SystemColors.Control;
		jqN7YfpEG7.Dock = DockStyle.Fill;
		jqN7YfpEG7.Location = new Point(3, 3);
		jqN7YfpEG7.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(58296);
		jqN7YfpEG7.Size = new Size(672, 448);
		jqN7YfpEG7.TabIndex = 0;
		i6aC8kywcJ.Dock = DockStyle.Fill;
		i6aC8kywcJ.Location = new Point(0, 0);
		i6aC8kywcJ.Margin = new Padding(0);
		i6aC8kywcJ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(58326);
		i6aC8kywcJ.Size = new Size(675, 190);
		i6aC8kywcJ.TabIndex = 13;
		jum7vspi5r.Dock = DockStyle.Fill;
		jum7vspi5r.Location = new Point(0, 0);
		jum7vspi5r.Margin = new Padding(0);
		jum7vspi5r.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(58350);
		jum7vspi5r.Size = new Size(675, 191);
		jum7vspi5r.TabIndex = 14;
		pMi7k5hbF0.Dock = DockStyle.Fill;
		pMi7k5hbF0.Location = new Point(3, 3);
		pMi7k5hbF0.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(58378);
		pMi7k5hbF0.Size = new Size(681, 454);
		pMi7k5hbF0.TabIndex = 0;
		eJG73gPjxK.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		eJG73gPjxK.AutoSize = true;
		eJG73gPjxK.Location = new Point(496, 574);
		eJG73gPjxK.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(58408);
		eJG73gPjxK.Size = new Size(91, 17);
		eJG73gPjxK.TabIndex = 20;
		eJG73gPjxK.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(58438);
		eJG73gPjxK.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(955, 598);
		base.Controls.Add(eJG73gPjxK);
		base.Controls.Add(Jdh7imP1TP);
		base.Controls.Add(iab7SNXEpS);
		base.Controls.Add(cD27wYBsG1);
		base.Controls.Add(GxZCHj9I9T);
		base.Controls.Add(W5ICF6nnyx);
		base.Controls.Add(HLtCjdLFCO);
		base.Controls.Add(eO7CdwRgkM);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(58466);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57914);
		base.Load += lixCSqvJEP;
		omVCA757Dk.ResumeLayout(performLayout: false);
		omVCA757Dk.PerformLayout();
		mN97gZctnn.ResumeLayout(performLayout: false);
		peG7PQAoQa.ResumeLayout(performLayout: false);
		peG7PQAoQa.PerformLayout();
		kPHC9OEpp6.Panel1.ResumeLayout(performLayout: false);
		kPHC9OEpp6.Panel2.ResumeLayout(performLayout: false);
		((ISupportInitialize)kPHC9OEpp6).EndInit();
		kPHC9OEpp6.ResumeLayout(performLayout: false);
		ekT7R28Nof.ResumeLayout(performLayout: false);
		cD27wYBsG1.ResumeLayout(performLayout: false);
		cD27wYBsG1.PerformLayout();
		Jdh7imP1TP.Panel1.ResumeLayout(performLayout: false);
		Jdh7imP1TP.Panel2.ResumeLayout(performLayout: false);
		Jdh7imP1TP.Panel2.PerformLayout();
		((ISupportInitialize)Jdh7imP1TP).EndInit();
		Jdh7imP1TP.ResumeLayout(performLayout: false);
		MkY7mLbAEF.ResumeLayout(performLayout: false);
		oBN7t4gsRI.ResumeLayout(performLayout: false);
		oBN7t4gsRI.PerformLayout();
		BN27eJ97yD.ResumeLayout(performLayout: false);
		OFi7MeQej6.ResumeLayout(performLayout: false);
		OFi7MeQej6.PerformLayout();
		Tp97LPSjVe.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static FindReplaceEntry()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		matchCondition = new Dictionary<string, string>
		{
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57302),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(58502)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57392),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(58512)
			}
		};
	}
}
