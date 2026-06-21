using System;

namespace Microsoft.ClearScript.V8;

internal abstract class V8TestProxy : V8Proxy
{
	internal sealed class Statistics
	{
		public ulong IsolateCount;

		public ulong ContextCount;
	}

	public static V8TestProxy Create()
	{
		return V8Proxy.CreateImpl<V8TestProxy>(new object[0]);
	}

	public abstract UIntPtr GetNativeDigest(string value);

	public abstract Statistics GetStatistics();
}
