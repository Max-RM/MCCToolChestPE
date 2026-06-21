using System;

namespace Microsoft.ClearScript.Windows;

public interface IHostWindow
{
	IntPtr OwnerHandle { get; }

	void EnableModeless(bool enable);
}
