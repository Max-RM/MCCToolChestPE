using System;
using System.Reflection;
using Microsoft.ClearScript.Util;

namespace Microsoft.ClearScript;

public class EventSource<T>
{
	private readonly ScriptEngine engine;

	private readonly object source;

	private readonly EventInfo eventInfo;

	internal object Source => source;

	internal EventInfo EventInfo => eventInfo;

	internal EventSource(ScriptEngine engine, object source, EventInfo eventInfo)
	{
		MiscHelpers.VerifyNonNullArgument(engine, "engine");
		MiscHelpers.VerifyNonNullArgument(eventInfo, "eventInfo");
		if (eventInfo.EventHandlerType != typeof(T))
		{
			throw new ArgumentException("Invalid event type", "eventInfo");
		}
		this.engine = engine;
		this.source = source;
		this.eventInfo = eventInfo;
	}

	public EventConnection<T> connect(object scriptFunc)
	{
		MiscHelpers.VerifyNonNullArgument(scriptFunc, "scriptFunc");
		Delegate handler = DelegateFactory.CreateDelegate(engine, scriptFunc, eventInfo.EventHandlerType);
		eventInfo.AddEventHandler(source, handler);
		return new EventConnection<T>(source, eventInfo, handler);
	}
}
