using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.Properties;
using Save_Manager.events;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace Save_Manager;

public class SaveManager : Form
{
	private SaveSelectedEventArgs wrJSxIYQaWF;

	private IContainer beBSxzxrrjB;

	private SaveFileDialog quaSeTfingm;

	private OpenFileDialog RfZSeSSgktb;

	private OpenFileDialog HAqSeGU0cqh;

	private TabControl vDFSebWYHhc;

	private Label HLpSevS6jYX;

	private Button n2tSewPnacm;

	private TabPage RWlSe47bLRR;

	private ImageList tP8SeV81k3X;

	private TabPage P5YSeWYNSnw;

	private TabPage mVVSeplxLAF;

	public SaveSelectedEventArgs SaveSelected
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return wrJSxIYQaWF;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			wrJSxIYQaWF = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SaveManager()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		PVeSx9tnubQ();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ub6SxAAMphI(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.Icon = Resources.usMSrbJo37S();
		vDFSebWYHhc.TabPages.RemoveByKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(208752));
		vDFSebWYHhc.TabPages.RemoveByKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(208768));
		vDFSebWYHhc.TabPages.RemoveByKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(208780));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void zOiSxdD1VfI(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		X4OSxHBg0gf();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void X4OSxHBg0gf()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (wrJSxIYQaWF != null)
		{
			base.DialogResult = DialogResult.OK;
			Close();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void D5kSxFCVJfQ(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		wrJSxIYQaWF = null;
		HLpSevS6jYX.Text = "";
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void vMFSxj2YeYH(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		SaveSelectedEventArgs e = P_1 as SaveSelectedEventArgs;
		HLpSevS6jYX.Text = e.Name;
		wrJSxIYQaWF = e;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DKHSx8b90JM(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		vMFSxj2YeYH(P_0, P_1);
		X4OSxHBg0gf();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && beBSxzxrrjB != null)
		{
			beBSxzxrrjB.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PVeSx9tnubQ()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		beBSxzxrrjB = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(SaveManager));
		quaSeTfingm = new SaveFileDialog();
		RfZSeSSgktb = new OpenFileDialog();
		HAqSeGU0cqh = new OpenFileDialog();
		vDFSebWYHhc = new TabControl();
		RWlSe47bLRR = new TabPage();
		P5YSeWYNSnw = new TabPage();
		tP8SeV81k3X = new ImageList(beBSxzxrrjB);
		HLpSevS6jYX = new Label();
		n2tSewPnacm = new Button();
		mVVSeplxLAF = new TabPage();
		vDFSebWYHhc.SuspendLayout();
		SuspendLayout();
		quaSeTfingm.DefaultExt = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(208796);
		quaSeTfingm.FileName = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(208804);
		quaSeTfingm.Filter = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(208828);
		RfZSeSSgktb.DefaultExt = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(208796);
		RfZSeSSgktb.Filter = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(208828);
		RfZSeSSgktb.Title = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(208866);
		HAqSeGU0cqh.DefaultExt = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(208894);
		HAqSeGU0cqh.FileName = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70638);
		HAqSeGU0cqh.Filter = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(208904);
		HAqSeGU0cqh.Title = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(208970);
		vDFSebWYHhc.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		vDFSebWYHhc.Controls.Add(mVVSeplxLAF);
		vDFSebWYHhc.Controls.Add(RWlSe47bLRR);
		vDFSebWYHhc.Controls.Add(P5YSeWYNSnw);
		vDFSebWYHhc.Location = new Point(0, 12);
		vDFSebWYHhc.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(209000);
		vDFSebWYHhc.SelectedIndex = 0;
		vDFSebWYHhc.Size = new Size(396, 518);
		vDFSebWYHhc.TabIndex = 1;
		vDFSebWYHhc.SelectedIndexChanged += D5kSxFCVJfQ;
		RWlSe47bLRR.ImageIndex = 3;
		RWlSe47bLRR.Location = new Point(4, 22);
		RWlSe47bLRR.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(208768);
		RWlSe47bLRR.Padding = new Padding(3);
		RWlSe47bLRR.Size = new Size(388, 492);
		RWlSe47bLRR.TabIndex = 3;
		RWlSe47bLRR.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(208302);
		RWlSe47bLRR.UseVisualStyleBackColor = true;
		P5YSeWYNSnw.Location = new Point(4, 22);
		P5YSeWYNSnw.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(208780);
		P5YSeWYNSnw.Padding = new Padding(3);
		P5YSeWYNSnw.Size = new Size(388, 492);
		P5YSeWYNSnw.TabIndex = 5;
		P5YSeWYNSnw.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29532);
		P5YSeWYNSnw.UseVisualStyleBackColor = true;
		tP8SeV81k3X.ImageStream = (ImageListStreamer)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(209026));
		tP8SeV81k3X.TransparentColor = Color.Transparent;
		tP8SeV81k3X.Images.SetKeyName(0, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(209066));
		tP8SeV81k3X.Images.SetKeyName(1, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(209094));
		tP8SeV81k3X.Images.SetKeyName(2, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(209112));
		tP8SeV81k3X.Images.SetKeyName(3, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(209132));
		HLpSevS6jYX.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		HLpSevS6jYX.AutoSize = true;
		HLpSevS6jYX.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		HLpSevS6jYX.Location = new Point(7, 542);
		HLpSevS6jYX.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		HLpSevS6jYX.Padding = new Padding(3, 0, 3, 0);
		HLpSevS6jYX.Size = new Size(6, 16);
		HLpSevS6jYX.TabIndex = 2;
		n2tSewPnacm.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		n2tSewPnacm.Location = new Point(343, 539);
		n2tSewPnacm.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(209148);
		n2tSewPnacm.Size = new Size(53, 23);
		n2tSewPnacm.TabIndex = 3;
		n2tSewPnacm.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29568);
		n2tSewPnacm.UseVisualStyleBackColor = true;
		n2tSewPnacm.Click += zOiSxdD1VfI;
		mVVSeplxLAF.Location = new Point(4, 22);
		mVVSeplxLAF.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(209166);
		mVVSeplxLAF.Padding = new Padding(3);
		mVVSeplxLAF.Size = new Size(388, 492);
		mVVSeplxLAF.TabIndex = 6;
		mVVSeplxLAF.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(208310);
		mVVSeplxLAF.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(404, 571);
		base.Controls.Add(n2tSewPnacm);
		base.Controls.Add(HLpSevS6jYX);
		base.Controls.Add(vDFSebWYHhc);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(209178);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(209204);
		base.Load += ub6SxAAMphI;
		vDFSebWYHhc.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
