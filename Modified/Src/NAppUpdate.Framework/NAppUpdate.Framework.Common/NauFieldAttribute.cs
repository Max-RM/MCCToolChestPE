using System;
using System.Diagnostics;

namespace NAppUpdate.Framework.Common;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public class NauFieldAttribute : Attribute
{
	private readonly string _alias;

	private readonly string _description;

	private readonly bool _isRequired;

	public string Alias
	{
		[DebuggerStepThrough]
		get
		{
			return _alias;
		}
	}

	public string Description
	{
		[DebuggerStepThrough]
		get
		{
			return _description;
		}
	}

	public bool IsRequired
	{
		[DebuggerStepThrough]
		get
		{
			return _isRequired;
		}
	}

	public NauFieldAttribute(string alias, string description, bool isRequired)
	{
		_alias = alias;
		_description = description;
		_isRequired = isRequired;
	}
}
