using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using HaI2p2xMqxTADue2UA;
using HiT3kduFNLtRQIR37JV;
using MCCToolChest.controllers;
using MCCToolChest.model;
using MCCToolChest.Properties;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.forms;

public class EntityConversionList : Form
{
	private static ImageList WL3NzwH3tX;

	private static ImageList fERDT66Uik;

	private static Dictionary<string, int> G4PDSAEWXs;

	private EntityLookup MWADG9WcqO;

	private List<string> mjlDba0PGb;

	private IContainer Xf6DvJ1nni;

	private ListView FAGDwdY3yn;

	private ColumnHeader VOtD4KvOVr;

	private ColumnHeader tFQDV29CMY;

	private Button wxaDWMQyYd;

	private Button HETDp8ItDW;

	public List<string> EntityList
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return mjlDba0PGb;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			mjlDba0PGb = value;
		}
	}

	[DllImport("user32.dll")]
	public static extern int SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EntityConversionList(List<string> entityList)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		MWADG9WcqO = new EntityLookup();
		RrTNI5WT57();
		mjlDba0PGb = entityList;
		if (fERDT66Uik == null)
		{
			fERDT66Uik = new ImageList();
			fERDT66Uik.ColorDepth = ColorDepth.Depth32Bit;
			fERDT66Uik.TransparentColor = Color.Transparent;
			fERDT66Uik.ImageSize = new Size(32, 32);
			Bitmap value = new Bitmap(32, 32);
			fERDT66Uik.Images.Add(value);
			G4PDSAEWXs = new Dictionary<string, int>();
		}
		FAGDwdY3yn.LargeImageList = MobImageManager.MobImages;
		FAGDwdY3yn.SmallImageList = MobImageManager.MobImages;
		if (MobImageManager.MobImages.Images[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(52434)] == null)
		{
			MobImageManager.MobImages.Images.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(52434), Resources.WxLS1g7VB74());
			MobImageManager.MobImages.Images.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(52452), Resources.BnFS1RQSj5I());
		}
		FAGDwdY3yn.Columns[0].ImageKey = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(52452);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void wq5N7DEI9s(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.Icon = Resources.usMSrbJo37S();
		m2LNAQuvkH();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void m2LNAQuvkH()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		FAGDwdY3yn.Items.Clear();
		foreach (EntityItem value in MWADG9WcqO.ConsoleEntities.Values)
		{
			ListViewItem listViewItem = new ListViewItem();
			listViewItem.UseItemStyleForSubItems = false;
			listViewItem.ImageKey = value.ConsoleName;
			listViewItem.Tag = value;
			ListViewItem.ListViewSubItem listViewSubItem = listViewItem.SubItems.Add(value.ConsoleName);
			listViewSubItem.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12898), 16f, FontStyle.Italic);
			listViewItem.Checked = mjlDba0PGb.Contains(value.ConsoleName);
			FAGDwdY3yn.Items.Add(listViewItem);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int rJrNdwe4gQ(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = 0;
		if (P_0.IndexOf(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9974)) >= 0 && INYifyudg3hCpcrleHt.mXTS0yn6FgU().ContainsKey(P_0))
		{
			P_0 = Constants.BEDROCK_ENTITY_BLOCKS[INYifyudg3hCpcrleHt.mXTS0yn6FgU()[P_0].Id];
		}
		if (G4PDSAEWXs.ContainsKey(P_0))
		{
			num = G4PDSAEWXs[P_0];
		}
		else if (Constants.BEDROCK_ENTITY_BLOCKS_BY_NAME.ContainsKey(P_0))
		{
			int num2 = Constants.BEDROCK_ENTITY_BLOCKS_BY_NAME[P_0];
			Image image = Jlxk34F1xl7DbN5CrR.YOTSpprXb7(num2, 0);
			if (image != null)
			{
				num = fERDT66Uik.Images.Count;
				fERDT66Uik.Images.Add(image);
				G4PDSAEWXs.Add(P_0, num);
			}
		}
		return num;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void vABNHXLVwG(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		mjlDba0PGb = new List<string>();
		for (int i = 0; i < FAGDwdY3yn.CheckedItems.Count; i++)
		{
			EntityItem entityItem = FAGDwdY3yn.CheckedItems[i].Tag as EntityItem;
			mjlDba0PGb.Add(entityItem.ConsoleName);
		}
		base.DialogResult = DialogResult.OK;
		Close();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void r1TNFBimk4(object P_0, ColumnClickEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P6VNjWx5pS();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void P6VNjWx5pS()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bool flag = FAGDwdY3yn.Items.Count == FAGDwdY3yn.CheckedItems.Count;
		for (int i = 0; i < FAGDwdY3yn.Items.Count; i++)
		{
			FAGDwdY3yn.Items[i].Checked = !flag;
		}
		EONN8S23YX();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EONN8S23YX()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		FAGDwdY3yn.Columns[0].ImageKey = ((FAGDwdY3yn.Items.Count == FAGDwdY3yn.CheckedItems.Count) ? Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(52434) : Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(52452));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void kIiN9thEHW(object P_0, ItemCheckedEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		EONN8S23YX();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && Xf6DvJ1nni != null)
		{
			Xf6DvJ1nni.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RrTNI5WT57()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		FAGDwdY3yn = new ListView();
		VOtD4KvOVr = new ColumnHeader();
		tFQDV29CMY = new ColumnHeader();
		wxaDWMQyYd = new Button();
		HETDp8ItDW = new Button();
		SuspendLayout();
		FAGDwdY3yn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		FAGDwdY3yn.CheckBoxes = true;
		FAGDwdY3yn.Columns.AddRange(new ColumnHeader[2] { VOtD4KvOVr, tFQDV29CMY });
		FAGDwdY3yn.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
		FAGDwdY3yn.FullRowSelect = true;
		FAGDwdY3yn.Location = new Point(12, 12);
		FAGDwdY3yn.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(52474);
		FAGDwdY3yn.Size = new Size(392, 520);
		FAGDwdY3yn.TabIndex = 0;
		FAGDwdY3yn.UseCompatibleStateImageBehavior = false;
		FAGDwdY3yn.View = View.Details;
		FAGDwdY3yn.ColumnClick += r1TNFBimk4;
		FAGDwdY3yn.ItemChecked += kIiN9thEHW;
		VOtD4KvOVr.Text = "";
		VOtD4KvOVr.Width = 70;
		tFQDV29CMY.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15852);
		tFQDV29CMY.Width = 280;
		wxaDWMQyYd.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		wxaDWMQyYd.Location = new Point(245, 543);
		wxaDWMQyYd.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34632);
		wxaDWMQyYd.Size = new Size(75, 23);
		wxaDWMQyYd.TabIndex = 7;
		wxaDWMQyYd.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34646);
		wxaDWMQyYd.UseVisualStyleBackColor = true;
		wxaDWMQyYd.Click += vABNHXLVwG;
		HETDp8ItDW.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		HETDp8ItDW.DialogResult = DialogResult.Cancel;
		HETDp8ItDW.Location = new Point(329, 543);
		HETDp8ItDW.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34610);
		HETDp8ItDW.Size = new Size(75, 23);
		HETDp8ItDW.TabIndex = 6;
		HETDp8ItDW.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20198);
		HETDp8ItDW.UseVisualStyleBackColor = true;
		base.AcceptButton = wxaDWMQyYd;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = HETDp8ItDW;
		base.ClientSize = new Size(417, 573);
		base.Controls.Add(wxaDWMQyYd);
		base.Controls.Add(HETDp8ItDW);
		base.Controls.Add(FAGDwdY3yn);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(52502);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(52546);
		base.Load += wq5N7DEI9s;
		ResumeLayout(performLayout: false);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static EntityConversionList()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}
}
