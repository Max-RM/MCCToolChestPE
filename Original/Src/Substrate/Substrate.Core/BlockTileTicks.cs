using System;
using System.Collections.Generic;
using Substrate.Nbt;

namespace Substrate.Core;

public class BlockTileTicks
{
	private IDataArray3 _blocks;

	private TagNodeList _tileTicks;

	private Dictionary<BlockKey, TagNodeCompound> _tileTickTable;

	public event BlockCoordinateHandler TranslateCoordinates;

	public BlockTileTicks(IDataArray3 blocks, TagNodeList tileTicks)
	{
		_blocks = blocks;
		_tileTicks = tileTicks;
		BuildTileTickCache();
	}

	public BlockTileTicks(BlockTileTicks bte)
	{
		_blocks = bte._blocks;
		_tileTicks = bte._tileTicks;
		BuildTileTickCache();
	}

	public int GetTileTickValue(int x, int y, int z)
	{
		BlockKey key = ((this.TranslateCoordinates != null) ? this.TranslateCoordinates(x, y, z) : new BlockKey(x, y, z));
		if (!_tileTickTable.TryGetValue(key, out var value))
		{
			return 0;
		}
		if (!value.ContainsKey("t"))
		{
			return 0;
		}
		return value["t"].ToTagInt().Data;
	}

	public void SetTileTickValue(int x, int y, int z, int tickValue)
	{
		BlockKey key = ((this.TranslateCoordinates != null) ? this.TranslateCoordinates(x, y, z) : new BlockKey(x, y, z));
		if (!_tileTickTable.TryGetValue(key, out var value))
		{
			TileTick tileTick = new TileTick();
			tileTick.ID = _blocks[x, y, z];
			tileTick.Ticks = tickValue;
			tileTick.X = key.x;
			tileTick.Y = key.y;
			tileTick.Z = key.z;
			TileTick tileTick2 = tileTick;
			value = tileTick2.BuildTree() as TagNodeCompound;
			_tileTicks.Add(value);
			_tileTickTable[key] = value;
		}
		else
		{
			value["t"].ToTagInt().Data = tickValue;
		}
	}

	public TileTick GetTileTick(int x, int y, int z)
	{
		BlockKey key = ((this.TranslateCoordinates != null) ? this.TranslateCoordinates(x, y, z) : new BlockKey(x, y, z));
		if (!_tileTickTable.TryGetValue(key, out var value))
		{
			return null;
		}
		if (!value.ContainsKey("i"))
		{
			return null;
		}
		return TileTick.FromTreeSafe(value);
	}

	public void SetTileTick(int x, int y, int z, TileTick te)
	{
		if (te.ID != _blocks[x, y, z])
		{
			throw new ArgumentException("The TileTick type is not valid for this block.", "te");
		}
		BlockKey key = ((this.TranslateCoordinates != null) ? this.TranslateCoordinates(x, y, z) : new BlockKey(x, y, z));
		if (_tileTickTable.TryGetValue(key, out var value))
		{
			_tileTicks.Remove(value);
		}
		te.X = key.x;
		te.Y = key.y;
		te.Z = key.z;
		TagNodeCompound tagNodeCompound = te.BuildTree() as TagNodeCompound;
		_tileTicks.Add(tagNodeCompound);
		_tileTickTable[key] = tagNodeCompound;
	}

	public void CreateTileTick(int x, int y, int z)
	{
		TileTick tileTick = new TileTick();
		tileTick.ID = _blocks[x, y, z];
		TileTick tileTick2 = tileTick;
		BlockKey key = ((this.TranslateCoordinates != null) ? this.TranslateCoordinates(x, y, z) : new BlockKey(x, y, z));
		if (_tileTickTable.TryGetValue(key, out var value))
		{
			_tileTicks.Remove(value);
		}
		tileTick2.X = key.x;
		tileTick2.Y = key.y;
		tileTick2.Z = key.z;
		TagNodeCompound tagNodeCompound = tileTick2.BuildTree() as TagNodeCompound;
		_tileTicks.Add(tagNodeCompound);
		_tileTickTable[key] = tagNodeCompound;
	}

	public void ClearTileTick(int x, int y, int z)
	{
		BlockKey key = ((this.TranslateCoordinates != null) ? this.TranslateCoordinates(x, y, z) : new BlockKey(x, y, z));
		if (_tileTickTable.TryGetValue(key, out var value))
		{
			_tileTicks.Remove(value);
			_tileTickTable.Remove(key);
		}
	}

	private void BuildTileTickCache()
	{
		_tileTickTable = new Dictionary<BlockKey, TagNodeCompound>();
		foreach (TagNodeCompound tileTick in _tileTicks)
		{
			int x = tileTick["x"].ToTagInt();
			int y = tileTick["y"].ToTagInt();
			int z = tileTick["z"].ToTagInt();
			BlockKey key = new BlockKey(x, y, z);
			_tileTickTable[key] = tileTick;
		}
	}
}
