using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace Microsoft.ClearScript.Util;

internal static class MemberMap
{
	private sealed class Field : FieldInfo
	{
		private readonly string name;

		public override FieldAttributes Attributes => FieldAttributes.Public;

		public override RuntimeFieldHandle FieldHandle
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public override Type FieldType => typeof(object);

		public override Type DeclaringType => typeof(object);

		public override string Name => name;

		public override Type ReflectedType
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public Field(string name)
		{
			this.name = name;
		}

		public override object GetValue(object obj)
		{
			if (obj is IReflect reflect)
			{
				return reflect.InvokeMember(name, BindingFlags.GetField, null, obj, ArrayHelpers.GetEmptyArray<object>(), null, CultureInfo.InvariantCulture, null);
			}
			throw new InvalidOperationException("Invalid field retrieval");
		}

		public override void SetValue(object obj, object value, BindingFlags invokeFlags, Binder binder, CultureInfo culture)
		{
			if (obj is IReflect reflect)
			{
				reflect.InvokeMember(name, BindingFlags.SetField, null, obj, new object[1] { value }, null, culture, null);
				return;
			}
			throw new InvalidOperationException("Invalid field assignment");
		}

		public override object[] GetCustomAttributes(Type attributeType, bool inherit)
		{
			return ArrayHelpers.GetEmptyArray<object>();
		}

		public override object[] GetCustomAttributes(bool inherit)
		{
			throw new NotImplementedException();
		}

		public override bool IsDefined(Type attributeType, bool inherit)
		{
			throw new NotImplementedException();
		}
	}

	private sealed class Method : MethodInfo
	{
		private readonly string name;

		public override ICustomAttributeProvider ReturnTypeCustomAttributes
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public override MethodAttributes Attributes
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public override RuntimeMethodHandle MethodHandle
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public override Type DeclaringType
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public override string Name => name;

		public override Type ReflectedType
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public Method(string name)
		{
			this.name = name;
		}

		public override MethodInfo GetBaseDefinition()
		{
			throw new NotImplementedException();
		}

		public override MethodImplAttributes GetMethodImplementationFlags()
		{
			throw new NotImplementedException();
		}

		public override ParameterInfo[] GetParameters()
		{
			return ArrayHelpers.GetEmptyArray<ParameterInfo>();
		}

		public override object Invoke(object obj, BindingFlags invokeFlags, Binder binder, object[] args, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		public override object[] GetCustomAttributes(Type attributeType, bool inherit)
		{
			return ArrayHelpers.GetEmptyArray<object>();
		}

		public override object[] GetCustomAttributes(bool inherit)
		{
			throw new NotImplementedException();
		}

		public override bool IsDefined(Type attributeType, bool inherit)
		{
			throw new NotImplementedException();
		}
	}

	private sealed class Property : PropertyInfo
	{
		private readonly string name;

		public override PropertyAttributes Attributes
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public override bool CanRead
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public override bool CanWrite
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public override Type PropertyType
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public override Type DeclaringType
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public override string Name => name;

		public override Type ReflectedType
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public Property(string name)
		{
			this.name = name;
		}

		public override MethodInfo[] GetAccessors(bool nonPublic)
		{
			throw new NotImplementedException();
		}

		public override MethodInfo GetGetMethod(bool nonPublic)
		{
			throw new NotImplementedException();
		}

		public override ParameterInfo[] GetIndexParameters()
		{
			return ArrayHelpers.GetEmptyArray<ParameterInfo>();
		}

		public override MethodInfo GetSetMethod(bool nonPublic)
		{
			throw new NotImplementedException();
		}

		public override object GetValue(object obj, BindingFlags invokeFlags, Binder binder, object[] index, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		public override void SetValue(object obj, object value, BindingFlags invokeFlags, Binder binder, object[] index, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		public override object[] GetCustomAttributes(Type attributeType, bool inherit)
		{
			return ArrayHelpers.GetEmptyArray<object>();
		}

		public override object[] GetCustomAttributes(bool inherit)
		{
			throw new NotImplementedException();
		}

		public override bool IsDefined(Type attributeType, bool inherit)
		{
			throw new NotImplementedException();
		}
	}

	private class MemberMapBase
	{
		protected const int CompactionThreshold = 1048576;

		protected static readonly TimeSpan CompactionInterval = TimeSpan.FromMinutes(5.0);
	}

	private sealed class MemberMapImpl<T> : MemberMapBase where T : MemberInfo
	{
		private readonly object dataLock = new object();

		private readonly Dictionary<string, WeakReference> map = new Dictionary<string, WeakReference>();

		private DateTime lastCompactionTime = DateTime.MinValue;

		public T GetMember(string name)
		{
			lock (dataLock)
			{
				T memberInternal = GetMemberInternal(name);
				CompactIfNecessary();
				return memberInternal;
			}
		}

		public T[] GetMembers(string[] names)
		{
			lock (dataLock)
			{
				T[] result = names.Select(GetMemberInternal).ToArray();
				CompactIfNecessary();
				return result;
			}
		}

		private T GetMemberInternal(string name)
		{
			T val;
			if (map.TryGetValue(name, out var value))
			{
				val = value.Target as T;
				if (val == null)
				{
					Type typeFromHandle = typeof(T);
					object[] args = new object[1] { name };
					val = (T)(value.Target = (T)typeFromHandle.CreateInstance(args));
				}
			}
			else
			{
				val = (T)typeof(T).CreateInstance(name);
				map.Add(name, new WeakReference(val));
			}
			return val;
		}

		private void CompactIfNecessary()
		{
			if (map.Count < 1048576)
			{
				return;
			}
			DateTime utcNow = DateTime.UtcNow;
			if (lastCompactionTime + MemberMapBase.CompactionInterval <= utcNow)
			{
				map.Where((KeyValuePair<string, WeakReference> pair) => !pair.Value.IsAlive).ToList().ForEach(delegate(KeyValuePair<string, WeakReference> pair)
				{
					map.Remove(pair.Key);
				});
				lastCompactionTime = utcNow;
			}
		}
	}

	private static readonly MemberMapImpl<Field> fieldMap = new MemberMapImpl<Field>();

	private static readonly MemberMapImpl<Method> methodMap = new MemberMapImpl<Method>();

	private static readonly MemberMapImpl<Property> propertyMap = new MemberMapImpl<Property>();

	public static FieldInfo GetField(string name)
	{
		return fieldMap.GetMember(name);
	}

	public static FieldInfo[] GetFields(string[] names)
	{
		return fieldMap.GetMembers(names);
	}

	public static MethodInfo GetMethod(string name)
	{
		return methodMap.GetMember(name);
	}

	public static MethodInfo[] GetMethods(string[] names)
	{
		return methodMap.GetMembers(names);
	}

	public static PropertyInfo GetProperty(string name)
	{
		return propertyMap.GetMember(name);
	}

	public static PropertyInfo[] GetProperties(string[] names)
	{
		return propertyMap.GetMembers(names);
	}
}
