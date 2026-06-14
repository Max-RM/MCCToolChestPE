using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PortableDeviceApiLib;

[ComImport]
[InterfaceType(1)]
[Guid("2C8C6DBF-E3DC-4061-BECC-8542E810D126")]
public interface IPortableDeviceCapabilities
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetSupportedCommands([MarshalAs(UnmanagedType.Interface)] out IPortableDeviceKeyCollection ppCommands);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetCommandOptions([In] ref _tagpropertykey Command, [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppOptions);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetFunctionalCategories([MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppCategories);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetFunctionalObjects([In] ref Guid Category, [MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppObjectIDs);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetSupportedContentTypes([In] ref Guid Category, [MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppContentTypes);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetSupportedFormats([In] ref Guid ContentType, [MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppFormats);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetSupportedFormatProperties([In] ref Guid Format, [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceKeyCollection ppKeys);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetFixedPropertyAttributes([In] ref Guid Format, [In] ref _tagpropertykey key, [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppAttributes);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void Cancel();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetSupportedEvents([MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppEvents);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetEventOptions([In] ref Guid Event, [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppOptions);
}
