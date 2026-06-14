using System;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using MCCToolChest.Properties;
using YBh7EaXMWmkFRJOX37M;

namespace Save_Manager.model;

public class PEWorldFolder
{
	private PEFolderType wQFSeZRO1Hu;

	private string ntFSefooVvy;

	private int QZaSei2b9gg;

	private string ypjSes7hC3y;

	private byte[] SJySeqPIHF1;

	private long lpHSeKI6UGv;

	private DateTime m66Sehnh0sk;

	private string AXiSemPNcUV;

	private string i0ESenbV1XL;

	private MemoryStream YH0Sel1ltP0;

	public PEFolderType FolderType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return wQFSeZRO1Hu;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			wQFSeZRO1Hu = value;
		}
	}

	public string Name
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return ntFSefooVvy;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			ntFSefooVvy = value;
		}
	}

	public int GameType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return QZaSei2b9gg;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			QZaSei2b9gg = value;
		}
	}

	public byte[] ImageBytes
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return SJySeqPIHF1;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			SJySeqPIHF1 = value;
			if (SJySeqPIHF1 != null)
			{
				YH0Sel1ltP0 = new MemoryStream(SJySeqPIHF1);
			}
		}
	}

	public Image Image
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			if (YH0Sel1ltP0 != null)
			{
				return Image.FromStream(YH0Sel1ltP0);
			}
			return Resources.b5CS15mOtxr();
		}
	}

	public string Path
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return ypjSes7hC3y;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			ypjSes7hC3y = value;
		}
	}

	public long Size
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return lpHSeKI6UGv;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			lpHSeKI6UGv = value;
		}
	}

	public DateTime Date
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return m66Sehnh0sk;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			m66Sehnh0sk = value;
		}
	}

	public string DeviceId
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return AXiSemPNcUV;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			AXiSemPNcUV = value;
		}
	}

	public string FolderId
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return i0ESenbV1XL;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			i0ESenbV1XL = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PEWorldFolder()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}
}
