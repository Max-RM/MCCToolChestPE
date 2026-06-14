using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.controls;
using MCCToolChest.MCSBCode.Workers;
using MCCToolChest.Properties;
using MCCToolChest.utils;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.forms;

public class MapManager : Form
{
	private ImageUtils XAldY9JM5g;

	private List<string> dOkd3SFuZV;

	private Bitmap DJEd1QT9B8;

	private byte[] jMZdEl9K6b;

	private Bitmap C6fdrmNXAB;

	private TagNodeCompound Oekd5TNfkd;

	private IContainer iGZd6rYy2t;

	private PictureBox RwidNWY8mD;

	private MenuStrip DcEdDkrmpG;

	private ToolStripMenuItem wkRdcuFArh;

	private Button fN9dJy0MqH;

	private Button T5IduAUqh0;

	private ToolStripMenuItem ahMdoprkAR;

	private PictureBox YiRdQtgNLS;

	private PictureBoxWithInterpolationMode jKedO7exm9;

	private CheckBox DyAdCid0us;

	private CheckBox yN4d7IfbxY;

	private CheckBox jNTdABfV2q;

	private Label YKnddb7A5E;

	private Label I8AdH5ApWE;

	public TagNodeCompound Map
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return Oekd5TNfkd;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			Oekd5TNfkd = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MapManager(TagNodeCompound mapNode)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		XAldY9JM5g = new ImageUtils();
		dOkd3SFuZV = new List<string>
		{
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12722),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22148),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22160),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22172)
		};
		z22dkPJMnV();
		LV7d0iZ25I(mapNode);
		Map = mapNode;
		YiRdQtgNLS.Image = C6fdrmNXAB;
		RwidNWY8mD.Image = C6fdrmNXAB;
		AllowDrop = true;
		base.DragEnter += b3Zd2tZRYY;
		base.DragDrop += QUWdy93LlQ;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void b3Zd2tZRYY(object P_0, DragEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_1.Data.GetDataPresent(DataFormats.FileDrop))
		{
			P_1.Effect = DragDropEffects.Copy;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void QUWdy93LlQ(object P_0, DragEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string[] array = (string[])P_1.Data.GetData(DataFormats.FileDrop);
		if (array.Length > 0)
		{
			string text = array[0];
			string extension = Path.GetExtension(text);
			if (dOkd3SFuZV.Contains(extension.ToLower()))
			{
				mxydaelYn3(text);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LV7d0iZ25I(TagNodeCompound P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MapConverterWorker mapConverterWorker = new MapConverterWorker();
		C6fdrmNXAB = mapConverterWorker.ToImage(P_0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void IbKdBo1qoD(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22324);
		string text2 = FileUtils.BugSgNoWh4E(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22518), text, null, null);
		if (!string.IsNullOrWhiteSpace(text2))
		{
			mxydaelYn3(text2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Dr7dt4a3Yk(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55730);
		string text2 = FileUtils.VXKSgcyptXi(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22518), text, null, null);
		if (!string.IsNullOrWhiteSpace(text2))
		{
			try
			{
				MapConverterWorker mapConverterWorker = new MapConverterWorker();
				mapConverterWorker.SaveImage(Oekd5TNfkd, text2);
			}
			catch (Exception ex)
			{
				MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55812) + Environment.NewLine + ex.Message, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55870));
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void mxydaelYn3(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!string.IsNullOrWhiteSpace(P_0))
		{
			DJEd1QT9B8 = new Bitmap(P_0);
			if (DJEd1QT9B8.Width <= 128 && DJEd1QT9B8.Height <= 128)
			{
				jKedO7exm9.Image = DJEd1QT9B8;
			}
			else
			{
				jKedO7exm9.Image = XAldY9JM5g.ResizeWithPerspective(DJEd1QT9B8, jNTdABfV2q.Checked);
			}
			bool flag = DJEd1QT9B8.Width != DJEd1QT9B8.Height;
			DyAdCid0us.Checked = flag;
			DyAdCid0us.Enabled = flag;
			bool flag2 = DJEd1QT9B8.Width <= 128 && DJEd1QT9B8.Height <= 128;
			yN4d7IfbxY.Checked = flag2;
			yN4d7IfbxY.Enabled = flag2;
			jNTdABfV2q.Enabled = true;
			dKvdX3R9C3();
			EuadxlFLqK();
			YKnddb7A5E.Text = DJEd1QT9B8.Width + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22184) + DJEd1QT9B8.Height + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22192);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void dKvdX3R9C3()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (DJEd1QT9B8 == null)
		{
			return;
		}
		if (yN4d7IfbxY.Checked && DJEd1QT9B8.Width <= 128 && DJEd1QT9B8.Height <= 128)
		{
			C6fdrmNXAB = XAldY9JM5g.CopySmallerImage(DJEd1QT9B8);
			return;
		}
		if (DyAdCid0us.Checked)
		{
			C6fdrmNXAB = XAldY9JM5g.ResizeWithPerspective(DJEd1QT9B8, jNTdABfV2q.Checked);
		}
		else if (jNTdABfV2q.Checked)
		{
			C6fdrmNXAB = XAldY9JM5g.EnlargeImage(DJEd1QT9B8, 128, 128);
		}
		else
		{
			C6fdrmNXAB = YVyderyksD(DJEd1QT9B8);
		}
		if (C6fdrmNXAB.Width < 128 || C6fdrmNXAB.Height < 128)
		{
			C6fdrmNXAB = XAldY9JM5g.CopySmallerImage(C6fdrmNXAB);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EuadxlFLqK()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MapConverterWorker mapConverterWorker = new MapConverterWorker();
		mapConverterWorker.FromImage(Oekd5TNfkd, C6fdrmNXAB);
		RwidNWY8mD.Image = C6fdrmNXAB;
		YiRdQtgNLS.Image = C6fdrmNXAB;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool ThumbnailCallback()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Bitmap YVyderyksD(Bitmap P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Image.GetThumbnailImageAbort callback = ThumbnailCallback;
		Image thumbnailImage = P_0.GetThumbnailImage(128, 128, callback, default(IntPtr));
		return (Bitmap)thumbnailImage;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void XeCdMk4LKp(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void boSdUW1QAu(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.DialogResult = DialogResult.OK;
		Close();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void rQldL7v1FH(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.Icon = Resources.usMSrbJo37S();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void NRHdgHEa9m(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		dKvdX3R9C3();
		EuadxlFLqK();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void nfxdPsLYV1(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		dKvdX3R9C3();
		EuadxlFLqK();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void P16dR3dP5Z(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		dKvdX3R9C3();
		EuadxlFLqK();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && iGZd6rYy2t != null)
		{
			iGZd6rYy2t.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void z22dkPJMnV()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		RwidNWY8mD = new PictureBox();
		DcEdDkrmpG = new MenuStrip();
		wkRdcuFArh = new ToolStripMenuItem();
		ahMdoprkAR = new ToolStripMenuItem();
		fN9dJy0MqH = new Button();
		T5IduAUqh0 = new Button();
		YiRdQtgNLS = new PictureBox();
		DyAdCid0us = new CheckBox();
		yN4d7IfbxY = new CheckBox();
		jNTdABfV2q = new CheckBox();
		YKnddb7A5E = new Label();
		I8AdH5ApWE = new Label();
		jKedO7exm9 = new PictureBoxWithInterpolationMode();
		((ISupportInitialize)RwidNWY8mD).BeginInit();
		DcEdDkrmpG.SuspendLayout();
		((ISupportInitialize)YiRdQtgNLS).BeginInit();
		((ISupportInitialize)jKedO7exm9).BeginInit();
		SuspendLayout();
		RwidNWY8mD.Anchor = AnchorStyles.Bottom;
		RwidNWY8mD.BackgroundImageLayout = ImageLayout.None;
		RwidNWY8mD.BorderStyle = BorderStyle.FixedSingle;
		RwidNWY8mD.Location = new Point(16, 199);
		RwidNWY8mD.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(59910);
		RwidNWY8mD.Size = new Size(384, 384);
		RwidNWY8mD.SizeMode = PictureBoxSizeMode.Zoom;
		RwidNWY8mD.TabIndex = 0;
		RwidNWY8mD.TabStop = false;
		DcEdDkrmpG.Items.AddRange(new ToolStripItem[2] { wkRdcuFArh, ahMdoprkAR });
		DcEdDkrmpG.Location = new Point(0, 0);
		DcEdDkrmpG.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26656);
		DcEdDkrmpG.Size = new Size(414, 24);
		DcEdDkrmpG.TabIndex = 1;
		DcEdDkrmpG.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26656);
		wkRdcuFArh.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(59944);
		wkRdcuFArh.Size = new Size(96, 20);
		wkRdcuFArh.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(59972);
		wkRdcuFArh.Click += IbKdBo1qoD;
		ahMdoprkAR.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60000);
		ahMdoprkAR.Size = new Size(88, 20);
		ahMdoprkAR.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60032);
		ahMdoprkAR.Click += Dr7dt4a3Yk;
		fN9dJy0MqH.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		fN9dJy0MqH.Location = new Point(241, 589);
		fN9dJy0MqH.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34632);
		fN9dJy0MqH.Size = new Size(75, 23);
		fN9dJy0MqH.TabIndex = 5;
		fN9dJy0MqH.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34646);
		fN9dJy0MqH.UseVisualStyleBackColor = true;
		fN9dJy0MqH.Click += boSdUW1QAu;
		T5IduAUqh0.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		T5IduAUqh0.DialogResult = DialogResult.Cancel;
		T5IduAUqh0.Location = new Point(325, 589);
		T5IduAUqh0.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34610);
		T5IduAUqh0.Size = new Size(75, 23);
		T5IduAUqh0.TabIndex = 4;
		T5IduAUqh0.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20198);
		T5IduAUqh0.UseVisualStyleBackColor = true;
		T5IduAUqh0.Click += XeCdMk4LKp;
		YiRdQtgNLS.BorderStyle = BorderStyle.FixedSingle;
		YiRdQtgNLS.Location = new Point(272, 43);
		YiRdQtgNLS.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60060);
		YiRdQtgNLS.Size = new Size(128, 128);
		YiRdQtgNLS.SizeMode = PictureBoxSizeMode.CenterImage;
		YiRdQtgNLS.TabIndex = 6;
		YiRdQtgNLS.TabStop = false;
		DyAdCid0us.AutoSize = true;
		DyAdCid0us.Checked = true;
		DyAdCid0us.CheckState = CheckState.Checked;
		DyAdCid0us.Location = new Point(158, 43);
		DyAdCid0us.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23276);
		DyAdCid0us.Size = new Size(113, 17);
		DyAdCid0us.TabIndex = 8;
		DyAdCid0us.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23318);
		DyAdCid0us.UseVisualStyleBackColor = true;
		DyAdCid0us.CheckedChanged += NRHdgHEa9m;
		yN4d7IfbxY.AutoSize = true;
		yN4d7IfbxY.Checked = true;
		yN4d7IfbxY.CheckState = CheckState.Checked;
		yN4d7IfbxY.Location = new Point(158, 66);
		yN4d7IfbxY.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60094);
		yN4d7IfbxY.Size = new Size(77, 17);
		yN4d7IfbxY.TabIndex = 9;
		yN4d7IfbxY.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60122);
		yN4d7IfbxY.UseVisualStyleBackColor = true;
		yN4d7IfbxY.CheckedChanged += nfxdPsLYV1;
		jNTdABfV2q.AutoSize = true;
		jNTdABfV2q.Checked = true;
		jNTdABfV2q.CheckState = CheckState.Checked;
		jNTdABfV2q.Location = new Point(158, 89);
		jNTdABfV2q.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23220);
		jNTdABfV2q.Size = new Size(76, 17);
		jNTdABfV2q.TabIndex = 10;
		jNTdABfV2q.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23250);
		jNTdABfV2q.UseVisualStyleBackColor = true;
		jNTdABfV2q.CheckedChanged += P16dR3dP5Z;
		YKnddb7A5E.Location = new Point(13, 174);
		YKnddb7A5E.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23192);
		YKnddb7A5E.Size = new Size(131, 12);
		YKnddb7A5E.TabIndex = 11;
		YKnddb7A5E.TextAlign = ContentAlignment.TopCenter;
		I8AdH5ApWE.Location = new Point(269, 174);
		I8AdH5ApWE.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10582);
		I8AdH5ApWE.Size = new Size(131, 12);
		I8AdH5ApWE.TabIndex = 12;
		I8AdH5ApWE.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60146);
		I8AdH5ApWE.TextAlign = ContentAlignment.TopCenter;
		jKedO7exm9.BorderStyle = BorderStyle.FixedSingle;
		jKedO7exm9.InterpolationMode = InterpolationMode.Default;
		jKedO7exm9.Location = new Point(16, 43);
		jKedO7exm9.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23356);
		jKedO7exm9.Size = new Size(128, 128);
		jKedO7exm9.SizeMode = PictureBoxSizeMode.CenterImage;
		jKedO7exm9.TabIndex = 7;
		jKedO7exm9.TabStop = false;
		base.AcceptButton = fN9dJy0MqH;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = T5IduAUqh0;
		base.ClientSize = new Size(414, 619);
		base.Controls.Add(I8AdH5ApWE);
		base.Controls.Add(YKnddb7A5E);
		base.Controls.Add(jNTdABfV2q);
		base.Controls.Add(yN4d7IfbxY);
		base.Controls.Add(DyAdCid0us);
		base.Controls.Add(jKedO7exm9);
		base.Controls.Add(YiRdQtgNLS);
		base.Controls.Add(fN9dJy0MqH);
		base.Controls.Add(T5IduAUqh0);
		base.Controls.Add(RwidNWY8mD);
		base.Controls.Add(DcEdDkrmpG);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.MainMenuStrip = DcEdDkrmpG;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60168);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60192);
		base.Load += rQldL7v1FH;
		((ISupportInitialize)RwidNWY8mD).EndInit();
		DcEdDkrmpG.ResumeLayout(performLayout: false);
		DcEdDkrmpG.PerformLayout();
		((ISupportInitialize)YiRdQtgNLS).EndInit();
		((ISupportInitialize)jKedO7exm9).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
