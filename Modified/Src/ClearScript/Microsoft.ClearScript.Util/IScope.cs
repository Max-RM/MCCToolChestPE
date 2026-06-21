using System;

namespace Microsoft.ClearScript.Util;

internal interface IScope<out T> : IDisposable
{
	T Value { get; }
}
