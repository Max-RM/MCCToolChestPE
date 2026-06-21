using System;

namespace Substrate.Core;

public sealed class XZYByteArray : ByteArray, IDataArray3, IDataArray
{
	private readonly int _xdim;

	private readonly int _ydim;

	private readonly int _zdim;

	public int this[int x, int y, int z]
	{
		get
		{
			int num = _ydim * (x * _zdim + z) + y;
			return dataArray[num];
		}
		set
		{
			int num = _ydim * (x * _zdim + z) + y;
			dataArray[num] = (byte)value;
		}
	}

	public int XDim => _xdim;

	public int YDim => _ydim;

	public int ZDim => _zdim;

	public XZYByteArray(int xdim, int ydim, int zdim)
		: base(xdim * ydim * zdim)
	{
		_xdim = xdim;
		_ydim = ydim;
		_zdim = zdim;
	}

	public XZYByteArray(int xdim, int ydim, int zdim, byte[] data)
		: base(data)
	{
		_xdim = xdim;
		_ydim = ydim;
		_zdim = zdim;
		if (xdim * ydim * zdim != data.Length)
		{
			throw new ArgumentException("Product of dimensions must equal length of data");
		}
	}

	public int GetIndex(int x, int y, int z)
	{
		return _ydim * (x * _zdim + z) + y;
	}

	public void GetMultiIndex(int index, out int x, out int y, out int z)
	{
		int num = _ydim * _zdim;
		x = index / num;
		int num2 = index - x * num;
		z = num2 / _ydim;
		y = num2 - z * _ydim;
	}

	public override ByteArray Copy()
	{
		byte[] array = new byte[dataArray.Length];
		dataArray.CopyTo(array, 0);
		return new XZYByteArray(_xdim, _ydim, _zdim, array);
	}
}
