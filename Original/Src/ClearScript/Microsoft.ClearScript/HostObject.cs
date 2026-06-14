using System;
using System.Reflection;
using Microsoft.ClearScript.Util;

namespace Microsoft.ClearScript;

internal sealed class HostObject : HostTarget
{
	private static class NullWrapper<T>
	{
		private static readonly HostObject value = new HostObject(null, typeof(T));

		public static HostObject Value => value;
	}

	private readonly object target;

	private readonly Type type;

	private static readonly MethodInfo getNullWrapperGenericMethod = typeof(HostObject).GetMethod("GetNullWrapperGeneric", BindingFlags.Static | BindingFlags.NonPublic);

	public override Type Type => type;

	public override object Target => target;

	public override object InvokeTarget => target;

	public override object DynamicInvokeTarget => target;

	public override HostTargetFlags Flags => HostTargetFlags.AllowInstanceMembers | HostTargetFlags.AllowExtensionMethods;

	private HostObject(object target, Type type)
	{
		this.target = CanonicalRefTable.GetCanonicalRef(target);
		this.type = type ?? target.GetType();
	}

	public static HostObject Wrap(object target)
	{
		return Wrap(target, null);
	}

	public static HostObject Wrap(object target, Type type)
	{
		if (target == null)
		{
			return null;
		}
		return new HostObject(target, type);
	}

	public static object WrapResult(object result, Type type, bool wrapNull)
	{
		if (result is HostItem || result is HostTarget)
		{
			return result;
		}
		if (result == null)
		{
			if (!wrapNull)
			{
				return null;
			}
			return GetNullWrapper(type);
		}
		if (type == typeof(void) || type == typeof(object) || type.IsNullable())
		{
			return result;
		}
		if (type == result.GetType() || Type.GetTypeCode(type) != TypeCode.Object)
		{
			return result;
		}
		return Wrap(result, type);
	}

	private static HostObject GetNullWrapper(Type type)
	{
		return (HostObject)getNullWrapperGenericMethod.MakeGenericMethod(type).Invoke(null, ArrayHelpers.GetEmptyArray<object>());
	}

	private static HostObject GetNullWrapperGeneric<T>()
	{
		return NullWrapper<T>.Value;
	}

	public override string ToString()
	{
		if (target is ScriptItem && typeof(ScriptItem).IsAssignableFrom(type))
		{
			return "ScriptItem";
		}
		string friendlyName = target.GetFriendlyName(type);
		return MiscHelpers.FormatInvariant("HostObject:{0}", friendlyName);
	}

	public override Invocability GetInvocability(BindingFlags bindFlags, Type accessContext, ScriptAccess defaultAccess, bool ignoreDynamic)
	{
		return type.GetInvocability(bindFlags, accessContext, defaultAccess, ignoreDynamic);
	}
}
