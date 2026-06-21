using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.ClearScript.Util;

namespace Microsoft.ClearScript;

public class PropertyBag : IPropertyBag, IDictionary<string, object>, ICollection<KeyValuePair<string, object>>, IEnumerable<KeyValuePair<string, object>>, IEnumerable, INotifyPropertyChanged, IScriptableObject
{
	private readonly Dictionary<string, object> dictionary;

	private readonly ICollection<KeyValuePair<string, object>> collection;

	private readonly bool isReadOnly;

	private readonly ConcurrentWeakSet<ScriptEngine> engineSet = new ConcurrentWeakSet<ScriptEngine>();

	internal int EngineCount => engineSet.Count;

	int ICollection<KeyValuePair<string, object>>.Count => collection.Count;

	bool ICollection<KeyValuePair<string, object>>.IsReadOnly => isReadOnly;

	public object this[string key]
	{
		get
		{
			return dictionary[key];
		}
		set
		{
			CheckReadOnly();
			SetPropertyNoCheck(key, value);
		}
	}

	public ICollection<string> Keys => dictionary.Keys;

	public ICollection<object> Values => dictionary.Values;

	public event PropertyChangedEventHandler PropertyChanged;

	public PropertyBag()
		: this(isReadOnly: false)
	{
	}

	public PropertyBag(bool isReadOnly)
	{
		dictionary = new Dictionary<string, object>();
		collection = dictionary;
		this.isReadOnly = isReadOnly;
	}

	public void SetPropertyNoCheck(string name, object value)
	{
		dictionary[name] = value;
		NotifyPropertyChanged(name);
		NotifyExposedToScriptCode(value);
	}

	public bool RemovePropertyNoCheck(string name)
	{
		if (dictionary.Remove(name))
		{
			NotifyPropertyChanged(name);
			return true;
		}
		return false;
	}

	public void ClearNoCheck()
	{
		dictionary.Clear();
		NotifyPropertyChanged(null);
	}

	private void CheckReadOnly()
	{
		if (isReadOnly)
		{
			throw new UnauthorizedAccessException("Object is read-only");
		}
	}

	private void AddPropertyNoCheck(string name, object value)
	{
		dictionary.Add(name, value);
		NotifyPropertyChanged(name);
		NotifyExposedToScriptCode(value);
	}

	private void NotifyPropertyChanged(string name)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
	}

	private void NotifyExposedToScriptCode(object value)
	{
		if (value is IScriptableObject scriptableObject)
		{
			engineSet.ForEach(scriptableObject.OnExposedToScriptCode);
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return dictionary.GetEnumerator();
	}

	IEnumerator<KeyValuePair<string, object>> IEnumerable<KeyValuePair<string, object>>.GetEnumerator()
	{
		return dictionary.GetEnumerator();
	}

	void ICollection<KeyValuePair<string, object>>.Add(KeyValuePair<string, object> item)
	{
		CheckReadOnly();
		SetPropertyNoCheck(item.Key, item.Value);
	}

	void ICollection<KeyValuePair<string, object>>.Clear()
	{
		CheckReadOnly();
		ClearNoCheck();
	}

	bool ICollection<KeyValuePair<string, object>>.Contains(KeyValuePair<string, object> item)
	{
		return collection.Contains(item);
	}

	void ICollection<KeyValuePair<string, object>>.CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
	{
		collection.CopyTo(array, arrayIndex);
	}

	bool ICollection<KeyValuePair<string, object>>.Remove(KeyValuePair<string, object> item)
	{
		CheckReadOnly();
		if (collection.Remove(item))
		{
			NotifyPropertyChanged(item.Key);
			return true;
		}
		return false;
	}

	public bool ContainsKey(string key)
	{
		return dictionary.ContainsKey(key);
	}

	public void Add(string key, object value)
	{
		CheckReadOnly();
		AddPropertyNoCheck(key, value);
	}

	public bool Remove(string key)
	{
		CheckReadOnly();
		return RemovePropertyNoCheck(key);
	}

	public bool TryGetValue(string key, out object value)
	{
		return dictionary.TryGetValue(key, out value);
	}

	void IScriptableObject.OnExposedToScriptCode(ScriptEngine engine)
	{
		if (engine == null || !engineSet.TryAdd(engine))
		{
			return;
		}
		foreach (IScriptableObject item in Values.OfType<IScriptableObject>())
		{
			item.OnExposedToScriptCode(engine);
		}
	}
}
