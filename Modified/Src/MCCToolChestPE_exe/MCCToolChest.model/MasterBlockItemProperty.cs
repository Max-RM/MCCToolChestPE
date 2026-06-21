using System.Runtime.CompilerServices;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.model;

public class MasterBlockItemProperty
{
	public string name;

	public string value;

	public string nbtType;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MasterBlockItemProperty()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MasterBlockItemProperty(string name, string value)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		this.name = name;
		this.value = value;
		nbtType = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9820);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TagNode GenBlockDataNode()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (nbtType == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9844))
		{
			int result = 0;
			int.TryParse(value, out result);
			return new TagNodeInt(result);
		}
		if (nbtType == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9862))
		{
			byte result2 = 0;
			byte.TryParse(value, out result2);
			return new TagNodeByte(result2);
		}
		return new TagNodeString(value);
	}
}
