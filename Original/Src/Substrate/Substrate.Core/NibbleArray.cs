using System;

namespace Substrate.Core;

public class NibbleArray : IDataArray, ICopyable<NibbleArray>
{
	private readonly byte[] _data;

	public int this[int index]
	{
		get
		{
			int num = index >> 1;
			if ((index & 1) == 0)
			{
				return (byte)(_data[num] & 0xF);
			}
			return (byte)((_data[num] >> 4) & 0xF);
		}
		set
		{
			int num = index >> 1;
			if ((index & 1) == 0)
			{
				_data[num] = (byte)((_data[num] & 0xF0) | (value & 0xF));
			}
			else
			{
				_data[num] = (byte)((_data[num] & 0xF) | ((value & 0xF) << 4));
			}
		}
	}

	public int Length => _data.Length << 1;

	public int DataWidth => 4;

	public byte[] Data => _data;

	public NibbleArray(int length)
	{
		_data = new byte[(int)Math.Ceiling((double)length / 2.0)];
	}

	public NibbleArray(byte[] data)
	{
		_data = data;
	}

	public void Clear()
	{
		for (int i = 0; i < _data.Length; i++)
		{
			_data[i] = 0;
		}
	}

	public virtual NibbleArray Copy()
	{
		byte[] array = new byte[_data.Length];
		_data.CopyTo(array, 0);
		return new NibbleArray(array);
	}
}
