using System;
using System.Runtime.Serialization;

namespace NAppUpdate.Framework;

[Serializable]
public class NAppUpdateException : Exception
{
	public NAppUpdateException()
	{
	}

	public NAppUpdateException(string message)
		: base(message)
	{
	}

	public NAppUpdateException(string message, Exception ex)
		: base(message, ex)
	{
	}

	public NAppUpdateException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	public override string ToString()
	{
		string text = Message;
		if (!string.IsNullOrEmpty(text))
		{
			text += Environment.NewLine;
		}
		if (base.InnerException != null)
		{
			return text + base.InnerException;
		}
		return text + StackTrace;
	}
}
