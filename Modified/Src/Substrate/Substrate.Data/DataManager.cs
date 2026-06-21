using System;

namespace Substrate.Data;

public abstract class DataManager
{
	public virtual int CurrentMapId
	{
		get
		{
			throw new NotImplementedException();
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public IMapManager Maps => GetMapManager();

	protected virtual IMapManager GetMapManager()
	{
		return null;
	}

	public virtual bool Save()
	{
		return true;
	}
}
