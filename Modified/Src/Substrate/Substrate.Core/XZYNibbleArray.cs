using System;

namespace Substrate.Core;

public sealed class XZYNibbleArray : NibbleArray, IDataArray3, IDataArray
{
	private readonly int _xdim;

	private readonly int _ydim;

	private readonly int _zdim;

	public int this[int x, int y, int z]
	{
		get
		{
			int index = _ydim * (x * _zdim + z) + y;
			return base[index];
		}
		set
		{
			int index = _ydim * (x * _zdim + z) + y;
			base[index] = value;
		}
	}

	public int XDim => _xdim;

	public int YDim => _ydim;

	public int ZDim => _zdim;

	public XZYNibbleArray(int xdim, int ydim, int zdim)
		: base(xdim * ydim * zdim)
	{
		_xdim = xdim;
		_ydim = ydim;
		_zdim = zdim;
	}

	public XZYNibbleArray(int xdim, int ydim, int zdim, byte[] data)
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

	public override NibbleArray Copy()
	{
		byte[] array = new byte[base.Data.Length];
		base.Data.CopyTo(array, 0);
		return new XZYNibbleArray(_xdim, _ydim, _zdim, array);
	}
}
