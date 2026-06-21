using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace FastColoredTextBoxNS;

public class SelectionStyle : Style
{
	public Brush BackgroundBrush { get; set; }

	public Brush ForegroundBrush { get; private set; }

	public override bool IsExportable
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public SelectionStyle(Brush backgroundBrush, Brush foregroundBrush = null)
	{
		BackgroundBrush = backgroundBrush;
		ForegroundBrush = foregroundBrush;
	}

	public override void Draw(Graphics gr, Point position, Range range)
	{
		if (BackgroundBrush == null)
		{
			return;
		}
		gr.SmoothingMode = SmoothingMode.None;
		Rectangle rect = new Rectangle(position.X, position.Y, (range.End.iChar - range.Start.iChar) * range.tb.CharWidth, range.tb.CharHeight);
		if (rect.Width == 0)
		{
			return;
		}
		gr.FillRectangle(BackgroundBrush, rect);
		if (ForegroundBrush == null)
		{
			return;
		}
		gr.SmoothingMode = SmoothingMode.AntiAlias;
		Range range2 = new Range(range.tb, range.Start.iChar, range.Start.iLine, Math.Min(range.tb[range.End.iLine].Count, range.End.iChar), range.End.iLine);
		using TextStyle textStyle = new TextStyle(ForegroundBrush, null, FontStyle.Regular);
		textStyle.Draw(gr, new Point(position.X, position.Y - 1), range2);
	}
}
