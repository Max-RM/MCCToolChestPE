using System;
using System.Threading;

namespace NAppUpdate.Framework.Common;

public class UpdateProcessAsyncResult : IAsyncResult
{
	private const int StatePending = 0;

	private const int StateCompletedSynchronously = 1;

	private const int StateCompletedAsynchronously = 2;

	private readonly AsyncCallback _asyncCallback;

	private readonly object _asyncState;

	private int _completedState;

	private ManualResetEvent _asyncWaitHandle;

	private Exception _exception;

	public bool IsCompleted => Thread.VolatileRead(ref _completedState) != 0;

	public WaitHandle AsyncWaitHandle
	{
		get
		{
			if (_asyncWaitHandle == null)
			{
				bool isCompleted = IsCompleted;
				ManualResetEvent manualResetEvent = new ManualResetEvent(isCompleted);
				if (Interlocked.CompareExchange(ref _asyncWaitHandle, manualResetEvent, null) != null)
				{
					manualResetEvent.Close();
				}
				else if (!isCompleted && IsCompleted)
				{
					_asyncWaitHandle.Set();
				}
			}
			return _asyncWaitHandle;
		}
	}

	public object AsyncState => _asyncState;

	public bool CompletedSynchronously => Thread.VolatileRead(ref _completedState) == 1;

	public UpdateProcessAsyncResult(AsyncCallback asyncCallback, object state)
	{
		_asyncCallback = asyncCallback;
		_asyncState = state;
	}

	public void SetAsCompleted(Exception exception, bool completedSynchronously)
	{
		_exception = exception;
		if (Interlocked.Exchange(ref _completedState, completedSynchronously ? 1 : 2) != 0)
		{
			throw new InvalidOperationException("You can set a result only once");
		}
		if (_asyncWaitHandle != null)
		{
			_asyncWaitHandle.Set();
		}
		if (_asyncCallback != null)
		{
			_asyncCallback(this);
		}
	}

	public void EndInvoke()
	{
		if (!IsCompleted)
		{
			AsyncWaitHandle.WaitOne();
			AsyncWaitHandle.Close();
			_asyncWaitHandle = null;
		}
		if (_exception != null)
		{
			throw _exception;
		}
	}
}
