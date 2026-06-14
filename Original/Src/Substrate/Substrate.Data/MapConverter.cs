using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Substrate.Data;

public class MapConverter
{
	private static Color[] _defaultColorIndex;

	private Color[] _colorIndex;

	private ColorGroup[] _blockIndex;

	private int _groupSize = 4;

	private Vector3[] _labIndex;

	public int ColorGroupSize
	{
		get
		{
			return _groupSize;
		}
		set
		{
			if (value <= 0)
			{
				throw new ArgumentOutOfRangeException("The ColorGroupSize property must be a positive number.");
			}
			_groupSize = value;
		}
	}

	public Color[] ColorIndex => _colorIndex;

	public ColorGroup[] BlockIndex => _blockIndex;

	public MapConverter()
	{
		_colorIndex = new Color[256];
		_labIndex = new Vector3[256];
		_defaultColorIndex.CopyTo(_colorIndex, 0);
		RefreshColorCache();
		_blockIndex = new ColorGroup[4096];
		for (int i = 0; i < _blockIndex.Length; i++)
		{
			_blockIndex[i] = ColorGroup.Other;
		}
		_blockIndex[BlockInfo.Grass.ID] = ColorGroup.Grass;
		_blockIndex[BlockInfo.TallGrass.ID] = ColorGroup.Grass;
		_blockIndex[BlockInfo.Sand.ID] = ColorGroup.Sand;
		_blockIndex[BlockInfo.Gravel.ID] = ColorGroup.Sand;
		_blockIndex[BlockInfo.Sandstone.ID] = ColorGroup.Sand;
		_blockIndex[BlockInfo.Lava.ID] = ColorGroup.Lava;
		_blockIndex[BlockInfo.StationaryLava.ID] = ColorGroup.Lava;
		_blockIndex[BlockInfo.Ice.ID] = ColorGroup.Ice;
		_blockIndex[BlockInfo.Leaves.ID] = ColorGroup.Plant;
		_blockIndex[BlockInfo.YellowFlower.ID] = ColorGroup.Plant;
		_blockIndex[BlockInfo.RedRose.ID] = ColorGroup.Plant;
		_blockIndex[BlockInfo.Snow.ID] = ColorGroup.White;
		_blockIndex[BlockInfo.SnowBlock.ID] = ColorGroup.White;
		_blockIndex[BlockInfo.ClayBlock.ID] = ColorGroup.Clay;
		_blockIndex[BlockInfo.Dirt.ID] = ColorGroup.Dirt;
		_blockIndex[BlockInfo.Stone.ID] = ColorGroup.Stone;
		_blockIndex[BlockInfo.Cobblestone.ID] = ColorGroup.Stone;
		_blockIndex[BlockInfo.CoalOre.ID] = ColorGroup.Stone;
		_blockIndex[BlockInfo.IronOre.ID] = ColorGroup.Stone;
		_blockIndex[BlockInfo.GoldOre.ID] = ColorGroup.Stone;
		_blockIndex[BlockInfo.DiamondOre.ID] = ColorGroup.Stone;
		_blockIndex[BlockInfo.RedstoneOre.ID] = ColorGroup.Stone;
		_blockIndex[BlockInfo.LapisOre.ID] = ColorGroup.Stone;
		_blockIndex[BlockInfo.Water.ID] = ColorGroup.Water;
		_blockIndex[BlockInfo.StationaryWater.ID] = ColorGroup.Water;
		_blockIndex[BlockInfo.Wood.ID] = ColorGroup.Wood;
	}

	public int BlockToColorIndex(int blockId)
	{
		return BlockToColorIndex(blockId, 0);
	}

	public int BlockToColorIndex(int blockId, int level)
	{
		if (level < 0 || level >= _groupSize)
		{
			throw new ArgumentOutOfRangeException("level", level, "Argument 'level' must be in range [0, " + (_groupSize - 1) + "]");
		}
		if (blockId < 0 || blockId >= 4096)
		{
			throw new ArgumentOutOfRangeException("blockId");
		}
		return (int)_blockIndex[blockId] * _groupSize + level;
	}

	public Color BlockToColor(int blockId)
	{
		return BlockToColor(blockId, 0);
	}

	public Color BlockToColor(int blockId, int level)
	{
		int num = BlockToColorIndex(blockId, level);
		if (num < 0 || num >= 256)
		{
			throw new InvalidOperationException("The specified Block ID mapped to an invalid color index.");
		}
		return _colorIndex[num];
	}

	public ColorGroup ColorIndexToGroup(int colorIndex)
	{
		int result = colorIndex / _groupSize;
		try
		{
			return (ColorGroup)result;
		}
		catch
		{
			return ColorGroup.Other;
		}
	}

	public int GroupToColorIndex(ColorGroup group)
	{
		return GroupToColorIndex(group, 0);
	}

	public int GroupToColorIndex(ColorGroup group, int level)
	{
		if (level < 0 || level >= _groupSize)
		{
			throw new ArgumentOutOfRangeException("level", level, "Argument 'level' must be in range [0, " + (_groupSize - 1) + "]");
		}
		return (int)group * _groupSize + level;
	}

	public Color GroupToColor(ColorGroup group)
	{
		return GroupToColor(group, 0);
	}

	public Color GroupToColor(ColorGroup group, int level)
	{
		int num = GroupToColorIndex(group, level);
		if (num < 0 || num >= 256)
		{
			throw new InvalidOperationException("The specified group mapped to an invalid color index.");
		}
		return _colorIndex[num];
	}

	public void RefreshColorCache()
	{
		for (int i = 0; i < _colorIndex.Length; i++)
		{
			_labIndex[i] = RgbToLab(_colorIndex[i]);
		}
	}

	public int NearestColorIndex(Color color)
	{
		double num = double.MaxValue;
		int result = 0;
		Vector3 vector = RgbToLab(color);
		for (int i = 0; i < _colorIndex.Length; i++)
		{
			if (_colorIndex[i].A != 0)
			{
				double num2 = vector.X - _labIndex[i].X;
				double num3 = vector.Y - _labIndex[i].Y;
				double num4 = vector.Z - _labIndex[i].Z;
				double num5 = num2 * num2 + num3 * num3 + num4 * num4;
				if (num5 < num)
				{
					num = num5;
					result = i;
				}
			}
		}
		return result;
	}

	public Color NearestColor(Color color)
	{
		return _colorIndex[NearestColorIndex(color)];
	}

	public void BitmapToMap(Map map, Bitmap bmp)
	{
		if (map.Width != bmp.Width || map.Height != bmp.Height)
		{
			throw new InvalidOperationException("The source map and bitmap must have the same dimensions.");
		}
		for (int i = 0; i < map.Width; i++)
		{
			for (int j = 0; j < map.Height; j++)
			{
				Color pixel = bmp.GetPixel(i, j);
				byte value = 0;
				if (pixel.A > 0)
				{
					value = (byte)NearestColorIndex(pixel);
				}
				map[i, j] = value;
			}
		}
	}

	public Bitmap MapToBitmap(Map map)
	{
		Bitmap bitmap = new Bitmap(map.Width, map.Height, PixelFormat.Format32bppArgb);
		for (int i = 0; i < map.Width; i++)
		{
			for (int j = 0; j < map.Height; j++)
			{
				Color color = _colorIndex[map[i, j]];
				bitmap.SetPixel(i, j, color);
			}
		}
		return bitmap;
	}

	public Bitmap ConvertBitmap(Bitmap inBmp)
	{
		Bitmap bitmap = new Bitmap(inBmp.Width, inBmp.Height, PixelFormat.Format32bppArgb);
		for (int i = 0; i < inBmp.Width; i++)
		{
			for (int j = 0; j < inBmp.Height; j++)
			{
				Color pixel = inBmp.GetPixel(i, j);
				byte b = 0;
				if (pixel.A > 0)
				{
					b = (byte)NearestColorIndex(pixel);
				}
				pixel = _colorIndex[b];
				bitmap.SetPixel(i, j, pixel);
			}
		}
		return bitmap;
	}

	private Vector3 RgbToXyz(Color color)
	{
		double num = (double)(int)color.R / 255.0;
		double num2 = (double)(int)color.G / 255.0;
		double num3 = (double)(int)color.B / 255.0;
		num = ((num > 0.04045) ? Math.Pow((num + 0.055) / 1.055, 2.4) : (num / 12.92));
		num2 = ((num2 > 0.04045) ? Math.Pow((num2 + 0.055) / 1.055, 2.4) : (num2 / 12.92));
		num3 = ((num3 > 0.04045) ? Math.Pow((num3 + 0.055) / 1.055, 2.4) : (num3 / 12.92));
		num *= 100.0;
		num2 *= 100.0;
		num3 *= 100.0;
		Vector3 vector = new Vector3();
		vector.X = num * 0.4124 + num2 * 0.3576 + num3 * 0.1805;
		vector.Y = num * 0.2126 + num2 * 0.7152 + num3 * 0.0722;
		vector.Z = num * 0.0193 + num2 * 0.1192 + num3 * 0.9505;
		return vector;
	}

	private Vector3 XyzToLab(Vector3 xyz)
	{
		double num = xyz.X / 95.047;
		double num2 = xyz.Y / 100.0;
		double num3 = xyz.Z / 108.883;
		num = ((num > 0.008856) ? Math.Pow(num, 1.0 / 3.0) : (7.787 * num + 0.13793103448275862));
		num2 = ((num2 > 0.008856) ? Math.Pow(num2, 1.0 / 3.0) : (7.787 * num2 + 0.13793103448275862));
		num3 = ((num3 > 0.008856) ? Math.Pow(num3, 1.0 / 3.0) : (7.787 * num3 + 0.13793103448275862));
		Vector3 vector = new Vector3();
		vector.X = 116.0 * num2 - 16.0;
		vector.Y = 500.0 * (num - num2);
		vector.Z = 200.0 * (num2 - num3);
		return vector;
	}

	private Vector3 RgbToLab(Color rgb)
	{
		return XyzToLab(RgbToXyz(rgb));
	}

	static MapConverter()
	{
		_defaultColorIndex = new Color[144]
		{
			Color.FromArgb(0, 0, 0, 0),
			Color.FromArgb(0, 0, 0, 0),
			Color.FromArgb(0, 0, 0, 0),
			Color.FromArgb(0, 0, 0, 0),
			Color.FromArgb(90, 126, 40),
			Color.FromArgb(110, 154, 48),
			Color.FromArgb(127, 178, 56),
			Color.FromArgb(67, 94, 30),
			Color.FromArgb(174, 164, 115),
			Color.FromArgb(213, 201, 141),
			Color.FromArgb(247, 233, 163),
			Color.FromArgb(131, 123, 86),
			Color.FromArgb(140, 140, 140),
			Color.FromArgb(172, 172, 172),
			Color.FromArgb(199, 199, 199),
			Color.FromArgb(105, 105, 105),
			Color.FromArgb(180, 0, 0),
			Color.FromArgb(220, 0, 0),
			Color.FromArgb(255, 0, 0),
			Color.FromArgb(135, 0, 0),
			Color.FromArgb(113, 113, 180),
			Color.FromArgb(138, 138, 220),
			Color.FromArgb(160, 160, 255),
			Color.FromArgb(85, 85, 135),
			Color.FromArgb(118, 118, 118),
			Color.FromArgb(144, 144, 144),
			Color.FromArgb(167, 167, 167),
			Color.FromArgb(88, 88, 88),
			Color.FromArgb(0, 88, 0),
			Color.FromArgb(0, 107, 0),
			Color.FromArgb(0, 124, 0),
			Color.FromArgb(0, 66, 0),
			Color.FromArgb(180, 180, 180),
			Color.FromArgb(220, 220, 220),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(135, 135, 135),
			Color.FromArgb(116, 119, 130),
			Color.FromArgb(141, 145, 159),
			Color.FromArgb(164, 168, 184),
			Color.FromArgb(87, 89, 97),
			Color.FromArgb(107, 77, 54),
			Color.FromArgb(130, 94, 66),
			Color.FromArgb(151, 109, 77),
			Color.FromArgb(80, 58, 41),
			Color.FromArgb(79, 79, 79),
			Color.FromArgb(97, 97, 97),
			Color.FromArgb(112, 112, 112),
			Color.FromArgb(59, 59, 59),
			Color.FromArgb(45, 45, 180),
			Color.FromArgb(55, 55, 220),
			Color.FromArgb(64, 64, 255),
			Color.FromArgb(34, 34, 135),
			Color.FromArgb(101, 84, 51),
			Color.FromArgb(123, 103, 62),
			Color.FromArgb(143, 119, 72),
			Color.FromArgb(76, 63, 38),
			Color.FromArgb(180, 178, 173),
			Color.FromArgb(220, 217, 211),
			Color.FromArgb(255, 252, 245),
			Color.FromArgb(135, 133, 130),
			Color.FromArgb(152, 90, 36),
			Color.FromArgb(186, 110, 44),
			Color.FromArgb(216, 127, 51),
			Color.FromArgb(114, 67, 27),
			Color.FromArgb(126, 54, 152),
			Color.FromArgb(154, 66, 186),
			Color.FromArgb(178, 76, 216),
			Color.FromArgb(94, 40, 114),
			Color.FromArgb(72, 108, 152),
			Color.FromArgb(88, 132, 186),
			Color.FromArgb(102, 153, 216),
			Color.FromArgb(54, 81, 114),
			Color.FromArgb(162, 162, 36),
			Color.FromArgb(198, 198, 44),
			Color.FromArgb(229, 229, 51),
			Color.FromArgb(121, 121, 27),
			Color.FromArgb(90, 144, 18),
			Color.FromArgb(110, 176, 22),
			Color.FromArgb(127, 204, 25),
			Color.FromArgb(67, 108, 13),
			Color.FromArgb(171, 90, 116),
			Color.FromArgb(209, 110, 142),
			Color.FromArgb(242, 127, 165),
			Color.FromArgb(128, 67, 87),
			Color.FromArgb(54, 54, 54),
			Color.FromArgb(66, 66, 66),
			Color.FromArgb(76, 76, 76),
			Color.FromArgb(40, 40, 40),
			Color.FromArgb(108, 108, 108),
			Color.FromArgb(132, 132, 132),
			Color.FromArgb(153, 153, 153),
			Color.FromArgb(81, 81, 81),
			Color.FromArgb(54, 90, 108),
			Color.FromArgb(66, 110, 132),
			Color.FromArgb(76, 127, 153),
			Color.FromArgb(40, 67, 81),
			Color.FromArgb(90, 44, 126),
			Color.FromArgb(110, 54, 154),
			Color.FromArgb(127, 63, 178),
			Color.FromArgb(67, 33, 94),
			Color.FromArgb(36, 54, 126),
			Color.FromArgb(44, 66, 154),
			Color.FromArgb(51, 76, 178),
			Color.FromArgb(27, 40, 94),
			Color.FromArgb(72, 54, 36),
			Color.FromArgb(88, 66, 44),
			Color.FromArgb(102, 76, 51),
			Color.FromArgb(54, 40, 27),
			Color.FromArgb(72, 90, 36),
			Color.FromArgb(88, 110, 44),
			Color.FromArgb(102, 127, 51),
			Color.FromArgb(54, 67, 27),
			Color.FromArgb(108, 36, 36),
			Color.FromArgb(132, 44, 44),
			Color.FromArgb(153, 51, 51),
			Color.FromArgb(81, 27, 27),
			Color.FromArgb(18, 18, 18),
			Color.FromArgb(22, 22, 22),
			Color.FromArgb(25, 25, 25),
			Color.FromArgb(13, 13, 13),
			Color.FromArgb(176, 168, 54),
			Color.FromArgb(216, 205, 66),
			Color.FromArgb(250, 238, 77),
			Color.FromArgb(132, 126, 41),
			Color.FromArgb(65, 155, 150),
			Color.FromArgb(79, 189, 184),
			Color.FromArgb(92, 219, 213),
			Color.FromArgb(49, 116, 113),
			Color.FromArgb(52, 90, 180),
			Color.FromArgb(64, 110, 220),
			Color.FromArgb(74, 128, 255),
			Color.FromArgb(39, 68, 135),
			Color.FromArgb(0, 153, 41),
			Color.FromArgb(0, 187, 50),
			Color.FromArgb(0, 217, 58),
			Color.FromArgb(0, 115, 31),
			Color.FromArgb(91, 61, 35),
			Color.FromArgb(111, 74, 42),
			Color.FromArgb(129, 86, 49),
			Color.FromArgb(68, 46, 26),
			Color.FromArgb(79, 1, 0),
			Color.FromArgb(97, 2, 0),
			Color.FromArgb(112, 2, 0),
			Color.FromArgb(59, 1, 0)
		};
	}
}
