using System.Collections;

namespace Be.Windows.Forms;

public class ByteCollection : CollectionBase
{
	public byte this[int index]
	{
		get
		{
			return (byte)base.List[index];
		}
		set
		{
			base.List[index] = value;
		}
	}

	public ByteCollection()
	{
	}

	public ByteCollection(byte[] bs)
	{
		AddRange(bs);
	}

	public void Add(byte b)
	{
		base.List.Add(b);
	}

	public void AddRange(byte[] bs)
	{
		base.InnerList.AddRange(bs);
	}

	public void Remove(byte b)
	{
		base.List.Remove(b);
	}

	public void RemoveRange(int index, int count)
	{
		base.InnerList.RemoveRange(index, count);
	}

	public void InsertRange(int index, byte[] bs)
	{
		base.InnerList.InsertRange(index, bs);
	}

	public byte[] GetBytes()
	{
		byte[] array = new byte[base.Count];
		base.InnerList.CopyTo(0, array, 0, array.Length);
		return array;
	}

	public void Insert(int index, byte b)
	{
		base.InnerList.Insert(index, b);
	}

	public int IndexOf(byte b)
	{
		return base.InnerList.IndexOf(b);
	}

	public bool Contains(byte b)
	{
		return base.InnerList.Contains(b);
	}

	public void CopyTo(byte[] bs, int index)
	{
		base.InnerList.CopyTo(bs, index);
	}

	public byte[] ToArray()
	{
		byte[] array = new byte[base.Count];
		CopyTo(array, 0);
		return array;
	}
}
