using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PortableDeviceTypesLib;

[ComImport]
[ComConversionLoss]
[InterfaceType(1)]
[Guid("00020401-0000-0000-C000-000000000046")]
public interface ITypeInfo
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void RemoteGetTypeAttr([Out] IntPtr ppTypeAttr, [ComAliasName("PortableDeviceTypesLib.DWORD")] out uint pDummy);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetTypeComp([MarshalAs(UnmanagedType.Interface)] out ITypeComp ppTComp);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void RemoteGetFuncDesc([In] uint index, [Out] IntPtr ppFuncDesc, [ComAliasName("PortableDeviceTypesLib.DWORD")] out uint pDummy);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void RemoteGetVarDesc([In] uint index, [Out] IntPtr ppVarDesc, [ComAliasName("PortableDeviceTypesLib.DWORD")] out uint pDummy);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void RemoteGetNames([In] int memid, [MarshalAs(UnmanagedType.BStr)] out string rgBstrNames, [In] uint cMaxNames, out uint pcNames);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetRefTypeOfImplType([In] uint index, out uint pRefType);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetImplTypeFlags([In] uint index, out int pImplTypeFlags);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void LocalGetIDsOfNames();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void LocalInvoke();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void RemoteGetDocumentation([In] int memid, [In] uint refPtrFlags, [MarshalAs(UnmanagedType.BStr)] out string pbstrName, [MarshalAs(UnmanagedType.BStr)] out string pBstrDocString, out uint pdwHelpContext, [MarshalAs(UnmanagedType.BStr)] out string pBstrHelpFile);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void RemoteGetDllEntry([In] int memid, [In] tagINVOKEKIND invkind, [In] uint refPtrFlags, [MarshalAs(UnmanagedType.BStr)] out string pBstrDllName, [MarshalAs(UnmanagedType.BStr)] out string pbstrName, out ushort pwOrdinal);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetRefTypeInfo([In] uint hreftype, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "System.Runtime.InteropServices.CustomMarshalers.TypeToTypeInfoMarshaler, CustomMarshalers, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")] out Type ppTInfo);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void LocalAddressOfMember();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void RemoteCreateInstance([In] ref Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppvObj);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetMops([In] int memid, [MarshalAs(UnmanagedType.BStr)] out string pBstrMops);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void RemoteGetContainingTypeLib([MarshalAs(UnmanagedType.Interface)] out ITypeLib ppTLib, out uint pIndex);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void LocalReleaseTypeAttr();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void LocalReleaseFuncDesc();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void LocalReleaseVarDesc();
}
