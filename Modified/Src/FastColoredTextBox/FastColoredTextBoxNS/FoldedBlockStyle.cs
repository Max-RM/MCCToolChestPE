using System.Drawing;

namespace FastColoredTextBoxNS;

public class FoldedBlockStyle : TextStyle
{
	public FoldedBlockStyle(Brush foreBrush, Brush backgroundBrush, FontStyle fontStyle)
		: base(foreBrush, backgroundBrush, fontStyle)
	{
	}

	public override void Draw(Graphics gr, Point position, Range range)
	{
		if (range.End.iChar > range.Start.iChar)
		{
			base.Draw(gr, position, range);
			int num = position.X;
			for (int i = range.Start.iChar; i < range.End.iChar && range.tb[range.Start.iLine][i].c == ' '; i++)
			{
				num += range.tb.CharWidth;
			}
			range.tb.AddVisualMarker(new FoldedAreaMarker(range.Start.iLine, new Rectangle(num, position.Y, position.X + (range.End.iChar - range.Start.iChar) * range.tb.CharWidth - num, range.tb.CharHeight)));
		}
		else
		{
			using (Font font = new Font(range.tb.Font, base.FontStyle))
			{
				gr.DrawString("...", font, base.ForeBrush, range.tb.LeftIndent, position.Y - 2);
			}
			range.tb.AddVisualMarker(new FoldedAreaMarker(range.Start.iLine, new Rectangle(range.tb.LeftIndent + 2, position.Y, 2 * range.tb.CharHeight, range.tb.CharHeight)));
		}
	}
}
