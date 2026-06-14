using System;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using PortableDeviceApiLib;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace PortableDevices;

public class PortableDeviceCollection : Collection<PortableDevice>
{
	private readonly PortableDeviceManager YtiS3NB47ON;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PortableDeviceCollection()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		YtiS3NB47ON = (PortableDeviceManager)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(256070))));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Refresh()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		YtiS3NB47ON.RefreshDeviceList();
		string[] array = new string[1];
		uint pcPnPDeviceIDs = 1u;
		YtiS3NB47ON.GetDevices(null, ref pcPnPDeviceIDs);
		array = new string[pcPnPDeviceIDs];
		YtiS3NB47ON.GetDevices(array, ref pcPnPDeviceIDs);
		string[] array2 = array;
		foreach (string deviceId in array2)
		{
			Add(new PortableDevice(deviceId));
		}
	}
}
