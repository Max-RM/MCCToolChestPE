using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.ClearScript.Util;

namespace Microsoft.ClearScript;

public abstract class ScriptEngine : IDisposable
{
	internal sealed class ScriptFrame
	{
		public Exception HostException { get; set; }

		public IScriptEngineException ScriptError { get; set; }

		public IScriptEngineException PendingScriptError { get; set; }

		public bool InterruptRequested { get; set; }
	}

	private readonly string name;

	private Type accessContext;

	private ScriptAccess defaultAccess;

	private bool enforceAnonymousTypeAccess;

	private DocumentSettings documentSettings;

	private readonly DocumentSettings defaultDocumentSettings = new DocumentSettings();

	private static readonly IUniqueNameManager nameManager = new UniqueNameManager();

	private static readonly object nullHostObjectProxy = new object();

	[ThreadStatic]
	private static ScriptEngine currentEngine;

	private object enumerationSettingsToken = new object();

	private readonly ExtensionMethodTable extensionMethodTable = new ExtensionMethodTable();

	private readonly Dictionary<BindSignature, object> bindCache = new Dictionary<BindSignature, object>();

	private readonly ConditionalWeakTable<object, List<WeakReference>> hostObjectHostItemCache = new ConditionalWeakTable<object, List<WeakReference>>();

	private readonly ConditionalWeakTable<Type, List<WeakReference>> hostTypeHostItemCache = new ConditionalWeakTable<Type, List<WeakReference>>();

	internal readonly HostTargetMemberData SharedHostMethodMemberData = new HostTargetMemberData();

	internal readonly HostTargetMemberData SharedHostIndexedPropertyMemberData = new HostTargetMemberData();

	internal readonly HostTargetMemberData SharedScriptMethodMemberData = new HostTargetMemberData();

	private readonly ConditionalWeakTable<Type, List<WeakReference>> sharedHostObjectMemberDataCache = new ConditionalWeakTable<Type, List<WeakReference>>();

	public string Name => name;

	public static ScriptEngine Current => currentEngine;

	public abstract string FileNameExtension { get; }

	public Type AccessContext
	{
		get
		{
			return accessContext;
		}
		set
		{
			accessContext = value;
			OnAccessSettingsChanged();
		}
	}

	public ScriptAccess DefaultAccess
	{
		get
		{
			return defaultAccess;
		}
		set
		{
			defaultAccess = value;
			OnAccessSettingsChanged();
		}
	}

	public bool EnforceAnonymousTypeAccess
	{
		get
		{
			return enforceAnonymousTypeAccess;
		}
		set
		{
			enforceAnonymousTypeAccess = value;
			OnAccessSettingsChanged();
		}
	}

	public bool FormatCode { get; set; }

	public bool AllowReflection { get; set; }

	public bool DisableTypeRestriction { get; set; }

	public bool DisableListIndexTypeRestriction { get; set; }

	public bool EnableNullResultWrapping { get; set; }

	public bool UseReflectionBindFallback { get; set; }

	public bool EnableAutoHostVariables { get; set; }

	public ContinuationCallback ContinuationCallback { get; set; }

	public abstract dynamic Script { get; }

	public DocumentSettings DocumentSettings
	{
		get
		{
			return documentSettings ?? defaultDocumentSettings;
		}
		set
		{
			documentSettings = value;
		}
	}

	internal abstract IUniqueNameManager DocumentNameManager { get; }

	internal virtual bool EnumerateInstanceMethods => true;

	internal virtual bool EnumerateExtensionMethods => EnumerateInstanceMethods;

	internal ScriptFrame CurrentScriptFrame { get; private set; }

	internal object EnumerationSettingsToken => enumerationSettingsToken;

	internal ExtensionMethodSummary ExtensionMethodSummary => extensionMethodTable.Summary;

	internal abstract HostItemCollateral HostItemCollateral { get; }

	[Obsolete("Use ScriptEngine(string name, string fileNameExtensions) instead.")]
	protected ScriptEngine(string name)
		: this(name, null)
	{
	}

	protected ScriptEngine(string name, string fileNameExtensions)
	{
		this.name = nameManager.GetUniqueName(name, GetType().GetRootName());
		defaultDocumentSettings.FileNameExtensions = fileNameExtensions;
	}

	public void AddHostObject(string itemName, object target)
	{
		AddHostObject(itemName, HostItemFlags.None, target);
	}

	public void AddHostObject(string itemName, HostItemFlags flags, object target)
	{
		MiscHelpers.VerifyNonNullArgument(target, "target");
		AddHostItem(itemName, flags, target);
	}

	public void AddRestrictedHostObject<T>(string itemName, T target)
	{
		AddRestrictedHostObject(itemName, HostItemFlags.None, target);
	}

	public void AddRestrictedHostObject<T>(string itemName, HostItemFlags flags, T target)
	{
		AddHostItem(itemName, flags, HostItem.Wrap(this, target, typeof(T)));
	}

	public void AddCOMObject(string itemName, string progID)
	{
		AddCOMObject(itemName, HostItemFlags.None, progID);
	}

	public void AddCOMObject(string itemName, string progID, string serverName)
	{
		AddCOMObject(itemName, HostItemFlags.None, progID, serverName);
	}

	public void AddCOMObject(string itemName, HostItemFlags flags, string progID)
	{
		AddCOMObject(itemName, flags, progID, null);
	}

	public void AddCOMObject(string itemName, HostItemFlags flags, string progID, string serverName)
	{
		AddHostItem(itemName, flags, MiscHelpers.CreateCOMObject(progID, serverName));
	}

	public void AddCOMObject(string itemName, Guid clsid)
	{
		AddCOMObject(itemName, HostItemFlags.None, clsid);
	}

	public void AddCOMObject(string itemName, Guid clsid, string serverName)
	{
		AddCOMObject(itemName, HostItemFlags.None, clsid, serverName);
	}

	public void AddCOMObject(string itemName, HostItemFlags flags, Guid clsid)
	{
		AddCOMObject(itemName, flags, clsid, null);
	}

	public void AddCOMObject(string itemName, HostItemFlags flags, Guid clsid, string serverName)
	{
		AddHostItem(itemName, flags, MiscHelpers.CreateCOMObject(clsid, serverName));
	}

	public void AddHostType(Type type)
	{
		AddHostType(HostItemFlags.None, type);
	}

	public void AddHostType(HostItemFlags flags, Type type)
	{
		AddHostType(type.GetRootName(), flags, type);
	}

	public void AddHostType(string itemName, Type type)
	{
		AddHostType(itemName, HostItemFlags.None, type);
	}

	public void AddHostType(string itemName, HostItemFlags flags, Type type)
	{
		MiscHelpers.VerifyNonNullArgument(type, "type");
		AddHostItem(itemName, flags, HostType.Wrap(type));
	}

	public void AddHostType(string itemName, string typeName, params Type[] typeArgs)
	{
		AddHostType(itemName, HostItemFlags.None, typeName, typeArgs);
	}

	public void AddHostType(string itemName, HostItemFlags flags, string typeName, params Type[] typeArgs)
	{
		AddHostItem(itemName, flags, TypeHelpers.ImportType(typeName, null, useAssemblyName: false, typeArgs));
	}

	public void AddHostType(string itemName, string typeName, string assemblyName, params Type[] typeArgs)
	{
		AddHostType(itemName, HostItemFlags.None, typeName, assemblyName, typeArgs);
	}

	public void AddHostType(string itemName, HostItemFlags flags, string typeName, string assemblyName, params Type[] typeArgs)
	{
		AddHostItem(itemName, flags, TypeHelpers.ImportType(typeName, assemblyName, useAssemblyName: true, typeArgs));
	}

	public void AddCOMType(string itemName, string progID)
	{
		AddCOMType(itemName, HostItemFlags.None, progID);
	}

	public void AddCOMType(string itemName, string progID, string serverName)
	{
		AddCOMType(itemName, HostItemFlags.None, progID, serverName);
	}

	public void AddCOMType(string itemName, HostItemFlags flags, string progID)
	{
		AddCOMType(itemName, flags, progID, null);
	}

	public void AddCOMType(string itemName, HostItemFlags flags, string progID, string serverName)
	{
		AddHostItem(itemName, flags, HostType.Wrap(MiscHelpers.GetCOMType(progID, serverName)));
	}

	public void AddCOMType(string itemName, Guid clsid)
	{
		AddCOMType(itemName, HostItemFlags.None, clsid);
	}

	public void AddCOMType(string itemName, Guid clsid, string serverName)
	{
		AddCOMType(itemName, HostItemFlags.None, clsid, serverName);
	}

	public void AddCOMType(string itemName, HostItemFlags flags, Guid clsid)
	{
		AddCOMType(itemName, flags, clsid, null);
	}

	public void AddCOMType(string itemName, HostItemFlags flags, Guid clsid, string serverName)
	{
		AddHostItem(itemName, flags, HostType.Wrap(MiscHelpers.GetCOMType(clsid, serverName)));
	}

	public void Execute(string code)
	{
		Execute(null, code);
	}

	public void Execute(string documentName, string code)
	{
		Execute(documentName, discard: false, code);
	}

	public void Execute(string documentName, bool discard, string code)
	{
		Execute(new DocumentInfo(documentName)
		{
			Flags = (discard ? DocumentFlags.IsTransient : DocumentFlags.None)
		}, code);
	}

	public void Execute(DocumentInfo documentInfo, string code)
	{
		Execute(documentInfo.MakeUnique(this), code, evaluate: false);
	}

	public void ExecuteDocument(string specifier)
	{
		ExecuteDocument(specifier, null);
	}

	public void ExecuteDocument(string specifier, DocumentCategory category)
	{
		ExecuteDocument(specifier, category, null);
	}

	public void ExecuteDocument(string specifier, DocumentCategory category, DocumentContextCallback contextCallback)
	{
		MiscHelpers.VerifyNonBlankArgument(specifier, "specifier", "Invalid document specifier");
		Document document = DocumentSettings.Loader.LoadDocument(DocumentSettings, null, specifier, category, contextCallback);
		Execute(document.Info, document.GetTextContents());
	}

	public virtual string ExecuteCommand(string command)
	{
		DocumentInfo documentInfo = new DocumentInfo("Command");
		documentInfo.Flags = DocumentFlags.IsTransient;
		DocumentInfo documentInfo2 = documentInfo;
		return GetCommandResultString(Evaluate(documentInfo2.MakeUnique(this), command, marshalResult: false));
	}

	public object Evaluate(string code)
	{
		return Evaluate(null, code);
	}

	public object Evaluate(string documentName, string code)
	{
		return Evaluate(documentName, discard: true, code);
	}

	public object Evaluate(string documentName, bool discard, string code)
	{
		return Evaluate(new DocumentInfo(documentName)
		{
			Flags = (discard ? DocumentFlags.IsTransient : DocumentFlags.None)
		}, code);
	}

	public object Evaluate(DocumentInfo documentInfo, string code)
	{
		return Evaluate(documentInfo.MakeUnique(this, DocumentFlags.IsTransient), code, marshalResult: true);
	}

	public object EvaluateDocument(string specifier)
	{
		return EvaluateDocument(specifier, null);
	}

	public object EvaluateDocument(string specifier, DocumentCategory category)
	{
		return EvaluateDocument(specifier, category, null);
	}

	public object EvaluateDocument(string specifier, DocumentCategory category, DocumentContextCallback contextCallback)
	{
		MiscHelpers.VerifyNonBlankArgument(specifier, "specifier", "Invalid document specifier");
		Document document = DocumentSettings.Loader.LoadDocument(DocumentSettings, null, specifier, category, contextCallback);
		return Evaluate(document.Info, document.GetTextContents());
	}

	public object Invoke(string funcName, params object[] args)
	{
		MiscHelpers.VerifyNonBlankArgument(funcName, "funcName", "Invalid function name");
		return ((IDynamic)Script).InvokeMethod(funcName, args ?? ArrayHelpers.GetEmptyArray<object>());
	}

	public abstract string GetStackTrace();

	public abstract void Interrupt();

	public abstract void CollectGarbage(bool exhaustive);

	internal abstract void AddHostItem(string itemName, HostItemFlags flags, object item);

	internal object PrepareResult<T>(T result, ScriptMemberFlags flags, bool isListIndexResult)
	{
		return PrepareResult(result, typeof(T), flags, isListIndexResult);
	}

	internal virtual object PrepareResult(object result, Type type, ScriptMemberFlags flags, bool isListIndexResult)
	{
		bool flag = flags.HasFlag(ScriptMemberFlags.WrapNullResult) || EnableNullResultWrapping;
		if (flag && result == null)
		{
			return HostObject.WrapResult(null, type, wrapNull: true);
		}
		if (!flags.HasFlag(ScriptMemberFlags.ExposeRuntimeType) && !DisableTypeRestriction && (!isListIndexResult || !DisableListIndexTypeRestriction))
		{
			return HostObject.WrapResult(result, type, flag);
		}
		return result;
	}

	internal abstract object MarshalToScript(object obj, HostItemFlags flags);

	internal object MarshalToScript(object obj)
	{
		return MarshalToScript(obj, (obj as HostItem)?.Flags ?? HostItemFlags.None);
	}

	internal object[] MarshalToScript(object[] args)
	{
		return args.Select(MarshalToScript).ToArray();
	}

	internal abstract object MarshalToHost(object obj, bool preserveHostTarget);

	internal object[] MarshalToHost(object[] args, bool preserveHostTargets)
	{
		return args.Select((object arg) => MarshalToHost(arg, preserveHostTargets)).ToArray();
	}

	internal abstract object Execute(UniqueDocumentInfo documentInfo, string code, bool evaluate);

	internal abstract object ExecuteRaw(UniqueDocumentInfo documentInfo, string code, bool evaluate);

	internal object Evaluate(UniqueDocumentInfo documentInfo, string code, bool marshalResult)
	{
		object obj = Execute(documentInfo, code, evaluate: true);
		if (marshalResult)
		{
			obj = MarshalToHost(obj, preserveHostTarget: false);
		}
		return obj;
	}

	internal string GetCommandResultString(object result)
	{
		if (result is HostItem hostItem && hostItem.Target is IHostVariable)
		{
			return result.ToString();
		}
		object obj = MarshalToHost(result, preserveHostTarget: false);
		if (obj is VoidResult)
		{
			return null;
		}
		if (obj == null)
		{
			return "[null]";
		}
		if (obj is Undefined)
		{
			return obj.ToString();
		}
		if (obj is ScriptItem)
		{
			return "[ScriptObject]";
		}
		return result.ToString();
	}

	internal void RequestInterrupt()
	{
		ScriptFrame currentScriptFrame = CurrentScriptFrame;
		if (currentScriptFrame != null)
		{
			currentScriptFrame.InterruptRequested = true;
		}
	}

	internal void CheckReflection()
	{
		if (!AllowReflection)
		{
			throw new UnauthorizedAccessException("Use of reflection is prohibited in this script engine");
		}
	}

	internal virtual void OnAccessSettingsChanged()
	{
	}

	internal virtual void HostInvoke(Action action)
	{
		action();
	}

	internal virtual T HostInvoke<T>(Func<T> func)
	{
		return func();
	}

	internal IDisposable CreateEngineScope()
	{
		return Scope.Create(() => MiscHelpers.Exchange(ref currentEngine, this), delegate(ScriptEngine previousEngine)
		{
			currentEngine = previousEngine;
		});
	}

	internal virtual void ScriptInvoke(Action action)
	{
		using (CreateEngineScope())
		{
			ScriptInvokeInternal(action);
		}
	}

	internal virtual T ScriptInvoke<T>(Func<T> func)
	{
		using (CreateEngineScope())
		{
			return ScriptInvokeInternal(func);
		}
	}

	internal void ScriptInvokeInternal(Action action)
	{
		ScriptFrame currentScriptFrame = CurrentScriptFrame;
		CurrentScriptFrame = new ScriptFrame();
		try
		{
			action();
		}
		finally
		{
			CurrentScriptFrame = currentScriptFrame;
		}
	}

	internal T ScriptInvokeInternal<T>(Func<T> func)
	{
		ScriptFrame currentScriptFrame = CurrentScriptFrame;
		CurrentScriptFrame = new ScriptFrame();
		try
		{
			return func();
		}
		finally
		{
			CurrentScriptFrame = currentScriptFrame;
		}
	}

	internal void ThrowScriptError()
	{
		if (CurrentScriptFrame != null)
		{
			ThrowScriptError(CurrentScriptFrame.ScriptError);
		}
	}

	internal static void ThrowScriptError(IScriptEngineException scriptError)
	{
		if (scriptError != null)
		{
			if (scriptError is ScriptInterruptedException)
			{
				throw new ScriptInterruptedException(scriptError.EngineName, scriptError.Message, scriptError.ErrorDetails, scriptError.HResult, scriptError.IsFatal, scriptError.ExecutionStarted, scriptError.ScriptException, scriptError.InnerException);
			}
			throw new ScriptEngineException(scriptError.EngineName, scriptError.Message, scriptError.ErrorDetails, scriptError.HResult, scriptError.IsFatal, scriptError.ExecutionStarted, scriptError.ScriptException, scriptError.InnerException);
		}
	}

	internal virtual void SyncInvoke(Action action)
	{
		action();
	}

	internal virtual T SyncInvoke<T>(Func<T> func)
	{
		return func();
	}

	internal void OnEnumerationSettingsChanged()
	{
		enumerationSettingsToken = new object();
	}

	internal void ProcessExtensionMethodType(Type type)
	{
		if (extensionMethodTable.ProcessType(type, AccessContext, DefaultAccess))
		{
			bindCache.Clear();
		}
	}

	internal void RebuildExtensionMethodSummary()
	{
		extensionMethodTable.RebuildSummary();
	}

	internal void CacheBindResult(BindSignature signature, object result)
	{
		bindCache.Add(signature, result);
	}

	internal bool TryGetCachedBindResult(BindSignature signature, out object result)
	{
		return bindCache.TryGetValue(signature, out result);
	}

	internal HostItem GetOrCreateHostItem(HostTarget target, HostItemFlags flags, HostItem.CreateFunc createHostItem)
	{
		if (target is HostObject hostObject)
		{
			return GetOrCreateHostItemForHostObject(hostObject, hostObject.Target, flags, createHostItem);
		}
		if (target is HostType hostType)
		{
			return GetOrCreateHostItemForHostType(hostType, flags, createHostItem);
		}
		if (target is HostMethod hostMethod)
		{
			return GetOrCreateHostItemForHostObject(hostMethod, hostMethod, flags, createHostItem);
		}
		if (target is HostVariableBase hostVariableBase)
		{
			return GetOrCreateHostItemForHostObject(hostVariableBase, hostVariableBase, flags, createHostItem);
		}
		if (target is HostIndexedProperty hostIndexedProperty)
		{
			return GetOrCreateHostItemForHostObject(hostIndexedProperty, hostIndexedProperty, flags, createHostItem);
		}
		return createHostItem(this, target, flags);
	}

	private HostItem GetOrCreateHostItemForHostObject(HostTarget hostTarget, object target, HostItemFlags flags, HostItem.CreateFunc createHostItem)
	{
		List<WeakReference> orCreateValue = hostObjectHostItemCache.GetOrCreateValue(target ?? nullHostObjectProxy);
		List<WeakReference> list = null;
		int num = 0;
		foreach (WeakReference item in orCreateValue)
		{
			if (!(item.Target is HostItem hostItem))
			{
				num++;
				continue;
			}
			if (hostItem.Target.Type == hostTarget.Type && hostItem.Flags == flags)
			{
				return hostItem;
			}
			if (list == null)
			{
				list = new List<WeakReference>(orCreateValue.Count);
			}
			list.Add(item);
		}
		if (num > 4)
		{
			orCreateValue.Clear();
			if (list != null)
			{
				orCreateValue.Capacity = list.Count + 1;
				orCreateValue.AddRange(list);
			}
		}
		HostItem hostItem2 = createHostItem(this, hostTarget, flags);
		orCreateValue.Add(new WeakReference(hostItem2));
		return hostItem2;
	}

	private HostItem GetOrCreateHostItemForHostType(HostType hostType, HostItemFlags flags, HostItem.CreateFunc createHostItem)
	{
		if (hostType.Types.Length != 1)
		{
			return createHostItem(this, hostType, flags);
		}
		List<WeakReference> orCreateValue = hostTypeHostItemCache.GetOrCreateValue(hostType.Types[0]);
		List<WeakReference> list = null;
		int num = 0;
		foreach (WeakReference item in orCreateValue)
		{
			if (!(item.Target is HostItem hostItem))
			{
				num++;
				continue;
			}
			if (hostItem.Flags == flags)
			{
				return hostItem;
			}
			if (list == null)
			{
				list = new List<WeakReference>(orCreateValue.Count);
			}
			list.Add(item);
		}
		if (num > 4)
		{
			orCreateValue.Clear();
			if (list != null)
			{
				orCreateValue.Capacity = list.Count + 1;
				orCreateValue.AddRange(list);
			}
		}
		HostItem hostItem2 = createHostItem(this, hostType, flags);
		orCreateValue.Add(new WeakReference(hostItem2));
		return hostItem2;
	}

	internal HostTargetMemberData GetSharedHostObjectMemberData(HostObject target, Type targetAccessContext, ScriptAccess targetDefaultAccess)
	{
		List<WeakReference> orCreateValue = sharedHostObjectMemberDataCache.GetOrCreateValue(target.Type);
		List<WeakReference> list = null;
		int num = 0;
		foreach (WeakReference item in orCreateValue)
		{
			if (!(item.Target is SharedHostObjectMemberData sharedHostObjectMemberData))
			{
				num++;
				continue;
			}
			if (sharedHostObjectMemberData.AccessContext == targetAccessContext && sharedHostObjectMemberData.DefaultAccess == targetDefaultAccess)
			{
				return sharedHostObjectMemberData;
			}
			if (list == null)
			{
				list = new List<WeakReference>(orCreateValue.Count);
			}
			list.Add(item);
		}
		if (num > 4)
		{
			orCreateValue.Clear();
			if (list != null)
			{
				orCreateValue.Capacity = list.Count + 1;
				orCreateValue.AddRange(list);
			}
		}
		SharedHostObjectMemberData sharedHostObjectMemberData2 = new SharedHostObjectMemberData(targetAccessContext, targetDefaultAccess);
		orCreateValue.Add(new WeakReference(sharedHostObjectMemberData2));
		return sharedHostObjectMemberData2;
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected abstract void Dispose(bool disposing);

	~ScriptEngine()
	{
		Dispose(disposing: false);
	}
}
