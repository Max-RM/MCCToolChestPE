namespace Substrate.Core;

public class IntArray : IDataArray, ICopyable<IntArray>
{
	protected readonly int[] dataArray;

	public int this[int i]
	{
		get
		{
			return dataArray[i];
		}
		set
		{
			dataArray[i] = value;
		}
	}

	public int Length => dataArray.Length;

	public int DataWidth => 32;

	public IntArray(int length)
	{
		dataArray = new int[length];
	}

	public IntArray(int[] data)
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

	public virtual IntArray Copy()
	{
		int[] array = new int[dataArray.Length];
		dataArray.CopyTo(array, 0);
		return new IntArray(array);
	}
}
