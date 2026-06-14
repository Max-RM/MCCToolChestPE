using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Security.Permissions;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace DynamicExpresso;

[Serializable]
public class UnknownIdentifierException : ParseException
{
	[CompilerGenerated]
	private string ddXMSvKwx5;

	public string Identifier
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return ddXMSvKwx5;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			ddXMSvKwx5 = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public UnknownIdentifierException(string identifier, int position) : base(string.Format(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31336), identifier), position)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		Identifier = identifier;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected UnknownIdentifierException(SerializationInfo info, StreamingContext context) : base(info, context)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		Identifier = info.GetString(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(30938));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		info.AddValue(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(30938), Identifier);
		base.GetObjectData(info, context);
	}
}
