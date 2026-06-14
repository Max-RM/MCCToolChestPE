using Substrate.Core;

namespace Substrate;

public struct AlphaBlockRef : IVersion10BlockRef, IAlphaBlockRef, IDataBlock, ILitBlock, IPropertyBlock, IActiveBlock, IBlock
{
	private readonly AlphaBlockCollection _collection;

	private readonly int _index;

	public bool IsValid => _collection != null;

	public BlockInfo Info => _collection.GetInfo(_index);

	public int ID
	{
		get
		{
			return _collection.GetID(_index);
		}
		set
		{
			_collection.SetID(_index, value);
		}
	}

	public int Data
	{
		get
		{
			return _collection.GetData(_index);
		}
		set
		{
			_collection.SetData(_index, value);
		}
	}

	public int BlockLight
	{
		get
		{
			return _collection.GetBlockLight(_index);
		}
		set
		{
			_collection.SetBlockLight(_index, value);
		}
	}

	public int SkyLight
	{
		get
		{
			return _collection.GetSkyLight(_index);
		}
		set
		{
			_collection.SetSkyLight(_index, value);
		}
	}

	public int TileTickValue
	{
		get
		{
			return _collection.GetTileTickValue(_index);
		}
		set
		{
			_collection.SetTileTickValue(_index, value);
		}
	}

	internal AlphaBlockRef(AlphaBlockCollection collection, int index)
	{
		_collection = collection;
		_index = index;
	}

	public TileEntity GetTileEntity()
	{
		return _collection.GetTileEntity(_index);
	}

	public void SetTileEntity(TileEntity te)
	{
		_collection.SetTileEntity(_index, te);
	}

	public void CreateTileEntity()
	{
		_collection.CreateTileEntity(_index);
	}

	public void ClearTileEntity()
	{
		_collection.ClearTileEntity(_index);
	}

	public TileTick GetTileTick()
	{
		return _collection.GetTileTick(_index);
	}

	public void SetTileTick(TileTick te)
	{
		_collection.SetTileTick(_index, te);
	}

	public void CreateTileTick()
	{
		_collection.CreateTileTick(_index);
	}

	public void ClearTileTick()
	{
		_collection.ClearTileTick(_index);
	}
}
