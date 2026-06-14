namespace Substrate.Core;

public interface IDataBlockCollection : IBlockCollection
{
	new IDataBlock GetBlock(int x, int y, int z);

	new IDataBlock GetBlockRef(int x, int y, int z);

	void SetBlock(int x, int y, int z, IDataBlock block);

	int GetData(int x, int y, int z);

	void SetData(int x, int y, int z, int data);
}
