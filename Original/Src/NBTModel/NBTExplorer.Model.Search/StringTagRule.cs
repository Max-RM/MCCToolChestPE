using System.Collections.Generic;
using Substrate.Nbt;

namespace NBTExplorer.Model.Search;

public class StringTagRule : TagRule
{
	public string Value { get; set; }

	public StringOperator Operator { get; set; }

	public override string NodeDisplay => string.Format("{0} {1} {2}", base.Name, SearchRule.StringOpStrings[Operator], (Operator != StringOperator.Any) ? ('"' + Value + '"') : "");

	public override bool Matches(TagCompoundDataNode container, List<TagDataNode> matchedNodes)
	{
		TagDataNode child = SearchRule.GetChild(container, base.Name);
		TagNodeString tagNodeString = LookupTag<TagNodeString>(container, base.Name);
		if (tagNodeString == null)
		{
			return false;
		}
		switch (Operator)
		{
		case StringOperator.Equals:
			if (tagNodeString.ToTagString().Data != Value)
			{
				return false;
			}
			break;
		case StringOperator.NotEquals:
			if (tagNodeString.ToTagString().Data == Value)
			{
				return false;
			}
			break;
		case StringOperator.Contains:
			if (!tagNodeString.ToTagString().Data.Contains(Value))
			{
				return false;
			}
			break;
		case StringOperator.NotContains:
			if (tagNodeString.ToTagString().Data.Contains(Value))
			{
				return false;
			}
			break;
		case StringOperator.StartsWith:
			if (!tagNodeString.ToTagString().Data.StartsWith(Value))
			{
				return false;
			}
			break;
		case StringOperator.EndsWith:
			if (!tagNodeString.ToTagString().Data.EndsWith(Value))
			{
				return false;
			}
			break;
		default:
			return false;
		case StringOperator.Any:
			break;
		}
		if (!matchedNodes.Contains(child))
		{
			matchedNodes.Add(child);
		}
		return true;
	}
}
