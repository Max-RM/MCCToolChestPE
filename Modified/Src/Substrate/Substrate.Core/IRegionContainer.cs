namespace Substrate.Core;

public interface IRegionContainer
{
	bool RegionExists(int rx, int rz);

	IRegion GetRegion(int rx, int rz);

	IRegion CreateRegion(int rx, int rz);

	bool DeleteRegion(int rx, int rz);
}
