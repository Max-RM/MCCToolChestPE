using System.Collections.Generic;

namespace NBTExplorer.Model;

public class NbtPath
{
	private class PathPart
	{
		public string Name;

		public DataNode Node;
	}

	private List<DataNode> _nodes;

	internal NbtPath(List<DataNode> nodes)
	{
		_nodes = nodes;
	}
}
