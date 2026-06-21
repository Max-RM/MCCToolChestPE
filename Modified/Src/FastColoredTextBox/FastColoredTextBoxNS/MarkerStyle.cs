using System.Drawing;

namespace FastColoredTextBoxNS;

public class MarkerStyle : Style
{
	public Brush BackgroundBrush { get; set; }

	public MarkerStyle(Brush backgroundBrush)
	{
		BackgroundBrush = backgroundBrush;
		IsExportable = true;
	}

	public override void Draw(Graphics gr, Point position, Range range)
	{
		if (BackgroundBrush != null)
		{
			Rectangle rect = new Rectangle(position.X, position.Y, (range.End.iChar - range.Start.iChar) * range.tb.CharWidth, range.tb.CharHeight);
			if (rect.Width != 0)
			{
				gr.FillRectangle(BackgroundBrush, rect);
			}
		}
	}

	public override string GetCSS()
	{
		string text = "";
		if (BackgroundBrush is SolidBrush)
		{
			string colorAsString = ExportToHTML.GetColorAsString((BackgroundBrush as SolidBrush).Color);
			if (colorAsString != "")
			{
				text = text + "background-color:" + colorAsString + ";";
			}
		}
		return text;
	}
}
