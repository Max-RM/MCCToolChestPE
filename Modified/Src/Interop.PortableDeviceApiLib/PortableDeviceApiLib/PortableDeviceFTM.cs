using System.Runtime.InteropServices;

namespace PortableDeviceApiLib;

[ComImport]
[Guid("625E2DF8-6392-4CF0-9AD1-3CFA5F17775C")]
[CoClass(typeof(PortableDeviceFTMClass))]
public interface PortableDeviceFTM : IPortableDevice
{
}
