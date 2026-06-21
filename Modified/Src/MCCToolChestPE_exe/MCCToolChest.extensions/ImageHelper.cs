using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;

namespace MCCToolChest.extensions;

public static class ImageHelper
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Image EnlargeImage(this Image original, int width, int height)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Bitmap bitmap = new Bitmap(width, height);
		using Graphics graphics = Graphics.FromImage(bitmap);
		graphics.InterpolationMode = InterpolationMode.Bicubic;
		graphics.DrawImage(original, new Rectangle(Point.Empty, bitmap.Size));
		return bitmap;
	}
}
