using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Web.Script.Serialization;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.MCSBCode.JSONParser;

public class DynamicJsonConverter : JavaScriptConverter
{
	public override IEnumerable<Type> SupportedTypes
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return new ReadOnlyCollection<Type>(new List<Type>(new Type[1] { typeof(object) }));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (dictionary == null)
		{
			throw new ArgumentNullException(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(70280));
		}
		if (type == typeof(object))
		{
			return new DynamicJsonObject(dictionary);
		}
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		throw new NotImplementedException();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DynamicJsonConverter()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}
}
