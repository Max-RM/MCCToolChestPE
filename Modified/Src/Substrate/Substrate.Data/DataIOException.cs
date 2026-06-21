using System;
using System.Runtime.Serialization;

namespace Substrate.Data;

[Serializable]
public class DataIOException : SubstrateException
{
	public DataIOException()
	{
	}

	public DataIOException(string message)
		: base(message)
	{
	}

	public DataIOException(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	protected DataIOException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
