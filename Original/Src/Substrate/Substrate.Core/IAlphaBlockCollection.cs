namespace Substrate.Core;

public interface IAlphaBlockCollection : IDataBlockCollection, ILitBlockCollection, IPropertyBlockCollection, IBlockCollection
{
	new AlphaBlock GetBlock(int x, int y, int z);

	new AlphaBlockRef GetBlockRef(int x, int y, int z);

	void SetBlock(int x, int y, int z, AlphaBlock block);
}
