namespace Substrate.Core;

public interface IBoundedBlockCollection
{
	int XDim { get; }

	int YDim { get; }

	int ZDim { get; }

	int CountByID(int id);

	IBlock GetBlock(int x, int y, int z);

	IBlock GetBlockRef(int x, int y, int z);

	void SetBlock(int x, int y, int z, IBlock block);

	int GetID(int x, int y, int z);

	void SetID(int x, int y, int z, int id);

	BlockInfo GetInfo(int x, int y, int z);
}
