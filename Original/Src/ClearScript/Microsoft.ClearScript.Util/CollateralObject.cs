using System.Runtime.CompilerServices;

namespace Microsoft.ClearScript.Util;

internal class CollateralObject<THolder, TValue> where THolder : class where TValue : class
{
	private readonly ConditionalWeakTable<THolder, TValue> table = new ConditionalWeakTable<THolder, TValue>();

	public TValue Get(THolder holder)
	{
		if (!table.TryGetValue(holder, out var value))
		{
			return null;
		}
		return value;
	}

	public TValue GetOrCreate(THolder holder)
	{
		return table.GetOrCreateValue(holder);
	}

	public virtual void Set(THolder holder, TValue value)
	{
		Clear(holder);
		if (value != null)
		{
			table.Add(holder, value);
		}
	}

	public void Clear(THolder holder)
	{
		table.Remove(holder);
	}
}
