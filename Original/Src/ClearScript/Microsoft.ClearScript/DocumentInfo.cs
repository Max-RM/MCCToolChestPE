using System;
using System.IO;
using System.Threading;
using Microsoft.ClearScript.Util;

namespace Microsoft.ClearScript;

public struct DocumentInfo
{
	private static long lastUniqueId;

	private readonly string name;

	private readonly Uri uri;

	private DocumentCategory category;

	private ulong uniqueId;

	public string Name => MiscHelpers.EnsureNonBlank(name, Category.DefaultName);

	public Uri Uri => uri;

	public Uri SourceMapUri { get; set; }

	public DocumentCategory Category
	{
		get
		{
			return category ?? DocumentCategory.Script;
		}
		set
		{
			category = value;
		}
	}

	public DocumentFlags? Flags { get; set; }

	public DocumentContextCallback ContextCallback { get; set; }

	public DocumentInfo(string name)
	{
		this = default(DocumentInfo);
		this.name = name;
		uniqueId = Interlocked.Increment(ref lastUniqueId).ToUnsigned();
	}

	public DocumentInfo(Uri uri)
	{
		this = default(DocumentInfo);
		MiscHelpers.VerifyNonNullArgument(uri, "uri");
		this.uri = (uri.IsAbsoluteUri ? uri : new Uri(Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar.ToString() + uri));
		name = Path.GetFileName(this.uri.AbsolutePath);
		uniqueId = Interlocked.Increment(ref lastUniqueId).ToUnsigned();
	}

	internal UniqueDocumentInfo MakeUnique(ScriptEngine engine)
	{
		return MakeUnique(engine.DocumentNameManager);
	}

	internal UniqueDocumentInfo MakeUnique(ScriptEngine engine, DocumentFlags? defaultFlags)
	{
		return MakeUnique(engine.DocumentNameManager, defaultFlags);
	}

	internal UniqueDocumentInfo MakeUnique(IUniqueNameManager manager)
	{
		return MakeUnique(manager, null);
	}

	internal UniqueDocumentInfo MakeUnique(IUniqueNameManager manager, DocumentFlags? defaultFlags)
	{
		DocumentInfo info = this;
		if (!info.Flags.HasValue && defaultFlags.HasValue)
		{
			info.Flags = defaultFlags;
		}
		if (uniqueId < 1)
		{
			uniqueId = Interlocked.Increment(ref lastUniqueId).ToUnsigned();
		}
		string text = manager.GetUniqueName(Name, Category.DefaultName);
		if (Flags.GetValueOrDefault().HasFlag(DocumentFlags.IsTransient))
		{
			text += " [temp]";
		}
		return new UniqueDocumentInfo(info, uniqueId, text);
	}
}
