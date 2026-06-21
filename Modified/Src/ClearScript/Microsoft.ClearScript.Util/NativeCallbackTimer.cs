using System;
using System.Threading;

namespace Microsoft.ClearScript.Util;

internal sealed class NativeCallbackTimer : IDisposable
{
	private readonly Timer timer;

	private readonly INativeCallback callback;

	private readonly InterlockedOneWayFlag disposedFlag = new InterlockedOneWayFlag();

	public NativeCallbackTimer(int dueTime, int period, INativeCallback callback)
	{
		this.callback = callback;
		timer = new Timer(OnTimer, null, -1, -1);
		if (dueTime != -1 || period != -1)
		{
			timer.Change(dueTime, period);
		}
	}

	public bool Change(int dueTime, int period)
	{
		if (!disposedFlag.IsSet && MiscHelpers.Try(out var result, () => timer.Change(dueTime, period)))
		{
			return result;
		}
		return false;
	}

	private void OnTimer(object state)
	{
		if (!disposedFlag.IsSet)
		{
			MiscHelpers.Try(callback.Invoke);
		}
	}

	public void Dispose()
	{
		if (disposedFlag.Set())
		{
			timer.Dispose();
			callback.Dispose();
		}
	}
}
