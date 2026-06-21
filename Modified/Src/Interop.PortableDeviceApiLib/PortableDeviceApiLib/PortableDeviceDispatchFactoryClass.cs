using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PortableDeviceApiLib;

[ComImport]
[TypeLibType(2)]
[Guid("43232233-8338-4658-AE01-0B4AE830B6B0")]
[ClassInterface(0)]
public class PortableDeviceDispatchFactoryClass : IPortableDeviceDispatchFactory, PortableDeviceDispatchFactory
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void GetDeviceDispatch([In][MarshalAs(UnmanagedType.LPWStr)] string pszPnPDeviceID, [MarshalAs(UnmanagedType.IDispatch)] out object ppDeviceDispatch);
}
