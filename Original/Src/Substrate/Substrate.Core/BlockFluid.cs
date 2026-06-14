using System;
using System.Collections.Generic;

namespace Substrate.Core;

public class BlockFluid
{
	public delegate IBoundedDataBlockCollection NeighborLookupHandler(int relx, int rely, int relz);

	internal class BlockCoord
	{
		internal IBoundedDataBlockCollection chunk;

		internal int lx;

		internal int ly;

		internal int lz;

		internal BlockCoord(IBoundedDataBlockCollection _chunk, int _lx, int _ly, int _lz)
		{
			chunk = _chunk;
			lx = _lx;
			ly = _ly;
			lz = _lz;
		}
	}

	private IBoundedDataBlockCollection _blockset;

	private readonly int _xdim;

	private readonly int _ydim;

	private readonly int _zdim;

	private Dictionary<ChunkKey, IBoundedDataBlockCollection> _chunks;

	public event NeighborLookupHandler ResolveNeighbor;

	public BlockFluid(IBoundedDataBlockCollection blockset)
	{
		_blockset = blockset;
		_xdim = _blockset.XDim;
		_ydim = _blockset.YDim;
		_zdim = _blockset.ZDim;
		_chunks = new Dictionary<ChunkKey, IBoundedDataBlockCollection>();
	}

	public BlockFluid(BlockFluid bl)
	{
		_blockset = bl._blockset;
		_xdim = bl._xdim;
		_ydim = bl._ydim;
		_zdim = bl._zdim;
		_chunks = new Dictionary<ChunkKey, IBoundedDataBlockCollection>();
	}

	public void ResetWater(IDataArray blocks, IDataArray data)
	{
		for (int i = 0; i < blocks.Length; i++)
		{
			if ((blocks[i] == BlockInfo.StationaryWater.ID || blocks[i] == BlockInfo.Water.ID) && data[i] != 0)
			{
				blocks[i] = (byte)BlockInfo.Air.ID;
				data[i] = 0;
			}
			else if (blocks[i] == BlockInfo.Water.ID)
			{
				blocks[i] = (byte)BlockInfo.StationaryWater.ID;
			}
		}
	}

	public void ResetLava(IDataArray blocks, IDataArray data)
	{
		for (int i = 0; i < blocks.Length; i++)
		{
			if ((blocks[i] == BlockInfo.StationaryLava.ID || blocks[i] == BlockInfo.Lava.ID) && data[i] != 0)
			{
				blocks[i] = (byte)BlockInfo.Air.ID;
				data[i] = 0;
			}
			else if (blocks[i] == BlockInfo.Lava.ID)
			{
				blocks[i] = (byte)BlockInfo.StationaryLava.ID;
			}
		}
	}

	public void UpdateWater(int x, int y, int z)
	{
		DoWater(x, y, z);
		_chunks.Clear();
	}

	public void UpdateLava(int x, int y, int z)
	{
		DoLava(x, y, z);
		_chunks.Clear();
	}

	public void RebuildWater()
	{
		int xdim = _xdim;
		int ydim = _ydim;
		int zdim = _zdim;
		List<BlockKey> list = new List<BlockKey>();
		for (int i = 0; i < xdim; i++)
		{
			for (int j = 0; j < zdim; j++)
			{
				for (int k = 0; k < ydim; k++)
				{
					BlockInfo info = _blockset.GetInfo(i, k, j);
					if (info.ID == BlockInfo.StationaryWater.ID && _blockset.GetData(i, k, j) == 0)
					{
						list.Add(new BlockKey(i, k, j));
					}
				}
			}
		}
		foreach (BlockKey item in list)
		{
			DoWater(item.x, item.y, item.z);
		}
		_chunks.Clear();
	}

	public void RebuildLava()
	{
		int xdim = _xdim;
		int ydim = _ydim;
		int zdim = _zdim;
		List<BlockKey> list = new List<BlockKey>();
		for (int i = 0; i < xdim; i++)
		{
			for (int j = 0; j < zdim; j++)
			{
				for (int k = 0; k < ydim; k++)
				{
					BlockInfo info = _blockset.GetInfo(i, k, j);
					if (info.ID == BlockInfo.StationaryLava.ID && _blockset.GetData(i, k, j) == 0)
					{
						list.Add(new BlockKey(i, k, j));
					}
				}
			}
		}
		foreach (BlockKey item in list)
		{
			DoLava(item.x, item.y, item.z);
		}
		_chunks.Clear();
	}

	private BlockCoord TranslateCoord(int x, int y, int z)
	{
		IBoundedDataBlockCollection chunk = GetChunk(x, z);
		int lx = (x % _xdim + _xdim) % _xdim;
		int lz = (z % _zdim + _zdim) % _zdim;
		return new BlockCoord(chunk, lx, y, lz);
	}

	private IBoundedDataBlockCollection GetChunk(int x, int z)
	{
		int num = x / _xdim + (x >> 31);
		int num2 = z / _zdim + (z >> 31);
		ChunkKey key = new ChunkKey(num, num2);
		if (!_chunks.TryGetValue(key, out var value))
		{
			value = OnResolveNeighbor(num, 0, num2);
			_chunks[key] = value;
		}
		return value;
	}

	private IBoundedDataBlockCollection OnResolveNeighbor(int relX, int relY, int relZ)
	{
		if (this.ResolveNeighbor != null)
		{
			IBoundedDataBlockCollection boundedDataBlockCollection = this.ResolveNeighbor(relX, relY, relZ);
			if (boundedDataBlockCollection == null)
			{
				return null;
			}
			if (boundedDataBlockCollection.XDim != _xdim || boundedDataBlockCollection.YDim != _ydim || boundedDataBlockCollection.ZDim != _zdim)
			{
				throw new InvalidOperationException("Subscriber returned incompatible IDataBlockCollection");
			}
			return boundedDataBlockCollection;
		}
		return null;
	}

	private List<BlockKey> TileOutflow(BlockKey key, int reach = 5)
	{
		Queue<BlockKey> queue = new Queue<BlockKey>();
		Queue<KeyValuePair<BlockKey, int>> queue2 = new Queue<KeyValuePair<BlockKey, int>>();
		Dictionary<BlockKey, int> dictionary = new Dictionary<BlockKey, int>();
		queue.Enqueue(key);
		dictionary.Add(key, 0);
		while (queue.Count > 0)
		{
			BlockKey blockKey = queue.Dequeue();
			int num = dictionary[blockKey];
			if (num > reach)
			{
				continue;
			}
			BlockCoord blockCoord = TranslateCoord(blockKey.x, blockKey.y, blockKey.z);
			if (blockCoord.chunk == null || blockKey.y == 0)
			{
				dictionary.Remove(blockKey);
				continue;
			}
			if (num > 0)
			{
				BlockInfo info = blockCoord.chunk.GetInfo(blockCoord.lx, blockCoord.ly, blockCoord.lz);
				if (info.BlocksFluid)
				{
					dictionary.Remove(blockKey);
					continue;
				}
			}
			BlockCoord blockCoord2 = TranslateCoord(blockKey.x, blockKey.y - 1, blockKey.z);
			BlockInfo info2 = blockCoord2.chunk.GetInfo(blockCoord2.lx, blockCoord2.ly, blockCoord2.lz);
			if (!info2.BlocksFluid)
			{
				if (key == blockKey)
				{
					List<BlockKey> list = new List<BlockKey>();
					list.Add(new BlockKey(blockKey.x, blockKey.y - 1, blockKey.z));
					return list;
				}
				reach = num;
				queue2.Enqueue(new KeyValuePair<BlockKey, int>(blockKey, num));
			}
			else
			{
				if (num >= reach)
				{
					continue;
				}
				BlockKey[] array = new BlockKey[4]
				{
					new BlockKey(blockKey.x - 1, blockKey.y, blockKey.z),
					new BlockKey(blockKey.x + 1, blockKey.y, blockKey.z),
					new BlockKey(blockKey.x, blockKey.y, blockKey.z - 1),
					new BlockKey(blockKey.x, blockKey.y, blockKey.z + 1)
				};
				for (int i = 0; i < 4; i++)
				{
					if (!dictionary.ContainsKey(array[i]))
					{
						queue.Enqueue(array[i]);
						dictionary.Add(array[i], num + 1);
					}
				}
			}
		}
		BlockKey[] array2 = new BlockKey[4]
		{
			new BlockKey(key.x - 1, key.y, key.z),
			new BlockKey(key.x + 1, key.y, key.z),
			new BlockKey(key.x, key.y, key.z - 1),
			new BlockKey(key.x, key.y, key.z + 1)
		};
		List<BlockKey> list2 = new List<BlockKey>();
		BlockKey[] array3 = array2;
		foreach (BlockKey blockKey2 in array3)
		{
			if (dictionary.ContainsKey(blockKey2))
			{
				list2.Add(blockKey2);
			}
		}
		if (queue2.Count == 0)
		{
			return list2;
		}
		while (queue2.Count > 0)
		{
			KeyValuePair<BlockKey, int> keyValuePair = queue2.Dequeue();
			BlockKey key2 = keyValuePair.Key;
			int value = keyValuePair.Value;
			dictionary.Remove(key2);
			BlockKey[] array4 = new BlockKey[4]
			{
				new BlockKey(key2.x - 1, key2.y, key2.z),
				new BlockKey(key2.x + 1, key2.y, key2.z),
				new BlockKey(key2.x, key2.y, key2.z - 1),
				new BlockKey(key2.x, key2.y, key2.z + 1)
			};
			for (int k = 0; k < 4; k++)
			{
				if (dictionary.TryGetValue(array4[k], out var value2) && value2 < value)
				{
					dictionary.Remove(array4[k]);
					queue2.Enqueue(new KeyValuePair<BlockKey, int>(array4[k], value2));
				}
			}
		}
		BlockKey[] array5 = array2;
		foreach (BlockKey blockKey3 in array5)
		{
			if (dictionary.ContainsKey(blockKey3))
			{
				list2.Remove(blockKey3);
			}
		}
		return list2;
	}

	private int TileInflow(BlockKey key)
	{
		if (key.y < _ydim - 1)
		{
			BlockCoord blockCoord = TranslateCoord(key.x, key.y + 1, key.z);
			BlockInfo info = blockCoord.chunk.GetInfo(blockCoord.lx, blockCoord.ly, blockCoord.lz);
			if (info.State == BlockState.FLUID)
			{
				return blockCoord.chunk.GetData(blockCoord.lx, blockCoord.ly, blockCoord.lz) | 8;
			}
		}
		BlockKey[] array = new BlockKey[4]
		{
			new BlockKey(key.x - 1, key.y, key.z),
			new BlockKey(key.x + 1, key.y, key.z),
			new BlockKey(key.x, key.y, key.z - 1),
			new BlockKey(key.x, key.y, key.z + 1)
		};
		int num = 16;
		for (int i = 0; i < 4; i++)
		{
			BlockCoord blockCoord2 = TranslateCoord(array[i].x, array[i].y, array[i].z);
			if (blockCoord2.chunk == null)
			{
				continue;
			}
			BlockInfo info2 = blockCoord2.chunk.GetInfo(blockCoord2.lx, blockCoord2.ly, blockCoord2.lz);
			if (info2.State != BlockState.FLUID)
			{
				continue;
			}
			int data = blockCoord2.chunk.GetData(blockCoord2.lx, blockCoord2.ly, blockCoord2.lz);
			if ((data & 8) != 0)
			{
				if (array[i].y != 0)
				{
					BlockCoord blockCoord3 = TranslateCoord(array[i].x, array[i].y - 1, array[i].z);
					BlockInfo info3 = blockCoord3.chunk.GetInfo(blockCoord3.lx, blockCoord3.ly, blockCoord3.lz);
					if (info3.BlocksFluid)
					{
						return 0;
					}
				}
			}
			else if (data < num)
			{
				num = data;
			}
		}
		return num;
	}

	private void DoWater(int x, int y, int z)
	{
		Queue<BlockKey> queue = new Queue<BlockKey>();
		BlockKey blockKey = new BlockKey(x, y, z);
		queue.Enqueue(blockKey);
		List<BlockKey> list = TileOutflow(blockKey);
		foreach (BlockKey item in list)
		{
			queue.Enqueue(item);
		}
		while (queue.Count > 0)
		{
			BlockKey key = queue.Dequeue();
			int num = 16;
			int num2 = TileInflow(key);
			BlockCoord blockCoord = TranslateCoord(key.x, key.y, key.z);
			BlockInfo info = blockCoord.chunk.GetInfo(blockCoord.lx, blockCoord.ly, blockCoord.lz);
			if (info.ID == BlockInfo.StationaryWater.ID || info.ID == BlockInfo.Water.ID)
			{
				num = blockCoord.chunk.GetData(blockCoord.lx, blockCoord.ly, blockCoord.lz);
			}
			else if (info.BlocksFluid)
			{
				continue;
			}
			bool flag = (num & 8) != 0;
			bool flag2 = (num2 & 8) != 0;
			if (num == 0 || num == num2 || flag)
			{
				continue;
			}
			int num3 = num;
			num3 = (flag2 ? num2 : ((num2 < 7) ? (num2 + 1) : 16));
			if (num3 == num)
			{
				continue;
			}
			if (num3 < 16 && num == 16)
			{
				if ((info.ID == BlockInfo.StationaryLava.ID || info.ID == BlockInfo.Lava.ID) && (num3 & 8) != 0)
				{
					if (blockCoord.chunk.GetData(blockCoord.lx, blockCoord.ly, blockCoord.lz) == 0)
					{
						blockCoord.chunk.SetID(blockCoord.lx, blockCoord.ly, blockCoord.lz, BlockInfo.Obsidian.ID);
					}
					else
					{
						blockCoord.chunk.SetID(blockCoord.lx, blockCoord.ly, blockCoord.lz, BlockInfo.Cobblestone.ID);
					}
					blockCoord.chunk.SetData(blockCoord.lx, blockCoord.ly, blockCoord.lz, 0);
					continue;
				}
				blockCoord.chunk.SetID(blockCoord.lx, blockCoord.ly, blockCoord.lz, BlockInfo.StationaryWater.ID);
				blockCoord.chunk.SetData(blockCoord.lx, blockCoord.ly, blockCoord.lz, num3);
			}
			else if (num3 == 16)
			{
				blockCoord.chunk.SetID(blockCoord.lx, blockCoord.ly, blockCoord.lz, BlockInfo.Air.ID);
				blockCoord.chunk.SetData(blockCoord.lx, blockCoord.ly, blockCoord.lz, 0);
			}
			else
			{
				blockCoord.chunk.SetData(blockCoord.lx, blockCoord.ly, blockCoord.lz, num3);
			}
			list = TileOutflow(key);
			foreach (BlockKey item2 in list)
			{
				queue.Enqueue(item2);
			}
		}
	}

	private void DoLava(int x, int y, int z)
	{
		Queue<BlockKey> queue = new Queue<BlockKey>();
		BlockKey blockKey = new BlockKey(x, y, z);
		queue.Enqueue(blockKey);
		List<BlockKey> list = TileOutflow(blockKey);
		foreach (BlockKey item in list)
		{
			queue.Enqueue(item);
		}
		while (queue.Count > 0)
		{
			BlockKey key = queue.Dequeue();
			int num = 16;
			int num2 = TileInflow(key);
			BlockCoord blockCoord = TranslateCoord(key.x, key.y, key.z);
			BlockInfo info = blockCoord.chunk.GetInfo(blockCoord.lx, blockCoord.ly, blockCoord.lz);
			if (info.ID == BlockInfo.StationaryLava.ID || info.ID == BlockInfo.Lava.ID)
			{
				num = blockCoord.chunk.GetData(blockCoord.lx, blockCoord.ly, blockCoord.lz);
			}
			else if (info.BlocksFluid)
			{
				continue;
			}
			bool flag = (num & 8) != 0;
			bool flag2 = (num2 & 8) != 0;
			if (num == 0 || num == num2 || flag)
			{
				continue;
			}
			int num3 = num;
			num3 = (flag2 ? num2 : ((num2 < 6) ? (num2 + 2) : 16));
			if (num3 == num)
			{
				continue;
			}
			if (num3 < 16 && num == 16)
			{
				if ((info.ID == BlockInfo.StationaryWater.ID || info.ID == BlockInfo.Water.ID) && (num3 & 8) == 0)
				{
					blockCoord.chunk.SetID(blockCoord.lx, blockCoord.ly, blockCoord.lz, BlockInfo.Cobblestone.ID);
					blockCoord.chunk.SetData(blockCoord.lx, blockCoord.ly, blockCoord.lz, 0);
					continue;
				}
				blockCoord.chunk.SetID(blockCoord.lx, blockCoord.ly, blockCoord.lz, BlockInfo.StationaryLava.ID);
				blockCoord.chunk.SetData(blockCoord.lx, blockCoord.ly, blockCoord.lz, num3);
			}
			else if (num3 == 16)
			{
				blockCoord.chunk.SetID(blockCoord.lx, blockCoord.ly, blockCoord.lz, BlockInfo.Air.ID);
				blockCoord.chunk.SetData(blockCoord.lx, blockCoord.ly, blockCoord.lz, 0);
			}
			else
			{
				blockCoord.chunk.SetData(blockCoord.lx, blockCoord.ly, blockCoord.lz, num3);
			}
			list = TileOutflow(key);
			foreach (BlockKey item2 in list)
			{
				queue.Enqueue(item2);
			}
		}
	}
}
