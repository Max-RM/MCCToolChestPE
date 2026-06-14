using System;
using System.Dynamic;
using Microsoft.ClearScript.JavaScript;
using Microsoft.ClearScript.Util;

namespace Microsoft.ClearScript.V8;

internal class V8ScriptItem : ScriptItem, IDisposable
{
	private class V8ArrayBufferOrView : V8ScriptItem
	{
		private V8ArrayBufferOrViewInfo info;

		private IArrayBuffer arrayBuffer;

		protected IArrayBuffer ArrayBuffer => GetArrayBuffer();

		protected ulong Offset => GetInfo().Offset;

		protected ulong Size => GetInfo().Size;

		protected ulong Length => GetInfo().Length;

		protected V8ArrayBufferOrView(V8ScriptEngine engine, IV8Object target)
			: base(engine, target)
		{
		}

		protected byte[] GetBytes()
		{
			return engine.ScriptInvoke(delegate
			{
				byte[] result = new byte[Size];
				target.InvokeWithArrayBufferOrViewData(delegate(IntPtr pData)
				{
					UnmanagedMemoryHelpers.Copy(pData, Size, result, 0uL);
				});
				return result;
			});
		}

		protected ulong ReadBytes(ulong offset, ulong count, byte[] destination, ulong destinationIndex)
		{
			ulong size = Size;
			if (offset >= size)
			{
				throw new ArgumentOutOfRangeException("offset");
			}
			count = Math.Min(count, size - offset);
			return engine.ScriptInvoke(delegate
			{
				target.InvokeWithArrayBufferOrViewData(delegate(IntPtr pData)
				{
					count = UnmanagedMemoryHelpers.Copy(GetPtrWithOffset(pData, offset), count, destination, destinationIndex);
				});
				return count;
			});
		}

		protected ulong WriteBytes(byte[] source, ulong sourceIndex, ulong count, ulong offset)
		{
			ulong size = Size;
			if (offset >= size)
			{
				throw new ArgumentOutOfRangeException("offset");
			}
			count = Math.Min(count, size - offset);
			return engine.ScriptInvoke(delegate
			{
				target.InvokeWithArrayBufferOrViewData(delegate(IntPtr pData)
				{
					count = UnmanagedMemoryHelpers.Copy(source, sourceIndex, count, GetPtrWithOffset(pData, offset));
				});
				return count;
			});
		}

		private V8ArrayBufferOrViewInfo GetInfo()
		{
			VerifyNotDisposed();
			if (info == null)
			{
				engine.ScriptInvoke(delegate
				{
					if (info == null)
					{
						info = target.GetArrayBufferOrViewInfo();
					}
				});
			}
			return info;
		}

		private IArrayBuffer GetArrayBuffer()
		{
			if (arrayBuffer == null)
			{
				arrayBuffer = (IArrayBuffer)engine.MarshalToHost(GetInfo().ArrayBuffer, preserveHostTarget: false);
			}
			return arrayBuffer;
		}

		private static IntPtr GetPtrWithOffset(IntPtr pData, ulong offset)
		{
			ulong num = (ulong)pData.ToInt64();
			return new IntPtr((long)checked(num + offset));
		}
	}

	private sealed class V8ArrayBuffer : V8ArrayBufferOrView, IArrayBuffer
	{
		ulong IArrayBuffer.Size => base.Size;

		public V8ArrayBuffer(V8ScriptEngine engine, IV8Object target)
			: base(engine, target)
		{
		}

		byte[] IArrayBuffer.GetBytes()
		{
			return GetBytes();
		}

		ulong IArrayBuffer.ReadBytes(ulong offset, ulong count, byte[] destination, ulong destinationIndex)
		{
			return ReadBytes(offset, count, destination, destinationIndex);
		}

		ulong IArrayBuffer.WriteBytes(byte[] source, ulong sourceIndex, ulong count, ulong offset)
		{
			return WriteBytes(source, sourceIndex, count, offset);
		}
	}

	private class V8ArrayBufferView : V8ArrayBufferOrView, IArrayBufferView
	{
		IArrayBuffer IArrayBufferView.ArrayBuffer => base.ArrayBuffer;

		ulong IArrayBufferView.Offset => base.Offset;

		ulong IArrayBufferView.Size => base.Size;

		protected V8ArrayBufferView(V8ScriptEngine engine, IV8Object target)
			: base(engine, target)
		{
		}

		byte[] IArrayBufferView.GetBytes()
		{
			return GetBytes();
		}

		ulong IArrayBufferView.ReadBytes(ulong offset, ulong count, byte[] destination, ulong destinationIndex)
		{
			return ReadBytes(offset, count, destination, destinationIndex);
		}

		ulong IArrayBufferView.WriteBytes(byte[] source, ulong sourceIndex, ulong count, ulong offset)
		{
			return WriteBytes(source, sourceIndex, count, offset);
		}
	}

	private sealed class V8DataView : V8ArrayBufferView, IDataView, IArrayBufferView
	{
		public V8DataView(V8ScriptEngine engine, IV8Object target)
			: base(engine, target)
		{
		}
	}

	private class V8TypedArray : V8ArrayBufferView, ITypedArray, IArrayBufferView
	{
		ulong ITypedArray.Length => base.Length;

		protected V8TypedArray(V8ScriptEngine engine, IV8Object target)
			: base(engine, target)
		{
		}

		protected IntPtr GetPtrWithIndex(IntPtr pData, ulong index)
		{
			ulong num = (ulong)pData.ToInt64();
			return new IntPtr((long)checked(num + index * unchecked(base.Size / base.Length)));
		}
	}

	private class V8TypedArray<T> : V8TypedArray, ITypedArray<T>, ITypedArray, IArrayBufferView
	{
		public V8TypedArray(V8ScriptEngine engine, IV8Object target)
			: base(engine, target)
		{
		}

		T[] ITypedArray<T>.ToArray()
		{
			return engine.ScriptInvoke(delegate
			{
				T[] result = new T[base.Length];
				target.InvokeWithArrayBufferOrViewData(delegate(IntPtr pData)
				{
					UnmanagedMemoryHelpers.Copy(pData, base.Length, result, 0uL);
				});
				return result;
			});
		}

		ulong ITypedArray<T>.Read(ulong index, ulong length, T[] destination, ulong destinationIndex)
		{
			ulong length2 = base.Length;
			if (index >= length2)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			length = Math.Min(length, length2 - index);
			return engine.ScriptInvoke(delegate
			{
				target.InvokeWithArrayBufferOrViewData(delegate(IntPtr pData)
				{
					length = UnmanagedMemoryHelpers.Copy(GetPtrWithIndex(pData, index), length, destination, destinationIndex);
				});
				return length;
			});
		}

		ulong ITypedArray<T>.Write(T[] source, ulong sourceIndex, ulong length, ulong index)
		{
			ulong length2 = base.Length;
			if (index >= length2)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			length = Math.Min(length, length2 - index);
			return engine.ScriptInvoke(delegate
			{
				target.InvokeWithArrayBufferOrViewData(delegate(IntPtr pData)
				{
					length = UnmanagedMemoryHelpers.Copy(source, sourceIndex, length, GetPtrWithIndex(pData, index));
				});
				return length;
			});
		}
	}

	private sealed class V8UInt16Array : V8TypedArray<ushort>, ITypedArray<char>, ITypedArray, IArrayBufferView
	{
		public V8UInt16Array(V8ScriptEngine engine, IV8Object target)
			: base(engine, target)
		{
		}

		char[] ITypedArray<char>.ToArray()
		{
			return engine.ScriptInvoke(delegate
			{
				char[] result = new char[base.Length];
				target.InvokeWithArrayBufferOrViewData(delegate(IntPtr pData)
				{
					UnmanagedMemoryHelpers.Copy(pData, base.Length, result, 0uL);
				});
				return result;
			});
		}

		ulong ITypedArray<char>.Read(ulong index, ulong length, char[] destination, ulong destinationIndex)
		{
			ulong length2 = base.Length;
			if (index >= length2)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			length = Math.Min(length, length2 - index);
			return engine.ScriptInvoke(delegate
			{
				target.InvokeWithArrayBufferOrViewData(delegate(IntPtr pData)
				{
					length = UnmanagedMemoryHelpers.Copy(GetPtrWithIndex(pData, index), length, destination, destinationIndex);
				});
				return length;
			});
		}

		ulong ITypedArray<char>.Write(char[] source, ulong sourceIndex, ulong length, ulong index)
		{
			ulong length2 = base.Length;
			if (index >= length2)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			length = Math.Min(length, length2 - index);
			return engine.ScriptInvoke(delegate
			{
				target.InvokeWithArrayBufferOrViewData(delegate(IntPtr pData)
				{
					length = UnmanagedMemoryHelpers.Copy(source, sourceIndex, length, GetPtrWithIndex(pData, index));
				});
				return length;
			});
		}
	}

	private readonly V8ScriptEngine engine;

	private readonly IV8Object target;

	private V8ScriptItem holder;

	private readonly InterlockedOneWayFlag disposedFlag = new InterlockedOneWayFlag();

	public override ScriptEngine Engine => engine;

	private V8ScriptItem(V8ScriptEngine engine, IV8Object target)
	{
		this.engine = engine;
		this.target = target;
	}

	public static object Wrap(V8ScriptEngine engine, object obj)
	{
		if (obj == null)
		{
			return null;
		}
		if (obj is IV8Object iV8Object)
		{
			if (!iV8Object.IsArrayBufferOrView())
			{
				return new V8ScriptItem(engine, iV8Object);
			}
			switch (iV8Object.GetArrayBufferOrViewKind())
			{
			case V8ArrayBufferOrViewKind.ArrayBuffer:
				return new V8ArrayBuffer(engine, iV8Object);
			case V8ArrayBufferOrViewKind.DataView:
				return new V8DataView(engine, iV8Object);
			case V8ArrayBufferOrViewKind.Uint8Array:
			case V8ArrayBufferOrViewKind.Uint8ClampedArray:
				return new V8TypedArray<byte>(engine, iV8Object);
			case V8ArrayBufferOrViewKind.Int8Array:
				return new V8TypedArray<sbyte>(engine, iV8Object);
			case V8ArrayBufferOrViewKind.Uint16Array:
				return new V8UInt16Array(engine, iV8Object);
			case V8ArrayBufferOrViewKind.Int16Array:
				return new V8TypedArray<short>(engine, iV8Object);
			case V8ArrayBufferOrViewKind.Uint32Array:
				return new V8TypedArray<uint>(engine, iV8Object);
			case V8ArrayBufferOrViewKind.Int32Array:
				return new V8TypedArray<int>(engine, iV8Object);
			case V8ArrayBufferOrViewKind.Float32Array:
				return new V8TypedArray<float>(engine, iV8Object);
			case V8ArrayBufferOrViewKind.Float64Array:
				return new V8TypedArray<double>(engine, iV8Object);
			default:
				return new V8ScriptItem(engine, iV8Object);
			}
		}
		return obj;
	}

	private void VerifyNotDisposed()
	{
		if (disposedFlag.IsSet)
		{
			throw new ObjectDisposedException(ToString());
		}
	}

	protected override bool TryBindAndInvoke(DynamicMetaObjectBinder binder, object[] args, out object result)
	{
		VerifyNotDisposed();
		try
		{
			if (binder is GetMemberBinder getMemberBinder)
			{
				result = target.GetProperty(getMemberBinder.Name);
				return true;
			}
			if (binder is SetMemberBinder setMemberBinder && args != null && args.Length != 0)
			{
				target.SetProperty(setMemberBinder.Name, args[0]);
				result = args[0];
				return true;
			}
			if (binder is GetIndexBinder)
			{
				if (args != null && args.Length == 1)
				{
					if (MiscHelpers.TryGetNumericIndex(args[0], out int index))
					{
						result = target.GetProperty(index);
					}
					else
					{
						result = target.GetProperty(args[0].ToString());
					}
					return true;
				}
				throw new InvalidOperationException("Invalid argument or index count");
			}
			if (binder is SetIndexBinder)
			{
				if (args != null && args.Length == 2)
				{
					if (MiscHelpers.TryGetNumericIndex(args[0], out int index2))
					{
						target.SetProperty(index2, args[1]);
					}
					else
					{
						target.SetProperty(args[0].ToString(), args[1]);
					}
					result = args[1];
					return true;
				}
				throw new InvalidOperationException("Invalid argument or index count");
			}
			if (binder is InvokeBinder)
			{
				result = target.Invoke(asConstructor: false, args);
				return true;
			}
			if (binder is InvokeMemberBinder invokeMemberBinder)
			{
				result = target.InvokeMethod(invokeMemberBinder.Name, args);
				return true;
			}
		}
		catch (Exception ex)
		{
			if (engine.CurrentScriptFrame != null)
			{
				if (ex is IScriptEngineException ex2)
				{
					if (ex2.ExecutionStarted)
					{
						throw;
					}
					engine.CurrentScriptFrame.ScriptError = ex2;
				}
				else
				{
					engine.CurrentScriptFrame.ScriptError = new ScriptEngineException(engine.Name, ex.Message, null, RawCOMHelpers.HResult.CLEARSCRIPT_E_SCRIPTITEMEXCEPTION, isFatal: false, executionStarted: false, null, ex);
				}
			}
		}
		result = null;
		return false;
	}

	public override string[] GetPropertyNames()
	{
		VerifyNotDisposed();
		return engine.ScriptInvoke(() => target.GetPropertyNames());
	}

	public override int[] GetPropertyIndices()
	{
		VerifyNotDisposed();
		return engine.ScriptInvoke(() => target.GetPropertyIndices());
	}

	public override object GetProperty(string name, params object[] args)
	{
		VerifyNotDisposed();
		if (args != null && args.Length != 0)
		{
			throw new InvalidOperationException("Invalid argument or index count");
		}
		object obj = engine.MarshalToHost(engine.ScriptInvoke(() => target.GetProperty(name)), preserveHostTarget: false);
		if (obj is V8ScriptItem v8ScriptItem && v8ScriptItem.engine == engine)
		{
			v8ScriptItem.holder = this;
		}
		return obj;
	}

	public override void SetProperty(string name, params object[] args)
	{
		VerifyNotDisposed();
		if (args == null || args.Length != 1)
		{
			throw new InvalidOperationException("Invalid argument or index count");
		}
		engine.ScriptInvoke(delegate
		{
			target.SetProperty(name, engine.MarshalToScript(args[0]));
		});
	}

	public override bool DeleteProperty(string name)
	{
		VerifyNotDisposed();
		return engine.ScriptInvoke(() => target.DeleteProperty(name));
	}

	public override object GetProperty(int index)
	{
		VerifyNotDisposed();
		return engine.MarshalToHost(engine.ScriptInvoke(() => target.GetProperty(index)), preserveHostTarget: false);
	}

	public override void SetProperty(int index, object value)
	{
		VerifyNotDisposed();
		engine.ScriptInvoke(delegate
		{
			target.SetProperty(index, engine.MarshalToScript(value));
		});
	}

	public override bool DeleteProperty(int index)
	{
		VerifyNotDisposed();
		return engine.ScriptInvoke(() => target.DeleteProperty(index));
	}

	public override object Invoke(bool asConstructor, params object[] args)
	{
		VerifyNotDisposed();
		if (asConstructor || holder == null)
		{
			return engine.MarshalToHost(engine.ScriptInvoke(() => target.Invoke(asConstructor, engine.MarshalToScript(args))), preserveHostTarget: false);
		}
		return engine.Script.EngineInternal.invokeMethod(holder, this, args);
	}

	public override object InvokeMethod(string name, params object[] args)
	{
		VerifyNotDisposed();
		return engine.MarshalToHost(engine.ScriptInvoke(() => target.InvokeMethod(name, engine.MarshalToScript(args))), preserveHostTarget: false);
	}

	public override object Unwrap()
	{
		return target;
	}

	public void Dispose()
	{
		if (disposedFlag.Set())
		{
			target.Dispose();
		}
	}
}
