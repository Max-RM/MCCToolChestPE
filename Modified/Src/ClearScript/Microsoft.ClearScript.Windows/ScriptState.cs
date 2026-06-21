namespace Microsoft.ClearScript.Windows;

internal enum ScriptState : uint
{
	Uninitialized = 0u,
	Initialized = 5u,
	Started = 1u,
	Connected = 2u,
	Disconnected = 3u,
	Closed = 4u
}
