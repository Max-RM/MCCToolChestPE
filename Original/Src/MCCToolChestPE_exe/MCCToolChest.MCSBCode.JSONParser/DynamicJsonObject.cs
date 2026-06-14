using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.MCSBCode.JSONParser;

public class DynamicJsonObject : DynamicObject
{
	[CompilerGenerated]
	private IDictionary<string, object> gZQSGvgZHYt;

	[CompilerGenerated]
	private static Func<object, DynamicJsonObject> xTBSGwllqn4;

	public IDictionary<string, object> Dictionary
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return gZQSGvgZHYt;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			gZQSGvgZHYt = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DynamicJsonObject(IDictionary<string, object> dictionary)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		Dictionary = dictionary;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool TryGetMember(GetMemberBinder binder, out object result)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		result = Dictionary[binder.Name];
		if (result is IDictionary<string, object>)
		{
			result = new DynamicJsonObject(result as IDictionary<string, object>);
		}
		else if (result is ArrayList && (result as ArrayList) is IDictionary<string, object>)
		{
			result = new List<DynamicJsonObject>((result as ArrayList).ToArray().Select([MethodImpl(MethodImplOptions.NoInlining)] (object P_0) =>
			{
				while (false)
				{
					_ = ((object[])null)[0];
				}
				return new DynamicJsonObject(P_0 as IDictionary<string, object>);
			}));
		}
		else if (result is ArrayList)
		{
			result = new List<object>((result as ArrayList).ToArray());
		}
		return Dictionary.ContainsKey(binder.Name);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static DynamicJsonObject yiYSGbpjS7o(object P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return new DynamicJsonObject(P_0 as IDictionary<string, object>);
	}
}
