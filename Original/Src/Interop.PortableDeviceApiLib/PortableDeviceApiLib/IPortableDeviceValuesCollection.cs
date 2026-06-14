using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PortableDeviceApiLib;

[ComImport]
[Guid("6E3F2D79-4E07-48C4-8208-D8C2E5AF4A99")]
[InterfaceType(1)]
public interface IPortableDeviceValuesCollection
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetCount([In] ref uint pcElems);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetAt([In] uint dwIndex, [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppValues);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void Add([In][MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pValues);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void Clear();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void RemoveAt([In] uint dwIndex);
}
