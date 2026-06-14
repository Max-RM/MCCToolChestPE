using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Security.Permissions;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace DynamicExpresso;

[Serializable]
public class NoApplicableMethodException : ParseException
{
	[CompilerGenerated]
	private string mH5eIscDG2;

	[CompilerGenerated]
	private string zaDezUdBRX;

	public string MethodTypeName
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return mH5eIscDG2;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			mH5eIscDG2 = value;
		}
	}

	public string MethodName
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return zaDezUdBRX;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			zaDezUdBRX = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NoApplicableMethodException(string methodName, string methodTypeName, int position) : base(string.Format(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(30996), methodName, methodTypeName), position)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		MethodTypeName = methodTypeName;
		MethodName = methodName;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected NoApplicableMethodException(SerializationInfo info, StreamingContext context) : base(info, context)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		MethodTypeName = info.GetString(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31094));
		MethodName = info.GetString(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31126));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		info.AddValue(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31126), MethodName);
		info.AddValue(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31094), MethodTypeName);
		base.GetObjectData(info, context);
	}
}
