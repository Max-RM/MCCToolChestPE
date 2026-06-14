using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PortableDeviceApiLib;

[ComImport]
[InterfaceType(1)]
[Guid("5E1EAFC3-E3D7-4132-96FA-759C0F9D1E0F")]
public interface IPortableDeviceDispatchFactory
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetDeviceDispatch([In][MarshalAs(UnmanagedType.LPWStr)] string pszPnPDeviceID, [MarshalAs(UnmanagedType.IDispatch)] out object ppDeviceDispatch);
}
