using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace FastColoredTextBoxNS;

public class ExportToRTF
{
	private FastColoredTextBox tb;

	private Dictionary<Color, int> colorTable = new Dictionary<Color, int>();

	public bool IncludeLineNumbers { get; set; }

	public bool UseOriginalFont { get; set; }

	public ExportToRTF()
	{
		UseOriginalFont = true;
	}

	public string GetRtf(FastColoredTextBox tb)
	{
		this.tb = tb;
		Range range = new Range(tb);
		range.SelectAll();
		return GetRtf(range);
	}

	public string GetRtf(Range r)
	{
		tb = r.tb;
		Dictionary<StyleIndex, object> dictionary = new Dictionary<StyleIndex, object>();
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = new StringBuilder();
		StyleIndex styleIndex = StyleIndex.None;
		r.Normalize();
		int iLine = r.Start.iLine;
		dictionary[styleIndex] = null;
		colorTable.Clear();
		int colorTableNumber = GetColorTableNumber(r.tb.LineNumberColor);
		if (IncludeLineNumbers)
		{
			stringBuilder2.AppendFormat("{{\\cf{1} {0}}}\\tab", iLine + 1, colorTableNumber);
		}
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
					stringBuilder2.AppendLine("\\line");
					if (IncludeLineNumbers)
					{
						stringBuilder2.AppendFormat("{{\\cf{1} {0}}}\\tab", i + 2, colorTableNumber);
					}
				}
				iLine = item.iLine;
			}
			switch (obj.c)
			{
			case '\\':
				stringBuilder2.Append("\\\\");
				continue;
			case '{':
				stringBuilder2.Append("\\{");
				continue;
			case '}':
				stringBuilder2.Append("\\}");
				continue;
			}
			char c = obj.c;
			int num = c;
			if (num < 128)
			{
				stringBuilder2.Append(obj.c);
			}
			else
			{
				stringBuilder2.AppendFormat("{{\\u{0}}}", num);
			}
		}
		Flush(stringBuilder, stringBuilder2, styleIndex);
		SortedList<int, Color> sortedList = new SortedList<int, Color>();
		foreach (KeyValuePair<Color, int> item2 in colorTable)
		{
			sortedList.Add(item2.Value, item2.Key);
		}
		stringBuilder2.Length = 0;
		stringBuilder2.AppendFormat("{{\\colortbl;");
		foreach (KeyValuePair<int, Color> item3 in sortedList)
		{
			stringBuilder2.Append(GetColorAsString(item3.Value) + ";");
		}
		stringBuilder2.AppendLine("}");
		if (UseOriginalFont)
		{
			stringBuilder.Insert(0, string.Format("{{\\fonttbl{{\\f0\\fmodern {0};}}}}{{\\fs{1} ", tb.Font.Name, (int)(2f * tb.Font.SizeInPoints), tb.CharHeight));
			stringBuilder.AppendLine("}");
		}
		stringBuilder.Insert(0, stringBuilder2.ToString());
		stringBuilder.Insert(0, "{\\rtf1\\ud\\deff0");
		stringBuilder.AppendLine("}");
		return stringBuilder.ToString();
	}

	private RTFStyleDescriptor GetRtfDescriptor(StyleIndex styleIndex)
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
		RTFStyleDescriptor rTFStyleDescriptor = null;
		if (!flag)
		{
			return tb.DefaultStyle.GetRTF();
		}
		return textStyle.GetRTF();
	}

	public static string GetColorAsString(Color color)
	{
		if (color == Color.Transparent)
		{
			return "";
		}
		return $"\\red{color.R}\\green{color.G}\\blue{color.B}";
	}

	private void Flush(StringBuilder sb, StringBuilder tempSB, StyleIndex currentStyle)
	{
		if (tempSB.Length != 0)
		{
			RTFStyleDescriptor rtfDescriptor = GetRtfDescriptor(currentStyle);
			int colorTableNumber = GetColorTableNumber(rtfDescriptor.ForeColor);
			int colorTableNumber2 = GetColorTableNumber(rtfDescriptor.BackColor);
			StringBuilder stringBuilder = new StringBuilder();
			if (colorTableNumber >= 0)
			{
				stringBuilder.AppendFormat("\\cf{0}", colorTableNumber);
			}
			if (colorTableNumber2 >= 0)
			{
				stringBuilder.AppendFormat("\\highlight{0}", colorTableNumber2);
			}
			if (!string.IsNullOrEmpty(rtfDescriptor.AdditionalTags))
			{
				stringBuilder.Append(rtfDescriptor.AdditionalTags.Trim());
			}
			if (stringBuilder.Length > 0)
			{
				sb.AppendFormat("{{{0} {1}}}", stringBuilder, tempSB.ToString());
			}
			else
			{
				sb.Append(tempSB.ToString());
			}
			tempSB.Length = 0;
		}
	}

	private int GetColorTableNumber(Color color)
	{
		if (color.A == 0)
		{
			return -1;
		}
		if (!colorTable.ContainsKey(color))
		{
			colorTable[color] = colorTable.Count + 1;
		}
		return colorTable[color];
	}
}
