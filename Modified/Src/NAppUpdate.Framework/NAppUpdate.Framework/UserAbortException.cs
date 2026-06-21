using System;

namespace NAppUpdate.Framework;

[Serializable]
public class UserAbortException : NAppUpdateException
{
	public UserAbortException()
		: base("User abort")
	{
	}
}
