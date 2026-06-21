namespace Microsoft.ClearScript;

public interface IScriptableObject
{
	void OnExposedToScriptCode(ScriptEngine engine);
}
