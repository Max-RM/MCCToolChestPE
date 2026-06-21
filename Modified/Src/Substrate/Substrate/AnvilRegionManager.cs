using System;
using System.IO;
using Substrate.Core;

namespace Substrate;

public class AnvilRegionManager : RegionManager
{
	public AnvilRegionManager(string regionDir, ChunkCache cache)
		: base(regionDir, cache)
	{
	}

	protected override IRegion CreateRegionCore(int rx, int rz)
	{
		return new AnvilRegion(this, _chunkCache, rx, rz);
	}

	protected override RegionFile CreateRegionFileCore(int rx, int rz)
	{
		string path = "r." + rx + "." + rz + ".mca";
		return new RegionFile(Path.Combine(_regionPath, path));
	}

	protected override void DeleteRegionCore(IRegion region)
	{
		if (region is AnvilRegion anvilRegion)
		{
			anvilRegion.Dispose();
		}
	}

	public override IRegion GetRegion(string filename)
	{
		if (!AnvilRegion.ParseFileName(filename, out var x, out var z))
		{
			throw new ArgumentException("Malformed region file name: " + filename, "filename");
		}
		return GetRegion(x, z);
	}
}
