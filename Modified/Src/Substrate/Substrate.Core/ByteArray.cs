namespace Substrate.Core;

public class ByteArray : IDataArray, ICopyable<ByteArray>
{
	protected readonly byte[] dataArray;

	public int this[int i]
	{
		get
		{
			return dataArray[i];
		}
		set
		{
			dataArray[i] = (byte)value;
		}
	}

	public int Length => dataArray.Length;

	public int DataWidth => 8;

	public byte[] Data => dataArray;

	public ByteArray(int length)
	{
		dataArray = new byte[length];
	}

	public ByteArray(byte[] data)
	{
		dataArray = data;
	}

	public void Clear()
	{
		for (int i = 0; i < dataArray.Length; i++)
		{
			dataArray[i] = 0;
		}
	}

	public virtual ByteArray Copy()
	{
		byte[] array = new byte[dataArray.Length];
		dataArray.CopyTo(array, 0);
		return new ByteArray(array);
	}
}
