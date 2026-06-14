using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.ClearScript.Util;

namespace Microsoft.ClearScript;

internal static class CanonicalRefTable
{
	private interface ICanonicalRefMap
	{
		object GetRef(object obj);
	}

	private abstract class CanonicalRefMapBase : ICanonicalRefMap
	{
		protected const int CompactionThreshold = 262144;

		protected static readonly TimeSpan CompactionInterval = TimeSpan.FromMinutes(2.0);

		public abstract object GetRef(object obj);
	}

	private sealed class CanonicalRefMap<T> : CanonicalRefMapBase
	{
		private readonly object mapLock = new object();

		private readonly Dictionary<T, WeakReference> map = new Dictionary<T, WeakReference>();

		private DateTime lastCompactionTime = DateTime.MinValue;

		private object GetRefInternal(object obj)
		{
			T key = (T)obj;
			object obj2;
			if (map.TryGetValue(key, out var value))
			{
				obj2 = value.Target;
				if (obj2 == null)
				{
					obj2 = (value.Target = obj);
				}
			}
			else
			{
				obj2 = obj;
				map.Add(key, new WeakReference(obj2));
			}
			return obj2;
		}

		private void CompactIfNecessary()
		{
			if (map.Count < 262144)
			{
				return;
			}
			DateTime utcNow = DateTime.UtcNow;
			if (lastCompactionTime + CanonicalRefMapBase.CompactionInterval <= utcNow)
			{
				map.Where((KeyValuePair<T, WeakReference> pair) => !pair.Value.IsAlive).ToList().ForEach(delegate(KeyValuePair<T, WeakReference> pair)
				{
					map.Remove(pair.Key);
				});
				lastCompactionTime = utcNow;
			}
		}

		public override object GetRef(object obj)
		{
			lock (mapLock)
			{
				object refInternal = GetRefInternal(obj);
				CompactIfNecessary();
				return refInternal;
			}
		}
	}

	private static readonly object tableLock = new object();

	private static readonly Dictionary<Type, ICanonicalRefMap> table = new Dictionary<Type, ICanonicalRefMap>();

	public static object GetCanonicalRef(object obj)
	{
		if (obj is ValueType)
		{
			ICanonicalRefMap map = GetMap(obj);
			if (map != null)
			{
				obj = map.GetRef(obj);
			}
		}
		return obj;
	}

	private static ICanonicalRefMap GetMap(object obj)
	{
		Type type = obj.GetType();
		lock (tableLock)
		{
			if (!table.TryGetValue(type, out var value))
			{
				if (type.IsEnum || type.IsNumeric() || type == typeof(DateTime) || type == typeof(DateTimeOffset) || type == typeof(TimeSpan) || type.GetCustomAttributes(typeof(ImmutableValueAttribute), inherit: false).Any())
				{
					value = (ICanonicalRefMap)typeof(CanonicalRefMap<>).MakeGenericType(type).CreateInstance();
				}
				table.Add(type, value);
			}
			return value;
		}
	}
}
