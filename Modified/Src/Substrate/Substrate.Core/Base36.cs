using System;
using System.Collections.Generic;

namespace Substrate.Core;

internal static class Base36
{
	private const string _alphabet = "0123456789abcdefghijklmnopqrstuvwxyz";

	public static string Encode(long input)
	{
		if (input == 0)
		{
			return "0";
		}
		bool flag = input < 0;
		if (flag)
		{
			input *= -1;
		}
		Stack<char> stack = new Stack<char>();
		while (input != 0)
		{
			stack.Push("0123456789abcdefghijklmnopqrstuvwxyz"[(int)(input % 36)]);
			input /= 36;
		}
		string text = new string(stack.ToArray());
		if (flag)
		{
			text = '-' + text;
		}
		return text;
	}

	public static long Decode(string input)
	{
		if (input.Length == 0)
		{
			throw new ArgumentOutOfRangeException("input", input);
		}
		bool flag = false;
		if (input[0] == '-')
		{
			flag = true;
			input = input.Substring(1);
		}
		input = input.ToLower();
		long num = 0L;
		int num2 = 0;
		for (int num3 = input.Length - 1; num3 >= 0; num3--)
		{
			num += "0123456789abcdefghijklmnopqrstuvwxyz".IndexOf(input[num3]) * (long)Math.Pow(36.0, num2);
			num2++;
		}
		if (flag)
		{
			num *= -1;
		}
		return num;
	}
}
