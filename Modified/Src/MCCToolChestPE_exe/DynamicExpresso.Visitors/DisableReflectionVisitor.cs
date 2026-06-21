using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace DynamicExpresso.Visitors;

public class DisableReflectionVisitor : ExpressionVisitor
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override Expression VisitMethodCall(MethodCallExpression node)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (node.Object != null && (typeof(Type).IsAssignableFrom(node.Object.Type) || typeof(MemberInfo).IsAssignableFrom(node.Object.Type)))
		{
			throw new ReflectionNotAllowedException();
		}
		return base.VisitMethodCall(node);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override Expression VisitMember(MemberExpression node)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if ((typeof(Type).IsAssignableFrom(node.Member.DeclaringType) || typeof(MemberInfo).IsAssignableFrom(node.Member.DeclaringType)) && node.Member.Name != Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10196))
		{
			throw new ReflectionNotAllowedException();
		}
		return base.VisitMember(node);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DisableReflectionVisitor()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}
}
