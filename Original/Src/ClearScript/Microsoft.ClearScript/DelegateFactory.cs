using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.ClearScript.Util;

namespace Microsoft.ClearScript;

internal static class DelegateFactory
{
	private abstract class DelegateShim
	{
		public abstract Delegate Delegate { get; }

		protected ScriptEngine Engine { get; private set; }

		protected DelegateShim(ScriptEngine engine)
		{
			Engine = engine;
		}

		protected static bool GetAllByValue(params Type[] types)
		{
			return !types.Any((Type type) => typeof(IByRefArg).IsAssignableFrom(type));
		}

		protected static object GetArgValue(object arg)
		{
			if (!(arg is IByRefArg byRefArg))
			{
				return arg;
			}
			return byRefArg.Value;
		}

		protected static void SetArgValue(object arg, object value)
		{
			if (arg is IByRefArg byRefArg)
			{
				byRefArg.Value = value;
			}
		}

		protected static object GetCompatibleTarget(Type delegateType, object target)
		{
			if (target is Delegate obj && obj.GetType() != delegateType)
			{
				return Delegate.CreateDelegate(delegateType, obj.Target, obj.Method);
			}
			return target;
		}
	}

	private abstract class ProcShim : DelegateShim
	{
		private readonly Action<Action> invoker;

		protected ProcShim(ScriptEngine engine)
			: base(engine)
		{
			if (engine == null)
			{
				invoker = delegate(Action action)
				{
					action();
				};
			}
			else
			{
				invoker = engine.SyncInvoke;
			}
		}

		protected void Invoke(Action action)
		{
			invoker(action);
		}
	}

	private abstract class FuncShim<TResult> : DelegateShim
	{
		private readonly Func<Func<TResult>, TResult> invoker;

		protected FuncShim(ScriptEngine engine)
			: base(engine)
		{
			if (engine == null)
			{
				invoker = (Func<TResult> func) => func();
			}
			else
			{
				invoker = engine.SyncInvoke;
			}
		}

		protected TResult Invoke(Func<TResult> func)
		{
			return invoker(func);
		}
	}

	[ExcludeFromCodeCoverage]
	private class ProcShim<TDelegate> : ProcShim
	{
		private static readonly MethodInfo method = typeof(ProcShim<TDelegate>).GetMethod("InvokeTarget");

		private static readonly bool allByValue = true;

		private readonly object target;

		private readonly Delegate del;

		public override Delegate Delegate => del;

		public ProcShim(ScriptEngine engine, object target)
			: base(engine)
		{
			this.target = DelegateShim.GetCompatibleTarget(typeof(TDelegate), target);
			del = Delegate.CreateDelegate(typeof(TDelegate), this, method);
		}

		public void InvokeTarget()
		{
			if (allByValue || base.Engine.EnableAutoHostVariables)
			{
				Invoke(delegate
				{
					((dynamic)target)();
				});
			}
			else
			{
				Invoke(delegate
				{
					((dynamic)target)();
				});
			}
		}
	}

	[ExcludeFromCodeCoverage]
	private class ProcShim<T1, TDelegate> : ProcShim
	{
		private static readonly MethodInfo method = typeof(ProcShim<T1, TDelegate>).GetMethod("InvokeTarget");

		private static readonly bool allByValue = DelegateShim.GetAllByValue(typeof(T1));

		private readonly object target;

		private readonly Delegate del;

		public override Delegate Delegate => del;

		public ProcShim(ScriptEngine engine, object target)
			: base(engine)
		{
			this.target = DelegateShim.GetCompatibleTarget(typeof(TDelegate), target);
			del = Delegate.CreateDelegate(typeof(TDelegate), this, method);
		}

		public void InvokeTarget(T1 a1)
		{
			if (allByValue || base.Engine.EnableAutoHostVariables)
			{
				Invoke(delegate
				{
					((dynamic)target)(a1);
				});
				return;
			}
			object v1 = DelegateShim.GetArgValue(a1);
			try
			{
				Invoke(delegate
				{
					((dynamic)target)(ref v1);
				});
			}
			finally
			{
				DelegateShim.SetArgValue(a1, v1);
			}
		}
	}

	[ExcludeFromCodeCoverage]
	private class ProcShim<T1, T2, TDelegate> : ProcShim
	{
		private static readonly MethodInfo method = typeof(ProcShim<T1, T2, TDelegate>).GetMethod("InvokeTarget");

		private static readonly bool allByValue = DelegateShim.GetAllByValue(typeof(T1), typeof(T2));

		private readonly object target;

		private readonly Delegate del;

		public override Delegate Delegate => del;

		public ProcShim(ScriptEngine engine, object target)
			: base(engine)
		{
			this.target = DelegateShim.GetCompatibleTarget(typeof(TDelegate), target);
			del = Delegate.CreateDelegate(typeof(TDelegate), this, method);
		}

		public void InvokeTarget(T1 a1, T2 a2)
		{
			if (allByValue || base.Engine.EnableAutoHostVariables)
			{
				Invoke(delegate
				{
					((dynamic)target)(a1, a2);
				});
				return;
			}
			object v1 = DelegateShim.GetArgValue(a1);
			object v2 = DelegateShim.GetArgValue(a2);
			try
			{
				Invoke(delegate
				{
					((dynamic)target)(ref v1, ref v2);
				});
			}
			finally
			{
				DelegateShim.SetArgValue(a1, v1);
				DelegateShim.SetArgValue(a2, v2);
			}
		}
	}

	[ExcludeFromCodeCoverage]
	private class ProcShim<T1, T2, T3, TDelegate> : ProcShim
	{
		private static readonly MethodInfo method = typeof(ProcShim<T1, T2, T3, TDelegate>).GetMethod("InvokeTarget");

		private static readonly bool allByValue = DelegateShim.GetAllByValue(typeof(T1), typeof(T2), typeof(T3));

		private readonly object target;

		private readonly Delegate del;

		public override Delegate Delegate => del;

		public ProcShim(ScriptEngine engine, object target)
			: base(engine)
		{
			this.target = DelegateShim.GetCompatibleTarget(typeof(TDelegate), target);
			del = Delegate.CreateDelegate(typeof(TDelegate), this, method);
		}

		public void InvokeTarget(T1 a1, T2 a2, T3 a3)
		{
			if (allByValue || base.Engine.EnableAutoHostVariables)
			{
				Invoke(delegate
				{
					((dynamic)target)(a1, a2, a3);
				});
				return;
			}
			object v1 = DelegateShim.GetArgValue(a1);
			object v2 = DelegateShim.GetArgValue(a2);
			object v3 = DelegateShim.GetArgValue(a3);
			try
			{
				Invoke(delegate
				{
					((dynamic)target)(ref v1, ref v2, ref v3);
				});
			}
			finally
			{
				DelegateShim.SetArgValue(a1, v1);
				DelegateShim.SetArgValue(a2, v2);
				DelegateShim.SetArgValue(a3, v3);
			}
		}
	}

	[ExcludeFromCodeCoverage]
	private class ProcShim<T1, T2, T3, T4, TDelegate> : ProcShim
	{
		private static readonly MethodInfo method = typeof(ProcShim<T1, T2, T3, T4, TDelegate>).GetMethod("InvokeTarget");

		private static readonly bool allByValue = DelegateShim.GetAllByValue(typeof(T1), typeof(T2), typeof(T3), typeof(T4));

		private readonly object target;

		private readonly Delegate del;

		public override Delegate Delegate => del;

		public ProcShim(ScriptEngine engine, object target)
			: base(engine)
		{
			this.target = DelegateShim.GetCompatibleTarget(typeof(TDelegate), target);
			del = Delegate.CreateDelegate(typeof(TDelegate), this, method);
		}

		public void InvokeTarget(T1 a1, T2 a2, T3 a3, T4 a4)
		{
			if (allByValue || base.Engine.EnableAutoHostVariables)
			{
				Invoke(delegate
				{
					((dynamic)target)(a1, a2, a3, a4);
				});
				return;
			}
			object v1 = DelegateShim.GetArgValue(a1);
			object v2 = DelegateShim.GetArgValue(a2);
			object v3 = DelegateShim.GetArgValue(a3);
			object v4 = DelegateShim.GetArgValue(a4);
			try
			{
				Invoke(delegate
				{
					((dynamic)target)(ref v1, ref v2, ref v3, ref v4);
				});
			}
			finally
			{
				DelegateShim.SetArgValue(a1, v1);
				DelegateShim.SetArgValue(a2, v2);
				DelegateShim.SetArgValue(a3, v3);
				DelegateShim.SetArgValue(a4, v4);
			}
		}
	}

	[ExcludeFromCodeCoverage]
	private class ProcShim<T1, T2, T3, T4, T5, TDelegate> : ProcShim
	{
		private static readonly MethodInfo method = typeof(ProcShim<T1, T2, T3, T4, T5, TDelegate>).GetMethod("InvokeTarget");

		private static readonly bool allByValue = DelegateShim.GetAllByValue(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5));

		private readonly object target;

		private readonly Delegate del;

		public override Delegate Delegate => del;

		public ProcShim(ScriptEngine engine, object target)
			: base(engine)
		{
			this.target = DelegateShim.GetCompatibleTarget(typeof(TDelegate), target);
			del = Delegate.CreateDelegate(typeof(TDelegate), this, method);
		}

		public void InvokeTarget(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5)
		{
			if (allByValue || base.Engine.EnableAutoHostVariables)
			{
				Invoke(delegate
				{
					((dynamic)target)(a1, a2, a3, a4, a5);
				});
				return;
			}
			object v1 = DelegateShim.GetArgValue(a1);
			object v2 = DelegateShim.GetArgValue(a2);
			object v3 = DelegateShim.GetArgValue(a3);
			object v4 = DelegateShim.GetArgValue(a4);
			object v5 = DelegateShim.GetArgValue(a5);
			try
			{
				Invoke(delegate
				{
					((dynamic)target)(ref v1, ref v2, ref v3, ref v4, ref v5);
				});
			}
			finally
			{
				DelegateShim.SetArgValue(a1, v1);
				DelegateShim.SetArgValue(a2, v2);
				DelegateShim.SetArgValue(a3, v3);
				DelegateShim.SetArgValue(a4, v4);
				DelegateShim.SetArgValue(a5, v5);
			}
		}
	}

	[ExcludeFromCodeCoverage]
	private class ProcShim<T1, T2, T3, T4, T5, T6, TDelegate> : ProcShim
	{
		private static readonly MethodInfo method = typeof(ProcShim<T1, T2, T3, T4, T5, T6, TDelegate>).GetMethod("InvokeTarget");

		private static readonly bool allByValue = DelegateShim.GetAllByValue(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6));

		private readonly object target;

		private readonly Delegate del;

		public override Delegate Delegate => del;

		public ProcShim(ScriptEngine engine, object target)
			: base(engine)
		{
			this.target = DelegateShim.GetCompatibleTarget(typeof(TDelegate), target);
			del = Delegate.CreateDelegate(typeof(TDelegate), this, method);
		}

		public void InvokeTarget(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6)
		{
			if (allByValue || base.Engine.EnableAutoHostVariables)
			{
				Invoke(delegate
				{
					((dynamic)target)(a1, a2, a3, a4, a5, a6);
				});
				return;
			}
			object v1 = DelegateShim.GetArgValue(a1);
			object v2 = DelegateShim.GetArgValue(a2);
			object v3 = DelegateShim.GetArgValue(a3);
			object v4 = DelegateShim.GetArgValue(a4);
			object v5 = DelegateShim.GetArgValue(a5);
			object v6 = DelegateShim.GetArgValue(a6);
			try
			{
				Invoke(delegate
				{
					((dynamic)target)(ref v1, ref v2, ref v3, ref v4, ref v5, ref v6);
				});
			}
			finally
			{
				DelegateShim.SetArgValue(a1, v1);
				DelegateShim.SetArgValue(a2, v2);
				DelegateShim.SetArgValue(a3, v3);
				DelegateShim.SetArgValue(a4, v4);
				DelegateShim.SetArgValue(a5, v5);
				DelegateShim.SetArgValue(a6, v6);
			}
		}
	}

	[ExcludeFromCodeCoverage]
	private class ProcShim<T1, T2, T3, T4, T5, T6, T7, TDelegate> : ProcShim
	{
		private static readonly MethodInfo method = typeof(ProcShim<T1, T2, T3, T4, T5, T6, T7, TDelegate>).GetMethod("InvokeTarget");

		private static readonly bool allByValue = DelegateShim.GetAllByValue(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7));

		private readonly object target;

		private readonly Delegate del;

		public override Delegate Delegate => del;

		public ProcShim(ScriptEngine engine, object target)
			: base(engine)
		{
			this.target = DelegateShim.GetCompatibleTarget(typeof(TDelegate), target);
			del = Delegate.CreateDelegate(typeof(TDelegate), this, method);
		}

		public void InvokeTarget(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7)
		{
			if (allByValue || base.Engine.EnableAutoHostVariables)
			{
				Invoke(delegate
				{
					((dynamic)target)(a1, a2, a3, a4, a5, a6, a7);
				});
				return;
			}
			object v1 = DelegateShim.GetArgValue(a1);
			object v2 = DelegateShim.GetArgValue(a2);
			object v3 = DelegateShim.GetArgValue(a3);
			object v4 = DelegateShim.GetArgValue(a4);
			object v5 = DelegateShim.GetArgValue(a5);
			object v6 = DelegateShim.GetArgValue(a6);
			object v7 = DelegateShim.GetArgValue(a7);
			try
			{
				Invoke(delegate
				{
					((dynamic)target)(ref v1, ref v2, ref v3, ref v4, ref v5, ref v6, ref v7);
				});
			}
			finally
			{
				DelegateShim.SetArgValue(a1, v1);
				DelegateShim.SetArgValue(a2, v2);
				DelegateShim.SetArgValue(a3, v3);
				DelegateShim.SetArgValue(a4, v4);
				DelegateShim.SetArgValue(a5, v5);
				DelegateShim.SetArgValue(a6, v6);
				DelegateShim.SetArgValue(a7, v7);
			}
		}
	}

	[ExcludeFromCodeCoverage]
	private class ProcShim<T1, T2, T3, T4, T5, T6, T7, T8, TDelegate> : ProcShim
	{
		private static readonly MethodInfo method = typeof(ProcShim<T1, T2, T3, T4, T5, T6, T7, T8, TDelegate>).GetMethod("InvokeTarget");

		private static readonly bool allByValue = DelegateShim.GetAllByValue(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8));

		private readonly object target;

		private readonly Delegate del;

		public override Delegate Delegate => del;

		public ProcShim(ScriptEngine engine, object target)
			: base(engine)
		{
			this.target = DelegateShim.GetCompatibleTarget(typeof(TDelegate), target);
			del = Delegate.CreateDelegate(typeof(TDelegate), this, method);
		}

		public void InvokeTarget(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8)
		{
			if (allByValue || base.Engine.EnableAutoHostVariables)
			{
				Invoke(delegate
				{
					((dynamic)target)(a1, a2, a3, a4, a5, a6, a7, a8);
				});
				return;
			}
			object v1 = DelegateShim.GetArgValue(a1);
			object v2 = DelegateShim.GetArgValue(a2);
			object v3 = DelegateShim.GetArgValue(a3);
			object v4 = DelegateShim.GetArgValue(a4);
			object v5 = DelegateShim.GetArgValue(a5);
			object v6 = DelegateShim.GetArgValue(a6);
			object v7 = DelegateShim.GetArgValue(a7);
			object v8 = DelegateShim.GetArgValue(a8);
			try
			{
				Invoke(delegate
				{
					((dynamic)target)(ref v1, ref v2, ref v3, ref v4, ref v5, ref v6, ref v7, ref v8);
				});
			}
			finally
			{
				DelegateShim.SetArgValue(a1, v1);
				DelegateShim.SetArgValue(a2, v2);
				DelegateShim.SetArgValue(a3, v3);
				DelegateShim.SetArgValue(a4, v4);
				DelegateShim.SetArgValue(a5, v5);
				DelegateShim.SetArgValue(a6, v6);
				DelegateShim.SetArgValue(a7, v7);
				DelegateShim.SetArgValue(a8, v8);
			}
		}
	}

	[ExcludeFromCodeCoverage]
	private class ProcShim<T1, T2, T3, T4, T5, T6, T7, T8, T9, TDelegate> : ProcShim
	{
		private static readonly MethodInfo method = typeof(ProcShim<T1, T2, T3, T4, T5, T6, T7, T8, T9, TDelegate>).GetMethod("InvokeTarget");

		private static readonly bool allByValue = DelegateShim.GetAllByValue(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9));

		private readonly object target;

		private readonly Delegate del;

		public override Delegate Delegate => del;

		public ProcShim(ScriptEngine engine, object target)
			: base(engine)
		{
			this.target = DelegateShim.GetCompatibleTarget(typeof(TDelegate), target);
			del = Delegate.CreateDelegate(typeof(TDelegate), this, method);
		}

		public void InvokeTarget(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9)
		{
			if (allByValue || base.Engine.EnableAutoHostVariables)
			{
				Invoke(delegate
				{
					((dynamic)target)(a1, a2, a3, a4, a5, a6, a7, a8, a9);
				});
				return;
			}
			object v1 = DelegateShim.GetArgValue(a1);
			object v2 = DelegateShim.GetArgValue(a2);
			object v3 = DelegateShim.GetArgValue(a3);
			object v4 = DelegateShim.GetArgValue(a4);
			object v5 = DelegateShim.GetArgValue(a5);
			object v6 = DelegateShim.GetArgValue(a6);
			object v7 = DelegateShim.GetArgValue(a7);
			object v8 = DelegateShim.GetArgValue(a8);
			object v9 = DelegateShim.GetArgValue(a9);
			try
			{
				Invoke(delegate
				{
					((dynamic)target)(ref v1, ref v2, ref v3, ref v4, ref v5, ref v6, ref v7, ref v8, ref v9);
				});
			}
			finally
			{
				DelegateShim.SetArgValue(a1, v1);
				DelegateShim.SetArgValue(a2, v2);
				DelegateShim.SetArgValue(a3, v3);
				DelegateShim.SetArgValue(a4, v4);
				DelegateShim.SetArgValue(a5, v5);
				DelegateShim.SetArgValue(a6, v6);
				DelegateShim.SetArgValue(a7, v7);
				DelegateShim.SetArgValue(a8, v8);
				DelegateShim.SetArgValue(a9, v9);
			}
		}
	}

	[ExcludeFromCodeCoverage]
	private class ProcShim<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TDelegate> : ProcShim
	{
		private static readonly MethodInfo method = typeof(ProcShim<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TDelegate>).GetMethod("InvokeTarget");

		private static readonly bool allByValue = DelegateShim.GetAllByValue(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10));

		private readonly object target;

		private readonly Delegate del;

		public override Delegate Delegate => del;

		public ProcShim(ScriptEngine engine, object target)
			: base(engine)
		{
			this.target = DelegateShim.GetCompatibleTarget(typeof(TDelegate), target);
			del = Delegate.CreateDelegate(typeof(TDelegate), this, method);
		}

		public void InvokeTarget(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10)
		{
			if (allByValue || base.Engine.EnableAutoHostVariables)
			{
				Invoke(delegate
				{
					((dynamic)target)(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10);
				});
				return;
			}
			object v1 = DelegateShim.GetArgValue(a1);
			object v2 = DelegateShim.GetArgValue(a2);
			object v3 = DelegateShim.GetArgValue(a3);
			object v4 = DelegateShim.GetArgValue(a4);
			object v5 = DelegateShim.GetArgValue(a5);
			object v6 = DelegateShim.GetArgValue(a6);
			object v7 = DelegateShim.GetArgValue(a7);
			object v8 = DelegateShim.GetArgValue(a8);
			object v9 = DelegateShim.GetArgValue(a9);
			object v10 = DelegateShim.GetArgValue(a10);
			try
			{
				Invoke(delegate
				{
					((dynamic)target)(ref v1, ref v2, ref v3, ref v4, ref v5, ref v6, ref v7, ref v8, ref v9, ref v10);
				});
			}
			finally
			{
				DelegateShim.SetArgValue(a1, v1);
				DelegateShim.SetArgValue(a2, v2);
				DelegateShim.SetArgValue(a3, v3);
				DelegateShim.SetArgValue(a4, v4);
				DelegateShim.SetArgValue(a5, v5);
				DelegateShim.SetArgValue(a6, v6);
				DelegateShim.SetArgValue(a7, v7);
				DelegateShim.SetArgValue(a8, v8);
				DelegateShim.SetArgValue(a9, v9);
				DelegateShim.SetArgValue(a10, v10);
			}
		}
	}

	[ExcludeFromCodeCoverage]
	private class ProcShim<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TDelegate> : ProcShim
	{
		private static readonly MethodInfo method = typeof(ProcShim<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TDelegate>).GetMethod("InvokeTarget");

		private static readonly bool allByValue = DelegateShim.GetAllByValue(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11));

		private readonly object target;

		private readonly Delegate del;

		public override Delegate Delegate => del;

		public ProcShim(ScriptEngine engine, object target)
			: base(engine)
		{
			this.target = DelegateShim.GetCompatibleTarget(typeof(TDelegate), target);
			del = Delegate.CreateDelegate(typeof(TDelegate), this, method);
		}

		public void InvokeTarget(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11)
		{
			if (allByValue || base.Engine.EnableAutoHostVariables)
			{
				Invoke(delegate
				{
					((dynamic)target)(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11);
				});
				return;
			}
			object v1 = DelegateShim.GetArgValue(a1);
			object v2 = DelegateShim.GetArgValue(a2);
			object v3 = DelegateShim.GetArgValue(a3);
			object v4 = DelegateShim.GetArgValue(a4);
			object v5 = DelegateShim.GetArgValue(a5);
			object v6 = DelegateShim.GetArgValue(a6);
			object v7 = DelegateShim.GetArgValue(a7);
			object v8 = DelegateShim.GetArgValue(a8);
			object v9 = DelegateShim.GetArgValue(a9);
			object v10 = DelegateShim.GetArgValue(a10);
			object v11 = DelegateShim.GetArgValue(a11);
			try
			{
				Invoke(delegate
				{
					((dynamic)target)(ref v1, ref v2, ref v3, ref v4, ref v5, ref v6, ref v7, ref v8, ref v9, ref v10, ref v11);
				});
			}
			finally
			{
				DelegateShim.SetArgValue(a1, v1);
				DelegateShim.SetArgValue(a2, v2);
				DelegateShim.SetArgValue(a3, v3);
				DelegateShim.SetArgValue(a4, v4);
				DelegateShim.SetArgValue(a5, v5);
				DelegateShim.SetArgValue(a6, v6);
				DelegateShim.SetArgValue(a7, v7);
				DelegateShim.SetArgValue(a8, v8);
				DelegateShim.SetArgValue(a9, v9);
				DelegateShim.SetArgValue(a10, v10);
				DelegateShim.SetArgValue(a11, v11);
			}
		}
	}

	[ExcludeFromCodeCoverage]
	private class ProcShim<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TDelegate> : ProcShim
	{
		private static readonly MethodInfo method = typeof(ProcShim<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TDelegate>).GetMethod("InvokeTarget");

		private static readonly bool allByValue = DelegateShim.GetAllByValue(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12));

		private readonly object target;

		private readonly Delegate del;

		public override Delegate Delegate => del;

		public ProcShim(ScriptEngine engine, object target)
			: base(engine)
		{
			this.target = DelegateShim.GetCompatibleTarget(typeof(TDelegate), target);
			del = Delegate.CreateDelegate(typeof(TDelegate), this, method);
		}

		public void InvokeTarget(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11, T12 a12)
		{
			if (allByValue || base.Engine.EnableAutoHostVariables)
			{
				Invoke(delegate
				{
					((dynamic)target)(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12);
				});
				return;
			}
			object v1 = DelegateShim.GetArgValue(a1);
			object v2 = DelegateShim.GetArgValue(a2);
			object v3 = DelegateShim.GetArgValue(a3);
			object v4 = DelegateShim.GetArgValue(a4);
			object v5 = DelegateShim.GetArgValue(a5);
			object v6 = DelegateShim.GetArgValue(a6);
			object v7 = DelegateShim.GetArgValue(a7);
			object v8 = DelegateShim.GetArgValue(a8);
			object v9 = DelegateShim.GetArgValue(a9);
			object v10 = DelegateShim.GetArgValue(a10);
			object v11 = DelegateShim.GetArgValue(a11);
			object v12 = DelegateShim.GetArgValue(a12);
			try
			{
				Invoke(delegate
				{
					((dynamic)target)(ref v1, ref v2, ref v3, ref v4, ref v5, ref v6, ref v7, ref v8, ref v9, ref v10, ref v11, ref v12);
				});
			}
			finally
			{
				DelegateShim.SetArgValue(a1, v1);
				DelegateShim.SetArgValue(a2, v2);
				DelegateShim.SetArgValue(a3, v3);
				DelegateShim.SetArgValue(a4, v4);
				DelegateShim.SetArgValue(a5, v5);
				DelegateShim.SetArgValue(a6, v6);
				DelegateShim.SetArgValue(a7, v7);
				DelegateShim.SetArgValue(a8, v8);
				DelegateShim.SetArgValue(a9, v9);
				DelegateShim.SetArgValue(a10, v10);
				DelegateShim.SetArgValue(a11, v11);
				DelegateShim.SetArgValue(a12, v12);
			}
		}
	}

	[ExcludeFromCodeCoverage]
	private class ProcShim<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TDelegate> : ProcShim
	{
		private static readonly MethodInfo method = typeof(ProcShim<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TDelegate>).GetMethod("InvokeTarget");

		private static readonly bool allByValue = DelegateShim.GetAllByValue(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13));

		private readonly object target;

		private readonly Delegate del;

		public override Delegate Delegate => del;

		public ProcShim(ScriptEngine engine, object target)
			: base(engine)
		{
			this.target = DelegateShim.GetCompatibleTarget(typeof(TDelegate), target);
			del = Delegate.CreateDelegate(typeof(TDelegate), this, method);
		}

		public void InvokeTarget(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11, T12 a12, T13 a13)
		{
			if (allByValue || base.Engine.EnableAutoHostVariables)
			{
				Invoke(delegate
				{
					((dynamic)target)(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13);
				});
				return;
			}
			object v1 = DelegateShim.GetArgValue(a1);
			object v2 = DelegateShim.GetArgValue(a2);
			object v3 = DelegateShim.GetArgValue(a3);
			object v4 = DelegateShim.GetArgValue(a4);
			object v5 = DelegateShim.GetArgValue(a5);
			object v6 = DelegateShim.GetArgValue(a6);
			object v7 = DelegateShim.GetArgValue(a7);
			object v8 = DelegateShim.GetArgValue(a8);
			object v9 = DelegateShim.GetArgValue(a9);
			object v10 = DelegateShim.GetArgValue(a10);
			object v11 = DelegateShim.GetArgValue(a11);
			object v12 = DelegateShim.GetArgValue(a12);
			object v13 = DelegateShim.GetArgValue(a13);
			try
			{
				Invoke(delegate
				{
					((dynamic)target)(ref v1, ref v2, ref v3, ref v4, ref v5, ref v6, ref v7, ref v8, ref v9, ref v10, ref v11, ref v12, ref v13);
				});
			}
			finally
			{
				DelegateShim.SetArgValue(a1, v1);
				DelegateShim.SetArgValue(a2, v2);
				DelegateShim.SetArgValue(a3, v3);
				DelegateShim.SetArgValue(a4, v4);
				DelegateShim.SetArgValue(a5, v5);
				DelegateShim.SetArgValue(a6, v6);
				DelegateShim.SetArgValue(a7, v7);
				DelegateShim.SetArgValue(a8, v8);
				DelegateShim.SetArgValue(a9, v9);
				DelegateShim.SetArgValue(a10, v10);
				DelegateShim.SetArgValue(a11, v11);
				DelegateShim.SetArgValue(a12, v12);
				DelegateShim.SetArgValue(a13, v13);
			}
		}
	}

	[ExcludeFromCodeCoverage]
	private class ProcShim<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TDelegate> : ProcShim
	{
		private static readonly MethodInfo method = typeof(ProcShim<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TDelegate>).GetMethod("InvokeTarget");

		private static readonly bool allByValue = DelegateShim.GetAllByValue(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14));

		private readonly object target;

		private readonly Delegate del;

		public override Delegate Delegate => del;

		public ProcShim(ScriptEngine engine, object target)
			: base(engine)
		{
			this.target = DelegateShim.GetCompatibleTarget(typeof(TDelegate), target);
			del = Delegate.CreateDelegate(typeof(TDelegate), this, method);
		}

		public void InvokeTarget(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11, T12 a12, T13 a13, T14 a14)
		{
			if (allByValue || base.Engine.EnableAutoHostVariables)
			{
				Invoke(delegate
				{
					((dynamic)target)(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14);
				});
				return;
			}
			object v1 = DelegateShim.GetArgValue(a1);
			object v2 = DelegateShim.GetArgValue(a2);
			object v3 = DelegateShim.GetArgValue(a3);
			object v4 = DelegateShim.GetArgValue(a4);
			object v5 = DelegateShim.GetArgValue(a5);
			object v6 = DelegateShim.GetArgValue(a6);
			object v7 = DelegateShim.GetArgValue(a7);
			object v8 = DelegateShim.GetArgValue(a8);
			object v9 = DelegateShim.GetArgValue(a9);
			object v10 = DelegateShim.GetArgValue(a10);
			object v11 = DelegateShim.GetArgValue(a11);
			object v12 = DelegateShim.GetArgValue(a12);
			object v13 = DelegateShim.GetArgValue(a13);
			object v14 = DelegateShim.GetArgValue(a14);
			try
			{
				Invoke(delegate
				{
					((dynamic)target)(ref v1, ref v2, ref v3, ref v4, ref v5, ref v6, ref v7, ref v8, ref v9, ref v10, ref v11, ref v12, ref v13, ref v14);
				});
			}
			finally
			{
				DelegateShim.SetArgValue(a1, v1);
				DelegateShim.SetArgValue(a2, v2);
				DelegateShim.SetArgValue(a3, v3);
				DelegateShim.SetArgValue(a4, v4);
				DelegateShim.SetArgValue(a5, v5);
				DelegateShim.SetArgValue(a6, v6);
				DelegateShim.SetArgValue(a7, v7);
				DelegateShim.SetArgValue(a8, v8);
				DelegateShim.SetArgValue(a9, v9);
				DelegateShim.SetArgValue(a10, v10);
				DelegateShim.SetArgValue(a11, v11);
				DelegateShim.SetArgValue(a12, v12);
				DelegateShim.SetArgValue(a13, v13);
				DelegateShim.SetArgValue(a14, v14);
			}
		}
	}

	[ExcludeFromCodeCoverage]
	private class ProcShim<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TDelegate> : ProcShim
	{
		private static readonly MethodInfo method = typeof(ProcShim<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TDelegate>).GetMethod("InvokeTarget");

		private static readonly bool allByValue = DelegateShim.GetAllByValue(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14), typeof(T15));

		private readonly object target;

		private readonly Delegate del;

		public override Delegate Delegate => del;

		public ProcShim(ScriptEngine engine, object target)
			: base(engine)
		{
			this.target = DelegateShim.GetCompatibleTarget(typeof(TDelegate), target);
			del = Delegate.CreateDelegate(typeof(TDelegate), this, method);
		}

		public void InvokeTarget(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11, T12 a12, T13 a13, T14 a14, T15 a15)
		{
			if (allByValue || base.Engine.EnableAutoHostVariables)
			{
				Invoke(delegate
				{
					((dynamic)target)(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15);
				});
				return;
			}
			object v1 = DelegateShim.GetArgValue(a1);
			object v2 = DelegateShim.GetArgValue(a2);
			object v3 = DelegateShim.GetArgValue(a3);
			object v4 = DelegateShim.GetArgValue(a4);
			object v5 = DelegateShim.GetArgValue(a5);
			object v6 = DelegateShim.GetArgValue(a6);
			object v7 = DelegateShim.GetArgValue(a7);
			object v8 = DelegateShim.GetArgValue(a8);
			object v9 = DelegateShim.GetArgValue(a9);
			object v10 = DelegateShim.GetArgValue(a10);
			object v11 = DelegateShim.GetArgValue(a11);
			object v12 = DelegateShim.GetArgValue(a12);
			object v13 = DelegateShim.GetArgValue(a13);
			object v14 = DelegateShim.GetArgValue(a14);
			object v15 = DelegateShim.GetArgValue(a15);
			try
			{
				Invoke(delegate
				{
					((dynamic)target)(ref v1, ref v2, ref v3, ref v4, ref v5, ref v6, ref v7, ref v8, ref v9, ref v10, ref v11, ref v12, ref v13, ref v14, ref v15);
				});
			}
			finally
			{
				DelegateShim.SetArgValue(a1, v1);
				DelegateShim.SetArgValue(a2, v2);
				DelegateShim.SetArgValue(a3, v3);
				DelegateShim.SetArgValue(a4, v4);
				DelegateShim.SetArgValue(a5, v5);
				DelegateShim.SetArgValue(a6, v6);
				DelegateShim.SetArgValue(a7, v7);
				DelegateShim.SetArgValue(a8, v8);
				DelegateShim.SetArgValue(a9, v9);
				DelegateShim.SetArgValue(a10, v10);
				DelegateShim.SetArgValue(a11, v11);
				DelegateShim.SetArgValue(a12, v12);
				DelegateShim.SetArgValue(a13, v13);
				DelegateShim.SetArgValue(a14, v14);
				DelegateShim.SetArgValue(a15, v15);
			}
		}
	}

	[ExcludeFromCodeCoverage]
	private class ProcShim<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TDelegate> : ProcShim
	{
		private static readonly MethodInfo method = typeof(ProcShim<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TDelegate>).GetMethod("InvokeTarget");

		private static readonly bool allByValue = DelegateShim.GetAllByValue(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14), typeof(T15), typeof(T16));

		private readonly object target;

		private readonly Delegate del;

		public override Delegate Delegate => del;

		public ProcShim(ScriptEngine engine, object target)
			: base(engine)
		{
			this.target = DelegateShim.GetCompatibleTarget(typeof(TDelegate), target);
			del = Delegate.CreateDelegate(typeof(TDelegate), this, method);
		}

		public void InvokeTarget(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11, T12 a12, T13 a13, T14 a14, T15 a15, T16 a16)
		{
			if (allByValue || base.Engine.EnableAutoHostVariables)
			{
				Invoke(delegate
				{
					((dynamic)target)(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16);
				});
				return;
			}
			object v1 = DelegateShim.GetArgValue(a1);
			object v2 = DelegateShim.GetArgValue(a2);
			object v3 = DelegateShim.GetArgValue(a3);
			object v4 = DelegateShim.GetArgValue(a4);
			object v5 = DelegateShim.GetArgValue(a5);
			object v6 = DelegateShim.GetArgValue(a6);
			object v7 = DelegateShim.GetArgValue(a7);
			object v8 = DelegateShim.GetArgValue(a8);
			object v9 = DelegateShim.GetArgValue(a9);
			object v10 = DelegateShim.GetArgValue(a10);
			object v11 = DelegateShim.GetArgValue(a11);
			object v12 = DelegateShim.GetArgValue(a12);
			object v13 = DelegateShim.GetArgValue(a13);
			object v14 = DelegateShim.GetArgValue(a14);
			object v15 = DelegateShim.GetArgValue(a15);
			object v16 = DelegateShim.GetArgValue(a16);
			try
			{
				Invoke(delegate
				{
					((dynamic)target)(ref v1, ref v2, ref v3, ref v4, ref v5, ref v6, ref v7, ref v8, ref v9, ref v10, ref v11, ref v12, ref v13, ref v14, ref v15, ref v16);
				});
			}
			finally
			{
				DelegateShim.SetArgValue(a1, v1);
				DelegateShim.SetArgValue(a2, v2);
				DelegateShim.SetArgValue(a3, v3);
				DelegateShim.SetArgValue(a4, v4);
				DelegateShim.SetArgValue(a5, v5);
				DelegateShim.SetArgValue(a6, v6);
				DelegateShim.SetArgValue(a7, v7);
				DelegateShim.SetArgValue(a8, v8);
				DelegateShim.SetArgValue(a9, v9);
				DelegateShim.SetArgValue(a10, v10);
				DelegateShim.SetArgValue(a11, v11);
				DelegateShim.SetArgValue(a12, v12);
				DelegateShim.SetArgValue(a13, v13);
				DelegateShim.SetArgValue(a14, v14);
				DelegateShim.SetArgValue(a15, v15);
				DelegateShim.SetArgValue(a16, v16);
			}
		}
	}

	[ExcludeFromCodeCoverage]
	private class FuncShim<TResult, TDelegate> : FuncShim<TResult>
	{
		private static readonly MethodInfo method = typeof(FuncShim<TResult, TDelegate>).GetMethod("InvokeTarget");

		private static readonly bool allByValue = true;

		private readonly object target;

		private readonly Delegate del;

		public override Delegate Delegate => del;

		public FuncShim(ScriptEngine engine, object target)
			: base(engine)
		{
			this.target = DelegateShim.GetCompatibleTarget(typeof(TDelegate), target);
			del = Delegate.CreateDelegate(typeof(TDelegate), this, method);
		}

		public TResult InvokeTarget()
		{
			if (allByValue || base.Engine.EnableAutoHostVariables)
			{
				return Invoke(() => (TResult)((dynamic)target)());
			}
			return Invoke(() => (TResult)((dynamic)target)());
		}
	}

	[ExcludeFromCodeCoverage]
	private class FuncShim<T1, TResult, TDelegate> : FuncShim<TResult>
	{
		private static readonly MethodInfo method = typeof(FuncShim<T1, TResult, TDelegate>).GetMethod("InvokeTarget");

		private static readonly bool allByValue = DelegateShim.GetAllByValue(typeof(T1));

		private readonly object target;

		private readonly Delegate del;

		public override Delegate Delegate => del;

		public FuncShim(ScriptEngine engine, object target)
			: base(engine)
		{
			this.target = DelegateShim.GetCompatibleTarget(typeof(TDelegate), target);
			del = Delegate.CreateDelegate(typeof(TDelegate), this, method);
		}

		public TResult InvokeTarget(T1 a1)
		{
			if (allByValue || base.Engine.EnableAutoHostVariables)
			{
				return Invoke(() => (TResult)((dynamic)target)(a1));
			}
			object v1 = DelegateShim.GetArgValue(a1);
			try
			{
				return Invoke(() => (TResult)((dynamic)target)(ref v1));
			}
			finally
			{
				DelegateShim.SetArgValue(a1, v1);
			}
		}
	}

	[ExcludeFromCodeCoverage]
	private class FuncShim<T1, T2, TResult, TDelegate> : FuncShim<TResult>
	{
		private static readonly MethodInfo method = typeof(FuncShim<T1, T2, TResult, TDelegate>).GetMethod("InvokeTarget");

		private static readonly bool allByValue = DelegateShim.GetAllByValue(typeof(T1), typeof(T2));

		private readonly object target;

		private readonly Delegate del;

		public override Delegate Delegate => del;

		public FuncShim(ScriptEngine engine, object target)
			: base(engine)
		{
			this.target = DelegateShim.GetCompatibleTarget(typeof(TDelegate), target);
			del = Delegate.CreateDelegate(typeof(TDelegate), this, method);
		}

		public TResult InvokeTarget(T1 a1, T2 a2)
		{
			if (allByValue || base.Engine.EnableAutoHostVariables)
			{
				return Invoke(() => (TResult)((dynamic)target)(a1, a2));
			}
			object v1 = DelegateShim.GetArgValue(a1);
			object v2 = DelegateShim.GetArgValue(a2);
			try
			{
				return Invoke(() => (TResult)((dynamic)target)(ref v1, ref v2));
			}
			finally
			{
				DelegateShim.SetArgValue(a1, v1);
				DelegateShim.SetArgValue(a2, v2);
			}
		}
	}

	[ExcludeFromCodeCoverage]
	private class FuncShim<T1, T2, T3, TResult, TDelegate> : FuncShim<TResult>
	{
		private static readonly MethodInfo method = typeof(FuncShim<T1, T2, T3, TResult, TDelegate>).GetMethod("InvokeTarget");

		private static readonly bool allByValue = DelegateShim.GetAllByValue(typeof(T1), typeof(T2), typeof(T3));

		private readonly object target;

		private readonly Delegate del;

		public override Delegate Delegate => del;

		public FuncShim(ScriptEngine engine, object target)
			: base(engine)
		{
			this.target = DelegateShim.GetCompatibleTarget(typeof(TDelegate), target);
			del = Delegate.CreateDelegate(typeof(TDelegate), this, method);
		}

		public TResult InvokeTarget(T1 a1, T2 a2, T3 a3)
		{
			if (allByValue || base.Engine.EnableAutoHostVariables)
			{
				return Invoke(() => (TResult)((dynamic)target)(a1, a2, a3));
			}
			object v1 = DelegateShim.GetArgValue(a1);
			object v2 = DelegateShim.GetArgValue(a2);
			object v3 = DelegateShim.GetArgValue(a3);
			try
			{
				return Invoke(() => (TResult)((dynamic)target)(ref v1, ref v2, ref v3));
			}
			finally
			{
				DelegateShim.SetArgValue(a1, v1);
				DelegateShim.SetArgValue(a2, v2);
				DelegateShim.SetArgValue(a3, v3);
			}
		}
	}

	[ExcludeFromCodeCoverage]
	private class FuncShim<T1, T2, T3, T4, TResult, TDelegate> : FuncShim<TResult>
	{
		private static readonly MethodInfo method = typeof(FuncShim<T1, T2, T3, T4, TResult, TDelegate>).GetMethod("InvokeTarget");

		private static readonly bool allByValue = DelegateShim.GetAllByValue(typeof(T1), typeof(T2), typeof(T3), typeof(T4));

		private readonly object target;

		private readonly Delegate del;

		public override Delegate Delegate => del;

		public FuncShim(ScriptEngine engine, object target)
			: base(engine)
		{
			this.target = DelegateShim.GetCompatibleTarget(typeof(TDelegate), target);
			del = Delegate.CreateDelegate(typeof(TDelegate), this, method);
		}

		public TResult InvokeTarget(T1 a1, T2 a2, T3 a3, T4 a4)
		{
			if (allByValue || base.Engine.EnableAutoHostVariables)
			{
				return Invoke(() => (TResult)((dynamic)target)(a1, a2, a3, a4));
			}
			object v1 = DelegateShim.GetArgValue(a1);
			object v2 = DelegateShim.GetArgValue(a2);
			object v3 = DelegateShim.GetArgValue(a3);
			object v4 = DelegateShim.GetArgValue(a4);
			try
			{
				return Invoke(() => (TResult)((dynamic)target)(ref v1, ref v2, ref v3, ref v4));
			}
			finally
			{
				DelegateShim.SetArgValue(a1, v1);
				DelegateShim.SetArgValue(a2, v2);
				DelegateShim.SetArgValue(a3, v3);
				DelegateShim.SetArgValue(a4, v4);
			}
		}
	}

	[ExcludeFromCodeCoverage]
	private class FuncShim<T1, T2, T3, T4, T5, TResult, TDelegate> : FuncShim<TResult>
	{
		private static readonly MethodInfo method = typeof(FuncShim<T1, T2, T3, T4, T5, TResult, TDelegate>).GetMethod("InvokeTarget");

		private static readonly bool allByValue = DelegateShim.GetAllByValue(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5));

		private readonly object target;

		private readonly Delegate del;

		public override Delegate Delegate => del;

		public FuncShim(ScriptEngine engine, object target)
			: base(engine)
		{
			this.target = DelegateShim.GetCompatibleTarget(typeof(TDelegate), target);
			del = Delegate.CreateDelegate(typeof(TDelegate), this, method);
		}

		public TResult InvokeTarget(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5)
		{
			if (allByValue || base.Engine.EnableAutoHostVariables)
			{
				return Invoke(() => (TResult)((dynamic)target)(a1, a2, a3, a4, a5));
			}
			object v1 = DelegateShim.GetArgValue(a1);
			object v2 = DelegateShim.GetArgValue(a2);
			object v3 = DelegateShim.GetArgValue(a3);
			object v4 = DelegateShim.GetArgValue(a4);
			object v5 = DelegateShim.GetArgValue(a5);
			try
			{
				return Invoke(() => (TResult)((dynamic)target)(ref v1, ref v2, ref v3, ref v4, ref v5));
			}
			finally
			{
				DelegateShim.SetArgValue(a1, v1);
				DelegateShim.SetArgValue(a2, v2);
				DelegateShim.SetArgValue(a3, v3);
				DelegateShim.SetArgValue(a4, v4);
				DelegateShim.SetArgValue(a5, v5);
			}
		}
	}

	[ExcludeFromCodeCoverage]
	private class FuncShim<T1, T2, T3, T4, T5, T6, TResult, TDelegate> : FuncShim<TResult>
	{
		private static readonly MethodInfo method = typeof(FuncShim<T1, T2, T3, T4, T5, T6, TResult, TDelegate>).GetMethod("InvokeTarget");

		private static readonly bool allByValue = DelegateShim.GetAllByValue(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6));

		private readonly object target;

		private readonly Delegate del;

		public override Delegate Delegate => del;

		public FuncShim(ScriptEngine engine, object target)
			: base(engine)
		{
			this.target = DelegateShim.GetCompatibleTarget(typeof(TDelegate), target);
			del = Delegate.CreateDelegate(typeof(TDelegate), this, method);
		}

		public TResult InvokeTarget(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6)
		{
			if (allByValue || base.Engine.EnableAutoHostVariables)
			{
				return Invoke(() => (TResult)((dynamic)target)(a1, a2, a3, a4, a5, a6));
			}
			object v1 = DelegateShim.GetArgValue(a1);
			object v2 = DelegateShim.GetArgValue(a2);
			object v3 = DelegateShim.GetArgValue(a3);
			object v4 = DelegateShim.GetArgValue(a4);
			object v5 = DelegateShim.GetArgValue(a5);
			object v6 = DelegateShim.GetArgValue(a6);
			try
			{
				return Invoke(() => (TResult)((dynamic)target)(ref v1, ref v2, ref v3, ref v4, ref v5, ref v6));
			}
			finally
			{
				DelegateShim.SetArgValue(a1, v1);
				DelegateShim.SetArgValue(a2, v2);
				DelegateShim.SetArgValue(a3, v3);
				DelegateShim.SetArgValue(a4, v4);
				DelegateShim.SetArgValue(a5, v5);
				DelegateShim.SetArgValue(a6, v6);
			}
		}
	}

	[ExcludeFromCodeCoverage]
	private class FuncShim<T1, T2, T3, T4, T5, T6, T7, TResult, TDelegate> : FuncShim<TResult>
	{
		private static readonly MethodInfo method = typeof(FuncShim<T1, T2, T3, T4, T5, T6, T7, TResult, TDelegate>).GetMethod("InvokeTarget");

		private static readonly bool allByValue = DelegateShim.GetAllByValue(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7));

		private readonly object target;

		private readonly Delegate del;

		public override Delegate Delegate => del;

		public FuncShim(ScriptEngine engine, object target)
			: base(engine)
		{
			this.target = DelegateShim.GetCompatibleTarget(typeof(TDelegate), target);
			del = Delegate.CreateDelegate(typeof(TDelegate), this, method);
		}

		public TResult InvokeTarget(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7)
		{
			if (allByValue || base.Engine.EnableAutoHostVariables)
			{
				return Invoke(() => (TResult)((dynamic)target)(a1, a2, a3, a4, a5, a6, a7));
			}
			object v1 = DelegateShim.GetArgValue(a1);
			object v2 = DelegateShim.GetArgValue(a2);
			object v3 = DelegateShim.GetArgValue(a3);
			object v4 = DelegateShim.GetArgValue(a4);
			object v5 = DelegateShim.GetArgValue(a5);
			object v6 = DelegateShim.GetArgValue(a6);
			object v7 = DelegateShim.GetArgValue(a7);
			try
			{
				return Invoke(() => (TResult)((dynamic)target)(ref v1, ref v2, ref v3, ref v4, ref v5, ref v6, ref v7));
			}
			finally
			{
				DelegateShim.SetArgValue(a1, v1);
				DelegateShim.SetArgValue(a2, v2);
				DelegateShim.SetArgValue(a3, v3);
				DelegateShim.SetArgValue(a4, v4);
				DelegateShim.SetArgValue(a5, v5);
				DelegateShim.SetArgValue(a6, v6);
				DelegateShim.SetArgValue(a7, v7);
			}
		}
	}

	[ExcludeFromCodeCoverage]
	private class FuncShim<T1, T2, T3, T4, T5, T6, T7, T8, TResult, TDelegate> : FuncShim<TResult>
	{
		private static readonly MethodInfo method = typeof(FuncShim<T1, T2, T3, T4, T5, T6, T7, T8, TResult, TDelegate>).GetMethod("InvokeTarget");

		private static readonly bool allByValue = DelegateShim.GetAllByValue(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8));

		private readonly object target;

		private readonly Delegate del;

		public override Delegate Delegate => del;

		public FuncShim(ScriptEngine engine, object target)
			: base(engine)
		{
			this.target = DelegateShim.GetCompatibleTarget(typeof(TDelegate), target);
			del = Delegate.CreateDelegate(typeof(TDelegate), this, method);
		}

		public TResult InvokeTarget(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8)
		{
			if (allByValue || base.Engine.EnableAutoHostVariables)
			{
				return Invoke(() => (TResult)((dynamic)target)(a1, a2, a3, a4, a5, a6, a7, a8));
			}
			object v1 = DelegateShim.GetArgValue(a1);
			object v2 = DelegateShim.GetArgValue(a2);
			object v3 = DelegateShim.GetArgValue(a3);
			object v4 = DelegateShim.GetArgValue(a4);
			object v5 = DelegateShim.GetArgValue(a5);
			object v6 = DelegateShim.GetArgValue(a6);
			object v7 = DelegateShim.GetArgValue(a7);
			object v8 = DelegateShim.GetArgValue(a8);
			try
			{
				return Invoke(() => (TResult)((dynamic)target)(ref v1, ref v2, ref v3, ref v4, ref v5, ref v6, ref v7, ref v8));
			}
			finally
			{
				DelegateShim.SetArgValue(a1, v1);
				DelegateShim.SetArgValue(a2, v2);
				DelegateShim.SetArgValue(a3, v3);
				DelegateShim.SetArgValue(a4, v4);
				DelegateShim.SetArgValue(a5, v5);
				DelegateShim.SetArgValue(a6, v6);
				DelegateShim.SetArgValue(a7, v7);
				DelegateShim.SetArgValue(a8, v8);
			}
		}
	}

	[ExcludeFromCodeCoverage]
	private class FuncShim<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult, TDelegate> : FuncShim<TResult>
	{
		private static readonly MethodInfo method = typeof(FuncShim<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult, TDelegate>).GetMethod("InvokeTarget");

		private static readonly bool allByValue = DelegateShim.GetAllByValue(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9));

		private readonly object target;

		private readonly Delegate del;

		public override Delegate Delegate => del;

		public FuncShim(ScriptEngine engine, object target)
			: base(engine)
		{
			this.target = DelegateShim.GetCompatibleTarget(typeof(TDelegate), target);
			del = Delegate.CreateDelegate(typeof(TDelegate), this, method);
		}

		public TResult InvokeTarget(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9)
		{
			if (allByValue || base.Engine.EnableAutoHostVariables)
			{
				return Invoke(() => (TResult)((dynamic)target)(a1, a2, a3, a4, a5, a6, a7, a8, a9));
			}
			object v1 = DelegateShim.GetArgValue(a1);
			object v2 = DelegateShim.GetArgValue(a2);
			object v3 = DelegateShim.GetArgValue(a3);
			object v4 = DelegateShim.GetArgValue(a4);
			object v5 = DelegateShim.GetArgValue(a5);
			object v6 = DelegateShim.GetArgValue(a6);
			object v7 = DelegateShim.GetArgValue(a7);
			object v8 = DelegateShim.GetArgValue(a8);
			object v9 = DelegateShim.GetArgValue(a9);
			try
			{
				return Invoke(() => (TResult)((dynamic)target)(ref v1, ref v2, ref v3, ref v4, ref v5, ref v6, ref v7, ref v8, ref v9));
			}
			finally
			{
				DelegateShim.SetArgValue(a1, v1);
				DelegateShim.SetArgValue(a2, v2);
				DelegateShim.SetArgValue(a3, v3);
				DelegateShim.SetArgValue(a4, v4);
				DelegateShim.SetArgValue(a5, v5);
				DelegateShim.SetArgValue(a6, v6);
				DelegateShim.SetArgValue(a7, v7);
				DelegateShim.SetArgValue(a8, v8);
				DelegateShim.SetArgValue(a9, v9);
			}
		}
	}

	[ExcludeFromCodeCoverage]
	private class FuncShim<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult, TDelegate> : FuncShim<TResult>
	{
		private static readonly MethodInfo method = typeof(FuncShim<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult, TDelegate>).GetMethod("InvokeTarget");

		private static readonly bool allByValue = DelegateShim.GetAllByValue(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10));

		private readonly object target;

		private readonly Delegate del;

		public override Delegate Delegate => del;

		public FuncShim(ScriptEngine engine, object target)
			: base(engine)
		{
			this.target = DelegateShim.GetCompatibleTarget(typeof(TDelegate), target);
			del = Delegate.CreateDelegate(typeof(TDelegate), this, method);
		}

		public TResult InvokeTarget(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10)
		{
			if (allByValue || base.Engine.EnableAutoHostVariables)
			{
				return Invoke(() => (TResult)((dynamic)target)(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10));
			}
			object v1 = DelegateShim.GetArgValue(a1);
			object v2 = DelegateShim.GetArgValue(a2);
			object v3 = DelegateShim.GetArgValue(a3);
			object v4 = DelegateShim.GetArgValue(a4);
			object v5 = DelegateShim.GetArgValue(a5);
			object v6 = DelegateShim.GetArgValue(a6);
			object v7 = DelegateShim.GetArgValue(a7);
			object v8 = DelegateShim.GetArgValue(a8);
			object v9 = DelegateShim.GetArgValue(a9);
			object v10 = DelegateShim.GetArgValue(a10);
			try
			{
				return Invoke(() => (TResult)((dynamic)target)(ref v1, ref v2, ref v3, ref v4, ref v5, ref v6, ref v7, ref v8, ref v9, ref v10));
			}
			finally
			{
				DelegateShim.SetArgValue(a1, v1);
				DelegateShim.SetArgValue(a2, v2);
				DelegateShim.SetArgValue(a3, v3);
				DelegateShim.SetArgValue(a4, v4);
				DelegateShim.SetArgValue(a5, v5);
				DelegateShim.SetArgValue(a6, v6);
				DelegateShim.SetArgValue(a7, v7);
				DelegateShim.SetArgValue(a8, v8);
				DelegateShim.SetArgValue(a9, v9);
				DelegateShim.SetArgValue(a10, v10);
			}
		}
	}

	[ExcludeFromCodeCoverage]
	private class FuncShim<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult, TDelegate> : FuncShim<TResult>
	{
		private static readonly MethodInfo method = typeof(FuncShim<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult, TDelegate>).GetMethod("InvokeTarget");

		private static readonly bool allByValue = DelegateShim.GetAllByValue(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11));

		private readonly object target;

		private readonly Delegate del;

		public override Delegate Delegate => del;

		public FuncShim(ScriptEngine engine, object target)
			: base(engine)
		{
			this.target = DelegateShim.GetCompatibleTarget(typeof(TDelegate), target);
			del = Delegate.CreateDelegate(typeof(TDelegate), this, method);
		}

		public TResult InvokeTarget(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11)
		{
			if (allByValue || base.Engine.EnableAutoHostVariables)
			{
				return Invoke(() => (TResult)((dynamic)target)(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11));
			}
			object v1 = DelegateShim.GetArgValue(a1);
			object v2 = DelegateShim.GetArgValue(a2);
			object v3 = DelegateShim.GetArgValue(a3);
			object v4 = DelegateShim.GetArgValue(a4);
			object v5 = DelegateShim.GetArgValue(a5);
			object v6 = DelegateShim.GetArgValue(a6);
			object v7 = DelegateShim.GetArgValue(a7);
			object v8 = DelegateShim.GetArgValue(a8);
			object v9 = DelegateShim.GetArgValue(a9);
			object v10 = DelegateShim.GetArgValue(a10);
			object v11 = DelegateShim.GetArgValue(a11);
			try
			{
				return Invoke(() => (TResult)((dynamic)target)(ref v1, ref v2, ref v3, ref v4, ref v5, ref v6, ref v7, ref v8, ref v9, ref v10, ref v11));
			}
			finally
			{
				DelegateShim.SetArgValue(a1, v1);
				DelegateShim.SetArgValue(a2, v2);
				DelegateShim.SetArgValue(a3, v3);
				DelegateShim.SetArgValue(a4, v4);
				DelegateShim.SetArgValue(a5, v5);
				DelegateShim.SetArgValue(a6, v6);
				DelegateShim.SetArgValue(a7, v7);
				DelegateShim.SetArgValue(a8, v8);
				DelegateShim.SetArgValue(a9, v9);
				DelegateShim.SetArgValue(a10, v10);
				DelegateShim.SetArgValue(a11, v11);
			}
		}
	}

	[ExcludeFromCodeCoverage]
	private class FuncShim<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult, TDelegate> : FuncShim<TResult>
	{
		private static readonly MethodInfo method = typeof(FuncShim<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult, TDelegate>).GetMethod("InvokeTarget");

		private static readonly bool allByValue = DelegateShim.GetAllByValue(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12));

		private readonly object target;

		private readonly Delegate del;

		public override Delegate Delegate => del;

		public FuncShim(ScriptEngine engine, object target)
			: base(engine)
		{
			this.target = DelegateShim.GetCompatibleTarget(typeof(TDelegate), target);
			del = Delegate.CreateDelegate(typeof(TDelegate), this, method);
		}

		public TResult InvokeTarget(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11, T12 a12)
		{
			if (allByValue || base.Engine.EnableAutoHostVariables)
			{
				return Invoke(() => (TResult)((dynamic)target)(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12));
			}
			object v1 = DelegateShim.GetArgValue(a1);
			object v2 = DelegateShim.GetArgValue(a2);
			object v3 = DelegateShim.GetArgValue(a3);
			object v4 = DelegateShim.GetArgValue(a4);
			object v5 = DelegateShim.GetArgValue(a5);
			object v6 = DelegateShim.GetArgValue(a6);
			object v7 = DelegateShim.GetArgValue(a7);
			object v8 = DelegateShim.GetArgValue(a8);
			object v9 = DelegateShim.GetArgValue(a9);
			object v10 = DelegateShim.GetArgValue(a10);
			object v11 = DelegateShim.GetArgValue(a11);
			object v12 = DelegateShim.GetArgValue(a12);
			try
			{
				return Invoke(() => (TResult)((dynamic)target)(ref v1, ref v2, ref v3, ref v4, ref v5, ref v6, ref v7, ref v8, ref v9, ref v10, ref v11, ref v12));
			}
			finally
			{
				DelegateShim.SetArgValue(a1, v1);
				DelegateShim.SetArgValue(a2, v2);
				DelegateShim.SetArgValue(a3, v3);
				DelegateShim.SetArgValue(a4, v4);
				DelegateShim.SetArgValue(a5, v5);
				DelegateShim.SetArgValue(a6, v6);
				DelegateShim.SetArgValue(a7, v7);
				DelegateShim.SetArgValue(a8, v8);
				DelegateShim.SetArgValue(a9, v9);
				DelegateShim.SetArgValue(a10, v10);
				DelegateShim.SetArgValue(a11, v11);
				DelegateShim.SetArgValue(a12, v12);
			}
		}
	}

	[ExcludeFromCodeCoverage]
	private class FuncShim<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult, TDelegate> : FuncShim<TResult>
	{
		private static readonly MethodInfo method = typeof(FuncShim<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult, TDelegate>).GetMethod("InvokeTarget");

		private static readonly bool allByValue = DelegateShim.GetAllByValue(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13));

		private readonly object target;

		private readonly Delegate del;

		public override Delegate Delegate => del;

		public FuncShim(ScriptEngine engine, object target)
			: base(engine)
		{
			this.target = DelegateShim.GetCompatibleTarget(typeof(TDelegate), target);
			del = Delegate.CreateDelegate(typeof(TDelegate), this, method);
		}

		public TResult InvokeTarget(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11, T12 a12, T13 a13)
		{
			if (allByValue || base.Engine.EnableAutoHostVariables)
			{
				return Invoke(() => (TResult)((dynamic)target)(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13));
			}
			object v1 = DelegateShim.GetArgValue(a1);
			object v2 = DelegateShim.GetArgValue(a2);
			object v3 = DelegateShim.GetArgValue(a3);
			object v4 = DelegateShim.GetArgValue(a4);
			object v5 = DelegateShim.GetArgValue(a5);
			object v6 = DelegateShim.GetArgValue(a6);
			object v7 = DelegateShim.GetArgValue(a7);
			object v8 = DelegateShim.GetArgValue(a8);
			object v9 = DelegateShim.GetArgValue(a9);
			object v10 = DelegateShim.GetArgValue(a10);
			object v11 = DelegateShim.GetArgValue(a11);
			object v12 = DelegateShim.GetArgValue(a12);
			object v13 = DelegateShim.GetArgValue(a13);
			try
			{
				return Invoke(() => (TResult)((dynamic)target)(ref v1, ref v2, ref v3, ref v4, ref v5, ref v6, ref v7, ref v8, ref v9, ref v10, ref v11, ref v12, ref v13));
			}
			finally
			{
				DelegateShim.SetArgValue(a1, v1);
				DelegateShim.SetArgValue(a2, v2);
				DelegateShim.SetArgValue(a3, v3);
				DelegateShim.SetArgValue(a4, v4);
				DelegateShim.SetArgValue(a5, v5);
				DelegateShim.SetArgValue(a6, v6);
				DelegateShim.SetArgValue(a7, v7);
				DelegateShim.SetArgValue(a8, v8);
				DelegateShim.SetArgValue(a9, v9);
				DelegateShim.SetArgValue(a10, v10);
				DelegateShim.SetArgValue(a11, v11);
				DelegateShim.SetArgValue(a12, v12);
				DelegateShim.SetArgValue(a13, v13);
			}
		}
	}

	[ExcludeFromCodeCoverage]
	private class FuncShim<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult, TDelegate> : FuncShim<TResult>
	{
		private static readonly MethodInfo method = typeof(FuncShim<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult, TDelegate>).GetMethod("InvokeTarget");

		private static readonly bool allByValue = DelegateShim.GetAllByValue(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14));

		private readonly object target;

		private readonly Delegate del;

		public override Delegate Delegate => del;

		public FuncShim(ScriptEngine engine, object target)
			: base(engine)
		{
			this.target = DelegateShim.GetCompatibleTarget(typeof(TDelegate), target);
			del = Delegate.CreateDelegate(typeof(TDelegate), this, method);
		}

		public TResult InvokeTarget(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11, T12 a12, T13 a13, T14 a14)
		{
			if (allByValue || base.Engine.EnableAutoHostVariables)
			{
				return Invoke(() => (TResult)((dynamic)target)(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14));
			}
			object v1 = DelegateShim.GetArgValue(a1);
			object v2 = DelegateShim.GetArgValue(a2);
			object v3 = DelegateShim.GetArgValue(a3);
			object v4 = DelegateShim.GetArgValue(a4);
			object v5 = DelegateShim.GetArgValue(a5);
			object v6 = DelegateShim.GetArgValue(a6);
			object v7 = DelegateShim.GetArgValue(a7);
			object v8 = DelegateShim.GetArgValue(a8);
			object v9 = DelegateShim.GetArgValue(a9);
			object v10 = DelegateShim.GetArgValue(a10);
			object v11 = DelegateShim.GetArgValue(a11);
			object v12 = DelegateShim.GetArgValue(a12);
			object v13 = DelegateShim.GetArgValue(a13);
			object v14 = DelegateShim.GetArgValue(a14);
			try
			{
				return Invoke(() => (TResult)((dynamic)target)(ref v1, ref v2, ref v3, ref v4, ref v5, ref v6, ref v7, ref v8, ref v9, ref v10, ref v11, ref v12, ref v13, ref v14));
			}
			finally
			{
				DelegateShim.SetArgValue(a1, v1);
				DelegateShim.SetArgValue(a2, v2);
				DelegateShim.SetArgValue(a3, v3);
				DelegateShim.SetArgValue(a4, v4);
				DelegateShim.SetArgValue(a5, v5);
				DelegateShim.SetArgValue(a6, v6);
				DelegateShim.SetArgValue(a7, v7);
				DelegateShim.SetArgValue(a8, v8);
				DelegateShim.SetArgValue(a9, v9);
				DelegateShim.SetArgValue(a10, v10);
				DelegateShim.SetArgValue(a11, v11);
				DelegateShim.SetArgValue(a12, v12);
				DelegateShim.SetArgValue(a13, v13);
				DelegateShim.SetArgValue(a14, v14);
			}
		}
	}

	[ExcludeFromCodeCoverage]
	private class FuncShim<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult, TDelegate> : FuncShim<TResult>
	{
		private static readonly MethodInfo method = typeof(FuncShim<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult, TDelegate>).GetMethod("InvokeTarget");

		private static readonly bool allByValue = DelegateShim.GetAllByValue(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14), typeof(T15));

		private readonly object target;

		private readonly Delegate del;

		public override Delegate Delegate => del;

		public FuncShim(ScriptEngine engine, object target)
			: base(engine)
		{
			this.target = DelegateShim.GetCompatibleTarget(typeof(TDelegate), target);
			del = Delegate.CreateDelegate(typeof(TDelegate), this, method);
		}

		public TResult InvokeTarget(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11, T12 a12, T13 a13, T14 a14, T15 a15)
		{
			if (allByValue || base.Engine.EnableAutoHostVariables)
			{
				return Invoke(() => (TResult)((dynamic)target)(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15));
			}
			object v1 = DelegateShim.GetArgValue(a1);
			object v2 = DelegateShim.GetArgValue(a2);
			object v3 = DelegateShim.GetArgValue(a3);
			object v4 = DelegateShim.GetArgValue(a4);
			object v5 = DelegateShim.GetArgValue(a5);
			object v6 = DelegateShim.GetArgValue(a6);
			object v7 = DelegateShim.GetArgValue(a7);
			object v8 = DelegateShim.GetArgValue(a8);
			object v9 = DelegateShim.GetArgValue(a9);
			object v10 = DelegateShim.GetArgValue(a10);
			object v11 = DelegateShim.GetArgValue(a11);
			object v12 = DelegateShim.GetArgValue(a12);
			object v13 = DelegateShim.GetArgValue(a13);
			object v14 = DelegateShim.GetArgValue(a14);
			object v15 = DelegateShim.GetArgValue(a15);
			try
			{
				return Invoke(() => (TResult)((dynamic)target)(ref v1, ref v2, ref v3, ref v4, ref v5, ref v6, ref v7, ref v8, ref v9, ref v10, ref v11, ref v12, ref v13, ref v14, ref v15));
			}
			finally
			{
				DelegateShim.SetArgValue(a1, v1);
				DelegateShim.SetArgValue(a2, v2);
				DelegateShim.SetArgValue(a3, v3);
				DelegateShim.SetArgValue(a4, v4);
				DelegateShim.SetArgValue(a5, v5);
				DelegateShim.SetArgValue(a6, v6);
				DelegateShim.SetArgValue(a7, v7);
				DelegateShim.SetArgValue(a8, v8);
				DelegateShim.SetArgValue(a9, v9);
				DelegateShim.SetArgValue(a10, v10);
				DelegateShim.SetArgValue(a11, v11);
				DelegateShim.SetArgValue(a12, v12);
				DelegateShim.SetArgValue(a13, v13);
				DelegateShim.SetArgValue(a14, v14);
				DelegateShim.SetArgValue(a15, v15);
			}
		}
	}

	[ExcludeFromCodeCoverage]
	private class FuncShim<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult, TDelegate> : FuncShim<TResult>
	{
		private static readonly MethodInfo method = typeof(FuncShim<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult, TDelegate>).GetMethod("InvokeTarget");

		private static readonly bool allByValue = DelegateShim.GetAllByValue(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14), typeof(T15), typeof(T16));

		private readonly object target;

		private readonly Delegate del;

		public override Delegate Delegate => del;

		public FuncShim(ScriptEngine engine, object target)
			: base(engine)
		{
			this.target = DelegateShim.GetCompatibleTarget(typeof(TDelegate), target);
			del = Delegate.CreateDelegate(typeof(TDelegate), this, method);
		}

		public TResult InvokeTarget(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11, T12 a12, T13 a13, T14 a14, T15 a15, T16 a16)
		{
			if (allByValue || base.Engine.EnableAutoHostVariables)
			{
				return Invoke(() => (TResult)((dynamic)target)(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16));
			}
			object v1 = DelegateShim.GetArgValue(a1);
			object v2 = DelegateShim.GetArgValue(a2);
			object v3 = DelegateShim.GetArgValue(a3);
			object v4 = DelegateShim.GetArgValue(a4);
			object v5 = DelegateShim.GetArgValue(a5);
			object v6 = DelegateShim.GetArgValue(a6);
			object v7 = DelegateShim.GetArgValue(a7);
			object v8 = DelegateShim.GetArgValue(a8);
			object v9 = DelegateShim.GetArgValue(a9);
			object v10 = DelegateShim.GetArgValue(a10);
			object v11 = DelegateShim.GetArgValue(a11);
			object v12 = DelegateShim.GetArgValue(a12);
			object v13 = DelegateShim.GetArgValue(a13);
			object v14 = DelegateShim.GetArgValue(a14);
			object v15 = DelegateShim.GetArgValue(a15);
			object v16 = DelegateShim.GetArgValue(a16);
			try
			{
				return Invoke(() => (TResult)((dynamic)target)(ref v1, ref v2, ref v3, ref v4, ref v5, ref v6, ref v7, ref v8, ref v9, ref v10, ref v11, ref v12, ref v13, ref v14, ref v15, ref v16));
			}
			finally
			{
				DelegateShim.SetArgValue(a1, v1);
				DelegateShim.SetArgValue(a2, v2);
				DelegateShim.SetArgValue(a3, v3);
				DelegateShim.SetArgValue(a4, v4);
				DelegateShim.SetArgValue(a5, v5);
				DelegateShim.SetArgValue(a6, v6);
				DelegateShim.SetArgValue(a7, v7);
				DelegateShim.SetArgValue(a8, v8);
				DelegateShim.SetArgValue(a9, v9);
				DelegateShim.SetArgValue(a10, v10);
				DelegateShim.SetArgValue(a11, v11);
				DelegateShim.SetArgValue(a12, v12);
				DelegateShim.SetArgValue(a13, v13);
				DelegateShim.SetArgValue(a14, v14);
				DelegateShim.SetArgValue(a15, v15);
				DelegateShim.SetArgValue(a16, v16);
			}
		}
	}

	private const int maxArgCount = 16;

	private static readonly Type[] procTemplates = new Type[17]
	{
		typeof(Action),
		typeof(Action<>),
		typeof(Action<, >),
		typeof(Action<, , >),
		typeof(Action<, , , >),
		typeof(Action<, , , , >),
		typeof(Action<, , , , , >),
		typeof(Action<, , , , , , >),
		typeof(Action<, , , , , , , >),
		typeof(Action<, , , , , , , , >),
		typeof(Action<, , , , , , , , , >),
		typeof(Action<, , , , , , , , , , >),
		typeof(Action<, , , , , , , , , , , >),
		typeof(Action<, , , , , , , , , , , , >),
		typeof(Action<, , , , , , , , , , , , , >),
		typeof(Action<, , , , , , , , , , , , , , >),
		typeof(Action<, , , , , , , , , , , , , , , >)
	};

	private static readonly Type[] funcTemplates = new Type[17]
	{
		typeof(Func<>),
		typeof(Func<, >),
		typeof(Func<, , >),
		typeof(Func<, , , >),
		typeof(Func<, , , , >),
		typeof(Func<, , , , , >),
		typeof(Func<, , , , , , >),
		typeof(Func<, , , , , , , >),
		typeof(Func<, , , , , , , , >),
		typeof(Func<, , , , , , , , , >),
		typeof(Func<, , , , , , , , , , >),
		typeof(Func<, , , , , , , , , , , >),
		typeof(Func<, , , , , , , , , , , , >),
		typeof(Func<, , , , , , , , , , , , , >),
		typeof(Func<, , , , , , , , , , , , , , >),
		typeof(Func<, , , , , , , , , , , , , , , >),
		typeof(Func<, , , , , , , , , , , , , , , , >)
	};

	private static readonly Type[] procShimTemplates = new Type[17]
	{
		typeof(ProcShim<>),
		typeof(ProcShim<, >),
		typeof(ProcShim<, , >),
		typeof(ProcShim<, , , >),
		typeof(ProcShim<, , , , >),
		typeof(ProcShim<, , , , , >),
		typeof(ProcShim<, , , , , , >),
		typeof(ProcShim<, , , , , , , >),
		typeof(ProcShim<, , , , , , , , >),
		typeof(ProcShim<, , , , , , , , , >),
		typeof(ProcShim<, , , , , , , , , , >),
		typeof(ProcShim<, , , , , , , , , , , >),
		typeof(ProcShim<, , , , , , , , , , , , >),
		typeof(ProcShim<, , , , , , , , , , , , , >),
		typeof(ProcShim<, , , , , , , , , , , , , , >),
		typeof(ProcShim<, , , , , , , , , , , , , , , >),
		typeof(ProcShim<, , , , , , , , , , , , , , , , >)
	};

	private static readonly Type[] funcShimTemplates = new Type[17]
	{
		typeof(FuncShim<, >),
		typeof(FuncShim<, , >),
		typeof(FuncShim<, , , >),
		typeof(FuncShim<, , , , >),
		typeof(FuncShim<, , , , , >),
		typeof(FuncShim<, , , , , , >),
		typeof(FuncShim<, , , , , , , >),
		typeof(FuncShim<, , , , , , , , >),
		typeof(FuncShim<, , , , , , , , , >),
		typeof(FuncShim<, , , , , , , , , , >),
		typeof(FuncShim<, , , , , , , , , , , >),
		typeof(FuncShim<, , , , , , , , , , , , >),
		typeof(FuncShim<, , , , , , , , , , , , , >),
		typeof(FuncShim<, , , , , , , , , , , , , , >),
		typeof(FuncShim<, , , , , , , , , , , , , , , >),
		typeof(FuncShim<, , , , , , , , , , , , , , , , >),
		typeof(FuncShim<, , , , , , , , , , , , , , , , , >)
	};

	public static Delegate CreateProc(ScriptEngine engine, object target, int argCount)
	{
		if (argCount < 0 || argCount > 16)
		{
			throw new ArgumentException("Invalid argument count", "argCount");
		}
		Type[] typeArgs = Enumerable.Repeat(typeof(object), argCount).ToArray();
		return CreateDelegate(engine, target, procTemplates[argCount].MakeSpecificType(typeArgs));
	}

	public static Delegate CreateFunc<TResult>(ScriptEngine engine, object target, int argCount)
	{
		if (argCount < 0 || argCount > 16)
		{
			throw new ArgumentException("Invalid argument count", "argCount");
		}
		Type[] typeArgs = Enumerable.Repeat(typeof(object), argCount).Concat(typeof(TResult).ToEnumerable()).ToArray();
		return CreateDelegate(engine, target, funcTemplates[argCount].MakeSpecificType(typeArgs));
	}

	public static TDelegate CreateDelegate<TDelegate>(ScriptEngine engine, object target)
	{
		return (TDelegate)(object)CreateDelegate(engine, target, typeof(TDelegate));
	}

	public static Delegate CreateDelegate(ScriptEngine engine, object target, Type delegateType)
	{
		MiscHelpers.VerifyNonNullArgument(target, "target");
		if (!typeof(Delegate).IsAssignableFrom(delegateType))
		{
			throw new ArgumentException("Invalid delegate type");
		}
		MethodInfo method = delegateType.GetMethod("Invoke");
		if (method == null)
		{
			throw new ArgumentException("Invalid delegate type (invocation method not found)");
		}
		ParameterInfo[] parameters = method.GetParameters();
		if (parameters.Length > 16)
		{
			throw new ArgumentException("Invalid delegate type (parameter count too large)");
		}
		Type[] source = parameters.Select((ParameterInfo param) => param.ParameterType).ToArray();
		if (source.Any((Type paramType) => paramType.IsByRef))
		{
			return CreateComplexDelegate(engine, target, delegateType);
		}
		return CreateSimpleDelegate(engine, target, delegateType);
	}

	private static Delegate CreateSimpleDelegate(ScriptEngine engine, object target, Type delegateType)
	{
		MethodInfo method = delegateType.GetMethod("Invoke");
		Type[] array = (from param in method.GetParameters()
			select param.ParameterType).ToArray();
		Type type;
		if (method.ReturnType == typeof(void))
		{
			Type[] typeArgs = array.Concat(delegateType.ToEnumerable()).ToArray();
			type = procShimTemplates[array.Length].MakeSpecificType(typeArgs);
		}
		else
		{
			Type[] typeArgs2 = array.Concat(new Type[2] { method.ReturnType, delegateType }).ToArray();
			type = funcShimTemplates[array.Length].MakeSpecificType(typeArgs2);
		}
		DelegateShim delegateShim = (DelegateShim)type.CreateInstance(engine, target);
		return delegateShim.Delegate;
	}

	private static Delegate CreateComplexDelegate(ScriptEngine engine, object target, Type delegateType)
	{
		MethodInfo method = delegateType.GetMethod("Invoke");
		ParameterInfo[] parameters = method.GetParameters();
		Type[] array = parameters.Select((ParameterInfo param) => param.ParameterType).ToArray();
		Type[] array2 = new Type[parameters.Length];
		for (int num = 0; num < parameters.Length; num++)
		{
			Type type = array[num];
			if (parameters[num].IsOut)
			{
				array2[num] = typeof(OutArg<>).MakeSpecificType(type.GetElementType());
			}
			else if (type.IsByRef)
			{
				array2[num] = typeof(RefArg<>).MakeSpecificType(type.GetElementType());
			}
			else
			{
				array2[num] = type;
			}
		}
		Type delegateType2;
		if (method.ReturnType == typeof(void))
		{
			delegateType2 = procTemplates[array2.Length].MakeSpecificType(array2);
		}
		else
		{
			Type[] typeArgs = array2.Concat(method.ReturnType.ToEnumerable()).ToArray();
			delegateType2 = funcTemplates[array2.Length].MakeSpecificType(typeArgs);
		}
		ParameterExpression[] array3 = array.Select((Type paramType, int index) => Expression.Parameter(paramType, "a" + index)).ToArray();
		ParameterExpression[] array4 = array2.Select((Type paramType, int index) => Expression.Variable(paramType, "v" + index)).ToArray();
		List<Expression> list = new List<Expression>();
		for (int num2 = 0; num2 < array4.Length; num2++)
		{
			if (array[num2].IsByRef)
			{
				ConstructorInfo constructor = array2[num2].GetConstructor(new Type[1] { array[num2].GetElementType() });
				list.Add(Expression.Assign(array4[num2], Expression.New(constructor, array3[num2])));
			}
			else
			{
				list.Add(Expression.Assign(array4[num2], array3[num2]));
			}
		}
		Delegate value = CreateSimpleDelegate(engine, target, delegateType2);
		ConstantExpression expression = Expression.Constant(value);
		Expression[] arguments = array4;
		InvocationExpression body = Expression.Invoke(expression, arguments);
		List<Expression> list2 = new List<Expression>();
		for (int num3 = 0; num3 < array4.Length; num3++)
		{
			if (array[num3].IsByRef)
			{
				PropertyInfo property = array2[num3].GetProperty("Value");
				MemberExpression right = Expression.MakeMemberAccess(array4[num3], property);
				list2.Add(Expression.Assign(array3[num3], right));
			}
		}
		BlockExpression blockExpression = Expression.Block(list2);
		list.Add(Expression.TryFinally(body, blockExpression));
		BlockExpression body2 = Expression.Block(method.ReturnType, array4, list);
		return Expression.Lambda(delegateType, body2, array3).Compile();
	}
}
