using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Security.Permissions;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace DynamicExpresso;

[Serializable]
public class AssignmentOperatorDisabledException : ParseException
{
	[CompilerGenerated]
	private string zYleds7PEH;

	public string OperatorString
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return zYleds7PEH;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			zYleds7PEH = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AssignmentOperatorDisabledException(string operatorString, int position) : base(string.Format(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(30732), operatorString), position)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		OperatorString = operatorString;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected AssignmentOperatorDisabledException(SerializationInfo info, StreamingContext context) : base(info, context)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		OperatorString = info.GetString(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(30810));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		info.AddValue(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(30810), OperatorString);
		base.GetObjectData(info, context);
	}
}
