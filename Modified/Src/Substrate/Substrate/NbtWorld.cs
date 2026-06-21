using System;
using System.Collections.Generic;
using Substrate.Core;
using Substrate.Data;

namespace Substrate;

public abstract class NbtWorld
{
	private const string _DATA_DIR = "data";

	private string _path;

	private string _dataDir;

	public string Path
	{
		get
		{
			return _path;
		}
		set
		{
			_path = value;
		}
	}

	public string DataDirectory
	{
		get
		{
			return _dataDir;
		}
		set
		{
			_dataDir = value;
		}
	}

	public abstract Level Level { get; }

	protected static event EventHandler<OpenWorldEventArgs> ResolveOpen;

	protected NbtWorld()
	{
		_dataDir = "data";
	}

	public IBlockManager GetBlockManager()
	{
		return GetBlockManagerVirt(0);
	}

	public IBlockManager GetBlockManager(int dim)
	{
		return GetBlockManagerVirt(dim);
	}

	public IBlockManager GetBlockManager(string dim)
	{
		return GetBlockManagerVirt(dim);
	}

	public IChunkManager GetChunkManager()
	{
		return GetChunkManagerVirt(0);
	}

	public IChunkManager GetChunkManager(int dim)
	{
		return GetChunkManagerVirt(dim);
	}

	public IChunkManager GetChunkManager(string dim)
	{
		return GetChunkManagerVirt(dim);
	}

	public IPlayerManager GetPlayerManager()
	{
		return GetPlayerManagerVirt();
	}

	public DataManager GetDataManager()
	{
		return GetDataManagerVirt();
	}

	public static NbtWorld Open(string path)
	{
		if (NbtWorld.ResolveOpen == null)
		{
			return null;
		}
		OpenWorldEventArgs e = new OpenWorldEventArgs(path);
		NbtWorld.ResolveOpen(null, e);
		if (e.HandlerCount != 1)
		{
			return null;
		}
		using (IEnumerator<OpenWorldCallback> enumerator = e.Handlers.GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				OpenWorldCallback current = enumerator.Current;
				return current(path);
			}
		}
		return null;
	}

	public abstract void Save();

	protected abstract IBlockManager GetBlockManagerVirt(int dim);

	protected abstract IChunkManager GetChunkManagerVirt(int dim);

	protected virtual IBlockManager GetBlockManagerVirt(string dim)
	{
		throw new NotImplementedException();
	}

	protected virtual IChunkManager GetChunkManagerVirt(string dim)
	{
		throw new NotImplementedException();
	}

	protected abstract IPlayerManager GetPlayerManagerVirt();

	protected virtual DataManager GetDataManagerVirt()
	{
		throw new NotImplementedException();
	}

	static NbtWorld()
	{
		ResolveOpen += AnvilWorld.OnResolveOpen;
		ResolveOpen += BetaWorld.OnResolveOpen;
		ResolveOpen += AlphaWorld.OnResolveOpen;
	}
}
