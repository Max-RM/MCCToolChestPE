using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace NBTExplorer.Utility;

public class NaturalComparer : Comparer<string>, IDisposable
{
	private Dictionary<string, string[]> table;

	public NaturalComparer()
	{
		table = new Dictionary<string, string[]>();
	}

	public void Dispose()
	{
		table.Clear();
		table = null;
	}

	public override int Compare(string x, string y)
	{
		if (x == y)
		{
			return 0;
		}
		if (!table.TryGetValue(x, out var value))
		{
			value = Regex.Split(x.Replace(" ", ""), "(-?[0-9]+)");
			table.Add(x, value);
		}
		if (!table.TryGetValue(y, out var value2))
		{
			value2 = Regex.Split(y.Replace(" ", ""), "(-?[0-9]+)");
			table.Add(y, value2);
		}
		for (int i = 0; i < value.Length && i < value2.Length; i++)
		{
			if (value[i] != value2[i])
			{
				return PartCompare(value[i], value2[i]);
			}
		}
		if (value2.Length > value.Length)
		{
			return 1;
		}
		if (value.Length > value2.Length)
		{
			return -1;
		}
		return 0;
	}

	private static int PartCompare(string left, string right)
	{
		if (!int.TryParse(left, out var result))
		{
			return left.CompareTo(right);
		}
		if (!int.TryParse(right, out var result2))
		{
			return left.CompareTo(right);
		}
		return result.CompareTo(result2);
	}
}
