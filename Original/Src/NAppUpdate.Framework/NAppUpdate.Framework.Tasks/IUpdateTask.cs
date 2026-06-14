using NAppUpdate.Framework.Common;
using NAppUpdate.Framework.Conditions;
using NAppUpdate.Framework.Sources;

namespace NAppUpdate.Framework.Tasks;

public interface IUpdateTask : INauFieldsHolder
{
	string Description { get; set; }

	BooleanCondition UpdateConditions { get; set; }

	TaskExecutionStatus ExecutionStatus { get; set; }

	event ReportProgressDelegate ProgressDelegate;

	void Prepare(IUpdateSource source);

	TaskExecutionStatus Execute(bool coldRun);

	bool Rollback();
}
