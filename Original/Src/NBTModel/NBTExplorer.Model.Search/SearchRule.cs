using System.Collections.Generic;

namespace NBTExplorer.Model.Search;

public abstract class SearchRule
{
	public static readonly Dictionary<NumericOperator, string> NumericOpStrings = new Dictionary<NumericOperator, string>
	{
		{
			NumericOperator.Equals,
			"="
		},
		{
			NumericOperator.NotEquals,
			"!="
		},
		{
			NumericOperator.GreaterThan,
			">"
		},
		{
			NumericOperator.LessThan,
			"<"
		},
		{
			NumericOperator.Any,
			"ANY"
		}
	};

	public static readonly Dictionary<StringOperator, string> StringOpStrings = new Dictionary<StringOperator, string>
	{
		{
			StringOperator.Equals,
			"="
		},
		{
			StringOperator.NotEquals,
			"!="
		},
		{
			StringOperator.Contains,
			"Contains"
		},
		{
			StringOperator.NotContains,
			"Does not Contain"
		},
		{
			StringOperator.StartsWith,
			"Begins With"
		},
		{
			StringOperator.EndsWith,
			"Ends With"
		},
		{
			StringOperator.Any,
			"ANY"
		}
	};

	public static readonly Dictionary<WildcardOperator, string> WildcardOpStrings = new Dictionary<WildcardOperator, string>
	{
		{
			WildcardOperator.Equals,
			"="
		},
		{
			WildcardOperator.NotEquals,
			"!="
		},
		{
			WildcardOperator.Any,
			"ANY"
		}
	};

	public abstract string NodeDisplay { get; }

	public virtual bool CanAddRules => false;

	public virtual bool Matches(TagCompoundDataNode container, List<TagDataNode> matchedNodes)
	{
		return false;
	}

	protected static TagDataNode GetChild(TagCompoundDataNode container, string name)
	{
		foreach (DataNode node in container.Nodes)
		{
			if (node is TagDataNode tagDataNode && tagDataNode.NodeName == name)
			{
				return tagDataNode;
			}
		}
		return null;
	}
}
