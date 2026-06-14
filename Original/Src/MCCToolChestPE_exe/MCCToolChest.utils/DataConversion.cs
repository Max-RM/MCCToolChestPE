using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Serialization;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.utils;

public class DataConversion
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string Serialize(object obj)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (obj == null)
		{
			return null;
		}
		XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());
		MemoryStream memoryStream = new MemoryStream();
		xmlSerializer.Serialize(memoryStream, obj);
		string result = Encoding.Default.GetString(memoryStream.ToArray());
		memoryStream.Dispose();
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T Deserialize<T>(string xml)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		T val = Activator.CreateInstance<T>();
		MemoryStream memoryStream = new MemoryStream(Encoding.Unicode.GetBytes(xml));
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
		val = (T)xmlSerializer.Deserialize(memoryStream);
		memoryStream.Close();
		memoryStream.Dispose();
		return val;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DataConversion()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}
}
