using System;
using System.Collections.Generic;

namespace Substrate.Core;

public class OpenWorldEventArgs : EventArgs
{
	private List<OpenWorldCallback> _handlers;

	private string _path;

	public string Path => _path;

	internal int HandlerCount => _handlers.Count;

	internal ICollection<OpenWorldCallback> Handlers => _handlers;

	public OpenWorldEventArgs(string path)
	{
		_path = path;
		_handlers = new List<OpenWorldCallback>();
	}

	public void AddHandler(OpenWorldCallback callback)
	{
		_handlers.Add(callback);
	}
}
