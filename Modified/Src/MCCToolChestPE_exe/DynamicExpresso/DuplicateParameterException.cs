using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Security.Permissions;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace DynamicExpresso;

[Serializable]
public class DuplicateParameterException : DynamicExpressoException
{
	[CompilerGenerated]
	private string SOTeFjwgMu;

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
			return SOTeFjwgMu;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			SOTeFjwgMu = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DuplicateParameterException(string identifier) : base(string.Format(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(30842), identifier))
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		Identifier = identifier;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected DuplicateParameterException(SerializationInfo info, StreamingContext context) : base(info, context)
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
