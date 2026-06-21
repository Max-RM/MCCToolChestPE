using System;

namespace NBTExplorer.Controllers;

public class MessageBoxEventArgs : EventArgs
{
	public bool Cancel { get; set; }

	public string Message { get; set; }

	public MessageBoxEventArgs(string message)
	{
		Message = message;
	}
}
