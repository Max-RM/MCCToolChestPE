using System;
using System.Reflection;
using Microsoft.ClearScript.Util;

namespace Microsoft.ClearScript;

internal sealed class HostIndexedProperty : HostTarget
{
	private static readonly string[] auxMethodNames = new string[2] { "get", "set" };

	private readonly HostItem target;

	private readonly string name;

	public override Type Type => typeof(void);

	public override object Target => this;

	public override object InvokeTarget => null;

	public override object DynamicInvokeTarget => null;

	public override HostTargetFlags Flags => HostTargetFlags.None;

	public HostIndexedProperty(HostItem target, string name)
	{
		this.target = target;
		this.name = name;
	}

	public override string ToString()
	{
		return MiscHelpers.FormatInvariant("HostIndexedProperty:{0}", name);
	}

	public override string[] GetAuxMethodNames(IHostInvokeContext context, BindingFlags bindFlags)
	{
		return auxMethodNames;
	}

	public override bool TryInvokeAuxMember(IHostInvokeContext context, string memberName, BindingFlags invokeFlags, object[] args, object[] bindArgs, out object result)
	{
		if (invokeFlags.HasFlag(BindingFlags.InvokeMethod))
		{
			if (memberName == "get")
			{
				result = target.InvokeMember(name, BindingFlags.GetProperty, args, bindArgs, null, bypassTunneling: true);
				return true;
			}
			if (memberName == "set")
			{
				result = target.InvokeMember(name, BindingFlags.SetProperty, args, bindArgs, null, bypassTunneling: true);
				return true;
			}
		}
		result = null;
		return false;
	}

	public override bool TryInvoke(IHostInvokeContext context, BindingFlags invokeFlags, object[] args, object[] bindArgs, out object result)
	{
		result = target.InvokeMember(name, invokeFlags.HasFlag(BindingFlags.SetField) ? BindingFlags.SetProperty : BindingFlags.GetProperty, args, bindArgs, null, bypassTunneling: true);
		return true;
	}

	public override Invocability GetInvocability(BindingFlags bindFlags, Type accessContext, ScriptAccess defaultAccess, bool ignoreDynamic)
	{
		return Invocability.Delegate;
	}
}
