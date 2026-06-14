using System.Runtime.CompilerServices;
using Substrate.Nbt;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.utils;

public class TagNodeUtils
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static short ReadShort(TagNodeCompound entity, string nodeName)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		short result = 0;
		if (entity.ContainsKey(nodeName) && entity[nodeName] is TagNodeShort)
		{
			result = entity[nodeName] as TagNodeShort;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float ReadFloat(TagNodeCompound entity, string nodeName)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		float result = 0f;
		if (entity.ContainsKey(nodeName) && entity[nodeName] is TagNodeFloat)
		{
			result = entity[nodeName] as TagNodeFloat;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int ReadInt(TagNodeCompound entity, string nodeName)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int result = 0;
		if (entity.ContainsKey(nodeName) && entity[nodeName] is TagNodeInt)
		{
			result = entity[nodeName] as TagNodeInt;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string ReadString(TagNodeCompound entity, string nodeName)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string result = "";
		if (entity.ContainsKey(nodeName) && entity[nodeName] is TagNodeString)
		{
			result = entity[nodeName] as TagNodeString;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteShort(TagNodeCompound entity, string nodeName, short value)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		entity[nodeName] = new TagNodeShort(value);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteFloat(TagNodeCompound entity, string nodeName, float value)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		entity[nodeName] = new TagNodeFloat(value);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TagNodeUtils()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}
}
