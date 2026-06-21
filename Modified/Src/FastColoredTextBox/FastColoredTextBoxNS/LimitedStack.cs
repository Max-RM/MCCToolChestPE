using System;

namespace FastColoredTextBoxNS;

public class LimitedStack<T>
{
	private T[] items;

	private int count;

	private int start;

	public int MaxItemCount => items.Length;

	public int Count => count;

	private int LastIndex => (start + count - 1) % items.Length;

	public LimitedStack(int maxItemCount)
	{
		items = new T[maxItemCount];
		count = 0;
		start = 0;
	}

	public T Pop()
	{
		if (count == 0)
		{
			throw new Exception("Stack is empty");
		}
		int lastIndex = LastIndex;
		T result = items[lastIndex];
		items[lastIndex] = default(T);
		count--;
		return result;
	}

	public T Peek()
	{
		if (count == 0)
		{
			return default(T);
		}
		return items[LastIndex];
	}

	public void Push(T item)
	{
		if (count == items.Length)
		{
			start = (start + 1) % items.Length;
		}
		else
		{
			count++;
		}
		items[LastIndex] = item;
	}

	public void Clear()
	{
		items = new T[items.Length];
		count = 0;
		start = 0;
	}

	public T[] ToArray()
	{
		T[] array = new T[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = items[(start + i) % items.Length];
		}
		return array;
	}
}
