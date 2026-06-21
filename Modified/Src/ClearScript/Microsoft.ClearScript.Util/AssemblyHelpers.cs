using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Microsoft.ClearScript.Util;

internal static class AssemblyHelpers
{
	public static T GetAttribute<T>(this Assembly assembly, bool inherit) where T : Attribute
	{
		return Attribute.GetCustomAttributes(assembly, typeof(T), inherit).SingleOrDefault() as T;
	}

	public static IEnumerable<T> GetAttributes<T>(this Assembly assembly, bool inherit) where T : Attribute
	{
		return Attribute.GetCustomAttributes(assembly, typeof(T), inherit).OfType<T>();
	}

	public static bool IsFriendOf(this Assembly thisAssembly, Assembly thatAssembly)
	{
		if (thatAssembly == thisAssembly)
		{
			return true;
		}
		AssemblyName name = thisAssembly.GetName();
		foreach (InternalsVisibleToAttribute attribute in thatAssembly.GetAttributes<InternalsVisibleToAttribute>(inherit: false))
		{
			AssemblyName reference = new AssemblyName(attribute.AssemblyName);
			if (AssemblyName.ReferenceMatchesDefinition(reference, name))
			{
				return true;
			}
		}
		return false;
	}
}
