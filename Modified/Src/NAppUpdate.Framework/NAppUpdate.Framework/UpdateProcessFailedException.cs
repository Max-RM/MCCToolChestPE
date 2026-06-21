using System;
using System.Runtime.Serialization;

namespace NAppUpdate.Framework;

[Serializable]
public class UpdateProcessFailedException : NAppUpdateException
{
	public UpdateProcessFailedException()
	{
	}

	public UpdateProcessFailedException(string message)
		: base(message)
	{
	}

	public UpdateProcessFailedException(string message, Exception ex)
		: base(message, ex)
	{
	}

	public UpdateProcessFailedException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
