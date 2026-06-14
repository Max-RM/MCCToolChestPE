using System;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using MCCToolChest.Properties;
using YBh7EaXMWmkFRJOX37M;

namespace Save_Manager.model;

public class PCWorldFolder
{
	private PEFolderType l2lSWZ8C8iG;

	private string A8oSWfhPh94;

	private int NjhSWiO8PeD;

	private string m7iSWssRRs6;

	private byte[] sDRSWquXr2m;

	private long tygSWKT1lpT;

	private DateTime hPxSWh8PSdQ;

	private string V7cSWmKpQOF;

	private string PprSWnp39Fa;

	private MemoryStream bWMSWl6ckMP;

	public PEFolderType FolderType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return l2lSWZ8C8iG;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			l2lSWZ8C8iG = value;
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
			return A8oSWfhPh94;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			A8oSWfhPh94 = value;
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
			return NjhSWiO8PeD;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			NjhSWiO8PeD = value;
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
			return sDRSWquXr2m;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			sDRSWquXr2m = value;
			if (sDRSWquXr2m != null)
			{
				bWMSWl6ckMP = new MemoryStream(sDRSWquXr2m);
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
			if (bWMSWl6ckMP != null)
			{
				return Image.FromStream(bWMSWl6ckMP);
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
			return m7iSWssRRs6;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			m7iSWssRRs6 = value;
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
			return tygSWKT1lpT;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			tygSWKT1lpT = value;
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
			return hPxSWh8PSdQ;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			hPxSWh8PSdQ = value;
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
			return V7cSWmKpQOF;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			V7cSWmKpQOF = value;
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
			return PprSWnp39Fa;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			PprSWnp39Fa = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PCWorldFolder()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}
}
