using System.Runtime.InteropServices;

namespace PortableDeviceTypesLib;

[ComImport]
[Guid("B32F4002-BB27-45FF-AF4F-06631C1E8DAD")]
[CoClass(typeof(WpdSerializerClass))]
public interface WpdSerializer : IWpdSerializer
{
}
