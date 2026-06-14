namespace Microsoft.ClearScript.V8;

public class V8RuntimeHeapInfo
{
	public ulong TotalHeapSize { get; internal set; }

	public ulong TotalHeapSizeExecutable { get; internal set; }

	public ulong TotalPhysicalSize { get; internal set; }

	public ulong UsedHeapSize { get; internal set; }

	public ulong HeapSizeLimit { get; internal set; }

	internal V8RuntimeHeapInfo()
	{
	}
}
