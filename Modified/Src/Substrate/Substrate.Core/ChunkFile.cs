using System.IO;

namespace Substrate.Core;

public class ChunkFile : NBTFile
{
	public ChunkFile(string path)
		: base(path)
	{
	}

	public ChunkFile(string path, int cx, int cz)
		: base("")
	{
		string text = Base36.Encode(cx);
		string text2 = Base36.Encode(cz);
		string path2 = "c." + text + "." + text2 + ".dat";
		while (cx < 0)
		{
			cx += 4096;
		}
		while (cz < 0)
		{
			cz += 4096;
		}
		string path3 = Base36.Encode(cx % 64);
		string path4 = Base36.Encode(cz % 64);
		base.FileName = Path.Combine(path, path3);
		if (!Directory.Exists(base.FileName))
		{
			Directory.CreateDirectory(base.FileName);
		}
		base.FileName = Path.Combine(base.FileName, path4);
		if (!Directory.Exists(base.FileName))
		{
			Directory.CreateDirectory(base.FileName);
		}
		base.FileName = Path.Combine(base.FileName, path2);
	}
}
