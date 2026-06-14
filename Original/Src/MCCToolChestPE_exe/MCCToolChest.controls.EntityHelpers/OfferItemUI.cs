using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.events;
using MCCToolChest.model;
using nJfKIGjYOandKUMf9r2;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls.EntityHelpers;

public class OfferItemUI : UserControl
{
	public static bool ENCHANT_FORM_SHOWING;

	private static Pen qOrqM9Xeqx;

	private static Pen R0JqUPKLJr;

	private OfferItemType U9QqLdC9oS;

	private bool lpFqgxEBV6;

	private static Font AnDqPmSbIi;

	private static Font W0FqRxKDV0;

	private fGAse5jADxgBiXK2mJb AxlqkNoCoL;

	private OfferSelected l0kqYRfR4H;

	private OfferItemSelected VoPq344KrI;

	private bool BXqq1mI7Q0;

	private IContainer MkjqEmqpq2;

	private PictureBox SwIqrNCHY8;

	private PictureBox N27q52UD0P;

	private PictureBox b30q6JvRDr;

	private Label dsKqNvGytU;

	private CheckBox y1TqD7toHX;

	private TextBox RLsqcicIFL;

	private TextBox AXwqJPgRf4;

	private TextBox bQ6quT2GYp;

	private TextBox GGCqoi561H;

	private Timer WVBqQgfdSW;

	public bool Active
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return lpFqgxEBV6;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			lpFqgxEBV6 = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	internal fGAse5jADxgBiXK2mJb NdRqXifW2b()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return AxlqkNoCoL;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	internal void xgtqxEf14h(fGAse5jADxgBiXK2mJb value)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		AxlqkNoCoL = value;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public OfferItemUI(TagNodeCompound offerTag, OfferSelected offerSelected, OfferItemSelected offerItemSelected)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		oiXqaXV4Xt();
		AxlqkNoCoL = new fGAse5jADxgBiXK2mJb(offerTag);
		l0kqYRfR4H = offerSelected;
		VoPq344KrI = offerItemSelected;
		r5asQJQaGX();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void r5asQJQaGX()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		RLsqcicIFL.Text = AxlqkNoCoL.AT6S4bl5LqS().ToString();
		y1TqD7toHX.Checked = AxlqkNoCoL.q6xS4TUSktK();
		SwIqrNCHY8.Image = AxlqkNoCoL.qqvS4p3dCak().Image;
		N27q52UD0P.Image = AxlqkNoCoL.hylS4fkAnmX().Image;
		b30q6JvRDr.Image = AxlqkNoCoL.E0fS4sNLH8w().Image;
		SwIqrNCHY8.AllowDrop = true;
		N27q52UD0P.AllowDrop = true;
		b30q6JvRDr.AllowDrop = true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void aTHsOs3tS9(object P_0, PaintEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (AxlqkNoCoL.qqvS4p3dCak().Enchanted)
		{
			P_1.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(80, Color.SlateBlue)), 0, 0, 42, 42);
		}
		Jn8sA5vSSx(P_1.Graphics, AxlqkNoCoL.qqvS4p3dCak().Count.ToString());
		Pen pen = null;
		pen = ((Active && U9QqLdC9oS == OfferItemType.Buy) ? qOrqM9Xeqx : R0JqUPKLJr);
		SrZsjuEEyu(P_1.Graphics, pen);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Hs1sC2cEjd(object P_0, PaintEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (AxlqkNoCoL.hylS4fkAnmX().Id > 0)
		{
			if (AxlqkNoCoL.hylS4fkAnmX().Enchanted)
			{
				P_1.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(80, Color.SlateBlue)), 0, 0, 42, 42);
			}
			Jn8sA5vSSx(P_1.Graphics, AxlqkNoCoL.hylS4fkAnmX().Count.ToString());
		}
		Pen pen = null;
		pen = ((Active && U9QqLdC9oS == OfferItemType.BuyB) ? qOrqM9Xeqx : R0JqUPKLJr);
		SrZsjuEEyu(P_1.Graphics, pen);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void mc8s7j3C59(object P_0, PaintEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (AxlqkNoCoL.E0fS4sNLH8w().Enchanted)
		{
			P_1.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(80, Color.SlateBlue)), 0, 0, 42, 42);
		}
		Jn8sA5vSSx(P_1.Graphics, AxlqkNoCoL.E0fS4sNLH8w().Count.ToString());
		Pen pen = null;
		pen = ((Active && U9QqLdC9oS == OfferItemType.Sell) ? qOrqM9Xeqx : R0JqUPKLJr);
		SrZsjuEEyu(P_1.Graphics, pen);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Jn8sA5vSSx(Graphics P_0, string P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Color black = Color.Black;
		Color white = Color.White;
		l0IsHFqtDq(P_0, black, 3, 1, P_1);
		l0IsHFqtDq(P_0, black, 4, 1, P_1);
		l0IsHFqtDq(P_0, black, 2, 2, P_1);
		l0IsHFqtDq(P_0, black, 5, 2, P_1);
		l0IsHFqtDq(P_0, black, 3, 3, P_1);
		l0IsHFqtDq(P_0, black, 4, 3, P_1);
		l0IsHFqtDq(P_0, white, 3, 2, P_1);
		l0IsHFqtDq(P_0, white, 4, 2, P_1);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void aLWsd0LoA2(Graphics P_0, Color P_1, int P_2, int P_3, string P_4)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_0.DrawString(P_4, AnDqPmSbIi, new SolidBrush(P_1), P_2 + 2, P_3 + 1);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void l0IsHFqtDq(Graphics P_0, Color P_1, int P_2, int P_3, string P_4)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		StringFormat stringFormat = new StringFormat();
		stringFormat.Alignment = StringAlignment.Far;
		stringFormat.LineAlignment = StringAlignment.Far;
		StringFormat format = stringFormat;
		P_0.DrawString(P_4, W0FqRxKDV0, new SolidBrush(P_1), 44 - P_2, 44 - P_3, format);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void wA5sFlUyjV(Graphics P_0, Color P_1, int P_2, int P_3, string P_4)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		StringFormat stringFormat = new StringFormat();
		stringFormat.Alignment = StringAlignment.Center;
		stringFormat.LineAlignment = StringAlignment.Center;
		StringFormat format = stringFormat;
		P_0.DrawString(P_4, AnDqPmSbIi, new SolidBrush(P_1), 22 + P_2, 22 + P_3, format);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SrZsjuEEyu(Graphics P_0, Pen P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Rectangle rect = new Rectangle(1, 1, 39, 39);
		P_0.DrawRectangle(P_1, rect);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void deTs8Hrt7k(object P_0, DragEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_1.Data.GetDataPresent(typeof(InventoryItem)))
		{
			InventoryItem inventoryItem = (InventoryItem)P_1.Data.GetData(typeof(InventoryItem));
			AxlqkNoCoL.qqvS4p3dCak().Id = inventoryItem.ID;
			AxlqkNoCoL.qqvS4p3dCak().Damage = inventoryItem.Damage;
			AxlqkNoCoL.qqvS4p3dCak().Count = 1;
			AXwqJPgRf4.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18714);
			SwIqrNCHY8.Image = AxlqkNoCoL.qqvS4p3dCak().Image;
			jEvqp0QGDy();
			U9QqLdC9oS = OfferItemType.Buy;
			GqCqZ19O6g(AxlqkNoCoL.qqvS4p3dCak());
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GGps9crU2E(object P_0, DragEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_1.Data.GetDataPresent(typeof(InventoryItem)))
		{
			_ = (InventoryItem)P_1.Data.GetData(typeof(InventoryItem));
			P_1.Effect = DragDropEffects.Copy;
		}
		else
		{
			P_1.Effect = DragDropEffects.None;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ueksIgd0eL(object P_0, DragEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_1.Data.GetDataPresent(typeof(InventoryItem)))
		{
			InventoryItem inventoryItem = (InventoryItem)P_1.Data.GetData(typeof(InventoryItem));
			AxlqkNoCoL.hylS4fkAnmX().Id = inventoryItem.ID;
			AxlqkNoCoL.hylS4fkAnmX().Damage = inventoryItem.Damage;
			AxlqkNoCoL.hylS4fkAnmX().Count = 1;
			bQ6quT2GYp.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18714);
			N27q52UD0P.Image = AxlqkNoCoL.hylS4fkAnmX().Image;
			jEvqp0QGDy();
			U9QqLdC9oS = OfferItemType.BuyB;
			GqCqZ19O6g(AxlqkNoCoL.hylS4fkAnmX());
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ksOszJ1EVU(object P_0, DragEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_1.Data.GetDataPresent(typeof(InventoryItem)))
		{
			_ = (InventoryItem)P_1.Data.GetData(typeof(InventoryItem));
			P_1.Effect = DragDropEffects.Copy;
		}
		else
		{
			P_1.Effect = DragDropEffects.None;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void a19qT6MFJS(object P_0, DragEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_1.Data.GetDataPresent(typeof(InventoryItem)))
		{
			InventoryItem inventoryItem = (InventoryItem)P_1.Data.GetData(typeof(InventoryItem));
			AxlqkNoCoL.E0fS4sNLH8w().Id = inventoryItem.ID;
			AxlqkNoCoL.E0fS4sNLH8w().Damage = inventoryItem.Damage;
			AxlqkNoCoL.E0fS4sNLH8w().Count = inventoryItem.Count;
			GGCqoi561H.Text = inventoryItem.Count.ToString();
			b30q6JvRDr.Image = AxlqkNoCoL.E0fS4sNLH8w().Image;
			jEvqp0QGDy();
			U9QqLdC9oS = OfferItemType.Sell;
			GqCqZ19O6g(AxlqkNoCoL.E0fS4sNLH8w());
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void gj3qSRJ2kL(object P_0, DragEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_1.Data.GetDataPresent(typeof(InventoryItem)))
		{
			_ = (InventoryItem)P_1.Data.GetData(typeof(InventoryItem));
			P_1.Effect = DragDropEffects.Copy;
		}
		else
		{
			P_1.Effect = DragDropEffects.None;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Gs9qGGFG5c(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!lpFqgxEBV6)
		{
			GnRqvpA1Kt(Color.LightBlue);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void w3RqbV9NXT(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!lpFqgxEBV6)
		{
			GnRqvpA1Kt(Color.White);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GnRqvpA1Kt(Color P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BackColor = P_0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void M5BqwOnmnx(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ILNq4jIbxn(this, null);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ILNq4jIbxn(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		U9QqLdC9oS = OfferItemType.Buy;
		jEvqp0QGDy();
		AXwqJPgRf4.Focus();
		GqCqZ19O6g(AxlqkNoCoL.qqvS4p3dCak());
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Hs5qVpo7ay(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		U9QqLdC9oS = OfferItemType.BuyB;
		jEvqp0QGDy();
		bQ6quT2GYp.Focus();
		GqCqZ19O6g(AxlqkNoCoL.hylS4fkAnmX());
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void xdAqWAf3dp(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		U9QqLdC9oS = OfferItemType.Sell;
		jEvqp0QGDy();
		GGCqoi561H.Focus();
		GqCqZ19O6g(AxlqkNoCoL.E0fS4sNLH8w());
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void jEvqp0QGDy()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!lpFqgxEBV6)
		{
			l0kqYRfR4H(this);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GqCqZ19O6g(OfferItem P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		JkFq0nWyHJ();
		VoPq344KrI(P_0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetActive(bool active)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BXqq1mI7Q0 = true;
		lpFqgxEBV6 = active;
		if (active)
		{
			BackColor = Color.LightBlue;
			base.Height = 80;
			WVBqQgfdSW.Start();
		}
		else
		{
			BackColor = Color.White;
			base.Height = 61;
			U9QqLdC9oS = OfferItemType.None;
		}
		AXwqJPgRf4.Visible = active;
		bQ6quT2GYp.Visible = active;
		GGCqoi561H.Visible = active;
		yVPqfJEbiD();
		BXqq1mI7Q0 = false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void yVPqfJEbiD()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (lpFqgxEBV6)
		{
			AXwqJPgRf4.Text = AxlqkNoCoL.qqvS4p3dCak().Count.ToString();
			bQ6quT2GYp.Text = AxlqkNoCoL.hylS4fkAnmX().Count.ToString();
			GGCqoi561H.Text = AxlqkNoCoL.E0fS4sNLH8w().Count.ToString();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void xSWqiPY6CN(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		WVBqQgfdSW.Stop();
		if (U9QqLdC9oS == OfferItemType.Buy)
		{
			AXwqJPgRf4.Focus();
		}
		else if (U9QqLdC9oS == OfferItemType.BuyB)
		{
			bQ6quT2GYp.Focus();
		}
		else if (U9QqLdC9oS == OfferItemType.Sell)
		{
			GGCqoi561H.Focus();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void e82qsgIIh2(object P_0, KeyEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int.TryParse(AXwqJPgRf4.Text, out var result);
		AxlqkNoCoL.qqvS4p3dCak().Count = (byte)result;
		SwIqrNCHY8.Invalidate();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void VOIqqmIeci(object P_0, KeyEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int.TryParse(bQ6quT2GYp.Text, out var result);
		AxlqkNoCoL.hylS4fkAnmX().Count = (byte)result;
		N27q52UD0P.Invalidate();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void tx0qK9nm4x(object P_0, KeyEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int.TryParse(GGCqoi561H.Text, out var result);
		AxlqkNoCoL.E0fS4sNLH8w().Count = (byte)result;
		b30q6JvRDr.Invalidate();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void K3yqhU4MNU(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!ENCHANT_FORM_SHOWING)
		{
			U9QqLdC9oS = OfferItemType.Buy;
			GqCqZ19O6g(AxlqkNoCoL.qqvS4p3dCak());
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void lxqqmXtAEm(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TfbqnKsffJ(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!ENCHANT_FORM_SHOWING)
		{
			U9QqLdC9oS = OfferItemType.BuyB;
			GqCqZ19O6g(AxlqkNoCoL.hylS4fkAnmX());
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hxCqlsIVU4(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ahtq2yVe5O(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!ENCHANT_FORM_SHOWING)
		{
			U9QqLdC9oS = OfferItemType.Sell;
			GqCqZ19O6g(AxlqkNoCoL.E0fS4sNLH8w());
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void NBQqyqqooQ(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void JkFq0nWyHJ()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		SwIqrNCHY8.Invalidate();
		N27q52UD0P.Invalidate();
		b30q6JvRDr.Invalidate();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void yuOqByroAs(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!lpFqgxEBV6 && !BXqq1mI7Q0 && !ENCHANT_FORM_SHOWING)
		{
			ILNq4jIbxn(this, null);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void JFnqt60Yoo(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!lpFqgxEBV6 && !BXqq1mI7Q0 && !ENCHANT_FORM_SHOWING)
		{
			U9QqLdC9oS = OfferItemType.NoAction;
			jEvqp0QGDy();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && MkjqEmqpq2 != null)
		{
			MkjqEmqpq2.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void oiXqaXV4Xt()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MkjqEmqpq2 = new Container();
		SwIqrNCHY8 = new PictureBox();
		N27q52UD0P = new PictureBox();
		b30q6JvRDr = new PictureBox();
		dsKqNvGytU = new Label();
		y1TqD7toHX = new CheckBox();
		RLsqcicIFL = new TextBox();
		AXwqJPgRf4 = new TextBox();
		bQ6quT2GYp = new TextBox();
		GGCqoi561H = new TextBox();
		WVBqQgfdSW = new Timer(MkjqEmqpq2);
		((ISupportInitialize)SwIqrNCHY8).BeginInit();
		((ISupportInitialize)N27q52UD0P).BeginInit();
		((ISupportInitialize)b30q6JvRDr).BeginInit();
		SuspendLayout();
		SwIqrNCHY8.BackColor = Color.FromArgb(230, 230, 230);
		SwIqrNCHY8.BorderStyle = BorderStyle.FixedSingle;
		SwIqrNCHY8.Location = new Point(6, 8);
		SwIqrNCHY8.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18720);
		SwIqrNCHY8.Padding = new Padding(5);
		SwIqrNCHY8.Size = new Size(44, 44);
		SwIqrNCHY8.TabIndex = 0;
		SwIqrNCHY8.TabStop = false;
		SwIqrNCHY8.Click += ILNq4jIbxn;
		SwIqrNCHY8.DragDrop += deTs8Hrt7k;
		SwIqrNCHY8.DragOver += GGps9crU2E;
		SwIqrNCHY8.Paint += aTHsOs3tS9;
		SwIqrNCHY8.MouseEnter += Gs9qGGFG5c;
		SwIqrNCHY8.MouseLeave += w3RqbV9NXT;
		N27q52UD0P.BackColor = Color.FromArgb(230, 230, 230);
		N27q52UD0P.BorderStyle = BorderStyle.FixedSingle;
		N27q52UD0P.Location = new Point(55, 8);
		N27q52UD0P.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18734);
		N27q52UD0P.Padding = new Padding(5);
		N27q52UD0P.Size = new Size(44, 44);
		N27q52UD0P.TabIndex = 1;
		N27q52UD0P.TabStop = false;
		N27q52UD0P.Click += Hs5qVpo7ay;
		N27q52UD0P.DragDrop += ueksIgd0eL;
		N27q52UD0P.DragOver += ksOszJ1EVU;
		N27q52UD0P.Paint += Hs1sC2cEjd;
		N27q52UD0P.MouseEnter += Gs9qGGFG5c;
		N27q52UD0P.MouseLeave += w3RqbV9NXT;
		b30q6JvRDr.BackColor = Color.FromArgb(230, 230, 230);
		b30q6JvRDr.BorderStyle = BorderStyle.FixedSingle;
		b30q6JvRDr.Location = new Point(121, 8);
		b30q6JvRDr.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18750);
		b30q6JvRDr.Padding = new Padding(5);
		b30q6JvRDr.Size = new Size(44, 44);
		b30q6JvRDr.TabIndex = 2;
		b30q6JvRDr.TabStop = false;
		b30q6JvRDr.Click += xdAqWAf3dp;
		b30q6JvRDr.DragDrop += a19qT6MFJS;
		b30q6JvRDr.DragOver += gj3qSRJ2kL;
		b30q6JvRDr.Paint += mc8s7j3C59;
		b30q6JvRDr.MouseEnter += Gs9qGGFG5c;
		b30q6JvRDr.MouseLeave += w3RqbV9NXT;
		dsKqNvGytU.AutoSize = true;
		dsKqNvGytU.Location = new Point(169, 9);
		dsKqNvGytU.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		dsKqNvGytU.Size = new Size(50, 13);
		dsKqNvGytU.TabIndex = 3;
		dsKqNvGytU.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18766);
		dsKqNvGytU.Click += M5BqwOnmnx;
		dsKqNvGytU.MouseEnter += Gs9qGGFG5c;
		dsKqNvGytU.MouseLeave += w3RqbV9NXT;
		y1TqD7toHX.AutoSize = true;
		y1TqD7toHX.CheckAlign = ContentAlignment.MiddleRight;
		y1TqD7toHX.Location = new Point(168, 36);
		y1TqD7toHX.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18784);
		y1TqD7toHX.Size = new Size(76, 17);
		y1TqD7toHX.TabIndex = 5;
		y1TqD7toHX.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18810);
		y1TqD7toHX.UseVisualStyleBackColor = true;
		y1TqD7toHX.Click += M5BqwOnmnx;
		y1TqD7toHX.Enter += JFnqt60Yoo;
		y1TqD7toHX.MouseEnter += Gs9qGGFG5c;
		y1TqD7toHX.MouseLeave += w3RqbV9NXT;
		RLsqcicIFL.Location = new Point(224, 6);
		RLsqcicIFL.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18832);
		RLsqcicIFL.Size = new Size(54, 20);
		RLsqcicIFL.TabIndex = 4;
		RLsqcicIFL.Click += M5BqwOnmnx;
		RLsqcicIFL.Enter += yuOqByroAs;
		RLsqcicIFL.MouseEnter += Gs9qGGFG5c;
		RLsqcicIFL.MouseLeave += w3RqbV9NXT;
		AXwqJPgRf4.Location = new Point(6, 53);
		AXwqJPgRf4.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18854);
		AXwqJPgRf4.Size = new Size(44, 20);
		AXwqJPgRf4.TabIndex = 0;
		AXwqJPgRf4.Visible = false;
		AXwqJPgRf4.Enter += K3yqhU4MNU;
		AXwqJPgRf4.KeyUp += e82qsgIIh2;
		AXwqJPgRf4.Leave += lxqqmXtAEm;
		bQ6quT2GYp.Location = new Point(55, 53);
		bQ6quT2GYp.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18874);
		bQ6quT2GYp.Size = new Size(44, 20);
		bQ6quT2GYp.TabIndex = 1;
		bQ6quT2GYp.Visible = false;
		bQ6quT2GYp.Enter += TfbqnKsffJ;
		bQ6quT2GYp.KeyUp += VOIqqmIeci;
		bQ6quT2GYp.Leave += hxCqlsIVU4;
		GGCqoi561H.Location = new Point(121, 53);
		GGCqoi561H.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18896);
		GGCqoi561H.Size = new Size(44, 20);
		GGCqoi561H.TabIndex = 2;
		GGCqoi561H.Visible = false;
		GGCqoi561H.Enter += ahtq2yVe5O;
		GGCqoi561H.KeyUp += tx0qK9nm4x;
		GGCqoi561H.Leave += NBQqyqqooQ;
		WVBqQgfdSW.Tick += xSWqiPY6CN;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.White;
		base.Controls.Add(GGCqoi561H);
		base.Controls.Add(bQ6quT2GYp);
		base.Controls.Add(AXwqJPgRf4);
		base.Controls.Add(RLsqcicIFL);
		base.Controls.Add(y1TqD7toHX);
		base.Controls.Add(dsKqNvGytU);
		base.Controls.Add(b30q6JvRDr);
		base.Controls.Add(N27q52UD0P);
		base.Controls.Add(SwIqrNCHY8);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18918);
		base.Size = new Size(299, 61);
		base.Click += M5BqwOnmnx;
		base.MouseEnter += Gs9qGGFG5c;
		base.MouseLeave += w3RqbV9NXT;
		((ISupportInitialize)SwIqrNCHY8).EndInit();
		((ISupportInitialize)N27q52UD0P).EndInit();
		((ISupportInitialize)b30q6JvRDr).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static OfferItemUI()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		ENCHANT_FORM_SHOWING = false;
		qOrqM9Xeqx = new Pen(Color.Red);
		R0JqUPKLJr = new Pen(Color.FromArgb(255, 230, 230, 230));
		AnDqPmSbIi = new Font(FontFamily.GenericMonospace, 8f, FontStyle.Bold);
		W0FqRxKDV0 = new Font(FontFamily.GenericMonospace, 10f, FontStyle.Bold);
	}
}
