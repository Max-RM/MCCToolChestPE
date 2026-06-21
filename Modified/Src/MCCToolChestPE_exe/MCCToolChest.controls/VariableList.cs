using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.model.SearchReplace;
using MCCToolChest.Properties;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls;

public class VariableList : UserControl
{
	private VariableEntry kIueghhuFU;

	private IContainer heOePymruU;

	private Panel jqgeRvAJel;

	private Label I1Wekkvuw9;

	private Label SgSeYhtPAd;

	private Label O9ue35khkE;

	private Button njee1SOEub;

	private Button I9heElMY5C;

	private FlowLayoutPanel X2OermUWMr;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public VariableList()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		aLCeLVcVfM();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void MmCe0gKP3a(List<SearchReplaceVariable> P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		X2OermUWMr.Controls.Clear();
		foreach (SearchReplaceVariable item in P_0)
		{
			bPneeNXb62(item);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<SearchReplaceVariable> GetVariables()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<SearchReplaceVariable> list = new List<SearchReplaceVariable>();
		foreach (UserControl control in X2OermUWMr.Controls)
		{
			VariableEntry variableEntry = control as VariableEntry;
			list.Add(variableEntry.GetVariable());
		}
		return list;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HHkeBdSsDy(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		I9ketQ9CDO();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void I9ketQ9CDO()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = CViead4D8q();
		foreach (UserControl control in X2OermUWMr.Controls)
		{
			control.Width = num;
		}
		_ = (jqgeRvAJel.Width - 90) / 2;
		O9ue35khkE.Width = 180;
		SgSeYhtPAd.Width = 135;
		SgSeYhtPAd.Left = O9ue35khkE.Width;
		I1Wekkvuw9.Width = num - (SgSeYhtPAd.Width + O9ue35khkE.Width);
		I1Wekkvuw9.Left = SgSeYhtPAd.Width + SgSeYhtPAd.Left;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int CViead4D8q()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return X2OermUWMr.Width - (X2OermUWMr.VerticalScroll.Visible ? 30 : 10);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void QdReXwLqOW(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bPneeNXb62();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void z9jexvr82V(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		DubeUnFuFj();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void bPneeNXb62(SearchReplaceVariable P_0 = null)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		VariableEntry variableEntry = ((P_0 == null) ? new VariableEntry(TQveMUCdOr) : new VariableEntry(TQveMUCdOr, P_0));
		variableEntry.Width = CViead4D8q();
		X2OermUWMr.Controls.Add(variableEntry);
		typeof(Control).GetMethod(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21686), BindingFlags.Instance | BindingFlags.NonPublic).Invoke(X2OermUWMr, new object[1] { EventArgs.Empty });
		variableEntry.ajqeir3JnU();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TQveMUCdOr(VariableEntry P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (kIueghhuFU != null)
		{
			kIueghhuFU.SetActive(active: false);
		}
		kIueghhuFU = P_0;
		kIueghhuFU.SetActive(active: true);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DubeUnFuFj()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (kIueghhuFU != null)
		{
			X2OermUWMr.Controls.Remove(kIueghhuFU);
		}
		if (X2OermUWMr.Controls.Count > 0)
		{
			((VariableEntry)X2OermUWMr.Controls[X2OermUWMr.Controls.Count - 1]).ajqeir3JnU();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && heOePymruU != null)
		{
			heOePymruU.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void aLCeLVcVfM()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		jqgeRvAJel = new Panel();
		I1Wekkvuw9 = new Label();
		SgSeYhtPAd = new Label();
		O9ue35khkE = new Label();
		njee1SOEub = new Button();
		I9heElMY5C = new Button();
		X2OermUWMr = new FlowLayoutPanel();
		jqgeRvAJel.SuspendLayout();
		SuspendLayout();
		jqgeRvAJel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		jqgeRvAJel.BackColor = SystemColors.AppWorkspace;
		jqgeRvAJel.BorderStyle = BorderStyle.FixedSingle;
		jqgeRvAJel.Controls.Add(I1Wekkvuw9);
		jqgeRvAJel.Controls.Add(SgSeYhtPAd);
		jqgeRvAJel.Controls.Add(O9ue35khkE);
		jqgeRvAJel.Location = new Point(0, 0);
		jqgeRvAJel.Margin = new Padding(0);
		jqgeRvAJel.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21734);
		jqgeRvAJel.Size = new Size(418, 20);
		jqgeRvAJel.TabIndex = 7;
		I1Wekkvuw9.Location = new Point(249, 3);
		I1Wekkvuw9.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10482);
		I1Wekkvuw9.Size = new Size(35, 13);
		I1Wekkvuw9.TabIndex = 2;
		I1Wekkvuw9.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11118);
		SgSeYhtPAd.Location = new Point(71, 3);
		SgSeYhtPAd.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10582);
		SgSeYhtPAd.Size = new Size(113, 13);
		SgSeYhtPAd.TabIndex = 1;
		SgSeYhtPAd.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(30014);
		O9ue35khkE.Location = new Point(3, 3);
		O9ue35khkE.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		O9ue35khkE.Padding = new Padding(5, 0, 0, 0);
		O9ue35khkE.Size = new Size(115, 13);
		O9ue35khkE.TabIndex = 0;
		O9ue35khkE.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(30434);
		njee1SOEub.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		njee1SOEub.Image = Resources.GSfSEcQrVsG();
		njee1SOEub.Location = new Point(418, 25);
		njee1SOEub.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14426);
		njee1SOEub.Size = new Size(24, 24);
		njee1SOEub.TabIndex = 6;
		njee1SOEub.UseVisualStyleBackColor = true;
		njee1SOEub.Click += z9jexvr82V;
		I9heElMY5C.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		I9heElMY5C.Image = Resources.C61S3HP5IFi();
		I9heElMY5C.Location = new Point(418, 0);
		I9heElMY5C.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14448);
		I9heElMY5C.Size = new Size(24, 24);
		I9heElMY5C.TabIndex = 5;
		I9heElMY5C.UseVisualStyleBackColor = true;
		I9heElMY5C.Click += QdReXwLqOW;
		X2OermUWMr.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		X2OermUWMr.AutoScroll = true;
		X2OermUWMr.BorderStyle = BorderStyle.FixedSingle;
		X2OermUWMr.Location = new Point(0, 19);
		X2OermUWMr.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(30464);
		X2OermUWMr.Size = new Size(418, 233);
		X2OermUWMr.TabIndex = 4;
		X2OermUWMr.Resize += HHkeBdSsDy;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(jqgeRvAJel);
		base.Controls.Add(njee1SOEub);
		base.Controls.Add(I9heElMY5C);
		base.Controls.Add(X2OermUWMr);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(30498);
		base.Size = new Size(441, 253);
		jqgeRvAJel.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
	}
}
