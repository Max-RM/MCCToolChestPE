using System.Runtime.CompilerServices;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.model;

public class MasterBlock
{
	public string name;

	public string label;

	public MasterBlockItem java;

	public MasterBlockItem bedrock;

	public bool link;

	public bool linkable;

	public bool transparent;

	public bool cache;

	public int color;

	public string blockStates;

	public string Name
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return name;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			name = value;
		}
	}

	public string Label
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return label;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			label = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MasterBlock()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MasterBlock Copy()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MasterBlock masterBlock = new MasterBlock();
		masterBlock.name = name;
		masterBlock.label = label;
		masterBlock.java = java;
		masterBlock.bedrock = bedrock;
		masterBlock.link = link;
		masterBlock.linkable = linkable;
		masterBlock.transparent = transparent;
		masterBlock.cache = cache;
		masterBlock.color = color;
		return masterBlock;
	}
}
