using System.Runtime.InteropServices;

namespace PortableDeviceApiLib;

[ComImport]
[CoClass(typeof(PortableDeviceManagerClass))]
[Guid("A1567595-4C2F-4574-A6FA-ECEF917B9A40")]
public interface PortableDeviceManager : IPortableDeviceManager
{
}
