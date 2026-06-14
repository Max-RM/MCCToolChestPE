using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PortableDeviceTypesLib;

[ComImport]
[TypeLibType(2)]
[ClassInterface(0)]
[Guid("08A99E2F-6D6D-4B80-AF5A-BAF2BCBE4CB9")]
public class PortableDevicePropVariantCollectionClass : IPortableDevicePropVariantCollection, PortableDevicePropVariantCollection
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void GetCount([In] ref uint pcElems);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void GetAt([In] uint dwIndex, [In] ref tag_inner_PROPVARIANT pValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void Add([In] ref tag_inner_PROPVARIANT pValue);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void GetType(out ushort pvt);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void ChangeType([In] ushort vt);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void Clear();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void RemoveAt([In] uint dwIndex);
}
