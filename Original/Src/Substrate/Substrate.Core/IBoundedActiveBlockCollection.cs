namespace Substrate.Core;

public interface IBoundedActiveBlockCollection : IBoundedBlockCollection
{
	new IActiveBlock GetBlock(int x, int y, int z);

	new IActiveBlock GetBlockRef(int x, int y, int z);

	void SetBlock(int x, int y, int z, IActiveBlock block);

	TileTick GetTileTick(int x, int y, int z);

	void SetTileTick(int x, int y, int z, TileTick tt);

	void CreateTileTick(int x, int y, int z);

	void ClearTileTick(int x, int y, int z);

	int GetTileTickValue(int x, int y, int z);

	void SetTileTickValue(int x, int y, int z, int tickValue);
}
