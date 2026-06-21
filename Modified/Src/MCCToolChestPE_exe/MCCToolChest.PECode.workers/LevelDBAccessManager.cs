using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MCPELevelDBI.workers;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.PECode.workers;

public class LevelDBAccessManager
{
	private static Dictionary<string, LevelDBWorker> UJ6SVY0SIsU;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static LevelDBWorker OpenConnection(string dbPath)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!UJ6SVY0SIsU.ContainsKey(dbPath))
		{
			UJ6SVY0SIsU[dbPath] = PEUtility.OpenDBWorker(dbPath);
		}
		return UJ6SVY0SIsU[dbPath];
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CloseConnection(LevelDBWorker dbWorker)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		UJ6SVY0SIsU.Remove(dbWorker.DBPath);
		dbWorker.CloseDB();
		dbWorker = null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LevelDBAccessManager()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static LevelDBAccessManager()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		UJ6SVY0SIsU = new Dictionary<string, LevelDBWorker>();
	}
}
