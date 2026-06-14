using System;
using System.Runtime.Serialization;

namespace Substrate;

[Serializable]
public class LevelIOException : SubstrateException
{
	public LevelIOException()
	{
	}

	public LevelIOException(string message)
		: base(message)
	{
	}

	public LevelIOException(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	protected LevelIOException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
