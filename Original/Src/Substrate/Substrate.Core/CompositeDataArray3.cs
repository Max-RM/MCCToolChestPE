using System;

namespace Substrate.Core;

public class CompositeDataArray3 : IDataArray3, IDataArray
{
	private IDataArray3[] _sections;

	public int this[int x, int y, int z]
	{
		get
		{
			int num = y / _sections[0].YDim;
			int y2 = y - num * _sections[0].YDim;
			return _sections[num][x, y2, z];
		}
		set
		{
			int num = y / _sections[0].YDim;
			int y2 = y - num * _sections[0].YDim;
			_sections[num][x, y2, z] = value;
		}
	}

	public int XDim => _sections[0].XDim;

	public int YDim => _sections[0].YDim * _sections.Length;

	public int ZDim => _sections[0].ZDim;

	public int this[int i]
	{
		get
		{
			int num = i / _sections[0].Length;
			int i2 = i - num * _sections[0].Length;
			return _sections[num][i2];
		}
		set
		{
			int num = i / _sections[0].Length;
			int i2 = i - num * _sections[0].Length;
			_sections[num][i2] = value;
		}
	}

	public int Length => _sections[0].Length * _sections.Length;

	public int DataWidth => _sections[0].DataWidth;

	public CompositeDataArray3(IDataArray3[] sections)
	{
		for (int i = 0; i < sections.Length; i++)
		{
			if (sections[i] == null)
			{
				throw new ArgumentException("sections argument cannot have null entries.");
			}
		}
		for (int j = 0; j < sections.Length; j++)
		{
			if (sections[j].Length != sections[0].Length || sections[j].XDim != sections[0].XDim || sections[j].YDim != sections[0].YDim || sections[j].ZDim != sections[0].ZDim)
			{
				throw new ArgumentException("All elements in sections argument must have same metrics.");
			}
		}
		_sections = sections;
	}

	public int GetIndex(int x, int y, int z)
	{
		int num = y / _sections[0].YDim;
		int y2 = y - num * _sections[0].YDim;
		return num * _sections[0].Length + _sections[num].GetIndex(x, y2, z);
	}

	public void GetMultiIndex(int index, out int x, out int y, out int z)
	{
		int num = index / _sections[0].Length;
		int index2 = index - num * _sections[0].Length;
		_sections[num].GetMultiIndex(index2, out x, out y, out z);
		y += num * _sections[0].YDim;
	}

	public void Clear()
	{
		for (int i = 0; i < _sections.Length; i++)
		{
			_sections[i].Clear();
		}
	}
}
