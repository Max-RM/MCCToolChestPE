using System;
using System.Collections.Generic;
using NAppUpdate.Framework.Common;
using NAppUpdate.Framework.Tasks;

namespace NAppUpdate.Framework.Conditions;

[Serializable]
public sealed class BooleanCondition : IUpdateCondition, INauFieldsHolder
{
	[Flags]
	public enum ConditionType : byte
	{
		AND = 1,
		OR = 2,
		NOT = 4
	}

	protected class ConditionItem
	{
		public readonly IUpdateCondition _Condition;

		public readonly ConditionType _ConditionType;

		public ConditionItem(IUpdateCondition cnd, ConditionType typ)
		{
			_Condition = cnd;
			_ConditionType = typ;
		}
	}

	protected LinkedList<ConditionItem> ChildConditions { get; set; }

	public int ChildConditionsCount
	{
		get
		{
			if (ChildConditions != null)
			{
				return ChildConditions.Count;
			}
			return 0;
		}
	}

	public IDictionary<string, string> Attributes { get; private set; }

	public static ConditionType ConditionTypeFromString(string type)
	{
		if (!string.IsNullOrEmpty(type))
		{
			switch (type.ToLower())
			{
			case "and":
				return ConditionType.AND;
			case "or":
				return ConditionType.OR;
			case "not":
			case "and-not":
				return ConditionType.AND | ConditionType.NOT;
			case "or-not":
				return ConditionType.OR | ConditionType.NOT;
			}
		}
		return ConditionType.AND;
	}

	public BooleanCondition()
	{
		Attributes = new Dictionary<string, string>();
	}

	public void AddCondition(IUpdateCondition cnd)
	{
		AddCondition(cnd, ConditionType.AND);
	}

	public void AddCondition(IUpdateCondition cnd, ConditionType type)
	{
		if (ChildConditions == null)
		{
			ChildConditions = new LinkedList<ConditionItem>();
		}
		ChildConditions.AddLast(new ConditionItem(cnd, type));
	}

	public IUpdateCondition Degrade()
	{
		if (ChildConditionsCount == 1 && (ChildConditions.First.Value._ConditionType & ConditionType.NOT) == 0)
		{
			return ChildConditions.First.Value._Condition;
		}
		return this;
	}

	public bool IsMet(IUpdateTask task)
	{
		if (ChildConditions == null)
		{
			return true;
		}
		bool flag = true;
		bool flag2 = true;
		foreach (ConditionItem childCondition in ChildConditions)
		{
			if (!flag2)
			{
				if (flag && (int)(childCondition._ConditionType & ConditionType.OR) > 0)
				{
					return true;
				}
			}
			else
			{
				flag2 = false;
			}
			if (!flag)
			{
				if ((int)(childCondition._ConditionType & ConditionType.OR) > 0)
				{
					bool flag3 = childCondition._Condition.IsMet(task);
					flag = (((int)(childCondition._ConditionType & ConditionType.NOT) > 0) ? (!flag3) : flag3);
				}
			}
			else
			{
				bool flag4 = childCondition._Condition.IsMet(task);
				flag = (((int)(childCondition._ConditionType & ConditionType.NOT) > 0) ? (!flag4) : flag4);
			}
		}
		return flag;
	}
}
