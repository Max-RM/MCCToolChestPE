using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.ClearScript.Util;

namespace Microsoft.ClearScript;

internal sealed class HostList : IHostList
{
	private readonly ScriptEngine engine;

	private readonly IList list;

	private readonly Type elementType;

	public int Count => list.Count;

	public object this[int index]
	{
		get
		{
			return engine.PrepareResult(list[index], elementType, ScriptMemberFlags.None, isListIndexResult: true);
		}
		set
		{
			list[index] = value;
		}
	}

	public HostList(ScriptEngine engine, IList list, Type elementType)
	{
		this.engine = engine;
		this.list = list;
		this.elementType = elementType;
	}
}
internal sealed class HostList<T> : IHostList
{
	private readonly ScriptEngine engine;

	private readonly IList<T> list;

	public int Count => list.Count;

	public object this[int index]
	{
		get
		{
			return engine.PrepareResult(list[index], ScriptMemberFlags.None, isListIndexResult: true);
		}
		set
		{
			if (!typeof(T).IsAssignableFrom(ref value))
			{
				throw new InvalidOperationException("Assignment invalid due to type mismatch");
			}
			list[index] = (T)value;
		}
	}

	public HostList(ScriptEngine engine, IList<T> list)
	{
		this.engine = engine;
		this.list = list;
	}
}
