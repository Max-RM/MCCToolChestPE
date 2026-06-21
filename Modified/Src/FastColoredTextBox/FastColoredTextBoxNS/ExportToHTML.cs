using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace FastColoredTextBoxNS;

public class ExportToHTML
{
	public string LineNumbersCSS = "<style type=\"text/css\"> .lineNumber{font-family : monospace; font-size : small; font-style : normal; font-weight : normal; color : Teal; background-color : ThreedFace;} </style>";

	private FastColoredTextBox tb;

	public bool UseNbsp { get; set; }

	public bool UseForwardNbsp { get; set; }

	public bool UseOriginalFont { get; set; }

	public bool UseStyleTag { get; set; }

	public bool UseBr { get; set; }

	public bool IncludeLineNumbers { get; set; }

	public ExportToHTML()
	{
		UseNbsp = true;
		UseOriginalFont = true;
		UseStyleTag = true;
		UseBr = true;
	}

	public string GetHtml(FastColoredTextBox tb)
	{
		this.tb = tb;
		Range range = new Range(tb);
		range.SelectAll();
		return GetHtml(range);
	}

	public string GetHtml(Range r)
	{
		tb = r.tb;
		Dictionary<StyleIndex, object> dictionary = new Dictionary<StyleIndex, object>();
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = new StringBuilder();
		StyleIndex styleIndex = StyleIndex.None;
		r.Normalize();
		int iLine = r.Start.iLine;
		dictionary[styleIndex] = null;
		if (UseOriginalFont)
		{
			stringBuilder.AppendFormat("<font style=\"font-family: {0}, monospace; font-size: {1}pt; line-height: {2}px;\">", r.tb.Font.Name, r.tb.Font.SizeInPoints, r.tb.CharHeight);
		}
		if (IncludeLineNumbers)
		{
			stringBuilder2.AppendFormat("<span class=lineNumber>{0}</span>  ", iLine + 1);
		}
		bool flag = false;
		foreach (Place item in (IEnumerable<Place>)r)
		{
			Char obj = r.tb[item.iLine][item.iChar];
			if (obj.style != styleIndex)
			{
				Flush(stringBuilder, stringBuilder2, styleIndex);
				styleIndex = obj.style;
				dictionary[styleIndex] = null;
			}
			if (item.iLine != iLine)
			{
				for (int i = iLine; i < item.iLine; i++)
				{
					stringBuilder2.Append(UseBr ? "<br>" : "\r\n");
					if (IncludeLineNumbers)
					{
						stringBuilder2.AppendFormat("<span class=lineNumber>{0}</span>  ", i + 2);
					}
				}
				iLine = item.iLine;
				flag = false;
			}
			switch (obj.c)
			{
			case ' ':
				if ((flag || !UseForwardNbsp) && !UseNbsp)
				{
					break;
				}
				stringBuilder2.Append("&nbsp;");
				continue;
			case '<':
				stringBuilder2.Append("&lt;");
				continue;
			case '>':
				stringBuilder2.Append("&gt;");
				continue;
			case '&':
				stringBuilder2.Append("&amp;");
				continue;
			}
			flag = true;
			stringBuilder2.Append(obj.c);
		}
		Flush(stringBuilder, stringBuilder2, styleIndex);
		if (UseOriginalFont)
		{
			stringBuilder.Append("</font>");
		}
		if (UseStyleTag)
		{
			stringBuilder2.Length = 0;
			stringBuilder2.Append("<style type=\"text/css\">");
			foreach (StyleIndex key in dictionary.Keys)
			{
				stringBuilder2.AppendFormat(".fctb{0}{{ {1} }}\r\n", GetStyleName(key), GetCss(key));
			}
			stringBuilder2.Append("</style>");
			stringBuilder.Insert(0, stringBuilder2.ToString());
		}
		if (IncludeLineNumbers)
		{
			stringBuilder.Insert(0, LineNumbersCSS);
		}
		return stringBuilder.ToString();
	}

	private string GetCss(StyleIndex styleIndex)
	{
		List<Style> list = new List<Style>();
		TextStyle textStyle = null;
		int num = 1;
		bool flag = false;
		for (int i = 0; i < tb.Styles.Length; i++)
		{
			if (tb.Styles[i] != null && ((uint)styleIndex & (uint)num) != 0 && tb.Styles[i].IsExportable)
			{
				Style style = tb.Styles[i];
				list.Add(style);
				if (style is TextStyle && (!flag || tb.AllowSeveralTextStyleDrawing))
				{
					flag = true;
					textStyle = style as TextStyle;
				}
			}
			num <<= 1;
		}
		string text = "";
		text = (flag ? textStyle.GetCSS() : tb.DefaultStyle.GetCSS());
		foreach (Style item in list)
		{
			if (!(item is TextStyle))
			{
				text += item.GetCSS();
			}
		}
		return text;
	}

	public static string GetColorAsString(Color color)
	{
		if (color == Color.Transparent)
		{
			return "";
		}
		return $"#{color.R:x2}{color.G:x2}{color.B:x2}";
	}

	private string GetStyleName(StyleIndex styleIndex)
	{
		return styleIndex.ToString().Replace(" ", "").Replace(",", "");
	}

	private void Flush(StringBuilder sb, StringBuilder tempSB, StyleIndex currentStyle)
	{
		if (tempSB.Length == 0)
		{
			return;
		}
		if (UseStyleTag)
		{
			sb.AppendFormat("<font class=fctb{0}>{1}</font>", GetStyleName(currentStyle), tempSB.ToString());
		}
		else
		{
			string css = GetCss(currentStyle);
			if (css != "")
			{
				sb.AppendFormat("<font style=\"{0}\">", css);
			}
			sb.Append(tempSB.ToString());
			if (css != "")
			{
				sb.Append("</font>");
			}
		}
		tempSB.Length = 0;
	}
}
