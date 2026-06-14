namespace Substrate.Nbt;

public sealed class TagNodeIntArray : TagNode
{
	private int[] _data;

	public int[] Data
	{
		get
		{
			return _data;
		}
		set
		{
			_data = value;
		}
	}

	public int Length => _data.Length;

	public int this[int index]
	{
		get
		{
			return _data[index];
		}
		set
		{
			_data[index] = value;
		}
	}

	public override TagNodeIntArray ToTagIntArray()
	{
		return this;
	}

	public override TagType GetTagType()
	{
		return TagType.TAG_INT_ARRAY;
	}

	public TagNodeIntArray()
	{
	}

	public TagNodeIntArray(int[] d)
	{
		_data = d;
	}

	public override TagNode Copy()
	{
		int[] array = new int[_data.Length];
		_data.CopyTo(array, 0);
		return new TagNodeIntArray(array);
	}

	public override string ToString()
	{
		return _data.ToString();
	}

	public static implicit operator TagNodeIntArray(int[] i)
	{
		return new TagNodeIntArray(i);
	}

	public static implicit operator int[](TagNodeIntArray i)
	{
		return i._data;
	}
}
