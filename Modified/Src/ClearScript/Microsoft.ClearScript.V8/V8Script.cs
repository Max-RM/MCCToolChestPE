using System;

namespace Microsoft.ClearScript.V8;

public abstract class V8Script : IDisposable
{
	[Obsolete("Use DocumentInfo instead.")]
	public string Name => UniqueDocumentInfo.UniqueName;

	public DocumentInfo DocumentInfo => UniqueDocumentInfo.Info;

	internal UniqueDocumentInfo UniqueDocumentInfo { get; private set; }

	internal UIntPtr CodeDigest { get; private set; }

	internal V8Script(UniqueDocumentInfo documentInfo, UIntPtr codeDigest)
	{
		UniqueDocumentInfo = documentInfo;
		CodeDigest = codeDigest;
	}

	public abstract void Dispose();
}
