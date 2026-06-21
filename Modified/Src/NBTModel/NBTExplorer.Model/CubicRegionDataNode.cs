using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using NBTModel.Interop;

namespace NBTExplorer.Model;

public class CubicRegionDataNode : DataNode
{
	private string _path;

	private CubicRegionFile _region;

	private static Regex _namePattern = new Regex("^r2(\\.-?\\d+){3}\\.(mcr|mca)$");

	protected override NodeCapabilities Capabilities => NodeCapabilities.Search | NodeCapabilities.Refresh;

	public override bool HasUnexpandedChildren => !base.IsExpanded;

	public override bool IsContainerType => true;

	public override string NodePathName => Path.GetFileName(_path);

	public override string NodeDisplay => Path.GetFileName(_path);

	private CubicRegionDataNode(string path)
	{
		_path = path;
	}

	public static CubicRegionDataNode TryCreateFrom(string path)
	{
		return new CubicRegionDataNode(path);
	}

	public static bool SupportedNamePattern(string path)
	{
		path = Path.GetFileName(path);
		return _namePattern.IsMatch(path);
	}

	protected override void ExpandCore()
	{
		try
		{
			if (_region == null)
			{
				_region = new CubicRegionFile(_path);
			}
			for (int i = 0; i < 32; i++)
			{
				for (int j = 0; j < 32; j++)
				{
					if (_region.HasChunk(i, j))
					{
						base.Nodes.Add(new RegionChunkDataNode(_region, i, j));
					}
				}
			}
		}
		catch
		{
			if (FormRegistry.MessageBox != null)
			{
				FormRegistry.MessageBox("Not a valid cubic region file.");
			}
		}
	}

	protected override void ReleaseCore()
	{
		if (_region != null)
		{
			_region.Close();
		}
		_region = null;
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
