using System;

namespace NBTExplorer.Utility;

public class SnapshotState<T> : IDisposable
{
	private SnapshotList<T> _list;

	internal SnapshotState(SnapshotList<T> list)
	{
		_list = list;
		_list.Begin();
	}

	public void Dispose()
	{
		_list.End();
		GC.SuppressFinalize(this);
	}
}
