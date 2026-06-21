using System;
using System.Collections.Generic;

namespace NBTExplorer.Model;

internal static class FilterExpressionConverter
{
	private static List<List<string>> OperatorGroups = new List<List<string>>
	{
		new List<string> { "equal", "greater", "less", "contains", "begins", "ends" },
		new List<string> { "not" },
		new List<string> { "and", "or" }
	};

	public static List<string> Convert(List<string> tokens)
	{
		Queue<string> queue = new Queue<string>(tokens);
		List<string> list = new List<string>();
		Stack<string> stack = new Stack<string>();
		while (queue.Count > 0)
		{
			string text = queue.Dequeue();
			if (IsGroupStart(text))
			{
				stack.Push(text);
			}
			else if (IsGroupEnd(text))
			{
				while (stack.Count > 0 && !IsGroupStart(stack.Peek()))
				{
					list.Add(stack.Pop());
				}
				if (stack.Count == 0)
				{
					throw new Exception("Mismatched grouping");
				}
				stack.Pop();
			}
			else if (IsOperator(text))
			{
				while (stack.Count > 0 && IsOperator(stack.Peek()))
				{
					if (Precedence(text) > Precedence(stack.Peek()))
					{
						list.Add(stack.Pop());
					}
				}
				stack.Push(text);
			}
			else
			{
				list.Add(text);
			}
		}
		while (stack.Count > 0)
		{
			if (IsGroupStart(stack.Peek()))
			{
				throw new Exception("Mismatched grouping");
			}
			list.Add(stack.Pop());
		}
		return list;
	}

	private static bool IsGroupStart(string token)
	{
		return token == "(";
	}

	private static bool IsGroupEnd(string token)
	{
		return token == ")";
	}

	private static bool IsOperator(string token)
	{
		foreach (List<string> operatorGroup in OperatorGroups)
		{
			if (operatorGroup.Contains(token))
			{
				return true;
			}
		}
		return false;
	}

	private static int Precedence(string op)
	{
		for (int i = 0; i < OperatorGroups.Count; i++)
		{
			if (OperatorGroups[i].Contains(op))
			{
				return i;
			}
		}
		return int.MaxValue;
	}
}
