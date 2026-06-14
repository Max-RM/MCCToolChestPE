using System;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.ClearScript.Util;

namespace Microsoft.ClearScript;

public class HostFunctions : IScriptableObject
{
	private ScriptEngine engine;

	public PropertyBag newObj()
	{
		return new PropertyBag();
	}

	public T newObj<T>(params object[] args)
	{
		return (T)typeof(T).CreateInstance(args);
	}

	public object newObj(object type, params object[] args)
	{
		return GetUniqueHostType(type, "type").CreateInstance(args);
	}

	public object newObj(IDynamicMetaObjectProvider target, params object[] args)
	{
		MiscHelpers.VerifyNonNullArgument(target, "target");
		if (target.GetMetaObject(Expression.Constant(target)).TryCreateInstance(args, out var result))
		{
			return result;
		}
		throw new InvalidOperationException("Invalid dynamic instantiation");
	}

	public object newArr<T>(params int[] lengths)
	{
		return Array.CreateInstance(typeof(T), lengths);
	}

	public object newArr(params int[] lengths)
	{
		return newArr<object>(lengths);
	}

	public object newVar<T>(T initValue = default(T))
	{
		return new HostVariable<T>(initValue);
	}

	public T del<T>(object scriptFunc)
	{
		return DelegateFactory.CreateDelegate<T>(GetEngine(), scriptFunc);
	}

	public object proc(int argCount, object scriptFunc)
	{
		return DelegateFactory.CreateProc(GetEngine(), scriptFunc, argCount);
	}

	public object func<T>(int argCount, object scriptFunc)
	{
		return DelegateFactory.CreateFunc<T>(GetEngine(), scriptFunc, argCount);
	}

	public object func(int argCount, object scriptFunc)
	{
		return func<object>(argCount, scriptFunc);
	}

	public Type typeOf<T>()
	{
		GetEngine().CheckReflection();
		return typeof(T);
	}

	public Type typeOf(object value)
	{
		GetEngine().CheckReflection();
		return GetUniqueHostType(value, "value");
	}

	public bool isType<T>(object value)
	{
		return value is T;
	}

	public object asType<T>(object value) where T : class
	{
		return HostItem.Wrap(GetEngine(), value as T, typeof(T));
	}

	public object cast<T>(object value)
	{
		return HostItem.Wrap(GetEngine(), value.DynamicCast<T>(), typeof(T));
	}

	public bool isTypeObj(object value)
	{
		return value is HostType;
	}

	public bool isTypeObj<T>()
	{
		return true;
	}

	public bool isNull(object value)
	{
		return value == null;
	}

	public T flags<T>(params T[] args)
	{
		Type typeFromHandle = typeof(T);
		if (!typeFromHandle.IsFlagsEnum())
		{
			throw new InvalidOperationException(MiscHelpers.FormatInvariant("{0} is not a flag set type", typeFromHandle.GetFullFriendlyName()));
		}
		try
		{
			return args.Aggregate(0uL, (ulong flags, T arg) => flags | Convert.ToUInt64(arg, CultureInfo.InvariantCulture)).DynamicCast<T>();
		}
		catch (OverflowException)
		{
			return args.Aggregate(0L, (long flags, T arg) => flags | Convert.ToInt64(arg, CultureInfo.InvariantCulture)).DynamicCast<T>();
		}
	}

	public object toSByte(IConvertible value)
	{
		return HostObject.Wrap(Convert.ToSByte(value));
	}

	public object toByte(IConvertible value)
	{
		return HostObject.Wrap(Convert.ToByte(value));
	}

	public object toInt16(IConvertible value)
	{
		return HostObject.Wrap(Convert.ToInt16(value));
	}

	public object toUInt16(IConvertible value)
	{
		return HostObject.Wrap(Convert.ToUInt16(value));
	}

	public object toChar(IConvertible value)
	{
		return HostObject.Wrap(Convert.ToChar(value));
	}

	public object toInt32(IConvertible value)
	{
		return HostObject.Wrap(Convert.ToInt32(value));
	}

	public object toUInt32(IConvertible value)
	{
		return HostObject.Wrap(Convert.ToUInt32(value));
	}

	public object toInt64(IConvertible value)
	{
		return HostObject.Wrap(Convert.ToInt64(value));
	}

	public object toUInt64(IConvertible value)
	{
		return HostObject.Wrap(Convert.ToUInt64(value));
	}

	public object toSingle(IConvertible value)
	{
		return HostObject.Wrap(Convert.ToSingle(value));
	}

	public object toDouble(IConvertible value)
	{
		return HostObject.Wrap(Convert.ToDouble(value));
	}

	public object toDecimal(IConvertible value)
	{
		return HostObject.Wrap(Convert.ToDecimal(value));
	}

	public object getProperty(IPropertyBag target, string name)
	{
		MiscHelpers.VerifyNonNullArgument(target, "target");
		if (target.TryGetValue(name, out var value))
		{
			return value;
		}
		return Nonexistent.Value;
	}

	public object setProperty(IPropertyBag target, string name, object value)
	{
		MiscHelpers.VerifyNonNullArgument(target, "target");
		return target[name] = value;
	}

	public bool removeProperty(IPropertyBag target, string name)
	{
		MiscHelpers.VerifyNonNullArgument(target, "target");
		return target.Remove(name);
	}

	public object getProperty(IDynamicMetaObjectProvider target, string name)
	{
		MiscHelpers.VerifyNonNullArgument(target, "target");
		if (target.GetMetaObject(Expression.Constant(target)).TryGetMember(name, out var result))
		{
			return result;
		}
		return Nonexistent.Value;
	}

	public object setProperty(IDynamicMetaObjectProvider target, string name, object value)
	{
		MiscHelpers.VerifyNonNullArgument(target, "target");
		if (target.GetMetaObject(Expression.Constant(target)).TrySetMember(name, value, out var result))
		{
			return result;
		}
		throw new InvalidOperationException("Invalid dynamic property assignment");
	}

	public bool removeProperty(IDynamicMetaObjectProvider target, string name)
	{
		MiscHelpers.VerifyNonNullArgument(target, "target");
		if (target.GetMetaObject(Expression.Constant(target)).TryDeleteMember(name, out var result))
		{
			return result;
		}
		throw new InvalidOperationException("Invalid dynamic property deletion");
	}

	public object getElement(IDynamicMetaObjectProvider target, params object[] indices)
	{
		MiscHelpers.VerifyNonNullArgument(target, "target");
		if (target.GetMetaObject(Expression.Constant(target)).TryGetIndex(indices, out var result))
		{
			return result;
		}
		return Nonexistent.Value;
	}

	public object setElement(IDynamicMetaObjectProvider target, object value, params object[] indices)
	{
		MiscHelpers.VerifyNonNullArgument(target, "target");
		if (target.GetMetaObject(Expression.Constant(target)).TrySetIndex(indices, value, out var result))
		{
			return result;
		}
		throw new InvalidOperationException("Invalid dynamic element assignment");
	}

	public bool removeElement(IDynamicMetaObjectProvider target, params object[] indices)
	{
		MiscHelpers.VerifyNonNullArgument(target, "target");
		if (target.GetMetaObject(Expression.Constant(target)).TryDeleteIndex(indices, out var result))
		{
			return result;
		}
		throw new InvalidOperationException("Invalid dynamic element deletion");
	}

	public object toStaticType(IDynamicMetaObjectProvider value)
	{
		return HostItem.Wrap(GetEngine(), value, HostItemFlags.HideDynamicMembers);
	}

	public bool tryCatch(object tryFunc, object catchFunc, object finallyFunc = null)
	{
		MiscHelpers.VerifyNonNullArgument(tryFunc, "tryFunc");
		MiscHelpers.VerifyNonNullArgument(catchFunc, "catchFunc");
		try
		{
			((dynamic)tryFunc)();
			return true;
		}
		catch (Exception ex)
		{
			if ((!((dynamic)catchFunc)(ex)))
			{
				throw;
			}
			return false;
		}
		finally
		{
			if (finallyFunc != null)
			{
				((dynamic)finallyFunc)();
			}
		}
	}

	internal ScriptEngine GetEngine()
	{
		ScriptEngine scriptEngine = ScriptEngine.Current ?? engine;
		if (scriptEngine == null)
		{
			throw new InvalidOperationException("Operation requires a script engine");
		}
		return scriptEngine;
	}

	internal static Type GetUniqueHostType(object type, string paramName)
	{
		if (!(type is HostType hostType))
		{
			throw new ArgumentException("Invalid host type", paramName);
		}
		if (hostType.Types.Length > 1)
		{
			throw new ArgumentException(MiscHelpers.FormatInvariant("'{0}' does not identify a unique host type", hostType.Types[0].GetLocator()), paramName);
		}
		return hostType.Types[0];
	}

	void IScriptableObject.OnExposedToScriptCode(ScriptEngine engine)
	{
		MiscHelpers.VerifyNonNullArgument(engine, "engine");
		this.engine = engine;
	}
}
