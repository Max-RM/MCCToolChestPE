namespace Substrate.Core;

public interface IBoundedLitBlockCollection : IBoundedBlockCollection
{
	new ILitBlock GetBlock(int x, int y, int z);

	new ILitBlock GetBlockRef(int x, int y, int z);

	void SetBlock(int x, int y, int z, ILitBlock block);

	int GetBlockLight(int x, int y, int z);

	int GetSkyLight(int x, int y, int z);

	void SetBlockLight(int x, int y, int z, int light);

	void SetSkyLight(int x, int y, int z, int light);

	int GetHeight(int x, int z);

	void SetHeight(int x, int z, int height);

	void UpdateBlockLight(int x, int y, int z);

	void UpdateSkyLight(int x, int y, int z);

	void ResetBlockLight();

	void ResetSkyLight();

	void RebuildBlockLight();

	void RebuildSkyLight();

	void RebuildHeightMap();

	void StitchBlockLight();

	void StitchSkyLight();

	void StitchBlockLight(IBoundedLitBlockCollection blockset, BlockCollectionEdge edge);

	void StitchSkyLight(IBoundedLitBlockCollection blockset, BlockCollectionEdge edge);
}
