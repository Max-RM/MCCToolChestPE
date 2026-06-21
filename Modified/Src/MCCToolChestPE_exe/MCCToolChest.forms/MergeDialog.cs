using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using KZR2jb4Jm3EKXx6h58;
using MCCToolChest.Forms;
using MCCToolChest.model;
using MCCToolChest.PECode;
using MCCToolChest.Properties;
using MCCToolChest.utils;
using MCPELevelDBI.workers;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.forms;

public class MergeDialog : Form
{
	private MergeParameters n1NDa0UBac;

	private List<PEDimension> qMxDXwaZIi;

	private string bP8DxYpBfb;

	private List<BiomeChange> k1MDeOdae6;

	private IContainer DJEDMP2W3s;

	private GroupBox MSGDUyuiAS;

	private Button GhqDLyxsFM;

	private Label YhDDgQVmtN;

	private Label diLDPEvcjC;

	private NumericUpDown xqNDRpDivP;

	private NumericUpDown PjADkhUSgT;

	private CheckBox Gh8DYdAq80;

	private Button UYLD3KBALV;

	private Button s41D1S8jem;

	private Button iqSDEy3xqj;

	private PictureBox b0mDrWGExc;

	private Label uABD52Tdyh;

	private Label S4kD6ec7O7;

	private Label X6LDNLqTt7;

	private Label n6gDDjq3qv;

	private GroupBox JQQDcidtMY;

	private CheckBox zkrDJKb7s2;

	private CheckBox NM5Dug7Fk6;

	private GroupBox JaRDo5jt91;

	private CheckBox Mu5DQyvEFp;

	private CheckBox AWODOaFSPZ;

	private CheckBox vHGDCvXtKq;

	private GroupBox bSrD776cKt;

	private CheckBox E5JDAsCDNd;

	private CheckBox Li5DdmgbVY;

	private Button KHTDHHKqlf;

	private Button TtEDF9LJBj;

	public MergeParameters MergeParameters
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return n1NDa0UBac;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			n1NDa0UBac = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MergeDialog()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		ES2DtFXy9l();
		k1MDeOdae6 = Utils.ReadBiomeChanges(ConvertType.Other);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void VHUDZAwUD6(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.Icon = Resources.usMSrbJo37S();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void T1LDfmRbFb(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!string.IsNullOrWhiteSpace(bP8DxYpBfb) && qMxDXwaZIi != null)
		{
			n1NDa0UBac = new MergeParameters();
			n1NDa0UBac.ConvertOverworld = vHGDCvXtKq.Checked;
			n1NDa0UBac.ConvertNether = AWODOaFSPZ.Checked;
			n1NDa0UBac.ConvertTheEnd = Mu5DQyvEFp.Checked;
			n1NDa0UBac.MergeWorldFolder = FileUtils.CheckFolderSep(bP8DxYpBfb);
			n1NDa0UBac.ConvertTileEntities = zkrDJKb7s2.Checked;
			n1NDa0UBac.ConvertEntities = NM5Dug7Fk6.Checked;
			n1NDa0UBac.MergeWorldDimensions = qMxDXwaZIi;
			if (Gh8DYdAq80.Checked)
			{
				n1NDa0UBac.UseConvertOffsets = true;
				n1NDa0UBac.XRegionOffset = (int)PjADkhUSgT.Value;
				n1NDa0UBac.ZRegionOffset = (int)xqNDRpDivP.Value;
			}
			n1NDa0UBac.ReplaceBiomes = Li5DdmgbVY.Checked;
			n1NDa0UBac.BiomeChanges = k1MDeOdae6;
			base.DialogResult = DialogResult.OK;
			Close();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EAuDirjXTj(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		try
		{
			if (Settings.Default.UseFileExplorer)
			{
				igwDq1an7v();
			}
			else
			{
				GePDsCJbSM();
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(52584) + Environment.NewLine + ex.Message, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(52686));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GePDsCJbSM()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		_ = string.Empty;
		if (Directory.Exists(Utils.GetGetMCPESaveFolder()))
		{
			MCPEFolder mCPEFolder = new MCPEFolder(PCSelectDisplayType.Source);
			DialogResult dialogResult = mCPEFolder.ShowDialog(this);
			if (dialogResult == DialogResult.OK)
			{
				if (mCPEFolder.q5UQiauCd2() == (BUCE1Z1t57tWTV5OPi)0)
				{
					M0iDKCxK04(mCPEFolder.PEWorldFolder.Path);
				}
				else
				{
					igwDq1an7v();
				}
			}
		}
		else
		{
			igwDq1an7v();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void igwDq1an7v()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(52724);
		string text2 = FileUtils.W66SgJArfAS(Utils.GetGetMCPESaveFolder(), text);
		if (!string.IsNullOrWhiteSpace(text2))
		{
			M0iDKCxK04(text2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void M0iDKCxK04(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bP8DxYpBfb = P_0;
		qMxDXwaZIi = null;
		string path = Path.Combine(P_0, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(52776));
		b0mDrWGExc.Image = null;
		if (File.Exists(path))
		{
			using FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
			b0mDrWGExc.BackgroundImage = Image.FromStream(stream);
		}
		string text = "";
		string path2 = Path.Combine(P_0, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(52810));
		if (File.Exists(path2))
		{
			text = File.ReadAllText(path2);
		}
		uABD52Tdyh.Text = text;
		string fileName = Path.GetFileName(P_0);
		S4kD6ec7O7.Text = fileName;
		lhtDh4JUDv();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void lhtDh4JUDv()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LevelDBWorker levelDBWorker = PEUtility.OpenDBWorker(bP8DxYpBfb);
		qMxDXwaZIi = levelDBWorker.GetAvailableChunks();
		levelDBWorker.CloseDB();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void i9DDmfoOEA(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (qMxDXwaZIi != null)
		{
			MergeOffsetDisplay mergeOffsetDisplay = new MergeOffsetDisplay(qMxDXwaZIi, (int)PjADkhUSgT.Value, (int)xqNDRpDivP.Value);
			DialogResult dialogResult = mergeOffsetDisplay.ShowDialog(this);
			if (dialogResult == DialogResult.OK)
			{
				PjADkhUSgT.Value = mergeOffsetDisplay.RxOffset;
				xqNDRpDivP.Value = mergeOffsetDisplay.RzOffset;
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void y7KDnFXmUe(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void QrnDlB8aFJ(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PbsD2tL6nE(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Fq2Dy9doKi(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PZKD0fcSyS(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void kkRDBo9LMM(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BiomeAssignment biomeAssignment = new BiomeAssignment(k1MDeOdae6);
		if (biomeAssignment.ShowDialog(this) == DialogResult.OK)
		{
			k1MDeOdae6 = biomeAssignment.BiomeList;
			Utils.SaveBiomeChanges(ConvertType.FROM_PC, k1MDeOdae6);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && DJEDMP2W3s != null)
		{
			DJEDMP2W3s.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ES2DtFXy9l()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MSGDUyuiAS = new GroupBox();
		GhqDLyxsFM = new Button();
		YhDDgQVmtN = new Label();
		diLDPEvcjC = new Label();
		xqNDRpDivP = new NumericUpDown();
		PjADkhUSgT = new NumericUpDown();
		Gh8DYdAq80 = new CheckBox();
		UYLD3KBALV = new Button();
		s41D1S8jem = new Button();
		iqSDEy3xqj = new Button();
		b0mDrWGExc = new PictureBox();
		uABD52Tdyh = new Label();
		S4kD6ec7O7 = new Label();
		X6LDNLqTt7 = new Label();
		n6gDDjq3qv = new Label();
		JQQDcidtMY = new GroupBox();
		zkrDJKb7s2 = new CheckBox();
		NM5Dug7Fk6 = new CheckBox();
		JaRDo5jt91 = new GroupBox();
		Mu5DQyvEFp = new CheckBox();
		AWODOaFSPZ = new CheckBox();
		vHGDCvXtKq = new CheckBox();
		bSrD776cKt = new GroupBox();
		E5JDAsCDNd = new CheckBox();
		Li5DdmgbVY = new CheckBox();
		KHTDHHKqlf = new Button();
		TtEDF9LJBj = new Button();
		MSGDUyuiAS.SuspendLayout();
		((ISupportInitialize)xqNDRpDivP).BeginInit();
		((ISupportInitialize)PjADkhUSgT).BeginInit();
		((ISupportInitialize)b0mDrWGExc).BeginInit();
		JQQDcidtMY.SuspendLayout();
		JaRDo5jt91.SuspendLayout();
		bSrD776cKt.SuspendLayout();
		SuspendLayout();
		MSGDUyuiAS.Controls.Add(GhqDLyxsFM);
		MSGDUyuiAS.Controls.Add(YhDDgQVmtN);
		MSGDUyuiAS.Controls.Add(diLDPEvcjC);
		MSGDUyuiAS.Controls.Add(xqNDRpDivP);
		MSGDUyuiAS.Controls.Add(PjADkhUSgT);
		MSGDUyuiAS.Controls.Add(Gh8DYdAq80);
		MSGDUyuiAS.Location = new Point(12, 242);
		MSGDUyuiAS.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42570);
		MSGDUyuiAS.Size = new Size(190, 106);
		MSGDUyuiAS.TabIndex = 16;
		MSGDUyuiAS.TabStop = false;
		MSGDUyuiAS.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(52840);
		GhqDLyxsFM.Location = new Point(106, 18);
		GhqDLyxsFM.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42624);
		GhqDLyxsFM.Size = new Size(73, 23);
		GhqDLyxsFM.TabIndex = 5;
		GhqDLyxsFM.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42648);
		GhqDLyxsFM.UseVisualStyleBackColor = true;
		GhqDLyxsFM.Click += i9DDmfoOEA;
		YhDDgQVmtN.AutoSize = true;
		YhDDgQVmtN.Location = new Point(74, 76);
		YhDDgQVmtN.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10482);
		YhDDgQVmtN.Size = new Size(82, 13);
		YhDDgQVmtN.TabIndex = 4;
		YhDDgQVmtN.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42672);
		diLDPEvcjC.AutoSize = true;
		diLDPEvcjC.Location = new Point(74, 47);
		diLDPEvcjC.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10582);
		diLDPEvcjC.Size = new Size(82, 13);
		diLDPEvcjC.TabIndex = 3;
		diLDPEvcjC.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42706);
		xqNDRpDivP.Location = new Point(24, 74);
		xqNDRpDivP.Maximum = new decimal(new int[4] { 10000, 0, 0, 0 });
		xqNDRpDivP.Minimum = new decimal(new int[4] { 10000, 0, 0, -2147483648 });
		xqNDRpDivP.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42740);
		xqNDRpDivP.Size = new Size(43, 20);
		xqNDRpDivP.TabIndex = 2;
		PjADkhUSgT.Location = new Point(24, 44);
		PjADkhUSgT.Maximum = new decimal(new int[4] { 10000, 0, 0, 0 });
		PjADkhUSgT.Minimum = new decimal(new int[4] { 10000, 0, 0, -2147483648 });
		PjADkhUSgT.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42776);
		PjADkhUSgT.Size = new Size(43, 20);
		PjADkhUSgT.TabIndex = 1;
		Gh8DYdAq80.AutoSize = true;
		Gh8DYdAq80.Checked = true;
		Gh8DYdAq80.CheckState = CheckState.Checked;
		Gh8DYdAq80.Location = new Point(24, 25);
		Gh8DYdAq80.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42812);
		Gh8DYdAq80.Size = new Size(81, 17);
		Gh8DYdAq80.TabIndex = 0;
		Gh8DYdAq80.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42860);
		Gh8DYdAq80.UseVisualStyleBackColor = true;
		UYLD3KBALV.Location = new Point(268, 369);
		UYLD3KBALV.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(52868);
		UYLD3KBALV.Size = new Size(75, 23);
		UYLD3KBALV.TabIndex = 18;
		UYLD3KBALV.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(52888);
		UYLD3KBALV.UseVisualStyleBackColor = true;
		UYLD3KBALV.Click += T1LDfmRbFb;
		s41D1S8jem.DialogResult = DialogResult.Cancel;
		s41D1S8jem.Location = new Point(354, 369);
		s41D1S8jem.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34610);
		s41D1S8jem.Size = new Size(75, 23);
		s41D1S8jem.TabIndex = 17;
		s41D1S8jem.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20198);
		s41D1S8jem.UseVisualStyleBackColor = true;
		iqSDEy3xqj.Location = new Point(12, 82);
		iqSDEy3xqj.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(52902);
		iqSDEy3xqj.Size = new Size(110, 24);
		iqSDEy3xqj.TabIndex = 19;
		iqSDEy3xqj.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(52934);
		iqSDEy3xqj.UseVisualStyleBackColor = true;
		iqSDEy3xqj.Click += EAuDirjXTj;
		b0mDrWGExc.BackgroundImageLayout = ImageLayout.Stretch;
		b0mDrWGExc.BorderStyle = BorderStyle.FixedSingle;
		b0mDrWGExc.Location = new Point(12, 12);
		b0mDrWGExc.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(52962);
		b0mDrWGExc.Size = new Size(110, 64);
		b0mDrWGExc.TabIndex = 20;
		b0mDrWGExc.TabStop = false;
		b0mDrWGExc.Click += PZKD0fcSyS;
		uABD52Tdyh.AutoSize = true;
		uABD52Tdyh.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
		uABD52Tdyh.Location = new Point(129, 22);
		uABD52Tdyh.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(52988);
		uABD52Tdyh.Size = new Size(24, 17);
		uABD52Tdyh.TabIndex = 21;
		uABD52Tdyh.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28858);
		uABD52Tdyh.Click += PbsD2tL6nE;
		S4kD6ec7O7.AutoSize = true;
		S4kD6ec7O7.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
		S4kD6ec7O7.Location = new Point(129, 61);
		S4kD6ec7O7.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(53016);
		S4kD6ec7O7.Size = new Size(24, 17);
		S4kD6ec7O7.TabIndex = 22;
		S4kD6ec7O7.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28858);
		S4kD6ec7O7.Click += QrnDlB8aFJ;
		X6LDNLqTt7.AutoSize = true;
		X6LDNLqTt7.ForeColor = Color.DimGray;
		X6LDNLqTt7.Location = new Point(129, 11);
		X6LDNLqTt7.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		X6LDNLqTt7.Size = new Size(35, 13);
		X6LDNLqTt7.TabIndex = 23;
		X6LDNLqTt7.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10196);
		X6LDNLqTt7.Click += y7KDnFXmUe;
		n6gDDjq3qv.AutoSize = true;
		n6gDDjq3qv.ForeColor = Color.DimGray;
		n6gDDjq3qv.Location = new Point(129, 51);
		n6gDDjq3qv.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12846);
		n6gDDjq3qv.Size = new Size(36, 13);
		n6gDDjq3qv.TabIndex = 24;
		n6gDDjq3qv.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(53048);
		n6gDDjq3qv.Click += Fq2Dy9doKi;
		JQQDcidtMY.Controls.Add(zkrDJKb7s2);
		JQQDcidtMY.Controls.Add(NM5Dug7Fk6);
		JQQDcidtMY.Location = new Point(155, 120);
		JQQDcidtMY.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42144);
		JQQDcidtMY.Size = new Size(125, 106);
		JQQDcidtMY.TabIndex = 26;
		JQQDcidtMY.TabStop = false;
		JQQDcidtMY.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42166);
		zkrDJKb7s2.AutoSize = true;
		zkrDJKb7s2.Checked = true;
		zkrDJKb7s2.CheckState = CheckState.Checked;
		zkrDJKb7s2.Location = new Point(21, 28);
		zkrDJKb7s2.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42060);
		zkrDJKb7s2.Size = new Size(90, 17);
		zkrDJKb7s2.TabIndex = 7;
		zkrDJKb7s2.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42092);
		zkrDJKb7s2.UseVisualStyleBackColor = true;
		NM5Dug7Fk6.AutoSize = true;
		NM5Dug7Fk6.Checked = true;
		NM5Dug7Fk6.CheckState = CheckState.Checked;
		NM5Dug7Fk6.Location = new Point(21, 54);
		NM5Dug7Fk6.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17194);
		NM5Dug7Fk6.Size = new Size(60, 17);
		NM5Dug7Fk6.TabIndex = 8;
		NM5Dug7Fk6.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42124);
		NM5Dug7Fk6.UseVisualStyleBackColor = true;
		JaRDo5jt91.Controls.Add(Mu5DQyvEFp);
		JaRDo5jt91.Controls.Add(AWODOaFSPZ);
		JaRDo5jt91.Controls.Add(vHGDCvXtKq);
		JaRDo5jt91.Location = new Point(11, 120);
		JaRDo5jt91.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41880);
		JaRDo5jt91.Size = new Size(125, 106);
		JaRDo5jt91.TabIndex = 25;
		JaRDo5jt91.TabStop = false;
		JaRDo5jt91.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(53064);
		Mu5DQyvEFp.AutoSize = true;
		Mu5DQyvEFp.Location = new Point(21, 81);
		Mu5DQyvEFp.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28714);
		Mu5DQyvEFp.Size = new Size(67, 17);
		Mu5DQyvEFp.TabIndex = 2;
		Mu5DQyvEFp.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28734);
		Mu5DQyvEFp.UseVisualStyleBackColor = true;
		AWODOaFSPZ.AutoSize = true;
		AWODOaFSPZ.Location = new Point(21, 54);
		AWODOaFSPZ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28752);
		AWODOaFSPZ.Size = new Size(58, 17);
		AWODOaFSPZ.TabIndex = 1;
		AWODOaFSPZ.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28772);
		AWODOaFSPZ.UseVisualStyleBackColor = true;
		vHGDCvXtKq.AutoSize = true;
		vHGDCvXtKq.Checked = true;
		vHGDCvXtKq.CheckState = CheckState.Checked;
		vHGDCvXtKq.Location = new Point(21, 28);
		vHGDCvXtKq.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28666);
		vHGDCvXtKq.Size = new Size(74, 17);
		vHGDCvXtKq.TabIndex = 0;
		vHGDCvXtKq.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28692);
		vHGDCvXtKq.UseVisualStyleBackColor = true;
		bSrD776cKt.Controls.Add(E5JDAsCDNd);
		bSrD776cKt.Controls.Add(Li5DdmgbVY);
		bSrD776cKt.Controls.Add(KHTDHHKqlf);
		bSrD776cKt.Controls.Add(TtEDF9LJBj);
		bSrD776cKt.Location = new Point(301, 120);
		bSrD776cKt.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42342);
		bSrD776cKt.Size = new Size(128, 106);
		bSrD776cKt.TabIndex = 27;
		bSrD776cKt.TabStop = false;
		bSrD776cKt.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37220);
		E5JDAsCDNd.AutoSize = true;
		E5JDAsCDNd.Location = new Point(20, 65);
		E5JDAsCDNd.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37742);
		E5JDAsCDNd.Size = new Size(15, 14);
		E5JDAsCDNd.TabIndex = 7;
		E5JDAsCDNd.UseVisualStyleBackColor = true;
		E5JDAsCDNd.Visible = false;
		Li5DdmgbVY.AutoSize = true;
		Li5DdmgbVY.Location = new Point(20, 30);
		Li5DdmgbVY.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41940);
		Li5DdmgbVY.Size = new Size(15, 14);
		Li5DdmgbVY.TabIndex = 5;
		Li5DdmgbVY.UseVisualStyleBackColor = true;
		KHTDHHKqlf.Location = new Point(15, 25);
		KHTDHHKqlf.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41972);
		KHTDHHKqlf.Size = new Size(87, 23);
		KHTDHHKqlf.TabIndex = 6;
		KHTDHHKqlf.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41992);
		KHTDHHKqlf.UseVisualStyleBackColor = true;
		KHTDHHKqlf.Click += kkRDBo9LMM;
		TtEDF9LJBj.Location = new Point(15, 60);
		TtEDF9LJBj.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42008);
		TtEDF9LJBj.Size = new Size(87, 23);
		TtEDF9LJBj.TabIndex = 8;
		TtEDF9LJBj.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38788);
		TtEDF9LJBj.UseVisualStyleBackColor = true;
		TtEDF9LJBj.Visible = false;
		base.AcceptButton = UYLD3KBALV;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = s41D1S8jem;
		base.ClientSize = new Size(443, 404);
		base.Controls.Add(bSrD776cKt);
		base.Controls.Add(JQQDcidtMY);
		base.Controls.Add(JaRDo5jt91);
		base.Controls.Add(n6gDDjq3qv);
		base.Controls.Add(X6LDNLqTt7);
		base.Controls.Add(S4kD6ec7O7);
		base.Controls.Add(uABD52Tdyh);
		base.Controls.Add(b0mDrWGExc);
		base.Controls.Add(iqSDEy3xqj);
		base.Controls.Add(UYLD3KBALV);
		base.Controls.Add(s41D1S8jem);
		base.Controls.Add(MSGDUyuiAS);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(53098);
		base.SizeGripStyle = SizeGripStyle.Hide;
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(53124);
		base.Load += VHUDZAwUD6;
		MSGDUyuiAS.ResumeLayout(performLayout: false);
		MSGDUyuiAS.PerformLayout();
		((ISupportInitialize)xqNDRpDivP).EndInit();
		((ISupportInitialize)PjADkhUSgT).EndInit();
		((ISupportInitialize)b0mDrWGExc).EndInit();
		JQQDcidtMY.ResumeLayout(performLayout: false);
		JQQDcidtMY.PerformLayout();
		JaRDo5jt91.ResumeLayout(performLayout: false);
		JaRDo5jt91.PerformLayout();
		bSrD776cKt.ResumeLayout(performLayout: false);
		bSrD776cKt.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
