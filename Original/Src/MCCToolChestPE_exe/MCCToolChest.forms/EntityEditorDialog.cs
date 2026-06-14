using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using afNMf7uWOyq6L7IHxiu;
using MCCToolChest.controls;
using MCCToolChest.model;
using MCCToolChest.Properties;
using MCCToolChest.workers;
using MCCToolChestDB.Model;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.forms;

public class EntityEditorDialog : Form
{
	private int LGxuYyhnAa;

	private int yPtu3ntNKg;

	private List<ChunkYLayer> gPgu15Tfve;

	private IContainer M8CuEcFlsa;

	private EntityEditor L6gur4mPM4;

	private MenuStrip gubu5CumBi;

	private ToolStripMenuItem s6Gu6eQXs4;

	public TagNodeList TileEntities
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return L6gur4mPM4.TileEntities;
		}
	}

	public TagNodeList Entities
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return L6gur4mPM4.Entities;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EntityEditorDialog(TagNodeList sections, TagNodeList entities, TagNodeList tileEntities, int chunkX, int chunkZ)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		JWiuk3dNI7();
		L6gur4mPM4.Entities = entities;
		L6gur4mPM4.TileEntities = tileEntities;
		L6gur4mPM4.ChunkX = chunkX;
		L6gur4mPM4.ChunkZ = chunkZ;
		LGxuYyhnAa = chunkX;
		yPtu3ntNKg = chunkZ;
		ExtractLayerWorker extractLayerWorker = new ExtractLayerWorker();
		gPgu15Tfve = extractLayerWorker.ExtractLayers(sections);
		L6gur4mPM4.Layers = gPgu15Tfve;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void z9ZueaZgow(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.Icon = Resources.usMSrbJo37S();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void lwfuMtWC9W(object P_0, FormClosingEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		L6gur4mPM4.kngWhtAtHF();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void KOPuUmZFEC(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LibraryItemCloud libraryItemCloud = new LibraryItemCloud();
		DialogResult dialogResult = libraryItemCloud.ShowDialog(this);
		if (dialogResult != DialogResult.OK)
		{
			return;
		}
		NBTLibraryItem libraryItem = libraryItemCloud.LibraryItem;
		if (libraryItem != null)
		{
			string nBTString = libraryItem.NBTString;
			TagNodeCompound tagNodeCompound = (TagNodeCompound)lxe7hMuSirBXGUQugsD.v4fSPe0WJtV(nBTString);
			if (MMXuLP6cDP(tagNodeCompound))
			{
				L6gur4mPM4.AddEntity(tagNodeCompound, (!(libraryItem.EntityType.ToLower() == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(53968))) ? EntityType.TileEntity : EntityType.Entity);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool MMXuLP6cDP(TagNodeCompound P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bool flag = true;
		T74ug63jPd(P_0);
		deMuPPdoWQ(P_0);
		EntityPositionEntry entityPositionEntry = new EntityPositionEntry(P_0, gPgu15Tfve, LGxuYyhnAa, yPtu3ntNKg);
		return entityPositionEntry.ShowDialog(this) == DialogResult.OK;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void T74ug63jPd(TagNodeCompound P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeList tagNodeList = P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17418)] as TagNodeList;
		int num = P7juRu6Anu(LGxuYyhnAa);
		int num2 = P7juRu6Anu(yPtu3ntNKg);
		num = ((num < 0) ? (num + -8) : (num + 8));
		num2 = ((num2 < 0) ? (num2 + -8) : (num2 + 8));
		tagNodeList[0] = new TagNodeFloat(num);
		tagNodeList[1] = new TagNodeFloat(0f);
		tagNodeList[2] = new TagNodeFloat(num2);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void deMuPPdoWQ(TagNodeCompound P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Random rng = new Random();
		long num = rng.NextLong(long.MinValue, long.MaxValue);
		if (num > 0)
		{
			num *= -1;
		}
		P_0[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(27938)] = new TagNodeLong(num);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int P7juRu6Anu(int P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0 * 16;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && M8CuEcFlsa != null)
		{
			M8CuEcFlsa.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void JWiuk3dNI7()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		gubu5CumBi = new MenuStrip();
		s6Gu6eQXs4 = new ToolStripMenuItem();
		L6gur4mPM4 = new EntityEditor();
		gubu5CumBi.SuspendLayout();
		SuspendLayout();
		gubu5CumBi.Items.AddRange(new ToolStripItem[1] { s6Gu6eQXs4 });
		gubu5CumBi.Location = new Point(0, 0);
		gubu5CumBi.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26656);
		gubu5CumBi.Size = new Size(982, 24);
		gubu5CumBi.TabIndex = 1;
		gubu5CumBi.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26656);
		s6Gu6eQXs4.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28918);
		s6Gu6eQXs4.Size = new Size(41, 20);
		s6Gu6eQXs4.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28934);
		s6Gu6eQXs4.Click += KOPuUmZFEC;
		L6gur4mPM4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		L6gur4mPM4.ChunkX = 0;
		L6gur4mPM4.ChunkZ = 0;
		L6gur4mPM4.Entities = null;
		L6gur4mPM4.Layers = null;
		L6gur4mPM4.Location = new Point(0, 27);
		L6gur4mPM4.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(53984);
		L6gur4mPM4.Size = new Size(982, 602);
		L6gur4mPM4.TabIndex = 0;
		L6gur4mPM4.TileEntities = null;
		L6gur4mPM4.Load += z9ZueaZgow;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(982, 629);
		base.Controls.Add(L6gur4mPM4);
		base.Controls.Add(gubu5CumBi);
		base.MainMenuStrip = gubu5CumBi;
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(54014);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(54054);
		base.FormClosing += lwfuMtWC9W;
		gubu5CumBi.ResumeLayout(performLayout: false);
		gubu5CumBi.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
