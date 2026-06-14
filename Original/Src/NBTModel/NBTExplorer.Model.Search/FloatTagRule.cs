using System.Collections.Generic;
using Substrate.Nbt;

namespace NBTExplorer.Model.Search;

public abstract class FloatTagRule<T> : TagRule where T : TagNode
{
	public double Value { get; set; }

	public NumericOperator Operator { get; set; }

	public override string NodeDisplay => string.Format("{0} {1} {2}", base.Name, SearchRule.NumericOpStrings[Operator], (Operator != NumericOperator.Any) ? Value.ToString() : "");

	public override bool Matches(TagCompoundDataNode container, List<TagDataNode> matchedNodes)
	{
		TagDataNode child = SearchRule.GetChild(container, base.Name);
		T val = LookupTag<T>(container, base.Name);
		if (val == null)
		{
			return false;
		}
		switch (Operator)
		{
		case NumericOperator.Equals:
			if ((double)val.ToTagDouble() != Value)
			{
				return false;
			}
			break;
		case NumericOperator.NotEquals:
			if ((double)val.ToTagDouble() == Value)
			{
				return false;
			}
			break;
		case NumericOperator.GreaterThan:
			if ((double)val.ToTagDouble() <= Value)
			{
				return false;
			}
			break;
		case NumericOperator.LessThan:
			if ((double)val.ToTagDouble() >= Value)
			{
				return false;
			}
			break;
		default:
			return false;
		case NumericOperator.Any:
			break;
		}
		if (!matchedNodes.Contains(child))
		{
			matchedNodes.Add(child);
		}
		return true;
	}
}
public class FloatTagRule : FloatTagRule<TagNodeFloat>
{
}
