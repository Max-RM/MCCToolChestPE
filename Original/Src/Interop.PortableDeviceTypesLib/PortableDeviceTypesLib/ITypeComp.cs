using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PortableDeviceTypesLib;

[ComImport]
[InterfaceType(1)]
[ComConversionLoss]
[Guid("00020403-0000-0000-C000-000000000046")]
public interface ITypeComp
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void RemoteBind([In][MarshalAs(UnmanagedType.LPWStr)] string szName, [In] uint lHashVal, [In] ushort wFlags, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "System.Runtime.InteropServices.CustomMarshalers.TypeToTypeInfoMarshaler, CustomMarshalers, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")] out Type ppTInfo, out tagDESCKIND pDescKind, [Out] IntPtr ppFuncDesc, [Out] IntPtr ppVarDesc, [MarshalAs(UnmanagedType.Interface)] out ITypeComp ppTypeComp, [ComAliasName("PortableDeviceTypesLib.DWORD")] out uint pDummy);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void RemoteBindType([In][MarshalAs(UnmanagedType.LPWStr)] string szName, [In] uint lHashVal, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "System.Runtime.InteropServices.CustomMarshalers.TypeToTypeInfoMarshaler, CustomMarshalers, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")] out Type ppTInfo);
}
