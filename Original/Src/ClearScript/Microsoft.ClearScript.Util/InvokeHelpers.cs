using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq.Expressions;
using System.Reflection;

namespace Microsoft.ClearScript.Util;

internal static class InvokeHelpers
{
	private sealed class ByRefArgItem
	{
		public IByRefArg ByRefArg { get; private set; }

		public Array Array { get; private set; }

		public int Index { get; private set; }

		public ByRefArgItem(IByRefArg arg, Array array, int index)
		{
			ByRefArg = arg;
			Array = array;
			Index = index;
		}
	}

	public static object InvokeMethod(IHostInvokeContext context, object target, MethodInfo method, object[] args)
	{
		List<object> list = new List<object>();
		List<ByRefArgItem> list2 = new List<ByRefArgItem>();
		object obj = null;
		ParameterInfo[] parameters = method.GetParameters();
		for (int i = 0; i < parameters.Length; i++)
		{
			ParameterInfo parameterInfo = parameters[i];
			if (Attribute.IsDefined(parameterInfo, typeof(ParamArrayAttribute)) && (i != args.Length - 1 || !parameterInfo.ParameterType.IsInstanceOfType(args[i])))
			{
				Type elementType = parameterInfo.ParameterType.GetElementType();
				Array array = Array.CreateInstance(elementType, args.Length - i);
				for (int j = i; j < args.Length; j++)
				{
					if (!(args[j] is IByRefArg byRefArg))
					{
						array.SetValue(GetCompatibleArg(parameterInfo.Name, elementType, args[j]), j - i);
						continue;
					}
					array.SetValue(GetCompatibleArg(parameterInfo.Name, elementType, byRefArg.Value), j - i);
					list2.Add(new ByRefArgItem(byRefArg, array, j - i));
				}
				list.Add(array);
				obj = array;
				break;
			}
			if (i < args.Length)
			{
				if (!(args[i] is IByRefArg byRefArg2))
				{
					list.Add(GetCompatibleArg(parameterInfo, args[i]));
					continue;
				}
				list.Add(GetCompatibleArg(parameterInfo, byRefArg2.Value));
				list2.Add(new ByRefArgItem(byRefArg2, null, i));
				continue;
			}
			if (!parameterInfo.IsOptional)
			{
				break;
			}
			if (parameterInfo.Attributes.HasFlag(ParameterAttributes.HasDefault))
			{
				try
				{
					list.Add(parameterInfo.DefaultValue);
				}
				catch (FormatException)
				{
					list.Add(null);
				}
			}
			else
			{
				list.Add(Missing.Value);
			}
		}
		object[] array2 = list.ToArray();
		object result = method.Invoke(target, array2);
		foreach (ByRefArgItem item in list2)
		{
			Array array3 = item.Array ?? array2;
			item.ByRefArg.Value = array3.GetValue(item.Index);
		}
		for (int k = 0; k < array2.Length && k < args.Length; k++)
		{
			object obj2 = array2[k];
			if (obj2 == obj)
			{
				break;
			}
			args[k] = obj2;
		}
		Type returnType = method.ReturnType;
		if (returnType == typeof(void))
		{
			return VoidResult.Value;
		}
		return context.Engine.PrepareResult(result, returnType, method.GetScriptMemberFlags(), isListIndexResult: false);
	}

	public static object InvokeDelegate(IHostInvokeContext context, Delegate del, object[] args)
	{
		return InvokeMethod(context, del, del.GetType().GetMethod("Invoke"), args);
	}

	public static bool TryInvokeObject(IHostInvokeContext context, object target, BindingFlags invokeFlags, object[] args, object[] bindArgs, bool tryDynamic, out object result)
	{
		if (target is HostTarget hostTarget)
		{
			if (hostTarget.TryInvoke(context, invokeFlags, args, bindArgs, out result))
			{
				return true;
			}
			if (hostTarget is HostType)
			{
				return false;
			}
			target = hostTarget.InvokeTarget;
			tryDynamic = tryDynamic && typeof(IDynamicMetaObjectProvider).IsAssignableFrom(hostTarget.Type);
		}
		if (target != null && invokeFlags.HasFlag(BindingFlags.InvokeMethod))
		{
			if (target is ScriptItem scriptItem)
			{
				target = DelegateFactory.CreateFunc<object>(scriptItem.Engine, target, args.Length);
			}
			if (target is Delegate del)
			{
				result = InvokeDelegate(context, del, args);
				return true;
			}
			if (tryDynamic && target is IDynamicMetaObjectProvider dynamicMetaObjectProvider && dynamicMetaObjectProvider.GetMetaObject(Expression.Constant(target)).TryInvoke(context, args, out result))
			{
				return true;
			}
		}
		result = null;
		return false;
	}

	private static object GetCompatibleArg(ParameterInfo param, object value)
	{
		return GetCompatibleArg(param.Name, param.ParameterType, value);
	}

	private static object GetCompatibleArg(string paramName, Type type, object value)
	{
		if (!type.IsAssignableFrom(ref value))
		{
			throw new ArgumentException(MiscHelpers.FormatInvariant("Invalid argument specified for parameter '{0}'", paramName));
		}
		return value;
	}
}
