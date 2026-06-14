using System;
using System.Runtime.Serialization;

namespace Substrate;

[Serializable]
public class SubstrateException : Exception
{
	public SubstrateException()
	{
	}

	public SubstrateException(string message)
		: base(message)
	{
	}

	public SubstrateException(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	protected SubstrateException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
