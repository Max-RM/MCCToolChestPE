using System.Threading.Tasks;
using Microsoft.ClearScript.Util;

namespace Microsoft.ClearScript.JavaScript;

public static class JavaScriptExtensions
{
	private delegate void Executor(dynamic resolve, dynamic reject);

	public static object ToPromise<TResult>(this Task<TResult> task)
	{
		return task.ToPromise(ScriptEngine.Current);
	}

	public static object ToPromise<TResult>(this Task<TResult> task, ScriptEngine engine)
	{
		MiscHelpers.VerifyNonNullArgument(task, "task");
		MiscHelpers.VerifyNonNullArgument(engine, "engine");
		ScriptObject scriptObject = (ScriptObject)engine.Script.Promise;
		return scriptObject.Invoke(true, (Executor)delegate(dynamic resolve, dynamic reject)
		{
			task.ContinueWith(delegate(Task<TResult> thisTask)
			{
				if (thisTask.IsCompleted)
				{
					resolve(thisTask.Result);
				}
				else
				{
					reject(thisTask.Exception);
				}
			}, TaskContinuationOptions.ExecuteSynchronously);
		});
	}

	public static object ToPromise(this Task task)
	{
		return task.ToPromise(ScriptEngine.Current);
	}

	public static object ToPromise(this Task task, ScriptEngine engine)
	{
		MiscHelpers.VerifyNonNullArgument(task, "task");
		MiscHelpers.VerifyNonNullArgument(engine, "engine");
		ScriptObject scriptObject = (ScriptObject)engine.Script.Promise;
		return scriptObject.Invoke(true, (Executor)delegate(dynamic resolve, dynamic reject)
		{
			task.ContinueWith(delegate(Task thisTask)
			{
				if (thisTask.IsCompleted)
				{
					resolve();
				}
				else
				{
					reject(thisTask.Exception);
				}
			}, TaskContinuationOptions.ExecuteSynchronously);
		});
	}
}
