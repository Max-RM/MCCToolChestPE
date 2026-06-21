using System;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Expando;
using Microsoft.ClearScript.Util;

namespace Microsoft.ClearScript.Windows;

internal sealed class WindowsScriptItem : ScriptItem, IWindowsScriptObject, IDisposable
{
	private readonly WindowsScriptEngine engine;

	private readonly IExpando target;

	private WindowsScriptItem holder;

	private readonly InterlockedOneWayFlag disposedFlag = new InterlockedOneWayFlag();

	public override ScriptEngine Engine => engine;

	private WindowsScriptItem(WindowsScriptEngine engine, IExpando target)
	{
		this.engine = engine;
		this.target = target;
	}

	public static object Wrap(WindowsScriptEngine engine, object obj)
	{
		if (obj == null)
		{
			return null;
		}
		if (obj is IExpando expando && obj.GetType().IsCOMObject)
		{
			return new WindowsScriptItem(engine, expando);
		}
		return obj;
	}

	private IScriptEngineException GetScriptError(Exception exception)
	{
		if (TryGetScriptError(exception, out var scriptError))
		{
			return scriptError;
		}
		return new ScriptEngineException(engine.Name, exception.Message, null, RawCOMHelpers.HResult.CLEARSCRIPT_E_SCRIPTITEMEXCEPTION, isFatal: false, executionStarted: false, null, exception);
	}

	private bool TryGetScriptError(Exception exception, out IScriptEngineException scriptError)
	{
		while (exception is TargetInvocationException)
		{
			exception = exception.InnerException;
		}
		scriptError = exception as IScriptEngineException;
		if (scriptError != null)
		{
			return true;
		}
		if (exception is COMException { ErrorCode: var errorCode })
		{
			if ((errorCode == RawCOMHelpers.HResult.SCRIPT_E_REPORTED || errorCode == RawCOMHelpers.HResult.CLEARSCRIPT_E_HOSTEXCEPTION) && engine.CurrentScriptFrame != null)
			{
				scriptError = engine.CurrentScriptFrame.ScriptError ?? engine.CurrentScriptFrame.PendingScriptError;
				if (scriptError != null)
				{
					return true;
				}
				Exception hostException = engine.CurrentScriptFrame.HostException;
				if (hostException != null)
				{
					scriptError = new ScriptEngineException(engine.Name, hostException.Message, null, RawCOMHelpers.HResult.CLEARSCRIPT_E_HOSTEXCEPTION, isFatal: false, executionStarted: true, null, hostException);
					return true;
				}
			}
			else if (RawCOMHelpers.HResult.GetFacility(errorCode) == 10)
			{
				if (engine.RuntimeErrorMap.TryGetValue(RawCOMHelpers.HResult.GetCode(errorCode), out var value) && value != exception.Message)
				{
					scriptError = new ScriptEngineException(engine.Name, value, null, RawCOMHelpers.HResult.CLEARSCRIPT_E_SCRIPTITEMEXCEPTION, isFatal: false, executionStarted: false, null, exception.InnerException);
					return true;
				}
				if (engine.SyntaxErrorMap.TryGetValue(RawCOMHelpers.HResult.GetCode(errorCode), out var value2) && value2 != exception.Message)
				{
					scriptError = new ScriptEngineException(engine.Name, value2, null, RawCOMHelpers.HResult.CLEARSCRIPT_E_SCRIPTITEMEXCEPTION, isFatal: false, executionStarted: false, null, exception.InnerException);
					return true;
				}
			}
			else if (errorCode == RawCOMHelpers.HResult.DISP_E_MEMBERNOTFOUND || errorCode == RawCOMHelpers.HResult.DISP_E_UNKNOWNNAME)
			{
				scriptError = new ScriptEngineException(engine.Name, "Invalid object or property access", null, RawCOMHelpers.HResult.CLEARSCRIPT_E_SCRIPTITEMEXCEPTION, isFatal: false, executionStarted: false, null, exception.InnerException);
				return true;
			}
		}
		else if (exception is ArgumentException { ParamName: null })
		{
			scriptError = new ScriptEngineException(engine.Name, "Invalid object or property access", null, RawCOMHelpers.HResult.CLEARSCRIPT_E_SCRIPTITEMEXCEPTION, isFatal: false, executionStarted: false, null, exception.InnerException);
			return true;
		}
		return false;
	}

	private void VerifyNotDisposed()
	{
		if (disposedFlag.IsSet)
		{
			throw new ObjectDisposedException(ToString());
		}
	}

	protected override bool TryBindAndInvoke(DynamicMetaObjectBinder binder, object[] args, out object result)
	{
		VerifyNotDisposed();
		if (!DynamicHelpers.TryBindAndInvoke(binder, target, args, out result))
		{
			if (result is Exception ex && engine.CurrentScriptFrame != null)
			{
				IScriptEngineException ex2 = ex as IScriptEngineException;
				if (ex2 == null)
				{
					ex2 = GetScriptError(ex);
				}
				if (ex2.ExecutionStarted)
				{
					throw (Exception)ex2;
				}
				engine.CurrentScriptFrame.ScriptError = ex2;
			}
			result = null;
			return false;
		}
		return true;
	}

	protected override object[] AdjustInvokeArgs(object[] args)
	{
		if (!(engine is JScriptEngine) || args.Length >= 1)
		{
			return args;
		}
		return new object[1] { Undefined.Value };
	}

	public override string[] GetPropertyNames()
	{
		VerifyNotDisposed();
		return engine.ScriptInvoke(() => (from property in target.GetProperties(BindingFlags.Default)
			select property.Name).ExcludeIndices().ToArray());
	}

	public override int[] GetPropertyIndices()
	{
		VerifyNotDisposed();
		return engine.ScriptInvoke(() => (from property in target.GetProperties(BindingFlags.Default)
			select property.Name).GetIndices().ToArray());
	}

	public override object GetProperty(string name, params object[] args)
	{
		VerifyNotDisposed();
		object obj = engine.MarshalToHost(engine.ScriptInvoke(delegate
		{
			try
			{
				return target.InvokeMember(name, BindingFlags.GetProperty, null, target, engine.MarshalToScript(args), null, CultureInfo.InvariantCulture, null);
			}
			catch (Exception)
			{
				if (target.GetMethod(name, BindingFlags.GetProperty) != null)
				{
					return new ScriptMethod(this, name);
				}
				return Undefined.Value;
			}
		}), preserveHostTarget: false);
		if (obj is WindowsScriptItem windowsScriptItem && windowsScriptItem.engine == engine)
		{
			windowsScriptItem.holder = this;
		}
		return obj;
	}

	public override void SetProperty(string name, params object[] args)
	{
		VerifyNotDisposed();
		engine.ScriptInvoke(delegate
		{
			object[] args2 = engine.MarshalToScript(args);
			try
			{
				try
				{
					target.InvokeMember(name, BindingFlags.SetProperty, null, target, args2, null, CultureInfo.InvariantCulture, null);
				}
				catch (COMException ex)
				{
					if (ex.ErrorCode == RawCOMHelpers.HResult.DISP_E_MEMBERNOTFOUND)
					{
						try
						{
							target.InvokeMember(name, BindingFlags.SetProperty | BindingFlags.PutDispProperty, null, target, args2, null, CultureInfo.InvariantCulture, null);
							return;
						}
						catch (COMException ex2)
						{
							if (ex2.ErrorCode == RawCOMHelpers.HResult.DISP_E_MEMBERNOTFOUND)
							{
								target.InvokeMember(name, BindingFlags.SetProperty | BindingFlags.PutRefDispProperty, null, target, args2, null, CultureInfo.InvariantCulture, null);
								return;
							}
							throw;
						}
					}
					throw;
				}
			}
			catch (MissingMemberException)
			{
				target.AddProperty(name);
				target.InvokeMember(name, BindingFlags.SetProperty, null, target, args2, null, CultureInfo.InvariantCulture, null);
			}
		});
	}

	public override bool DeleteProperty(string name)
	{
		VerifyNotDisposed();
		return engine.ScriptInvoke(delegate
		{
			FieldInfo field = target.GetField(name, BindingFlags.Default);
			if (field != null)
			{
				target.RemoveMember(field);
				return true;
			}
			PropertyInfo property = target.GetProperty(name, BindingFlags.Default);
			if (property != null)
			{
				target.RemoveMember(property);
				return true;
			}
			return false;
		});
	}

	public override object GetProperty(int index)
	{
		VerifyNotDisposed();
		return GetProperty(index.ToString(CultureInfo.InvariantCulture), ArrayHelpers.GetEmptyArray<object>());
	}

	public override void SetProperty(int index, object value)
	{
		VerifyNotDisposed();
		SetProperty(index.ToString(CultureInfo.InvariantCulture), value);
	}

	public override bool DeleteProperty(int index)
	{
		VerifyNotDisposed();
		return DeleteProperty(index.ToString(CultureInfo.InvariantCulture));
	}

	public override object Invoke(bool asConstructor, params object[] args)
	{
		VerifyNotDisposed();
		if (!asConstructor)
		{
			return engine.Script.EngineInternal.invokeMethod(holder, this, args);
		}
		return engine.Script.EngineInternal.invokeConstructor(this, args);
	}

	public override object InvokeMethod(string name, params object[] args)
	{
		VerifyNotDisposed();
		try
		{
			return engine.MarshalToHost(engine.ScriptInvoke(() => (target is IDispatchEx dispatchEx) ? dispatchEx.InvokeMethod(name, ignoreCase: false, engine.MarshalToScript(args)) : target.InvokeMember(name, BindingFlags.InvokeMethod, null, target, engine.MarshalToScript(args), null, CultureInfo.InvariantCulture, null)), preserveHostTarget: false);
		}
		catch (Exception exception)
		{
			if (TryGetScriptError(exception, out var scriptError))
			{
				throw (Exception)scriptError;
			}
			throw;
		}
	}

	public override object Unwrap()
	{
		return target;
	}

	object IWindowsScriptObject.GetUnderlyingObject()
	{
		IntPtr iUnknownForObject = Marshal.GetIUnknownForObject(target);
		object objectForIUnknown = Marshal.GetObjectForIUnknown(iUnknownForObject);
		Marshal.Release(iUnknownForObject);
		return objectForIUnknown;
	}

	public void Dispose()
	{
		if (disposedFlag.Set())
		{
			Marshal.ReleaseComObject(target);
		}
	}
}
