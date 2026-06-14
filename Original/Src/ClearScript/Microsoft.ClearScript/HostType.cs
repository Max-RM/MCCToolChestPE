using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.ClearScript.Util;

namespace Microsoft.ClearScript;

internal sealed class HostType : HostTarget, IScriptableObject
{
	private readonly Type[] types;

	public Type[] Types => types;

	public override Type Type => GetSpecificTypeNoThrow() ?? types[0];

	public override object Target => this;

	public override object InvokeTarget
	{
		get
		{
			GetSpecificType();
			return null;
		}
	}

	public override object DynamicInvokeTarget => GetSpecificType();

	public override HostTargetFlags Flags
	{
		get
		{
			Type specificTypeNoThrow = GetSpecificTypeNoThrow();
			if (!(specificTypeNoThrow != null))
			{
				return HostTargetFlags.None;
			}
			return HostTargetFlags.AllowStaticMembers;
		}
	}

	private HostType(Type type)
		: this(new Type[1] { type })
	{
	}

	private HostType(Type[] types)
	{
		IList<IGrouping<bool, Type>> list = (from type in types
			group type by type.IsNested).ToIList();
		if (list.Count != 1)
		{
			throw new NotSupportedException("Cannot create type wrapper for multiple unrelated types");
		}
		if (list[0].Key)
		{
			if ((from type in types
				group type by type.DeclaringType).Count() > 1)
			{
				throw new NotSupportedException("Cannot create type wrapper for multiple unrelated types");
			}
		}
		else if ((from type in types
			group type by type.GetLocator()).Count() > 1)
		{
			throw new NotSupportedException("Cannot create type wrapper for multiple unrelated types");
		}
		IEnumerable<Type> source = types.Where((Type testType) => testType.IsSpecific());
		if (source.Count() > 1)
		{
			throw new NotSupportedException("Cannot create type wrapper for multiple specific types");
		}
		this.types = types;
	}

	public static HostType Wrap(Type type)
	{
		if (!(type != null))
		{
			return null;
		}
		return new HostType(type);
	}

	public static HostType Wrap(Type[] types)
	{
		if (types == null || types.Length == 0)
		{
			return null;
		}
		return new HostType(types);
	}

	public Type GetSpecificType()
	{
		Type specificTypeNoThrow = GetSpecificTypeNoThrow();
		if (specificTypeNoThrow == null)
		{
			throw new InvalidOperationException(MiscHelpers.FormatInvariant("'{0}' requires type arguments", types[0].GetRootName()));
		}
		return specificTypeNoThrow;
	}

	public Type GetTypeArg()
	{
		Type specificType = GetSpecificType();
		if (specificType.IsStatic())
		{
			throw new InvalidOperationException(MiscHelpers.FormatInvariant("'{0}': static types cannot be used as type arguments", specificType.GetRootName()));
		}
		if (specificType.IsUnknownCOMObject())
		{
			throw new InvalidOperationException("Unknown COM/ActiveX types cannot be used as type arguments");
		}
		return specificType;
	}

	public Type GetTypeArgNoThrow()
	{
		Type specificTypeNoThrow = GetSpecificTypeNoThrow();
		if (!(specificTypeNoThrow == null) && !specificTypeNoThrow.IsStatic() && !specificTypeNoThrow.IsUnknownCOMObject())
		{
			return specificTypeNoThrow;
		}
		return null;
	}

	private Type GetSpecificTypeNoThrow()
	{
		return types.FirstOrDefault((Type testType) => testType.IsSpecific());
	}

	public override string ToString()
	{
		Type specificTypeNoThrow = GetSpecificTypeNoThrow();
		if (specificTypeNoThrow != null)
		{
			return MiscHelpers.FormatInvariant("HostType:{0}", specificTypeNoThrow.GetFriendlyName());
		}
		Type[] genericArguments = types[0].GetGenericArguments();
		string text = string.Empty;
		if (types[0].IsNested)
		{
			Type type = types[0].DeclaringType.MakeSpecificType(genericArguments);
			text = type.GetFriendlyName() + ".";
		}
		return MiscHelpers.FormatInvariant((types.Length > 1) ? "HostTypeGroup:{0}{1}" : "GenericHostType:{0}{1}", text, types[0].GetRootName());
	}

	public override string[] GetAuxPropertyNames(IHostInvokeContext context, BindingFlags bindFlags)
	{
		Type specificTypeNoThrow = GetSpecificTypeNoThrow();
		if (specificTypeNoThrow != null)
		{
			return (from testType in specificTypeNoThrow.GetScriptableNestedTypes(bindFlags, context.AccessContext, context.DefaultAccess)
				select testType.GetRootName()).Distinct().ToArray();
		}
		return ArrayHelpers.GetEmptyArray<string>();
	}

	public override bool TryInvokeAuxMember(IHostInvokeContext context, string name, BindingFlags invokeFlags, object[] args, object[] bindArgs, out object result)
	{
		Type type = GetSpecificTypeNoThrow();
		if (type != null)
		{
			IList<Type> list = (from testType in type.GetScriptableNestedTypes(invokeFlags, context.AccessContext, context.DefaultAccess)
				where testType.GetRootName() == name
				select testType).ToIList();
			if (list.Count > 0)
			{
				HostType hostType = Wrap(list.Select((Type testType) => testType.ApplyTypeArguments(type.GetGenericArguments())).ToArray());
				if (invokeFlags.HasFlag(BindingFlags.InvokeMethod))
				{
					if (hostType.TryInvoke(context, invokeFlags, args, bindArgs, out result))
					{
						return true;
					}
					if (!invokeFlags.HasFlag(BindingFlags.GetField) && !invokeFlags.HasFlag(BindingFlags.GetProperty))
					{
						return false;
					}
				}
				result = hostType;
				return true;
			}
		}
		result = null;
		return false;
	}

	public override bool TryInvoke(IHostInvokeContext context, BindingFlags invokeFlags, object[] args, object[] bindArgs, out object result)
	{
		if (!invokeFlags.HasFlag(BindingFlags.InvokeMethod) || args.Length < 1)
		{
			result = null;
			return false;
		}
		if (!args.All((object arg) => arg is HostType))
		{
			throw new ArgumentException("Invalid generic type argument");
		}
		Type[] array = types.Where((Type type2) => !type2.IsSpecific()).ToArray();
		Type[] typeArgs = (from HostType hostType in args
			select hostType.GetTypeArg()).ToArray();
		Type type = array.FirstOrDefault((Type testTemplate) => testTemplate.GetGenericParamCount() == typeArgs.Length);
		if (type == null)
		{
			throw new TypeLoadException(MiscHelpers.FormatInvariant("Could not find a matching generic type definition for '{0}'", array[0].GetRootName()));
		}
		result = Wrap(type.MakeSpecificType(typeArgs));
		return true;
	}

	public override Invocability GetInvocability(BindingFlags bindFlags, Type accessContext, ScriptAccess defaultAccess, bool ignoreDynamic)
	{
		return Invocability.Delegate;
	}

	void IScriptableObject.OnExposedToScriptCode(ScriptEngine engine)
	{
		if (engine != null)
		{
			Type specificTypeNoThrow = GetSpecificTypeNoThrow();
			if (specificTypeNoThrow != null)
			{
				engine.ProcessExtensionMethodType(specificTypeNoThrow);
			}
		}
	}
}
