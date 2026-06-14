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

public class ReplaceList : UserControl
{
	private ReplaceEntry ExZxDMnICp;

	private IContainer VVUxc26pMe;

	private FlowLayoutPanel zQqxJqX5Z5;

	private Button OntxuwqC6h;

	private Button PJYxoeOC2q;

	private Panel TrmxQPGBin;

	private Label wh2xO0kP2B;

	private Label znbxCkLiNB;

	private Label Pnox7A1qy7;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ReplaceList()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		QXTxNlTear();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddReplacement(ReplaceValue replacement = null)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ReplaceEntry replaceEntry = ((replacement == null) ? new ReplaceEntry(tRMxrJudQf) : new ReplaceEntry(tRMxrJudQf, replacement));
		replaceEntry.Width = MNCx1AI9C6();
		zQqxJqX5Z5.Controls.Add(replaceEntry);
		typeof(Control).GetMethod(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21686), BindingFlags.Instance | BindingFlags.NonPublic).Invoke(zQqxJqX5Z5, new object[1] { EventArgs.Empty });
		replaceEntry.IKpxM8RMda();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Kf4xYPmoP4(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		SmQx3QkgHB();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SmQx3QkgHB()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = MNCx1AI9C6();
		foreach (UserControl control in zQqxJqX5Z5.Controls)
		{
			control.Width = num;
		}
		int num2 = (TrmxQPGBin.Width - 90) / 2;
		Pnox7A1qy7.Width = num2;
		znbxCkLiNB.Width = 95;
		znbxCkLiNB.Left = Pnox7A1qy7.Width;
		wh2xO0kP2B.Width = num2;
		wh2xO0kP2B.Left = znbxCkLiNB.Width + znbxCkLiNB.Left;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int MNCx1AI9C6()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return zQqxJqX5Z5.Width - (zQqxJqX5Z5.VerticalScroll.Visible ? 30 : 10);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<ReplaceValue> GetReplacements()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<ReplaceValue> list = new List<ReplaceValue>();
		foreach (UserControl control in zQqxJqX5Z5.Controls)
		{
			ReplaceEntry replaceEntry = control as ReplaceEntry;
			list.Add(replaceEntry.GetReplacement());
		}
		return list;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BIJxEutZH1(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		AddReplacement();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void tRMxrJudQf(ReplaceEntry P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (ExZxDMnICp != null)
		{
			ExZxDMnICp.SetActive(active: false);
		}
		ExZxDMnICp = P_0;
		ExZxDMnICp.SetActive(active: true);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void l9xx513gah(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (ExZxDMnICp != null)
		{
			zQqxJqX5Z5.Controls.Remove(ExZxDMnICp);
		}
		if (zQqxJqX5Z5.Controls.Count > 0)
		{
			((ReplaceEntry)zQqxJqX5Z5.Controls[zQqxJqX5Z5.Controls.Count - 1]).IKpxM8RMda();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void gGtx6ZVyvW(List<ReplaceValue> P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		zQqxJqX5Z5.Controls.Clear();
		foreach (ReplaceValue item in P_0)
		{
			AddReplacement(item);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && VVUxc26pMe != null)
		{
			VVUxc26pMe.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void QXTxNlTear()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		zQqxJqX5Z5 = new FlowLayoutPanel();
		OntxuwqC6h = new Button();
		PJYxoeOC2q = new Button();
		TrmxQPGBin = new Panel();
		Pnox7A1qy7 = new Label();
		znbxCkLiNB = new Label();
		wh2xO0kP2B = new Label();
		TrmxQPGBin.SuspendLayout();
		SuspendLayout();
		zQqxJqX5Z5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		zQqxJqX5Z5.AutoScroll = true;
		zQqxJqX5Z5.BorderStyle = BorderStyle.FixedSingle;
		zQqxJqX5Z5.Location = new Point(0, 19);
		zQqxJqX5Z5.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29954);
		zQqxJqX5Z5.Size = new Size(418, 233);
		zQqxJqX5Z5.TabIndex = 0;
		zQqxJqX5Z5.Resize += Kf4xYPmoP4;
		OntxuwqC6h.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		OntxuwqC6h.Image = Resources.C61S3HP5IFi();
		OntxuwqC6h.Location = new Point(418, 0);
		OntxuwqC6h.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14448);
		OntxuwqC6h.Size = new Size(24, 24);
		OntxuwqC6h.TabIndex = 1;
		OntxuwqC6h.UseVisualStyleBackColor = true;
		OntxuwqC6h.Click += BIJxEutZH1;
		PJYxoeOC2q.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		PJYxoeOC2q.Image = Resources.GSfSEcQrVsG();
		PJYxoeOC2q.Location = new Point(418, 25);
		PJYxoeOC2q.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14426);
		PJYxoeOC2q.Size = new Size(24, 24);
		PJYxoeOC2q.TabIndex = 2;
		PJYxoeOC2q.UseVisualStyleBackColor = true;
		PJYxoeOC2q.Click += l9xx513gah;
		TrmxQPGBin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		TrmxQPGBin.BackColor = SystemColors.AppWorkspace;
		TrmxQPGBin.BorderStyle = BorderStyle.FixedSingle;
		TrmxQPGBin.Controls.Add(wh2xO0kP2B);
		TrmxQPGBin.Controls.Add(znbxCkLiNB);
		TrmxQPGBin.Controls.Add(Pnox7A1qy7);
		TrmxQPGBin.Location = new Point(0, 0);
		TrmxQPGBin.Margin = new Padding(0);
		TrmxQPGBin.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21734);
		TrmxQPGBin.Size = new Size(418, 20);
		TrmxQPGBin.TabIndex = 3;
		Pnox7A1qy7.Location = new Point(3, 3);
		Pnox7A1qy7.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		Pnox7A1qy7.Padding = new Padding(5, 0, 0, 0);
		Pnox7A1qy7.Size = new Size(62, 13);
		Pnox7A1qy7.TabIndex = 0;
		Pnox7A1qy7.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29986);
		znbxCkLiNB.Location = new Point(71, 3);
		znbxCkLiNB.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10582);
		znbxCkLiNB.Size = new Size(35, 13);
		znbxCkLiNB.TabIndex = 1;
		znbxCkLiNB.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(30014);
		wh2xO0kP2B.Location = new Point(249, 3);
		wh2xO0kP2B.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10482);
		wh2xO0kP2B.Size = new Size(35, 13);
		wh2xO0kP2B.TabIndex = 2;
		wh2xO0kP2B.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(30036);
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(TrmxQPGBin);
		base.Controls.Add(PJYxoeOC2q);
		base.Controls.Add(OntxuwqC6h);
		base.Controls.Add(zQqxJqX5Z5);
		base.Margin = new Padding(0);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(30066);
		base.Size = new Size(441, 253);
		TrmxQPGBin.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
	}
}
