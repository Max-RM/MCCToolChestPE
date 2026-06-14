using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace NBTExplorer.Model;

public class NbtPathEnumerator : IEnumerable<DataNode>, IEnumerable
{
	private class PathPartDesc
	{
		public string Name;

		public DataNode Node;
	}

	private string _pathRoot;

	private List<string> _pathParts = new List<string>();

	public NbtPathEnumerator(string path)
	{
		_pathRoot = Path.GetPathRoot(path);
		_pathParts = new List<string>(path.Substring(_pathRoot.Length).Split('/', '\\'));
		if (string.IsNullOrEmpty(_pathRoot))
		{
			_pathRoot = Directory.GetCurrentDirectory();
		}
	}

	public IEnumerator<DataNode> GetEnumerator()
	{
		DataNode dataNode = new DirectoryDataNode(_pathRoot);
		dataNode.Expand();
		foreach (DataNode item in EnumerateNodes(dataNode, _pathParts))
		{
			yield return item;
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	private IEnumerable<DataNode> EnumerateNodes(DataNode containerNode, List<string> nextLevels)
	{
		containerNode.Expand();
		if (nextLevels.Count == 0)
		{
			yield return containerNode;
		}
		else
		{
			if (containerNode.Nodes.Count == 0)
			{
				yield break;
			}
			string part = nextLevels[0];
			List<string> remainingLevels = nextLevels.GetRange(1, nextLevels.Count - 1);
			if (part == "*")
			{
				foreach (DataNode childNode in containerNode.Nodes)
				{
					foreach (DataNode item in EnumerateNodes(childNode, remainingLevels))
					{
						yield return item;
					}
				}
				yield break;
			}
			if (part == "**")
			{
				foreach (DataNode childNode2 in containerNode.Nodes)
				{
					foreach (DataNode item2 in EnumerateNodes(childNode2, remainingLevels))
					{
						yield return item2;
					}
					foreach (DataNode item3 in EnumerateNodes(childNode2, nextLevels))
					{
						yield return item3;
					}
				}
				yield break;
			}
			foreach (DataNode childNode3 in containerNode.Nodes)
			{
				if (!(childNode3.NodePathName == part))
				{
					continue;
				}
				foreach (DataNode item4 in EnumerateNodes(childNode3, remainingLevels))
				{
					yield return item4;
				}
			}
		}
	}
}
