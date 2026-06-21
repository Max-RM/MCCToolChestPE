using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using Ipd9FQuHFywPC2qc3U0;
using MCCToolChest.model;
using MCCToolChest.Properties;
using MCCToolChest.utils;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.forms;

public class LibraryItemDlg : Form
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass1
	{
		public char[] invalidChars;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _003C_003Ec__DisplayClass1()
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool _003CCleanName_003Eb__0(char x)
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return !invalidChars.Contains(x);
		}
	}

	public LibraryItem libraryItem;

	private IContainer mRFdGuy5I1;

	private Label phHdbkh5pj;

	private TextBox fk6dvZl8kT;

	private Button VExdwBRRIV;

	private Button vUqd4hcyGJ;

	private TextBox dZqdVVqj1T;

	private Label BDudWmUd24;

	private TextBox xA9dphhqvw;

	private Label V1udZ9hN2T;

	private Label LtWdf0TGDH;

	private ComboBox zPMdi1hLZy;

	private TabPage hQNdslhUwX;

	private TextBox eZWdqSdKjn;

	private TabPage iS8dKFNdYs;

	private TextBox rirdhwr6dH;

	private TabPage xR1dmsgDBp;

	private TextBox ga0dn7PL5n;

	private TabControl zRYdljPFgs;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LibraryItemDlg()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		gbxdSUoQAr();
		iayAA86iUt();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void iayAA86iUt()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string[] array = RjxtHpuJeeKUWTRviGE.lZKStfRmi9D();
		zPMdi1hLZy.Items.Clear();
		string[] array2 = array;
		foreach (string item in array2)
		{
			zPMdi1hLZy.Items.Add(item);
		}
		zPMdi1hLZy.SelectedIndex = -1;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LibraryItemDlg(LibraryItem libraryItem)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		this.libraryItem = libraryItem;
		fk6dvZl8kT.ReadOnly = true;
		dZqdVVqj1T.ReadOnly = true;
		ONUAFrH52u();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void u8HAdG0F9k(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (GTwAjaI7be() && S27AImCON9())
		{
			mALAHfyWS6();
			base.DialogResult = DialogResult.OK;
			Close();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void mALAHfyWS6()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (libraryItem == null)
		{
			libraryItem = new LibraryItem();
		}
		libraryItem.Name = HQTA93qdi0(fk6dvZl8kT.Text.Trim());
		libraryItem.Author = dZqdVVqj1T.Text;
		libraryItem.Category = zPMdi1hLZy.Text;
		libraryItem.Link = xA9dphhqvw.Text;
		libraryItem.Description = ga0dn7PL5n.Text;
		libraryItem.Instructions = rirdhwr6dH.Text;
		libraryItem.NBTString = eZWdqSdKjn.Text;
		f2OA8ehrLR(libraryItem);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ONUAFrH52u()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		fk6dvZl8kT.Text = libraryItem.Name;
		dZqdVVqj1T.Text = libraryItem.Author;
		zPMdi1hLZy.Text = libraryItem.Category;
		xA9dphhqvw.Text = libraryItem.Link;
		ga0dn7PL5n.Text = libraryItem.Description;
		rirdhwr6dH.Text = libraryItem.Instructions;
		eZWdqSdKjn.Text = libraryItem.NBTString;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool GTwAjaI7be()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		StringBuilder stringBuilder = new StringBuilder();
		if (string.IsNullOrWhiteSpace(fk6dvZl8kT.Text))
		{
			stringBuilder.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(59302));
		}
		if (string.IsNullOrWhiteSpace(eZWdqSdKjn.Text))
		{
			stringBuilder.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(59340));
		}
		if (!Utils.IsHex(eZWdqSdKjn.Text))
		{
			stringBuilder.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(59376));
		}
		if (eZWdqSdKjn.Text.Length % 2 != 0)
		{
			stringBuilder.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(59422));
		}
		if (stringBuilder.Length > 0)
		{
			MessageBox.Show(stringBuilder.ToString(), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(59474));
		}
		return stringBuilder.Length == 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void f2OA8ehrLR(LibraryItem P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string folderPath = pRoAzmcmvR();
		string path = FileUtils.CheckFolderSep(folderPath) + HQTA93qdi0(P_0.Name) + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(59498);
		string value = DataConversion.Serialize(P_0);
		using StreamWriter streamWriter = new StreamWriter(File.Create(path));
		streamWriter.Write(value);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string HQTA93qdi0(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		_003C_003Ec__DisplayClass1 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass1();
		CS_0024_003C_003E8__locals2.invalidChars = Path.GetInvalidFileNameChars();
		return new string(P_0.Where([MethodImpl(MethodImplOptions.NoInlining)] (char x) =>
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return !CS_0024_003C_003E8__locals2.invalidChars.Contains(x);
		}).ToArray());
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool S27AImCON9()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bool result = true;
		if (libraryItem == null)
		{
			string folderPath = pRoAzmcmvR();
			string path = FileUtils.CheckFolderSep(folderPath) + fk6dvZl8kT.Text + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(59498);
			if (File.Exists(path))
			{
				DialogResult dialogResult = MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(59510) + Environment.NewLine + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(59590), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(59652), MessageBoxButtons.YesNo);
				result = dialogResult == DialogResult.Yes;
			}
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string pRoAzmcmvR()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return Utils.LibraryPath();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void pdkdTFPE8h(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.Icon = Resources.usMSrbJo37S();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && mRFdGuy5I1 != null)
		{
			mRFdGuy5I1.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void gbxdSUoQAr()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		phHdbkh5pj = new Label();
		fk6dvZl8kT = new TextBox();
		VExdwBRRIV = new Button();
		vUqd4hcyGJ = new Button();
		dZqdVVqj1T = new TextBox();
		BDudWmUd24 = new Label();
		xA9dphhqvw = new TextBox();
		V1udZ9hN2T = new Label();
		LtWdf0TGDH = new Label();
		zPMdi1hLZy = new ComboBox();
		hQNdslhUwX = new TabPage();
		eZWdqSdKjn = new TextBox();
		iS8dKFNdYs = new TabPage();
		rirdhwr6dH = new TextBox();
		xR1dmsgDBp = new TabPage();
		ga0dn7PL5n = new TextBox();
		zRYdljPFgs = new TabControl();
		hQNdslhUwX.SuspendLayout();
		iS8dKFNdYs.SuspendLayout();
		xR1dmsgDBp.SuspendLayout();
		zRYdljPFgs.SuspendLayout();
		SuspendLayout();
		phHdbkh5pj.AutoSize = true;
		phHdbkh5pj.Location = new Point(13, 9);
		phHdbkh5pj.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		phHdbkh5pj.Size = new Size(35, 13);
		phHdbkh5pj.TabIndex = 0;
		phHdbkh5pj.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10196);
		fk6dvZl8kT.Location = new Point(13, 24);
		fk6dvZl8kT.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55110);
		fk6dvZl8kT.Size = new Size(300, 20);
		fk6dvZl8kT.TabIndex = 1;
		VExdwBRRIV.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		VExdwBRRIV.DialogResult = DialogResult.Cancel;
		VExdwBRRIV.Location = new Point(554, 496);
		VExdwBRRIV.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(53508);
		VExdwBRRIV.Size = new Size(75, 23);
		VExdwBRRIV.TabIndex = 14;
		VExdwBRRIV.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20198);
		VExdwBRRIV.UseVisualStyleBackColor = true;
		vUqd4hcyGJ.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		vUqd4hcyGJ.Location = new Point(467, 496);
		vUqd4hcyGJ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(35742);
		vUqd4hcyGJ.Size = new Size(75, 23);
		vUqd4hcyGJ.TabIndex = 15;
		vUqd4hcyGJ.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(53536);
		vUqd4hcyGJ.Click += u8HAdG0F9k;
		dZqdVVqj1T.Location = new Point(328, 24);
		dZqdVVqj1T.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(59674);
		dZqdVVqj1T.Size = new Size(300, 20);
		dZqdVVqj1T.TabIndex = 3;
		BDudWmUd24.AutoSize = true;
		BDudWmUd24.Location = new Point(328, 9);
		BDudWmUd24.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11162);
		BDudWmUd24.Size = new Size(90, 13);
		BDudWmUd24.TabIndex = 2;
		BDudWmUd24.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12784);
		xA9dphhqvw.Location = new Point(328, 66);
		xA9dphhqvw.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(59694);
		xA9dphhqvw.Size = new Size(300, 20);
		xA9dphhqvw.TabIndex = 7;
		V1udZ9hN2T.AutoSize = true;
		V1udZ9hN2T.Location = new Point(328, 51);
		V1udZ9hN2T.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11298);
		V1udZ9hN2T.Size = new Size(27, 13);
		V1udZ9hN2T.TabIndex = 6;
		V1udZ9hN2T.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(59710);
		LtWdf0TGDH.AutoSize = true;
		LtWdf0TGDH.Location = new Point(13, 51);
		LtWdf0TGDH.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11132);
		LtWdf0TGDH.Size = new Size(49, 13);
		LtWdf0TGDH.TabIndex = 4;
		LtWdf0TGDH.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(59722);
		zPMdi1hLZy.DropDownStyle = ComboBoxStyle.DropDownList;
		zPMdi1hLZy.FormattingEnabled = true;
		zPMdi1hLZy.Location = new Point(13, 66);
		zPMdi1hLZy.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(59742);
		zPMdi1hLZy.Size = new Size(300, 21);
		zPMdi1hLZy.Sorted = true;
		zPMdi1hLZy.TabIndex = 5;
		hQNdslhUwX.Controls.Add(eZWdqSdKjn);
		hQNdslhUwX.Location = new Point(4, 22);
		hQNdslhUwX.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15898);
		hQNdslhUwX.Padding = new Padding(3);
		hQNdslhUwX.Size = new Size(612, 362);
		hQNdslhUwX.TabIndex = 2;
		hQNdslhUwX.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15976);
		hQNdslhUwX.UseVisualStyleBackColor = true;
		eZWdqSdKjn.Dock = DockStyle.Fill;
		eZWdqSdKjn.Location = new Point(3, 3);
		eZWdqSdKjn.Multiline = true;
		eZWdqSdKjn.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(59766);
		eZWdqSdKjn.Size = new Size(606, 356);
		eZWdqSdKjn.TabIndex = 13;
		iS8dKFNdYs.Controls.Add(rirdhwr6dH);
		iS8dKFNdYs.Location = new Point(4, 22);
		iS8dKFNdYs.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57098);
		iS8dKFNdYs.Padding = new Padding(3);
		iS8dKFNdYs.Size = new Size(612, 362);
		iS8dKFNdYs.TabIndex = 1;
		iS8dKFNdYs.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(59792);
		iS8dKFNdYs.UseVisualStyleBackColor = true;
		rirdhwr6dH.Dock = DockStyle.Fill;
		rirdhwr6dH.Location = new Point(3, 3);
		rirdhwr6dH.Multiline = true;
		rirdhwr6dH.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(59820);
		rirdhwr6dH.Size = new Size(606, 356);
		rirdhwr6dH.TabIndex = 11;
		xR1dmsgDBp.Controls.Add(ga0dn7PL5n);
		xR1dmsgDBp.Location = new Point(4, 22);
		xR1dmsgDBp.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(56536);
		xR1dmsgDBp.Padding = new Padding(3);
		xR1dmsgDBp.Size = new Size(612, 362);
		xR1dmsgDBp.TabIndex = 0;
		xR1dmsgDBp.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11830);
		xR1dmsgDBp.UseVisualStyleBackColor = true;
		ga0dn7PL5n.Dock = DockStyle.Fill;
		ga0dn7PL5n.Location = new Point(3, 3);
		ga0dn7PL5n.Multiline = true;
		ga0dn7PL5n.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55080);
		ga0dn7PL5n.Size = new Size(606, 356);
		ga0dn7PL5n.TabIndex = 9;
		zRYdljPFgs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		zRYdljPFgs.Controls.Add(xR1dmsgDBp);
		zRYdljPFgs.Controls.Add(iS8dKFNdYs);
		zRYdljPFgs.Controls.Add(hQNdslhUwX);
		zRYdljPFgs.Location = new Point(13, 98);
		zRYdljPFgs.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(56510);
		zRYdljPFgs.SelectedIndex = 0;
		zRYdljPFgs.Size = new Size(620, 388);
		zRYdljPFgs.TabIndex = 16;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = VExdwBRRIV;
		base.ClientSize = new Size(645, 528);
		base.Controls.Add(zRYdljPFgs);
		base.Controls.Add(zPMdi1hLZy);
		base.Controls.Add(xA9dphhqvw);
		base.Controls.Add(V1udZ9hN2T);
		base.Controls.Add(LtWdf0TGDH);
		base.Controls.Add(dZqdVVqj1T);
		base.Controls.Add(BDudWmUd24);
		base.Controls.Add(VExdwBRRIV);
		base.Controls.Add(vUqd4hcyGJ);
		base.Controls.Add(fk6dvZl8kT);
		base.Controls.Add(phHdbkh5pj);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(59852);
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(59884);
		base.Load += pdkdTFPE8h;
		hQNdslhUwX.ResumeLayout(performLayout: false);
		hQNdslhUwX.PerformLayout();
		iS8dKFNdYs.ResumeLayout(performLayout: false);
		iS8dKFNdYs.PerformLayout();
		xR1dmsgDBp.ResumeLayout(performLayout: false);
		xR1dmsgDBp.PerformLayout();
		zRYdljPFgs.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
