using System;
using System.Runtime.Serialization;
using Microsoft.ClearScript.Util;

namespace Microsoft.ClearScript;

[Serializable]
public class ScriptInterruptedException : OperationCanceledException, IScriptEngineException
{
	private readonly string engineName;

	private const string engineNameItemName = "ScriptEngineName";

	private readonly string errorDetails;

	private const string errorDetailsItemName = "ScriptErrorDetails";

	private readonly bool isFatal;

	private const string isFatalItemName = "IsFatal";

	private readonly bool executionStarted;

	private const string executionStartedItemName = "ExecutionStarted";

	private readonly object scriptException;

	private const string defaultMessage = "Script execution was interrupted";

	int IScriptEngineException.HResult => base.HResult;

	public string EngineName => engineName;

	public string ErrorDetails => errorDetails;

	public bool IsFatal => isFatal;

	public bool ExecutionStarted => executionStarted;

	public dynamic ScriptException => scriptException;

	public ScriptInterruptedException()
		: base("Script execution was interrupted")
	{
		errorDetails = base.Message;
	}

	public ScriptInterruptedException(string message)
		: base(MiscHelpers.EnsureNonBlank(message, "Script execution was interrupted"))
	{
		errorDetails = base.Message;
	}

	public ScriptInterruptedException(string message, Exception innerException)
		: base(MiscHelpers.EnsureNonBlank(message, "Script execution was interrupted"), innerException)
	{
		errorDetails = base.Message;
	}

	protected ScriptInterruptedException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		engineName = info.GetString("ScriptEngineName");
		errorDetails = info.GetString("ScriptErrorDetails");
		isFatal = info.GetBoolean("IsFatal");
		executionStarted = info.GetBoolean("ExecutionStarted");
	}

	internal ScriptInterruptedException(string engineName, string message, string errorDetails, int errorCode, bool isFatal, bool executionStarted, object scriptException, Exception innerException)
		: base(MiscHelpers.EnsureNonBlank(message, "Script execution was interrupted"), innerException)
	{
		this.engineName = engineName;
		this.errorDetails = MiscHelpers.EnsureNonBlank(errorDetails, base.Message);
		this.isFatal = isFatal;
		this.executionStarted = executionStarted;
		this.scriptException = scriptException;
		if (errorCode != 0)
		{
			base.HResult = errorCode;
		}
	}

	public override string ToString()
	{
		string text = base.ToString();
		if (!string.IsNullOrEmpty(errorDetails) && errorDetails != Message)
		{
			string text2 = "   " + errorDetails.Replace("\n", "\n   ");
			text = text + "\n   --- Script error details follow ---\n" + text2;
		}
		return text;
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue("ScriptEngineName", engineName);
		info.AddValue("ScriptErrorDetails", errorDetails);
		info.AddValue("IsFatal", isFatal);
		info.AddValue("ExecutionStarted", executionStarted);
	}
}
