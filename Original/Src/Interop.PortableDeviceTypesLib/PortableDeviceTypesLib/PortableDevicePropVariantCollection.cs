using System.Runtime.InteropServices;

namespace PortableDeviceTypesLib;

[ComImport]
[Guid("89B2E422-4F1B-4316-BCEF-A44AFEA83EB3")]
[CoClass(typeof(PortableDevicePropVariantCollectionClass))]
public interface PortableDevicePropVariantCollection : IPortableDevicePropVariantCollection
{
}
