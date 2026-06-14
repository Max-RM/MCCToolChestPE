using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Expando;

namespace Microsoft.ClearScript.Util;

internal static class DynamicHelpers
{
	private sealed class DynamicCreateInstanceBinder : CreateInstanceBinder
	{
		public DynamicCreateInstanceBinder(string[] paramNames)
			: base(new CallInfo(paramNames.Length, paramNames))
		{
		}

		public override DynamicMetaObject FallbackCreateInstance(DynamicMetaObject target, DynamicMetaObject[] args, DynamicMetaObject errorSuggestion)
		{
			if (errorSuggestion != null)
			{
				return errorSuggestion;
			}
			return new DynamicMetaObject(Expression.Block(CreateThrowExpr<InvalidDynamicOperationException>("Invalid dynamic instantiation"), Expression.Constant(Nonexistent.Value)), BindingRestrictions.Empty);
		}
	}

	private sealed class DynamicInvokeBinder : InvokeBinder
	{
		public DynamicInvokeBinder(string[] paramNames)
			: base(new CallInfo(paramNames.Length, paramNames))
		{
		}

		public override DynamicMetaObject FallbackInvoke(DynamicMetaObject target, DynamicMetaObject[] args, DynamicMetaObject errorSuggestion)
		{
			if (errorSuggestion != null)
			{
				return errorSuggestion;
			}
			return new DynamicMetaObject(Expression.Block(CreateThrowExpr<InvalidDynamicOperationException>("Invalid dynamic object invocation"), Expression.Constant(Nonexistent.Value)), BindingRestrictions.Empty);
		}
	}

	private sealed class DynamicGetMemberBinder : GetMemberBinder
	{
		public DynamicGetMemberBinder(string name)
			: base(name, ignoreCase: false)
		{
		}

		public override DynamicMetaObject FallbackGetMember(DynamicMetaObject target, DynamicMetaObject errorSuggestion)
		{
			if (errorSuggestion != null)
			{
				return errorSuggestion;
			}
			return new DynamicMetaObject(Expression.Block(CreateThrowExpr<InvalidDynamicOperationException>("Invalid dynamic member retrieval"), Expression.Constant(Nonexistent.Value)), BindingRestrictions.Empty);
		}
	}

	private sealed class DynamicSetMemberBinder : SetMemberBinder
	{
		public DynamicSetMemberBinder(string name)
			: base(name, ignoreCase: false)
		{
		}

		public override DynamicMetaObject FallbackSetMember(DynamicMetaObject target, DynamicMetaObject value, DynamicMetaObject errorSuggestion)
		{
			if (errorSuggestion != null)
			{
				return errorSuggestion;
			}
			return new DynamicMetaObject(Expression.Block(CreateThrowExpr<InvalidDynamicOperationException>("Invalid dynamic member assignment"), Expression.Constant(Nonexistent.Value)), BindingRestrictions.Empty);
		}
	}

	private sealed class DynamicInvokeMemberBinder : InvokeMemberBinder
	{
		private static readonly MethodInfo invokeMemberValueMethod = typeof(DynamicInvokeMemberBinder).GetMethod("InvokeMemberValue", BindingFlags.Static | BindingFlags.NonPublic);

		private readonly IHostInvokeContext context;

		private readonly BindingFlags invokeFlags;

		public DynamicInvokeMemberBinder(IHostInvokeContext context, string name, BindingFlags invokeFlags, string[] paramNames)
			: base(name, ignoreCase: false, new CallInfo(paramNames.Length, paramNames))
		{
			this.context = context;
			this.invokeFlags = invokeFlags;
		}

		public override DynamicMetaObject FallbackInvokeMember(DynamicMetaObject target, DynamicMetaObject[] args, DynamicMetaObject errorSuggestion)
		{
			if (errorSuggestion != null)
			{
				return errorSuggestion;
			}
			return new DynamicMetaObject(Expression.Block(CreateThrowExpr<InvalidDynamicOperationException>("Invalid dynamic member invocation"), Expression.Constant(Nonexistent.Value)), BindingRestrictions.Empty);
		}

		public override DynamicMetaObject FallbackInvoke(DynamicMetaObject target, DynamicMetaObject[] args, DynamicMetaObject errorSuggestion)
		{
			if (errorSuggestion != null)
			{
				return errorSuggestion;
			}
			Expression[] arguments = new Expression[4]
			{
				Expression.Constant(context),
				target.Expression,
				Expression.Constant(invokeFlags),
				Expression.NewArrayInit(typeof(object), args.Select(GetArgRefExpr))
			};
			return new DynamicMetaObject(Expression.Call(invokeMemberValueMethod, arguments), BindingRestrictions.Empty);
		}

		private static Expression GetArgRefExpr(DynamicMetaObject arg)
		{
			Expression expression = arg.Expression;
			if (!expression.Type.IsValueType)
			{
				return expression;
			}
			return Expression.Convert(expression, typeof(object));
		}

		private static object InvokeMemberValue(IHostInvokeContext context, object target, BindingFlags invokeFlags, object[] args)
		{
			if (InvokeHelpers.TryInvokeObject(context, target, BindingFlags.InvokeMethod, args, args, tryDynamic: true, out var result))
			{
				return result;
			}
			if (invokeFlags.HasFlag(BindingFlags.GetField) && args.Length < 1)
			{
				return target;
			}
			throw new InvalidDynamicOperationException("Invalid dynamic member value invocation");
		}
	}

	private sealed class DynamicDeleteMemberBinder : DeleteMemberBinder
	{
		public DynamicDeleteMemberBinder(string name)
			: base(name, ignoreCase: false)
		{
		}

		public override DynamicMetaObject FallbackDeleteMember(DynamicMetaObject target, DynamicMetaObject errorSuggestion)
		{
			if (errorSuggestion != null)
			{
				return errorSuggestion;
			}
			return new DynamicMetaObject(CreateThrowExpr<InvalidDynamicOperationException>("Invalid dynamic member deletion"), BindingRestrictions.Empty);
		}
	}

	private sealed class DynamicGetIndexBinder : GetIndexBinder
	{
		public DynamicGetIndexBinder(string[] paramNames)
			: base(new CallInfo(paramNames.Length, paramNames))
		{
		}

		public override DynamicMetaObject FallbackGetIndex(DynamicMetaObject target, DynamicMetaObject[] indexes, DynamicMetaObject errorSuggestion)
		{
			if (errorSuggestion != null)
			{
				return errorSuggestion;
			}
			return new DynamicMetaObject(Expression.Block(CreateThrowExpr<InvalidDynamicOperationException>("Invalid dynamic index retrieval"), Expression.Constant(Nonexistent.Value)), BindingRestrictions.Empty);
		}
	}

	private sealed class DynamicSetIndexBinder : SetIndexBinder
	{
		public DynamicSetIndexBinder(string[] paramNames)
			: base(new CallInfo(paramNames.Length, paramNames))
		{
		}

		public override DynamicMetaObject FallbackSetIndex(DynamicMetaObject target, DynamicMetaObject[] indexes, DynamicMetaObject value, DynamicMetaObject errorSuggestion)
		{
			if (errorSuggestion != null)
			{
				return errorSuggestion;
			}
			return new DynamicMetaObject(Expression.Block(CreateThrowExpr<InvalidDynamicOperationException>("Invalid dynamic index assignment"), Expression.Constant(Nonexistent.Value)), BindingRestrictions.Empty);
		}
	}

	private sealed class DynamicDeleteIndexBinder : DeleteIndexBinder
	{
		public DynamicDeleteIndexBinder(string[] paramNames)
			: base(new CallInfo(paramNames.Length, paramNames))
		{
		}

		public override DynamicMetaObject FallbackDeleteIndex(DynamicMetaObject target, DynamicMetaObject[] indices, DynamicMetaObject errorSuggestion)
		{
			if (errorSuggestion != null)
			{
				return errorSuggestion;
			}
			return new DynamicMetaObject(CreateThrowExpr<InvalidDynamicOperationException>("Invalid dynamic index deletion"), BindingRestrictions.Empty);
		}
	}

	[Serializable]
	private sealed class InvalidDynamicOperationException : InvalidOperationException
	{
		public InvalidDynamicOperationException(string message)
			: base(message)
		{
		}
	}

	public static DynamicMetaObject Bind(DynamicMetaObjectBinder binder, object target, object[] args)
	{
		return binder.Bind(CreateDynamicTarget(target), CreateDynamicArgs(args));
	}

	public static object Invoke(Expression expr)
	{
		return Expression.Lambda(expr).Compile().DynamicInvoke();
	}

	public static object Invoke(Expression expr, IEnumerable<ParameterExpression> parameters, object[] args)
	{
		return Expression.Lambda(expr, parameters).Compile().DynamicInvoke(args);
	}

	public static bool TryBindAndInvoke(DynamicMetaObjectBinder binder, object target, object[] args, out object result)
	{
		try
		{
			if (target is IReflect reflect && reflect.GetType().IsCOMObject)
			{
				if (binder is GetMemberBinder getMemberBinder)
				{
					if (TryGetProperty(reflect, getMemberBinder.Name, getMemberBinder.IgnoreCase, args, out result))
					{
						return true;
					}
				}
				else if (binder is SetMemberBinder setMemberBinder)
				{
					if (TrySetProperty(reflect, setMemberBinder.Name, setMemberBinder.IgnoreCase, args, out result))
					{
						return true;
					}
				}
				else if (binder is CreateInstanceBinder)
				{
					if (TryCreateInstance(reflect, args, out result))
					{
						return true;
					}
				}
				else if (binder is InvokeBinder)
				{
					if (TryInvoke(reflect, args, out result))
					{
						return true;
					}
				}
				else if (binder is InvokeMemberBinder invokeMemberBinder)
				{
					if (TryInvokeMethod(reflect, invokeMemberBinder.Name, invokeMemberBinder.IgnoreCase, args, out result))
					{
						return true;
					}
				}
				else if (args != null && args.Length != 0)
				{
					if (binder is GetIndexBinder)
					{
						if (TryGetProperty(reflect, args[0].ToString(), ignoreCase: false, args.Skip(1).ToArray(), out result))
						{
							return true;
						}
					}
					else if (binder is SetIndexBinder && TrySetProperty(reflect, args[0].ToString(), ignoreCase: false, args.Skip(1).ToArray(), out result))
					{
						return true;
					}
				}
			}
			DynamicMetaObject dynamicMetaObject = Bind(binder, target, args);
			result = Invoke(dynamicMetaObject.Expression);
			return true;
		}
		catch (Exception ex)
		{
			result = ex;
			return false;
		}
	}

	public static bool TryCreateInstance(this DynamicMetaObject target, object[] args, out object result)
	{
		return TryDynamicOperation(() => target.CreateInstance(args), out result);
	}

	public static bool TryInvoke(this DynamicMetaObject target, IHostInvokeContext context, object[] args, out object result)
	{
		return TryDynamicOperation(() => target.Invoke(args), out result);
	}

	public static bool TryInvokeMember(this DynamicMetaObject target, IHostInvokeContext context, string name, BindingFlags invokeFlags, object[] args, out object result)
	{
		return TryDynamicOperation(() => target.InvokeMember(context, name, invokeFlags, args), out result);
	}

	public static bool TryGetMember(this DynamicMetaObject target, string name, out object result)
	{
		return TryDynamicOperation(() => target.GetMember(name), out result);
	}

	public static bool TrySetMember(this DynamicMetaObject target, string name, object value, out object result)
	{
		return TryDynamicOperation(() => target.SetMember(name, value), out result);
	}

	public static bool TryDeleteMember(this DynamicMetaObject target, string name, out bool result)
	{
		return TryDynamicOperation(() => target.DeleteMember(name), out result);
	}

	public static bool TryGetIndex(this DynamicMetaObject target, object[] indices, out object result)
	{
		return TryDynamicOperation(() => target.GetIndex(indices), out result);
	}

	public static bool TrySetIndex(this DynamicMetaObject target, object[] indices, object value, out object result)
	{
		return TryDynamicOperation(() => target.SetIndex(indices, value), out result);
	}

	public static bool TryDeleteIndex(this DynamicMetaObject target, object[] indices, out bool result)
	{
		return TryDynamicOperation(() => target.DeleteIndex(indices), out result);
	}

	private static bool TryGetProperty(IReflect target, string name, bool ignoreCase, object[] args, out object result)
	{
		if (target is IDispatchEx dispatchEx)
		{
			result = dispatchEx.GetProperty(name, ignoreCase, args);
			return true;
		}
		BindingFlags bindingFlags = BindingFlags.Public;
		if (ignoreCase)
		{
			bindingFlags |= BindingFlags.IgnoreCase;
		}
		PropertyInfo property = target.GetProperty(name, bindingFlags);
		if (property != null)
		{
			result = property.GetValue(target, args);
			return true;
		}
		result = null;
		return false;
	}

	private static bool TrySetProperty(IReflect target, string name, bool ignoreCase, object[] args, out object result)
	{
		if (args != null && args.Length != 0)
		{
			if (target is IDispatchEx dispatchEx)
			{
				dispatchEx.SetProperty(name, ignoreCase, args);
				result = args[args.Length - 1];
				return true;
			}
			BindingFlags bindingFlags = BindingFlags.Public;
			if (ignoreCase)
			{
				bindingFlags |= BindingFlags.IgnoreCase;
			}
			PropertyInfo propertyInfo = target.GetProperty(name, bindingFlags);
			if (propertyInfo == null && target is IExpando expando)
			{
				propertyInfo = expando.AddProperty(name);
			}
			if (propertyInfo != null)
			{
				propertyInfo.SetValue(target, args[args.Length - 1], args.Take(args.Length - 1).ToArray());
				result = args[args.Length - 1];
				return true;
			}
		}
		result = null;
		return false;
	}

	private static bool TryCreateInstance(IReflect target, object[] args, out object result)
	{
		if (target is IDispatchEx dispatchEx)
		{
			result = dispatchEx.Invoke(asConstructor: true, args);
			return true;
		}
		try
		{
			result = target.InvokeMember(SpecialMemberNames.Default, BindingFlags.CreateInstance, null, target, args, null, CultureInfo.InvariantCulture, null);
			return true;
		}
		catch (TargetInvocationException)
		{
			throw;
		}
		catch (Exception)
		{
			result = null;
			return false;
		}
	}

	private static bool TryInvoke(IReflect target, object[] args, out object result)
	{
		if (target is IDispatchEx dispatchEx)
		{
			result = dispatchEx.Invoke(asConstructor: false, args);
			return true;
		}
		try
		{
			result = target.InvokeMember(SpecialMemberNames.Default, BindingFlags.InvokeMethod, null, target, args, null, CultureInfo.InvariantCulture, null);
			return true;
		}
		catch (TargetInvocationException)
		{
			throw;
		}
		catch (Exception)
		{
			result = null;
			return false;
		}
	}

	private static bool TryInvokeMethod(IReflect target, string name, bool ignoreCase, object[] args, out object result)
	{
		if (target is IDispatchEx dispatchEx)
		{
			result = dispatchEx.InvokeMethod(name, ignoreCase, args);
			return true;
		}
		BindingFlags bindingFlags = BindingFlags.Public;
		if (ignoreCase)
		{
			bindingFlags |= BindingFlags.IgnoreCase;
		}
		MethodInfo method = target.GetMethod(name, bindingFlags);
		if (method != null)
		{
			result = method.Invoke(target, BindingFlags.InvokeMethod | bindingFlags, null, args, CultureInfo.InvariantCulture);
			return true;
		}
		result = null;
		return false;
	}

	private static bool TryDynamicOperation<T>(Func<T> operation, out T result)
	{
		try
		{
			result = operation();
			return true;
		}
		catch (TargetInvocationException ex)
		{
			if (ex.InnerException is InvalidDynamicOperationException)
			{
				result = default(T);
				return false;
			}
			throw;
		}
	}

	private static object CreateInstance(this DynamicMetaObject target, object[] args)
	{
		string[] array = (from index in Enumerable.Range(0, args.Length)
			select "a" + index).ToArray();
		ParameterExpression[] array2 = array.Select((string paramName, int index) => Expression.Parameter(GetParamTypeForArg(args[index]), paramName)).ToArray();
		DynamicMetaObject[] args2 = array2.Select((ParameterExpression paramExpr) => new DynamicMetaObject(paramExpr, BindingRestrictions.Empty)).ToArray();
		DynamicMetaObject dynamicMetaObject = target.BindCreateInstance(new DynamicCreateInstanceBinder(array), args2);
		BlockExpression expr = Expression.Block(Expression.Label(CallSiteBinder.UpdateLabel), dynamicMetaObject.Expression);
		return Invoke(expr, array2, args);
	}

	private static object Invoke(this DynamicMetaObject target, object[] args)
	{
		string[] array = (from index in Enumerable.Range(0, args.Length)
			select "a" + index).ToArray();
		ParameterExpression[] array2 = array.Select((string paramName, int index) => Expression.Parameter(GetParamTypeForArg(args[index]), paramName)).ToArray();
		DynamicMetaObject[] args2 = array2.Select((ParameterExpression paramExpr) => new DynamicMetaObject(paramExpr, BindingRestrictions.Empty)).ToArray();
		DynamicMetaObject dynamicMetaObject = target.BindInvoke(new DynamicInvokeBinder(array), args2);
		BlockExpression expr = Expression.Block(Expression.Label(CallSiteBinder.UpdateLabel), dynamicMetaObject.Expression);
		return Invoke(expr, array2, args);
	}

	private static object InvokeMember(this DynamicMetaObject target, IHostInvokeContext context, string name, BindingFlags invokeFlags, object[] args)
	{
		string[] array = (from index in Enumerable.Range(0, args.Length)
			select "a" + index).ToArray();
		ParameterExpression[] array2 = array.Select((string paramName, int index) => Expression.Parameter(GetParamTypeForArg(args[index]), paramName)).ToArray();
		DynamicMetaObject[] args2 = array2.Select((ParameterExpression paramExpr) => new DynamicMetaObject(paramExpr, BindingRestrictions.Empty)).ToArray();
		DynamicMetaObject dynamicMetaObject = target.BindInvokeMember(new DynamicInvokeMemberBinder(context, name, invokeFlags, array), args2);
		BlockExpression expr = Expression.Block(Expression.Label(CallSiteBinder.UpdateLabel), dynamicMetaObject.Expression);
		return Invoke(expr, array2, args);
	}

	private static object GetMember(this DynamicMetaObject target, string name)
	{
		DynamicMetaObject dynamicMetaObject = target.BindGetMember(new DynamicGetMemberBinder(name));
		BlockExpression expr = Expression.Block(Expression.Label(CallSiteBinder.UpdateLabel), dynamicMetaObject.Expression);
		return Invoke(expr);
	}

	private static object SetMember(this DynamicMetaObject target, string name, object value)
	{
		DynamicMetaObject dynamicMetaObject = target.BindSetMember(new DynamicSetMemberBinder(name), CreateDynamicArg(value));
		BlockExpression expr = Expression.Block(Expression.Label(CallSiteBinder.UpdateLabel), dynamicMetaObject.Expression);
		return Invoke(expr);
	}

	private static bool DeleteMember(this DynamicMetaObject target, string name)
	{
		DynamicMetaObject dynamicMetaObject = target.BindDeleteMember(new DynamicDeleteMemberBinder(name));
		BlockExpression expr = Expression.Block(Expression.Label(CallSiteBinder.UpdateLabel), dynamicMetaObject.Expression);
		try
		{
			Invoke(expr);
			return true;
		}
		catch (TargetInvocationException ex)
		{
			if (ex.InnerException is InvalidDynamicOperationException)
			{
				return false;
			}
			throw;
		}
	}

	private static object GetIndex(this DynamicMetaObject target, object[] indices)
	{
		string[] array = (from index in Enumerable.Range(0, indices.Length)
			select "a" + index).ToArray();
		ParameterExpression[] array2 = array.Select((string paramName, int index) => Expression.Parameter(GetParamTypeForArg(indices[index]), paramName)).ToArray();
		DynamicMetaObject[] indexes = array2.Select((ParameterExpression paramExpr) => new DynamicMetaObject(paramExpr, BindingRestrictions.Empty)).ToArray();
		DynamicMetaObject dynamicMetaObject = target.BindGetIndex(new DynamicGetIndexBinder(array), indexes);
		BlockExpression expr = Expression.Block(Expression.Label(CallSiteBinder.UpdateLabel), dynamicMetaObject.Expression);
		return Invoke(expr, array2, indices);
	}

	private static object SetIndex(this DynamicMetaObject target, object[] indices, object value)
	{
		string[] array = (from index in Enumerable.Range(0, indices.Length)
			select "a" + index).ToArray();
		ParameterExpression[] array2 = array.Select((string paramName, int index) => Expression.Parameter(GetParamTypeForArg(indices[index]), paramName)).ToArray();
		DynamicMetaObject[] indexes = array2.Select((ParameterExpression paramExpr) => new DynamicMetaObject(paramExpr, BindingRestrictions.Empty)).ToArray();
		DynamicMetaObject dynamicMetaObject = target.BindSetIndex(new DynamicSetIndexBinder(array), indexes, CreateDynamicArg(value));
		BlockExpression expr = Expression.Block(Expression.Label(CallSiteBinder.UpdateLabel), dynamicMetaObject.Expression);
		return Invoke(expr, array2, indices);
	}

	private static bool DeleteIndex(this DynamicMetaObject target, object[] indices)
	{
		string[] array = (from index in Enumerable.Range(0, indices.Length)
			select "a" + index).ToArray();
		ParameterExpression[] array2 = array.Select((string paramName, int index) => Expression.Parameter(GetParamTypeForArg(indices[index]), paramName)).ToArray();
		DynamicMetaObject[] indexes = array2.Select((ParameterExpression paramExpr) => new DynamicMetaObject(paramExpr, BindingRestrictions.Empty)).ToArray();
		DynamicMetaObject dynamicMetaObject = target.BindDeleteIndex(new DynamicDeleteIndexBinder(array), indexes);
		BlockExpression expr = Expression.Block(Expression.Label(CallSiteBinder.UpdateLabel), dynamicMetaObject.Expression);
		try
		{
			Invoke(expr, array2, indices);
			return true;
		}
		catch (TargetInvocationException ex)
		{
			if (ex.InnerException is InvalidDynamicOperationException)
			{
				return false;
			}
			throw;
		}
	}

	private static DynamicMetaObject CreateDynamicTarget(object target)
	{
		if (target is IByRefArg byRefArg)
		{
			return CreateDynamicMetaObject(byRefArg.Value, Expression.Parameter(byRefArg.Type.MakeByRefType()));
		}
		if (!(target is HostTarget hostTarget))
		{
			return CreateDynamicMetaObject(target, Expression.Constant(target));
		}
		target = hostTarget.DynamicInvokeTarget;
		if (hostTarget is HostType)
		{
			return CreateDynamicMetaObject(target, Expression.Constant(target));
		}
		Type type = hostTarget.Type;
		try
		{
			return CreateDynamicMetaObject(target, Expression.Constant(target, type));
		}
		catch (ArgumentException)
		{
			return CreateDynamicMetaObject(target, Expression.Constant(target));
		}
	}

	private static DynamicMetaObject CreateDynamicArg(object arg)
	{
		if (arg is IByRefArg byRefArg)
		{
			return CreateDynamicMetaObject(byRefArg.Value, Expression.Parameter(byRefArg.Type.MakeByRefType()));
		}
		if (arg is HostType)
		{
			return CreateDynamicMetaObject(arg, Expression.Constant(arg));
		}
		if (!(arg is HostTarget hostTarget))
		{
			return CreateDynamicMetaObject(arg, Expression.Constant(arg));
		}
		arg = hostTarget.Target;
		Type type = hostTarget.Type;
		try
		{
			return CreateDynamicMetaObject(arg, Expression.Constant(arg, type));
		}
		catch (ArgumentException)
		{
			return CreateDynamicMetaObject(arg, Expression.Constant(arg));
		}
	}

	private static DynamicMetaObject[] CreateDynamicArgs(object[] args)
	{
		return args.Select(CreateDynamicArg).ToArray();
	}

	private static DynamicMetaObject CreateDynamicMetaObject(object value, Expression expr)
	{
		return new DynamicMetaObject(expr, BindingRestrictions.Empty, value);
	}

	private static Expression CreateThrowExpr<T>(string message) where T : Exception
	{
		ConstructorInfo constructor = typeof(T).GetConstructor(new Type[1] { typeof(string) });
		Expression value = ((!(constructor != null)) ? ((Expression)Expression.Constant(typeof(T).CreateInstance(message))) : ((Expression)Expression.New(constructor, Expression.Constant(message))));
		return Expression.Throw(value);
	}

	private static Type GetParamTypeForArg(object arg)
	{
		if (arg == null)
		{
			return typeof(object);
		}
		return arg.GetType();
	}
}
