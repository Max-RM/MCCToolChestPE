using System;

namespace Microsoft.ClearScript;

public interface IScriptEngineException
{
	string Message { get; }

	int HResult { get; }

	string EngineName { get; }

	string ErrorDetails { get; }

	bool IsFatal { get; }

	bool ExecutionStarted { get; }

	dynamic ScriptException { get; }

	Exception InnerException { get; }
}
