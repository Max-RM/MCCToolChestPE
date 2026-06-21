using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.ClearScript;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.scripting;

public class JsDictionary : IPropertyBag, IDictionary<string, object>, ICollection<KeyValuePair<string, object>>, IEnumerable<KeyValuePair<string, object>>, IEnumerable
{
	private Dictionary<string, object> APWSL7HJ5Hg;

	public ICollection<string> Keys
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return APWSL7HJ5Hg.Keys;
		}
	}

	public ICollection<object> Values
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return APWSL7HJ5Hg.Values;
		}
	}

	public virtual object this[string key]
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return APWSL7HJ5Hg[key];
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			APWSL7HJ5Hg[key] = value;
		}
	}

	public int Count
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return APWSL7HJ5Hg.Count;
		}
	}

	public int length
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return APWSL7HJ5Hg.Count;
		}
	}

	public bool IsReadOnly
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return false;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Add(string key, object value)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		APWSL7HJ5Hg[key] = value;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool ContainsKey(string key)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return APWSL7HJ5Hg.ContainsKey(key);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool Remove(string key)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return APWSL7HJ5Hg.Remove(key);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool TryGetValue(string key, out object value)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return APWSL7HJ5Hg.TryGetValue(key, out value);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Add(KeyValuePair<string, object> item)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		APWSL7HJ5Hg.Add(item.Key, item.Value);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Clear()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		APWSL7HJ5Hg.Clear();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool Contains(KeyValuePair<string, object> item)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return APWSL7HJ5Hg.Contains(item);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool Remove(KeyValuePair<string, object> item)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (APWSL7HJ5Hg.Contains(item))
		{
			return APWSL7HJ5Hg.Remove(item.Key);
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return APWSL7HJ5Hg.GetEnumerator();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	IEnumerator IEnumerable.GetEnumerator()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return APWSL7HJ5Hg.GetEnumerator();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public JsDictionary()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		APWSL7HJ5Hg = new Dictionary<string, object>();
	}
}
