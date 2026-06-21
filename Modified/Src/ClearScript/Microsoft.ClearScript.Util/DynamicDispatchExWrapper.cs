using System.Globalization;
using System.Linq;

namespace Microsoft.ClearScript.Util;

internal sealed class DynamicDispatchExWrapper : IDynamic
{
	private readonly IDispatchEx dispatchEx;

	public DynamicDispatchExWrapper(IDispatchEx dispatchEx)
	{
		this.dispatchEx = dispatchEx;
	}

	public object GetProperty(string name, params object[] args)
	{
		bool isCacheable;
		return GetProperty(name, out isCacheable, args);
	}

	public object GetProperty(string name, out bool isCacheable, params object[] args)
	{
		isCacheable = false;
		return dispatchEx.GetProperty(name, ignoreCase: false, args);
	}

	public void SetProperty(string name, params object[] args)
	{
		dispatchEx.SetProperty(name, ignoreCase: false, args);
	}

	public bool DeleteProperty(string name)
	{
		return dispatchEx.DeleteProperty(name, ignoreCase: false);
	}

	public string[] GetPropertyNames()
	{
		return dispatchEx.GetPropertyNames().ExcludeIndices().ToArray();
	}

	public object GetProperty(int index)
	{
		return dispatchEx.GetProperty(index.ToString(CultureInfo.InvariantCulture), ignoreCase: false, ArrayHelpers.GetEmptyArray<object>());
	}

	public void SetProperty(int index, object value)
	{
		dispatchEx.SetProperty(index.ToString(CultureInfo.InvariantCulture), ignoreCase: false, new object[1] { value });
	}

	public bool DeleteProperty(int index)
	{
		return dispatchEx.DeleteProperty(index.ToString(CultureInfo.InvariantCulture), ignoreCase: false);
	}

	public int[] GetPropertyIndices()
	{
		return dispatchEx.GetPropertyNames().GetIndices().ToArray();
	}

	public object Invoke(bool asConstructor, params object[] args)
	{
		return dispatchEx.Invoke(asConstructor, args);
	}

	public object InvokeMethod(string name, params object[] args)
	{
		return dispatchEx.InvokeMethod(name, ignoreCase: false, args);
	}
}
