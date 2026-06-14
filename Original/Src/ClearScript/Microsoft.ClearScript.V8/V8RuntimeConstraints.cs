using System;

namespace Microsoft.ClearScript.V8;

public sealed class V8RuntimeConstraints
{
	public int MaxNewSpaceSize { get; set; }

	public int MaxOldSpaceSize { get; set; }

	[Obsolete("Executable code now occupies the old object heap. See MaxOldSpaceSize.")]
	public int MaxExecutableSize { get; set; }

	[Obsolete("Use MaxNewSpaceSize instead.")]
	public int MaxYoungSpaceSize
	{
		get
		{
			return MaxNewSpaceSize;
		}
		set
		{
			MaxNewSpaceSize = value;
		}
	}
}
