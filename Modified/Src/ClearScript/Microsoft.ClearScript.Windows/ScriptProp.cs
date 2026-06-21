namespace Microsoft.ClearScript.Windows;

internal enum ScriptProp : uint
{
	Name = 0u,
	MajorVersion = 1u,
	MinorVersion = 2u,
	BuildNumber = 3u,
	DelayedEventSinking = 4096u,
	CatchException = 4097u,
	ConversionLCID = 4098u,
	HostStackRequired = 4099u,
	Debugger = 4352u,
	JITDebug = 4353u,
	GCControlSoftClose = 8192u,
	IntegerMode = 12288u,
	StringCompareInstance = 12289u,
	InvokeVersioning = 16384u,
	HackFiberSupport = 1879048192u,
	HackTridentEventSink = 1879048193u,
	AbbreviateGlobalNameResolution = 1879048194u,
	HostKeepAlive = 1879048196u
}
