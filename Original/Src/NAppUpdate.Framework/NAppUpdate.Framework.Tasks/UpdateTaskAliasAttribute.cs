using System;
using System.Diagnostics;

namespace NAppUpdate.Framework.Tasks;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class UpdateTaskAliasAttribute : Attribute
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

	public UpdateTaskAliasAttribute(string alias)
	{
		_alias = alias;
	}
}
