using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using HiT3kduFNLtRQIR37JV;
using MCCToolChest.model;
using MCCToolChest.utils;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls;

public class BlockReplaceII : UserControl
{
	private BlockChange uDrVUq6J8p;

	private BlockReplaceType QCJVLdkS7y;

	private IContainer Qw5Vgsixtu;

	private TableLayoutPanel nwuVPqIrUL;

	private Label JtFVRDi0pD;

	private Label HryVkRJ3yE;

	private Label V9tVYQAbAH;

	private Label WN1V37I2gF;

	private TextBox bRuV1Zd77P;

	private TextBox U2kVEBRENC;

	private ComboBox vq4Vr0mncE;

	private ComboBox AM4V5S45XQ;

	private TextBox TMxV6ORSdS;

	private Label fpKVNvkrvJ;

	private Panel SxRVDWaMNJ;

	private ComboBox AQFVcUiIjF;

	private Label UEsVJLLkKc;

	private Panel csOVuCJ1pt;

	private TextBox wY2Vo531LN;

	private Panel ekQVQg5kvE;

	private TextBox P5OVOlJfY9;

	private TextBox iK5VCbc9mx;

	private Label e4IV7M6lZe;

	private Panel zfPVAip3IW;

	private TextBox SYhVdiE8MD;

	private ComboBox SLcVHnkQi7;

	public BlockChange BlockChange
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			jxmVhtYyQT();
			return uDrVUq6J8p;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			uDrVUq6J8p = value;
			O4BVnMPXwZ();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BlockReplaceII()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		wQqVM5chHe();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetBlocks(BlockReplaceType blockReplaceType)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		QCJVLdkS7y = blockReplaceType;
		QYIVlgoHKr();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void jxmVhtYyQT()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		uDrVUq6J8p.FromBlock = (int)vq4Vr0mncE.SelectedValue;
		uDrVUq6J8p.FromData = IntSringConverter.ConvertFromString(bRuV1Zd77P.Text);
		uDrVUq6J8p.ToBlock = (int)AM4V5S45XQ.SelectedValue;
		uDrVUq6J8p.ToData = zEbVmtwvys(U2kVEBRENC.Text);
		uDrVUq6J8p.Layer2Block = (int)SLcVHnkQi7.SelectedValue;
		uDrVUq6J8p.Layer2Data = zEbVmtwvys(iK5VCbc9mx.Text);
		uDrVUq6J8p.ToBlockLight = (int)AQFVcUiIjF.SelectedValue;
		uDrVUq6J8p.Layers = IntSringConverter.ConvertFromString(TMxV6ORSdS.Text);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int zEbVmtwvys(string P_0)
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
	private void O4BVnMPXwZ()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		vq4Vr0mncE.SelectedValue = uDrVUq6J8p.FromBlock;
		bRuV1Zd77P.Text = IntSringConverter.ConvertToString(uDrVUq6J8p.FromData.ToArray());
		AM4V5S45XQ.SelectedValue = uDrVUq6J8p.ToBlock;
		U2kVEBRENC.Text = uDrVUq6J8p.ToData.ToString();
		SLcVHnkQi7.SelectedValue = uDrVUq6J8p.Layer2Block;
		iK5VCbc9mx.Text = uDrVUq6J8p.Layer2Data.ToString();
		AQFVcUiIjF.SelectedValue = uDrVUq6J8p.ToBlockLight;
		TMxV6ORSdS.Text = IntSringConverter.ConvertToString(uDrVUq6J8p.Layers.ToArray());
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void QYIVlgoHKr()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (QCJVLdkS7y == BlockReplaceType.ConvertToPC)
		{
			vq4Vr0mncE.ValueMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10770);
			vq4Vr0mncE.DisplayMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11102);
			vq4Vr0mncE.DataSource = INYifyudg3hCpcrleHt.Qp6S0miwnPj();
			AM4V5S45XQ.ValueMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10770);
			AM4V5S45XQ.DisplayMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11102);
			AM4V5S45XQ.DataSource = INYifyudg3hCpcrleHt.mAbS0V8YlqX();
		}
		else if (QCJVLdkS7y == BlockReplaceType.ConvertToPE)
		{
			vq4Vr0mncE.ValueMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10770);
			vq4Vr0mncE.DisplayMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11102);
			vq4Vr0mncE.DataSource = INYifyudg3hCpcrleHt.qGoS0pRIMcd();
			AM4V5S45XQ.ValueMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10770);
			AM4V5S45XQ.DisplayMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11102);
			AM4V5S45XQ.DataSource = INYifyudg3hCpcrleHt.GKBS0K4re36();
		}
		else if (QCJVLdkS7y == BlockReplaceType.ReplacePC)
		{
			vq4Vr0mncE.ValueMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10770);
			vq4Vr0mncE.DisplayMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11102);
			vq4Vr0mncE.DataSource = INYifyudg3hCpcrleHt.qGoS0pRIMcd();
			AM4V5S45XQ.ValueMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10770);
			AM4V5S45XQ.DisplayMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11102);
			AM4V5S45XQ.DataSource = INYifyudg3hCpcrleHt.mAbS0V8YlqX();
		}
		else if (QCJVLdkS7y == BlockReplaceType.ReplacePE)
		{
			vq4Vr0mncE.ValueMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10770);
			vq4Vr0mncE.DisplayMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11102);
			vq4Vr0mncE.DataSource = INYifyudg3hCpcrleHt.Qp6S0miwnPj();
			AM4V5S45XQ.ValueMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10770);
			AM4V5S45XQ.DisplayMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11102);
			AM4V5S45XQ.DataSource = INYifyudg3hCpcrleHt.GKBS0K4re36().ToList();
			SLcVHnkQi7.ValueMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10770);
			SLcVHnkQi7.DisplayMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11102);
			SLcVHnkQi7.DataSource = INYifyudg3hCpcrleHt.GKBS0K4re36().ToList();
		}
		AQFVcUiIjF.ValueMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10936);
		AQFVcUiIjF.DisplayMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11118);
		AQFVcUiIjF.DataSource = new BindingSource(Constants.wwBS0AsRbLZ, null);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void POvV21sPKK(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (vq4Vr0mncE.SelectedValue != null)
		{
			P5OVOlJfY9.Text = vq4Vr0mncE.SelectedValue.ToString();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void VRXVycMVrk(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (AM4V5S45XQ.SelectedValue != null)
		{
			wY2Vo531LN.Text = AM4V5S45XQ.SelectedValue.ToString();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void JNgV0M9Oil(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (SLcVHnkQi7.SelectedValue != null)
		{
			SYhVdiE8MD.Text = SLcVHnkQi7.SelectedValue.ToString();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void fd4VBq8uOS(object P_0, KeyPressEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!char.IsControl(P_1.KeyChar) && !char.IsDigit(P_1.KeyChar))
		{
			P_1.Handled = true;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void psDVtoAgCf(object P_0, KeyEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int.TryParse(P5OVOlJfY9.Text, out var result);
		vq4Vr0mncE.SelectedValue = result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void p1HVanEBIZ(object P_0, KeyPressEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!char.IsControl(P_1.KeyChar) && !char.IsDigit(P_1.KeyChar))
		{
			P_1.Handled = true;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Wm7VXNy1LV(object P_0, KeyEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int.TryParse(wY2Vo531LN.Text, out var result);
		AM4V5S45XQ.SelectedValue = result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void VSAVxJFsmC(object P_0, KeyPressEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!char.IsControl(P_1.KeyChar) && !char.IsDigit(P_1.KeyChar))
		{
			P_1.Handled = true;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CSSVeHaKZd(object P_0, KeyEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int.TryParse(SYhVdiE8MD.Text, out var result);
		SLcVHnkQi7.SelectedValue = result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsValid()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (vq4Vr0mncE.SelectedValue != null)
		{
			return AM4V5S45XQ.SelectedValue != null;
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && Qw5Vgsixtu != null)
		{
			Qw5Vgsixtu.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void wQqVM5chHe()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		nwuVPqIrUL = new TableLayoutPanel();
		iK5VCbc9mx = new TextBox();
		fpKVNvkrvJ = new Label();
		JtFVRDi0pD = new Label();
		HryVkRJ3yE = new Label();
		V9tVYQAbAH = new Label();
		WN1V37I2gF = new Label();
		bRuV1Zd77P = new TextBox();
		U2kVEBRENC = new TextBox();
		TMxV6ORSdS = new TextBox();
		SxRVDWaMNJ = new Panel();
		UEsVJLLkKc = new Label();
		AQFVcUiIjF = new ComboBox();
		csOVuCJ1pt = new Panel();
		wY2Vo531LN = new TextBox();
		AM4V5S45XQ = new ComboBox();
		ekQVQg5kvE = new Panel();
		P5OVOlJfY9 = new TextBox();
		vq4Vr0mncE = new ComboBox();
		zfPVAip3IW = new Panel();
		SYhVdiE8MD = new TextBox();
		SLcVHnkQi7 = new ComboBox();
		e4IV7M6lZe = new Label();
		nwuVPqIrUL.SuspendLayout();
		SxRVDWaMNJ.SuspendLayout();
		csOVuCJ1pt.SuspendLayout();
		ekQVQg5kvE.SuspendLayout();
		zfPVAip3IW.SuspendLayout();
		SuspendLayout();
		nwuVPqIrUL.ColumnCount = 4;
		nwuVPqIrUL.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40f));
		nwuVPqIrUL.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33334f));
		nwuVPqIrUL.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333f));
		nwuVPqIrUL.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33334f));
		nwuVPqIrUL.Controls.Add(iK5VCbc9mx, 3, 2);
		nwuVPqIrUL.Controls.Add(fpKVNvkrvJ, 0, 3);
		nwuVPqIrUL.Controls.Add(JtFVRDi0pD, 0, 2);
		nwuVPqIrUL.Controls.Add(HryVkRJ3yE, 1, 0);
		nwuVPqIrUL.Controls.Add(V9tVYQAbAH, 2, 0);
		nwuVPqIrUL.Controls.Add(WN1V37I2gF, 0, 1);
		nwuVPqIrUL.Controls.Add(bRuV1Zd77P, 1, 2);
		nwuVPqIrUL.Controls.Add(U2kVEBRENC, 2, 2);
		nwuVPqIrUL.Controls.Add(TMxV6ORSdS, 1, 3);
		nwuVPqIrUL.Controls.Add(SxRVDWaMNJ, 2, 3);
		nwuVPqIrUL.Controls.Add(csOVuCJ1pt, 2, 1);
		nwuVPqIrUL.Controls.Add(ekQVQg5kvE, 1, 1);
		nwuVPqIrUL.Controls.Add(zfPVAip3IW, 3, 1);
		nwuVPqIrUL.Controls.Add(e4IV7M6lZe, 3, 0);
		nwuVPqIrUL.Dock = DockStyle.Fill;
		nwuVPqIrUL.Location = new Point(0, 0);
		nwuVPqIrUL.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10826);
		nwuVPqIrUL.RowCount = 4;
		nwuVPqIrUL.RowStyles.Add(new RowStyle(SizeType.Absolute, 12f));
		nwuVPqIrUL.RowStyles.Add(new RowStyle(SizeType.Absolute, 26f));
		nwuVPqIrUL.RowStyles.Add(new RowStyle(SizeType.Absolute, 26f));
		nwuVPqIrUL.RowStyles.Add(new RowStyle(SizeType.Absolute, 26f));
		nwuVPqIrUL.Size = new Size(392, 93);
		nwuVPqIrUL.TabIndex = 0;
		iK5VCbc9mx.Dock = DockStyle.Fill;
		iK5VCbc9mx.Location = new Point(277, 41);
		iK5VCbc9mx.MaximumSize = new Size(40, 20);
		iK5VCbc9mx.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13048);
		iK5VCbc9mx.Size = new Size(40, 20);
		iK5VCbc9mx.TabIndex = 16;
		fpKVNvkrvJ.AutoSize = true;
		fpKVNvkrvJ.Dock = DockStyle.Fill;
		fpKVNvkrvJ.Location = new Point(3, 64);
		fpKVNvkrvJ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11132);
		fpKVNvkrvJ.Padding = new Padding(0, 6, 0, 0);
		fpKVNvkrvJ.Size = new Size(34, 29);
		fpKVNvkrvJ.TabIndex = 12;
		fpKVNvkrvJ.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11148);
		fpKVNvkrvJ.TextAlign = ContentAlignment.TopRight;
		JtFVRDi0pD.AutoSize = true;
		JtFVRDi0pD.Dock = DockStyle.Fill;
		JtFVRDi0pD.Location = new Point(3, 38);
		JtFVRDi0pD.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11162);
		JtFVRDi0pD.Padding = new Padding(0, 6, 0, 0);
		JtFVRDi0pD.Size = new Size(34, 26);
		JtFVRDi0pD.TabIndex = 9;
		JtFVRDi0pD.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11178);
		JtFVRDi0pD.TextAlign = ContentAlignment.TopRight;
		HryVkRJ3yE.AutoSize = true;
		HryVkRJ3yE.Dock = DockStyle.Fill;
		HryVkRJ3yE.Location = new Point(43, 0);
		HryVkRJ3yE.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		HryVkRJ3yE.Size = new Size(111, 12);
		HryVkRJ3yE.TabIndex = 1;
		HryVkRJ3yE.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11190);
		V9tVYQAbAH.AutoSize = true;
		V9tVYQAbAH.Dock = DockStyle.Fill;
		V9tVYQAbAH.Location = new Point(160, 0);
		V9tVYQAbAH.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10582);
		V9tVYQAbAH.Size = new Size(111, 12);
		V9tVYQAbAH.TabIndex = 8;
		V9tVYQAbAH.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13068);
		WN1V37I2gF.AutoSize = true;
		WN1V37I2gF.Dock = DockStyle.Fill;
		WN1V37I2gF.Location = new Point(3, 12);
		WN1V37I2gF.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10482);
		WN1V37I2gF.Padding = new Padding(0, 6, 0, 0);
		WN1V37I2gF.Size = new Size(34, 26);
		WN1V37I2gF.TabIndex = 2;
		WN1V37I2gF.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10770);
		WN1V37I2gF.TextAlign = ContentAlignment.TopRight;
		bRuV1Zd77P.Dock = DockStyle.Fill;
		bRuV1Zd77P.Location = new Point(43, 41);
		bRuV1Zd77P.MaximumSize = new Size(40, 20);
		bRuV1Zd77P.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11234);
		bRuV1Zd77P.Size = new Size(40, 20);
		bRuV1Zd77P.TabIndex = 10;
		U2kVEBRENC.Dock = DockStyle.Fill;
		U2kVEBRENC.Location = new Point(160, 41);
		U2kVEBRENC.MaximumSize = new Size(40, 20);
		U2kVEBRENC.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11258);
		U2kVEBRENC.Size = new Size(40, 20);
		U2kVEBRENC.TabIndex = 11;
		TMxV6ORSdS.Dock = DockStyle.Fill;
		TMxV6ORSdS.Location = new Point(43, 67);
		TMxV6ORSdS.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11278);
		TMxV6ORSdS.Size = new Size(111, 20);
		TMxV6ORSdS.TabIndex = 13;
		SxRVDWaMNJ.Controls.Add(UEsVJLLkKc);
		SxRVDWaMNJ.Controls.Add(AQFVcUiIjF);
		SxRVDWaMNJ.Dock = DockStyle.Fill;
		SxRVDWaMNJ.Location = new Point(160, 67);
		SxRVDWaMNJ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10398);
		SxRVDWaMNJ.Size = new Size(111, 23);
		SxRVDWaMNJ.TabIndex = 14;
		UEsVJLLkKc.AutoSize = true;
		UEsVJLLkKc.Location = new Point(3, 6);
		UEsVJLLkKc.Margin = new Padding(0);
		UEsVJLLkKc.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11298);
		UEsVJLLkKc.Size = new Size(30, 13);
		UEsVJLLkKc.TabIndex = 15;
		UEsVJLLkKc.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11314);
		UEsVJLLkKc.Visible = false;
		AQFVcUiIjF.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		AQFVcUiIjF.DropDownStyle = ComboBoxStyle.DropDownList;
		AQFVcUiIjF.FormattingEnabled = true;
		AQFVcUiIjF.Location = new Point(35, 1);
		AQFVcUiIjF.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11328);
		AQFVcUiIjF.Size = new Size(76, 21);
		AQFVcUiIjF.TabIndex = 16;
		AQFVcUiIjF.Visible = false;
		csOVuCJ1pt.Controls.Add(wY2Vo531LN);
		csOVuCJ1pt.Controls.Add(AM4V5S45XQ);
		csOVuCJ1pt.Dock = DockStyle.Fill;
		csOVuCJ1pt.Location = new Point(157, 12);
		csOVuCJ1pt.Margin = new Padding(0);
		csOVuCJ1pt.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11356);
		csOVuCJ1pt.Size = new Size(117, 26);
		csOVuCJ1pt.TabIndex = 6;
		wY2Vo531LN.Location = new Point(4, 4);
		wY2Vo531LN.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11372);
		wY2Vo531LN.Size = new Size(30, 20);
		wY2Vo531LN.TabIndex = 7;
		wY2Vo531LN.KeyPress += p1HVanEBIZ;
		wY2Vo531LN.KeyUp += Wm7VXNy1LV;
		AM4V5S45XQ.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		AM4V5S45XQ.DropDownStyle = ComboBoxStyle.DropDownList;
		AM4V5S45XQ.FormattingEnabled = true;
		AM4V5S45XQ.Location = new Point(35, 3);
		AM4V5S45XQ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11388);
		AM4V5S45XQ.Size = new Size(79, 21);
		AM4V5S45XQ.TabIndex = 8;
		AM4V5S45XQ.SelectedIndexChanged += VRXVycMVrk;
		ekQVQg5kvE.Controls.Add(P5OVOlJfY9);
		ekQVQg5kvE.Controls.Add(vq4Vr0mncE);
		ekQVQg5kvE.Dock = DockStyle.Fill;
		ekQVQg5kvE.Location = new Point(40, 12);
		ekQVQg5kvE.Margin = new Padding(0);
		ekQVQg5kvE.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11404);
		ekQVQg5kvE.Size = new Size(117, 26);
		ekQVQg5kvE.TabIndex = 3;
		P5OVOlJfY9.Location = new Point(4, 4);
		P5OVOlJfY9.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11420);
		P5OVOlJfY9.Size = new Size(30, 20);
		P5OVOlJfY9.TabIndex = 4;
		P5OVOlJfY9.KeyPress += fd4VBq8uOS;
		P5OVOlJfY9.KeyUp += psDVtoAgCf;
		vq4Vr0mncE.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		vq4Vr0mncE.DropDownStyle = ComboBoxStyle.DropDownList;
		vq4Vr0mncE.FormattingEnabled = true;
		vq4Vr0mncE.Location = new Point(35, 3);
		vq4Vr0mncE.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11440);
		vq4Vr0mncE.Size = new Size(79, 21);
		vq4Vr0mncE.TabIndex = 5;
		vq4Vr0mncE.SelectedIndexChanged += POvV21sPKK;
		zfPVAip3IW.Controls.Add(SYhVdiE8MD);
		zfPVAip3IW.Controls.Add(SLcVHnkQi7);
		zfPVAip3IW.Dock = DockStyle.Fill;
		zfPVAip3IW.Location = new Point(274, 12);
		zfPVAip3IW.Margin = new Padding(0);
		zfPVAip3IW.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13112);
		zfPVAip3IW.Size = new Size(118, 26);
		zfPVAip3IW.TabIndex = 11;
		SYhVdiE8MD.Location = new Point(4, 4);
		SYhVdiE8MD.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13128);
		SYhVdiE8MD.Size = new Size(30, 20);
		SYhVdiE8MD.TabIndex = 9;
		SYhVdiE8MD.KeyPress += VSAVxJFsmC;
		SYhVdiE8MD.KeyUp += CSSVeHaKZd;
		SLcVHnkQi7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		SLcVHnkQi7.DropDownStyle = ComboBoxStyle.DropDownList;
		SLcVHnkQi7.FormattingEnabled = true;
		SLcVHnkQi7.Location = new Point(35, 3);
		SLcVHnkQi7.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13144);
		SLcVHnkQi7.Size = new Size(79, 21);
		SLcVHnkQi7.TabIndex = 10;
		SLcVHnkQi7.SelectedIndexChanged += JNgV0M9Oil;
		e4IV7M6lZe.Dock = DockStyle.Fill;
		e4IV7M6lZe.Location = new Point(277, 0);
		e4IV7M6lZe.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12846);
		e4IV7M6lZe.Size = new Size(112, 12);
		e4IV7M6lZe.TabIndex = 15;
		e4IV7M6lZe.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13160);
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(nwuVPqIrUL);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13204);
		base.Size = new Size(392, 93);
		nwuVPqIrUL.ResumeLayout(performLayout: false);
		nwuVPqIrUL.PerformLayout();
		SxRVDWaMNJ.ResumeLayout(performLayout: false);
		SxRVDWaMNJ.PerformLayout();
		csOVuCJ1pt.ResumeLayout(performLayout: false);
		csOVuCJ1pt.PerformLayout();
		ekQVQg5kvE.ResumeLayout(performLayout: false);
		ekQVQg5kvE.PerformLayout();
		zfPVAip3IW.ResumeLayout(performLayout: false);
		zfPVAip3IW.PerformLayout();
		ResumeLayout(performLayout: false);
	}
}
