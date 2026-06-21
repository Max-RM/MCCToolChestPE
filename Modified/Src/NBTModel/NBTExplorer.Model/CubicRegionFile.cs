using Substrate.Core;

namespace NBTExplorer.Model;

public class CubicRegionFile : RegionFile
{
	private const int _sectorBytes = 256;

	private static byte[] _emptySector = new byte[256];

	protected override int SectorBytes => 256;

	protected override byte[] EmptySector => _emptySector;

	public CubicRegionFile(string path)
		: base(path)
	{
	}
}
