using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PortableDeviceApiLib;

[ComImport]
[InterfaceType(1)]
[Guid("C424233C-AFCE-4828-A756-7ED7A2350083")]
public interface IPortableDeviceServiceMethodCallback
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void OnComplete([In][MarshalAs(UnmanagedType.Error)] int hrStatus, [In][MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pResults);
}
