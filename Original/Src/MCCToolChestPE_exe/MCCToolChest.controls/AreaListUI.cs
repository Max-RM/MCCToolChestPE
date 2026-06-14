using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using MCCToolChest.events;
using MCCToolChest.Properties;
using MCCToolChest.utils;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls;

public class AreaListUI : UserControl
{
	private int WPcbT8yMOT;

	private bool TIqbSEqDMZ;

	private bool wfGbGefk4v;

	private int Nshbb882r7;

	private AreaItemUI m2FbvUClfu;

	private EventHandler lXubw7uq7r;

	private IContainer diNb4Bumkt;

	private FlowLayoutPanel Qe1bVm3k38;

	private Panel e0WbWqtuNj;

	private Button i3JbpXkrqd;

	private Label e3cbZmtMA6;

	private Label Bl2bfJV617;

	private Button yVrbiSb3Ma;

	private Label Ln3bsE0bJt;

	private Button SkJbq87xNV;

	private Button yRCbKpf48K;

	private Label YdabhPxM5w;

	private NumericUpDown wwebmwMk7K;

	public int Rotation
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return WPcbT8yMOT;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			WPcbT8yMOT = value;
		}
	}

	public bool FlipTopToBottom
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return TIqbSEqDMZ;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			TIqbSEqDMZ = value;
		}
	}

	public bool FlipLeftToRight
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return wfGbGefk4v;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			wfGbGefk4v = value;
		}
	}

	public int YOffset
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return Nshbb882r7;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			Nshbb882r7 = value;
		}
	}

	public event EventHandler AreaItemActive
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = lXubw7uq7r;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref lXubw7uq7r, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		remove
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = lXubw7uq7r;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref lXubw7uq7r, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AreaListUI()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		H1ZGzIfPVf();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void LoadList()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Qe1bVm3k38.Controls.Clear();
		string[] directories = Directory.GetDirectories(Utils.AreaLibraryPath(), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10366), SearchOption.TopDirectoryOnly);
		string[] array = directories;
		foreach (string path in array)
		{
			AddAreaItemn(path);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddAreaItemn(string path)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		AreaItemUI areaItemUI = new AreaItemUI(E9EGO9yy6c, XxuGCCBtv2, path);
		areaItemUI.Tag = path;
		if (areaItemUI.AreaAttributes != null)
		{
			Qe1bVm3k38.Controls.Add(areaItemUI);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void E9EGO9yy6c(AreaItemUI P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0 != null)
		{
			if (m2FbvUClfu != null)
			{
				m2FbvUClfu.SetActive(isActive: false);
			}
			m2FbvUClfu = P_0;
			OnAreaActive(this, new AreaActiveEventArgs(P_0.AreaAttributes, P_0.Tag as string));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void XxuGCCBtv2(AreaItemUI P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		for (int i = 0; i < Qe1bVm3k38.Controls.Count; i++)
		{
			if (Qe1bVm3k38.Controls[i] == P_0)
			{
				AreaItemUI areaItemUI = Qe1bVm3k38.Controls[i] as AreaItemUI;
				if (m2FbvUClfu == areaItemUI)
				{
					m2FbvUClfu = null;
				}
				Qe1bVm3k38.Controls.Remove(areaItemUI);
				try
				{
					FileUtils.DeleteDirectory(areaItemUI.path);
					break;
				}
				catch (Exception)
				{
					break;
				}
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnAreaActive(object sender, AreaActiveEventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		lXubw7uq7r?.Invoke(this, e);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal AreaItemUI D21G7RedUP()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return m2FbvUClfu;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void LQwGAg1RKq()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (m2FbvUClfu != null)
		{
			m2FbvUClfu.SetActive(isActive: false);
			m2FbvUClfu = null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void pWBGdTbkA3(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		WPcbT8yMOT -= 90;
		if (WPcbT8yMOT < -270)
		{
			WPcbT8yMOT = 0;
		}
		I7RGFRqITd(WPcbT8yMOT);
		if (m2FbvUClfu != null)
		{
			OnAreaActive(this, new AreaActiveEventArgs(m2FbvUClfu.AreaAttributes, m2FbvUClfu.Tag as string));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void VbDGH24ADM(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		WPcbT8yMOT += 90;
		if (WPcbT8yMOT > 270)
		{
			WPcbT8yMOT = 0;
		}
		I7RGFRqITd(WPcbT8yMOT);
		if (m2FbvUClfu != null)
		{
			OnAreaActive(this, new AreaActiveEventArgs(m2FbvUClfu.AreaAttributes, m2FbvUClfu.Tag as string));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void I7RGFRqITd(int P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		e3cbZmtMA6.Text = P_0.ToString();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void lhrGjAs3y4(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TIqbSEqDMZ = !TIqbSEqDMZ;
		xWjG9kxVZq(yRCbKpf48K, TIqbSEqDMZ);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void tiiG8qUbOc(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		wfGbGefk4v = !wfGbGefk4v;
		xWjG9kxVZq(SkJbq87xNV, wfGbGefk4v);
		if (m2FbvUClfu != null)
		{
			OnAreaActive(this, new AreaActiveEventArgs(m2FbvUClfu.AreaAttributes, m2FbvUClfu.Tag as string));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void xWjG9kxVZq(Button P_0, bool P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Color color = Color.FromArgb(120, 0, 255, 0);
		Color color2 = Color.FromArgb(120, 224, 224, 224);
		P_0.BackColor = (P_1 ? color : color2);
		if (m2FbvUClfu != null)
		{
			OnAreaActive(this, new AreaActiveEventArgs(m2FbvUClfu.AreaAttributes, m2FbvUClfu.Tag as string));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void qejGI5QAVI(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Nshbb882r7 = (int)wwebmwMk7K.Value;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && diNb4Bumkt != null)
		{
			diNb4Bumkt.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void H1ZGzIfPVf()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Qe1bVm3k38 = new FlowLayoutPanel();
		e0WbWqtuNj = new Panel();
		wwebmwMk7K = new NumericUpDown();
		YdabhPxM5w = new Label();
		SkJbq87xNV = new Button();
		yRCbKpf48K = new Button();
		Ln3bsE0bJt = new Label();
		yVrbiSb3Ma = new Button();
		i3JbpXkrqd = new Button();
		e3cbZmtMA6 = new Label();
		Bl2bfJV617 = new Label();
		e0WbWqtuNj.SuspendLayout();
		((ISupportInitialize)wwebmwMk7K).BeginInit();
		SuspendLayout();
		Qe1bVm3k38.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Qe1bVm3k38.AutoScroll = true;
		Qe1bVm3k38.BorderStyle = BorderStyle.FixedSingle;
		Qe1bVm3k38.Location = new Point(0, 0);
		Qe1bVm3k38.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10372);
		Qe1bVm3k38.Size = new Size(414, 288);
		Qe1bVm3k38.TabIndex = 0;
		e0WbWqtuNj.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		e0WbWqtuNj.BackColor = Color.FromArgb(224, 224, 224);
		e0WbWqtuNj.Controls.Add(wwebmwMk7K);
		e0WbWqtuNj.Controls.Add(YdabhPxM5w);
		e0WbWqtuNj.Controls.Add(SkJbq87xNV);
		e0WbWqtuNj.Controls.Add(yRCbKpf48K);
		e0WbWqtuNj.Controls.Add(Ln3bsE0bJt);
		e0WbWqtuNj.Controls.Add(yVrbiSb3Ma);
		e0WbWqtuNj.Controls.Add(i3JbpXkrqd);
		e0WbWqtuNj.Controls.Add(e3cbZmtMA6);
		e0WbWqtuNj.Controls.Add(Bl2bfJV617);
		e0WbWqtuNj.Location = new Point(0, 288);
		e0WbWqtuNj.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10398);
		e0WbWqtuNj.Size = new Size(414, 69);
		e0WbWqtuNj.TabIndex = 1;
		wwebmwMk7K.Location = new Point(53, 42);
		wwebmwMk7K.Maximum = new decimal(new int[4] { 255, 0, 0, 0 });
		wwebmwMk7K.Minimum = new decimal(new int[4] { 255, 0, 0, -2147483648 });
		wwebmwMk7K.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10414);
		wwebmwMk7K.Size = new Size(43, 20);
		wwebmwMk7K.TabIndex = 9;
		wwebmwMk7K.TextAlign = HorizontalAlignment.Right;
		wwebmwMk7K.ValueChanged += qejGI5QAVI;
		YdabhPxM5w.AutoSize = true;
		YdabhPxM5w.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		YdabhPxM5w.Location = new Point(3, 43);
		YdabhPxM5w.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10482);
		YdabhPxM5w.Size = new Size(48, 15);
		YdabhPxM5w.TabIndex = 7;
		YdabhPxM5w.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10498);
		SkJbq87xNV.BackgroundImage = Resources.IunS1VD7x9q();
		SkJbq87xNV.BackgroundImageLayout = ImageLayout.Zoom;
		SkJbq87xNV.Location = new Point(197, 5);
		SkJbq87xNV.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10518);
		SkJbq87xNV.Size = new Size(26, 26);
		SkJbq87xNV.TabIndex = 6;
		SkJbq87xNV.UseVisualStyleBackColor = true;
		SkJbq87xNV.Click += tiiG8qUbOc;
		yRCbKpf48K.BackgroundImage = Resources.GlqS1pimZDs();
		yRCbKpf48K.BackgroundImageLayout = ImageLayout.Zoom;
		yRCbKpf48K.Location = new Point(171, 5);
		yRCbKpf48K.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10550);
		yRCbKpf48K.Size = new Size(26, 26);
		yRCbKpf48K.TabIndex = 5;
		yRCbKpf48K.UseVisualStyleBackColor = true;
		yRCbKpf48K.Click += lhrGjAs3y4;
		Ln3bsE0bJt.AutoSize = true;
		Ln3bsE0bJt.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		Ln3bsE0bJt.Location = new Point(144, 9);
		Ln3bsE0bJt.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10582);
		Ln3bsE0bJt.Size = new Size(27, 15);
		Ln3bsE0bJt.TabIndex = 4;
		Ln3bsE0bJt.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10598);
		yVrbiSb3Ma.BackgroundImage = Resources.kcGSECTZj8j();
		yVrbiSb3Ma.BackgroundImageLayout = ImageLayout.Zoom;
		yVrbiSb3Ma.Location = new Point(106, 5);
		yVrbiSb3Ma.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10610);
		yVrbiSb3Ma.Size = new Size(26, 26);
		yVrbiSb3Ma.TabIndex = 3;
		yVrbiSb3Ma.UseVisualStyleBackColor = true;
		yVrbiSb3Ma.Click += VbDGH24ADM;
		i3JbpXkrqd.BackgroundImage = Resources.Yt5SEQGSjFO();
		i3JbpXkrqd.BackgroundImageLayout = ImageLayout.Zoom;
		i3JbpXkrqd.Location = new Point(44, 5);
		i3JbpXkrqd.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10642);
		i3JbpXkrqd.Size = new Size(26, 26);
		i3JbpXkrqd.TabIndex = 2;
		i3JbpXkrqd.UseVisualStyleBackColor = true;
		i3JbpXkrqd.Click += pWBGdTbkA3;
		e3cbZmtMA6.BackColor = Color.White;
		e3cbZmtMA6.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		e3cbZmtMA6.Location = new Point(67, 8);
		e3cbZmtMA6.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10672);
		e3cbZmtMA6.Padding = new Padding(3, 2, 0, 0);
		e3cbZmtMA6.Size = new Size(40, 20);
		e3cbZmtMA6.TabIndex = 1;
		e3cbZmtMA6.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10708);
		Bl2bfJV617.AutoSize = true;
		Bl2bfJV617.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		Bl2bfJV617.Location = new Point(2, 9);
		Bl2bfJV617.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		Bl2bfJV617.Size = new Size(43, 15);
		Bl2bfJV617.TabIndex = 0;
		Bl2bfJV617.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10730);
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = SystemColors.Control;
		base.Controls.Add(e0WbWqtuNj);
		base.Controls.Add(Qe1bVm3k38);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10746);
		base.Size = new Size(414, 356);
		e0WbWqtuNj.ResumeLayout(performLayout: false);
		e0WbWqtuNj.PerformLayout();
		((ISupportInitialize)wwebmwMk7K).EndInit();
		ResumeLayout(performLayout: false);
	}
}
