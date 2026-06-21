using System.Drawing;
using System.Runtime.CompilerServices;
using MCCToolChest.model;
using Substrate.Data;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.process.pixelArt;

public class convertPixelToBlock
{
	private MapConverter pBfSMP17s35;

	private Block[] OMfSMRUO3kJ;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Block ConvertPixel(Bitmap inBmp, int x, int y)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Color pixel = inBmp.GetPixel(x, y);
		return ConvertPixel(pixel);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Block ConvertPixel(Color c)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte b = 0;
		if (c.A > 0)
		{
			b = (byte)pBfSMP17s35.NearestColorIndex(c);
		}
		return OMfSMRUO3kJ[b];
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public convertPixelToBlock()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		pBfSMP17s35 = new MapConverter();
		OMfSMRUO3kJ = new Block[36]
		{
			new Block(0, 0),
			new Block(159, 5),
			new Block(12, 0),
			new Block(0, 0),
			new Block(213, 0),
			new Block(79, 0),
			new Block(42, 0),
			new Block(159, 5),
			new Block(159, 0),
			new Block(82, 0),
			new Block(3, 0),
			new Block(1, 0),
			new Block(212, 0),
			new Block(30, 0),
			new Block(1, 3),
			new Block(159, 1),
			new Block(159, 2),
			new Block(159, 3),
			new Block(159, 4),
			new Block(159, 5),
			new Block(159, 6),
			new Block(159, 7),
			new Block(159, 8),
			new Block(159, 9),
			new Block(159, 10),
			new Block(159, 11),
			new Block(159, 12),
			new Block(159, 13),
			new Block(159, 14),
			new Block(159, 15),
			new Block(41, 0),
			new Block(57, 0),
			new Block(22, 0),
			new Block(133, 0),
			new Block(49, 0),
			new Block(87, 0)
		};
	}
}
