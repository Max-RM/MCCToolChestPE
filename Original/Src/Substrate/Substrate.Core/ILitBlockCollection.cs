namespace Substrate.Core;

public interface ILitBlockCollection : IBlockCollection
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
}
