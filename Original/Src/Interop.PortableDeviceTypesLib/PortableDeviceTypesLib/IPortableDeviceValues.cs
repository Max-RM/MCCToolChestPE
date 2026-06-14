using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PortableDeviceTypesLib;

[ComImport]
[InterfaceType(1)]
[ComConversionLoss]
[Guid("6848F6F2-3155-4F86-B6F5-263EEEAB3143")]
public interface IPortableDeviceValues
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetCount([In] ref uint pcelt);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetAt([In] uint index, [In][Out] ref _tagpropertykey pKey, [In][Out] ref tag_inner_PROPVARIANT pValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void SetValue([In] ref _tagpropertykey key, [In] ref tag_inner_PROPVARIANT pValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetValue([In] ref _tagpropertykey key, out tag_inner_PROPVARIANT pValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void SetStringValue([In] ref _tagpropertykey key, [In][MarshalAs(UnmanagedType.LPWStr)] string Value);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetStringValue([In] ref _tagpropertykey key, [MarshalAs(UnmanagedType.LPWStr)] out string pValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void SetUnsignedIntegerValue([In] ref _tagpropertykey key, [In] uint Value);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetUnsignedIntegerValue([In] ref _tagpropertykey key, out uint pValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void SetSignedIntegerValue([In] ref _tagpropertykey key, [In] int Value);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetSignedIntegerValue([In] ref _tagpropertykey key, out int pValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void SetUnsignedLargeIntegerValue([In] ref _tagpropertykey key, [In] ulong Value);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetUnsignedLargeIntegerValue([In] ref _tagpropertykey key, out ulong pValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void SetSignedLargeIntegerValue([In] ref _tagpropertykey key, [In] long Value);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetSignedLargeIntegerValue([In] ref _tagpropertykey key, out long pValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void SetFloatValue([In] ref _tagpropertykey key, [In] float Value);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetFloatValue([In] ref _tagpropertykey key, out float pValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void SetErrorValue([In] ref _tagpropertykey key, [In][MarshalAs(UnmanagedType.Error)] int Value);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetErrorValue([In] ref _tagpropertykey key, [MarshalAs(UnmanagedType.Error)] out int pValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void SetKeyValue([In] ref _tagpropertykey key, [In] ref _tagpropertykey Value);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetKeyValue([In] ref _tagpropertykey key, out _tagpropertykey pValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void SetBoolValue([In] ref _tagpropertykey key, [In] int Value);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetBoolValue([In] ref _tagpropertykey key, out int pValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void SetIUnknownValue([In] ref _tagpropertykey key, [In][MarshalAs(UnmanagedType.IUnknown)] object pValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetIUnknownValue([In] ref _tagpropertykey key, [MarshalAs(UnmanagedType.IUnknown)] out object ppValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void SetGuidValue([In] ref _tagpropertykey key, [In] ref Guid Value);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetGuidValue([In] ref _tagpropertykey key, out Guid pValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void SetBufferValue([In] ref _tagpropertykey key, [In] ref byte pValue, [In] uint cbValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetBufferValue([In] ref _tagpropertykey key, [Out] IntPtr ppValue, out uint pcbValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void SetIPortableDeviceValuesValue([In] ref _tagpropertykey key, [In][MarshalAs(UnmanagedType.Interface)] PortableDeviceValues pValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetIPortableDeviceValuesValue([In] ref _tagpropertykey key, [MarshalAs(UnmanagedType.Interface)] out PortableDeviceValues ppValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void SetIPortableDevicePropVariantCollectionValue([In] ref _tagpropertykey key, [In][MarshalAs(UnmanagedType.Interface)] PortableDevicePropVariantCollection pValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetIPortableDevicePropVariantCollectionValue([In] ref _tagpropertykey key, [MarshalAs(UnmanagedType.Interface)] out PortableDevicePropVariantCollection ppValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void SetIPortableDeviceKeyCollectionValue([In] ref _tagpropertykey key, [In][MarshalAs(UnmanagedType.Interface)] PortableDeviceKeyCollection pValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetIPortableDeviceKeyCollectionValue([In] ref _tagpropertykey key, [MarshalAs(UnmanagedType.Interface)] out PortableDeviceKeyCollection ppValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void SetIPortableDeviceValuesCollectionValue([In] ref _tagpropertykey key, [In][MarshalAs(UnmanagedType.Interface)] PortableDeviceValuesCollection pValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetIPortableDeviceValuesCollectionValue([In] ref _tagpropertykey key, [MarshalAs(UnmanagedType.Interface)] out PortableDeviceValuesCollection ppValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void RemoveValue([In] ref _tagpropertykey key);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void CopyValuesFromPropertyStore([In][MarshalAs(UnmanagedType.Interface)] IPropertyStore pStore);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void CopyValuesToPropertyStore([In][MarshalAs(UnmanagedType.Interface)] IPropertyStore pStore);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void Clear();
}
