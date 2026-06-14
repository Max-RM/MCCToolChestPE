namespace Substrate.Core;

public interface IPropertyBlock : IBlock
{
	TileEntity GetTileEntity();

	void SetTileEntity(TileEntity te);

	void CreateTileEntity();

	void ClearTileEntity();
}
