using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using afNMf7uWOyq6L7IHxiu;
using HiT3kduFNLtRQIR37JV;
using MCCToolChest.controllers;
using MCCToolChest.events;
using MCCToolChest.forms;
using MCCToolChest.MCSBCode;
using MCCToolChest.MCSBCode.Workers;
using MCCToolChest.model;
using MCCToolChest.PECode;
using MCCToolChest.Properties;
using MCCToolChest.utils;
using MCCToolChest.workers;
using MCPELevelDBI.workers;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using uP7B13T5waxVpI3AEv;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls;

public class MapDimension : UserControl
{
	private System.Timers.Timer gW7niNtgst;

	private static ImageList wEDnsPTFJo;

	private static ImageList vtonqMSbN7;

	private static Dictionary<string, int> RFvnKBLMux;

	private Color UxvnhwqMEx;

	private Color xmKnmWoeDk;

	private MapViewType AbFnnq6xay;

	private EntityLookup SJrnl3gexc;

	private bool BqSn2ymZOF;

	private bool hcgnyj1x7b;

	private bool wPkn0SrOgC;

	private bool BSQnBGjeQ8;

	private bool JAEntCB4I0;

	private bool fpSnaYKJen;

	private bool xJOnXg74AZ;

	private int Jg6nxJutRc;

	private int MkBneOKucn;

	private int MF1nM2uDIJ;

	private int J2XnUuXe9g;

	private int BWnnLf32jl;

	private int oOAngbPE3R;

	private bool c3NnPCqkiN;

	private int V5TnRVL54n;

	private int wtfnk96inq;

	private int YD9nY1X0kC;

	private Bitmap oJ3n3RPjDa;

	private Image[] WA6n1nqDbR;

	private int N5fnEB7nwK;

	private int xRVnrsCVbQ;

	private int K4Wn53Pf87;

	private int O2Vn6n70JJ;

	private int KxanNOIpJw;

	private int dhAnDnvCu5;

	private int QiyncqFXNh;

	private bool bqDnJTFXO2;

	private SolidBrush XOinuEYVOH;

	private SolidBrush IIwnoLPB9T;

	private SolidBrush iF9nQeZjC9;

	private EventHandler M38nO4uy3X;

	private EventHandler U84nCfcj9Y;

	private EventHandler DcBn7lmGBE;

	private EventHandler X9onAm5Web;

	private EventHandler THUndIRcg4;

	private EventHandler QJanHVFPYH;

	private EventHandler FL3nFQHbFA;

	private EventHandler em3njH7Iwj;

	private EventHandler Cq7n8O2Ahw;

	private EventHandler lopn9be9mR;

	private EventHandler JX0nIOtNTw;

	private DimensionWorkingData dpYnz7GUrv;

	private List<RegionDisplayChunk[]> WwQlTCUX76;

	private Bitmap glelS37sFq;

	private MapSize pZxlGwt7W3;

	private int h2Clbc08YX;

	private int oOWlv5I5va;

	private List<int[]> g3WlwnQJn1;

	private BackgroundWorker Wi0l4eiF89;

	private bool LvjlVtbECc;

	private MouseEventArgs YhalWi5GLU;

	private FileSystemWatcher bA3lpxMOM5;

	private int G7BlZYAF9c;

	private int zIDlfcEsGg;

	private int fNalicprVu;

	private int GcDlsODJ0P;

	private bool vxQlqKsQmi;

	private IContainer kQmlK0taiH;

	private Label rkwlheFOrm;

	private Label ep2lmkZmht;

	private FlowLayoutPanel cfYlnslcxM;

	private DoubleBufferPanel idZlljZTov;

	private ContextMenuStrip tyLl2GJumn;

	private ToolStripMenuItem ITNlyhXd2k;

	private ToolStripMenuItem FO1l08cWYL;

	private ProgressBar OPBlB4797L;

	private Panel P7blt4hPli;

	private Label ti9laTpjAL;

	private ToolStripMenuItem J4OlXeyvjQ;

	private ToolStripMenuItem U7tlx43riC;

	private ToolStripMenuItem VBFlej5tXd;

	private ToolStripMenuItem MBflMGJjJx;

	private ToolStripSeparator i9blURGsq7;

	private ToolStripMenuItem jtNlLUh9jC;

	private ToolStripMenuItem axJlgXaqtS;

	private ToolStripSeparator OLElP79Bwh;

	private ToolStripMenuItem r6clR5moAx;

	public Bitmap AreaMask
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return oJ3n3RPjDa;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			oJ3n3RPjDa = value;
			idZlljZTov.Invalidate();
		}
	}

	public MapViewType ViewType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return AbFnnq6xay;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			AbFnnq6xay = value;
			idZlljZTov.Invalidate();
		}
	}

	public Bitmap[] Maps
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return (Bitmap[])WA6n1nqDbR;
		}
	}

	public bool ShowPlayers
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return wPkn0SrOgC;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			wPkn0SrOgC = value;
			idZlljZTov.Invalidate();
		}
	}

	public bool ShowChunkGrid
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return BqSn2ymZOF;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			BqSn2ymZOF = value;
			idZlljZTov.Invalidate();
		}
	}

	public bool ShowRegionGrid
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return hcgnyj1x7b;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			hcgnyj1x7b = value;
			idZlljZTov.Invalidate();
		}
	}

	public bool ShowSearchResults
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return BSQnBGjeQ8;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			BSQnBGjeQ8 = value;
			idZlljZTov.Invalidate();
		}
	}

	public bool ShowSpawn
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return fpSnaYKJen;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			fpSnaYKJen = value;
			idZlljZTov.Invalidate();
		}
	}

	public DimensionWorkingData DimensionData
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return dpYnz7GUrv;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			dpYnz7GUrv = value;
			WwQlTCUX76 = null;
			rkwlheFOrm.Text = "";
			O2Vn6n70JJ = 0;
			KxanNOIpJw = 0;
			WA6n1nqDbR = null;
			pZxlGwt7W3 = null;
			if (dpYnz7GUrv != null)
			{
				pZxlGwt7W3 = hpqmFpgTtL();
			}
			if (value != null && !Wi0l4eiF89.IsBusy)
			{
				string text = Constants.dimensionNames[value.Dimension];
				rkwlheFOrm.Text = text;
				N5fnEB7nwK = JeNhj3kXfl();
				BAcm69xkwg(dpYnz7GUrv);
			}
			if (dpYnz7GUrv != null)
			{
				idZlljZTov.Width = (pZxlGwt7W3.width + 1) * (xRVnrsCVbQ * 32) + 2;
				idZlljZTov.Height = (pZxlGwt7W3.height + 1) * (xRVnrsCVbQ * 32) + 2;
			}
		}
	}

	public List<RegionDisplayChunk[]> ChunkEntries
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return WwQlTCUX76;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			WwQlTCUX76 = value;
		}
	}

	public event EventHandler ChunkSelected
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = M38nO4uy3X;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref M38nO4uy3X, value2, eventHandler2);
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
			EventHandler eventHandler = M38nO4uy3X;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref M38nO4uy3X, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler MapUpdated
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = U84nCfcj9Y;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref U84nCfcj9Y, value2, eventHandler2);
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
			EventHandler eventHandler = U84nCfcj9Y;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref U84nCfcj9Y, value2, eventHandler2);
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
			EventHandler eventHandler = DcBn7lmGBE;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref DcBn7lmGBE, value2, eventHandler2);
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
			EventHandler eventHandler = DcBn7lmGBE;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref DcBn7lmGBE, value2, eventHandler2);
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
			EventHandler eventHandler = X9onAm5Web;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref X9onAm5Web, value2, eventHandler2);
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
			EventHandler eventHandler = X9onAm5Web;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref X9onAm5Web, value2, eventHandler2);
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
			EventHandler eventHandler = THUndIRcg4;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref THUndIRcg4, value2, eventHandler2);
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
			EventHandler eventHandler = THUndIRcg4;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref THUndIRcg4, value2, eventHandler2);
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
			EventHandler eventHandler = QJanHVFPYH;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref QJanHVFPYH, value2, eventHandler2);
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
			EventHandler eventHandler = QJanHVFPYH;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref QJanHVFPYH, value2, eventHandler2);
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
			EventHandler eventHandler = FL3nFQHbFA;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref FL3nFQHbFA, value2, eventHandler2);
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
			EventHandler eventHandler = FL3nFQHbFA;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref FL3nFQHbFA, value2, eventHandler2);
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
			EventHandler eventHandler = em3njH7Iwj;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref em3njH7Iwj, value2, eventHandler2);
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
			EventHandler eventHandler = em3njH7Iwj;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref em3njH7Iwj, value2, eventHandler2);
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
			EventHandler eventHandler = Cq7n8O2Ahw;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref Cq7n8O2Ahw, value2, eventHandler2);
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
			EventHandler eventHandler = Cq7n8O2Ahw;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref Cq7n8O2Ahw, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler ChunkCornerSelected
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = lopn9be9mR;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref lopn9be9mR, value2, eventHandler2);
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
			EventHandler eventHandler = lopn9be9mR;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref lopn9be9mR, value2, eventHandler2);
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
			EventHandler eventHandler = JX0nIOtNTw;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref JX0nIOtNTw, value2, eventHandler2);
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
			EventHandler eventHandler = JX0nIOtNTw;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref JX0nIOtNTw, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetChunkSelected(int rx, int rz, int chunkX, int chunkZ, int index)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		c3NnPCqkiN = true;
		h2Clbc08YX = chunkX;
		oOWlv5I5va = chunkZ;
		MapSize mapSize = hpqmFpgTtL();
		int num = Math.Abs(mapSize.minX - rx) * 32;
		int num2 = Math.Abs(mapSize.minZ - rz) * 32;
		int num3 = index % 32 + num;
		int qiyncqFXNh = index / 32 + num2;
		Graphics graphics = idZlljZTov.CreateGraphics();
		if (bqDnJTFXO2)
		{
			Rectangle rc = new Rectangle(dhAnDnvCu5 * xRVnrsCVbQ - 1, QiyncqFXNh * xRVnrsCVbQ - 1, xRVnrsCVbQ + 3, xRVnrsCVbQ + 3);
			idZlljZTov.Invalidate(rc);
			idZlljZTov.Update();
		}
		bqDnJTFXO2 = true;
		dhAnDnvCu5 = num3;
		QiyncqFXNh = qiyncqFXNh;
		if (oJ3n3RPjDa != null)
		{
			idZlljZTov.Invalidate();
		}
		else
		{
			csZmrCIjwF(dhAnDnvCu5, QiyncqFXNh, IIwnoLPB9T, graphics);
		}
		if (!JAEntCB4I0)
		{
			int num4 = dhAnDnvCu5 * xRVnrsCVbQ + 1;
			int num5 = QiyncqFXNh * xRVnrsCVbQ + 1;
			cfYlnslcxM.AutoScrollPosition = new Point(num4 - cfYlnslcxM.ClientSize.Width / 2, num5 - cfYlnslcxM.ClientSize.Height / 2);
		}
		JAEntCB4I0 = false;
		c3NnPCqkiN = false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MapDimension()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		UxvnhwqMEx = Color.Black;
		xmKnmWoeDk = Color.White;
		SJrnl3gexc = new EntityLookup();
		V5TnRVL54n = 8;
		YD9nY1X0kC = 8;
		N5fnEB7nwK = 32;
		xRVnrsCVbQ = 4;
		K4Wn53Pf87 = 800;
		XOinuEYVOH = new SolidBrush(Color.LightGray);
		IIwnoLPB9T = new SolidBrush(Color.Red);
		iF9nQeZjC9 = new SolidBrush(Color.White);
		glelS37sFq = new Bitmap(1024, 1024);
		g3WlwnQJn1 = new List<int[]>
		{
			new int[5] { 64, 128, 256, 512, 1024 },
			new int[5] { 64, 128, 256, 512, 1024 }
		};
		Wi0l4eiF89 = new BackgroundWorker();
		Y2WnfFJdKe();
		NfBm57weFI();
		base.MouseWheel += Pk4mO8vYOL;
		idZlljZTov.MouseWheel += Pk4mO8vYOL;
		cfYlnslcxM.MouseWheel += Pk4mO8vYOL;
		idZlljZTov.Paint += OnPanelPaint;
		if (wEDnsPTFJo == null)
		{
			wEDnsPTFJo = new ImageList();
			vtonqMSbN7 = new ImageList();
			wEDnsPTFJo.ColorDepth = ColorDepth.Depth32Bit;
			wEDnsPTFJo.TransparentColor = Color.Transparent;
			wEDnsPTFJo.ImageSize = new Size(20, 20);
			vtonqMSbN7.ColorDepth = ColorDepth.Depth32Bit;
			vtonqMSbN7.TransparentColor = Color.Transparent;
			vtonqMSbN7.ImageSize = new Size(32, 32);
			Bitmap value = new Bitmap(32, 32);
			wEDnsPTFJo.Images.Add(value);
			vtonqMSbN7.Images.Add(value);
			RFvnKBLMux = new Dictionary<string, int>();
		}
		Settings settings = new Settings();
		hcgnyj1x7b = settings.ShowRegionGrid;
		BqSn2ymZOF = settings.ShowChunkGrid;
		wPkn0SrOgC = settings.ShowPlayers;
		BSQnBGjeQ8 = settings.ShowSearchResults;
		fpSnaYKJen = settings.ShowSpawn;
		PlayerPositionWorker.LoadPlayersMapData();
		gW7niNtgst = new System.Timers.Timer(500.0);
		gW7niNtgst.Elapsed += WjjmzKVx3K;
		gW7niNtgst.Enabled = false;
		DoubleBuffered = true;
		SetStyle(ControlStyles.OptimizedDoubleBuffer, value: true);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int JeNhj3kXfl()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return 32;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnPaint(PaintEventArgs pe)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.OnPaint(pe);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void OnPanelPaint(object sender, PaintEventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Graphics graphics = e.Graphics;
		try
		{
			idZlljZTov.Width = (pZxlGwt7W3.width + 1) * (xRVnrsCVbQ * 32) + 2;
			idZlljZTov.Height = (pZxlGwt7W3.height + 1) * (xRVnrsCVbQ * 32) + 2;
			EPRmVemYoi(graphics);
			Mash9jcrbr(graphics);
			bAJhIBFmel(graphics);
			qcBhz8nI6O(graphics);
			ThYmZ9key5(graphics);
			hkSh8yyyM1(graphics);
			NMSmTEM5A6(graphics);
			if (!c3NnPCqkiN && bqDnJTFXO2)
			{
				csZmrCIjwF(dhAnDnvCu5, QiyncqFXNh, IIwnoLPB9T, graphics);
			}
		}
		catch (Exception)
		{
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hkSh8yyyM1(Graphics P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Brush brush = new SolidBrush(Color.FromArgb(100, 10, 200, 200));
		if (vxQlqKsQmi)
		{
			int num = (fNalicprVu - G7BlZYAF9c + 1) * xRVnrsCVbQ;
			int num2 = (GcDlsODJ0P - zIDlfcEsGg + 1) * xRVnrsCVbQ;
			int num3 = ogSmGjUTwl(G7BlZYAF9c);
			int num4 = ogSmGjUTwl(zIDlfcEsGg);
			int num5 = (num3 - pZxlGwt7W3.minX) * K4Wn53Pf87;
			int num6 = (num4 - pZxlGwt7W3.minZ) * K4Wn53Pf87;
			int num7 = Math.Abs(vXOmwCidWH(G7BlZYAF9c, 32)) * xRVnrsCVbQ;
			int num8 = Math.Abs(vXOmwCidWH(zIDlfcEsGg, 32)) * xRVnrsCVbQ;
			num5 += num7;
			num6 += num8;
			new Point(num5 + 1, num6 + 1);
			P_0.FillRectangle(brush, num5, num6, num, num2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Mash9jcrbr(Graphics P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (ShowSpawn)
		{
			_ = Working.playerMapData;
			Image image = Resources.CMMSEVmHooE();
			int num = JeNhj3kXfl();
			int num2 = num * 16;
			_ = (float)(idZlljZTov.Width - 2) / (float)(num2 * 2);
			_ = (float)(idZlljZTov.Height - 2) / (float)(num2 * 2);
			int num3 = nCGmSqkx6j(V5TnRVL54n);
			int num4 = nCGmSqkx6j(YD9nY1X0kC);
			int num5 = (num3 - pZxlGwt7W3.minX) * K4Wn53Pf87;
			int num6 = (num4 - pZxlGwt7W3.minZ) * K4Wn53Pf87;
			int num7 = Math.Abs(AiHmbfGHEC(V5TnRVL54n)) * xRVnrsCVbQ;
			int num8 = Math.Abs(AiHmbfGHEC(YD9nY1X0kC)) * xRVnrsCVbQ;
			int num9 = Math.Abs(oAvmvRIGGB(V5TnRVL54n)) * (xRVnrsCVbQ / 16);
			int num10 = Math.Abs(oAvmvRIGGB(YD9nY1X0kC)) * (xRVnrsCVbQ / 16);
			num5 += num7 + num9;
			num6 += num8 + num10;
			P_0.DrawImage(image, num5 + 1 - image.Width / 2 + 4, num6 + 1 - (image.Height - 4));
			num6 += 4;
			string text = string.Format(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20398), V5TnRVL54n, wtfnk96inq, YD9nY1X0kC);
			GraphicHelpers.DrawString3(P_0, UxvnhwqMEx, num5 + 3, num6 + 1, text);
			GraphicHelpers.DrawString3(P_0, UxvnhwqMEx, num5 + 4, num6 + 1, text);
			GraphicHelpers.DrawString3(P_0, UxvnhwqMEx, num5 + 2, num6 + 2, text);
			GraphicHelpers.DrawString3(P_0, UxvnhwqMEx, num5 + 5, num6 + 2, text);
			GraphicHelpers.DrawString3(P_0, UxvnhwqMEx, num5 + 3, num6 + 3, text);
			GraphicHelpers.DrawString3(P_0, UxvnhwqMEx, num5 + 4, num6 + 3, text);
			GraphicHelpers.DrawString3(P_0, xmKnmWoeDk, num5 + 3, num6 + 2, text);
			GraphicHelpers.DrawString3(P_0, xmKnmWoeDk, num5 + 4, num6 + 2, text);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void bAJhIBFmel(Graphics P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!wPkn0SrOgC)
		{
			return;
		}
		List<PlayerMapData> playerMapData = Working.playerMapData;
		Image image = Resources.YoUSEjsAPlZ();
		int num = JeNhj3kXfl();
		int num2 = num * 16;
		int num3 = 16;
		_ = (float)(idZlljZTov.Width - 2) / (float)(num2 * 2);
		_ = (float)(idZlljZTov.Height - 2) / (float)(num2 * 2);
		foreach (PlayerMapData item in playerMapData)
		{
			int num4 = nCGmSqkx6j(item.x);
			int num5 = nCGmSqkx6j(item.z);
			int num6 = (num4 - pZxlGwt7W3.minX) * K4Wn53Pf87;
			int num7 = (num5 - pZxlGwt7W3.minZ) * K4Wn53Pf87;
			int num8 = Math.Abs(AiHmbfGHEC(item.x)) * xRVnrsCVbQ;
			int num9 = Math.Abs(AiHmbfGHEC(item.z)) * xRVnrsCVbQ;
			int num10 = Math.Abs(oAvmvRIGGB(item.x)) * (xRVnrsCVbQ / 16);
			int num11 = Math.Abs(oAvmvRIGGB(item.z)) * (xRVnrsCVbQ / 16);
			num6 += num8 + num10;
			num7 += num9 + num11;
			P_0.DrawImage(image, num6 + 1 - num3, num7 + 1 - num3);
			num7 += 20;
			string name = item.name;
			GraphicHelpers.DrawString3(P_0, UxvnhwqMEx, num6 + 3, num7 + 1, name);
			GraphicHelpers.DrawString3(P_0, UxvnhwqMEx, num6 + 4, num7 + 1, name);
			GraphicHelpers.DrawString3(P_0, UxvnhwqMEx, num6 + 2, num7 + 2, name);
			GraphicHelpers.DrawString3(P_0, UxvnhwqMEx, num6 + 5, num7 + 2, name);
			GraphicHelpers.DrawString3(P_0, UxvnhwqMEx, num6 + 3, num7 + 3, name);
			GraphicHelpers.DrawString3(P_0, UxvnhwqMEx, num6 + 4, num7 + 3, name);
			GraphicHelpers.DrawString3(P_0, xmKnmWoeDk, num6 + 3, num7 + 2, name);
			GraphicHelpers.DrawString3(P_0, xmKnmWoeDk, num6 + 4, num7 + 2, name);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void qcBhz8nI6O(Graphics P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!BSQnBGjeQ8)
		{
			return;
		}
		ImageList imageList = ((xRVnrsCVbQ >= 48) ? vtonqMSbN7 : wEDnsPTFJo);
		int num = ((xRVnrsCVbQ >= 48) ? 8 : 4);
		Dictionary<string, List<EntitySearchResult>> dictionary = null;
		if (Working.khEStDj4vgI() != null && Working.khEStDj4vgI().ContainsKey(dpYnz7GUrv.Dimension))
		{
			dictionary = Working.khEStDj4vgI()[dpYnz7GUrv.Dimension];
		}
		if (dictionary == null)
		{
			return;
		}
		foreach (List<EntitySearchResult> value in dictionary.Values)
		{
			if (value == null)
			{
				continue;
			}
			foreach (EntitySearchResult item in value)
			{
				int index = KBNm4qtZeN(item.EntityId);
				Image image = imageList.Images[index];
				int num2 = nCGmSqkx6j(item.X);
				int num3 = nCGmSqkx6j(item.Z);
				int num4 = (num2 - pZxlGwt7W3.minX) * K4Wn53Pf87;
				int num5 = (num3 - pZxlGwt7W3.minZ) * K4Wn53Pf87;
				int num6 = Math.Abs(AiHmbfGHEC(item.X)) * xRVnrsCVbQ;
				int num7 = Math.Abs(AiHmbfGHEC(item.Z)) * xRVnrsCVbQ;
				int num8 = Math.Abs(oAvmvRIGGB(item.X)) * (xRVnrsCVbQ / 16);
				int num9 = Math.Abs(oAvmvRIGGB(item.Z)) * (xRVnrsCVbQ / 16);
				num4 += num6 + num8;
				num5 += num7 + num9;
				P_0.DrawImage(image, num4 + 1 - num, num5 + 1 - num);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void NMSmTEM5A6(Graphics P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (oJ3n3RPjDa != null)
		{
			int num = oJ3n3RPjDa.Width / 16 * xRVnrsCVbQ;
			int num2 = oJ3n3RPjDa.Height / 16 * xRVnrsCVbQ;
			Point point = new Point(dhAnDnvCu5 * xRVnrsCVbQ + 1, QiyncqFXNh * xRVnrsCVbQ + 1);
			P_0.DrawImage(destRect: new RectangleF(point.X, point.Y, num, num2), srcRect: new Rectangle(0, 0, oJ3n3RPjDa.Width, oJ3n3RPjDa.Height), image: oJ3n3RPjDa, srcUnit: GraphicsUnit.Pixel);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int nCGmSqkx6j(int P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0 >> 4 >> 5;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int ogSmGjUTwl(int P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0 >> 5;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int AiHmbfGHEC(int P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return vXOmwCidWH(P_0 >> 4, 32);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int oAvmvRIGGB(int P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return vXOmwCidWH(P_0, 16);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int vXOmwCidWH(int P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return (P_0 % P_1 + P_1) % P_1;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int KBNm4qtZeN(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = 0;
		if (P_0.IndexOf(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9974)) >= 0)
		{
			if (SJrnl3gexc.PCEntities.ContainsKey(P_0))
			{
				P_0 = SJrnl3gexc.PCEntities[P_0].ConsoleName;
			}
			else if (INYifyudg3hCpcrleHt.mXTS0yn6FgU().ContainsKey(P_0))
			{
				P_0 = Constants.BEDROCK_ENTITY_BLOCKS[INYifyudg3hCpcrleHt.mXTS0yn6FgU()[P_0].Id];
			}
		}
		if (RFvnKBLMux.ContainsKey(P_0))
		{
			num = RFvnKBLMux[P_0];
		}
		else if (MobImageManager.SOLG0vnEyp().ContainsKey(P_0))
		{
			Image value = MobImageManager.MobImages.Images[MobImageManager.SOLG0vnEyp()[P_0].ImageId];
			num = wEDnsPTFJo.Images.Count;
			wEDnsPTFJo.Images.Add(value);
			vtonqMSbN7.Images.Add(value);
			RFvnKBLMux.Add(P_0, num);
		}
		else if (Constants.BEDROCK_ENTITY_BLOCKS_BY_NAME.ContainsKey(P_0))
		{
			int num2 = Constants.BEDROCK_ENTITY_BLOCKS_BY_NAME[P_0];
			Image value2 = BFRL2f2UoG7tBGIHJF.xRoSMGJq48(num2, 0);
			num = wEDnsPTFJo.Images.Count;
			wEDnsPTFJo.Images.Add(value2);
			vtonqMSbN7.Images.Add(value2);
			RFvnKBLMux.Add(P_0, num);
		}
		return num;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EPRmVemYoi(Graphics P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_0.InterpolationMode = InterpolationMode.NearestNeighbor;
		PEDimension pEDimension = PEUtility.GetPEDimension(dpYnz7GUrv.Dimension);
		c9rmWonsyE(P_0, pEDimension);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void c9rmWonsyE(Graphics P_0, PEDimension P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string path = Path.Combine(Working.T92StMGt1p4(), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20428), Constants.GetDimensionFolderName(P_1.Dimension));
		int k4Wn53Pf = K4Wn53Pf87;
		string text = mvBmpuApRw();
		foreach (PERegion value in P_1.Region.Values)
		{
			string text2 = Path.Combine(path, value.ToString() + text + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12722));
			if (File.Exists(text2))
			{
				Image image = Image.FromFile(text2);
				int num = value.RX - pZxlGwt7W3.minX;
				int num2 = value.RZ - pZxlGwt7W3.minZ;
				Rectangle rectangle = new Rectangle(0, 0, 511, 511);
				RectangleF destRect = new RectangleF(num * k4Wn53Pf + 1, num2 * k4Wn53Pf + 1, k4Wn53Pf, k4Wn53Pf);
				P_0.DrawImage(image, destRect, rectangle, GraphicsUnit.Pixel);
				image.Dispose();
			}
		}
		GC.Collect();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SaveMaps(string imagePath)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = imagePath.Substring(0, imagePath.Length - 4);
		int num = 6144;
		PEDimension pEDimension = PEUtility.GetPEDimension(dpYnz7GUrv.Dimension);
		string path = Path.Combine(Working.T92StMGt1p4(), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20428), Constants.GetDimensionFolderName(pEDimension.Dimension));
		string[] array = new string[3]
		{
			"",
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20454),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20470)
		};
		MapSize mapSize = hpqmFpgTtL();
		int num2 = (mapSize.width + 1) * 512;
		int num3 = (mapSize.height + 1) * 512;
		int num4 = ((num2 > num3) ? num2 : num3);
		if (num4 > num)
		{
			double num5 = (double)num / (double)num4;
			num2 = (int)((double)num2 * num5);
			num3 = (int)((double)num3 * num5);
		}
		num4 = num2 / (mapSize.width + 1);
		for (int i = 0; i < 3; i++)
		{
			string text2 = array[i];
			Bitmap bitmap = new Bitmap(num2, num3);
			using Graphics graphics = Graphics.FromImage(bitmap);
			foreach (PERegion value in pEDimension.Region.Values)
			{
				string text3 = Path.Combine(path, value.ToString() + text2 + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12722));
				if (File.Exists(text3))
				{
					Image image = Image.FromFile(text3);
					int num6 = value.RX - mapSize.minX;
					int num7 = value.RZ - mapSize.minZ;
					Rectangle rectangle = new Rectangle(0, 0, 512, 512);
					RectangleF destRect = new RectangleF(num6 * num4, num7 * num4, num4, num4);
					graphics.DrawImage(image, destRect, rectangle, GraphicsUnit.Pixel);
					image.Dispose();
				}
			}
			bitmap.Save(text + text2 + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12722));
			GC.Collect();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string mvBmpuApRw()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string result = string.Empty;
		if (AbFnnq6xay == MapViewType.BiomeView)
		{
			result = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20454);
		}
		if (AbFnnq6xay == MapViewType.HeightView)
		{
			result = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20470);
		}
		if (AbFnnq6xay == MapViewType.HybridView)
		{
			result = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20488);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ThYmZ9key5(Graphics P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (BqSn2ymZOF)
		{
			sYymfopXho(P_0);
		}
		if (hcgnyj1x7b)
		{
			EQFminKqWc(P_0);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void sYymfopXho(Graphics P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (xRVnrsCVbQ != 0)
		{
			MJDmh9vTW3();
			Pen pen = new Pen(Color.LightGray);
			Point pt = new Point(1, 1);
			Point pt2 = new Point(idZlljZTov.Width - 2, 1);
			for (int i = 1; i < idZlljZTov.Height; i += xRVnrsCVbQ)
			{
				pt.Y = i;
				pt2.Y = i;
				P_0.DrawLine(pen, pt, pt2);
			}
			pt.Y = 1;
			pt2.Y = idZlljZTov.Height - 2;
			for (int j = 1; j < idZlljZTov.Width; j += xRVnrsCVbQ)
			{
				pt.X = j;
				pt2.X = j;
				P_0.DrawLine(pen, pt, pt2);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EQFminKqWc(Graphics P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = (idZlljZTov.Width - 2) / (pZxlGwt7W3.width + 1);
		int num2 = (idZlljZTov.Height - 2) / (pZxlGwt7W3.height + 1);
		int num3 = ((num > num2) ? num2 : num);
		Pen pen = new Pen(Color.Red);
		int num4 = num3 * (pZxlGwt7W3.height + 1);
		for (int i = 0; i <= pZxlGwt7W3.width + 1; i++)
		{
			Point pt = new Point(num3 * i + 1, 0);
			Point pt2 = new Point(num3 * i + 1, num4);
			P_0.DrawLine(pen, pt, pt2);
		}
		num4 = num3 * (pZxlGwt7W3.width + 1);
		for (int j = 0; j <= pZxlGwt7W3.height + 1; j++)
		{
			Point pt3 = new Point(0, num3 * j + 1);
			Point pt4 = new Point(num4, num3 * j + 1);
			P_0.DrawLine(pen, pt3, pt4);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void xiemsd72rq(PEDimension P_0, PERegion P_1, List<RegionDisplayChunk[]> P_2, int P_3, int P_4)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = lxe7hMuSirBXGUQugsD.e1cSPCO6PUl(P_3, P_1.RX);
		int num2 = lxe7hMuSirBXGUQugsD.e1cSPCO6PUl(P_4, P_1.RZ);
		bool isPresent = lxe7hMuSirBXGUQugsD.zNZSPALhXMG(P_1.Chunks, num, num2);
		RegionDisplayChunk regionDisplayChunk = new RegionDisplayChunk();
		regionDisplayChunk.Dimension = P_0.Dimension;
		regionDisplayChunk.Region = P_1.ToString();
		regionDisplayChunk.ChunkIndex = lxe7hMuSirBXGUQugsD.rMDSPOktq2F(num, num2);
		regionDisplayChunk.IsPresent = isPresent;
		regionDisplayChunk.RX = P_1.RX;
		regionDisplayChunk.RZ = P_1.RZ;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TbbmqWWU70(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = base.Height / 2 - P7blt4hPli.Height;
		if (num < 0)
		{
			num = 0;
		}
		P7blt4hPli.Top = num;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FBKmK5K7WH()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MJDmh9vTW3();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MJDmh9vTW3()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		K4Wn53Pf87 = xRVnrsCVbQ * 32;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EOCmmshl0l(object P_0, MouseEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PYjmnbuVqH(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HWumlBCbIr(MouseEventArgs P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = P_0.X;
		int num2 = P_0.Y;
		if (num >= 1 && num2 >= 1)
		{
			pZxlGwt7W3 = hpqmFpgTtL();
			int k4Wn53Pf = K4Wn53Pf87;
			int k4Wn53Pf2 = K4Wn53Pf87;
			int num3 = xRVnrsCVbQ;
			int num4 = xRVnrsCVbQ;
			int num5 = num / k4Wn53Pf;
			int num6 = num2 / k4Wn53Pf2;
			if (num3 > 0 && num4 > 0)
			{
				int num7 = num % k4Wn53Pf / num3;
				int num8 = num2 % k4Wn53Pf2 / num4;
				int num9 = (pZxlGwt7W3.minX + num5) * 32 + num7;
				int num10 = (pZxlGwt7W3.minZ + num6) * 32 + num8;
				string text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20506) + (pZxlGwt7W3.minX + num5) + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13710) + (pZxlGwt7W3.minZ + num6);
				ep2lmkZmht.Text = text + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20514) + num9 + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11952) + num10 + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20542);
				ep2lmkZmht.Visible = true;
			}
			else
			{
				ep2lmkZmht.Visible = false;
			}
			num = P_0.X / xRVnrsCVbQ;
			num2 = P_0.Y / xRVnrsCVbQ;
			idZlljZTov.CreateGraphics();
			if (num == O2Vn6n70JJ)
			{
				_ = KxanNOIpJw;
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int dGCm2xYDSm(int P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_1 < 0)
		{
			return (N5fnEB7nwK - P_0) * -1;
		}
		return P_0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int j1fmyu3Bky(int P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_1 < 0)
		{
			return (N5fnEB7nwK - P_0) * -1;
		}
		return P_0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Lbnm0CLHTm(MouseEventArgs P_0, bool P_1 = false)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = P_0.X;
		int num2 = P_0.Y;
		if (num >= 1 && num2 >= 1)
		{
			Tuple<string, string, int, int, int> tuple = oQ8mascj3y(num, num2);
			i9CmXm67oT(tuple.Item1, tuple.Item2, tuple.Item5);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void NlUmB0ML4j(MouseEventArgs P_0, bool P_1 = false)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int corner = (((Control.ModifierKeys & Keys.Shift) != Keys.None || P_1) ? 1 : 0);
		int num = P_0.X;
		int num2 = P_0.Y;
		if (num >= 1 && num2 >= 1)
		{
			Tuple<string, string, int, int, int> tuple = oQ8mascj3y(num, num2);
			ChunkSelectedEventArgs e = new ChunkSelectedEventArgs(tuple.Item1, tuple.Item2, tuple.Item5);
			e.Corner = corner;
			e.X = tuple.Item3;
			e.Z = tuple.Item4;
			OnChunkCornerSelected(this, e);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Tuple<string, int, int, int, int, int> rubmt7o8Yq(int P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		pZxlGwt7W3 = hpqmFpgTtL();
		int k4Wn53Pf = K4Wn53Pf87;
		int k4Wn53Pf2 = K4Wn53Pf87;
		int num = xRVnrsCVbQ;
		int num2 = xRVnrsCVbQ;
		int num3 = P_0 / k4Wn53Pf;
		int num4 = P_1 / k4Wn53Pf2;
		int num5 = P_0 % k4Wn53Pf / num;
		int num6 = P_1 % k4Wn53Pf2 / num2;
		int num7 = (pZxlGwt7W3.minX + num3) * 32 + num5;
		int num8 = (pZxlGwt7W3.minZ + num4) * 32 + num6;
		int item = pZxlGwt7W3.minX + num3;
		int item2 = pZxlGwt7W3.minZ + num4;
		string dimension = dpYnz7GUrv.Dimension;
		int item3 = lxe7hMuSirBXGUQugsD.rMDSPOktq2F(num7, num8);
		return new Tuple<string, int, int, int, int, int>(dimension, item, item2, num7, num8, item3);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Tuple<string, string, int, int, int> oQ8mascj3y(int P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		pZxlGwt7W3 = hpqmFpgTtL();
		int k4Wn53Pf = K4Wn53Pf87;
		int k4Wn53Pf2 = K4Wn53Pf87;
		int num = xRVnrsCVbQ;
		int num2 = xRVnrsCVbQ;
		int num3 = P_0 / k4Wn53Pf;
		int num4 = P_1 / k4Wn53Pf2;
		int num5 = P_0 % k4Wn53Pf / num;
		int num6 = P_1 % k4Wn53Pf2 / num2;
		int num7 = (pZxlGwt7W3.minX + num3) * 32 + num5;
		int num8 = (pZxlGwt7W3.minZ + num4) * 32 + num6;
		string item = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20506) + (pZxlGwt7W3.minX + num3) + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13710) + (pZxlGwt7W3.minZ + num4);
		string dimension = dpYnz7GUrv.Dimension;
		int item2 = lxe7hMuSirBXGUQugsD.rMDSPOktq2F(num7, num8);
		return new Tuple<string, string, int, int, int>(dimension, item, num7, num8, item2);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void i9CmXm67oT(string P_0, string P_1, int P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		OnChunkSelected(this, new ChunkSelectedEventArgs(P_0, P_1, P_2));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RLXmxpcFD5(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		yuKme6pUhS();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void yuKme6pUhS()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int bWnnLf32jl = BWnnLf32jl;
		int num = oOAngbPE3R;
		if (bWnnLf32jl >= 1 && num >= 1)
		{
			Tuple<string, string, int, int, int> tuple = oQ8mascj3y(bWnnLf32jl, num);
			OnChunkDeleted(this, new ChunkSelectedEventArgs(tuple.Item1, tuple.Item2, tuple.Item5));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void jaMmMB2KI7(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		vfOmUCENxe();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void vfOmUCENxe()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int bWnnLf32jl = BWnnLf32jl;
		int num = oOAngbPE3R;
		if (bWnnLf32jl >= 1 && num >= 1)
		{
			Tuple<string, string, int, int, int> tuple = oQ8mascj3y(bWnnLf32jl, num);
			OnRegionDeleted(this, new ChunkSelectedEventArgs(tuple.Item1, tuple.Item2, tuple.Item5));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LNHmLeR3i5(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		OnEditChunkBlocks(this, new ChunkSelectedEventArgs());
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LbumgR9DmJ(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		OnEditChunkEntities(this, new ChunkSelectedEventArgs());
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Hw3mPhvXRT(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		OnEditChunkBiomes(this, new ChunkSelectedEventArgs());
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnCopyChunk(object sender, ChunkSelectedEventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		em3njH7Iwj?.Invoke(this, e);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnPasteChunk(object sender, ChunkSelectedEventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		glelS37sFq = new Bitmap(1, 1);
		Cq7n8O2Ahw?.Invoke(this, e);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnChunkCornerSelected(object sender, ChunkSelectedEventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		lopn9be9mR?.Invoke(this, e);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnChunkSelected(object sender, ChunkSelectedEventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		JAEntCB4I0 = true;
		M38nO4uy3X?.Invoke(this, e);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnChunkDeleted(object sender, ChunkSelectedEventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		DcBn7lmGBE?.Invoke(this, e);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnRegionDeleted(object sender, ChunkSelectedEventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		X9onAm5Web?.Invoke(this, e);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnMapUpdated(object sender, EventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		U84nCfcj9Y?.Invoke(this, e);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnEditChunkBlocks(object sender, ChunkSelectedEventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		THUndIRcg4?.Invoke(this, e);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnEditChunkEntities(object sender, ChunkSelectedEventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		FL3nFQHbFA?.Invoke(this, e);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnEditChunkBiomes(object sender, ChunkSelectedEventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		QJanHVFPYH?.Invoke(this, e);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void a4HmR40f3X(int P_0, int P_1, int P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		SpawnEventArgs e = new SpawnEventArgs(P_0, P_1, P_2);
		JX0nIOtNTw?.Invoke(this, e);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CODmku9w8h(object P_0, MouseEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_1.Button == MouseButtons.Left)
		{
			Lbnm0CLHTm(P_1);
		}
		_ = P_1.Button;
		_ = 2097152;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private SolidBrush xBwmY2KJ6d(int P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return XOinuEYVOH;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BBjm35TcUA(int P_0, int P_1, Graphics P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void pBbm1TUnAH(Graphics P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_0.InterpolationMode = InterpolationMode.NearestNeighbor;
		P_0.SmoothingMode = SmoothingMode.None;
		P_0.PixelOffsetMode = PixelOffsetMode.Half;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void t7RmEUdg7m(int P_0, int P_1, Graphics P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		try
		{
			Point p = new Point(P_0 * xRVnrsCVbQ + 1, P_1 * xRVnrsCVbQ + 1);
			Point point = idZlljZTov.PointToScreen(p);
			glelS37sFq = new Bitmap(xRVnrsCVbQ + 1, xRVnrsCVbQ + 1);
			Graphics graphics = Graphics.FromImage(glelS37sFq);
			graphics.CopyFromScreen(point.X, point.Y, 0, 0, glelS37sFq.Size);
		}
		catch (Exception)
		{
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void csZmrCIjwF(int P_0, int P_1, SolidBrush P_2, Graphics P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		pBbm1TUnAH(P_3);
		Point point = new Point(P_0 * xRVnrsCVbQ + 1, P_1 * xRVnrsCVbQ + 1);
		Pen pen = new Pen(P_2);
		P_3.DrawRectangle(pen, point.X + 1, point.Y + 1, xRVnrsCVbQ, xRVnrsCVbQ);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void NfBm57weFI()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Wi0l4eiF89.DoWork += xl7mNt4XLT;
		Wi0l4eiF89.ProgressChanged += Ng3mDurQsG;
		Wi0l4eiF89.RunWorkerCompleted += rP0mcatyaX;
		Wi0l4eiF89.WorkerReportsProgress = true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BAcm69xkwg(DimensionWorkingData P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!Wi0l4eiF89.IsBusy)
		{
			cfYlnslcxM.Visible = false;
			P7blt4hPli.Visible = true;
			string dimension = P_0.Dimension;
			MapBlockPEParameter mapBlockPEParameter = new MapBlockPEParameter();
			mapBlockPEParameter.OutFolderPath = P_0.Path;
			mapBlockPEParameter.Dimension = dimension;
			Wi0l4eiF89.RunWorkerAsync(mapBlockPEParameter);
			q4GmjB4sID();
			GwAmJjQ1iY();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void xl7mNt4XLT(object P_0, DoWorkEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BackgroundWorker backgroundWorker = P_0 as BackgroundWorker;
		MapBlockPEParameter mapBlockPEParameter = P_1.Argument as MapBlockPEParameter;
		MapBlockWorker mapBlockWorker = new MapBlockWorker(backgroundWorker);
		mapBlockWorker.MapBlocks(mapBlockPEParameter.Dimension, mapBlockPEParameter.OutFolderPath);
		WA6n1nqDbR = new Image[4];
		P_1.Result = WA6n1nqDbR;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Ng3mDurQsG(object P_0, ProgressChangedEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void rP0mcatyaX(object P_0, RunWorkerCompletedEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		WA6n1nqDbR = null;
		if (P_1.Result != null && P_1.Result is Image[])
		{
			WA6n1nqDbR = P_1.Result as Image[];
			GwAmJjQ1iY();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GwAmJjQ1iY()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		try
		{
			cfYlnslcxM.Visible = true;
			P7blt4hPli.Visible = false;
			MJDmh9vTW3();
			FBKmK5K7WH();
			idZlljZTov.Invalidate();
		}
		catch (Exception)
		{
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void zI4muMdYQy(int P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = (dhAnDnvCu5 + P_0) * xRVnrsCVbQ + 1;
		int num2 = QiyncqFXNh * xRVnrsCVbQ + 1;
		Tuple<string, string, int, int, int> tuple = oQ8mascj3y(num, num2);
		i9CmXm67oT(tuple.Item1, tuple.Item2, tuple.Item5);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RLHmowvfHd(int P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = dhAnDnvCu5 * xRVnrsCVbQ + 1;
		int num2 = (QiyncqFXNh + P_0) * xRVnrsCVbQ + 1;
		Tuple<string, string, int, int, int> tuple = oQ8mascj3y(num, num2);
		i9CmXm67oT(tuple.Item1, tuple.Item2, tuple.Item5);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void iPRmQmReFm(object P_0, KeyEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		_ = P_1.KeyCode;
		_ = 38;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool IsInputKey(Keys keyData)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bool flag = false;
		switch (keyData)
		{
		case Keys.Right:
			zI4muMdYQy(1);
			flag = true;
			break;
		case Keys.Left:
			zI4muMdYQy(-1);
			flag = true;
			break;
		case Keys.Up:
			RLHmowvfHd(-1);
			flag = true;
			break;
		case Keys.Down:
			RLHmowvfHd(1);
			flag = true;
			break;
		case Keys.Add | Keys.Control:
		case Keys.Oemplus | Keys.Control:
			DoScaling(1);
			flag = true;
			break;
		case Keys.Subtract | Keys.Control:
		case Keys.OemMinus | Keys.Control:
			DoScaling(-1);
			flag = true;
			break;
		case Keys.Delete:
			yuKme6pUhS();
			flag = true;
			break;
		case Keys.Delete | Keys.Control:
			vfOmUCENxe();
			flag = true;
			break;
		case Keys.C | Keys.Control:
			OnCopyChunk(this, new ChunkSelectedEventArgs());
			flag = true;
			break;
		case Keys.V | Keys.Control:
			OnPasteChunk(this, new ChunkSelectedEventArgs());
			flag = true;
			break;
		case Keys.B | Keys.Control:
			OnEditChunkBlocks(this, new ChunkSelectedEventArgs());
			flag = true;
			break;
		case Keys.E | Keys.Control:
			OnEditChunkEntities(this, new ChunkSelectedEventArgs());
			flag = true;
			break;
		case Keys.O | Keys.Control:
			OnEditChunkBiomes(this, new ChunkSelectedEventArgs());
			flag = true;
			break;
		case Keys.Left | Keys.Shift:
		case Keys.Up | Keys.Shift:
		case Keys.Right | Keys.Shift:
		case Keys.Down | Keys.Shift:
			return true;
		}
		if (flag)
		{
			return true;
		}
		return base.IsInputKey(keyData);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnKeyDown(KeyEventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.OnKeyDown(e);
		switch (e.KeyCode)
		{
		case Keys.Left:
		case Keys.Up:
		case Keys.Right:
		case Keys.Down:
			_ = e.Shift;
			break;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Pk4mO8vYOL(object P_0, MouseEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = 15;
		if (P_1.Delta < 0)
		{
			num = -15;
		}
		if (Control.ModifierKeys == Keys.Shift)
		{
			Point autoScrollPosition = new Point(cfYlnslcxM.HorizontalScroll.Value, num + cfYlnslcxM.VerticalScroll.Value);
			cfYlnslcxM.AutoScrollPosition = autoScrollPosition;
			((HandledMouseEventArgs)P_1).Handled = true;
		}
		else if (Control.ModifierKeys == Keys.Control)
		{
			Point autoScrollPosition2 = new Point(num + cfYlnslcxM.HorizontalScroll.Value, cfYlnslcxM.VerticalScroll.Value);
			cfYlnslcxM.AutoScrollPosition = autoScrollPosition2;
			((HandledMouseEventArgs)P_1).Handled = true;
		}
		else
		{
			DoScaling(P_1.Delta);
			((HandledMouseEventArgs)P_1).Handled = true;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DoScaling(int delta)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		xJOnXg74AZ = false;
		LvjlVtbECc = true;
		idZlljZTov.CreateGraphics();
		MapSize mapSize = hpqmFpgTtL();
		float num = (float)cfYlnslcxM.VerticalScroll.Value / (float)cfYlnslcxM.VerticalScroll.Maximum;
		float num2 = (float)cfYlnslcxM.HorizontalScroll.Value / (float)cfYlnslcxM.HorizontalScroll.Maximum;
		if (delta < 0)
		{
			xRVnrsCVbQ -= 4;
			if (xRVnrsCVbQ < 4)
			{
				xRVnrsCVbQ = 4;
				return;
			}
			idZlljZTov.Width = (mapSize.width + 1) * (xRVnrsCVbQ * 32) + 2;
			idZlljZTov.Height = (mapSize.height + 1) * (xRVnrsCVbQ * 32) + 2;
		}
		else
		{
			xRVnrsCVbQ += 4;
			if (xRVnrsCVbQ > 96)
			{
				xRVnrsCVbQ = 96;
				return;
			}
			idZlljZTov.Width = (mapSize.width + 1) * (xRVnrsCVbQ * 32) + 2;
			idZlljZTov.Height = (mapSize.height + 1) * (xRVnrsCVbQ * 32) + 2;
		}
		cfYlnslcxM.VerticalScroll.Value = (int)((float)cfYlnslcxM.VerticalScroll.Maximum * num);
		cfYlnslcxM.HorizontalScroll.Value = (int)((float)cfYlnslcxM.HorizontalScroll.Maximum * num2);
		MJDmh9vTW3();
		O2Vn6n70JJ = -100;
		KxanNOIpJw = -100;
		cfYlnslcxM.PerformLayout();
		if (bqDnJTFXO2)
		{
			Point point = new Point(dhAnDnvCu5 * xRVnrsCVbQ + 1, QiyncqFXNh * xRVnrsCVbQ + 1);
			cfYlnslcxM.AutoScrollPosition = new Point(point.X - (cfYlnslcxM.ClientSize.Width / 2 - xRVnrsCVbQ / 2), point.Y - (cfYlnslcxM.ClientSize.Height / 2 - xRVnrsCVbQ / 2));
		}
		idZlljZTov.Invalidate();
		LvjlVtbECc = false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void fN7mCGxFmc(object P_0, MouseEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MF1nM2uDIJ = cfYlnslcxM.HorizontalScroll.Value;
		J2XnUuXe9g = cfYlnslcxM.VerticalScroll.Value;
		Point point = PointToClient(Cursor.Position);
		Jg6nxJutRc = point.X;
		MkBneOKucn = point.Y;
		BWnnLf32jl = P_1.X;
		oOAngbPE3R = P_1.Y;
		if (P_1.Button == MouseButtons.Left)
		{
			Cursor = new Cursor(Cursor.Current.Handle);
		}
		YhalWi5GLU = P_1;
		xJOnXg74AZ = false;
		Focus();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void dD3m73Cv95(object P_0, MouseEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if ((xJOnXg74AZ || P_1.Button != MouseButtons.Left) && P_1.Button != MouseButtons.Right)
		{
			return;
		}
		if (xJOnXg74AZ && P_1.Button == MouseButtons.Right)
		{
			if (YhalWi5GLU != null)
			{
				NlUmB0ML4j(YhalWi5GLU);
			}
			NlUmB0ML4j(P_1, true);
		}
		else
		{
			Lbnm0CLHTm(P_1);
			Tuple<string, int, int, int, int, int> tuple = rubmt7o8Yq(BWnnLf32jl, oOAngbPE3R);
			JAEntCB4I0 = true;
			SetChunkSelected(tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OfvmAJm5KG(object P_0, MouseEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int mF1nM2uDIJ = MF1nM2uDIJ;
		int j2XnUuXe9g = J2XnUuXe9g;
		Point point = PointToClient(Cursor.Position);
		if ((P_1.Button == MouseButtons.Left || P_1.Button == MouseButtons.Right) && (point.X > Jg6nxJutRc + 2 || point.X < Jg6nxJutRc - 2 || point.Y > MkBneOKucn + 2 || point.Y < MkBneOKucn - 2))
		{
			if (P_1.Button == MouseButtons.Left)
			{
				mF1nM2uDIJ = MF1nM2uDIJ - (point.X - Jg6nxJutRc);
				j2XnUuXe9g = J2XnUuXe9g - (point.Y - MkBneOKucn);
				if (mF1nM2uDIJ < 0)
				{
					mF1nM2uDIJ = 0;
				}
				if (mF1nM2uDIJ > cfYlnslcxM.HorizontalScroll.Maximum)
				{
					mF1nM2uDIJ = cfYlnslcxM.HorizontalScroll.Maximum;
				}
				if (j2XnUuXe9g < 0)
				{
					j2XnUuXe9g = 0;
				}
				if (j2XnUuXe9g > cfYlnslcxM.VerticalScroll.Maximum)
				{
					j2XnUuXe9g = cfYlnslcxM.VerticalScroll.Maximum;
				}
				cfYlnslcxM.HorizontalScroll.Value = mF1nM2uDIJ;
				cfYlnslcxM.VerticalScroll.Value = j2XnUuXe9g;
			}
			if (P_1.Button == MouseButtons.Right)
			{
				if (YhalWi5GLU != null)
				{
					NlUmB0ML4j(YhalWi5GLU);
				}
				NlUmB0ML4j(P_1, true);
			}
			xJOnXg74AZ = true;
		}
		HWumlBCbIr(P_1);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PQ3mdjvg6S(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ep2lmkZmht.Visible = false;
		O2Vn6n70JJ = -100;
		KxanNOIpJw = -100;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void kYmmH7h3lC()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		idZlljZTov.Invalidate();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MapSize hpqmFpgTtL()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PEDimension pEDimension = PEUtility.GetPEDimension(dpYnz7GUrv.Dimension);
		List<PERegion> list = pEDimension.Region.Values.ToList();
		MapSize mapSize = new MapSize();
		int num = 99999;
		int num2 = -99999;
		int num3 = 99999;
		int num4 = -99999;
		foreach (PERegion item in list)
		{
			if (item != null)
			{
				if (item.RX < num)
				{
					num = item.RX;
				}
				if (item.RX > num2)
				{
					num2 = item.RX;
				}
				if (item.RZ < num3)
				{
					num3 = item.RZ;
				}
				if (item.RZ > num4)
				{
					num4 = item.RZ;
				}
			}
		}
		mapSize.minX = num;
		mapSize.maxX = num2;
		mapSize.minZ = num3;
		mapSize.maxZ = num4;
		return mapSize;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void q4GmjB4sID()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (bA3lpxMOM5 == null)
		{
			string path = Path.Combine(Working.T92StMGt1p4(), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20428));
			Directory.CreateDirectory(path);
			bA3lpxMOM5 = new FileSystemWatcher();
			bA3lpxMOM5.Path = path;
			bA3lpxMOM5.NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.LastWrite | NotifyFilters.LastAccess;
			bA3lpxMOM5.Filter = "";
			bA3lpxMOM5.IncludeSubdirectories = true;
			bA3lpxMOM5.Changed += Cywm9rblUn;
			bA3lpxMOM5.Created += Cywm9rblUn;
			bA3lpxMOM5.Deleted += raVmIYeMgw;
			bA3lpxMOM5.EnableRaisingEvents = true;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void amTm80Tuh5(object P_0, RenamedEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Cywm9rblUn(object P_0, FileSystemEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!gW7niNtgst.Enabled)
		{
			gW7niNtgst.Enabled = true;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void raVmIYeMgw(object P_0, FileSystemEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		pZxlGwt7W3 = hpqmFpgTtL();
		if (!gW7niNtgst.Enabled)
		{
			gW7niNtgst.Enabled = true;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void WjjmzKVx3K(object P_0, ElapsedEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		glelS37sFq = new Bitmap(1, 1);
		gW7niNtgst.Enabled = false;
		idZlljZTov.Invalidate();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void z5vnTSFHmu(object P_0, CancelEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_1.Cancel = xJOnXg74AZ;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void dVbnSTirm4(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void xgmnGKeUUS(object P_0, ToolStripDropDownClosedEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void mcxnbuK7PD(object P_0, ScrollEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TlDnvmiMCl(object P_0, ScrollEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void VoFnwhvIf8(object P_0, MouseEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		OnEditChunkBlocks(this, new ChunkSelectedEventArgs());
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void T45n42E0Lb(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		OnCopyChunk(this, new ChunkSelectedEventArgs());
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void gafnVZclYC(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		OnPasteChunk(this, new ChunkSelectedEventArgs());
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetArea(int c1x, int c1z, int c2x, int c2z)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		G7BlZYAF9c = c1x;
		zIDlfcEsGg = c1z;
		fNalicprVu = c2x;
		GcDlsODJ0P = c2z;
		vxQlqKsQmi = true;
		idZlljZTov.Invalidate();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearArea()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		G7BlZYAF9c = 0;
		zIDlfcEsGg = 0;
		fNalicprVu = 0;
		GcDlsODJ0P = 0;
		vxQlqKsQmi = false;
		idZlljZTov.Invalidate();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hsEnWqKHos(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound tagNodeCompound = new TagNodeCompound();
		TagNodeList tagNodeList = new TagNodeList(TagType.TAG_FLOAT);
		tagNodeList.Add(new TagNodeFloat(V5TnRVL54n));
		tagNodeList.Add(new TagNodeFloat(wtfnk96inq));
		tagNodeList.Add(new TagNodeFloat(YD9nY1X0kC));
		tagNodeCompound.Add(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17418), tagNodeList);
		Tuple<string, string, int, int, int> tuple = oQ8mascj3y(BWnnLf32jl, oOAngbPE3R);
		PEProcessWorker pEProcessWorker = new PEProcessWorker();
		TagNodeCompound chunk = pEProcessWorker.GetChunk(Working.T92StMGt1p4(), 0, tuple.Item3, tuple.Item4);
		if (chunk == null || !chunk.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18204)))
		{
			return;
		}
		TagNodeCompound tagNodeCompound2 = chunk[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18204)] as TagNodeCompound;
		if (tagNodeCompound2.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20548)))
		{
			TagNodeList sections = tagNodeCompound2[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20548)] as TagNodeList;
			ExtractLayerWorker extractLayerWorker = new ExtractLayerWorker();
			List<ChunkYLayer> layers = extractLayerWorker.ExtractLayers(sections);
			SpawnPointDialog spawnPointDialog = new SpawnPointDialog(tagNodeCompound, layers, tuple.Item3, tuple.Item4);
			spawnPointDialog.ShowDialog(this);
			if (spawnPointDialog.DialogResult == DialogResult.OK)
			{
				V5TnRVL54n = (int)(float)(tagNodeList[0] as TagNodeFloat);
				wtfnk96inq = (int)(float)(tagNodeList[1] as TagNodeFloat);
				YD9nY1X0kC = (int)(float)(tagNodeList[2] as TagNodeFloat);
				idZlljZTov.Invalidate();
				a4HmR40f3X(V5TnRVL54n, wtfnk96inq, YD9nY1X0kC);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void d8enp5MJqg(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		try
		{
			Y4cnZcCZqD();
			int rx = nCGmSqkx6j(V5TnRVL54n);
			int rz = nCGmSqkx6j(YD9nY1X0kC);
			int num = AiHmbfGHEC(V5TnRVL54n);
			int num2 = AiHmbfGHEC(YD9nY1X0kC);
			JAEntCB4I0 = true;
			SetChunkSelected(rx, rz, num, num2, lxe7hMuSirBXGUQugsD.rMDSPOktq2F(num, num2));
		}
		catch (Exception)
		{
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Y4cnZcCZqD()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound tagNodeCompound = PEUtility.LoadPELevel(Working.T92StMGt1p4());
		if (tagNodeCompound != null)
		{
			if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20568)))
			{
				V5TnRVL54n = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20568)] as TagNodeInt;
			}
			if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20584)))
			{
				wtfnk96inq = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20584)] as TagNodeInt;
			}
			if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20600)))
			{
				YD9nY1X0kC = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20600)] as TagNodeInt;
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Tuple<int, int> GetSelectedChunk()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return new Tuple<int, int>(h2Clbc08YX, oOWlv5I5va);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && kQmlK0taiH != null)
		{
			kQmlK0taiH.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Y2WnfFJdKe()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		kQmlK0taiH = new Container();
		rkwlheFOrm = new Label();
		ep2lmkZmht = new Label();
		cfYlnslcxM = new FlowLayoutPanel();
		idZlljZTov = new DoubleBufferPanel();
		tyLl2GJumn = new ContextMenuStrip(kQmlK0taiH);
		MBflMGJjJx = new ToolStripMenuItem();
		axJlgXaqtS = new ToolStripMenuItem();
		jtNlLUh9jC = new ToolStripMenuItem();
		i9blURGsq7 = new ToolStripSeparator();
		ITNlyhXd2k = new ToolStripMenuItem();
		FO1l08cWYL = new ToolStripMenuItem();
		J4OlXeyvjQ = new ToolStripMenuItem();
		U7tlx43riC = new ToolStripMenuItem();
		VBFlej5tXd = new ToolStripMenuItem();
		OLElP79Bwh = new ToolStripSeparator();
		r6clR5moAx = new ToolStripMenuItem();
		OPBlB4797L = new ProgressBar();
		P7blt4hPli = new Panel();
		ti9laTpjAL = new Label();
		cfYlnslcxM.SuspendLayout();
		tyLl2GJumn.SuspendLayout();
		P7blt4hPli.SuspendLayout();
		SuspendLayout();
		rkwlheFOrm.AutoSize = true;
		rkwlheFOrm.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
		rkwlheFOrm.Location = new Point(1, 5);
		rkwlheFOrm.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14610);
		rkwlheFOrm.Size = new Size(51, 20);
		rkwlheFOrm.TabIndex = 2;
		rkwlheFOrm.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		ep2lmkZmht.AutoSize = true;
		ep2lmkZmht.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
		ep2lmkZmht.Location = new Point(101, 5);
		ep2lmkZmht.MinimumSize = new Size(2, 0);
		ep2lmkZmht.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20616);
		ep2lmkZmht.Size = new Size(51, 20);
		ep2lmkZmht.TabIndex = 3;
		ep2lmkZmht.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10582);
		ep2lmkZmht.Visible = false;
		cfYlnslcxM.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		cfYlnslcxM.AutoScroll = true;
		cfYlnslcxM.Controls.Add(idZlljZTov);
		cfYlnslcxM.Location = new Point(0, 26);
		cfYlnslcxM.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20642);
		cfYlnslcxM.Size = new Size(556, 530);
		cfYlnslcxM.TabIndex = 5;
		cfYlnslcxM.Visible = false;
		cfYlnslcxM.Scroll += TlDnvmiMCl;
		idZlljZTov.ContextMenuStrip = tyLl2GJumn;
		idZlljZTov.Location = new Point(3, 3);
		idZlljZTov.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20676);
		idZlljZTov.Size = new Size(512, 375);
		idZlljZTov.TabIndex = 0;
		idZlljZTov.Scroll += mcxnbuK7PD;
		idZlljZTov.MouseDoubleClick += VoFnwhvIf8;
		idZlljZTov.MouseDown += fN7mCGxFmc;
		idZlljZTov.MouseLeave += PQ3mdjvg6S;
		idZlljZTov.MouseMove += OfvmAJm5KG;
		idZlljZTov.MouseUp += dD3m73Cv95;
		tyLl2GJumn.Items.AddRange(new ToolStripItem[9] { MBflMGJjJx, axJlgXaqtS, jtNlLUh9jC, i9blURGsq7, ITNlyhXd2k, FO1l08cWYL, J4OlXeyvjQ, OLElP79Bwh, r6clR5moAx });
		tyLl2GJumn.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20692);
		tyLl2GJumn.Size = new Size(180, 192);
		tyLl2GJumn.Closed += xgmnGKeUUS;
		tyLl2GJumn.Opening += z5vnTSFHmu;
		tyLl2GJumn.Opened += dVbnSTirm4;
		MBflMGJjJx.Image = Resources.I3wSEsrMLCN();
		MBflMGJjJx.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20716);
		MBflMGJjJx.ShortcutKeys = Keys.B | Keys.Control;
		MBflMGJjJx.Size = new Size(179, 22);
		MBflMGJjJx.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20746);
		MBflMGJjJx.Click += LNHmLeR3i5;
		axJlgXaqtS.Image = Resources.biome;
		axJlgXaqtS.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20772);
		axJlgXaqtS.ShortcutKeys = Keys.O | Keys.Control;
		axJlgXaqtS.Size = new Size(179, 22);
		axJlgXaqtS.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20802);
		axJlgXaqtS.Click += Hw3mPhvXRT;
		jtNlLUh9jC.Image = Resources.GSPSEmZwdCt();
		jtNlLUh9jC.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20828);
		jtNlLUh9jC.ShortcutKeys = Keys.E | Keys.Control;
		jtNlLUh9jC.Size = new Size(179, 22);
		jtNlLUh9jC.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20862);
		jtNlLUh9jC.Click += LbumgR9DmJ;
		i9blURGsq7.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20892);
		i9blURGsq7.Size = new Size(176, 6);
		ITNlyhXd2k.Image = Resources.fp5S1ExUZGo();
		ITNlyhXd2k.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20932);
		ITNlyhXd2k.ShortcutKeys = Keys.C | Keys.Control;
		ITNlyhXd2k.Size = new Size(179, 22);
		ITNlyhXd2k.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20950);
		ITNlyhXd2k.Click += T45n42E0Lb;
		FO1l08cWYL.Image = Resources.XPyS13kSbEo();
		FO1l08cWYL.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20962);
		FO1l08cWYL.ShortcutKeys = Keys.V | Keys.Control;
		FO1l08cWYL.Size = new Size(179, 22);
		FO1l08cWYL.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20982);
		FO1l08cWYL.Click += gafnVZclYC;
		J4OlXeyvjQ.DropDownItems.AddRange(new ToolStripItem[2] { U7tlx43riC, VBFlej5tXd });
		J4OlXeyvjQ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20996);
		J4OlXeyvjQ.Size = new Size(179, 22);
		J4OlXeyvjQ.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10326);
		U7tlx43riC.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21046);
		U7tlx43riC.ShortcutKeys = Keys.Delete;
		U7tlx43riC.Size = new Size(162, 22);
		U7tlx43riC.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21078);
		U7tlx43riC.Click += RLXmxpcFD5;
		VBFlej5tXd.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21092);
		VBFlej5tXd.ShortcutKeys = Keys.Delete | Keys.Control;
		VBFlej5tXd.Size = new Size(162, 22);
		VBFlej5tXd.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21126);
		VBFlej5tXd.Click += jaMmMB2KI7;
		OLElP79Bwh.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21142);
		OLElP79Bwh.Size = new Size(176, 6);
		r6clR5moAx.Image = Resources.CMMSEVmHooE();
		r6clR5moAx.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21182);
		r6clR5moAx.Size = new Size(179, 22);
		r6clR5moAx.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21242);
		r6clR5moAx.Click += hsEnWqKHos;
		OPBlB4797L.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		OPBlB4797L.Location = new Point(31, 24);
		OPBlB4797L.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21270);
		OPBlB4797L.Size = new Size(484, 23);
		OPBlB4797L.Style = ProgressBarStyle.Marquee;
		OPBlB4797L.TabIndex = 0;
		P7blt4hPli.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		P7blt4hPli.Controls.Add(ti9laTpjAL);
		P7blt4hPli.Controls.Add(OPBlB4797L);
		P7blt4hPli.Location = new Point(0, 456);
		P7blt4hPli.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21298);
		P7blt4hPli.Size = new Size(556, 62);
		P7blt4hPli.TabIndex = 1;
		P7blt4hPli.Visible = false;
		ti9laTpjAL.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		ti9laTpjAL.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
		ti9laTpjAL.Location = new Point(31, 3);
		ti9laTpjAL.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		ti9laTpjAL.Size = new Size(484, 23);
		ti9laTpjAL.TabIndex = 1;
		ti9laTpjAL.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21322);
		ti9laTpjAL.TextAlign = ContentAlignment.MiddleCenter;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(P7blt4hPli);
		base.Controls.Add(cfYlnslcxM);
		base.Controls.Add(ep2lmkZmht);
		base.Controls.Add(rkwlheFOrm);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21352);
		base.Size = new Size(559, 556);
		base.Load += d8enp5MJqg;
		base.KeyDown += iPRmQmReFm;
		base.MouseDown += CODmku9w8h;
		base.MouseLeave += PYjmnbuVqH;
		base.MouseMove += EOCmmshl0l;
		base.Resize += TbbmqWWU70;
		cfYlnslcxM.ResumeLayout(performLayout: false);
		tyLl2GJumn.ResumeLayout(performLayout: false);
		P7blt4hPli.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MapDimension()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}
}
