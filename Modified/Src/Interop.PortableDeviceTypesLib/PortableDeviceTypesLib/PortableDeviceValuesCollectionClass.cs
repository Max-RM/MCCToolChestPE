using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PortableDeviceTypesLib;

[ComImport]
[Guid("3882134D-14CF-4220-9CB4-435F86D83F60")]
[TypeLibType(2)]
[ClassInterface(0)]
public class PortableDeviceValuesCollectionClass : IPortableDeviceValuesCollection, PortableDeviceValuesCollection
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void GetCount([In] ref uint pcElems);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void GetAt([In] uint dwIndex, [MarshalAs(UnmanagedType.Interface)] out PortableDeviceValues ppValues);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void Add([In][MarshalAs(UnmanagedType.Interface)] PortableDeviceValues pValues);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void Clear();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void RemoveAt([In] uint dwIndex);
}
