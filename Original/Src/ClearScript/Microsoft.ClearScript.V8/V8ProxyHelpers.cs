using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.ClearScript.Util;

namespace Microsoft.ClearScript.V8;

internal static class V8ProxyHelpers
{
	public unsafe static char* AllocString(string value)
	{
		return (char*)Marshal.StringToHGlobalUni(value).ToPointer();
	}

	public unsafe static void FreeString(char* pValue)
	{
		Marshal.FreeHGlobal((IntPtr)pValue);
	}

	public unsafe static void* AddRefHostObject(void* pObject)
	{
		return AddRefHostObject(GetHostObject(pObject));
	}

	public unsafe static void* AddRefHostObject(object obj)
	{
		return GCHandle.ToIntPtr(GCHandle.Alloc(obj)).ToPointer();
	}

	public unsafe static void ReleaseHostObject(void* pObject)
	{
		GCHandle.FromIntPtr((IntPtr)pObject).Free();
	}

	public unsafe static object GetHostObject(void* pObject)
	{
		return GCHandle.FromIntPtr((IntPtr)pObject).Target;
	}

	public unsafe static object GetHostObjectProperty(void* pObject, string name)
	{
		return GetHostObjectProperty(GetHostObject(pObject), name);
	}

	public static object GetHostObjectProperty(object obj, string name)
	{
		return ((IDynamic)obj).GetProperty(name, ArrayHelpers.GetEmptyArray<object>());
	}

	public unsafe static object GetHostObjectProperty(void* pObject, string name, out bool isCacheable)
	{
		return GetHostObjectProperty(GetHostObject(pObject), name, out isCacheable);
	}

	public static object GetHostObjectProperty(object obj, string name, out bool isCacheable)
	{
		return ((IDynamic)obj).GetProperty(name, out isCacheable, ArrayHelpers.GetEmptyArray<object>());
	}

	public unsafe static void SetHostObjectProperty(void* pObject, string name, object value)
	{
		SetHostObjectProperty(GetHostObject(pObject), name, value);
	}

	public static void SetHostObjectProperty(object obj, string name, object value)
	{
		((IDynamic)obj).SetProperty(name, value);
	}

	public unsafe static bool DeleteHostObjectProperty(void* pObject, string name)
	{
		return DeleteHostObjectProperty(GetHostObject(pObject), name);
	}

	public static bool DeleteHostObjectProperty(object obj, string name)
	{
		return ((IDynamic)obj).DeleteProperty(name);
	}

	public unsafe static string[] GetHostObjectPropertyNames(void* pObject)
	{
		return GetHostObjectPropertyNames(GetHostObject(pObject));
	}

	public static string[] GetHostObjectPropertyNames(object obj)
	{
		return ((IDynamic)obj).GetPropertyNames();
	}

	public unsafe static object GetHostObjectProperty(void* pObject, int index)
	{
		return GetHostObjectProperty(GetHostObject(pObject), index);
	}

	public static object GetHostObjectProperty(object obj, int index)
	{
		return ((IDynamic)obj).GetProperty(index);
	}

	public unsafe static void SetHostObjectProperty(void* pObject, int index, object value)
	{
		SetHostObjectProperty(GetHostObject(pObject), index, value);
	}

	public static void SetHostObjectProperty(object obj, int index, object value)
	{
		((IDynamic)obj).SetProperty(index, value);
	}

	public unsafe static bool DeleteHostObjectProperty(void* pObject, int index)
	{
		return DeleteHostObjectProperty(GetHostObject(pObject), index);
	}

	public static bool DeleteHostObjectProperty(object obj, int index)
	{
		return ((IDynamic)obj).DeleteProperty(index);
	}

	public unsafe static int[] GetHostObjectPropertyIndices(void* pObject)
	{
		return GetHostObjectPropertyIndices(GetHostObject(pObject));
	}

	public static int[] GetHostObjectPropertyIndices(object obj)
	{
		return ((IDynamic)obj).GetPropertyIndices();
	}

	public unsafe static object InvokeHostObject(void* pObject, bool asConstructor, object[] args)
	{
		return InvokeHostObject(GetHostObject(pObject), asConstructor, args);
	}

	public static object InvokeHostObject(object obj, bool asConstructor, object[] args)
	{
		return ((IDynamic)obj).Invoke(asConstructor, args);
	}

	public unsafe static object InvokeHostObjectMethod(void* pObject, string name, object[] args)
	{
		return InvokeHostObjectMethod(GetHostObject(pObject), name, args);
	}

	public static object InvokeHostObjectMethod(object obj, string name, object[] args)
	{
		return ((IDynamic)obj).InvokeMethod(name, args);
	}

	public unsafe static Invocability GetHostObjectInvocability(void* pObject)
	{
		return GetHostObjectInvocability(GetHostObject(pObject));
	}

	public static Invocability GetHostObjectInvocability(object obj)
	{
		if (!(obj is HostItem hostItem))
		{
			return Invocability.None;
		}
		return hostItem.Invocability;
	}

	public unsafe static object GetEnumeratorForHostObject(void* pObject)
	{
		return GetEnumeratorForHostObject(GetHostObject(pObject));
	}

	public static object GetEnumeratorForHostObject(object obj)
	{
		return ((IDynamic)obj).InvokeMethod(SpecialMemberNames.NewEnum, ArrayHelpers.GetEmptyArray<object>());
	}

	public unsafe static bool AdvanceEnumerator(void* pEnumerator, out object value)
	{
		return AdvanceEnumerator(GetHostObject(pEnumerator), out value);
	}

	public static bool AdvanceEnumerator(object enumerator, out object value)
	{
		IScriptMarshalWrapper scriptMarshalWrapper = (IScriptMarshalWrapper)enumerator;
		if (((IEnumerator)scriptMarshalWrapper.Unwrap()).MoveNext())
		{
			value = ((IDynamic)enumerator).GetProperty("Current", ArrayHelpers.GetEmptyArray<object>());
			return true;
		}
		value = null;
		return false;
	}

	public unsafe static object MarshalExceptionToScript(void* pSource, Exception exception)
	{
		return MarshalExceptionToScript(GetHostObject(pSource), exception);
	}

	public static object MarshalExceptionToScript(object source, Exception exception)
	{
		return ((IScriptMarshalWrapper)source).Engine.MarshalToScript(exception);
	}

	public static Exception MarshalExceptionToHost(object exception)
	{
		if (exception == null)
		{
			return null;
		}
		return (Exception)((IScriptMarshalWrapper)exception).Engine.MarshalToHost(exception, preserveHostTarget: false);
	}

	public unsafe static void* CreateV8ObjectCache()
	{
		return AddRefHostObject(new Dictionary<object, IntPtr>());
	}

	public unsafe static void CacheV8Object(void* pCache, void* pObject, void* pV8Object)
	{
		((Dictionary<object, IntPtr>)GetHostObject(pCache)).Add(GetHostObject(pObject), (IntPtr)pV8Object);
	}

	public unsafe static void* GetCachedV8Object(void* pCache, void* pObject)
	{
		if (!((Dictionary<object, IntPtr>)GetHostObject(pCache)).TryGetValue(GetHostObject(pObject), out var value))
		{
			return null;
		}
		return value.ToPointer();
	}

	public unsafe static IntPtr[] GetAllCachedV8Objects(void* pCache)
	{
		return ((Dictionary<object, IntPtr>)GetHostObject(pCache)).Values.ToArray();
	}

	public unsafe static bool RemoveV8ObjectCacheEntry(void* pCache, void* pObject)
	{
		return ((Dictionary<object, IntPtr>)GetHostObject(pCache)).Remove(GetHostObject(pObject));
	}

	public unsafe static void* CreateDebugAgent(string name, string version, int port, bool remote, IV8DebugListener listener)
	{
		return AddRefHostObject(new V8DebugAgent(name, version, port, remote, listener));
	}

	public unsafe static void SendDebugMessage(void* pAgent, string content)
	{
		((V8DebugAgent)GetHostObject(pAgent)).SendMessage(content);
	}

	public unsafe static void DestroyDebugAgent(void* pAgent)
	{
		((V8DebugAgent)GetHostObject(pAgent)).Dispose();
		ReleaseHostObject(pAgent);
	}

	public unsafe static void* CreateNativeCallbackTimer(int dueTime, int period, INativeCallback callback)
	{
		return AddRefHostObject(new NativeCallbackTimer(dueTime, period, callback));
	}

	public unsafe static bool ChangeNativeCallbackTimer(void* pTimer, int dueTime, int period)
	{
		return ((NativeCallbackTimer)GetHostObject(pTimer)).Change(dueTime, period);
	}

	public unsafe static void DestroyNativeCallbackTimer(void* pTimer)
	{
		((NativeCallbackTimer)GetHostObject(pTimer)).Dispose();
		ReleaseHostObject(pTimer);
	}

	public unsafe static string LoadModule(void* pSourceDocumentInfo, string specifier, DocumentCategory category, out UniqueDocumentInfo documentInfo)
	{
		ScriptEngine current = ScriptEngine.Current;
		if (current == null)
		{
			throw new InvalidOperationException("Module loading requires a script engine");
		}
		DocumentSettings documentSettings = current.DocumentSettings;
		Document document = documentSettings.Loader.LoadDocument(documentSettings, ((UniqueDocumentInfo)GetHostObject(pSourceDocumentInfo)).Info, specifier, category, null);
		string textContents = document.GetTextContents();
		documentInfo = document.Info.MakeUnique(current);
		return textContents;
	}

	public unsafe static IDictionary<string, object> CreateModuleContext(void* pDocumentInfo)
	{
		ScriptEngine current = ScriptEngine.Current;
		if (current == null)
		{
			throw new InvalidOperationException("Module context construction requires a script engine");
		}
		UniqueDocumentInfo uniqueDocumentInfo = (UniqueDocumentInfo)GetHostObject(pDocumentInfo);
		DocumentContextCallback documentContextCallback = uniqueDocumentInfo.ContextCallback ?? current.DocumentSettings.ContextCallback;
		if (documentContextCallback != null)
		{
			IDictionary<string, object> dictionary = documentContextCallback(uniqueDocumentInfo.Info);
			if (dictionary != null)
			{
				Dictionary<string, object> dictionary2 = new Dictionary<string, object>(dictionary.Count);
				{
					foreach (KeyValuePair<string, object> item in dictionary)
					{
						dictionary2.Add(item.Key, current.MarshalToScript(item.Value));
					}
					return dictionary2;
				}
			}
		}
		return null;
	}
}
