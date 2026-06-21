using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.ClearScript.Util;

namespace Microsoft.ClearScript.JavaScript;

internal sealed class CommonJSManager
{
	public sealed class Module
	{
		private readonly CommonJSManager manager;

		private readonly ScriptEngine engine;

		private object module;

		private object exports;

		private object require;

		private ScriptObject function;

		private bool invoked;

		private const string codePrefix = "(function (module, exports, require) {\n";

		private const string codeSuffix = "\n}).valueOf()";

		public UniqueDocumentInfo DocumentInfo { get; private set; }

		public UIntPtr CodeDigest { get; private set; }

		public Func<object> Evaluator { get; set; }

		public Module(CommonJSManager manager, ScriptEngine engine, UniqueDocumentInfo documentInfo, UIntPtr codeDigest, string code)
			: this(manager, engine, documentInfo, codeDigest, () => engine.ExecuteRaw(documentInfo, GetAugmentedCode(code), evaluate: true))
		{
		}

		public Module(CommonJSManager manager, ScriptEngine engine, UniqueDocumentInfo documentInfo, UIntPtr codeDigest, Func<object> evaluator)
		{
			this.manager = manager;
			this.engine = engine;
			DocumentInfo = documentInfo;
			CodeDigest = codeDigest;
			Evaluator = evaluator;
		}

		public static string GetAugmentedCode(string code)
		{
			return "(function (module, exports, require) {\n" + code + "\n}).valueOf()";
		}

		public object Process()
		{
			if (module == null)
			{
				string text = ((DocumentInfo.Uri != null) ? DocumentInfo.Uri.AbsoluteUri : DocumentInfo.UniqueName);
				string text2 = ((DocumentInfo.Uri != null) ? text : null);
				Action<object, object> action = Initialize;
				Func<string, object> func = Require;
				Func<ScriptObject, ScriptObject> func2 = InitializeContext;
				module = manager.createModule.Invoke(false, text, text2, action, func, func2, typeof(CommonJSLegacyModule).ToHostType(engine));
			}
			if (function == null)
			{
				function = (ScriptObject)engine.MarshalToHost(engine.ScriptInvoke(() => Evaluator()), preserveHostTarget: false);
			}
			if (!invoked)
			{
				invoked = true;
				object result = function.Invoke(false, module, exports, require);
				exports = ((dynamic)module).exports;
				return result;
			}
			return Undefined.Value;
		}

		private void Initialize(object scriptExports, object scriptRequire)
		{
			exports = scriptExports;
			require = scriptRequire;
		}

		private object Require(string specifier)
		{
			DocumentSettings documentSettings = engine.DocumentSettings;
			Document document = documentSettings.Loader.LoadDocument(documentSettings, DocumentInfo.Info, specifier, ModuleCategory.CommonJS, null);
			string code = document.GetTextContents();
			if (engine.FormatCode)
			{
				code = MiscHelpers.FormatCode(code);
			}
			Module orCreateModule = manager.GetOrCreateModule(document.Info.MakeUnique(engine), code);
			orCreateModule.Process();
			return orCreateModule.exports;
		}

		private ScriptObject InitializeContext(ScriptObject context)
		{
			DocumentContextCallback documentContextCallback = DocumentInfo.ContextCallback ?? engine.DocumentSettings.ContextCallback;
			if (documentContextCallback != null)
			{
				IDictionary<string, object> dictionary = documentContextCallback(DocumentInfo.Info);
				if (dictionary != null)
				{
					foreach (KeyValuePair<string, object> item in dictionary)
					{
						context.SetProperty(item.Key, item.Value);
					}
				}
			}
			return context;
		}
	}

	private readonly ScriptEngine engine;

	private readonly ScriptObject createModule;

	private readonly List<Module> moduleCache = new List<Module>();

	private const int maxModuleCacheSize = 1024;

	private static readonly DocumentInfo createModuleInfo = new DocumentInfo("CommonJS-createModule [internal]");

	public int ModuleCacheSize => moduleCache.Count;

	public CommonJSManager(ScriptEngine engine)
	{
		this.engine = engine;
		if (((IJavaScriptEngine)engine).BaseLanguageVersion >= 5)
		{
			createModule = (ScriptObject)engine.Evaluate(createModuleInfo, "\r\n                    (function (id, uri, hostInitialize, hostRequire, initializeContext) {\r\n                        'use strict';\r\n                        var module = {}, exports = {}, context;\r\n                        Object.defineProperty(module, 'id', { value: id });\r\n                        if (uri) {\r\n                            Object.defineProperty(module, 'uri', { value: uri });\r\n                        }\r\n                        module.exports = exports;\r\n                        Object.defineProperty(module, 'meta', { get: function () {\r\n                            return context || (context = initializeContext({}));\r\n                        }});\r\n                        hostInitialize(exports, function (moduleId) {\r\n                            return hostRequire(moduleId);\r\n                        });\r\n                        return module;\r\n                    }).valueOf()\r\n                ");
		}
		else
		{
			createModule = (ScriptObject)engine.Evaluate(createModuleInfo, "\r\n                    (function (id, uri, hostInitialize, hostRequire, initializeContext, LegacyModule) {\r\n                        'use strict';\r\n                        var exports = {};\r\n                        hostInitialize(exports, function (moduleId) {\r\n                            return hostRequire(moduleId);\r\n                        });\r\n                        return new LegacyModule(id, uri, exports, {}, initializeContext);\r\n                    }).valueOf()\r\n                ");
		}
	}

	public Module GetOrCreateModule(UniqueDocumentInfo documentInfo, string code)
	{
		UIntPtr digest = code.GetDigest();
		Module cachedModule = GetCachedModule(documentInfo, digest);
		if (cachedModule != null)
		{
			return cachedModule;
		}
		return CacheModule(new Module(this, engine, documentInfo, digest, code));
	}

	public Module GetOrCreateModule(UniqueDocumentInfo documentInfo, UIntPtr codeDigest, Func<object> evaluator)
	{
		Module cachedModule = GetCachedModule(documentInfo, codeDigest);
		if (cachedModule != null)
		{
			return cachedModule;
		}
		return CacheModule(new Module(this, engine, documentInfo, codeDigest, evaluator));
	}

	private Module GetCachedModule(UniqueDocumentInfo documentInfo, UIntPtr codeDigest)
	{
		for (int i = 0; i < moduleCache.Count; i++)
		{
			Module module = moduleCache[i];
			if (module.DocumentInfo.UniqueId == documentInfo.UniqueId && module.CodeDigest == codeDigest)
			{
				moduleCache.RemoveAt(i);
				moduleCache.Insert(0, module);
				return module;
			}
		}
		return null;
	}

	private Module CacheModule(Module module)
	{
		Module module2 = moduleCache.FirstOrDefault((Module testModule) => testModule.DocumentInfo.UniqueId == module.DocumentInfo.UniqueId && testModule.CodeDigest == module.CodeDigest);
		if (module2 != null)
		{
			return module2;
		}
		while (moduleCache.Count >= 1024)
		{
			moduleCache.RemoveAt(moduleCache.Count - 1);
		}
		moduleCache.Insert(0, module);
		return module;
	}
}
