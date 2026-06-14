using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PortableDeviceApiLib;

[ComImport]
[InterfaceType(1)]
[Guid("24DBD89D-413E-43E0-BD5B-197F3C56C886")]
public interface IPortableDeviceServiceCapabilities
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetSupportedMethods([MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppMethods);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetSupportedMethodsByFormat([In] ref Guid Format, [MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppMethods);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetMethodAttributes([In] ref Guid Method, [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppAttributes);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetMethodParameterAttributes([In] ref Guid Method, [In] ref _tagpropertykey Parameter, [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppAttributes);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetSupportedFormats([MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppFormats);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetFormatAttributes([In] ref Guid Format, [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppAttributes);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetSupportedFormatProperties([In] ref Guid Format, [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceKeyCollection ppKeys);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetFormatPropertyAttributes([In] ref Guid Format, [In] ref _tagpropertykey Property, [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppAttributes);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetSupportedEvents([MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppEvents);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetEventAttributes([In] ref Guid Event, [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppAttributes);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetEventParameterAttributes([In] ref Guid Event, [In] ref _tagpropertykey Parameter, [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppAttributes);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetInheritedServices([In] uint dwInheritanceType, [MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppServices);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetFormatRenderingProfiles([In] ref Guid Format, [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValuesCollection ppRenderingProfiles);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetSupportedCommands([MarshalAs(UnmanagedType.Interface)] out IPortableDeviceKeyCollection ppCommands);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetCommandOptions([In] ref _tagpropertykey Command, [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppOptions);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void Cancel();
}
