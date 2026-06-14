using System;
using System.Collections.Generic;
using Substrate.Nbt;

namespace Substrate.Core;

public class BlockTileEntities
{
	private IDataArray3 _blocks;

	private TagNodeList _tileEntities;

	private Dictionary<BlockKey, TagNodeCompound> _tileEntityTable;

	public event BlockCoordinateHandler TranslateCoordinates;

	public BlockTileEntities(IDataArray3 blocks, TagNodeList tileEntities)
	{
		_blocks = blocks;
		_tileEntities = tileEntities;
		BuildTileEntityCache();
	}

	public BlockTileEntities(BlockTileEntities bte)
	{
		_blocks = bte._blocks;
		_tileEntities = bte._tileEntities;
		BuildTileEntityCache();
	}

	public TileEntity GetTileEntity(int x, int y, int z)
	{
		BlockKey key = ((this.TranslateCoordinates != null) ? this.TranslateCoordinates(x, y, z) : new BlockKey(x, y, z));
		if (!_tileEntityTable.TryGetValue(key, out var value))
		{
			return null;
		}
		return TileEntityFactory.CreateGeneric(value);
	}

	public void SetTileEntity(int x, int y, int z, TileEntity te)
	{
		if (BlockInfo.BlockTable[_blocks[x, y, z]] is BlockInfoEx blockInfoEx && te.GetType() != TileEntityFactory.Lookup(blockInfoEx.TileEntityName))
		{
			throw new ArgumentException("The TileEntity type is not valid for this block.", "te");
		}
		BlockKey key = ((this.TranslateCoordinates != null) ? this.TranslateCoordinates(x, y, z) : new BlockKey(x, y, z));
		if (_tileEntityTable.TryGetValue(key, out var value))
		{
			_tileEntities.Remove(value);
		}
		te.X = key.x;
		te.Y = key.y;
		te.Z = key.z;
		TagNodeCompound tagNodeCompound = te.BuildTree() as TagNodeCompound;
		_tileEntities.Add(tagNodeCompound);
		_tileEntityTable[key] = tagNodeCompound;
	}

	public void CreateTileEntity(int x, int y, int z)
	{
		if (!(BlockInfo.BlockTable[_blocks[x, y, z]] is BlockInfoEx blockInfoEx))
		{
			throw new InvalidOperationException("The given block is of a type that does not support TileEntities.");
		}
		TileEntity tileEntity = TileEntityFactory.Create(blockInfoEx.TileEntityName);
		if (tileEntity == null)
		{
			throw new UnknownTileEntityException("The TileEntity type '" + blockInfoEx.TileEntityName + "' has not been registered with the TileEntityFactory.");
		}
		BlockKey key = ((this.TranslateCoordinates != null) ? this.TranslateCoordinates(x, y, z) : new BlockKey(x, y, z));
		if (_tileEntityTable.TryGetValue(key, out var value))
		{
			_tileEntities.Remove(value);
		}
		tileEntity.X = key.x;
		tileEntity.Y = key.y;
		tileEntity.Z = key.z;
		TagNodeCompound tagNodeCompound = tileEntity.BuildTree() as TagNodeCompound;
		_tileEntities.Add(tagNodeCompound);
		_tileEntityTable[key] = tagNodeCompound;
	}

	public void ClearTileEntity(int x, int y, int z)
	{
		BlockKey key = ((this.TranslateCoordinates != null) ? this.TranslateCoordinates(x, y, z) : new BlockKey(x, y, z));
		if (_tileEntityTable.TryGetValue(key, out var value))
		{
			_tileEntities.Remove(value);
			_tileEntityTable.Remove(key);
		}
	}

	private void BuildTileEntityCache()
	{
		_tileEntityTable = new Dictionary<BlockKey, TagNodeCompound>();
		foreach (TagNodeCompound tileEntity in _tileEntities)
		{
			int x = tileEntity["x"].ToTagInt();
			int y = tileEntity["y"].ToTagInt();
			int z = tileEntity["z"].ToTagInt();
			BlockKey key = new BlockKey(x, y, z);
			_tileEntityTable[key] = tileEntity;
		}
	}
}
