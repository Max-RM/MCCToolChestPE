using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Microsoft.ClearScript.Util;

internal static class EnumerableHelpers
{
	public static readonly HostType HostType = HostType.Wrap(typeof(EnumerableHelpers));

	public static IList<T> ToIList<T>(this IEnumerable<T> source)
	{
		return (source as IList<T>) ?? source.ToList();
	}

	public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
	{
		foreach (T item in source)
		{
			action(item);
		}
	}

	public static void ForEach<T>(this IEnumerable<T> source, Action<T, int> action)
	{
		int num = 0;
		foreach (T item in source)
		{
			action(item, num++);
		}
	}

	public static IEnumerable<T> ToSafeEnumerable<T>(this IEnumerable<T> source)
	{
		if (source == null)
		{
			yield break;
		}
		foreach (T item in source)
		{
			yield return item;
		}
	}

	public static IEnumerable<T> Flatten<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> selector)
	{
		foreach (T element in source)
		{
			yield return element;
			foreach (T item in selector(element).Flatten(selector))
			{
				yield return item;
			}
		}
	}

	public static IEnumerable<T> ToEnumerable<T>(this T element)
	{
		yield return element;
	}

	public static IEnumerable<string> ExcludeIndices(this IEnumerable<string> names)
	{
		foreach (string name in names)
		{
			if (!int.TryParse(name, NumberStyles.Integer, CultureInfo.InvariantCulture, out var _))
			{
				yield return name;
			}
		}
	}

	public static IEnumerable<int> GetIndices(this IEnumerable<string> names)
	{
		foreach (string name in names)
		{
			if (int.TryParse(name, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result))
			{
				yield return result;
			}
		}
	}

	public static IEnumerator<T> GetEnumerator<T>(IEnumerable<T> source)
	{
		return source.GetEnumerator();
	}

	public static IEnumerator GetEnumerator(IEnumerable source)
	{
		return source.GetEnumerator();
	}
}
