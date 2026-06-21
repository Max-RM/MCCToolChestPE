using System;
using System.IO;
using System.Text.RegularExpressions;
using Substrate.Core;
using Substrate.Nbt;

namespace Substrate;

public class BetaRegion : Region
{
	private static Regex _namePattern = new Regex("r\\.(-?[0-9]+)\\.(-?[0-9]+)\\.mcr$");

	public BetaRegion(BetaRegionManager rm, ChunkCache cache, int rx, int rz)
		: base(rm, cache, rx, rz)
	{
	}

	public override string GetFileName()
	{
		return "r." + _rx + "." + _rz + ".mcr";
	}

	public override string GetFilePath()
	{
		return Path.Combine(_regionMan.GetRegionPath(), GetFileName());
	}

	public static bool TestFileName(string filename)
	{
		Match match = _namePattern.Match(filename);
		if (!match.Success)
		{
			return false;
		}
		return true;
	}

	public static bool ParseFileName(string filename, out int x, out int z)
	{
		x = 0;
		z = 0;
		Match match = _namePattern.Match(filename);
		if (!match.Success)
		{
			return false;
		}
		x = Convert.ToInt32(match.Groups[1].Value);
		z = Convert.ToInt32(match.Groups[2].Value);
		return true;
	}

	protected override bool ParseFileNameCore(string filename, out int x, out int z)
	{
		return ParseFileName(filename, out x, out z);
	}

	protected override IChunk CreateChunkCore(int cx, int cz)
	{
		return AlphaChunk.Create(cx, cz);
	}

	protected override IChunk CreateChunkVerifiedCore(NbtTree tree)
	{
		return AlphaChunk.CreateVerified(tree);
	}
}
