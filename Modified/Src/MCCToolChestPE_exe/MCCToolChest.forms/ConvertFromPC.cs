using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using afNMf7uWOyq6L7IHxiu;
using MCCToolChest.Forms;
using MCCToolChest.MCSBCode;
using MCCToolChest.model;
using MCCToolChest.PECode;
using MCCToolChest.Properties;
using MCCToolChest.utils;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.forms;

public class ConvertFromPC : Form
{
	private string NGp5qq9ifW;

	private TagNodeCompound PEy5KUe25D;

	private ConvertParameters lup5hhcACh;

	private List<BiomeChange> c925mPNBZ3;

	private BlocksReplaceDefinition kcQ5nASstK;

	private IContainer DYF5lneGuA;

	private GroupBox Xho52syHYe;

	private CheckBox nv25yomDt8;

	private CheckBox Ert50CQAN0;

	private CheckBox taV5BtJN1p;

	private CheckBox vGF5tkGAHt;

	private Button Mjk5a3XnU5;

	private Button jUj5XLW7DD;

	private CheckBox EY75xkDuPy;

	private Button NVM5ex2NNK;

	private Button PF75MJ3XWP;

	private Label Yj45UlqgHt;

	private TextBox a5n5LI7sI4;

	private Button JDt5gbtwZJ;

	private GroupBox fYH5Pxysf6;

	private CheckBox yOs5R5IGju;

	private CheckBox rF25kkxY7i;

	private CheckBox J405Y6fbKO;

	private GroupBox Xeg539Tdpq;

	private RadioButton Jj751CW50J;

	private RadioButton UQY5ENiyj7;

	private RadioButton SUJ5rebt9O;

	private GroupBox FDU55xEiLi;

	private Label UbQ56EWawP;

	private Label O1u5N5Gopa;

	private NumericUpDown MEY5D2OqaV;

	private NumericUpDown ubh5cWBDsG;

	private CheckBox JLa5JPGE0V;

	private GroupBox GWS5uak032;

	private RadioButton ft05ox4arj;

	private RadioButton DyZ5Q5iPJm;

	private Button LI25O3I3qC;

	private GroupBox x1F5CKyOkg;

	private Button CP457RDdiq;

	private CheckBox MRF5AcmWJf;

	private RadioButton lkn5dB8flx;

	private Button KDv5H90cfe;

	private GroupBox cfO5Fm1t8v;

	private Button U4v5jLGGSx;

	private GroupBox n2d58qsKIj;

	private CheckBox M4K59rym8C;

	public ConvertParameters ConvertParameters
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return lup5hhcACh;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ConvertFromPC()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		NGp5qq9ifW = "";
		PGV5sPN3c8();
		c925mPNBZ3 = Utils.ReadBiomeChanges(ConvertType.FROM_PC);
		kcQ5nASstK = Utils.ReadBlockChangesII(ConvertType.FROM_PC);
		a5n5LI7sI4.Text = Utils.ReadConvertFromPCFolder();
		yOs5R5IGju.Checked = true;
		rF25kkxY7i.Checked = true;
		J405Y6fbKO.Checked = true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void jllrIFpo0c(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BiomeAssignment biomeAssignment = new BiomeAssignment(c925mPNBZ3);
		if (biomeAssignment.ShowDialog(this) == DialogResult.OK)
		{
			c925mPNBZ3 = biomeAssignment.BiomeList;
			Utils.SaveBiomeChanges(ConvertType.FROM_PC, c925mPNBZ3);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void rMBrz2tTHO(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ReplaceBlocksUI replaceBlocksUI = new ReplaceBlocksUI(kcQ5nASstK, ConvertType.FROM_PC);
		if (replaceBlocksUI.ShowDialog(this) == DialogResult.OK)
		{
			kcQ5nASstK = replaceBlocksUI.blocksReplaceDefinition;
			Utils.SaveBlockChangesII(ConvertType.FROM_PC, kcQ5nASstK);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void IOh5TlihaX(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (sOk541rDhT(FileUtils.CheckFolderSep(a5n5LI7sI4.Text)))
		{
			lup5hhcACh = new ConvertParameters();
			lup5hhcACh.ConvertOverworld = nv25yomDt8.Checked;
			lup5hhcACh.ConvertNether = taV5BtJN1p.Checked;
			lup5hhcACh.ConvertTheEnd = Ert50CQAN0.Checked;
			lup5hhcACh.ReplaceBiomes = vGF5tkGAHt.Checked;
			lup5hhcACh.BiomeChanges = c925mPNBZ3;
			lup5hhcACh.ReplaceBlocks = EY75xkDuPy.Checked;
			lup5hhcACh.BlockChanges = kcQ5nASstK;
			lup5hhcACh.PCWorldFolder = FileUtils.CheckFolderSep(a5n5LI7sI4.Text);
			lup5hhcACh.ConvertTileEntities = yOs5R5IGju.Checked;
			lup5hhcACh.ConvertEntities = rF25kkxY7i.Checked;
			lup5hhcACh.ItemIdString = J405Y6fbKO.Checked;
			lup5hhcACh.ItemIdString = false;
			lup5hhcACh.UpdateLevelData = MRF5AcmWJf.Checked;
			lup5hhcACh.ModifiedLevelNode = PEy5KUe25D;
			lup5hhcACh.ConvertInto = pVN5SWjVUx();
			lup5hhcACh.FlatworldLayers = NGp5qq9ifW;
			lup5hhcACh.RunPostProcessing = M4K59rym8C.Checked;
			if (JLa5JPGE0V.Checked)
			{
				lup5hhcACh.UseConvertOffsets = true;
				lup5hhcACh.XRegionOffset = (int)ubh5cWBDsG.Value;
				lup5hhcACh.ZRegionOffset = (int)MEY5D2OqaV.Value;
			}
			if (lkn5dB8flx.Checked)
			{
				lup5hhcACh.ConvertToFormat = ConversionFormat.Aquatic113;
			}
			else if (ft05ox4arj.Checked)
			{
				lup5hhcACh.ConvertToFormat = ConversionFormat.Aquatic;
			}
			else if (DyZ5Q5iPJm.Checked)
			{
				lup5hhcACh.ConvertToFormat = ConversionFormat.PreAquatic;
			}
			Utils.SaveConvertFromPCFolder(lup5hhcACh.PCWorldFolder);
			base.DialogResult = DialogResult.OK;
			Close();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ConvertIntoType pVN5SWjVUx()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (SUJ5rebt9O.Checked)
		{
			return ConvertIntoType.EmptyWorld;
		}
		if (UQY5ENiyj7.Checked)
		{
			return ConvertIntoType.EmptyDimension;
		}
		if (Jj751CW50J.Checked)
		{
			return ConvertIntoType.OccupiedDimension;
		}
		return ConvertIntoType.EmptyWorld;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ggm5GGl7hF(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		tV95bZbgcx();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void tV95bZbgcx()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = peZ5vYpGWm();
		if (!string.IsNullOrWhiteSpace(text))
		{
			a5n5LI7sI4.Text = FileUtils.CheckFolderSep(text);
			Tj95fskWha();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string peZ5vYpGWm()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string result = string.Empty;
		string text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41764);
		if (Directory.Exists(Utils.GetGetMCPCSaveFolder()))
		{
			MCPCFolder mCPCFolder = new MCPCFolder(PCSelectDisplayType.Source);
			DialogResult dialogResult = mCPCFolder.ShowDialog(this);
			if (dialogResult == DialogResult.OK)
			{
				result = ((mCPCFolder.p6rjbal2h5() != 0) ? SFR5wq1tTU(text) : mCPCFolder.PCWorldFolder);
			}
		}
		else
		{
			result = SFR5wq1tTU(text);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string SFR5wq1tTU(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return FileUtils.W66SgJArfAS(Utils.GetGetMCPCSaveFolder(), P_0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool sOk541rDhT(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bool flag = true;
		StringBuilder stringBuilder = new StringBuilder();
		string text = FileUtils.CheckFolderSep(P_0) + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21936);
		string folderPath = FileUtils.CheckFolderSep(P_0) + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43780);
		string folderPath2 = FileUtils.CheckFolderSep(P_0) + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43794);
		string[] files = Directory.GetFiles(text, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43806));
		string[] files2 = Directory.GetFiles(text, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40696));
		if (files.Length > 0 && files2.Length == 0)
		{
			MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43820), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(44222));
			flag = false;
		}
		else
		{
			if (!FileUtils.CheckFolderExists(P_0))
			{
				flag = false;
				stringBuilder.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(44260));
			}
			if (flag)
			{
				if (nv25yomDt8.Checked && !FileUtils.CheckFolderExists(text))
				{
					stringBuilder.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(44308));
				}
				if (taV5BtJN1p.Checked && !FileUtils.CheckFolderExists(folderPath))
				{
					stringBuilder.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(44360));
				}
				if (Ert50CQAN0.Checked && !FileUtils.CheckFolderExists(folderPath2))
				{
					stringBuilder.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(44410));
				}
			}
			if (stringBuilder.Length > 0)
			{
				MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(44458) + Environment.NewLine + stringBuilder.ToString(), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(44564));
				flag = false;
			}
		}
		return flag;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CqT5Ve7FtI(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.Icon = Resources.usMSrbJo37S();
		tV95bZbgcx();
		Tj95fskWha();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LqM5Wwqq64(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ConvertOffsetDisplay convertOffsetDisplay = new ConvertOffsetDisplay(FileUtils.CheckFolderSep(a5n5LI7sI4.Text), (int)ubh5cWBDsG.Value, (int)MEY5D2OqaV.Value);
		DialogResult dialogResult = convertOffsetDisplay.ShowDialog(this);
		if (dialogResult == DialogResult.OK)
		{
			ubh5cWBDsG.Value = convertOffsetDisplay.RxOffset;
			MEY5D2OqaV.Value = convertOffsetDisplay.RzOffset;
			JLa5JPGE0V.Checked = true;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void iYr5pKo5rU(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound tagNodeCompound = PEUtility.LoadPELevel(Working.T92StMGt1p4());
		TagNodeCompound tagNodeCompound2 = PEy5KUe25D;
		if (tagNodeCompound2 == null)
		{
			TagNodeCompound tagNodeCompound3 = MCSupport.xTjSGcOSfFO(FileUtils.CheckFolderSep(a5n5LI7sI4.Text));
			tagNodeCompound2 = MCSupport.t5dSGdITJ6h((TagNodeCompound)tagNodeCompound.Copy(), tagNodeCompound3, pVN5SWjVUx(), NGp5qq9ifW);
		}
		NBTBeforeAfter nBTBeforeAfter = new NBTBeforeAfter(tagNodeCompound, (TagNodeCompound)tagNodeCompound2.Copy());
		DialogResult dialogResult = nBTBeforeAfter.ShowDialog(this);
		if (dialogResult == DialogResult.OK)
		{
			PEy5KUe25D = nBTBeforeAfter.afterNode;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void t0i5ZYjXJw(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		FlatWorldLayersEditor flatWorldLayersEditor = new FlatWorldLayersEditor(NGp5qq9ifW);
		if (flatWorldLayersEditor.ShowDialog(this) == DialogResult.OK)
		{
			NGp5qq9ifW = flatWorldLayersEditor.FlatWorldLayers;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Tj95fskWha()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound tagNodeCompound = MCSupport.xTjSGcOSfFO(FileUtils.CheckFolderSep(a5n5LI7sI4.Text));
		TagNode tagNode = null;
		try
		{
			if (tagNodeCompound != null)
			{
				TagNodeCompound tagNodeCompound2 = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11178)] as TagNodeCompound;
				if (tagNodeCompound2.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(44612)))
				{
					tagNode = tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(44612)];
				}
			}
		}
		catch (Exception)
		{
		}
		try
		{
			if (tagNode != null)
			{
				NGp5qq9ifW = lxe7hMuSirBXGUQugsD.ClQSP9TgpRp(tagNode);
			}
		}
		catch (Exception)
		{
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ON45iyBlPG(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PostProcessing postProcessing = new PostProcessing();
		postProcessing.ShowDialog(this);
		_ = 1;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && DYF5lneGuA != null)
		{
			DYF5lneGuA.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PGV5sPN3c8()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(ConvertFromPC));
		Xho52syHYe = new GroupBox();
		Ert50CQAN0 = new CheckBox();
		taV5BtJN1p = new CheckBox();
		nv25yomDt8 = new CheckBox();
		vGF5tkGAHt = new CheckBox();
		Mjk5a3XnU5 = new Button();
		jUj5XLW7DD = new Button();
		EY75xkDuPy = new CheckBox();
		NVM5ex2NNK = new Button();
		PF75MJ3XWP = new Button();
		Yj45UlqgHt = new Label();
		a5n5LI7sI4 = new TextBox();
		JDt5gbtwZJ = new Button();
		fYH5Pxysf6 = new GroupBox();
		yOs5R5IGju = new CheckBox();
		rF25kkxY7i = new CheckBox();
		J405Y6fbKO = new CheckBox();
		Xeg539Tdpq = new GroupBox();
		Jj751CW50J = new RadioButton();
		UQY5ENiyj7 = new RadioButton();
		SUJ5rebt9O = new RadioButton();
		FDU55xEiLi = new GroupBox();
		LI25O3I3qC = new Button();
		UbQ56EWawP = new Label();
		O1u5N5Gopa = new Label();
		MEY5D2OqaV = new NumericUpDown();
		ubh5cWBDsG = new NumericUpDown();
		JLa5JPGE0V = new CheckBox();
		GWS5uak032 = new GroupBox();
		lkn5dB8flx = new RadioButton();
		ft05ox4arj = new RadioButton();
		DyZ5Q5iPJm = new RadioButton();
		x1F5CKyOkg = new GroupBox();
		CP457RDdiq = new Button();
		MRF5AcmWJf = new CheckBox();
		KDv5H90cfe = new Button();
		cfO5Fm1t8v = new GroupBox();
		U4v5jLGGSx = new Button();
		n2d58qsKIj = new GroupBox();
		M4K59rym8C = new CheckBox();
		Xho52syHYe.SuspendLayout();
		fYH5Pxysf6.SuspendLayout();
		Xeg539Tdpq.SuspendLayout();
		FDU55xEiLi.SuspendLayout();
		((ISupportInitialize)MEY5D2OqaV).BeginInit();
		((ISupportInitialize)ubh5cWBDsG).BeginInit();
		GWS5uak032.SuspendLayout();
		x1F5CKyOkg.SuspendLayout();
		cfO5Fm1t8v.SuspendLayout();
		n2d58qsKIj.SuspendLayout();
		SuspendLayout();
		Xho52syHYe.Controls.Add(Ert50CQAN0);
		Xho52syHYe.Controls.Add(taV5BtJN1p);
		Xho52syHYe.Controls.Add(nv25yomDt8);
		Xho52syHYe.Location = new Point(12, 68);
		Xho52syHYe.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41880);
		Xho52syHYe.Size = new Size(125, 101);
		Xho52syHYe.TabIndex = 0;
		Xho52syHYe.TabStop = false;
		Xho52syHYe.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41902);
		Ert50CQAN0.AutoSize = true;
		Ert50CQAN0.Location = new Point(21, 76);
		Ert50CQAN0.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28714);
		Ert50CQAN0.Size = new Size(67, 17);
		Ert50CQAN0.TabIndex = 2;
		Ert50CQAN0.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28734);
		Ert50CQAN0.UseVisualStyleBackColor = true;
		taV5BtJN1p.AutoSize = true;
		taV5BtJN1p.Location = new Point(21, 49);
		taV5BtJN1p.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28752);
		taV5BtJN1p.Size = new Size(58, 17);
		taV5BtJN1p.TabIndex = 1;
		taV5BtJN1p.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28772);
		taV5BtJN1p.UseVisualStyleBackColor = true;
		nv25yomDt8.AutoSize = true;
		nv25yomDt8.Checked = true;
		nv25yomDt8.CheckState = CheckState.Checked;
		nv25yomDt8.Location = new Point(21, 23);
		nv25yomDt8.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28666);
		nv25yomDt8.Size = new Size(74, 17);
		nv25yomDt8.TabIndex = 0;
		nv25yomDt8.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28692);
		nv25yomDt8.UseVisualStyleBackColor = true;
		vGF5tkGAHt.AutoSize = true;
		vGF5tkGAHt.Location = new Point(321, 75);
		vGF5tkGAHt.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41940);
		vGF5tkGAHt.Size = new Size(103, 17);
		vGF5tkGAHt.TabIndex = 1;
		vGF5tkGAHt.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(36574);
		vGF5tkGAHt.UseVisualStyleBackColor = true;
		Mjk5a3XnU5.Location = new Point(321, 93);
		Mjk5a3XnU5.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41972);
		Mjk5a3XnU5.Size = new Size(87, 23);
		Mjk5a3XnU5.TabIndex = 2;
		Mjk5a3XnU5.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41992);
		Mjk5a3XnU5.UseVisualStyleBackColor = true;
		Mjk5a3XnU5.Click += jllrIFpo0c;
		jUj5XLW7DD.Location = new Point(321, 146);
		jUj5XLW7DD.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42008);
		jUj5XLW7DD.Size = new Size(87, 23);
		jUj5XLW7DD.TabIndex = 4;
		jUj5XLW7DD.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38788);
		jUj5XLW7DD.UseVisualStyleBackColor = true;
		jUj5XLW7DD.Visible = false;
		jUj5XLW7DD.Click += rMBrz2tTHO;
		EY75xkDuPy.AutoSize = true;
		EY75xkDuPy.Location = new Point(321, 128);
		EY75xkDuPy.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37742);
		EY75xkDuPy.Size = new Size(101, 17);
		EY75xkDuPy.TabIndex = 3;
		EY75xkDuPy.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42028);
		EY75xkDuPy.UseVisualStyleBackColor = true;
		EY75xkDuPy.Visible = false;
		NVM5ex2NNK.DialogResult = DialogResult.Cancel;
		NVM5ex2NNK.Location = new Point(413, 523);
		NVM5ex2NNK.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34610);
		NVM5ex2NNK.Size = new Size(75, 23);
		NVM5ex2NNK.TabIndex = 5;
		NVM5ex2NNK.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20198);
		NVM5ex2NNK.UseVisualStyleBackColor = true;
		PF75MJ3XWP.Location = new Point(327, 523);
		PF75MJ3XWP.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23078);
		PF75MJ3XWP.Size = new Size(75, 23);
		PF75MJ3XWP.TabIndex = 6;
		PF75MJ3XWP.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23102);
		PF75MJ3XWP.UseVisualStyleBackColor = true;
		PF75MJ3XWP.Click += IOh5TlihaX;
		Yj45UlqgHt.AutoSize = true;
		Yj45UlqgHt.Location = new Point(12, 17);
		Yj45UlqgHt.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		Yj45UlqgHt.Size = new Size(134, 13);
		Yj45UlqgHt.TabIndex = 7;
		Yj45UlqgHt.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42284);
		a5n5LI7sI4.Location = new Point(12, 30);
		a5n5LI7sI4.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42256);
		a5n5LI7sI4.Size = new Size(458, 20);
		a5n5LI7sI4.TabIndex = 8;
		JDt5gbtwZJ.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42184));
		JDt5gbtwZJ.Location = new Point(472, 30);
		JDt5gbtwZJ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42226);
		JDt5gbtwZJ.Size = new Size(20, 20);
		JDt5gbtwZJ.TabIndex = 9;
		JDt5gbtwZJ.UseVisualStyleBackColor = true;
		JDt5gbtwZJ.Click += ggm5GGl7hF;
		fYH5Pxysf6.Controls.Add(yOs5R5IGju);
		fYH5Pxysf6.Controls.Add(rF25kkxY7i);
		fYH5Pxysf6.Location = new Point(159, 68);
		fYH5Pxysf6.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42144);
		fYH5Pxysf6.Size = new Size(125, 101);
		fYH5Pxysf6.TabIndex = 10;
		fYH5Pxysf6.TabStop = false;
		fYH5Pxysf6.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42166);
		yOs5R5IGju.AutoSize = true;
		yOs5R5IGju.Checked = true;
		yOs5R5IGju.CheckState = CheckState.Checked;
		yOs5R5IGju.Location = new Point(21, 23);
		yOs5R5IGju.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42060);
		yOs5R5IGju.Size = new Size(90, 17);
		yOs5R5IGju.TabIndex = 7;
		yOs5R5IGju.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42092);
		yOs5R5IGju.UseVisualStyleBackColor = true;
		rF25kkxY7i.AutoSize = true;
		rF25kkxY7i.Checked = true;
		rF25kkxY7i.CheckState = CheckState.Checked;
		rF25kkxY7i.Location = new Point(21, 49);
		rF25kkxY7i.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17194);
		rF25kkxY7i.Size = new Size(60, 17);
		rF25kkxY7i.TabIndex = 8;
		rF25kkxY7i.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42124);
		rF25kkxY7i.UseVisualStyleBackColor = true;
		J405Y6fbKO.AutoSize = true;
		J405Y6fbKO.Location = new Point(15, 182);
		J405Y6fbKO.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43132);
		J405Y6fbKO.Size = new Size(137, 17);
		J405Y6fbKO.TabIndex = 13;
		J405Y6fbKO.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43168);
		J405Y6fbKO.UseVisualStyleBackColor = true;
		J405Y6fbKO.Visible = false;
		Xeg539Tdpq.Controls.Add(Jj751CW50J);
		Xeg539Tdpq.Controls.Add(UQY5ENiyj7);
		Xeg539Tdpq.Controls.Add(SUJ5rebt9O);
		Xeg539Tdpq.Location = new Point(15, 182);
		Xeg539Tdpq.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42342);
		Xeg539Tdpq.Size = new Size(171, 94);
		Xeg539Tdpq.TabIndex = 14;
		Xeg539Tdpq.TabStop = false;
		Xeg539Tdpq.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42908);
		Jj751CW50J.AutoSize = true;
		Jj751CW50J.Location = new Point(21, 65);
		Jj751CW50J.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42936);
		Jj751CW50J.Size = new Size(123, 17);
		Jj751CW50J.TabIndex = 17;
		Jj751CW50J.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42974);
		Jj751CW50J.UseVisualStyleBackColor = true;
		UQY5ENiyj7.AutoSize = true;
		UQY5ENiyj7.Checked = true;
		UQY5ENiyj7.Location = new Point(21, 42);
		UQY5ENiyj7.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43014);
		UQY5ENiyj7.Size = new Size(106, 17);
		UQY5ENiyj7.TabIndex = 16;
		UQY5ENiyj7.TabStop = true;
		UQY5ENiyj7.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43044);
		UQY5ENiyj7.UseVisualStyleBackColor = true;
		SUJ5rebt9O.AutoSize = true;
		SUJ5rebt9O.Location = new Point(21, 19);
		SUJ5rebt9O.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43078);
		SUJ5rebt9O.Size = new Size(85, 17);
		SUJ5rebt9O.TabIndex = 15;
		SUJ5rebt9O.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43106);
		SUJ5rebt9O.UseVisualStyleBackColor = true;
		FDU55xEiLi.Controls.Add(LI25O3I3qC);
		FDU55xEiLi.Controls.Add(UbQ56EWawP);
		FDU55xEiLi.Controls.Add(O1u5N5Gopa);
		FDU55xEiLi.Controls.Add(MEY5D2OqaV);
		FDU55xEiLi.Controls.Add(ubh5cWBDsG);
		FDU55xEiLi.Controls.Add(JLa5JPGE0V);
		FDU55xEiLi.Location = new Point(202, 182);
		FDU55xEiLi.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42570);
		FDU55xEiLi.Size = new Size(183, 94);
		FDU55xEiLi.TabIndex = 15;
		FDU55xEiLi.TabStop = false;
		FDU55xEiLi.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42592);
		LI25O3I3qC.Location = new Point(104, 13);
		LI25O3I3qC.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42624);
		LI25O3I3qC.Size = new Size(73, 23);
		LI25O3I3qC.TabIndex = 5;
		LI25O3I3qC.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42648);
		LI25O3I3qC.UseVisualStyleBackColor = true;
		LI25O3I3qC.Click += LqM5Wwqq64;
		UbQ56EWawP.AutoSize = true;
		UbQ56EWawP.Location = new Point(75, 66);
		UbQ56EWawP.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10482);
		UbQ56EWawP.Size = new Size(82, 13);
		UbQ56EWawP.TabIndex = 4;
		UbQ56EWawP.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42672);
		O1u5N5Gopa.AutoSize = true;
		O1u5N5Gopa.Location = new Point(75, 42);
		O1u5N5Gopa.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10582);
		O1u5N5Gopa.Size = new Size(82, 13);
		O1u5N5Gopa.TabIndex = 3;
		O1u5N5Gopa.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42706);
		MEY5D2OqaV.Location = new Point(25, 64);
		MEY5D2OqaV.Maximum = new decimal(new int[4] { 10000, 0, 0, 0 });
		MEY5D2OqaV.Minimum = new decimal(new int[4] { 10000, 0, 0, -2147483648 });
		MEY5D2OqaV.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42740);
		MEY5D2OqaV.Size = new Size(43, 20);
		MEY5D2OqaV.TabIndex = 2;
		ubh5cWBDsG.Location = new Point(25, 39);
		ubh5cWBDsG.Maximum = new decimal(new int[4] { 10000, 0, 0, 0 });
		ubh5cWBDsG.Minimum = new decimal(new int[4] { 10000, 0, 0, -2147483648 });
		ubh5cWBDsG.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42776);
		ubh5cWBDsG.Size = new Size(43, 20);
		ubh5cWBDsG.TabIndex = 1;
		JLa5JPGE0V.AutoSize = true;
		JLa5JPGE0V.Location = new Point(25, 20);
		JLa5JPGE0V.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42812);
		JLa5JPGE0V.Size = new Size(81, 17);
		JLa5JPGE0V.TabIndex = 0;
		JLa5JPGE0V.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42860);
		JLa5JPGE0V.UseVisualStyleBackColor = true;
		GWS5uak032.Controls.Add(lkn5dB8flx);
		GWS5uak032.Controls.Add(ft05ox4arj);
		GWS5uak032.Controls.Add(DyZ5Q5iPJm);
		GWS5uak032.Location = new Point(15, 294);
		GWS5uak032.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42886);
		GWS5uak032.Size = new Size(171, 94);
		GWS5uak032.TabIndex = 18;
		GWS5uak032.TabStop = false;
		GWS5uak032.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43242);
		lkn5dB8flx.AutoSize = true;
		lkn5dB8flx.Location = new Point(21, 20);
		lkn5dB8flx.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(44648);
		lkn5dB8flx.Size = new Size(126, 17);
		lkn5dB8flx.TabIndex = 17;
		lkn5dB8flx.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(44688);
		lkn5dB8flx.UseVisualStyleBackColor = true;
		ft05ox4arj.AutoSize = true;
		ft05ox4arj.Checked = true;
		ft05ox4arj.Location = new Point(21, 43);
		ft05ox4arj.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43318);
		ft05ox4arj.Size = new Size(120, 17);
		ft05ox4arj.TabIndex = 16;
		ft05ox4arj.TabStop = true;
		ft05ox4arj.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(44732);
		ft05ox4arj.UseVisualStyleBackColor = true;
		DyZ5Q5iPJm.AutoSize = true;
		DyZ5Q5iPJm.Location = new Point(21, 66);
		DyZ5Q5iPJm.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43378);
		DyZ5Q5iPJm.Size = new Size(115, 17);
		DyZ5Q5iPJm.TabIndex = 15;
		DyZ5Q5iPJm.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(44774);
		DyZ5Q5iPJm.UseVisualStyleBackColor = true;
		x1F5CKyOkg.Controls.Add(CP457RDdiq);
		x1F5CKyOkg.Controls.Add(MRF5AcmWJf);
		x1F5CKyOkg.Location = new Point(15, 404);
		x1F5CKyOkg.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43444);
		x1F5CKyOkg.Size = new Size(171, 82);
		x1F5CKyOkg.TabIndex = 21;
		x1F5CKyOkg.TabStop = false;
		x1F5CKyOkg.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43466);
		CP457RDdiq.Location = new Point(19, 39);
		CP457RDdiq.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43482);
		CP457RDdiq.Size = new Size(69, 23);
		CP457RDdiq.TabIndex = 8;
		CP457RDdiq.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43516);
		CP457RDdiq.UseVisualStyleBackColor = true;
		CP457RDdiq.Click += iYr5pKo5rU;
		MRF5AcmWJf.AutoSize = true;
		MRF5AcmWJf.Checked = true;
		MRF5AcmWJf.CheckState = CheckState.Checked;
		MRF5AcmWJf.Location = new Point(21, 21);
		MRF5AcmWJf.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43538);
		MRF5AcmWJf.Size = new Size(70, 17);
		MRF5AcmWJf.TabIndex = 7;
		MRF5AcmWJf.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43574);
		MRF5AcmWJf.UseVisualStyleBackColor = true;
		KDv5H90cfe.Location = new Point(19, 22);
		KDv5H90cfe.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(44814);
		KDv5H90cfe.Size = new Size(87, 23);
		KDv5H90cfe.TabIndex = 22;
		KDv5H90cfe.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11650);
		KDv5H90cfe.UseVisualStyleBackColor = true;
		KDv5H90cfe.Click += t0i5ZYjXJw;
		cfO5Fm1t8v.Controls.Add(KDv5H90cfe);
		cfO5Fm1t8v.Location = new Point(208, 294);
		cfO5Fm1t8v.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43220);
		cfO5Fm1t8v.Size = new Size(125, 74);
		cfO5Fm1t8v.TabIndex = 23;
		cfO5Fm1t8v.TabStop = false;
		cfO5Fm1t8v.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(44854);
		U4v5jLGGSx.Location = new Point(19, 39);
		U4v5jLGGSx.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(44878);
		U4v5jLGGSx.Size = new Size(87, 23);
		U4v5jLGGSx.TabIndex = 22;
		U4v5jLGGSx.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(44916);
		U4v5jLGGSx.UseVisualStyleBackColor = true;
		U4v5jLGGSx.Click += ON45iyBlPG;
		n2d58qsKIj.Controls.Add(M4K59rym8C);
		n2d58qsKIj.Controls.Add(U4v5jLGGSx);
		n2d58qsKIj.Location = new Point(360, 294);
		n2d58qsKIj.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(44938);
		n2d58qsKIj.Size = new Size(125, 74);
		n2d58qsKIj.TabIndex = 24;
		n2d58qsKIj.TabStop = false;
		n2d58qsKIj.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34758);
		M4K59rym8C.AutoSize = true;
		M4K59rym8C.Checked = true;
		M4K59rym8C.CheckState = CheckState.Checked;
		M4K59rym8C.Location = new Point(19, 21);
		M4K59rym8C.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(44960);
		M4K59rym8C.Size = new Size(46, 17);
		M4K59rym8C.TabIndex = 23;
		M4K59rym8C.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28806);
		M4K59rym8C.UseVisualStyleBackColor = true;
		base.AcceptButton = PF75MJ3XWP;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = NVM5ex2NNK;
		base.ClientSize = new Size(504, 574);
		base.Controls.Add(n2d58qsKIj);
		base.Controls.Add(cfO5Fm1t8v);
		base.Controls.Add(x1F5CKyOkg);
		base.Controls.Add(GWS5uak032);
		base.Controls.Add(FDU55xEiLi);
		base.Controls.Add(Xeg539Tdpq);
		base.Controls.Add(J405Y6fbKO);
		base.Controls.Add(fYH5Pxysf6);
		base.Controls.Add(JDt5gbtwZJ);
		base.Controls.Add(a5n5LI7sI4);
		base.Controls.Add(Yj45UlqgHt);
		base.Controls.Add(PF75MJ3XWP);
		base.Controls.Add(NVM5ex2NNK);
		base.Controls.Add(jUj5XLW7DD);
		base.Controls.Add(EY75xkDuPy);
		base.Controls.Add(Mjk5a3XnU5);
		base.Controls.Add(vGF5tkGAHt);
		base.Controls.Add(Xho52syHYe);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(45002);
		base.SizeGripStyle = SizeGripStyle.Hide;
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(45032);
		base.Load += CqT5Ve7FtI;
		Xho52syHYe.ResumeLayout(performLayout: false);
		Xho52syHYe.PerformLayout();
		fYH5Pxysf6.ResumeLayout(performLayout: false);
		fYH5Pxysf6.PerformLayout();
		Xeg539Tdpq.ResumeLayout(performLayout: false);
		Xeg539Tdpq.PerformLayout();
		FDU55xEiLi.ResumeLayout(performLayout: false);
		FDU55xEiLi.PerformLayout();
		((ISupportInitialize)MEY5D2OqaV).EndInit();
		((ISupportInitialize)ubh5cWBDsG).EndInit();
		GWS5uak032.ResumeLayout(performLayout: false);
		GWS5uak032.PerformLayout();
		x1F5CKyOkg.ResumeLayout(performLayout: false);
		x1F5CKyOkg.PerformLayout();
		cfO5Fm1t8v.ResumeLayout(performLayout: false);
		n2d58qsKIj.ResumeLayout(performLayout: false);
		n2d58qsKIj.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
