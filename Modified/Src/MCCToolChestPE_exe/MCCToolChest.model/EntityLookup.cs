using System.Collections.Generic;
using System.Runtime.CompilerServices;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.model;

public class EntityLookup
{
	private static List<EntityItem> aFdSZciq5Db;

	private Dictionary<string, EntityItem> ifPSZJEBYEU;

	private Dictionary<string, EntityItem> wJOSZuVJI7V;

	private Dictionary<int, string> e0nSZoMmvSj;

	public Dictionary<int, string> HorseEntities
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return e0nSZoMmvSj;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			e0nSZoMmvSj = value;
		}
	}

	public Dictionary<string, EntityItem> PCEntities
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return ifPSZJEBYEU;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			ifPSZJEBYEU = value;
		}
	}

	public Dictionary<string, EntityItem> ConsoleEntities
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return wJOSZuVJI7V;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			wJOSZuVJI7V = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EntityLookup()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		rD2SZ6bLqIX();
		bC8SZNagPES();
		iFrSZDrHAmq();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void rD2SZ6bLqIX()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ifPSZJEBYEU = new Dictionary<string, EntityItem>();
		foreach (EntityItem item in aFdSZciq5Db)
		{
			ifPSZJEBYEU.Add(item.PCOldName, item);
			ifPSZJEBYEU.Add(item.PCName, item);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void bC8SZNagPES()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		wJOSZuVJI7V = new Dictionary<string, EntityItem>();
		foreach (EntityItem item in aFdSZciq5Db)
		{
			if (!wJOSZuVJI7V.ContainsKey(item.ConsoleName))
			{
				wJOSZuVJI7V.Add(item.ConsoleName, item);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void iFrSZDrHAmq()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		e0nSZoMmvSj = new Dictionary<int, string>
		{
			{
				0,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7172)
			},
			{
				1,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7212)
			},
			{
				2,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7228)
			},
			{
				3,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7302)
			},
			{
				4,
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7240)
			}
		};
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static EntityLookup()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		aFdSZciq5Db = new List<EntityItem>
		{
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6834), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6834), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(81338), consoleSpawner: true, EntityCategory.MOB),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6680), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6680), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(81368), consoleSpawner: true, EntityCategory.MOB),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6606), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6606), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(81464), consoleSpawner: true, EntityCategory.MOB),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6952), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6952), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(81554), consoleSpawner: true, EntityCategory.MOB),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6942), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6942), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(81690), consoleSpawner: true, EntityCategory.MOB),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(2508), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(2508), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14936), consoleSpawner: true, EntityCategory.MOB),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7680), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7680), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(81916), consoleSpawner: true, EntityCategory.MOB),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6740), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6740), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(82018), consoleSpawner: true, EntityCategory.MOB),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6586), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6586), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(82112), consoleSpawner: true, EntityCategory.MOB),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6858), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6858), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(82152), consoleSpawner: true, EntityCategory.MOB),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7492), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7492), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(82246), consoleSpawner: true, EntityCategory.MOB),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7172), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7172), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(82634), consoleSpawner: true, EntityCategory.MOB, 0),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7172), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7212), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(81758), consoleSpawner: true, EntityCategory.MOB, 1),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7172), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7228), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(83188), consoleSpawner: true, EntityCategory.MOB, 2),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7172), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7302), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(84932), consoleSpawner: true, EntityCategory.MOB, 3),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7172), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7240), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(83868), consoleSpawner: true, EntityCategory.MOB, 4),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6520), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6520), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(82560), consoleSpawner: true, EntityCategory.MOB),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6448), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6448), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(87726), consoleSpawner: true, EntityCategory.MOB),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6880), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6880), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(82594), consoleSpawner: true, EntityCategory.MOB),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7742), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7742), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(82668), consoleSpawner: true, EntityCategory.MOB),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7532), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7532), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(87760), consoleSpawner: true, EntityCategory.MOB),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7418), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7418), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(82936), consoleSpawner: true, EntityCategory.MOB),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6694), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6694), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(83014), consoleSpawner: true, EntityCategory.MOB),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6996), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6996), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(83098), consoleSpawner: true, EntityCategory.MOB),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7086), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7086), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(87816), consoleSpawner: true, EntityCategory.MOB),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7102), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7102), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(83250), consoleSpawner: true, EntityCategory.MOB),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7432), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7432), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(83360), consoleSpawner: true, EntityCategory.MOB),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6918), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6918), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(83434), consoleSpawner: true, EntityCategory.MOB),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6534), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6534), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14886), consoleSpawner: true, EntityCategory.MOB),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7372), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7372), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(83540), consoleSpawner: true, EntityCategory.MOB),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7356), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7356), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(83628), consoleSpawner: true, EntityCategory.MOB),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6928), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6928), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(83700), consoleSpawner: true, EntityCategory.MOB),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6900), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6900), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(83734), consoleSpawner: true, EntityCategory.MOB),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6656), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6656), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(83824), consoleSpawner: true, EntityCategory.MOB),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6412), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6412), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14974), consoleSpawner: true, EntityCategory.MOB),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6506), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6506), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(83920), consoleSpawner: true, EntityCategory.MOB),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7044), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7044), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(87852), consoleSpawner: true, EntityCategory.MOB),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6432), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6432), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(84090), consoleSpawner: true, EntityCategory.MOB),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6970), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6970), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(84176), consoleSpawner: true, EntityCategory.MOB),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7518), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7518), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(84210), consoleSpawner: true, EntityCategory.MOB),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7508), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7508), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(84508), consoleSpawner: true, EntityCategory.MOB),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7448), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7448), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15534), consoleSpawner: true, EntityCategory.MOB),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7118), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7118), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(87890), consoleSpawner: true, EntityCategory.MOB),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7468), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7468), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(87942), consoleSpawner: true, EntityCategory.MOB),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6844), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6844), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(84582), consoleSpawner: true, EntityCategory.MOB),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6794), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6794), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(84616), consoleSpawner: true, EntityCategory.MOB),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7754), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7754), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(84652), consoleSpawner: true, EntityCategory.MOB),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6984), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6984), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(84822), consoleSpawner: true, EntityCategory.MOB),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6490), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6490), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14850), consoleSpawner: true, EntityCategory.MOB),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7614), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7614), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15014), consoleSpawner: true, EntityCategory.MOB),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6000), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6000), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(83058), consoleSpawner: true, EntityCategory.VEHICLE),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6056), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6056), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15068), consoleSpawner: true, EntityCategory.VEHICLE),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6122), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6122), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88004), consoleSpawner: true, EntityCategory.VEHICLE),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6256), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6256), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(15120), consoleSpawner: true, EntityCategory.VEHICLE),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6192), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6192), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(84326), consoleSpawner: true, EntityCategory.VEHICLE),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6332), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(6332), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88060), consoleSpawner: true, EntityCategory.VEHICLE),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(5988), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(5988), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(81402), consoleSpawner: true, EntityCategory.VEHICLE),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(5836), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(5836), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(81220), consoleSpawner: true, EntityCategory.OTHER),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7556), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7556), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(81968), consoleSpawner: true, EntityCategory.OTHER),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88116), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88116), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(82304), consoleSpawner: true, EntityCategory.OTHER),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(5568), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(5568), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(82456), consoleSpawner: true, EntityCategory.OTHER),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(5366), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(5366), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65298), consoleSpawner: true, EntityCategory.OTHER),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(4892), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(4892), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(82784), consoleSpawner: true, EntityCategory.OTHER),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(4936), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(4936), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(83286), consoleSpawner: true, EntityCategory.OTHER),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(4742), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(4742), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(84896), consoleSpawner: true, EntityCategory.OTHER),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(4702), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(4702), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(66310), consoleSpawner: true, EntityCategory.OTHER),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88140), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88140), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(84296), consoleSpawner: true, EntityCategory.DYNAMIC),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(5512), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(5512), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(82366), consoleSpawner: true, EntityCategory.DYNAMIC),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(4956), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(4956), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(81266), consoleSpawner: true, EntityCategory.PROJECTILE),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(5770), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(5770), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(81794), consoleSpawner: true, EntityCategory.PROJECTILE),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(5042), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(5042), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(83954), consoleSpawner: true, EntityCategory.PROJECTILE),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(4970), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(4970), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(84050), consoleSpawner: true, EntityCategory.PROJECTILE),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88162), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88162), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88192), consoleSpawner: true, EntityCategory.PROJECTILE),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(4860), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(4860), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(81886), consoleSpawner: true, EntityCategory.PROJECTILE),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(5104), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(5104), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(82066), consoleSpawner: true, EntityCategory.PROJECTILE),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(5288), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(5288), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(84854), consoleSpawner: true, EntityCategory.PROJECTILE),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(5230), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(5230), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88244), consoleSpawner: true, EntityCategory.PROJECTILE),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(5412), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(5412), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(84706), consoleSpawner: true, EntityCategory.PROJECTILE),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(4788), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(4788), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(81162), consoleSpawner: true, EntityCategory.PROJECTILE),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(5708), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(5708), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(83772), consoleSpawner: true, EntityCategory.PROJECTILE),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88280), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88280), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(82970), consoleSpawner: true, EntityCategory.PROJECTILE),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65798), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(65798), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88302), consoleSpawner: true, EntityCategory.OTHER),
			new EntityItem(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88352), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88352), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(88384), consoleSpawner: true, EntityCategory.OTHER)
		};
	}
}
