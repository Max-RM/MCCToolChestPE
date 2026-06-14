using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.Properties;
using uL2B6CXB2hZQU16Di7r;
using W7XEw1ukTn4yRrm2wV4;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.forms;

public class ErrorLogViewer : Form
{
	private IContainer aEsuj7qqHu;

	private Button y37u83on8K;

	private TextBox Jm6u95ZmgZ;

	private SplitContainer kI4uIma7Q3;

	private ListView rZWuzWiZ3p;

	private ColumnHeader mTvoTrePBM;

	private ColumnHeader NwCoS8FIUG;

	private Button PgMoGuktdZ;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ErrorLogViewer()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		l7huFOBYIq();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DehuOCXdNH(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.Icon = Resources.kgpS1U6jIS0();
		OFguCfA7bD();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OFguCfA7bD()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		try
		{
			Jiwu7YeAV7();
			Jm6u95ZmgZ.Text = VrfLq3utcbtaHoMfeNR.LHaSYxBsxpu();
		}
		catch (Exception)
		{
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Jiwu7YeAV7()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		rZWuzWiZ3p.Items.Clear();
		FileInfo[] array = VrfLq3utcbtaHoMfeNR.wjCSYLAx65I();
		FileInfo[] array2 = array;
		foreach (FileInfo fileInfo in array2)
		{
			ListViewItem listViewItem = new ListViewItem(Path.GetFileName(fileInfo.FullName));
			listViewItem.SubItems.Add(fileInfo.LastWriteTime.ToShortDateString());
			listViewItem.Tag = fileInfo;
			rZWuzWiZ3p.Items.Add(listViewItem);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Fo8uAmDZY7(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		VrfLq3utcbtaHoMfeNR.lSHSYUfALyv();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void A9qudWEqYD(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (rZWuzWiZ3p.SelectedItems.Count > 0)
		{
			if (rZWuzWiZ3p.SelectedItems[0].Tag is FileInfo fileInfo)
			{
				VrfLq3utcbtaHoMfeNR.Id = Path.GetFileNameWithoutExtension(fileInfo.FullName);
				Jm6u95ZmgZ.Text = VrfLq3utcbtaHoMfeNR.LHaSYxBsxpu();
			}
			else
			{
				Jm6u95ZmgZ.Text = "";
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void rnDuHxooUl(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		VrfLq3utcbtaHoMfeNR.n42SYgNaeyv();
		Jiwu7YeAV7();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && aEsuj7qqHu != null)
		{
			aEsuj7qqHu.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void l7huFOBYIq()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		y37u83on8K = new Button();
		Jm6u95ZmgZ = new TextBox();
		kI4uIma7Q3 = new SplitContainer();
		rZWuzWiZ3p = new ListView();
		mTvoTrePBM = new ColumnHeader();
		NwCoS8FIUG = new ColumnHeader();
		PgMoGuktdZ = new Button();
		((ISupportInitialize)kI4uIma7Q3).BeginInit();
		kI4uIma7Q3.Panel1.SuspendLayout();
		kI4uIma7Q3.Panel2.SuspendLayout();
		kI4uIma7Q3.SuspendLayout();
		SuspendLayout();
		y37u83on8K.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		y37u83on8K.Location = new Point(617, 537);
		y37u83on8K.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(54208);
		y37u83on8K.Size = new Size(118, 23);
		y37u83on8K.TabIndex = 2;
		y37u83on8K.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(54226);
		y37u83on8K.UseVisualStyleBackColor = true;
		y37u83on8K.Click += Fo8uAmDZY7;
		Jm6u95ZmgZ.Dock = DockStyle.Fill;
		Jm6u95ZmgZ.Location = new Point(0, 0);
		Jm6u95ZmgZ.Multiline = true;
		Jm6u95ZmgZ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(54258);
		Jm6u95ZmgZ.ReadOnly = true;
		Jm6u95ZmgZ.Size = new Size(467, 519);
		Jm6u95ZmgZ.TabIndex = 3;
		kI4uIma7Q3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		kI4uIma7Q3.Location = new Point(12, 12);
		kI4uIma7Q3.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13750);
		kI4uIma7Q3.Panel1.Controls.Add(rZWuzWiZ3p);
		kI4uIma7Q3.Panel2.Controls.Add(Jm6u95ZmgZ);
		kI4uIma7Q3.Size = new Size(723, 519);
		kI4uIma7Q3.SplitterDistance = 252;
		kI4uIma7Q3.TabIndex = 4;
		rZWuzWiZ3p.Columns.AddRange(new ColumnHeader[2] { mTvoTrePBM, NwCoS8FIUG });
		rZWuzWiZ3p.Dock = DockStyle.Fill;
		rZWuzWiZ3p.FullRowSelect = true;
		rZWuzWiZ3p.Location = new Point(0, 0);
		rZWuzWiZ3p.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(54278);
		rZWuzWiZ3p.Size = new Size(252, 519);
		rZWuzWiZ3p.TabIndex = 0;
		rZWuzWiZ3p.UseCompatibleStateImageBehavior = false;
		rZWuzWiZ3p.View = View.Details;
		rZWuzWiZ3p.SelectedIndexChanged += A9qudWEqYD;
		mTvoTrePBM.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(54310);
		mTvoTrePBM.Width = 150;
		NwCoS8FIUG.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(54328);
		NwCoS8FIUG.Width = 80;
		PgMoGuktdZ.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		PgMoGuktdZ.Location = new Point(11, 537);
		PgMoGuktdZ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(54340);
		PgMoGuktdZ.Size = new Size(88, 23);
		PgMoGuktdZ.TabIndex = 5;
		PgMoGuktdZ.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(54368);
		PgMoGuktdZ.UseVisualStyleBackColor = true;
		PgMoGuktdZ.Click += rnDuHxooUl;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(741, 564);
		base.Controls.Add(PgMoGuktdZ);
		base.Controls.Add(kI4uIma7Q3);
		base.Controls.Add(y37u83on8K);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(54392);
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(54424);
		base.Load += DehuOCXdNH;
		kI4uIma7Q3.Panel1.ResumeLayout(performLayout: false);
		kI4uIma7Q3.Panel2.ResumeLayout(performLayout: false);
		kI4uIma7Q3.Panel2.PerformLayout();
		((ISupportInitialize)kI4uIma7Q3).EndInit();
		kI4uIma7Q3.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
	}
}
