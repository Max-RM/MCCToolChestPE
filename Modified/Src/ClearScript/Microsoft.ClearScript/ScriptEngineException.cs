using System;
using System.Runtime.Serialization;
using Microsoft.ClearScript.Util;

namespace Microsoft.ClearScript;

[Serializable]
public class ScriptEngineException : InvalidOperationException, IScriptEngineException
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

	private const string defaultMessage = "An error occurred during script execution";

	int IScriptEngineException.HResult => base.HResult;

	public string EngineName => engineName;

	public string ErrorDetails => errorDetails;

	public bool IsFatal => isFatal;

	public bool ExecutionStarted => executionStarted;

	public dynamic ScriptException => scriptException;

	public ScriptEngineException()
		: base("An error occurred during script execution")
	{
		errorDetails = base.Message;
	}

	public ScriptEngineException(string message)
		: base(MiscHelpers.EnsureNonBlank(message, "An error occurred during script execution"))
	{
		errorDetails = base.Message;
	}

	public ScriptEngineException(string message, Exception innerException)
		: base(MiscHelpers.EnsureNonBlank(message, "An error occurred during script execution"), innerException)
	{
		errorDetails = base.Message;
	}

	protected ScriptEngineException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		engineName = info.GetString("ScriptEngineName");
		errorDetails = info.GetString("ScriptErrorDetails");
		isFatal = info.GetBoolean("IsFatal");
		executionStarted = info.GetBoolean("ExecutionStarted");
	}

	internal ScriptEngineException(string engineName, string message, string errorDetails, int errorCode, bool isFatal, bool executionStarted, object scriptException, Exception innerException)
		: base(MiscHelpers.EnsureNonBlank(message, "An error occurred during script execution"), innerException)
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
