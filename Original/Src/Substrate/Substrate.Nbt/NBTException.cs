using System;

namespace Substrate.Nbt;

public class NBTException : Exception
{
	public const string MSG_GZIP_ENDOFSTREAM = "Gzip Error: Unexpected end of stream";

	public const string MSG_READ_NEG = "Read Error: Negative length";

	public const string MSG_READ_TYPE = "Read Error: Invalid value type";

	public NBTException()
	{
	}

	public NBTException(string msg)
		: base(msg)
	{
	}

	public NBTException(string msg, Exception innerException)
		: base(msg, innerException)
	{
	}
}
