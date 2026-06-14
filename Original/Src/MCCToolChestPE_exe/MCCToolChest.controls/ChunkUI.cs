using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using afNMf7uWOyq6L7IHxiu;
using MCCToolChest.events;
using MCCToolChest.forms;
using MCCToolChest.model;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using uP7B13T5waxVpI3AEv;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls;

public class ChunkUI : UserControl
{
	private int gmww9SB7KF;

	private int f5FwICRoPW;

	private ChunkYLayer JTJwzbw3Gy;

	private Block vAN4TLLaXd;

	private Block PMK4S3YDy7;

	private Block Stt4GIv6AQ;

	private bool wRG4boMvvU;

	private Block moq4vTWTQX;

	private bool b284wXYSUt;

	private int afY44mKne0;

	private int vlo4Vn36iH;

	private EventHandler MrJ4WGbtTw;

	private EventHandler a344p4Jy6q;

	private IContainer KwJ4ZeRJ07;

	private Label Ybs4fM8VZ0;

	private Label inG4i6tMu6;

	public ChunkYLayer Level
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return JTJwzbw3Gy;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			JTJwzbw3Gy = value;
			Invalidate();
		}
	}

	public int ChunkX
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return gmww9SB7KF;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			gmww9SB7KF = value;
			afY44mKne0 = ((gmww9SB7KF >= 0) ? (gmww9SB7KF * 16) : ((gmww9SB7KF + 1) * 16));
		}
	}

	public int ChunkZ
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return f5FwICRoPW;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			f5FwICRoPW = value;
			vlo4Vn36iH = ((f5FwICRoPW >= 0) ? (f5FwICRoPW * 16) : ((f5FwICRoPW + 1) * 16));
		}
	}

	public bool CopyBlockActive
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return wRG4boMvvU;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			wRG4boMvvU = value;
		}
	}

	public Block SearchBlock
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return moq4vTWTQX;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			moq4vTWTQX = value;
		}
	}

	public bool SearchActive
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return b284wXYSUt;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			b284wXYSUt = value;
			Invalidate();
		}
	}

	public event EventHandler BlockCopied
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = MrJ4WGbtTw;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref MrJ4WGbtTw, value2, eventHandler2);
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
			EventHandler eventHandler = MrJ4WGbtTw;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref MrJ4WGbtTw, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler BlockChanged
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = a344p4Jy6q;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref a344p4Jy6q, value2, eventHandler2);
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
			EventHandler eventHandler = a344p4Jy6q;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref a344p4Jy6q, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ChunkUI()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		rk1w7uyGF2();
		qqvwecFwjG();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void qqvwecFwjG()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Ybs4fM8VZ0.Left = 10;
		Ybs4fM8VZ0.Top = 554;
		inG4i6tMu6.Left = 554 - inG4i6tMu6.Width;
		inG4i6tMu6.Top = 554;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	internal Block prGwAagDZG()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return PMK4S3YDy7;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	internal void f4Uwdj01tF(Block value)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PMK4S3YDy7 = value;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	internal Block OknwFjZxiH()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return vAN4TLLaXd;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	internal void mMcwjePRFC(Block value)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		vAN4TLLaXd = value;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnPaint(PaintEventArgs pe)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.OnPaint(pe);
		RKPwM0So6h(pe);
		r8fwUaCa5F(pe);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RKPwM0So6h(PaintEventArgs P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Brush brush = new SolidBrush(Color.White);
		P_0.Graphics.FillRectangle(brush, 10, 10, 544, 544);
		Pen pen = new Pen(Color.LightGray);
		Point pt = new Point(10, 10);
		Point pt2 = new Point(554, 10);
		for (int i = 0; i < 17; i++)
		{
			int num = i * 34;
			pt.Y = 10 + num;
			pt2.Y = 10 + num;
			P_0.Graphics.DrawLine(pen, pt, pt2);
		}
		pt.Y = 10;
		pt2.Y = 554;
		for (int j = 0; j < 17; j++)
		{
			int num2 = j * 34;
			pt.X = 10 + num2;
			pt2.X = 10 + num2;
			P_0.Graphics.DrawLine(pen, pt, pt2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void r8fwUaCa5F(PaintEventArgs P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Level == null)
		{
			return;
		}
		for (int i = 0; i < 16; i++)
		{
			for (int j = 0; j < 16; j++)
			{
				Point point = new Point(i * 34 + 11, j * 34 + 11);
				int num = j * 16 + i;
				if (F1ywLQvWnb(JTJwzbw3Gy.Blocks[num].Id, JTJwzbw3Gy.Blocks[num].Data))
				{
					Brush brush = new SolidBrush(Color.Red);
					P_0.Graphics.FillRectangle(brush, point.X, point.Y, 32, 32);
				}
				Image image = BFRL2f2UoG7tBGIHJF.xRoSMGJq48(JTJwzbw3Gy.Blocks[num].Id, JTJwzbw3Gy.Blocks[num].Data);
				if (image != null)
				{
					P_0.Graphics.DrawImage(image, point);
				}
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool F1ywLQvWnb(int P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (SearchActive && P_0 == moq4vTWTQX.Id)
		{
			if (P_1 != moq4vTWTQX.Data)
			{
				return moq4vTWTQX.Data == -1;
			}
			return true;
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void mobwgGoPmx(object P_0, MouseEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Stt4GIv6AQ = null;
		if (!jpYwC8h3ur(P_1))
		{
			return;
		}
		if (Control.ModifierKeys == (Keys.Shift | Keys.Control))
		{
			UXWwODMRqr(P_1);
		}
		else if (wRG4boMvvU || Control.ModifierKeys == Keys.Shift || Control.ModifierKeys == Keys.Control || Control.ModifierKeys == Keys.Alt)
		{
			if (P_1.Button == MouseButtons.Left)
			{
				Stt4GIv6AQ = vAN4TLLaXd;
			}
			else
			{
				Stt4GIv6AQ = PMK4S3YDy7;
			}
			if (wRG4boMvvU)
			{
				yt5wR9i1kj(P_1);
			}
			else if (Control.ModifierKeys == Keys.Shift)
			{
				pNUw5dOtpo(P_1);
				o5lwryrxki(P_1);
			}
			else if (Control.ModifierKeys == Keys.Control)
			{
				NiBwYxfnVC();
			}
			else if (Control.ModifierKeys == Keys.Alt)
			{
				KJcwkYNFmi(P_1);
			}
		}
		else
		{
			RL0wPaQJI1(P_1);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RL0wPaQJI1(MouseEventArgs P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound tagNodeCompound = null;
		TagNodeCompound node = null;
		if (!jpYwC8h3ur(P_0))
		{
			return;
		}
		int num = owvwJtaj8g(P_0.X, P_0.Y);
		if (num < 256)
		{
			int num2 = (P_0.X - 10) / 34;
			int num3 = (P_0.Y - 10) / 34;
			Block block = JTJwzbw3Gy.Blocks[num];
			if (Constants.BEDROCK_ENTITY_BLOCKS.ContainsKey(block.Id))
			{
				tagNodeCompound = t1mw6Uu3Uj(JTJwzbw3Gy.TileEntities, num2, JTJwzbw3Gy.Layer, num3);
				if (tagNodeCompound != null)
				{
					node = tagNodeCompound.Copy() as TagNodeCompound;
				}
				BlockEntityEdit blockEntityEdit = new BlockEntityEdit(JTJwzbw3Gy.Blocks[num], node);
				if (blockEntityEdit.ShowDialog(this) == DialogResult.OK)
				{
					tagNodeCompound = blockEntityEdit.Entity;
					if (tagNodeCompound != null)
					{
						IUCwNQlpTo(JTJwzbw3Gy.TileEntities, num2, JTJwzbw3Gy.Layer, num3);
						yVywcxKNvo(tagNodeCompound, num2, JTJwzbw3Gy.Layer, num3);
						JTJwzbw3Gy.TileEntities.Add(tagNodeCompound);
					}
				}
			}
		}
		Stt4GIv6AQ = null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void yt5wR9i1kj(MouseEventArgs P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (jpYwC8h3ur(P_0) && Stt4GIv6AQ != null)
		{
			int num = owvwJtaj8g(P_0.X, P_0.Y);
			if (num < 256)
			{
				Stt4GIv6AQ.Id = JTJwzbw3Gy.Blocks[num].Id;
				Stt4GIv6AQ.Data = JTJwzbw3Gy.Blocks[num].Data;
			}
			wRG4boMvvU = false;
			OnBlockCopied(this, new BlockCopiedEventArgs(Stt4GIv6AQ.Copy()));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void KJcwkYNFmi(MouseEventArgs P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!jpYwC8h3ur(P_0))
		{
			return;
		}
		int num = owvwJtaj8g(P_0.X, P_0.Y);
		if (num >= 256)
		{
			return;
		}
		int id = JTJwzbw3Gy.Blocks[num].Id;
		int data = JTJwzbw3Gy.Blocks[num].Data;
		Block block = JTJwzbw3Gy.Blocks[num].Copy();
		for (int i = 0; i < JTJwzbw3Gy.Blocks.Length; i++)
		{
			if (JTJwzbw3Gy.Blocks[i].Id == id && JTJwzbw3Gy.Blocks[i].Data == data)
			{
				Wusw3XEsEq(i, Stt4GIv6AQ);
			}
		}
		Invalidate();
		OnBlockChanged(this, new BlockChangedEventArgs(block.Copy()));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void NiBwYxfnVC()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (JTJwzbw3Gy != null)
		{
			for (int i = 0; i < JTJwzbw3Gy.Blocks.Length; i++)
			{
				Wusw3XEsEq(i, Stt4GIv6AQ);
			}
			Invalidate();
			OnBlockChanged(this, new BlockChangedEventArgs(Stt4GIv6AQ.Copy()));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Wusw3XEsEq(int P_0, Block P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = P_0 / 16;
		int num2 = P_0 % 16;
		if (Constants.BEDROCK_ENTITY_BLOCKS.ContainsKey(Level.Blocks[P_0].Id))
		{
			IUCwNQlpTo(JTJwzbw3Gy.TileEntities, num, JTJwzbw3Gy.Layer, num2);
		}
		JTJwzbw3Gy.Blocks[P_0].Id = P_1.Id;
		JTJwzbw3Gy.Blocks[P_0].Data = P_1.Data;
		if (Constants.BEDROCK_ENTITY_BLOCKS.ContainsKey(P_1.Id))
		{
			wcFwDXmkPV(P_1.Id, JTJwzbw3Gy.TileEntities, num, JTJwzbw3Gy.Layer, num2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ISLw1CUoMK(object P_0, MouseEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Stt4GIv6AQ = null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void vS4wE3vrP9(object P_0, MouseEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Control.ModifierKeys == Keys.Shift)
		{
			pNUw5dOtpo(P_1);
		}
		o5lwryrxki(P_1);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void o5lwryrxki(MouseEventArgs P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!jpYwC8h3ur(P_0))
		{
			Ybs4fM8VZ0.Visible = false;
			inG4i6tMu6.Visible = false;
			return;
		}
		int num = owvwJtaj8g(P_0.X, P_0.Y);
		if (num < 256)
		{
			Ybs4fM8VZ0.Visible = true;
			inG4i6tMu6.Visible = true;
			string name = BlockMaster.GetBedrockBlockState(Level.Blocks[num].Id, (short)Level.Blocks[num].Data).masterBlock.Name;
			Ybs4fM8VZ0.Text = name + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12654) + Level.Blocks[num].Data;
			inG4i6tMu6.Text = aixwuWIoeB(P_0.X, P_0.Y);
			inG4i6tMu6.Left = 554 - inG4i6tMu6.Width;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void pNUw5dOtpo(MouseEventArgs P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!jpYwC8h3ur(P_0) || Stt4GIv6AQ == null)
		{
			return;
		}
		int num = (P_0.X - 10) / 34 * 34 + 11;
		int num2 = (P_0.Y - 10) / 34 * 34 + 11;
		Point point = new Point(num, num2);
		if (Level == null)
		{
			return;
		}
		int num3 = owvwJtaj8g(P_0.X, P_0.Y);
		if (num3 < 256)
		{
			Image image = BFRL2f2UoG7tBGIHJF.xRoSMGJq48(Stt4GIv6AQ.Id, Stt4GIv6AQ.Data);
			Graphics graphics = CreateGraphics();
			Brush brush = new SolidBrush(Color.White);
			graphics.FillRectangle(brush, point.X, point.Y, 32, 32);
			if (image != null)
			{
				graphics.DrawImage(image, point);
			}
			if (Constants.BEDROCK_ENTITY_BLOCKS.ContainsKey(Level.Blocks[num3].Id))
			{
				IUCwNQlpTo(JTJwzbw3Gy.TileEntities, num / 34, JTJwzbw3Gy.Layer, num2 / 34);
			}
			Level.Blocks[num3].Id = Stt4GIv6AQ.Id;
			Level.Blocks[num3].Data = Stt4GIv6AQ.Data;
			if (Constants.BEDROCK_ENTITY_BLOCKS.ContainsKey(Stt4GIv6AQ.Id))
			{
				wcFwDXmkPV(Stt4GIv6AQ.Id, JTJwzbw3Gy.TileEntities, num / 34, JTJwzbw3Gy.Layer, num2 / 34);
			}
			OnBlockChanged(this, new BlockChangedEventArgs(Stt4GIv6AQ.Copy()));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNodeCompound t1mw6Uu3Uj(TagNodeList P_0, int P_1, int P_2, int P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_1 = dvVwo3KykM(P_1, afY44mKne0, gmww9SB7KF);
		P_3 = dvVwo3KykM(P_3, vlo4Vn36iH, f5FwICRoPW);
		return lxe7hMuSirBXGUQugsD.kxISPapgZlQ(P_0, P_1, P_2, P_3);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNodeCompound IUCwNQlpTo(TagNodeList P_0, int P_1, int P_2, int P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_1 = dvVwo3KykM(P_1, afY44mKne0, gmww9SB7KF);
		P_3 = dvVwo3KykM(P_3, vlo4Vn36iH, f5FwICRoPW);
		return lxe7hMuSirBXGUQugsD.YcASPtiwwBY(P_0, P_1, P_2, P_3);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void wcFwDXmkPV(int P_0, TagNodeList P_1, int P_2, int P_3, int P_4)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_2 = dvVwo3KykM(P_2, afY44mKne0, gmww9SB7KF);
		P_4 = dvVwo3KykM(P_4, vlo4Vn36iH, f5FwICRoPW);
		lxe7hMuSirBXGUQugsD.uOuSPX05suh(P_0, P_1, P_2, P_3, P_4, null);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void yVywcxKNvo(TagNodeCompound P_0, int P_1, int P_2, int P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_1 = dvVwo3KykM(P_1, afY44mKne0, gmww9SB7KF);
		P_3 = dvVwo3KykM(P_3, vlo4Vn36iH, f5FwICRoPW);
		lxe7hMuSirBXGUQugsD.psnSPLt4q2O(P_0, P_1, P_2, P_3);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int owvwJtaj8g(int P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_0 -= 10;
		P_1 -= 10;
		return P_1 / 34 * 16 + P_0 / 34;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string aixwuWIoeB(int P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_0 -= 10;
		P_1 -= 10;
		P_0 /= 34;
		P_1 /= 34;
		int num = dvVwo3KykM(P_0, afY44mKne0, gmww9SB7KF);
		int num2 = dvVwo3KykM(P_1, vlo4Vn36iH, f5FwICRoPW);
		return num + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11952) + JTJwzbw3Gy.Layer + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11952) + num2;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int dvVwo3KykM(int P_0, int P_1, int P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_1 + ((P_2 >= 0) ? P_0 : ((16 - P_0) * -1));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void bDDwQ7oA3I(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Ybs4fM8VZ0.Visible = false;
		inG4i6tMu6.Visible = false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Rotate(RotateType dir)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Block[] array = new Block[256];
		Block[] array2 = JTJwzbw3Gy.Blocks;
		TagNodeList tagNodeList = new TagNodeList(TagType.TAG_COMPOUND);
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < 16; i++)
		{
			for (int j = 0; j < 16; j++)
			{
				int num3 = i * 16 + j;
				if (dir == RotateType.Left)
				{
					num = j;
					num2 = 15 - i;
				}
				else
				{
					num = 15 - j;
					num2 = i;
				}
				int num4 = num * 16 + num2;
				array[num4] = array2[num3];
				if (Constants.BEDROCK_ENTITY_BLOCKS.ContainsKey(array2[num3].Id))
				{
					TagNodeCompound tagNodeCompound = IUCwNQlpTo(JTJwzbw3Gy.TileEntities, i, JTJwzbw3Gy.Layer, j);
					if (tagNodeCompound != null)
					{
						yVywcxKNvo(tagNodeCompound, num, JTJwzbw3Gy.Layer, num2);
						tagNodeList.Add(tagNodeCompound);
					}
				}
			}
		}
		JTJwzbw3Gy.Blocks = array;
		JTJwzbw3Gy.TileEntities = tagNodeList;
		Invalidate();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Flip(FlipType flipType)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = 0;
		int num2 = 0;
		TagNodeList tagNodeList = new TagNodeList(TagType.TAG_COMPOUND);
		Block[] array = new Block[256];
		Block[] array2 = JTJwzbw3Gy.Blocks;
		for (int i = 0; i < 16; i++)
		{
			for (int j = 0; j < 16; j++)
			{
				int num3 = i * 16 + j;
				if (flipType == FlipType.Vertical)
				{
					num = i;
					num2 = 15 - j;
				}
				else
				{
					num = 15 - i;
					num2 = j;
				}
				int num4 = num * 16 + num2;
				array[num4] = array2[num3];
				if (Constants.BEDROCK_ENTITY_BLOCKS.ContainsKey(array2[num3].Id))
				{
					TagNodeCompound tagNodeCompound = IUCwNQlpTo(JTJwzbw3Gy.TileEntities, i, JTJwzbw3Gy.Layer, j);
					if (tagNodeCompound != null)
					{
						yVywcxKNvo(tagNodeCompound, num, JTJwzbw3Gy.Layer, num2);
						tagNodeList.Add(tagNodeCompound);
					}
				}
			}
		}
		JTJwzbw3Gy.Blocks = array;
		JTJwzbw3Gy.TileEntities = tagNodeList;
		Invalidate();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UXWwODMRqr(MouseEventArgs P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!jpYwC8h3ur(P_0))
		{
			return;
		}
		int num = owvwJtaj8g(P_0.X, P_0.Y);
		if (num < 256)
		{
			int id = JTJwzbw3Gy.Blocks[num].Id;
			_ = JTJwzbw3Gy.Blocks[num].Data;
			if (id > 0)
			{
				lxe7hMuSirBXGUQugsD.Ec8SPM9mSqm(Constants.mapItemFrame);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool jpYwC8h3ur(MouseEventArgs P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Level != null && P_0.X >= 10 && P_0.X <= 554 && P_0.Y >= 10)
		{
			return P_0.Y <= 553;
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnBlockCopied(object sender, BlockCopiedEventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MrJ4WGbtTw?.Invoke(this, e);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnBlockChanged(object sender, BlockChangedEventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		a344p4Jy6q?.Invoke(this, e);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && KwJ4ZeRJ07 != null)
		{
			KwJ4ZeRJ07.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void rk1w7uyGF2()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Ybs4fM8VZ0 = new Label();
		inG4i6tMu6 = new Label();
		SuspendLayout();
		Ybs4fM8VZ0.AutoSize = true;
		Ybs4fM8VZ0.BorderStyle = BorderStyle.FixedSingle;
		Ybs4fM8VZ0.Location = new Point(3, 429);
		Ybs4fM8VZ0.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12660);
		Ybs4fM8VZ0.Padding = new Padding(4);
		Ybs4fM8VZ0.Size = new Size(10, 23);
		Ybs4fM8VZ0.TabIndex = 0;
		Ybs4fM8VZ0.TextAlign = ContentAlignment.MiddleLeft;
		Ybs4fM8VZ0.Visible = false;
		inG4i6tMu6.AutoSize = true;
		inG4i6tMu6.BorderStyle = BorderStyle.FixedSingle;
		inG4i6tMu6.Location = new Point(31, 429);
		inG4i6tMu6.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12688);
		inG4i6tMu6.Padding = new Padding(4);
		inG4i6tMu6.Size = new Size(10, 23);
		inG4i6tMu6.TabIndex = 1;
		inG4i6tMu6.TextAlign = ContentAlignment.MiddleRight;
		inG4i6tMu6.Visible = false;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(inG4i6tMu6);
		base.Controls.Add(Ybs4fM8VZ0);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12704);
		base.Size = new Size(457, 460);
		base.MouseDown += mobwgGoPmx;
		base.MouseLeave += bDDwQ7oA3I;
		base.MouseMove += vS4wE3vrP9;
		base.MouseUp += ISLw1CUoMK;
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
