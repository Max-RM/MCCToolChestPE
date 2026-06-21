using System.Collections.Generic;

namespace Microsoft.ClearScript.Util;

internal sealed class UniqueNameManager : IUniqueNameManager
{
	private readonly object mapLock = new object();

	private readonly Dictionary<string, uint> map = new Dictionary<string, uint>();

	public string GetUniqueName(string inputName, string alternate)
	{
		lock (mapLock)
		{
			string text = MiscHelpers.EnsureNonBlank(inputName, alternate);
			map.TryGetValue(text, out var value);
			value = (map[text] = value + 1);
			return (value < 2) ? text : (text + " [" + value + "]");
		}
	}
}
