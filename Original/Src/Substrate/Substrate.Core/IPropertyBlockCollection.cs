namespace Substrate.Core;

public interface IPropertyBlockCollection : IBlockCollection
{
	new IPropertyBlock GetBlock(int x, int y, int z);

	new IPropertyBlock GetBlockRef(int x, int y, int z);

	void SetBlock(int x, int y, int z, IPropertyBlock block);

	TileEntity GetTileEntity(int x, int y, int z);

	void SetTileEntity(int x, int y, int z, TileEntity te);

	void CreateTileEntity(int x, int y, int z);

	void ClearTileEntity(int x, int y, int z);
}
