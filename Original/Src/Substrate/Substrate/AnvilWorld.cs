using System;
using System.Collections.Generic;
using System.IO;
using Substrate.Core;
using Substrate.Data;
using Substrate.Nbt;

namespace Substrate;

public class AnvilWorld : NbtWorld
{
	private const string _REGION_DIR = "region";

	private const string _PLAYER_DIR = "players";

	private string _levelFile = "level.dat";

	private Level _level;

	private Dictionary<string, AnvilRegionManager> _regionMgrs;

	private Dictionary<string, RegionChunkManager> _chunkMgrs;

	private Dictionary<string, BlockManager> _blockMgrs;

	private Dictionary<string, ChunkCache> _caches;

	private PlayerManager _playerMan;

	private BetaDataManager _dataMan;

	private int _prefCacheSize = 256;

	public override Level Level => _level;

	private AnvilWorld()
	{
		_regionMgrs = new Dictionary<string, AnvilRegionManager>();
		_chunkMgrs = new Dictionary<string, RegionChunkManager>();
		_blockMgrs = new Dictionary<string, BlockManager>();
		_caches = new Dictionary<string, ChunkCache>();
	}

	public new BlockManager GetBlockManager()
	{
		return GetBlockManagerVirt(0) as BlockManager;
	}

	public new BlockManager GetBlockManager(int dim)
	{
		return GetBlockManagerVirt(dim) as BlockManager;
	}

	public new BlockManager GetBlockManager(string dim)
	{
		return GetBlockManagerVirt(dim) as BlockManager;
	}

	public new RegionChunkManager GetChunkManager()
	{
		return GetChunkManagerVirt(0) as RegionChunkManager;
	}

	public new RegionChunkManager GetChunkManager(int dim)
	{
		return GetChunkManagerVirt(dim) as RegionChunkManager;
	}

	public new RegionChunkManager GetChunkManager(string dim)
	{
		return GetChunkManagerVirt(dim) as RegionChunkManager;
	}

	public AnvilRegionManager GetRegionManager()
	{
		return GetRegionManager(0);
	}

	public AnvilRegionManager GetRegionManager(int dim)
	{
		return GetRegionManager(DimensionFromInt(dim));
	}

	public AnvilRegionManager GetRegionManager(string dim)
	{
		if (_regionMgrs.TryGetValue(dim, out var value))
		{
			return value;
		}
		OpenDimension(dim);
		return _regionMgrs[dim];
	}

	public new PlayerManager GetPlayerManager()
	{
		return GetPlayerManagerVirt() as PlayerManager;
	}

	public new BetaDataManager GetDataManager()
	{
		return GetDataManagerVirt() as BetaDataManager;
	}

	public override void Save()
	{
		_level.Save();
		foreach (KeyValuePair<string, RegionChunkManager> chunkMgr in _chunkMgrs)
		{
			chunkMgr.Value.Save();
		}
	}

	public ChunkCache GetChunkCache()
	{
		return GetChunkCache(0);
	}

	public ChunkCache GetChunkCache(int dim)
	{
		return GetChunkCache(DimensionFromInt(dim));
	}

	public ChunkCache GetChunkCache(string dim)
	{
		if (_caches.ContainsKey(dim))
		{
			return _caches[dim];
		}
		return null;
	}

	public new static AnvilWorld Open(string path)
	{
		return new AnvilWorld().OpenWorld(path);
	}

	public static AnvilWorld Open(string path, int cacheSize)
	{
		AnvilWorld anvilWorld = new AnvilWorld().OpenWorld(path);
		anvilWorld._prefCacheSize = cacheSize;
		return anvilWorld;
	}

	public static AnvilWorld Create(string path)
	{
		return new AnvilWorld().CreateWorld(path);
	}

	public static AnvilWorld Create(string path, int cacheSize)
	{
		AnvilWorld anvilWorld = new AnvilWorld().CreateWorld(path);
		anvilWorld._prefCacheSize = cacheSize;
		return anvilWorld;
	}

	protected override IBlockManager GetBlockManagerVirt(int dim)
	{
		return GetBlockManagerVirt(DimensionFromInt(dim));
	}

	protected override IBlockManager GetBlockManagerVirt(string dim)
	{
		if (_blockMgrs.TryGetValue(dim, out var value))
		{
			return value;
		}
		OpenDimension(dim);
		return _blockMgrs[dim];
	}

	protected override IChunkManager GetChunkManagerVirt(int dim)
	{
		return GetChunkManagerVirt(DimensionFromInt(dim));
	}

	protected override IChunkManager GetChunkManagerVirt(string dim)
	{
		if (_chunkMgrs.TryGetValue(dim, out var value))
		{
			return value;
		}
		OpenDimension(dim);
		return _chunkMgrs[dim];
	}

	protected override IPlayerManager GetPlayerManagerVirt()
	{
		if (_playerMan != null)
		{
			return _playerMan;
		}
		string playerDir = System.IO.Path.Combine(base.Path, "players");
		_playerMan = new PlayerManager(playerDir);
		return _playerMan;
	}

	protected override DataManager GetDataManagerVirt()
	{
		if (_dataMan != null)
		{
			return _dataMan;
		}
		_dataMan = new BetaDataManager(this);
		return _dataMan;
	}

	private string DimensionFromInt(int dim)
	{
		if (dim == 0)
		{
			return "";
		}
		return "DIM" + dim;
	}

	private void OpenDimension(string dim)
	{
		string path = base.Path;
		if (string.IsNullOrEmpty(dim))
		{
			path = System.IO.Path.Combine(path, "region");
		}
		else
		{
			path = System.IO.Path.Combine(path, dim);
			path = System.IO.Path.Combine(path, "region");
		}
		if (!Directory.Exists(path))
		{
			Directory.CreateDirectory(path);
		}
		ChunkCache chunkCache = new ChunkCache(_prefCacheSize);
		AnvilRegionManager anvilRegionManager = new AnvilRegionManager(path, chunkCache);
		RegionChunkManager regionChunkManager = new RegionChunkManager(anvilRegionManager, chunkCache);
		BlockManager value = new AnvilBlockManager(regionChunkManager);
		_regionMgrs[dim] = anvilRegionManager;
		_chunkMgrs[dim] = regionChunkManager;
		_blockMgrs[dim] = value;
		_caches[dim] = chunkCache;
	}

	private AnvilWorld OpenWorld(string path)
	{
		if (!Directory.Exists(path))
		{
			if (!File.Exists(path))
			{
				throw new DirectoryNotFoundException("Directory '" + path + "' not found");
			}
			_levelFile = System.IO.Path.GetFileName(path);
			path = System.IO.Path.GetDirectoryName(path);
		}
		base.Path = path;
		string text = System.IO.Path.Combine(path, _levelFile);
		if (!File.Exists(text))
		{
			throw new FileNotFoundException("Data file '" + _levelFile + "' not found in '" + path + "'", text);
		}
		if (!LoadLevel())
		{
			throw new Exception("Failed to load '" + _levelFile + "'");
		}
		return this;
	}

	private AnvilWorld CreateWorld(string path)
	{
		if (!Directory.Exists(path))
		{
			throw new DirectoryNotFoundException("Directory '" + path + "' not found");
		}
		string path2 = System.IO.Path.Combine(path, "region");
		if (!Directory.Exists(path2))
		{
			Directory.CreateDirectory(path2);
		}
		base.Path = path;
		_level = new Level(this);
		return this;
	}

	private bool LoadLevel()
	{
		NBTFile nBTFile = new NBTFile(System.IO.Path.Combine(base.Path, _levelFile));
		Stream dataInputStream = nBTFile.GetDataInputStream();
		if (dataInputStream == null)
		{
			return false;
		}
		NbtTree nbtTree = new NbtTree(dataInputStream);
		_level = new Level(this);
		_level = _level.LoadTreeSafe(nbtTree.Root);
		return _level != null;
	}

	internal static void OnResolveOpen(object sender, OpenWorldEventArgs e)
	{
		try
		{
			AnvilWorld anvilWorld = new AnvilWorld().OpenWorld(e.Path);
			if (anvilWorld != null)
			{
				string path = System.IO.Path.Combine(e.Path, "region");
				if (Directory.Exists(path) && anvilWorld.Level.Version >= 19133)
				{
					e.AddHandler(Open);
				}
			}
		}
		catch (Exception)
		{
		}
	}
}
