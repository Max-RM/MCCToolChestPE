using System;

namespace Microsoft.ClearScript.Util;

internal interface INativeCallback : IDisposable
{
	void Invoke();
}
