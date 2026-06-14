using System;
using System.Runtime.Serialization;

namespace Substrate.Nbt;

[Serializable]
public class NbtIOException : SubstrateException
{
	public NbtIOException()
	{
	}

	public NbtIOException(string message)
		: base(message)
	{
	}

	public NbtIOException(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	protected NbtIOException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
