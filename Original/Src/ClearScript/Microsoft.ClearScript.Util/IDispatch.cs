using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Microsoft.ClearScript.Util;

[ComImport]
[Guid("00020400-0000-0000-c000-000000000046")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IDispatch
{
	[PreserveSig]
	int GetTypeInfoCount(out uint count);

	[PreserveSig]
	int GetTypeInfo([In] uint index, [In] int lcid, [MarshalAs(UnmanagedType.Interface)] out ITypeInfo typeInfo);

	void GetIDsOfNames([In] ref Guid iid, [In][MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 2)] string[] names, [In] uint count, [In] int lcid, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] int[] dispids);

	void Invoke([In] int dispid, [In] ref Guid iid, [In] int lcid, [In] DispatchFlags flags, [In] ref System.Runtime.InteropServices.ComTypes.DISPPARAMS args, [In] IntPtr pVarResult, out System.Runtime.InteropServices.ComTypes.EXCEPINFO excepInfo, out uint argErr);
}
