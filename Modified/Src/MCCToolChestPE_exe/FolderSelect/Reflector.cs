using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace FolderSelect;

public class Reflector
{
	private string aotV8yhoZL;

	private Assembly S9sV9No7wo;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Reflector(string ns) : this(ns, ns)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Reflector(string an, string ns)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		aotV8yhoZL = ns;
		S9sV9No7wo = null;
		AssemblyName[] referencedAssemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies();
		foreach (AssemblyName assemblyName in referencedAssemblies)
		{
			if (assemblyName.FullName.StartsWith(an))
			{
				S9sV9No7wo = Assembly.Load(assemblyName);
				break;
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Type GetType(string typeName)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Type type = null;
		string[] array = typeName.Split('.');
		if (array.Length > 0)
		{
			type = S9sV9No7wo.GetType(aotV8yhoZL + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13710) + array[0]);
		}
		for (int i = 1; i < array.Length; i++)
		{
			type = type.GetNestedType(array[i], BindingFlags.NonPublic);
		}
		return type;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public object New(string name, params object[] parameters)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Type type = GetType(name);
		ConstructorInfo[] constructors = type.GetConstructors();
		ConstructorInfo[] array = constructors;
		foreach (ConstructorInfo constructorInfo in array)
		{
			try
			{
				return constructorInfo.Invoke(parameters);
			}
			catch
			{
			}
		}
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public object Call(object obj, string func, params object[] parameters)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return Call2(obj, func, parameters);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public object Call2(object obj, string func, object[] parameters)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return CallAs2(obj.GetType(), obj, func, parameters);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public object CallAs(Type type, object obj, string func, params object[] parameters)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return CallAs2(type, obj, func, parameters);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public object CallAs2(Type type, object obj, string func, object[] parameters)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MethodInfo method = type.GetMethod(func, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		return method.Invoke(obj, parameters);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public object Get(object obj, string prop)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return GetAs(obj.GetType(), obj, prop);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public object GetAs(Type type, object obj, string prop)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PropertyInfo property = type.GetProperty(prop, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		return property.GetValue(obj, null);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public object GetEnum(string typeName, string name)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Type type = GetType(typeName);
		FieldInfo field = type.GetField(name);
		return field.GetValue(null);
	}
}
