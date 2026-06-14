using System.Runtime.InteropServices;

namespace PortableDeviceApiLib;

[ComImport]
[CoClass(typeof(PortableDeviceServiceClass))]
[Guid("D3BD3A44-D7B5-40A9-98B7-2FA4D01DEC08")]
public interface PortableDeviceService : IPortableDeviceService
{
}
