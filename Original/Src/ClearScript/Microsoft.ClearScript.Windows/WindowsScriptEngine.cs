using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Threading;
using Microsoft.ClearScript.Util;

namespace Microsoft.ClearScript.Windows;

public abstract class WindowsScriptEngine : ScriptEngine
{
	private sealed class HostItemMap : Dictionary<string, object>
	{
	}

	private sealed class DebugDocument : IDebugDocumentInfo, IDebugDocumentProvider, IDebugDocument, IDebugDocumentText
	{
		private readonly WindowsScriptEngine engine;

		private readonly UIntPtr sourceContext;

		private readonly UniqueDocumentInfo documentInfo;

		private readonly string code;

		private string[] codeLines;

		private IDebugApplicationNode node;

		public string Code => code;

		public DebugDocument(WindowsScriptEngine engine, UIntPtr sourceContext, UniqueDocumentInfo documentInfo, string code)
		{
			this.engine = engine;
			this.sourceContext = sourceContext;
			this.documentInfo = documentInfo;
			this.code = code;
			Initialize();
		}

		private void Initialize()
		{
			codeLines = (from line in code.Split('\n')
				select line + "\n").ToArray();
			engine.debugApplication.CreateApplicationNode(out node);
			node.SetDocumentProvider(this);
			engine.debugApplication.GetRootNode(out var debugApplicationNode);
			node.Attach(debugApplicationNode);
		}

		public void Close()
		{
			node.Detach();
			node.Close();
			node = null;
		}

		private string GetFileName()
		{
			if (!Path.HasExtension(documentInfo.Name))
			{
				return Path.ChangeExtension(documentInfo.Name, engine.FileNameExtension);
			}
			return documentInfo.Name;
		}

		private string GetUrl()
		{
			if (documentInfo.Uri != null)
			{
				if (!documentInfo.Uri.IsAbsoluteUri)
				{
					return documentInfo.Uri.ToString();
				}
				return documentInfo.Uri.AbsoluteUri;
			}
			return MiscHelpers.FormatInvariant("{0}/{1}", engine.Name, GetFileName());
		}

		private bool TryGetSourceMapUrl(out string sourceMapUrl)
		{
			if (documentInfo.SourceMapUri != null)
			{
				sourceMapUrl = (documentInfo.SourceMapUri.IsAbsoluteUri ? documentInfo.SourceMapUri.AbsoluteUri : documentInfo.SourceMapUri.ToString());
				return true;
			}
			sourceMapUrl = null;
			return false;
		}

		public uint GetName(DocumentNameType type, out string documentName)
		{
			switch (type)
			{
			case DocumentNameType.Title:
				documentName = documentInfo.Name;
				return 0u;
			case DocumentNameType.FileTail:
				documentName = GetFileName();
				return 0u;
			case DocumentNameType.URL:
				documentName = GetUrl();
				return 0u;
			case DocumentNameType.AppNode:
			case DocumentNameType.UniqueTitle:
				documentName = documentInfo.UniqueName;
				return 0u;
			case DocumentNameType.SourceMapURL:
				if (!TryGetSourceMapUrl(out documentName))
				{
					return RawCOMHelpers.HResult.E_FAIL.ToUnsigned();
				}
				return 0u;
			default:
				documentName = null;
				return RawCOMHelpers.HResult.E_FAIL.ToUnsigned();
			}
		}

		public void GetDocumentClassId(out Guid clsid)
		{
			clsid = Guid.Empty;
		}

		public void GetDocument(out IDebugDocument document)
		{
			document = this;
		}

		public void GetDocumentAttributes(out TextDocAttrs attrs)
		{
			attrs = TextDocAttrs.ReadOnly;
		}

		public void GetSize(out uint numLines, out uint length)
		{
			numLines = (uint)codeLines.Length;
			length = (uint)code.Length;
		}

		public void GetPositionOfLine(uint lineNumber, out uint position)
		{
			if (lineNumber >= codeLines.Length)
			{
				throw new ArgumentOutOfRangeException("lineNumber");
			}
			position = 0u;
			for (int i = 0; i < lineNumber; i++)
			{
				position += (uint)codeLines[i].Length;
			}
		}

		public void GetLineOfPosition(uint position, out uint lineNumber, out uint offsetInLine)
		{
			if (position >= code.Length)
			{
				throw new ArgumentOutOfRangeException("position");
			}
			offsetInLine = position;
			lineNumber = 0u;
			while (lineNumber < codeLines.Length)
			{
				uint length = (uint)codeLines[lineNumber].Length;
				if (offsetInLine >= length)
				{
					offsetInLine -= length;
					lineNumber++;
					continue;
				}
				break;
			}
		}

		public void GetText(uint position, IntPtr pChars, IntPtr pAttrs, ref uint length, uint maxChars)
		{
			uint length2 = (uint)code.Length;
			if (position < length2)
			{
				length = Math.Min(length2 - position, maxChars);
				if (pChars != IntPtr.Zero)
				{
					Marshal.Copy(code.ToCharArray(), (int)position, pChars, (int)length);
				}
				if (pAttrs != IntPtr.Zero)
				{
					short[] source = Enumerable.Repeat((short)0, (int)length).ToArray();
					Marshal.Copy(source, 0, pAttrs, (int)length);
				}
			}
		}

		public void GetPositionOfContext(IDebugDocumentContext context, out uint position, out uint length)
		{
			DebugDocumentContext debugDocumentContext = (DebugDocumentContext)context;
			position = debugDocumentContext.Position;
			length = debugDocumentContext.Length;
		}

		public void GetContextOfPosition(uint position, uint length, out IDebugDocumentContext context)
		{
			engine.activeScript.EnumCodeContextsOfPosition(sourceContext, position, length, out var enumContexts);
			context = new DebugDocumentContext(this, position, length, enumContexts);
		}
	}

	private sealed class DebugDocumentMap : Dictionary<UIntPtr, DebugDocument>
	{
	}

	private sealed class DebugDocumentContext : IDebugDocumentContext
	{
		private readonly DebugDocument document;

		private readonly uint position;

		private readonly uint length;

		private readonly IEnumDebugCodeContexts enumCodeContexts;

		public uint Position => position;

		public uint Length => length;

		public DebugDocumentContext(DebugDocument document, uint position, uint length, IEnumDebugCodeContexts enumCodeContexts)
		{
			this.document = document;
			this.position = position;
			this.length = length;
			this.enumCodeContexts = enumCodeContexts;
		}

		public void GetDocument(out IDebugDocument debugDocument)
		{
			debugDocument = document;
		}

		public void EnumCodeContexts(out IEnumDebugCodeContexts enumContexts)
		{
			enumCodeContexts.Clone(out enumContexts);
		}
	}

	private sealed class ScriptSite : IActiveScriptSite, IActiveScriptSiteInterruptPoll, IActiveScriptSiteWindow, IActiveScriptSiteDebug32, IActiveScriptSiteDebug64, IActiveScriptSiteDebugEx, ICustomQueryInterface
	{
		private readonly WindowsScriptEngine engine;

		public ScriptSite(WindowsScriptEngine engine)
		{
			this.engine = engine;
		}

		private string GetDetails(object error, string message)
		{
			if (engine.processDebugManager != null)
			{
				try
				{
					bool flag = false;
					if (error is IActiveScriptError activeScriptError)
					{
						activeScriptError.GetExceptionInfo(out var excepInfo);
						if (RawCOMHelpers.HResult.GetFacility(excepInfo.scode) == 10)
						{
							flag = engine.SyntaxErrorMap.ContainsKey(RawCOMHelpers.HResult.GetCode(excepInfo.scode));
						}
					}
					if (flag)
					{
						string text = message;
						string errorLocation = GetErrorLocation(error);
						if (!string.IsNullOrWhiteSpace(errorLocation))
						{
							text = text + "\n" + errorLocation;
						}
						string stackTraceInternal = engine.GetStackTraceInternal();
						if (!string.IsNullOrWhiteSpace(stackTraceInternal))
						{
							text = text + "\n" + stackTraceInternal;
						}
						return text;
					}
					string stackTraceInternal2 = engine.GetStackTraceInternal();
					if (!string.IsNullOrWhiteSpace(stackTraceInternal2))
					{
						return message + "\n" + stackTraceInternal2;
					}
					string errorLocation2 = GetErrorLocation(error);
					if (!string.IsNullOrWhiteSpace(errorLocation2))
					{
						return message + "\n" + errorLocation2;
					}
				}
				catch (Exception)
				{
				}
			}
			return message;
		}

		private string GetErrorLocation(object error)
		{
			if (error is IActiveScriptError activeScriptError)
			{
				activeScriptError.GetSourcePosition(out var sourceContext, out var lineNumber, out var position);
				if (engine.debugDocumentMap.TryGetValue(new UIntPtr(sourceContext), out var value))
				{
					value.GetName(DocumentNameType.UniqueTitle, out var documentName);
					int count;
					if (lineNumber != 0)
					{
						value.GetPositionOfLine(lineNumber, out var position2);
						count = (int)position2 + position;
					}
					else
					{
						count = position;
					}
					string text = new string(value.Code.Skip(count).TakeWhile((char ch) => ch != '\n').ToArray());
					return MiscHelpers.FormatInvariant("    at ({0}:{1}:{2}) -> {3}", documentName, lineNumber, position, text);
				}
			}
			return null;
		}

		public void GetLCID(out uint lcid)
		{
			lcid = (uint)CultureInfo.CurrentCulture.LCID;
		}

		public void GetItemInfo(string name, ScriptInfoFlags mask, ref IntPtr pUnkItem, ref IntPtr pTypeInfo)
		{
			object obj = engine.hostItemMap[name];
			if (mask.HasFlag(ScriptInfoFlags.IUnknown))
			{
				pUnkItem = Marshal.GetIDispatchForObject(obj);
			}
			if (mask.HasFlag(ScriptInfoFlags.ITypeInfo))
			{
				pTypeInfo = Marshal.GetITypeInfoForType(obj.GetType());
			}
		}

		public void GetDocVersionString(out string version)
		{
			throw new NotImplementedException();
		}

		public void OnScriptTerminate(IntPtr pVarResult, ref System.Runtime.InteropServices.ComTypes.EXCEPINFO excepInfo)
		{
		}

		public void OnStateChange(ScriptState state)
		{
		}

		public void OnScriptError(IActiveScriptError error)
		{
			if (engine.CurrentScriptFrame == null || error == null)
			{
				return;
			}
			error.GetExceptionInfo(out var excepInfo);
			if (excepInfo.scode == RawCOMHelpers.HResult.E_ABORT)
			{
				engine.activeScript.SetScriptState(ScriptState.Started);
				string message = excepInfo.bstrDescription ?? "Script execution interrupted by host";
				engine.CurrentScriptFrame.ScriptError = new ScriptInterruptedException(engine.Name, message, GetDetails(error, message), excepInfo.scode, isFatal: false, executionStarted: true, null, null);
				return;
			}
			string text = excepInfo.bstrDescription;
			Exception ex;
			if (excepInfo.scode != RawCOMHelpers.HResult.CLEARSCRIPT_E_HOSTEXCEPTION)
			{
				ex = null;
			}
			else
			{
				ex = engine.CurrentScriptFrame.HostException;
				if (ex != null && string.IsNullOrWhiteSpace(text))
				{
					text = ex.Message;
				}
			}
			engine.CurrentScriptFrame.ScriptError = new ScriptEngineException(engine.Name, text, GetDetails(error, text), excepInfo.scode, isFatal: false, executionStarted: true, null, ex);
		}

		public void OnEnterScript()
		{
		}

		public void OnLeaveScript()
		{
		}

		public uint QueryContinue()
		{
			bool flag = engine.ContinuationCallback?.Invoke() ?? true;
			if (engine.CurrentScriptFrame != null)
			{
				flag = flag && !engine.CurrentScriptFrame.InterruptRequested;
			}
			if (!flag)
			{
				return RawCOMHelpers.HResult.E_ABORT.ToUnsigned();
			}
			return 0u;
		}

		public void GetWindow(out IntPtr hwnd)
		{
			hwnd = engine.HostWindow?.OwnerHandle ?? IntPtr.Zero;
		}

		public void EnableModeless(bool enable)
		{
			engine.HostWindow?.EnableModeless(enable);
		}

		public void GetDocumentContextFromPosition(uint sourceContext, uint offset, uint length, out IDebugDocumentContext context)
		{
			context = null;
			if (engine.debugDocumentMap.TryGetValue(new UIntPtr(sourceContext), out var value))
			{
				value.GetContextOfPosition(offset, length, out context);
			}
		}

		public void GetApplication(out IDebugApplication32 application)
		{
			application = DebugApplicationWrapper32.Unwrap(engine.debugApplication);
		}

		public void GetRootApplicationNode(out IDebugApplicationNode node)
		{
			engine.debugApplication.GetRootNode(out node);
		}

		public void OnScriptErrorDebug(IActiveScriptErrorDebug errorDebug, out bool enterDebugger, out bool callOnScriptErrorWhenContinuing)
		{
			if (engine.CurrentScriptFrame != null && errorDebug != null)
			{
				errorDebug.GetExceptionInfo(out var excepInfo);
				if (excepInfo.scode == RawCOMHelpers.HResult.E_ABORT)
				{
					string message = excepInfo.bstrDescription ?? "Script execution interrupted by host";
					engine.CurrentScriptFrame.PendingScriptError = new ScriptInterruptedException(engine.Name, message, GetDetails(errorDebug, message), excepInfo.scode, isFatal: false, executionStarted: true, null, null);
				}
				else
				{
					string text = excepInfo.bstrDescription;
					Exception ex;
					if (excepInfo.scode != RawCOMHelpers.HResult.CLEARSCRIPT_E_HOSTEXCEPTION)
					{
						ex = null;
					}
					else
					{
						ex = engine.CurrentScriptFrame.HostException;
						if (ex != null && string.IsNullOrWhiteSpace(text))
						{
							text = ex.Message;
						}
					}
					engine.CurrentScriptFrame.PendingScriptError = new ScriptEngineException(engine.Name, text, GetDetails(errorDebug, text), excepInfo.scode, isFatal: false, executionStarted: true, null, ex);
				}
			}
			enterDebugger = engine.engineFlags.HasFlag(WindowsScriptEngineFlags.EnableJITDebugging);
			callOnScriptErrorWhenContinuing = true;
		}

		public void GetDocumentContextFromPosition(ulong sourceContext, uint offset, uint length, out IDebugDocumentContext context)
		{
			context = null;
			if (engine.debugDocumentMap.TryGetValue(new UIntPtr(sourceContext), out var value))
			{
				value.GetContextOfPosition(offset, length, out context);
			}
		}

		public void GetApplication(out IDebugApplication64 application)
		{
			application = DebugApplicationWrapper64.Unwrap(engine.debugApplication);
		}

		public void OnCanNotJITScriptErrorDebug(IActiveScriptErrorDebug errorDebug, out bool callOnScriptErrorWhenContinuing)
		{
			OnScriptErrorDebug(errorDebug, out var _, out callOnScriptErrorWhenContinuing);
		}

		public CustomQueryInterfaceResult GetInterface(ref Guid iid, out IntPtr pInterface)
		{
			pInterface = IntPtr.Zero;
			if (iid == typeof(IActiveScriptSiteDebug32).GUID || iid == typeof(IActiveScriptSiteDebug64).GUID || iid == typeof(IActiveScriptSiteDebugEx).GUID)
			{
				if (engine.processDebugManager == null)
				{
					return CustomQueryInterfaceResult.Failed;
				}
				return CustomQueryInterfaceResult.NotHandled;
			}
			if (iid == typeof(IActiveScriptSiteWindow).GUID)
			{
				if (engine.HostWindow == null)
				{
					return CustomQueryInterfaceResult.Failed;
				}
				return CustomQueryInterfaceResult.NotHandled;
			}
			return CustomQueryInterfaceResult.NotHandled;
		}
	}

	private static readonly object nullDispatch = new DispatchWrapper(null);

	private ActiveScriptWrapper activeScript;

	private WindowsScriptEngineFlags engineFlags;

	private readonly HostItemMap hostItemMap = new HostItemMap();

	private readonly HostItemCollateral hostItemCollateral = new HostItemCollateral();

	private readonly object script;

	private ProcessDebugManagerWrapper processDebugManager;

	private DebugApplicationWrapper debugApplication;

	private uint debugApplicationCookie;

	private readonly IUniqueNameManager debugDocumentNameManager = new UniqueFileNameManager();

	private bool sourceManagement;

	private readonly DebugDocumentMap debugDocumentMap = new DebugDocumentMap();

	private uint nextSourceContext = 1u;

	private readonly Dispatcher dispatcher = Dispatcher.CurrentDispatcher;

	private readonly InterlockedOneWayFlag disposedFlag = new InterlockedOneWayFlag();

	public Dispatcher Dispatcher
	{
		get
		{
			VerifyNotDisposed();
			return dispatcher;
		}
	}

	public IHostWindow HostWindow { get; set; }

	internal abstract IDictionary<int, string> RuntimeErrorMap { get; }

	internal abstract IDictionary<int, string> SyntaxErrorMap { get; }

	public override dynamic Script
	{
		get
		{
			VerifyNotDisposed();
			return script;
		}
	}

	internal override IUniqueNameManager DocumentNameManager => debugDocumentNameManager;

	internal override HostItemCollateral HostItemCollateral => hostItemCollateral;

	[Obsolete("Use WindowsScriptEngine(string progID, string name, string fileNameExtensions, WindowsScriptEngineFlags flags) instead.")]
	protected WindowsScriptEngine(string progID, string name, WindowsScriptEngineFlags flags)
		: this(progID, name, null, flags)
	{
	}

	protected WindowsScriptEngine(string progID, string name, string fileNameExtensions, WindowsScriptEngineFlags flags)
		: base(name, fileNameExtensions)
	{
		WindowsScriptEngine windowsScriptEngine = this;
		script = base.ScriptInvoke(delegate
		{
			windowsScriptEngine.activeScript = ActiveScriptWrapper.Create(progID, flags);
			windowsScriptEngine.engineFlags = flags;
			if (flags.HasFlag(WindowsScriptEngineFlags.EnableDebugging) && ProcessDebugManagerWrapper.TryCreate(out windowsScriptEngine.processDebugManager))
			{
				windowsScriptEngine.processDebugManager.CreateApplication(out windowsScriptEngine.debugApplication);
				windowsScriptEngine.debugApplication.SetName(windowsScriptEngine.Name);
				if (windowsScriptEngine.processDebugManager.TryAddApplication(windowsScriptEngine.debugApplication, out windowsScriptEngine.debugApplicationCookie))
				{
					windowsScriptEngine.sourceManagement = !flags.HasFlag(WindowsScriptEngineFlags.DisableSourceManagement);
				}
				else
				{
					windowsScriptEngine.debugApplication.Close();
					windowsScriptEngine.debugApplication = null;
					windowsScriptEngine.processDebugManager = null;
				}
			}
			windowsScriptEngine.activeScript.SetScriptSite(new ScriptSite(windowsScriptEngine));
			windowsScriptEngine.activeScript.InitNew();
			windowsScriptEngine.activeScript.SetScriptState(ScriptState.Started);
			return WindowsScriptItem.Wrap(windowsScriptEngine, windowsScriptEngine.GetScriptDispatch());
		});
	}

	public bool CheckAccess()
	{
		VerifyNotDisposed();
		return dispatcher.CheckAccess();
	}

	public void VerifyAccess()
	{
		VerifyNotDisposed();
		dispatcher.VerifyAccess();
	}

	private object GetScriptDispatch()
	{
		activeScript.GetScriptDispatch(null, out var dispatch);
		return dispatch;
	}

	private void Parse(UniqueDocumentInfo documentInfo, string code, ScriptTextFlags flags, IntPtr pVarResult, out System.Runtime.InteropServices.ComTypes.EXCEPINFO excepInfo)
	{
		DebugDocument document;
		UIntPtr uIntPtr = CreateDebugDocument(documentInfo, code, out document);
		if (uIntPtr != UIntPtr.Zero)
		{
			flags |= ScriptTextFlags.HostManagesSource;
		}
		try
		{
			activeScript.ParseScriptText(code, null, null, null, uIntPtr, 0u, flags, pVarResult, out excepInfo);
		}
		finally
		{
			if (documentInfo.Flags.GetValueOrDefault().HasFlag(DocumentFlags.IsTransient) && uIntPtr != UIntPtr.Zero)
			{
				debugDocumentMap.Remove(uIntPtr);
				document.Close();
			}
		}
	}

	private UIntPtr CreateDebugDocument(UniqueDocumentInfo documentInfo, string code, out DebugDocument document)
	{
		UIntPtr uIntPtr;
		if (!sourceManagement)
		{
			uIntPtr = UIntPtr.Zero;
			document = null;
		}
		else
		{
			uIntPtr = new UIntPtr(nextSourceContext++);
			document = new DebugDocument(this, uIntPtr, documentInfo, code);
			debugDocumentMap[uIntPtr] = document;
		}
		return uIntPtr;
	}

	private string GetStackTraceInternal()
	{
		string text = string.Empty;
		activeScript.EnumStackFrames(out var enumFrames);
		while (true)
		{
			enumFrames.Next(1u, out var descriptor, out var countFetched);
			if (countFetched < 1)
			{
				break;
			}
			try
			{
				descriptor.Frame.GetDescriptionString(longString: true, out var description);
				descriptor.Frame.GetCodeContext(out var context);
				context.GetDocumentContext(out var context2);
				if (context2 == null)
				{
					text += MiscHelpers.FormatInvariant("    at {0}\n", description);
					continue;
				}
				context2.GetDocument(out var document);
				IDebugDocumentText debugDocumentText = (IDebugDocumentText)document;
				document.GetName(DocumentNameType.UniqueTitle, out var text2);
				debugDocumentText.GetPositionOfContext(context2, out var position, out var length);
				using CoTaskMemArrayBlock coTaskMemArrayBlock = new CoTaskMemArrayBlock(2, (int)length);
				uint length2 = 0u;
				debugDocumentText.GetText(position, coTaskMemArrayBlock.Addr, IntPtr.Zero, ref length2, length);
				string text3 = Marshal.PtrToStringUni(coTaskMemArrayBlock.Addr, (int)length2);
				debugDocumentText.GetLineOfPosition(position, out var lineNumber, out var offsetInLine);
				text += MiscHelpers.FormatInvariant("    at {0} ({1}:{2}:{3}) -> {4}\n", description, text2, lineNumber, offsetInLine, text3);
			}
			finally
			{
				if (descriptor.pFinalObject != IntPtr.Zero)
				{
					Marshal.Release(descriptor.pFinalObject);
				}
			}
		}
		return text.TrimEnd('\n');
	}

	private void VerifyNotDisposed()
	{
		if (disposedFlag.IsSet)
		{
			throw new ObjectDisposedException(ToString());
		}
	}

	private static bool GetDirectAccessItem(object item, out object directAccessItem)
	{
		while (true)
		{
			if (item is IScriptMarshalWrapper scriptMarshalWrapper)
			{
				item = scriptMarshalWrapper.Unwrap();
				continue;
			}
			if (!(item is HostTarget hostTarget))
			{
				break;
			}
			item = hostTarget.Target;
		}
		if (item != null && item.GetType().IsCOMObject)
		{
			directAccessItem = item;
			return true;
		}
		directAccessItem = null;
		return false;
	}

	private object MarshalToScriptInternal(object obj, HostItemFlags flags, HashSet<Array> marshaledArraySet)
	{
		if (obj == null)
		{
			if (engineFlags.HasFlag(WindowsScriptEngineFlags.MarshalNullAsDispatch))
			{
				return nullDispatch;
			}
			return DBNull.Value;
		}
		if (obj is Undefined)
		{
			return null;
		}
		if (obj is Nonexistent)
		{
			return null;
		}
		if (obj is Nothing)
		{
			return nullDispatch;
		}
		if (engineFlags.HasFlag(WindowsScriptEngineFlags.MarshalDecimalAsCurrency) && obj is decimal)
		{
			return new CurrencyWrapper(obj);
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
		if (engineFlags.HasFlag(WindowsScriptEngineFlags.MarshalArraysByValue))
		{
			Array array = obj as Array;
			if (array != null && (hostTarget == null || typeof(Array).IsAssignableFrom(hostTarget.Type)))
			{
				bool flag;
				if (marshaledArraySet != null)
				{
					flag = marshaledArraySet.Contains(array);
				}
				else
				{
					marshaledArraySet = new HashSet<Array>();
					flag = false;
				}
				if (!flag)
				{
					marshaledArraySet.Add(array);
					int[] source = Enumerable.Range(0, array.Rank).ToArray();
					Array marshaledArray = Array.CreateInstance(typeof(object), source.Select(array.GetLength).ToArray(), source.Select(array.GetLowerBound).ToArray());
					array.Iterate(delegate(int[] indices)
					{
						marshaledArray.SetValue(MarshalToScriptInternal(array.GetValue(indices), flags, marshaledArraySet), indices);
					});
					return marshaledArray;
				}
				return MarshalToScriptInternal(null, flags, marshaledArraySet);
			}
		}
		return HostItem.Wrap(this, hostTarget ?? obj, flags);
	}

	private object MarshalToHostInternal(object obj, bool preserveHostTarget, HashSet<Array> marshaledArraySet)
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
		Array array = obj as Array;
		if (array != null)
		{
			bool flag;
			if (marshaledArraySet != null)
			{
				flag = marshaledArraySet.Contains(array);
			}
			else
			{
				marshaledArraySet = new HashSet<Array>();
				flag = false;
			}
			if (!flag)
			{
				marshaledArraySet.Add(array);
				array.Iterate(delegate(int[] indices)
				{
					array.SetValue(MarshalToHostInternal(array.GetValue(indices), preserveHostTarget, marshaledArraySet), indices);
				});
			}
			return array;
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
		return WindowsScriptItem.Wrap(this, obj);
	}

	private void ThrowHostException(Exception exception)
	{
		if (base.CurrentScriptFrame != null)
		{
			base.CurrentScriptFrame.HostException = exception;
			throw new COMException(exception.Message, RawCOMHelpers.HResult.CLEARSCRIPT_E_HOSTEXCEPTION);
		}
	}

	private void ThrowScriptError(Exception exception)
	{
		if (!(exception is COMException ex))
		{
			return;
		}
		if (ex.ErrorCode == RawCOMHelpers.HResult.SCRIPT_E_REPORTED)
		{
			ScriptEngine.ThrowScriptError(base.CurrentScriptFrame.ScriptError ?? base.CurrentScriptFrame.PendingScriptError);
		}
		else if (ex.ErrorCode == RawCOMHelpers.HResult.CLEARSCRIPT_E_HOSTEXCEPTION)
		{
			Exception hostException = base.CurrentScriptFrame.HostException;
			if (hostException != null)
			{
				throw new ScriptEngineException(base.Name, hostException.Message, null, RawCOMHelpers.HResult.CLEARSCRIPT_E_HOSTEXCEPTION, isFatal: false, executionStarted: true, null, hostException);
			}
		}
	}

	public override string GetStackTrace()
	{
		VerifyNotDisposed();
		if (processDebugManager == null)
		{
			return string.Empty;
		}
		return ScriptInvoke(() => GetStackTraceInternal());
	}

	public override void Interrupt()
	{
		VerifyNotDisposed();
		System.Runtime.InteropServices.ComTypes.EXCEPINFO excepInfo = new System.Runtime.InteropServices.ComTypes.EXCEPINFO
		{
			scode = RawCOMHelpers.HResult.E_ABORT
		};
		activeScript.InterruptScriptThread(4294967294u, ref excepInfo, ScriptInterruptFlags.None);
	}

	public override void CollectGarbage(bool exhaustive)
	{
		VerifyNotDisposed();
		ScriptInvoke(delegate
		{
			activeScript.CollectGarbage(exhaustive ? ScriptGCType.Exhaustive : ScriptGCType.Normal);
		});
	}

	internal override void AddHostItem(string itemName, HostItemFlags flags, object item)
	{
		VerifyNotDisposed();
		MiscHelpers.VerifyNonNullArgument(itemName, "itemName");
		ScriptInvoke(delegate
		{
			if (!flags.HasFlag(HostItemFlags.DirectAccess) || !GetDirectAccessItem(item, out var directAccessItem))
			{
				directAccessItem = MarshalToScript(item, flags);
				if (!(directAccessItem is HostItem))
				{
					throw new InvalidOperationException("Invalid host item");
				}
			}
			object obj = ((IDictionary)hostItemMap)[(object)itemName];
			hostItemMap[itemName] = directAccessItem;
			ScriptItemFlags scriptItemFlags = ScriptItemFlags.IsVisible;
			if (flags.HasFlag(HostItemFlags.GlobalMembers))
			{
				scriptItemFlags |= ScriptItemFlags.GlobalMembers;
			}
			try
			{
				activeScript.AddNamedItem(itemName, scriptItemFlags);
			}
			catch (Exception)
			{
				if (obj != null)
				{
					hostItemMap[itemName] = obj;
				}
				else
				{
					hostItemMap.Remove(itemName);
				}
				throw;
			}
		});
	}

	internal override object PrepareResult(object result, Type type, ScriptMemberFlags flags, bool isListIndexResult)
	{
		object obj = base.PrepareResult(result, type, flags, isListIndexResult);
		if (obj != null || !engineFlags.HasFlag(WindowsScriptEngineFlags.MarshalNullAsDispatch))
		{
			return obj;
		}
		if (type == typeof(object) || type == typeof(string) || type == typeof(bool?) || type.IsNullableNumeric())
		{
			return DBNull.Value;
		}
		return null;
	}

	internal override object MarshalToScript(object obj, HostItemFlags flags)
	{
		return MarshalToScriptInternal(obj, flags, null);
	}

	internal override object MarshalToHost(object obj, bool preserveHostTarget)
	{
		return MarshalToHostInternal(obj, preserveHostTarget, null);
	}

	internal override object Execute(UniqueDocumentInfo documentInfo, string code, bool evaluate)
	{
		VerifyNotDisposed();
		return ScriptInvoke(() => ExecuteRaw(documentInfo, code, evaluate));
	}

	internal sealed override object ExecuteRaw(UniqueDocumentInfo documentInfo, string code, bool evaluate)
	{
		System.Runtime.InteropServices.ComTypes.EXCEPINFO excepInfo;
		if (!evaluate)
		{
			Parse(documentInfo, code, ScriptTextFlags.IsVisible, IntPtr.Zero, out excepInfo);
			return null;
		}
		using CoTaskMemVariantBlock coTaskMemVariantBlock = new CoTaskMemVariantBlock();
		Parse(documentInfo, code, ScriptTextFlags.IsExpression, coTaskMemVariantBlock.Addr, out excepInfo);
		return Marshal.GetObjectForNativeVariant(coTaskMemVariantBlock.Addr);
	}

	internal override void HostInvoke(Action action)
	{
		try
		{
			base.HostInvoke(action);
		}
		catch (Exception exception)
		{
			ThrowHostException(exception);
			throw;
		}
	}

	internal override T HostInvoke<T>(Func<T> func)
	{
		try
		{
			return base.HostInvoke(func);
		}
		catch (Exception exception)
		{
			ThrowHostException(exception);
			throw;
		}
	}

	internal override void ScriptInvoke(Action action)
	{
		VerifyAccess();
		base.ScriptInvoke(delegate
		{
			try
			{
				action();
			}
			catch (Exception exception)
			{
				ThrowScriptError(exception);
				throw;
			}
		});
	}

	internal override T ScriptInvoke<T>(Func<T> func)
	{
		VerifyAccess();
		return base.ScriptInvoke(delegate
		{
			try
			{
				return func();
			}
			catch (Exception exception)
			{
				ThrowScriptError(exception);
				throw;
			}
		});
	}

	internal override void SyncInvoke(Action action)
	{
		dispatcher.Invoke(DispatcherPriority.Send, action);
	}

	internal override T SyncInvoke<T>(Func<T> func)
	{
		return (T)dispatcher.Invoke(DispatcherPriority.Send, func);
	}

	protected override void Dispose(bool disposing)
	{
		if (!disposedFlag.Set() || !disposing)
		{
			return;
		}
		if (sourceManagement)
		{
			debugDocumentMap.Values.ForEach(delegate(DebugDocument debugDocument)
			{
				debugDocument.Close();
			});
		}
		if (processDebugManager != null)
		{
			processDebugManager.RemoveApplication(debugApplicationCookie);
			debugApplication.Close();
		}
		((IDisposable)script).Dispose();
		activeScript.Close();
	}

	internal IEnumerable<string> GetDebugDocumentNames()
	{
		return debugDocumentMap.Values.Select(delegate(DebugDocument debugDocument)
		{
			debugDocument.GetName(DocumentNameType.UniqueTitle, out var documentName);
			return documentName;
		});
	}
}
