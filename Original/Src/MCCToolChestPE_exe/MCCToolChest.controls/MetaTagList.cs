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

public class MetaTagList : UserControl
{
	private MatchEntry DPI2clBjvO;

	private IContainer d6k2Ja0pio;

	private FlowLayoutPanel Y0i2uSl8HF;

	private Button XrD2ow3pIS;

	private Button IhQ2QDxq5t;

	private Panel U982OQZG8o;

	private Label aUc2CVEfwf;

	private Label cV9277ftYe;

	private Label UAo2AUH1CB;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MetaTagList()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		ddL2DUTake();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddCondition(MatchCondition condition = null)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MatchEntry matchEntry = ((condition == null) ? new MatchEntry(pxo25yKcaT) : new MatchEntry(pxo25yKcaT, condition));
		matchEntry.Width = PeJ2EaaOaW();
		Y0i2uSl8HF.Controls.Add(matchEntry);
		typeof(Control).GetMethod(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21686), BindingFlags.Instance | BindingFlags.NonPublic).Invoke(Y0i2uSl8HF, new object[1] { EventArgs.Empty });
		matchEntry.rcx0r9vQ0o();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hdX23RFr9w(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		zL321uLoGD();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void zL321uLoGD()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = PeJ2EaaOaW();
		foreach (UserControl control in Y0i2uSl8HF.Controls)
		{
			control.Width = num;
		}
		int num2 = (U982OQZG8o.Width - 90) / 2;
		UAo2AUH1CB.Width = num2;
		cV9277ftYe.Width = 95;
		cV9277ftYe.Left = UAo2AUH1CB.Width;
		aUc2CVEfwf.Width = num2;
		aUc2CVEfwf.Left = cV9277ftYe.Width + cV9277ftYe.Left;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int PeJ2EaaOaW()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return Y0i2uSl8HF.Width - (Y0i2uSl8HF.VerticalScroll.Visible ? 30 : 10);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<MatchCondition> GetConditions()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<MatchCondition> list = new List<MatchCondition>();
		foreach (UserControl control in Y0i2uSl8HF.Controls)
		{
			MatchEntry matchEntry = control as MatchEntry;
			list.Add(matchEntry.GetCondition());
		}
		return list;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void QA62rvJrsS(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		AddCondition();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void pxo25yKcaT(MatchEntry P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (DPI2clBjvO != null)
		{
			DPI2clBjvO.SetActive(active: false);
		}
		DPI2clBjvO = P_0;
		DPI2clBjvO.SetActive(active: true);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Kou26S5wx6(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (DPI2clBjvO != null)
		{
			Y0i2uSl8HF.Controls.Remove(DPI2clBjvO);
		}
		if (Y0i2uSl8HF.Controls.Count > 0)
		{
			((MatchEntry)Y0i2uSl8HF.Controls[Y0i2uSl8HF.Controls.Count - 1]).rcx0r9vQ0o();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void xCg2NRfwCT(List<MatchCondition> P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Y0i2uSl8HF.Controls.Clear();
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
		if (disposing && d6k2Ja0pio != null)
		{
			d6k2Ja0pio.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ddL2DUTake()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Y0i2uSl8HF = new FlowLayoutPanel();
		XrD2ow3pIS = new Button();
		IhQ2QDxq5t = new Button();
		U982OQZG8o = new Panel();
		aUc2CVEfwf = new Label();
		cV9277ftYe = new Label();
		UAo2AUH1CB = new Label();
		U982OQZG8o.SuspendLayout();
		SuspendLayout();
		Y0i2uSl8HF.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Y0i2uSl8HF.AutoScroll = true;
		Y0i2uSl8HF.BorderStyle = BorderStyle.FixedSingle;
		Y0i2uSl8HF.Location = new Point(0, 19);
		Y0i2uSl8HF.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21706);
		Y0i2uSl8HF.Size = new Size(418, 233);
		Y0i2uSl8HF.TabIndex = 0;
		Y0i2uSl8HF.Resize += hdX23RFr9w;
		XrD2ow3pIS.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		XrD2ow3pIS.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		XrD2ow3pIS.Image = Resources.GSfSEcQrVsG();
		XrD2ow3pIS.Location = new Point(418, 25);
		XrD2ow3pIS.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14426);
		XrD2ow3pIS.Size = new Size(24, 24);
		XrD2ow3pIS.TabIndex = 4;
		XrD2ow3pIS.UseVisualStyleBackColor = true;
		XrD2ow3pIS.Click += Kou26S5wx6;
		IhQ2QDxq5t.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		IhQ2QDxq5t.Image = Resources.C61S3HP5IFi();
		IhQ2QDxq5t.Location = new Point(418, 0);
		IhQ2QDxq5t.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14448);
		IhQ2QDxq5t.Size = new Size(24, 24);
		IhQ2QDxq5t.TabIndex = 3;
		IhQ2QDxq5t.UseVisualStyleBackColor = true;
		IhQ2QDxq5t.Click += QA62rvJrsS;
		U982OQZG8o.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		U982OQZG8o.BackColor = SystemColors.AppWorkspace;
		U982OQZG8o.BorderStyle = BorderStyle.FixedSingle;
		U982OQZG8o.Controls.Add(aUc2CVEfwf);
		U982OQZG8o.Controls.Add(cV9277ftYe);
		U982OQZG8o.Controls.Add(UAo2AUH1CB);
		U982OQZG8o.Location = new Point(0, 0);
		U982OQZG8o.Margin = new Padding(0);
		U982OQZG8o.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21734);
		U982OQZG8o.Size = new Size(418, 20);
		U982OQZG8o.TabIndex = 5;
		aUc2CVEfwf.Location = new Point(249, 3);
		aUc2CVEfwf.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10482);
		aUc2CVEfwf.Size = new Size(35, 13);
		aUc2CVEfwf.TabIndex = 2;
		aUc2CVEfwf.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21756);
		cV9277ftYe.Location = new Point(71, 3);
		cV9277ftYe.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10582);
		cV9277ftYe.Size = new Size(35, 13);
		cV9277ftYe.TabIndex = 1;
		cV9277ftYe.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21786);
		UAo2AUH1CB.Location = new Point(3, 3);
		UAo2AUH1CB.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		UAo2AUH1CB.Padding = new Padding(5, 0, 0, 0);
		UAo2AUH1CB.Size = new Size(62, 13);
		UAo2AUH1CB.TabIndex = 0;
		UAo2AUH1CB.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21810);
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(U982OQZG8o);
		base.Controls.Add(XrD2ow3pIS);
		base.Controls.Add(IhQ2QDxq5t);
		base.Controls.Add(Y0i2uSl8HF);
		base.Margin = new Padding(0);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21838);
		base.Size = new Size(441, 253);
		U982OQZG8o.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
	}
}
