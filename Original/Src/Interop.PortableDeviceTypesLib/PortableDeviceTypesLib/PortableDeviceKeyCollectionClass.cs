using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PortableDeviceTypesLib;

[ComImport]
[ClassInterface(0)]
[Guid("DE2D022D-2480-43BE-97F0-D1FA2CF98F4F")]
[TypeLibType(2)]
public class PortableDeviceKeyCollectionClass : IPortableDeviceKeyCollection, PortableDeviceKeyCollection
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void GetCount([In] ref uint pcElems);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void GetAt([In] uint dwIndex, [In] ref _tagpropertykey pKey);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void Add([In] ref _tagpropertykey key);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void Clear();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void RemoveAt([In] uint dwIndex);
}
