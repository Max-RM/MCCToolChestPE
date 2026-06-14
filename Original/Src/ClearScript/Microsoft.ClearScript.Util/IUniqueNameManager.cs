namespace Microsoft.ClearScript.Util;

internal interface IUniqueNameManager
{
	string GetUniqueName(string inputName, string alternate);
}
