using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PortableDeviceApiLib;

[ComImport]
[CompilerGenerated]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[TypeIdentifier]
[Guid("FD8878AC-D841-4D17-891C-E6829CDB6934")]
public interface IPortableDeviceResources
{
	void _VtblGap1_2();

	void GetStream([In][MarshalAs(UnmanagedType.LPWStr)] string pszObjectID, [In] ref _tagpropertykey key, [In] uint dwMode, [In][Out] ref uint pdwOptimalBufferSize, [MarshalAs(UnmanagedType.Interface)] out IStream ppStream);
}
