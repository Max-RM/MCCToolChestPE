using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PortableDeviceApiLib;

[ComImport]
[CompilerGenerated]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[TypeIdentifier]
[Guid("6848F6F2-3155-4F86-B6F5-263EEEAB3143")]
public interface IPortableDeviceValues
{
	void _VtblGap1_3();

	void GetValue([In] ref _tagpropertykey key, out tag_inner_PROPVARIANT pValue);

	void SetStringValue([In] ref _tagpropertykey key, [In][MarshalAs(UnmanagedType.LPWStr)] string Value);

	void GetStringValue([In] ref _tagpropertykey key, [MarshalAs(UnmanagedType.LPWStr)] out string pValue);

	void _VtblGap2_4();

	void SetUnsignedLargeIntegerValue([In] ref _tagpropertykey key, [In] ulong Value);

	void _VtblGap3_14();

	void GetGuidValue([In] ref _tagpropertykey key, out Guid pValue);
}
