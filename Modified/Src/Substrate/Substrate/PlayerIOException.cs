using System;
using System.Runtime.Serialization;

namespace Substrate;

[Serializable]
public class PlayerIOException : SubstrateException
{
	public PlayerIOException()
	{
	}

	public PlayerIOException(string message)
		: base(message)
	{
	}

	public PlayerIOException(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	protected PlayerIOException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
