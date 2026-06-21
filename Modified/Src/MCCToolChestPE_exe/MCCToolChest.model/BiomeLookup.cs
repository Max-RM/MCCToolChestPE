using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.model;

public class BiomeLookup
{
	public static Dictionary<string, Biome> name;

	public static Dictionary<int, Biome> list;

	public static Dictionary<int, Biome> javaId;

	public static Dictionary<int, Biome> bedrockId;

	[CompilerGenerated]
	private static Func<KeyValuePair<int, Biome>, int> hdFSwWgWCLp;

	[CompilerGenerated]
	private static Func<KeyValuePair<int, Biome>, Biome> JjMSwptU8wO;

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void EfrSwwZC8iE()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		try
		{
			list = bedrockId.ToDictionary([MethodImpl(MethodImplOptions.NoInlining)] (KeyValuePair<int, Biome> P_0) =>
			{
				while (false)
				{
					_ = ((object[])null)[0];
				}
				return P_0.Key;
			}, [MethodImpl(MethodImplOptions.NoInlining)] (KeyValuePair<int, Biome> P_0) =>
			{
				while (false)
				{
					_ = ((object[])null)[0];
				}
				return P_0.Value;
			});
			bedrockId.Remove(1000);
			name = new Dictionary<string, Biome>();
			javaId = new Dictionary<int, Biome>();
			foreach (Biome value in bedrockId.Values)
			{
				name[value.Name] = value;
				javaId[value.JavaId] = value;
			}
		}
		catch (Exception)
		{
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BiomeLookup()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static int Vs1Sw4jhvmZ(KeyValuePair<int, Biome> P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0.Key;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static Biome u55SwVy8XOW(KeyValuePair<int, Biome> P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0.Value;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static BiomeLookup()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		name = null;
		list = null;
		javaId = null;
		bedrockId = new Dictionary<int, Biome>
		{
			{
				1000,
				new Biome(1000, 1000, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(74540), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(74564), 0u, uint.MaxValue)
			},
			{
				0,
				new Biome(0, 0, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(74588), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(74622), 112u, uint.MaxValue)
			},
			{
				1,
				new Biome(1, 1, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(74636), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(74672), 9286496u, uint.MaxValue)
			},
			{
				2,
				new Biome(2, 2, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(74688), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(46302), 16421912u, 0u)
			},
			{
				3,
				new Biome(3, 3, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(74724), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(74766), 6316128u, uint.MaxValue)
			},
			{
				4,
				new Biome(4, 4, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(74788), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(74824), 353825u, uint.MaxValue)
			},
			{
				5,
				new Biome(5, 5, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(74840), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(74874), 747097u, uint.MaxValue)
			},
			{
				6,
				new Biome(6, 6, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(74888), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(74922), 522674u, 0u)
			},
			{
				7,
				new Biome(7, 7, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(74936), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(74970), 255u, uint.MaxValue)
			},
			{
				8,
				new Biome(8, 8, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(74984), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28772), 16711680u, uint.MaxValue)
			},
			{
				9,
				new Biome(9, 9, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(75020), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28734), 8421631u, uint.MaxValue)
			},
			{
				10,
				new Biome(10, 10, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(75058), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(75106), 9474208u, uint.MaxValue)
			},
			{
				11,
				new Biome(11, 11, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(75134), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(75182), 10526975u, uint.MaxValue)
			},
			{
				12,
				new Biome(12, 12, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(75210), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(75258), 16777215u, 0u)
			},
			{
				13,
				new Biome(13, 13, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(75286), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(75340), 10526880u, uint.MaxValue)
			},
			{
				14,
				new Biome(14, 14, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(75374), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(75428), 16711935u, uint.MaxValue)
			},
			{
				15,
				new Biome(15, 15, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(75462), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(75526), 10486015u, uint.MaxValue)
			},
			{
				16,
				new Biome(16, 16, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(75570), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(75604), 16440917u, 0u)
			},
			{
				17,
				new Biome(17, 17, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(75618), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(75666), 13786898u, 0u)
			},
			{
				18,
				new Biome(18, 18, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(75694), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(75742), 2250012u, uint.MaxValue)
			},
			{
				19,
				new Biome(19, 19, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(75770), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(75816), 1456435u, uint.MaxValue)
			},
			{
				20,
				new Biome(20, 20, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(75842), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(75892), 7501978u, uint.MaxValue)
			},
			{
				21,
				new Biome(21, 21, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(75922), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(75958), 5470985u, uint.MaxValue)
			},
			{
				22,
				new Biome(22, 22, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(75974), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(76022), 2900485u, uint.MaxValue)
			},
			{
				23,
				new Biome(23, 23, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(76050), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(76096), 6458135u, uint.MaxValue)
			},
			{
				24,
				new Biome(24, 24, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(76122), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(76166), 48u, uint.MaxValue)
			},
			{
				25,
				new Biome(25, 25, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(76190), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(76236), 10658436u, uint.MaxValue)
			},
			{
				26,
				new Biome(26, 26, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(76262), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(76308), 16445632u, 0u)
			},
			{
				27,
				new Biome(27, 27, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(76334), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(76382), 3175492u, uint.MaxValue)
			},
			{
				28,
				new Biome(28, 28, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(76410), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(76470), 2055986u, uint.MaxValue)
			},
			{
				29,
				new Biome(29, 29, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(76510), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(76556), 4215066u, uint.MaxValue)
			},
			{
				30,
				new Biome(30, 30, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(76582), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(76628), 3233098u, uint.MaxValue)
			},
			{
				31,
				new Biome(31, 31, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(76654), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(76712), 2375478u, uint.MaxValue)
			},
			{
				32,
				new Biome(32, 32, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(76750), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(76806), 5858897u, uint.MaxValue)
			},
			{
				33,
				new Biome(33, 33, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(76842), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(76910), 5529406u, uint.MaxValue)
			},
			{
				34,
				new Biome(34, 34, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(76958), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(77014), 5271632u, uint.MaxValue)
			},
			{
				35,
				new Biome(35, 35, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(77050), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(77088), 12431967u, uint.MaxValue)
			},
			{
				36,
				new Biome(36, 36, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(77106), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(77160), 10984804u, uint.MaxValue)
			},
			{
				37,
				new Biome(37, 37, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(77194), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(77234), 14238997u, uint.MaxValue)
			},
			{
				38,
				new Biome(38, 38, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(77254), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(77324), 11573093u, uint.MaxValue)
			},
			{
				39,
				new Biome(39, 39, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(77374), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(77430), 13274213u, uint.MaxValue)
			},
			{
				40,
				new Biome(40, 40, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(77466), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(77510), 5057469u, uint.MaxValue)
			},
			{
				41,
				new Biome(41, 41, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(77534), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(77586), 5651372u, uint.MaxValue)
			},
			{
				42,
				new Biome(42, 42, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(77618), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(77662), 4487643u, uint.MaxValue)
			},
			{
				43,
				new Biome(43, 43, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(77686), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(77740), 6239719u, uint.MaxValue)
			},
			{
				44,
				new Biome(44, 44, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(77774), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(77836), 7095028u, uint.MaxValue)
			},
			{
				45,
				new Biome(45, 45, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(77878), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(77932), 1526697u, uint.MaxValue)
			},
			{
				46,
				new Biome(46, 46, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(77966), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(78024), 10534129u, uint.MaxValue)
			},
			{
				48,
				new Biome(48, 48, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(78062), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(78112), 7202052u, uint.MaxValue)
			},
			{
				49,
				new Biome(49, 49, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(78142), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(78204), 6211075u, uint.MaxValue)
			},
			{
				127,
				new Biome(127, 127, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(78248), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(46350), 0u, uint.MaxValue)
			},
			{
				129,
				new Biome(129, 129, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(78288), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(78344), 11918216u, 0u)
			},
			{
				130,
				new Biome(130, 130, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(78380), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(78428), 16759872u, 0u)
			},
			{
				131,
				new Biome(131, 131, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(78456), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(78516), 8947848u, uint.MaxValue)
			},
			{
				132,
				new Biome(132, 132, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(78556), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(78606), 6976549u, uint.MaxValue)
			},
			{
				133,
				new Biome(133, 133, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(78636), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(78690), 5858897u, uint.MaxValue)
			},
			{
				134,
				new Biome(134, 134, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(78724), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(78770), 3145690u, 0u)
			},
			{
				140,
				new Biome(140, 140, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(78796), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(78840), 11853020u, 0u)
			},
			{
				149,
				new Biome(149, 149, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(78864), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(78918), 8102705u, uint.MaxValue)
			},
			{
				151,
				new Biome(151, 151, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(78952), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(79016), 9089855u, uint.MaxValue)
			},
			{
				155,
				new Biome(155, 155, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(79060), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(79118), 5807212u, uint.MaxValue)
			},
			{
				156,
				new Biome(156, 156, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(79156), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(79212), 4687706u, uint.MaxValue)
			},
			{
				157,
				new Biome(157, 157, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(79248), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(79306), 6846786u, uint.MaxValue)
			},
			{
				158,
				new Biome(158, 158, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(79344), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(79410), 5864818u, uint.MaxValue)
			},
			{
				160,
				new Biome(160, 160, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(79456), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(79516), 7036748u, uint.MaxValue)
			},
			{
				161,
				new Biome(161, 161, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(79556), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(79628), 7173990u, uint.MaxValue)
			},
			{
				162,
				new Biome(162, 162, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(79680), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(79758), 7903352u, uint.MaxValue)
			},
			{
				163,
				new Biome(163, 163, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(79800), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(79858), 15063687u, 0u)
			},
			{
				164,
				new Biome(164, 164, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(79896), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(79970), 13616524u, 0u)
			},
			{
				165,
				new Biome(165, 165, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(80024), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(80078), 16739645u, 0u)
			},
			{
				166,
				new Biome(166, 166, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(80112), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(80200), 14204813u, 0u)
			},
			{
				167,
				new Biome(167, 167, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(80268), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(80342), 15905933u, 0u)
			},
			{
				178,
				new Biome(178, 170, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(80396), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(80452), 2184535u, uint.MaxValue)
			},
			{
				179,
				new Biome(179, 171, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(80488), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(80540), 9058058u, uint.MaxValue)
			},
			{
				180,
				new Biome(180, 172, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(80572), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(80622), 1397834u, uint.MaxValue)
			},
			{
				181,
				new Biome(181, 173, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(80652), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(80702), 5458519u, uint.MaxValue)
			}
		};
	}
}
