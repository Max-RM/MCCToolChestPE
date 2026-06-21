using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.ClearScript.Util;

internal static class ArrayHelpers
{
	private static class EmptyArray<T>
	{
		private static readonly T[] value = new T[0];

		public static T[] Value => value;
	}

	public static void Iterate(this Array array, Action<int[]> action)
	{
		if (array.Rank > 0)
		{
			IEnumerable<int> source = Enumerable.Range(0, array.Rank);
			if (source.Aggregate(1, (int count, int dimension) => count * array.GetLength(dimension)) > 0)
			{
				Iterate(array, new int[array.Rank], 0, action);
			}
		}
	}

	private static void Iterate(Array array, int[] indices, int dimension, Action<int[]> action)
	{
		if (dimension >= indices.Length)
		{
			action(indices);
			return;
		}
		int lowerBound = array.GetLowerBound(dimension);
		int upperBound = array.GetUpperBound(dimension);
		for (int i = lowerBound; i <= upperBound; i++)
		{
			indices[dimension] = i;
			Iterate(array, indices, dimension + 1, action);
		}
	}

	public static T[] GetEmptyArray<T>()
	{
		return EmptyArray<T>.Value;
	}
}
