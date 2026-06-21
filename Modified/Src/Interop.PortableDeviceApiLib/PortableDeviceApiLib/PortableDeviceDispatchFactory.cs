using System.Runtime.InteropServices;

namespace PortableDeviceApiLib;

[ComImport]
[CoClass(typeof(PortableDeviceDispatchFactoryClass))]
[Guid("5E1EAFC3-E3D7-4132-96FA-759C0F9D1E0F")]
public interface PortableDeviceDispatchFactory : IPortableDeviceDispatchFactory
{
}
