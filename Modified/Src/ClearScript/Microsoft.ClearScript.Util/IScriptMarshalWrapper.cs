namespace Microsoft.ClearScript.Util;

internal interface IScriptMarshalWrapper
{
	ScriptEngine Engine { get; }

	object Unwrap();
}
