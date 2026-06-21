using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using MCCToolChest.model;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.workers;

public class ParseConditionsWorker
{
	private enum rARiNhu1BkyZwelU1ST
	{

	}

	private char[] Mi8S3vGVJb4;

	private Dictionary<string, SearchCondition> HybS3wDq66p;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<NodeSearchcriterion> ParseConditions(string cs)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<NodeSearchcriterion> list = new List<NodeSearchcriterion>();
		string[] array = cs.Split(',');
		string[] array2 = array;
		foreach (string text in array2)
		{
			NodeSearchcriterion nodeSearchcriterion = Ih8S3bZD3U2(text);
			if (nodeSearchcriterion != null)
			{
				list.Add(nodeSearchcriterion);
			}
		}
		return list;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private NodeSearchcriterion Ih8S3bZD3U2(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		NodeSearchcriterion nodeSearchcriterion = null;
		string text = string.Empty;
		string text2 = string.Empty;
		string text3 = string.Empty;
		rARiNhu1BkyZwelU1ST rARiNhu1BkyZwelU1ST2 = (rARiNhu1BkyZwelU1ST)0;
		for (int i = 0; i < P_0.Length; i++)
		{
			char c = P_0[i];
			switch (rARiNhu1BkyZwelU1ST2)
			{
			case (rARiNhu1BkyZwelU1ST)0:
				if (Mi8S3vGVJb4.Contains(c))
				{
					text2 = c.ToString();
					rARiNhu1BkyZwelU1ST2 = (rARiNhu1BkyZwelU1ST)1;
				}
				else
				{
					text += c;
				}
				break;
			case (rARiNhu1BkyZwelU1ST)1:
				if (!Mi8S3vGVJb4.Contains(c))
				{
					if (c != ' ')
					{
						text3 = c.ToString();
						rARiNhu1BkyZwelU1ST2 = (rARiNhu1BkyZwelU1ST)2;
					}
				}
				else
				{
					text2 += c;
				}
				break;
			case (rARiNhu1BkyZwelU1ST)2:
				text3 += c;
				break;
			}
		}
		text = text.Trim();
		text3 = text3.Trim();
		if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(text2) && HybS3wDq66p.ContainsKey(text2))
		{
			nodeSearchcriterion = new NodeSearchcriterion();
			nodeSearchcriterion.Node = text;
			nodeSearchcriterion.Value = text3;
			nodeSearchcriterion.Condition = HybS3wDq66p[text2];
		}
		return nodeSearchcriterion;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ParseConditionsWorker()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		Mi8S3vGVJb4 = new char[4] { '=', '!', '<', '>' };
		HybS3wDq66p = new Dictionary<string, SearchCondition>
		{
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31730),
				SearchCondition.Equal
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247442),
				SearchCondition.NotEqual
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247450),
				SearchCondition.LessThan
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247456),
				SearchCondition.GreaterThan
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247462),
				SearchCondition.LessThanEqual
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247470),
				SearchCondition.GreaterThanEqual
			}
		};
	}
}
