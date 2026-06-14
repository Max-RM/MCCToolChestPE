using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Microsoft.ClearScript.Util;

internal static class MemberHelpers
{
	public static bool IsScriptable(this EventInfo eventInfo, Type accessContext, ScriptAccess defaultAccess)
	{
		if (!eventInfo.IsSpecialName && !eventInfo.IsExplicitImplementation() && eventInfo.IsAccessible(accessContext))
		{
			return !eventInfo.IsBlockedFromScript(defaultAccess);
		}
		return false;
	}

	public static bool IsScriptable(this FieldInfo field, Type accessContext, ScriptAccess defaultAccess)
	{
		if (!field.IsSpecialName && field.IsAccessible(accessContext))
		{
			return !field.IsBlockedFromScript(defaultAccess);
		}
		return false;
	}

	public static bool IsScriptable(this MethodInfo method, Type accessContext, ScriptAccess defaultAccess)
	{
		if (!method.IsSpecialName && !method.IsExplicitImplementation() && method.IsAccessible(accessContext))
		{
			return !method.IsBlockedFromScript(defaultAccess);
		}
		return false;
	}

	public static bool IsScriptable(this PropertyInfo property, Type accessContext, ScriptAccess defaultAccess)
	{
		if (!property.IsSpecialName && !property.IsExplicitImplementation() && property.IsAccessible(accessContext))
		{
			return !property.IsBlockedFromScript(defaultAccess);
		}
		return false;
	}

	public static bool IsScriptable(this Type type, Type accessContext, ScriptAccess defaultAccess)
	{
		if (!type.IsSpecialName && type.IsAccessible(accessContext))
		{
			return !type.IsBlockedFromScript(defaultAccess);
		}
		return false;
	}

	public static bool IsAccessible(this EventInfo eventInfo, Type accessContext)
	{
		return eventInfo.AddMethod.IsAccessible(accessContext);
	}

	public static bool IsAccessible(this FieldInfo field, Type accessContext)
	{
		Type declaringType = field.DeclaringType;
		if (!declaringType.IsAccessible(accessContext))
		{
			return false;
		}
		FieldAttributes fieldAttributes = field.Attributes & FieldAttributes.FieldAccessMask;
		if (fieldAttributes == FieldAttributes.Public)
		{
			return true;
		}
		if (accessContext == null)
		{
			return false;
		}
		switch (fieldAttributes)
		{
		case FieldAttributes.Private:
			return declaringType.EqualsOrDeclares(accessContext);
		case FieldAttributes.Family:
			return accessContext.IsFamilyOf(declaringType);
		case FieldAttributes.Assembly:
			return accessContext.IsFriendOf(declaringType);
		case FieldAttributes.FamORAssem:
			if (!accessContext.IsFamilyOf(declaringType))
			{
				return accessContext.IsFriendOf(declaringType);
			}
			return true;
		case FieldAttributes.FamANDAssem:
			if (accessContext.IsFamilyOf(declaringType))
			{
				return accessContext.IsFriendOf(declaringType);
			}
			return false;
		default:
			return false;
		}
	}

	public static bool IsAccessible(this MethodBase method, Type accessContext)
	{
		Type declaringType = method.DeclaringType;
		if (!declaringType.IsAccessible(accessContext))
		{
			return false;
		}
		MethodAttributes methodAttributes = method.Attributes & MethodAttributes.MemberAccessMask;
		if (methodAttributes == MethodAttributes.Public)
		{
			return true;
		}
		if (accessContext == null)
		{
			return false;
		}
		switch (methodAttributes)
		{
		case MethodAttributes.Private:
			return declaringType.EqualsOrDeclares(accessContext);
		case MethodAttributes.Family:
			return accessContext.IsFamilyOf(declaringType);
		case MethodAttributes.Assembly:
			return accessContext.IsFriendOf(declaringType);
		case MethodAttributes.FamORAssem:
			if (!accessContext.IsFamilyOf(declaringType))
			{
				return accessContext.IsFriendOf(declaringType);
			}
			return true;
		case MethodAttributes.FamANDAssem:
			if (accessContext.IsFamilyOf(declaringType))
			{
				return accessContext.IsFriendOf(declaringType);
			}
			return false;
		default:
			return false;
		}
	}

	public static bool IsAccessible(this MethodInfo method, Type accessContext)
	{
		return ((MethodBase)method.GetBaseDefinition()).IsAccessible(accessContext);
	}

	public static bool IsAccessible(this PropertyInfo property, Type accessContext)
	{
		MethodInfo getMethod = property.GetMethod;
		if (getMethod != null && getMethod.IsAccessible(accessContext))
		{
			return true;
		}
		MethodInfo setMethod = property.SetMethod;
		if (setMethod != null && setMethod.IsAccessible(accessContext))
		{
			return true;
		}
		return false;
	}

	public static bool IsAccessible(this Type type, Type accessContext)
	{
		TypeAttributes typeAttributes = type.Attributes & TypeAttributes.VisibilityMask;
		if (typeAttributes == TypeAttributes.Public)
		{
			return true;
		}
		if (accessContext == null)
		{
			if (typeAttributes == TypeAttributes.NestedPublic)
			{
				return type.DeclaringType.IsAccessible(null);
			}
			return false;
		}
		if (typeAttributes == TypeAttributes.NotPublic)
		{
			return accessContext.IsFriendOf(type);
		}
		type = type.DeclaringType;
		if (!type.IsAccessible(accessContext))
		{
			return false;
		}
		switch (typeAttributes)
		{
		case TypeAttributes.NestedPublic:
			return true;
		case TypeAttributes.NestedPrivate:
			return type.EqualsOrDeclares(accessContext);
		case TypeAttributes.NestedFamily:
			return accessContext.IsFamilyOf(type);
		case TypeAttributes.NestedAssembly:
			return accessContext.IsFriendOf(type);
		case TypeAttributes.VisibilityMask:
			if (!accessContext.IsFamilyOf(type))
			{
				return accessContext.IsFriendOf(type);
			}
			return true;
		case TypeAttributes.NestedFamANDAssem:
			if (accessContext.IsFamilyOf(type))
			{
				return accessContext.IsFriendOf(type);
			}
			return false;
		default:
			return false;
		}
	}

	public static string GetScriptName(this MemberInfo member)
	{
		ScriptMemberAttribute attribute = member.GetAttribute<ScriptMemberAttribute>(inherit: true);
		if (attribute == null || attribute.Name == null)
		{
			return member.GetShortName();
		}
		return attribute.Name;
	}

	public static bool IsBlockedFromScript(this MemberInfo member, ScriptAccess defaultAccess, bool chain = true)
	{
		return member.GetScriptAccess(defaultAccess, chain) == ScriptAccess.None;
	}

	public static bool IsReadOnlyForScript(this MemberInfo member, ScriptAccess defaultAccess)
	{
		return member.GetScriptAccess(defaultAccess) == ScriptAccess.ReadOnly;
	}

	public static ScriptAccess GetScriptAccess(this MemberInfo member, ScriptAccess defaultValue, bool chain = true)
	{
		ScriptUsageAttribute attribute = member.GetAttribute<ScriptUsageAttribute>(inherit: true);
		if (attribute != null)
		{
			return attribute.Access;
		}
		if (chain)
		{
			Type declaringType = member.DeclaringType;
			if (declaringType != null)
			{
				Type type = declaringType;
				do
				{
					if (type.IsNested)
					{
						ScriptUsageAttribute attribute2 = type.GetAttribute<ScriptUsageAttribute>(inherit: true);
						if (attribute2 != null)
						{
							return attribute2.Access;
						}
					}
					DefaultScriptUsageAttribute attribute3 = type.GetAttribute<DefaultScriptUsageAttribute>(inherit: true);
					if (attribute3 != null)
					{
						return attribute3.Access;
					}
					type = type.DeclaringType;
				}
				while (type != null);
				DefaultScriptUsageAttribute attribute4 = declaringType.Assembly.GetAttribute<DefaultScriptUsageAttribute>(inherit: true);
				if (attribute4 != null)
				{
					return attribute4.Access;
				}
			}
		}
		return defaultValue;
	}

	public static bool IsRestrictedForScript(this MemberInfo member)
	{
		return !member.GetScriptMemberFlags().HasFlag(ScriptMemberFlags.ExposeRuntimeType);
	}

	public static bool IsDispID(this MemberInfo member, int dispid)
	{
		DispIdAttribute attribute = member.GetAttribute<DispIdAttribute>(inherit: true);
		if (attribute != null)
		{
			return attribute.Value == dispid;
		}
		return false;
	}

	public static ScriptMemberFlags GetScriptMemberFlags(this MemberInfo member)
	{
		return member.GetAttribute<ScriptMemberAttribute>(inherit: true)?.Flags ?? ScriptMemberFlags.None;
	}

	public static string GetShortName(this MemberInfo member)
	{
		string name = member.Name;
		int num = name.LastIndexOf('.');
		if (num < 0)
		{
			return name;
		}
		return name.Substring(num + 1);
	}

	private static bool IsExplicitImplementation(this MemberInfo member)
	{
		return member.Name.IndexOf('.') >= 0;
	}

	private static T GetAttribute<T>(this MemberInfo member, bool inherit) where T : Attribute
	{
		try
		{
			return Attribute.GetCustomAttributes(member, typeof(T), inherit).SingleOrDefault() as T;
		}
		catch (AmbiguousMatchException)
		{
			if (inherit)
			{
				return Attribute.GetCustomAttributes(member, typeof(T), inherit: false).SingleOrDefault() as T;
			}
			throw;
		}
	}
}
