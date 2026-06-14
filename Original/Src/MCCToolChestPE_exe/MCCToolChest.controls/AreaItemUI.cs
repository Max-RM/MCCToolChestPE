using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.events;
using MCCToolChest.model;
using MCCToolChest.Properties;
using MCCToolChest.utils;
using MCCToolChest.workers;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls;

public class AreaItemUI : UserControl
{
	private bool rVdG5aoH5e;

	private AreaItemSelected D1WG6qBvcX;

	private AreaItemDelete FlyGNe7gQ8;

	public string path;

	public AreaAttributes AreaAttributes;

	private IContainer mPfGD5QJ4m;

	private PictureBox ynfGcVwkKg;

	private Label RPtGJOaUCw;

	private Label yBxGuHJuAf;

	private ContextMenuStrip m2KGoyeZB7;

	private ToolStripMenuItem DGBGQ8vEmH;

	public bool Active
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return rVdG5aoH5e;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			rVdG5aoH5e = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AreaItemUI(AreaItemSelected areaItemSelected, AreaItemDelete areaItemDelete, string path)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		mVqGrYYJsr();
		this.path = path;
		D1WG6qBvcX = areaItemSelected;
		FlyGNe7gQ8 = areaItemDelete;
		ykhGY00jg8();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ykhGY00jg8()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = Path.Combine(path, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10076));
		if (File.Exists(text))
		{
			byte[] buffer = FileUtils.pURSg6Zk53A(text);
			Bitmap image;
			using (MemoryStream stream = new MemoryStream(buffer))
			{
				image = new Bitmap(stream);
			}
			ynfGcVwkKg.Image = image;
		}
		string text2 = Path.Combine(path, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10096));
		if (File.Exists(text2))
		{
			string json = File.ReadAllText(text2);
			AreaAttributes = JsonDataConversion.Deserialize<AreaAttributes>(json);
			if (AreaAttributes != null)
			{
				RPtGJOaUCw.Text = AreaAttributes.name;
				yBxGuHJuAf.Text = string.Format(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10116), AreaAttributes.width, AreaAttributes.height);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetActive(bool isActive)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		rVdG5aoH5e = isActive;
		Refresh();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void k3DG353geT(object P_0, PaintEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Pen pen = null;
		pen = ((!rVdG5aoH5e) ? new Pen(Color.Black) : new Pen(Color.Red));
		Graphics graphics = P_1.Graphics;
		graphics.DrawRectangle(pen, new Rectangle(0, 0, base.Width - 1, base.Height - 1));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void JfAG1uUsKi(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		D1WG6qBvcX(this);
		SetActive(isActive: true);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void THxGEf5eLd(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		FlyGNe7gQ8(this);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && mPfGD5QJ4m != null)
		{
			mPfGD5QJ4m.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void mVqGrYYJsr()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		mPfGD5QJ4m = new Container();
		ynfGcVwkKg = new PictureBox();
		RPtGJOaUCw = new Label();
		yBxGuHJuAf = new Label();
		m2KGoyeZB7 = new ContextMenuStrip(mPfGD5QJ4m);
		DGBGQ8vEmH = new ToolStripMenuItem();
		((ISupportInitialize)ynfGcVwkKg).BeginInit();
		m2KGoyeZB7.SuspendLayout();
		SuspendLayout();
		ynfGcVwkKg.BorderStyle = BorderStyle.FixedSingle;
		ynfGcVwkKg.ContextMenuStrip = m2KGoyeZB7;
		ynfGcVwkKg.Location = new Point(11, 3);
		ynfGcVwkKg.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10152);
		ynfGcVwkKg.Size = new Size(128, 128);
		ynfGcVwkKg.SizeMode = PictureBoxSizeMode.Zoom;
		ynfGcVwkKg.TabIndex = 2;
		ynfGcVwkKg.TabStop = false;
		ynfGcVwkKg.Click += JfAG1uUsKi;
		RPtGJOaUCw.ContextMenuStrip = m2KGoyeZB7;
		RPtGJOaUCw.Location = new Point(11, 133);
		RPtGJOaUCw.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10178);
		RPtGJOaUCw.Size = new Size(128, 18);
		RPtGJOaUCw.TabIndex = 3;
		RPtGJOaUCw.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10196);
		RPtGJOaUCw.TextAlign = ContentAlignment.MiddleCenter;
		RPtGJOaUCw.Click += JfAG1uUsKi;
		yBxGuHJuAf.ContextMenuStrip = m2KGoyeZB7;
		yBxGuHJuAf.Location = new Point(11, 150);
		yBxGuHJuAf.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10208);
		yBxGuHJuAf.Size = new Size(128, 18);
		yBxGuHJuAf.TabIndex = 4;
		yBxGuHJuAf.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10226);
		yBxGuHJuAf.TextAlign = ContentAlignment.MiddleCenter;
		yBxGuHJuAf.Click += JfAG1uUsKi;
		m2KGoyeZB7.Items.AddRange(new ToolStripItem[1] { DGBGQ8vEmH });
		m2KGoyeZB7.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10238);
		m2KGoyeZB7.Size = new Size(153, 48);
		DGBGQ8vEmH.Image = Resources.fmvS1uvOW2l();
		DGBGQ8vEmH.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10280);
		DGBGQ8vEmH.Size = new Size(152, 22);
		DGBGQ8vEmH.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10326);
		DGBGQ8vEmH.Click += THxGEf5eLd;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		ContextMenuStrip = m2KGoyeZB7;
		base.Controls.Add(yBxGuHJuAf);
		base.Controls.Add(ynfGcVwkKg);
		base.Controls.Add(RPtGJOaUCw);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10342);
		base.Size = new Size(150, 170);
		base.Click += JfAG1uUsKi;
		base.Paint += k3DG353geT;
		((ISupportInitialize)ynfGcVwkKg).EndInit();
		m2KGoyeZB7.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
	}
}
