using System;

namespace Microsoft.ClearScript;

internal class UniqueDocumentInfo
{
	public DocumentInfo Info { get; private set; }

	public string Name => Info.Name;

	public Uri Uri => Info.Uri;

	public Uri SourceMapUri => Info.SourceMapUri;

	public DocumentCategory Category => Info.Category;

	public DocumentFlags? Flags => Info.Flags;

	public DocumentContextCallback ContextCallback => Info.ContextCallback;

	public ulong UniqueId { get; private set; }

	public string UniqueName { get; private set; }

	public UniqueDocumentInfo(DocumentInfo info, ulong uniqueId, string uniqueName)
	{
		Info = info;
		UniqueId = uniqueId;
		UniqueName = uniqueName;
	}
}
