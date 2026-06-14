using System;
using System.Reflection;
using Microsoft.ClearScript.Util;

namespace Microsoft.ClearScript;

public class EventConnection<T>
{
	private object source;

	private EventInfo eventInfo;

	private Delegate handler;

	internal EventConnection(object source, EventInfo eventInfo, Delegate handler)
	{
		MiscHelpers.VerifyNonNullArgument(handler, "handler");
		MiscHelpers.VerifyNonNullArgument(eventInfo, "eventInfo");
		if (eventInfo.EventHandlerType != typeof(T))
		{
			throw new ArgumentException("Invalid event type", "eventInfo");
		}
		this.source = source;
		this.eventInfo = eventInfo;
		this.handler = handler;
	}

	public void disconnect()
	{
		if ((object)handler != null)
		{
			eventInfo.RemoveEventHandler(source, handler);
			source = null;
			eventInfo = null;
			handler = null;
		}
	}
}
