using System.Collections.Generic;

namespace Substrate.Core;

internal static class Base16
{
	private const string _alphabet = "0123456789abcdef";

	public static string Encode(byte[] input, int stride = 0, char strideChar = ' ')
	{
		List<char> list = new List<char>();
		for (int i = 0; i < input.Length; i++)
		{
			int index = (input[i] >> 4) & 0xF;
			int index2 = input[i] & 0xF;
			list.Add("0123456789abcdef"[index]);
			if (stride > 0 && ((i + 1) * 2 - 1) % stride == 0)
			{
				list.Add(strideChar);
			}
			list.Add("0123456789abcdef"[index2]);
			if (stride > 0 && (i + 1) * 2 % stride == 0)
			{
				list.Add(strideChar);
			}
		}
		return new string(list.ToArray());
	}
}
