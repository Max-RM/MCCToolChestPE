using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Json;
using System.Text;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.workers;

public class JsonDataConversion
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
		DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(obj.GetType());
		MemoryStream memoryStream = new MemoryStream();
		dataContractJsonSerializer.WriteObject(memoryStream, obj);
		string result = Encoding.Default.GetString(memoryStream.ToArray());
		memoryStream.Dispose();
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T Deserialize<T>(string json)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		T val = Activator.CreateInstance<T>();
		MemoryStream memoryStream = new MemoryStream(Encoding.Unicode.GetBytes(json));
		DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(val.GetType());
		val = (T)dataContractJsonSerializer.ReadObject(memoryStream);
		memoryStream.Close();
		memoryStream.Dispose();
		return val;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public JsonDataConversion()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}
}
