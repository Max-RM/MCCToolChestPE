using System;
using System.Runtime.InteropServices;

namespace Microsoft.ClearScript.Util;

internal sealed class CoTaskMemVariantArgsByRefBlock : CoTaskMemBlock
{
	private readonly object[] args;

	public CoTaskMemVariantArgsByRefBlock(object[] args)
		: base(args.Length * 2 * RawCOMHelpers.VariantSize)
	{
		this.args = args;
		for (int i = 0; i < args.Length; i++)
		{
			IntPtr addrInternal = GetAddrInternal(args.Length + i);
			Marshal.GetNativeVariantForObject(args[i], addrInternal);
			IntPtr addrInternal2 = GetAddrInternal(args.Length - 1 - i);
			NativeMethods.VariantInit(addrInternal2);
			Marshal.WriteInt16(addrInternal2, 0, 16396);
			Marshal.WriteIntPtr(addrInternal2, 8, addrInternal);
		}
	}

	public IntPtr GetAddr(int index)
	{
		if (index < 0 || index >= args.Length)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		if (base.Addr == IntPtr.Zero)
		{
			throw new ObjectDisposedException(ToString());
		}
		return GetAddrInternal(args.Length - 1 - index);
	}

	private IntPtr GetAddrInternal(int index)
	{
		return base.Addr + index * RawCOMHelpers.VariantSize;
	}

	protected override void Dispose(bool disposing)
	{
		if (base.Addr != IntPtr.Zero)
		{
			for (int i = 0; i < args.Length; i++)
			{
				IntPtr addrInternal = GetAddrInternal(args.Length + i);
				args[i] = Marshal.GetObjectForNativeVariant(addrInternal);
				NativeMethods.VariantClear(addrInternal);
			}
		}
		base.Dispose(disposing);
	}
}
