using System;

namespace Substrate.Core;

public sealed class YZXNibbleArray : NibbleArray, IDataArray3, IDataArray
{
	private readonly int _xdim;

	private readonly int _ydim;

	private readonly int _zdim;

	public int this[int x, int y, int z]
	{
		get
		{
			int index = _xdim * (y * _zdim + z) + x;
			return base[index];
		}
		set
		{
			int index = _xdim * (y * _zdim + z) + x;
			base[index] = value;
		}
	}

	public int XDim => _xdim;

	public int YDim => _ydim;

	public int ZDim => _zdim;

	public YZXNibbleArray(int xdim, int ydim, int zdim)
		: base(xdim * ydim * zdim)
	{
		_xdim = xdim;
		_ydim = ydim;
		_zdim = zdim;
	}

	public YZXNibbleArray(int xdim, int ydim, int zdim, byte[] data)
		: base(data)
	{
		_xdim = xdim;
		_ydim = ydim;
		_zdim = zdim;
		if (xdim * ydim * zdim != data.Length * 2)
		{
			throw new ArgumentException("Product of dimensions must equal half length of raw data");
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

	public override NibbleArray Copy()
	{
		byte[] array = new byte[base.Data.Length];
		base.Data.CopyTo(array, 0);
		return new YZXNibbleArray(_xdim, _ydim, _zdim, array);
	}
}
