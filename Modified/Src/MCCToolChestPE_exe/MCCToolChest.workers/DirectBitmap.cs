using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.workers;

public class DirectBitmap : IDisposable
{
	[CompilerGenerated]
	private Bitmap fU6SYywNA1P;

	[CompilerGenerated]
	private int[] hXoSY0qeu5f;

	[CompilerGenerated]
	private bool o35SYBpJb3V;

	[CompilerGenerated]
	private int P65SYtZTAJE;

	[CompilerGenerated]
	private int cSGSYao8fnv;

	[CompilerGenerated]
	private GCHandle GQOSYXDiVMV;

	public Bitmap Bitmap
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return fU6SYywNA1P;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			fU6SYywNA1P = value;
		}
	}

	public int[] Bits
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return hXoSY0qeu5f;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			hXoSY0qeu5f = value;
		}
	}

	public bool Disposed
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return o35SYBpJb3V;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			o35SYBpJb3V = value;
		}
	}

	public int Height
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return P65SYtZTAJE;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			P65SYtZTAJE = value;
		}
	}

	public int Width
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return cSGSYao8fnv;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			cSGSYao8fnv = value;
		}
	}

	protected GCHandle BitsHandle
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return GQOSYXDiVMV;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			GQOSYXDiVMV = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DirectBitmap(int width, int height)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		Width = width;
		Height = height;
		Bits = new int[width * height];
		BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
		Bitmap = new Bitmap(width, height, width * 4, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPixel(int x, int y, Color colour)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = x + y * Width;
		int num2 = colour.ToArgb();
		Bits[num] = num2;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Color GetPixel(int x, int y)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = x + y * Width;
		int argb = Bits[num];
		return Color.FromArgb(argb);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Dispose()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!Disposed)
		{
			Disposed = true;
			Bitmap.Dispose();
			BitsHandle.Free();
		}
	}
}
