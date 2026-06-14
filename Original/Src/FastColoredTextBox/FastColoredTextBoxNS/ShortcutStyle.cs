using System.Drawing;

namespace FastColoredTextBoxNS;

public class ShortcutStyle : Style
{
	public Pen borderPen;

	public ShortcutStyle(Pen borderPen)
	{
		this.borderPen = borderPen;
	}

	public override void Draw(Graphics gr, Point position, Range range)
	{
		Point point = range.tb.PlaceToPoint(range.End);
		Rectangle rect = new Rectangle(point.X - 5, point.Y + range.tb.CharHeight - 2, 4, 3);
		gr.FillPath(Brushes.White, Style.GetRoundedRectangle(rect, 1));
		gr.DrawPath(borderPen, Style.GetRoundedRectangle(rect, 1));
		AddVisualMarker(range.tb, new StyleVisualMarker(new Rectangle(point.X - range.tb.CharWidth, point.Y, range.tb.CharWidth, range.tb.CharHeight), this));
	}
}
