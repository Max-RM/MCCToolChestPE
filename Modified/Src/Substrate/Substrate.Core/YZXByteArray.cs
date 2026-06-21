using System;

namespace Substrate.Core;

public sealed class YZXByteArray : ByteArray, IDataArray3, IDataArray
{
	private readonly int _xdim;

	private readonly int _ydim;

	private readonly int _zdim;

	public int this[int x, int y, int z]
	{
		get
		{
			int num = _xdim * (y * _zdim + z) + x;
			return dataArray[num];
		}
		set
		{
			int num = _xdim * (y * _zdim + z) + x;
			dataArray[num] = (byte)value;
		}
	}

	public int XDim => _xdim;

	public int YDim => _ydim;

	public int ZDim => _zdim;

	public YZXByteArray(int xdim, int ydim, int zdim)
		: base(xdim * ydim * zdim)
	{
		_xdim = xdim;
		_ydim = ydim;
		_zdim = zdim;
	}

	public YZXByteArray(int xdim, int ydim, int zdim, byte[] data)
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
		return _xdim * (y * _zdim + z) + x;
	}

	public void GetMultiIndex(int index, out int x, out int y, out int z)
	{
		int num = _xdim * _zdim;
		y = index / num;
		int num2 = index - y * num;
		z = num2 / _xdim;
		x = num2 - z * _xdim;
	}

	public override ByteArray Copy()
	{
		byte[] array = new byte[dataArray.Length];
		dataArray.CopyTo(array, 0);
		return new YZXByteArray(_xdim, _ydim, _zdim, array);
	}
}
