using System.Collections.Generic;
using NBTExplorer.Model;
using NBTExplorer.Model.Search;

namespace NBTExplorer.Windows;

public abstract class ContainerRuleSearchState : ISearchState
{
	public GroupRule RuleTags { get; set; }

	public DataNode RootNode { get; set; }

	public IEnumerator<DataNode> State { get; set; }

	public bool TerminateOnDiscover { get; set; }

	public bool IsTerminated { get; set; }

	public float ProgressRate { get; set; }

	public abstract void InvokeDiscoverCallback(DataNode node);

	public abstract void InvokeProgressCallback(DataNode node);

	public abstract void InvokeCollapseCallback(DataNode node);

	public abstract void InvokeEndCallback(DataNode node);

	protected ContainerRuleSearchState()
	{
		TerminateOnDiscover = true;
		ProgressRate = 0.5f;
	}

	public bool TestNode(DataNode node)
	{
		if (RuleTags == null)
		{
			return false;
		}
		if (!(node is TagCompoundDataNode container))
		{
			return false;
		}
		List<TagDataNode> matchedNodes = new List<TagDataNode>();
		if (!RuleTags.Matches(container, matchedNodes))
		{
			return false;
		}
		return true;
	}
}
