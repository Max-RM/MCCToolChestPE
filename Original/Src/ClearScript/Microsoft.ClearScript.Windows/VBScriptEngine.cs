using System;
using System.Collections.Generic;
using Microsoft.ClearScript.Util;

namespace Microsoft.ClearScript.Windows;

public class VBScriptEngine : WindowsScriptEngine
{
	private static readonly Dictionary<int, string> runtimeErrorMap = new Dictionary<int, string>
	{
		{ 429, "ActiveX component can't create object" },
		{ 507, "An exception occurred" },
		{ 449, "Argument not optional" },
		{ 17, "Can't perform requested operation" },
		{ 430, "Class doesn't support Automation" },
		{ 506, "Class not defined" },
		{ 11, "Division by zero" },
		{ 48, "Error in loading DLL" },
		{ 5020, "Expected ')' in regular expression" },
		{ 5019, "Expected ']' in regular expression" },
		{ 432, "File name or class name not found during Automation operation" },
		{ 92, "For loop not initialized" },
		{ 5008, "Illegal assignment" },
		{ 51, "Internal error" },
		{ 505, "Invalid or unqualified reference" },
		{ 481, "Invalid picture" },
		{ 5, "Invalid procedure call or argument" },
		{ 5021, "Invalid range in character set" },
		{ 94, "Invalid use of Null" },
		{ 448, "Named argument not found" },
		{ 447, "Object doesn't support current locale setting" },
		{ 445, "Object doesn't support this action" },
		{ 438, "Object doesn't support this property or method" },
		{ 451, "Object not a collection" },
		{ 504, "Object not safe for creating" },
		{ 503, "Object not safe for initializing" },
		{ 502, "Object not safe for scripting" },
		{ 424, "Object required" },
		{ 91, "Object variable not set" },
		{ 7, "Out of Memory" },
		{ 28, "Out of stack space" },
		{ 14, "Out of string space" },
		{ 6, "Overflow" },
		{ 35, "Sub or function not defined" },
		{ 9, "Subscript out of range" },
		{ 5017, "Syntax error in regular expression" },
		{ 462, "The remote server machine does not exist or is unavailable" },
		{ 10, "This array is fixed or temporarily locked" },
		{ 13, "Type mismatch" },
		{ 5018, "Unexpected quantifier" },
		{ 500, "Variable is undefined" },
		{ 458, "Variable uses an Automation type not supported in VBScript" },
		{ 450, "Wrong number of arguments or invalid property assignment" }
	};

	private static readonly Dictionary<int, string> syntaxErrorMap = new Dictionary<int, string>
	{
		{ 1052, "Cannot have multiple default property/method in a Class" },
		{ 1044, "Cannot use parentheses when calling a Sub" },
		{ 1053, "Class initialize or terminate do not have arguments" },
		{ 1058, "'Default' specification can only be on Property Get" },
		{ 1057, "'Default' specification must also specify 'Public'" },
		{ 1005, "Expected '('" },
		{ 1006, "Expected ')'" },
		{ 1011, "Expected '='" },
		{ 1021, "Expected 'Case'" },
		{ 1047, "Expected 'Class'" },
		{ 1025, "Expected end of statement" },
		{ 1014, "Expected 'End'" },
		{ 1023, "Expected expression" },
		{ 1015, "Expected 'Function'" },
		{ 1010, "Expected identifier" },
		{ 1012, "Expected 'If'" },
		{ 1046, "Expected 'In'" },
		{ 1026, "Expected integer constant" },
		{ 1049, "Expected Let or Set or Get in property declaration" },
		{ 1045, "Expected literal constant" },
		{ 1019, "Expected 'Loop'" },
		{ 1020, "Expected 'Next'" },
		{ 1050, "Expected 'Property'" },
		{ 1022, "Expected 'Select'" },
		{ 1024, "Expected statement" },
		{ 1016, "Expected 'Sub'" },
		{ 1017, "Expected 'Then'" },
		{ 1013, "Expected 'To'" },
		{ 1018, "Expected 'Wend'" },
		{ 1027, "Expected 'While' or 'Until'" },
		{ 1028, "Expected 'While,' 'Until,' or end of statement" },
		{ 1029, "Expected 'With'" },
		{ 1030, "Identifier too long" },
		{ 1032, "Invalid character" },
		{ 1039, "Invalid 'exit' statement" },
		{ 1040, "Invalid 'for' loop control variable" },
		{ 1031, "Invalid number" },
		{ 1037, "Invalid use of 'Me' keyword" },
		{ 1038, "'loop' without 'do'" },
		{ 1048, "Must be defined inside a Class" },
		{ 1042, "Must be first statement on the line" },
		{ 1041, "Name redefined" },
		{ 1051, "Number of arguments must be consistent across properties specification" },
		{ 1001, "Out of Memory" },
		{ 1054, "Property Set or Let must have at least one argument" },
		{ 1002, "Syntax error" },
		{ 1055, "Unexpected 'Next'" },
		{ 1033, "Unterminated string constant" }
	};

	public override string FileNameExtension => "vbs";

	internal override IDictionary<int, string> RuntimeErrorMap => runtimeErrorMap;

	internal override IDictionary<int, string> SyntaxErrorMap => syntaxErrorMap;

	public VBScriptEngine()
		: this(null)
	{
	}

	public VBScriptEngine(string name)
		: this(name, WindowsScriptEngineFlags.None)
	{
	}

	public VBScriptEngine(WindowsScriptEngineFlags flags)
		: this(null, flags)
	{
	}

	public VBScriptEngine(string name, WindowsScriptEngineFlags flags)
		: this("VBScript", name, flags)
	{
	}

	protected VBScriptEngine(string progID, string name, WindowsScriptEngineFlags flags)
		: this(progID, name, "vbs", flags)
	{
	}

	protected VBScriptEngine(string progID, string name, string fileNameExtensions, WindowsScriptEngineFlags flags)
		: base(progID, name, fileNameExtensions, flags)
	{
		Execute(MiscHelpers.FormatInvariant("{0} [internal]", GetType().Name), "\r\n                    class EngineInternalImpl\r\n                        public function getCommandResult(value)\r\n                            if IsObject(value) then\r\n                                if value is nothing then\r\n                                    getCommandResult = \"[nothing]\"\r\n                                else\r\n                                    dim valueTypeName\r\n                                    valueTypeName = TypeName(value)\r\n                                    if (valueTypeName = \"Object\" or valueTypeName = \"Unknown\") then\r\n                                        set getCommandResult = value\r\n                                    else\r\n                                        getCommandResult = \"[ScriptObject:\" & valueTypeName & \"]\"\r\n                                    end if\r\n                                end if\r\n                            elseif IsArray(value) then\r\n                                getCommandResult = \"[array]\"\r\n                            elseif IsNull(value) then\r\n                                getCommandResult = \"[null]\"\r\n                            elseif IsEmpty(value) then\r\n                                getCommandResult = \"[empty]\"\r\n                            else\r\n                                getCommandResult = CStr(value)\r\n                            end if\r\n                        end function\r\n                        public function invokeConstructor(constructor, args)\r\n                            Err.Raise 445\r\n                        end function\r\n                        public function invokeMethod(target, method, args)\r\n                            if IsObject(target) then\r\n                                if target is nothing then\r\n                                else\r\n                                    Err.Raise 445\r\n                                end if\r\n                            elseif IsNull(target) then\r\n                            elseif IsEmpty(target) then\r\n                            else\r\n                                Err.Raise 445\r\n                            end if\r\n                            dim count\r\n                            if IsArray(args) then\r\n                                count = UBound(args) + 1\r\n                                if count < 1 then\r\n                                    invokeMethod = method()\r\n                                elseif count = 1 then\r\n                                    invokeMethod = method(args(0))\r\n                                elseif count = 2 then\r\n                                    invokeMethod = method(args(0), args(1))\r\n                                elseif count = 3 then\r\n                                    invokeMethod = method(args(0), args(1), args(2))\r\n                                elseif count = 4 then\r\n                                    invokeMethod = method(args(0), args(1), args(2), args(3))\r\n                                elseif count = 5 then\r\n                                    invokeMethod = method(args(0), args(1), args(2), args(3), args(4))\r\n                                elseif count = 6 then\r\n                                    invokeMethod = method(args(0), args(1), args(2), args(3), args(4), args(5))\r\n                                elseif count = 7 then\r\n                                    invokeMethod = method(args(0), args(1), args(2), args(3), args(4), args(5), args(6))\r\n                                elseif count = 8 then\r\n                                    invokeMethod = method(args(0), args(1), args(2), args(3), args(4), args(5), args(6), args(7))\r\n                                elseif count = 9 then\r\n                                    invokeMethod = method(args(0), args(1), args(2), args(3), args(4), args(5), args(6), args(7), args(8))\r\n                                elseif count = 10 then\r\n                                    invokeMethod = method(args(0), args(1), args(2), args(3), args(4), args(5), args(6), args(7), args(8), args(9))\r\n                                elseif count = 11 then\r\n                                    invokeMethod = method(args(0), args(1), args(2), args(3), args(4), args(5), args(6), args(7), args(8), args(9), args(10))\r\n                                elseif count = 12 then\r\n                                    invokeMethod = method(args(0), args(1), args(2), args(3), args(4), args(5), args(6), args(7), args(8), args(9), args(10), args(11))\r\n                                elseif count = 13 then\r\n                                    invokeMethod = method(args(0), args(1), args(2), args(3), args(4), args(5), args(6), args(7), args(8), args(9), args(10), args(11), args(12))\r\n                                elseif count = 14 then\r\n                                    invokeMethod = method(args(0), args(1), args(2), args(3), args(4), args(5), args(6), args(7), args(8), args(9), args(10), args(11), args(12), args(13))\r\n                                elseif count = 15 then\r\n                                    invokeMethod = method(args(0), args(1), args(2), args(3), args(4), args(5), args(6), args(7), args(8), args(9), args(10), args(11), args(12), args(13), args(14))\r\n                                elseif count = 16 then\r\n                                    invokeMethod = method(args(0), args(1), args(2), args(3), args(4), args(5), args(6), args(7), args(8), args(9), args(10), args(11), args(12), args(13), args(14), args(15))\r\n                                else\r\n                                    Err.Raise 450\r\n                                end if\r\n                            else\r\n                                count = args.Length\r\n                                if count < 1 then\r\n                                    invokeMethod = method()\r\n                                elseif count = 1 then\r\n                                    invokeMethod = method(args.GetValue(0))\r\n                                elseif count = 2 then\r\n                                    invokeMethod = method(args.GetValue(0), args.GetValue(1))\r\n                                elseif count = 3 then\r\n                                    invokeMethod = method(args.GetValue(0), args.GetValue(1), args.GetValue(2))\r\n                                elseif count = 4 then\r\n                                    invokeMethod = method(args.GetValue(0), args.GetValue(1), args.GetValue(2), args.GetValue(3))\r\n                                elseif count = 5 then\r\n                                    invokeMethod = method(args.GetValue(0), args.GetValue(1), args.GetValue(2), args.GetValue(3), args.GetValue(4))\r\n                                elseif count = 6 then\r\n                                    invokeMethod = method(args.GetValue(0), args.GetValue(1), args.GetValue(2), args.GetValue(3), args.GetValue(4), args.GetValue(5))\r\n                                elseif count = 7 then\r\n                                    invokeMethod = method(args.GetValue(0), args.GetValue(1), args.GetValue(2), args.GetValue(3), args.GetValue(4), args.GetValue(5), args.GetValue(6))\r\n                                elseif count = 8 then\r\n                                    invokeMethod = method(args.GetValue(0), args.GetValue(1), args.GetValue(2), args.GetValue(3), args.GetValue(4), args.GetValue(5), args.GetValue(6), args.GetValue(7))\r\n                                elseif count = 9 then\r\n                                    invokeMethod = method(args.GetValue(0), args.GetValue(1), args.GetValue(2), args.GetValue(3), args.GetValue(4), args.GetValue(5), args.GetValue(6), args.GetValue(7), args.GetValue(8))\r\n                                elseif count = 10 then\r\n                                    invokeMethod = method(args.GetValue(0), args.GetValue(1), args.GetValue(2), args.GetValue(3), args.GetValue(4), args.GetValue(5), args.GetValue(6), args.GetValue(7), args.GetValue(8), args.GetValue(9))\r\n                                elseif count = 11 then\r\n                                    invokeMethod = method(args.GetValue(0), args.GetValue(1), args.GetValue(2), args.GetValue(3), args.GetValue(4), args.GetValue(5), args.GetValue(6), args.GetValue(7), args.GetValue(8), args.GetValue(9), args.GetValue(10))\r\n                                elseif count = 12 then\r\n                                    invokeMethod = method(args.GetValue(0), args.GetValue(1), args.GetValue(2), args.GetValue(3), args.GetValue(4), args.GetValue(5), args.GetValue(6), args.GetValue(7), args.GetValue(8), args.GetValue(9), args.GetValue(10), args.GetValue(11))\r\n                                elseif count = 13 then\r\n                                    invokeMethod = method(args.GetValue(0), args.GetValue(1), args.GetValue(2), args.GetValue(3), args.GetValue(4), args.GetValue(5), args.GetValue(6), args.GetValue(7), args.GetValue(8), args.GetValue(9), args.GetValue(10), args.GetValue(11), args.GetValue(12))\r\n                                elseif count = 14 then\r\n                                    invokeMethod = method(args.GetValue(0), args.GetValue(1), args.GetValue(2), args.GetValue(3), args.GetValue(4), args.GetValue(5), args.GetValue(6), args.GetValue(7), args.GetValue(8), args.GetValue(9), args.GetValue(10), args.GetValue(11), args.GetValue(12), args.GetValue(13))\r\n                                elseif count = 15 then\r\n                                    invokeMethod = method(args.GetValue(0), args.GetValue(1), args.GetValue(2), args.GetValue(3), args.GetValue(4), args.GetValue(5), args.GetValue(6), args.GetValue(7), args.GetValue(8), args.GetValue(9), args.GetValue(10), args.GetValue(11), args.GetValue(12), args.GetValue(13), args.GetValue(14))\r\n                                elseif count = 16 then\r\n                                    invokeMethod = method(args.GetValue(0), args.GetValue(1), args.GetValue(2), args.GetValue(3), args.GetValue(4), args.GetValue(5), args.GetValue(6), args.GetValue(7), args.GetValue(8), args.GetValue(9), args.GetValue(10), args.GetValue(11), args.GetValue(12), args.GetValue(13), args.GetValue(14), args.GetValue(15))\r\n                                else\r\n                                    Err.Raise 450\r\n                                end if\r\n                            end if\r\n                        end function\r\n                    end class\r\n                    set EngineInternal = new EngineInternalImpl\r\n                ");
	}

	public override string ExecuteCommand(string command)
	{
		string text = command.Trim();
		if (text.StartsWith("eval ", StringComparison.OrdinalIgnoreCase))
		{
			string code = MiscHelpers.FormatInvariant("EngineInternal.getCommandResult({0})", text.Substring(5));
			DocumentInfo documentInfo = new DocumentInfo("Expression");
			documentInfo.Flags = DocumentFlags.IsTransient;
			DocumentInfo documentInfo2 = documentInfo;
			return GetCommandResultString(Evaluate(documentInfo2.MakeUnique(this), code, marshalResult: false));
		}
		Execute("Command", discard: true, text);
		return null;
	}

	internal override object Execute(UniqueDocumentInfo documentInfo, string code, bool evaluate)
	{
		if (base.FormatCode)
		{
			code = MiscHelpers.FormatCode(code);
		}
		if (documentInfo.Category != DocumentCategory.Script)
		{
			throw new NotSupportedException(string.Concat("Engine cannot execute documents of type '", documentInfo.Category, "'"));
		}
		return base.Execute(documentInfo, code, evaluate);
	}
}
