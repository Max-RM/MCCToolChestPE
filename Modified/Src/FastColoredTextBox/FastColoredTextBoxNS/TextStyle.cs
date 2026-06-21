using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace FastColoredTextBoxNS;

public class TextStyle : Style
{
	public StringFormat stringFormat;

	public Brush ForeBrush { get; set; }

	public Brush BackgroundBrush { get; set; }

	public FontStyle FontStyle { get; set; }

	public TextStyle(Brush foreBrush, Brush backgroundBrush, FontStyle fontStyle)
	{
		ForeBrush = foreBrush;
		BackgroundBrush = backgroundBrush;
		FontStyle = fontStyle;
		stringFormat = new StringFormat(StringFormatFlags.MeasureTrailingSpaces);
	}

	public override void Draw(Graphics gr, Point position, Range range)
	{
		if (BackgroundBrush != null)
		{
			gr.FillRectangle(BackgroundBrush, position.X, position.Y, (range.End.iChar - range.Start.iChar) * range.tb.CharWidth, range.tb.CharHeight);
		}
		using Font font = new Font(range.tb.Font, FontStyle);
		Line line = range.tb[range.Start.iLine];
		float num = range.tb.CharWidth;
		float num2 = position.Y + range.tb.LineInterval / 2;
		float num3 = position.X - range.tb.CharWidth / 3;
		if (ForeBrush == null)
		{
			ForeBrush = new SolidBrush(range.tb.ForeColor);
		}
		if (range.tb.ImeAllowed)
		{
			for (int i = range.Start.iChar; i < range.End.iChar; i++)
			{
				SizeF charSize = FastColoredTextBox.GetCharSize(font, line[i].c);
				GraphicsState gstate = gr.Save();
				float num4 = ((charSize.Width > (float)(range.tb.CharWidth + 1)) ? ((float)range.tb.CharWidth / charSize.Width) : 1f);
				gr.TranslateTransform(num3, num2 + (1f - num4) * (float)range.tb.CharHeight / 2f);
				gr.ScaleTransform(num4, (float)Math.Sqrt(num4));
				gr.DrawString(line[i].c.ToString(), font, ForeBrush, 0f, 0f, stringFormat);
				gr.Restore(gstate);
				num3 += num;
			}
		}
		else
		{
			for (int j = range.Start.iChar; j < range.End.iChar; j++)
			{
				gr.DrawString(line[j].c.ToString(), font, ForeBrush, num3, num2, stringFormat);
				num3 += num;
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
		if (ForeBrush is SolidBrush)
		{
			string colorAsString2 = ExportToHTML.GetColorAsString((ForeBrush as SolidBrush).Color);
			if (colorAsString2 != "")
			{
				text = text + "color:" + colorAsString2 + ";";
			}
		}
		if ((FontStyle & FontStyle.Bold) != FontStyle.Regular)
		{
			text += "font-weight:bold;";
		}
		if ((FontStyle & FontStyle.Italic) != FontStyle.Regular)
		{
			text += "font-style:oblique;";
		}
		if ((FontStyle & FontStyle.Strikeout) != FontStyle.Regular)
		{
			text += "text-decoration:line-through;";
		}
		if ((FontStyle & FontStyle.Underline) != FontStyle.Regular)
		{
			text += "text-decoration:underline;";
		}
		return text;
	}

	public override RTFStyleDescriptor GetRTF()
	{
		RTFStyleDescriptor rTFStyleDescriptor = new RTFStyleDescriptor();
		if (BackgroundBrush is SolidBrush)
		{
			rTFStyleDescriptor.BackColor = (BackgroundBrush as SolidBrush).Color;
		}
		if (ForeBrush is SolidBrush)
		{
			rTFStyleDescriptor.ForeColor = (ForeBrush as SolidBrush).Color;
		}
		if ((FontStyle & FontStyle.Bold) != FontStyle.Regular)
		{
			rTFStyleDescriptor.AdditionalTags += "\\b";
		}
		if ((FontStyle & FontStyle.Italic) != FontStyle.Regular)
		{
			rTFStyleDescriptor.AdditionalTags += "\\i";
		}
		if ((FontStyle & FontStyle.Strikeout) != FontStyle.Regular)
		{
			rTFStyleDescriptor.AdditionalTags += "\\strike";
		}
		if ((FontStyle & FontStyle.Underline) != FontStyle.Regular)
		{
			rTFStyleDescriptor.AdditionalTags += "\\ul";
		}
		return rTFStyleDescriptor;
	}
}
