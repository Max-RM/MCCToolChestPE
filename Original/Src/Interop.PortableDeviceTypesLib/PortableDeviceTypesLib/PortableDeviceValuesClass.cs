using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PortableDeviceTypesLib;

[ComImport]
[ComConversionLoss]
[Guid("0C15D503-D017-47CE-9016-7B3F978721CC")]
[TypeLibType(2)]
[ClassInterface(0)]
public class PortableDeviceValuesClass : IPortableDeviceValues, PortableDeviceValues
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void GetCount([In] ref uint pcelt);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void GetAt([In] uint index, [In][Out] ref _tagpropertykey pKey, [In][Out] ref tag_inner_PROPVARIANT pValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void SetValue([In] ref _tagpropertykey key, [In] ref tag_inner_PROPVARIANT pValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void GetValue([In] ref _tagpropertykey key, out tag_inner_PROPVARIANT pValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void SetStringValue([In] ref _tagpropertykey key, [In][MarshalAs(UnmanagedType.LPWStr)] string Value);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void GetStringValue([In] ref _tagpropertykey key, [MarshalAs(UnmanagedType.LPWStr)] out string pValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void SetUnsignedIntegerValue([In] ref _tagpropertykey key, [In] uint Value);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void GetUnsignedIntegerValue([In] ref _tagpropertykey key, out uint pValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void SetSignedIntegerValue([In] ref _tagpropertykey key, [In] int Value);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void GetSignedIntegerValue([In] ref _tagpropertykey key, out int pValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void SetUnsignedLargeIntegerValue([In] ref _tagpropertykey key, [In] ulong Value);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void GetUnsignedLargeIntegerValue([In] ref _tagpropertykey key, out ulong pValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void SetSignedLargeIntegerValue([In] ref _tagpropertykey key, [In] long Value);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void GetSignedLargeIntegerValue([In] ref _tagpropertykey key, out long pValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void SetFloatValue([In] ref _tagpropertykey key, [In] float Value);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void GetFloatValue([In] ref _tagpropertykey key, out float pValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void SetErrorValue([In] ref _tagpropertykey key, [In][MarshalAs(UnmanagedType.Error)] int Value);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void GetErrorValue([In] ref _tagpropertykey key, [MarshalAs(UnmanagedType.Error)] out int pValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void SetKeyValue([In] ref _tagpropertykey key, [In] ref _tagpropertykey Value);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void GetKeyValue([In] ref _tagpropertykey key, out _tagpropertykey pValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void SetBoolValue([In] ref _tagpropertykey key, [In] int Value);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void GetBoolValue([In] ref _tagpropertykey key, out int pValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void SetIUnknownValue([In] ref _tagpropertykey key, [In][MarshalAs(UnmanagedType.IUnknown)] object pValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void GetIUnknownValue([In] ref _tagpropertykey key, [MarshalAs(UnmanagedType.IUnknown)] out object ppValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void SetGuidValue([In] ref _tagpropertykey key, [In] ref Guid Value);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void GetGuidValue([In] ref _tagpropertykey key, out Guid pValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void SetBufferValue([In] ref _tagpropertykey key, [In] ref byte pValue, [In] uint cbValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void GetBufferValue([In] ref _tagpropertykey key, [Out] IntPtr ppValue, out uint pcbValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void SetIPortableDeviceValuesValue([In] ref _tagpropertykey key, [In][MarshalAs(UnmanagedType.Interface)] PortableDeviceValues pValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void GetIPortableDeviceValuesValue([In] ref _tagpropertykey key, [MarshalAs(UnmanagedType.Interface)] out PortableDeviceValues ppValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void SetIPortableDevicePropVariantCollectionValue([In] ref _tagpropertykey key, [In][MarshalAs(UnmanagedType.Interface)] PortableDevicePropVariantCollection pValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void GetIPortableDevicePropVariantCollectionValue([In] ref _tagpropertykey key, [MarshalAs(UnmanagedType.Interface)] out PortableDevicePropVariantCollection ppValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void SetIPortableDeviceKeyCollectionValue([In] ref _tagpropertykey key, [In][MarshalAs(UnmanagedType.Interface)] PortableDeviceKeyCollection pValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void GetIPortableDeviceKeyCollectionValue([In] ref _tagpropertykey key, [MarshalAs(UnmanagedType.Interface)] out PortableDeviceKeyCollection ppValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void SetIPortableDeviceValuesCollectionValue([In] ref _tagpropertykey key, [In][MarshalAs(UnmanagedType.Interface)] PortableDeviceValuesCollection pValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void GetIPortableDeviceValuesCollectionValue([In] ref _tagpropertykey key, [MarshalAs(UnmanagedType.Interface)] out PortableDeviceValuesCollection ppValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void RemoveValue([In] ref _tagpropertykey key);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void CopyValuesFromPropertyStore([In][MarshalAs(UnmanagedType.Interface)] IPropertyStore pStore);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void CopyValuesToPropertyStore([In][MarshalAs(UnmanagedType.Interface)] IPropertyStore pStore);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void Clear();
}
