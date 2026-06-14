using System;

namespace NAppUpdate.Framework.Common;

[Serializable]
public class UpdateProgressInfo
{
	public int TaskId { get; set; }

	public string TaskDescription { get; set; }

	public string Message { get; set; }

	public int Percentage { get; set; }

	public bool StillWorking { get; set; }
}
