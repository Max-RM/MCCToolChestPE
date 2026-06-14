using System.Collections.Generic;

namespace NBTExplorer.Model.Search;

public class IntersectRule : GroupRule
{
	public override string NodeDisplay => "Match All";

	public override bool Matches(TagCompoundDataNode container, List<TagDataNode> matchedNodes)
	{
		foreach (SearchRule rule in base.Rules)
		{
			if (!rule.Matches(container, matchedNodes))
			{
				return false;
			}
		}
		return true;
	}
}
