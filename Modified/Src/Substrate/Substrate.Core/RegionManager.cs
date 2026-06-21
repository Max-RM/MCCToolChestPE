using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Substrate.Core;

public abstract class RegionManager : IRegionManager, IRegionContainer, IEnumerable<IRegion>, IEnumerable
{
	private struct Enumerator : IEnumerator<IRegion>, IDisposable, IEnumerator
	{
		private List<IRegion> _regions = new List<IRegion>();

		private int _pos = -1;

		object IEnumerator.Current => Current;

		IRegion IEnumerator<IRegion>.Current => Current;

		public IRegion Current
		{
			get
			{
				try
				{
					return _regions[_pos];
				}
				catch (IndexOutOfRangeException)
				{
					throw new InvalidOperationException();
				}
			}
		}

		public Enumerator(RegionManager rm)
		{
			if (!Directory.Exists(rm.GetRegionPath()))
			{
				throw new DirectoryNotFoundException();
			}
			List<string> list = new List<string>(Directory.GetFiles(rm.GetRegionPath()));
			_regions.Capacity = list.Count;
			list.Sort(RegionSort);
			foreach (string item in list)
			{
				try
				{
					IRegion region = rm.GetRegion(item);
					_regions.Add(region);
				}
				catch (ArgumentException)
				{
				}
			}
		}

		public bool MoveNext()
		{
			_pos++;
			return _pos < _regions.Count;
		}

		public void Reset()
		{
			_pos = -1;
		}

		void IDisposable.Dispose()
		{
		}

		private int RegionSort(string A, string B)
		{
			Regex regex = new Regex(".+r\\.(?<x>-?\\d+)\\.(?<y>-?\\d+)\\.(mca|mcr)", RegexOptions.None);
			Match match = regex.Match(A);
			if (!match.Success)
			{
				return 0;
			}
			int num = int.Parse(match.Groups["x"].Value);
			int num2 = int.Parse(match.Groups["y"].Value);
			match = regex.Match(B);
			if (!match.Success)
			{
				return 0;
			}
			int num3 = int.Parse(match.Groups["x"].Value);
			int num4 = int.Parse(match.Groups["y"].Value);
			if (num2 < num4)
			{
				return -1;
			}
			if (num2 > num4)
			{
				return 1;
			}
			if (num < num3)
			{
				return -1;
			}
			if (num > num3)
			{
				return 1;
			}
			return 0;
		}
	}

	protected string _regionPath;

	protected Dictionary<RegionKey, IRegion> _cache;

	protected ChunkCache _chunkCache;

	protected abstract IRegion CreateRegionCore(int rx, int rz);

	protected abstract RegionFile CreateRegionFileCore(int rx, int rz);

	protected abstract void DeleteRegionCore(IRegion region);

	public abstract IRegion GetRegion(string filename);

	public RegionManager(string regionDir, ChunkCache cache)
	{
		_regionPath = regionDir;
		_chunkCache = cache;
		_cache = new Dictionary<RegionKey, IRegion>();
	}

	public IRegion GetRegion(int rx, int rz)
	{
		RegionKey key = new RegionKey(rx, rz);
		try
		{
			if (!_cache.TryGetValue(key, out var value))
			{
				value = CreateRegionCore(rx, rz);
				_cache.Add(key, value);
			}
			return value;
		}
		catch (FileNotFoundException)
		{
			_cache.Add(key, null);
			return null;
		}
	}

	public bool RegionExists(int rx, int rz)
	{
		IRegion region = GetRegion(rx, rz);
		return region != null;
	}

	public IRegion CreateRegion(int rx, int rz)
	{
		IRegion region = GetRegion(rx, rz);
		if (region == null)
		{
			_ = "r." + rx + "." + rz + ".mca";
			using (CreateRegionFileCore(rx, rz))
			{
			}
			region = CreateRegionCore(rx, rz);
			RegionKey key = new RegionKey(rx, rz);
			_cache[key] = region;
		}
		return region;
	}

	public string GetRegionPath()
	{
		return _regionPath;
	}

	public bool DeleteRegion(int rx, int rz)
	{
		IRegion region = GetRegion(rx, rz);
		if (region == null)
		{
			return false;
		}
		RegionKey key = new RegionKey(rx, rz);
		_cache.Remove(key);
		DeleteRegionCore(region);
		try
		{
			File.Delete(region.GetFilePath());
		}
		catch (Exception ex)
		{
			Console.WriteLine("NOTICE: " + ex.Message);
			return false;
		}
		return true;
	}

	public IEnumerator<IRegion> GetEnumerator()
	{
		return new Enumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new Enumerator(this);
	}
}
