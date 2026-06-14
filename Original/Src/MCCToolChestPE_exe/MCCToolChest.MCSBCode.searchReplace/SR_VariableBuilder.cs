using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.MCSBCode.searchReplace;

public class SR_VariableBuilder
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T[] ConvertVariableList<T>(string varValues)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string[] separator = new string[2]
		{
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40710),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66238)
		};
		varValues = varValues.Replace(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(72306), "");
		List<T> list = new List<T>();
		string[] array = varValues.Split(separator, StringSplitOptions.RemoveEmptyEntries);
		string[] array2 = array;
		foreach (string text in array2)
		{
			T item = ConvertVariableString<T>(text.Trim());
			list.Add(item);
		}
		return list.ToArray();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T ConvertVariableString<T>(string input)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
		if (converter != null)
		{
			return (T)converter.ConvertFromString(input);
		}
		return default(T);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SR_VariableBuilder()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}
}
