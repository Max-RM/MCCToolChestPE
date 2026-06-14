using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.events;
using MCCToolChest.MCSBCode.Workers;
using MCCToolChest.model;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls;

public class MapItem : UserControl
{
	private bool GwDBZofBAo;

	private byte[] wvrBfA6CVY;

	private Bitmap BAiBiqu5Ol;

	private TagNodeCompound WadBs8uH7X;

	private MCMap W5hBqgs04B;

	private MapItemSelected CHvBKMl7D4;

	private IContainer hNLBhaYNYh;

	private PictureBox Cr8BmbkT5U;

	private Label TMUBnYVi1l;

	public MCMap MapData
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return W5hBqgs04B;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			W5hBqgs04B = value;
		}
	}

	public byte[] Colors
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return wvrBfA6CVY;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			wvrBfA6CVY = value;
		}
	}

	public Bitmap MapImage
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return BAiBiqu5Ol;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			BAiBiqu5Ol = value;
		}
	}

	public TagNodeCompound Map
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return WadBs8uH7X;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			WadBs8uH7X = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MapItem(MCMap mcmap, MapItemSelected mapItemSelected)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		fHLBpk7mAi();
		base.BorderStyle = BorderStyle.None;
		WadBs8uH7X = mcmap.Map;
		W5hBqgs04B = mcmap;
		CHvBKMl7D4 = mapItemSelected;
		LoadMapFile(mcmap.Name, mcmap.Map);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void LoadMapFile(string name, TagNodeCompound map)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MapConverterWorker mapConverterWorker = new MapConverterWorker();
		BAiBiqu5Ol = mapConverterWorker.ToImage(map);
		Cr8BmbkT5U.Image = BAiBiqu5Ol;
		TMUBnYVi1l.Text = name;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void LoadMapFile(string name)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MapConverterII mapConverterII = new MapConverterII();
		BAiBiqu5Ol = mapConverterII.MapToBitmap(WadBs8uH7X);
		Cr8BmbkT5U.Image = BAiBiqu5Ol;
		TMUBnYVi1l.Text = name;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void E1WBwyFbNs(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		CHvBKMl7D4(this);
		SetActive(isActive: true);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hBNB4TNMGy(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		CHvBKMl7D4(this);
		SetActive(isActive: true);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void werBV1bntq(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		CHvBKMl7D4(this);
		SetActive(isActive: true);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetActive(bool isActive)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		GwDBZofBAo = isActive;
		Refresh();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RjYBW9OL4B(object P_0, PaintEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Pen pen = null;
		pen = ((!GwDBZofBAo) ? new Pen(Color.Black) : new Pen(Color.Red));
		Graphics graphics = P_1.Graphics;
		graphics.DrawRectangle(pen, new Rectangle(0, 0, base.Width - 1, base.Height - 1));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && hNLBhaYNYh != null)
		{
			hNLBhaYNYh.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void fHLBpk7mAi()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Cr8BmbkT5U = new PictureBox();
		TMUBnYVi1l = new Label();
		((ISupportInitialize)Cr8BmbkT5U).BeginInit();
		SuspendLayout();
		Cr8BmbkT5U.BorderStyle = BorderStyle.FixedSingle;
		Cr8BmbkT5U.Location = new Point(4, 4);
		Cr8BmbkT5U.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10152);
		Cr8BmbkT5U.Size = new Size(128, 128);
		Cr8BmbkT5U.TabIndex = 0;
		Cr8BmbkT5U.TabStop = false;
		Cr8BmbkT5U.Click += hBNB4TNMGy;
		TMUBnYVi1l.Location = new Point(4, 131);
		TMUBnYVi1l.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10178);
		TMUBnYVi1l.Size = new Size(128, 18);
		TMUBnYVi1l.TabIndex = 1;
		TMUBnYVi1l.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10196);
		TMUBnYVi1l.TextAlign = ContentAlignment.MiddleCenter;
		TMUBnYVi1l.Click += werBV1bntq;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(Cr8BmbkT5U);
		base.Controls.Add(TMUBnYVi1l);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23582);
		base.Size = new Size(136, 156);
		base.Click += E1WBwyFbNs;
		base.Paint += RjYBW9OL4B;
		((ISupportInitialize)Cr8BmbkT5U).EndInit();
		ResumeLayout(performLayout: false);
	}
}
