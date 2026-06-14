using System.Runtime.CompilerServices;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.model;

public class BiomeChange
{
	private int mniSyg7b3uy;

	private int vkRSyPCE3HO;

	public int FromBiome
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return mniSyg7b3uy;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			mniSyg7b3uy = value;
		}
	}

	public int ToBiome
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return vkRSyPCE3HO;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			vkRSyPCE3HO = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string ToString()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return mniSyg7b3uy.ToString() + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40710) + vkRSyPCE3HO.ToString() + '|';
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static BiomeChange FromString(string changeStr)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BiomeChange result = null;
		string[] array = changeStr.Split(',');
		if (array.Length == 2)
		{
			int result2 = 0;
			int result3 = 0;
			int.TryParse(array[0], out result2);
			int.TryParse(array[1], out result3);
			BiomeChange biomeChange = new BiomeChange();
			biomeChange.FromBiome = result2;
			biomeChange.ToBiome = result3;
			result = biomeChange;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BiomeChange()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		mniSyg7b3uy = 1000;
	}
}
