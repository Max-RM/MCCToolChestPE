using System;
using System.Runtime.Serialization;

namespace NAppUpdate.Framework;

[Serializable]
public class FeedReaderException : NAppUpdateException
{
	public FeedReaderException()
	{
	}

	public FeedReaderException(string message)
		: base(message)
	{
	}

	public FeedReaderException(string message, Exception ex)
		: base(message, ex)
	{
	}

	public FeedReaderException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
