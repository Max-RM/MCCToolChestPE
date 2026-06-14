using System.Collections.Generic;
using System.IO;

namespace Microsoft.ClearScript.Util;

internal sealed class UniqueFileNameManager : IUniqueNameManager
{
	private readonly object mapLock = new object();

	private readonly Dictionary<string, uint> map = new Dictionary<string, uint>();

	public string GetUniqueName(string inputName, string alternate)
	{
		lock (mapLock)
		{
			string text = MiscHelpers.EnsureNonBlank(Path.GetFileNameWithoutExtension(inputName), alternate);
			string extension = Path.GetExtension(inputName);
			map.TryGetValue(text, out var value);
			value = (map[text] = value + 1);
			return (value < 2) ? (text + extension) : (text + " [" + value + "]" + extension);
		}
	}
}
