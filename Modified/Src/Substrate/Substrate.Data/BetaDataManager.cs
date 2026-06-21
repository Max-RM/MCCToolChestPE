using System;
using System.IO;
using Substrate.Core;
using Substrate.Nbt;

namespace Substrate.Data;

public class BetaDataManager : DataManager, INbtObject<BetaDataManager>
{
	private static SchemaNodeCompound _schema = new SchemaNodeCompound
	{
		new SchemaNodeScaler("map", TagType.TAG_SHORT)
	};

	private TagNodeCompound _source;

	private NbtWorld _world;

	private short _mapId;

	private MapManager _maps;

	public override int CurrentMapId
	{
		get
		{
			return _mapId;
		}
		set
		{
			_mapId = (short)value;
		}
	}

	public new MapManager Maps => _maps;

	public BetaDataManager(NbtWorld world)
	{
		_world = world;
		_maps = new MapManager(_world);
	}

	protected override IMapManager GetMapManager()
	{
		return _maps;
	}

	public override bool Save()
	{
		if (_world == null)
		{
			return false;
		}
		try
		{
			string path = Path.Combine(_world.Path, _world.DataDirectory);
			NBTFile nBTFile = new NBTFile(Path.Combine(path, "idcounts.dat"));
			Stream dataOutputStream = nBTFile.GetDataOutputStream(CompressionType.None);
			if (dataOutputStream == null)
			{
				NbtIOException ex = new NbtIOException("Failed to initialize uncompressed NBT stream for output");
				ex.Data["DataManager"] = this;
				throw ex;
			}
			new NbtTree(BuildTree() as TagNodeCompound).WriteTo(dataOutputStream);
			dataOutputStream.Close();
			return true;
		}
		catch (Exception innerException)
		{
			Exception ex2 = new Exception("Could not save idcounts.dat file.", innerException);
			ex2.Data["DataManager"] = this;
			throw ex2;
		}
	}

	public virtual BetaDataManager LoadTree(TagNode tree)
	{
		if (!(tree is TagNodeCompound tagNodeCompound))
		{
			return null;
		}
		_mapId = tagNodeCompound["map"].ToTagShort();
		_source = tagNodeCompound.Copy() as TagNodeCompound;
		return this;
	}

	public virtual BetaDataManager LoadTreeSafe(TagNode tree)
	{
		if (!ValidateTree(tree))
		{
			return null;
		}
		return LoadTree(tree);
	}

	public virtual TagNode BuildTree()
	{
		TagNodeCompound tagNodeCompound = new TagNodeCompound();
		tagNodeCompound["map"] = new TagNodeLong(_mapId);
		if (_source != null)
		{
			tagNodeCompound.MergeFrom(_source);
		}
		return tagNodeCompound;
	}

	public virtual bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, _schema).Verify();
	}
}
