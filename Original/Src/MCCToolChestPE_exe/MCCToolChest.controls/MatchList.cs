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

public class MatchList : UserControl
{
	private MatchEntry DQ50H1CPKW;

	private IContainer Lvs0FlOj8T;

	private FlowLayoutPanel a2K0jsG8T4;

	private Button ueY08j4gSs;

	private Button t7w098CwAr;

	private Panel hKl0Ibf49J;

	private Label y060zK2j3T;

	private Label xC7BTerdKY;

	private Label wEJBS0sLV5;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MatchList()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		Wye0dvuOsP();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddCondition(MatchCondition condition = null)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MatchEntry matchEntry = ((condition == null) ? new MatchEntry(KHU0CG3hkW) : new MatchEntry(KHU0CG3hkW, condition));
		matchEntry.Width = IbT0QTjbC1();
		a2K0jsG8T4.Controls.Add(matchEntry);
		typeof(Control).GetMethod(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21686), BindingFlags.Instance | BindingFlags.NonPublic).Invoke(a2K0jsG8T4, new object[1] { EventArgs.Empty });
		matchEntry.rcx0r9vQ0o();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RNK0uo3nfF(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		rq30oMA6SQ();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void rq30oMA6SQ()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = IbT0QTjbC1();
		foreach (UserControl control in a2K0jsG8T4.Controls)
		{
			control.Width = num;
		}
		int num2 = (hKl0Ibf49J.Width - 90) / 2;
		wEJBS0sLV5.Width = num2;
		xC7BTerdKY.Width = 95;
		xC7BTerdKY.Left = wEJBS0sLV5.Width;
		y060zK2j3T.Width = num2;
		y060zK2j3T.Left = xC7BTerdKY.Width + xC7BTerdKY.Left;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int IbT0QTjbC1()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return a2K0jsG8T4.Width - (a2K0jsG8T4.VerticalScroll.Visible ? 30 : 10);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<MatchCondition> GetConditions()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<MatchCondition> list = new List<MatchCondition>();
		foreach (UserControl control in a2K0jsG8T4.Controls)
		{
			MatchEntry matchEntry = control as MatchEntry;
			list.Add(matchEntry.GetCondition());
		}
		return list;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Fp20ObcynT(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		AddCondition();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void KHU0CG3hkW(MatchEntry P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (DQ50H1CPKW != null)
		{
			DQ50H1CPKW.SetActive(active: false);
		}
		DQ50H1CPKW = P_0;
		DQ50H1CPKW.SetActive(active: true);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Ejg07lKRSY(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (DQ50H1CPKW != null)
		{
			a2K0jsG8T4.Controls.Remove(DQ50H1CPKW);
		}
		if (a2K0jsG8T4.Controls.Count > 0)
		{
			((MatchEntry)a2K0jsG8T4.Controls[a2K0jsG8T4.Controls.Count - 1]).rcx0r9vQ0o();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void YoJ0AfFc5q(List<MatchCondition> P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		a2K0jsG8T4.Controls.Clear();
		foreach (MatchCondition item in P_0)
		{
			AddCondition(item);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && Lvs0FlOj8T != null)
		{
			Lvs0FlOj8T.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Wye0dvuOsP()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		a2K0jsG8T4 = new FlowLayoutPanel();
		ueY08j4gSs = new Button();
		t7w098CwAr = new Button();
		hKl0Ibf49J = new Panel();
		y060zK2j3T = new Label();
		xC7BTerdKY = new Label();
		wEJBS0sLV5 = new Label();
		hKl0Ibf49J.SuspendLayout();
		SuspendLayout();
		a2K0jsG8T4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		a2K0jsG8T4.AutoScroll = true;
		a2K0jsG8T4.BorderStyle = BorderStyle.FixedSingle;
		a2K0jsG8T4.Location = new Point(0, 19);
		a2K0jsG8T4.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21706);
		a2K0jsG8T4.Size = new Size(418, 233);
		a2K0jsG8T4.TabIndex = 0;
		a2K0jsG8T4.Resize += RNK0uo3nfF;
		ueY08j4gSs.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		ueY08j4gSs.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		ueY08j4gSs.Image = Resources.GSfSEcQrVsG();
		ueY08j4gSs.Location = new Point(418, 25);
		ueY08j4gSs.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14426);
		ueY08j4gSs.Size = new Size(24, 24);
		ueY08j4gSs.TabIndex = 4;
		ueY08j4gSs.UseVisualStyleBackColor = true;
		ueY08j4gSs.Click += Ejg07lKRSY;
		t7w098CwAr.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		t7w098CwAr.Image = Resources.C61S3HP5IFi();
		t7w098CwAr.Location = new Point(418, 0);
		t7w098CwAr.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14448);
		t7w098CwAr.Size = new Size(24, 24);
		t7w098CwAr.TabIndex = 3;
		t7w098CwAr.UseVisualStyleBackColor = true;
		t7w098CwAr.Click += Fp20ObcynT;
		hKl0Ibf49J.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		hKl0Ibf49J.BackColor = SystemColors.AppWorkspace;
		hKl0Ibf49J.BorderStyle = BorderStyle.FixedSingle;
		hKl0Ibf49J.Controls.Add(y060zK2j3T);
		hKl0Ibf49J.Controls.Add(xC7BTerdKY);
		hKl0Ibf49J.Controls.Add(wEJBS0sLV5);
		hKl0Ibf49J.Location = new Point(0, 0);
		hKl0Ibf49J.Margin = new Padding(0);
		hKl0Ibf49J.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21734);
		hKl0Ibf49J.Size = new Size(418, 20);
		hKl0Ibf49J.TabIndex = 5;
		y060zK2j3T.Location = new Point(249, 3);
		y060zK2j3T.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10482);
		y060zK2j3T.Size = new Size(35, 13);
		y060zK2j3T.TabIndex = 2;
		y060zK2j3T.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21756);
		xC7BTerdKY.Location = new Point(71, 3);
		xC7BTerdKY.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10582);
		xC7BTerdKY.Size = new Size(35, 13);
		xC7BTerdKY.TabIndex = 1;
		xC7BTerdKY.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21786);
		wEJBS0sLV5.Location = new Point(3, 3);
		wEJBS0sLV5.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		wEJBS0sLV5.Padding = new Padding(5, 0, 0, 0);
		wEJBS0sLV5.Size = new Size(62, 13);
		wEJBS0sLV5.TabIndex = 0;
		wEJBS0sLV5.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21810);
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(hKl0Ibf49J);
		base.Controls.Add(ueY08j4gSs);
		base.Controls.Add(t7w098CwAr);
		base.Controls.Add(a2K0jsG8T4);
		base.Margin = new Padding(0);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21838);
		base.Size = new Size(441, 253);
		hKl0Ibf49J.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
	}
}
