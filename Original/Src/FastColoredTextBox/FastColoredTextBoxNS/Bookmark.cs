using System.Drawing;
using System.Drawing.Drawing2D;

namespace FastColoredTextBoxNS;

public class Bookmark
{
	public FastColoredTextBox TB { get; private set; }

	public string Name { get; set; }

	public int LineIndex { get; set; }

	public Color Color { get; set; }

	public virtual void DoVisible()
	{
		TB.Selection.Start = new Place(0, LineIndex);
		TB.DoRangeVisible(TB.Selection, tryToCentre: true);
		TB.Invalidate();
	}

	public Bookmark(FastColoredTextBox tb, string name, int lineIndex)
	{
		TB = tb;
		Name = name;
		LineIndex = lineIndex;
		Color = tb.BookmarkColor;
	}

	public virtual void Paint(Graphics gr, Rectangle lineRect)
	{
		int num = TB.CharHeight - 1;
		using (LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, lineRect.Top, num, num), Color.White, Color, 45f))
		{
			gr.FillEllipse(brush, 0, lineRect.Top, num, num);
		}
		using Pen pen = new Pen(Color);
		gr.DrawEllipse(pen, 0, lineRect.Top, num, num);
	}
}
