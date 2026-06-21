using System;
using System.IO;
using Substrate.Core;

namespace Substrate;

public class BetaRegionManager : RegionManager
{
	public BetaRegionManager(string regionDir, ChunkCache cache)
		: base(regionDir, cache)
	{
	}

	protected override IRegion CreateRegionCore(int rx, int rz)
	{
		return new BetaRegion(this, _chunkCache, rx, rz);
	}

	protected override RegionFile CreateRegionFileCore(int rx, int rz)
	{
		string path = "r." + rx + "." + rz + ".mcr";
		return new RegionFile(Path.Combine(_regionPath, path));
	}

	protected override void DeleteRegionCore(IRegion region)
	{
		if (region is BetaRegion betaRegion)
		{
			betaRegion.Dispose();
		}
	}

	public override IRegion GetRegion(string filename)
	{
		if (!BetaRegion.ParseFileName(filename, out var x, out var z))
		{
			throw new ArgumentException("Malformed region file name: " + filename, "filename");
		}
		return GetRegion(x, z);
	}
}
