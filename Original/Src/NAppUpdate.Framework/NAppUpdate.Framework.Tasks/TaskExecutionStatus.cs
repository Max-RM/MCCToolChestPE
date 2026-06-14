using System;

namespace NAppUpdate.Framework.Tasks;

[Serializable]
public enum TaskExecutionStatus
{
	Pending,
	FailedToPrepare,
	Prepared,
	Successful,
	Failed,
	RequiresAppRestart,
	RequiresPrivilegedAppRestart
}
