using System.Runtime.InteropServices;

namespace PortableDeviceTypesLib;

[ComImport]
[Guid("6848F6F2-3155-4F86-B6F5-263EEEAB3143")]
[CoClass(typeof(PortableDeviceValuesClass))]
public interface PortableDeviceValues : IPortableDeviceValues
{
}
