using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using afNMf7uWOyq6L7IHxiu;
using Ceiuksw9F19XMTtOq5;
using GKLeKtjBpORrSZSThqN;
using HiT3kduFNLtRQIR37JV;
using KZR2jb4Jm3EKXx6h58;
using MCCToolChest.controls;
using MCCToolChest.events;
using MCCToolChest.forms;
using MCCToolChest.Forms;
using MCCToolChest.Logic;
using MCCToolChest.MCSBCode;
using MCCToolChest.MCSBCode.Workers;
using MCCToolChest.model;
using MCCToolChest.PECode;
using MCCToolChest.Properties;
using MCCToolChest.scripting;
using MCCToolChest.utils;
using MCCToolChest.worker;
using MCCToolChest.workers;
using MCPELevelDBI.workers;
using NAppUpdate.Framework;
using NAppUpdate.Framework.Common;
using NAppUpdate.Framework.Sources;
using NBTExplorer.Controllers;
using NBTExplorer.Model;
using NBTModel.Interop;
using pdmCJqu7Vy6R8l3B4bD;
using Save_Manager.model;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using W7XEw1ukTn4yRrm2wV4;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest;

public class MainForm : Form
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass2
	{
		public UpdateManager updateManager;

		public MainForm _003C_003E4__this;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _003C_003Ec__DisplayClass2()
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _003CUpdater_CheckForUpdates_003Eb__1(IAsyncResult asyncResult)
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			Action action = _003C_003E4__this.CCSSKZGvvKF;
			if (asyncResult.IsCompleted)
			{
				try
				{
					((UpdateProcessAsyncResult)asyncResult).EndInvoke();
				}
				catch (Exception)
				{
					return;
				}
				if (updateManager.UpdatesAvailable != 0)
				{
					_003C_003E4__this.IHjShVw6Afb = true;
					action();
				}
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5
	{
		public UpdateManager updateManager;

		public MainForm _003C_003E4__this;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _003C_003Ec__DisplayClass5()
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _003CUpdateNow_003Eb__4(IAsyncResult asyncResult)
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			try
			{
				((UpdateProcessAsyncResult)asyncResult).EndInvoke();
			}
			catch (Exception)
			{
				MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(259026));
				return;
			}
			try
			{
				updateManager.ApplyUpdates(relaunchApplication: true);
				_003C_003E4__this.IHjShVw6Afb = false;
			}
			catch
			{
				MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(259082));
			}
			updateManager.CleanUp();
		}
	}

	private MCNBTTreeSupport b6jShGgrqLL;

	private Library pV9Shbu5auK;

	private ChunkLookup kh3ShvqtHgk;

	private TreeNode FXqShwtcb7L;

	private Dictionary<string, ModifiedFile> KJySh48Y2Cp;

	private bool IHjShVw6Afb;

	private EventHandler MqWShWR2Nm4;

	private EventHandler MgwShpvkLWx;

	private EventHandler Cm1ShZWcEu8;

	private EventHandler btSShflUmJV;

	private IContainer PXpShixaZCM;

	private MenuStrip bdiShsNgjVE;

	private ToolStripMenuItem wgXShqQRcuV;

	private TreeView CZCShKpUaJ9;

	private ToolStripMenuItem aUYShhESBbA;

	private ImageList OijShm4rNck;

	private SplitContainer aKYShnYoo41;

	private ToolStrip IJfShl9LiSl;

	private ToolStripButton KK6Sh2a2ydc;

	private ToolStripButton nIBShyiMArD;

	private ToolStripButton N5dSh0l8yme;

	private ToolStripSeparator Sf2ShBy8bwC;

	private ToolStripButton iIlShtmt9jE;

	private ToolStripMenuItem QdWSha9O8wM;

	private ToolStripMenuItem DKKShXoZlre;

	private StatusStrip dj9ShxRLm97;

	private ToolStripMenuItem DCASheayBH5;

	private ToolStripSeparator zr5ShM5QeuU;

	private ToolStripStatusLabel q0AShUPDFyp;

	private ToolStripStatusLabel k2jShLKDVK7;

	private ToolStripStatusLabel qK0Shgl81pa;

	private ToolTip FG0ShPxaiFX;

	private ToolStripComboBox Y9dShRQ2Gc9;

	private ToolStripMenuItem CbpShkw3q97;

	private ToolStripMenuItem YbuShYZUwZ2;

	private ToolStripMenuItem tKtSh3f4PQy;

	private ToolStripMenuItem xiVSh1rGEVr;

	private ToolStripSeparator dcNShEoug4y;

	private ToolStripMenuItem jtbShrjS9FI;

	private ToolStripMenuItem dM4Sh5k2imL;

	private ToolStripMenuItem hABSh6NNIdh;

	private ToolStripSeparator Ik1ShNjwBsv;

	private ToolStripMenuItem gmvShDOjfh2;

	private ToolStripMenuItem MPXShcYZcNI;

	private ToolStripMenuItem tvqShJ80nXm;

	private ToolStripMenuItem op8ShuAujsI;

	private ToolStripMenuItem t2MShoG9uX4;

	private ToolStripMenuItem xL4ShQhB7Ae;

	private ToolStripMenuItem ES0ShOeiX9Y;

	private ToolStripMenuItem iglShC060wL;

	private ToolStripMenuItem pF7Sh7JtZq8;

	private ToolStripMenuItem OQBShAWyHmr;

	private ToolStripMenuItem UqdShd4QmHG;

	private ToolStripMenuItem fq7ShH0cnpY;

	private ToolStripMenuItem jxpShFsxuAQ;

	private ToolStripSeparator iMnShj83d3l;

	private ContextMenuStrip kA5Sh8yt5Wm;

	private ToolStripMenuItem CZVSh9rVYwo;

	private ToolStripMenuItem XOnShI3aPat;

	private ToolStripSeparator LrKShzGj9BQ;

	private ToolStripMenuItem grMSmTvbeIG;

	private ToolStripMenuItem brkSmSSME94;

	private ToolStripMenuItem Rf7SmGQpu1s;

	private ToolStripMenuItem mhISmbl7hyW;

	private ToolStripMenuItem jFxSmvItyKV;

	private ToolStripSeparator kvpSmwvNc2S;

	private ListView x3SSm4q4WRW;

	private Panel AHWSmVeaBgQ;

	private ColumnHeader MPWSmWNxeKC;

	private ColumnHeader N5xSmpv3IGR;

	private ColumnHeader u96SmZlSB5w;

	private ColumnHeader qPvSmfDkOP6;

	private ColumnHeader fx5Smij4klp;

	private ToolStripMenuItem S2KSmsLU12T;

	private ToolStripMenuItem RKaSmqyYTyO;

	private ToolStripSeparator g6XSmKWoPwS;

	private ColumnHeader VuLSmhptcV1;

	private ToolStripStatusLabel xfFSmma9KwJ;

	private NBTFrame tPRSmnjF0Jx;

	private ToolStripMenuItem yXkSmlprASm;

	private ToolStripMenuItem os8Sm27ebC0;

	private ToolStripMenuItem RN7SmyaY4X4;

	private ToolStripMenuItem P2BSm0nMXGp;

	private ToolStripMenuItem y0LSmBHbOlc;

	private ToolStripMenuItem T1QSmt5tyMA;

	private ToolStripMenuItem LGqSmaTK6OR;

	private ToolStripMenuItem ueZSmXPhHf0;

	private ToolStripSeparator HNoSmxw1ffF;

	private RegionDisplay yh3Sme5i0Yu;

	private DimensionDisplay ym2SmMNZ1l2;

	private MapManagerUI MPASmUndjLJ;

	private ToolStripMenuItem v1TSmL4aDXY;

	private ChunkButtonsFrame IP0SmgviEFx;

	private LevelButtonsFrame BYNSmPqLFo5;

	private PlayerButtonsFrame GkXSmRRWXTn;

	private MapButtonsFrame RFPSmkGp6mu;

	private PlayerListUI zAdSmYjJLqk;

	private ToolStripMenuItem o0ESm3RR5ZG;

	private ToolStripButton sW3Sm10bBEH;

	private ToolStripMenuItem vvaSmEteF1h;

	private ToolStripMenuItem kOQSmrfC79T;

	private ToolStripMenuItem Fa9Sm5PeYX6;

	private ToolStripMenuItem Br0Sm6E28LB;

	private ToolStripSeparator qhiSmN4iDk2;

	private ToolStripMenuItem uFZSmDuOLum;

	private ToolStripButton GPhSmc367Rb;

	private ToolStripMenuItem WrLSmJensx0;

	private ToolStripSeparator OIMSmuXWrYH;

	private ToolStripMenuItem KfUSmokcHKH;

	private ToolStripSeparator BfbSmQhWs3X;

	private ToolStripMenuItem DZDSmOfh0Xu;

	private ToolStripMenuItem ablSmCDqwQF;

	private ToolStripSeparator pHCSm7aFPhs;

	private ToolStripSeparator qMLSmAuSrHd;

	private ToolStripMenuItem LFfSmdqWjkr;

	private ToolStripMenuItem Vv3SmHTyJun;

	private ToolStripMenuItem tcWSmFC1glK;

	private ToolStripMenuItem Mc3SmjYuYPm;

	private ToolStripMenuItem Jq1Sm8JKpOU;

	private ToolStripMenuItem vZoSm91aT4W;

	private ToolStripMenuItem AluSmItANiV;

	private ToolStripSeparator JVnSmzjaac5;

	private ToolStripButton RSNSnTS7qqo;

	private ToolStripSeparator GclSnSQkiOd;

	private ToolStripMenuItem ILsSnG3XMtx;

	private ToolStripMenuItem SOASnbSDFS5;

	private ToolStripMenuItem bqtSnvRrjFx;

	private ToolStripMenuItem nRfSnwysHvX;

	private ToolStripSeparator lW8Sn4CPSfC;

	private ToolStripMenuItem PTKSnVPadw7;

	private ToolStripSeparator Y50SnWxwhVg;

	public event EventHandler ChunkSelected
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = MqWShWR2Nm4;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref MqWShWR2Nm4, value2, eventHandler2);
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
			EventHandler eventHandler = MqWShWR2Nm4;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref MqWShWR2Nm4, value2, eventHandler2);
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
			EventHandler eventHandler = MgwShpvkLWx;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref MgwShpvkLWx, value2, eventHandler2);
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
			EventHandler eventHandler = MgwShpvkLWx;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref MgwShpvkLWx, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler ReloadMap
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = Cm1ShZWcEu8;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref Cm1ShZWcEu8, value2, eventHandler2);
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
			EventHandler eventHandler = Cm1ShZWcEu8;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref Cm1ShZWcEu8, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler ReDrawMap
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = btSShflUmJV;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref btSShflUmJV, value2, eventHandler2);
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
			EventHandler eventHandler = btSShflUmJV;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref btSShflUmJV, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MainForm(string[] args)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		b6jShGgrqLL = new MCNBTTreeSupport();
		KJySh48Y2Cp = new Dictionary<string, ModifiedFile>();
		VrfLq3utcbtaHoMfeNR.LTsSYeXGHCA(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88794));
		try
		{
			VrfLq3utcbtaHoMfeNR.LTsSYeXGHCA(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88864));
			dsVShSrjUpU();
			VrfLq3utcbtaHoMfeNR.LTsSYeXGHCA(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88906));
			vbnSsvsDRLZ();
			if (Settings.Default.ShowSplashScreen)
			{
				D7sSiIDnmE5();
			}
			VrfLq3utcbtaHoMfeNR.LTsSYeXGHCA(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88952));
			VZYSsbDM86J();
			VrfLq3utcbtaHoMfeNR.LTsSYeXGHCA(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88994));
			tPRSmnjF0Jx.Controller.ConfirmAction += ySASs3FNTMl;
			KK6Sh2a2ydc.Click += FGLSsDTVrma;
			nIBShyiMArD.Click += jRKSsc81AX1;
			N5dSh0l8yme.Click += PkqSsJ9eFZB;
			dM4Sh5k2imL.Click += LqFSqwwpc6H;
			jtbShrjS9FI.Click += eb1Sq4CIujq;
			hABSh6NNIdh.Click += vRDSqVaM7fb;
			tKtSh3f4PQy.Click += WLSSqWXbHTU;
			YbuShYZUwZ2.Click += LoKSqpeowO5;
			xiVSh1rGEVr.Click += G1JSqZ50CWk;
			VrfLq3utcbtaHoMfeNR.LTsSYeXGHCA(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(89016));
			tPRSmnjF0Jx.UpdateUI();
			VrfLq3utcbtaHoMfeNR.LTsSYeXGHCA(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(89036));
			UdfSqsXopYi();
			VrfLq3utcbtaHoMfeNR.LTsSYeXGHCA(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(89066));
			cbmDOtjrLfpxQy3V0nH.APnSTFvBXIb();
			VrfLq3utcbtaHoMfeNR.LTsSYeXGHCA(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(89094));
			INYifyudg3hCpcrleHt.M3CS0GsdHSs();
			VrfLq3utcbtaHoMfeNR.LTsSYeXGHCA(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(89122));
			INYifyudg3hCpcrleHt.tTYS0bysvPP();
			VrfLq3utcbtaHoMfeNR.LTsSYeXGHCA(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(89158));
			INYifyudg3hCpcrleHt.zukS0v3mZBM();
			VrfLq3utcbtaHoMfeNR.LTsSYeXGHCA(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(89198));
			INYifyudg3hCpcrleHt.aT0SyzpTSMq();
			VrfLq3utcbtaHoMfeNR.LTsSYeXGHCA(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(89226));
			INYifyudg3hCpcrleHt.MEmS0TQNDx0();
			VrfLq3utcbtaHoMfeNR.LTsSYeXGHCA(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(89262));
			INYifyudg3hCpcrleHt.o5GS0SYposK();
			BlockMaster.InitBlockManager();
			ItemTranslations.X22SB8SpAAw();
			VrfLq3utcbtaHoMfeNR.LTsSYeXGHCA(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(89302));
			BiomeLookup.EfrSwwZC8iE();
			VrfLq3utcbtaHoMfeNR.LTsSYeXGHCA(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(89336));
			VrfLq3utcbtaHoMfeNR.LTsSYeXGHCA(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(89382));
			AllowDrop = true;
			base.DragEnter += hRySsSNwQta;
			base.DragDrop += xI0SsGoeWtb;
			VrfLq3utcbtaHoMfeNR.LTsSYeXGHCA(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(89414));
			LTuSizSA8Lh();
			tPRSmnjF0Jx.AddIconImages();
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
			VrfLq3utcbtaHoMfeNR.LTsSYeXGHCA(ex.Message);
		}
		try
		{
			for (int i = 0; i < args.Length; i++)
			{
				if (args[i].Trim().ToLower() == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(89452))
				{
					Settings.Default.AutoCheckUpdates = false;
					Settings.Default.Save();
				}
			}
			if (Settings.Default.AutoCheckUpdates)
			{
				tLpSKWxSGBo();
			}
		}
		catch (Exception ex2)
		{
			MessageBox.Show(ex2.Message);
			VrfLq3utcbtaHoMfeNR.LTsSYeXGHCA(ex2.Message);
		}
		DZDSmOfh0Xu.Visible = false;
		BfbSmQhWs3X.Visible = false;
		VrfLq3utcbtaHoMfeNR.LTsSYeXGHCA(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(89474));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void D7sSiIDnmE5()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string splashCaption = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(89546);
		string splashCaption2 = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(89718);
		string splashCaption3 = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(89780);
		Random random = new Random();
		int num = random.Next(0, 10);
		if (num == 5)
		{
			SplashScreen splashScreen = new SplashScreen(splashCaption, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(89864), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(89882));
			splashScreen.ShowDialog(this);
		}
		else if (num < 5)
		{
			SplashScreen splashScreen2 = new SplashScreen(splashCaption2, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(89952), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(35292));
			splashScreen2.ShowDialog(this);
		}
		else if (num > 5)
		{
			SplashScreen splashScreen3 = new SplashScreen(splashCaption3, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(89970), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(89988));
			splashScreen3.ShowDialog(this);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LTuSizSA8Lh()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ManualResetEvent manualResetEvent = new ManualResetEvent(initialState: false);
		b9JNX7uNnV588Slcyuy b9JNX7uNnV588Slcyuy2 = new b9JNX7uNnV588Slcyuy(manualResetEvent);
		DeleteFolderWorker deleteFolderWorker = new DeleteFolderWorker();
		ThreadPool.QueueUserWorkItem(deleteFolderWorker.DoDelete, b9JNX7uNnV588Slcyuy2);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Y6VSsTaumT4(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.Icon = Resources.usMSrbJo37S();
		if (Settings.Default.AutoCheckUpdates)
		{
			BTUSKpyvTTD();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hRySsSNwQta(object P_0, DragEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_1.Data.GetDataPresent(DataFormats.FileDrop))
		{
			P_1.Effect = DragDropEffects.Copy;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void xI0SsGoeWtb(object P_0, DragEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string[] array = (string[])P_1.Data.GetData(DataFormats.FileDrop);
		if (array.Length > 0)
		{
			ddOSssaVyaD(array[0]);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void VZYSsbDM86J()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		x3SSm4q4WRW.Left = 0;
		x3SSm4q4WRW.Top = 27;
		x3SSm4q4WRW.Width = 27;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void vbnSsvsDRLZ()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		try
		{
			if (Settings.Default.UpgradeSettings)
			{
				bool autoCheckUpdates = QUbSswW7Asf(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(90044), JnbB8UjbHivoDQ8qpWn: true);
				bool useTestVersion = QUbSswW7Asf(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(90080), JnbB8UjbHivoDQ8qpWn: false);
				bool allowTelemetry = QUbSswW7Asf(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(90112), JnbB8UjbHivoDQ8qpWn: true);
				bool verifyOnDelete = QUbSswW7Asf(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(90144), JnbB8UjbHivoDQ8qpWn: true);
				bool useFileExplorer = QUbSswW7Asf(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(90176), JnbB8UjbHivoDQ8qpWn: false);
				StringCollection recentScripts = QUbSswW7Asf<StringCollection>(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(90210), null);
				Settings.Default.Upgrade();
				Settings.Default.UpgradeSettings = false;
				Settings.Default.FromPCBlockTranslations = "";
				Settings.Default.AutoCheckUpdates = autoCheckUpdates;
				Settings.Default.UseTestVersion = useTestVersion;
				Settings.Default.AllowTelemetry = allowTelemetry;
				Settings.Default.VerifyOnDelete = verifyOnDelete;
				Settings.Default.UseFileExplorer = useFileExplorer;
				Settings.Default.RecentScripts = recentScripts;
				Settings.Default.Save();
			}
		}
		catch (Exception)
		{
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private T1xY0WjK1ojMYRiDCjF QUbSswW7Asf<T1xY0WjK1ojMYRiDCjF>(string P_0, T1xY0WjK1ojMYRiDCjF JnbB8UjbHivoDQ8qpWn)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		T1xY0WjK1ojMYRiDCjF result = JnbB8UjbHivoDQ8qpWn;
		object previousVersion = Settings.Default.GetPreviousVersion(P_0);
		if (previousVersion is T1xY0WjK1ojMYRiDCjF)
		{
			result = (T1xY0WjK1ojMYRiDCjF)previousVersion;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UVwSs4vFTeY(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		B7MSsVMq0Q9();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void B7MSsVMq0Q9()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		NbtTree.IsFileBigEndian = false;
		if (tPRSmnjF0Jx.Controller.CheckModifications() || Y6PSsNQK0GQ() || Working.DataChanged)
		{
			DialogResult dialogResult = MessageBox.Show(this, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(90240), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(90318), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
			if (dialogResult == DialogResult.Yes)
			{
				XlNSsuR99ec();
			}
			if (dialogResult == DialogResult.Cancel)
			{
				return;
			}
		}
		I0qSsasuqhH(Working.T92StMGt1p4(), false);
		Working.OriginalFolder = "";
		string text = FileUtils.CheckFolderSep(Path.GetTempPath()) + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(90342) + Guid.NewGuid().ToString() + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20100);
		Directory.CreateDirectory(Path.Combine(text, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64270)));
		LevelDBWorker levelDBWorker = new LevelDBWorker();
		levelDBWorker.OpenDB(Path.Combine(text, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64270)), createIfNotExist: true);
		levelDBWorker.CloseDB();
		Directory.CreateDirectory(Path.Combine(text, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55206)));
		Directory.CreateDirectory(Path.Combine(text, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28436)));
		string fileName = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(90372);
		byte[] resourceBytes = EmbeddedUtils.GetResourceBytes(fileName);
		FileUtils.WriteFile(resourceBytes, Path.Combine(text, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43516)));
		Working.om2StUCHOnZ(text);
		IZvSsffrH2l();
		Fm6SsB53Um1(text);
		fYSSs12pvYk();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void fyXSsWWikrh(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		hvISsp5Ldwc();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hvISsp5Ldwc()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		try
		{
			if (Settings.Default.UseFileExplorer)
			{
				cxtSsi3fyqh();
			}
			else
			{
				UiLSsZ5Po1j();
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(52584) + Environment.NewLine + ex.Message, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(52686));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UiLSsZ5Po1j()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string empty = string.Empty;
		if (Directory.Exists(Utils.GetGetMCPESaveFolder()))
		{
			MCPEFolder mCPEFolder = new MCPEFolder(PCSelectDisplayType.Source);
			DialogResult dialogResult = mCPEFolder.ShowDialog(this);
			if (dialogResult != DialogResult.OK)
			{
				return;
			}
			if (mCPEFolder.q5UQiauCd2() == (BUCE1Z1t57tWTV5OPi)0)
			{
				if (tPRSmnjF0Jx.Controller.CheckModifications() || Y6PSsNQK0GQ() || Working.DataChanged)
				{
					DialogResult dialogResult2 = MessageBox.Show(this, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(90240), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(90318), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
					if (dialogResult2 == DialogResult.Yes)
					{
						XlNSsuR99ec();
					}
					if (dialogResult2 == DialogResult.Cancel)
					{
						return;
					}
				}
				IZvSsffrH2l();
				if (mCPEFolder.PEWorldFolder.FolderType == PEFolderType.PC)
				{
					empty = mCPEFolder.PEWorldFolder.Path;
					ddOSssaVyaD(empty);
				}
				else if (mCPEFolder.PEWorldFolder.FolderType == PEFolderType.WPD)
				{
					Q43Ssqn67VL(mCPEFolder.PEWorldFolder);
				}
			}
			else
			{
				cxtSsi3fyqh();
			}
		}
		else
		{
			cxtSsi3fyqh();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void IZvSsffrH2l()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		DisplayUI displayUI = DisplayUI.NONE;
		CZCShKpUaJ9.Nodes.Clear();
		OoLSsUwRB3t(displayUI, false, false, false, false);
		q0AShUPDFyp.Text = "";
		k2jShLKDVK7.Text = "";
		qK0Shgl81pa.Text = "";
		Working.DataChanged = false;
		Working.MapsGenerated = new Dictionary<string, bool>();
		Y9dShRQ2Gc9.Items.Clear();
		KJySh48Y2Cp.Clear();
		tPRSmnjF0Jx.tvNBTEdit.Nodes.Clear();
		tPRSmnjF0Jx.tvNBTEdit.SelectedNode = null;
		MPASmUndjLJ.Clear();
		x3SSm4q4WRW.Items.Clear();
		kh3ShvqtHgk = new ChunkLookup();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void cxtSsi3fyqh()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(52724);
		string text2 = FileUtils.W66SgJArfAS(Utils.GetGetMCPESaveFolder(), text);
		if (string.IsNullOrWhiteSpace(text2))
		{
			return;
		}
		if (tPRSmnjF0Jx.Controller.CheckModifications() || Y6PSsNQK0GQ() || Working.DataChanged)
		{
			DialogResult dialogResult = MessageBox.Show(this, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(90240), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(90318), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
			if (dialogResult == DialogResult.Yes)
			{
				XlNSsuR99ec();
			}
			if (dialogResult == DialogResult.Cancel)
			{
				return;
			}
		}
		ddOSssaVyaD(text2);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ddOSssaVyaD(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = null;
		string text2 = Working.T92StMGt1p4();
		bool flag = true;
		text = FileUtils.CheckFolderSep(Path.GetTempPath()) + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(90342) + Guid.NewGuid().ToString() + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20100);
		Working.KuqStcPPN9Y(new Dictionary<string, Dictionary<string, List<EntitySearchResult>>>());
		if (!string.IsNullOrWhiteSpace(P_0) && !string.IsNullOrWhiteSpace(text))
		{
			Cursor.Current = Cursors.WaitCursor;
			FileUtils.TTSSgQ9uTyR(text);
			Working.OriginalFolder = P_0;
			Working.ijjSttfGhFP(P_0);
			if (Working.RXpStXcJiRk() == PlatformType.PE)
			{
				flag = s1QSshhPOvj(P_0, text);
				NbtTree.IsFileBigEndian = false;
			}
			else
			{
				NbtTree.IsFileBigEndian = true;
			}
			I0qSsasuqhH(text2, false);
			if (flag)
			{
				tOiSsK1stO7(P_0);
				Fm6SsB53Um1(text);
				qK0Shgl81pa.Text = Working.z81Sta6xa2b();
				Settings.Default.LastOpenFile = P_0;
				Settings.Default.Save();
				Cursor.Current = Cursors.Default;
			}
			else
			{
				Working.om2StUCHOnZ(string.Empty);
			}
			fYSSs12pvYk();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Q43Ssqn67VL(PEWorldFolder P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = null;
		string text2 = Working.T92StMGt1p4();
		Working.KuqStcPPN9Y(new Dictionary<string, Dictionary<string, List<EntitySearchResult>>>());
		text = FileUtils.CheckFolderSep(Path.GetTempPath()) + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(90342) + Guid.NewGuid().ToString() + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20100);
		FileUtils.TTSSgQ9uTyR(text);
		Cursor.Current = Cursors.WaitCursor;
		JqoSsmtxTbH(P_0, text);
		tOiSsK1stO7(text);
		Working.ijjSttfGhFP(text);
		NbtTree.IsFileBigEndian = false;
		Fm6SsB53Um1(text);
		qK0Shgl81pa.Text = Working.z81Sta6xa2b();
		I0qSsasuqhH(text2, false);
		Cursor.Current = Cursors.Default;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void tOiSsK1stO7(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string fileName = Path.GetFileName(Working.OriginalFolder);
		string text = "";
		string path = Path.Combine(P_0, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(52810));
		if (File.Exists(path))
		{
			text = File.ReadAllText(path);
		}
		q0AShUPDFyp.Text = fileName + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11960) + text;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool s1QSshhPOvj(string P_0, string P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PEProcessWorker pEProcessWorker = new PEProcessWorker();
		return pEProcessWorker.DoPEStaging(P_0, P_1);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string JqoSsmtxTbH(PEWorldFolder P_0, string P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string empty = string.Empty;
		PEWPDProcessWorker pEWPDProcessWorker = new PEWPDProcessWorker();
		pEWPDProcessWorker.DoPEStaging(P_0, P_1);
		return empty;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OEZSsnoNtpZ(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!string.IsNullOrWhiteSpace(Working.OriginalFolder))
		{
			XlNSsuR99ec();
		}
		else
		{
			hTFSs2OIpbP();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void sqZSsl13MTO(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		hTFSs2OIpbP();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hTFSs2OIpbP()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string empty = string.Empty;
		empty = ((!Settings.Default.UseFileExplorer) ? kqpSsyTEtRj() : L59Ss0XyVF0());
		if (string.IsNullOrWhiteSpace(empty))
		{
			return;
		}
		string text = Path.GetFileName(empty).Trim();
		if (Directory.Exists(empty))
		{
			DialogResult dialogResult = MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(90426) + Environment.NewLine + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(90546) + text, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(90578), MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.No)
			{
				return;
			}
		}
		PEUtility.ChangeLevelName(text, Working.T92StMGt1p4());
		Directory.CreateDirectory(empty);
		Directory.CreateDirectory(Path.Combine(empty, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64270)));
		if (!string.IsNullOrWhiteSpace(Working.OriginalFolder) && Directory.Exists(Working.OriginalFolder))
		{
			FileUtils.CopyFoldersAndFiles(Working.OriginalFolder, empty);
		}
		Working.OriginalFolder = empty;
		XlNSsuR99ec();
		tOiSsK1stO7(empty);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string kqpSsyTEtRj()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string result = string.Empty;
		if (Directory.Exists(Utils.GetGetMCPESaveFolder()))
		{
			MCPEFolder mCPEFolder = new MCPEFolder(PCSelectDisplayType.Destination);
			DialogResult dialogResult = mCPEFolder.ShowDialog(this);
			if (dialogResult == DialogResult.OK)
			{
				result = ((mCPEFolder.q5UQiauCd2() != 0) ? L59Ss0XyVF0() : mCPEFolder.PEWorldFolder.Path);
			}
		}
		else
		{
			result = L59Ss0XyVF0();
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string L59Ss0XyVF0()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(52724);
		return FileUtils.W66SgJArfAS(Utils.GetGetMCPESaveFolder(), text);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Fm6SsB53Um1(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!string.IsNullOrWhiteSpace(P_0))
		{
			if (t8NSsteFoHf(P_0))
			{
				Working.DataChanged = false;
				Working.MapsGenerated = new Dictionary<string, bool>();
				OoLSsUwRB3t(DisplayUI.NONE, false, false, false, false);
				Y9dShRQ2Gc9.Items.Clear();
				KJySh48Y2Cp.Clear();
				tPRSmnjF0Jx.tvNBTEdit.Nodes.Clear();
				tPRSmnjF0Jx.tvNBTEdit.SelectedNode = null;
				MPASmUndjLJ.Clear();
				x3SSm4q4WRW.Items.Clear();
				kh3ShvqtHgk = new ChunkLookup();
				Working.om2StUCHOnZ(FileUtils.CheckFolderSep(P_0));
				PEFileTree pEFileTree = new PEFileTree();
				pEFileTree.DisplayMinecraftFiles(P_0, CZCShKpUaJ9, qK0Shgl81pa);
				fYSSs12pvYk();
				OnReloadMap(this, null);
			}
			else
			{
				MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(90650), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(90708));
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool t8NSsteFoHf(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return Working.ijjSttfGhFP(P_0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void I0qSsasuqhH(string P_0, bool P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ManualResetEvent manualResetEvent = new ManualResetEvent(initialState: false);
		DeleteFolderParameter deleteFolderParameter = new DeleteFolderParameter(P_0, manualResetEvent);
		DeleteWorkingFolder deleteWorkingFolder = new DeleteWorkingFolder();
		ThreadPool.QueueUserWorkItem(deleteWorkingFolder.DoDelete, deleteFolderParameter);
		if (P_1)
		{
			manualResetEvent.WaitOne(0, exitContext: true);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void vcnSsXOFFgy(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = FileUtils.W66SgJArfAS(Utils.GetGetMCPESaveFolder(), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(90740));
		if (!string.IsNullOrWhiteSpace(text))
		{
			FxmSsxYGl5s(text);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FxmSsxYGl5s(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!string.IsNullOrWhiteSpace(P_0))
		{
			SGExtractDialog sGExtractDialog = new SGExtractDialog("", P_0, RunTypes.Create);
			sGExtractDialog.ShowDialog(this);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void sRXSseFvyEp(object P_0, TreeViewEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0 != null)
		{
			TreeView treeView = P_0 as TreeView;
			NmHSsMvVjT5(treeView);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void NmHSsMvVjT5(TreeView P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		DisplayUI displayUI = DisplayUI.NONE;
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		if (P_0 != null)
		{
			TreeNode selectedNode = P_0.SelectedNode;
			string text = null;
			string text2 = null;
			int originalFileSize = 0;
			string text3 = null;
			if (selectedNode != null && selectedNode.Text == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28436))
			{
				selectedNode.Tag = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28436);
			}
			if (selectedNode != null && selectedNode.Tag != null)
			{
				if (FXqShwtcb7L != null && tPRSmnjF0Jx.Controller.CheckModifications())
				{
					G5fSsR0fB3e(FXqShwtcb7L, FileStateType.MODIFIED);
				}
				FXqShwtcb7L = selectedNode;
				if (selectedNode.Text == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28436))
				{
					displayUI = DisplayUI.PLAYERS;
					zAdSmYjJLqk.UpdateUI(KJySh48Y2Cp);
				}
				else if (selectedNode.Tag is DimensionWorkingData)
				{
					displayUI = DisplayUI.DIMENSION;
					eR7SsLW5iOx(selectedNode.Tag as DimensionWorkingData);
				}
				else if (selectedNode.Tag is PERegion)
				{
					displayUI = DisplayUI.REGION;
					kQYSsg20IKZ(selectedNode.Tag as PERegion);
				}
				else if (selectedNode.Tag is IndexEntry)
				{
					IndexEntry indexEntry = selectedNode.Tag as IndexEntry;
					if (indexEntry.ParentName == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28436))
					{
						flag2 = true;
					}
					if (indexEntry.FileName.StartsWith(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88438)))
					{
						flag3 = true;
					}
					if (indexEntry.FileName.ToLower().StartsWith(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43516)))
					{
						flag4 = true;
					}
					if (!indexEntry.IsRegion && (indexEntry.FileName.ToLower() == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(90774).ToLower() || indexEntry.FileName.ToLower() == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(90826).ToLower()))
					{
						displayUI = DisplayUI.MAP;
						MPASmUndjLJ.LoadMaps();
					}
					else if (!indexEntry.IsRegion)
					{
						text = Working.T92StMGt1p4() + indexEntry.FilePath;
						text2 = indexEntry.FileName;
						text3 = indexEntry.FileName;
						displayUI = DisplayUI.NBT;
					}
				}
				else if (selectedNode.Tag is ChunkData chunkData)
				{
					MemoryStream memoryStream = b6jShGgrqLL.ConvertChunk(chunkData, Working.T92StMGt1p4());
					originalFileSize = (int)memoryStream.Length;
					FileUtils.TTSSgQ9uTyR(Working.T92StMGt1p4() + Working.gEdStuTy8w0());
					text = Working.T92StMGt1p4() + Working.gEdStuTy8w0() + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(90868);
					text2 = selectedNode.Text;
					FileUtils.WriteFile(memoryStream, text);
					flag = true;
					text3 = chunkData.Key.ToString();
					displayUI = DisplayUI.NBT;
					int xWorldCoords = chunkData.XWorldCoords;
					int zWorldCoords = chunkData.ZWorldCoords;
					OnChunkSelected(this, new ChunkSelectedEventArgs(chunkData.Parent, chunkData.RegionIndex.RX, chunkData.RegionIndex.RZ, xWorldCoords, zWorldCoords, chunkData.SQ7S0L9d7YF().ChunkIndex));
				}
				if (!(selectedNode.Tag is ChunkData) && text3 != null && KJySh48Y2Cp.ContainsKey(text3))
				{
					ModifiedFile modifiedFile = KJySh48Y2Cp[text3];
					tPRSmnjF0Jx.Controller.OpenExistingNode(modifiedFile.FileNode);
					Y9dShRQ2Gc9.Text = modifiedFile.ToString();
				}
				else
				{
					QAOSskSf7ss(new string[1] { text });
					Y9dShRQ2Gc9.SelectedIndex = -1;
					if (flag)
					{
						((ChunkData)selectedNode.Tag).OriginalFileSize = originalFileSize;
					}
				}
				if (flag && tPRSmnjF0Jx.tvNBTEdit.Nodes.Count > 0)
				{
					tPRSmnjF0Jx.tvNBTEdit.Nodes[0].Text = tPRSmnjF0Jx.tvNBTEdit.Nodes[0].Text.Replace(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(90868), text2 + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(90890));
					ChunkData chunkData2 = selectedNode.Tag as ChunkData;
					int xWorldCoords2 = chunkData2.XWorldCoords;
					int zWorldCoords2 = chunkData2.ZWorldCoords;
					text2 = string.Format(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(90898), text2, eu8SsPPl9UG(xWorldCoords2), eu8SsPPl9UG(zWorldCoords2), chunkData2.SQ7S0L9d7YF().ChunkIndex);
					foreach (TreeNode node in tPRSmnjF0Jx.tvNBTEdit.Nodes)
					{
						node.Expand();
						foreach (TreeNode node2 in node.Nodes)
						{
							node2.Expand();
						}
					}
				}
				k2jShLKDVK7.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(90890) + text2;
				tPRSmnjF0Jx.tvNBTEdit.SelectedNode = null;
				fYSSs12pvYk();
			}
		}
		OoLSsUwRB3t(displayUI, flag, flag2, flag3, flag4);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OoLSsUwRB3t(DisplayUI P_0, bool P_1, bool P_2, bool P_3, bool P_4)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		yh3Sme5i0Yu.Visible = P_0 == DisplayUI.REGION;
		tPRSmnjF0Jx.Visible = P_0 == DisplayUI.NBT;
		ym2SmMNZ1l2.Visible = false;
		MPASmUndjLJ.Visible = P_0 == DisplayUI.MAP;
		IP0SmgviEFx.Visible = P_0 == DisplayUI.NBT && P_1;
		GkXSmRRWXTn.Visible = P_0 == DisplayUI.NBT && P_2;
		RFPSmkGp6mu.Visible = P_0 == DisplayUI.NBT && P_3;
		BYNSmPqLFo5.Visible = P_0 == DisplayUI.NBT && P_4;
		zAdSmYjJLqk.Visible = P_0 == DisplayUI.PLAYERS;
		h8bSKek8bUh();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void eR7SsLW5iOx(DimensionWorkingData P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ym2SmMNZ1l2.DimensionData = P_0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void kQYSsg20IKZ(PERegion P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		yh3Sme5i0Yu.RegionEntry = P_0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string eu8SsPPl9UG(int P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = P_0 * 16;
		int num2 = (P_0 + 1) * 16 - 1;
		return string.Format(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60362), num, num2);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void G5fSsR0fB3e(TreeNode P_0, FileStateType P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		DataNode existingNode = tPRSmnjF0Jx.Controller.GetExistingNode();
		string key = null;
		object tag = null;
		if (P_0.Tag is IndexEntry indexEntry)
		{
			if (!indexEntry.IsRegion)
			{
				key = indexEntry.FileName;
			}
			tag = indexEntry;
			existingNode?.Save();
		}
		else if (FXqShwtcb7L.Tag is ChunkData { Key: var key2 } chunkData)
		{
			key = key2.ToString();
			tag = chunkData;
		}
		if (!KJySh48Y2Cp.ContainsKey(key))
		{
			ModifiedFile modifiedFile = new ModifiedFile();
			modifiedFile.FileNode = existingNode;
			modifiedFile.Tag = tag;
			modifiedFile.Treenode = P_0;
			modifiedFile.FileState = P_1;
			ModifiedFile modifiedFile2 = modifiedFile;
			KJySh48Y2Cp.Add(key, modifiedFile2);
			if (modifiedFile2.FileState != FileStateType.DELETED)
			{
				Y9dShRQ2Gc9.Items.Add(modifiedFile2);
			}
		}
		else
		{
			KJySh48Y2Cp[key].FileNode = existingNode;
			if (KJySh48Y2Cp[key].FileState != FileStateType.MODIFIED)
			{
				KJySh48Y2Cp[key].FileState = P_1;
			}
		}
		if (P_0.Tag is ChunkData)
		{
			PEProcessWorker pEProcessWorker = new PEProcessWorker();
			pEProcessWorker.ProcessModifiedChunk(KJySh48Y2Cp[key], Working.T92StMGt1p4());
			KJySh48Y2Cp[key].FileState = FileStateType.PINNED;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void QAOSskSf7ss(string[] P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = tPRSmnjF0Jx.Controller.OpenPaths(P_0);
		for (int i = 0; i < P_0.Length; i++)
		{
			_ = P_0[i];
		}
		fYSSs12pvYk();
		if (num > 0)
		{
			MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(90972));
			k2jShLKDVK7.Text = "";
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool q5FSsYmCZNQ()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bool result = true;
		if (tPRSmnjF0Jx.Controller.CheckModifications() || Y6PSsNQK0GQ())
		{
			result = MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(91034), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23780), MessageBoxButtons.OKCancel) == DialogResult.OK;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ySASs3FNTMl(object P_0, MessageBoxEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (tPRSmnjF0Jx.Controller.CheckModifications() && MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23702) + P_1.Message, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23780), MessageBoxButtons.OKCancel) != DialogResult.OK)
		{
			P_1.Cancel = true;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void fYSSs12pvYk()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TreeNode selectedNode = tPRSmnjF0Jx.tvNBTEdit.SelectedNode;
		if (tPRSmnjF0Jx.tvNBTEdit.SelectedNodes.Count > 1)
		{
			cFGSs6iC327(tPRSmnjF0Jx.tvNBTEdit.SelectedNodes);
			return;
		}
		if (selectedNode != null && selectedNode.Tag is DataNode)
		{
			PnvSs5pfM17(selectedNode.Tag as DataNode);
			return;
		}
		N5dSh0l8yme.Enabled = tPRSmnjF0Jx.Controller.CheckModifications() || Y6PSsNQK0GQ() || Working.DataChanged;
		iIlShtmt9jE.Enabled = !string.IsNullOrWhiteSpace(Working.T92StMGt1p4());
		sW3Sm10bBEH.Enabled = !string.IsNullOrWhiteSpace(Working.T92StMGt1p4());
		GPhSmc367Rb.Enabled = !string.IsNullOrWhiteSpace(Working.T92StMGt1p4());
		QucSsr3RrJD(tKtSh3f4PQy, YbuShYZUwZ2, hABSh6NNIdh, dM4Sh5k2imL, xiVSh1rGEVr, jtbShrjS9FI, gmvShDOjfh2, MPXShcYZcNI);
		tvqShJ80nXm.Enabled = N5dSh0l8yme.Enabled;
		o0ESm3RR5ZG.Enabled = !string.IsNullOrWhiteSpace(Working.OriginalFolder);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void kT8SsER9LwF(params ToolStripButton[] buttons)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		foreach (ToolStripButton toolStripButton in buttons)
		{
			toolStripButton.Enabled = false;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void QucSsr3RrJD(params ToolStripMenuItem[] buttons)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		foreach (ToolStripMenuItem toolStripMenuItem in buttons)
		{
			toolStripMenuItem.Enabled = false;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PnvSs5pfM17(DataNode P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0 != null)
		{
			tvqShJ80nXm.Enabled = N5dSh0l8yme.Enabled;
			tKtSh3f4PQy.Enabled = P_0.CanCopyNode && NbtClipboardController.IsInitialized;
			YbuShYZUwZ2.Enabled = P_0.CanCutNode && NbtClipboardController.IsInitialized;
			hABSh6NNIdh.Enabled = P_0.CanDeleteNode;
			dM4Sh5k2imL.Enabled = P_0.CanEditNode;
			xiVSh1rGEVr.Enabled = P_0.CanPasteIntoNode && NbtClipboardController.IsInitialized;
			jtbShrjS9FI.Enabled = P_0.CanRenameNode;
			gmvShDOjfh2.Enabled = P_0.CanMoveNodeUp;
			MPXShcYZcNI.Enabled = P_0.CanMoveNodeDown;
			cFGSs6iC327(tPRSmnjF0Jx.tvNBTEdit.SelectedNodes);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void cFGSs6iC327(IList<TreeNode> P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0 != null)
		{
			N5dSh0l8yme.Enabled = tPRSmnjF0Jx.Controller.CheckModifications() || Y6PSsNQK0GQ() || Working.DataChanged;
			o0ESm3RR5ZG.Enabled = !string.IsNullOrWhiteSpace(Working.OriginalFolder);
			tvqShJ80nXm.Enabled = N5dSh0l8yme.Enabled;
			jtbShrjS9FI.Enabled = tPRSmnjF0Jx._buttonRename.Enabled;
			dM4Sh5k2imL.Enabled = tPRSmnjF0Jx._buttonEdit.Enabled;
			hABSh6NNIdh.Enabled = tPRSmnjF0Jx._buttonDelete.Enabled;
			gmvShDOjfh2.Enabled = tPRSmnjF0Jx.Controller.CanOperateOnSelection(NodeTreeController.Predicates.MoveNodeUpPred);
			MPXShcYZcNI.Enabled = tPRSmnjF0Jx.Controller.CanOperateOnSelection(NodeTreeController.Predicates.MoveNodeDownPred);
			YbuShYZUwZ2.Enabled = tPRSmnjF0Jx._buttonCut.Enabled;
			tKtSh3f4PQy.Enabled = tPRSmnjF0Jx._buttonCopy.Enabled;
			xiVSh1rGEVr.Enabled = tPRSmnjF0Jx._buttonPaste.Enabled;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool Y6PSsNQK0GQ()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bool result = false;
		foreach (string key in KJySh48Y2Cp.Keys)
		{
			if (KJySh48Y2Cp[key].FileState != FileStateType.PINNED)
			{
				result = true;
				break;
			}
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FGLSsDTVrma(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void jRKSsc81AX1(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Settings.Default.UseFileExplorer)
		{
			cxtSsi3fyqh();
		}
		else
		{
			UiLSsZ5Po1j();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PkqSsJ9eFZB(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!string.IsNullOrWhiteSpace(Working.OriginalFolder))
		{
			XlNSsuR99ec();
		}
		else
		{
			hTFSs2OIpbP();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void XlNSsuR99ec()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (MPASmUndjLJ.MapsChanged)
		{
			MPASmUndjLJ.SaveMaps();
		}
		if (tPRSmnjF0Jx.Controller.CheckModifications())
		{
			G5fSsR0fB3e(FXqShwtcb7L, FileStateType.MODIFIED);
		}
		if (!string.IsNullOrWhiteSpace(Working.T92StMGt1p4()))
		{
			SGExtractDialog sGExtractDialog = new SGExtractDialog(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29604), Working.T92StMGt1p4(), RunTypes.Save, KJySh48Y2Cp);
			sGExtractDialog.ShowDialog(this);
		}
		Working.DataChanged = false;
		Fm6SsB53Um1(Working.T92StMGt1p4());
		fYSSs12pvYk();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SuxSsoqRkKo(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		tPRSmnjF0Jx.Controller.EditSelection();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void yp9SsQJ2OGS(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		tPRSmnjF0Jx.Controller.RenameSelection();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void XxSSsOfG879(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		tPRSmnjF0Jx.Controller.DeleteSelection();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void KPcSsC8k0a5(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		tPRSmnjF0Jx.Controller.CopySelection();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void kotSs7xdEMn(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		tPRSmnjF0Jx.Controller.CutSelection();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hqASsA2awEQ(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		tPRSmnjF0Jx.Controller.PasteIntoSelection();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SD0SsdsH66R(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		tPRSmnjF0Jx.Controller.CreateNode(TagType.TAG_BYTE_ARRAY);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GnwSsHFgr8e(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		tPRSmnjF0Jx.Controller.CreateNode(TagType.TAG_BYTE);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void pwRSsFt4X19(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		tPRSmnjF0Jx.Controller.CreateNode(TagType.TAG_COMPOUND);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Es8Ssjxni0g(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		tPRSmnjF0Jx.Controller.CreateNode(TagType.TAG_DOUBLE);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FWBSs8VCCyS(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		tPRSmnjF0Jx.Controller.CreateNode(TagType.TAG_FLOAT);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SgFSs9XUOqL(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		tPRSmnjF0Jx.Controller.CreateNode(TagType.TAG_INT);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void X17SsIYEbIg(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		tPRSmnjF0Jx.Controller.CreateNode(TagType.TAG_INT_ARRAY);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HmdSszygcBa(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		tPRSmnjF0Jx.Controller.CreateNode(TagType.TAG_LIST);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void sSeSqTsHrga(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		tPRSmnjF0Jx.Controller.CreateNode(TagType.TAG_LONG);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void kw6SqSBAEU8(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		tPRSmnjF0Jx.Controller.CreateNode(TagType.TAG_SHORT);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void n7lSqGU2Xjf(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		tPRSmnjF0Jx.Controller.CreateNode(TagType.TAG_STRING);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PpMSqbZJ3wV(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void bGTSqvma0Us(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		tPRSmnjF0Jx.Controller.RefreshSelection();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LqFSqwwpc6H(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		tPRSmnjF0Jx.Controller.EditSelection();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void eb1Sq4CIujq(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		tPRSmnjF0Jx.Controller.RenameSelection();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void vRDSqVaM7fb(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		tPRSmnjF0Jx.Controller.DeleteSelection();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void WLSSqWXbHTU(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		tPRSmnjF0Jx.Controller.CopySelection();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LoKSqpeowO5(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		tPRSmnjF0Jx.Controller.CutSelection();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void G1JSqZ50CWk(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		tPRSmnjF0Jx.Controller.PasteIntoSelection();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ByYSqfJScxc(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LIXSyQ6hk5LvDgLGX2 lIXSyQ6hk5LvDgLGX = new LIXSyQ6hk5LvDgLGX2();
		lIXSyQ6hk5LvDgLGX.ShowDialog(this);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void VSVSqiYtpf7(object P_0, SplitterEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		UdfSqsXopYi();
		h8bSKek8bUh();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UdfSqsXopYi()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = aKYShnYoo41.Panel1.Width;
		q0AShUPDFyp.Width = num - 20;
		k2jShLKDVK7.Width = dj9ShxRLm97.Width - (num + qK0Shgl81pa.Width + 20);
		num = IJfShl9LiSl.Width;
		Y9dShRQ2Gc9.Width = num - 145;
		IJfShl9LiSl.Width = num - 1;
		IJfShl9LiSl.Width = num;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void pORSqqSnJ8E(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		FindOptions findOptions = new FindOptions();
		if (findOptions.ShowDialog(this) == DialogResult.OK)
		{
			if (findOptions.Action == FindOptionsAction.FIND_CHUNK)
			{
				ohPSqKgdS1i();
			}
			if (findOptions.Action == FindOptionsAction.FIND_ENTITY)
			{
				hdmSqFCcA5R();
			}
			if (findOptions.Action == FindOptionsAction.FIND_REPLACE)
			{
				T5MSq8ErPUD();
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ohPSqKgdS1i()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MCFindBlock mCFindBlock = new MCFindBlock(kh3ShvqtHgk);
		if (mCFindBlock.ShowDialog(this) == DialogResult.OK)
		{
			MCFindBlock.FindBlockData searchData = mCFindBlock.SearchData;
			if (searchData != null)
			{
				int num = (int)Math.Floor((double)lxe7hMuSirBXGUQugsD.VnhSPPKC0e9(searchData.x) / 32.0);
				int num2 = (int)Math.Floor((double)lxe7hMuSirBXGUQugsD.VnhSPPKC0e9(searchData.z) / 32.0);
				string text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20506) + num + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13710) + num2;
				int num3 = lxe7hMuSirBXGUQugsD.rMDSPOktq2F(searchData.x, searchData.z);
				e1ISKSIwVIo(text, Constants.dimensionById[searchData.dimension], num3);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void W4cSqhmv2D1(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Y9dShRQ2Gc9.SelectedItem is ModifiedFile modifiedFile)
		{
			CZCShKpUaJ9.SelectedNode = modifiedFile.Treenode;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AQESqmTBxjy(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		peiSqBgHQx5(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(91194));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void tihSqnL57AX(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		peiSqBgHQx5(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(91284));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void n92Sql2TDWr(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		peiSqBgHQx5(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(91372));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void l1sSq2N74QG(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		peiSqBgHQx5(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(91458));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void fuFSqy7hgwH(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		peiSqBgHQx5(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(62784));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void nyDSq051vWM(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		peiSqBgHQx5(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(91550));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void peiSqBgHQx5(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		CallBrowser callBrowser = new CallBrowser();
		callBrowser.Call(P_0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void p6oSqtMdvgq(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		new Settings();
		string text = Utils.LibraryPath();
		if (!string.IsNullOrWhiteSpace(text) && FileUtils.CheckFolderExists(text))
		{
			if (pV9Shbu5auK == null || pV9Shbu5auK.IsDisposed)
			{
				pV9Shbu5auK = new Library();
			}
			pV9Shbu5auK.Show();
			pV9Shbu5auK.WindowState = FormWindowState.Normal;
			pV9Shbu5auK.BringToFront();
			pV9Shbu5auK.Focus();
		}
		else
		{
			MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(91670), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29454));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void vpISqanvuu5(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		tPRSmnjF0Jx.Controller.MoveSelectionUp();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void mYtSqXiDnGP(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		tPRSmnjF0Jx.Controller.MoveSelectionDown();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void n9FSqxRC5iX(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Options options = new Options();
		options.ShowDialog(this);
		_ = 1;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void wZtSqemx4UQ(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (string.IsNullOrWhiteSpace(Working.OriginalFolder))
		{
			hvISsp5Ldwc();
		}
		if (!string.IsNullOrWhiteSpace(Working.T92StMGt1p4()))
		{
			ConvertToPC convertToPC = new ConvertToPC();
			Telemetry.MissingBedrockBlocks.Clear();
			Telemetry.MissingBedrockBlockStates.Clear();
			if (convertToPC.ShowDialog(this) == DialogResult.OK)
			{
				ConvertParameters convertParameters = convertToPC.ConvertParameters;
				SGExtractDialog sGExtractDialog = new SGExtractDialog(Working.T92StMGt1p4(), convertParameters, RunTypes.ConvertToPC);
				sGExtractDialog.ShowDialog(this);
				Telemetry.CheckMissingBedrockBlockStates();
			}
		}
		else
		{
			MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(91830), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(91910));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void uUZSqMUqp8L(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (string.IsNullOrWhiteSpace(Working.T92StMGt1p4()))
		{
			B7MSsVMq0Q9();
		}
		ConvertFromPC convertFromPC = new ConvertFromPC();
		if (convertFromPC.ShowDialog(this) == DialogResult.OK)
		{
			Telemetry.MissingJavaBlockStates.Clear();
			ConvertParameters convertParameters = convertFromPC.ConvertParameters;
			SGExtractDialog sGExtractDialog = new SGExtractDialog(convertParameters.PCWorldFolder, Working.T92StMGt1p4(), convertParameters, RunTypes.ConvertFromPC);
			sGExtractDialog.ShowDialog(this);
			Fm6SsB53Um1(Working.T92StMGt1p4());
			if (convertParameters.RunPostProcessing)
			{
				OgbSqUBTBq4();
			}
			Working.DataChanged = true;
			fYSSs12pvYk();
			tOiSsK1stO7(Working.T92StMGt1p4());
			Telemetry.CheckMissingJavaBlockStates();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OgbSqUBTBq4()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		_ = Settings.Default.PostProcessingSRG;
		Dictionary<string, PostProcessingSRG> dictionary = new Dictionary<string, PostProcessingSRG>();
		string postProcessingSRG = Settings.Default.PostProcessingSRG;
		if (string.IsNullOrWhiteSpace(postProcessingSRG))
		{
			return;
		}
		dictionary = JsonDataConversion.Deserialize<Dictionary<string, PostProcessingSRG>>(postProcessingSRG);
		bool flag = false;
		foreach (PostProcessingSRG value in dictionary.Values)
		{
			if (value.M9DSVPAge8G())
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			SRGPostProcessing sRGPostProcessing = new SRGPostProcessing(Working.T92StMGt1p4());
			sRGPostProcessing.ShowDialog(this);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YG8SqLmpHJ4(object P_0, MouseEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_1.Button == MouseButtons.Right && CZCShKpUaJ9.HitTest(P_1.Location).Node != null)
		{
			CZCShKpUaJ9.SelectedNode = CZCShKpUaJ9.HitTest(P_1.Location).Node;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void NfTSqgxLWcO(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		G5fSsR0fB3e(FXqShwtcb7L, FileStateType.PINNED);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DrOSqPhlNGG(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int? num = null;
		int? num2 = null;
		int? num3 = 0;
		if (tPRSmnjF0Jx.Controller.Tree.Nodes.Count <= 0 || tPRSmnjF0Jx.Controller.Tree.Nodes[0].Tag == null || !(tPRSmnjF0Jx.Controller.Tree.Nodes[0].Tag is NbtFileDataNode))
		{
			return;
		}
		NbtFileDataNode nbtFileDataNode = tPRSmnjF0Jx.Controller.Tree.Nodes[0].Tag as NbtFileDataNode;
		if (nbtFileDataNode.Nodes == null)
		{
			return;
		}
		foreach (DataNode node in nbtFileDataNode.Nodes)
		{
			if (node.NodeName == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17418))
			{
				TagNodeList tagNodeList = ((TagListDataNode)node).Tag.ToTagList();
				if (tagNodeList != null)
				{
					num = (int)(float)(tagNodeList[0] as TagNodeFloat);
					num2 = (int)(float)(tagNodeList[2] as TagNodeFloat);
				}
			}
			else if (node.NodeName == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(91934))
			{
				TagNode tag = ((TagIntDataNode)node).Tag;
				if (tag != null)
				{
					num3 = tag.ToTagInt();
				}
			}
		}
		if (num.HasValue && num2.HasValue && num3.HasValue)
		{
			if (Constants.dimensionById.ContainsKey(num3.Value))
			{
				if (kh3ShvqtHgk.DoesChunkExist(num3.Value, lxe7hMuSirBXGUQugsD.VnhSPPKC0e9(num.Value), lxe7hMuSirBXGUQugsD.VnhSPPKC0e9(num2.Value)))
				{
					TITSKT8cbrk(num3.Value, num.Value, num2.Value);
				}
				else
				{
					MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60448), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60492));
				}
			}
			else
			{
				MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(91960), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(92046));
			}
		}
		else
		{
			MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60448), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60492));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void lysSqRY7YQj(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TreeNode selectedNode = CZCShKpUaJ9.SelectedNode;
		if (selectedNode != null && selectedNode.Tag is PERegion)
		{
			CPhSqk0depC();
		}
		else
		{
			YcfSqY4ydAx();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CPhSqk0depC()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TreeNode selectedNode = CZCShKpUaJ9.SelectedNode;
		if (selectedNode != null && selectedNode.Tag is PERegion)
		{
			bool verifyOnDelete = Settings.Default.VerifyOnDelete;
			DialogResult dialogResult = DialogResult.Yes;
			PERegion pERegion = selectedNode.Tag as PERegion;
			if (verifyOnDelete)
			{
				string caption = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(92090);
				string text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(92142) + pERegion.ToString() + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(92232);
				dialogResult = MessageBox.Show(text, caption, MessageBoxButtons.YesNo);
			}
			if (dialogResult == DialogResult.Yes)
			{
				PEProcessWorker pEProcessWorker = new PEProcessWorker();
				pEProcessWorker.DeleteRegionChunks(pERegion, Working.T92StMGt1p4());
				selectedNode.Nodes.Clear();
				selectedNode.Remove();
				Working.DataChanged = true;
				fYSSs12pvYk();
				string dimension = Constants.dimensionFolderNames[pERegion.Dimension];
				MapBlockWorker.DeleteRegionImage(dimension, pERegion.ToString(), Working.T92StMGt1p4());
				PEUtility.RemovePEDimensionRegion(dimension, pERegion.ToString());
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YcfSqY4ydAx()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TreeNode selectedNode = CZCShKpUaJ9.SelectedNode;
		if (selectedNode == null || selectedNode.Tag == null || !(selectedNode.Tag is string) || !((string)selectedNode.Tag == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28436)))
		{
			return;
		}
		string caption = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(92238);
		string text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(92278);
		bool verifyOnDelete = Settings.Default.VerifyOnDelete;
		DialogResult dialogResult = DialogResult.Yes;
		if (verifyOnDelete)
		{
			dialogResult = MessageBox.Show(text, caption, MessageBoxButtons.YesNo);
		}
		if (dialogResult != DialogResult.Yes)
		{
			return;
		}
		foreach (TreeNode node in selectedNode.Nodes)
		{
			TreeNode treeNode = (FXqShwtcb7L = node);
			try
			{
				IndexEntry indexEntry = treeNode.Tag as IndexEntry;
				string path = Path.Combine(Working.T92StMGt1p4(), indexEntry.FilePath);
				if (File.Exists(path))
				{
					File.Delete(path);
				}
				dpoSq3KdnSA(indexEntry.FileName);
			}
			catch (Exception)
			{
			}
		}
		tPRSmnjF0Jx.tvNBTEdit.Nodes.Clear();
		tPRSmnjF0Jx.tvNBTEdit.SelectedNode = null;
		selectedNode.Nodes.Clear();
		FXqShwtcb7L = null;
		fYSSs12pvYk();
		zAdSmYjJLqk.UpdateUI(KJySh48Y2Cp);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void dpoSq3KdnSA(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PEProcessWorker.DeleteRecord(P_0, Working.T92StMGt1p4());
		Working.DataChanged = true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void fwXSq1cinTE(object P_0, KeyEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_1.KeyCode == Keys.Delete)
		{
			uJ0Sqr3Z0yA();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void JoKSqETt3cH(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		uJ0Sqr3Z0yA();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void uJ0Sqr3Z0yA()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TreeNode selectedNode = CZCShKpUaJ9.SelectedNode;
		if ((selectedNode != null && selectedNode.Tag != null && selectedNode.Tag is IndexEntry && ((IndexEntry)selectedNode.Tag).ParentName == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28436)) || selectedNode.Tag is ChunkData || selectedNode.Tag is PERegion)
		{
			if (selectedNode.Tag is PERegion)
			{
				CPhSqk0depC();
				return;
			}
			if (selectedNode.Tag is ChunkData)
			{
				DQtSKKL6FIv();
				return;
			}
			IndexEntry indexEntry = selectedNode.Tag as IndexEntry;
			jkSSK3vvJqy(Path.GetFileName(indexEntry.FilePath));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void x87Sq5sZxgl(object P_0, CancelEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TreeNode selectedNode = CZCShKpUaJ9.SelectedNode;
		bool flag = false;
		CZVSh9rVYwo.Visible = false;
		RKaSmqyYTyO.Visible = false;
		jFxSmvItyKV.Visible = false;
		ueZSmXPhHf0.Visible = false;
		g6XSmKWoPwS.Visible = false;
		if (selectedNode != null && selectedNode.Tag is PERegion)
		{
			ueZSmXPhHf0.Visible = true;
			flag = true;
		}
		else if (selectedNode != null && selectedNode.Tag != null)
		{
			g6XSmKWoPwS.Visible = (selectedNode.Tag is IndexEntry && ((IndexEntry)selectedNode.Tag).ParentName == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28436)) || selectedNode.Tag is ChunkData;
			if (selectedNode.Tag is ChunkData)
			{
				CZVSh9rVYwo.Visible = true;
				flag = true;
			}
			if (selectedNode.Tag is IndexEntry && ((IndexEntry)selectedNode.Tag).ParentName == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28436))
			{
				RKaSmqyYTyO.Visible = true;
				flag = true;
			}
			if ((selectedNode.Tag is IndexEntry && (((IndexEntry)selectedNode.Tag).ParentName == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28436) || ((IndexEntry)selectedNode.Tag).FileName.ToLower() == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(92348))) || selectedNode.Tag is ChunkData)
			{
				jFxSmvItyKV.Visible = true;
				flag = true;
			}
			if (selectedNode.Tag is string && (string)selectedNode.Tag == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28436))
			{
				ueZSmXPhHf0.Visible = true;
				flag = true;
			}
			g6XSmKWoPwS.Visible = true;
		}
		P_1.Cancel = !flag;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagCompoundDataNode wIxSq6aVrsW()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagCompoundDataNode tagCompoundDataNode = null;
		if (CZCShKpUaJ9.SelectedNode != null && CZCShKpUaJ9.SelectedNode.Tag is ChunkData && CZCShKpUaJ9.SelectedNode.Tag is ChunkData && tagCompoundDataNode == null)
		{
			tagCompoundDataNode = tPRSmnjF0Jx.Controller.Tree.Nodes[0].Nodes[0].Tag as TagCompoundDataNode;
		}
		return tagCompoundDataNode;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Y7eSqNqcknA()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagCompoundDataNode tagCompoundDataNode = wIxSq6aVrsW();
		if (tagCompoundDataNode == null)
		{
			return;
		}
		TagNodeCompound tagNodeCompound = tagCompoundDataNode.Tag as TagNodeCompound;
		if (QA9SqcoVyN5(tagNodeCompound))
		{
			int chunkX = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64984)] as TagNodeInt;
			int chunkZ = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64996)] as TagNodeInt;
			TagNodeList tagNodeList = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20548)].Copy() as TagNodeList;
			TagNodeList tagNodeList2 = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63796)].Copy() as TagNodeList;
			TagNodeIntArray tagNodeIntArray = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65008)] as TagNodeIntArray;
			if (tagNodeList != null && tagNodeList2 != null)
			{
				ChunkDesigner chunkDesigner = new ChunkDesigner(tagNodeList, tagNodeList2, tagNodeIntArray, chunkX, chunkZ);
				if (chunkDesigner.ShowDialog(this) == DialogResult.OK)
				{
					I0XSqDl6teC(chunkDesigner.TileEntities, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63796));
					I0XSqDl6teC(chunkDesigner.Sections, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20548));
					tagNodeIntArray.Data = chunkDesigner.HeightMap;
					tagCompoundDataNode.IsDataModified = true;
					NmHSsMvVjT5(CZCShKpUaJ9);
					ChunkData chunkData = CZCShKpUaJ9.SelectedNode.Tag as ChunkData;
					string dimension = Constants.dimensionFolderNames[chunkData.Dimension];
					MapBlockWorker mapBlockWorker = new MapBlockWorker();
					mapBlockWorker.RegenRegionImage(dimension, chunkData.RegionIndex.ToString(), Working.T92StMGt1p4());
					Working.DataChanged = true;
					fYSSs12pvYk();
				}
			}
		}
		else
		{
			MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(92394), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(92474));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void I0XSqDl6teC(TagNodeList P_0, string P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagCompoundDataNode tagCompoundDataNode = wIxSq6aVrsW();
		TagNodeCompound tagNodeCompound = tagCompoundDataNode.Tag as TagNodeCompound;
		DataNode dataNode = null;
		foreach (DataNode node in tagCompoundDataNode.Nodes)
		{
			if (node.NodeName == P_1)
			{
				dataNode = node;
				break;
			}
		}
		if (dataNode == null)
		{
			return;
		}
		dataNode.Nodes.Clear();
		TagNodeList tagNodeList = tagNodeCompound[P_1] as TagNodeList;
		tagNodeList.Clear();
		if (P_0.Count > 0)
		{
			tagNodeList.ChangeValueType(TagType.TAG_COMPOUND);
		}
		TagListDataNode tagListDataNode = dataNode as TagListDataNode;
		foreach (TagNodeCompound item in P_0)
		{
			tagListDataNode.AppendTag(item);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool QA9SqcoVyN5(TagNodeCompound P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20548)))
		{
			return P_0.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63796));
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void bNVSqJEZF27()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!(tPRSmnjF0Jx.Controller.Tree.Nodes[0].Tag is NbtFileDataNode nbtFileDataNode))
		{
			return;
		}
		TagNodeCompound root = nbtFileDataNode.Tree.Root;
		if (root != null)
		{
			TagNodeCompound tagNodeCompound = (TagNodeCompound)root.Copy();
			if (tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55206)))
			{
				tagNodeCompound = (TagNodeCompound)tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55206)];
			}
			MapManager mapManager = new MapManager(tagNodeCompound);
			if (mapManager.ShowDialog(this) == DialogResult.OK)
			{
				TagNodeByteArray tagNodeByteArray = root[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(73608)] as TagNodeByteArray;
				tagNodeByteArray.Data = mapManager.Map[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(73608)] as TagNodeByteArray;
				TagNodeByte tagNodeByte = root[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(73586)] as TagNodeByte;
				tagNodeByte.Data = byte.MaxValue;
				nbtFileDataNode.IsDataModified = true;
				NmHSsMvVjT5(CZCShKpUaJ9);
				fYSSs12pvYk();
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void uS7Squ0IMuG()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = 0;
		int num2 = 0;
		TagCompoundDataNode tagCompoundDataNode = wIxSq6aVrsW();
		if (tagCompoundDataNode == null || !(tagCompoundDataNode.Tag is TagNodeCompound tagNodeCompound) || !tagNodeCompound.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41992)))
		{
			return;
		}
		num = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64984)] as TagNodeInt;
		num2 = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64996)] as TagNodeInt;
		if (tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41992)] is TagNodeByteArray { Data: var data } tagNodeByteArray)
		{
			BiomeEditor biomeEditor = new BiomeEditor(data, num, num2);
			if (biomeEditor.ShowDialog(this) == DialogResult.OK)
			{
				tagNodeByteArray.Data = biomeEditor.Biomes;
				tagCompoundDataNode.IsDataModified = true;
				Working.DataChanged = true;
				fYSSs12pvYk();
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNodeByteArray YQMSqop2sSv(TreeNode P_0, string P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		foreach (TreeNode node in P_0.Nodes)
		{
			if (node.Text.StartsWith(P_1))
			{
				return ((TagNodeByteArray)((TagByteArrayDataNode)node.Tag).Tag).Data;
			}
		}
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private byte[] bi8SqQBtwCF(TreeNode P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		foreach (TreeNode node in P_0.Nodes)
		{
			if (node.Text.StartsWith(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(92508)))
			{
				return ((TagNodeByteArray)((TagByteArrayDataNode)node.Tag).Tag).Data;
			}
		}
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LVYSqO55UL1(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (i6tSqAWhlm8() && BfoSqdvTVVL())
		{
			BlockReplaceInteractive blockReplaceInteractive = new BlockReplaceInteractive(Working.T92StMGt1p4());
			blockReplaceInteractive.ShowDialog();
			fYSSs12pvYk();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void gLdSqCm64gB(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (i6tSqAWhlm8() && BfoSqdvTVVL())
		{
			BlockReplaceGlobal blockReplaceGlobal = new BlockReplaceGlobal(Working.T92StMGt1p4());
			blockReplaceGlobal.ShowDialog();
			fYSSs12pvYk();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void eyFSq7Rnwwm(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (i6tSqAWhlm8() && BfoSqdvTVVL())
		{
			BiomeReplaceGlobal biomeReplaceGlobal = new BiomeReplaceGlobal(Working.T92StMGt1p4());
			biomeReplaceGlobal.ShowDialog();
			fYSSs12pvYk();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool i6tSqAWhlm8()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bool result = true;
		if (string.IsNullOrWhiteSpace(Working.T92StMGt1p4()))
		{
			MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(92522), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(91910));
			result = false;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool BfoSqdvTVVL()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool enZSqH8aJmL()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!tPRSmnjF0Jx.Controller.CheckModifications())
		{
			return Y6PSsNQK0GQ();
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hdmSqFCcA5R()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (i6tSqAWhlm8())
		{
			EntitySearchEntry entitySearchEntry = new EntitySearchEntry(this, Working.T92StMGt1p4(), e1ISKSIwVIo, rv5SqjNIeaa);
			entitySearchEntry.Show(this);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void rv5SqjNIeaa(string P_0, Dictionary<string, List<EntitySearchResult>> P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Working.khEStDj4vgI() == null)
		{
			Working.KuqStcPPN9Y(new Dictionary<string, Dictionary<string, List<EntitySearchResult>>>());
		}
		Working.khEStDj4vgI()[P_0] = P_1;
		OnReDrawMap(this, null);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void T5MSq8ErPUD()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (i6tSqAWhlm8() && BfoSqdvTVVL())
		{
			FindReplaceEntry findReplaceEntry = new FindReplaceEntry(Working.T92StMGt1p4());
			findReplaceEntry.ShowDialog(this);
			if (findReplaceEntry.DataChanged)
			{
				Working.DataChanged = true;
				fYSSs12pvYk();
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ON9Sq9c0gCv(Dictionary<string, List<EntitySearchResult>> P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		x3SSm4q4WRW.Items.Clear();
		foreach (List<EntitySearchResult> value in P_0.Values)
		{
			if (value == null)
			{
				continue;
			}
			foreach (EntitySearchResult item in value)
			{
				IRISqIBWBUd(item);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void IRISqIBWBUd(EntitySearchResult P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ListViewItem listViewItem = new ListViewItem();
		listViewItem.Text = P_0.EntityId;
		listViewItem.SubItems.Add((P_0.EntityType == EntityType.Entity) ? Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15852) : Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(36926));
		listViewItem.SubItems.Add(P_0.Region);
		listViewItem.SubItems.Add(P_0.ChunkString());
		listViewItem.SubItems.Add(P_0.PositionString());
		listViewItem.SubItems.Add(P_0.Parent);
		listViewItem.Tag = P_0;
		x3SSm4q4WRW.Items.Add(listViewItem);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void qSYSqz4pRcW(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		EntitySearchResult entitySearchResult = null;
		if (x3SSm4q4WRW.SelectedItems.Count > 0)
		{
			entitySearchResult = x3SSm4q4WRW.SelectedItems[0].Tag as EntitySearchResult;
		}
		if (entitySearchResult != null)
		{
			e1ISKSIwVIo(entitySearchResult.Region, entitySearchResult.Dimension, entitySearchResult.ChunkIndex);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TITSKT8cbrk(int P_0, int P_1, int P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = (int)Math.Floor((double)lxe7hMuSirBXGUQugsD.VnhSPPKC0e9(P_1) / 32.0);
		int num2 = (int)Math.Floor((double)lxe7hMuSirBXGUQugsD.VnhSPPKC0e9(P_2) / 32.0);
		string text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20506) + num + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13710) + num2;
		int num3 = lxe7hMuSirBXGUQugsD.rMDSPOktq2F(lxe7hMuSirBXGUQugsD.VnhSPPKC0e9(P_1), lxe7hMuSirBXGUQugsD.VnhSPPKC0e9(P_2));
		e1ISKSIwVIo(text, Constants.dimensionById[P_0], num3);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void e1ISKSIwVIo(string P_0, string P_1, int P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TreeNode treeNode = null;
		TreeNode[] array = CZCShKpUaJ9.Nodes.Find(P_0, searchAllChildren: true);
		if (array != null && array.Length > 0)
		{
			TreeNode[] array2 = array;
			foreach (TreeNode treeNode2 in array2)
			{
				if (treeNode2.Parent.Text == Constants.dimensionNames[P_1])
				{
					Tm6SKjSNmYS(treeNode2);
					treeNode = treeNode2;
					break;
				}
			}
		}
		if (treeNode == null)
		{
			return;
		}
		foreach (TreeNode node in treeNode.Nodes)
		{
			if (node.Tag is ChunkData chunkData && chunkData.SQ7S0L9d7YF().ChunkIndex == P_2)
			{
				CZCShKpUaJ9.SelectedNode = node;
				break;
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void xODSKGrtaMp(object P_0, FormClosedEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!string.IsNullOrWhiteSpace(Working.T92StMGt1p4()))
		{
			base.Visible = false;
			try
			{
				Directory.Delete(Working.T92StMGt1p4(), recursive: true);
			}
			catch (Exception)
			{
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void b7ASKbFs7cP(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!string.IsNullOrWhiteSpace(Working.T92StMGt1p4()))
		{
			Process.Start(Working.T92StMGt1p4());
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void fKfSKvmcjVA(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		fYSSs12pvYk();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void WWKSKw4wL51(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Y7eSqNqcknA();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Ph6SK4J5jnn(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bNVSqJEZF27();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DDVSKVHcel8(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		uS7Squ0IMuG();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void tLpSKWxSGBo()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		try
		{
			string feedUrl = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(92564);
			if (Settings.Default.UseTestVersion)
			{
				feedUrl = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(92690);
			}
			SimpleWebSource updateSource = new SimpleWebSource(feedUrl);
			UpdateManager instance = UpdateManager.Instance;
			instance.UpdateSource = updateSource;
			instance.ReinstateIfRestarted();
		}
		catch (Exception)
		{
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BTUSKpyvTTD()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		_003C_003Ec__DisplayClass2 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass2();
		CS_0024_003C_003E8__locals6._003C_003E4__this = this;
		string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
		Environment.CurrentDirectory = baseDirectory;
		CS_0024_003C_003E8__locals6.updateManager = UpdateManager.Instance;
		CS_0024_003C_003E8__locals6.updateManager.BeginCheckForUpdates([MethodImpl(MethodImplOptions.NoInlining)] (IAsyncResult asyncResult) =>
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			Action action = CS_0024_003C_003E8__locals6._003C_003E4__this.CCSSKZGvvKF;
			if (asyncResult.IsCompleted)
			{
				try
				{
					((UpdateProcessAsyncResult)asyncResult).EndInvoke();
				}
				catch (Exception)
				{
					return;
				}
				if (CS_0024_003C_003E8__locals6.updateManager.UpdatesAvailable != 0)
				{
					CS_0024_003C_003E8__locals6._003C_003E4__this.IHjShVw6Afb = true;
					action();
				}
			}
		}, null);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CCSSKZGvvKF()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		_ = UpdateManager.Instance;
		UpdateAvailable2 updateAvailable = new UpdateAvailable2();
		DialogResult dialogResult = updateAvailable.ShowDialog();
		if (dialogResult == DialogResult.Yes)
		{
			UpdateNow();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void UpdateNow()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		_003C_003Ec__DisplayClass5 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass5();
		CS_0024_003C_003E8__locals6._003C_003E4__this = this;
		CS_0024_003C_003E8__locals6.updateManager = UpdateManager.Instance;
		CS_0024_003C_003E8__locals6.updateManager.BeginPrepareUpdates([MethodImpl(MethodImplOptions.NoInlining)] (IAsyncResult asyncResult) =>
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			try
			{
				((UpdateProcessAsyncResult)asyncResult).EndInvoke();
			}
			catch (Exception)
			{
				MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(259026));
				return;
			}
			try
			{
				CS_0024_003C_003E8__locals6.updateManager.ApplyUpdates(relaunchApplication: true);
				CS_0024_003C_003E8__locals6._003C_003E4__this.IHjShVw6Afb = false;
			}
			catch
			{
				MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(259082));
			}
			CS_0024_003C_003E8__locals6.updateManager.CleanUp();
		}, null);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void U63SKfsAQxf(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ChunkSelectedEventArgs e = P_1 as ChunkSelectedEventArgs;
		e1ISKSIwVIo(e.Region, e.Dimension, e.ChunkIndex);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GlnSKiFjNth(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ChunkSelectedEventArgs e = P_1 as ChunkSelectedEventArgs;
		e1ISKSIwVIo(e.Region, e.Dimension, e.ChunkIndex);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Oy6SKsfuNSw(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		DQtSKKL6FIv();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YxPSKqCJYRm(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		SpawnEventArgs e = P_1 as SpawnEventArgs;
		IuuSK8yBWSZ(e.X, e.Y, e.Z);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DQtSKKL6FIv()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		DialogResult dialogResult = DialogResult.Yes;
		TreeNode selectedNode = CZCShKpUaJ9.SelectedNode;
		if (selectedNode != null && selectedNode.Tag != null && selectedNode.Tag is ChunkData)
		{
			bool verifyOnDelete = Settings.Default.VerifyOnDelete;
			ChunkData chunkData = selectedNode.Tag as ChunkData;
			if (verifyOnDelete)
			{
				string caption = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(92850);
				string text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(92878);
				dialogResult = MessageBox.Show(text, caption, MessageBoxButtons.YesNo);
			}
			if (dialogResult == DialogResult.Yes)
			{
				tPRSmnjF0Jx.tvNBTEdit.Nodes.Clear();
				tPRSmnjF0Jx.tvNBTEdit.SelectedNode = null;
				PEProcessWorker pEProcessWorker = new PEProcessWorker();
				pEProcessWorker.DeleteRegionChunks(new List<ChunkData> { selectedNode.Tag as ChunkData }, Working.T92StMGt1p4());
				CZCShKpUaJ9.Nodes.Remove(selectedNode);
				fYSSs12pvYk();
				MapBlockWorker mapBlockWorker = new MapBlockWorker();
				PEDimension pEDimension = Working.PEDimensions[chunkData.Dimension];
				PERegion pERegion = pEDimension.Region[chunkData.RegionIndex.RX + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13710) + chunkData.RegionIndex.RZ];
				pERegion.Chunks[chunkData.SQ7S0L9d7YF().ChunkIndex] = 0;
				string dimension = Constants.dimensionFolderNames[chunkData.Dimension];
				mapBlockWorker.RegenRegionImage(dimension, chunkData.RegionIndex.ToString(), Working.T92StMGt1p4());
				Working.DataChanged = true;
				fYSSs12pvYk();
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YOESKhAVJAV(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ChunkSelectedEventArgs e = P_1 as ChunkSelectedEventArgs;
		TreeNode treeNode = CZCShKpUaJ9.Nodes[e.Dimension].Nodes[e.Region];
		if (treeNode != null)
		{
			CZCShKpUaJ9.SelectedNode = treeNode;
			CPhSqk0depC();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DI6SKmahS4O(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Working.DataChanged = true;
		fYSSs12pvYk();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void lNLSKnCW7Ue(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Working.DataChanged = true;
		fYSSs12pvYk();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BQ9SKlWcDTx(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnChunkSelected(object sender, ChunkSelectedEventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MqWShWR2Nm4?.Invoke(this, e);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnChunkDeleted(object sender, ChunkSelectedEventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MgwShpvkLWx?.Invoke(this, e);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void VqESK2vd6st(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Y7eSqNqcknA();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void xe3SKyvRI1j(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		aLTSKLvxjMr();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void dKqSK0maFZ9(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		uS7Squ0IMuG();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TxiSKBfUqI5(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagCompoundDataNode pContainer = wIxSq6aVrsW();
		ChunkWorker chunkWorker = new ChunkWorker();
		chunkWorker.CopyChunk(CZCShKpUaJ9, pContainer);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void jQLSKtRHTAj(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		AreaActionWorker areaActionWorker = new AreaActionWorker();
		AreaActionEventArgs e = P_1 as AreaActionEventArgs;
		areaActionWorker.DoAreaAction(e, CZCShKpUaJ9, this);
		if (e.AreaAction != AreaActionType.AREACOPY)
		{
			fYSSs12pvYk();
			Working.MapsGenerated = new Dictionary<string, bool>();
			OnReloadMap(this, null);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void dimensionDisplay_PasteChunk(object sender, EventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ChunkPastedEventArgs args = e as ChunkPastedEventArgs;
		ChunkWorker chunkWorker = new ChunkWorker();
		chunkWorker.PasteChunk(CZCShKpUaJ9, args);
		NmHSsMvVjT5(CZCShKpUaJ9);
		Working.DataChanged = true;
		fYSSs12pvYk();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnReloadMap(object sender, EventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Cm1ShZWcEu8?.Invoke(this, e);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnReDrawMap(object sender, EventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		btSShflUmJV?.Invoke(this, e);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void iyDSKal5sK6(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (i6tSqAWhlm8() && BfoSqdvTVVL() && !Working.mapIsOpen)
		{
			DimensionMap dimensionMap = new DimensionMap(this);
			dimensionMap.ChunkSelected += GlnSKiFjNth;
			dimensionMap.ChunkDeleted += Oy6SKsfuNSw;
			dimensionMap.RegionDeleted += YOESKhAVJAV;
			dimensionMap.EditChunkBlocks += VqESK2vd6st;
			dimensionMap.EditChunkEntities += xe3SKyvRI1j;
			dimensionMap.EditChunkBiomes += dKqSK0maFZ9;
			dimensionMap.CopyChunk += TxiSKBfUqI5;
			dimensionMap.PasteChunk += dimensionDisplay_PasteChunk;
			dimensionMap.AreaAction += jQLSKtRHTAj;
			dimensionMap.ChangeSpawnData += YxPSKqCJYRm;
			dimensionMap.Show();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void tTmSKXeU3Qv(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PixelArt pixelArt = new PixelArt();
		pixelArt.ShowDialog();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void V6CSKxAPlho(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		h8bSKek8bUh();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void h8bSKek8bUh()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = aKYShnYoo41.Panel2.ClientSize.Width;
		int num2 = aKYShnYoo41.Panel2.ClientSize.Height;
		tPRSmnjF0Jx.Top = 0;
		tPRSmnjF0Jx.Left = 0;
		tPRSmnjF0Jx.Height = num2;
		IP0SmgviEFx.Top = 0;
		IP0SmgviEFx.Left = num - (IP0SmgviEFx.Width + 2);
		IP0SmgviEFx.Height = num2;
		RFPSmkGp6mu.Top = 0;
		RFPSmkGp6mu.Left = num - (RFPSmkGp6mu.Width + 2);
		RFPSmkGp6mu.Height = num2;
		GkXSmRRWXTn.Top = 0;
		GkXSmRRWXTn.Left = num - (GkXSmRRWXTn.Width + 2);
		GkXSmRRWXTn.Height = num2;
		BYNSmPqLFo5.Top = 0;
		BYNSmPqLFo5.Left = num - (BYNSmPqLFo5.Width + 2);
		BYNSmPqLFo5.Height = num2;
		if (IP0SmgviEFx.Visible || RFPSmkGp6mu.Visible || GkXSmRRWXTn.Visible || BYNSmPqLFo5.Visible)
		{
			tPRSmnjF0Jx.Width = num - IP0SmgviEFx.Width;
		}
		else
		{
			tPRSmnjF0Jx.Width = num;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void qbOSKMahiLi(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		NbtFileDataNode nbtFileDataNode = tPRSmnjF0Jx.Controller.Tree.Nodes[0].Tag as NbtFileDataNode;
		TagNodeCompound root = nbtFileDataNode.Tree.Root;
		InventoryEdit inventoryEdit = new InventoryEdit(root, InventoryType.PlayerInventory);
		DialogResult dialogResult = inventoryEdit.ShowDialog(this);
		if (dialogResult != DialogResult.OK)
		{
			return;
		}
		DataNode dataNode = null;
		foreach (DataNode node in nbtFileDataNode.Nodes)
		{
			if (node.NodeName == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18452))
			{
				dataNode = node;
				break;
			}
		}
		if (dataNode != null)
		{
			dataNode.Nodes.Clear();
			TagNodeList tagNodeList = root[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18452)] as TagNodeList;
			TagNodeList tagNodeList2 = (TagNodeList)tagNodeList.Copy();
			tagNodeList.Clear();
			if (tagNodeList2.Count > 0)
			{
				tagNodeList.ChangeValueType(TagType.TAG_COMPOUND);
			}
			TagListDataNode tagListDataNode = dataNode as TagListDataNode;
			foreach (TagNodeCompound item in tagNodeList2)
			{
				tagListDataNode.AppendTag(item);
			}
			tagListDataNode.IsDataModified = true;
		}
		nbtFileDataNode.IsDataModified = true;
		NmHSsMvVjT5(CZCShKpUaJ9);
		fYSSs12pvYk();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YqpSKUcw6NZ(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		aLTSKLvxjMr();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void aLTSKLvxjMr()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagCompoundDataNode tagCompoundDataNode = wIxSq6aVrsW();
		if (tagCompoundDataNode == null)
		{
			return;
		}
		TagNodeCompound tagNodeCompound = tagCompoundDataNode.Tag as TagNodeCompound;
		if (QA9SqcoVyN5(tagNodeCompound))
		{
			int chunkX = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64984)] as TagNodeInt;
			int chunkZ = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64996)] as TagNodeInt;
			TagNodeList sections = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20548)].Copy() as TagNodeList;
			TagNodeList tagNodeList = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63796)].Copy() as TagNodeList;
			TagNodeList tagNodeList2 = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42124)].Copy() as TagNodeList;
			if (tagNodeList != null && tagNodeList2 != null)
			{
				EntityEditorDialog entityEditorDialog = new EntityEditorDialog(sections, tagNodeList2, tagNodeList, chunkX, chunkZ);
				entityEditorDialog.ShowDialog(this);
				DataNode dataNode = null;
				foreach (DataNode node in tagCompoundDataNode.Nodes)
				{
					if (node.NodeName == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63796))
					{
						dataNode = node;
						break;
					}
				}
				if (dataNode != null)
				{
					dataNode.Nodes.Clear();
					tagNodeList = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63796)] as TagNodeList;
					tagNodeList.Clear();
					if (entityEditorDialog.TileEntities.Count > 0)
					{
						tagNodeList.ChangeValueType(TagType.TAG_COMPOUND);
					}
					TagListDataNode tagListDataNode = dataNode as TagListDataNode;
					foreach (TagNodeCompound tileEntity in entityEditorDialog.TileEntities)
					{
						tagListDataNode.AppendTag(tileEntity);
					}
				}
				DataNode dataNode2 = null;
				foreach (DataNode node2 in tagCompoundDataNode.Nodes)
				{
					if (node2.NodeName == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42124))
					{
						dataNode2 = node2;
						break;
					}
				}
				if (dataNode2 != null)
				{
					dataNode2.Nodes.Clear();
					tagNodeList2 = tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(42124)] as TagNodeList;
					tagNodeList2.Clear();
					if (entityEditorDialog.Entities.Count > 0)
					{
						tagNodeList2.ChangeValueType(TagType.TAG_COMPOUND);
					}
					TagListDataNode tagListDataNode2 = dataNode2 as TagListDataNode;
					foreach (TagNodeCompound entity in entityEditorDialog.Entities)
					{
						tagListDataNode2.AppendTag(entity);
					}
				}
				tagCompoundDataNode.IsDataModified = true;
				Working.DataChanged = true;
				fYSSs12pvYk();
			}
			NmHSsMvVjT5(CZCShKpUaJ9);
		}
		else
		{
			MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(92394), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(92474));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LIuSKghblJl(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		NbtFileDataNode nbtFileDataNode = tPRSmnjF0Jx.Controller.Tree.Nodes[0].Tag as NbtFileDataNode;
		TagNodeCompound root = nbtFileDataNode.Tree.Root;
		InventoryEdit inventoryEdit = new InventoryEdit(root, InventoryType.PlayerEnderInventory);
		DialogResult dialogResult = inventoryEdit.ShowDialog(this);
		if (dialogResult != DialogResult.OK)
		{
			return;
		}
		DataNode dataNode = null;
		foreach (DataNode node in nbtFileDataNode.Nodes)
		{
			if (node.NodeName == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(92936))
			{
				dataNode = node;
				break;
			}
		}
		if (dataNode != null)
		{
			dataNode.Nodes.Clear();
			TagNodeList tagNodeList = root[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(92936)] as TagNodeList;
			TagNodeList tagNodeList2 = (TagNodeList)tagNodeList.Copy();
			tagNodeList.Clear();
			if (tagNodeList2.Count > 0)
			{
				tagNodeList.ChangeValueType(TagType.TAG_COMPOUND);
			}
			TagListDataNode tagListDataNode = dataNode as TagListDataNode;
			foreach (TagNodeCompound item in tagNodeList2)
			{
				tagListDataNode.AppendTag(item);
			}
			tagListDataNode.IsDataModified = true;
		}
		nbtFileDataNode.IsDataModified = true;
		NmHSsMvVjT5(CZCShKpUaJ9);
		fYSSs12pvYk();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void oXySKP56mQR(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PlayerActionEventArgs e = P_1 as PlayerActionEventArgs;
		GOpSKRxsWJJ(Path.GetFileName(e.Path));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GOpSKRxsWJJ(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TreeNode treeNode = fojSKkIS8kf(P_0);
		if (treeNode != null)
		{
			CZCShKpUaJ9.SelectedNode = treeNode;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TreeNode fojSKkIS8kf(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TreeNode treeNode = null;
		TreeNode result = null;
		TreeNode[] array = CZCShKpUaJ9.Nodes.Find(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28436), searchAllChildren: true);
		if (array != null && array.Length > 0)
		{
			treeNode = array[0];
		}
		if (treeNode != null)
		{
			foreach (TreeNode node in treeNode.Nodes)
			{
				if (node.Tag is IndexEntry indexEntry && indexEntry.FileName + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22554) == P_0)
				{
					result = node;
				}
			}
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void gBESKYtoqNy(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PlayerActionEventArgs e = P_1 as PlayerActionEventArgs;
		jkSSK3vvJqy(Path.GetFileName(e.Path));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void jkSSK3vvJqy(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string caption = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(92960);
		string text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(92990);
		bool verifyOnDelete = Settings.Default.VerifyOnDelete;
		DialogResult dialogResult = DialogResult.Yes;
		if (verifyOnDelete)
		{
			dialogResult = MessageBox.Show(text, caption, MessageBoxButtons.YesNo);
		}
		if (dialogResult != DialogResult.Yes)
		{
			return;
		}
		TreeNode treeNode = fojSKkIS8kf(P_0);
		if (treeNode != null)
		{
			CZCShKpUaJ9.Nodes.Remove(treeNode);
			IndexEntry indexEntry = treeNode.Tag as IndexEntry;
			string path = Path.Combine(Working.T92StMGt1p4(), indexEntry.FilePath);
			if (File.Exists(path))
			{
				File.Delete(path);
			}
			dpoSq3KdnSA(indexEntry.FileName);
			fYSSs12pvYk();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void J5fSK1rAnwZ(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (i6tSqAWhlm8())
		{
			CombineItems combineItems = new CombineItems();
			combineItems.CheckJavaItems();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AasSKE9pfFg(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ArchiveWorker archiveWorker = new ArchiveWorker();
		archiveWorker.ArchiveWorld(this);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void JOXSKrMR6bs(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ArchiveWorker archiveWorker = new ArchiveWorker();
		archiveWorker.ExtractWorld();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MyhSK5wQrgp(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bMXSK6rpWdb();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void bMXSK6rpWdb()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!(tPRSmnjF0Jx.Controller.Tree.Nodes[0].Tag is NbtFileDataNode nbtFileDataNode))
		{
			return;
		}
		TagNodeCompound root = nbtFileDataNode.Tree.Root;
		if (root != null)
		{
			string text = null;
			if (!root.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41840)))
			{
				root[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41840)] = new TagNodeString();
			}
			text = root[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41840)] as TagNodeString;
			FlatWorldLayersEditor flatWorldLayersEditor = new FlatWorldLayersEditor(text);
			if (flatWorldLayersEditor.ShowDialog(this) == DialogResult.OK)
			{
				text = flatWorldLayersEditor.FlatWorldLayers;
				TagNodeString tagNodeString = root[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(41840)] as TagNodeString;
				tagNodeString.Data = text;
				nbtFileDataNode.IsDataModified = true;
				NmHSsMvVjT5(CZCShKpUaJ9);
				fYSSs12pvYk();
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void nEHSKN5FnnF(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!string.IsNullOrWhiteSpace(Working.T92StMGt1p4()))
		{
			PlayerMapsManager playerMapsManager = new PlayerMapsManager(CZCShKpUaJ9);
			playerMapsManager.ShowDialog(this);
		}
		else
		{
			MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(93050), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(91910));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CMWSKD7UCBp(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void O4VSKcAd5wT(object P_0, FormClosingEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!dDKSKJSD2JO())
		{
			P_1.Cancel = true;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool dDKSKJSD2JO()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bool result = true;
		DialogResult dialogResult = DialogResult.OK;
		if (tPRSmnjF0Jx.Controller.CheckModifications() || Y6PSsNQK0GQ() || Working.DataChanged)
		{
			dialogResult = MessageBox.Show(this, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(90240), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(90318), MessageBoxButtons.YesNoCancel);
			if (dialogResult == DialogResult.Yes)
			{
				XlNSsuR99ec();
			}
		}
		if (dialogResult == DialogResult.Cancel)
		{
			result = false;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FccSKuJSeyR(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		try
		{
			UpdateManager.Instance.CleanUp();
			tLpSKWxSGBo();
			BTUSKpyvTTD();
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(93090));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YRGSKosnxyB(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OldSKQIrpkI(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!string.IsNullOrWhiteSpace(Working.T92StMGt1p4()))
		{
			CodeEditor codeEditor = new CodeEditor();
			codeEditor.ShowDialog(this);
		}
		else
		{
			MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(93122), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(91910));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void cjqSKOU1NR9(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!string.IsNullOrWhiteSpace(Working.T92StMGt1p4()))
		{
			MergeDialog mergeDialog = new MergeDialog();
			if (mergeDialog.ShowDialog(this) == DialogResult.OK)
			{
				MergeParameters mergeParameters = mergeDialog.MergeParameters;
				SGExtractDialog sGExtractDialog = new SGExtractDialog(mergeParameters.MergeWorldFolder, Working.T92StMGt1p4(), mergeParameters, RunTypes.MergeWorlds);
				sGExtractDialog.ShowDialog(this);
				Fm6SsB53Um1(Working.T92StMGt1p4());
				Working.DataChanged = true;
				fYSSs12pvYk();
			}
		}
		else
		{
			MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(93222), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(91910));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void dPrSKChW3Hv(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!string.IsNullOrWhiteSpace(Working.T92StMGt1p4()))
		{
			string text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(93308);
			string text2 = FileUtils.W66SgJArfAS(Utils.GetGetMCPESaveFolder(), text);
			if (!string.IsNullOrWhiteSpace(text2))
			{
				LevelDBWorker levelDBWorker = PEUtility.OpenDBWorker(Working.T92StMGt1p4());
				try
				{
					levelDBWorker.BuildAnalysis(text2);
					MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(93360), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(93408));
				}
				catch (Exception)
				{
					MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(93446), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63960));
				}
				levelDBWorker.CloseDB();
			}
		}
		else
		{
			MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(93496), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(91910));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void cyISK7PFumU(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!string.IsNullOrWhiteSpace(Working.T92StMGt1p4()))
		{
			string text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(93308);
			string text2 = FileUtils.W66SgJArfAS(Utils.GetGetMCPESaveFolder(), text);
			if (!string.IsNullOrWhiteSpace(text2))
			{
				try
				{
					DumpAsText dumpAsText = new DumpAsText();
					dumpAsText.DoDump(text2);
					MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(93360), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(93408));
				}
				catch (Exception)
				{
					MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(93446), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63960));
				}
			}
		}
		else
		{
			MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(93496), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(91910));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TvcSKAgBkS2(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!string.IsNullOrWhiteSpace(Working.T92StMGt1p4()))
		{
			LogicDeleteTickingAreas logicDeleteTickingAreas = new LogicDeleteTickingAreas();
			string result = logicDeleteTickingAreas.ProcessRegions();
			Working.DataChanged = true;
			fYSSs12pvYk();
			GenericResultDisplay genericResultDisplay = new GenericResultDisplay(result);
			genericResultDisplay.ShowDialog(this);
		}
		else
		{
			MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(93050), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(91910));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GMxSKd0DlXs(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!string.IsNullOrWhiteSpace(Working.T92StMGt1p4()))
		{
			DeletePruneEntry deletePruneEntry = new DeletePruneEntry();
			if (deletePruneEntry.ShowDialog(this) == DialogResult.OK)
			{
				AreaActionEventArgs e = new AreaActionEventArgs();
				e.AreaAction = deletePruneEntry.areaAction;
				e.X1 = deletePruneEntry.c1x;
				e.Z1 = deletePruneEntry.c1z;
				e.X2 = deletePruneEntry.c2x;
				e.Z2 = deletePruneEntry.c2z;
				jQLSKtRHTAj(this, e);
			}
		}
		else
		{
			MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(93050), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(91910));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void QSUSKHE4CSl(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!string.IsNullOrWhiteSpace(Working.T92StMGt1p4()))
		{
			ChangeBlockStateFormat changeBlockStateFormat = new ChangeBlockStateFormat();
			changeBlockStateFormat.ShowDialog(this);
			fYSSs12pvYk();
		}
		else
		{
			MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(93050), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(91910));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void xoGSKFBciIC(object P_0, TreeViewCancelEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Tm6SKjSNmYS(P_1.Node);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Tm6SKjSNmYS(TreeNode P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0 != null && P_0.Tag is PERegion && P_0.Nodes.Count == 1)
		{
			TreeNode treeNode = P_0.Nodes[0];
			if (treeNode.Tag is string && (string)treeNode.Tag == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(93588))
			{
				PERegion region = P_0.Tag as PERegion;
				P_0.Nodes.Remove(treeNode);
				PEFileTree pEFileTree = new PEFileTree();
				CZCShKpUaJ9.BeginUpdate();
				pEFileTree.DisplayChunkNodes(P_0, region);
				CZCShKpUaJ9.EndUpdate();
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void IuuSK8yBWSZ(int P_0, int P_1, int P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeCompound tagNodeCompound = PEUtility.LoadPELevel(Working.T92StMGt1p4());
		if (tagNodeCompound != null)
		{
			tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20568)] = new TagNodeInt(P_0);
			tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20584)] = new TagNodeInt(P_1);
			tagNodeCompound[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20600)] = new TagNodeInt(P_2);
			string text = Path.Combine(Working.T92StMGt1p4(), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43516));
			lxe7hMuSirBXGUQugsD.EAISPUuIyGd(tagNodeCompound, text);
			Working.DataChanged = true;
			fYSSs12pvYk();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void dfRSK9njm34(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		peiSqBgHQx5(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(89988));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void jtwSKIxL2Yl(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		peiSqBgHQx5(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(93614));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void h4YSKzPlSN1(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ErrorLogViewer errorLogViewer = new ErrorLogViewer();
		errorLogViewer.ShowDialog();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void VfBShTPNqrK(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		peiSqBgHQx5(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(89882));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && PXpShixaZCM != null)
		{
			PXpShixaZCM.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void dsVShSrjUpU()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PXpShixaZCM = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MainForm));
		bdiShsNgjVE = new MenuStrip();
		wgXShqQRcuV = new ToolStripMenuItem();
		AluSmItANiV = new ToolStripMenuItem();
		aUYShhESBbA = new ToolStripMenuItem();
		JVnSmzjaac5 = new ToolStripSeparator();
		tvqShJ80nXm = new ToolStripMenuItem();
		o0ESm3RR5ZG = new ToolStripMenuItem();
		qhiSmN4iDk2 = new ToolStripSeparator();
		kOQSmrfC79T = new ToolStripMenuItem();
		Fa9Sm5PeYX6 = new ToolStripMenuItem();
		Br0Sm6E28LB = new ToolStripMenuItem();
		CbpShkw3q97 = new ToolStripMenuItem();
		YbuShYZUwZ2 = new ToolStripMenuItem();
		tKtSh3f4PQy = new ToolStripMenuItem();
		xiVSh1rGEVr = new ToolStripMenuItem();
		dcNShEoug4y = new ToolStripSeparator();
		jtbShrjS9FI = new ToolStripMenuItem();
		dM4Sh5k2imL = new ToolStripMenuItem();
		hABSh6NNIdh = new ToolStripMenuItem();
		Ik1ShNjwBsv = new ToolStripSeparator();
		gmvShDOjfh2 = new ToolStripMenuItem();
		MPXShcYZcNI = new ToolStripMenuItem();
		ES0ShOeiX9Y = new ToolStripMenuItem();
		iglShC060wL = new ToolStripMenuItem();
		pF7Sh7JtZq8 = new ToolStripMenuItem();
		OQBShAWyHmr = new ToolStripMenuItem();
		grMSmTvbeIG = new ToolStripMenuItem();
		Rf7SmGQpu1s = new ToolStripMenuItem();
		brkSmSSME94 = new ToolStripMenuItem();
		mhISmbl7hyW = new ToolStripMenuItem();
		ablSmCDqwQF = new ToolStripMenuItem();
		pHCSm7aFPhs = new ToolStripSeparator();
		v1TSmL4aDXY = new ToolStripMenuItem();
		UqdShd4QmHG = new ToolStripMenuItem();
		uFZSmDuOLum = new ToolStripMenuItem();
		HNoSmxw1ffF = new ToolStripSeparator();
		WrLSmJensx0 = new ToolStripMenuItem();
		BfbSmQhWs3X = new ToolStripSeparator();
		DZDSmOfh0Xu = new ToolStripMenuItem();
		OIMSmuXWrYH = new ToolStripSeparator();
		LFfSmdqWjkr = new ToolStripMenuItem();
		vZoSm91aT4W = new ToolStripMenuItem();
		Jq1Sm8JKpOU = new ToolStripMenuItem();
		Vv3SmHTyJun = new ToolStripMenuItem();
		Mc3SmjYuYPm = new ToolStripMenuItem();
		tcWSmFC1glK = new ToolStripMenuItem();
		KfUSmokcHKH = new ToolStripMenuItem();
		vvaSmEteF1h = new ToolStripMenuItem();
		qMLSmAuSrHd = new ToolStripSeparator();
		fq7ShH0cnpY = new ToolStripMenuItem();
		QdWSha9O8wM = new ToolStripMenuItem();
		DCASheayBH5 = new ToolStripMenuItem();
		op8ShuAujsI = new ToolStripMenuItem();
		t2MShoG9uX4 = new ToolStripMenuItem();
		xL4ShQhB7Ae = new ToolStripMenuItem();
		S2KSmsLU12T = new ToolStripMenuItem();
		zr5ShM5QeuU = new ToolStripSeparator();
		jxpShFsxuAQ = new ToolStripMenuItem();
		GclSnSQkiOd = new ToolStripSeparator();
		ILsSnG3XMtx = new ToolStripMenuItem();
		bqtSnvRrjFx = new ToolStripMenuItem();
		SOASnbSDFS5 = new ToolStripMenuItem();
		iMnShj83d3l = new ToolStripSeparator();
		PTKSnVPadw7 = new ToolStripMenuItem();
		Y50SnWxwhVg = new ToolStripSeparator();
		XOnShI3aPat = new ToolStripMenuItem();
		LrKShzGj9BQ = new ToolStripSeparator();
		nRfSnwysHvX = new ToolStripMenuItem();
		lW8Sn4CPSfC = new ToolStripSeparator();
		DKKShXoZlre = new ToolStripMenuItem();
		yXkSmlprASm = new ToolStripMenuItem();
		os8Sm27ebC0 = new ToolStripMenuItem();
		RN7SmyaY4X4 = new ToolStripMenuItem();
		P2BSm0nMXGp = new ToolStripMenuItem();
		y0LSmBHbOlc = new ToolStripMenuItem();
		T1QSmt5tyMA = new ToolStripMenuItem();
		LGqSmaTK6OR = new ToolStripMenuItem();
		CZCShKpUaJ9 = new TreeView();
		kA5Sh8yt5Wm = new ContextMenuStrip(PXpShixaZCM);
		RKaSmqyYTyO = new ToolStripMenuItem();
		CZVSh9rVYwo = new ToolStripMenuItem();
		g6XSmKWoPwS = new ToolStripSeparator();
		jFxSmvItyKV = new ToolStripMenuItem();
		ueZSmXPhHf0 = new ToolStripMenuItem();
		OijShm4rNck = new ImageList(PXpShixaZCM);
		aKYShnYoo41 = new SplitContainer();
		AHWSmVeaBgQ = new Panel();
		x3SSm4q4WRW = new ListView();
		MPWSmWNxeKC = new ColumnHeader();
		N5xSmpv3IGR = new ColumnHeader();
		u96SmZlSB5w = new ColumnHeader();
		qPvSmfDkOP6 = new ColumnHeader();
		fx5Smij4klp = new ColumnHeader();
		VuLSmhptcV1 = new ColumnHeader();
		IJfShl9LiSl = new ToolStrip();
		RSNSnTS7qqo = new ToolStripButton();
		KK6Sh2a2ydc = new ToolStripButton();
		nIBShyiMArD = new ToolStripButton();
		N5dSh0l8yme = new ToolStripButton();
		Sf2ShBy8bwC = new ToolStripSeparator();
		GPhSmc367Rb = new ToolStripButton();
		sW3Sm10bBEH = new ToolStripButton();
		iIlShtmt9jE = new ToolStripButton();
		kvpSmwvNc2S = new ToolStripSeparator();
		Y9dShRQ2Gc9 = new ToolStripComboBox();
		BYNSmPqLFo5 = new LevelButtonsFrame();
		zAdSmYjJLqk = new PlayerListUI();
		GkXSmRRWXTn = new PlayerButtonsFrame();
		IP0SmgviEFx = new ChunkButtonsFrame();
		tPRSmnjF0Jx = new NBTFrame();
		MPASmUndjLJ = new MapManagerUI();
		yh3Sme5i0Yu = new RegionDisplay();
		ym2SmMNZ1l2 = new DimensionDisplay();
		RFPSmkGp6mu = new MapButtonsFrame();
		dj9ShxRLm97 = new StatusStrip();
		q0AShUPDFyp = new ToolStripStatusLabel();
		xfFSmma9KwJ = new ToolStripStatusLabel();
		k2jShLKDVK7 = new ToolStripStatusLabel();
		qK0Shgl81pa = new ToolStripStatusLabel();
		FG0ShPxaiFX = new ToolTip(PXpShixaZCM);
		bdiShsNgjVE.SuspendLayout();
		kA5Sh8yt5Wm.SuspendLayout();
		((ISupportInitialize)aKYShnYoo41).BeginInit();
		aKYShnYoo41.Panel1.SuspendLayout();
		aKYShnYoo41.Panel2.SuspendLayout();
		aKYShnYoo41.SuspendLayout();
		AHWSmVeaBgQ.SuspendLayout();
		IJfShl9LiSl.SuspendLayout();
		dj9ShxRLm97.SuspendLayout();
		SuspendLayout();
		bdiShsNgjVE.Items.AddRange(new ToolStripItem[6] { wgXShqQRcuV, CbpShkw3q97, ES0ShOeiX9Y, QdWSha9O8wM, yXkSmlprASm, P2BSm0nMXGp });
		bdiShsNgjVE.Location = new Point(0, 0);
		bdiShsNgjVE.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26656);
		bdiShsNgjVE.Size = new Size(827, 24);
		bdiShsNgjVE.TabIndex = 0;
		bdiShsNgjVE.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26656);
		wgXShqQRcuV.DropDownItems.AddRange(new ToolStripItem[7] { AluSmItANiV, aUYShhESBbA, JVnSmzjaac5, tvqShJ80nXm, o0ESm3RR5ZG, qhiSmN4iDk2, kOQSmrfC79T });
		wgXShqQRcuV.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(93756);
		wgXShqQRcuV.Size = new Size(37, 20);
		wgXShqQRcuV.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29532);
		AluSmItANiV.Image = Resources.Rc5SEEMbn5E();
		AluSmItANiV.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(93774);
		AluSmItANiV.ShortcutKeys = Keys.N | Keys.Control;
		AluSmItANiV.Size = new Size(146, 22);
		AluSmItANiV.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57992);
		AluSmItANiV.Click += UVwSs4vFTeY;
		aUYShhESBbA.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(93800));
		aUYShhESBbA.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(58002);
		aUYShhESBbA.ShortcutKeyDisplayString = "";
		aUYShhESBbA.ShortcutKeys = Keys.O | Keys.Control;
		aUYShhESBbA.Size = new Size(146, 22);
		aUYShhESBbA.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29568);
		aUYShhESBbA.Click += fyXSsWWikrh;
		JVnSmzjaac5.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(93830);
		JVnSmzjaac5.Size = new Size(143, 6);
		tvqShJ80nXm.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(93870));
		tvqShJ80nXm.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(58020);
		tvqShJ80nXm.ShortcutKeys = Keys.S | Keys.Control;
		tvqShJ80nXm.Size = new Size(146, 22);
		tvqShJ80nXm.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29604);
		tvqShJ80nXm.Click += OEZSsnoNtpZ;
		o0ESm3RR5ZG.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(93900));
		o0ESm3RR5ZG.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57954);
		o0ESm3RR5ZG.Size = new Size(146, 22);
		o0ESm3RR5ZG.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(93934);
		o0ESm3RR5ZG.Click += sqZSsl13MTO;
		qhiSmN4iDk2.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21142);
		qhiSmN4iDk2.Size = new Size(143, 6);
		kOQSmrfC79T.DropDownItems.AddRange(new ToolStripItem[2] { Fa9Sm5PeYX6, Br0Sm6E28LB });
		kOQSmrfC79T.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(93958);
		kOQSmrfC79T.Size = new Size(146, 22);
		kOQSmrfC79T.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(94010);
		Fa9Sm5PeYX6.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(94028);
		Fa9Sm5PeYX6.Size = new Size(110, 22);
		Fa9Sm5PeYX6.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(94064);
		Fa9Sm5PeYX6.Click += AasSKE9pfFg;
		Br0Sm6E28LB.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(94080);
		Br0Sm6E28LB.Size = new Size(110, 22);
		Br0Sm6E28LB.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(94118);
		Br0Sm6E28LB.Click += JOXSKrMR6bs;
		CbpShkw3q97.DropDownItems.AddRange(new ToolStripItem[10] { YbuShYZUwZ2, tKtSh3f4PQy, xiVSh1rGEVr, dcNShEoug4y, jtbShrjS9FI, dM4Sh5k2imL, hABSh6NNIdh, Ik1ShNjwBsv, gmvShDOjfh2, MPXShcYZcNI });
		CbpShkw3q97.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26680);
		CbpShkw3q97.ShortcutKeys = Keys.Up | Keys.Control;
		CbpShkw3q97.Size = new Size(39, 20);
		CbpShkw3q97.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(60992);
		YbuShYZUwZ2.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26740));
		YbuShYZUwZ2.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26780);
		YbuShYZUwZ2.ShortcutKeys = Keys.X | Keys.Control;
		YbuShYZUwZ2.Size = new Size(203, 22);
		YbuShYZUwZ2.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26808);
		tKtSh3f4PQy.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26820));
		tKtSh3f4PQy.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26862);
		tKtSh3f4PQy.ShortcutKeys = Keys.C | Keys.Control;
		tKtSh3f4PQy.Size = new Size(203, 22);
		tKtSh3f4PQy.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26892);
		xiVSh1rGEVr.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26906));
		xiVSh1rGEVr.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26950);
		xiVSh1rGEVr.ShortcutKeys = Keys.V | Keys.Control;
		xiVSh1rGEVr.Size = new Size(203, 22);
		xiVSh1rGEVr.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26982);
		dcNShEoug4y.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26998);
		dcNShEoug4y.Size = new Size(200, 6);
		jtbShrjS9FI.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(27040));
		jtbShrjS9FI.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(27086);
		jtbShrjS9FI.ShortcutKeys = Keys.R | Keys.Control;
		jtbShrjS9FI.Size = new Size(203, 22);
		jtbShrjS9FI.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(27120);
		dM4Sh5k2imL.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(27138));
		dM4Sh5k2imL.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(27190);
		dM4Sh5k2imL.ShortcutKeys = Keys.E | Keys.Control;
		dM4Sh5k2imL.Size = new Size(203, 22);
		dM4Sh5k2imL.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(27230);
		hABSh6NNIdh.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(27256));
		hABSh6NNIdh.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(27302);
		hABSh6NNIdh.ShortcutKeys = Keys.Delete;
		hABSh6NNIdh.Size = new Size(203, 22);
		hABSh6NNIdh.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(27336);
		Ik1ShNjwBsv.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(27354);
		Ik1ShNjwBsv.Size = new Size(200, 6);
		gmvShDOjfh2.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(27398));
		gmvShDOjfh2.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(27444);
		gmvShDOjfh2.ShortcutKeys = Keys.Up | Keys.Control;
		gmvShDOjfh2.Size = new Size(203, 22);
		gmvShDOjfh2.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(27478);
		gmvShDOjfh2.Click += vpISqanvuu5;
		MPXShcYZcNI.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(27498));
		MPXShcYZcNI.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(27548);
		MPXShcYZcNI.ShortcutKeys = Keys.Down | Keys.Control;
		MPXShcYZcNI.Size = new Size(203, 22);
		MPXShcYZcNI.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(27586);
		MPXShcYZcNI.Click += mYtSqXiDnGP;
		ES0ShOeiX9Y.DropDownItems.AddRange(new ToolStripItem[17]
		{
			iglShC060wL, grMSmTvbeIG, ablSmCDqwQF, pHCSm7aFPhs, v1TSmL4aDXY, UqdShd4QmHG, uFZSmDuOLum, HNoSmxw1ffF, WrLSmJensx0, BfbSmQhWs3X,
			DZDSmOfh0Xu, OIMSmuXWrYH, LFfSmdqWjkr, KfUSmokcHKH, vvaSmEteF1h, qMLSmAuSrHd, fq7ShH0cnpY
		});
		ES0ShOeiX9Y.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(94136);
		ES0ShOeiX9Y.Size = new Size(46, 20);
		ES0ShOeiX9Y.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(94156);
		ES0ShOeiX9Y.DropDownOpening += BQ9SKlWcDTx;
		iglShC060wL.DropDownItems.AddRange(new ToolStripItem[2] { pF7Sh7JtZq8, OQBShAWyHmr });
		iglShC060wL.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(94170));
		iglShC060wL.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(94206);
		iglShC060wL.Size = new Size(148, 22);
		iglShC060wL.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23102);
		pF7Sh7JtZq8.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(94230);
		pF7Sh7JtZq8.Size = new Size(132, 22);
		pF7Sh7JtZq8.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(94262);
		pF7Sh7JtZq8.Click += wZtSqemx4UQ;
		OQBShAWyHmr.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(94280);
		OQBShAWyHmr.Size = new Size(132, 22);
		OQBShAWyHmr.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(94316);
		OQBShAWyHmr.Click += uUZSqMUqp8L;
		grMSmTvbeIG.DropDownItems.AddRange(new ToolStripItem[3] { Rf7SmGQpu1s, brkSmSSME94, mhISmbl7hyW });
		grMSmTvbeIG.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(94340);
		grMSmTvbeIG.Size = new Size(148, 22);
		grMSmTvbeIG.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37220);
		Rf7SmGQpu1s.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(94392);
		Rf7SmGQpu1s.Size = new Size(166, 22);
		Rf7SmGQpu1s.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(94456);
		Rf7SmGQpu1s.Click += gLdSqCm64gB;
		brkSmSSME94.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(94486);
		brkSmSSME94.Size = new Size(166, 22);
		brkSmSSME94.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(94550);
		brkSmSSME94.Visible = false;
		brkSmSSME94.Click += LVYSqO55UL1;
		mhISmbl7hyW.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(94590);
		mhISmbl7hyW.Size = new Size(166, 22);
		mhISmbl7hyW.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(94624);
		mhISmbl7hyW.Click += eyFSq7Rnwwm;
		ablSmCDqwQF.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(94654);
		ablSmCDqwQF.Size = new Size(148, 22);
		ablSmCDqwQF.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(52888);
		ablSmCDqwQF.Click += cjqSKOU1NR9;
		pHCSm7aFPhs.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(94674);
		pHCSm7aFPhs.Size = new Size(145, 6);
		v1TSmL4aDXY.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(94714);
		v1TSmL4aDXY.Size = new Size(148, 22);
		v1TSmL4aDXY.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(94740);
		v1TSmL4aDXY.Visible = false;
		v1TSmL4aDXY.Click += tTmSKXeU3Qv;
		UqdShd4QmHG.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(94762));
		UqdShd4QmHG.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(94798);
		UqdShd4QmHG.Size = new Size(148, 22);
		UqdShd4QmHG.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(61354);
		UqdShd4QmHG.Click += p6oSqtMdvgq;
		uFZSmDuOLum.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(94822);
		uFZSmDuOLum.Size = new Size(148, 22);
		uFZSmDuOLum.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55274);
		uFZSmDuOLum.Click += nEHSKN5FnnF;
		HNoSmxw1ffF.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(94852);
		HNoSmxw1ffF.Size = new Size(145, 6);
		WrLSmJensx0.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(94874);
		WrLSmJensx0.Size = new Size(148, 22);
		WrLSmJensx0.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(94906);
		WrLSmJensx0.Click += FccSKuJSeyR;
		BfbSmQhWs3X.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(94934);
		BfbSmQhWs3X.Size = new Size(145, 6);
		DZDSmOfh0Xu.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(94976);
		DZDSmOfh0Xu.Size = new Size(148, 22);
		DZDSmOfh0Xu.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(62344);
		DZDSmOfh0Xu.Click += OldSKQIrpkI;
		OIMSmuXWrYH.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(95000);
		OIMSmuXWrYH.Size = new Size(145, 6);
		LFfSmdqWjkr.DropDownItems.AddRange(new ToolStripItem[5] { vZoSm91aT4W, Jq1Sm8JKpOU, Vv3SmHTyJun, Mc3SmjYuYPm, tcWSmFC1glK });
		LFfSmdqWjkr.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(95040);
		LFfSmdqWjkr.Size = new Size(148, 22);
		LFfSmdqWjkr.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(95058);
		vZoSm91aT4W.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(95070);
		vZoSm91aT4W.Size = new Size(217, 22);
		vZoSm91aT4W.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38454);
		vZoSm91aT4W.Click += QSUSKHE4CSl;
		Jq1Sm8JKpOU.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(95112);
		Jq1Sm8JKpOU.Size = new Size(217, 22);
		Jq1Sm8JKpOU.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(46106);
		Jq1Sm8JKpOU.Click += GMxSKd0DlXs;
		Vv3SmHTyJun.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(95148);
		Vv3SmHTyJun.Size = new Size(217, 22);
		Vv3SmHTyJun.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(95182);
		Vv3SmHTyJun.Click += dPrSKChW3Hv;
		Mc3SmjYuYPm.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(95212);
		Mc3SmjYuYPm.Size = new Size(217, 22);
		Mc3SmjYuYPm.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(95242);
		Mc3SmjYuYPm.Click += cyISK7PFumU;
		tcWSmFC1glK.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(95268);
		tcWSmFC1glK.Size = new Size(217, 22);
		tcWSmFC1glK.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(95342);
		tcWSmFC1glK.Click += TvcSKAgBkS2;
		KfUSmokcHKH.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(95388);
		KfUSmokcHKH.Size = new Size(148, 22);
		KfUSmokcHKH.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(95414);
		KfUSmokcHKH.Visible = false;
		KfUSmokcHKH.Click += YRGSKosnxyB;
		vvaSmEteF1h.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(95434);
		vvaSmEteF1h.Size = new Size(148, 22);
		vvaSmEteF1h.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(95484);
		vvaSmEteF1h.Visible = false;
		vvaSmEteF1h.Click += J5fSK1rAnwZ;
		qMLSmAuSrHd.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(95500);
		qMLSmAuSrHd.Size = new Size(145, 6);
		fq7ShH0cnpY.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(95536));
		fq7ShH0cnpY.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(95572);
		fq7ShH0cnpY.Size = new Size(148, 22);
		fq7ShH0cnpY.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(62072);
		fq7ShH0cnpY.Click += n9FSqxRC5iX;
		QdWSha9O8wM.DropDownItems.AddRange(new ToolStripItem[13]
		{
			DCASheayBH5, zr5ShM5QeuU, jxpShFsxuAQ, GclSnSQkiOd, ILsSnG3XMtx, iMnShj83d3l, PTKSnVPadw7, Y50SnWxwhVg, XOnShI3aPat, LrKShzGj9BQ,
			nRfSnwysHvX, lW8Sn4CPSfC, DKKShXoZlre
		});
		QdWSha9O8wM.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(95596);
		QdWSha9O8wM.Size = new Size(44, 20);
		QdWSha9O8wM.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40532);
		DCASheayBH5.DropDownItems.AddRange(new ToolStripItem[4] { op8ShuAujsI, t2MShoG9uX4, xL4ShQhB7Ae, S2KSmsLU12T });
		DCASheayBH5.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(95642));
		DCASheayBH5.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(95686);
		DCASheayBH5.Size = new Size(148, 22);
		DCASheayBH5.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(95718);
		op8ShuAujsI.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(95746));
		op8ShuAujsI.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(95784);
		op8ShuAujsI.Size = new Size(109, 22);
		op8ShuAujsI.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21078);
		op8ShuAujsI.Click += AQESqmTBxjy;
		t2MShoG9uX4.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(95810));
		t2MShoG9uX4.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(95846);
		t2MShoG9uX4.Size = new Size(109, 22);
		t2MShoG9uX4.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11178);
		t2MShoG9uX4.Click += tihSqnL57AX;
		xL4ShQhB7Ae.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(95870));
		xL4ShQhB7Ae.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(95904);
		xL4ShQhB7Ae.Size = new Size(109, 22);
		xL4ShQhB7Ae.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15976);
		xL4ShQhB7Ae.Click += n92Sql2TDWr;
		S2KSmsLU12T.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(95926));
		S2KSmsLU12T.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(95960);
		S2KSmsLU12T.Size = new Size(109, 22);
		S2KSmsLU12T.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14736);
		S2KSmsLU12T.Click += nyDSq051vWM;
		zr5ShM5QeuU.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20892);
		zr5ShM5QeuU.Size = new Size(145, 6);
		jxpShFsxuAQ.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(95982));
		jxpShFsxuAQ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(96020);
		jxpShFsxuAQ.Size = new Size(148, 22);
		jxpShFsxuAQ.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(96046);
		jxpShFsxuAQ.Click += l1sSq2N74QG;
		GclSnSQkiOd.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(96066);
		GclSnSQkiOd.Size = new Size(145, 6);
		ILsSnG3XMtx.DropDownItems.AddRange(new ToolStripItem[2] { bqtSnvRrjFx, SOASnbSDFS5 });
		ILsSnG3XMtx.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(96106));
		ILsSnG3XMtx.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(96170);
		ILsSnG3XMtx.Size = new Size(148, 22);
		ILsSnG3XMtx.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(89970);
		bqtSnvRrjFx.Image = Resources.FxDS1AWmlp4();
		bqtSnvRrjFx.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(96222);
		bqtSnvRrjFx.Size = new Size(103, 22);
		bqtSnvRrjFx.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(59710);
		bqtSnvRrjFx.Click += jtwSKIxL2Yl;
		SOASnbSDFS5.Image = Resources.mTUS1H3uvUk();
		SOASnbSDFS5.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(96268);
		SOASnbSDFS5.Size = new Size(103, 22);
		SOASnbSDFS5.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(96318);
		SOASnbSDFS5.Click += dfRSK9njm34;
		iMnShj83d3l.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(96334);
		iMnShj83d3l.Size = new Size(145, 6);
		PTKSnVPadw7.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(96374));
		PTKSnVPadw7.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(96438);
		PTKSnVPadw7.Size = new Size(148, 22);
		PTKSnVPadw7.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(89864);
		PTKSnVPadw7.Click += VfBShTPNqrK;
		Y50SnWxwhVg.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(96490);
		Y50SnWxwhVg.Size = new Size(145, 6);
		XOnShI3aPat.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(96532));
		XOnShI3aPat.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(96600);
		XOnShI3aPat.Size = new Size(148, 22);
		XOnShI3aPat.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(96656);
		XOnShI3aPat.Click += fuFSqy7hgwH;
		LrKShzGj9BQ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(96680);
		LrKShzGj9BQ.Size = new Size(145, 6);
		nRfSnwysHvX.Image = Resources.jEaS1ebwyDj();
		nRfSnwysHvX.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(96720);
		nRfSnwysHvX.Size = new Size(148, 22);
		nRfSnwysHvX.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(96774);
		nRfSnwysHvX.Click += h4YSKzPlSN1;
		lW8Sn4CPSfC.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(96796);
		lW8Sn4CPSfC.Size = new Size(145, 6);
		DKKShXoZlre.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(96836));
		DKKShXoZlre.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(96868);
		DKKShXoZlre.Size = new Size(148, 22);
		DKKShXoZlre.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(36446);
		DKKShXoZlre.Click += ByYSqfJScxc;
		yXkSmlprASm.DropDownItems.AddRange(new ToolStripItem[2] { os8Sm27ebC0, RN7SmyaY4X4 });
		yXkSmlprASm.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(96888);
		yXkSmlprASm.Size = new Size(61, 20);
		yXkSmlprASm.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23102);
		yXkSmlprASm.Visible = false;
		os8Sm27ebC0.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(96942);
		os8Sm27ebC0.Size = new Size(120, 22);
		os8Sm27ebC0.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(96988);
		RN7SmyaY4X4.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(97002);
		RN7SmyaY4X4.Size = new Size(120, 22);
		RN7SmyaY4X4.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(97052);
		P2BSm0nMXGp.DropDownItems.AddRange(new ToolStripItem[3] { y0LSmBHbOlc, T1QSmt5tyMA, LGqSmaTK6OR });
		P2BSm0nMXGp.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(97070);
		P2BSm0nMXGp.Size = new Size(60, 20);
		P2BSm0nMXGp.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37220);
		P2BSm0nMXGp.Visible = false;
		y0LSmBHbOlc.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(97124);
		y0LSmBHbOlc.Size = new Size(166, 22);
		y0LSmBHbOlc.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(94550);
		y0LSmBHbOlc.Click += LVYSqO55UL1;
		T1QSmt5tyMA.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(97182);
		T1QSmt5tyMA.Size = new Size(166, 22);
		T1QSmt5tyMA.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(94456);
		T1QSmt5tyMA.Click += gLdSqCm64gB;
		LGqSmaTK6OR.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(97230);
		LGqSmaTK6OR.Size = new Size(166, 22);
		LGqSmaTK6OR.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(94624);
		LGqSmaTK6OR.Click += eyFSq7Rnwwm;
		CZCShKpUaJ9.BorderStyle = BorderStyle.None;
		CZCShKpUaJ9.ContextMenuStrip = kA5Sh8yt5Wm;
		CZCShKpUaJ9.Dock = DockStyle.Fill;
		CZCShKpUaJ9.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 9.75f);
		CZCShKpUaJ9.HideSelection = false;
		CZCShKpUaJ9.ImageIndex = 0;
		CZCShKpUaJ9.ImageList = OijShm4rNck;
		CZCShKpUaJ9.Location = new Point(0, 0);
		CZCShKpUaJ9.Margin = new Padding(0);
		CZCShKpUaJ9.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(97278);
		CZCShKpUaJ9.SelectedImageIndex = 0;
		CZCShKpUaJ9.Size = new Size(252, 602);
		CZCShKpUaJ9.TabIndex = 2;
		CZCShKpUaJ9.BeforeExpand += xoGSKFBciIC;
		CZCShKpUaJ9.AfterSelect += sRXSseFvyEp;
		CZCShKpUaJ9.KeyDown += fwXSq1cinTE;
		CZCShKpUaJ9.MouseDown += YG8SqLmpHJ4;
		kA5Sh8yt5Wm.Items.AddRange(new ToolStripItem[5] { RKaSmqyYTyO, CZVSh9rVYwo, g6XSmKWoPwS, jFxSmvItyKV, ueZSmXPhHf0 });
		kA5Sh8yt5Wm.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(97300);
		kA5Sh8yt5Wm.Size = new Size(143, 98);
		kA5Sh8yt5Wm.Opening += x87Sq5sZxgl;
		RKaSmqyYTyO.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(97320);
		RKaSmqyYTyO.Size = new Size(142, 22);
		RKaSmqyYTyO.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(97344);
		RKaSmqyYTyO.TextAlign = ContentAlignment.BottomCenter;
		RKaSmqyYTyO.Click += DrOSqPhlNGG;
		CZVSh9rVYwo.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(97370);
		CZVSh9rVYwo.Size = new Size(142, 22);
		CZVSh9rVYwo.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(97386);
		CZVSh9rVYwo.Click += NfTSqgxLWcO;
		g6XSmKWoPwS.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(97396);
		g6XSmKWoPwS.Size = new Size(139, 6);
		jFxSmvItyKV.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(97414);
		jFxSmvItyKV.Size = new Size(142, 22);
		jFxSmvItyKV.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10326);
		jFxSmvItyKV.Click += JoKSqETt3cH;
		ueZSmXPhHf0.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29650);
		ueZSmXPhHf0.Size = new Size(142, 22);
		ueZSmXPhHf0.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29678);
		ueZSmXPhHf0.Click += lysSqRY7YQj;
		OijShm4rNck.ImageStream = (ImageListStreamer)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(23886));
		OijShm4rNck.TransparentColor = Color.Transparent;
		OijShm4rNck.Images.SetKeyName(0, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(97440));
		OijShm4rNck.Images.SetKeyName(1, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(97480));
		OijShm4rNck.Images.SetKeyName(2, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(97510));
		OijShm4rNck.Images.SetKeyName(3, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(97532));
		OijShm4rNck.Images.SetKeyName(4, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(97564));
		aKYShnYoo41.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		aKYShnYoo41.FixedPanel = FixedPanel.Panel1;
		aKYShnYoo41.Location = new Point(0, 23);
		aKYShnYoo41.Margin = new Padding(4);
		aKYShnYoo41.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13750);
		aKYShnYoo41.Panel1.Controls.Add(AHWSmVeaBgQ);
		aKYShnYoo41.Panel1.Controls.Add(IJfShl9LiSl);
		aKYShnYoo41.Panel2.Controls.Add(BYNSmPqLFo5);
		aKYShnYoo41.Panel2.Controls.Add(zAdSmYjJLqk);
		aKYShnYoo41.Panel2.Controls.Add(GkXSmRRWXTn);
		aKYShnYoo41.Panel2.Controls.Add(IP0SmgviEFx);
		aKYShnYoo41.Panel2.Controls.Add(tPRSmnjF0Jx);
		aKYShnYoo41.Panel2.Controls.Add(MPASmUndjLJ);
		aKYShnYoo41.Panel2.Controls.Add(yh3Sme5i0Yu);
		aKYShnYoo41.Panel2.Controls.Add(ym2SmMNZ1l2);
		aKYShnYoo41.Panel2.Controls.Add(RFPSmkGp6mu);
		aKYShnYoo41.Size = new Size(830, 630);
		aKYShnYoo41.SplitterDistance = 252;
		aKYShnYoo41.TabIndex = 4;
		aKYShnYoo41.SplitterMoved += VSVSqiYtpf7;
		AHWSmVeaBgQ.Controls.Add(CZCShKpUaJ9);
		AHWSmVeaBgQ.Controls.Add(x3SSm4q4WRW);
		AHWSmVeaBgQ.Dock = DockStyle.Fill;
		AHWSmVeaBgQ.Location = new Point(0, 28);
		AHWSmVeaBgQ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10398);
		AHWSmVeaBgQ.Size = new Size(252, 602);
		AHWSmVeaBgQ.TabIndex = 8;
		x3SSm4q4WRW.BorderStyle = BorderStyle.None;
		x3SSm4q4WRW.Columns.AddRange(new ColumnHeader[6] { MPWSmWNxeKC, N5xSmpv3IGR, u96SmZlSB5w, qPvSmfDkOP6, fx5Smij4klp, VuLSmhptcV1 });
		x3SSm4q4WRW.Dock = DockStyle.Fill;
		x3SSm4q4WRW.FullRowSelect = true;
		x3SSm4q4WRW.HideSelection = false;
		x3SSm4q4WRW.Location = new Point(0, 0);
		x3SSm4q4WRW.MultiSelect = false;
		x3SSm4q4WRW.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(58760);
		x3SSm4q4WRW.Size = new Size(252, 602);
		x3SSm4q4WRW.TabIndex = 7;
		x3SSm4q4WRW.UseCompatibleStateImageBehavior = false;
		x3SSm4q4WRW.View = View.Details;
		x3SSm4q4WRW.Visible = false;
		x3SSm4q4WRW.SelectedIndexChanged += qSYSqz4pRcW;
		MPWSmWNxeKC.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10770);
		MPWSmWNxeKC.Width = 127;
		N5xSmpv3IGR.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55068);
		N5xSmpv3IGR.Width = 69;
		u96SmZlSB5w.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21126);
		qPvSmfDkOP6.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(58794);
		qPvSmfDkOP6.Width = 80;
		fx5Smij4klp.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(58816);
		fx5Smij4klp.Width = 85;
		VuLSmhptcV1.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(58844);
		VuLSmhptcV1.Width = 100;
		IJfShl9LiSl.AutoSize = false;
		IJfShl9LiSl.GripMargin = new Padding(0);
		IJfShl9LiSl.GripStyle = ToolStripGripStyle.Hidden;
		IJfShl9LiSl.Items.AddRange(new ToolStripItem[10] { RSNSnTS7qqo, KK6Sh2a2ydc, nIBShyiMArD, N5dSh0l8yme, Sf2ShBy8bwC, GPhSmc367Rb, sW3Sm10bBEH, iIlShtmt9jE, kvpSmwvNc2S, Y9dShRQ2Gc9 });
		IJfShl9LiSl.Location = new Point(0, 0);
		IJfShl9LiSl.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(97594);
		IJfShl9LiSl.Padding = new Padding(10, 0, 1, 0);
		IJfShl9LiSl.Size = new Size(252, 28);
		IJfShl9LiSl.Stretch = true;
		IJfShl9LiSl.TabIndex = 6;
		RSNSnTS7qqo.DisplayStyle = ToolStripItemDisplayStyle.Image;
		RSNSnTS7qqo.Image = Resources.Rc5SEEMbn5E();
		RSNSnTS7qqo.ImageTransparentColor = Color.Magenta;
		RSNSnTS7qqo.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(97618);
		RSNSnTS7qqo.Size = new Size(23, 25);
		RSNSnTS7qqo.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(97642);
		RSNSnTS7qqo.ToolTipText = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29568);
		RSNSnTS7qqo.Visible = false;
		KK6Sh2a2ydc.DisplayStyle = ToolStripItemDisplayStyle.Image;
		KK6Sh2a2ydc.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(97686));
		KK6Sh2a2ydc.ImageTransparentColor = Color.Magenta;
		KK6Sh2a2ydc.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(97724);
		KK6Sh2a2ydc.Size = new Size(23, 25);
		KK6Sh2a2ydc.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(97642);
		KK6Sh2a2ydc.ToolTipText = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29568);
		KK6Sh2a2ydc.Visible = false;
		nIBShyiMArD.DisplayStyle = ToolStripItemDisplayStyle.Image;
		nIBShyiMArD.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(97750));
		nIBShyiMArD.ImageTransparentColor = Color.Magenta;
		nIBShyiMArD.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(97800);
		nIBShyiMArD.Size = new Size(23, 25);
		nIBShyiMArD.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(97838);
		N5dSh0l8yme.DisplayStyle = ToolStripItemDisplayStyle.Image;
		N5dSh0l8yme.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(97864));
		N5dSh0l8yme.ImageTransparentColor = Color.Magenta;
		N5dSh0l8yme.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(97902);
		N5dSh0l8yme.Size = new Size(23, 25);
		N5dSh0l8yme.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(97928);
		N5dSh0l8yme.ToolTipText = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29604);
		Sf2ShBy8bwC.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(97976);
		Sf2ShBy8bwC.Size = new Size(6, 28);
		GPhSmc367Rb.DisplayStyle = ToolStripItemDisplayStyle.Image;
		GPhSmc367Rb.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(98018));
		GPhSmc367Rb.ImageTransparentColor = Color.Magenta;
		GPhSmc367Rb.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(98068);
		GPhSmc367Rb.Size = new Size(23, 25);
		GPhSmc367Rb.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(98106);
		GPhSmc367Rb.Visible = false;
		GPhSmc367Rb.Click += CMWSKD7UCBp;
		sW3Sm10bBEH.DisplayStyle = ToolStripItemDisplayStyle.Image;
		sW3Sm10bBEH.Image = Resources.Rc5SEEMbn5E();
		sW3Sm10bBEH.ImageTransparentColor = Color.Magenta;
		sW3Sm10bBEH.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(98136);
		sW3Sm10bBEH.Size = new Size(23, 25);
		sW3Sm10bBEH.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57266);
		sW3Sm10bBEH.Click += iyDSKal5sK6;
		iIlShtmt9jE.DisplayStyle = ToolStripItemDisplayStyle.Image;
		iIlShtmt9jE.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(98164));
		iIlShtmt9jE.ImageTransparentColor = Color.Magenta;
		iIlShtmt9jE.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(98200);
		iIlShtmt9jE.Size = new Size(23, 25);
		iIlShtmt9jE.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26620);
		iIlShtmt9jE.ToolTipText = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(54488);
		iIlShtmt9jE.Click += pORSqqSnJ8E;
		kvpSmwvNc2S.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(98224);
		kvpSmwvNc2S.Size = new Size(6, 28);
		Y9dShRQ2Gc9.AutoSize = false;
		Y9dShRQ2Gc9.DropDownStyle = ComboBoxStyle.DropDownList;
		Y9dShRQ2Gc9.DropDownWidth = 100;
		Y9dShRQ2Gc9.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(98266);
		Y9dShRQ2Gc9.Size = new Size(75, 23);
		Y9dShRQ2Gc9.SelectedIndexChanged += W4cSqhmv2D1;
		BYNSmPqLFo5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
		BYNSmPqLFo5.BackColor = Color.Gainsboro;
		BYNSmPqLFo5.Location = new Point(758, 0);
		BYNSmPqLFo5.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(98300);
		BYNSmPqLFo5.Size = new Size(72, 630);
		BYNSmPqLFo5.TabIndex = 5;
		BYNSmPqLFo5.Visible = false;
		BYNSmPqLFo5.LayerEditor += MyhSK5wQrgp;
		zAdSmYjJLqk.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		zAdSmYjJLqk.Location = new Point(0, 0);
		zAdSmYjJLqk.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(98340);
		zAdSmYjJLqk.Size = new Size(574, 630);
		zAdSmYjJLqk.TabIndex = 8;
		zAdSmYjJLqk.Visible = false;
		zAdSmYjJLqk.PlayerSelected += oXySKP56mQR;
		zAdSmYjJLqk.PlayerDeleted += gBESKYtoqNy;
		GkXSmRRWXTn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
		GkXSmRRWXTn.BackColor = Color.Gainsboro;
		GkXSmRRWXTn.Location = new Point(688, 0);
		GkXSmRRWXTn.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(98370);
		GkXSmRRWXTn.Size = new Size(72, 630);
		GkXSmRRWXTn.TabIndex = 7;
		GkXSmRRWXTn.Visible = false;
		GkXSmRRWXTn.InventoryEditor += qbOSKMahiLi;
		GkXSmRRWXTn.EnderInventoryEditor += LIuSKghblJl;
		IP0SmgviEFx.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
		IP0SmgviEFx.BackColor = Color.Gainsboro;
		IP0SmgviEFx.Location = new Point(758, 0);
		IP0SmgviEFx.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(98412);
		IP0SmgviEFx.Size = new Size(72, 630);
		IP0SmgviEFx.TabIndex = 5;
		IP0SmgviEFx.Visible = false;
		IP0SmgviEFx.BlockEditor += WWKSKw4wL51;
		IP0SmgviEFx.BiomeEditor += DDVSKVHcel8;
		IP0SmgviEFx.EntityEditor += YqpSKUcw6NZ;
		tPRSmnjF0Jx.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		tPRSmnjF0Jx.Location = new Point(3, 0);
		tPRSmnjF0Jx.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(98454);
		tPRSmnjF0Jx.Size = new Size(423, 630);
		tPRSmnjF0Jx.TabIndex = 0;
		tPRSmnjF0Jx.Visible = false;
		tPRSmnjF0Jx.UIUpdated += fKfSKvmcjVA;
		tPRSmnjF0Jx.BlockEditor += WWKSKw4wL51;
		tPRSmnjF0Jx.MapEditor += Ph6SK4J5jnn;
		tPRSmnjF0Jx.BiomeEditor += DDVSKVHcel8;
		MPASmUndjLJ.Dock = DockStyle.Fill;
		MPASmUndjLJ.Location = new Point(0, 0);
		MPASmUndjLJ.MapList = null;
		MPASmUndjLJ.MapsChanged = false;
		MPASmUndjLJ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55218);
		MPASmUndjLJ.Size = new Size(574, 630);
		MPASmUndjLJ.TabIndex = 4;
		MPASmUndjLJ.Visible = false;
		MPASmUndjLJ.DataChanged += lNLSKnCW7Ue;
		yh3Sme5i0Yu.ChunkEntries = null;
		yh3Sme5i0Yu.Dock = DockStyle.Fill;
		yh3Sme5i0Yu.Location = new Point(0, 0);
		yh3Sme5i0Yu.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(98474);
		yh3Sme5i0Yu.RegionEntry = null;
		yh3Sme5i0Yu.Size = new Size(574, 630);
		yh3Sme5i0Yu.TabIndex = 1;
		yh3Sme5i0Yu.Visible = false;
		yh3Sme5i0Yu.ChunkSelected += U63SKfsAQxf;
		ym2SmMNZ1l2.ChunkEntries = null;
		ym2SmMNZ1l2.DimensionData = null;
		ym2SmMNZ1l2.Dock = DockStyle.Fill;
		ym2SmMNZ1l2.Location = new Point(0, 0);
		ym2SmMNZ1l2.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(98504);
		ym2SmMNZ1l2.Size = new Size(574, 630);
		ym2SmMNZ1l2.TabIndex = 2;
		ym2SmMNZ1l2.Visible = false;
		ym2SmMNZ1l2.ChunkSelected += U63SKfsAQxf;
		RFPSmkGp6mu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
		RFPSmkGp6mu.BackColor = Color.Gainsboro;
		RFPSmkGp6mu.Location = new Point(760, 0);
		RFPSmkGp6mu.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(98540);
		RFPSmkGp6mu.Size = new Size(72, 630);
		RFPSmkGp6mu.TabIndex = 6;
		RFPSmkGp6mu.Visible = false;
		RFPSmkGp6mu.MapEditor += Ph6SK4J5jnn;
		dj9ShxRLm97.Items.AddRange(new ToolStripItem[4] { q0AShUPDFyp, xfFSmma9KwJ, k2jShLKDVK7, qK0Shgl81pa });
		dj9ShxRLm97.Location = new Point(0, 651);
		dj9ShxRLm97.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(98576);
		dj9ShxRLm97.ShowItemToolTips = true;
		dj9ShxRLm97.Size = new Size(827, 24);
		dj9ShxRLm97.TabIndex = 5;
		dj9ShxRLm97.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37836);
		q0AShUPDFyp.AutoSize = false;
		q0AShUPDFyp.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(98606);
		q0AShUPDFyp.Padding = new Padding(20, 0, 0, 0);
		q0AShUPDFyp.Size = new Size(30, 19);
		q0AShUPDFyp.TextAlign = ContentAlignment.MiddleLeft;
		q0AShUPDFyp.ToolTipText = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(98642);
		xfFSmma9KwJ.AutoSize = false;
		xfFSmma9KwJ.BackgroundImageLayout = ImageLayout.None;
		xfFSmma9KwJ.Image = (Image)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(98670));
		xfFSmma9KwJ.Margin = new Padding(0);
		xfFSmma9KwJ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(98732);
		xfFSmma9KwJ.Size = new Size(20, 24);
		xfFSmma9KwJ.ToolTipText = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(98782);
		xfFSmma9KwJ.Click += b7ASKbFs7cP;
		k2jShLKDVK7.AutoSize = false;
		k2jShLKDVK7.BorderSides = ToolStripStatusLabelBorderSides.Left;
		k2jShLKDVK7.BorderStyle = Border3DStyle.Etched;
		k2jShLKDVK7.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(98824);
		k2jShLKDVK7.Padding = new Padding(20, 0, 0, 0);
		k2jShLKDVK7.Size = new Size(200, 19);
		k2jShLKDVK7.TextAlign = ContentAlignment.MiddleLeft;
		k2jShLKDVK7.ToolTipText = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(98862);
		qK0Shgl81pa.AutoSize = false;
		qK0Shgl81pa.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(98888);
		qK0Shgl81pa.Size = new Size(75, 19);
		qK0Shgl81pa.TextAlign = ContentAlignment.MiddleRight;
		qK0Shgl81pa.ToolTipText = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(98918);
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(827, 675);
		base.Controls.Add(dj9ShxRLm97);
		base.Controls.Add(aKYShnYoo41);
		base.Controls.Add(bdiShsNgjVE);
		base.MainMenuStrip = bdiShsNgjVE;
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(98980);
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(99000);
		base.FormClosing += O4VSKcAd5wT;
		base.FormClosed += xODSKGrtaMp;
		base.Load += Y6VSsTaumT4;
		base.Resize += V6CSKxAPlho;
		bdiShsNgjVE.ResumeLayout(performLayout: false);
		bdiShsNgjVE.PerformLayout();
		kA5Sh8yt5Wm.ResumeLayout(performLayout: false);
		aKYShnYoo41.Panel1.ResumeLayout(performLayout: false);
		aKYShnYoo41.Panel2.ResumeLayout(performLayout: false);
		((ISupportInitialize)aKYShnYoo41).EndInit();
		aKYShnYoo41.ResumeLayout(performLayout: false);
		AHWSmVeaBgQ.ResumeLayout(performLayout: false);
		IJfShl9LiSl.ResumeLayout(performLayout: false);
		IJfShl9LiSl.PerformLayout();
		dj9ShxRLm97.ResumeLayout(performLayout: false);
		dj9ShxRLm97.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
