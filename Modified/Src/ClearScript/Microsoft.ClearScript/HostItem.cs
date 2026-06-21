using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices.Expando;
using System.Threading;
using Microsoft.ClearScript.Util;
using Microsoft.CSharp.RuntimeBinder;

namespace Microsoft.ClearScript;

internal class HostItem : DynamicObject, IReflect, IDynamic, IEnumVARIANT, ICustomQueryInterface, IScriptMarshalWrapper, IHostInvokeContext
{
	private abstract class MethodBindResult
	{
		public abstract object RawResult { get; }

		public static MethodBindResult Create(string name, object rawResult, HostTarget hostTarget, object[] args)
		{
			MethodInfo method = rawResult as MethodInfo;
			if (method != null)
			{
				if (method.IsStatic && !hostTarget.Flags.HasFlag(HostTargetFlags.AllowStaticMembers))
				{
					return new MethodBindFailure(() => new InvalidOperationException(MiscHelpers.FormatInvariant("Cannot access static method '{0}' in non-static context", method.Name)));
				}
				return new MethodBindSuccess(hostTarget, method, args);
			}
			return new MethodBindFailure((rawResult as Func<Exception>) ?? ((Func<Exception>)(() => new NotSupportedException(MiscHelpers.FormatInvariant("Invocation of method '{0}' failed (unrecognized binding)", name)))));
		}

		public abstract bool IsPreferredMethod(HostItem hostItem, string name);

		public abstract bool IsUnblockedMethod(HostItem hostItem);

		public abstract object Invoke(HostItem hostItem);
	}

	private sealed class MethodBindSuccess : MethodBindResult
	{
		private static readonly MethodInfo[] reflectionMethods = new MethodInfo[3]
		{
			typeof(object).GetMethod("GetType"),
			typeof(_Exception).GetMethod("GetType"),
			typeof(Exception).GetMethod("GetType")
		};

		private readonly HostTarget hostTarget;

		private readonly MethodInfo method;

		private readonly object[] args;

		public override object RawResult => method;

		public MethodBindSuccess(HostTarget hostTarget, MethodInfo method, object[] args)
		{
			this.hostTarget = hostTarget;
			this.method = method;
			this.args = args;
		}

		public override bool IsPreferredMethod(HostItem hostItem, string name)
		{
			if (!method.IsBlockedFromScript(hostItem.DefaultAccess))
			{
				return method.GetScriptName() == name;
			}
			return false;
		}

		public override bool IsUnblockedMethod(HostItem hostItem)
		{
			return !method.IsBlockedFromScript(hostItem.DefaultAccess);
		}

		public override object Invoke(HostItem hostItem)
		{
			if (reflectionMethods.Contains(method, MemberComparer<MethodInfo>.Instance))
			{
				hostItem.Engine.CheckReflection();
			}
			return InvokeHelpers.InvokeMethod(hostItem, hostTarget.InvokeTarget, method, args);
		}
	}

	private sealed class MethodBindFailure : MethodBindResult
	{
		private readonly Func<Exception> exceptionFactory;

		public override object RawResult => exceptionFactory;

		public MethodBindFailure(Func<Exception> exceptionFactory)
		{
			this.exceptionFactory = exceptionFactory;
		}

		public override bool IsPreferredMethod(HostItem hostItem, string name)
		{
			return false;
		}

		public override bool IsUnblockedMethod(HostItem hostItem)
		{
			return false;
		}

		public override object Invoke(HostItem hostItem)
		{
			throw exceptionFactory();
		}
	}

	private sealed class MethodBindingVisitor : ExpressionVisitor
	{
		private readonly object target;

		private readonly string name;

		private readonly List<object> results = new List<object>();

		public object Result => results[0];

		public MethodBindingVisitor(object target, string name, Expression expression)
		{
			this.target = target;
			this.name = name;
			Visit(expression);
			if (results.Count != 1)
			{
				results.Clear();
				AddResult(() => new NotSupportedException(MiscHelpers.FormatInvariant("Invocation of method '{0}' failed (unrecognized binding)", name)));
			}
			else
			{
				MethodInfo methodInfo = results[0] as MethodInfo;
				_ = methodInfo != null;
			}
		}

		protected override Expression VisitMethodCall(MethodCallExpression node)
		{
			if (node.Method.Name == name)
			{
				AddResult(node.Method);
			}
			return base.VisitMethodCall(node);
		}

		protected override Expression VisitInvocation(InvocationExpression node)
		{
			if (target is Delegate obj)
			{
				Delegate obj2 = DynamicHelpers.Invoke(node.Expression) as Delegate;
				if (obj2 == obj)
				{
					AddResult(obj2.GetType().GetMethod("Invoke"));
				}
			}
			return base.VisitInvocation(node);
		}

		protected override Expression VisitUnary(UnaryExpression node)
		{
			if (node.NodeType == ExpressionType.Throw && DynamicHelpers.Invoke(node.Operand) is Exception)
			{
				AddResult(() => (Exception)DynamicHelpers.Invoke(node.Operand));
			}
			return base.VisitUnary(node);
		}

		private void AddResult(MethodInfo method)
		{
			results.Add(method);
		}

		private void AddResult(Func<Exception> exceptionFactory)
		{
			results.Add(exceptionFactory);
		}
	}

	public delegate HostItem CreateFunc(ScriptEngine engine, HostTarget target, HostItemFlags flags);

	private sealed class ExpandoHostItem : HostItem, IExpando, IReflect
	{
		public ExpandoHostItem(ScriptEngine engine, HostTarget target, HostItemFlags flags)
			: base(engine, target, flags)
		{
		}

		FieldInfo IExpando.AddField(string name)
		{
			return HostInvoke(delegate
			{
				if (CanAddExpandoMembers())
				{
					AddExpandoMemberName(name);
					return MemberMap.GetField(name);
				}
				throw new NotSupportedException("Object does not support dynamic fields");
			});
		}

		PropertyInfo IExpando.AddProperty(string name)
		{
			return HostInvoke(delegate
			{
				if (CanAddExpandoMembers())
				{
					AddExpandoMemberName(name);
					return MemberMap.GetProperty(name);
				}
				throw new NotSupportedException("Object does not support dynamic properties");
			});
		}

		MethodInfo IExpando.AddMethod(string name, Delegate method)
		{
			throw new NotImplementedException();
		}

		void IExpando.RemoveMember(MemberInfo member)
		{
			HostInvoke(delegate
			{
				if (base.TargetDynamic != null)
				{
					if (int.TryParse(member.Name, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result))
					{
						if (base.TargetDynamic.DeleteProperty(result))
						{
							RemoveExpandoMemberName(result.ToString(CultureInfo.InvariantCulture));
						}
					}
					else if (base.TargetDynamic.DeleteProperty(member.Name))
					{
						RemoveExpandoMemberName(member.Name);
					}
				}
				else if (base.TargetPropertyBag != null)
				{
					if (base.TargetPropertyBag.Remove(member.Name))
					{
						RemoveExpandoMemberName(member.Name);
					}
				}
				else
				{
					if (base.TargetDynamicMetaObject == null)
					{
						throw new NotSupportedException("Object does not support dynamic members");
					}
					int result3;
					if (base.TargetDynamicMetaObject.TryDeleteMember(member.Name, out var result2) && result2)
					{
						RemoveExpandoMemberName(member.Name);
					}
					else if (int.TryParse(member.Name, NumberStyles.Integer, CultureInfo.InvariantCulture, out result3) && base.TargetDynamicMetaObject.TryDeleteIndex(new object[1] { result3 }, out result2))
					{
						RemoveExpandoMemberName(result3.ToString(CultureInfo.InvariantCulture));
					}
					else if (base.TargetDynamicMetaObject.TryDeleteIndex(new object[1] { member.Name }, out result2))
					{
						RemoveExpandoMemberName(member.Name);
					}
				}
			});
		}
	}

	private static readonly ConcurrentDictionary<BindSignature, object> coreBindCache = new ConcurrentDictionary<BindSignature, object>();

	private static long coreBindCount;

	private readonly ScriptEngine engine;

	private readonly HostTarget target;

	private readonly HostItemFlags flags;

	private Type accessContext;

	private ScriptAccess defaultAccess;

	private HostTargetMemberData targetMemberData;

	internal static bool EnableVTablePatching;

	[ThreadStatic]
	private static bool bypassVTablePatching;

	private static readonly PropertyInfo[] reflectionProperties = new PropertyInfo[1] { typeof(Delegate).GetProperty("Method") };

	public HostTarget Target => target;

	public HostItemFlags Flags => flags;

	public Invocability Invocability
	{
		get
		{
			if (!TargetInvocability.HasValue)
			{
				TargetInvocability = target.GetInvocability(GetCommonBindFlags(), accessContext, defaultAccess, flags.HasFlag(HostItemFlags.HideDynamicMembers));
			}
			return TargetInvocability.GetValueOrDefault();
		}
	}

	private IReflect ThisReflect => this;

	private IDynamic ThisDynamic => this;

	private IDynamic TargetDynamic => Collateral.TargetDynamic.Get(this);

	private IPropertyBag TargetPropertyBag
	{
		get
		{
			return Collateral.TargetPropertyBag.Get(this);
		}
		set
		{
			Collateral.TargetPropertyBag.Set(this, value);
		}
	}

	private IHostList TargetList
	{
		get
		{
			return Collateral.TargetList.Get(this);
		}
		set
		{
			Collateral.TargetList.Set(this, value);
		}
	}

	private DynamicMetaObject TargetDynamicMetaObject
	{
		get
		{
			return Collateral.TargetDynamicMetaObject.Get(this);
		}
		set
		{
			Collateral.TargetDynamicMetaObject.Set(this, value);
		}
	}

	private IEnumerator TargetEnumerator => Collateral.TargetEnumerator.Get(this);

	private HashSet<string> ExpandoMemberNames
	{
		get
		{
			return Collateral.ExpandoMemberNames.Get(this);
		}
		set
		{
			Collateral.ExpandoMemberNames.Set(this, value);
		}
	}

	private Dictionary<string, HostMethod> HostMethodMap
	{
		get
		{
			return Collateral.HostMethodMap.Get(this);
		}
		set
		{
			Collateral.HostMethodMap.Set(this, value);
		}
	}

	private Dictionary<string, HostIndexedProperty> HostIndexedPropertyMap
	{
		get
		{
			return Collateral.HostIndexedPropertyMap.Get(this);
		}
		set
		{
			Collateral.HostIndexedPropertyMap.Set(this, value);
		}
	}

	private int[] PropertyIndices
	{
		get
		{
			return Collateral.ListData.GetOrCreate(this).PropertyIndices;
		}
		set
		{
			Collateral.ListData.GetOrCreate(this).PropertyIndices = value;
		}
	}

	private int CachedListCount
	{
		get
		{
			return Collateral.ListData.GetOrCreate(this).CachedCount;
		}
		set
		{
			Collateral.ListData.GetOrCreate(this).CachedCount = value;
		}
	}

	private HostItemCollateral Collateral => Engine.HostItemCollateral;

	private string[] TypeEventNames
	{
		get
		{
			return targetMemberData.TypeEventNames;
		}
		set
		{
			targetMemberData.TypeEventNames = value;
		}
	}

	private string[] TypeFieldNames
	{
		get
		{
			return targetMemberData.TypeFieldNames;
		}
		set
		{
			targetMemberData.TypeFieldNames = value;
		}
	}

	private string[] TypeMethodNames
	{
		get
		{
			return targetMemberData.TypeMethodNames;
		}
		set
		{
			targetMemberData.TypeMethodNames = value;
		}
	}

	private string[] TypePropertyNames
	{
		get
		{
			return targetMemberData.TypePropertyNames;
		}
		set
		{
			targetMemberData.TypePropertyNames = value;
		}
	}

	private string[] AllFieldNames
	{
		get
		{
			return targetMemberData.AllFieldNames;
		}
		set
		{
			targetMemberData.AllFieldNames = value;
		}
	}

	private string[] AllMethodNames
	{
		get
		{
			return targetMemberData.AllMethodNames;
		}
		set
		{
			targetMemberData.AllMethodNames = value;
		}
	}

	private string[] OwnMethodNames
	{
		get
		{
			return targetMemberData.OwnMethodNames;
		}
		set
		{
			targetMemberData.OwnMethodNames = value;
		}
	}

	private string[] EnumeratedMethodNames
	{
		get
		{
			if (!engine.EnumerateInstanceMethods)
			{
				return ArrayHelpers.GetEmptyArray<string>();
			}
			if (!engine.EnumerateExtensionMethods)
			{
				return OwnMethodNames;
			}
			return AllMethodNames;
		}
	}

	private string[] AllPropertyNames
	{
		get
		{
			return targetMemberData.AllPropertyNames;
		}
		set
		{
			targetMemberData.AllPropertyNames = value;
		}
	}

	private string[] AllMemberNames
	{
		get
		{
			return targetMemberData.AllMemberNames;
		}
		set
		{
			targetMemberData.AllMemberNames = value;
		}
	}

	private FieldInfo[] AllFields
	{
		get
		{
			return targetMemberData.AllFields;
		}
		set
		{
			targetMemberData.AllFields = value;
		}
	}

	private MethodInfo[] AllMethods
	{
		get
		{
			return targetMemberData.AllMethods;
		}
		set
		{
			targetMemberData.AllMethods = value;
		}
	}

	private PropertyInfo[] AllProperties
	{
		get
		{
			return targetMemberData.AllProperties;
		}
		set
		{
			targetMemberData.AllProperties = value;
		}
	}

	private object EnumerationSettingsToken
	{
		get
		{
			return targetMemberData.EnumerationSettingsToken;
		}
		set
		{
			targetMemberData.EnumerationSettingsToken = value;
		}
	}

	private ExtensionMethodSummary ExtensionMethodSummary
	{
		get
		{
			return targetMemberData.ExtensionMethodSummary;
		}
		set
		{
			targetMemberData.ExtensionMethodSummary = value;
		}
	}

	private Invocability? TargetInvocability
	{
		get
		{
			return targetMemberData.TargetInvocability;
		}
		set
		{
			targetMemberData.TargetInvocability = value;
		}
	}

	Type IReflect.UnderlyingSystemType
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public ScriptEngine Engine => engine;

	public Type AccessContext => accessContext;

	public ScriptAccess DefaultAccess => defaultAccess;

	private object InvokeMethod(string name, object[] args, object[] bindArgs)
	{
		Type[] array = GetTypeArgs(args).ToArray();
		if (array.Length != 0)
		{
			object[] array2 = args;
			int num = array.Length;
			args = args.Skip(num).ToArray();
			bindArgs = bindArgs.Skip(num).ToArray();
			object result = InvokeMethod(name, array, args, bindArgs);
			for (int i = 0; i < args.Length; i++)
			{
				array2[num + i] = args[i];
			}
			return result;
		}
		return InvokeMethod(name, array, args, bindArgs);
	}

	private object InvokeMethod(string name, Type[] typeArgs, object[] args, object[] bindArgs)
	{
		MethodBindResult methodBindResult = BindMethod(name, typeArgs, args, bindArgs);
		if (methodBindResult is MethodBindFailure && target.Flags.HasFlag(HostTargetFlags.AllowExtensionMethods))
		{
			IEnumerable<object> first = target.Target.ToEnumerable();
			object[] array = first.Concat(args).ToArray();
			object[] first2 = new object[1] { target };
			object[] bindArgs2 = first2.Concat(bindArgs).ToArray();
			Type[] types = ExtensionMethodSummary.Types;
			foreach (Type type in types)
			{
				HostItem hostItem = (HostItem)Wrap(engine, HostType.Wrap(type));
				MethodBindResult methodBindResult2 = hostItem.BindMethod(name, typeArgs, array, bindArgs2);
				if (methodBindResult2 is MethodBindSuccess)
				{
					object result = methodBindResult2.Invoke(hostItem);
					for (int j = 1; j < array.Length; j++)
					{
						args[j - 1] = array[j];
					}
					return result;
				}
			}
		}
		return methodBindResult.Invoke(this);
	}

	private static IEnumerable<Type> GetTypeArgs(object[] args)
	{
		foreach (object obj in args)
		{
			if (!(obj is HostType hostType))
			{
				break;
			}
			Type typeArgNoThrow = hostType.GetTypeArgNoThrow();
			if (typeArgNoThrow == null)
			{
				break;
			}
			yield return typeArgNoThrow;
		}
	}

	private MethodBindResult BindMethod(string name, Type[] typeArgs, object[] args, object[] bindArgs)
	{
		BindingFlags methodBindFlags = GetMethodBindFlags();
		BindSignature signature = new BindSignature(accessContext, methodBindFlags, target, name, typeArgs, bindArgs);
		MethodBindResult methodBindResult;
		if (engine.TryGetCachedBindResult(signature, out var result))
		{
			methodBindResult = MethodBindResult.Create(name, result, target, args);
		}
		else
		{
			methodBindResult = BindMethodInternal(accessContext, methodBindFlags, target, name, typeArgs, args, bindArgs);
			if (!methodBindResult.IsPreferredMethod(this, name))
			{
				if (methodBindResult is MethodBindSuccess)
				{
					methodBindResult = new MethodBindFailure(() => new MissingMemberException(MiscHelpers.FormatInvariant("Object has no method named '{0}' that matches the specified arguments", name)));
				}
				foreach (string altMethodName in GetAltMethodNames(name, methodBindFlags))
				{
					MethodBindResult methodBindResult2 = BindMethodInternal(accessContext, methodBindFlags, target, altMethodName, typeArgs, args, bindArgs);
					if (methodBindResult2.IsUnblockedMethod(this))
					{
						methodBindResult = methodBindResult2;
						break;
					}
				}
			}
			if (methodBindResult is MethodBindFailure && engine.UseReflectionBindFallback)
			{
				MethodBindResult methodBindResult3 = BindMethodUsingReflection(methodBindFlags, target, name, typeArgs, args);
				if (methodBindResult3 is MethodBindSuccess)
				{
					methodBindResult = methodBindResult3;
				}
			}
			engine.CacheBindResult(signature, methodBindResult.RawResult);
		}
		return methodBindResult;
	}

	private static MethodBindResult BindMethodInternal(Type bindContext, BindingFlags bindFlags, HostTarget target, string name, Type[] typeArgs, object[] args, object[] bindArgs)
	{
		BindSignature key = new BindSignature(bindContext, bindFlags, target, name, typeArgs, bindArgs);
		MethodBindResult methodBindResult;
		if (coreBindCache.TryGetValue(key, out var value))
		{
			methodBindResult = MethodBindResult.Create(name, value, target, args);
		}
		else
		{
			methodBindResult = BindMethodCore(bindContext, bindFlags, target, name, typeArgs, args, bindArgs);
			coreBindCache.TryAdd(key, methodBindResult.RawResult);
		}
		return methodBindResult;
	}

	private static MethodBindResult BindMethodCore(Type bindContext, BindingFlags bindFlags, HostTarget target, string name, Type[] typeArgs, object[] args, object[] bindArgs)
	{
		Interlocked.Increment(ref coreBindCount);
		InvokeMemberBinder binder = (InvokeMemberBinder)Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.InvokeSimpleName | CSharpBinderFlags.ResultDiscarded, name, typeArgs, bindContext, CreateArgInfoEnum(target, bindArgs));
		object rawResult = BindMethodRaw(bindFlags, binder, target, bindArgs);
		MethodBindResult methodBindResult = MethodBindResult.Create(name, rawResult, target, args);
		if (methodBindResult is MethodBindFailure && !(target is HostType) && target.Type.IsInterface)
		{
			Type[] interfaces = target.Type.GetInterfaces();
			foreach (Type type in interfaces)
			{
				HostObject hostObject = HostObject.Wrap(target.InvokeTarget, type);
				rawResult = BindMethodRaw(bindFlags, binder, hostObject, bindArgs);
				MethodBindResult methodBindResult2 = MethodBindResult.Create(name, rawResult, target, args);
				if (methodBindResult2 is MethodBindSuccess)
				{
					return methodBindResult2;
				}
			}
			HostObject hostObject2 = HostObject.Wrap(target.InvokeTarget, typeof(object));
			rawResult = BindMethodRaw(bindFlags, binder, hostObject2, bindArgs);
			MethodBindResult methodBindResult3 = MethodBindResult.Create(name, rawResult, target, args);
			if (methodBindResult3 is MethodBindSuccess)
			{
				return methodBindResult3;
			}
		}
		return methodBindResult;
	}

	private static object BindMethodRaw(BindingFlags bindFlags, InvokeMemberBinder binder, HostTarget target, object[] bindArgs)
	{
		Expression expression = DynamicHelpers.Bind(binder, target, bindArgs).Expression;
		if (expression == null)
		{
			return (Func<Exception>)(() => new MissingMemberException(MiscHelpers.FormatInvariant("Object has no method named '{0}'", binder.Name)));
		}
		if (expression.NodeType == ExpressionType.Dynamic)
		{
			try
			{
				MethodInfo method = target.Type.GetMethod(binder.Name, bindFlags);
				return ((object)method) ?? ((object)(Func<Exception>)(() => new MissingMemberException(MiscHelpers.FormatInvariant("Object has no method named '{0}'", binder.Name))));
			}
			catch (AmbiguousMatchException ex)
			{
				AmbiguousMatchException ex2 = ex;
				AmbiguousMatchException exception = ex2;
				return (Func<Exception>)(() => new AmbiguousMatchException(exception.Message));
			}
		}
		return new MethodBindingVisitor(target.InvokeTarget, binder.Name, expression).Result;
	}

	private IEnumerable<string> GetAltMethodNames(string name, BindingFlags bindFlags)
	{
		return GetAltMethodNamesInternal(name, bindFlags).Distinct();
	}

	private IEnumerable<string> GetAltMethodNamesInternal(string name, BindingFlags bindFlags)
	{
		foreach (MethodInfo scriptableMethod in target.Type.GetScriptableMethods(name, bindFlags, accessContext, defaultAccess))
		{
			string shortName = scriptableMethod.GetShortName();
			if (shortName != name)
			{
				yield return shortName;
			}
		}
	}

	private static IEnumerable<CSharpArgumentInfo> CreateArgInfoEnum(HostTarget target, object[] args)
	{
		if (target is HostType)
		{
			yield return CreateStaticTypeArgInfo();
		}
		else
		{
			yield return CreateArgInfo(target.DynamicInvokeTarget);
		}
		foreach (object arg in args)
		{
			yield return CreateArgInfo(arg);
		}
	}

	private static CSharpArgumentInfo CreateArgInfo(object arg)
	{
		CSharpArgumentInfoFlags cSharpArgumentInfoFlags = CSharpArgumentInfoFlags.None;
		if (arg != null)
		{
			cSharpArgumentInfoFlags |= CSharpArgumentInfoFlags.UseCompileTimeType;
			if (arg is int)
			{
				cSharpArgumentInfoFlags |= CSharpArgumentInfoFlags.Constant;
			}
			else if (arg is IOutArg)
			{
				cSharpArgumentInfoFlags |= CSharpArgumentInfoFlags.IsOut;
			}
			else if (arg is IRefArg)
			{
				cSharpArgumentInfoFlags |= CSharpArgumentInfoFlags.IsRef;
			}
		}
		return CSharpArgumentInfo.Create(cSharpArgumentInfoFlags, null);
	}

	private static CSharpArgumentInfo CreateStaticTypeArgInfo()
	{
		return CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.IsStaticType, null);
	}

	private MethodBindResult BindMethodUsingReflection(BindingFlags bindFlags, HostTarget hostTarget, string name, Type[] typeArgs, object[] args)
	{
		MethodInfo[] array = GetReflectionCandidates(bindFlags, hostTarget, name, typeArgs).Distinct().ToArray();
		if (array.Length != 0)
		{
			try
			{
				System.Reflection.Binder defaultBinder = Type.DefaultBinder;
				MethodBase[] match = array;
				object state;
				MethodBase rawResult = defaultBinder.BindToMethod(bindFlags, match, ref args, null, null, null, out state);
				return MethodBindResult.Create(name, rawResult, hostTarget, args);
			}
			catch (MissingMethodException)
			{
			}
			catch (AmbiguousMatchException)
			{
			}
		}
		return new MethodBindFailure(() => new MissingMemberException(MiscHelpers.FormatInvariant("Object has no method named '{0}' that matches the specified arguments", name)));
	}

	private IEnumerable<MethodInfo> GetReflectionCandidates(BindingFlags bindFlags, HostTarget hostTarget, string name, Type[] typeArgs)
	{
		foreach (MethodInfo reflectionCandidate in GetReflectionCandidates(bindFlags, hostTarget.Type, name, typeArgs))
		{
			yield return reflectionCandidate;
		}
		if (hostTarget is HostType || !hostTarget.Type.IsInterface)
		{
			yield break;
		}
		Type[] interfaces = hostTarget.Type.GetInterfaces();
		foreach (Type type in interfaces)
		{
			foreach (MethodInfo reflectionCandidate2 in GetReflectionCandidates(bindFlags, type, name, typeArgs))
			{
				yield return reflectionCandidate2;
			}
		}
		foreach (MethodInfo reflectionCandidate3 in GetReflectionCandidates(bindFlags, typeof(object), name, typeArgs))
		{
			yield return reflectionCandidate3;
		}
	}

	private IEnumerable<MethodInfo> GetReflectionCandidates(BindingFlags bindFlags, Type type, string name, Type[] typeArgs)
	{
		foreach (MethodInfo scriptableMethod in type.GetScriptableMethods(name, bindFlags, accessContext, defaultAccess))
		{
			MethodInfo methodInfo = null;
			if (scriptableMethod.ContainsGenericParameters)
			{
				try
				{
					methodInfo = scriptableMethod.MakeGenericMethod(typeArgs);
				}
				catch (ArgumentException)
				{
					continue;
				}
				catch (NotSupportedException)
				{
					continue;
				}
			}
			else if (typeArgs.Length < 1)
			{
				methodInfo = scriptableMethod;
			}
			if (methodInfo != null && !methodInfo.ContainsGenericParameters)
			{
				yield return methodInfo;
			}
		}
	}

	internal static void ResetCoreBindCache()
	{
		coreBindCache.Clear();
		Interlocked.Exchange(ref coreBindCount, 0L);
	}

	internal static long GetCoreBindCount()
	{
		return Interlocked.Read(ref coreBindCount);
	}

	private HostItem(ScriptEngine engine, HostTarget target, HostItemFlags flags)
	{
		this.engine = engine;
		this.target = target;
		this.flags = flags;
		BindSpecialTarget();
		BindTargetMemberData();
		if (target.Target is IScriptableObject scriptableObject)
		{
			scriptableObject.OnExposedToScriptCode(engine);
		}
	}

	public static object Wrap(ScriptEngine engine, object obj)
	{
		return Wrap(engine, obj, null, HostItemFlags.None);
	}

	public static object Wrap(ScriptEngine engine, object obj, Type type)
	{
		return Wrap(engine, obj, type, HostItemFlags.None);
	}

	public static object Wrap(ScriptEngine engine, object obj, HostItemFlags flags)
	{
		return Wrap(engine, obj, null, flags);
	}

	private static object Wrap(ScriptEngine engine, object obj, Type type, HostItemFlags flags)
	{
		if (obj == null)
		{
			return null;
		}
		if (obj is HostItem hostItem)
		{
			obj = hostItem.Target;
		}
		if (obj is HostTarget hostTarget)
		{
			return BindOrCreate(engine, hostTarget, flags);
		}
		if (type == null)
		{
			type = obj.GetTypeOrTypeInfo();
		}
		if (obj is Enum)
		{
			return BindOrCreate(engine, obj, type, flags);
		}
		TypeCode typeCode = Type.GetTypeCode(type);
		if (typeCode == TypeCode.Object || typeCode == TypeCode.DateTime)
		{
			return BindOrCreate(engine, obj, type, flags);
		}
		return obj;
	}

	public object InvokeMember(string name, BindingFlags invokeFlags, object[] args, object[] bindArgs, CultureInfo culture, bool bypassTunneling)
	{
		bool isCacheable;
		return InvokeMember(name, invokeFlags, args, bindArgs, culture, bypassTunneling, out isCacheable);
	}

	public object InvokeMember(string name, BindingFlags invokeFlags, object[] args, object[] bindArgs, CultureInfo culture, bool bypassTunneling, out bool isCacheable)
	{
		AdjustInvokeFlags(ref invokeFlags);
		isCacheable = false;
		if (target.TryInvokeAuxMember(this, name, invokeFlags, args, bindArgs, out var result))
		{
			if (target is IHostVariable)
			{
				BindSpecialTarget();
			}
			return result;
		}
		if (TargetDynamic != null)
		{
			return InvokeDynamicMember(name, invokeFlags, args);
		}
		if (TargetPropertyBag != null)
		{
			return InvokePropertyBagMember(name, invokeFlags, args, bindArgs);
		}
		if (TargetList != null && int.TryParse(name, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result2))
		{
			return InvokeListElement(result2, invokeFlags, args, bindArgs);
		}
		if (!bypassTunneling)
		{
			int num = ((!invokeFlags.HasFlag(BindingFlags.InvokeMethod)) ? (invokeFlags.HasFlag(BindingFlags.SetField) ? 1 : 0) : ((!invokeFlags.HasFlag(BindingFlags.GetField)) ? (-1) : 0));
			if (args.Length > num && name != SpecialMemberNames.Default)
			{
				bool isCacheable2;
				object hostProperty = GetHostProperty(name, GetCommonBindFlags(), ArrayHelpers.GetEmptyArray<object>(), ArrayHelpers.GetEmptyArray<object>(), culture, includeBoundMembers: false, out isCacheable2);
				if (!(hostProperty is Nonexistent) && engine.MarshalToScript(hostProperty) is HostItem hostItem)
				{
					return hostItem.InvokeMember(SpecialMemberNames.Default, invokeFlags, args, bindArgs, culture, bypassTunneling: true, out isCacheable);
				}
			}
		}
		return InvokeHostMember(name, invokeFlags, args, bindArgs, culture, out isCacheable);
	}

	private static object BindOrCreate(ScriptEngine engine, object target, Type type, HostItemFlags flags)
	{
		return BindOrCreate(engine, HostObject.Wrap(target, type), flags);
	}

	private static object BindOrCreate(ScriptEngine engine, HostTarget target, HostItemFlags flags)
	{
		return engine.GetOrCreateHostItem(target, flags, Create);
	}

	private static HostItem Create(ScriptEngine engine, HostTarget target, HostItemFlags flags)
	{
		if (!TargetSupportsExpandoMembers(target, flags))
		{
			return new HostItem(engine, target, flags);
		}
		return new ExpandoHostItem(engine, target, flags);
	}

	private void BindSpecialTarget()
	{
		if (TargetSupportsSpecialTargets(target))
		{
			IDynamicMetaObjectProvider specialTarget;
			if (BindSpecialTarget(Collateral.TargetDynamic))
			{
				TargetPropertyBag = null;
				TargetList = null;
				TargetDynamicMetaObject = null;
			}
			else if (BindSpecialTarget(Collateral.TargetPropertyBag))
			{
				TargetList = null;
				TargetDynamicMetaObject = null;
			}
			else if (!flags.HasFlag(HostItemFlags.HideDynamicMembers) && BindSpecialTarget<IDynamicMetaObjectProvider>(out specialTarget))
			{
				TargetDynamicMetaObject = specialTarget.GetMetaObject(Expression.Constant(target.InvokeTarget));
				TargetList = null;
			}
			else
			{
				TargetDynamicMetaObject = null;
				BindSpecialTarget(Collateral.TargetList);
			}
		}
	}

	private bool BindSpecialTarget<T>(CollateralObject<HostItem, T> property) where T : class
	{
		if (BindSpecialTarget<T>(out var specialTarget))
		{
			property.Set(this, specialTarget);
			return true;
		}
		property.Clear(this);
		return false;
	}

	private bool BindSpecialTarget<T>(out T specialTarget) where T : class
	{
		if (target.InvokeTarget == null)
		{
			specialTarget = null;
			return false;
		}
		if (typeof(T) == typeof(IDynamic))
		{
			if (target.InvokeTarget is IDispatchEx dispatchEx && dispatchEx.GetType().IsCOMObject)
			{
				specialTarget = (T)(object)new DynamicDispatchExWrapper(dispatchEx);
				return true;
			}
		}
		else if (typeof(T) == typeof(IHostList))
		{
			if (target.Type.IsAssignableToGenericType(typeof(IList<>), out var typeArgs))
			{
				if (typeof(IList).IsAssignableFrom(target.Type))
				{
					specialTarget = new HostList(engine, (IList)target.InvokeTarget, typeArgs[0]) as T;
					return specialTarget != null;
				}
				specialTarget = typeof(HostList<>).MakeGenericType(typeArgs).CreateInstance(engine, target.InvokeTarget) as T;
				return specialTarget != null;
			}
			if (typeof(IList).IsAssignableFrom(target.Type))
			{
				specialTarget = new HostList(engine, (IList)target.InvokeTarget, typeof(object)) as T;
				return specialTarget != null;
			}
			specialTarget = null;
			return false;
		}
		if (typeof(T).IsAssignableFrom(target.Type))
		{
			specialTarget = target.InvokeTarget as T;
			return specialTarget != null;
		}
		specialTarget = null;
		return false;
	}

	private void BindTargetMemberData()
	{
		Type type = ((flags.HasFlag(HostItemFlags.PrivateAccess) || (target.Type.IsAnonymous() && !engine.EnforceAnonymousTypeAccess)) ? target.Type : engine.AccessContext);
		ScriptAccess scriptAccess = engine.DefaultAccess;
		if (targetMemberData == null || accessContext != type || defaultAccess != scriptAccess)
		{
			accessContext = type;
			defaultAccess = scriptAccess;
			if (target is HostMethod)
			{
				targetMemberData = engine.SharedHostMethodMemberData;
			}
			else if (target is HostIndexedProperty)
			{
				targetMemberData = engine.SharedHostIndexedPropertyMemberData;
			}
			else if (target is ScriptMethod)
			{
				targetMemberData = engine.SharedScriptMethodMemberData;
			}
			else if (target is HostObject hostObject && TargetDynamic == null && TargetPropertyBag == null && TargetList == null && TargetDynamicMetaObject == null)
			{
				targetMemberData = engine.GetSharedHostObjectMemberData(hostObject, accessContext, defaultAccess);
			}
			else
			{
				targetMemberData = new HostTargetMemberData();
			}
		}
	}

	private static bool TargetSupportsSpecialTargets(HostTarget target)
	{
		if (!(target is HostObject) && !(target is IHostVariable))
		{
			return target is IByRefArg;
		}
		return true;
	}

	private static bool TargetSupportsExpandoMembers(HostTarget target, HostItemFlags flags)
	{
		if (!TargetSupportsSpecialTargets(target))
		{
			return false;
		}
		if (typeof(IDynamic).IsAssignableFrom(target.Type))
		{
			return true;
		}
		if (target is IHostVariable)
		{
			if (target.Type.IsImport)
			{
				return true;
			}
		}
		else if (target.InvokeTarget is IDispatchEx dispatchEx && dispatchEx.GetType().IsCOMObject)
		{
			return true;
		}
		if (typeof(IPropertyBag).IsAssignableFrom(target.Type))
		{
			return true;
		}
		if (!flags.HasFlag(HostItemFlags.HideDynamicMembers) && typeof(IDynamicMetaObjectProvider).IsAssignableFrom(target.Type))
		{
			return true;
		}
		return false;
	}

	private bool CanAddExpandoMembers()
	{
		if (TargetDynamic == null && (TargetPropertyBag == null || TargetPropertyBag.IsReadOnly))
		{
			return TargetDynamicMetaObject != null;
		}
		return true;
	}

	private string[] GetLocalEventNames()
	{
		if (TypeEventNames == null)
		{
			IEnumerable<EventInfo> scriptableEvents = target.Type.GetScriptableEvents(GetCommonBindFlags(), accessContext, defaultAccess);
			TypeEventNames = scriptableEvents.Select((EventInfo eventInfo) => eventInfo.GetScriptName()).ToArray();
		}
		return TypeEventNames;
	}

	private string[] GetLocalFieldNames()
	{
		if (TypeFieldNames == null)
		{
			IEnumerable<FieldInfo> scriptableFields = target.Type.GetScriptableFields(GetCommonBindFlags(), accessContext, defaultAccess);
			TypeFieldNames = scriptableFields.Select((FieldInfo field) => field.GetScriptName()).ToArray();
		}
		return TypeFieldNames;
	}

	private string[] GetLocalMethodNames()
	{
		if (TypeMethodNames == null)
		{
			IEnumerable<MethodInfo> scriptableMethods = target.Type.GetScriptableMethods(GetMethodBindFlags(), accessContext, defaultAccess);
			TypeMethodNames = scriptableMethods.Select((MethodInfo method) => method.GetScriptName()).ToArray();
		}
		return TypeMethodNames;
	}

	private string[] GetLocalPropertyNames()
	{
		if (TypePropertyNames == null)
		{
			IEnumerable<PropertyInfo> scriptableProperties = target.Type.GetScriptableProperties(GetCommonBindFlags(), accessContext, defaultAccess);
			TypePropertyNames = scriptableProperties.Select((PropertyInfo property) => property.GetScriptName()).ToArray();
		}
		return TypePropertyNames;
	}

	private string[] GetAllFieldNames()
	{
		if (TargetDynamic == null && TargetPropertyBag == null)
		{
			return GetLocalFieldNames().Concat(GetLocalEventNames()).Distinct().ToArray();
		}
		return ArrayHelpers.GetEmptyArray<string>();
	}

	private string[] GetAllMethodNames(out string[] ownMethodNames)
	{
		ownMethodNames = null;
		IEnumerable<string> enumerable = target.GetAuxMethodNames(this, GetMethodBindFlags()).AsEnumerable();
		if (TargetDynamic == null && TargetPropertyBag == null)
		{
			enumerable = enumerable.Concat(GetLocalMethodNames());
			if (target.Flags.HasFlag(HostTargetFlags.AllowExtensionMethods))
			{
				ExtensionMethodSummary extensionMethodSummary = (ExtensionMethodSummary = engine.ExtensionMethodSummary);
				string[] methodNames = extensionMethodSummary.MethodNames;
				if (methodNames.Length != 0)
				{
					ownMethodNames = enumerable.Distinct().ToArray();
					enumerable = ownMethodNames.Concat(methodNames);
				}
			}
		}
		string[] array = enumerable.Distinct().ToArray();
		if (ownMethodNames == null)
		{
			ownMethodNames = array;
		}
		return array;
	}

	private string[] GetAllPropertyNames()
	{
		IEnumerable<string> first = target.GetAuxPropertyNames(this, GetCommonBindFlags()).AsEnumerable();
		if (TargetDynamic != null)
		{
			first = first.Concat(TargetDynamic.GetPropertyNames());
			first = first.Concat(from index in TargetDynamic.GetPropertyIndices()
				select index.ToString(CultureInfo.InvariantCulture));
		}
		else if (TargetPropertyBag != null)
		{
			first = first.Concat(TargetPropertyBag.Keys);
		}
		else
		{
			first = first.Concat(GetLocalPropertyNames());
			if (TargetList != null)
			{
				CachedListCount = TargetList.Count;
				if (CachedListCount > 0)
				{
					first = first.Concat(from index in Enumerable.Range(0, CachedListCount)
						select index.ToString(CultureInfo.InvariantCulture));
				}
			}
			if (TargetDynamicMetaObject != null)
			{
				first = first.Concat(TargetDynamicMetaObject.GetDynamicMemberNames());
			}
		}
		if (ExpandoMemberNames != null)
		{
			first = first.Except(ExpandoMemberNames);
		}
		return first.Distinct().ToArray();
	}

	private void UpdateFieldNames(out bool updated)
	{
		if (AllFieldNames == null)
		{
			AllFieldNames = GetAllFieldNames();
			updated = true;
		}
		else
		{
			updated = false;
		}
	}

	private void UpdateMethodNames(out bool updated)
	{
		if (AllMethodNames == null || (target.Flags.HasFlag(HostTargetFlags.AllowExtensionMethods) && ExtensionMethodSummary != engine.ExtensionMethodSummary))
		{
			AllMethodNames = GetAllMethodNames(out var ownMethodNames);
			OwnMethodNames = ownMethodNames;
			updated = true;
		}
		else
		{
			updated = false;
		}
	}

	private void UpdatePropertyNames(out bool updated)
	{
		if (AllPropertyNames == null || TargetDynamic != null || TargetPropertyBag != null || TargetDynamicMetaObject != null || (TargetList != null && CachedListCount != TargetList.Count))
		{
			AllPropertyNames = GetAllPropertyNames();
			updated = true;
		}
		else
		{
			updated = false;
		}
	}

	private void UpdateEnumerationSettingsToken(out bool updated)
	{
		object enumerationSettingsToken = engine.EnumerationSettingsToken;
		if (EnumerationSettingsToken != enumerationSettingsToken)
		{
			EnumerationSettingsToken = enumerationSettingsToken;
			updated = true;
		}
		else
		{
			updated = false;
		}
	}

	private void AddExpandoMemberName(string name)
	{
		if (ExpandoMemberNames == null)
		{
			ExpandoMemberNames = new HashSet<string>();
		}
		ExpandoMemberNames.Add(name);
	}

	private void RemoveExpandoMemberName(string name)
	{
		if (ExpandoMemberNames != null)
		{
			ExpandoMemberNames.Remove(name);
		}
	}

	private void HostInvoke(Action action)
	{
		BindTargetMemberData();
		engine.HostInvoke(action);
	}

	private T HostInvoke<T>(Func<T> func)
	{
		BindTargetMemberData();
		return engine.HostInvoke(func);
	}

	private BindingFlags GetCommonBindFlags()
	{
		BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic;
		if (target.Flags.HasFlag(HostTargetFlags.AllowStaticMembers))
		{
			bindingFlags |= BindingFlags.Static;
		}
		if (target.Flags.HasFlag(HostTargetFlags.AllowInstanceMembers))
		{
			bindingFlags |= BindingFlags.Instance;
		}
		return bindingFlags;
	}

	private BindingFlags GetMethodBindFlags()
	{
		return GetCommonBindFlags() | BindingFlags.OptionalParamBinding;
	}

	private void AdjustInvokeFlags(ref BindingFlags invokeFlags)
	{
		invokeFlags |= BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.OptionalParamBinding;
		invokeFlags &= ~(BindingFlags.IgnoreCase | BindingFlags.DeclaredOnly | BindingFlags.ExactBinding);
		if (target.Flags.HasFlag(HostTargetFlags.AllowStaticMembers))
		{
			invokeFlags |= BindingFlags.Static;
		}
		else
		{
			invokeFlags &= ~BindingFlags.Static;
		}
		if (target.Flags.HasFlag(HostTargetFlags.AllowInstanceMembers))
		{
			invokeFlags |= BindingFlags.Instance;
		}
		else
		{
			invokeFlags &= ~BindingFlags.Instance;
		}
		if (invokeFlags.HasFlag(BindingFlags.GetProperty))
		{
			invokeFlags |= BindingFlags.GetField;
		}
		if ((invokeFlags & (BindingFlags.SetProperty | BindingFlags.PutDispProperty | BindingFlags.PutRefDispProperty)) != BindingFlags.Default)
		{
			invokeFlags |= BindingFlags.SetField;
		}
	}

	private object InvokeReflectMember(string name, BindingFlags invokeFlags, object[] wrappedArgs, CultureInfo culture, string[] namedParams)
	{
		bool isCacheable;
		return InvokeReflectMember(name, invokeFlags, wrappedArgs, culture, namedParams, out isCacheable);
	}

	private object InvokeReflectMember(string name, BindingFlags invokeFlags, object[] wrappedArgs, CultureInfo culture, string[] namedParams, out bool isCacheable)
	{
		bool resultIsCacheable = false;
		object result = engine.MarshalToScript(HostInvoke(delegate
		{
			object[] array = engine.MarshalToHost(wrappedArgs, preserveHostTargets: false);
			int num = 0;
			if (namedParams != null && namedParams.Length != 0 && namedParams[0] == SpecialParamNames.This)
			{
				array = array.Skip(1).ToArray();
				num = 1;
			}
			object[] bindArgs = array;
			if (array.Length != 0 && (invokeFlags.HasFlag(BindingFlags.InvokeMethod) || invokeFlags.HasFlag(BindingFlags.CreateInstance)))
			{
				bindArgs = engine.MarshalToHost(wrappedArgs, preserveHostTargets: true);
				if (num > 0)
				{
					bindArgs = bindArgs.Skip(num).ToArray();
				}
				object[] array2 = (object[])array.Clone();
				object result2 = InvokeMember(name, invokeFlags, array, bindArgs, culture, bypassTunneling: false, out resultIsCacheable);
				for (int i = 0; i < array.Length; i++)
				{
					object obj = array[i];
					if (obj != array2[i])
					{
						wrappedArgs[num + i] = engine.MarshalToScript(obj);
					}
				}
				return result2;
			}
			return InvokeMember(name, invokeFlags, array, bindArgs, culture, bypassTunneling: false, out resultIsCacheable);
		}));
		isCacheable = resultIsCacheable;
		return result;
	}

	private object InvokeDynamicMember(string name, BindingFlags invokeFlags, object[] args)
	{
		if (invokeFlags.HasFlag(BindingFlags.CreateInstance))
		{
			if (name == SpecialMemberNames.Default)
			{
				return TargetDynamic.Invoke(asConstructor: true, args);
			}
			throw new InvalidOperationException("Invalid constructor invocation");
		}
		if (invokeFlags.HasFlag(BindingFlags.InvokeMethod))
		{
			if (name == SpecialMemberNames.Default)
			{
				try
				{
					return TargetDynamic.Invoke(asConstructor: false, args);
				}
				catch (Exception)
				{
					if (!invokeFlags.HasFlag(BindingFlags.GetField) || args.Length >= 1)
					{
						throw;
					}
					return TargetDynamic;
				}
			}
			try
			{
				return TargetDynamic.InvokeMethod(name, args);
			}
			catch (Exception)
			{
				if (invokeFlags.HasFlag(BindingFlags.GetField) && args.Length < 1)
				{
					return TargetDynamic.GetProperty(name, args);
				}
				throw;
			}
		}
		if (invokeFlags.HasFlag(BindingFlags.GetField))
		{
			return TargetDynamic.GetProperty(name, args);
		}
		if (invokeFlags.HasFlag(BindingFlags.SetField))
		{
			if (args.Length != 0)
			{
				TargetDynamic.SetProperty(name, args);
				return args[args.Length - 1];
			}
			throw new InvalidOperationException("Invalid argument count");
		}
		throw new InvalidOperationException("Invalid member invocation mode");
	}

	private object InvokePropertyBagMember(string name, BindingFlags invokeFlags, object[] args, object[] bindArgs)
	{
		if (invokeFlags.HasFlag(BindingFlags.InvokeMethod))
		{
			object value;
			if (name == SpecialMemberNames.Default)
			{
				if (invokeFlags.HasFlag(BindingFlags.GetField))
				{
					if (args.Length < 1)
					{
						return TargetPropertyBag;
					}
					if (args.Length == 1)
					{
						if (!TargetPropertyBag.TryGetValue(Convert.ToString(args[0]), out value))
						{
							return Nonexistent.Value;
						}
						return value;
					}
				}
				throw new NotSupportedException("Object does not support the requested invocation operation");
			}
			if (name == SpecialMemberNames.NewEnum)
			{
				return HostObject.Wrap(TargetPropertyBag.GetEnumerator(), typeof(IEnumerator));
			}
			if (!TargetPropertyBag.TryGetValue(name, out value))
			{
				throw new MissingMemberException(MiscHelpers.FormatInvariant("Object has no property named '{0}'", name));
			}
			if (InvokeHelpers.TryInvokeObject(this, value, invokeFlags, args, bindArgs, tryDynamic: true, out var result))
			{
				return result;
			}
			if (invokeFlags.HasFlag(BindingFlags.GetField))
			{
				if (args.Length < 1)
				{
					return value;
				}
				if (args.Length == 1)
				{
					if (value == null)
					{
						throw new InvalidOperationException("Cannot invoke a null property value");
					}
					return ((HostItem)Wrap(engine, value)).InvokeMember(SpecialMemberNames.Default, invokeFlags, args, bindArgs, null, bypassTunneling: true);
				}
			}
			throw new NotSupportedException("Object does not support the requested invocation operation");
		}
		if (invokeFlags.HasFlag(BindingFlags.GetField))
		{
			if (name == SpecialMemberNames.Default)
			{
				if (args.Length == 1)
				{
					return TargetPropertyBag[Convert.ToString(args[0])];
				}
				throw new InvalidOperationException("Invalid argument count");
			}
			if (args.Length < 1)
			{
				if (!TargetPropertyBag.TryGetValue(name, out var value2))
				{
					return Nonexistent.Value;
				}
				return value2;
			}
			throw new InvalidOperationException("Invalid argument count");
		}
		if (invokeFlags.HasFlag(BindingFlags.SetField))
		{
			if (name == SpecialMemberNames.Default)
			{
				if (args.Length == 2)
				{
					return TargetPropertyBag[Convert.ToString(args[0])] = args[1];
				}
				throw new InvalidOperationException("Invalid argument count");
			}
			if (args.Length == 1)
			{
				return TargetPropertyBag[name] = args[0];
			}
			if (args.Length == 2)
			{
				if (TargetPropertyBag.TryGetValue(name, out var value3))
				{
					if (value3 == null)
					{
						throw new InvalidOperationException("Cannot invoke a null property value");
					}
					return ((HostItem)Wrap(engine, value3)).InvokeMember(SpecialMemberNames.Default, invokeFlags, args, bindArgs, null, bypassTunneling: true);
				}
				throw new MissingMemberException(MiscHelpers.FormatInvariant("Object has no property named '{0}'", name));
			}
			throw new InvalidOperationException("Invalid argument count");
		}
		throw new InvalidOperationException("Invalid member invocation mode");
	}

	private object InvokeListElement(int index, BindingFlags invokeFlags, object[] args, object[] bindArgs)
	{
		if (invokeFlags.HasFlag(BindingFlags.InvokeMethod))
		{
			if (InvokeHelpers.TryInvokeObject(this, TargetList[index], invokeFlags, args, bindArgs, tryDynamic: true, out var result))
			{
				return result;
			}
			if (invokeFlags.HasFlag(BindingFlags.GetField) && args.Length < 1)
			{
				return TargetList[index];
			}
			throw new NotSupportedException("Object does not support the requested invocation operation");
		}
		if (invokeFlags.HasFlag(BindingFlags.GetField))
		{
			if (args.Length < 1)
			{
				return TargetList[index];
			}
			throw new InvalidOperationException("Invalid argument count");
		}
		if (invokeFlags.HasFlag(BindingFlags.SetField))
		{
			if (args.Length == 1)
			{
				return TargetList[index] = args[0];
			}
			throw new InvalidOperationException("Invalid argument count");
		}
		throw new InvalidOperationException("Invalid member invocation mode");
	}

	private object InvokeHostMember(string name, BindingFlags invokeFlags, object[] args, object[] bindArgs, CultureInfo culture, out bool isCacheable)
	{
		isCacheable = false;
		object result;
		if (invokeFlags.HasFlag(BindingFlags.CreateInstance))
		{
			if (name == SpecialMemberNames.Default)
			{
				if (target is HostType hostType)
				{
					HostType[] array = GetTypeArgs(args).Select(HostType.Wrap).ToArray();
					if (array.Length != 0)
					{
						object[] array2 = array;
						object[] args2 = array2;
						array2 = array;
						if (hostType.TryInvoke(this, BindingFlags.InvokeMethod, args2, array2, out result) && result is HostType hostType2)
						{
							args = args.Skip(array.Length).ToArray();
							Type specificType = hostType2.GetSpecificType();
							if (typeof(Delegate).IsAssignableFrom(specificType))
							{
								if (args.Length != 1)
								{
									throw new InvalidOperationException("Invalid constructor invocation");
								}
								return DelegateFactory.CreateDelegate(engine, args[0], specificType);
							}
							return specificType.CreateInstance(accessContext, defaultAccess, args);
						}
						throw new InvalidOperationException("Invalid constructor invocation");
					}
					Type specificType2 = hostType.GetSpecificType();
					if (typeof(Delegate).IsAssignableFrom(specificType2))
					{
						if (args.Length != 1)
						{
							throw new InvalidOperationException("Invalid constructor invocation");
						}
						return DelegateFactory.CreateDelegate(engine, args[0], specificType2);
					}
					return specificType2.CreateInstance(accessContext, defaultAccess, args);
				}
				if (TargetDynamicMetaObject != null && TargetDynamicMetaObject.TryCreateInstance(args, out result))
				{
					return result;
				}
			}
			throw new InvalidOperationException("Invalid constructor invocation");
		}
		if (invokeFlags.HasFlag(BindingFlags.InvokeMethod))
		{
			if (name == SpecialMemberNames.Default)
			{
				if (InvokeHelpers.TryInvokeObject(this, target, invokeFlags, args, bindArgs, TargetDynamicMetaObject != null, out result))
				{
					return result;
				}
				if (invokeFlags.HasFlag(BindingFlags.GetField))
				{
					result = GetHostProperty(name, invokeFlags, args, bindArgs, culture, includeBoundMembers: true, out isCacheable);
					if (!(result is Nonexistent))
					{
						return result;
					}
					if (args.Length < 1)
					{
						return target;
					}
					if (TargetDynamicMetaObject != null)
					{
						return result;
					}
				}
				throw new NotSupportedException("Object does not support the requested invocation operation");
			}
			if (name == SpecialMemberNames.NewEnum)
			{
				if ((target is HostObject || target is IHostVariable || target is IByRefArg) && BindSpecialTarget<IEnumerable>(out var _))
				{
					object obj = Wrap(engine, EnumerableHelpers.HostType, HostItemFlags.PrivateAccess);
					try
					{
						return ((IDynamic)obj).InvokeMethod("GetEnumerator", this);
					}
					catch (MissingMemberException)
					{
					}
				}
				throw new NotSupportedException("Object is not enumerable");
			}
			if (TargetDynamicMetaObject != null && TargetDynamicMetaObject.GetDynamicMemberNames().Contains(name) && TargetDynamicMetaObject.TryInvokeMember(this, name, invokeFlags, args, out result))
			{
				return result;
			}
			if (ThisReflect.GetMethods(GetMethodBindFlags()).Any((MethodInfo method) => method.Name == name))
			{
				try
				{
					return InvokeMethod(name, args, bindArgs);
				}
				catch (TargetInvocationException)
				{
					throw;
				}
				catch (Exception)
				{
					try
					{
						if (invokeFlags.HasFlag(BindingFlags.GetField))
						{
							return GetHostProperty(name, invokeFlags, args, bindArgs, culture, includeBoundMembers: true, out isCacheable);
						}
					}
					catch (TargetInvocationException)
					{
						throw;
					}
					catch (Exception)
					{
					}
					throw;
				}
			}
			if (invokeFlags.HasFlag(BindingFlags.GetField))
			{
				return GetHostProperty(name, invokeFlags, args, bindArgs, culture, includeBoundMembers: true, out isCacheable);
			}
			throw new MissingMemberException(MiscHelpers.FormatInvariant("Object has no suitable method named '{0}'", name));
		}
		if (invokeFlags.HasFlag(BindingFlags.GetField))
		{
			return GetHostProperty(name, invokeFlags, args, bindArgs, culture, includeBoundMembers: true, out isCacheable);
		}
		if (invokeFlags.HasFlag(BindingFlags.SetField))
		{
			return SetHostProperty(name, invokeFlags, args, bindArgs, culture);
		}
		throw new InvalidOperationException("Invalid member invocation mode");
	}

	private object GetHostProperty(string name, BindingFlags invokeFlags, object[] args, object[] bindArgs, CultureInfo culture, bool includeBoundMembers, out bool isCacheable)
	{
		isCacheable = false;
		if (name == SpecialMemberNames.Default)
		{
			PropertyInfo scriptableDefaultProperty = target.Type.GetScriptableDefaultProperty(invokeFlags, bindArgs, accessContext, defaultAccess);
			if (scriptableDefaultProperty != null)
			{
				return GetHostProperty(scriptableDefaultProperty, invokeFlags, args, culture);
			}
			if (TargetDynamicMetaObject != null && TargetDynamicMetaObject.TryGetIndex(args, out var result))
			{
				return result;
			}
			return Nonexistent.Value;
		}
		if (TargetDynamicMetaObject != null && args.Length < 1)
		{
			object result2;
			int result3;
			if (TargetDynamicMetaObject.GetDynamicMemberNames().Contains(name))
			{
				if (TargetDynamicMetaObject.TryGetMember(name, out result2))
				{
					return result2;
				}
				if (int.TryParse(name, NumberStyles.Integer, CultureInfo.InvariantCulture, out result3) && TargetDynamicMetaObject.TryGetIndex(new object[1] { result3 }, out result2))
				{
					return result2;
				}
				if (TargetDynamicMetaObject.TryGetIndex(new object[1] { name }, out result2))
				{
					return result2;
				}
				if (includeBoundMembers)
				{
					if (HostMethodMap == null)
					{
						HostMethodMap = new Dictionary<string, HostMethod>();
					}
					if (!HostMethodMap.TryGetValue(name, out var value))
					{
						value = new HostMethod(this, name);
						HostMethodMap.Add(name, value);
					}
					return value;
				}
				return Nonexistent.Value;
			}
			if (int.TryParse(name, NumberStyles.Integer, CultureInfo.InvariantCulture, out result3) && TargetDynamicMetaObject.TryGetIndex(new object[1] { result3 }, out result2))
			{
				return result2;
			}
			if (TargetDynamicMetaObject.TryGetIndex(new object[1] { name }, out result2))
			{
				return result2;
			}
		}
		PropertyInfo scriptableProperty = target.Type.GetScriptableProperty(name, invokeFlags, bindArgs, accessContext, defaultAccess);
		if (scriptableProperty != null)
		{
			return GetHostProperty(scriptableProperty, invokeFlags, args, culture);
		}
		if (args.Length != 0)
		{
			throw new MissingMemberException(MiscHelpers.FormatInvariant("Object has no suitable property named '{0}'", name));
		}
		EventInfo scriptableEvent = target.Type.GetScriptableEvent(name, invokeFlags, accessContext, defaultAccess);
		if (scriptableEvent != null)
		{
			Type type = typeof(EventSource<>).MakeSpecificType(scriptableEvent.EventHandlerType);
			isCacheable = TargetDynamicMetaObject == null;
			return type.CreateInstance(BindingFlags.NonPublic, engine, target.InvokeTarget, scriptableEvent);
		}
		FieldInfo scriptableField = target.Type.GetScriptableField(name, invokeFlags, accessContext, defaultAccess);
		if (scriptableField != null)
		{
			object value2 = scriptableField.GetValue(target.InvokeTarget);
			isCacheable = TargetDynamicMetaObject == null && (scriptableField.IsLiteral || scriptableField.IsInitOnly);
			return engine.PrepareResult(value2, scriptableField.FieldType, scriptableField.GetScriptMemberFlags(), isListIndexResult: false);
		}
		if (includeBoundMembers)
		{
			if (target.Type.GetScriptableProperties(name, invokeFlags, accessContext, defaultAccess).Any())
			{
				if (HostIndexedPropertyMap == null)
				{
					HostIndexedPropertyMap = new Dictionary<string, HostIndexedProperty>();
				}
				if (!HostIndexedPropertyMap.TryGetValue(name, out var value3))
				{
					value3 = new HostIndexedProperty(this, name);
					HostIndexedPropertyMap.Add(name, value3);
				}
				return value3;
			}
			MethodInfo methodInfo = ThisReflect.GetMethods(GetMethodBindFlags()).FirstOrDefault((MethodInfo testMethod) => testMethod.Name == name);
			if (methodInfo != null)
			{
				if (HostMethodMap == null)
				{
					HostMethodMap = new Dictionary<string, HostMethod>();
				}
				if (!HostMethodMap.TryGetValue(name, out var value4))
				{
					value4 = new HostMethod(this, name);
					HostMethodMap.Add(name, value4);
				}
				isCacheable = TargetDynamicMetaObject == null;
				return value4;
			}
		}
		return Nonexistent.Value;
	}

	private object GetHostProperty(PropertyInfo property, BindingFlags invokeFlags, object[] args, CultureInfo culture)
	{
		if (reflectionProperties.Contains(property, MemberComparer<PropertyInfo>.Instance))
		{
			engine.CheckReflection();
		}
		MethodInfo getMethod = property.GetMethod;
		if (getMethod == null || !getMethod.IsAccessible(accessContext) || getMethod.IsBlockedFromScript(defaultAccess, chain: false))
		{
			throw new UnauthorizedAccessException("Property get method is unavailable or inaccessible");
		}
		object value = property.GetValue(target.InvokeTarget, invokeFlags, Type.DefaultBinder, args, culture);
		return engine.PrepareResult(value, property.PropertyType, property.GetScriptMemberFlags(), isListIndexResult: false);
	}

	private object SetHostProperty(string name, BindingFlags invokeFlags, object[] args, object[] bindArgs, CultureInfo culture)
	{
		if (name == SpecialMemberNames.Default)
		{
			if (args.Length < 2)
			{
				throw new InvalidOperationException("Invalid argument count");
			}
			PropertyInfo scriptableDefaultProperty = target.Type.GetScriptableDefaultProperty(invokeFlags, bindArgs.Take(bindArgs.Length - 1).ToArray(), accessContext, defaultAccess);
			if (scriptableDefaultProperty != null)
			{
				return SetHostProperty(scriptableDefaultProperty, invokeFlags, args, culture);
			}
			if (TargetDynamicMetaObject != null && TargetDynamicMetaObject.TrySetIndex(args.Take(args.Length - 1).ToArray(), args[args.Length - 1], out var result))
			{
				return result;
			}
			if (InvokeHelpers.TryInvokeObject(this, target, invokeFlags, args, bindArgs, tryDynamic: false, out result))
			{
				return result;
			}
			throw new InvalidOperationException("Invalid property assignment");
		}
		if (TargetDynamicMetaObject != null && args.Length == 1)
		{
			if (TargetDynamicMetaObject.TrySetMember(name, args[0], out var result2))
			{
				return result2;
			}
			if (int.TryParse(name, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result3) && TargetDynamicMetaObject.TrySetIndex(new object[1] { result3 }, args[0], out result2))
			{
				return result2;
			}
			if (TargetDynamicMetaObject.TrySetIndex(new object[1] { name }, args[0], out result2))
			{
				return result2;
			}
		}
		if (args.Length < 1)
		{
			throw new InvalidOperationException("Invalid argument count");
		}
		PropertyInfo scriptableProperty = target.Type.GetScriptableProperty(name, invokeFlags, bindArgs.Take(bindArgs.Length - 1).ToArray(), accessContext, defaultAccess);
		if (scriptableProperty != null)
		{
			return SetHostProperty(scriptableProperty, invokeFlags, args, culture);
		}
		FieldInfo scriptableField = target.Type.GetScriptableField(name, invokeFlags, accessContext, defaultAccess);
		if (scriptableField != null)
		{
			if (args.Length == 1)
			{
				if (scriptableField.IsLiteral || scriptableField.IsInitOnly || scriptableField.IsReadOnlyForScript(defaultAccess))
				{
					throw new UnauthorizedAccessException("Field is read-only");
				}
				object value = args[0];
				if (scriptableField.FieldType.IsAssignableFrom(ref value))
				{
					scriptableField.SetValue(target.InvokeTarget, value);
					return value;
				}
				throw new ArgumentException("Invalid field assignment");
			}
			throw new InvalidOperationException("Invalid argument count");
		}
		throw new MissingMemberException(MiscHelpers.FormatInvariant("Object has no suitable property or field named '{0}'", name));
	}

	private object SetHostProperty(PropertyInfo property, BindingFlags invokeFlags, object[] args, CultureInfo culture)
	{
		if (property.IsReadOnlyForScript(defaultAccess))
		{
			throw new UnauthorizedAccessException("Property is read-only");
		}
		MethodInfo setMethod = property.SetMethod;
		if (setMethod == null || !setMethod.IsAccessible(accessContext) || setMethod.IsBlockedFromScript(defaultAccess, chain: false))
		{
			throw new UnauthorizedAccessException("Property set method is unavailable or inaccessible");
		}
		object value = args[args.Length - 1];
		if (property.PropertyType.IsAssignableFrom(ref value))
		{
			property.SetValue(target.InvokeTarget, value, invokeFlags, Type.DefaultBinder, args.Take(args.Length - 1).ToArray(), culture);
			return value;
		}
		ParameterInfo[] parameters = setMethod.GetParameters();
		if (parameters.Length == args.Length && parameters[args.Length - 1].ParameterType.IsAssignableFrom(ref value))
		{
			property.SetValue(target.InvokeTarget, value, invokeFlags, Type.DefaultBinder, args.Take(args.Length - 1).ToArray(), culture);
			return value;
		}
		throw new ArgumentException("Invalid property assignment");
	}

	public override string ToString()
	{
		return MiscHelpers.FormatInvariant("[{0}]", target);
	}

	public override bool TryCreateInstance(CreateInstanceBinder binder, object[] args, out object result)
	{
		result = ThisDynamic.Invoke(asConstructor: true, args).ToDynamicResult(engine);
		return true;
	}

	public override bool TryGetMember(GetMemberBinder binder, out object result)
	{
		result = ThisDynamic.GetProperty(binder.Name, ArrayHelpers.GetEmptyArray<object>()).ToDynamicResult(engine);
		return true;
	}

	public override bool TrySetMember(SetMemberBinder binder, object value)
	{
		ThisDynamic.SetProperty(binder.Name, value);
		return true;
	}

	public override bool TryGetIndex(GetIndexBinder binder, object[] indices, out object result)
	{
		if (indices.Length == 1)
		{
			if (MiscHelpers.TryGetNumericIndex(indices[0], out int index))
			{
				result = ThisDynamic.GetProperty(index).ToDynamicResult(engine);
				return true;
			}
			result = ThisDynamic.GetProperty(indices[0].ToString(), ArrayHelpers.GetEmptyArray<object>()).ToDynamicResult(engine);
			return true;
		}
		if (indices.Length > 1)
		{
			result = ThisDynamic.GetProperty(SpecialMemberNames.Default, indices).ToDynamicResult(engine);
			return true;
		}
		throw new InvalidOperationException("Invalid argument or index count");
	}

	public override bool TrySetIndex(SetIndexBinder binder, object[] indices, object value)
	{
		if (indices.Length == 1)
		{
			if (MiscHelpers.TryGetNumericIndex(indices[0], out int index))
			{
				ThisDynamic.SetProperty(index, value);
				return true;
			}
			ThisDynamic.SetProperty(indices[0].ToString(), value);
			return true;
		}
		if (indices.Length > 1)
		{
			ThisDynamic.SetProperty(SpecialMemberNames.Default, indices.Concat(value.ToEnumerable()).ToArray());
		}
		throw new InvalidOperationException("Invalid argument or index count");
	}

	public override bool TryInvoke(InvokeBinder binder, object[] args, out object result)
	{
		result = ThisDynamic.Invoke(asConstructor: false, args).ToDynamicResult(engine);
		return true;
	}

	public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
	{
		result = ThisDynamic.InvokeMethod(binder.Name, args).ToDynamicResult(engine);
		return true;
	}

	public override bool TryConvert(ConvertBinder binder, out object result)
	{
		if ((target is HostObject || target is IHostVariable || target is IByRefArg) && binder.Type.IsAssignableFrom(target.Type))
		{
			result = Convert.ChangeType(target.InvokeTarget, binder.Type);
			return true;
		}
		result = null;
		return false;
	}

	FieldInfo IReflect.GetField(string name, BindingFlags bindFlags)
	{
		FieldInfo[] array = (from field in ThisReflect.GetFields(bindFlags)
			where field.Name == name
			select field).ToArray();
		if (array.Length < 1)
		{
			return null;
		}
		if (array.Length > 1)
		{
			throw new AmbiguousMatchException(MiscHelpers.FormatInvariant("Object has multiple fields named '{0}'", name));
		}
		return array[0];
	}

	FieldInfo[] IReflect.GetFields(BindingFlags bindFlags)
	{
		return HostInvoke(delegate
		{
			UpdateFieldNames(out var updated);
			if (updated || AllFields == null)
			{
				AllFields = MemberMap.GetFields(AllFieldNames);
			}
			return AllFields;
		});
	}

	MemberInfo[] IReflect.GetMember(string name, BindingFlags bindFlags)
	{
		return (from member in ThisReflect.GetMembers(bindFlags)
			where member.Name == name
			select member).ToArray();
	}

	MemberInfo[] IReflect.GetMembers(BindingFlags bindFlags)
	{
		return ThisReflect.GetFields(bindFlags).Cast<MemberInfo>().Concat(ThisReflect.GetMethods(bindFlags))
			.Concat(ThisReflect.GetProperties(bindFlags))
			.ToArray();
	}

	MethodInfo IReflect.GetMethod(string name, BindingFlags bindFlags)
	{
		MethodInfo[] array = (from method in ThisReflect.GetMethods(bindFlags)
			where method.Name == name
			select method).ToArray();
		if (array.Length < 1)
		{
			return null;
		}
		if (array.Length > 1)
		{
			throw new AmbiguousMatchException(MiscHelpers.FormatInvariant("Object has multiple methods named '{0}'", name));
		}
		return array[0];
	}

	MethodInfo IReflect.GetMethod(string name, BindingFlags bindFlags, System.Reflection.Binder binder, Type[] types, ParameterModifier[] modifiers)
	{
		throw new NotImplementedException();
	}

	MethodInfo[] IReflect.GetMethods(BindingFlags bindFlags)
	{
		return HostInvoke(delegate
		{
			UpdateMethodNames(out var updated);
			if (updated || AllMethods == null)
			{
				AllMethods = MemberMap.GetMethods(AllMethodNames);
			}
			return AllMethods;
		});
	}

	PropertyInfo[] IReflect.GetProperties(BindingFlags bindFlags)
	{
		return HostInvoke(delegate
		{
			UpdatePropertyNames(out var updated);
			if (updated || AllProperties == null)
			{
				AllProperties = MemberMap.GetProperties(AllPropertyNames);
			}
			return AllProperties;
		});
	}

	PropertyInfo IReflect.GetProperty(string name, BindingFlags bindFlags, System.Reflection.Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
	{
		throw new NotImplementedException();
	}

	PropertyInfo IReflect.GetProperty(string name, BindingFlags bindFlags)
	{
		PropertyInfo[] array = (from property in ThisReflect.GetProperties(bindFlags)
			where property.Name == name
			select property).ToArray();
		if (array.Length < 1)
		{
			return null;
		}
		if (array.Length > 1)
		{
			throw new AmbiguousMatchException(MiscHelpers.FormatInvariant("Object has multiple properties named '{0}'", name));
		}
		return array[0];
	}

	object IReflect.InvokeMember(string name, BindingFlags invokeFlags, System.Reflection.Binder binder, object invokeTarget, object[] wrappedArgs, ParameterModifier[] modifiers, CultureInfo culture, string[] namedParams)
	{
		return InvokeReflectMember(name, invokeFlags, wrappedArgs, culture, namedParams);
	}

	object IDynamic.GetProperty(string name, params object[] args)
	{
		return InvokeReflectMember(name, BindingFlags.GetProperty, args, CultureInfo.InvariantCulture, null);
	}

	object IDynamic.GetProperty(string name, out bool isCacheable, params object[] args)
	{
		return InvokeReflectMember(name, BindingFlags.GetProperty, args, CultureInfo.InvariantCulture, null, out isCacheable);
	}

	void IDynamic.SetProperty(string name, object[] args)
	{
		ThisReflect.InvokeMember(name, BindingFlags.SetProperty, null, ThisReflect, args, null, CultureInfo.InvariantCulture, null);
	}

	bool IDynamic.DeleteProperty(string name)
	{
		return HostInvoke(delegate
		{
			if (TargetDynamic != null)
			{
				return TargetDynamic.DeleteProperty(name);
			}
			if (TargetPropertyBag != null)
			{
				return TargetPropertyBag.Remove(name);
			}
			if (TargetDynamicMetaObject != null)
			{
				if (TargetDynamicMetaObject.TryDeleteMember(name, out var result) && result)
				{
					return true;
				}
				if (TargetDynamicMetaObject.TryDeleteIndex(new object[1] { name }, out result))
				{
					return result;
				}
				throw new InvalidOperationException("Invalid dynamic member deletion");
			}
			throw new NotSupportedException("Object does not support dynamic members");
		});
	}

	string[] IDynamic.GetPropertyNames()
	{
		return HostInvoke(delegate
		{
			UpdateFieldNames(out var updated);
			UpdateMethodNames(out var updated2);
			UpdatePropertyNames(out var updated3);
			UpdateEnumerationSettingsToken(out var updated4);
			if (updated || updated2 || updated3 || updated4 || AllMemberNames == null)
			{
				AllMemberNames = AllFieldNames.Concat(EnumeratedMethodNames).Concat(AllPropertyNames).ExcludeIndices()
					.Distinct()
					.ToArray();
			}
			return AllMemberNames;
		});
	}

	object IDynamic.GetProperty(int index)
	{
		return ThisDynamic.GetProperty(index.ToString(CultureInfo.InvariantCulture), ArrayHelpers.GetEmptyArray<object>());
	}

	void IDynamic.SetProperty(int index, object value)
	{
		ThisDynamic.SetProperty(index.ToString(CultureInfo.InvariantCulture), value);
	}

	bool IDynamic.DeleteProperty(int index)
	{
		return HostInvoke(delegate
		{
			if (TargetDynamic != null)
			{
				return TargetDynamic.DeleteProperty(index);
			}
			if (TargetPropertyBag != null)
			{
				return TargetPropertyBag.Remove(index.ToString(CultureInfo.InvariantCulture));
			}
			if (TargetDynamicMetaObject != null)
			{
				if (TargetDynamicMetaObject.TryDeleteMember(index.ToString(CultureInfo.InvariantCulture), out var result) && result)
				{
					return true;
				}
				if (TargetDynamicMetaObject.TryDeleteIndex(new object[1] { index }, out result))
				{
					return result;
				}
				throw new InvalidOperationException("Invalid dynamic member deletion");
			}
			return false;
		});
	}

	int[] IDynamic.GetPropertyIndices()
	{
		return HostInvoke(delegate
		{
			UpdatePropertyNames(out var updated);
			if (updated || PropertyIndices == null)
			{
				PropertyIndices = AllPropertyNames.GetIndices().Distinct().ToArray();
			}
			return PropertyIndices;
		});
	}

	object IDynamic.Invoke(bool asConstructor, params object[] args)
	{
		return ThisReflect.InvokeMember(SpecialMemberNames.Default, asConstructor ? BindingFlags.CreateInstance : ((args.Length < 1) ? BindingFlags.InvokeMethod : (BindingFlags.InvokeMethod | BindingFlags.GetProperty)), null, ThisReflect, args, null, CultureInfo.InvariantCulture, null);
	}

	object IDynamic.InvokeMethod(string name, params object[] args)
	{
		return ThisReflect.InvokeMember(name, BindingFlags.InvokeMethod, null, ThisReflect, args, null, CultureInfo.InvariantCulture, null);
	}

	int IEnumVARIANT.Next(int count, object[] elements, IntPtr pCountFetched)
	{
		return HostInvoke(delegate
		{
			int num = 0;
			if (elements != null)
			{
				int num2 = Math.Min(count, elements.Length);
				while (num < num2 && TargetEnumerator.MoveNext())
				{
					elements[num++] = ThisDynamic.GetProperty("Current", ArrayHelpers.GetEmptyArray<object>());
				}
			}
			if (pCountFetched != IntPtr.Zero)
			{
				Marshal.WriteInt32(pCountFetched, num);
			}
			return (num != count) ? 1 : 0;
		});
	}

	int IEnumVARIANT.Skip(int count)
	{
		return HostInvoke(delegate
		{
			int i;
			for (i = 0; i < count; i++)
			{
				if (!TargetEnumerator.MoveNext())
				{
					break;
				}
			}
			return (i != count) ? 1 : 0;
		});
	}

	int IEnumVARIANT.Reset()
	{
		return HostInvoke(delegate
		{
			TargetEnumerator.Reset();
			return 0;
		});
	}

	IEnumVARIANT IEnumVARIANT.Clone()
	{
		throw new NotImplementedException();
	}

	public CustomQueryInterfaceResult GetInterface(ref Guid iid, out IntPtr pInterface)
	{
		if (iid == typeof(IEnumVARIANT).GUID)
		{
			if (target is HostObject || target is IHostVariable || target is IByRefArg)
			{
				pInterface = IntPtr.Zero;
				if (!BindSpecialTarget(Collateral.TargetEnumerator))
				{
					return CustomQueryInterfaceResult.Failed;
				}
				return CustomQueryInterfaceResult.NotHandled;
			}
		}
		else if (iid == typeof(IDispatchEx).GUID && EnableVTablePatching && !bypassVTablePatching)
		{
			IntPtr iUnknownForObject = Marshal.GetIUnknownForObject(this);
			bypassVTablePatching = true;
			pInterface = RawCOMHelpers.QueryInterfaceNoThrow<IDispatchEx>(iUnknownForObject);
			bypassVTablePatching = false;
			Marshal.Release(iUnknownForObject);
			if (pInterface != IntPtr.Zero)
			{
				VTablePatcher.GetInstance().PatchDispatchEx(pInterface);
				return CustomQueryInterfaceResult.Handled;
			}
		}
		pInterface = IntPtr.Zero;
		return CustomQueryInterfaceResult.NotHandled;
	}

	public object Unwrap()
	{
		return target.Target;
	}
}
