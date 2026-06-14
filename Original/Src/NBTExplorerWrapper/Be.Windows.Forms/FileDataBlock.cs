using System;

namespace Be.Windows.Forms;

internal sealed class FileDataBlock : DataBlock
{
	private long _length;

	private long _fileOffset;

	public long FileOffset => _fileOffset;

	public override long Length => _length;

	public FileDataBlock(long fileOffset, long length)
	{
		_fileOffset = fileOffset;
		_length = length;
	}

	public void SetFileOffset(long value)
	{
		_fileOffset = value;
	}

	public void RemoveBytesFromEnd(long count)
	{
		if (count > _length)
		{
			throw new ArgumentOutOfRangeException("count");
		}
		_length -= count;
	}

	public void RemoveBytesFromStart(long count)
	{
		if (count > _length)
		{
			throw new ArgumentOutOfRangeException("count");
		}
		_fileOffset += count;
		_length -= count;
	}

	public override void RemoveBytes(long position, long count)
	{
		if (position > _length)
		{
			throw new ArgumentOutOfRangeException("position");
		}
		if (position + count > _length)
		{
			throw new ArgumentOutOfRangeException("count");
		}
		long fileOffset = _fileOffset;
		long num = _length - count - position;
		long fileOffset2 = _fileOffset + position + count;
		if (position > 0 && num > 0)
		{
			_fileOffset = fileOffset;
			_length = position;
			_map.AddAfter(this, new FileDataBlock(fileOffset2, num));
		}
		else if (position > 0)
		{
			_fileOffset = fileOffset;
			_length = position;
		}
		else
		{
			_fileOffset = fileOffset2;
			_length = num;
		}
	}
}
