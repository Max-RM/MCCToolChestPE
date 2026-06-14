using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PortableDeviceApiLib;

[ComImport]
[TypeIdentifier]
[Guid("89B2E422-4F1B-4316-BCEF-A44AFEA83EB3")]
[CompilerGenerated]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public interface IPortableDevicePropVariantCollection
{
	void _VtblGap1_2();

	void Add([In] ref tag_inner_PROPVARIANT pValue);
}
