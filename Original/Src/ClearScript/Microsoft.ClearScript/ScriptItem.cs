using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices.Expando;
using Microsoft.ClearScript.Util;

namespace Microsoft.ClearScript;

internal abstract class ScriptItem : ScriptObject, IExpando, IReflect, IDynamic, IScriptMarshalWrapper
{
	private sealed class MetaScriptItem : DynamicMetaObject
	{
		private readonly DynamicMetaObject metaDynamic;

		public MetaScriptItem(DynamicMetaObject metaDynamic)
			: base(metaDynamic.Expression, metaDynamic.Restrictions, metaDynamic.Value)
		{
			this.metaDynamic = metaDynamic;
		}

		public override IEnumerable<string> GetDynamicMemberNames()
		{
			return metaDynamic.GetDynamicMemberNames();
		}

		public override DynamicMetaObject BindBinaryOperation(BinaryOperationBinder binder, DynamicMetaObject arg)
		{
			return PostProcessBindResult(metaDynamic.BindBinaryOperation(binder, arg));
		}

		public override DynamicMetaObject BindConvert(ConvertBinder binder)
		{
			return PostProcessBindResult(metaDynamic.BindConvert(binder));
		}

		public override DynamicMetaObject BindCreateInstance(CreateInstanceBinder binder, DynamicMetaObject[] args)
		{
			return PostProcessBindResult(metaDynamic.BindCreateInstance(binder, args));
		}

		public override DynamicMetaObject BindDeleteIndex(DeleteIndexBinder binder, DynamicMetaObject[] indexes)
		{
			return PostProcessBindResult(metaDynamic.BindDeleteIndex(binder, indexes));
		}

		public override DynamicMetaObject BindDeleteMember(DeleteMemberBinder binder)
		{
			return PostProcessBindResult(metaDynamic.BindDeleteMember(binder));
		}

		public override DynamicMetaObject BindGetIndex(GetIndexBinder binder, DynamicMetaObject[] indexes)
		{
			return PostProcessBindResult(metaDynamic.BindGetIndex(binder, indexes));
		}

		public override DynamicMetaObject BindGetMember(GetMemberBinder binder)
		{
			return PostProcessBindResult(metaDynamic.BindGetMember(binder));
		}

		public override DynamicMetaObject BindInvoke(InvokeBinder binder, DynamicMetaObject[] args)
		{
			return PostProcessBindResult(metaDynamic.BindInvoke(binder, args));
		}

		public override DynamicMetaObject BindInvokeMember(InvokeMemberBinder binder, DynamicMetaObject[] args)
		{
			return PostProcessBindResult(metaDynamic.BindInvokeMember(binder, args));
		}

		public override DynamicMetaObject BindSetIndex(SetIndexBinder binder, DynamicMetaObject[] indexes, DynamicMetaObject value)
		{
			return PostProcessBindResult(metaDynamic.BindSetIndex(binder, indexes, value));
		}

		public override DynamicMetaObject BindSetMember(SetMemberBinder binder, DynamicMetaObject value)
		{
			return PostProcessBindResult(metaDynamic.BindSetMember(binder, value));
		}

		public override DynamicMetaObject BindUnaryOperation(UnaryOperationBinder binder)
		{
			return PostProcessBindResult(metaDynamic.BindUnaryOperation(binder));
		}
	}

	private static readonly MethodInfo throwLastScriptErrorMethod = typeof(ScriptItem).GetMethod("ThrowLastScriptError");

	private static readonly MethodInfo clearLastScriptErrorMethod = typeof(ScriptItem).GetMethod("ClearLastScriptError");

	[ThreadStatic]
	private static IScriptEngineException lastScriptError;

	public override IEnumerable<string> PropertyNames => GetPropertyNames();

	public override IEnumerable<int> PropertyIndices => GetPropertyIndices();

	public new object this[string name, params object[] args]
	{
		get
		{
			return GetProperty(name, args).ToDynamicResult(Engine);
		}
		set
		{
			SetProperty(name, args.Concat(value.ToEnumerable()).ToArray());
		}
	}

	public new object this[int index]
	{
		get
		{
			return GetProperty(index).ToDynamicResult(Engine);
		}
		set
		{
			SetProperty(index, value);
		}
	}

	public Type UnderlyingSystemType
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public static void ThrowLastScriptError()
	{
		IScriptEngineException ex = lastScriptError;
		if (ex != null)
		{
			if (ex is ScriptInterruptedException)
			{
				throw new ScriptInterruptedException(ex.EngineName, ex.Message, ex.ErrorDetails, ex.HResult, ex.IsFatal, ex.ExecutionStarted, ex.ScriptException, ex.InnerException);
			}
			throw new ScriptEngineException(ex.EngineName, ex.Message, ex.ErrorDetails, ex.HResult, ex.IsFatal, ex.ExecutionStarted, ex.ScriptException, ex.InnerException);
		}
	}

	public static void ClearLastScriptError()
	{
		lastScriptError = null;
	}

	protected abstract bool TryBindAndInvoke(DynamicMetaObjectBinder binder, object[] args, out object result);

	protected virtual object[] AdjustInvokeArgs(object[] args)
	{
		return args;
	}

	private bool TryWrappedBindAndInvoke(DynamicMetaObjectBinder binder, object[] wrappedArgs, out object result)
	{
		object[] args = null;
		object[] savedArgs = null;
		object tempResult = null;
		if (Engine.ScriptInvoke(delegate
		{
			args = Engine.MarshalToScript(wrappedArgs);
			savedArgs = (object[])args.Clone();
			if (!TryBindAndInvoke(binder, args, out tempResult))
			{
				if (Engine.CurrentScriptFrame != null && lastScriptError == null)
				{
					lastScriptError = Engine.CurrentScriptFrame.ScriptError;
				}
				return false;
			}
			return true;
		}))
		{
			for (int num = 0; num < args.Length; num++)
			{
				object obj = args[num];
				if (obj != savedArgs[num])
				{
					wrappedArgs[num] = Engine.MarshalToHost(args[num], preserveHostTarget: false);
				}
			}
			result = Engine.MarshalToHost(tempResult, preserveHostTarget: false).ToDynamicResult(Engine);
			return true;
		}
		result = null;
		return false;
	}

	private bool TryWrappedInvokeOrInvokeMember(DynamicMetaObjectBinder binder, ParameterInfo[] parameters, object[] args, out object result)
	{
		Type[] array = null;
		if (parameters != null && parameters.Length >= args.Length)
		{
			array = (from param in parameters.Skip(parameters.Length - args.Length)
				select param.ParameterType).ToArray();
		}
		if (array != null)
		{
			for (int num = 0; num < array.Length; num++)
			{
				Type type = array[num];
				if (type.IsByRef)
				{
					args[num] = typeof(HostVariable<>).MakeSpecificType(type.GetElementType()).CreateInstance(args[num]);
				}
			}
		}
		if (TryWrappedBindAndInvoke(binder, AdjustInvokeArgs(args), out result))
		{
			if (array != null)
			{
				for (int num2 = 0; num2 < array.Length; num2++)
				{
					if (array[num2].IsByRef && args[num2] is IHostVariable hostVariable)
					{
						args[num2] = hostVariable.Value;
					}
				}
			}
			return true;
		}
		return false;
	}

	private string[] GetAllPropertyNames()
	{
		return GetPropertyNames().Concat(from index in GetPropertyIndices()
			select index.ToString(CultureInfo.InvariantCulture)).ToArray();
	}

	private static DynamicMetaObject PostProcessBindResult(DynamicMetaObject result)
	{
		BlockExpression body = Expression.Block(Expression.Call(throwLastScriptErrorMethod), Expression.Rethrow(), Expression.Default(result.Expression.Type));
		return new DynamicMetaObject(Expression.TryCatchFinally(result.Expression, Expression.Call(clearLastScriptErrorMethod), Expression.Catch(typeof(Exception), body)), result.Restrictions);
	}

	public override DynamicMetaObject GetMetaObject(Expression param)
	{
		return new MetaScriptItem(base.GetMetaObject(param));
	}

	public override IEnumerable<string> GetDynamicMemberNames()
	{
		return GetPropertyNames().Concat(from index in GetPropertyIndices()
			select index.ToString(CultureInfo.InvariantCulture));
	}

	public override bool TryGetMember(GetMemberBinder binder, out object result)
	{
		return TryWrappedBindAndInvoke(binder, ArrayHelpers.GetEmptyArray<object>(), out result);
	}

	public override bool TrySetMember(SetMemberBinder binder, object value)
	{
		object result;
		return TryWrappedBindAndInvoke(binder, new object[1] { value }, out result);
	}

	public override bool TryGetIndex(GetIndexBinder binder, object[] indices, out object result)
	{
		return TryWrappedBindAndInvoke(binder, indices, out result);
	}

	public override bool TrySetIndex(SetIndexBinder binder, object[] indices, object value)
	{
		object result;
		return TryWrappedBindAndInvoke(binder, indices.Concat(value.ToEnumerable()).ToArray(), out result);
	}

	public override bool TryInvoke(InvokeBinder binder, object[] args, out object result)
	{
		ParameterInfo[] parameters = null;
		if (Engine.EnableAutoHostVariables)
		{
			parameters = new StackFrame(1, fNeedFileInfo: false).GetMethod().GetParameters();
		}
		return TryWrappedInvokeOrInvokeMember(binder, parameters, args, out result);
	}

	public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
	{
		ParameterInfo[] parameters = null;
		if (Engine.EnableAutoHostVariables)
		{
			parameters = new StackFrame(1, fNeedFileInfo: false).GetMethod().GetParameters();
		}
		return TryWrappedInvokeOrInvokeMember(binder, parameters, args, out result);
	}

	public MethodInfo GetMethod(string name, BindingFlags bindFlags, Binder binder, Type[] types, ParameterModifier[] modifiers)
	{
		throw new NotImplementedException();
	}

	public MethodInfo GetMethod(string name, BindingFlags bindFlags)
	{
		throw new NotImplementedException();
	}

	public MethodInfo[] GetMethods(BindingFlags bindFlags)
	{
		return ArrayHelpers.GetEmptyArray<MethodInfo>();
	}

	public FieldInfo GetField(string name, BindingFlags bindFlags)
	{
		throw new NotImplementedException();
	}

	public FieldInfo[] GetFields(BindingFlags bindFlags)
	{
		return MemberMap.GetFields(GetAllPropertyNames());
	}

	public PropertyInfo GetProperty(string name, BindingFlags bindFlags)
	{
		throw new NotImplementedException();
	}

	public PropertyInfo GetProperty(string name, BindingFlags bindFlags, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
	{
		throw new NotImplementedException();
	}

	public PropertyInfo[] GetProperties(BindingFlags bindFlags)
	{
		return ArrayHelpers.GetEmptyArray<PropertyInfo>();
	}

	public MemberInfo[] GetMember(string name, BindingFlags bindFlags)
	{
		return new FieldInfo[1] { MemberMap.GetField(name) };
	}

	public MemberInfo[] GetMembers(BindingFlags bindFlags)
	{
		return GetFields(bindFlags);
	}

	public object InvokeMember(string name, BindingFlags invokeFlags, Binder binder, object target, object[] args, ParameterModifier[] modifiers, CultureInfo culture, string[] namedParameters)
	{
		if (invokeFlags.HasFlag(BindingFlags.InvokeMethod))
		{
			if (name == SpecialMemberNames.Default)
			{
				return Invoke(asConstructor: false, args);
			}
			return InvokeMethod(name, args);
		}
		if (invokeFlags.HasFlag(BindingFlags.GetField))
		{
			if (int.TryParse(name, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result))
			{
				return GetProperty(result);
			}
			return GetProperty(name, args);
		}
		if (invokeFlags.HasFlag(BindingFlags.SetField))
		{
			if (args.Length != 1)
			{
				throw new InvalidOperationException("Invalid argument count");
			}
			object obj = args[0];
			if (int.TryParse(name, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result2))
			{
				SetProperty(result2, obj);
				return obj;
			}
			SetProperty(name, args);
			return obj;
		}
		throw new InvalidOperationException("Invalid member access mode");
	}

	public FieldInfo AddField(string name)
	{
		throw new NotImplementedException();
	}

	public PropertyInfo AddProperty(string name)
	{
		throw new NotImplementedException();
	}

	public MethodInfo AddMethod(string name, Delegate method)
	{
		throw new NotImplementedException();
	}

	public void RemoveMember(MemberInfo member)
	{
		throw new NotImplementedException();
	}

	public object GetProperty(string name, out bool isCacheable, params object[] args)
	{
		isCacheable = false;
		return GetProperty(name, args);
	}

	public abstract string[] GetPropertyNames();

	public abstract int[] GetPropertyIndices();

	public abstract object Unwrap();
}
