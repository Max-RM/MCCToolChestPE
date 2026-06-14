namespace Substrate.Nbt;

public sealed class TagNodeByteArray : TagNode
{
	private byte[] _data;

	public byte[] Data
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

	public byte this[int index]
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

	public override TagNodeByteArray ToTagByteArray()
	{
		return this;
	}

	public override TagType GetTagType()
	{
		return TagType.TAG_BYTE_ARRAY;
	}

	public TagNodeByteArray()
	{
	}

	public TagNodeByteArray(byte[] d)
	{
		_data = d;
	}

	public override TagNode Copy()
	{
		byte[] array = new byte[_data.Length];
		_data.CopyTo(array, 0);
		return new TagNodeByteArray(array);
	}

	public override string ToString()
	{
		return _data.ToString();
	}

	public static implicit operator TagNodeByteArray(byte[] b)
	{
		return new TagNodeByteArray(b);
	}

	public static implicit operator byte[](TagNodeByteArray b)
	{
		return b._data;
	}
}
