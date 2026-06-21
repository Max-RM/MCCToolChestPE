using System.Collections.Generic;

namespace NBTExplorer.Model.Search;

public abstract class GroupRule : SearchRule
{
	public List<SearchRule> Rules { get; set; }

	public override bool CanAddRules => true;

	protected GroupRule()
	{
		Rules = new List<SearchRule>();
	}
}
