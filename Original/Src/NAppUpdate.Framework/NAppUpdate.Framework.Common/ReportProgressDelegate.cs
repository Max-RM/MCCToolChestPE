using System;

namespace NAppUpdate.Framework.Common;

[Serializable]
public delegate void ReportProgressDelegate(UpdateProgressInfo currentStatus);
