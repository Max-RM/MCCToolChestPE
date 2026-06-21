using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Microsoft.ClearScript.Util;

internal static class COMDispatchHelpers
{
	public static object GetProperty(this IDispatchEx dispatchEx, string name, bool ignoreCase, object[] args)
	{
		Marshal.ThrowExceptionForHR(dispatchEx.GetDispID(name, (!ignoreCase) ? DispatchNameFlags.CaseSensitive : DispatchNameFlags.CaseInsensitive, out var dispid));
		using CoTaskMemVariantArgsBlock coTaskMemVariantArgsBlock = new CoTaskMemVariantArgsBlock(args);
		using CoTaskMemVariantBlock coTaskMemVariantBlock = new CoTaskMemVariantBlock();
		System.Runtime.InteropServices.ComTypes.DISPPARAMS args2 = new System.Runtime.InteropServices.ComTypes.DISPPARAMS
		{
			cArgs = args.Length,
			rgvarg = coTaskMemVariantArgsBlock.Addr,
			cNamedArgs = 0,
			rgdispidNamedArgs = IntPtr.Zero
		};
		Marshal.ThrowExceptionForHR(dispatchEx.InvokeEx(dispid, 0, DispatchFlags.PropertyGet, ref args2, coTaskMemVariantBlock.Addr, out var _));
		return Marshal.GetObjectForNativeVariant(coTaskMemVariantBlock.Addr);
	}

	public static void SetProperty(this IDispatchEx dispatchEx, string name, bool ignoreCase, object[] args)
	{
		if (args.Length < 1)
		{
			throw new ArgumentException("Invalid argument count", "args");
		}
		int dispID = dispatchEx.GetDispID(name, (DispatchNameFlags)(2 | ((!ignoreCase) ? 1 : 8)), out var dispid);
		if (dispID == RawCOMHelpers.HResult.DISP_E_UNKNOWNNAME)
		{
			throw new NotSupportedException("Object does not support dynamic properties");
		}
		Marshal.ThrowExceptionForHR(dispID);
		using CoTaskMemVariantArgsBlock coTaskMemVariantArgsBlock = new CoTaskMemVariantArgsBlock(args);
		using CoTaskMemBlock coTaskMemBlock = new CoTaskMemBlock(4);
		Marshal.WriteInt32(coTaskMemBlock.Addr, -3);
		System.Runtime.InteropServices.ComTypes.DISPPARAMS args2 = new System.Runtime.InteropServices.ComTypes.DISPPARAMS
		{
			cArgs = args.Length,
			rgvarg = coTaskMemVariantArgsBlock.Addr,
			cNamedArgs = 1,
			rgdispidNamedArgs = coTaskMemBlock.Addr
		};
		dispID = dispatchEx.InvokeEx(dispid, 0, DispatchFlags.PropertyPut | DispatchFlags.PropertyPutRef, ref args2, IntPtr.Zero, out var excepInfo);
		if (dispID == RawCOMHelpers.HResult.DISP_E_MEMBERNOTFOUND)
		{
			dispID = dispatchEx.InvokeEx(dispid, 0, DispatchFlags.PropertyPut, ref args2, IntPtr.Zero, out excepInfo);
			if (dispID == RawCOMHelpers.HResult.DISP_E_MEMBERNOTFOUND)
			{
				dispID = dispatchEx.InvokeEx(dispid, 0, DispatchFlags.PropertyPutRef, ref args2, IntPtr.Zero, out excepInfo);
			}
		}
		Marshal.ThrowExceptionForHR(dispID);
	}

	public static bool DeleteProperty(this IDispatchEx dispatchEx, string name, bool ignoreCase)
	{
		return dispatchEx.DeleteMemberByName(name, (!ignoreCase) ? DispatchNameFlags.CaseSensitive : DispatchNameFlags.CaseInsensitive) == 0;
	}

	public static IEnumerable<string> GetPropertyNames(this IDispatchEx dispatchEx)
	{
		int dispid;
		for (int nextDispID = dispatchEx.GetNextDispID(DispatchEnumFlags.All, -1, out dispid); nextDispID == 0; nextDispID = dispatchEx.GetNextDispID(DispatchEnumFlags.All, dispid, out dispid))
		{
			if (dispatchEx.GetMemberName(dispid, out var name) == 0)
			{
				yield return name;
			}
		}
	}

	public static object Invoke(this IDispatchEx dispatchEx, bool asConstructor, object[] args)
	{
		using CoTaskMemVariantArgsByRefBlock coTaskMemVariantArgsByRefBlock = new CoTaskMemVariantArgsByRefBlock(args);
		using CoTaskMemVariantBlock coTaskMemVariantBlock = new CoTaskMemVariantBlock();
		System.Runtime.InteropServices.ComTypes.DISPPARAMS args2 = new System.Runtime.InteropServices.ComTypes.DISPPARAMS
		{
			cArgs = args.Length,
			rgvarg = coTaskMemVariantArgsByRefBlock.Addr,
			cNamedArgs = 0,
			rgdispidNamedArgs = IntPtr.Zero
		};
		Marshal.ThrowExceptionForHR(dispatchEx.InvokeEx(0, 0, (!asConstructor) ? DispatchFlags.Method : DispatchFlags.Construct, ref args2, coTaskMemVariantBlock.Addr, out var _));
		return Marshal.GetObjectForNativeVariant(coTaskMemVariantBlock.Addr);
	}

	public static object InvokeMethod(this IDispatchEx dispatchEx, string name, bool ignoreCase, object[] args)
	{
		Marshal.ThrowExceptionForHR(dispatchEx.GetDispID(name, (!ignoreCase) ? DispatchNameFlags.CaseSensitive : DispatchNameFlags.CaseInsensitive, out var dispid));
		using CoTaskMemVariantArgsByRefBlock coTaskMemVariantArgsByRefBlock = new CoTaskMemVariantArgsByRefBlock(args);
		using CoTaskMemVariantBlock coTaskMemVariantBlock = new CoTaskMemVariantBlock();
		System.Runtime.InteropServices.ComTypes.DISPPARAMS args2 = new System.Runtime.InteropServices.ComTypes.DISPPARAMS
		{
			cArgs = args.Length,
			rgvarg = coTaskMemVariantArgsByRefBlock.Addr,
			cNamedArgs = 0,
			rgdispidNamedArgs = IntPtr.Zero
		};
		Marshal.ThrowExceptionForHR(dispatchEx.InvokeEx(dispid, 0, DispatchFlags.Method, ref args2, coTaskMemVariantBlock.Addr, out var _));
		return Marshal.GetObjectForNativeVariant(coTaskMemVariantBlock.Addr);
	}
}
