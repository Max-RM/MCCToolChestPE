using System.Collections.Generic;

namespace NBTExplorer.Model.Search;

public class UnionRule : GroupRule
{
	public override string NodeDisplay => "Match Any";

	public override bool Matches(TagCompoundDataNode container, List<TagDataNode> matchedNodes)
	{
		foreach (SearchRule rule in base.Rules)
		{
			if (rule.Matches(container, matchedNodes))
			{
				return true;
			}
		}
		return false;
	}
}
