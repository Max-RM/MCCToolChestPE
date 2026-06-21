using System;
using System.Collections.Generic;

namespace Microsoft.ClearScript.Util;

internal sealed class ConcurrentWeakSet<T> where T : class
{
	private readonly object dataLock = new object();

	private List<WeakReference> weakRefs = new List<WeakReference>();

	public int Count => GetItems().Count;

	public bool Contains(T item)
	{
		MiscHelpers.VerifyNonNullArgument(item, "item");
		return GetItems().Contains(item);
	}

	public bool TryAdd(T item)
	{
		MiscHelpers.VerifyNonNullArgument(item, "item");
		lock (dataLock)
		{
			if (!GetItemsInternal().Contains(item))
			{
				weakRefs.Add(new WeakReference(item));
				return true;
			}
			return false;
		}
	}

	public void ForEach(Action<T> action)
	{
		MiscHelpers.VerifyNonNullArgument(action, "action");
		GetItems().ForEach(action);
	}

	private List<T> GetItems()
	{
		lock (dataLock)
		{
			return GetItemsInternal();
		}
	}

	private List<T> GetItemsInternal()
	{
		List<T> list = new List<T>();
		List<WeakReference> list2 = new List<WeakReference>();
		foreach (WeakReference weakRef in weakRefs)
		{
			if (weakRef.Target is T item)
			{
				list.Add(item);
				list2.Add(weakRef);
			}
		}
		weakRefs = list2;
		return list;
	}
}
