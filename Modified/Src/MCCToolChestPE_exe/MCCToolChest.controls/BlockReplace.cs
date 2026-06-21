using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using HiT3kduFNLtRQIR37JV;
using MCCToolChest.model;
using MCCToolChest.utils;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls;

public class BlockReplace : UserControl
{
	private BlockChange PwUb86rCoX;

	private BlockReplaceType PD4b9jGWvU;

	private IContainer AGWbItNZc9;

	private TableLayoutPanel fxQbzxMXK0;

	private Label TUxvTtIqns;

	private Label W2ivSDZvVP;

	private Label YwAvGnEMOD;

	private Label O2Yvb17u6c;

	private TextBox GNLvv4Mx5f;

	private TextBox jTMvwOv9fm;

	private ComboBox i9hv4ML4eg;

	private ComboBox M1VvVHLCdV;

	private TextBox sF3vWpfAxc;

	private Label DMivpsi4ur;

	private Panel uh6vZEEfq9;

	private ComboBox oO4vftWhFv;

	private Label liJviNHGYo;

	private Panel zRtvsPe28m;

	private TextBox zDGvq6iXiW;

	private Panel irRvKuYJW6;

	private TextBox OIEvheDlSc;

	public BlockChange BlockChange
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			MvJbuwVFal();
			return PwUb86rCoX;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			PwUb86rCoX = value;
			jBubQmtr89();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BlockReplace()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		zpTbj7wv8x();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetBlocks(BlockReplaceType blockReplaceType)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PD4b9jGWvU = blockReplaceType;
		IIBbOl8cYL();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MvJbuwVFal()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PwUb86rCoX.FromBlock = (int)i9hv4ML4eg.SelectedValue;
		PwUb86rCoX.FromData = IntSringConverter.ConvertFromString(GNLvv4Mx5f.Text);
		PwUb86rCoX.ToBlock = (int)M1VvVHLCdV.SelectedValue;
		PwUb86rCoX.ToData = jGiboPGA5Z(jTMvwOv9fm.Text);
		PwUb86rCoX.ToBlockLight = (int)oO4vftWhFv.SelectedValue;
		PwUb86rCoX.Layers = IntSringConverter.ConvertFromString(sF3vWpfAxc.Text);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int jGiboPGA5Z(string P_0)
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
	private void jBubQmtr89()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		i9hv4ML4eg.SelectedValue = PwUb86rCoX.FromBlock;
		GNLvv4Mx5f.Text = IntSringConverter.ConvertToString(PwUb86rCoX.FromData.ToArray());
		M1VvVHLCdV.SelectedValue = PwUb86rCoX.ToBlock;
		jTMvwOv9fm.Text = PwUb86rCoX.ToData.ToString();
		oO4vftWhFv.SelectedValue = PwUb86rCoX.ToBlockLight;
		sF3vWpfAxc.Text = IntSringConverter.ConvertToString(PwUb86rCoX.Layers.ToArray());
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void IIBbOl8cYL()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (PD4b9jGWvU == BlockReplaceType.ConvertToPC)
		{
			i9hv4ML4eg.ValueMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10770);
			i9hv4ML4eg.DisplayMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11102);
			i9hv4ML4eg.DataSource = INYifyudg3hCpcrleHt.Qp6S0miwnPj();
			M1VvVHLCdV.ValueMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10770);
			M1VvVHLCdV.DisplayMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11102);
			M1VvVHLCdV.DataSource = INYifyudg3hCpcrleHt.mAbS0V8YlqX();
		}
		else if (PD4b9jGWvU == BlockReplaceType.ConvertToPE)
		{
			i9hv4ML4eg.ValueMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10770);
			i9hv4ML4eg.DisplayMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11102);
			i9hv4ML4eg.DataSource = INYifyudg3hCpcrleHt.qGoS0pRIMcd();
			M1VvVHLCdV.ValueMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10770);
			M1VvVHLCdV.DisplayMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11102);
			M1VvVHLCdV.DataSource = INYifyudg3hCpcrleHt.GKBS0K4re36();
		}
		else if (PD4b9jGWvU == BlockReplaceType.ReplacePC)
		{
			i9hv4ML4eg.ValueMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10770);
			i9hv4ML4eg.DisplayMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11102);
			i9hv4ML4eg.DataSource = INYifyudg3hCpcrleHt.qGoS0pRIMcd();
			M1VvVHLCdV.ValueMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10770);
			M1VvVHLCdV.DisplayMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11102);
			M1VvVHLCdV.DataSource = INYifyudg3hCpcrleHt.mAbS0V8YlqX();
		}
		else if (PD4b9jGWvU == BlockReplaceType.ReplacePE)
		{
			i9hv4ML4eg.ValueMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10770);
			i9hv4ML4eg.DisplayMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11102);
			i9hv4ML4eg.DataSource = INYifyudg3hCpcrleHt.Qp6S0miwnPj();
			M1VvVHLCdV.ValueMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10770);
			M1VvVHLCdV.DisplayMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11102);
			M1VvVHLCdV.DataSource = INYifyudg3hCpcrleHt.GKBS0K4re36();
		}
		oO4vftWhFv.ValueMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10936);
		oO4vftWhFv.DisplayMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11118);
		oO4vftWhFv.DataSource = new BindingSource(Constants.wwBS0AsRbLZ, null);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TN0bCBh337(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (i9hv4ML4eg.SelectedValue != null)
		{
			OIEvheDlSc.Text = i9hv4ML4eg.SelectedValue.ToString();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void mIPb7j8ipe(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (M1VvVHLCdV.SelectedValue != null)
		{
			zDGvq6iXiW.Text = M1VvVHLCdV.SelectedValue.ToString();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void VSDbALOIJN(object P_0, KeyPressEventArgs P_1)
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
	private void FIRbdnt6U9(object P_0, KeyEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int.TryParse(OIEvheDlSc.Text, out var result);
		i9hv4ML4eg.SelectedValue = result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void NtqbHyg8Z2(object P_0, KeyPressEventArgs P_1)
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
	private void PNEbFCu6kY(object P_0, KeyEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int.TryParse(zDGvq6iXiW.Text, out var result);
		M1VvVHLCdV.SelectedValue = result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsValid()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (i9hv4ML4eg.SelectedValue != null)
		{
			return M1VvVHLCdV.SelectedValue != null;
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
		if (disposing && AGWbItNZc9 != null)
		{
			AGWbItNZc9.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void zpTbj7wv8x()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		fxQbzxMXK0 = new TableLayoutPanel();
		DMivpsi4ur = new Label();
		TUxvTtIqns = new Label();
		W2ivSDZvVP = new Label();
		YwAvGnEMOD = new Label();
		O2Yvb17u6c = new Label();
		GNLvv4Mx5f = new TextBox();
		jTMvwOv9fm = new TextBox();
		sF3vWpfAxc = new TextBox();
		uh6vZEEfq9 = new Panel();
		liJviNHGYo = new Label();
		oO4vftWhFv = new ComboBox();
		zRtvsPe28m = new Panel();
		zDGvq6iXiW = new TextBox();
		M1VvVHLCdV = new ComboBox();
		irRvKuYJW6 = new Panel();
		OIEvheDlSc = new TextBox();
		i9hv4ML4eg = new ComboBox();
		fxQbzxMXK0.SuspendLayout();
		uh6vZEEfq9.SuspendLayout();
		zRtvsPe28m.SuspendLayout();
		irRvKuYJW6.SuspendLayout();
		SuspendLayout();
		fxQbzxMXK0.ColumnCount = 3;
		fxQbzxMXK0.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40f));
		fxQbzxMXK0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33334f));
		fxQbzxMXK0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333f));
		fxQbzxMXK0.Controls.Add(DMivpsi4ur, 0, 3);
		fxQbzxMXK0.Controls.Add(TUxvTtIqns, 0, 2);
		fxQbzxMXK0.Controls.Add(W2ivSDZvVP, 1, 0);
		fxQbzxMXK0.Controls.Add(YwAvGnEMOD, 2, 0);
		fxQbzxMXK0.Controls.Add(O2Yvb17u6c, 0, 1);
		fxQbzxMXK0.Controls.Add(GNLvv4Mx5f, 1, 2);
		fxQbzxMXK0.Controls.Add(jTMvwOv9fm, 2, 2);
		fxQbzxMXK0.Controls.Add(sF3vWpfAxc, 1, 3);
		fxQbzxMXK0.Controls.Add(uh6vZEEfq9, 2, 3);
		fxQbzxMXK0.Controls.Add(zRtvsPe28m, 2, 1);
		fxQbzxMXK0.Controls.Add(irRvKuYJW6, 1, 1);
		fxQbzxMXK0.Dock = DockStyle.Fill;
		fxQbzxMXK0.Location = new Point(0, 0);
		fxQbzxMXK0.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10826);
		fxQbzxMXK0.RowCount = 4;
		fxQbzxMXK0.RowStyles.Add(new RowStyle(SizeType.Absolute, 12f));
		fxQbzxMXK0.RowStyles.Add(new RowStyle(SizeType.Absolute, 26f));
		fxQbzxMXK0.RowStyles.Add(new RowStyle(SizeType.Absolute, 26f));
		fxQbzxMXK0.RowStyles.Add(new RowStyle(SizeType.Absolute, 26f));
		fxQbzxMXK0.Size = new Size(392, 93);
		fxQbzxMXK0.TabIndex = 0;
		DMivpsi4ur.AutoSize = true;
		DMivpsi4ur.Dock = DockStyle.Fill;
		DMivpsi4ur.Location = new Point(3, 64);
		DMivpsi4ur.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11132);
		DMivpsi4ur.Padding = new Padding(0, 6, 0, 0);
		DMivpsi4ur.Size = new Size(34, 29);
		DMivpsi4ur.TabIndex = 12;
		DMivpsi4ur.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11148);
		DMivpsi4ur.TextAlign = ContentAlignment.TopRight;
		TUxvTtIqns.AutoSize = true;
		TUxvTtIqns.Dock = DockStyle.Fill;
		TUxvTtIqns.Location = new Point(3, 38);
		TUxvTtIqns.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11162);
		TUxvTtIqns.Padding = new Padding(0, 6, 0, 0);
		TUxvTtIqns.Size = new Size(34, 26);
		TUxvTtIqns.TabIndex = 9;
		TUxvTtIqns.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11178);
		TUxvTtIqns.TextAlign = ContentAlignment.TopRight;
		W2ivSDZvVP.AutoSize = true;
		W2ivSDZvVP.Dock = DockStyle.Fill;
		W2ivSDZvVP.Location = new Point(43, 0);
		W2ivSDZvVP.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		W2ivSDZvVP.Size = new Size(170, 12);
		W2ivSDZvVP.TabIndex = 1;
		W2ivSDZvVP.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11190);
		YwAvGnEMOD.AutoSize = true;
		YwAvGnEMOD.Dock = DockStyle.Fill;
		YwAvGnEMOD.Location = new Point(219, 0);
		YwAvGnEMOD.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10582);
		YwAvGnEMOD.Size = new Size(170, 12);
		YwAvGnEMOD.TabIndex = 8;
		YwAvGnEMOD.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11214);
		O2Yvb17u6c.AutoSize = true;
		O2Yvb17u6c.Dock = DockStyle.Fill;
		O2Yvb17u6c.Location = new Point(3, 12);
		O2Yvb17u6c.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10482);
		O2Yvb17u6c.Padding = new Padding(0, 6, 0, 0);
		O2Yvb17u6c.Size = new Size(34, 26);
		O2Yvb17u6c.TabIndex = 2;
		O2Yvb17u6c.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10770);
		O2Yvb17u6c.TextAlign = ContentAlignment.TopRight;
		GNLvv4Mx5f.Dock = DockStyle.Fill;
		GNLvv4Mx5f.Location = new Point(43, 41);
		GNLvv4Mx5f.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11234);
		GNLvv4Mx5f.Size = new Size(170, 20);
		GNLvv4Mx5f.TabIndex = 10;
		jTMvwOv9fm.Dock = DockStyle.Fill;
		jTMvwOv9fm.Location = new Point(219, 41);
		jTMvwOv9fm.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11258);
		jTMvwOv9fm.Size = new Size(170, 20);
		jTMvwOv9fm.TabIndex = 11;
		sF3vWpfAxc.Dock = DockStyle.Fill;
		sF3vWpfAxc.Location = new Point(43, 67);
		sF3vWpfAxc.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11278);
		sF3vWpfAxc.Size = new Size(170, 20);
		sF3vWpfAxc.TabIndex = 13;
		uh6vZEEfq9.Controls.Add(liJviNHGYo);
		uh6vZEEfq9.Controls.Add(oO4vftWhFv);
		uh6vZEEfq9.Dock = DockStyle.Fill;
		uh6vZEEfq9.Location = new Point(219, 67);
		uh6vZEEfq9.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10398);
		uh6vZEEfq9.Size = new Size(170, 23);
		uh6vZEEfq9.TabIndex = 14;
		liJviNHGYo.AutoSize = true;
		liJviNHGYo.Location = new Point(3, 6);
		liJviNHGYo.Margin = new Padding(0);
		liJviNHGYo.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11298);
		liJviNHGYo.Size = new Size(30, 13);
		liJviNHGYo.TabIndex = 15;
		liJviNHGYo.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11314);
		oO4vftWhFv.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		oO4vftWhFv.DropDownStyle = ComboBoxStyle.DropDownList;
		oO4vftWhFv.FormattingEnabled = true;
		oO4vftWhFv.Location = new Point(35, 1);
		oO4vftWhFv.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11328);
		oO4vftWhFv.Size = new Size(135, 21);
		oO4vftWhFv.TabIndex = 16;
		zRtvsPe28m.Controls.Add(zDGvq6iXiW);
		zRtvsPe28m.Controls.Add(M1VvVHLCdV);
		zRtvsPe28m.Dock = DockStyle.Fill;
		zRtvsPe28m.Location = new Point(216, 12);
		zRtvsPe28m.Margin = new Padding(0);
		zRtvsPe28m.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11356);
		zRtvsPe28m.Size = new Size(176, 26);
		zRtvsPe28m.TabIndex = 6;
		zDGvq6iXiW.Location = new Point(4, 4);
		zDGvq6iXiW.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11372);
		zDGvq6iXiW.Size = new Size(30, 20);
		zDGvq6iXiW.TabIndex = 7;
		zDGvq6iXiW.KeyPress += NtqbHyg8Z2;
		zDGvq6iXiW.KeyUp += PNEbFCu6kY;
		M1VvVHLCdV.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		M1VvVHLCdV.DropDownStyle = ComboBoxStyle.DropDownList;
		M1VvVHLCdV.FormattingEnabled = true;
		M1VvVHLCdV.Location = new Point(35, 3);
		M1VvVHLCdV.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11388);
		M1VvVHLCdV.Size = new Size(138, 21);
		M1VvVHLCdV.TabIndex = 8;
		M1VvVHLCdV.SelectedIndexChanged += mIPb7j8ipe;
		irRvKuYJW6.Controls.Add(OIEvheDlSc);
		irRvKuYJW6.Controls.Add(i9hv4ML4eg);
		irRvKuYJW6.Dock = DockStyle.Fill;
		irRvKuYJW6.Location = new Point(40, 12);
		irRvKuYJW6.Margin = new Padding(0);
		irRvKuYJW6.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11404);
		irRvKuYJW6.Size = new Size(176, 26);
		irRvKuYJW6.TabIndex = 3;
		OIEvheDlSc.Location = new Point(4, 4);
		OIEvheDlSc.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11420);
		OIEvheDlSc.Size = new Size(30, 20);
		OIEvheDlSc.TabIndex = 4;
		OIEvheDlSc.KeyPress += VSDbALOIJN;
		OIEvheDlSc.KeyUp += FIRbdnt6U9;
		i9hv4ML4eg.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		i9hv4ML4eg.DropDownStyle = ComboBoxStyle.DropDownList;
		i9hv4ML4eg.FormattingEnabled = true;
		i9hv4ML4eg.Location = new Point(35, 3);
		i9hv4ML4eg.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11440);
		i9hv4ML4eg.Size = new Size(138, 21);
		i9hv4ML4eg.TabIndex = 5;
		i9hv4ML4eg.SelectedIndexChanged += TN0bCBh337;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(fxQbzxMXK0);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11460);
		base.Size = new Size(392, 93);
		fxQbzxMXK0.ResumeLayout(performLayout: false);
		fxQbzxMXK0.PerformLayout();
		uh6vZEEfq9.ResumeLayout(performLayout: false);
		uh6vZEEfq9.PerformLayout();
		zRtvsPe28m.ResumeLayout(performLayout: false);
		zRtvsPe28m.PerformLayout();
		irRvKuYJW6.ResumeLayout(performLayout: false);
		irRvKuYJW6.PerformLayout();
		ResumeLayout(performLayout: false);
	}
}
