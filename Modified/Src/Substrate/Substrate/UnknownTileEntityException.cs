using System;

namespace Substrate;

public class UnknownTileEntityException : Exception
{
	public UnknownTileEntityException(string message)
		: base(message)
	{
	}
}
