using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using MCCToolChest.controls;
using MCCToolChest.controls.EntityHelpers;
using MCCToolChest.model;
using MCCToolChest.Properties;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.forms;

public class FlatWorldLayersEditor : Form
{
	private string VqVoym4tlb;

	private IContainer zUmo0D3xvU;

	private Label TI5oBjw5DQ;

	private LayersUI njhotIQBj4;

	private Button EDtoaArUJq;

	private Button tCuoXTqkWJ;

	private BiomeSelector cV3oxvxB1Y;

	private Button B1aoegRux0;

	public string FlatWorldLayers
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return VqVoym4tlb;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			VqVoym4tlb = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public FlatWorldLayersEditor(string flatWorldLayers)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		Q7Io2QgnIj();
		RamoqLlSxR(flatWorldLayers);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RamoqLlSxR(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		VqVoym4tlb = P_0;
		FlatWorld flatWorld = JyDohufWOS(P_0);
		if (flatWorld != null)
		{
			cV3oxvxB1Y.Biome = flatWorld.biome_id;
			PgWoKEqddr(flatWorld);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PgWoKEqddr(FlatWorld P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		FlatWorldBlockLayer[] layers = P_0.block_layers.Reverse().ToArray();
		njhotIQBj4.BuildLayersDisplay(layers);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private FlatWorld JyDohufWOS(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		FlatWorld result = null;
		try
		{
			if (!string.IsNullOrWhiteSpace(P_0))
			{
				JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
				result = javaScriptSerializer.Deserialize<FlatWorld>(P_0);
			}
		}
		catch (Exception)
		{
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void itmomxq283(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.Icon = Resources.usMSrbJo37S();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void z3lonA1yVS(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!cV3oxvxB1Y.HasValue())
		{
			MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(54674), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(54738));
			return;
		}
		StringBuilder stringBuilder = new StringBuilder();
		FlatWorldBlockLayer[] layers = njhotIQBj4.Layers;
		layers = layers.Reverse().ToArray();
		FlatWorldBlockLayer[] array = layers;
		foreach (FlatWorldBlockLayer flatWorldBlockLayer in array)
		{
			if (stringBuilder.Length > 0)
			{
				stringBuilder.Append(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40710));
			}
			stringBuilder.Append(flatWorldBlockLayer.ToString());
		}
		int biome = cV3oxvxB1Y.Biome;
		VqVoym4tlb = string.Format(FlatWorld.layersTemplate, biome, stringBuilder.ToString());
		base.DialogResult = DialogResult.OK;
		Close();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void E2tolYIQkL(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		FlatWorldPresets flatWorldPresets = new FlatWorldPresets();
		if (flatWorldPresets.ShowDialog(this) == DialogResult.OK)
		{
			string flatWorldLayers = flatWorldPresets.FlatWorldLayers;
			RamoqLlSxR(flatWorldLayers);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && zUmo0D3xvU != null)
		{
			zUmo0D3xvU.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Q7Io2QgnIj()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TI5oBjw5DQ = new Label();
		EDtoaArUJq = new Button();
		tCuoXTqkWJ = new Button();
		cV3oxvxB1Y = new BiomeSelector();
		njhotIQBj4 = new LayersUI();
		B1aoegRux0 = new Button();
		SuspendLayout();
		TI5oBjw5DQ.AutoSize = true;
		TI5oBjw5DQ.Location = new Point(9, 10);
		TI5oBjw5DQ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		TI5oBjw5DQ.Size = new Size(36, 13);
		TI5oBjw5DQ.TabIndex = 2;
		TI5oBjw5DQ.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(45412);
		EDtoaArUJq.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		EDtoaArUJq.DialogResult = DialogResult.Cancel;
		EDtoaArUJq.Location = new Point(374, 612);
		EDtoaArUJq.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34610);
		EDtoaArUJq.Size = new Size(50, 23);
		EDtoaArUJq.TabIndex = 6;
		EDtoaArUJq.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20198);
		EDtoaArUJq.UseVisualStyleBackColor = true;
		tCuoXTqkWJ.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		tCuoXTqkWJ.Location = new Point(315, 612);
		tCuoXTqkWJ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34632);
		tCuoXTqkWJ.Size = new Size(50, 23);
		tCuoXTqkWJ.TabIndex = 5;
		tCuoXTqkWJ.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34646);
		tCuoXTqkWJ.UseVisualStyleBackColor = true;
		tCuoXTqkWJ.Click += z3lonA1yVS;
		cV3oxvxB1Y.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		cV3oxvxB1Y.Biome = 1000;
		cV3oxvxB1Y.Location = new Point(12, 22);
		cV3oxvxB1Y.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(54766);
		cV3oxvxB1Y.Size = new Size(412, 28);
		cV3oxvxB1Y.TabIndex = 7;
		njhotIQBj4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		njhotIQBj4.Location = new Point(12, 58);
		njhotIQBj4.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(54798);
		njhotIQBj4.Size = new Size(412, 550);
		njhotIQBj4.TabIndex = 4;
		B1aoegRux0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		B1aoegRux0.Location = new Point(12, 612);
		B1aoegRux0.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(54820);
		B1aoegRux0.Size = new Size(50, 23);
		B1aoegRux0.TabIndex = 8;
		B1aoegRux0.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(54844);
		B1aoegRux0.UseVisualStyleBackColor = true;
		B1aoegRux0.Click += E2tolYIQkL;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(438, 642);
		base.Controls.Add(B1aoegRux0);
		base.Controls.Add(cV3oxvxB1Y);
		base.Controls.Add(EDtoaArUJq);
		base.Controls.Add(tCuoXTqkWJ);
		base.Controls.Add(njhotIQBj4);
		base.Controls.Add(TI5oBjw5DQ);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(54862);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(54908);
		base.Load += itmomxq283;
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
