using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.ClearScript.JavaScript;
using Microsoft.ClearScript.Util;
using Microsoft.ClearScript.Windows;

namespace Microsoft.ClearScript.V8;

public sealed class V8ScriptEngine : ScriptEngine, IJavaScriptEngine
{
	internal sealed class Statistics
	{
		public ulong ScriptCount;

		public ulong ModuleCount;

		public ulong ModuleCacheSize;

		public int CommonJSModuleCacheSize;
	}

	private static readonly DocumentInfo initScriptInfo = new DocumentInfo(MiscHelpers.FormatInvariant("{0} [internal]", typeof(V8ScriptEngine).Name));

	private readonly V8ScriptEngineFlags engineFlags;

	private readonly V8ContextProxy proxy;

	private readonly object script;

	private readonly InterlockedOneWayFlag disposedFlag = new InterlockedOneWayFlag();

	private const int continuationInterval = 2000;

	private bool inContinuationTimerScope;

	private bool awaitDebuggerAndPause;

	private readonly HostItemCollateral hostItemCollateral;

	private readonly IUniqueNameManager documentNameManager;

	private List<string> documentNames;

	private bool suppressInstanceMethodEnumeration;

	private bool suppressExtensionMethodEnumeration;

	private CommonJSManager commonJSManager;

	public UIntPtr MaxRuntimeHeapSize
	{
		get
		{
			VerifyNotDisposed();
			return proxy.MaxRuntimeHeapSize;
		}
		set
		{
			VerifyNotDisposed();
			proxy.MaxRuntimeHeapSize = value;
		}
	}

	public TimeSpan RuntimeHeapSizeSampleInterval
	{
		get
		{
			VerifyNotDisposed();
			return proxy.RuntimeHeapSizeSampleInterval;
		}
		set
		{
			VerifyNotDisposed();
			proxy.RuntimeHeapSizeSampleInterval = value;
		}
	}

	public UIntPtr MaxRuntimeStackUsage
	{
		get
		{
			VerifyNotDisposed();
			return proxy.MaxRuntimeStackUsage;
		}
		set
		{
			VerifyNotDisposed();
			proxy.MaxRuntimeStackUsage = value;
		}
	}

	public bool SuppressInstanceMethodEnumeration
	{
		get
		{
			return suppressInstanceMethodEnumeration;
		}
		set
		{
			suppressInstanceMethodEnumeration = value;
			OnEnumerationSettingsChanged();
		}
	}

	public bool SuppressExtensionMethodEnumeration
	{
		get
		{
			return suppressExtensionMethodEnumeration;
		}
		set
		{
			suppressExtensionMethodEnumeration = value;
			RebuildExtensionMethodSummary();
		}
	}

	public uint CpuProfileSampleInterval
	{
		get
		{
			VerifyNotDisposed();
			return proxy.CpuProfileSampleInterval;
		}
		set
		{
			VerifyNotDisposed();
			proxy.CpuProfileSampleInterval = value;
		}
	}

	private CommonJSManager CommonJSManager
	{
		get
		{
			if (commonJSManager == null)
			{
				commonJSManager = new CommonJSManager(this);
			}
			return commonJSManager;
		}
	}

	public override string FileNameExtension => "js";

	public override dynamic Script
	{
		get
		{
			VerifyNotDisposed();
			return script;
		}
	}

	internal override IUniqueNameManager DocumentNameManager => documentNameManager;

	internal override bool EnumerateInstanceMethods
	{
		get
		{
			if (base.EnumerateInstanceMethods)
			{
				return !SuppressInstanceMethodEnumeration;
			}
			return false;
		}
	}

	internal override bool EnumerateExtensionMethods
	{
		get
		{
			if (base.EnumerateExtensionMethods)
			{
				return !SuppressExtensionMethodEnumeration;
			}
			return false;
		}
	}

	internal override HostItemCollateral HostItemCollateral => hostItemCollateral;

	uint IJavaScriptEngine.BaseLanguageVersion => 8u;

	public V8ScriptEngine()
		: this(null, null)
	{
	}

	public V8ScriptEngine(string name)
		: this(name, null)
	{
	}

	public V8ScriptEngine(V8RuntimeConstraints constraints)
		: this(null, constraints)
	{
	}

	public V8ScriptEngine(string name, V8RuntimeConstraints constraints)
		: this(name, constraints, V8ScriptEngineFlags.None)
	{
	}

	public V8ScriptEngine(V8ScriptEngineFlags flags)
		: this(flags, 0)
	{
	}

	public V8ScriptEngine(V8ScriptEngineFlags flags, int debugPort)
		: this(null, null, flags, debugPort)
	{
	}

	public V8ScriptEngine(string name, V8ScriptEngineFlags flags)
		: this(name, flags, 0)
	{
	}

	public V8ScriptEngine(string name, V8ScriptEngineFlags flags, int debugPort)
		: this(name, null, flags, debugPort)
	{
	}

	public V8ScriptEngine(V8RuntimeConstraints constraints, V8ScriptEngineFlags flags)
		: this(constraints, flags, 0)
	{
	}

	public V8ScriptEngine(V8RuntimeConstraints constraints, V8ScriptEngineFlags flags, int debugPort)
		: this(null, constraints, flags, debugPort)
	{
	}

	public V8ScriptEngine(string name, V8RuntimeConstraints constraints, V8ScriptEngineFlags flags)
		: this(name, constraints, flags, 0)
	{
	}

	public V8ScriptEngine(string name, V8RuntimeConstraints constraints, V8ScriptEngineFlags flags, int debugPort)
		: this(null, name, constraints, flags, debugPort)
	{
	}

	internal V8ScriptEngine(V8Runtime runtime, string name, V8RuntimeConstraints constraints, V8ScriptEngineFlags flags, int debugPort)
		: base((runtime != null) ? (runtime.Name + ":" + name) : name, "js")
	{
		using V8Runtime v8Runtime = ((runtime != null) ? null : new V8Runtime(name, constraints));
		V8Runtime v8Runtime2 = runtime ?? v8Runtime;
		documentNameManager = v8Runtime2.DocumentNameManager;
		hostItemCollateral = v8Runtime2.HostItemCollateral;
		engineFlags = flags;
		proxy = V8ContextProxy.Create(v8Runtime2.IsolateProxy, base.Name, flags, debugPort);
		script = GetRootItem();
		Execute(initScriptInfo, "\r\n                        EngineInternal = (function () {\r\n\r\n                            function convertArgs(args) {\r\n                                var result = [];\r\n                                var count = args.Length;\r\n                                for (var i = 0; i < count; i++) {\r\n                                    result.push(args[i]);\r\n                                }\r\n                                return result;\r\n                            }\r\n\r\n                            function construct(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15) {\r\n                                return new this(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);\r\n                            }\r\n\r\n                            var isHostObjectKey = this.isHostObjectKey;\r\n                            delete this.isHostObjectKey;\r\n\r\n                            return {\r\n\r\n                                getCommandResult: function (value) {\r\n                                    if (value == null) {\r\n                                        return value;\r\n                                    }\r\n                                    if (typeof(value.hasOwnProperty) != 'function') {\r\n                                        if (value[Symbol.toStringTag] == 'Module') {\r\n                                            return '[module]';\r\n                                        }\r\n                                        return '[external]';\r\n                                    }\r\n                                    if (value[isHostObjectKey] === true) {\r\n                                        return value;\r\n                                    }\r\n                                    if (typeof(value.toString) != 'function') {\r\n                                        return '[' + typeof(value) + ']';\r\n                                    }\r\n                                    return value.toString();\r\n                                },\r\n\r\n                                invokeConstructor: function (constructor, args) {\r\n                                    if (typeof(constructor) != 'function') {\r\n                                        throw new Error('Function expected');\r\n                                    }\r\n                                    return construct.apply(constructor, convertArgs(args));\r\n                                },\r\n\r\n                                invokeMethod: function (target, method, args) {\r\n                                    if (typeof(method) != 'function') {\r\n                                        throw new Error('Function expected');\r\n                                    }\r\n                                    return method.apply(target, convertArgs(args));\r\n                                },\r\n\r\n                                getStackTrace: function () {\r\n                                    try {\r\n                                        throw new Error('[stack trace]');\r\n                                    }\r\n                                    catch (exception) {\r\n                                        return exception.stack;\r\n                                    }\r\n                                    return '';\r\n                                }\r\n                            };\r\n                        })();\r\n                    ");
		if (flags.HasFlag(V8ScriptEngineFlags.EnableDebugging | V8ScriptEngineFlags.AwaitDebuggerAndPauseOnStart))
		{
			awaitDebuggerAndPause = true;
		}
	}

	public V8Script Compile(string code)
	{
		return Compile(null, code);
	}

	public V8Script Compile(string documentName, string code)
	{
		return Compile(new DocumentInfo(documentName), code);
	}

	public V8Script Compile(DocumentInfo documentInfo, string code)
	{
		VerifyNotDisposed();
		return ScriptInvoke(() => CompileInternal(documentInfo.MakeUnique(this), code));
	}

	public V8Script Compile(string code, V8CacheKind cacheKind, out byte[] cacheBytes)
	{
		return Compile(null, code, cacheKind, out cacheBytes);
	}

	public V8Script Compile(string documentName, string code, V8CacheKind cacheKind, out byte[] cacheBytes)
	{
		return Compile(new DocumentInfo(documentName), code, cacheKind, out cacheBytes);
	}

	public V8Script Compile(DocumentInfo documentInfo, string code, V8CacheKind cacheKind, out byte[] cacheBytes)
	{
		VerifyNotDisposed();
		V8Script tempScript = null;
		cacheBytes = ScriptInvoke(delegate
		{
			tempScript = CompileInternal(documentInfo.MakeUnique(this), code, cacheKind, out var cacheBytes2);
			return cacheBytes2;
		});
		return tempScript;
	}

	public V8Script Compile(string code, V8CacheKind cacheKind, byte[] cacheBytes, out bool cacheAccepted)
	{
		return Compile(null, code, cacheKind, cacheBytes, out cacheAccepted);
	}

	public V8Script Compile(string documentName, string code, V8CacheKind cacheKind, byte[] cacheBytes, out bool cacheAccepted)
	{
		return Compile(new DocumentInfo(documentName), code, cacheKind, cacheBytes, out cacheAccepted);
	}

	public V8Script Compile(DocumentInfo documentInfo, string code, V8CacheKind cacheKind, byte[] cacheBytes, out bool cacheAccepted)
	{
		VerifyNotDisposed();
		V8Script tempScript = null;
		cacheAccepted = ScriptInvoke(delegate
		{
			tempScript = CompileInternal(documentInfo.MakeUnique(this), code, cacheKind, cacheBytes, out var cacheAccepted2);
			return cacheAccepted2;
		});
		return tempScript;
	}

	public V8Script CompileDocument(string specifier)
	{
		return CompileDocument(specifier, null);
	}

	public V8Script CompileDocument(string specifier, DocumentCategory category)
	{
		return CompileDocument(specifier, category, null);
	}

	public V8Script CompileDocument(string specifier, DocumentCategory category, DocumentContextCallback contextCallback)
	{
		MiscHelpers.VerifyNonBlankArgument(specifier, "specifier", "Invalid document specifier");
		Document document = base.DocumentSettings.Loader.LoadDocument(base.DocumentSettings, null, specifier, category, contextCallback);
		return Compile(document.Info, document.GetTextContents());
	}

	public V8Script CompileDocument(string specifier, V8CacheKind cacheKind, out byte[] cacheBytes)
	{
		return CompileDocument(specifier, null, cacheKind, out cacheBytes);
	}

	public V8Script CompileDocument(string specifier, DocumentCategory category, V8CacheKind cacheKind, out byte[] cacheBytes)
	{
		return CompileDocument(specifier, category, null, cacheKind, out cacheBytes);
	}

	public V8Script CompileDocument(string specifier, DocumentCategory category, DocumentContextCallback contextCallback, V8CacheKind cacheKind, out byte[] cacheBytes)
	{
		MiscHelpers.VerifyNonBlankArgument(specifier, "specifier", "Invalid document specifier");
		Document document = base.DocumentSettings.Loader.LoadDocument(base.DocumentSettings, null, specifier, category, contextCallback);
		return Compile(document.Info, document.GetTextContents(), cacheKind, out cacheBytes);
	}

	public V8Script CompileDocument(string specifier, V8CacheKind cacheKind, byte[] cacheBytes, out bool cacheAccepted)
	{
		return CompileDocument(specifier, null, cacheKind, cacheBytes, out cacheAccepted);
	}

	public V8Script CompileDocument(string specifier, DocumentCategory category, V8CacheKind cacheKind, byte[] cacheBytes, out bool cacheAccepted)
	{
		return CompileDocument(specifier, category, null, cacheKind, cacheBytes, out cacheAccepted);
	}

	public V8Script CompileDocument(string specifier, DocumentCategory category, DocumentContextCallback contextCallback, V8CacheKind cacheKind, byte[] cacheBytes, out bool cacheAccepted)
	{
		MiscHelpers.VerifyNonBlankArgument(specifier, "specifier", "Invalid document specifier");
		Document document = base.DocumentSettings.Loader.LoadDocument(base.DocumentSettings, null, specifier, category, contextCallback);
		return Compile(document.Info, document.GetTextContents(), cacheKind, cacheBytes, out cacheAccepted);
	}

	public object Evaluate(V8Script script)
	{
		return Execute(script, evaluate: true);
	}

	public void Execute(V8Script script)
	{
		Execute(script, evaluate: false);
	}

	public V8RuntimeHeapInfo GetRuntimeHeapInfo()
	{
		VerifyNotDisposed();
		return proxy.GetRuntimeHeapInfo();
	}

	public bool BeginCpuProfile(string name)
	{
		return BeginCpuProfile(name, V8CpuProfileFlags.None);
	}

	public bool BeginCpuProfile(string name, V8CpuProfileFlags flags)
	{
		VerifyNotDisposed();
		return proxy.BeginCpuProfile(base.Name + ":" + name, flags);
	}

	public V8CpuProfile EndCpuProfile(string name)
	{
		VerifyNotDisposed();
		return proxy.EndCpuProfile(base.Name + ":" + name);
	}

	public void CollectCpuProfileSample()
	{
		VerifyNotDisposed();
		proxy.CollectCpuProfileSample();
	}

	internal V8Runtime.Statistics GetRuntimeStatistics()
	{
		VerifyNotDisposed();
		return proxy.GetRuntimeStatistics();
	}

	internal Statistics GetStatistics()
	{
		VerifyNotDisposed();
		return ScriptInvoke(delegate
		{
			Statistics statistics = proxy.GetStatistics();
			if (commonJSManager != null)
			{
				statistics.CommonJSModuleCacheSize = CommonJSManager.ModuleCacheSize;
			}
			return statistics;
		});
	}

	private object GetRootItem()
	{
		return MarshalToHost(ScriptInvoke(() => proxy.GetRootItem()), preserveHostTarget: false);
	}

	private void VerifyNotDisposed()
	{
		if (disposedFlag.IsSet)
		{
			throw new ObjectDisposedException(ToString());
		}
	}

	private object Execute(V8Script script, bool evaluate)
	{
		MiscHelpers.VerifyNonNullArgument(script, "script");
		VerifyNotDisposed();
		return MarshalToHost(ScriptInvoke(delegate
		{
			if (inContinuationTimerScope || base.ContinuationCallback == null)
			{
				if (MiscHelpers.Exchange(ref awaitDebuggerAndPause, value: false))
				{
					proxy.AwaitDebuggerAndPause();
				}
				return ExecuteInternal(script, evaluate);
			}
			Timer[] state = new Timer[1];
			using (state[0] = new Timer(delegate
			{
				OnContinuationTimer(state[0]);
			}, null, -1, -1))
			{
				inContinuationTimerScope = true;
				try
				{
					state[0].Change(2000, -1);
					if (MiscHelpers.Exchange(ref awaitDebuggerAndPause, value: false))
					{
						proxy.AwaitDebuggerAndPause();
					}
					return ExecuteInternal(script, evaluate);
				}
				finally
				{
					inContinuationTimerScope = false;
				}
			}
		}), preserveHostTarget: false);
	}

	private V8Script CompileInternal(UniqueDocumentInfo documentInfo, string code)
	{
		if (base.FormatCode)
		{
			code = MiscHelpers.FormatCode(code);
		}
		CommonJSManager.Module module = null;
		if (documentInfo.Category == ModuleCategory.CommonJS)
		{
			module = CommonJSManager.GetOrCreateModule(documentInfo, code);
			code = CommonJSManager.Module.GetAugmentedCode(code);
		}
		V8Script script = proxy.Compile(documentInfo, code);
		if (module != null)
		{
			module.Evaluator = () => proxy.Execute(script, evaluate: true);
		}
		return script;
	}

	private V8Script CompileInternal(UniqueDocumentInfo documentInfo, string code, V8CacheKind cacheKind, out byte[] cacheBytes)
	{
		if (base.FormatCode)
		{
			code = MiscHelpers.FormatCode(code);
		}
		CommonJSManager.Module module = null;
		if (documentInfo.Category == ModuleCategory.CommonJS)
		{
			module = CommonJSManager.GetOrCreateModule(documentInfo, code);
			code = CommonJSManager.Module.GetAugmentedCode(code);
		}
		V8Script script = proxy.Compile(documentInfo, code, cacheKind, out cacheBytes);
		if (module != null)
		{
			module.Evaluator = () => proxy.Execute(script, evaluate: true);
		}
		return script;
	}

	private V8Script CompileInternal(UniqueDocumentInfo documentInfo, string code, V8CacheKind cacheKind, byte[] cacheBytes, out bool cacheAccepted)
	{
		if (base.FormatCode)
		{
			code = MiscHelpers.FormatCode(code);
		}
		CommonJSManager.Module module = null;
		if (documentInfo.Category == ModuleCategory.CommonJS)
		{
			module = CommonJSManager.GetOrCreateModule(documentInfo, code);
			code = CommonJSManager.Module.GetAugmentedCode(code);
		}
		V8Script script = proxy.Compile(documentInfo, code, cacheKind, cacheBytes, out cacheAccepted);
		if (module != null)
		{
			module.Evaluator = () => proxy.Execute(script, evaluate: true);
		}
		return script;
	}

	private object ExecuteInternal(UniqueDocumentInfo documentInfo, string code, bool evaluate)
	{
		if (base.FormatCode)
		{
			code = MiscHelpers.FormatCode(code);
		}
		if (documentInfo.Category == ModuleCategory.CommonJS)
		{
			CommonJSManager.Module orCreateModule = CommonJSManager.GetOrCreateModule(documentInfo, code);
			return orCreateModule.Process();
		}
		return ExecuteRaw(documentInfo, code, evaluate);
	}

	private object ExecuteInternal(V8Script script, bool evaluate)
	{
		if (script.UniqueDocumentInfo.Category == ModuleCategory.CommonJS)
		{
			CommonJSManager.Module orCreateModule = CommonJSManager.GetOrCreateModule(script.UniqueDocumentInfo, script.CodeDigest, () => proxy.Execute(script, evaluate));
			return orCreateModule.Process();
		}
		return proxy.Execute(script, evaluate);
	}

	private void OnContinuationTimer(Timer timer)
	{
		try
		{
			ContinuationCallback continuationCallback = base.ContinuationCallback;
			if (continuationCallback != null && !continuationCallback())
			{
				Interrupt();
			}
			else
			{
				timer.Change(2000, -1);
			}
		}
		catch (ObjectDisposedException)
		{
		}
	}

	public override string ExecuteCommand(string command)
	{
		return ScriptInvoke(delegate
		{
			Script.EngineInternal.command = command;
			return base.ExecuteCommand("EngineInternal.getCommandResult(eval(EngineInternal.command))");
		});
	}

	public override string GetStackTrace()
	{
		string text = Script.EngineInternal.getStackTrace();
		string[] source = text.Split('\n');
		return string.Join("\n", source.Skip(2));
	}

	public override void Interrupt()
	{
		VerifyNotDisposed();
		proxy.Interrupt();
	}

	public override void CollectGarbage(bool exhaustive)
	{
		VerifyNotDisposed();
		proxy.CollectGarbage(exhaustive);
	}

	internal override void AddHostItem(string itemName, HostItemFlags flags, object item)
	{
		VerifyNotDisposed();
		bool globalMembers = flags.HasFlag(HostItemFlags.GlobalMembers);
		if (globalMembers && engineFlags.HasFlag(V8ScriptEngineFlags.DisableGlobalMembers))
		{
			throw new InvalidOperationException("GlobalMembers support is disabled in this script engine");
		}
		MiscHelpers.VerifyNonNullArgument(itemName, "itemName");
		ScriptInvoke(delegate
		{
			object obj = MarshalToScript(item, flags);
			if (!(obj is HostItem))
			{
				throw new InvalidOperationException("Invalid host item");
			}
			proxy.AddGlobalItem(itemName, obj, globalMembers);
		});
	}

	internal override object MarshalToScript(object obj, HostItemFlags flags)
	{
		if (obj == null)
		{
			return DBNull.Value;
		}
		if (obj is Undefined)
		{
			return null;
		}
		if (obj is Nonexistent)
		{
			return obj;
		}
		if (obj is Nothing)
		{
			return null;
		}
		if (engineFlags.HasFlag(V8ScriptEngineFlags.EnableDateTimeConversion) && obj is DateTime)
		{
			return obj;
		}
		if (obj is HostItem hostItem)
		{
			if (hostItem.Engine == this && hostItem.Flags == flags)
			{
				return obj;
			}
			obj = hostItem.Target;
		}
		HostTarget hostTarget = obj as HostTarget;
		if (hostTarget != null && !(hostTarget is IHostVariable))
		{
			obj = hostTarget.Target;
		}
		if (obj is ScriptItem scriptItem && scriptItem.Engine == this)
		{
			return scriptItem.Unwrap();
		}
		return HostItem.Wrap(this, hostTarget ?? obj, flags);
	}

	internal override object MarshalToHost(object obj, bool preserveHostTarget)
	{
		if (obj == null)
		{
			return Undefined.Value;
		}
		if (obj is DBNull)
		{
			return null;
		}
		if (MiscHelpers.TryMarshalPrimitiveToHost(obj, out var result))
		{
			return result;
		}
		if (obj is HostTarget hostTarget)
		{
			if (!preserveHostTarget)
			{
				return hostTarget.Target;
			}
			return hostTarget;
		}
		if (obj is HostItem hostItem)
		{
			if (!preserveHostTarget)
			{
				return hostItem.Unwrap();
			}
			return hostItem.Target;
		}
		if (obj is ScriptItem)
		{
			return obj;
		}
		return V8ScriptItem.Wrap(this, obj);
	}

	internal override object Execute(UniqueDocumentInfo documentInfo, string code, bool evaluate)
	{
		VerifyNotDisposed();
		return ScriptInvoke(delegate
		{
			if (documentNames != null && !documentInfo.Flags.GetValueOrDefault().HasFlag(DocumentFlags.IsTransient))
			{
				documentNames.Add(documentInfo.UniqueName);
			}
			if (inContinuationTimerScope || base.ContinuationCallback == null)
			{
				if (MiscHelpers.Exchange(ref awaitDebuggerAndPause, value: false))
				{
					proxy.AwaitDebuggerAndPause();
				}
				return ExecuteInternal(documentInfo, code, evaluate);
			}
			Timer[] state = new Timer[1];
			using (state[0] = new Timer(delegate
			{
				OnContinuationTimer(state[0]);
			}, null, -1, -1))
			{
				inContinuationTimerScope = true;
				try
				{
					state[0].Change(2000, -1);
					if (MiscHelpers.Exchange(ref awaitDebuggerAndPause, value: false))
					{
						proxy.AwaitDebuggerAndPause();
					}
					return ExecuteInternal(documentInfo, code, evaluate);
				}
				finally
				{
					inContinuationTimerScope = false;
				}
			}
		});
	}

	internal override object ExecuteRaw(UniqueDocumentInfo documentInfo, string code, bool evaluate)
	{
		return proxy.Execute(documentInfo, code, evaluate);
	}

	internal override void OnAccessSettingsChanged()
	{
		base.OnAccessSettingsChanged();
		ScriptInvoke(delegate
		{
			proxy.OnAccessSettingsChanged();
		});
	}

	internal override void ScriptInvoke(Action action)
	{
		VerifyNotDisposed();
		using (CreateEngineScope())
		{
			proxy.InvokeWithLock(delegate
			{
				ScriptInvokeInternal(action);
			});
		}
	}

	internal override T ScriptInvoke<T>(Func<T> func)
	{
		VerifyNotDisposed();
		using (CreateEngineScope())
		{
			T result = default(T);
			proxy.InvokeWithLock(delegate
			{
				result = ScriptInvokeInternal(func);
			});
			return result;
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposedFlag.Set() && disposing)
		{
			((IDisposable)script).Dispose();
			proxy.Dispose();
		}
	}

	internal void EnableDocumentNameTracking()
	{
		documentNames = new List<string>();
	}

	internal IEnumerable<string> GetDocumentNames()
	{
		return documentNames;
	}
}
