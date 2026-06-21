using System;

namespace Substrate.Nbt;

public static class VerifierLogger
{
	public static TagEventCode MissingTagHandler(TagEventArgs e)
	{
		Console.WriteLine("Missing Tag Error: '{0}'", e.TagName);
		return TagEventCode.NEXT;
	}

	public static TagEventCode InvalidTagTypeHandler(TagEventArgs e)
	{
		Console.WriteLine("Invalid Tag Type Error: '{0}' has type '{1}', expected '{2}'", e.TagName, e.Tag.GetTagType(), e.Schema.ToString());
		return TagEventCode.NEXT;
	}

	public static TagEventCode InvalidTagValueHandler(TagEventArgs e)
	{
		Console.WriteLine("Invalid Tag Value Error: '{0}' of type '{1}' is set to invalid value '{2}'", e.TagName, e.Tag.GetTagType(), e.Tag.ToString());
		return TagEventCode.NEXT;
	}
}
