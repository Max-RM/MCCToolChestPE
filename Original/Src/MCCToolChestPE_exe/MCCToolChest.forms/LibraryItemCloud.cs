using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.controls;
using MCCToolChest.Properties;
using MCCToolChest.workers;
using MCCToolChestDB.Model;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.forms;

public class LibraryItemCloud : Form
{
	private Timer QGgoJwXD7m;

	private string h2souXgq2x;

	private string bmaooKNajm;

	private NBTLibraryItem EpNoQrL5B0;

	private List<NBTLibraryItem> vY0oOIyVEn;

	private Dictionary<Guid, CloudLibraryItem> HSMoCskgSM;

	private IContainer DbMo7sKhs0;

	private FlowLayoutPanel oZ1oAeFDR6;

	private Panel MyuodWNbDO;

	private Label qVAoHaU00M;

	private TextBox xvVoFK9awe;

	private Label L3bojyoydO;

	private TextBox Vaeo8AWdHp;

	private BackgroundWorker rwbo9oRy1k;

	private ComboBox jr1oIKWlco;

	private Label ACtoz54kXG;

	public NBTLibraryItem LibraryItem
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return EpNoQrL5B0;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EpNoQrL5B0 = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LibraryItemCloud()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		h2souXgq2x = string.Empty;
		bmaooKNajm = string.Empty;
		sKUocq8QN5();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void WtWoMVZnhD(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.Icon = Resources.usMSrbJo37S();
		SortedDictionary<string, string> sortedDictionary = new SortedDictionary<string, string>();
		sortedDictionary.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15852), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(54946));
		SortedDictionary<string, string> dataSource = sortedDictionary;
		jr1oIKWlco.DataSource = new BindingSource(dataSource, null);
		jr1oIKWlco.DisplayMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10936);
		jr1oIKWlco.ValueMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11118);
		HgtoUWx7t4();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HgtoUWx7t4()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		rwbo9oRy1k.RunWorkerAsync();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void qaIoLOOBCu()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		_ = Vaeo8AWdHp.Text;
		_ = xvVoFK9awe.Text;
		oZ1oAeFDR6.Controls.Clear();
		if (vY0oOIyVEn == null)
		{
			return;
		}
		foreach (NBTLibraryItem item in vY0oOIyVEn)
		{
			HDuogtRCL0(item);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private CloudLibraryItem HDuogtRCL0(NBTLibraryItem P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		CloudLibraryItem cloudLibraryItem = null;
		string value = Vaeo8AWdHp.Text.ToLower();
		string value2 = xvVoFK9awe.Text.ToLower();
		string text = jr1oIKWlco.SelectedValue as string;
		if ((string.IsNullOrWhiteSpace(value) || P_0.Name.ToLower().IndexOf(value) >= 0) && (string.IsNullOrWhiteSpace(value2) || P_0.Description.ToLower().IndexOf(value2) >= 0) && P_0.EntityType.ToLower() == text.ToLower())
		{
			cloudLibraryItem = new CloudLibraryItem(P_0, zLroPZuw6e);
			oZ1oAeFDR6.Controls.Add(cloudLibraryItem);
		}
		return cloudLibraryItem;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void zLroPZuw6e(NBTLibraryItem P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0 != null)
		{
			EpNoQrL5B0 = P_0;
			base.DialogResult = DialogResult.OK;
			Close();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OINoR2avCJ(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Vaeo8AWdHp.Text != h2souXgq2x)
		{
			pRNo1sQGA2();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ixgokfMKxx(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (xvVoFK9awe.Text != bmaooKNajm)
		{
			pRNo1sQGA2();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GUVoYVovWn(object P_0, KeyEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Vaeo8AWdHp.Text != h2souXgq2x)
		{
			pRNo1sQGA2();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hhXo3K3MZV(object P_0, KeyEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (xvVoFK9awe.Text != bmaooKNajm)
		{
			pRNo1sQGA2();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void pRNo1sQGA2()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (QGgoJwXD7m == null)
		{
			QGgoJwXD7m = new Timer();
			QGgoJwXD7m.Interval = 300;
			QGgoJwXD7m.Tick += I7AoEgPuPP;
		}
		QGgoJwXD7m.Stop();
		QGgoJwXD7m.Start();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void I7AoEgPuPP(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0 is Timer timer)
		{
			qaIoLOOBCu();
			h2souXgq2x = Vaeo8AWdHp.Text;
			bmaooKNajm = xvVoFK9awe.Text;
			timer.Stop();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UE3ordpv6Y(object P_0, DoWorkEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BackgroundWorker backgroundWorker = P_0 as BackgroundWorker;
		backgroundWorker.WorkerReportsProgress = true;
		HSMoCskgSM = new Dictionary<Guid, CloudLibraryItem>();
		LibraryCloudWorker libraryCloudWorker = new LibraryCloudWorker(backgroundWorker);
		vY0oOIyVEn = libraryCloudWorker.CallLibrary(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(54962), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(54972), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(54980));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SsEo5ivTti(object P_0, ProgressChangedEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_1.UserState is NBTLibraryItem)
		{
			NBTLibraryItem nBTLibraryItem = P_1.UserState as NBTLibraryItem;
			CloudLibraryItem cloudLibraryItem = HDuogtRCL0(nBTLibraryItem);
			if (cloudLibraryItem != null)
			{
				HSMoCskgSM.Add(nBTLibraryItem.ID, cloudLibraryItem);
			}
		}
		else if (P_1.UserState is Guid)
		{
			Guid key = (Guid)P_1.UserState;
			if (HSMoCskgSM.ContainsKey(key))
			{
				HSMoCskgSM[key].S5I4noyC4b();
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void niyo67aALj(object P_0, RunWorkerCompletedEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void WN3oN66ayw(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		qaIoLOOBCu();
		h2souXgq2x = Vaeo8AWdHp.Text;
		bmaooKNajm = xvVoFK9awe.Text;
		oZ1oAeFDR6.Focus();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void E7moDF3CiK(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		oZ1oAeFDR6.Focus();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && DbMo7sKhs0 != null)
		{
			DbMo7sKhs0.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void sKUocq8QN5()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		oZ1oAeFDR6 = new FlowLayoutPanel();
		MyuodWNbDO = new Panel();
		jr1oIKWlco = new ComboBox();
		ACtoz54kXG = new Label();
		xvVoFK9awe = new TextBox();
		L3bojyoydO = new Label();
		Vaeo8AWdHp = new TextBox();
		qVAoHaU00M = new Label();
		rwbo9oRy1k = new BackgroundWorker();
		MyuodWNbDO.SuspendLayout();
		SuspendLayout();
		oZ1oAeFDR6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		oZ1oAeFDR6.AutoScroll = true;
		oZ1oAeFDR6.Location = new Point(0, 116);
		oZ1oAeFDR6.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55000);
		oZ1oAeFDR6.Padding = new Padding(0, 6, 0, 0);
		oZ1oAeFDR6.Size = new Size(582, 507);
		oZ1oAeFDR6.TabIndex = 2;
		MyuodWNbDO.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		MyuodWNbDO.Controls.Add(jr1oIKWlco);
		MyuodWNbDO.Controls.Add(ACtoz54kXG);
		MyuodWNbDO.Controls.Add(xvVoFK9awe);
		MyuodWNbDO.Controls.Add(L3bojyoydO);
		MyuodWNbDO.Controls.Add(Vaeo8AWdHp);
		MyuodWNbDO.Controls.Add(qVAoHaU00M);
		MyuodWNbDO.Location = new Point(0, 7);
		MyuodWNbDO.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10398);
		MyuodWNbDO.Size = new Size(582, 103);
		MyuodWNbDO.TabIndex = 3;
		jr1oIKWlco.DropDownStyle = ComboBoxStyle.DropDownList;
		jr1oIKWlco.FormattingEnabled = true;
		jr1oIKWlco.Location = new Point(76, 72);
		jr1oIKWlco.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55040);
		jr1oIKWlco.Size = new Size(161, 21);
		jr1oIKWlco.TabIndex = 5;
		jr1oIKWlco.SelectedIndexChanged += WN3oN66ayw;
		ACtoz54kXG.AutoSize = true;
		ACtoz54kXG.Location = new Point(13, 76);
		ACtoz54kXG.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10482);
		ACtoz54kXG.Size = new Size(31, 13);
		ACtoz54kXG.TabIndex = 4;
		ACtoz54kXG.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55068);
		xvVoFK9awe.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		xvVoFK9awe.Location = new Point(76, 45);
		xvVoFK9awe.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55080);
		xvVoFK9awe.Size = new Size(494, 20);
		xvVoFK9awe.TabIndex = 3;
		xvVoFK9awe.TextChanged += ixgokfMKxx;
		xvVoFK9awe.KeyUp += hhXo3K3MZV;
		L3bojyoydO.AutoSize = true;
		L3bojyoydO.Location = new Point(13, 48);
		L3bojyoydO.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10582);
		L3bojyoydO.Size = new Size(60, 13);
		L3bojyoydO.TabIndex = 2;
		L3bojyoydO.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11830);
		Vaeo8AWdHp.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		Vaeo8AWdHp.Location = new Point(76, 19);
		Vaeo8AWdHp.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55110);
		Vaeo8AWdHp.Size = new Size(494, 20);
		Vaeo8AWdHp.TabIndex = 1;
		Vaeo8AWdHp.TextChanged += OINoR2avCJ;
		Vaeo8AWdHp.KeyUp += GUVoYVovWn;
		qVAoHaU00M.AutoSize = true;
		qVAoHaU00M.Location = new Point(13, 19);
		qVAoHaU00M.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		qVAoHaU00M.Size = new Size(35, 13);
		qVAoHaU00M.TabIndex = 0;
		qVAoHaU00M.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10196);
		rwbo9oRy1k.DoWork += UE3ordpv6Y;
		rwbo9oRy1k.ProgressChanged += SsEo5ivTti;
		rwbo9oRy1k.RunWorkerCompleted += niyo67aALj;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(582, 623);
		base.Controls.Add(MyuodWNbDO);
		base.Controls.Add(oZ1oAeFDR6);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55126);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55162);
		base.Activated += E7moDF3CiK;
		base.Load += WtWoMVZnhD;
		MyuodWNbDO.ResumeLayout(performLayout: false);
		MyuodWNbDO.PerformLayout();
		ResumeLayout(performLayout: false);
	}
}
