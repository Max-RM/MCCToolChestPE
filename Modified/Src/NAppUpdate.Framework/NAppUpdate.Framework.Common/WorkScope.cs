using System;

namespace NAppUpdate.Framework.Common;

public class WorkScope : IDisposable
{
	private readonly Action<bool> isWorkingFunc;

	public WorkScope(Action<bool> b)
	{
		isWorkingFunc = b;
		isWorkingFunc(obj: true);
	}

	internal static IDisposable New(Action<bool> action)
	{
		return new WorkScope(action);
	}

	public void Dispose()
	{
		isWorkingFunc(obj: false);
	}
}
