using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PortableDeviceApiLib;

[ComImport]
[InterfaceType(1)]
[Guid("A8792A31-F385-493C-A893-40F64EB45F6E")]
public interface IPortableDeviceEventCallback
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void OnEvent([In][MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pEventParameters);
}
