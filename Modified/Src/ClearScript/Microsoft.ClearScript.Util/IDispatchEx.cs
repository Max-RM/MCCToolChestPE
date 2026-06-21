using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Microsoft.ClearScript.Util;

[ComImport]
[Guid("a6ef9860-c720-11d0-9337-00a0c90dcaa9")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IDispatchEx
{
	[PreserveSig]
	int GetTypeInfoCount(out uint count);

	[PreserveSig]
	int GetTypeInfo([In] uint index, [In] int lcid, [MarshalAs(UnmanagedType.Interface)] out ITypeInfo typeInfo);

	void GetIDsOfNames([In] ref Guid iid, [In][MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 2)] string[] names, [In] uint count, [In] int lcid, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] int[] dispids);

	void Invoke([In] int dispid, [In] ref Guid iid, [In] int lcid, [In] DispatchFlags flags, [In] ref System.Runtime.InteropServices.ComTypes.DISPPARAMS args, [In] IntPtr pVarResult, out System.Runtime.InteropServices.ComTypes.EXCEPINFO excepInfo, out uint argErr);

	[PreserveSig]
	int GetDispID([In][MarshalAs(UnmanagedType.BStr)] string name, [In] DispatchNameFlags flags, out int dispid);

	[PreserveSig]
	int InvokeEx([In] int dispid, [In] int lcid, [In] DispatchFlags flags, [In] ref System.Runtime.InteropServices.ComTypes.DISPPARAMS args, [In] IntPtr pVarResult, out System.Runtime.InteropServices.ComTypes.EXCEPINFO excepInfo, [Optional][In][MarshalAs(UnmanagedType.Interface)] IServiceProvider svpCaller);

	[PreserveSig]
	int DeleteMemberByName([In][MarshalAs(UnmanagedType.BStr)] string name, [In] DispatchNameFlags flags);

	void DeleteMemberByDispID([In] int dispid);

	void GetMemberProperties([In] int dispid, [In] DispatchPropFlags fetchFlags, out DispatchPropFlags flags);

	[PreserveSig]
	int GetMemberName([In] int dispid, [MarshalAs(UnmanagedType.BStr)] out string name);

	[PreserveSig]
	int GetNextDispID([In] DispatchEnumFlags flags, [In] int dispidCurrent, out int dispidNext);

	void GetNameSpaceParent([MarshalAs(UnmanagedType.IUnknown)] out object parent);
}
