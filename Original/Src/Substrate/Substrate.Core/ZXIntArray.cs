using System;

namespace Substrate.Core;

public sealed class ZXIntArray : IntArray, IDataArray2, IDataArray
{
	private readonly int _xdim;

	private readonly int _zdim;

	public int this[int x, int z]
	{
		get
		{
			int num = z * _xdim + x;
			return dataArray[num];
		}
		set
		{
			int num = z * _xdim + x;
			dataArray[num] = value;
		}
	}

	public int XDim => _xdim;

	public int ZDim => _zdim;

	public ZXIntArray(int xdim, int zdim)
		: base(xdim * zdim)
	{
		_xdim = xdim;
		_zdim = zdim;
	}

	public ZXIntArray(int xdim, int zdim, int[] data)
		: base(data)
	{
		_xdim = xdim;
		_zdim = zdim;
		if (xdim * zdim != data.Length)
		{
			throw new ArgumentException("Product of dimensions must equal length of data");
		}
	}

	public override IntArray Copy()
	{
		int[] array = new int[dataArray.Length];
		dataArray.CopyTo(array, 0);
		return new ZXIntArray(_xdim, _zdim, array);
	}
}
