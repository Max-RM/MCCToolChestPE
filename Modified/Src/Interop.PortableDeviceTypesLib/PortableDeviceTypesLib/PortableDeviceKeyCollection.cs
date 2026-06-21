using System.Runtime.InteropServices;

namespace PortableDeviceTypesLib;

[ComImport]
[CoClass(typeof(PortableDeviceKeyCollectionClass))]
[Guid("DADA2357-E0AD-492E-98DB-DD61C53BA353")]
public interface PortableDeviceKeyCollection : IPortableDeviceKeyCollection
{
}
