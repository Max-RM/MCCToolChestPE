using System;

namespace FastColoredTextBoxNS;

internal class RangeInfo
{
	public Place Start { get; set; }

	public Place End { get; set; }

	internal int FromX
	{
		get
		{
			if (End.iLine < Start.iLine)
			{
				return End.iChar;
			}
			if (End.iLine > Start.iLine)
			{
				return Start.iChar;
			}
			return Math.Min(End.iChar, Start.iChar);
		}
	}

	public RangeInfo(Range r)
	{
		Start = r.Start;
		End = r.End;
	}
}
