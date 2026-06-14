using System;

namespace Microsoft.ClearScript.V8;

internal interface IV8DebugListener : IDisposable
{
	void ConnectClient();

	void SendCommand(string command);

	void DisconnectClient();
}
