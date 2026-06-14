using System.IO;
using Substrate.Core;
using Substrate.Nbt;

namespace NBTExplorer.Model;

public class RegionChunkDataNode : DataNode, IMetaTagContainer, ITagContainer
{
	private RegionFile _regionFile;

	private NbtTree _tree;

	private int _x;

	private int _z;

	private CompoundTagContainer _container;

	public int X => _x;

	public int Z => _z;

	protected RegionFileDataNode RegionParent => base.Parent as RegionFileDataNode;

	protected override NodeCapabilities Capabilities => NodeCapabilities.PasteInto | NodeCapabilities.Delete | NodeCapabilities.CreateTag | NodeCapabilities.Search;

	public override bool HasUnexpandedChildren => !base.IsExpanded;

	public override string NodePathName => _x + "." + _z;

	public override string NodeDisplay
	{
		get
		{
			RegionKey regionKey = _regionFile.parseCoordinatesFromName();
			string text = "";
			if (regionKey != RegionKey.InvalidRegion)
			{
				text = "        in world at (" + (regionKey.X * 32 + _x) + ", " + (regionKey.Z * 32 + _z) + ")";
			}
			return "Chunk [" + _x + ", " + _z + "]" + text;
		}
	}

	public override bool IsContainerType => true;

	public bool IsNamedContainer => true;

	public bool IsOrderedContainer => false;

	public INamedTagContainer NamedTagContainer => _container;

	public IOrderedTagContainer OrderedTagContainer => null;

	public int TagCount => _container.TagCount;

	public RegionChunkDataNode(RegionFile regionFile, int x, int z)
	{
		_regionFile = regionFile;
		_x = x;
		_z = z;
		_container = new CompoundTagContainer(new TagNodeCompound());
	}

	protected override void ExpandCore()
	{
		if (_tree == null)
		{
			_tree = new NbtTree();
			_tree.ReadFrom(_regionFile.GetChunkDataInputStream(_x, _z));
			if (_tree.Root != null)
			{
				_container = new CompoundTagContainer(_tree.Root);
			}
		}
		foreach (TagNode value in _tree.Root.Values)
		{
			TagDataNode tagDataNode = TagDataNode.CreateFromTag(value);
			if (tagDataNode != null)
			{
				base.Nodes.Add(tagDataNode);
			}
		}
	}

	protected override void ReleaseCore()
	{
		_tree = null;
		base.Nodes.Clear();
	}

	protected override void SaveCore()
	{
		using Stream s = _regionFile.GetChunkDataOutputStream(_x, _z);
		_tree.WriteTo(s);
	}

	public override bool DeleteNode()
	{
		if (CanDeleteNode && _regionFile.HasChunk(_x, _z))
		{
			RegionParent.QueueDeleteChunk(_x, _z);
			base.IsParentModified = true;
			return base.Parent.Nodes.Remove(this);
		}
		return false;
	}

	public bool DeleteTag(TagNode tag)
	{
		return _container.DeleteTag(tag);
	}
}
