using System;
using System.Runtime.InteropServices;

namespace Microsoft.ClearScript.Util;

internal sealed class CoTaskMemVariantBlock : CoTaskMemBlock
{
	public CoTaskMemVariantBlock()
		: base(RawCOMHelpers.VariantSize)
	{
		NativeMethods.VariantInit(base.Addr);
	}

	public CoTaskMemVariantBlock(object obj)
		: base(RawCOMHelpers.VariantSize)
	{
		Marshal.GetNativeVariantForObject(obj, base.Addr);
	}

	protected override void Dispose(bool disposing)
	{
		if (base.Addr != IntPtr.Zero)
		{
			NativeMethods.VariantClear(base.Addr);
		}
		base.Dispose(disposing);
	}
}
