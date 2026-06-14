using System.Collections.Generic;
using System.Globalization;
using NBTExplorer.Model;

namespace NBTExplorer;

internal abstract class NameValueSearchState : ISearchState
{
	public virtual string SearchName { get; set; }

	public virtual string SearchValue { get; set; }

	public DataNode RootNode { get; set; }

	public IEnumerator<DataNode> State { get; set; }

	public bool TerminateOnDiscover { get; set; }

	public bool IsTerminated { get; set; }

	public float ProgressRate { get; set; }

	public abstract void InvokeDiscoverCallback(DataNode node);

	public abstract void InvokeProgressCallback(DataNode node);

	public abstract void InvokeCollapseCallback(DataNode node);

	public abstract void InvokeEndCallback(DataNode node);

	protected NameValueSearchState()
	{
		TerminateOnDiscover = true;
		ProgressRate = 0.5f;
	}

	public bool TestNode(DataNode node)
	{
		bool flag = SearchName == null;
		bool flag2 = SearchValue == null;
		if (SearchName != null)
		{
			string nodeName = node.NodeName;
			if (nodeName != null)
			{
				flag = CultureInfo.InvariantCulture.CompareInfo.IndexOf(nodeName, SearchName, CompareOptions.IgnoreCase) >= 0;
			}
		}
		if (SearchValue != null)
		{
			string nodeDisplay = node.NodeDisplay;
			if (nodeDisplay != null)
			{
				flag2 = CultureInfo.InvariantCulture.CompareInfo.IndexOf(nodeDisplay, SearchValue, CompareOptions.IgnoreCase) >= 0;
			}
		}
		if (flag && flag2)
		{
			return true;
		}
		return false;
	}
}
