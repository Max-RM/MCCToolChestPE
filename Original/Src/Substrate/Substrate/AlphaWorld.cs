using System;
using System.Collections.Generic;
using System.IO;
using Substrate.Core;
using Substrate.Nbt;

namespace Substrate;

public class AlphaWorld : NbtWorld
{
	private const string _PLAYER_DIR = "players";

	private string _levelFile = "level.dat";

	private Level _level;

	private Dictionary<string, AlphaChunkManager> _chunkMgrs;

	private Dictionary<string, BlockManager> _blockMgrs;

	private PlayerManager _playerMan;

	public override Level Level => _level;

	private AlphaWorld()
	{
		_chunkMgrs = new Dictionary<string, AlphaChunkManager>();
		_blockMgrs = new Dictionary<string, BlockManager>();
	}

	public new BlockManager GetBlockManager()
	{
		return GetBlockManagerVirt(0) as BlockManager;
	}

	public new BlockManager GetBlockManager(int dim)
	{
		return GetBlockManagerVirt(dim) as BlockManager;
	}

	public new AlphaChunkManager GetChunkManager()
	{
		return GetChunkManagerVirt(0) as AlphaChunkManager;
	}

	public new AlphaChunkManager GetChunkManager(int dim)
	{
		return GetChunkManagerVirt(dim) as AlphaChunkManager;
	}

	public new PlayerManager GetPlayerManager()
	{
		return GetPlayerManagerVirt() as PlayerManager;
	}

	public override void Save()
	{
		_level.Save();
		foreach (KeyValuePair<string, AlphaChunkManager> chunkMgr in _chunkMgrs)
		{
			chunkMgr.Value.Save();
		}
	}

	public new static AlphaWorld Open(string path)
	{
		return new AlphaWorld().OpenWorld(path);
	}

	public static AlphaWorld Create(string path)
	{
		return new AlphaWorld().CreateWorld(path);
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
		string text = base.Path;
		if (!string.IsNullOrEmpty(dim))
		{
			text = System.IO.Path.Combine(text, dim);
		}
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		AlphaChunkManager alphaChunkManager = new AlphaChunkManager(text);
		BlockManager value = new AlphaBlockManager(alphaChunkManager);
		_chunkMgrs[dim] = alphaChunkManager;
		_blockMgrs[dim] = value;
	}

	private AlphaWorld OpenWorld(string path)
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

	private AlphaWorld CreateWorld(string path)
	{
		if (!Directory.Exists(path))
		{
			throw new DirectoryNotFoundException("Directory '" + path + "' not found");
		}
		base.Path = path;
		_level = new Level(this);
		_level.Version = 0;
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
			AlphaWorld alphaWorld = new AlphaWorld().OpenWorld(e.Path);
			if (alphaWorld != null && alphaWorld.Level.Version == 0)
			{
				e.AddHandler(Open);
			}
		}
		catch (Exception)
		{
		}
	}
}
