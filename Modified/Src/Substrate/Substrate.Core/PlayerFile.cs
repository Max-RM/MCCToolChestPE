using System.IO;

namespace Substrate.Core;

public class PlayerFile : NBTFile
{
	public PlayerFile(string path)
		: base(path)
	{
	}

	public PlayerFile(string path, string name)
		: base("")
	{
		if (!Directory.Exists(path))
		{
			Directory.CreateDirectory(path);
		}
		string path2 = name + ".dat";
		base.FileName = Path.Combine(path, path2);
	}

	public static string NameFromFilename(string filename)
	{
		if (filename.EndsWith(".dat"))
		{
			return filename.Remove(filename.Length - 4);
		}
		return filename;
	}
}
