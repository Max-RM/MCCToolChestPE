using System;

namespace Microsoft.ClearScript.Util;

internal interface IHostInvokeContext
{
	ScriptEngine Engine { get; }

	Type AccessContext { get; }

	ScriptAccess DefaultAccess { get; }
}
