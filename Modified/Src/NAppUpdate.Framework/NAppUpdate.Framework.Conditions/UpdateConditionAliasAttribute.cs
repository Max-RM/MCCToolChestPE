using System;
using System.Diagnostics;

namespace NAppUpdate.Framework.Conditions;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class UpdateConditionAliasAttribute : Attribute
{
	private readonly string _alias;

	public string Alias
	{
		[DebuggerStepThrough]
		get
		{
			return _alias;
		}
	}

	public UpdateConditionAliasAttribute(string alias)
	{
		_alias = alias;
	}
}
