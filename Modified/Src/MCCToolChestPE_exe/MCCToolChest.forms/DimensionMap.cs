using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using MCCToolChest.controls;
using MCCToolChest.events;
using MCCToolChest.MCSBCode.Workers;
using MCCToolChest.model;
using MCCToolChest.Properties;
using MCCToolChest.utils;
using mLQMRIMFOvpjLbxR07;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.forms;

public class DimensionMap : Form
{
	private Dictionary<MapViewType, string> xWfOV7j4U9;

	private EventHandler Cm4OWekhvU;

	private EventHandler pkNOpImBm6;

	private EventHandler CdvOZCYfOP;

	private EventHandler yxjOfJJCwJ;

	private EventHandler deLOismb2Q;

	private EventHandler T6JOsvYefH;

	private EventHandler P7bOq7kWwg;

	private EventHandler uRiOKo5eWg;

	private EventHandler LJZOh06q7p;

	private EventHandler yySOmowiMH;

	private List<DropDownItem> e6jOn0tJ7N;

	private MainForm u1UOlYveRe;

	private IContainer OxvO2JymE6;

	private MapDimension dFhOydmqhO;

	private CheckBox OKEO0IowN8;

	private ComboBox V5vOBUHAqH;

	private Button vqKOtL9dbJ;

	private ComboBox jACOapW99Q;

	private CheckBox mENOXo60T5;

	private CheckBox OuOOxBNgDF;

	private Button Bh6OewZBBq;

	private Button gmkOMBr25R;

	private CheckBox zv7OUMDyx7;

	private ListView Fp8OLxlKTt;

	private ColumnHeader psmOgiOMnY;

	private ImageList o2oOPG60mo;

	private ContextMenuStrip VaIORCYOfI;

	private ToolStripMenuItem FrFOkbumeU;

	private TextBox iYXOYxxt2U;

	private TextBox w27O3FgKhc;

	private TextBox QCkO15u8r3;

	private TextBox vS1OEletuP;

	private Button PlCOr5igS4;

	private Button zyWO54k5OX;

	private Label dUEO6jlhEN;

	private Label QFFONuUfZw;

	private Button dnqODWPbEX;

	private SplitContainer BYFOcZwDph;

	private TabControl bQEOJ4WkvB;

	private TabPage hFLOubJWmr;

	private TabPage ojLOo3Ys4O;

	private Label yTxOQi5sG9;

	private Button a1HOOkiH6F;

	private TabPage A9sOCD2NEQ;

	private Button qMhO7j5qtI;

	private Button oDpOAolrou;

	private ToolTip HrwOd75V4H;

	private TabPage bqmOHjqhnA;

	private Button Yp0OFpDVrJ;

	private IBe8LoH64FQ11CRIs2 JGaOjJQbqu;

	private CheckBox Ne6O8wpc7k;

	private GroupBox yX4O90Vwk3;

	private AreaListUI QeCOIylHnp;

	[CompilerGenerated]
	private static Func<FileInfo, DateTime> guTOzn23ab;

	public event EventHandler ChunkSelected
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = Cm4OWekhvU;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref Cm4OWekhvU, value2, eventHandler2);
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
			EventHandler eventHandler = Cm4OWekhvU;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref Cm4OWekhvU, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler ChunkDeleted
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = pkNOpImBm6;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref pkNOpImBm6, value2, eventHandler2);
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
			EventHandler eventHandler = pkNOpImBm6;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref pkNOpImBm6, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler RegionDeleted
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = CdvOZCYfOP;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref CdvOZCYfOP, value2, eventHandler2);
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
			EventHandler eventHandler = CdvOZCYfOP;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref CdvOZCYfOP, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler EditChunkBlocks
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = yxjOfJJCwJ;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref yxjOfJJCwJ, value2, eventHandler2);
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
			EventHandler eventHandler = yxjOfJJCwJ;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref yxjOfJJCwJ, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler EditChunkEntities
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = deLOismb2Q;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref deLOismb2Q, value2, eventHandler2);
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
			EventHandler eventHandler = deLOismb2Q;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref deLOismb2Q, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler EditChunkBiomes
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = T6JOsvYefH;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref T6JOsvYefH, value2, eventHandler2);
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
			EventHandler eventHandler = T6JOsvYefH;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref T6JOsvYefH, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler CopyChunk
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = P7bOq7kWwg;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref P7bOq7kWwg, value2, eventHandler2);
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
			EventHandler eventHandler = P7bOq7kWwg;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref P7bOq7kWwg, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler PasteChunk
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = uRiOKo5eWg;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref uRiOKo5eWg, value2, eventHandler2);
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
			EventHandler eventHandler = uRiOKo5eWg;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref uRiOKo5eWg, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler AreaAction
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = LJZOh06q7p;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref LJZOh06q7p, value2, eventHandler2);
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
			EventHandler eventHandler = LJZOh06q7p;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref LJZOh06q7p, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler ChangeSpawnData
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = yySOmowiMH;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref yySOmowiMH, value2, eventHandler2);
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
			EventHandler eventHandler = yySOmowiMH;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref yySOmowiMH, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DimensionMap(MainForm parentForm)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		xWfOV7j4U9 = new Dictionary<MapViewType, string>
		{
			{
				MapViewType.BlockView,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55372)
			},
			{
				MapViewType.BiomeView,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55396)
			},
			{
				MapViewType.HeightView,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55420)
			},
			{
				MapViewType.HybridView,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55446)
			}
		};
		e6jOn0tJ7N = new List<DropDownItem>();
		ypPOwXF8ZE();
		u1UOlYveRe = parentForm;
		cnGQljMDFO();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void cnGQljMDFO()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Constants.PopulateDimensionCombo(V5vOBUHAqH);
		jACOapW99Q.DataSource = new BindingSource(xWfOV7j4U9, null);
		jACOapW99Q.ValueMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10936);
		jACOapW99Q.DisplayMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11118);
		u1UOlYveRe.ChunkSelected += PddQx26CKj;
		u1UOlYveRe.ReloadMap += bf7Q0nNuNm;
		u1UOlYveRe.ReDrawMap += O8XQyjEL0D;
		OKEO0IowN8.Checked = dFhOydmqhO.ShowChunkGrid;
		Settings settings = new Settings();
		mENOXo60T5.Checked = settings.ShowRegionGrid;
		OKEO0IowN8.Checked = settings.ShowChunkGrid;
		zv7OUMDyx7.Checked = settings.ShowPlayers;
		OuOOxBNgDF.Checked = settings.ShowSearchResults;
		Ne6O8wpc7k.Checked = settings.ShowSpawn;
		PlayerPositionWorker.LoadPlayersMapData();
		HrwOd75V4H.SetToolTip(PlCOr5igS4, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55472));
		HrwOd75V4H.SetToolTip(zyWO54k5OX, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55498));
		HrwOd75V4H.SetToolTip(oDpOAolrou, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(45568));
		HrwOd75V4H.SetToolTip(qMhO7j5qtI, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55522));
		HrwOd75V4H.SetToolTip(dnqODWPbEX, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55546));
		HrwOd75V4H.SetToolTip(Yp0OFpDVrJ, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55580));
		HrwOd75V4H.SetToolTip(a1HOOkiH6F, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55614));
		Tb7Qc4fBvQ();
		KS8Q2KdFd4();
		QeCOIylHnp.LoadList();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void KS8Q2KdFd4()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<Biome> list = BiomeLookup.bedrockId.Values.ToList();
		for (int i = 0; i < list.Count; i++)
		{
			Biome biome = list[i];
			DropDownItem item = new DropDownItem(biome.BedrockId, (int)biome.Color, biome.Label);
			e6jOn0tJ7N.Add(item);
		}
		JGaOjJQbqu.ValueMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10936);
		JGaOjJQbqu.DisplayMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10946);
		JGaOjJQbqu.DataSource = e6jOn0tJ7N;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void O8XQyjEL0D(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		dFhOydmqhO.kYmmH7h3lC();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void bf7Q0nNuNm(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PlayerPositionWorker.LoadPlayersMapData();
		eXXQavmJEH();
		dFhOydmqhO.Focus();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void QGnQBEYmtN(object P_0, FormClosedEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		u1UOlYveRe.ChunkSelected -= PddQx26CKj;
		u1UOlYveRe.ReloadMap -= bf7Q0nNuNm;
		Working.mapIsOpen = false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void vCAQtIdDI9(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.Icon = Resources.usMSrbJo37S();
		Working.mapIsOpen = true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void eXXQavmJEH()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string dimension = (V5vOBUHAqH.SelectedItem as DimensionListItem)?.FolderKey;
		DimensionWorkingData dimensionData = new DimensionWorkingData(dimension, Working.T92StMGt1p4());
		dFhOydmqhO.DimensionData = dimensionData;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void pPZQX04J4N(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		OnChunkSelected(this, P_1 as ChunkSelectedEventArgs);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void PddQx26CKj(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_1 is ChunkSelectedEventArgs e)
		{
			dFhOydmqhO.SetChunkSelected(e.RX, e.RZ, e.X, e.Z, e.ChunkIndex);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void xvEQeaZRZA(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		OnChunkDeleted(this, P_1 as ChunkSelectedEventArgs);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void deMQModmIA(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		OnRegionDeleted(this, P_1 as ChunkSelectedEventArgs);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hlFQUQS8Jj(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		OnEditChunkBlocks(this, P_1 as ChunkSelectedEventArgs);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void zl7QLo8TYk(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		OnEditChunkEntities(this, P_1 as ChunkSelectedEventArgs);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void T05QgApBS1(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		OnEditChunkBiomes(this, P_1 as ChunkSelectedEventArgs);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ae3QPvr3mx(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		OnCopyChunk(this, P_1 as ChunkSelectedEventArgs);
		bQEOJ4WkvB.SelectTab(2);
		Tb7Qc4fBvQ();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void v6rQR6JUXb(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Fp8OLxlKTt.SelectedItems.Count > 0)
		{
			string path = Fp8OLxlKTt.SelectedItems[0].Tag as string;
			ChunkPastedEventArgs e = new ChunkPastedEventArgs();
			e.Path = path;
			OnPasteChunk(this, e);
		}
		else
		{
			MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55638), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55702));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YnJQkb3uCr(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		yk1QYn65rt(this, P_1 as SpawnEventArgs);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void yk1QYn65rt(object P_0, SpawnEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		yySOmowiMH?.Invoke(this, P_1);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnChunkSelected(object sender, ChunkSelectedEventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Cm4OWekhvU?.Invoke(this, e);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnChunkDeleted(object sender, ChunkSelectedEventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		pkNOpImBm6?.Invoke(this, e);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnRegionDeleted(object sender, ChunkSelectedEventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		CdvOZCYfOP?.Invoke(this, e);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnEditChunkBlocks(object sender, ChunkSelectedEventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		yxjOfJJCwJ?.Invoke(this, e);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnEditChunkEntities(object sender, ChunkSelectedEventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		deLOismb2Q?.Invoke(this, e);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnEditChunkBiomes(object sender, ChunkSelectedEventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		T6JOsvYefH?.Invoke(this, e);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnCopyChunk(object sender, ChunkSelectedEventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P7bOq7kWwg?.Invoke(this, e);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnPasteChunk(object sender, ChunkPastedEventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		uRiOKo5eWg?.Invoke(this, e);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnAreaAction(object sender, AreaActionEventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LJZOh06q7p?.Invoke(this, e);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ba6Q36qLH2(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		eXXQavmJEH();
		dFhOydmqhO.Focus();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void qViQ1ElGhT(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55730);
		string text2 = "";
		string path = Path.Combine(Working.T92StMGt1p4(), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(52810));
		if (File.Exists(path))
		{
			text2 = File.ReadAllText(path);
		}
		string text3 = FileUtils.VXKSgcyptXi(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22518), text, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55802), text2);
		if (!string.IsNullOrWhiteSpace(text3))
		{
			try
			{
				dFhOydmqhO.SaveMaps(text3);
			}
			catch (Exception ex)
			{
				MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55812) + Environment.NewLine + ex.Message, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55870));
			}
		}
		dFhOydmqhO.Focus();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SaveImage(Bitmap mapImage, string imagePath)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!string.IsNullOrWhiteSpace(imagePath))
		{
			mapImage.Save(imagePath, ImageFormat.Png);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void vu7QEKndqp(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		try
		{
			if (jACOapW99Q.SelectedValue is MapViewType)
			{
				MapViewType viewType = (MapViewType)jACOapW99Q.SelectedValue;
				dFhOydmqhO.ViewType = viewType;
			}
		}
		catch (Exception)
		{
		}
		dFhOydmqhO.Focus();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ppHQr3sKXl(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		dFhOydmqhO.ShowPlayers = zv7OUMDyx7.Checked;
		dFhOydmqhO.Focus();
		Settings.Default.ShowPlayers = zv7OUMDyx7.Checked;
		Settings.Default.Save();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void rsaQ5pC3Ll(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		dFhOydmqhO.ShowChunkGrid = OKEO0IowN8.Checked;
		dFhOydmqhO.Focus();
		Settings.Default.ShowChunkGrid = OKEO0IowN8.Checked;
		Settings.Default.Save();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void vYLQ6oqb7k(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		dFhOydmqhO.ShowRegionGrid = mENOXo60T5.Checked;
		dFhOydmqhO.Focus();
		Settings.Default.ShowRegionGrid = mENOXo60T5.Checked;
		Settings.Default.Save();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TrTQNeVUtx(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		dFhOydmqhO.ShowSearchResults = OuOOxBNgDF.Checked;
		dFhOydmqhO.Focus();
		Settings.Default.ShowSearchResults = OuOOxBNgDF.Checked;
		Settings.Default.Save();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void WeZQD6y9nP(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		dFhOydmqhO.ShowSpawn = Ne6O8wpc7k.Checked;
		dFhOydmqhO.Focus();
		Settings.Default.ShowSpawn = Ne6O8wpc7k.Checked;
		Settings.Default.Save();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Tb7Qc4fBvQ()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Fp8OLxlKTt.Items.Clear();
		string path = Utils.ChunkLibraryPath();
		Directory.GetFiles(path, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55900));
		DirectoryInfo directoryInfo = new DirectoryInfo(path);
		FileInfo[] array = directoryInfo.GetFiles().OrderByDescending([MethodImpl(MethodImplOptions.NoInlining)] (FileInfo P_0) =>
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return P_0.CreationTime;
		}).ToArray();
		FileInfo[] array2 = array;
		foreach (FileInfo fileInfo in array2)
		{
			string fullName = fileInfo.FullName;
			if (fullName.ToLower().EndsWith(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55918)))
			{
				ListViewItem listViewItem = new ListViewItem();
				listViewItem.Tag = fullName;
				listViewItem.ImageIndex = 0;
				Fp8OLxlKTt.Items.Add(listViewItem);
				string text = fullName.Replace(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55918), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55932));
				if (File.Exists(text))
				{
					Image image = NRpQJlSwAv(text);
					o2oOPG60mo.Images.Add(Path.GetFileNameWithoutExtension(fullName), image);
					listViewItem.ImageKey = Path.GetFileNameWithoutExtension(fullName);
				}
			}
		}
		TabPage selectedTab = bQEOJ4WkvB.SelectedTab;
		bQEOJ4WkvB.SelectTab(2);
		if (Fp8OLxlKTt.Items.Count > 0)
		{
			Fp8OLxlKTt.Focus();
			Fp8OLxlKTt.Select();
			Fp8OLxlKTt.Items[0].Focused = true;
			Fp8OLxlKTt.Items[0].Selected = true;
		}
		bQEOJ4WkvB.SelectTab(selectedTab);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Image NRpQJlSwAv(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] buffer = FileUtils.pURSg6Zk53A(P_0);
		MemoryStream stream = new MemoryStream(buffer);
		return Image.FromStream(stream);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void NVrQuUY7st(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void mLTQoi3bBX(object P_0, MouseEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		dFhOydmqhO.Focus();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LIKQQxpPrH(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Fp8OLxlKTt.SelectedItems.Count > 0)
		{
			o2oOPG60mo.Images.Clear();
			try
			{
				string text = Fp8OLxlKTt.SelectedItems[0].Tag as string;
				File.Delete(text);
				text = text.Replace(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55918), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55932));
				File.Delete(text);
			}
			catch (Exception)
			{
			}
			Tb7Qc4fBvQ();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void zpPQOD4QYJ(object P_0, CancelEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EaxQCy7qEb(object P_0, MouseEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ListViewItem item = Fp8OLxlKTt.HitTest(P_1.X, P_1.Y).Item;
		if (P_1.Button == MouseButtons.Right && item != null)
		{
			VaIORCYOfI.Show(Fp8OLxlKTt, new Point(P_1.X, P_1.Y));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void jY4Q7kQNfr(object P_0, KeyPressEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_1.Handled = !char.IsDigit(P_1.KeyChar) && P_1.KeyChar != '-' && P_1.KeyChar != '\b';
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void eTvQAPP8p6(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ChunkSelectedEventArgs e = P_1 as ChunkSelectedEventArgs;
		if (e.Corner == 0)
		{
			iYXOYxxt2U.Text = e.X.ToString();
			w27O3FgKhc.Text = e.Z.ToString();
		}
		else
		{
			vS1OEletuP.Text = e.X.ToString();
			QCkO15u8r3.Text = e.Z.ToString();
		}
		tyrQdTFNrx();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void tyrQdTFNrx()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int c1x = 0;
		int c1z = 0;
		int c2x = 0;
		int c2z = 0;
		if (ADpQHfiVli(out c1x, out c1z, out c2x, out c2z))
		{
			dFhOydmqhO.SetArea(c1x, c1z, c2x, c2z);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool ADpQHfiVli(out int P_0, out int P_1, out int P_2, out int P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bool result = false;
		P_0 = 0;
		P_1 = 0;
		P_2 = 0;
		P_3 = 0;
		if (int.TryParse(iYXOYxxt2U.Text.Trim(), out P_0) && int.TryParse(w27O3FgKhc.Text.Trim(), out P_1) && int.TryParse(vS1OEletuP.Text.Trim(), out P_2) && int.TryParse(QCkO15u8r3.Text.Trim(), out P_3))
		{
			if (P_0 > P_2)
			{
				int num = P_0;
				P_0 = P_2;
				P_2 = num;
			}
			if (P_1 > P_3)
			{
				int num2 = P_1;
				P_1 = P_3;
				P_3 = num2;
			}
			result = true;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FnGQFxm7FP(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		SX7Q853qjY(AreaActionType.DELETE);
		dFhOydmqhO.Focus();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void x31QjOs8Om(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		SX7Q853qjY(AreaActionType.PRUNE);
		dFhOydmqhO.Focus();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SX7Q853qjY(AreaActionType P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int x = 0;
		int z = 0;
		int x2 = 0;
		int z2 = 0;
		if (!ADpQHfiVli(out x, out z, out x2, out z2) && P_0 != AreaActionType.AREAFILL)
		{
			return;
		}
		AreaActionEventArgs e = new AreaActionEventArgs(0, x, z, x2, z2, P_0);
		e.Dimension = (V5vOBUHAqH.SelectedItem as DimensionListItem)?.DimensionId ?? V5vOBUHAqH.SelectedIndex;
		switch (P_0)
		{
		case AreaActionType.CHUNKFILL:
		{
			string text = gOHQ9YVSXk();
			if (text != null)
			{
				e.Path = text;
				break;
			}
			MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55942), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(56016));
			return;
		}
		case AreaActionType.BIOMEFILL:
			if (JGaOjJQbqu.SelectedValue != null)
			{
				int.TryParse(JGaOjJQbqu.SelectedValue.ToString(), out var result);
				e.Biome = result;
				break;
			}
			MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(56054), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(56128));
			return;
		case AreaActionType.AREACOPY:
		{
			TextEntry textEntry = new TextEntry(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(56166));
			if (textEntry.ShowDialog(this) == DialogResult.OK)
			{
				string entryValue = textEntry.EntryValue;
				if (string.IsNullOrWhiteSpace(entryValue))
				{
					return;
				}
				e.AreaName = entryValue;
			}
			break;
		}
		case AreaActionType.AREAFILL:
		{
			AreaItemUI areaItemUI = QeCOIylHnp.D21G7RedUP();
			if (areaItemUI != null)
			{
				Tuple<int, int> selectedChunk = dFhOydmqhO.GetSelectedChunk();
				e.Path = areaItemUI.Tag as string;
				e.X1 = selectedChunk.Item1;
				e.Z1 = selectedChunk.Item2;
				e.X2 = e.X1 + areaItemUI.AreaAttributes.width - 1;
				e.Z2 = e.Z1 + areaItemUI.AreaAttributes.height - 1;
				e.Rotation = QeCOIylHnp.Rotation;
				e.FlipTopToBottom = QeCOIylHnp.FlipTopToBottom;
				e.FlipLeftToRight = QeCOIylHnp.FlipLeftToRight;
				e.YOffset = QeCOIylHnp.YOffset;
				break;
			}
			MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(56188), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(56234));
			return;
		}
		}
		OnAreaAction(this, e);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string gOHQ9YVSXk()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string result = null;
		if (Fp8OLxlKTt.SelectedItems.Count > 0)
		{
			result = Fp8OLxlKTt.SelectedItems[0].Tag as string;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void vvEQIbNqGK(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		iYXOYxxt2U.Text = "";
		w27O3FgKhc.Text = "";
		vS1OEletuP.Text = "";
		QCkO15u8r3.Text = "";
		dFhOydmqhO.AreaMask = null;
		dFhOydmqhO.ClearArea();
		QeCOIylHnp.LQwGAg1RKq();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void eEuQzh2OeU(object P_0, KeyEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		tyrQdTFNrx();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void iUOOTDtxY1(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		SX7Q853qjY(AreaActionType.CHUNKFILL);
		dFhOydmqhO.Focus();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void pflOSr7NdN(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		SX7Q853qjY(AreaActionType.BIOMEFILL);
		dFhOydmqhO.Focus();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void VViOGDvBwD(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		SX7Q853qjY(AreaActionType.AREAFILL);
		dFhOydmqhO.Focus();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void VhQObm9cnf(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		SX7Q853qjY(AreaActionType.AREACOPY);
		dFhOydmqhO.Focus();
		QeCOIylHnp.LoadList();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void npyOvbAKKG(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		AreaActiveEventArgs e = P_1 as AreaActiveEventArgs;
		string text = Path.Combine(e.Path, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10076));
		if (!File.Exists(text))
		{
			return;
		}
		byte[] buffer = FileUtils.pURSg6Zk53A(text);
		Bitmap bitmap;
		using (MemoryStream stream = new MemoryStream(buffer))
		{
			bitmap = new Bitmap(stream);
		}
		if (QeCOIylHnp.Rotation != 0)
		{
			RotateFlipType rotateFlipType = RotateFlipType.Rotate180FlipNone;
			if (QeCOIylHnp.Rotation == -90 || QeCOIylHnp.Rotation == 270)
			{
				rotateFlipType = RotateFlipType.Rotate270FlipNone;
			}
			if (QeCOIylHnp.Rotation == 90 || QeCOIylHnp.Rotation == -270)
			{
				rotateFlipType = RotateFlipType.Rotate90FlipNone;
			}
			bitmap.RotateFlip(rotateFlipType);
		}
		if (QeCOIylHnp.FlipTopToBottom)
		{
			bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
		}
		if (QeCOIylHnp.FlipLeftToRight)
		{
			bitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);
		}
		dFhOydmqhO.AreaMask = bitmap;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && OxvO2JymE6 != null)
		{
			OxvO2JymE6.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ypPOwXF8ZE()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		OxvO2JymE6 = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(DimensionMap));
		VaIORCYOfI = new ContextMenuStrip(OxvO2JymE6);
		FrFOkbumeU = new ToolStripMenuItem();
		o2oOPG60mo = new ImageList(OxvO2JymE6);
		HrwOd75V4H = new ToolTip(OxvO2JymE6);
		BYFOcZwDph = new SplitContainer();
		yX4O90Vwk3 = new GroupBox();
		Yp0OFpDVrJ = new Button();
		zyWO54k5OX = new Button();
		PlCOr5igS4 = new Button();
		qMhO7j5qtI = new Button();
		dUEO6jlhEN = new Label();
		oDpOAolrou = new Button();
		QCkO15u8r3 = new TextBox();
		a1HOOkiH6F = new Button();
		vS1OEletuP = new TextBox();
		yTxOQi5sG9 = new Label();
		QFFONuUfZw = new Label();
		w27O3FgKhc = new TextBox();
		dnqODWPbEX = new Button();
		iYXOYxxt2U = new TextBox();
		bQEOJ4WkvB = new TabControl();
		hFLOubJWmr = new TabPage();
		Ne6O8wpc7k = new CheckBox();
		V5vOBUHAqH = new ComboBox();
		OKEO0IowN8 = new CheckBox();
		vqKOtL9dbJ = new Button();
		jACOapW99Q = new ComboBox();
		mENOXo60T5 = new CheckBox();
		OuOOxBNgDF = new CheckBox();
		Bh6OewZBBq = new Button();
		gmkOMBr25R = new Button();
		zv7OUMDyx7 = new CheckBox();
		A9sOCD2NEQ = new TabPage();
		ojLOo3Ys4O = new TabPage();
		Fp8OLxlKTt = new ListView();
		psmOgiOMnY = new ColumnHeader();
		bqmOHjqhnA = new TabPage();
		dFhOydmqhO = new MapDimension();
		QeCOIylHnp = new AreaListUI();
		JGaOjJQbqu = new IBe8LoH64FQ11CRIs2();
		VaIORCYOfI.SuspendLayout();
		((ISupportInitialize)BYFOcZwDph).BeginInit();
		BYFOcZwDph.Panel1.SuspendLayout();
		BYFOcZwDph.Panel2.SuspendLayout();
		BYFOcZwDph.SuspendLayout();
		yX4O90Vwk3.SuspendLayout();
		bQEOJ4WkvB.SuspendLayout();
		hFLOubJWmr.SuspendLayout();
		A9sOCD2NEQ.SuspendLayout();
		ojLOo3Ys4O.SuspendLayout();
		bqmOHjqhnA.SuspendLayout();
		SuspendLayout();
		VaIORCYOfI.Items.AddRange(new ToolStripItem[1] { FrFOkbumeU });
		VaIORCYOfI.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10238);
		VaIORCYOfI.Size = new Size(108, 26);
		VaIORCYOfI.Opening += zpPQOD4QYJ;
		FrFOkbumeU.Image = Resources.fmvS1uvOW2l();
		FrFOkbumeU.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10280);
		FrFOkbumeU.Size = new Size(107, 22);
		FrFOkbumeU.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10326);
		FrFOkbumeU.Click += LIKQQxpPrH;
		o2oOPG60mo.ImageStream = (ImageListStreamer)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(56260));
		o2oOPG60mo.TransparentColor = Color.Transparent;
		o2oOPG60mo.Images.SetKeyName(0, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(56314));
		BYFOcZwDph.Dock = DockStyle.Fill;
		BYFOcZwDph.FixedPanel = FixedPanel.Panel2;
		BYFOcZwDph.Location = new Point(0, 0);
		BYFOcZwDph.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13750);
		BYFOcZwDph.Panel1.Controls.Add(dFhOydmqhO);
		BYFOcZwDph.Panel2.Controls.Add(yX4O90Vwk3);
		BYFOcZwDph.Panel2.Controls.Add(bQEOJ4WkvB);
		BYFOcZwDph.Size = new Size(1160, 675);
		BYFOcZwDph.SplitterDistance = 917;
		BYFOcZwDph.TabIndex = 29;
		yX4O90Vwk3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		yX4O90Vwk3.Controls.Add(Yp0OFpDVrJ);
		yX4O90Vwk3.Controls.Add(zyWO54k5OX);
		yX4O90Vwk3.Controls.Add(PlCOr5igS4);
		yX4O90Vwk3.Controls.Add(qMhO7j5qtI);
		yX4O90Vwk3.Controls.Add(dUEO6jlhEN);
		yX4O90Vwk3.Controls.Add(oDpOAolrou);
		yX4O90Vwk3.Controls.Add(QCkO15u8r3);
		yX4O90Vwk3.Controls.Add(a1HOOkiH6F);
		yX4O90Vwk3.Controls.Add(vS1OEletuP);
		yX4O90Vwk3.Controls.Add(yTxOQi5sG9);
		yX4O90Vwk3.Controls.Add(QFFONuUfZw);
		yX4O90Vwk3.Controls.Add(w27O3FgKhc);
		yX4O90Vwk3.Controls.Add(dnqODWPbEX);
		yX4O90Vwk3.Controls.Add(iYXOYxxt2U);
		yX4O90Vwk3.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
		yX4O90Vwk3.Location = new Point(4, 545);
		yX4O90Vwk3.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41880);
		yX4O90Vwk3.Size = new Size(232, 126);
		yX4O90Vwk3.TabIndex = 35;
		yX4O90Vwk3.TabStop = false;
		yX4O90Vwk3.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(56336);
		Yp0OFpDVrJ.BackgroundImage = Resources.A9mS3jXcE7Q();
		Yp0OFpDVrJ.BackgroundImageLayout = ImageLayout.Zoom;
		Yp0OFpDVrJ.Location = new Point(189, 86);
		Yp0OFpDVrJ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(56348);
		Yp0OFpDVrJ.Size = new Size(32, 32);
		Yp0OFpDVrJ.TabIndex = 33;
		Yp0OFpDVrJ.UseVisualStyleBackColor = true;
		Yp0OFpDVrJ.Click += pflOSr7NdN;
		zyWO54k5OX.BackgroundImage = Resources.zYTS1wnTUXu();
		zyWO54k5OX.BackgroundImageLayout = ImageLayout.Stretch;
		zyWO54k5OX.Location = new Point(189, 16);
		zyWO54k5OX.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(45630);
		zyWO54k5OX.Size = new Size(32, 32);
		zyWO54k5OX.TabIndex = 25;
		zyWO54k5OX.UseVisualStyleBackColor = true;
		zyWO54k5OX.Click += x31QjOs8Om;
		zyWO54k5OX.KeyPress += jY4Q7kQNfr;
		PlCOr5igS4.BackgroundImage = Resources.bj4S1Snacsq();
		PlCOr5igS4.BackgroundImageLayout = ImageLayout.Zoom;
		PlCOr5igS4.Location = new Point(151, 16);
		PlCOr5igS4.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(45672);
		PlCOr5igS4.Size = new Size(32, 32);
		PlCOr5igS4.TabIndex = 24;
		PlCOr5igS4.UseVisualStyleBackColor = true;
		PlCOr5igS4.Click += FnGQFxm7FP;
		qMhO7j5qtI.BackgroundImage = Resources.o98S1bndyAo();
		qMhO7j5qtI.BackgroundImageLayout = ImageLayout.Zoom;
		qMhO7j5qtI.Location = new Point(189, 51);
		qMhO7j5qtI.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(56384);
		qMhO7j5qtI.Size = new Size(32, 32);
		qMhO7j5qtI.TabIndex = 31;
		qMhO7j5qtI.UseVisualStyleBackColor = true;
		qMhO7j5qtI.Click += VViOGDvBwD;
		dUEO6jlhEN.AutoSize = true;
		dUEO6jlhEN.Location = new Point(13, 43);
		dUEO6jlhEN.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		dUEO6jlhEN.Size = new Size(17, 17);
		dUEO6jlhEN.TabIndex = 26;
		dUEO6jlhEN.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(45624);
		oDpOAolrou.BackgroundImage = Resources.wIPS3zd2Rrp();
		oDpOAolrou.BackgroundImageLayout = ImageLayout.Stretch;
		oDpOAolrou.Location = new Point(151, 51);
		oDpOAolrou.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(56410);
		oDpOAolrou.Size = new Size(32, 32);
		oDpOAolrou.TabIndex = 32;
		oDpOAolrou.UseVisualStyleBackColor = true;
		oDpOAolrou.Click += VhQObm9cnf;
		QCkO15u8r3.Location = new Point(83, 63);
		QCkO15u8r3.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(45702);
		QCkO15u8r3.Size = new Size(46, 23);
		QCkO15u8r3.TabIndex = 23;
		QCkO15u8r3.KeyPress += jY4Q7kQNfr;
		QCkO15u8r3.KeyUp += eEuQzh2OeU;
		a1HOOkiH6F.BackgroundImage = Resources.QvlSEusB3qR();
		a1HOOkiH6F.BackgroundImageLayout = ImageLayout.Zoom;
		a1HOOkiH6F.Location = new Point(31, 89);
		a1HOOkiH6F.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(45590);
		a1HOOkiH6F.Size = new Size(32, 32);
		a1HOOkiH6F.TabIndex = 30;
		a1HOOkiH6F.UseVisualStyleBackColor = true;
		a1HOOkiH6F.Click += vvEQIbNqGK;
		vS1OEletuP.Location = new Point(83, 39);
		vS1OEletuP.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(45728);
		vS1OEletuP.Size = new Size(46, 23);
		vS1OEletuP.TabIndex = 22;
		vS1OEletuP.KeyPress += jY4Q7kQNfr;
		vS1OEletuP.KeyUp += eEuQzh2OeU;
		yTxOQi5sG9.AutoSize = true;
		yTxOQi5sG9.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 9.5f, FontStyle.Regular, GraphicsUnit.Point, 0);
		yTxOQi5sG9.Location = new Point(12, 21);
		yTxOQi5sG9.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10482);
		yTxOQi5sG9.Size = new Size(121, 16);
		yTxOQi5sG9.TabIndex = 29;
		yTxOQi5sG9.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(56436);
		QFFONuUfZw.AutoSize = true;
		QFFONuUfZw.Location = new Point(12, 68);
		QFFONuUfZw.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10582);
		QFFONuUfZw.Size = new Size(17, 17);
		QFFONuUfZw.TabIndex = 27;
		QFFONuUfZw.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(45618);
		w27O3FgKhc.Location = new Point(31, 63);
		w27O3FgKhc.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(45754);
		w27O3FgKhc.Size = new Size(46, 23);
		w27O3FgKhc.TabIndex = 21;
		w27O3FgKhc.KeyPress += jY4Q7kQNfr;
		w27O3FgKhc.KeyUp += eEuQzh2OeU;
		dnqODWPbEX.BackgroundImage = Resources.i8ZS399u47i();
		dnqODWPbEX.BackgroundImageLayout = ImageLayout.Zoom;
		dnqODWPbEX.Location = new Point(151, 86);
		dnqODWPbEX.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(56474);
		dnqODWPbEX.Size = new Size(32, 32);
		dnqODWPbEX.TabIndex = 28;
		dnqODWPbEX.UseVisualStyleBackColor = true;
		dnqODWPbEX.Click += iUOOTDtxY1;
		iYXOYxxt2U.Location = new Point(31, 39);
		iYXOYxxt2U.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(45780);
		iYXOYxxt2U.Size = new Size(46, 23);
		iYXOYxxt2U.TabIndex = 20;
		iYXOYxxt2U.KeyPress += jY4Q7kQNfr;
		iYXOYxxt2U.KeyUp += eEuQzh2OeU;
		bQEOJ4WkvB.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		bQEOJ4WkvB.Controls.Add(hFLOubJWmr);
		bQEOJ4WkvB.Controls.Add(A9sOCD2NEQ);
		bQEOJ4WkvB.Controls.Add(ojLOo3Ys4O);
		bQEOJ4WkvB.Controls.Add(bqmOHjqhnA);
		bQEOJ4WkvB.Location = new Point(0, 4);
		bQEOJ4WkvB.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(56510);
		bQEOJ4WkvB.SelectedIndex = 0;
		bQEOJ4WkvB.Size = new Size(236, 535);
		bQEOJ4WkvB.TabIndex = 0;
		hFLOubJWmr.Controls.Add(Ne6O8wpc7k);
		hFLOubJWmr.Controls.Add(V5vOBUHAqH);
		hFLOubJWmr.Controls.Add(OKEO0IowN8);
		hFLOubJWmr.Controls.Add(vqKOtL9dbJ);
		hFLOubJWmr.Controls.Add(jACOapW99Q);
		hFLOubJWmr.Controls.Add(mENOXo60T5);
		hFLOubJWmr.Controls.Add(OuOOxBNgDF);
		hFLOubJWmr.Controls.Add(Bh6OewZBBq);
		hFLOubJWmr.Controls.Add(gmkOMBr25R);
		hFLOubJWmr.Controls.Add(zv7OUMDyx7);
		hFLOubJWmr.Location = new Point(4, 22);
		hFLOubJWmr.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(56536);
		hFLOubJWmr.Padding = new Padding(3);
		hFLOubJWmr.Size = new Size(228, 509);
		hFLOubJWmr.TabIndex = 0;
		hFLOubJWmr.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(56556);
		hFLOubJWmr.UseVisualStyleBackColor = true;
		Ne6O8wpc7k.AutoSize = true;
		Ne6O8wpc7k.Location = new Point(19, 79);
		Ne6O8wpc7k.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(56566);
		Ne6O8wpc7k.Size = new Size(89, 17);
		Ne6O8wpc7k.TabIndex = 19;
		Ne6O8wpc7k.TabStop = false;
		Ne6O8wpc7k.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(56592);
		Ne6O8wpc7k.UseVisualStyleBackColor = true;
		Ne6O8wpc7k.CheckedChanged += WeZQD6y9nP;
		V5vOBUHAqH.DropDownStyle = ComboBoxStyle.DropDownList;
		V5vOBUHAqH.FormattingEnabled = true;
		V5vOBUHAqH.Location = new Point(17, 18);
		V5vOBUHAqH.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37176);
		V5vOBUHAqH.Size = new Size(118, 21);
		V5vOBUHAqH.TabIndex = 5;
		V5vOBUHAqH.TabStop = false;
		V5vOBUHAqH.SelectedIndexChanged += ba6Q36qLH2;
		OKEO0IowN8.AutoSize = true;
		OKEO0IowN8.Location = new Point(19, 125);
		OKEO0IowN8.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(56616);
		OKEO0IowN8.Size = new Size(109, 17);
		OKEO0IowN8.TabIndex = 1;
		OKEO0IowN8.TabStop = false;
		OKEO0IowN8.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(56640);
		OKEO0IowN8.UseVisualStyleBackColor = true;
		OKEO0IowN8.CheckedChanged += rsaQ5pC3Ll;
		vqKOtL9dbJ.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(56674));
		vqKOtL9dbJ.Location = new Point(57, 201);
		vqKOtL9dbJ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(56718);
		vqKOtL9dbJ.Size = new Size(38, 38);
		vqKOtL9dbJ.TabIndex = 7;
		vqKOtL9dbJ.TabStop = false;
		vqKOtL9dbJ.UseVisualStyleBackColor = true;
		vqKOtL9dbJ.Click += bf7Q0nNuNm;
		jACOapW99Q.DropDownStyle = ComboBoxStyle.DropDownList;
		jACOapW99Q.FormattingEnabled = true;
		jACOapW99Q.Location = new Point(17, 45);
		jACOapW99Q.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(56750);
		jACOapW99Q.Size = new Size(118, 21);
		jACOapW99Q.TabIndex = 8;
		jACOapW99Q.TabStop = false;
		jACOapW99Q.SelectedIndexChanged += vu7QEKndqp;
		mENOXo60T5.AutoSize = true;
		mENOXo60T5.Location = new Point(19, 148);
		mENOXo60T5.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(56774);
		mENOXo60T5.Size = new Size(112, 17);
		mENOXo60T5.TabIndex = 9;
		mENOXo60T5.TabStop = false;
		mENOXo60T5.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(56810);
		mENOXo60T5.UseVisualStyleBackColor = true;
		mENOXo60T5.CheckedChanged += vYLQ6oqb7k;
		OuOOxBNgDF.AutoSize = true;
		OuOOxBNgDF.Location = new Point(19, 171);
		OuOOxBNgDF.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(56846);
		OuOOxBNgDF.Size = new Size(128, 17);
		OuOOxBNgDF.TabIndex = 14;
		OuOOxBNgDF.TabStop = false;
		OuOOxBNgDF.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(56888);
		OuOOxBNgDF.UseVisualStyleBackColor = true;
		OuOOxBNgDF.CheckedChanged += TrTQNeVUtx;
		Bh6OewZBBq.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(56930));
		Bh6OewZBBq.Location = new Point(99, 201);
		Bh6OewZBBq.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(56960);
		Bh6OewZBBq.Size = new Size(38, 38);
		Bh6OewZBBq.TabIndex = 16;
		Bh6OewZBBq.TabStop = false;
		Bh6OewZBBq.UseVisualStyleBackColor = true;
		Bh6OewZBBq.Click += qViQ1ElGhT;
		gmkOMBr25R.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(56978));
		gmkOMBr25R.Location = new Point(15, 201);
		gmkOMBr25R.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57008);
		gmkOMBr25R.Size = new Size(38, 38);
		gmkOMBr25R.TabIndex = 17;
		gmkOMBr25R.TabStop = false;
		gmkOMBr25R.UseVisualStyleBackColor = true;
		zv7OUMDyx7.AutoSize = true;
		zv7OUMDyx7.Location = new Point(19, 102);
		zv7OUMDyx7.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57026);
		zv7OUMDyx7.Size = new Size(90, 17);
		zv7OUMDyx7.TabIndex = 18;
		zv7OUMDyx7.TabStop = false;
		zv7OUMDyx7.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57056);
		zv7OUMDyx7.UseVisualStyleBackColor = true;
		zv7OUMDyx7.CheckedChanged += ppHQr3sKXl;
		A9sOCD2NEQ.Controls.Add(QeCOIylHnp);
		A9sOCD2NEQ.Location = new Point(4, 22);
		A9sOCD2NEQ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15898);
		A9sOCD2NEQ.Size = new Size(228, 509);
		A9sOCD2NEQ.TabIndex = 2;
		A9sOCD2NEQ.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57084);
		A9sOCD2NEQ.UseVisualStyleBackColor = true;
		ojLOo3Ys4O.Controls.Add(Fp8OLxlKTt);
		ojLOo3Ys4O.Location = new Point(4, 22);
		ojLOo3Ys4O.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57098);
		ojLOo3Ys4O.Padding = new Padding(3);
		ojLOo3Ys4O.Size = new Size(228, 509);
		ojLOo3Ys4O.TabIndex = 1;
		ojLOo3Ys4O.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57118);
		ojLOo3Ys4O.UseVisualStyleBackColor = true;
		Fp8OLxlKTt.BackColor = SystemColors.Control;
		Fp8OLxlKTt.Columns.AddRange(new ColumnHeader[1] { psmOgiOMnY });
		Fp8OLxlKTt.ContextMenuStrip = VaIORCYOfI;
		Fp8OLxlKTt.Dock = DockStyle.Fill;
		Fp8OLxlKTt.HideSelection = false;
		Fp8OLxlKTt.LargeImageList = o2oOPG60mo;
		Fp8OLxlKTt.Location = new Point(3, 3);
		Fp8OLxlKTt.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57134);
		Fp8OLxlKTt.Size = new Size(222, 503);
		Fp8OLxlKTt.TabIndex = 19;
		Fp8OLxlKTt.UseCompatibleStateImageBehavior = false;
		Fp8OLxlKTt.SelectedIndexChanged += NVrQuUY7st;
		Fp8OLxlKTt.MouseDown += EaxQCy7qEb;
		Fp8OLxlKTt.MouseUp += mLTQoi3bBX;
		psmOgiOMnY.Width = 120;
		bqmOHjqhnA.Controls.Add(JGaOjJQbqu);
		bqmOHjqhnA.Location = new Point(4, 22);
		bqmOHjqhnA.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57162);
		bqmOHjqhnA.Size = new Size(228, 509);
		bqmOHjqhnA.TabIndex = 3;
		bqmOHjqhnA.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41992);
		bqmOHjqhnA.UseVisualStyleBackColor = true;
		dFhOydmqhO.BorderStyle = BorderStyle.FixedSingle;
		dFhOydmqhO.ChunkEntries = null;
		dFhOydmqhO.DimensionData = null;
		dFhOydmqhO.Dock = DockStyle.Fill;
		dFhOydmqhO.Location = new Point(0, 0);
		dFhOydmqhO.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57182);
		dFhOydmqhO.ShowChunkGrid = false;
		dFhOydmqhO.ShowPlayers = false;
		dFhOydmqhO.ShowRegionGrid = false;
		dFhOydmqhO.ShowSearchResults = false;
		dFhOydmqhO.ShowSpawn = false;
		dFhOydmqhO.Size = new Size(917, 675);
		dFhOydmqhO.TabIndex = 0;
		dFhOydmqhO.ViewType = MapViewType.BlockView;
		dFhOydmqhO.ChunkSelected += pPZQX04J4N;
		dFhOydmqhO.ChunkDeleted += xvEQeaZRZA;
		dFhOydmqhO.RegionDeleted += deMQModmIA;
		dFhOydmqhO.EditChunkBlocks += hlFQUQS8Jj;
		dFhOydmqhO.EditChunkBiomes += T05QgApBS1;
		dFhOydmqhO.EditChunkEntities += zl7QLo8TYk;
		dFhOydmqhO.CopyChunk += ae3QPvr3mx;
		dFhOydmqhO.PasteChunk += v6rQR6JUXb;
		dFhOydmqhO.ChunkCornerSelected += eTvQAPP8p6;
		dFhOydmqhO.ChangeSpawnData += YnJQkb3uCr;
		QeCOIylHnp.Dock = DockStyle.Fill;
		QeCOIylHnp.Location = new Point(0, 0);
		QeCOIylHnp.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57212);
		QeCOIylHnp.Size = new Size(228, 509);
		QeCOIylHnp.TabIndex = 0;
		QeCOIylHnp.AreaItemActive += npyOvbAKKG;
		JGaOjJQbqu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		JGaOjJQbqu.DrawMode = DrawMode.OwnerDrawFixed;
		JGaOjJQbqu.DropDownStyle = ComboBoxStyle.DropDownList;
		JGaOjJQbqu.FormattingEnabled = true;
		JGaOjJQbqu.Location = new Point(16, 22);
		JGaOjJQbqu.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10958);
		JGaOjJQbqu.Size = new Size(184, 21);
		JGaOjJQbqu.TabIndex = 4;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(1160, 675);
		base.Controls.Add(BYFOcZwDph);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57238);
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57266);
		base.FormClosed += QGnQBEYmtN;
		base.Load += vCAQtIdDI9;
		VaIORCYOfI.ResumeLayout(performLayout: false);
		BYFOcZwDph.Panel1.ResumeLayout(performLayout: false);
		BYFOcZwDph.Panel2.ResumeLayout(performLayout: false);
		((ISupportInitialize)BYFOcZwDph).EndInit();
		BYFOcZwDph.ResumeLayout(performLayout: false);
		yX4O90Vwk3.ResumeLayout(performLayout: false);
		yX4O90Vwk3.PerformLayout();
		bQEOJ4WkvB.ResumeLayout(performLayout: false);
		hFLOubJWmr.ResumeLayout(performLayout: false);
		hFLOubJWmr.PerformLayout();
		A9sOCD2NEQ.ResumeLayout(performLayout: false);
		ojLOo3Ys4O.ResumeLayout(performLayout: false);
		bqmOHjqhnA.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static DateTime ux3O4MvCHD(FileInfo P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0.CreationTime;
	}
}
