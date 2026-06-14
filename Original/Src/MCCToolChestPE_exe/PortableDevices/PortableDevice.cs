using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using PortableDeviceApiLib;
using PortableDeviceTypesLib;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace PortableDevices;

public class PortableDevice
{
	private bool WidS31EjHw8;

	private readonly PortableDeviceApiLib.PortableDevice PXPS3EG5FQI;

	private static bool dk0S3rO6TqW;

	private static int A5rS35XlTtG;

	[CompilerGenerated]
	private string AinS36JDlnT;

	public string DeviceId
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return AinS36JDlnT;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			AinS36JDlnT = value;
		}
	}

	public string FriendlyName
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			if (!WidS31EjHw8)
			{
				throw new InvalidOperationException(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(255850));
			}
			PXPS3EG5FQI.Content(out var ppContent);
			ppContent.Properties(out var ppProperties);
			ppProperties.GetValues(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(255902), null, out var ppValues);
			_tagpropertykey key = new _tagpropertykey
			{
				fmtid = new Guid(651466650u, 58947, 17958, 158, 43, 115, 109, 192, 201, 47, 220),
				pid = 12u
			};
			ppValues.GetStringValue(ref key, out var pValue);
			return pValue;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PortableDevice(string deviceId)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		PXPS3EG5FQI = (PortableDeviceApiLib.PortableDevice)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(255774))));
		DeviceId = deviceId;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	internal PortableDeviceApiLib.PortableDevice HJXS3YqvWhv()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return PXPS3EG5FQI;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Connect()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!WidS31EjHw8)
		{
			PortableDeviceApiLib.IPortableDeviceValues pClientInfo = (PortableDeviceApiLib.IPortableDeviceValues)(PortableDeviceValues)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(255918))));
			PXPS3EG5FQI.Open(DeviceId, pClientInfo);
			WidS31EjHw8 = true;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Disconnect()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (WidS31EjHw8)
		{
			PXPS3EG5FQI.Close();
			WidS31EjHw8 = false;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PortableDeviceFolder GetContents()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PortableDeviceFolder portableDeviceFolder = new PortableDeviceFolder(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(255902), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(255902));
		PXPS3EG5FQI.Content(out var ppContent);
		YAMS3Lg80Kw(ref ppContent, portableDeviceFolder);
		return portableDeviceFolder;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PortableDeviceFolder GetContents(PortableDeviceFolder folder)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PXPS3EG5FQI.Content(out var ppContent);
		ikNS3g6FWEp(ref ppContent, folder);
		return folder;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void YAMS3Lg80Kw(ref IPortableDeviceContent P_0, PortableDeviceFolder P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_0.Properties(out var ppProperties);
		P_0.EnumObjects(0u, P_1.Id, null, out var ppenum);
		uint pcFetched = 0u;
		do
		{
			ppenum.Next(1u, out var pObjIDs, ref pcFetched);
			if (pcFetched != 0)
			{
				PortableDeviceObject portableDeviceObject = MKBS3kJSDMQ(ppProperties, pObjIDs);
				if (portableDeviceObject.Name == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(85374))
				{
					dk0S3rO6TqW = true;
				}
				if (A5rS35XlTtG == 0 || dk0S3rO6TqW)
				{
					P_1.Files.Add(portableDeviceObject);
				}
				if ((A5rS35XlTtG <= 1 || dk0S3rO6TqW) && portableDeviceObject is PortableDeviceFolder)
				{
					A5rS35XlTtG++;
					YAMS3Lg80Kw(ref P_0, (PortableDeviceFolder)portableDeviceObject);
					A5rS35XlTtG--;
				}
				if (portableDeviceObject.Name == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(85374))
				{
					dk0S3rO6TqW = false;
					break;
				}
			}
		}
		while (pcFetched != 0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ikNS3g6FWEp(ref IPortableDeviceContent P_0, PortableDeviceFolder P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_0.Properties(out var ppProperties);
		P_0.EnumObjects(0u, P_1.Id, null, out var ppenum);
		uint pcFetched = 0u;
		do
		{
			ppenum.Next(1u, out var pObjIDs, ref pcFetched);
			if (pcFetched != 0)
			{
				PortableDeviceObject portableDeviceObject = MKBS3kJSDMQ(ppProperties, pObjIDs);
				P_1.Files.Add(portableDeviceObject);
				if (portableDeviceObject is PortableDeviceFolder)
				{
					ikNS3g6FWEp(ref P_0, (PortableDeviceFolder)portableDeviceObject);
				}
			}
		}
		while (pcFetched != 0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe byte[] DownloadFile(PortableDeviceFile file)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MemoryStream memoryStream = new MemoryStream();
		PXPS3EG5FQI.Content(out var ppContent);
		ppContent.Transfer(out var ppResources);
		uint pdwOptimalBufferSize = 0u;
		_tagpropertykey key = new _tagpropertykey
		{
			fmtid = new Guid(3894311358u, 13552, 16831, 181, 63, 241, 160, 106, 232, 120, 66),
			pid = 0u
		};
		try
		{
			ppResources.GetStream(file.Id, ref key, 0u, ref pdwOptimalBufferSize, out var ppStream);
			System.Runtime.InteropServices.ComTypes.IStream stream = (System.Runtime.InteropServices.ComTypes.IStream)ppStream;
			_ = file.Name;
			byte[] array = new byte[1024];
			int num = default(int);
			do
			{
				stream.Read(array, 1024, new IntPtr(&num));
				memoryStream.Write(array, 0, num);
			}
			while (num > 0);
			memoryStream.Close();
		}
		catch (Exception)
		{
		}
		return memoryStream.ToArray();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe void DownloadFile(PortableDeviceFile file, string saveToPath)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PXPS3EG5FQI.Content(out var ppContent);
		ppContent.Transfer(out var ppResources);
		uint pdwOptimalBufferSize = 0u;
		_tagpropertykey key = new _tagpropertykey
		{
			fmtid = new Guid(3894311358u, 13552, 16831, 181, 63, 241, 160, 106, 232, 120, 66),
			pid = 0u
		};
		try
		{
			ppResources.GetStream(file.Id, ref key, 0u, ref pdwOptimalBufferSize, out var ppStream);
			System.Runtime.InteropServices.ComTypes.IStream stream = (System.Runtime.InteropServices.ComTypes.IStream)ppStream;
			string name = file.Name;
			FileStream fileStream = new FileStream(Path.Combine(saveToPath, name), FileMode.Create, FileAccess.Write);
			byte[] array = new byte[1024];
			int num = default(int);
			do
			{
				stream.Read(array, 1024, new IntPtr(&num));
				fileStream.Write(array, 0, num);
			}
			while (num > 0);
			fileStream.Close();
		}
		catch (Exception)
		{
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DeleteFile(PortableDeviceFile file)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PXPS3EG5FQI.Content(out var ppContent);
		tag_inner_PROPVARIANT tag_inner_PROPVARIANT2 = default(tag_inner_PROPVARIANT);
		boiS3R4Mutu(file.Id, out tag_inner_PROPVARIANT2);
		PortableDeviceApiLib.IPortableDevicePropVariantCollection portableDevicePropVariantCollection = ((PortableDevicePropVariantCollection)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(255994))))) as PortableDeviceApiLib.IPortableDevicePropVariantCollection;
		tag_inner_PROPVARIANT pValue = tag_inner_PROPVARIANT2;
		portableDevicePropVariantCollection.Add(ref pValue);
		IPortableDeviceContent portableDeviceContent = ppContent;
		PortableDeviceApiLib.IPortableDevicePropVariantCollection ppResults = null;
		portableDeviceContent.Delete(0u, portableDevicePropVariantCollection, ref ppResults);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TransferContentToDevice(string fileName, string parentObjectId)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PXPS3EG5FQI.Content(out var ppContent);
		PortableDeviceApiLib.IPortableDeviceValues pValues = cAaS3POf5Cl(fileName, parentObjectId);
		uint pdwOptimalWriteBufferSize = 0u;
		IPortableDeviceContent portableDeviceContent = ppContent;
		string ppszCookie = null;
		portableDeviceContent.CreateObjectWithPropertiesAndData(pValues, out var ppData, ref pdwOptimalWriteBufferSize, ref ppszCookie);
		System.Runtime.InteropServices.ComTypes.IStream stream = (System.Runtime.InteropServices.ComTypes.IStream)ppData;
		try
		{
			using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
			{
				byte[] array = new byte[pdwOptimalWriteBufferSize];
				int num;
				do
				{
					num = fileStream.Read(array, 0, (int)pdwOptimalWriteBufferSize);
					IntPtr zero = IntPtr.Zero;
					stream.Write(array, (int)pdwOptimalWriteBufferSize, zero);
				}
				while (num > 0);
			}
			stream.Commit(0);
		}
		finally
		{
			Marshal.ReleaseComObject(ppData);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private PortableDeviceApiLib.IPortableDeviceValues cAaS3POf5Cl(string P_0, string P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PortableDeviceApiLib.IPortableDeviceValues portableDeviceValues = ((PortableDeviceValues)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(255918))))) as PortableDeviceApiLib.IPortableDeviceValues;
		_tagpropertykey key = new _tagpropertykey
		{
			fmtid = new Guid(4016785677u, 23768, 17274, 175, 252, 218, 139, 96, 238, 74, 60),
			pid = 3u
		};
		portableDeviceValues.SetStringValue(ref key, P_1);
		FileInfo fileInfo = new FileInfo(P_0);
		_tagpropertykey tagpropertykey = new _tagpropertykey
		{
			fmtid = new Guid(4016785677u, 23768, 17274, 175, 252, 218, 139, 96, 238, 74, 60),
			pid = 11u
		};
		_tagpropertykey key2 = tagpropertykey;
		portableDeviceValues.SetUnsignedLargeIntegerValue(ref key2, (ulong)fileInfo.Length);
		_tagpropertykey tagpropertykey2 = new _tagpropertykey
		{
			fmtid = new Guid(4016785677u, 23768, 17274, 175, 252, 218, 139, 96, 238, 74, 60),
			pid = 12u
		};
		_tagpropertykey key3 = tagpropertykey2;
		portableDeviceValues.SetStringValue(ref key3, Path.GetFileName(P_0));
		_tagpropertykey tagpropertykey3 = new _tagpropertykey
		{
			fmtid = new Guid(4016785677u, 23768, 17274, 175, 252, 218, 139, 96, 238, 74, 60),
			pid = 4u
		};
		_tagpropertykey key4 = tagpropertykey3;
		portableDeviceValues.SetStringValue(ref key4, Path.GetFileName(P_0));
		return portableDeviceValues;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void boiS3R4Mutu(string P_0, out tag_inner_PROPVARIANT P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PortableDeviceApiLib.IPortableDeviceValues portableDeviceValues = (PortableDeviceApiLib.IPortableDeviceValues)(PortableDeviceValues)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(255918))));
		_tagpropertykey key = new _tagpropertykey
		{
			fmtid = new Guid(4016785677u, 23768, 17274, 175, 252, 218, 139, 96, 238, 74, 60),
			pid = 2u
		};
		portableDeviceValues.SetStringValue(ref key, P_0);
		portableDeviceValues.GetValue(ref key, out P_1);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static PortableDeviceObject MKBS3kJSDMQ(IPortableDeviceProperties P_0, string P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_0.GetSupportedProperties(P_1, out var ppKeys);
		P_0.GetValues(P_1, ppKeys, out var ppValues);
		_tagpropertykey tagpropertykey = new _tagpropertykey
		{
			fmtid = new Guid(4016785677u, 23768, 17274, 175, 252, 218, 139, 96, 238, 74, 60),
			pid = 4u
		};
		PortableDeviceApiLib.IPortableDeviceValues portableDeviceValues = ppValues;
		_tagpropertykey key = tagpropertykey;
		portableDeviceValues.GetStringValue(ref key, out var pValue);
		string pValue2 = pValue;
		try
		{
			tagpropertykey = new _tagpropertykey
			{
				fmtid = new Guid(4016785677u, 23768, 17274, 175, 252, 218, 139, 96, 238, 74, 60),
				pid = 12u
			};
			PortableDeviceApiLib.IPortableDeviceValues portableDeviceValues2 = ppValues;
			_tagpropertykey key2 = tagpropertykey;
			portableDeviceValues2.GetStringValue(ref key2, out pValue2);
		}
		catch (Exception)
		{
			pValue2 = pValue;
		}
		tagpropertykey = new _tagpropertykey
		{
			fmtid = new Guid(4016785677u, 23768, 17274, 175, 252, 218, 139, 96, 238, 74, 60),
			pid = 7u
		};
		PortableDeviceApiLib.IPortableDeviceValues portableDeviceValues3 = ppValues;
		_tagpropertykey key3 = tagpropertykey;
		portableDeviceValues3.GetGuidValue(ref key3, out var pValue3);
		Guid guid = new Guid(669180818u, 41233, 18656, 171, 12, 225, 119, 5, 160, 95, 133);
		Guid guid2 = new Guid(2582446432u, 6143, 19524, 157, 152, 29, 122, 111, 148, 25, 33);
		if (pValue3 == guid || pValue3 == guid2)
		{
			return new PortableDeviceFolder(P_1, pValue2);
		}
		return new PortableDeviceFile(P_1, pValue2);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static PortableDevice()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}
}
