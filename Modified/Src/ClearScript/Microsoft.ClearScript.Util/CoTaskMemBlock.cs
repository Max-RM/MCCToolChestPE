using System;
using System.Runtime.InteropServices;

namespace Microsoft.ClearScript.Util;

internal class CoTaskMemBlock : IDisposable
{
	public IntPtr Addr { get; private set; }

	public CoTaskMemBlock(int size)
	{
		Addr = Marshal.AllocCoTaskMem(size);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (Addr != IntPtr.Zero)
		{
			Marshal.FreeCoTaskMem(Addr);
			Addr = IntPtr.Zero;
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	~CoTaskMemBlock()
	{
		Dispose(disposing: false);
	}
}
