using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.model.SearchReplace;

[Serializable]
public class SearchReplaceCriteria
{
	private string oX2S2mN1F3g;

	private bool VEhS2nHIZFn;

	private string yW5S2l8TCXW;

	private ConditionMatchType iy1S22tNenG;

	private List<MatchCondition> YOfS2yIGG2i;

	private List<ReplaceValue> IT1S20yyUyX;

	private List<SearchReplaceVariable> WUpS2BPCmHF;

	private List<SearchReplaceCriteria> DvPS2ttnsmG;

	public string Name
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return oX2S2mN1F3g;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			oX2S2mN1F3g = value;
		}
	}

	public bool Active
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return VEhS2nHIZFn;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			VEhS2nHIZFn = value;
		}
	}

	public string NodeSelector
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return yW5S2l8TCXW;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			yW5S2l8TCXW = value;
		}
	}

	public ConditionMatchType MatchType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return iy1S22tNenG;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			iy1S22tNenG = value;
		}
	}

	public List<MatchCondition> Conditions
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			if (YOfS2yIGG2i == null)
			{
				YOfS2yIGG2i = new List<MatchCondition>();
			}
			return YOfS2yIGG2i;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			YOfS2yIGG2i = value;
		}
	}

	public List<ReplaceValue> Values
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			if (IT1S20yyUyX == null)
			{
				IT1S20yyUyX = new List<ReplaceValue>();
			}
			return IT1S20yyUyX;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			IT1S20yyUyX = value;
		}
	}

	public List<SearchReplaceVariable> Variables
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			if (WUpS2BPCmHF == null)
			{
				WUpS2BPCmHF = new List<SearchReplaceVariable>();
			}
			return WUpS2BPCmHF;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			WUpS2BPCmHF = value;
		}
	}

	public List<SearchReplaceCriteria> Children
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			if (DvPS2ttnsmG == null)
			{
				DvPS2ttnsmG = new List<SearchReplaceCriteria>();
			}
			return DvPS2ttnsmG;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			DvPS2ttnsmG = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal SearchReplaceCriteria WdAS2hQgmhs()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		SearchReplaceCriteria searchReplaceCriteria = new SearchReplaceCriteria();
		searchReplaceCriteria.Name = Name;
		searchReplaceCriteria.Active = Active;
		searchReplaceCriteria.NodeSelector = NodeSelector;
		searchReplaceCriteria.MatchType = MatchType;
		foreach (MatchCondition item in YOfS2yIGG2i)
		{
			searchReplaceCriteria.Conditions.Add(item.e6PS2isJYAK());
		}
		foreach (ReplaceValue value in Values)
		{
			searchReplaceCriteria.Values.Add(value.kRYS2a2C9VX());
		}
		foreach (SearchReplaceVariable variable in Variables)
		{
			searchReplaceCriteria.Variables.Add(variable.VtWS23sOwyb());
		}
		foreach (SearchReplaceCriteria child in Children)
		{
			searchReplaceCriteria.Children.Add(child.WdAS2hQgmhs());
		}
		return searchReplaceCriteria;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SearchReplaceCriteria()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		oX2S2mN1F3g = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(99112);
		VEhS2nHIZFn = true;
	}
}
