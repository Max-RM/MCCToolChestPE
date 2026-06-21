using System.IO;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.model;

public static class PeStagingPaths
{
	public static string DataFolderName => Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55206);

	public static string DataRelativePrefix => Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55192);

	public static string DataFileExtension => Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22554);

	public static string DataFilePattern => Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(99040);

	public static string GetDataFolderPath(string stagingRoot)
	{
		return Path.Combine(stagingRoot, DataFolderName);
	}

	public static string BuildDataRelativePath(string fileNameOnDisk)
	{
		return DataRelativePrefix + fileNameOnDisk;
	}

	public static string BuildDataAbsolutePath(string stagingRoot, string fileNameOnDisk)
	{
		return Path.Combine(GetDataFolderPath(stagingRoot), fileNameOnDisk);
	}
}
