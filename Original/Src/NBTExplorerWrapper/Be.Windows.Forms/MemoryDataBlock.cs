using System;

namespace Be.Windows.Forms;

internal sealed class MemoryDataBlock : DataBlock
{
	private byte[] _data;

	public override long Length => _data.LongLength;

	public byte[] Data => _data;

	public MemoryDataBlock(byte data)
	{
		_data = new byte[1] { data };
	}

	public MemoryDataBlock(byte[] data)
	{
		if (data == null)
		{
			throw new ArgumentNullException("data");
		}
		_data = (byte[])data.Clone();
	}

	public void AddByteToEnd(byte value)
	{
		byte[] array = new byte[_data.LongLength + 1];
		_data.CopyTo(array, 0);
		array[array.LongLength - 1] = value;
		_data = array;
	}

	public void AddByteToStart(byte value)
	{
		byte[] array = new byte[_data.LongLength + 1];
		array[0] = value;
		_data.CopyTo(array, 1);
		_data = array;
	}

	public void InsertBytes(long position, byte[] data)
	{
		byte[] array = new byte[_data.LongLength + data.LongLength];
		if (position > 0)
		{
			Array.Copy(_data, 0L, array, 0L, position);
		}
		Array.Copy(data, 0L, array, position, data.LongLength);
		if (position < _data.LongLength)
		{
			Array.Copy(_data, position, array, position + data.LongLength, _data.LongLength - position);
		}
		_data = array;
	}

	public override void RemoveBytes(long position, long count)
	{
		byte[] array = new byte[_data.LongLength - count];
		if (position > 0)
		{
			Array.Copy(_data, 0L, array, 0L, position);
		}
		if (position + count < _data.LongLength)
		{
			Array.Copy(_data, position + count, array, position, array.LongLength - position);
		}
		_data = array;
	}
}
