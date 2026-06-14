using NAppUpdate.Framework.Common;
using NAppUpdate.Framework.Tasks;

namespace NAppUpdate.Framework.Conditions;

public interface IUpdateCondition : INauFieldsHolder
{
	bool IsMet(IUpdateTask task);
}
