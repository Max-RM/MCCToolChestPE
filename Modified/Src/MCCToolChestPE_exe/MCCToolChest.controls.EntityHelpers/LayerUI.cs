using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using HiT3kduFNLtRQIR37JV;
using MCCToolChest.events;
using MCCToolChest.model;
using uL2B6CXB2hZQU16Di7r;
using uP7B13T5waxVpI3AEv;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls.EntityHelpers;

public class LayerUI : UserControl
{
	private bool CBlhZlmXj8;

	private bool On6hf4RGVs;

	private FlatWorldBlockLayer Kxrhi2Exdq;

	private LayerChanged VQWhsmSCer;

	private LayerUISelected E0NhqEQdCp;

	private IContainer Ej3hKen8hV;

	private ComboBox GbkhhhW08B;

	private PictureBoxWithInterpolationMode WyxhmrQoI1;

	private NumericUpDown e6rhnM0WdB;

	private TextBox xirhl5OMwO;

	private Label bKgh2bLqNS;

	private Label HpNhyCbanr;

	public FlatWorldBlockLayer FlatWorldLayer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return Kxrhi2Exdq;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			Kxrhi2Exdq = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetActiveState(bool active)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		On6hf4RGVs = active;
		base.BorderStyle = (active ? BorderStyle.FixedSingle : BorderStyle.None);
		if (active)
		{
			GbkhhhW08B.Focus();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LayerUI(FlatWorldBlockLayer flatWorldBlockLayer, LayerChanged layerChanged, LayerUISelected layerUISelected)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		XG7hpEWjgE();
		Kxrhi2Exdq = flatWorldBlockLayer;
		VQWhsmSCer = layerChanged;
		E0NhqEQdCp = layerUISelected;
		CBlhZlmXj8 = true;
		crnhbMVsmt();
		CBlhZlmXj8 = false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void crnhbMVsmt()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (INYifyudg3hCpcrleHt.GKBS0K4re36() == null)
		{
			return;
		}
		GbkhhhW08B.ValueMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10196);
		GbkhhhW08B.DisplayMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11830);
		GbkhhhW08B.DataSource = BFRL2f2UoG7tBGIHJF.mAVSRPT1qd().Values.ToList();
		if (Kxrhi2Exdq != null)
		{
			e6rhnM0WdB.Text = Kxrhi2Exdq.count.ToString();
			int block_id = Kxrhi2Exdq.block_id;
			short block_data = Kxrhi2Exdq.block_data;
			string block_name = Kxrhi2Exdq.block_name;
			if (!string.IsNullOrWhiteSpace(block_name))
			{
				block_name = BlockMaster.GetBedrockBlockState(block_name, block_data).masterBlock.name;
				Kxrhi2Exdq.block_id = BlockMaster.GetBedrockBlockState(block_name, block_data).id.Value;
			}
			else
			{
				block_name = BlockMaster.GetBedrockBlockState(block_id, block_data).masterBlock.Name;
				Kxrhi2Exdq.block_name = BlockMaster.GetBedrockBlockState(block_id, block_data).name;
			}
			GbkhhhW08B.SelectedValue = block_name;
			UpdateBlockImage();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ng9hvJ80E1(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!CBlhZlmXj8)
		{
			string key = (string)GbkhhhW08B.SelectedValue;
			int block_id = (BlockMaster.Blocks[key].bedrock.id.HasValue ? BlockMaster.Blocks[key].bedrock.id.Value : 0);
			int num = (BlockMaster.Blocks[key].bedrock.data.HasValue ? BlockMaster.Blocks[key].bedrock.data.Value : 0);
			string name = BlockMaster.Blocks[key].bedrock.name;
			Kxrhi2Exdq.block_id = block_id;
			Kxrhi2Exdq.block_data = (byte)num;
			Kxrhi2Exdq.block_name = name;
			UpdateBlockImage();
			AcShwQbG6o();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AcShwQbG6o()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (VQWhsmSCer != null)
		{
			VQWhsmSCer();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FEqh4jn0nC(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		short.TryParse(xirhl5OMwO.Text, out var result);
		Kxrhi2Exdq.block_data = result;
		AcShwQbG6o();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void b3ChVmmXeI(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Kxrhi2Exdq.count = (short)e6rhnM0WdB.Value;
		AcShwQbG6o();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateBlockImage()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Image image = BFRL2f2UoG7tBGIHJF.iWMSUEyuJn(Kxrhi2Exdq.block_name, Kxrhi2Exdq.block_data);
		WyxhmrQoI1.Image = image;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void NTuhWFVGfe(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (E0NhqEQdCp != null)
		{
			E0NhqEQdCp(this);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && Ej3hKen8hV != null)
		{
			Ej3hKen8hV.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void XG7hpEWjgE()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		GbkhhhW08B = new ComboBox();
		e6rhnM0WdB = new NumericUpDown();
		xirhl5OMwO = new TextBox();
		bKgh2bLqNS = new Label();
		HpNhyCbanr = new Label();
		WyxhmrQoI1 = new PictureBoxWithInterpolationMode();
		((ISupportInitialize)e6rhnM0WdB).BeginInit();
		((ISupportInitialize)WyxhmrQoI1).BeginInit();
		SuspendLayout();
		GbkhhhW08B.DropDownStyle = ComboBoxStyle.DropDownList;
		GbkhhhW08B.FormattingEnabled = true;
		GbkhhhW08B.Location = new Point(76, 7);
		GbkhhhW08B.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20022);
		GbkhhhW08B.Size = new Size(280, 21);
		GbkhhhW08B.TabIndex = 1;
		GbkhhhW08B.SelectedIndexChanged += ng9hvJ80E1;
		GbkhhhW08B.Click += NTuhWFVGfe;
		e6rhnM0WdB.Location = new Point(115, 37);
		e6rhnM0WdB.Maximum = new decimal(new int[4] { 255, 0, 0, 0 });
		e6rhnM0WdB.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20042);
		e6rhnM0WdB.Size = new Size(47, 20);
		e6rhnM0WdB.TabIndex = 3;
		e6rhnM0WdB.ValueChanged += b3ChVmmXeI;
		e6rhnM0WdB.Click += NTuhWFVGfe;
		xirhl5OMwO.Location = new Point(302, 37);
		xirhl5OMwO.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11856);
		xirhl5OMwO.Size = new Size(42, 20);
		xirhl5OMwO.TabIndex = 12;
		xirhl5OMwO.Visible = false;
		xirhl5OMwO.Click += NTuhWFVGfe;
		xirhl5OMwO.TextChanged += FEqh4jn0nC;
		bKgh2bLqNS.AutoSize = true;
		bKgh2bLqNS.Location = new Point(270, 40);
		bKgh2bLqNS.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10482);
		bKgh2bLqNS.Size = new Size(30, 13);
		bKgh2bLqNS.TabIndex = 11;
		bKgh2bLqNS.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11178);
		bKgh2bLqNS.Visible = false;
		bKgh2bLqNS.Click += NTuhWFVGfe;
		HpNhyCbanr.AutoSize = true;
		HpNhyCbanr.Location = new Point(77, 40);
		HpNhyCbanr.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		HpNhyCbanr.Size = new Size(38, 13);
		HpNhyCbanr.TabIndex = 13;
		HpNhyCbanr.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11650);
		HpNhyCbanr.Click += NTuhWFVGfe;
		WyxhmrQoI1.BorderStyle = BorderStyle.FixedSingle;
		WyxhmrQoI1.InterpolationMode = InterpolationMode.NearestNeighbor;
		WyxhmrQoI1.Location = new Point(3, 5);
		WyxhmrQoI1.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11872);
		WyxhmrQoI1.Size = new Size(64, 64);
		WyxhmrQoI1.SizeMode = PictureBoxSizeMode.StretchImage;
		WyxhmrQoI1.TabIndex = 2;
		WyxhmrQoI1.TabStop = false;
		WyxhmrQoI1.Click += NTuhWFVGfe;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(HpNhyCbanr);
		base.Controls.Add(xirhl5OMwO);
		base.Controls.Add(bKgh2bLqNS);
		base.Controls.Add(e6rhnM0WdB);
		base.Controls.Add(WyxhmrQoI1);
		base.Controls.Add(GbkhhhW08B);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20062);
		base.Size = new Size(360, 75);
		base.Click += NTuhWFVGfe;
		((ISupportInitialize)e6rhnM0WdB).EndInit();
		((ISupportInitialize)WyxhmrQoI1).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
