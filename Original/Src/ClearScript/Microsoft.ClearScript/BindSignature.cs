using System;
using System.Reflection;

namespace Microsoft.ClearScript;

internal sealed class BindSignature : IEquatable<BindSignature>
{
	private enum TargetKind
	{
		Static,
		Null,
		Instance
	}

	private sealed class TargetInfo : IEquatable<TargetInfo>
	{
		private readonly TargetKind kind;

		private readonly Type targetType;

		private readonly Type instanceType;

		public TargetInfo(HostTarget target)
		{
			if (target is HostType)
			{
				kind = TargetKind.Static;
				targetType = target.Type;
				return;
			}
			if (target.InvokeTarget == null)
			{
				kind = TargetKind.Null;
				targetType = target.Type;
				return;
			}
			kind = TargetKind.Instance;
			targetType = target.Type;
			Type type = target.InvokeTarget.GetType();
			if (type != targetType)
			{
				instanceType = type;
			}
		}

		public void UpdateHash(ref HashAccumulator accumulator)
		{
			accumulator.Update((int)kind);
			accumulator.Update(targetType);
			accumulator.Update(instanceType);
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as TargetInfo);
		}

		public override int GetHashCode()
		{
			HashAccumulator accumulator = default(HashAccumulator);
			UpdateHash(ref accumulator);
			return accumulator.HashCode;
		}

		public bool Equals(TargetInfo that)
		{
			if (that != null && kind == that.kind && targetType == that.targetType)
			{
				return instanceType == that.instanceType;
			}
			return false;
		}
	}

	private enum ArgKind
	{
		Null,
		ByValue,
		Out,
		Ref
	}

	private sealed class ArgInfo : IEquatable<ArgInfo>
	{
		private readonly ArgKind kind;

		private readonly Type type;

		public ArgInfo(object arg)
		{
			if (arg == null)
			{
				kind = ArgKind.Null;
			}
			else if (arg is IOutArg outArg)
			{
				kind = ArgKind.Out;
				type = outArg.Type;
			}
			else if (arg is IRefArg refArg)
			{
				kind = ArgKind.Ref;
				type = refArg.Type;
			}
			else if (arg is HostType)
			{
				kind = ArgKind.ByValue;
				type = typeof(HostType);
			}
			else if (arg is HostMethod)
			{
				kind = ArgKind.ByValue;
				type = typeof(HostMethod);
			}
			else if (arg is HostIndexedProperty)
			{
				kind = ArgKind.ByValue;
				type = typeof(HostIndexedProperty);
			}
			else if (arg is ScriptMethod)
			{
				kind = ArgKind.ByValue;
				type = typeof(ScriptMethod);
			}
			else if (arg is HostTarget hostTarget)
			{
				kind = ArgKind.ByValue;
				type = hostTarget.Type;
			}
			else
			{
				kind = ArgKind.ByValue;
				type = arg.GetType();
			}
		}

		public void UpdateHash(ref HashAccumulator accumulator)
		{
			accumulator.Update((int)kind);
			accumulator.Update(type);
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as ArgInfo);
		}

		public override int GetHashCode()
		{
			HashAccumulator accumulator = default(HashAccumulator);
			UpdateHash(ref accumulator);
			return accumulator.HashCode;
		}

		public bool Equals(ArgInfo that)
		{
			if (that != null && kind == that.kind)
			{
				return type == that.type;
			}
			return false;
		}
	}

	private struct HashAccumulator
	{
		public int HashCode { get; private set; }

		public void Update(int value)
		{
			HashCode = HashCode * 31 + value;
		}

		public void Update(object obj)
		{
			HashCode = HashCode * 31 + (obj?.GetHashCode() ?? 0);
		}
	}

	private readonly Type context;

	private readonly BindingFlags flags;

	private readonly TargetInfo targetInfo;

	private readonly string name;

	private readonly Type[] typeArgs;

	private readonly ArgInfo[] argData;

	public BindSignature(Type context, BindingFlags flags, HostTarget target, string name, Type[] typeArgs, object[] args)
	{
		this.context = context;
		this.flags = flags;
		targetInfo = new TargetInfo(target);
		this.name = name;
		this.typeArgs = typeArgs;
		argData = new ArgInfo[args.Length];
		for (int i = 0; i < args.Length; i++)
		{
			argData[i] = new ArgInfo(args[i]);
		}
	}

	public override bool Equals(object obj)
	{
		return Equals(obj as BindSignature);
	}

	public override int GetHashCode()
	{
		HashAccumulator accumulator = default(HashAccumulator);
		accumulator.Update(context);
		accumulator.Update((int)flags);
		targetInfo.UpdateHash(ref accumulator);
		accumulator.Update(name);
		Type[] array = typeArgs;
		foreach (Type obj in array)
		{
			accumulator.Update(obj);
		}
		ArgInfo[] array2 = argData;
		foreach (ArgInfo argInfo in array2)
		{
			argInfo.UpdateHash(ref accumulator);
		}
		return accumulator.HashCode;
	}

	public bool Equals(BindSignature that)
	{
		if (that == null)
		{
			return false;
		}
		if (context != that.context)
		{
			return false;
		}
		if (flags != that.flags)
		{
			return false;
		}
		if (!targetInfo.Equals(that.targetInfo))
		{
			return false;
		}
		if (name != that.name)
		{
			return false;
		}
		if (typeArgs.Length != that.typeArgs.Length)
		{
			return false;
		}
		for (int i = 0; i < typeArgs.Length; i++)
		{
			if (typeArgs[i] != that.typeArgs[i])
			{
				return false;
			}
		}
		if (argData.Length != that.argData.Length)
		{
			return false;
		}
		for (int j = 0; j < argData.Length; j++)
		{
			if (!argData[j].Equals(that.argData[j]))
			{
				return false;
			}
		}
		return true;
	}
}
