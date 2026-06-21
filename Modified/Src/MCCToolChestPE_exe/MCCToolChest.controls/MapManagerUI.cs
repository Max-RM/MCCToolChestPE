using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MCCToolChest.events;
using MCCToolChest.forms;
using MCCToolChest.model;
using MCCToolChest.model.Parameter;
using MCCToolChest.utils;
using OAxWrWumnobfHyEL9yr;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls;

public class MapManagerUI : UserControl
{
	private EventHandler g5Y0bQFrUi;

	private ImageUtils KAD0vqlgDQ;

	private List<string> jCc0wqkUur;

	private SortedDictionary<long, MCMap> P2c04WiCtC;

	private MCMap UN20ValYus;

	private Bitmap r860WoNKls;

	private bool qdF0pY9cns;

	private bool Yaa0ZhCGys;

	private bool L420ftbDhm;

	private VScrollBar ra90iI3nBL;

	private HScrollBar U600sh5xpf;

	private byte[] UxE0qwDabO;

	private byte[] F1L0KlnVnY;

	private byte[] hBt0hRQZRI;

	private IContainer U0a0mGw9cs;

	private Label l1R0nhs605;

	private Label zrX0lLSL9Y;

	private ToolStrip YhI02BdId3;

	private ToolStripButton grv0y9uuKA;

	private ToolStripButton G0x004jVSv;

	private ToolStripButton YGr0BAIkgJ;

	private Label LE80tDIw2F;

	private Button BKa0aWVAnk;

	private Label WqT0XXtsfh;

	private Label tA10xWJHTQ;

	private NumericUpDown Mpl0egD4ff;

	private NumericUpDown jZp0Mpr7bp;

	private Label rp90UDcvoW;

	private CheckBox Hxe0LGQmaF;

	private CheckBox w8n0gqRWxS;

	private PictureBox xHq0Pq809P;

	private PictureBox QSg0RQaMjc;

	private MapItemList XgD0kV9a8q;

	private Panel OGG0YVJ3v4;

	public SortedDictionary<long, MCMap> MapList
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return P2c04WiCtC;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			P2c04WiCtC = value;
		}
	}

	public bool MapsChanged
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return L420ftbDhm;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			L420ftbDhm = value;
		}
	}

	public event EventHandler DataChanged
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = g5Y0bQFrUi;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref g5Y0bQFrUi, value2, eventHandler2);
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
			EventHandler eventHandler = g5Y0bQFrUi;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref g5Y0bQFrUi, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MapManagerUI()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		KAD0vqlgDQ = new ImageUtils();
		jCc0wqkUur = new List<string>
		{
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12722),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22148),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22160),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22172)
		};
		UxE0qwDabO = new byte[8] { 224, 0, 0, 124, 174, 247, 3, 73 };
		F1L0KlnVnY = new byte[8];
		hBt0hRQZRI = new byte[32]
		{
			255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
			82, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0
		};
		QD60GvKdpX();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Clear()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Yaa0ZhCGys = false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void zyfyYB1Kc0(MapItem P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0 != null)
		{
			QSg0RQaMjc.Image = P_0.MapImage;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void LoadMaps()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!Yaa0ZhCGys)
		{
			P2c04WiCtC = KAD0vqlgDQ.LoadMaps();
			XgD0kV9a8q.LoadList(P2c04WiCtC.Values.ToList());
			hgJy3iFH0N();
			Yaa0ZhCGys = true;
			L420ftbDhm = false;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hgJy3iFH0N()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		XgD0kV9a8q.Check();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YViy1EwY6k(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		hgJy3iFH0N();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void D6myEqZGyi(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		hgJy3iFH0N();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void J3wyrHnUXo(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MapActiveEventArgs e = P_1 as MapActiveEventArgs;
		MCMap map = e.Map;
		CCPy5qs1sk(map);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CCPy5qs1sk(MCMap P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0 != null)
		{
			UN20ValYus = P_0;
			l1R0nhs605.Text = UN20ValYus.Name;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FHRy6tBMdF(object P_0, DragEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string[] array = (string[])P_1.Data.GetData(DataFormats.FileDrop);
		if (array.Length > 0)
		{
			string text = array[0];
			string extension = Path.GetExtension(text);
			if (jCc0wqkUur.Contains(extension.ToLower()))
			{
				YdoyDdZgJS(text);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void xL1yN9xxKf(object P_0, DragEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_1.Data.GetFormats();
		P_1.Effect = DragDropEffects.Copy;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YdoyDdZgJS(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		qdF0pY9cns = true;
		if (!string.IsNullOrWhiteSpace(P_0))
		{
			r860WoNKls = new Bitmap(P_0);
			Bitmap image = ((r860WoNKls.Width > xHq0Pq809P.Width || r860WoNKls.Height > xHq0Pq809P.Height) ? KAD0vqlgDQ.ResizeWithPerspective(r860WoNKls, xHq0Pq809P.Width, xHq0Pq809P.Height, Hxe0LGQmaF.Checked) : r860WoNKls);
			xHq0Pq809P.Image = image;
			w8n0gqRWxS.Checked = true;
			w8n0gqRWxS.Enabled = true;
			Hxe0LGQmaF.Enabled = true;
			jZp0Mpr7bp.Value = r860WoNKls.Width;
			Mpl0egD4ff.Value = r860WoNKls.Height;
			rp90UDcvoW.Text = r860WoNKls.Width + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22184) + r860WoNKls.Height + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22192);
			fncyuWmqMG();
			QSg0RQaMjc.Image = image;
		}
		qdF0pY9cns = false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void c1LycvQJDX(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!qdF0pY9cns && w8n0gqRWxS.Checked)
		{
			qdF0pY9cns = true;
			decimal num = (decimal)r860WoNKls.Height / (decimal)r860WoNKls.Width;
			int num2 = (int)(jZp0Mpr7bp.Value * num);
			Mpl0egD4ff.Value = num2;
			qdF0pY9cns = false;
		}
		fncyuWmqMG();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void a5TyJ0IN7e(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!qdF0pY9cns && w8n0gqRWxS.Checked)
		{
			qdF0pY9cns = true;
			decimal num = (decimal)r860WoNKls.Width / (decimal)r860WoNKls.Height;
			int num2 = (int)(Mpl0egD4ff.Value * num);
			jZp0Mpr7bp.Value = num2;
			qdF0pY9cns = false;
		}
		fncyuWmqMG();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void fncyuWmqMG()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		decimal value = jZp0Mpr7bp.Value;
		decimal value2 = Mpl0egD4ff.Value;
		int num = (int)Math.Ceiling(value / 128m);
		int num2 = (int)Math.Ceiling(value2 / 128m);
		LE80tDIw2F.Text = string.Format(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22198), num, num2, (decimal)(num * 128) - value, (decimal)(num2 * 128) - value2);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void rSJyo0SEnp(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		nggyQ0D9vo();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void nggyQ0D9vo()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = (int)jZp0Mpr7bp.Value;
		int num2 = (int)Mpl0egD4ff.Value;
		long index = NAQyO4iMCm();
		MapConverterParameters parms = new MapConverterParameters(num, num2, r860WoNKls, P2c04WiCtC, index, w8n0gqRWxS.Checked, Hxe0LGQmaF.Checked);
		MapWorkerStatus mapWorkerStatus = new MapWorkerStatus(parms);
		mapWorkerStatus.ShowDialog(this);
		XgD0kV9a8q.LoadList(P2c04WiCtC.Values.ToList());
		XKm0TUGwvq();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private long NAQyO4iMCm()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		long result = 4200000000L;
		if (UN20ValYus != null)
		{
			result = UN20ValYus.Index;
		}
		else if (P2c04WiCtC.Count > 0)
		{
			long[] array = P2c04WiCtC.Keys.ToArray();
			result = P2c04WiCtC[array[array.Length - 1]].Index + 1;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void o0fyCP5725(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		jVCy7M4E6M();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void jVCy7M4E6M()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P2c04WiCtC != null)
		{
			long num = 4200000000L;
			if (P2c04WiCtC.Count > 0)
			{
				long[] array = P2c04WiCtC.Keys.ToArray();
				num = P2c04WiCtC[array[array.Length - 1]].Index + 1;
			}
			MCMap mCMap = new MCMap(num);
			P2c04WiCtC.Add(num, mCMap);
			XgD0kV9a8q.AddMap(mCMap);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void piiyAo9act(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		kNeydgqwaU();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void kNeydgqwaU()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22324);
		string text2 = FileUtils.BugSgNoWh4E(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22518), text, null, null);
		if (!string.IsNullOrWhiteSpace(text2))
		{
			YdoyDdZgJS(text2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void q6uyHO1ETi(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		SaveMaps();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SaveMaps()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P2c04WiCtC != null)
		{
			UBVyjg2iZa();
			foreach (MCMap value in P2c04WiCtC.Values)
			{
				if (value.MapStatus != MapStatusType.NoChange)
				{
					dB5yFb8M8T(value.Index, value.Map);
					Working.DataChanged = true;
					value.MapStatus = MapStatusType.NoChange;
				}
			}
		}
		L420ftbDhm = false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void dB5yFb8M8T(long P_0, TagNodeCompound P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		NbtTree nbtTree = new NbtTree(P_1);
		MemoryStream memoryStream = new MemoryStream();
		nbtTree.WriteTo(memoryStream);
		string filename = Working.T92StMGt1p4() + Working.WorkFolder + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22532) + P_0 + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22554);
		FileUtils.WriteFile(memoryStream, filename);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UBVyjg2iZa()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MemoryStream memoryStream = new MemoryStream();
		string format = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22566);
		int num = 0;
		if (P2c04WiCtC != null)
		{
			foreach (MCMap value in P2c04WiCtC.Values)
			{
				if (value.MapStatus == MapStatusType.New)
				{
					string s = string.Format(format, value.Index);
					byte[] bytes = Encoding.Unicode.GetBytes(s);
					byte[] array = new byte[144];
					for (int i = 0; i < bytes.Length; i++)
					{
						array[i + 1] = bytes[i];
					}
					memoryStream.Write(array, 0, array.Length);
					num++;
				}
			}
		}
		if (num > 0)
		{
			PlMy8bDRI8(num, memoryStream);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PlMy8bDRI8(int P_0, MemoryStream P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		NJVJiCuZKORGPYB1Y4v nJVJiCuZKORGPYB1Y4v = new NJVJiCuZKORGPYB1Y4v();
		string path = Working.T92StMGt1p4() ?? "";
		int num = 0;
		if (File.Exists(path))
		{
			using (BinaryReader binaryReader = new BinaryReader(File.Open(path, FileMode.Open)))
			{
				binaryReader.BaseStream.Seek(4L, SeekOrigin.Begin);
				num = nJVJiCuZKORGPYB1Y4v.PsDSRt4knGJ(binaryReader.BaseStream);
			}
			using BinaryWriter binaryWriter = new BinaryWriter(File.Open(path, FileMode.Open));
			num += P_0;
			binaryWriter.BaseStream.Seek(4L, SeekOrigin.Begin);
			nJVJiCuZKORGPYB1Y4v.aKxSRUQsOyk(num, binaryWriter.BaseStream);
			byte[] array = P_1.ToArray();
			binaryWriter.BaseStream.Seek(0L, SeekOrigin.End);
			binaryWriter.Write(array, 0, array.Length);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LCly9oAC37()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string path = Working.T92StMGt1p4() + Working.WorkFolder + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22602);
		if (File.Exists(path))
		{
			hYRyzvT814();
		}
		else
		{
			mShyILU45a();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void mShyILU45a()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P2c04WiCtC == null || P2c04WiCtC.Count <= 0)
		{
			return;
		}
		new NJVJiCuZKORGPYB1Y4v();
		string filename = Working.T92StMGt1p4() + Working.WorkFolder + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22664);
		MemoryStream memoryStream = new MemoryStream();
		for (int i = 0; i < 264; i++)
		{
			if (P2c04WiCtC.ContainsKey(i))
			{
				memoryStream.Write(UxE0qwDabO, 0, UxE0qwDabO.Length);
			}
			else
			{
				memoryStream.Write(F1L0KlnVnY, 0, F1L0KlnVnY.Length);
			}
		}
		FileUtils.WriteFile(memoryStream, filename);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hYRyzvT814()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P2c04WiCtC != null && P2c04WiCtC.Count > 0)
		{
			NJVJiCuZKORGPYB1Y4v nJVJiCuZKORGPYB1Y4v = new NJVJiCuZKORGPYB1Y4v();
			string filename = Working.T92StMGt1p4() + Working.WorkFolder + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22602);
			MemoryStream memoryStream = new MemoryStream();
			nJVJiCuZKORGPYB1Y4v.aKxSRUQsOyk(P2c04WiCtC.Count, memoryStream);
			memoryStream.Write(UxE0qwDabO, 0, UxE0qwDabO.Length);
			nJVJiCuZKORGPYB1Y4v.aKxSRUQsOyk(P2c04WiCtC.Count, memoryStream);
			int num = 12;
			for (int i = 0; i < P2c04WiCtC.Count; i++)
			{
				nJVJiCuZKORGPYB1Y4v.aKxSRUQsOyk(0, memoryStream);
				nJVJiCuZKORGPYB1Y4v.aKxSRUQsOyk(num, memoryStream);
				nJVJiCuZKORGPYB1Y4v.aKxSRUQsOyk(i, memoryStream);
			}
			memoryStream.Write(hBt0hRQZRI, 0, hBt0hRQZRI.Length);
			FileUtils.WriteFile(memoryStream, filename);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void XKm0TUGwvq()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		L420ftbDhm = true;
		OnDataChanged(this);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnDataChanged(object sender)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		g5Y0bQFrUi?.Invoke(this, null);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void u450SnSV8G(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = (base.Width - (OGG0YVJ3v4.Width + 40)) / 2;
		int num2 = XgD0kV9a8q.Top - (xHq0Pq809P.Top + 20);
		int num3 = ((num < num2) ? num : num2);
		xHq0Pq809P.Width = num3;
		xHq0Pq809P.Height = num3;
		QSg0RQaMjc.Width = num3;
		QSg0RQaMjc.Height = num3;
		xHq0Pq809P.Left = 10;
		OGG0YVJ3v4.Left = xHq0Pq809P.Left + xHq0Pq809P.Width + 10;
		QSg0RQaMjc.Left = OGG0YVJ3v4.Left + OGG0YVJ3v4.Width + 10;
		rp90UDcvoW.Top = xHq0Pq809P.Top + xHq0Pq809P.Height;
		rp90UDcvoW.Width = xHq0Pq809P.Width;
		rp90UDcvoW.Left = xHq0Pq809P.Left;
		LE80tDIw2F.Top = QSg0RQaMjc.Top + QSg0RQaMjc.Height;
		LE80tDIw2F.Width = QSg0RQaMjc.Width;
		LE80tDIw2F.Left = QSg0RQaMjc.Left;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && U0a0mGw9cs != null)
		{
			U0a0mGw9cs.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void QD60GvKdpX()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MapManagerUI));
		l1R0nhs605 = new Label();
		zrX0lLSL9Y = new Label();
		YhI02BdId3 = new ToolStrip();
		grv0y9uuKA = new ToolStripButton();
		G0x004jVSv = new ToolStripButton();
		YGr0BAIkgJ = new ToolStripButton();
		LE80tDIw2F = new Label();
		BKa0aWVAnk = new Button();
		WqT0XXtsfh = new Label();
		tA10xWJHTQ = new Label();
		Mpl0egD4ff = new NumericUpDown();
		jZp0Mpr7bp = new NumericUpDown();
		rp90UDcvoW = new Label();
		Hxe0LGQmaF = new CheckBox();
		w8n0gqRWxS = new CheckBox();
		xHq0Pq809P = new PictureBox();
		QSg0RQaMjc = new PictureBox();
		OGG0YVJ3v4 = new Panel();
		XgD0kV9a8q = new MapItemList();
		YhI02BdId3.SuspendLayout();
		((ISupportInitialize)Mpl0egD4ff).BeginInit();
		((ISupportInitialize)jZp0Mpr7bp).BeginInit();
		((ISupportInitialize)xHq0Pq809P).BeginInit();
		((ISupportInitialize)QSg0RQaMjc).BeginInit();
		OGG0YVJ3v4.SuspendLayout();
		SuspendLayout();
		l1R0nhs605.AutoSize = true;
		l1R0nhs605.Location = new Point(12, 180);
		l1R0nhs605.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22716);
		l1R0nhs605.Size = new Size(25, 13);
		l1R0nhs605.TabIndex = 40;
		l1R0nhs605.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22744);
		zrX0lLSL9Y.AutoSize = true;
		zrX0lLSL9Y.Location = new Point(12, 167);
		zrX0lLSL9Y.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10482);
		zrX0lLSL9Y.Size = new Size(61, 13);
		zrX0lLSL9Y.TabIndex = 39;
		zrX0lLSL9Y.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22760);
		YhI02BdId3.AutoSize = false;
		YhI02BdId3.GripStyle = ToolStripGripStyle.Hidden;
		YhI02BdId3.Items.AddRange(new ToolStripItem[3] { G0x004jVSv, grv0y9uuKA, YGr0BAIkgJ });
		YhI02BdId3.Location = new Point(0, 0);
		YhI02BdId3.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22784);
		YhI02BdId3.RenderMode = ToolStripRenderMode.System;
		YhI02BdId3.Size = new Size(962, 45);
		YhI02BdId3.TabIndex = 38;
		YhI02BdId3.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22784);
		grv0y9uuKA.AutoSize = false;
		grv0y9uuKA.BackColor = Color.Transparent;
		grv0y9uuKA.DisplayStyle = ToolStripItemDisplayStyle.Text;
		grv0y9uuKA.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22808));
		grv0y9uuKA.ImageTransparentColor = Color.Magenta;
		grv0y9uuKA.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22842);
		grv0y9uuKA.Size = new Size(100, 22);
		grv0y9uuKA.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22864);
		grv0y9uuKA.TextImageRelation = TextImageRelation.Overlay;
		grv0y9uuKA.Click += o0fyCP5725;
		G0x004jVSv.AutoSize = false;
		G0x004jVSv.BackColor = Color.Transparent;
		G0x004jVSv.DisplayStyle = ToolStripItemDisplayStyle.Text;
		G0x004jVSv.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22882));
		G0x004jVSv.ImageTransparentColor = Color.Magenta;
		G0x004jVSv.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22922);
		G0x004jVSv.Size = new Size(100, 22);
		G0x004jVSv.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22950);
		G0x004jVSv.TextImageRelation = TextImageRelation.Overlay;
		G0x004jVSv.Click += piiyAo9act;
		YGr0BAIkgJ.AutoSize = false;
		YGr0BAIkgJ.BackColor = Color.Transparent;
		YGr0BAIkgJ.DisplayStyle = ToolStripItemDisplayStyle.Text;
		YGr0BAIkgJ.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22974));
		YGr0BAIkgJ.ImageTransparentColor = Color.Magenta;
		YGr0BAIkgJ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23004);
		YGr0BAIkgJ.Size = new Size(100, 22);
		YGr0BAIkgJ.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23022);
		YGr0BAIkgJ.TextImageRelation = TextImageRelation.Overlay;
		YGr0BAIkgJ.Visible = false;
		YGr0BAIkgJ.Click += q6uyHO1ETi;
		LE80tDIw2F.Location = new Point(554, 446);
		LE80tDIw2F.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23050);
		LE80tDIw2F.Size = new Size(387, 12);
		LE80tDIw2F.TabIndex = 37;
		LE80tDIw2F.TextAlign = ContentAlignment.MiddleLeft;
		BKa0aWVAnk.Location = new Point(15, 122);
		BKa0aWVAnk.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23078);
		BKa0aWVAnk.Size = new Size(105, 23);
		BKa0aWVAnk.TabIndex = 36;
		BKa0aWVAnk.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23102);
		BKa0aWVAnk.UseVisualStyleBackColor = true;
		BKa0aWVAnk.Click += rSJyo0SEnp;
		WqT0XXtsfh.AutoSize = true;
		WqT0XXtsfh.Location = new Point(85, 70);
		WqT0XXtsfh.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10582);
		WqT0XXtsfh.Size = new Size(38, 13);
		WqT0XXtsfh.TabIndex = 35;
		WqT0XXtsfh.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23120);
		tA10xWJHTQ.AutoSize = true;
		tA10xWJHTQ.Location = new Point(85, 48);
		tA10xWJHTQ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		tA10xWJHTQ.Size = new Size(35, 13);
		tA10xWJHTQ.TabIndex = 34;
		tA10xWJHTQ.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23136);
		Mpl0egD4ff.Location = new Point(15, 68);
		Mpl0egD4ff.Maximum = new decimal(new int[4] { 8192, 0, 0, 0 });
		Mpl0egD4ff.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23150);
		Mpl0egD4ff.Size = new Size(63, 20);
		Mpl0egD4ff.TabIndex = 33;
		Mpl0egD4ff.ValueChanged += a5TyJ0IN7e;
		jZp0Mpr7bp.Location = new Point(15, 42);
		jZp0Mpr7bp.Maximum = new decimal(new int[4] { 8192, 0, 0, 0 });
		jZp0Mpr7bp.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23172);
		jZp0Mpr7bp.Size = new Size(63, 20);
		jZp0Mpr7bp.TabIndex = 32;
		jZp0Mpr7bp.ValueChanged += c1LycvQJDX;
		rp90UDcvoW.Location = new Point(12, 447);
		rp90UDcvoW.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23192);
		rp90UDcvoW.Size = new Size(131, 12);
		rp90UDcvoW.TabIndex = 31;
		rp90UDcvoW.TextAlign = ContentAlignment.MiddleLeft;
		Hxe0LGQmaF.AutoSize = true;
		Hxe0LGQmaF.Checked = true;
		Hxe0LGQmaF.CheckState = CheckState.Checked;
		Hxe0LGQmaF.Location = new Point(15, 98);
		Hxe0LGQmaF.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23220);
		Hxe0LGQmaF.Size = new Size(76, 17);
		Hxe0LGQmaF.TabIndex = 30;
		Hxe0LGQmaF.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23250);
		Hxe0LGQmaF.UseVisualStyleBackColor = true;
		w8n0gqRWxS.AutoSize = true;
		w8n0gqRWxS.Checked = true;
		w8n0gqRWxS.CheckState = CheckState.Checked;
		w8n0gqRWxS.Location = new Point(15, 14);
		w8n0gqRWxS.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23276);
		w8n0gqRWxS.Size = new Size(113, 17);
		w8n0gqRWxS.TabIndex = 29;
		w8n0gqRWxS.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23318);
		w8n0gqRWxS.UseVisualStyleBackColor = true;
		xHq0Pq809P.BorderStyle = BorderStyle.FixedSingle;
		xHq0Pq809P.Location = new Point(12, 59);
		xHq0Pq809P.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23356);
		xHq0Pq809P.Size = new Size(384, 384);
		xHq0Pq809P.SizeMode = PictureBoxSizeMode.CenterImage;
		xHq0Pq809P.TabIndex = 26;
		xHq0Pq809P.TabStop = false;
		QSg0RQaMjc.BorderStyle = BorderStyle.FixedSingle;
		QSg0RQaMjc.Location = new Point(557, 59);
		QSg0RQaMjc.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23378);
		QSg0RQaMjc.Size = new Size(384, 384);
		QSg0RQaMjc.SizeMode = PictureBoxSizeMode.CenterImage;
		QSg0RQaMjc.TabIndex = 27;
		QSg0RQaMjc.TabStop = false;
		OGG0YVJ3v4.Controls.Add(BKa0aWVAnk);
		OGG0YVJ3v4.Controls.Add(l1R0nhs605);
		OGG0YVJ3v4.Controls.Add(w8n0gqRWxS);
		OGG0YVJ3v4.Controls.Add(zrX0lLSL9Y);
		OGG0YVJ3v4.Controls.Add(Hxe0LGQmaF);
		OGG0YVJ3v4.Controls.Add(jZp0Mpr7bp);
		OGG0YVJ3v4.Controls.Add(Mpl0egD4ff);
		OGG0YVJ3v4.Controls.Add(tA10xWJHTQ);
		OGG0YVJ3v4.Controls.Add(WqT0XXtsfh);
		OGG0YVJ3v4.Location = new Point(402, 59);
		OGG0YVJ3v4.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23398);
		OGG0YVJ3v4.Size = new Size(140, 204);
		OGG0YVJ3v4.TabIndex = 41;
		XgD0kV9a8q.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		XgD0kV9a8q.BorderStyle = BorderStyle.FixedSingle;
		XgD0kV9a8q.Location = new Point(12, 471);
		XgD0kV9a8q.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23424);
		XgD0kV9a8q.Size = new Size(931, 195);
		XgD0kV9a8q.TabIndex = 28;
		XgD0kV9a8q.MapActive += J3wyrHnUXo;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(OGG0YVJ3v4);
		base.Controls.Add(YhI02BdId3);
		base.Controls.Add(LE80tDIw2F);
		base.Controls.Add(rp90UDcvoW);
		base.Controls.Add(xHq0Pq809P);
		base.Controls.Add(QSg0RQaMjc);
		base.Controls.Add(XgD0kV9a8q);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23452);
		base.Size = new Size(962, 679);
		base.Resize += u450SnSV8G;
		YhI02BdId3.ResumeLayout(performLayout: false);
		YhI02BdId3.PerformLayout();
		((ISupportInitialize)Mpl0egD4ff).EndInit();
		((ISupportInitialize)jZp0Mpr7bp).EndInit();
		((ISupportInitialize)xHq0Pq809P).EndInit();
		((ISupportInitialize)QSg0RQaMjc).EndInit();
		OGG0YVJ3v4.ResumeLayout(performLayout: false);
		OGG0YVJ3v4.PerformLayout();
		ResumeLayout(performLayout: false);
	}
}
