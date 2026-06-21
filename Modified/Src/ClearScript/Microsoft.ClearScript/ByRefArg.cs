using System;
using System.Reflection;
using Microsoft.ClearScript.Util;

namespace Microsoft.ClearScript;

internal abstract class ByRefArg<T> : HostTarget, IByRefArg
{
	private readonly HostVariable<T> target;

	public T Value
	{
		get
		{
			return target.Value;
		}
		set
		{
			target.Value = value;
		}
	}

	public override Type Type => target.Type;

	public override object Target => this;

	public override object InvokeTarget => target.InvokeTarget;

	public override object DynamicInvokeTarget => target.DynamicInvokeTarget;

	public override HostTargetFlags Flags => target.Flags;

	object IByRefArg.Value
	{
		get
		{
			return target.Value;
		}
		set
		{
			((IHostVariable)target).Value = value;
		}
	}

	protected ByRefArg(HostVariable<T> target)
	{
		this.target = target;
	}

	public override string[] GetAuxMethodNames(IHostInvokeContext context, BindingFlags bindFlags)
	{
		return target.GetAuxMethodNames(context, bindFlags);
	}

	public override string[] GetAuxPropertyNames(IHostInvokeContext context, BindingFlags bindFlags)
	{
		return target.GetAuxPropertyNames(context, bindFlags);
	}

	public override bool TryInvokeAuxMember(IHostInvokeContext context, string name, BindingFlags invokeFlags, object[] args, object[] bindArgs, out object result)
	{
		return target.TryInvokeAuxMember(context, name, invokeFlags, args, bindArgs, out result);
	}

	public override bool TryInvoke(IHostInvokeContext context, BindingFlags invokeFlags, object[] args, object[] bindArgs, out object result)
	{
		return target.TryInvoke(context, invokeFlags, args, bindArgs, out result);
	}

	public override Invocability GetInvocability(BindingFlags bindFlags, Type accessContext, ScriptAccess defaultAccess, bool ignoreDynamic)
	{
		return target.GetInvocability(bindFlags, accessContext, defaultAccess, ignoreDynamic);
	}
}
