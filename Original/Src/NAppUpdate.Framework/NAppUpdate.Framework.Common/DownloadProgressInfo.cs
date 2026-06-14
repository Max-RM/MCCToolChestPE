using System;

namespace NAppUpdate.Framework.Common;

[Serializable]
public class DownloadProgressInfo : UpdateProgressInfo
{
	public long FileSizeInBytes { get; set; }

	public long DownloadedInBytes { get; set; }
}
