using System;
using System.Collections;
using System.Collections.Generic;

namespace Substrate.Core;

public class BlockLight
{
	private struct LightRecord(int _x, int _y, int _z, int s)
	{
		public int x = _x;

		public int y = _y;

		public int z = _z;

		public int str = s;
	}

	public delegate IBoundedLitBlockCollection NeighborLookupHandler(int relx, int rely, int relz);

	private readonly int _xdim;

	private readonly int _ydim;

	private readonly int _zdim;

	private IBoundedLitBlockCollection _blockset;

	private BitArray _lightbit;

	private Queue<BlockKey> _update;

	public event NeighborLookupHandler ResolveNeighbor;

	public BlockLight(IBoundedLitBlockCollection blockset)
	{
		_blockset = blockset;
		_xdim = _blockset.XDim;
		_ydim = _blockset.YDim;
		_zdim = _blockset.ZDim;
		_lightbit = new BitArray(_blockset.XDim * 3 * _blockset.ZDim * 3 * _blockset.YDim);
		_update = new Queue<BlockKey>();
	}

	public BlockLight(BlockLight bl)
	{
		_blockset = bl._blockset;
		_xdim = bl._xdim;
		_ydim = bl._ydim;
		_zdim = bl._zdim;
		_lightbit = new BitArray(_blockset.XDim * 3 * _blockset.ZDim * 3 * _blockset.YDim);
		_update = new Queue<BlockKey>();
	}

	public void UpdateBlockLight(int lx, int ly, int lz)
	{
		BlockKey item = new BlockKey(lx, ly, lz);
		_update.Enqueue(item);
		if (ly > 0)
		{
			QueueRelight(new BlockKey(lx, ly - 1, lz));
		}
		if (ly < _ydim - 1)
		{
			QueueRelight(new BlockKey(lx, ly + 1, lz));
		}
		QueueRelight(new BlockKey(lx - 1, ly, lz));
		QueueRelight(new BlockKey(lx + 1, ly, lz));
		QueueRelight(new BlockKey(lx, ly, lz - 1));
		QueueRelight(new BlockKey(lx, ly, lz + 1));
		UpdateBlockLight();
	}

	public void UpdateBlockSkyLight(int lx, int ly, int lz)
	{
		BlockKey item = new BlockKey(lx, ly, lz);
		_update.Enqueue(item);
		UpdateBlockSkyLight();
	}

	public void UpdateHeightMap(int lx, int ly, int lz)
	{
		BlockInfo info = _blockset.GetInfo(lx, ly, lz);
		int num = Math.Min(ly + 1, _ydim - 1);
		int height = _blockset.GetHeight(lx, lz);
		if (num < height)
		{
			return;
		}
		if (num == height && !info.ObscuresLight)
		{
			for (int num2 = ly - 1; num2 >= 0; num2--)
			{
				BlockInfo info2 = _blockset.GetInfo(lx, num2, lz);
				if (info2.ObscuresLight)
				{
					_blockset.SetHeight(lx, lz, Math.Min(num2 + 1, _ydim - 1));
					break;
				}
			}
			UpdateBlockSkyLight(lx, num, lz);
		}
		else if (num > height && info.ObscuresLight)
		{
			_blockset.SetHeight(lx, lz, num);
			UpdateBlockSkyLight(lx, num, lz);
		}
	}

	public void RebuildBlockLight()
	{
		IBoundedLitBlockCollection[,] chunkMap = LocalBlockLightMap();
		int xdim = _xdim;
		int ydim = _ydim;
		int zdim = _zdim;
		for (int i = 0; i < xdim; i++)
		{
			for (int j = 0; j < zdim; j++)
			{
				for (int k = 0; k < ydim; k++)
				{
					BlockInfo info = _blockset.GetInfo(i, k, j);
					if (info.Luminance > 0)
					{
						SpreadBlockLight(chunkMap, i, k, j);
					}
				}
			}
		}
	}

	public void RebuildBlockSkyLight()
	{
		IBoundedLitBlockCollection[,] chunkMap = LocalBlockLightMap();
		int[,] array = LocalHeightMap(chunkMap);
		int xdim = _xdim;
		int ydim = _ydim;
		int zdim = _zdim;
		for (int i = 0; i < xdim; i++)
		{
			for (int j = 0; j < zdim; j++)
			{
				int num = i + xdim;
				int num2 = j + zdim;
				int val = array[num, num2];
				val = Math.Max(val, array[num, num2 - 1]);
				val = Math.Max(val, array[num - 1, num2]);
				val = Math.Max(val, array[num + 1, num2]);
				val = Math.Max(val, array[num, num2 + 1]);
				for (int k = val + 1; k < ydim; k++)
				{
					_blockset.SetSkyLight(i, k, j, 15);
				}
				SpreadSkyLight(chunkMap, array, i, val, j);
			}
		}
	}

	public void RebuildHeightMap()
	{
		int xdim = _xdim;
		int ydim = _ydim;
		int zdim = _zdim;
		for (int i = 0; i < xdim; i++)
		{
			for (int j = 0; j < zdim; j++)
			{
				for (int num = ydim - 1; num >= 0; num--)
				{
					BlockInfo info = _blockset.GetInfo(i, num, j);
					if (info.ObscuresLight)
					{
						_blockset.SetHeight(i, j, Math.Min(num + 1, ydim - 1));
						break;
					}
				}
			}
		}
	}

	public void StitchBlockLight()
	{
		IBoundedLitBlockCollection[,] array = LocalBlockLightMap();
		if (array[1, 0] != null)
		{
			StitchBlockLight(array[1, 0], BlockCollectionEdge.EAST);
		}
		if (array[0, 1] != null)
		{
			StitchBlockLight(array[0, 1], BlockCollectionEdge.NORTH);
		}
		if (array[1, 2] != null)
		{
			StitchBlockLight(array[1, 2], BlockCollectionEdge.WEST);
		}
		if (array[2, 1] != null)
		{
			StitchBlockLight(array[2, 1], BlockCollectionEdge.SOUTH);
		}
	}

	public void StitchBlockLight(IBoundedLitBlockCollection chunk, BlockCollectionEdge edge)
	{
		int xdim = _xdim;
		int ydim = _ydim;
		int zdim = _zdim;
		if (chunk.XDim != xdim || chunk.YDim != ydim || chunk.ZDim != zdim)
		{
			throw new InvalidOperationException("BlockLight must have same dimensions to be stitched");
		}
		switch (edge)
		{
		case BlockCollectionEdge.EAST:
		{
			for (int num = 0; num < xdim; num++)
			{
				for (int num2 = 0; num2 < ydim; num2++)
				{
					TestBlockLight(chunk, num, num2, 0, num, num2, zdim - 1);
				}
			}
			break;
		}
		case BlockCollectionEdge.NORTH:
		{
			for (int k = 0; k < zdim; k++)
			{
				for (int l = 0; l < ydim; l++)
				{
					TestBlockLight(chunk, 0, l, k, xdim - 1, l, k);
				}
			}
			break;
		}
		case BlockCollectionEdge.WEST:
		{
			for (int m = 0; m < xdim; m++)
			{
				for (int n = 0; n < ydim; n++)
				{
					TestBlockLight(chunk, m, n, zdim - 1, m, n, 0);
				}
			}
			break;
		}
		case BlockCollectionEdge.SOUTH:
		{
			for (int i = 0; i < zdim; i++)
			{
				for (int j = 0; j < ydim; j++)
				{
					TestBlockLight(chunk, xdim - 1, j, i, 0, j, i);
				}
			}
			break;
		}
		}
		UpdateBlockLight();
	}

	public void StitchBlockSkyLight()
	{
		IBoundedLitBlockCollection[,] array = LocalBlockLightMap();
		if (array[1, 0] != null)
		{
			StitchBlockSkyLight(array[1, 0], BlockCollectionEdge.EAST);
		}
		if (array[0, 1] != null)
		{
			StitchBlockSkyLight(array[0, 1], BlockCollectionEdge.NORTH);
		}
		if (array[1, 2] != null)
		{
			StitchBlockSkyLight(array[1, 2], BlockCollectionEdge.WEST);
		}
		if (array[2, 1] != null)
		{
			StitchBlockSkyLight(array[2, 1], BlockCollectionEdge.SOUTH);
		}
	}

	public void StitchBlockSkyLight(IBoundedLitBlockCollection chunk, BlockCollectionEdge edge)
	{
		int xdim = _xdim;
		int ydim = _ydim;
		int zdim = _zdim;
		if (chunk.XDim != xdim || chunk.YDim != ydim || chunk.ZDim != zdim)
		{
			throw new InvalidOperationException("BlockLight must have same dimensions to be stitched");
		}
		switch (edge)
		{
		case BlockCollectionEdge.EAST:
		{
			for (int num = 0; num < xdim; num++)
			{
				for (int num2 = 0; num2 < ydim; num2++)
				{
					TestSkyLight(chunk, num, num2, 0, num, num2, zdim - 1);
				}
			}
			break;
		}
		case BlockCollectionEdge.NORTH:
		{
			for (int k = 0; k < zdim; k++)
			{
				for (int l = 0; l < ydim; l++)
				{
					TestSkyLight(chunk, 0, l, k, xdim - 1, l, k);
				}
			}
			break;
		}
		case BlockCollectionEdge.WEST:
		{
			for (int m = 0; m < xdim; m++)
			{
				for (int n = 0; n < ydim; n++)
				{
					TestSkyLight(chunk, m, n, zdim - 1, m, n, 0);
				}
			}
			break;
		}
		case BlockCollectionEdge.SOUTH:
		{
			for (int i = 0; i < zdim; i++)
			{
				for (int j = 0; j < ydim; j++)
				{
					TestSkyLight(chunk, xdim - 1, j, i, 0, j, i);
				}
			}
			break;
		}
		}
		UpdateBlockSkyLight();
	}

	private void UpdateBlockLight()
	{
		IBoundedLitBlockCollection[,] array = LocalBlockLightMap();
		int xdim = _xdim;
		int ydim = _ydim;
		int zdim = _zdim;
		while (_update.Count > 0)
		{
			BlockKey key = _update.Dequeue();
			int index = LightBitmapIndex(key);
			_lightbit[index] = false;
			int num = key.x + xdim;
			int num2 = key.z + zdim;
			IBoundedLitBlockCollection boundedLitBlockCollection = array[num / xdim, num2 / zdim];
			if (boundedLitBlockCollection == null)
			{
				continue;
			}
			int val = NeighborLight(array, key.x, key.y, key.z - 1);
			int val2 = NeighborLight(array, key.x - 1, key.y, key.z);
			int val3 = NeighborLight(array, key.x, key.y, key.z + 1);
			int val4 = NeighborLight(array, key.x + 1, key.y, key.z);
			int val5 = NeighborLight(array, key.x, key.y - 1, key.z);
			int val6 = NeighborLight(array, key.x, key.y + 1, key.z);
			int x = num % xdim;
			int y = key.y;
			int z = num2 % zdim;
			int blockLight = boundedLitBlockCollection.GetBlockLight(x, y, z);
			BlockInfo info = boundedLitBlockCollection.GetInfo(x, y, z);
			int val7 = Math.Max(info.Luminance, 0);
			val7 = Math.Max(val7, val);
			val7 = Math.Max(val7, val2);
			val7 = Math.Max(val7, val3);
			val7 = Math.Max(val7, val4);
			val7 = Math.Max(val7, val5);
			val7 = Math.Max(val7, val6);
			val7 = Math.Max(val7 - info.Opacity, 0);
			if (val7 == blockLight)
			{
				continue;
			}
			boundedLitBlockCollection.SetBlockLight(x, y, z, val7);
			if (info.TransmitsLight)
			{
				if (key.y > 0)
				{
					QueueRelight(new BlockKey(key.x, key.y - 1, key.z));
				}
				if (key.y < ydim - 1)
				{
					QueueRelight(new BlockKey(key.x, key.y + 1, key.z));
				}
				QueueRelight(new BlockKey(key.x - 1, key.y, key.z));
				QueueRelight(new BlockKey(key.x + 1, key.y, key.z));
				QueueRelight(new BlockKey(key.x, key.y, key.z - 1));
				QueueRelight(new BlockKey(key.x, key.y, key.z + 1));
			}
		}
	}

	private void UpdateBlockSkyLight()
	{
		IBoundedLitBlockCollection[,] array = LocalBlockLightMap();
		int xdim = _xdim;
		int ydim = _ydim;
		int zdim = _zdim;
		while (_update.Count > 0)
		{
			BlockKey key = _update.Dequeue();
			int index = LightBitmapIndex(key);
			_lightbit[index] = false;
			int num = key.x + xdim;
			int num2 = key.z + zdim;
			IBoundedLitBlockCollection boundedLitBlockCollection = array[num / xdim, num2 / zdim];
			if (boundedLitBlockCollection == null)
			{
				continue;
			}
			int x = num % xdim;
			int y = key.y;
			int z = num2 % zdim;
			int skyLight = boundedLitBlockCollection.GetSkyLight(x, y, z);
			BlockInfo info = boundedLitBlockCollection.GetInfo(x, y, z);
			int val = 0;
			if (boundedLitBlockCollection.GetHeight(x, z) <= y)
			{
				val = 15;
			}
			else
			{
				int val2 = NeighborSkyLight(array, key.x, key.y, key.z - 1);
				int val3 = NeighborSkyLight(array, key.x - 1, key.y, key.z);
				int val4 = NeighborSkyLight(array, key.x, key.y, key.z + 1);
				int val5 = NeighborSkyLight(array, key.x + 1, key.y, key.z);
				int val6 = NeighborSkyLight(array, key.x, key.y - 1, key.z);
				int val7 = NeighborSkyLight(array, key.x, key.y + 1, key.z);
				val = Math.Max(val, val2);
				val = Math.Max(val, val3);
				val = Math.Max(val, val4);
				val = Math.Max(val, val5);
				val = Math.Max(val, val6);
				val = Math.Max(val, val7);
			}
			val = Math.Max(val - info.Opacity, 0);
			if (val == skyLight)
			{
				continue;
			}
			boundedLitBlockCollection.SetSkyLight(x, y, z, val);
			if (info.TransmitsLight)
			{
				if (key.y > 0)
				{
					QueueRelight(new BlockKey(key.x, key.y - 1, key.z));
				}
				if (key.y < ydim - 1)
				{
					QueueRelight(new BlockKey(key.x, key.y + 1, key.z));
				}
				QueueRelight(new BlockKey(key.x - 1, key.y, key.z));
				QueueRelight(new BlockKey(key.x + 1, key.y, key.z));
				QueueRelight(new BlockKey(key.x, key.y, key.z - 1));
				QueueRelight(new BlockKey(key.x, key.y, key.z + 1));
			}
		}
	}

	private void SpreadBlockLight(IBoundedLitBlockCollection[,] chunkMap, int lx, int ly, int lz)
	{
		BlockInfo info = _blockset.GetInfo(lx, ly, lz);
		int blockLight = _blockset.GetBlockLight(lx, ly, lz);
		int num = Math.Max(info.Luminance - info.Opacity, 0);
		if (blockLight < num)
		{
			_blockset.SetBlockLight(lx, ly, lz, num);
		}
		if (blockLight > info.Luminance - 1 && !info.TransmitsLight)
		{
			return;
		}
		int xdim = _xdim;
		int ydim = _ydim;
		int zdim = _zdim;
		Queue<LightRecord> queue = new Queue<LightRecord>();
		if (ly > 0)
		{
			queue.Enqueue(new LightRecord(lx, ly - 1, lz, info.Luminance - 1));
		}
		if (ly < ydim - 1)
		{
			queue.Enqueue(new LightRecord(lx, ly + 1, lz, info.Luminance - 1));
		}
		queue.Enqueue(new LightRecord(lx - 1, ly, lz, info.Luminance - 1));
		queue.Enqueue(new LightRecord(lx + 1, ly, lz, info.Luminance - 1));
		queue.Enqueue(new LightRecord(lx, ly, lz - 1, info.Luminance - 1));
		queue.Enqueue(new LightRecord(lx, ly, lz + 1, info.Luminance - 1));
		while (queue.Count > 0)
		{
			LightRecord lightRecord = queue.Dequeue();
			int num2 = lightRecord.x + xdim;
			int num3 = lightRecord.z + zdim;
			IBoundedLitBlockCollection boundedLitBlockCollection = chunkMap[num2 / xdim, num3 / zdim];
			if (boundedLitBlockCollection == null)
			{
				continue;
			}
			int x = num2 % xdim;
			int y = lightRecord.y;
			int z = num3 % zdim;
			BlockInfo info2 = boundedLitBlockCollection.GetInfo(x, y, z);
			int blockLight2 = boundedLitBlockCollection.GetBlockLight(x, y, z);
			int num4 = Math.Max(lightRecord.str - info2.Opacity, 0);
			if (num4 <= blockLight2)
			{
				continue;
			}
			boundedLitBlockCollection.SetBlockLight(x, y, z, num4);
			if (info2.TransmitsLight)
			{
				int s = ((info2.Opacity > 0) ? num4 : (num4 - 1));
				if (lightRecord.y > 0)
				{
					queue.Enqueue(new LightRecord(lightRecord.x, lightRecord.y - 1, lightRecord.z, s));
				}
				if (lightRecord.y < ydim - 1)
				{
					queue.Enqueue(new LightRecord(lightRecord.x, lightRecord.y + 1, lightRecord.z, s));
				}
				queue.Enqueue(new LightRecord(lightRecord.x - 1, lightRecord.y, lightRecord.z, s));
				queue.Enqueue(new LightRecord(lightRecord.x + 1, lightRecord.y, lightRecord.z, s));
				queue.Enqueue(new LightRecord(lightRecord.x, lightRecord.y, lightRecord.z - 1, s));
				queue.Enqueue(new LightRecord(lightRecord.x, lightRecord.y, lightRecord.z + 1, s));
			}
		}
	}

	private void SpreadSkyLight(IBoundedLitBlockCollection[,] chunkMap, int[,] heightMap, int lx, int ly, int lz)
	{
		BlockInfo info = _blockset.GetInfo(lx, ly, lz);
		int skyLight = _blockset.GetSkyLight(lx, ly, lz);
		int num = Math.Max(15 - info.Opacity, 0);
		if (skyLight < num)
		{
			_blockset.SetSkyLight(lx, ly, lz, num);
		}
		if (skyLight > 14 || !info.TransmitsLight)
		{
			return;
		}
		Queue<LightRecord> queue = new Queue<LightRecord>();
		int xdim = _xdim;
		int ydim = _ydim;
		int zdim = _zdim;
		int num2 = lx + xdim;
		int num3 = lz + zdim;
		int s = ((info.Opacity > 0) ? num : (num - 1));
		if (ly > 0)
		{
			if (heightMap[num2, num3] > ly - 1)
			{
				queue.Enqueue(new LightRecord(lx, ly - 1, lz, s));
			}
			else
			{
				queue.Enqueue(new LightRecord(lx, ly - 1, lz, num));
			}
		}
		if (ly < ydim - 1 && heightMap[num2, num3] > ly + 1)
		{
			queue.Enqueue(new LightRecord(lx, ly + 1, lz, s));
		}
		if (heightMap[num2 - 1, num3] > ly)
		{
			queue.Enqueue(new LightRecord(lx - 1, ly, lz, s));
		}
		if (heightMap[num2 + 1, num3] > ly)
		{
			queue.Enqueue(new LightRecord(lx + 1, ly, lz, s));
		}
		if (heightMap[num2, num3 - 1] > ly)
		{
			queue.Enqueue(new LightRecord(lx, ly, lz - 1, s));
		}
		if (heightMap[num2, num3 + 1] > ly)
		{
			queue.Enqueue(new LightRecord(lx, ly, lz + 1, s));
		}
		while (queue.Count > 0)
		{
			LightRecord lightRecord = queue.Dequeue();
			int num4 = lightRecord.x + xdim;
			int num5 = lightRecord.z + zdim;
			IBoundedLitBlockCollection boundedLitBlockCollection = chunkMap[num4 / xdim, num5 / zdim];
			if (boundedLitBlockCollection == null)
			{
				continue;
			}
			int x = num4 % xdim;
			int y = lightRecord.y;
			int z = num5 % zdim;
			BlockInfo info2 = boundedLitBlockCollection.GetInfo(x, y, z);
			int skyLight2 = boundedLitBlockCollection.GetSkyLight(x, y, z);
			int num6 = Math.Max(lightRecord.str - info2.Opacity, 0);
			if (num6 <= skyLight2)
			{
				continue;
			}
			boundedLitBlockCollection.SetSkyLight(x, y, z, num6);
			if (!info2.TransmitsLight)
			{
				continue;
			}
			s = ((info2.Opacity > 0) ? num6 : (num6 - 1));
			if (lightRecord.y > 0)
			{
				if (heightMap[num4, num5] > lightRecord.y - 1)
				{
					queue.Enqueue(new LightRecord(lightRecord.x, lightRecord.y - 1, lightRecord.z, s));
				}
				else
				{
					queue.Enqueue(new LightRecord(lightRecord.x, lightRecord.y - 1, lightRecord.z, num6));
				}
			}
			if (lightRecord.y < ydim - 1 && heightMap[num4, num5] > lightRecord.y + 1)
			{
				queue.Enqueue(new LightRecord(lightRecord.x, lightRecord.y + 1, lightRecord.z, s));
			}
			if (heightMap[num4 - 1, num5] > lightRecord.y)
			{
				queue.Enqueue(new LightRecord(lightRecord.x - 1, lightRecord.y, lightRecord.z, s));
			}
			if (heightMap[num4 + 1, num5] > lightRecord.y)
			{
				queue.Enqueue(new LightRecord(lightRecord.x + 1, lightRecord.y, lightRecord.z, s));
			}
			if (heightMap[num4, num5 - 1] > lightRecord.y)
			{
				queue.Enqueue(new LightRecord(lightRecord.x, lightRecord.y, lightRecord.z - 1, s));
			}
			if (heightMap[num4, num5 + 1] > lightRecord.y)
			{
				queue.Enqueue(new LightRecord(lightRecord.x, lightRecord.y, lightRecord.z + 1, s));
			}
		}
	}

	private int LightBitmapIndex(BlockKey key)
	{
		int num = key.x + _xdim;
		int y = key.y;
		int num2 = key.z + _zdim;
		int ydim = _ydim;
		int num3 = _zdim * 3 * ydim;
		return num * num3 + num2 * ydim + y;
	}

	private void QueueRelight(BlockKey key)
	{
		if (key.x >= -15 && key.x < 31 && key.z >= -15 && key.z < 31)
		{
			int index = LightBitmapIndex(key);
			if (!_lightbit[index])
			{
				_lightbit[index] = true;
				_update.Enqueue(key);
			}
		}
	}

	private IBoundedLitBlockCollection LocalChunk(int lx, int ly, int lz)
	{
		if (ly < 0 || ly >= _ydim)
		{
			return null;
		}
		if (lx < 0)
		{
			if (lz < 0)
			{
				return OnResolveNeighbor(-1, 0, -1);
			}
			if (lz >= _zdim)
			{
				return OnResolveNeighbor(-1, 0, 1);
			}
			return OnResolveNeighbor(-1, 0, 0);
		}
		if (lx >= _xdim)
		{
			if (lz < 0)
			{
				return OnResolveNeighbor(1, 0, -1);
			}
			if (lz >= _zdim)
			{
				return OnResolveNeighbor(1, 0, 1);
			}
			return OnResolveNeighbor(1, 0, 0);
		}
		if (lz < 0)
		{
			return OnResolveNeighbor(0, 0, -1);
		}
		if (lz >= _zdim)
		{
			return OnResolveNeighbor(0, 0, 1);
		}
		return _blockset;
	}

	private int NeighborLight(IBoundedLitBlockCollection[,] chunkMap, int x, int y, int z)
	{
		if (y < 0 || y >= _ydim)
		{
			return 0;
		}
		int xdim = _xdim;
		int zdim = _zdim;
		int num = x + xdim;
		int num2 = z + zdim;
		IBoundedLitBlockCollection boundedLitBlockCollection = chunkMap[num / xdim, num2 / zdim];
		if (boundedLitBlockCollection == null)
		{
			return 0;
		}
		x = num % xdim;
		z = num2 % zdim;
		BlockInfo info = boundedLitBlockCollection.GetInfo(x, y, z);
		if (!info.TransmitsLight)
		{
			return info.Luminance;
		}
		int blockLight = boundedLitBlockCollection.GetBlockLight(x, y, z);
		return Math.Max((info.Opacity > 0) ? blockLight : (blockLight - 1), info.Luminance - 1);
	}

	private int NeighborSkyLight(IBoundedLitBlockCollection[,] chunkMap, int x, int y, int z)
	{
		if (y < 0 || y >= _ydim)
		{
			return 0;
		}
		int xdim = _xdim;
		int zdim = _zdim;
		int num = x + xdim;
		int num2 = z + zdim;
		IBoundedLitBlockCollection boundedLitBlockCollection = chunkMap[num / xdim, num2 / zdim];
		if (boundedLitBlockCollection == null)
		{
			return 0;
		}
		x = num % xdim;
		z = num2 % zdim;
		BlockInfo info = boundedLitBlockCollection.GetInfo(x, y, z);
		if (!info.TransmitsLight)
		{
			return 0;
		}
		int skyLight = boundedLitBlockCollection.GetSkyLight(x, y, z);
		if (info.Opacity <= 0)
		{
			return skyLight - 1;
		}
		return skyLight;
	}

	private int NeighborHeight(int x, int z)
	{
		IBoundedLitBlockCollection boundedLitBlockCollection = LocalChunk(x, 0, z);
		if (boundedLitBlockCollection == null)
		{
			return _ydim - 1;
		}
		x = (x + _xdim * 2) % _xdim;
		z = (z + _zdim * 2) % _zdim;
		return boundedLitBlockCollection.GetHeight(x, z);
	}

	private void TestBlockLight(IBoundedLitBlockCollection chunk, int x1, int y1, int z1, int x2, int y2, int z2)
	{
		int blockLight = _blockset.GetBlockLight(x1, y1, z1);
		int blockLight2 = chunk.GetBlockLight(x2, y2, z2);
		int luminance = _blockset.GetInfo(x1, y1, z1).Luminance;
		int luminance2 = chunk.GetInfo(x2, y2, z2).Luminance;
		int num = Math.Max(blockLight, luminance);
		int num2 = Math.Max(blockLight2, luminance2);
		if (Math.Abs(num - num2) > 1)
		{
			QueueRelight(new BlockKey(x1, y1, z1));
		}
	}

	private void TestSkyLight(IBoundedLitBlockCollection chunk, int x1, int y1, int z1, int x2, int y2, int z2)
	{
		int skyLight = _blockset.GetSkyLight(x1, y1, z1);
		int skyLight2 = chunk.GetSkyLight(x2, y2, z2);
		if (Math.Abs(skyLight - skyLight2) > 1)
		{
			QueueRelight(new BlockKey(x1, y1, z1));
		}
	}

	private IBoundedLitBlockCollection[,] LocalBlockLightMap()
	{
		return new IBoundedLitBlockCollection[3, 3]
		{
			{
				OnResolveNeighbor(-1, 0, -1),
				OnResolveNeighbor(-1, 0, 0),
				OnResolveNeighbor(-1, 0, 1)
			},
			{
				OnResolveNeighbor(0, 0, -1),
				_blockset,
				OnResolveNeighbor(0, 0, 1)
			},
			{
				OnResolveNeighbor(1, 0, -1),
				OnResolveNeighbor(1, 0, 0),
				OnResolveNeighbor(1, 0, 1)
			}
		};
	}

	private int[,] LocalHeightMap(IBoundedLitBlockCollection[,] chunkMap)
	{
		int xdim = _xdim;
		int zdim = _zdim;
		int[,] array = new int[3 * xdim, 3 * zdim];
		for (int i = 0; i < 3; i++)
		{
			int num = i * xdim;
			for (int j = 0; j < 3; j++)
			{
				int num2 = j * zdim;
				if (chunkMap[i, j] == null)
				{
					continue;
				}
				for (int k = 0; k < xdim; k++)
				{
					int num3 = num + k;
					for (int l = 0; l < zdim; l++)
					{
						int num4 = num2 + l;
						array[num3, num4] = chunkMap[i, j].GetHeight(k, l);
					}
				}
			}
		}
		return array;
	}

	private IBoundedLitBlockCollection OnResolveNeighbor(int relX, int relY, int relZ)
	{
		if (this.ResolveNeighbor != null)
		{
			IBoundedLitBlockCollection boundedLitBlockCollection = this.ResolveNeighbor(relX, relY, relZ);
			if (boundedLitBlockCollection == null)
			{
				return null;
			}
			if (boundedLitBlockCollection.XDim != _xdim || boundedLitBlockCollection.YDim != _ydim || boundedLitBlockCollection.ZDim != _zdim)
			{
				throw new InvalidOperationException("Subscriber returned incompatible ILitBlockCollection");
			}
			return boundedLitBlockCollection;
		}
		return null;
	}
}
