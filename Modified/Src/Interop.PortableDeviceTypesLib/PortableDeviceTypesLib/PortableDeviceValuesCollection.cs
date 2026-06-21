using System.Runtime.InteropServices;

namespace PortableDeviceTypesLib;

[ComImport]
[Guid("6E3F2D79-4E07-48C4-8208-D8C2E5AF4A99")]
[CoClass(typeof(PortableDeviceValuesCollectionClass))]
public interface PortableDeviceValuesCollection : IPortableDeviceValuesCollection
{
}
