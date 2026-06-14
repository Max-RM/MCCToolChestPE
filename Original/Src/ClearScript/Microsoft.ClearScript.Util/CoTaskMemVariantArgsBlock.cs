using System;
using System.Runtime.InteropServices;

namespace Microsoft.ClearScript.Util;

internal sealed class CoTaskMemVariantArgsBlock : CoTaskMemBlock
{
	private readonly int length;

	public CoTaskMemVariantArgsBlock(object[] args)
		: base(args.Length * RawCOMHelpers.VariantSize)
	{
		length = args.Length;
		for (int i = 0; i < length; i++)
		{
			Marshal.GetNativeVariantForObject(args[i], GetAddrInternal(length - 1 - i));
		}
	}

	public IntPtr GetAddr(int index)
	{
		if (index < 0 || index >= length)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		if (base.Addr == IntPtr.Zero)
		{
			throw new ObjectDisposedException(ToString());
		}
		return GetAddrInternal(length - 1 - index);
	}

	private IntPtr GetAddrInternal(int index)
	{
		return base.Addr + index * RawCOMHelpers.VariantSize;
	}

	protected override void Dispose(bool disposing)
	{
		if (base.Addr != IntPtr.Zero)
		{
			for (int i = 0; i < length; i++)
			{
				NativeMethods.VariantClear(GetAddrInternal(i));
			}
		}
		base.Dispose(disposing);
	}
}
