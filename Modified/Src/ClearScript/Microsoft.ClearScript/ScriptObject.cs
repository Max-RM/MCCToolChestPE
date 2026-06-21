using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Microsoft.ClearScript.Util;

namespace Microsoft.ClearScript;

public abstract class ScriptObject : DynamicObject
{
	public abstract ScriptEngine Engine { get; }

	public abstract IEnumerable<string> PropertyNames { get; }

	public object this[string name, params object[] args]
	{
		get
		{
			return GetProperty(name, args);
		}
		set
		{
			SetProperty(name, args.Concat(value.ToEnumerable()).ToArray());
		}
	}

	public abstract IEnumerable<int> PropertyIndices { get; }

	public object this[int index]
	{
		get
		{
			return GetProperty(index);
		}
		set
		{
			SetProperty(index, value);
		}
	}

	internal ScriptObject()
	{
	}

	public abstract object GetProperty(string name, params object[] args);

	public abstract void SetProperty(string name, params object[] args);

	public abstract bool DeleteProperty(string name);

	public abstract object GetProperty(int index);

	public abstract void SetProperty(int index, object value);

	public abstract bool DeleteProperty(int index);

	public abstract object Invoke(bool asConstructor, params object[] args);

	public abstract object InvokeMethod(string name, params object[] args);
}
