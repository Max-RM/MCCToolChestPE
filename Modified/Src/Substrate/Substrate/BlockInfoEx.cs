namespace Substrate;

public class BlockInfoEx : BlockInfo
{
	private string _tileEntityName;

	public string TileEntityName => _tileEntityName;

	internal BlockInfoEx(int id)
		: base(id)
	{
	}

	public BlockInfoEx(int id, string name)
		: base(id, name)
	{
	}

	public BlockInfo SetTileEntity(string name)
	{
		_tileEntityName = name;
		return this;
	}
}
