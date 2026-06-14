using System.Collections.Generic;
using System.Drawing;

namespace FastColoredTextBoxNS;

public class WavyLineStyle : Style
{
	private Pen Pen { get; set; }

	public WavyLineStyle(int alpha, Color color)
	{
		Pen = new Pen(Color.FromArgb(alpha, color));
	}

	public override void Draw(Graphics gr, Point pos, Range range)
	{
		Size sizeOfRange = Style.GetSizeOfRange(range);
		Point start = new Point(pos.X, pos.Y + sizeOfRange.Height - 1);
		Point end = new Point(pos.X + sizeOfRange.Width, pos.Y + sizeOfRange.Height - 1);
		DrawWavyLine(gr, start, end);
	}

	private void DrawWavyLine(Graphics graphics, Point start, Point end)
	{
		if (end.X - start.X < 2)
		{
			graphics.DrawLine(Pen, start, end);
			return;
		}
		int num = -1;
		List<Point> list = new List<Point>();
		for (int i = start.X; i <= end.X; i += 2)
		{
			list.Add(new Point(i, start.Y + num));
			num = -num;
		}
		graphics.DrawLines(Pen, list.ToArray());
	}

	public override void Dispose()
	{
		base.Dispose();
		if (Pen != null)
		{
			Pen.Dispose();
		}
	}
}
