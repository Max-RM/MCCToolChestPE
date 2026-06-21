using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.controllers;
using MCCToolChest.events;
using MCCToolChest.MCSBCode;
using MCCToolChest.model;
using MCCToolChest.Properties;
using MCCToolChest.workers;
using uL2B6CXB2hZQU16Di7r;
using uP7B13T5waxVpI3AEv;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.forms;

public class EntitySearchEntry : Form
{
	private ListViewColumnSorter YZS79rgn4w;

	private MainForm HvI7IDCAwQ;

	private static ImageList WNB7zmfU6k;

	private static Dictionary<string, int> QLVATliO7W;

	private EntityLookup X82ASdV0wR;

	private string xvbAGbfq7W;

	private DoOpenChunk q68Ab9U6bh;

	private DoShowSearch iOsAvVQJ4S;

	private Dictionary<string, List<EntitySearchResult>> wf2AwRpEJG;

	private BackgroundWorker UMIA4tstHy;

	private IContainer RYoAVtuLqP;

	private Label irnAWtKUik;

	private TextBox b5QApmKOSH;

	private Label y6FAZcqKFQ;

	private ComboBox tLwAfM1ddQ;

	private Button CVDAiNHcyf;

	private Button SSeAsKjWcM;

	private ProgressBar KFNAq42R9n;

	private Label BYPAKwi0ji;

	private Panel f8xAhGX3la;

	private Label muSAmpke0N;

	private TextBox yfKAnr9H53;

	private ListView twhAlAlglg;

	private ColumnHeader s1IA2ox1MR;

	private ColumnHeader FUAAy9CoD2;

	private ColumnHeader UbNA0nDmTX;

	private ColumnHeader qmhAB8xpPS;

	private ColumnHeader tHfAt4aR05;

	private ColumnHeader SnYAajpcWi;

	private ColumnHeader P7EAXUidlR;

	private Button YyIAxPrFWw;

	private StatusStrip Fy1Aep8qqA;

	private ToolStripStatusLabel OwEAMEXabO;

	public Dictionary<string, List<EntitySearchResult>> SearchResults
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return wf2AwRpEJG;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EntitySearchEntry(MainForm parentForm, string workingFolder, DoOpenChunk openChunk, DoShowSearch showSearch)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		X82ASdV0wR = new EntityLookup();
		UMIA4tstHy = new BackgroundWorker();
		xvbAGbfq7W = workingFolder;
		gMr78jAsQZ();
		HvI7IDCAwQ = parentForm;
		q68Ab9U6bh = openChunk;
		iOsAvVQJ4S = showSearch;
		BnO7rgU31r();
		Cfl752NVaM();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void IOo71G8hXa()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		YZS79rgn4w = new ListViewColumnSorter();
		twhAlAlglg.ListViewItemSorter = YZS79rgn4w;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Fea7Enb6wS()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		twhAlAlglg.ListViewItemSorter = null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BnO7rgU31r()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (WNB7zmfU6k == null)
		{
			WNB7zmfU6k = new ImageList();
			WNB7zmfU6k.ColorDepth = ColorDepth.Depth32Bit;
			WNB7zmfU6k.TransparentColor = Color.Transparent;
			WNB7zmfU6k.ImageSize = new Size(20, 20);
			Bitmap value = new Bitmap(20, 20);
			WNB7zmfU6k.Images.Add(value);
			QLVATliO7W = new Dictionary<string, int>();
		}
		Settings settings = new Settings();
		b5QApmKOSH.Text = settings.LastEntitySearch;
		Constants.PopulateDimensionCombo(tLwAfM1ddQ, settings.LastEntitySearchRegion);
		yfKAnr9H53.Text = settings.LastEntitySearchConditions;
		twhAlAlglg.SmallImageList = WNB7zmfU6k;
		twhAlAlglg.LargeImageList = WNB7zmfU6k;
		string lastEntitySearchRegion = settings.LastEntitySearchRegion;
		if (Working.khEStDj4vgI() != null && Working.khEStDj4vgI().ContainsKey(lastEntitySearchRegion) && Working.khEStDj4vgI()[lastEntitySearchRegion] != null)
		{
			wf2AwRpEJG = Working.khEStDj4vgI()[lastEntitySearchRegion];
			XG07OXZjsn(wf2AwRpEJG);
		}
		HvI7IDCAwQ.ReloadMap += d4K7H1gVTB;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Cfl752NVaM()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		UMIA4tstHy.DoWork += Tph7Dl737s;
		UMIA4tstHy.ProgressChanged += Dau7cloP51;
		UMIA4tstHy.RunWorkerCompleted += hap7J0lwUW;
		UMIA4tstHy.WorkerReportsProgress = true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hNJ76TDSyq()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<NodeSearchcriterion> list = new List<NodeSearchcriterion>();
		if (!string.IsNullOrWhiteSpace(b5QApmKOSH.Text))
		{
			List<NodeSearchcriterion> nodeConditions = zy57N6o2Ki();
			string[] array = b5QApmKOSH.Text.Split(',');
			string[] array2 = array;
			foreach (string text in array2)
			{
				list.Add(new NodeSearchcriterion
				{
					Node = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634),
					Value = text.Trim(),
					Condition = SearchCondition.Equal,
					NodeConditions = nodeConditions
				});
			}
			string dimension = (tLwAfM1ddQ.SelectedItem as DimensionListItem)?.FolderKey;
			SearchEntityParameter argument = new SearchEntityParameter(dimension, list, xvbAGbfq7W);
			UMIA4tstHy.RunWorkerAsync(argument);
			f8xAhGX3la.Visible = false;
			BYPAKwi0ji.Visible = true;
			KFNAq42R9n.Visible = true;
			Settings settings = new Settings();
			settings.LastEntitySearch = b5QApmKOSH.Text;
			settings.LastEntitySearchRegion = (tLwAfM1ddQ.SelectedItem as DimensionListItem)?.FolderKey;
			settings.LastEntitySearchConditions = yfKAnr9H53.Text;
			settings.Save();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<NodeSearchcriterion> zy57N6o2Ki()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<NodeSearchcriterion> result = null;
		ParseConditionsWorker parseConditionsWorker = new ParseConditionsWorker();
		try
		{
			result = parseConditionsWorker.ParseConditions(yfKAnr9H53.Text);
		}
		catch (Exception)
		{
			MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(58522), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(58612));
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Tph7Dl737s(object P_0, DoWorkEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BackgroundWorker backgroundWorker = P_0 as BackgroundWorker;
		SearchEntityParameter searchEntityParameter = P_1.Argument as SearchEntityParameter;
		SearchEntityWorkerPE searchEntityWorkerPE = new SearchEntityWorkerPE(backgroundWorker);
		Dictionary<string, List<EntitySearchResult>> result = searchEntityWorkerPE.DoSearch(searchEntityParameter.Dimension, searchEntityParameter.Criteria, searchEntityParameter.OutFolderPath);
		P_1.Result = result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Dau7cloP51(object P_0, ProgressChangedEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BYPAKwi0ji.Text = P_1.UserState as string;
		if (P_1.ProgressPercentage > 0)
		{
			KFNAq42R9n.Value = P_1.ProgressPercentage;
		}
		KFNAq42R9n.Refresh();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hap7J0lwUW(object P_0, RunWorkerCompletedEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		wf2AwRpEJG = P_1.Result as Dictionary<string, List<EntitySearchResult>>;
		string dimension = (tLwAfM1ddQ.SelectedItem as DimensionListItem)?.FolderKey;
		f8xAhGX3la.Visible = true;
		BYPAKwi0ji.Visible = false;
		KFNAq42R9n.Visible = false;
		XG07OXZjsn(wf2AwRpEJG);
		iOsAvVQJ4S(dimension, wf2AwRpEJG);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void H597uup3tM(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		hNJ76TDSyq();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void cWk7oiXL0F(object P_0, FormClosingEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (UMIA4tstHy.IsBusy)
		{
			P_1.Cancel = true;
		}
		else
		{
			Working.searchIsOpen = false;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void P5m7QtK9Vr(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.Icon = Resources.usMSrbJo37S();
		Working.searchIsOpen = true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void XG07OXZjsn(Dictionary<string, List<EntitySearchResult>> P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = 0;
		twhAlAlglg.Items.Clear();
		Fea7Enb6wS();
		twhAlAlglg.BeginUpdate();
		foreach (List<EntitySearchResult> value in P_0.Values)
		{
			if (value == null)
			{
				continue;
			}
			foreach (EntitySearchResult item in value)
			{
				uDV7CexsiF(item);
				num++;
			}
		}
		twhAlAlglg.EndUpdate();
		IOo71G8hXa();
		YZS79rgn4w.Order = SortOrder.None;
		OwEAMEXabO.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18534) + num;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void uDV7CexsiF(EntitySearchResult P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ListViewItem listViewItem = new ListViewItem();
		listViewItem.ImageIndex = eML77I6Dm1(P_0.EntityId);
		listViewItem.SubItems.Add(P_0.EntityId);
		listViewItem.SubItems.Add((P_0.EntityType == EntityType.Entity) ? Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15852) : Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(36926));
		listViewItem.SubItems.Add(P_0.Region);
		listViewItem.SubItems.Add(P_0.ChunkString());
		listViewItem.SubItems.Add(P_0.PositionString());
		listViewItem.SubItems.Add(P_0.Parent);
		listViewItem.Tag = P_0;
		twhAlAlglg.Items.Add(listViewItem);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int eML77I6Dm1(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = 0;
		if (QLVATliO7W.ContainsKey(P_0))
		{
			num = QLVATliO7W[P_0];
		}
		else if (MobImageManager.SOLG0vnEyp().ContainsKey(P_0))
		{
			Image value = MobImageManager.MobImages.Images[MobImageManager.SOLG0vnEyp()[P_0].ImageId];
			num = WNB7zmfU6k.Images.Count;
			WNB7zmfU6k.Images.Add(value);
			QLVATliO7W.Add(P_0, num);
		}
		else if (Constants.BEDROCK_ENTITY_BLOCKS_BY_NAME.ContainsKey(P_0))
		{
			int num2 = Constants.BEDROCK_ENTITY_BLOCKS_BY_NAME[P_0];
			Image value2 = BFRL2f2UoG7tBGIHJF.xRoSMGJq48(num2, 0);
			num = WNB7zmfU6k.Images.Count;
			WNB7zmfU6k.Images.Add(value2);
			QLVATliO7W.Add(P_0, num);
		}
		return num;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void sqH7AZL5fs(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		EntitySearchResult entitySearchResult = null;
		if (twhAlAlglg.SelectedItems.Count > 0)
		{
			entitySearchResult = twhAlAlglg.SelectedItems[0].Tag as EntitySearchResult;
		}
		if (entitySearchResult != null)
		{
			q68Ab9U6bh(entitySearchResult.Region, entitySearchResult.Dimension, entitySearchResult.ChunkIndex);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void sWP7dt1hHg(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string dimension = (tLwAfM1ddQ.SelectedItem as DimensionListItem)?.FolderKey;
		wf2AwRpEJG = null;
		twhAlAlglg.Items.Clear();
		OwEAMEXabO.Text = "";
		iOsAvVQJ4S(dimension, null);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void d4K7H1gVTB(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		twhAlAlglg.Items.Clear();
		OwEAMEXabO.Text = "";
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ibk7Fh01M6(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		b5QApmKOSH.Focus();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void iai7jNWoRj(object P_0, ColumnClickEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_1.Column == YZS79rgn4w.SortColumn)
		{
			if (YZS79rgn4w.Order == SortOrder.Ascending)
			{
				YZS79rgn4w.Order = SortOrder.Descending;
			}
			else
			{
				YZS79rgn4w.Order = SortOrder.Ascending;
			}
		}
		else
		{
			YZS79rgn4w.SortColumn = P_1.Column;
			YZS79rgn4w.Order = SortOrder.Ascending;
		}
		twhAlAlglg.Sort();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && RYoAVtuLqP != null)
		{
			RYoAVtuLqP.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void gMr78jAsQZ()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		irnAWtKUik = new Label();
		b5QApmKOSH = new TextBox();
		y6FAZcqKFQ = new Label();
		tLwAfM1ddQ = new ComboBox();
		CVDAiNHcyf = new Button();
		SSeAsKjWcM = new Button();
		KFNAq42R9n = new ProgressBar();
		BYPAKwi0ji = new Label();
		f8xAhGX3la = new Panel();
		YyIAxPrFWw = new Button();
		muSAmpke0N = new Label();
		yfKAnr9H53 = new TextBox();
		twhAlAlglg = new ListView();
		P7EAXUidlR = new ColumnHeader();
		s1IA2ox1MR = new ColumnHeader();
		FUAAy9CoD2 = new ColumnHeader();
		UbNA0nDmTX = new ColumnHeader();
		qmhAB8xpPS = new ColumnHeader();
		tHfAt4aR05 = new ColumnHeader();
		SnYAajpcWi = new ColumnHeader();
		Fy1Aep8qqA = new StatusStrip();
		OwEAMEXabO = new ToolStripStatusLabel();
		f8xAhGX3la.SuspendLayout();
		Fy1Aep8qqA.SuspendLayout();
		SuspendLayout();
		irnAWtKUik.AutoSize = true;
		irnAWtKUik.Location = new Point(11, 55);
		irnAWtKUik.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		irnAWtKUik.Size = new Size(15, 13);
		irnAWtKUik.TabIndex = 3;
		irnAWtKUik.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634);
		b5QApmKOSH.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		b5QApmKOSH.Location = new Point(28, 52);
		b5QApmKOSH.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(58662);
		b5QApmKOSH.Size = new Size(528, 20);
		b5QApmKOSH.TabIndex = 4;
		y6FAZcqKFQ.AutoSize = true;
		y6FAZcqKFQ.Location = new Point(7, 19);
		y6FAZcqKFQ.Margin = new Padding(0);
		y6FAZcqKFQ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10582);
		y6FAZcqKFQ.Size = new Size(56, 13);
		y6FAZcqKFQ.TabIndex = 1;
		y6FAZcqKFQ.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37092);
		y6FAZcqKFQ.TextAlign = ContentAlignment.MiddleRight;
		tLwAfM1ddQ.DropDownStyle = ComboBoxStyle.DropDownList;
		tLwAfM1ddQ.FormattingEnabled = true;
		tLwAfM1ddQ.Location = new Point(64, 14);
		tLwAfM1ddQ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37176);
		tLwAfM1ddQ.Size = new Size(89, 21);
		tLwAfM1ddQ.TabIndex = 2;
		CVDAiNHcyf.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		CVDAiNHcyf.DialogResult = DialogResult.Cancel;
		CVDAiNHcyf.Location = new Point(330, 117);
		CVDAiNHcyf.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34610);
		CVDAiNHcyf.Size = new Size(50, 23);
		CVDAiNHcyf.TabIndex = 7;
		CVDAiNHcyf.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20198);
		CVDAiNHcyf.UseVisualStyleBackColor = true;
		CVDAiNHcyf.Visible = false;
		SSeAsKjWcM.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		SSeAsKjWcM.Location = new Point(503, 117);
		SSeAsKjWcM.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34632);
		SSeAsKjWcM.Size = new Size(50, 23);
		SSeAsKjWcM.TabIndex = 8;
		SSeAsKjWcM.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37454);
		SSeAsKjWcM.UseVisualStyleBackColor = true;
		SSeAsKjWcM.Click += H597uup3tM;
		KFNAq42R9n.Location = new Point(12, 62);
		KFNAq42R9n.MarqueeAnimationSpeed = 50;
		KFNAq42R9n.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37366);
		KFNAq42R9n.Size = new Size(546, 23);
		KFNAq42R9n.TabIndex = 9;
		KFNAq42R9n.Visible = false;
		BYPAKwi0ji.BackColor = Color.Transparent;
		BYPAKwi0ji.Location = new Point(11, 33);
		BYPAKwi0ji.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37114);
		BYPAKwi0ji.Size = new Size(547, 17);
		BYPAKwi0ji.TabIndex = 10;
		BYPAKwi0ji.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10482);
		BYPAKwi0ji.TextAlign = ContentAlignment.MiddleCenter;
		BYPAKwi0ji.Visible = false;
		f8xAhGX3la.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		f8xAhGX3la.Controls.Add(YyIAxPrFWw);
		f8xAhGX3la.Controls.Add(SSeAsKjWcM);
		f8xAhGX3la.Controls.Add(CVDAiNHcyf);
		f8xAhGX3la.Controls.Add(muSAmpke0N);
		f8xAhGX3la.Controls.Add(yfKAnr9H53);
		f8xAhGX3la.Controls.Add(irnAWtKUik);
		f8xAhGX3la.Controls.Add(b5QApmKOSH);
		f8xAhGX3la.Controls.Add(tLwAfM1ddQ);
		f8xAhGX3la.Controls.Add(y6FAZcqKFQ);
		f8xAhGX3la.Location = new Point(1, 3);
		f8xAhGX3la.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10398);
		f8xAhGX3la.Size = new Size(569, 151);
		f8xAhGX3la.TabIndex = 0;
		YyIAxPrFWw.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		YyIAxPrFWw.DialogResult = DialogResult.Cancel;
		YyIAxPrFWw.Location = new Point(447, 117);
		YyIAxPrFWw.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(58674);
		YyIAxPrFWw.Size = new Size(50, 23);
		YyIAxPrFWw.TabIndex = 9;
		YyIAxPrFWw.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(58694);
		YyIAxPrFWw.UseVisualStyleBackColor = true;
		YyIAxPrFWw.Click += sWP7dt1hHg;
		muSAmpke0N.AutoSize = true;
		muSAmpke0N.Location = new Point(11, 85);
		muSAmpke0N.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10482);
		muSAmpke0N.Size = new Size(56, 13);
		muSAmpke0N.TabIndex = 5;
		muSAmpke0N.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(58708);
		yfKAnr9H53.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		yfKAnr9H53.Location = new Point(73, 82);
		yfKAnr9H53.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(58732);
		yfKAnr9H53.Size = new Size(483, 20);
		yfKAnr9H53.TabIndex = 6;
		twhAlAlglg.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		twhAlAlglg.BorderStyle = BorderStyle.None;
		twhAlAlglg.Columns.AddRange(new ColumnHeader[7] { P7EAXUidlR, s1IA2ox1MR, FUAAy9CoD2, UbNA0nDmTX, qmhAB8xpPS, tHfAt4aR05, SnYAajpcWi });
		twhAlAlglg.FullRowSelect = true;
		twhAlAlglg.HideSelection = false;
		twhAlAlglg.Location = new Point(2, 160);
		twhAlAlglg.MultiSelect = false;
		twhAlAlglg.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(58760);
		twhAlAlglg.Size = new Size(568, 382);
		twhAlAlglg.TabIndex = 11;
		twhAlAlglg.UseCompatibleStateImageBehavior = false;
		twhAlAlglg.View = View.Details;
		twhAlAlglg.ColumnClick += iai7jNWoRj;
		twhAlAlglg.SelectedIndexChanged += sqH7AZL5fs;
		P7EAXUidlR.Text = "";
		P7EAXUidlR.Width = 25;
		s1IA2ox1MR.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10770);
		s1IA2ox1MR.Width = 127;
		FUAAy9CoD2.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55068);
		FUAAy9CoD2.Width = 69;
		UbNA0nDmTX.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21126);
		qmhAB8xpPS.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(58794);
		qmhAB8xpPS.Width = 80;
		tHfAt4aR05.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(58816);
		tHfAt4aR05.Width = 85;
		SnYAajpcWi.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(58844);
		SnYAajpcWi.Width = 100;
		Fy1Aep8qqA.Items.AddRange(new ToolStripItem[1] { OwEAMEXabO });
		Fy1Aep8qqA.Location = new Point(0, 545);
		Fy1Aep8qqA.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37836);
		Fy1Aep8qqA.Size = new Size(572, 22);
		Fy1Aep8qqA.SizingGrip = false;
		Fy1Aep8qqA.TabIndex = 12;
		Fy1Aep8qqA.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37836);
		OwEAMEXabO.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(58860);
		OwEAMEXabO.Size = new Size(0, 17);
		base.AcceptButton = SSeAsKjWcM;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = CVDAiNHcyf;
		base.ClientSize = new Size(572, 567);
		base.Controls.Add(Fy1Aep8qqA);
		base.Controls.Add(twhAlAlglg);
		base.Controls.Add(f8xAhGX3la);
		base.Controls.Add(BYPAKwi0ji);
		base.Controls.Add(KFNAq42R9n);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(58884);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(58922);
		base.Activated += ibk7Fh01M6;
		base.FormClosing += cWk7oiXL0F;
		base.Load += P5m7QtK9Vr;
		f8xAhGX3la.ResumeLayout(performLayout: false);
		f8xAhGX3la.PerformLayout();
		Fy1Aep8qqA.ResumeLayout(performLayout: false);
		Fy1Aep8qqA.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static EntitySearchEntry()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}
}
