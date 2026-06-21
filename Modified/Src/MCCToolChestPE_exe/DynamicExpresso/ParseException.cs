using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Security.Permissions;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace DynamicExpresso;

[Serializable]
public class ParseException : DynamicExpressoException
{
	[CompilerGenerated]
	private int NtWe76cd9W;

	public int Position
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return NtWe76cd9W;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			NtWe76cd9W = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ParseException(string message, int position) : base(string.Format(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(30690), message, position))
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		Position = position;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected ParseException(SerializationInfo info, StreamingContext context) : base(info, context)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		Position = info.GetInt32(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17470));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		info.AddValue(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17470), Position);
		base.GetObjectData(info, context);
	}
}
