using System;
using System.Dynamic;
using System.Reflection;
using Microsoft.ClearScript.Util;

namespace Microsoft.ClearScript;

internal sealed class HostVariable<T> : HostVariableBase, IHostVariable
{
	private T value;

	public T Value
	{
		get
		{
			return value;
		}
		set
		{
			this.value = value;
		}
	}

	public override Type Type => typeof(T);

	public override object Target => value;

	public override object InvokeTarget => value;

	public override object DynamicInvokeTarget => value;

	public override HostTargetFlags Flags => HostTargetFlags.AllowInstanceMembers | HostTargetFlags.AllowExtensionMethods;

	object IHostVariable.Value
	{
		get
		{
			return value;
		}
		set
		{
			if (!typeof(T).IsAssignableFrom(ref value))
			{
				throw new InvalidOperationException("Assignment invalid due to type mismatch");
			}
			if (value is HostItem || value is HostTarget)
			{
				throw new NotSupportedException("Unsupported value type");
			}
			this.value = (T)value;
		}
	}

	public HostVariable(T initValue)
	{
		if (typeof(T) == typeof(Undefined) || typeof(T) == typeof(VoidResult))
		{
			throw new NotSupportedException("Unsupported variable type");
		}
		if (typeof(HostItem).IsAssignableFrom(typeof(T)) || typeof(HostTarget).IsAssignableFrom(typeof(T)))
		{
			throw new NotSupportedException("Unsupported variable type");
		}
		if (initValue is HostItem || initValue is HostTarget)
		{
			throw new NotSupportedException("Unsupported value type");
		}
		value = initValue;
	}

	public override string ToString()
	{
		string friendlyName = value.GetFriendlyName(typeof(T));
		return MiscHelpers.FormatInvariant("HostVariable:{0}", friendlyName);
	}

	public override bool TryInvokeAuxMember(IHostInvokeContext context, string name, BindingFlags invokeFlags, object[] args, object[] bindArgs, out object result)
	{
		switch (name)
		{
		case "out":
			if ((invokeFlags & (BindingFlags.GetField | BindingFlags.GetProperty)) != BindingFlags.Default)
			{
				result = new OutArg<T>(this);
				return true;
			}
			break;
		case "ref":
			if ((invokeFlags & (BindingFlags.GetField | BindingFlags.GetProperty)) != BindingFlags.Default)
			{
				result = new RefArg<T>(this);
				return true;
			}
			break;
		case "value":
			if (invokeFlags.HasFlag(BindingFlags.InvokeMethod))
			{
				if (InvokeHelpers.TryInvokeObject(context, value, invokeFlags, args, bindArgs, typeof(IDynamicMetaObjectProvider).IsAssignableFrom(typeof(T)), out result))
				{
					return true;
				}
				if (invokeFlags.HasFlag(BindingFlags.GetField) && args.Length < 1)
				{
					result = context.Engine.PrepareResult(value, ScriptMemberFlags.None, isListIndexResult: false);
					return true;
				}
				result = null;
				return false;
			}
			if ((invokeFlags & (BindingFlags.GetField | BindingFlags.GetProperty)) != BindingFlags.Default)
			{
				result = context.Engine.PrepareResult(value, ScriptMemberFlags.None, isListIndexResult: false);
				return true;
			}
			if ((invokeFlags & (BindingFlags.SetProperty | BindingFlags.PutDispProperty | BindingFlags.PutRefDispProperty)) != BindingFlags.Default && args.Length == 1)
			{
				ScriptEngine engine = context.Engine;
				object result2 = (((IHostVariable)this).Value = args[0]);
				result = engine.PrepareResult(result2, typeof(T), ScriptMemberFlags.None, isListIndexResult: false);
				return true;
			}
			break;
		}
		result = null;
		return false;
	}

	public override Invocability GetInvocability(BindingFlags bindFlags, Type accessContext, ScriptAccess defaultAccess, bool ignoreDynamic)
	{
		return typeof(T).GetInvocability(bindFlags, accessContext, defaultAccess, ignoreDynamic);
	}
}
