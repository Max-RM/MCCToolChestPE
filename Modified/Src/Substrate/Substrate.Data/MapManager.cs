using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Substrate.Nbt;

namespace Substrate.Data;

public class MapManager : IMapManager, IEnumerable<Map>, IEnumerable
{
	private NbtWorld _world;

	private static Regex _namePattern = new Regex("^map_[0-9]+\\.dat$");

	public MapManager(NbtWorld world)
	{
		_world = world;
	}

	protected MapFile GetMapFile(int id)
	{
		return new MapFile(Path.Combine(_world.Path, _world.DataDirectory), id);
	}

	public NbtTree GetMapTree(int id)
	{
		MapFile mapFile = GetMapFile(id);
		Stream dataInputStream = mapFile.GetDataInputStream();
		if (dataInputStream == null)
		{
			throw new NbtIOException("Failed to initialize NBT data stream for input.");
		}
		return new NbtTree(dataInputStream);
	}

	public void SetMapTree(int id, NbtTree tree)
	{
		MapFile mapFile = GetMapFile(id);
		Stream dataOutputStream = mapFile.GetDataOutputStream();
		if (dataOutputStream == null)
		{
			throw new NbtIOException("Failed to initialize NBT data stream for output.");
		}
		tree.WriteTo(dataOutputStream);
		dataOutputStream.Close();
	}

	public Map GetMap(int id)
	{
		if (!MapExists(id))
		{
			return null;
		}
		try
		{
			Map map = new Map().LoadTreeSafe(GetMapTree(id).Root);
			map.Id = id;
			return map;
		}
		catch (Exception innerException)
		{
			DataIOException ex = new DataIOException("Could not load map", innerException);
			ex.Data["MapId"] = id;
			throw ex;
		}
	}

	public void SetMap(int id, Map map)
	{
		try
		{
			SetMapTree(id, new NbtTree(map.BuildTree() as TagNodeCompound));
		}
		catch (Exception innerException)
		{
			DataIOException ex = new DataIOException("Could not save map", innerException);
			ex.Data["MapId"] = id;
			throw ex;
		}
	}

	public void SetMap(Map map)
	{
		SetMap(map.Id, map);
	}

	public bool MapExists(int id)
	{
		return new MapFile(Path.Combine(_world.Path, _world.DataDirectory), id).Exists();
	}

	public void DeleteMap(int id)
	{
		try
		{
			new MapFile(Path.Combine(_world.Path, _world.DataDirectory), id).Delete();
		}
		catch (Exception innerException)
		{
			DataIOException ex = new DataIOException("Could not remove map", innerException);
			ex.Data["MapId"] = id;
			throw ex;
		}
	}

	public IEnumerator<Map> GetEnumerator()
	{
		string path = Path.Combine(_world.Path, _world.DataDirectory);
		if (!Directory.Exists(path))
		{
			throw new DirectoryNotFoundException();
		}
		string[] files = Directory.GetFiles(path);
		try
		{
			string[] array = files;
			foreach (string file in array)
			{
				string basename = Path.GetFileName(file);
				if (ParseFileName(basename))
				{
					int id = MapFile.IdFromFilename(basename);
					yield return GetMap(id);
				}
			}
		}
		finally
		{
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	private bool ParseFileName(string filename)
	{
		Match match = _namePattern.Match(filename);
		if (!match.Success)
		{
			return false;
		}
		return true;
	}
}
