using System;
using Microsoft.ClearScript.JavaScript;
using Microsoft.ClearScript.Util;

namespace Microsoft.ClearScript.V8;

public sealed class V8Runtime : IDisposable
{
	internal sealed class Statistics
	{
		public ulong ScriptCount;

		public ulong ScriptCacheSize;

		public ulong ModuleCount;
	}

	private readonly string name;

	private static readonly IUniqueNameManager nameManager = new UniqueNameManager();

	private readonly IUniqueNameManager documentNameManager = new UniqueFileNameManager();

	private readonly HostItemCollateral hostItemCollateral = new HostItemCollateral();

	private DocumentSettings documentSettings;

	private readonly DocumentSettings defaultDocumentSettings = new DocumentSettings();

	private readonly V8IsolateProxy proxy;

	private readonly InterlockedOneWayFlag disposedFlag = new InterlockedOneWayFlag();

	public string Name => name;

	public bool FormatCode { get; set; }

	public UIntPtr MaxHeapSize
	{
		get
		{
			VerifyNotDisposed();
			return proxy.MaxHeapSize;
		}
		set
		{
			VerifyNotDisposed();
			proxy.MaxHeapSize = value;
		}
	}

	public TimeSpan HeapSizeSampleInterval
	{
		get
		{
			VerifyNotDisposed();
			return proxy.HeapSizeSampleInterval;
		}
		set
		{
			VerifyNotDisposed();
			proxy.HeapSizeSampleInterval = value;
		}
	}

	public UIntPtr MaxStackUsage
	{
		get
		{
			VerifyNotDisposed();
			return proxy.MaxStackUsage;
		}
		set
		{
			VerifyNotDisposed();
			proxy.MaxStackUsage = value;
		}
	}

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

	internal IUniqueNameManager DocumentNameManager => documentNameManager;

	internal HostItemCollateral HostItemCollateral => hostItemCollateral;

	internal V8IsolateProxy IsolateProxy
	{
		get
		{
			VerifyNotDisposed();
			return proxy;
		}
	}

	public V8Runtime()
		: this(null, null)
	{
	}

	public V8Runtime(string name)
		: this(name, null)
	{
	}

	public V8Runtime(V8RuntimeConstraints constraints)
		: this(null, constraints)
	{
	}

	public V8Runtime(string name, V8RuntimeConstraints constraints)
		: this(name, constraints, V8RuntimeFlags.None)
	{
	}

	public V8Runtime(V8RuntimeFlags flags)
		: this(flags, 0)
	{
	}

	public V8Runtime(V8RuntimeFlags flags, int debugPort)
		: this(null, null, flags, debugPort)
	{
	}

	public V8Runtime(string name, V8RuntimeFlags flags)
		: this(name, flags, 0)
	{
	}

	public V8Runtime(string name, V8RuntimeFlags flags, int debugPort)
		: this(name, null, flags, debugPort)
	{
	}

	public V8Runtime(V8RuntimeConstraints constraints, V8RuntimeFlags flags)
		: this(constraints, flags, 0)
	{
	}

	public V8Runtime(V8RuntimeConstraints constraints, V8RuntimeFlags flags, int debugPort)
		: this(null, constraints, flags, debugPort)
	{
	}

	public V8Runtime(string name, V8RuntimeConstraints constraints, V8RuntimeFlags flags)
		: this(name, constraints, flags, 0)
	{
	}

	public V8Runtime(string name, V8RuntimeConstraints constraints, V8RuntimeFlags flags, int debugPort)
	{
		this.name = nameManager.GetUniqueName(name, GetType().GetRootName());
		proxy = V8IsolateProxy.Create(this.name, constraints, flags, debugPort);
	}

	public V8ScriptEngine CreateScriptEngine()
	{
		return CreateScriptEngine(null);
	}

	public V8ScriptEngine CreateScriptEngine(string engineName)
	{
		return CreateScriptEngine(engineName, V8ScriptEngineFlags.None);
	}

	public V8ScriptEngine CreateScriptEngine(V8ScriptEngineFlags flags)
	{
		return CreateScriptEngine(null, flags);
	}

	public V8ScriptEngine CreateScriptEngine(V8ScriptEngineFlags flags, int debugPort)
	{
		return CreateScriptEngine(null, flags, debugPort);
	}

	public V8ScriptEngine CreateScriptEngine(string engineName, V8ScriptEngineFlags flags)
	{
		return CreateScriptEngine(engineName, flags, 0);
	}

	public V8ScriptEngine CreateScriptEngine(string engineName, V8ScriptEngineFlags flags, int debugPort)
	{
		VerifyNotDisposed();
		return new V8ScriptEngine(this, engineName, null, flags, debugPort)
		{
			FormatCode = FormatCode
		};
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
		return CompileInternal(documentInfo.MakeUnique(documentNameManager), code);
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
		return CompileInternal(documentInfo.MakeUnique(documentNameManager), code, cacheKind, out cacheBytes);
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
		return CompileInternal(documentInfo.MakeUnique(documentNameManager), code, cacheKind, cacheBytes, out cacheAccepted);
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
		Document document = DocumentSettings.Loader.LoadDocument(DocumentSettings, null, specifier, category, contextCallback);
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
		Document document = DocumentSettings.Loader.LoadDocument(DocumentSettings, null, specifier, category, contextCallback);
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
		Document document = DocumentSettings.Loader.LoadDocument(DocumentSettings, null, specifier, category, contextCallback);
		return Compile(document.Info, document.GetTextContents(), cacheKind, cacheBytes, out cacheAccepted);
	}

	public V8RuntimeHeapInfo GetHeapInfo()
	{
		VerifyNotDisposed();
		return proxy.GetHeapInfo();
	}

	public void CollectGarbage(bool exhaustive)
	{
		VerifyNotDisposed();
		proxy.CollectGarbage(exhaustive);
	}

	public bool BeginCpuProfile(string name)
	{
		return BeginCpuProfile(name, V8CpuProfileFlags.None);
	}

	public bool BeginCpuProfile(string name, V8CpuProfileFlags flags)
	{
		VerifyNotDisposed();
		return proxy.BeginCpuProfile(name, flags);
	}

	public V8CpuProfile EndCpuProfile(string name)
	{
		VerifyNotDisposed();
		return proxy.EndCpuProfile(name);
	}

	public void CollectCpuProfileSample()
	{
		VerifyNotDisposed();
		proxy.CollectCpuProfileSample();
	}

	internal Statistics GetStatistics()
	{
		VerifyNotDisposed();
		return proxy.GetStatistics();
	}

	private void VerifyNotDisposed()
	{
		if (disposedFlag.IsSet)
		{
			throw new ObjectDisposedException(ToString());
		}
	}

	private V8Script CompileInternal(UniqueDocumentInfo documentInfo, string code)
	{
		if (FormatCode)
		{
			code = MiscHelpers.FormatCode(code);
		}
		if (documentInfo.Category == ModuleCategory.CommonJS)
		{
			code = CommonJSManager.Module.GetAugmentedCode(code);
		}
		return proxy.Compile(documentInfo, code);
	}

	private V8Script CompileInternal(UniqueDocumentInfo documentInfo, string code, V8CacheKind cacheKind, out byte[] cacheBytes)
	{
		if (FormatCode)
		{
			code = MiscHelpers.FormatCode(code);
		}
		if (documentInfo.Category == ModuleCategory.CommonJS)
		{
			code = CommonJSManager.Module.GetAugmentedCode(code);
		}
		return proxy.Compile(documentInfo, code, cacheKind, out cacheBytes);
	}

	private V8Script CompileInternal(UniqueDocumentInfo documentInfo, string code, V8CacheKind cacheKind, byte[] cacheBytes, out bool cacheAccepted)
	{
		if (FormatCode)
		{
			code = MiscHelpers.FormatCode(code);
		}
		if (documentInfo.Category == ModuleCategory.CommonJS)
		{
			code = CommonJSManager.Module.GetAugmentedCode(code);
		}
		return proxy.Compile(documentInfo, code, cacheKind, cacheBytes, out cacheAccepted);
	}

	public void Dispose()
	{
		if (disposedFlag.Set())
		{
			proxy.Dispose();
		}
	}
}
