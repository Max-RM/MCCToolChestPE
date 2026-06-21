using System;
using System.Collections.Generic;
using System.IO;

namespace NBTExplorer.Model;

public class StreamDataNode : DataNode
{
	private string _path;

	protected override NodeCapabilities Capabilities => NodeCapabilities.Search | NodeCapabilities.Refresh;

	public string NodeDirPath => _path;

	public override string NodePathName => "Chunk";

	public override string NodeDisplay => Path.GetFileName(_path);

	public override bool HasUnexpandedChildren => !base.IsExpanded;

	public override bool IsContainerType => true;

	public StreamDataNode(string path)
	{
		_path = path;
	}

	protected override void ExpandCore()
	{
		string[] directories = Directory.GetDirectories(_path);
		foreach (string path in directories)
		{
			base.Nodes.Add(new DirectoryDataNode(path));
		}
		string[] files = Directory.GetFiles(_path);
		foreach (string path2 in files)
		{
			DataNode dataNode = null;
			foreach (KeyValuePair<Type, FileTypeRecord> registeredType in FileTypeRegistry.RegisteredTypes)
			{
				if (registeredType.Value.NamePatternTest(path2))
				{
					dataNode = registeredType.Value.NodeCreate(path2);
				}
			}
			if (dataNode != null)
			{
				base.Nodes.Add(dataNode);
			}
		}
	}

	protected override void ReleaseCore()
	{
		base.Nodes.Clear();
	}

	public override bool RefreshNode()
	{
		Dictionary<string, object> dictionary = BuildExpandSet(this);
		Release();
		RestoreExpandSet(this, dictionary);
		return dictionary != null;
	}
}
