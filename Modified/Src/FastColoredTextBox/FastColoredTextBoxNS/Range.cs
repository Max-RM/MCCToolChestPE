using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FastColoredTextBoxNS;

public class Range : IEnumerable<Place>, IEnumerable
{
	private Place start;

	private Place end;

	public readonly FastColoredTextBox tb;

	private int preferedPos = -1;

	private int updating = 0;

	private string cachedText;

	private List<Place> cachedCharIndexToPlace;

	private int cachedTextVersion = -1;

	private bool columnSelectionMode;

	public virtual bool IsEmpty
	{
		get
		{
			if (ColumnSelectionMode)
			{
				return Start.iChar == End.iChar;
			}
			return Start == End;
		}
	}

	public bool ColumnSelectionMode
	{
		get
		{
			return columnSelectionMode;
		}
		set
		{
			columnSelectionMode = value;
		}
	}

	public Place Start
	{
		get
		{
			return start;
		}
		set
		{
			end = (start = value);
			preferedPos = -1;
			OnSelectionChanged();
		}
	}

	public Place End
	{
		get
		{
			return end;
		}
		set
		{
			end = value;
			OnSelectionChanged();
		}
	}

	public virtual string Text
	{
		get
		{
			if (ColumnSelectionMode)
			{
				return Text_ColumnSelectionMode;
			}
			int num = Math.Min(end.iLine, start.iLine);
			int num2 = Math.Max(end.iLine, start.iLine);
			int fromX = FromX;
			int toX = ToX;
			if (num < 0)
			{
				return null;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = num; i <= num2; i++)
			{
				int num3 = ((i == num) ? fromX : 0);
				int num4 = ((i == num2) ? Math.Min(tb[i].Count - 1, toX - 1) : (tb[i].Count - 1));
				for (int j = num3; j <= num4; j++)
				{
					stringBuilder.Append(tb[i][j].c);
				}
				if (i != num2 && num != num2)
				{
					stringBuilder.AppendLine();
				}
			}
			return stringBuilder.ToString();
		}
	}

	public int Length
	{
		get
		{
			if (ColumnSelectionMode)
			{
				return Length_ColumnSelectionMode(withNewLines: false);
			}
			int num = Math.Min(end.iLine, start.iLine);
			int num2 = Math.Max(end.iLine, start.iLine);
			int num3 = 0;
			if (num < 0)
			{
				return 0;
			}
			for (int i = num; i <= num2; i++)
			{
				int num4 = ((i == num) ? FromX : 0);
				int num5 = ((i == num2) ? Math.Min(tb[i].Count - 1, ToX - 1) : (tb[i].Count - 1));
				num3 += num5 - num4 + 1;
				if (i != num2 && num != num2)
				{
					num3 += Environment.NewLine.Length;
				}
			}
			return num3;
		}
	}

	public int TextLength
	{
		get
		{
			if (ColumnSelectionMode)
			{
				return Length_ColumnSelectionMode(withNewLines: true);
			}
			return Length;
		}
	}

	public char CharAfterStart
	{
		get
		{
			if (Start.iChar >= tb[Start.iLine].Count)
			{
				return '\n';
			}
			return tb[Start.iLine][Start.iChar].c;
		}
	}

	public char CharBeforeStart
	{
		get
		{
			if (Start.iChar > tb[Start.iLine].Count)
			{
				return '\n';
			}
			if (Start.iChar <= 0)
			{
				return '\n';
			}
			return tb[Start.iLine][Start.iChar - 1].c;
		}
	}

	internal int FromX
	{
		get
		{
			if (end.iLine < start.iLine)
			{
				return end.iChar;
			}
			if (end.iLine > start.iLine)
			{
				return start.iChar;
			}
			return Math.Min(end.iChar, start.iChar);
		}
	}

	internal int ToX
	{
		get
		{
			if (end.iLine < start.iLine)
			{
				return start.iChar;
			}
			if (end.iLine > start.iLine)
			{
				return end.iChar;
			}
			return Math.Max(end.iChar, start.iChar);
		}
	}

	public int FromLine => Math.Min(Start.iLine, End.iLine);

	public int ToLine => Math.Max(Start.iLine, End.iLine);

	public IEnumerable<Char> Chars
	{
		get
		{
			if (ColumnSelectionMode)
			{
				foreach (Place p in GetEnumerator_ColumnSelectionMode())
				{
					yield return tb[p];
				}
				yield break;
			}
			int fromLine = Math.Min(end.iLine, start.iLine);
			int toLine = Math.Max(end.iLine, start.iLine);
			int fromChar = FromX;
			int toChar = ToX;
			if (fromLine < 0)
			{
				yield break;
			}
			for (int y = fromLine; y <= toLine; y++)
			{
				int fromX = ((y == fromLine) ? fromChar : 0);
				int toX = ((y == toLine) ? Math.Min(toChar - 1, tb[y].Count - 1) : (tb[y].Count - 1));
				Line line = tb[y];
				for (int x = fromX; x <= toX; x++)
				{
					yield return line[x];
				}
			}
		}
	}

	public RangeRect Bounds
	{
		get
		{
			int iStartChar = Math.Min(Start.iChar, End.iChar);
			int iStartLine = Math.Min(Start.iLine, End.iLine);
			int iEndChar = Math.Max(Start.iChar, End.iChar);
			int iEndLine = Math.Max(Start.iLine, End.iLine);
			return new RangeRect(iStartLine, iStartChar, iEndLine, iEndChar);
		}
	}

	public bool ReadOnly
	{
		get
		{
			if (tb.ReadOnly)
			{
				return true;
			}
			ReadOnlyStyle readOnlyStyle = null;
			Style[] styles = tb.Styles;
			foreach (Style style in styles)
			{
				if (style is ReadOnlyStyle)
				{
					readOnlyStyle = (ReadOnlyStyle)style;
					break;
				}
			}
			if (readOnlyStyle != null)
			{
				StyleIndex styleIndex = ToStyleIndex(tb.GetStyleIndex(readOnlyStyle));
				if (IsEmpty)
				{
					Line line = tb[start.iLine];
					if (columnSelectionMode)
					{
						foreach (Range subRange in GetSubRanges(includeEmpty: false))
						{
							line = tb[subRange.start.iLine];
							if (subRange.start.iChar < line.Count && subRange.start.iChar > 0)
							{
								Char obj = line[subRange.start.iChar - 1];
								Char obj2 = line[subRange.start.iChar];
								if ((obj.style & styleIndex) != StyleIndex.None && (obj2.style & styleIndex) != StyleIndex.None)
								{
									return true;
								}
							}
						}
					}
					else if (start.iChar < line.Count && start.iChar > 0)
					{
						Char obj3 = line[start.iChar - 1];
						Char obj4 = line[start.iChar];
						if ((obj3.style & styleIndex) != StyleIndex.None && (obj4.style & styleIndex) != StyleIndex.None)
						{
							return true;
						}
					}
				}
				else
				{
					foreach (Char @char in Chars)
					{
						if ((@char.style & styleIndex) != StyleIndex.None)
						{
							return true;
						}
					}
				}
			}
			return false;
		}
		set
		{
			ReadOnlyStyle readOnlyStyle = null;
			Style[] styles = tb.Styles;
			foreach (Style style in styles)
			{
				if (style is ReadOnlyStyle)
				{
					readOnlyStyle = (ReadOnlyStyle)style;
					break;
				}
			}
			if (readOnlyStyle == null)
			{
				readOnlyStyle = new ReadOnlyStyle();
			}
			if (value)
			{
				SetStyle(readOnlyStyle);
				return;
			}
			ClearStyle(readOnlyStyle);
		}
	}

	private string Text_ColumnSelectionMode
	{
		get
		{
			StringBuilder stringBuilder = new StringBuilder();
			RangeRect bounds = Bounds;
			if (bounds.iStartLine < 0)
			{
				return "";
			}
			for (int i = bounds.iStartLine; i <= bounds.iEndLine; i++)
			{
				for (int j = bounds.iStartChar; j < bounds.iEndChar; j++)
				{
					if (j < tb[i].Count)
					{
						stringBuilder.Append(tb[i][j].c);
					}
				}
				if (bounds.iEndLine != bounds.iStartLine && i != bounds.iEndLine)
				{
					stringBuilder.AppendLine();
				}
			}
			return stringBuilder.ToString();
		}
	}

	public Range(FastColoredTextBox tb)
	{
		this.tb = tb;
	}

	public Range(FastColoredTextBox tb, int iStartChar, int iStartLine, int iEndChar, int iEndLine)
		: this(tb)
	{
		start = new Place(iStartChar, iStartLine);
		end = new Place(iEndChar, iEndLine);
	}

	public Range(FastColoredTextBox tb, Place start, Place end)
		: this(tb)
	{
		this.start = start;
		this.end = end;
	}

	public Range(FastColoredTextBox tb, int iLine)
		: this(tb)
	{
		start = new Place(0, iLine);
		end = new Place(tb[iLine].Count, iLine);
	}

	public bool Contains(Place place)
	{
		if (place.iLine < Math.Min(start.iLine, end.iLine))
		{
			return false;
		}
		if (place.iLine > Math.Max(start.iLine, end.iLine))
		{
			return false;
		}
		Place place2 = start;
		Place place3 = end;
		if (place2.iLine > place3.iLine || (place2.iLine == place3.iLine && place2.iChar > place3.iChar))
		{
			Place place4 = place2;
			place2 = place3;
			place3 = place4;
		}
		if (columnSelectionMode)
		{
			if (place.iChar < place2.iChar || place.iChar > place3.iChar)
			{
				return false;
			}
		}
		else
		{
			if (place.iLine == place2.iLine && place.iChar < place2.iChar)
			{
				return false;
			}
			if (place.iLine == place3.iLine && place.iChar > place3.iChar)
			{
				return false;
			}
		}
		return true;
	}

	public virtual Range GetIntersectionWith(Range range)
	{
		if (ColumnSelectionMode)
		{
			return GetIntersectionWith_ColumnSelectionMode(range);
		}
		Range range2 = Clone();
		Range range3 = range.Clone();
		range2.Normalize();
		range3.Normalize();
		Place place = ((range2.Start > range3.Start) ? range2.Start : range3.Start);
		Place place2 = ((range2.End < range3.End) ? range2.End : range3.End);
		if (place2 < place)
		{
			return new Range(tb, start, start);
		}
		return tb.GetRange(place, place2);
	}

	public Range GetUnionWith(Range range)
	{
		Range range2 = Clone();
		Range range3 = range.Clone();
		range2.Normalize();
		range3.Normalize();
		Place fromPlace = ((range2.Start < range3.Start) ? range2.Start : range3.Start);
		Place toPlace = ((range2.End > range3.End) ? range2.End : range3.End);
		return tb.GetRange(fromPlace, toPlace);
	}

	public void SelectAll()
	{
		ColumnSelectionMode = false;
		Start = new Place(0, 0);
		if (tb.LinesCount == 0)
		{
			Start = new Place(0, 0);
		}
		else
		{
			end = new Place(0, 0);
			start = new Place(tb[tb.LinesCount - 1].Count, tb.LinesCount - 1);
		}
		if (this == tb.Selection)
		{
			tb.Invalidate();
		}
	}

	internal void GetText(out string text, out List<Place> charIndexToPlace)
	{
		if (tb.TextVersion == cachedTextVersion)
		{
			text = cachedText;
			charIndexToPlace = cachedCharIndexToPlace;
			return;
		}
		int num = Math.Min(end.iLine, start.iLine);
		int num2 = Math.Max(end.iLine, start.iLine);
		int fromX = FromX;
		int toX = ToX;
		StringBuilder stringBuilder = new StringBuilder((num2 - num) * 50);
		charIndexToPlace = new List<Place>(stringBuilder.Capacity);
		if (num >= 0)
		{
			for (int i = num; i <= num2; i++)
			{
				int num3 = ((i == num) ? fromX : 0);
				int num4 = ((i == num2) ? Math.Min(toX - 1, tb[i].Count - 1) : (tb[i].Count - 1));
				for (int j = num3; j <= num4; j++)
				{
					stringBuilder.Append(tb[i][j].c);
					charIndexToPlace.Add(new Place(j, i));
				}
				if (i != num2 && num != num2)
				{
					string newLine = Environment.NewLine;
					foreach (char value in newLine)
					{
						stringBuilder.Append(value);
						charIndexToPlace.Add(new Place(tb[i].Count, i));
					}
				}
			}
		}
		text = stringBuilder.ToString();
		charIndexToPlace.Add((End > Start) ? End : Start);
		cachedText = text;
		cachedCharIndexToPlace = charIndexToPlace;
		cachedTextVersion = tb.TextVersion;
	}

	public string GetCharsBeforeStart(int charsCount)
	{
		int num = tb.PlaceToPosition(Start) - charsCount;
		if (num < 0)
		{
			num = 0;
		}
		return new Range(tb, tb.PositionToPlace(num), Start).Text;
	}

	public string GetCharsAfterStart(int charsCount)
	{
		return GetCharsBeforeStart(-charsCount);
	}

	public Range Clone()
	{
		return (Range)MemberwiseClone();
	}

	public bool GoRight()
	{
		Place place = start;
		GoRight(shift: false);
		return place != start;
	}

	public virtual bool GoRightThroughFolded()
	{
		if (ColumnSelectionMode)
		{
			return GoRightThroughFolded_ColumnSelectionMode();
		}
		if (start.iLine >= tb.LinesCount - 1 && start.iChar >= tb[tb.LinesCount - 1].Count)
		{
			return false;
		}
		if (start.iChar < tb[start.iLine].Count)
		{
			start.Offset(1, 0);
		}
		else
		{
			start = new Place(0, start.iLine + 1);
		}
		preferedPos = -1;
		end = start;
		OnSelectionChanged();
		return true;
	}

	public bool GoLeft()
	{
		ColumnSelectionMode = false;
		Place place = start;
		GoLeft(shift: false);
		return place != start;
	}

	public bool GoLeftThroughFolded()
	{
		ColumnSelectionMode = false;
		if (start.iChar == 0 && start.iLine == 0)
		{
			return false;
		}
		if (start.iChar > 0)
		{
			start.Offset(-1, 0);
		}
		else
		{
			start = new Place(tb[start.iLine - 1].Count, start.iLine - 1);
		}
		preferedPos = -1;
		end = start;
		OnSelectionChanged();
		return true;
	}

	public void GoLeft(bool shift)
	{
		ColumnSelectionMode = false;
		if (!shift && start > end)
		{
			Start = End;
			return;
		}
		if (start.iChar != 0 || start.iLine != 0)
		{
			if (start.iChar > 0 && tb.LineInfos[start.iLine].VisibleState == VisibleState.Visible)
			{
				start.Offset(-1, 0);
			}
			else
			{
				int num = tb.FindPrevVisibleLine(start.iLine);
				if (num == start.iLine)
				{
					return;
				}
				start = new Place(tb[num].Count, num);
			}
		}
		if (!shift)
		{
			end = start;
		}
		OnSelectionChanged();
		preferedPos = -1;
	}

	public void GoRight(bool shift)
	{
		ColumnSelectionMode = false;
		if (!shift && start < end)
		{
			Start = End;
			return;
		}
		if (start.iLine < tb.LinesCount - 1 || start.iChar < tb[tb.LinesCount - 1].Count)
		{
			if (start.iChar < tb[start.iLine].Count && tb.LineInfos[start.iLine].VisibleState == VisibleState.Visible)
			{
				start.Offset(1, 0);
			}
			else
			{
				int num = tb.FindNextVisibleLine(start.iLine);
				if (num == start.iLine)
				{
					return;
				}
				start = new Place(0, num);
			}
		}
		if (!shift)
		{
			end = start;
		}
		OnSelectionChanged();
		preferedPos = -1;
	}

	internal void GoUp(bool shift)
	{
		ColumnSelectionMode = false;
		if (!shift && start.iLine > end.iLine)
		{
			Start = End;
			return;
		}
		if (preferedPos < 0)
		{
			preferedPos = start.iChar - tb.LineInfos[start.iLine].GetWordWrapStringStartPosition(tb.LineInfos[start.iLine].GetWordWrapStringIndex(start.iChar));
		}
		int num = tb.LineInfos[start.iLine].GetWordWrapStringIndex(start.iChar);
		if (num == 0)
		{
			if (start.iLine <= 0)
			{
				return;
			}
			int num2 = tb.FindPrevVisibleLine(start.iLine);
			if (num2 == start.iLine)
			{
				return;
			}
			start.iLine = num2;
			num = tb.LineInfos[start.iLine].WordWrapStringsCount;
		}
		if (num > 0)
		{
			int wordWrapStringFinishPosition = tb.LineInfos[start.iLine].GetWordWrapStringFinishPosition(num - 1, tb[start.iLine]);
			start.iChar = tb.LineInfos[start.iLine].GetWordWrapStringStartPosition(num - 1) + preferedPos;
			if (start.iChar > wordWrapStringFinishPosition + 1)
			{
				start.iChar = wordWrapStringFinishPosition + 1;
			}
		}
		if (!shift)
		{
			end = start;
		}
		OnSelectionChanged();
	}

	internal void GoPageUp(bool shift)
	{
		ColumnSelectionMode = false;
		if (preferedPos < 0)
		{
			preferedPos = start.iChar - tb.LineInfos[start.iLine].GetWordWrapStringStartPosition(tb.LineInfos[start.iLine].GetWordWrapStringIndex(start.iChar));
		}
		int num = tb.ClientRectangle.Height / tb.CharHeight - 1;
		for (int i = 0; i < num; i++)
		{
			int num2 = tb.LineInfos[start.iLine].GetWordWrapStringIndex(start.iChar);
			if (num2 == 0)
			{
				if (start.iLine <= 0)
				{
					break;
				}
				int num3 = tb.FindPrevVisibleLine(start.iLine);
				if (num3 == start.iLine)
				{
					break;
				}
				start.iLine = num3;
				num2 = tb.LineInfos[start.iLine].WordWrapStringsCount;
			}
			if (num2 > 0)
			{
				int wordWrapStringFinishPosition = tb.LineInfos[start.iLine].GetWordWrapStringFinishPosition(num2 - 1, tb[start.iLine]);
				start.iChar = tb.LineInfos[start.iLine].GetWordWrapStringStartPosition(num2 - 1) + preferedPos;
				if (start.iChar > wordWrapStringFinishPosition + 1)
				{
					start.iChar = wordWrapStringFinishPosition + 1;
				}
			}
		}
		if (!shift)
		{
			end = start;
		}
		OnSelectionChanged();
	}

	internal void GoDown(bool shift)
	{
		ColumnSelectionMode = false;
		if (!shift && start.iLine < end.iLine)
		{
			Start = End;
			return;
		}
		if (preferedPos < 0)
		{
			preferedPos = start.iChar - tb.LineInfos[start.iLine].GetWordWrapStringStartPosition(tb.LineInfos[start.iLine].GetWordWrapStringIndex(start.iChar));
		}
		int num = tb.LineInfos[start.iLine].GetWordWrapStringIndex(start.iChar);
		if (num >= tb.LineInfos[start.iLine].WordWrapStringsCount - 1)
		{
			if (start.iLine >= tb.LinesCount - 1)
			{
				return;
			}
			int num2 = tb.FindNextVisibleLine(start.iLine);
			if (num2 == start.iLine)
			{
				return;
			}
			start.iLine = num2;
			num = -1;
		}
		if (num < tb.LineInfos[start.iLine].WordWrapStringsCount - 1)
		{
			int wordWrapStringFinishPosition = tb.LineInfos[start.iLine].GetWordWrapStringFinishPosition(num + 1, tb[start.iLine]);
			start.iChar = tb.LineInfos[start.iLine].GetWordWrapStringStartPosition(num + 1) + preferedPos;
			if (start.iChar > wordWrapStringFinishPosition + 1)
			{
				start.iChar = wordWrapStringFinishPosition + 1;
			}
		}
		if (!shift)
		{
			end = start;
		}
		OnSelectionChanged();
	}

	internal void GoPageDown(bool shift)
	{
		ColumnSelectionMode = false;
		if (preferedPos < 0)
		{
			preferedPos = start.iChar - tb.LineInfos[start.iLine].GetWordWrapStringStartPosition(tb.LineInfos[start.iLine].GetWordWrapStringIndex(start.iChar));
		}
		int num = tb.ClientRectangle.Height / tb.CharHeight - 1;
		for (int i = 0; i < num; i++)
		{
			int num2 = tb.LineInfos[start.iLine].GetWordWrapStringIndex(start.iChar);
			if (num2 >= tb.LineInfos[start.iLine].WordWrapStringsCount - 1)
			{
				if (start.iLine >= tb.LinesCount - 1)
				{
					break;
				}
				int num3 = tb.FindNextVisibleLine(start.iLine);
				if (num3 == start.iLine)
				{
					break;
				}
				start.iLine = num3;
				num2 = -1;
			}
			if (num2 < tb.LineInfos[start.iLine].WordWrapStringsCount - 1)
			{
				int wordWrapStringFinishPosition = tb.LineInfos[start.iLine].GetWordWrapStringFinishPosition(num2 + 1, tb[start.iLine]);
				start.iChar = tb.LineInfos[start.iLine].GetWordWrapStringStartPosition(num2 + 1) + preferedPos;
				if (start.iChar > wordWrapStringFinishPosition + 1)
				{
					start.iChar = wordWrapStringFinishPosition + 1;
				}
			}
		}
		if (!shift)
		{
			end = start;
		}
		OnSelectionChanged();
	}

	internal void GoHome(bool shift)
	{
		ColumnSelectionMode = false;
		if (start.iLine >= 0 && tb.LineInfos[start.iLine].VisibleState == VisibleState.Visible)
		{
			start = new Place(0, start.iLine);
			if (!shift)
			{
				end = start;
			}
			OnSelectionChanged();
			preferedPos = -1;
		}
	}

	internal void GoEnd(bool shift)
	{
		ColumnSelectionMode = false;
		if (start.iLine >= 0 && tb.LineInfos[start.iLine].VisibleState == VisibleState.Visible)
		{
			start = new Place(tb[start.iLine].Count, start.iLine);
			if (!shift)
			{
				end = start;
			}
			OnSelectionChanged();
			preferedPos = -1;
		}
	}

	public void SetStyle(Style style)
	{
		int orSetStyleLayerIndex = tb.GetOrSetStyleLayerIndex(style);
		SetStyle(ToStyleIndex(orSetStyleLayerIndex));
		tb.Invalidate();
	}

	public void SetStyle(Style style, string regexPattern)
	{
		StyleIndex styleLayer = ToStyleIndex(tb.GetOrSetStyleLayerIndex(style));
		SetStyle(styleLayer, regexPattern, RegexOptions.None);
	}

	public void SetStyle(Style style, Regex regex)
	{
		StyleIndex styleLayer = ToStyleIndex(tb.GetOrSetStyleLayerIndex(style));
		SetStyle(styleLayer, regex);
	}

	public void SetStyle(Style style, string regexPattern, RegexOptions options)
	{
		StyleIndex styleLayer = ToStyleIndex(tb.GetOrSetStyleLayerIndex(style));
		SetStyle(styleLayer, regexPattern, options);
	}

	public void SetStyle(StyleIndex styleLayer, string regexPattern, RegexOptions options)
	{
		if (Math.Abs(Start.iLine - End.iLine) > 1000)
		{
			options |= SyntaxHighlighter.RegexCompiledOption;
		}
		foreach (Range range in GetRanges(regexPattern, options))
		{
			range.SetStyle(styleLayer);
		}
		tb.Invalidate();
	}

	public void SetStyle(StyleIndex styleLayer, Regex regex)
	{
		foreach (Range range in GetRanges(regex))
		{
			range.SetStyle(styleLayer);
		}
		tb.Invalidate();
	}

	public void SetStyle(StyleIndex styleIndex)
	{
		int num = Math.Min(End.iLine, Start.iLine);
		int num2 = Math.Max(End.iLine, Start.iLine);
		int fromX = FromX;
		int toX = ToX;
		if (num < 0)
		{
			return;
		}
		for (int i = num; i <= num2; i++)
		{
			int num3 = ((i == num) ? fromX : 0);
			int num4 = ((i == num2) ? Math.Min(toX - 1, tb[i].Count - 1) : (tb[i].Count - 1));
			for (int j = num3; j <= num4; j++)
			{
				Char value = tb[i][j];
				value.style |= styleIndex;
				tb[i][j] = value;
			}
		}
	}

	public void SetFoldingMarkers(string startFoldingPattern, string finishFoldingPattern)
	{
		SetFoldingMarkers(startFoldingPattern, finishFoldingPattern, SyntaxHighlighter.RegexCompiledOption);
	}

	public void SetFoldingMarkers(string startFoldingPattern, string finishFoldingPattern, RegexOptions options)
	{
		if (startFoldingPattern == finishFoldingPattern)
		{
			SetFoldingMarkers(startFoldingPattern, options);
			return;
		}
		foreach (Range range in GetRanges(startFoldingPattern, options))
		{
			tb[range.Start.iLine].FoldingStartMarker = startFoldingPattern;
		}
		foreach (Range range2 in GetRanges(finishFoldingPattern, options))
		{
			tb[range2.Start.iLine].FoldingEndMarker = startFoldingPattern;
		}
		tb.Invalidate();
	}

	public void SetFoldingMarkers(string foldingPattern, RegexOptions options)
	{
		foreach (Range range in GetRanges(foldingPattern, options))
		{
			if (range.Start.iLine > 0)
			{
				tb[range.Start.iLine - 1].FoldingEndMarker = foldingPattern;
			}
			tb[range.Start.iLine].FoldingStartMarker = foldingPattern;
		}
		tb.Invalidate();
	}

	public IEnumerable<Range> GetRanges(string regexPattern)
	{
		return GetRanges(regexPattern, RegexOptions.None);
	}

	public IEnumerable<Range> GetRanges(string regexPattern, RegexOptions options)
	{
		GetText(out var text, out var charIndexToPlace);
		Regex regex = new Regex(regexPattern, options);
		foreach (Match m in regex.Matches(text))
		{
			Range r = new Range(tb);
			Group group = m.Groups["range"];
			if (!group.Success)
			{
				group = m.Groups[0];
			}
			r.Start = charIndexToPlace[group.Index];
			r.End = charIndexToPlace[group.Index + group.Length];
			yield return r;
		}
	}

	public IEnumerable<Range> GetRangesByLines(string regexPattern, RegexOptions options)
	{
		Regex regex = new Regex(regexPattern, options);
		foreach (Range rangesByLine in GetRangesByLines(regex))
		{
			yield return rangesByLine;
		}
	}

	public IEnumerable<Range> GetRangesByLines(Regex regex)
	{
		Normalize();
		FileTextSource fts = tb.TextSource as FileTextSource;
		for (int iLine = Start.iLine; iLine <= End.iLine; iLine++)
		{
			bool isLineLoaded = fts?.IsLineLoaded(iLine) ?? true;
			Range r = new Range(tb, new Place(0, iLine), new Place(tb[iLine].Count, iLine));
			if (iLine == Start.iLine || iLine == End.iLine)
			{
				r = r.GetIntersectionWith(this);
			}
			foreach (Range range in r.GetRanges(regex))
			{
				yield return range;
			}
			if (!isLineLoaded)
			{
				fts.UnloadLine(iLine);
			}
		}
	}

	public IEnumerable<Range> GetRangesByLinesReversed(string regexPattern, RegexOptions options)
	{
		Normalize();
		Regex regex = new Regex(regexPattern, options);
		FileTextSource fts = tb.TextSource as FileTextSource;
		for (int iLine = End.iLine; iLine >= Start.iLine; iLine--)
		{
			bool isLineLoaded = fts?.IsLineLoaded(iLine) ?? true;
			Range r = new Range(tb, new Place(0, iLine), new Place(tb[iLine].Count, iLine));
			if (iLine == Start.iLine || iLine == End.iLine)
			{
				r = r.GetIntersectionWith(this);
			}
			List<Range> list = new List<Range>();
			foreach (Range foundRange in r.GetRanges(regex))
			{
				list.Add(foundRange);
			}
			for (int i = list.Count - 1; i >= 0; i--)
			{
				yield return list[i];
			}
			if (!isLineLoaded)
			{
				fts.UnloadLine(iLine);
			}
		}
	}

	public IEnumerable<Range> GetRanges(Regex regex)
	{
		GetText(out var text, out var charIndexToPlace);
		foreach (Match m in regex.Matches(text))
		{
			Range r = new Range(tb);
			Group group = m.Groups["range"];
			if (!group.Success)
			{
				group = m.Groups[0];
			}
			r.Start = charIndexToPlace[group.Index];
			r.End = charIndexToPlace[group.Index + group.Length];
			yield return r;
		}
	}

	public void ClearStyle(params Style[] styles)
	{
		try
		{
			ClearStyle(tb.GetStyleIndexMask(styles));
		}
		catch
		{
		}
	}

	public void ClearStyle(StyleIndex styleIndex)
	{
		int num = Math.Min(End.iLine, Start.iLine);
		int num2 = Math.Max(End.iLine, Start.iLine);
		int fromX = FromX;
		int toX = ToX;
		if (num < 0)
		{
			return;
		}
		for (int i = num; i <= num2; i++)
		{
			int num3 = ((i == num) ? fromX : 0);
			int num4 = ((i == num2) ? Math.Min(toX - 1, tb[i].Count - 1) : (tb[i].Count - 1));
			for (int j = num3; j <= num4; j++)
			{
				Char value = tb[i][j];
				value.style &= (StyleIndex)(ushort)(~(int)styleIndex);
				tb[i][j] = value;
			}
		}
		tb.Invalidate();
	}

	public void ClearFoldingMarkers()
	{
		int num = Math.Min(End.iLine, Start.iLine);
		int num2 = Math.Max(End.iLine, Start.iLine);
		if (num >= 0)
		{
			for (int i = num; i <= num2; i++)
			{
				tb[i].ClearFoldingMarkers();
			}
			tb.Invalidate();
		}
	}

	private void OnSelectionChanged()
	{
		cachedTextVersion = -1;
		cachedText = null;
		cachedCharIndexToPlace = null;
		if (tb.Selection == this && updating == 0)
		{
			tb.OnSelectionChanged();
		}
	}

	public void BeginUpdate()
	{
		updating++;
	}

	public void EndUpdate()
	{
		updating--;
		if (updating == 0)
		{
			OnSelectionChanged();
		}
	}

	public override string ToString()
	{
		return string.Concat("Start: ", Start, " End: ", End);
	}

	public void Normalize()
	{
		if (Start > End)
		{
			Inverse();
		}
	}

	public void Inverse()
	{
		Place place = start;
		start = end;
		end = place;
	}

	public void Expand()
	{
		Normalize();
		start = new Place(0, start.iLine);
		end = new Place(tb.GetLineLength(end.iLine), end.iLine);
	}

	IEnumerator<Place> IEnumerable<Place>.GetEnumerator()
	{
		if (ColumnSelectionMode)
		{
			foreach (Place item in GetEnumerator_ColumnSelectionMode())
			{
				yield return item;
			}
			yield break;
		}
		int fromLine = Math.Min(end.iLine, start.iLine);
		int toLine = Math.Max(end.iLine, start.iLine);
		int fromChar = FromX;
		int toChar = ToX;
		if (fromLine < 0)
		{
			yield break;
		}
		for (int y = fromLine; y <= toLine; y++)
		{
			int fromX = ((y == fromLine) ? fromChar : 0);
			int toX = ((y == toLine) ? Math.Min(toChar - 1, tb[y].Count - 1) : (tb[y].Count - 1));
			for (int x = fromX; x <= toX; x++)
			{
				yield return new Place(x, y);
			}
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return ((IEnumerable<Place>)this).GetEnumerator();
	}

	public Range GetFragment(string allowedSymbolsPattern)
	{
		return GetFragment(allowedSymbolsPattern, RegexOptions.None);
	}

	public Range GetFragment(Style style, bool allowLineBreaks)
	{
		StyleIndex styleIndexMask = tb.GetStyleIndexMask(new Style[1] { style });
		Range range = new Range(tb);
		range.Start = Start;
		while (range.GoLeftThroughFolded() && (allowLineBreaks || range.CharAfterStart != '\n'))
		{
			if (range.Start.iChar < tb.GetLineLength(range.Start.iLine) && (tb[range.Start].style & styleIndexMask) == 0)
			{
				range.GoRightThroughFolded();
				break;
			}
		}
		Place place = range.Start;
		range.Start = Start;
		while ((allowLineBreaks || range.CharAfterStart != '\n') && (range.Start.iChar >= tb.GetLineLength(range.Start.iLine) || (tb[range.Start].style & styleIndexMask) != StyleIndex.None) && range.GoRightThroughFolded())
		{
		}
		Place place2 = range.Start;
		return new Range(tb, place, place2);
	}

	public Range GetFragment(string allowedSymbolsPattern, RegexOptions options)
	{
		Range range = new Range(tb);
		range.Start = Start;
		Regex regex = new Regex(allowedSymbolsPattern, options);
		while (range.GoLeftThroughFolded())
		{
			if (!regex.IsMatch(range.CharAfterStart.ToString()))
			{
				range.GoRightThroughFolded();
				break;
			}
		}
		Place place = range.Start;
		range.Start = Start;
		while (regex.IsMatch(range.CharAfterStart.ToString()) && range.GoRightThroughFolded())
		{
		}
		Place place2 = range.Start;
		return new Range(tb, place, place2);
	}

	private bool IsIdentifierChar(char c)
	{
		return char.IsLetterOrDigit(c) || c == '_';
	}

	private bool IsSpaceChar(char c)
	{
		return c == ' ' || c == '\t';
	}

	public void GoWordLeft(bool shift)
	{
		ColumnSelectionMode = false;
		if (!shift && start > end)
		{
			Start = End;
			return;
		}
		Range range = Clone();
		bool flag = false;
		while (IsSpaceChar(range.CharBeforeStart))
		{
			flag = true;
			range.GoLeft(shift);
		}
		bool flag2 = false;
		while (IsIdentifierChar(range.CharBeforeStart))
		{
			flag2 = true;
			range.GoLeft(shift);
		}
		if (!flag2 && (!flag || range.CharBeforeStart != '\n'))
		{
			range.GoLeft(shift);
		}
		Start = range.Start;
		End = range.End;
		if (tb.LineInfos[Start.iLine].VisibleState != VisibleState.Visible)
		{
			GoRight(shift);
		}
	}

	public void GoWordRight(bool shift, bool goToStartOfNextWord = false)
	{
		ColumnSelectionMode = false;
		if (!shift && start < end)
		{
			Start = End;
			return;
		}
		Range range = Clone();
		bool flag = false;
		if (range.CharAfterStart == '\n')
		{
			range.GoRight(shift);
			flag = true;
		}
		bool flag2 = false;
		while (IsSpaceChar(range.CharAfterStart))
		{
			flag2 = true;
			range.GoRight(shift);
		}
		if (!((flag2 || flag) && goToStartOfNextWord))
		{
			bool flag3 = false;
			while (IsIdentifierChar(range.CharAfterStart))
			{
				flag3 = true;
				range.GoRight(shift);
			}
			if (!flag3)
			{
				range.GoRight(shift);
			}
			if (goToStartOfNextWord && !flag2)
			{
				while (IsSpaceChar(range.CharAfterStart))
				{
					range.GoRight(shift);
				}
			}
		}
		Start = range.Start;
		End = range.End;
		if (tb.LineInfos[Start.iLine].VisibleState != VisibleState.Visible)
		{
			GoLeft(shift);
		}
	}

	internal void GoFirst(bool shift)
	{
		ColumnSelectionMode = false;
		start = new Place(0, 0);
		if (tb.LineInfos[Start.iLine].VisibleState != VisibleState.Visible)
		{
			tb.ExpandBlock(Start.iLine);
		}
		if (!shift)
		{
			end = start;
		}
		OnSelectionChanged();
	}

	internal void GoLast(bool shift)
	{
		ColumnSelectionMode = false;
		start = new Place(tb[tb.LinesCount - 1].Count, tb.LinesCount - 1);
		if (tb.LineInfos[Start.iLine].VisibleState != VisibleState.Visible)
		{
			tb.ExpandBlock(Start.iLine);
		}
		if (!shift)
		{
			end = start;
		}
		OnSelectionChanged();
	}

	public static StyleIndex ToStyleIndex(int i)
	{
		return (StyleIndex)(1 << i);
	}

	public IEnumerable<Range> GetSubRanges(bool includeEmpty)
	{
		if (!ColumnSelectionMode)
		{
			yield return this;
			yield break;
		}
		RangeRect rect = Bounds;
		for (int y = rect.iStartLine; y <= rect.iEndLine; y++)
		{
			if (rect.iStartChar <= tb[y].Count || includeEmpty)
			{
				yield return new Range(tb, rect.iStartChar, y, Math.Min(rect.iEndChar, tb[y].Count), y);
			}
		}
	}

	public bool IsReadOnlyLeftChar()
	{
		if (tb.ReadOnly)
		{
			return true;
		}
		Range range = Clone();
		range.Normalize();
		if (range.start.iChar == 0)
		{
			return false;
		}
		if (ColumnSelectionMode)
		{
			range.GoLeft_ColumnSelectionMode();
		}
		else
		{
			range.GoLeft(shift: true);
		}
		return range.ReadOnly;
	}

	public bool IsReadOnlyRightChar()
	{
		if (tb.ReadOnly)
		{
			return true;
		}
		Range range = Clone();
		range.Normalize();
		if (range.end.iChar >= tb[end.iLine].Count)
		{
			return false;
		}
		if (ColumnSelectionMode)
		{
			range.GoRight_ColumnSelectionMode();
		}
		else
		{
			range.GoRight(shift: true);
		}
		return range.ReadOnly;
	}

	public IEnumerable<Place> GetPlacesCyclic(Place startPlace, bool backward = false)
	{
		if (backward)
		{
			Range r = new Range(tb, startPlace, startPlace);
			while (r.GoLeft() && r.start >= Start)
			{
				if (r.Start.iChar < tb[r.Start.iLine].Count)
				{
					yield return r.Start;
				}
			}
			r = new Range(tb, End, End);
			while (r.GoLeft() && r.start >= startPlace)
			{
				if (r.Start.iChar < tb[r.Start.iLine].Count)
				{
					yield return r.Start;
				}
			}
			yield break;
		}
		Range r2 = new Range(tb, startPlace, startPlace);
		if (startPlace < End)
		{
			do
			{
				if (r2.Start.iChar < tb[r2.Start.iLine].Count)
				{
					yield return r2.Start;
				}
			}
			while (r2.GoRight());
		}
		r2 = new Range(tb, Start, Start);
		if (!(r2.Start < startPlace))
		{
			yield break;
		}
		do
		{
			if (r2.Start.iChar < tb[r2.Start.iLine].Count)
			{
				yield return r2.Start;
			}
		}
		while (r2.GoRight() && r2.Start < startPlace);
	}

	private Range GetIntersectionWith_ColumnSelectionMode(Range range)
	{
		if (range.Start.iLine != range.End.iLine)
		{
			return new Range(tb, Start, Start);
		}
		RangeRect bounds = Bounds;
		if (range.Start.iLine < bounds.iStartLine || range.Start.iLine > bounds.iEndLine)
		{
			return new Range(tb, Start, Start);
		}
		return new Range(tb, bounds.iStartChar, range.Start.iLine, bounds.iEndChar, range.Start.iLine).GetIntersectionWith(range);
	}

	private bool GoRightThroughFolded_ColumnSelectionMode()
	{
		RangeRect bounds = Bounds;
		bool flag = true;
		for (int i = bounds.iStartLine; i <= bounds.iEndLine; i++)
		{
			if (bounds.iEndChar < tb[i].Count)
			{
				flag = false;
				break;
			}
		}
		if (flag)
		{
			return false;
		}
		Place place = Start;
		Place place2 = End;
		place.Offset(1, 0);
		place2.Offset(1, 0);
		BeginUpdate();
		Start = place;
		End = place2;
		EndUpdate();
		return true;
	}

	private IEnumerable<Place> GetEnumerator_ColumnSelectionMode()
	{
		RangeRect bounds = Bounds;
		if (bounds.iStartLine < 0)
		{
			yield break;
		}
		for (int y = bounds.iStartLine; y <= bounds.iEndLine; y++)
		{
			for (int x = bounds.iStartChar; x < bounds.iEndChar; x++)
			{
				if (x < tb[y].Count)
				{
					yield return new Place(x, y);
				}
			}
		}
	}

	private int Length_ColumnSelectionMode(bool withNewLines)
	{
		RangeRect bounds = Bounds;
		if (bounds.iStartLine < 0)
		{
			return 0;
		}
		int num = 0;
		for (int i = bounds.iStartLine; i <= bounds.iEndLine; i++)
		{
			for (int j = bounds.iStartChar; j < bounds.iEndChar; j++)
			{
				if (j < tb[i].Count)
				{
					num++;
				}
			}
			if (withNewLines && bounds.iEndLine != bounds.iStartLine && i != bounds.iEndLine)
			{
				num += Environment.NewLine.Length;
			}
		}
		return num;
	}

	internal void GoDown_ColumnSelectionMode()
	{
		int iLine = tb.FindNextVisibleLine(End.iLine);
		End = new Place(End.iChar, iLine);
	}

	internal void GoUp_ColumnSelectionMode()
	{
		int iLine = tb.FindPrevVisibleLine(End.iLine);
		End = new Place(End.iChar, iLine);
	}

	internal void GoRight_ColumnSelectionMode()
	{
		End = new Place(End.iChar + 1, End.iLine);
	}

	internal void GoLeft_ColumnSelectionMode()
	{
		if (End.iChar > 0)
		{
			End = new Place(End.iChar - 1, End.iLine);
		}
	}
}
