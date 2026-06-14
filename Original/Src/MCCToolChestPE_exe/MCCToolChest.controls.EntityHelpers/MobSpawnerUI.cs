using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ConfTkj5LbUck64WyxM;
using DekWW8jSE3fVOo1d5ao;
using MCCToolChest.controllers;
using MCCToolChest.model;
using MCCToolChest.utils;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls.EntityHelpers;

public class MobSpawnerUI : UserControl
{
	private int MNTZEr0ogC;

	private TagNodeCompound AHAZrGh6rm;

	private static Dictionary<int, string> F9FZ5niyYj;

	private EntityLookup cS4Z6rU0Ou;

	private bool AOBZNulGfC;

	private IContainer C87ZDTjIfS;

	private EntityHelperHeader zerZcFAe0D;

	private NumericUpDown Y0RZJNMaOd;

	private NumericUpDown DesZuB5qnd;

	private NumericUpDown XFtZokNtaQ;

	private NumericUpDown Av1ZQJ5EZB;

	private NumericUpDown cB0ZOhQpae;

	private NumericUpDown NhpZC5wst0;

	private NumericUpDown nJtZ7biLKJ;

	private NumericUpDown VtxZAgxCbo;

	private NumericUpDown leqZdBTxxY;

	private Label FRHZHcw1iF;

	private Label zI3ZFrtyE1;

	private Label xePZjsSHns;

	private Label W3OZ8m5nv7;

	private Label oPTZ9PgYga;

	private Label BKyZIJ5K5O;

	private Label cOOZz6gDk3;

	private Label pKVfTM2oMd;

	private Label rtCfSoVmNJ;

	private PictureBox U7PfGGpdSD;

	private ComboBox HmSfbmmGi0;

	private Label yF0fvMvtJZ;

	private NumericUpDown GqDfwFBit5;

	[CompilerGenerated]
	private static Func<KeyValuePair<int, string>, string> YN2f42RGCv;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MobSpawnerUI(TagNodeCompound entity)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		cS4Z6rU0Ou = new EntityLookup();
		hYxZ3HFBGD();
		AHAZrGh6rm = entity;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void KSFZUXQXV5(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		W8RZgabPsB();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void APTZLD6MxE(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (zerZcFAe0D.ViewState == EntityHelperViewState.Contracted)
		{
			MNTZEr0ogC = base.Height;
			base.Height = zerZcFAe0D.Top + zerZcFAe0D.Height;
		}
		else
		{
			base.Height = MNTZEr0ogC;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void W8RZgabPsB()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		AOBZNulGfC = true;
		if (F9FZ5niyYj == null)
		{
			Dictionary<int, string> dictionary = new Dictionary<int, string>();
			foreach (NHRdVhjnRgobfuHvRk0 item in hvd0XujpavSpj5UhiI6.MaDSV0nae1F)
			{
				if (cS4Z6rU0Ou.PCEntities.ContainsKey(item.Name))
				{
					EntityItem entityItem = cS4Z6rU0Ou.PCEntities[item.Name];
					if (entityItem.EntityCategory == EntityCategory.MOB)
					{
						dictionary.Add(item.YhxSVSwIOdw(), entityItem.PCOldName);
					}
				}
			}
			F9FZ5niyYj = new Dictionary<int, string>();
			foreach (KeyValuePair<int, string> item2 in dictionary.OrderBy([MethodImpl(MethodImplOptions.NoInlining)] (KeyValuePair<int, string> P_0) =>
			{
				while (false)
				{
					_ = ((object[])null)[0];
				}
				return P_0.Value;
			}))
			{
				F9FZ5niyYj.Add(item2.Key, item2.Value);
			}
		}
		HmSfbmmGi0.DataSource = new BindingSource(F9FZ5niyYj, null);
		HmSfbmmGi0.ValueMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10936);
		HmSfbmmGi0.DisplayMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11118);
		Y0RZJNMaOd.DecimalPlaces = 2;
		Y0RZJNMaOd.Increment = 0.1m;
		DesZuB5qnd.DecimalPlaces = 2;
		DesZuB5qnd.Increment = 0.1m;
		XFtZokNtaQ.DecimalPlaces = 2;
		XFtZokNtaQ.Increment = 0.1m;
		GqDfwFBit5.Value = TagNodeUtils.ReadShort(AHAZrGh6rm, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(16054));
		Y0RZJNMaOd.Value = (decimal)TagNodeUtils.ReadFloat(AHAZrGh6rm, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(16068));
		DesZuB5qnd.Value = (decimal)TagNodeUtils.ReadFloat(AHAZrGh6rm, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(16110));
		XFtZokNtaQ.Value = (decimal)TagNodeUtils.ReadFloat(AHAZrGh6rm, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(16150));
		Av1ZQJ5EZB.Value = TagNodeUtils.ReadShort(AHAZrGh6rm, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(16190));
		cB0ZOhQpae.Value = TagNodeUtils.ReadShort(AHAZrGh6rm, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(16228));
		NhpZC5wst0.Value = TagNodeUtils.ReadShort(AHAZrGh6rm, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(16258));
		nJtZ7biLKJ.Value = TagNodeUtils.ReadShort(AHAZrGh6rm, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(16288));
		VtxZAgxCbo.Value = TagNodeUtils.ReadShort(AHAZrGh6rm, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(16330));
		leqZdBTxxY.Value = TagNodeUtils.ReadShort(AHAZrGh6rm, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(16354));
		int num = 4876;
		if (AHAZrGh6rm.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(16378)))
		{
			num = AHAZrGh6rm[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(16378)] as TagNodeInt;
		}
		else if (AHAZrGh6rm.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(16398)))
		{
			string key = AHAZrGh6rm[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(16398)] as TagNodeString;
			if (hvd0XujpavSpj5UhiI6.lfnSVhSnc0q().ContainsKey(key))
			{
				num = hvd0XujpavSpj5UhiI6.lfnSVhSnc0q()[key].YhxSVSwIOdw();
			}
		}
		if (!hvd0XujpavSpj5UhiI6.WBHSVsHEOJC().ContainsKey(num) && hvd0XujpavSpj5UhiI6.eCfSVZfnEaD().ContainsKey(num))
		{
			num = hvd0XujpavSpj5UhiI6.eCfSVZfnEaD()[num].YhxSVSwIOdw();
		}
		Al1ZPc8mrV(num);
		HmSfbmmGi0.SelectedValue = num;
		AOBZNulGfC = false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Al1ZPc8mrV(int P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (hvd0XujpavSpj5UhiI6.WBHSVsHEOJC().ContainsKey(P_0))
		{
			NHRdVhjnRgobfuHvRk0 nHRdVhjnRgobfuHvRk = hvd0XujpavSpj5UhiI6.WBHSVsHEOJC()[P_0];
			EntityItem entityItem = cS4Z6rU0Ou.PCEntities[nHRdVhjnRgobfuHvRk.Name];
			U7PfGGpdSD.Image = MobImageManager.MobImages.Images[entityItem.PCOldName];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FBOZRwLMIv()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeUtils.WriteShort(AHAZrGh6rm, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(16054), (short)GqDfwFBit5.Value);
		TagNodeUtils.WriteFloat(AHAZrGh6rm, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(16068), (float)Y0RZJNMaOd.Value);
		TagNodeUtils.WriteFloat(AHAZrGh6rm, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(16110), (float)DesZuB5qnd.Value);
		TagNodeUtils.WriteFloat(AHAZrGh6rm, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(16150), (float)XFtZokNtaQ.Value);
		TagNodeUtils.WriteShort(AHAZrGh6rm, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(16190), (short)Av1ZQJ5EZB.Value);
		TagNodeUtils.WriteShort(AHAZrGh6rm, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(16228), (short)cB0ZOhQpae.Value);
		TagNodeUtils.WriteShort(AHAZrGh6rm, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(16258), (short)NhpZC5wst0.Value);
		TagNodeUtils.WriteShort(AHAZrGh6rm, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(16288), (short)nJtZ7biLKJ.Value);
		TagNodeUtils.WriteShort(AHAZrGh6rm, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(16330), (short)VtxZAgxCbo.Value);
		TagNodeUtils.WriteShort(AHAZrGh6rm, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(16354), (short)leqZdBTxxY.Value);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void kHaZk9hYc5(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!AOBZNulGfC)
		{
			int num = 0;
			if (HmSfbmmGi0.SelectedValue is int)
			{
				num = (int)HmSfbmmGi0.SelectedValue;
				Al1ZPc8mrV(num);
				AHAZrGh6rm.Remove(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(16378));
				AHAZrGh6rm[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(16398)] = new TagNodeString(hvd0XujpavSpj5UhiI6.WBHSVsHEOJC()[num].Name);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YI6ZY6AHrG(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!AOBZNulGfC)
		{
			FBOZRwLMIv();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && C87ZDTjIfS != null)
		{
			C87ZDTjIfS.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hYxZ3HFBGD()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Y0RZJNMaOd = new NumericUpDown();
		DesZuB5qnd = new NumericUpDown();
		XFtZokNtaQ = new NumericUpDown();
		Av1ZQJ5EZB = new NumericUpDown();
		cB0ZOhQpae = new NumericUpDown();
		NhpZC5wst0 = new NumericUpDown();
		nJtZ7biLKJ = new NumericUpDown();
		VtxZAgxCbo = new NumericUpDown();
		leqZdBTxxY = new NumericUpDown();
		FRHZHcw1iF = new Label();
		zI3ZFrtyE1 = new Label();
		xePZjsSHns = new Label();
		W3OZ8m5nv7 = new Label();
		oPTZ9PgYga = new Label();
		BKyZIJ5K5O = new Label();
		cOOZz6gDk3 = new Label();
		pKVfTM2oMd = new Label();
		rtCfSoVmNJ = new Label();
		U7PfGGpdSD = new PictureBox();
		HmSfbmmGi0 = new ComboBox();
		yF0fvMvtJZ = new Label();
		GqDfwFBit5 = new NumericUpDown();
		zerZcFAe0D = new EntityHelperHeader();
		((ISupportInitialize)Y0RZJNMaOd).BeginInit();
		((ISupportInitialize)DesZuB5qnd).BeginInit();
		((ISupportInitialize)XFtZokNtaQ).BeginInit();
		((ISupportInitialize)Av1ZQJ5EZB).BeginInit();
		((ISupportInitialize)cB0ZOhQpae).BeginInit();
		((ISupportInitialize)NhpZC5wst0).BeginInit();
		((ISupportInitialize)nJtZ7biLKJ).BeginInit();
		((ISupportInitialize)VtxZAgxCbo).BeginInit();
		((ISupportInitialize)leqZdBTxxY).BeginInit();
		((ISupportInitialize)U7PfGGpdSD).BeginInit();
		((ISupportInitialize)GqDfwFBit5).BeginInit();
		SuspendLayout();
		Y0RZJNMaOd.Location = new Point(211, 77);
		Y0RZJNMaOd.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(16434);
		Y0RZJNMaOd.Size = new Size(59, 20);
		Y0RZJNMaOd.TabIndex = 2;
		Y0RZJNMaOd.TextAlign = HorizontalAlignment.Right;
		Y0RZJNMaOd.ValueChanged += YI6ZY6AHrG;
		DesZuB5qnd.Location = new Point(211, 105);
		DesZuB5qnd.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(16482);
		DesZuB5qnd.Size = new Size(59, 20);
		DesZuB5qnd.TabIndex = 3;
		DesZuB5qnd.TextAlign = HorizontalAlignment.Right;
		DesZuB5qnd.ValueChanged += YI6ZY6AHrG;
		XFtZokNtaQ.Location = new Point(211, 133);
		XFtZokNtaQ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(16528);
		XFtZokNtaQ.Size = new Size(59, 20);
		XFtZokNtaQ.TabIndex = 4;
		XFtZokNtaQ.TextAlign = HorizontalAlignment.Right;
		XFtZokNtaQ.ValueChanged += YI6ZY6AHrG;
		Av1ZQJ5EZB.Location = new Point(210, 161);
		Av1ZQJ5EZB.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(16574);
		Av1ZQJ5EZB.Size = new Size(59, 20);
		Av1ZQJ5EZB.TabIndex = 5;
		Av1ZQJ5EZB.TextAlign = HorizontalAlignment.Right;
		Av1ZQJ5EZB.ValueChanged += YI6ZY6AHrG;
		cB0ZOhQpae.Location = new Point(429, 49);
		cB0ZOhQpae.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
		cB0ZOhQpae.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(16618);
		cB0ZOhQpae.Size = new Size(59, 20);
		cB0ZOhQpae.TabIndex = 6;
		cB0ZOhQpae.TextAlign = HorizontalAlignment.Right;
		cB0ZOhQpae.ValueChanged += YI6ZY6AHrG;
		NhpZC5wst0.Location = new Point(429, 77);
		NhpZC5wst0.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
		NhpZC5wst0.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(16654);
		NhpZC5wst0.Size = new Size(59, 20);
		NhpZC5wst0.TabIndex = 7;
		NhpZC5wst0.TextAlign = HorizontalAlignment.Right;
		NhpZC5wst0.ValueChanged += YI6ZY6AHrG;
		nJtZ7biLKJ.Location = new Point(430, 105);
		nJtZ7biLKJ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(16690);
		nJtZ7biLKJ.Size = new Size(59, 20);
		nJtZ7biLKJ.TabIndex = 8;
		nJtZ7biLKJ.TextAlign = HorizontalAlignment.Right;
		nJtZ7biLKJ.ValueChanged += YI6ZY6AHrG;
		VtxZAgxCbo.Location = new Point(430, 133);
		VtxZAgxCbo.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(16738);
		VtxZAgxCbo.Size = new Size(59, 20);
		VtxZAgxCbo.TabIndex = 9;
		VtxZAgxCbo.TextAlign = HorizontalAlignment.Right;
		VtxZAgxCbo.ValueChanged += YI6ZY6AHrG;
		leqZdBTxxY.Location = new Point(430, 161);
		leqZdBTxxY.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(16768);
		leqZdBTxxY.Size = new Size(59, 20);
		leqZdBTxxY.TabIndex = 10;
		leqZdBTxxY.TextAlign = HorizontalAlignment.Right;
		leqZdBTxxY.ValueChanged += YI6ZY6AHrG;
		FRHZHcw1iF.AutoSize = true;
		FRHZHcw1iF.Location = new Point(276, 79);
		FRHZHcw1iF.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		FRHZHcw1iF.Size = new Size(104, 13);
		FRHZHcw1iF.TabIndex = 11;
		FRHZHcw1iF.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(16798);
		zI3ZFrtyE1.AutoSize = true;
		zI3ZFrtyE1.Location = new Point(276, 107);
		zI3ZFrtyE1.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10582);
		zI3ZFrtyE1.Size = new Size(100, 13);
		zI3ZFrtyE1.TabIndex = 12;
		zI3ZFrtyE1.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(16844);
		xePZjsSHns.AutoSize = true;
		xePZjsSHns.Location = new Point(276, 135);
		xePZjsSHns.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10482);
		xePZjsSHns.Size = new Size(101, 13);
		xePZjsSHns.TabIndex = 13;
		xePZjsSHns.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(16888);
		W3OZ8m5nv7.AutoSize = true;
		W3OZ8m5nv7.Location = new Point(276, 163);
		W3OZ8m5nv7.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12846);
		W3OZ8m5nv7.Size = new Size(101, 13);
		W3OZ8m5nv7.TabIndex = 14;
		W3OZ8m5nv7.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(16932);
		oPTZ9PgYga.AutoSize = true;
		oPTZ9PgYga.Location = new Point(495, 51);
		oPTZ9PgYga.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11162);
		oPTZ9PgYga.Size = new Size(93, 13);
		oPTZ9PgYga.TabIndex = 15;
		oPTZ9PgYga.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(16974);
		BKyZIJ5K5O.AutoSize = true;
		BKyZIJ5K5O.Location = new Point(495, 79);
		BKyZIJ5K5O.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11298);
		BKyZIJ5K5O.Size = new Size(90, 13);
		BKyZIJ5K5O.TabIndex = 16;
		BKyZIJ5K5O.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17008);
		cOOZz6gDk3.AutoSize = true;
		cOOZz6gDk3.Location = new Point(495, 107);
		cOOZz6gDk3.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11132);
		cOOZz6gDk3.Size = new Size(117, 13);
		cOOZz6gDk3.TabIndex = 17;
		cOOZz6gDk3.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17042);
		pKVfTM2oMd.AutoSize = true;
		pKVfTM2oMd.Location = new Point(495, 135);
		pKVfTM2oMd.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17088);
		pKVfTM2oMd.Size = new Size(71, 13);
		pKVfTM2oMd.TabIndex = 18;
		pKVfTM2oMd.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17104);
		rtCfSoVmNJ.AutoSize = true;
		rtCfSoVmNJ.Location = new Point(495, 163);
		rtCfSoVmNJ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17130);
		rtCfSoVmNJ.Size = new Size(75, 13);
		rtCfSoVmNJ.TabIndex = 19;
		rtCfSoVmNJ.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17146);
		U7PfGGpdSD.Location = new Point(34, 53);
		U7PfGGpdSD.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17172);
		U7PfGGpdSD.Size = new Size(128, 128);
		U7PfGGpdSD.SizeMode = PictureBoxSizeMode.Zoom;
		U7PfGGpdSD.TabIndex = 20;
		U7PfGGpdSD.TabStop = false;
		HmSfbmmGi0.DropDownStyle = ComboBoxStyle.DropDownList;
		HmSfbmmGi0.FormattingEnabled = true;
		HmSfbmmGi0.Location = new Point(16, 197);
		HmSfbmmGi0.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17194);
		HmSfbmmGi0.Size = new Size(159, 21);
		HmSfbmmGi0.TabIndex = 21;
		HmSfbmmGi0.SelectedIndexChanged += kHaZk9hYc5;
		yF0fvMvtJZ.AutoSize = true;
		yF0fvMvtJZ.Location = new Point(276, 53);
		yF0fvMvtJZ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17218);
		yF0fvMvtJZ.Size = new Size(34, 13);
		yF0fvMvtJZ.TabIndex = 23;
		yF0fvMvtJZ.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(16054);
		GqDfwFBit5.Location = new Point(211, 51);
		GqDfwFBit5.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17236);
		GqDfwFBit5.Size = new Size(59, 20);
		GqDfwFBit5.TabIndex = 22;
		GqDfwFBit5.TextAlign = HorizontalAlignment.Right;
		GqDfwFBit5.ValueChanged += YI6ZY6AHrG;
		zerZcFAe0D.BackColor = Color.Silver;
		zerZcFAe0D.Dock = DockStyle.Top;
		zerZcFAe0D.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		zerZcFAe0D.ForeColor = Color.Black;
		zerZcFAe0D.Location = new Point(0, 0);
		zerZcFAe0D.Margin = new Padding(4);
		zerZcFAe0D.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14148);
		zerZcFAe0D.Size = new Size(645, 35);
		zerZcFAe0D.TabIndex = 1;
		zerZcFAe0D.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17256);
		zerZcFAe0D.ViewState = EntityHelperViewState.Expanded;
		zerZcFAe0D.ChangeViewState += APTZLD6MxE;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(yF0fvMvtJZ);
		base.Controls.Add(GqDfwFBit5);
		base.Controls.Add(HmSfbmmGi0);
		base.Controls.Add(U7PfGGpdSD);
		base.Controls.Add(rtCfSoVmNJ);
		base.Controls.Add(pKVfTM2oMd);
		base.Controls.Add(cOOZz6gDk3);
		base.Controls.Add(BKyZIJ5K5O);
		base.Controls.Add(oPTZ9PgYga);
		base.Controls.Add(W3OZ8m5nv7);
		base.Controls.Add(xePZjsSHns);
		base.Controls.Add(zI3ZFrtyE1);
		base.Controls.Add(FRHZHcw1iF);
		base.Controls.Add(leqZdBTxxY);
		base.Controls.Add(VtxZAgxCbo);
		base.Controls.Add(nJtZ7biLKJ);
		base.Controls.Add(NhpZC5wst0);
		base.Controls.Add(cB0ZOhQpae);
		base.Controls.Add(Av1ZQJ5EZB);
		base.Controls.Add(XFtZokNtaQ);
		base.Controls.Add(DesZuB5qnd);
		base.Controls.Add(Y0RZJNMaOd);
		base.Controls.Add(zerZcFAe0D);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17282);
		base.Size = new Size(645, 255);
		base.Load += KSFZUXQXV5;
		((ISupportInitialize)Y0RZJNMaOd).EndInit();
		((ISupportInitialize)DesZuB5qnd).EndInit();
		((ISupportInitialize)XFtZokNtaQ).EndInit();
		((ISupportInitialize)Av1ZQJ5EZB).EndInit();
		((ISupportInitialize)cB0ZOhQpae).EndInit();
		((ISupportInitialize)NhpZC5wst0).EndInit();
		((ISupportInitialize)nJtZ7biLKJ).EndInit();
		((ISupportInitialize)VtxZAgxCbo).EndInit();
		((ISupportInitialize)leqZdBTxxY).EndInit();
		((ISupportInitialize)U7PfGGpdSD).EndInit();
		((ISupportInitialize)GqDfwFBit5).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static string E9WZ13VV0K(KeyValuePair<int, string> P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0.Value;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MobSpawnerUI()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}
}
