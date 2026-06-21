using System;

namespace Microsoft.ClearScript.JavaScript;

public sealed class CommonJSLegacyModule
{
	private readonly ScriptObject context;

	private readonly Func<ScriptObject, ScriptObject> initializeContext;

	private ScriptObject initializedContext;

	public string id { get; private set; }

	public string uri { get; private set; }

	public object exports { get; set; }

	public object meta => GetInitializedContext();

	public CommonJSLegacyModule(string id, string uri, object exports, ScriptObject context, Func<ScriptObject, ScriptObject> initializeContext)
	{
		this.context = context;
		this.initializeContext = initializeContext;
		this.id = id;
		this.uri = uri;
		this.exports = exports;
	}

	private ScriptObject GetInitializedContext()
	{
		if (initializedContext == null)
		{
			initializedContext = initializeContext(context);
		}
		return initializedContext;
	}
}
