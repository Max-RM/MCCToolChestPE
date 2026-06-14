using System.Collections.Generic;
using NBTExplorer.Model;

namespace NBTExplorer;

internal interface ISearchState
{
	DataNode RootNode { get; set; }

	IEnumerator<DataNode> State { get; set; }

	bool TerminateOnDiscover { get; set; }

	bool IsTerminated { get; set; }

	float ProgressRate { get; set; }

	void InvokeDiscoverCallback(DataNode node);

	void InvokeProgressCallback(DataNode node);

	void InvokeCollapseCallback(DataNode node);

	void InvokeEndCallback(DataNode node);

	bool TestNode(DataNode node);
}
