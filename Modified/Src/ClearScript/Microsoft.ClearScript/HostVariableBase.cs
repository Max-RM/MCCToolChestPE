using System.Reflection;
using Microsoft.ClearScript.Util;

namespace Microsoft.ClearScript;

internal abstract class HostVariableBase : HostTarget
{
	private static readonly string[] auxPropertyNames = new string[3] { "out", "ref", "value" };

	public override string[] GetAuxPropertyNames(IHostInvokeContext context, BindingFlags bindFlags)
	{
		return auxPropertyNames;
	}
}
