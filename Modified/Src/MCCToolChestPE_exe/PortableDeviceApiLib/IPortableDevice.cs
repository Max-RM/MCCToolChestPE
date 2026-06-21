using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PortableDeviceApiLib;

[ComImport]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[CompilerGenerated]
[Guid("625E2DF8-6392-4CF0-9AD1-3CFA5F17775C")]
[TypeIdentifier]
public interface IPortableDevice
{
	void Open([In][MarshalAs(UnmanagedType.LPWStr)] string pszPnPDeviceID, [In][MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pClientInfo);

	void _VtblGap1_1();

	void Content([MarshalAs(UnmanagedType.Interface)] out IPortableDeviceContent ppContent);

	void _VtblGap2_2();

	void Close();
}
