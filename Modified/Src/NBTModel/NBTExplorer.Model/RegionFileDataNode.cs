using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using NBTModel.Interop;
using Substrate.Core;

namespace NBTExplorer.Model;

public class RegionFileDataNode : DataNode
{
	private string _path;

	private RegionFile _region;

	private List<RegionKey> _deleteQueue = new List<RegionKey>();

	private static Regex _namePattern = new Regex("^r\\.(-?\\d+)\\.(-?\\d+)\\.(mcr|mca)$");

	protected override NodeCapabilities Capabilities => NodeCapabilities.Search | NodeCapabilities.Refresh;

	public override bool HasUnexpandedChildren => !base.IsExpanded;

	public override bool IsContainerType => true;

	public override string NodePathName => Path.GetFileName(_path);

	public override string NodeDisplay => Path.GetFileName(_path);

	private RegionFileDataNode(string path)
	{
		_path = path;
	}

	public static RegionFileDataNode TryCreateFrom(string path)
	{
		return new RegionFileDataNode(path);
	}

	public static bool SupportedNamePattern(string path)
	{
		path = Path.GetFileName(path);
		return _namePattern.IsMatch(path);
	}

	public static bool RegionCoordinates(string path, out int rx, out int rz)
	{
		rx = 0;
		rz = 0;
		Match match = _namePattern.Match(path);
		if (match.Success && match.Groups.Count > 3)
		{
			rx = int.Parse(match.Groups[1].Value);
			rz = int.Parse(match.Groups[2].Value);
		}
		return match.Success;
	}

	protected override void ExpandCore()
	{
		try
		{
			if (_region == null)
			{
				_region = new RegionFile(_path);
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
		catch (Exception)
		{
			if (FormRegistry.MessageBox != null)
			{
				FormRegistry.MessageBox("Not a valid region file.");
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

	protected override void SaveCore()
	{
		foreach (RegionKey item in _deleteQueue)
		{
			if (_region.HasChunk(item.X, item.Z))
			{
				_region.DeleteChunk(item.X, item.Z);
			}
		}
		_deleteQueue.Clear();
	}

	public override bool RefreshNode()
	{
		Dictionary<string, object> dictionary = BuildExpandSet(this);
		Release();
		RestoreExpandSet(this, dictionary);
		return dictionary != null;
	}

	public void QueueDeleteChunk(int rx, int rz)
	{
		RegionKey item = new RegionKey(rx, rz);
		if (!_deleteQueue.Contains(item))
		{
			_deleteQueue.Add(item);
		}
	}
}
