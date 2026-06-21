using System.Collections.Generic;
using Substrate.Nbt;

namespace NBTExplorer.Model.Search;

public class WildcardRule : SearchRule
{
	public string Name { get; set; }

	public string Value { get; set; }

	public WildcardOperator Operator { get; set; }

	public override string NodeDisplay => string.Format("{0} {1} {2}", Name, SearchRule.WildcardOpStrings[Operator], (Operator != WildcardOperator.Any) ? Value : "");

	public override bool Matches(TagCompoundDataNode container, List<TagDataNode> matchedNodes)
	{
		TagDataNode child = SearchRule.GetChild(container, Name);
		TagNode tagNode = container.NamedTagContainer.GetTagNode(Name);
		if (tagNode == null)
		{
			return false;
		}
		try
		{
			switch (tagNode.GetTagType())
			{
			case TagType.TAG_BYTE:
			case TagType.TAG_SHORT:
			case TagType.TAG_INT:
			case TagType.TAG_LONG:
				switch (Operator)
				{
				case WildcardOperator.Equals:
					if (long.Parse(Value) != (long)tagNode.ToTagLong())
					{
						return false;
					}
					break;
				case WildcardOperator.NotEquals:
					if (long.Parse(Value) == (long)tagNode.ToTagLong())
					{
						return false;
					}
					break;
				}
				if (!matchedNodes.Contains(child))
				{
					matchedNodes.Add(child);
				}
				return true;
			case TagType.TAG_FLOAT:
			case TagType.TAG_DOUBLE:
				switch (Operator)
				{
				case WildcardOperator.Equals:
					if (double.Parse(Value) != (double)tagNode.ToTagDouble())
					{
						return false;
					}
					break;
				case WildcardOperator.NotEquals:
					if (double.Parse(Value) == (double)tagNode.ToTagDouble())
					{
						return false;
					}
					break;
				}
				if (!matchedNodes.Contains(child))
				{
					matchedNodes.Add(child);
				}
				return true;
			case TagType.TAG_STRING:
				switch (Operator)
				{
				case WildcardOperator.Equals:
					if (Value != tagNode.ToTagString().Data)
					{
						return false;
					}
					break;
				case WildcardOperator.NotEquals:
					if (Value == tagNode.ToTagString().Data)
					{
						return false;
					}
					break;
				}
				if (!matchedNodes.Contains(child))
				{
					matchedNodes.Add(child);
				}
				return true;
			case TagType.TAG_BYTE_ARRAY:
				break;
			}
		}
		catch
		{
		}
		return false;
	}
}
