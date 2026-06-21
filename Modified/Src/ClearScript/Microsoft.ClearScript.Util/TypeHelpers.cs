using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.ClearScript.Util;

internal static class TypeHelpers
{
	private sealed class PropertySignatureComparer : IEqualityComparer<PropertyInfo>
	{
		private static readonly PropertySignatureComparer instance = new PropertySignatureComparer();

		public static PropertySignatureComparer Instance => instance;

		public bool Equals(PropertyInfo first, PropertyInfo second)
		{
			IEnumerable<Type> first2 = from param in first.GetIndexParameters()
				select param.ParameterType;
			IEnumerable<Type> second2 = from param in second.GetIndexParameters()
				select param.ParameterType;
			return first2.SequenceEqual(second2);
		}

		public int GetHashCode(PropertyInfo property)
		{
			int num = 0;
			ParameterInfo[] indexParameters = property.GetIndexParameters();
			ParameterInfo[] array = indexParameters;
			foreach (ParameterInfo parameterInfo in array)
			{
				num = num * 31 + parameterInfo.ParameterType.GetHashCode();
			}
			return num;
		}
	}

	private static readonly string[] importBlackList = new string[6] { "FXAssembly", "ThisAssembly", "AssemblyRef", "SRETW", "MatchState", "__DynamicallyInvokableAttribute" };

	private static readonly HashSet<Type> nullableNumericTypes = new HashSet<Type>
	{
		typeof(char?),
		typeof(sbyte?),
		typeof(byte?),
		typeof(short?),
		typeof(ushort?),
		typeof(int?),
		typeof(uint?),
		typeof(long?),
		typeof(ulong?),
		typeof(float?),
		typeof(double?),
		typeof(decimal?)
	};

	private static readonly ConcurrentDictionary<Tuple<Type, BindingFlags, Type, ScriptAccess, bool>, Invocability> invocabilityMap = new ConcurrentDictionary<Tuple<Type, BindingFlags, Type, ScriptAccess, bool>, Invocability>();

	public static bool IsStatic(this Type type)
	{
		if (type.IsAbstract)
		{
			return type.IsSealed;
		}
		return false;
	}

	public static bool IsSpecific(this Type type)
	{
		if (!type.IsGenericParameter)
		{
			return !type.ContainsGenericParameters;
		}
		return false;
	}

	public static bool IsCompilerGenerated(this Type type)
	{
		return type.IsDefined(typeof(CompilerGeneratedAttribute), inherit: false);
	}

	public static bool IsFlagsEnum(this Type type)
	{
		if (type.IsEnum)
		{
			return type.IsDefined(typeof(FlagsAttribute), inherit: false);
		}
		return false;
	}

	public static bool IsImportable(this Type type)
	{
		if (!type.IsNested && !type.IsSpecialName && !type.IsCompilerGenerated())
		{
			string locator = type.GetLocator();
			if (!importBlackList.Contains(locator))
			{
				return IsValidLocator(locator);
			}
			return false;
		}
		return false;
	}

	public static bool IsAnonymous(this Type type)
	{
		if (!type.IsGenericType)
		{
			return false;
		}
		if ((type.Attributes & TypeAttributes.VisibilityMask) != TypeAttributes.NotPublic)
		{
			return false;
		}
		string name = type.Name;
		if (!name.StartsWith("<>", StringComparison.Ordinal) && !name.StartsWith("VB$", StringComparison.OrdinalIgnoreCase))
		{
			return false;
		}
		if (!name.Contains("AnonymousType"))
		{
			return false;
		}
		if (!Attribute.IsDefined(type, typeof(CompilerGeneratedAttribute), inherit: false))
		{
			return false;
		}
		return true;
	}

	public static bool IsIntegral(this Type type)
	{
		if (!(type == typeof(sbyte)) && !(type == typeof(byte)) && !(type == typeof(short)) && !(type == typeof(ushort)) && !(type == typeof(char)) && !(type == typeof(int)) && !(type == typeof(uint)) && !(type == typeof(long)))
		{
			return type == typeof(ulong);
		}
		return true;
	}

	public static bool IsFloatingPoint(this Type type)
	{
		if (!(type == typeof(float)))
		{
			return type == typeof(double);
		}
		return true;
	}

	public static bool IsNumeric(this Type type, out bool isIntegral)
	{
		isIntegral = type.IsIntegral();
		if (!isIntegral && !type.IsFloatingPoint())
		{
			return type == typeof(decimal);
		}
		return true;
	}

	public static bool IsNumeric(this Type type)
	{
		bool isIntegral;
		return type.IsNumeric(out isIntegral);
	}

	public static bool IsNullable(this Type type)
	{
		if (type.IsGenericType)
		{
			return type.GetGenericTypeDefinition() == typeof(Nullable<>);
		}
		return false;
	}

	public static bool IsNullableNumeric(this Type type)
	{
		return nullableNumericTypes.Contains(type);
	}

	public static bool IsUnknownCOMObject(this Type type)
	{
		if (type.IsCOMObject)
		{
			return type.GetInterfaces().Length < 1;
		}
		return false;
	}

	public static bool IsAssignableFrom(this Type type, ref object value)
	{
		bool flag = false;
		if (type.IsByRef)
		{
			type = type.GetElementType();
			flag = true;
		}
		if (type.IsNullable())
		{
			if (value != null)
			{
				return Nullable.GetUnderlyingType(type).IsAssignableFrom(ref value);
			}
			return true;
		}
		if (value == null)
		{
			return !type.IsValueType;
		}
		Type type2 = value.GetType();
		if (type2 == type)
		{
			return true;
		}
		if (!flag && type.IsImplicitlyConvertibleFrom(type2, ref value))
		{
			return true;
		}
		if (!type.IsValueType)
		{
			if (type.IsAssignableFrom(type2))
			{
				return true;
			}
			if (type.IsInterface && type.IsImport && type2.IsCOMObject)
			{
				bool result = false;
				IntPtr iUnknownForObject = Marshal.GetIUnknownForObject(value);
				Guid iid = type.GUID;
				if (iid != Guid.Empty && RawCOMHelpers.HResult.Succeeded(Marshal.QueryInterface(iUnknownForObject, ref iid, out var ppv)))
				{
					Marshal.Release(ppv);
					result = true;
				}
				Marshal.Release(iUnknownForObject);
				return result;
			}
			return false;
		}
		if (!type2.IsValueType)
		{
			return false;
		}
		if (type.IsEnum)
		{
			if (Enum.GetUnderlyingType(type).IsAssignableFrom(ref value))
			{
				return value.DynamicCast<int>() == 0;
			}
			return false;
		}
		if (type2.IsEnum)
		{
			return false;
		}
		if (type.IsNumeric(out var isIntegral))
		{
			if (isIntegral)
			{
				if (!type2.IsIntegral())
				{
					return false;
				}
			}
			else if (!type2.IsNumeric())
			{
				return false;
			}
			value = Convert.ChangeType(value, type);
			return true;
		}
		return false;
	}

	public static bool IsAssignableToGenericType(this Type type, Type genericTypeDefinition, out Type[] typeArgs)
	{
		Type type2 = type;
		while (type2 != null)
		{
			if (type2.IsGenericType && type2.GetGenericTypeDefinition() == genericTypeDefinition)
			{
				typeArgs = type2.GetGenericArguments();
				return true;
			}
			type2 = type2.BaseType;
		}
		Type[] array = (from testType in type.GetInterfaces()
			where testType.IsGenericType && testType.GetGenericTypeDefinition() == genericTypeDefinition
			select testType).ToArray();
		if (array.Length == 1)
		{
			typeArgs = array[0].GetGenericArguments();
			return true;
		}
		typeArgs = null;
		return false;
	}

	public static bool HasExtensionMethods(this Type type)
	{
		return type.IsDefined(typeof(ExtensionAttribute), inherit: false);
	}

	public static bool EqualsOrDeclares(this Type type, Type thatType)
	{
		while (thatType != null)
		{
			if (thatType == type)
			{
				return true;
			}
			thatType = thatType.DeclaringType;
		}
		return false;
	}

	public static bool IsFamilyOf(this Type type, Type thatType)
	{
		while (type != null)
		{
			if (type == thatType || type.IsSubclassOf(thatType))
			{
				return true;
			}
			type = type.DeclaringType;
		}
		return false;
	}

	public static bool IsFriendOf(this Type type, Type thatType)
	{
		return type.Assembly.IsFriendOf(thatType.Assembly);
	}

	public static string GetRootName(this Type type)
	{
		return StripGenericSuffix(type.Name);
	}

	public static string GetFullRootName(this Type type)
	{
		return StripGenericSuffix(type.FullName);
	}

	public static string GetFriendlyName(this Type type)
	{
		return type.GetFriendlyName(GetRootName);
	}

	public static string GetFullFriendlyName(this Type type)
	{
		return type.GetFriendlyName(GetFullRootName);
	}

	public static string GetLocator(this Type type)
	{
		return type.GetFullRootName();
	}

	public static int GetGenericParamCount(this Type type)
	{
		return type.GetGenericArguments().Count((Type typeArg) => typeArg.IsGenericParameter);
	}

	public static IEnumerable<EventInfo> GetScriptableEvents(this Type type, BindingFlags bindFlags, Type accessContext, ScriptAccess defaultAccess)
	{
		IEnumerable<EventInfo> enumerable = type.GetEvents(bindFlags).AsEnumerable();
		if (type.IsInterface)
		{
			enumerable = enumerable.Concat(type.GetInterfaces().SelectMany((Type interfaceType) => interfaceType.GetScriptableEvents(bindFlags, accessContext, defaultAccess)));
		}
		return enumerable.Where((EventInfo eventInfo) => eventInfo.IsScriptable(accessContext, defaultAccess));
	}

	public static EventInfo GetScriptableEvent(this Type type, string name, BindingFlags bindFlags, Type accessContext, ScriptAccess defaultAccess)
	{
		return type.GetScriptableEvents(bindFlags, accessContext, defaultAccess).FirstOrDefault((EventInfo eventInfo) => eventInfo.GetScriptName() == name);
	}

	public static IEnumerable<FieldInfo> GetScriptableFields(this Type type, BindingFlags bindFlags, Type accessContext, ScriptAccess defaultAccess)
	{
		return from field in type.GetFields(bindFlags)
			where field.IsScriptable(accessContext, defaultAccess)
			select field;
	}

	public static FieldInfo GetScriptableField(this Type type, string name, BindingFlags bindFlags, Type accessContext, ScriptAccess defaultAccess)
	{
		return type.GetScriptableFields(bindFlags, accessContext, defaultAccess).FirstOrDefault((FieldInfo field) => field.GetScriptName() == name);
	}

	public static IEnumerable<MethodInfo> GetScriptableMethods(this Type type, BindingFlags bindFlags, Type accessContext, ScriptAccess defaultAccess)
	{
		IEnumerable<MethodInfo> enumerable = type.GetMethods(bindFlags).AsEnumerable();
		if (type.IsInterface)
		{
			enumerable = enumerable.Concat(type.GetInterfaces().SelectMany((Type interfaceType) => interfaceType.GetScriptableMethods(bindFlags, accessContext, defaultAccess)));
			enumerable = enumerable.Concat(typeof(object).GetScriptableMethods(bindFlags, accessContext, defaultAccess));
		}
		return enumerable.Where((MethodInfo method) => method.IsScriptable(accessContext, defaultAccess));
	}

	public static IEnumerable<MethodInfo> GetScriptableMethods(this Type type, string name, BindingFlags bindFlags, Type accessContext, ScriptAccess defaultAccess)
	{
		return from method in type.GetScriptableMethods(bindFlags, accessContext, defaultAccess)
			where method.GetScriptName() == name
			select method;
	}

	public static IEnumerable<PropertyInfo> GetScriptableProperties(this Type type, BindingFlags bindFlags, Type accessContext, ScriptAccess defaultAccess)
	{
		IEnumerable<PropertyInfo> enumerable = type.GetProperties(bindFlags).AsEnumerable();
		if (type.IsInterface)
		{
			enumerable = enumerable.Concat(type.GetInterfaces().SelectMany((Type interfaceType) => interfaceType.GetScriptableProperties(bindFlags, accessContext, defaultAccess)));
		}
		return enumerable.Where((PropertyInfo property) => property.IsScriptable(accessContext, defaultAccess));
	}

	public static IEnumerable<PropertyInfo> GetScriptableDefaultProperties(this Type type, BindingFlags bindFlags, Type accessContext, ScriptAccess defaultAccess)
	{
		if (type.IsArray)
		{
			PropertyInfo property = typeof(IList<>).MakeSpecificType(type.GetElementType()).GetProperty("Item");
			if (!(property != null))
			{
				return ArrayHelpers.GetEmptyArray<PropertyInfo>();
			}
			return property.ToEnumerable();
		}
		IEnumerable<PropertyInfo> enumerable = type.GetProperties(bindFlags).AsEnumerable();
		if (type.IsInterface)
		{
			enumerable = enumerable.Concat(type.GetInterfaces().SelectMany((Type interfaceType) => interfaceType.GetScriptableProperties(bindFlags, accessContext, defaultAccess)));
		}
		MemberInfo[] defaultMembers = type.GetDefaultMembers();
		return enumerable.Where((PropertyInfo propertyInfo) => propertyInfo.IsScriptable(accessContext, defaultAccess) && (defaultMembers.Contains(propertyInfo) || propertyInfo.IsDispID(0)));
	}

	public static IEnumerable<PropertyInfo> GetScriptableProperties(this Type type, string name, BindingFlags bindFlags, Type accessContext, ScriptAccess defaultAccess)
	{
		return from property in type.GetScriptableProperties(bindFlags, accessContext, defaultAccess)
			where property.GetScriptName() == name
			select property;
	}

	public static PropertyInfo GetScriptableProperty(this Type type, string name, BindingFlags bindFlags, object[] bindArgs, Type accessContext, ScriptAccess defaultAccess)
	{
		PropertyInfo[] candidates = type.GetScriptableProperties(name, bindFlags, accessContext, defaultAccess).Distinct(PropertySignatureComparer.Instance).ToArray();
		return SelectProperty(candidates, bindFlags, bindArgs);
	}

	public static PropertyInfo GetScriptableDefaultProperty(this Type type, BindingFlags bindFlags, object[] bindArgs, Type accessContext, ScriptAccess defaultAccess)
	{
		PropertyInfo[] candidates = type.GetScriptableDefaultProperties(bindFlags, accessContext, defaultAccess).Distinct(PropertySignatureComparer.Instance).ToArray();
		return SelectProperty(candidates, bindFlags, bindArgs);
	}

	public static IEnumerable<Type> GetScriptableNestedTypes(this Type type, BindingFlags bindFlags, Type accessContext, ScriptAccess defaultAccess)
	{
		return from nestedType in type.GetNestedTypes(bindFlags)
			where nestedType.IsScriptable(accessContext, defaultAccess)
			select nestedType;
	}

	public static Invocability GetInvocability(this Type type, BindingFlags bindFlags, Type accessContext, ScriptAccess defaultAccess, bool ignoreDynamic)
	{
		return invocabilityMap.GetOrAdd(Tuple.Create(type, bindFlags, accessContext, defaultAccess, ignoreDynamic), GetInvocabilityInternal);
	}

	public static object CreateInstance(this Type type, params object[] args)
	{
		return type.CreateInstance(BindingFlags.Public, args);
	}

	public static object CreateInstance(this Type type, BindingFlags flags, params object[] args)
	{
		return type.InvokeMember(null, BindingFlags.Instance | BindingFlags.CreateInstance | (flags & ~BindingFlags.Static), null, null, args, CultureInfo.InvariantCulture);
	}

	public static object CreateInstance(this Type type, Type accessContext, ScriptAccess defaultAccess, params object[] args)
	{
		if (type.IsCOMObject || (type.IsValueType && args.Length < 1))
		{
			return type.CreateInstance(args);
		}
		ConstructorInfo[] array = (from testConstructor in type.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
			where testConstructor.IsAccessible(accessContext) && !testConstructor.IsBlockedFromScript(defaultAccess)
			select testConstructor).ToArray();
		if (array.Length < 1)
		{
			throw new MissingMethodException(MiscHelpers.FormatInvariant("Type '{0}' has no constructor that matches the specified arguments", type.GetFullFriendlyName()));
		}
		ConstructorInfo constructorInfo = null;
		try
		{
			Binder defaultBinder = Type.DefaultBinder;
			MethodBase[] match = array;
			constructorInfo = defaultBinder.BindToMethod(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, match, ref args, null, null, null, out var _) as ConstructorInfo;
		}
		catch (MissingMethodException)
		{
		}
		if (constructorInfo == null)
		{
			throw new MissingMethodException(MiscHelpers.FormatInvariant("Type '{0}' has no constructor that matches the specified arguments", type.GetFullFriendlyName()));
		}
		return constructorInfo.Invoke(args);
	}

	public static Type MakeSpecificType(this Type template, params Type[] typeArgs)
	{
		return template.ApplyTypeArguments(typeArgs);
	}

	public static Type ApplyTypeArguments(this Type type, params Type[] typeArgs)
	{
		if (!type.IsSpecific())
		{
			Type[] array = (Type[])type.GetGenericArguments().Clone();
			int i = 0;
			int num = 0;
			for (; i < array.Length; i++)
			{
				if (array[i].IsGenericParameter)
				{
					array[i] = typeArgs[num++];
					if (num >= typeArgs.Length)
					{
						break;
					}
				}
			}
			return type.GetGenericTypeDefinition().MakeGenericType(array);
		}
		return type;
	}

	public static bool IsValidLocator(string name)
	{
		if (!string.IsNullOrWhiteSpace(name))
		{
			return name.All(IsValidLocatorChar);
		}
		return false;
	}

	public static HostType ImportType(string typeName, string assemblyName, bool useAssemblyName, object[] hostTypeArgs)
	{
		if (!IsValidLocator(typeName))
		{
			throw new ArgumentException("Invalid type name", "typeName");
		}
		if (useAssemblyName && string.IsNullOrWhiteSpace(assemblyName))
		{
			throw new ArgumentException("Invalid assembly name", "assemblyName");
		}
		if (!hostTypeArgs.All((object arg) => arg is HostType))
		{
			throw new ArgumentException("Invalid generic type argument");
		}
		Type[] typeArgs = (from HostType hostType in hostTypeArgs
			select hostType.GetTypeArg()).ToArray();
		return ImportType(typeName, assemblyName, useAssemblyName, typeArgs);
	}

	public static HostType ImportType(string typeName, string assemblyName, bool useAssemblyName, Type[] typeArgs)
	{
		if (typeArgs != null && typeArgs.Length != 0)
		{
			Type type = ImportType(typeName, assemblyName, useAssemblyName, typeArgs.Length);
			if (type == null)
			{
				throw new TypeLoadException(MiscHelpers.FormatInvariant("Could not find a matching generic type definition for '{0}'", typeName));
			}
			return HostType.Wrap(type.MakeSpecificType(typeArgs));
		}
		Type type2 = ImportType(typeName, assemblyName, useAssemblyName, 0);
		IEnumerable<int> source = Enumerable.Range(1, 16);
		Type[] array = source.Select((int count) => ImportType(typeName, assemblyName, useAssemblyName, count)).OfType<Type>().ToArray();
		if (array.Length < 1)
		{
			if (type2 == null)
			{
				throw new TypeLoadException(MiscHelpers.FormatInvariant("Could not find a specific type or generic type definition for '{0}'", typeName));
			}
			return HostType.Wrap(type2);
		}
		if (type2 == null)
		{
			return HostType.Wrap(array);
		}
		return HostType.Wrap(type2.ToEnumerable().Concat(array).ToArray());
	}

	private static Type ImportType(string typeName, string assemblyName, bool useAssemblyName, int typeArgCount)
	{
		string fullTypeName = GetFullTypeName(typeName, assemblyName, useAssemblyName, typeArgCount);
		Type type = null;
		try
		{
			type = Type.GetType(fullTypeName);
		}
		catch (ArgumentException)
		{
		}
		catch (TypeLoadException)
		{
		}
		if (!(type != null && useAssemblyName) || !(type.AssemblyQualifiedName != fullTypeName))
		{
			return type;
		}
		return null;
	}

	private static string GetFriendlyName(this Type type, Func<Type, string> getBaseName)
	{
		if (type.IsArray)
		{
			string text = new string(Enumerable.Repeat(',', type.GetArrayRank() - 1).ToArray());
			return MiscHelpers.FormatInvariant("{0}[{1}]", type.GetElementType().GetFriendlyName(getBaseName), text);
		}
		Type[] array = type.GetGenericArguments();
		string text2 = string.Empty;
		if (type.IsNested)
		{
			Type type2 = type.DeclaringType.MakeSpecificType(array);
			text2 = type2.GetFriendlyName(getBaseName) + ".";
			array = array.Skip(type2.GetGenericArguments().Length).ToArray();
			getBaseName = GetRootName;
		}
		if (array.Length < 1)
		{
			return MiscHelpers.FormatInvariant("{0}{1}", text2, getBaseName(type));
		}
		string text3 = getBaseName(type.GetGenericTypeDefinition());
		string text4 = string.Join(",", array.Select((Type typeArg) => typeArg.GetFriendlyName(getBaseName)));
		return MiscHelpers.FormatInvariant("{0}{1}<{2}>", text2, text3, text4);
	}

	private static string GetFullTypeName(string name, string assemblyName, bool useAssemblyName, int typeArgCount)
	{
		string text = name;
		if (typeArgCount > 0)
		{
			text += MiscHelpers.FormatInvariant("`{0}", typeArgCount);
		}
		if (useAssemblyName)
		{
			text += MiscHelpers.FormatInvariant(", {0}", AssemblyTable.GetFullAssemblyName(assemblyName));
		}
		return text;
	}

	private static Invocability GetInvocabilityInternal(Tuple<Type, BindingFlags, Type, ScriptAccess, bool> args)
	{
		if (typeof(Delegate).IsAssignableFrom(args.Item1))
		{
			return Invocability.Delegate;
		}
		if (!args.Item5 && typeof(IDynamicMetaObjectProvider).IsAssignableFrom(args.Item1))
		{
			return Invocability.Dynamic;
		}
		if (args.Item1.GetScriptableDefaultProperties(args.Item2, args.Item3, args.Item4).Any())
		{
			return Invocability.DefaultProperty;
		}
		return Invocability.None;
	}

	private static bool IsValidLocatorChar(char ch)
	{
		if (!char.IsLetterOrDigit(ch) && ch != '_')
		{
			return ch == '.';
		}
		return true;
	}

	private static string StripGenericSuffix(string name)
	{
		int num = name.LastIndexOf('`');
		if (num < 0)
		{
			return name;
		}
		return name.Substring(0, num);
	}

	private static Type GetPropertyIndexType(object bindArg)
	{
		if (bindArg is HostTarget hostTarget)
		{
			return hostTarget.Type;
		}
		if (bindArg != null)
		{
			return bindArg.GetType();
		}
		throw new InvalidOperationException("Property index value must not be null");
	}

	private static PropertyInfo SelectProperty(PropertyInfo[] candidates, BindingFlags bindFlags, object[] bindArgs)
	{
		if (candidates.Length < 1)
		{
			return null;
		}
		PropertyInfo propertyInfo = Type.DefaultBinder.SelectProperty(bindFlags, candidates, null, bindArgs.Select(GetPropertyIndexType).ToArray(), null);
		if (propertyInfo != null)
		{
			return propertyInfo;
		}
		if (candidates.Length == 1)
		{
			ParameterInfo[] indexParameters = candidates[0].GetIndexParameters();
			if (bindArgs.Length == indexParameters.Length || (bindArgs.Length != 0 && indexParameters.Length >= bindArgs.Length))
			{
				return candidates[0];
			}
		}
		return null;
	}

	private static bool IsImplicitlyConvertibleFrom(this Type type, Type sourceType, ref object value)
	{
		if (!IsImplicitlyConvertibleInternal(type, sourceType, type, ref value))
		{
			return IsImplicitlyConvertibleInternal(sourceType, sourceType, type, ref value);
		}
		return true;
	}

	private static bool IsImplicitlyConvertibleInternal(Type definingType, Type sourceType, Type targetType, ref object value)
	{
		foreach (MethodInfo item in from method in definingType.GetMethods(BindingFlags.Static | BindingFlags.Public)
			where method.Name == "op_Implicit"
			select method)
		{
			ParameterInfo[] parameters = item.GetParameters();
			if (parameters.Length == 1 && parameters[0].ParameterType.IsAssignableFrom(sourceType) && targetType.IsAssignableFrom(item.ReturnType))
			{
				value = item.Invoke(null, new object[1] { value });
				return true;
			}
		}
		return false;
	}
}
