using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
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

public class ConvertToPC : Form
{
	private string[] mMGrsqUVJ2;

	private TagNodeCompound bhmrqBVBsQ;

	private ConvertParameters r4UrK61OlZ;

	private List<BiomeChange> jeQrh0X4Yg;

	private string Cd7rmMVeWE;

	private BlocksReplaceDefinition aefrngLTFh;

	private IContainer KNqrl3sUgA;

	private GroupBox Newr23qPKm;

	private CheckBox q53ryoJr9c;

	private CheckBox yrsr0JI2x1;

	private CheckBox UytrB4PKDe;

	private CheckBox k6xrtxyQtX;

	private Button I9eraNGbqT;

	private Button VEdrXiljH7;

	private CheckBox nbvrxDEjoC;

	private Button OpyreFCmUV;

	private Button f10rMVUSyh;

	private CheckBox zp3rUcvZuF;

	private CheckBox XSCrLGFYnP;

	private GroupBox HUhrg6PBYx;

	private Button qJbrPMWu7e;

	private TextBox B4JrR5rHyg;

	private Label hMSrkPyGky;

	private GroupBox O4NrYm28Hg;

	private RadioButton gUAr3ZFneR;

	private RadioButton SAXr1ra0sG;

	private GroupBox wqWrEa7jj8;

	private Button RlbrrQryNG;

	private Label gJ6r53m4JH;

	private Label sT7r6ZttWG;

	private NumericUpDown eu1rNQWLM1;

	private NumericUpDown VWErDpWCIK;

	private CheckBox M67rcYX5a8;

	private GroupBox jhfrJ3MCCG;

	private RadioButton emQruDVPTP;

	private RadioButton Vhqrojy0SU;

	private RadioButton dnMrQJahkN;

	private CheckBox vlYrOV1iRZ;

	private GroupBox KSwrCDPU3J;

	private RadioButton YHQr7nV7yO;

	private RadioButton RfYrAZCdHT;

	private GroupBox HZFrdHhmZT;

	private CheckBox s2UrHQcVwZ;

	private Button upJrF4WdmU;

	private GroupBox fPFrjaR97Z;

	private ComboBox B0Nr8El7JF;

	private RadioButton UlAr9MsMMV;

	public ConvertParameters ConvertParameters
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return r4UrK61OlZ;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ConvertToPC()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		mMGrsqUVJ2 = new string[10]
		{
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41390),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41404),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41416),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41432),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41462),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41484),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41502),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41530),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41552),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41564)
		};
		Cd7rmMVeWE = "";
		ns6riT2Nf2();
		jeQrh0X4Yg = Utils.ReadBiomeChanges(ConvertType.TO_PC);
		aefrngLTFh = Utils.ReadBlockChangesII(ConvertType.TO_PC);
		B4JrR5rHyg.Text = Utils.ReadConvertToPCFolder();
		B0Nr8El7JF.DataSource = mMGrsqUVJ2;
		B0Nr8El7JF.SelectedIndex = 8;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void KmoEjyV9bY(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BiomeAssignment biomeAssignment = new BiomeAssignment(jeQrh0X4Yg);
		if (biomeAssignment.ShowDialog(this) == DialogResult.OK)
		{
			jeQrh0X4Yg = biomeAssignment.BiomeList;
			Utils.SaveBiomeChanges(ConvertType.TO_PC, jeQrh0X4Yg);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void r02E8WIcDc(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ReplaceBlocksUI replaceBlocksUI = new ReplaceBlocksUI(aefrngLTFh, ConvertType.TO_PC);
		if (replaceBlocksUI.ShowDialog(this) == DialogResult.OK)
		{
			aefrngLTFh = replaceBlocksUI.blocksReplaceDefinition;
			Utils.SaveBlockChangesII(ConvertType.TO_PC, aefrngLTFh);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void sGrE9qx7gJ(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (fslEIfeAkw(B4JrR5rHyg.Text))
		{
			r4UrK61OlZ = new ConvertParameters();
			r4UrK61OlZ.ConvertOverworld = q53ryoJr9c.Checked;
			r4UrK61OlZ.ConvertNether = UytrB4PKDe.Checked;
			r4UrK61OlZ.ConvertTheEnd = yrsr0JI2x1.Checked;
			r4UrK61OlZ.ReplaceBiomes = k6xrtxyQtX.Checked;
			r4UrK61OlZ.BiomeChanges = jeQrh0X4Yg;
			r4UrK61OlZ.ReplaceBlocks = nbvrxDEjoC.Checked;
			r4UrK61OlZ.BlockChanges = aefrngLTFh;
			r4UrK61OlZ.PCWorldFolder = FileUtils.CheckFolderSep(B4JrR5rHyg.Text);
			r4UrK61OlZ.ConvertTileEntities = zp3rUcvZuF.Checked;
			r4UrK61OlZ.ConvertEntities = XSCrLGFYnP.Checked;
			r4UrK61OlZ.UseFastConversion = SAXr1ra0sG.Checked;
			r4UrK61OlZ.UpdateLevelData = s2UrHQcVwZ.Checked;
			r4UrK61OlZ.ModifiedLevelNode = bhmrqBVBsQ;
			if (dnMrQJahkN.Checked)
			{
				r4UrK61OlZ.ConvertInto = ConvertIntoType.EmptyWorld;
			}
			else if (Vhqrojy0SU.Checked)
			{
				r4UrK61OlZ.ConvertInto = ConvertIntoType.EmptyDimension;
			}
			else if (emQruDVPTP.Checked)
			{
				r4UrK61OlZ.ConvertInto = ConvertIntoType.OccupiedDimension;
			}
			if (M67rcYX5a8.Checked)
			{
				r4UrK61OlZ.UseConvertOffsets = true;
				r4UrK61OlZ.XRegionOffset = (int)VWErDpWCIK.Value;
				r4UrK61OlZ.ZRegionOffset = (int)eu1rNQWLM1.Value;
			}
			r4UrK61OlZ.ConvertToFormat = ConversionFormat.PreAquatic;
			if (YHQr7nV7yO.Checked)
			{
				r4UrK61OlZ.ConvertToFormat = ConversionFormat.Aquatic;
			}
			if (UlAr9MsMMV.Checked)
			{
				r4UrK61OlZ.ConvertToFormat = ConversionFormat.Aquatic113;
			}
			r4UrK61OlZ.FlatworldLayers = Cd7rmMVeWE;
			r4UrK61OlZ.ChunkStatus = B0Nr8El7JF.SelectedValue as string;
			Utils.SaveConvertToPCFolder(r4UrK61OlZ.PCWorldFolder);
			base.DialogResult = DialogResult.OK;
			Close();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool fslEIfeAkw(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bool flag = true;
		if (string.IsNullOrWhiteSpace(P_0))
		{
			flag = false;
		}
		if (!flag)
		{
			MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41594), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41706));
		}
		return flag;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AQOEzGVQMc(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hk7rTl0LMT();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Hk7rTl0LMT()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = FaMrSBB6Ri();
		if (!string.IsNullOrWhiteSpace(text))
		{
			B4JrR5rHyg.Text = FileUtils.CheckFolderSep(text);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string FaMrSBB6Ri()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string result = string.Empty;
		string text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41764);
		if (Directory.Exists(Utils.GetGetMCPCSaveFolder()))
		{
			MCPCFolder mCPCFolder = new MCPCFolder(PCSelectDisplayType.Destination);
			DialogResult dialogResult = mCPCFolder.ShowDialog(this);
			if (dialogResult == DialogResult.OK)
			{
				result = ((mCPCFolder.p6rjbal2h5() != 0) ? FQlrGnivQO(text) : mCPCFolder.PCWorldFolder);
			}
		}
		else
		{
			result = FQlrGnivQO(text);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string FQlrGnivQO(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return FileUtils.W66SgJArfAS(Utils.GetGetMCPCSaveFolder(), P_0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hgorb0Ncgm(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.Icon = Resources.usMSrbJo37S();
		VfwrZuWdWa();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void m3FrvwNF8r(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PCConvertOffsetDisplay pCConvertOffsetDisplay = new PCConvertOffsetDisplay(FileUtils.CheckFolderSep(B4JrR5rHyg.Text), (int)VWErDpWCIK.Value, (int)eu1rNQWLM1.Value);
		DialogResult dialogResult = pCConvertOffsetDisplay.ShowDialog(this);
		if (dialogResult == DialogResult.OK)
		{
			VWErDpWCIK.Value = pCConvertOffsetDisplay.RxOffset;
			eu1rNQWLM1.Value = pCConvertOffsetDisplay.RzOffset;
			M67rcYX5a8.Checked = true;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void jfqrwXZ0KK(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound tagNodeCompound = MCSupport.xTjSGcOSfFO(FileUtils.CheckFolderSep(B4JrR5rHyg.Text));
		if (tagNodeCompound == null)
		{
			ConversionFormat conversionFormat = ConversionFormat.PreAquatic;
			if (YHQr7nV7yO.Checked)
			{
				conversionFormat = ConversionFormat.Aquatic;
			}
			if (UlAr9MsMMV.Checked)
			{
				conversionFormat = ConversionFormat.Aquatic113;
			}
			tagNodeCompound = MCSupport.xoBSGJvJUoq(conversionFormat);
		}
		TagNodeCompound tagNodeCompound2 = bhmrqBVBsQ;
		if (tagNodeCompound2 == null)
		{
			TagNodeCompound tagNodeCompound3 = PEUtility.LoadPELevel(Working.T92StMGt1p4());
			ConversionFormat conversionFormat2 = ConversionFormat.PreAquatic;
			if (YHQr7nV7yO.Checked)
			{
				conversionFormat2 = ConversionFormat.Aquatic;
			}
			if (UlAr9MsMMV.Checked)
			{
				conversionFormat2 = ConversionFormat.Aquatic113;
			}
			tagNodeCompound2 = MCSupport.erFSG1R4KfQ((TagNodeCompound)tagNodeCompound.Copy(), tagNodeCompound3, conversionFormat2, Working.T92StMGt1p4(), Cd7rmMVeWE);
		}
		NBTBeforeAfter nBTBeforeAfter = new NBTBeforeAfter(tagNodeCompound, (TagNodeCompound)tagNodeCompound2.Copy());
		DialogResult dialogResult = nBTBeforeAfter.ShowDialog(this);
		if (dialogResult == DialogResult.OK)
		{
			bhmrqBVBsQ = nBTBeforeAfter.afterNode;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BHjr4oKQoo(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		plvrpLO0G8();
		B0Nr8El7JF.SelectedIndex = 8;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void fH2rVfcYj4(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		plvrpLO0G8();
		B0Nr8El7JF.SelectedIndex = 4;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ofDrW7lDgH(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		plvrpLO0G8();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void plvrpLO0G8()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		fPFrjaR97Z.Visible = !RfYrAZCdHT.Checked;
		B0Nr8El7JF.SelectedIndex = 8;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void VfwrZuWdWa()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound tagNodeCompound = PEUtility.LoadPELevel(Working.T92StMGt1p4());
		if (tagNodeCompound == null)
		{
			return;
		}
		if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41818)))
		{
			string getMCPCSaveFolder = Utils.GetGetMCPCSaveFolder();
			string text = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41818)] as TagNodeString;
			text = J24rfuaFaR(text);
			B4JrR5rHyg.Text = Path.Combine(getMCPCSaveFolder, text);
		}
		if (!tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41840)))
		{
			return;
		}
		string text2 = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41840)] as TagNodeString;
		if (string.IsNullOrWhiteSpace(text2))
		{
			return;
		}
		try
		{
			FlatWorld flatWorld = lxe7hMuSirBXGUQugsD.ifaSP8IqSLO(text2);
			Cd7rmMVeWE = flatWorld.ToJava();
		}
		catch (Exception)
		{
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string J24rfuaFaR(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
		string text2 = text;
		for (int i = 0; i < text2.Length; i++)
		{
			P_0 = P_0.Replace(text2[i].ToString(), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41874));
		}
		return P_0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && KNqrl3sUgA != null)
		{
			KNqrl3sUgA.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ns6riT2Nf2()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(ConvertToPC));
		Newr23qPKm = new GroupBox();
		yrsr0JI2x1 = new CheckBox();
		UytrB4PKDe = new CheckBox();
		q53ryoJr9c = new CheckBox();
		k6xrtxyQtX = new CheckBox();
		I9eraNGbqT = new Button();
		VEdrXiljH7 = new Button();
		nbvrxDEjoC = new CheckBox();
		OpyreFCmUV = new Button();
		f10rMVUSyh = new Button();
		zp3rUcvZuF = new CheckBox();
		XSCrLGFYnP = new CheckBox();
		HUhrg6PBYx = new GroupBox();
		qJbrPMWu7e = new Button();
		B4JrR5rHyg = new TextBox();
		hMSrkPyGky = new Label();
		O4NrYm28Hg = new GroupBox();
		gUAr3ZFneR = new RadioButton();
		SAXr1ra0sG = new RadioButton();
		wqWrEa7jj8 = new GroupBox();
		RlbrrQryNG = new Button();
		gJ6r53m4JH = new Label();
		sT7r6ZttWG = new Label();
		eu1rNQWLM1 = new NumericUpDown();
		VWErDpWCIK = new NumericUpDown();
		M67rcYX5a8 = new CheckBox();
		jhfrJ3MCCG = new GroupBox();
		emQruDVPTP = new RadioButton();
		Vhqrojy0SU = new RadioButton();
		dnMrQJahkN = new RadioButton();
		vlYrOV1iRZ = new CheckBox();
		KSwrCDPU3J = new GroupBox();
		UlAr9MsMMV = new RadioButton();
		YHQr7nV7yO = new RadioButton();
		RfYrAZCdHT = new RadioButton();
		HZFrdHhmZT = new GroupBox();
		upJrF4WdmU = new Button();
		s2UrHQcVwZ = new CheckBox();
		fPFrjaR97Z = new GroupBox();
		B0Nr8El7JF = new ComboBox();
		Newr23qPKm.SuspendLayout();
		HUhrg6PBYx.SuspendLayout();
		O4NrYm28Hg.SuspendLayout();
		wqWrEa7jj8.SuspendLayout();
		((ISupportInitialize)eu1rNQWLM1).BeginInit();
		((ISupportInitialize)VWErDpWCIK).BeginInit();
		jhfrJ3MCCG.SuspendLayout();
		KSwrCDPU3J.SuspendLayout();
		HZFrdHhmZT.SuspendLayout();
		fPFrjaR97Z.SuspendLayout();
		SuspendLayout();
		Newr23qPKm.Controls.Add(yrsr0JI2x1);
		Newr23qPKm.Controls.Add(UytrB4PKDe);
		Newr23qPKm.Controls.Add(q53ryoJr9c);
		Newr23qPKm.Location = new Point(14, 66);
		Newr23qPKm.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41880);
		Newr23qPKm.Size = new Size(125, 106);
		Newr23qPKm.TabIndex = 0;
		Newr23qPKm.TabStop = false;
		Newr23qPKm.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41902);
		yrsr0JI2x1.AutoSize = true;
		yrsr0JI2x1.Location = new Point(21, 81);
		yrsr0JI2x1.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28714);
		yrsr0JI2x1.Size = new Size(67, 17);
		yrsr0JI2x1.TabIndex = 2;
		yrsr0JI2x1.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28734);
		yrsr0JI2x1.UseVisualStyleBackColor = true;
		UytrB4PKDe.AutoSize = true;
		UytrB4PKDe.Location = new Point(21, 54);
		UytrB4PKDe.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28752);
		UytrB4PKDe.Size = new Size(58, 17);
		UytrB4PKDe.TabIndex = 1;
		UytrB4PKDe.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28772);
		UytrB4PKDe.UseVisualStyleBackColor = true;
		q53ryoJr9c.AutoSize = true;
		q53ryoJr9c.Checked = true;
		q53ryoJr9c.CheckState = CheckState.Checked;
		q53ryoJr9c.Location = new Point(21, 28);
		q53ryoJr9c.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28666);
		q53ryoJr9c.Size = new Size(74, 17);
		q53ryoJr9c.TabIndex = 0;
		q53ryoJr9c.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28692);
		q53ryoJr9c.UseVisualStyleBackColor = true;
		k6xrtxyQtX.AutoSize = true;
		k6xrtxyQtX.Location = new Point(314, 73);
		k6xrtxyQtX.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41940);
		k6xrtxyQtX.Size = new Size(103, 17);
		k6xrtxyQtX.TabIndex = 1;
		k6xrtxyQtX.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(36574);
		k6xrtxyQtX.UseVisualStyleBackColor = true;
		I9eraNGbqT.Location = new Point(314, 91);
		I9eraNGbqT.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41972);
		I9eraNGbqT.Size = new Size(101, 23);
		I9eraNGbqT.TabIndex = 2;
		I9eraNGbqT.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41992);
		I9eraNGbqT.UseVisualStyleBackColor = true;
		I9eraNGbqT.Click += KmoEjyV9bY;
		VEdrXiljH7.Location = new Point(314, 149);
		VEdrXiljH7.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42008);
		VEdrXiljH7.Size = new Size(101, 23);
		VEdrXiljH7.TabIndex = 4;
		VEdrXiljH7.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38788);
		VEdrXiljH7.UseVisualStyleBackColor = true;
		VEdrXiljH7.Visible = false;
		VEdrXiljH7.Click += r02E8WIcDc;
		nbvrxDEjoC.AutoSize = true;
		nbvrxDEjoC.Checked = true;
		nbvrxDEjoC.CheckState = CheckState.Checked;
		nbvrxDEjoC.Location = new Point(314, 131);
		nbvrxDEjoC.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37742);
		nbvrxDEjoC.Size = new Size(101, 17);
		nbvrxDEjoC.TabIndex = 3;
		nbvrxDEjoC.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42028);
		nbvrxDEjoC.UseVisualStyleBackColor = true;
		nbvrxDEjoC.Visible = false;
		OpyreFCmUV.DialogResult = DialogResult.Cancel;
		OpyreFCmUV.Location = new Point(417, 493);
		OpyreFCmUV.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34610);
		OpyreFCmUV.Size = new Size(75, 23);
		OpyreFCmUV.TabIndex = 5;
		OpyreFCmUV.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20198);
		OpyreFCmUV.UseVisualStyleBackColor = true;
		f10rMVUSyh.Location = new Point(330, 492);
		f10rMVUSyh.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23078);
		f10rMVUSyh.Size = new Size(75, 23);
		f10rMVUSyh.TabIndex = 6;
		f10rMVUSyh.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23102);
		f10rMVUSyh.UseVisualStyleBackColor = true;
		f10rMVUSyh.Click += sGrE9qx7gJ;
		zp3rUcvZuF.AutoSize = true;
		zp3rUcvZuF.Checked = true;
		zp3rUcvZuF.CheckState = CheckState.Checked;
		zp3rUcvZuF.Location = new Point(21, 28);
		zp3rUcvZuF.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42060);
		zp3rUcvZuF.Size = new Size(90, 17);
		zp3rUcvZuF.TabIndex = 7;
		zp3rUcvZuF.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42092);
		zp3rUcvZuF.UseVisualStyleBackColor = true;
		XSCrLGFYnP.AutoSize = true;
		XSCrLGFYnP.Checked = true;
		XSCrLGFYnP.CheckState = CheckState.Checked;
		XSCrLGFYnP.Location = new Point(21, 54);
		XSCrLGFYnP.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17194);
		XSCrLGFYnP.Size = new Size(60, 17);
		XSCrLGFYnP.TabIndex = 8;
		XSCrLGFYnP.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42124);
		XSCrLGFYnP.UseVisualStyleBackColor = true;
		HUhrg6PBYx.Controls.Add(zp3rUcvZuF);
		HUhrg6PBYx.Controls.Add(XSCrLGFYnP);
		HUhrg6PBYx.Location = new Point(158, 66);
		HUhrg6PBYx.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42144);
		HUhrg6PBYx.Size = new Size(125, 106);
		HUhrg6PBYx.TabIndex = 9;
		HUhrg6PBYx.TabStop = false;
		HUhrg6PBYx.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42166);
		qJbrPMWu7e.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42184));
		qJbrPMWu7e.Location = new Point(472, 29);
		qJbrPMWu7e.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42226);
		qJbrPMWu7e.Size = new Size(20, 20);
		qJbrPMWu7e.TabIndex = 12;
		qJbrPMWu7e.UseVisualStyleBackColor = true;
		qJbrPMWu7e.Click += AQOEzGVQMc;
		B4JrR5rHyg.Location = new Point(12, 29);
		B4JrR5rHyg.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42256);
		B4JrR5rHyg.Size = new Size(458, 20);
		B4JrR5rHyg.TabIndex = 11;
		hMSrkPyGky.AutoSize = true;
		hMSrkPyGky.Location = new Point(12, 16);
		hMSrkPyGky.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		hMSrkPyGky.Size = new Size(134, 13);
		hMSrkPyGky.TabIndex = 10;
		hMSrkPyGky.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42284);
		O4NrYm28Hg.Controls.Add(gUAr3ZFneR);
		O4NrYm28Hg.Controls.Add(SAXr1ra0sG);
		O4NrYm28Hg.Location = new Point(207, 308);
		O4NrYm28Hg.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42342);
		O4NrYm28Hg.Size = new Size(199, 74);
		O4NrYm28Hg.TabIndex = 13;
		O4NrYm28Hg.TabStop = false;
		O4NrYm28Hg.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42364);
		gUAr3ZFneR.AutoSize = true;
		gUAr3ZFneR.Location = new Point(14, 42);
		gUAr3ZFneR.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42398);
		gUAr3ZFneR.Size = new Size(155, 17);
		gUAr3ZFneR.TabIndex = 1;
		gUAr3ZFneR.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42428);
		gUAr3ZFneR.UseVisualStyleBackColor = true;
		SAXr1ra0sG.AutoSize = true;
		SAXr1ra0sG.Checked = true;
		SAXr1ra0sG.Location = new Point(14, 19);
		SAXr1ra0sG.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42484);
		SAXr1ra0sG.Size = new Size(158, 17);
		SAXr1ra0sG.TabIndex = 0;
		SAXr1ra0sG.TabStop = true;
		SAXr1ra0sG.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42514);
		SAXr1ra0sG.UseVisualStyleBackColor = true;
		wqWrEa7jj8.Controls.Add(RlbrrQryNG);
		wqWrEa7jj8.Controls.Add(gJ6r53m4JH);
		wqWrEa7jj8.Controls.Add(sT7r6ZttWG);
		wqWrEa7jj8.Controls.Add(eu1rNQWLM1);
		wqWrEa7jj8.Controls.Add(VWErDpWCIK);
		wqWrEa7jj8.Controls.Add(M67rcYX5a8);
		wqWrEa7jj8.Location = new Point(207, 193);
		wqWrEa7jj8.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42570);
		wqWrEa7jj8.Size = new Size(183, 94);
		wqWrEa7jj8.TabIndex = 18;
		wqWrEa7jj8.TabStop = false;
		wqWrEa7jj8.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42592);
		RlbrrQryNG.Location = new Point(104, 13);
		RlbrrQryNG.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42624);
		RlbrrQryNG.Size = new Size(73, 23);
		RlbrrQryNG.TabIndex = 5;
		RlbrrQryNG.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42648);
		RlbrrQryNG.UseVisualStyleBackColor = true;
		RlbrrQryNG.Click += m3FrvwNF8r;
		gJ6r53m4JH.AutoSize = true;
		gJ6r53m4JH.Location = new Point(75, 66);
		gJ6r53m4JH.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10482);
		gJ6r53m4JH.Size = new Size(82, 13);
		gJ6r53m4JH.TabIndex = 4;
		gJ6r53m4JH.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42672);
		sT7r6ZttWG.AutoSize = true;
		sT7r6ZttWG.Location = new Point(75, 42);
		sT7r6ZttWG.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10582);
		sT7r6ZttWG.Size = new Size(82, 13);
		sT7r6ZttWG.TabIndex = 3;
		sT7r6ZttWG.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42706);
		eu1rNQWLM1.Location = new Point(25, 64);
		eu1rNQWLM1.Maximum = new decimal(new int[4] { 10000, 0, 0, 0 });
		eu1rNQWLM1.Minimum = new decimal(new int[4] { 10000, 0, 0, -2147483648 });
		eu1rNQWLM1.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42740);
		eu1rNQWLM1.Size = new Size(43, 20);
		eu1rNQWLM1.TabIndex = 2;
		VWErDpWCIK.Location = new Point(25, 39);
		VWErDpWCIK.Maximum = new decimal(new int[4] { 10000, 0, 0, 0 });
		VWErDpWCIK.Minimum = new decimal(new int[4] { 10000, 0, 0, -2147483648 });
		VWErDpWCIK.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42776);
		VWErDpWCIK.Size = new Size(43, 20);
		VWErDpWCIK.TabIndex = 1;
		M67rcYX5a8.AutoSize = true;
		M67rcYX5a8.Location = new Point(25, 20);
		M67rcYX5a8.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42812);
		M67rcYX5a8.Size = new Size(81, 17);
		M67rcYX5a8.TabIndex = 0;
		M67rcYX5a8.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42860);
		M67rcYX5a8.UseVisualStyleBackColor = true;
		jhfrJ3MCCG.Controls.Add(emQruDVPTP);
		jhfrJ3MCCG.Controls.Add(Vhqrojy0SU);
		jhfrJ3MCCG.Controls.Add(dnMrQJahkN);
		jhfrJ3MCCG.Location = new Point(14, 193);
		jhfrJ3MCCG.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42886);
		jhfrJ3MCCG.Size = new Size(171, 94);
		jhfrJ3MCCG.TabIndex = 17;
		jhfrJ3MCCG.TabStop = false;
		jhfrJ3MCCG.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42908);
		emQruDVPTP.AutoSize = true;
		emQruDVPTP.Location = new Point(21, 65);
		emQruDVPTP.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42936);
		emQruDVPTP.Size = new Size(123, 17);
		emQruDVPTP.TabIndex = 17;
		emQruDVPTP.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42974);
		emQruDVPTP.UseVisualStyleBackColor = true;
		Vhqrojy0SU.AutoSize = true;
		Vhqrojy0SU.Checked = true;
		Vhqrojy0SU.Location = new Point(21, 42);
		Vhqrojy0SU.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43014);
		Vhqrojy0SU.Size = new Size(106, 17);
		Vhqrojy0SU.TabIndex = 16;
		Vhqrojy0SU.TabStop = true;
		Vhqrojy0SU.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43044);
		Vhqrojy0SU.UseVisualStyleBackColor = true;
		dnMrQJahkN.AutoSize = true;
		dnMrQJahkN.Location = new Point(21, 19);
		dnMrQJahkN.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43078);
		dnMrQJahkN.Size = new Size(85, 17);
		dnMrQJahkN.TabIndex = 15;
		dnMrQJahkN.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43106);
		dnMrQJahkN.UseVisualStyleBackColor = true;
		vlYrOV1iRZ.AutoSize = true;
		vlYrOV1iRZ.Location = new Point(14, 193);
		vlYrOV1iRZ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43132);
		vlYrOV1iRZ.Size = new Size(137, 17);
		vlYrOV1iRZ.TabIndex = 16;
		vlYrOV1iRZ.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43168);
		vlYrOV1iRZ.UseVisualStyleBackColor = true;
		vlYrOV1iRZ.Visible = false;
		KSwrCDPU3J.Controls.Add(UlAr9MsMMV);
		KSwrCDPU3J.Controls.Add(YHQr7nV7yO);
		KSwrCDPU3J.Controls.Add(RfYrAZCdHT);
		KSwrCDPU3J.Location = new Point(15, 308);
		KSwrCDPU3J.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43220);
		KSwrCDPU3J.Size = new Size(170, 87);
		KSwrCDPU3J.TabIndex = 19;
		KSwrCDPU3J.TabStop = false;
		KSwrCDPU3J.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43242);
		UlAr9MsMMV.AutoSize = true;
		UlAr9MsMMV.Location = new Point(20, 40);
		UlAr9MsMMV.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43266);
		UlAr9MsMMV.Size = new Size(81, 17);
		UlAr9MsMMV.TabIndex = 17;
		UlAr9MsMMV.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43292);
		UlAr9MsMMV.UseVisualStyleBackColor = true;
		UlAr9MsMMV.CheckedChanged += fH2rVfcYj4;
		YHQr7nV7yO.AutoSize = true;
		YHQr7nV7yO.Checked = true;
		YHQr7nV7yO.Location = new Point(20, 19);
		YHQr7nV7yO.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43318);
		YHQr7nV7yO.Size = new Size(81, 17);
		YHQr7nV7yO.TabIndex = 16;
		YHQr7nV7yO.TabStop = true;
		YHQr7nV7yO.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43352);
		YHQr7nV7yO.UseVisualStyleBackColor = true;
		YHQr7nV7yO.CheckedChanged += BHjr4oKQoo;
		RfYrAZCdHT.AutoSize = true;
		RfYrAZCdHT.Location = new Point(20, 61);
		RfYrAZCdHT.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43378);
		RfYrAZCdHT.Size = new Size(81, 17);
		RfYrAZCdHT.TabIndex = 15;
		RfYrAZCdHT.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43418);
		RfYrAZCdHT.UseVisualStyleBackColor = true;
		RfYrAZCdHT.CheckedChanged += ofDrW7lDgH;
		HZFrdHhmZT.Controls.Add(upJrF4WdmU);
		HZFrdHhmZT.Controls.Add(s2UrHQcVwZ);
		HZFrdHhmZT.Location = new Point(14, 401);
		HZFrdHhmZT.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43444);
		HZFrdHhmZT.Size = new Size(125, 82);
		HZFrdHhmZT.TabIndex = 20;
		HZFrdHhmZT.TabStop = false;
		HZFrdHhmZT.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43466);
		upJrF4WdmU.Location = new Point(19, 39);
		upJrF4WdmU.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43482);
		upJrF4WdmU.Size = new Size(69, 23);
		upJrF4WdmU.TabIndex = 8;
		upJrF4WdmU.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43516);
		upJrF4WdmU.UseVisualStyleBackColor = true;
		upJrF4WdmU.Click += jfqrwXZ0KK;
		s2UrHQcVwZ.AutoSize = true;
		s2UrHQcVwZ.Checked = true;
		s2UrHQcVwZ.CheckState = CheckState.Checked;
		s2UrHQcVwZ.Location = new Point(21, 21);
		s2UrHQcVwZ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43538);
		s2UrHQcVwZ.Size = new Size(70, 17);
		s2UrHQcVwZ.TabIndex = 7;
		s2UrHQcVwZ.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43574);
		s2UrHQcVwZ.UseVisualStyleBackColor = true;
		fPFrjaR97Z.Controls.Add(B0Nr8El7JF);
		fPFrjaR97Z.Location = new Point(179, 401);
		fPFrjaR97Z.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43596);
		fPFrjaR97Z.Size = new Size(197, 82);
		fPFrjaR97Z.TabIndex = 21;
		fPFrjaR97Z.TabStop = false;
		fPFrjaR97Z.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43626);
		B0Nr8El7JF.DropDownStyle = ComboBoxStyle.DropDownList;
		B0Nr8El7JF.FormattingEnabled = true;
		B0Nr8El7JF.Location = new Point(28, 21);
		B0Nr8El7JF.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43662);
		B0Nr8El7JF.Size = new Size(157, 21);
		B0Nr8El7JF.TabIndex = 0;
		base.AcceptButton = f10rMVUSyh;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = OpyreFCmUV;
		base.ClientSize = new Size(510, 532);
		base.Controls.Add(fPFrjaR97Z);
		base.Controls.Add(HZFrdHhmZT);
		base.Controls.Add(KSwrCDPU3J);
		base.Controls.Add(wqWrEa7jj8);
		base.Controls.Add(jhfrJ3MCCG);
		base.Controls.Add(vlYrOV1iRZ);
		base.Controls.Add(O4NrYm28Hg);
		base.Controls.Add(qJbrPMWu7e);
		base.Controls.Add(B4JrR5rHyg);
		base.Controls.Add(hMSrkPyGky);
		base.Controls.Add(HUhrg6PBYx);
		base.Controls.Add(f10rMVUSyh);
		base.Controls.Add(OpyreFCmUV);
		base.Controls.Add(VEdrXiljH7);
		base.Controls.Add(nbvrxDEjoC);
		base.Controls.Add(I9eraNGbqT);
		base.Controls.Add(k6xrtxyQtX);
		base.Controls.Add(Newr23qPKm);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43692);
		base.SizeGripStyle = SizeGripStyle.Hide;
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43718);
		base.Load += hgorb0Ncgm;
		Newr23qPKm.ResumeLayout(performLayout: false);
		Newr23qPKm.PerformLayout();
		HUhrg6PBYx.ResumeLayout(performLayout: false);
		HUhrg6PBYx.PerformLayout();
		O4NrYm28Hg.ResumeLayout(performLayout: false);
		O4NrYm28Hg.PerformLayout();
		wqWrEa7jj8.ResumeLayout(performLayout: false);
		wqWrEa7jj8.PerformLayout();
		((ISupportInitialize)eu1rNQWLM1).EndInit();
		((ISupportInitialize)VWErDpWCIK).EndInit();
		jhfrJ3MCCG.ResumeLayout(performLayout: false);
		jhfrJ3MCCG.PerformLayout();
		KSwrCDPU3J.ResumeLayout(performLayout: false);
		KSwrCDPU3J.PerformLayout();
		HZFrdHhmZT.ResumeLayout(performLayout: false);
		HZFrdHhmZT.PerformLayout();
		fPFrjaR97Z.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
