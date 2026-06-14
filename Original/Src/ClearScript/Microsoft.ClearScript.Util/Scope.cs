using System;

namespace Microsoft.ClearScript.Util;

internal static class Scope
{
	private sealed class ScopeImpl : IDisposable
	{
		private readonly Action exitAction;

		private readonly OneWayFlag disposedFlag = new OneWayFlag();

		public ScopeImpl(Action enterAction, Action exitAction)
		{
			this.exitAction = exitAction;
			enterAction?.Invoke();
		}

		public void Dispose()
		{
			if (disposedFlag.Set() && exitAction != null)
			{
				exitAction();
			}
		}
	}

	private sealed class ScopeImpl<T> : IScope<T>, IDisposable
	{
		private readonly T value;

		private readonly Action<T> exitAction;

		private readonly OneWayFlag disposedFlag = new OneWayFlag();

		public T Value => value;

		public ScopeImpl(Func<T> enterFunc, Action<T> exitAction)
		{
			this.exitAction = exitAction;
			if (enterFunc != null)
			{
				value = enterFunc();
			}
		}

		public void Dispose()
		{
			if (disposedFlag.Set() && exitAction != null)
			{
				exitAction(value);
			}
		}
	}

	public static IDisposable Create(Action enterAction, Action exitAction)
	{
		return new ScopeImpl(enterAction, exitAction);
	}

	public static IScope<T> Create<T>(Func<T> enterFunc, Action<T> exitAction)
	{
		return new ScopeImpl<T>(enterFunc, exitAction);
	}
}
