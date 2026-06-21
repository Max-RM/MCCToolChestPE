using System;
using System.Collections.Generic;
using Microsoft.ClearScript.JavaScript;
using Microsoft.ClearScript.Util;

namespace Microsoft.ClearScript.Windows;

public class JScriptEngine : WindowsScriptEngine, IJavaScriptEngine
{
	private static readonly Dictionary<int, string> runtimeErrorMap = new Dictionary<int, string>
	{
		{ 5029, "Array length must be a finite positive integer" },
		{ 5030, "Array length must be assigned a finite positive number" },
		{ 5028, "Array or arguments object expected" },
		{ 5010, "Boolean expected" },
		{ 5003, "Cannot assign to a function result" },
		{ 5000, "Cannot assign to 'this'" },
		{ 5034, "Circular reference in value argument not supported" },
		{ 5006, "Date object expected" },
		{ 5015, "Enumerator object expected" },
		{ 5022, "Exception thrown and not caught" },
		{ 5020, "Expected ')' in regular expression" },
		{ 5019, "Expected ']' in regular expression" },
		{ 5023, "Function does not have a valid prototype object" },
		{ 5002, "Function expected" },
		{ 5008, "Illegal assignment" },
		{ 5021, "Invalid range in character set" },
		{ 5035, "Invalid replacer argument" },
		{ 5014, "JScript object expected" },
		{ 5001, "Number expected" },
		{ 5007, "Object expected" },
		{ 5012, "Object member expected" },
		{ 5016, "Regular Expression object expected" },
		{ 5005, "String expected" },
		{ 5017, "Syntax error in regular expression" },
		{ 5026, "The number of fractional digits is out of range" },
		{ 5027, "The precision is out of range" },
		{ 5025, "The URI to be decoded is not a valid encoding" },
		{ 5024, "The URI to be encoded contains an invalid character" },
		{ 5009, "Undefined identifier" },
		{ 5018, "Unexpected quantifier" },
		{ 5013, "VBArray expected" }
	};

	private static readonly Dictionary<int, string> syntaxErrorMap = new Dictionary<int, string>
	{
		{ 1019, "Can't have 'break' outside of loop" },
		{ 1020, "Can't have 'continue' outside of loop" },
		{ 1030, "Conditional compilation is turned off" },
		{ 1027, "'default' can only appear once in a 'switch' statement" },
		{ 1005, "Expected '('" },
		{ 1006, "Expected ')'" },
		{ 1012, "Expected '/'" },
		{ 1003, "Expected ':'" },
		{ 1004, "Expected ';'" },
		{ 1032, "Expected '@'" },
		{ 1029, "Expected '@end'" },
		{ 1007, "Expected ']'" },
		{ 1008, "Expected '{'" },
		{ 1009, "Expected '}'" },
		{ 1011, "Expected '='" },
		{ 1033, "Expected 'catch'" },
		{ 1031, "Expected constant" },
		{ 1023, "Expected hexadecimal digit" },
		{ 1010, "Expected identifier" },
		{ 1028, "Expected identifier, string or number" },
		{ 1024, "Expected 'while'" },
		{ 1014, "Invalid character" },
		{ 1026, "Label not found" },
		{ 1025, "Label redefined" },
		{ 1018, "'return' statement outside of function" },
		{ 1002, "Syntax error" },
		{ 1035, "Throw must be followed by an expression on the same source line" },
		{ 1016, "Unterminated comment" },
		{ 1015, "Unterminated string constant" }
	};

	private CommonJSManager commonJSManager;

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

	internal override IDictionary<int, string> RuntimeErrorMap => runtimeErrorMap;

	internal override IDictionary<int, string> SyntaxErrorMap => syntaxErrorMap;

	uint IJavaScriptEngine.BaseLanguageVersion => 3u;

	public JScriptEngine()
		: this(null)
	{
	}

	public JScriptEngine(string name)
		: this(name, WindowsScriptEngineFlags.None)
	{
	}

	public JScriptEngine(WindowsScriptEngineFlags flags)
		: this(null, flags)
	{
	}

	public JScriptEngine(string name, WindowsScriptEngineFlags flags)
		: this("JScript", name, flags)
	{
	}

	protected JScriptEngine(string progID, string name, WindowsScriptEngineFlags flags)
		: this(progID, name, "js", flags)
	{
	}

	protected JScriptEngine(string progID, string name, string fileNameExtensions, WindowsScriptEngineFlags flags)
		: base(progID, name, fileNameExtensions, flags)
	{
		Execute(MiscHelpers.FormatInvariant("{0} [internal]", GetType().Name), "\r\n                    EngineInternal = (function () {\r\n\r\n                        function convertArgs(args) {\r\n                            var result = [];\r\n                            if (args.GetValue) {\r\n                                var count = args.Length;\r\n                                for (var i = 0; i < count; i++) {\r\n                                    result.push(args[i]);\r\n                                }\r\n                            }\r\n                            else {\r\n                                args = new VBArray(args);\r\n                                var count = args.ubound(1) + 1;\r\n                                for (var i = 0; i < count; i++) {\r\n                                    result.push(args.getItem(i));\r\n                                }\r\n                            }\r\n                            return result;\r\n                        }\r\n\r\n                        function construct(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15) {\r\n                            return new this(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);\r\n                        }\r\n\r\n                        return {\r\n\r\n                            getCommandResult: function (value) {\r\n                                if (value != null) {\r\n                                    if ((typeof(value) == 'object') || (typeof(value) == 'function')) {\r\n                                        if (typeof(value.toString) == 'function') {\r\n                                            return value.toString();\r\n                                        }\r\n                                    }\r\n                                }\r\n                                return value;\r\n                            },\r\n\r\n                            invokeConstructor: function (constructor, args) {\r\n                                if (typeof(constructor) != 'function') {\r\n                                    throw new Error('Function expected');\r\n                                }\r\n                                return construct.apply(constructor, convertArgs(args));\r\n                            },\r\n\r\n                            invokeMethod: function (target, method, args) {\r\n                                if (typeof(method) != 'function') {\r\n                                    throw new Error('Function expected');\r\n                                }\r\n                                return method.apply(target, convertArgs(args));\r\n                            }\r\n                        };\r\n                    })();\r\n                ");
	}

	public override string ExecuteCommand(string command)
	{
		Script.EngineInternal.command = command;
		return base.ExecuteCommand("EngineInternal.getCommandResult(eval(EngineInternal.command))");
	}

	internal override object Execute(UniqueDocumentInfo documentInfo, string code, bool evaluate)
	{
		if (base.FormatCode)
		{
			code = MiscHelpers.FormatCode(code);
		}
		if (documentInfo.Category == ModuleCategory.CommonJS)
		{
			CommonJSManager.Module module = CommonJSManager.GetOrCreateModule(documentInfo, code);
			return ScriptInvoke(() => module.Process());
		}
		if (documentInfo.Category != DocumentCategory.Script)
		{
			throw new NotSupportedException(string.Concat("Engine cannot execute documents of type '", documentInfo.Category, "'"));
		}
		return base.Execute(documentInfo, code, evaluate);
	}
}
