using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Microsoft.ClearScript.Util;

internal static class UnmanagedMemoryHelpers
{
	private delegate ulong ReadArrayFromUnmanagedMemoryHandler(IntPtr pSource, ulong length, Array destinationArray, ulong destinationIndex);

	private delegate ulong WriteArrayToUnmanagedMemoryHandler(Array sourceArray, ulong sourceIndex, ulong length, IntPtr pDestination);

	private static readonly Dictionary<Type, ReadArrayFromUnmanagedMemoryHandler> readArrayFromUnmanagedMemoryHandlerMap = new Dictionary<Type, ReadArrayFromUnmanagedMemoryHandler>
	{
		{
			typeof(byte),
			ReadByteArrayFromUnmanagedMemory
		},
		{
			typeof(sbyte),
			ReadSByteArrayFromUnmanagedMemory
		},
		{
			typeof(ushort),
			ReadUInt16ArrayFromUnmanagedMemory
		},
		{
			typeof(char),
			ReadCharArrayFromUnmanagedMemory
		},
		{
			typeof(short),
			ReadInt16ArrayFromUnmanagedMemory
		},
		{
			typeof(uint),
			ReadUInt32ArrayFromUnmanagedMemory
		},
		{
			typeof(int),
			ReadInt32ArrayFromUnmanagedMemory
		},
		{
			typeof(float),
			ReadSingleArrayFromUnmanagedMemory
		},
		{
			typeof(double),
			ReadDoubleArrayFromUnmanagedMemory
		}
	};

	private static readonly Dictionary<Type, WriteArrayToUnmanagedMemoryHandler> writeArrayToUnmanagedMemoryHandlerMap = new Dictionary<Type, WriteArrayToUnmanagedMemoryHandler>
	{
		{
			typeof(byte),
			WriteByteArrayToUnmanagedMemory
		},
		{
			typeof(sbyte),
			WriteSByteArrayToUnmanagedMemory
		},
		{
			typeof(ushort),
			WriteUInt16ArrayToUnmanagedMemory
		},
		{
			typeof(char),
			WriteCharArrayToUnmanagedMemory
		},
		{
			typeof(short),
			WriteInt16ArrayToUnmanagedMemory
		},
		{
			typeof(uint),
			WriteUInt32ArrayToUnmanagedMemory
		},
		{
			typeof(int),
			WriteInt32ArrayToUnmanagedMemory
		},
		{
			typeof(float),
			WriteSingleArrayToUnmanagedMemory
		},
		{
			typeof(double),
			WriteDoubleArrayToUnmanagedMemory
		}
	};

	internal static bool DisableMarshalCopy;

	public static ulong Copy<T>(IntPtr pSource, ulong length, T[] destination, ulong destinationIndex)
	{
		return Copy(typeof(T), pSource, length, destination, destinationIndex);
	}

	public static ulong Copy<T>(T[] source, ulong sourceIndex, ulong length, IntPtr pDestination)
	{
		return Copy(typeof(T), source, sourceIndex, length, pDestination);
	}

	private static ulong Copy(Type type, IntPtr pSource, ulong length, Array destinationArray, ulong destinationIndex)
	{
		if (readArrayFromUnmanagedMemoryHandlerMap.TryGetValue(type, out var value))
		{
			return value(pSource, length, destinationArray, destinationIndex);
		}
		throw new NotSupportedException("Unsupported unmanaged data transfer operation");
	}

	private static ulong Copy(Type type, Array sourceArray, ulong sourceIndex, ulong length, IntPtr pDestination)
	{
		if (writeArrayToUnmanagedMemoryHandlerMap.TryGetValue(type, out var value))
		{
			return value(sourceArray, sourceIndex, length, pDestination);
		}
		throw new NotSupportedException("Unsupported unmanaged data transfer operation");
	}

	private unsafe static ulong ReadByteArrayFromUnmanagedMemory(IntPtr pSource, ulong length, Array destinationArray, ulong destinationIndex)
	{
		ulong longLength = (ulong)destinationArray.LongLength;
		if (destinationIndex >= longLength)
		{
			throw new ArgumentOutOfRangeException("destinationIndex");
		}
		byte[] array = (byte[])destinationArray;
		length = Math.Min(length, longLength - destinationIndex);
		try
		{
			VerifyMarshalCopyEnabled();
			Marshal.Copy(pSource, array, Convert.ToInt32(destinationIndex), Convert.ToInt32(length));
		}
		catch (OverflowException)
		{
			fixed (byte* ptr = array)
			{
				byte* ptr2 = (byte*)(void*)pSource;
				for (ulong num = 0uL; num < length; num++)
				{
					ptr[destinationIndex + num] = ptr2[num];
				}
			}
		}
		return length;
	}

	private unsafe static ulong ReadSByteArrayFromUnmanagedMemory(IntPtr pSource, ulong length, Array destinationArray, ulong destinationIndex)
	{
		ulong longLength = (ulong)destinationArray.LongLength;
		if (destinationIndex >= longLength)
		{
			throw new ArgumentOutOfRangeException("destinationIndex");
		}
		sbyte[] array = (sbyte[])destinationArray;
		length = Math.Min(length, longLength - destinationIndex);
		fixed (sbyte* ptr = array)
		{
			sbyte* ptr2 = (sbyte*)(void*)pSource;
			for (ulong num = 0uL; num < length; num++)
			{
				ptr[destinationIndex + num] = ptr2[num];
			}
		}
		return length;
	}

	private unsafe static ulong ReadUInt16ArrayFromUnmanagedMemory(IntPtr pSource, ulong length, Array destinationArray, ulong destinationIndex)
	{
		ulong longLength = (ulong)destinationArray.LongLength;
		if (destinationIndex >= longLength)
		{
			throw new ArgumentOutOfRangeException("destinationIndex");
		}
		ushort[] array = (ushort[])destinationArray;
		length = Math.Min(length, longLength - destinationIndex);
		fixed (ushort* ptr = array)
		{
			ushort* ptr2 = (ushort*)(void*)pSource;
			for (ulong num = 0uL; num < length; num++)
			{
				ptr[destinationIndex + num] = ptr2[num];
			}
		}
		return length;
	}

	private unsafe static ulong ReadCharArrayFromUnmanagedMemory(IntPtr pSource, ulong length, Array destinationArray, ulong destinationIndex)
	{
		ulong longLength = (ulong)destinationArray.LongLength;
		if (destinationIndex >= longLength)
		{
			throw new ArgumentOutOfRangeException("destinationIndex");
		}
		char[] array = (char[])destinationArray;
		length = Math.Min(length, longLength - destinationIndex);
		try
		{
			VerifyMarshalCopyEnabled();
			Marshal.Copy(pSource, array, Convert.ToInt32(destinationIndex), Convert.ToInt32(length));
		}
		catch (OverflowException)
		{
			fixed (char* ptr = array)
			{
				char* ptr2 = (char*)(void*)pSource;
				for (ulong num = 0uL; num < length; num++)
				{
					ptr[destinationIndex + num] = ptr2[num];
				}
			}
		}
		return length;
	}

	private unsafe static ulong ReadInt16ArrayFromUnmanagedMemory(IntPtr pSource, ulong length, Array destinationArray, ulong destinationIndex)
	{
		ulong longLength = (ulong)destinationArray.LongLength;
		if (destinationIndex >= longLength)
		{
			throw new ArgumentOutOfRangeException("destinationIndex");
		}
		short[] array = (short[])destinationArray;
		length = Math.Min(length, longLength - destinationIndex);
		try
		{
			VerifyMarshalCopyEnabled();
			Marshal.Copy(pSource, array, Convert.ToInt32(destinationIndex), Convert.ToInt32(length));
		}
		catch (OverflowException)
		{
			fixed (short* ptr = array)
			{
				short* ptr2 = (short*)(void*)pSource;
				for (ulong num = 0uL; num < length; num++)
				{
					ptr[destinationIndex + num] = ptr2[num];
				}
			}
		}
		return length;
	}

	private unsafe static ulong ReadUInt32ArrayFromUnmanagedMemory(IntPtr pSource, ulong length, Array destinationArray, ulong destinationIndex)
	{
		ulong longLength = (ulong)destinationArray.LongLength;
		if (destinationIndex >= longLength)
		{
			throw new ArgumentOutOfRangeException("destinationIndex");
		}
		uint[] array = (uint[])destinationArray;
		length = Math.Min(length, longLength - destinationIndex);
		fixed (uint* ptr = array)
		{
			uint* ptr2 = (uint*)(void*)pSource;
			for (ulong num = 0uL; num < length; num++)
			{
				ptr[destinationIndex + num] = ptr2[num];
			}
		}
		return length;
	}

	private unsafe static ulong ReadInt32ArrayFromUnmanagedMemory(IntPtr pSource, ulong length, Array destinationArray, ulong destinationIndex)
	{
		ulong longLength = (ulong)destinationArray.LongLength;
		if (destinationIndex >= longLength)
		{
			throw new ArgumentOutOfRangeException("destinationIndex");
		}
		int[] array = (int[])destinationArray;
		length = Math.Min(length, longLength - destinationIndex);
		try
		{
			VerifyMarshalCopyEnabled();
			Marshal.Copy(pSource, array, Convert.ToInt32(destinationIndex), Convert.ToInt32(length));
		}
		catch (OverflowException)
		{
			fixed (int* ptr = array)
			{
				int* ptr2 = (int*)(void*)pSource;
				for (ulong num = 0uL; num < length; num++)
				{
					ptr[destinationIndex + num] = ptr2[num];
				}
			}
		}
		return length;
	}

	private unsafe static ulong ReadSingleArrayFromUnmanagedMemory(IntPtr pSource, ulong length, Array destinationArray, ulong destinationIndex)
	{
		ulong longLength = (ulong)destinationArray.LongLength;
		if (destinationIndex >= longLength)
		{
			throw new ArgumentOutOfRangeException("destinationIndex");
		}
		float[] array = (float[])destinationArray;
		length = Math.Min(length, longLength - destinationIndex);
		try
		{
			VerifyMarshalCopyEnabled();
			Marshal.Copy(pSource, array, Convert.ToInt32(destinationIndex), Convert.ToInt32(length));
		}
		catch (OverflowException)
		{
			fixed (float* ptr = array)
			{
				float* ptr2 = (float*)(void*)pSource;
				for (ulong num = 0uL; num < length; num++)
				{
					ptr[destinationIndex + num] = ptr2[num];
				}
			}
		}
		return length;
	}

	private unsafe static ulong ReadDoubleArrayFromUnmanagedMemory(IntPtr pSource, ulong length, Array destinationArray, ulong destinationIndex)
	{
		ulong longLength = (ulong)destinationArray.LongLength;
		if (destinationIndex >= longLength)
		{
			throw new ArgumentOutOfRangeException("destinationIndex");
		}
		double[] array = (double[])destinationArray;
		length = Math.Min(length, longLength - destinationIndex);
		try
		{
			VerifyMarshalCopyEnabled();
			Marshal.Copy(pSource, array, Convert.ToInt32(destinationIndex), Convert.ToInt32(length));
		}
		catch (OverflowException)
		{
			fixed (double* ptr = array)
			{
				double* ptr2 = (double*)(void*)pSource;
				for (ulong num = 0uL; num < length; num++)
				{
					ptr[destinationIndex + num] = ptr2[num];
				}
			}
		}
		return length;
	}

	private unsafe static ulong WriteByteArrayToUnmanagedMemory(Array sourceArray, ulong sourceIndex, ulong length, IntPtr pDestination)
	{
		ulong longLength = (ulong)sourceArray.LongLength;
		if (sourceIndex >= longLength)
		{
			throw new ArgumentOutOfRangeException("sourceIndex");
		}
		byte[] array = (byte[])sourceArray;
		length = Math.Min(length, longLength - sourceIndex);
		try
		{
			VerifyMarshalCopyEnabled();
			Marshal.Copy(array, Convert.ToInt32(sourceIndex), pDestination, Convert.ToInt32(length));
		}
		catch (OverflowException)
		{
			fixed (byte* ptr = array)
			{
				byte* ptr2 = (byte*)(void*)pDestination;
				for (ulong num = 0uL; num < length; num++)
				{
					ptr2[num] = ptr[sourceIndex + num];
				}
			}
		}
		return length;
	}

	private unsafe static ulong WriteSByteArrayToUnmanagedMemory(Array sourceArray, ulong sourceIndex, ulong length, IntPtr pDestination)
	{
		ulong longLength = (ulong)sourceArray.LongLength;
		if (sourceIndex >= longLength)
		{
			throw new ArgumentOutOfRangeException("sourceIndex");
		}
		sbyte[] array = (sbyte[])sourceArray;
		length = Math.Min(length, longLength - sourceIndex);
		fixed (sbyte* ptr = array)
		{
			sbyte* ptr2 = (sbyte*)(void*)pDestination;
			for (ulong num = 0uL; num < length; num++)
			{
				ptr2[num] = ptr[sourceIndex + num];
			}
		}
		return length;
	}

	private unsafe static ulong WriteUInt16ArrayToUnmanagedMemory(Array sourceArray, ulong sourceIndex, ulong length, IntPtr pDestination)
	{
		ulong longLength = (ulong)sourceArray.LongLength;
		if (sourceIndex >= longLength)
		{
			throw new ArgumentOutOfRangeException("sourceIndex");
		}
		ushort[] array = (ushort[])sourceArray;
		length = Math.Min(length, longLength - sourceIndex);
		fixed (ushort* ptr = array)
		{
			ushort* ptr2 = (ushort*)(void*)pDestination;
			for (ulong num = 0uL; num < length; num++)
			{
				ptr2[num] = ptr[sourceIndex + num];
			}
		}
		return length;
	}

	private unsafe static ulong WriteCharArrayToUnmanagedMemory(Array sourceArray, ulong sourceIndex, ulong length, IntPtr pDestination)
	{
		ulong longLength = (ulong)sourceArray.LongLength;
		if (sourceIndex >= longLength)
		{
			throw new ArgumentOutOfRangeException("sourceIndex");
		}
		char[] array = (char[])sourceArray;
		length = Math.Min(length, longLength - sourceIndex);
		try
		{
			VerifyMarshalCopyEnabled();
			Marshal.Copy(array, Convert.ToInt32(sourceIndex), pDestination, Convert.ToInt32(length));
		}
		catch (OverflowException)
		{
			fixed (char* ptr = array)
			{
				char* ptr2 = (char*)(void*)pDestination;
				for (ulong num = 0uL; num < length; num++)
				{
					ptr2[num] = ptr[sourceIndex + num];
				}
			}
		}
		return length;
	}

	private unsafe static ulong WriteInt16ArrayToUnmanagedMemory(Array sourceArray, ulong sourceIndex, ulong length, IntPtr pDestination)
	{
		ulong longLength = (ulong)sourceArray.LongLength;
		if (sourceIndex >= longLength)
		{
			throw new ArgumentOutOfRangeException("sourceIndex");
		}
		short[] array = (short[])sourceArray;
		length = Math.Min(length, longLength - sourceIndex);
		try
		{
			VerifyMarshalCopyEnabled();
			Marshal.Copy(array, Convert.ToInt32(sourceIndex), pDestination, Convert.ToInt32(length));
		}
		catch (OverflowException)
		{
			fixed (short* ptr = array)
			{
				short* ptr2 = (short*)(void*)pDestination;
				for (ulong num = 0uL; num < length; num++)
				{
					ptr2[num] = ptr[sourceIndex + num];
				}
			}
		}
		return length;
	}

	private unsafe static ulong WriteUInt32ArrayToUnmanagedMemory(Array sourceArray, ulong sourceIndex, ulong length, IntPtr pDestination)
	{
		ulong longLength = (ulong)sourceArray.LongLength;
		if (sourceIndex >= longLength)
		{
			throw new ArgumentOutOfRangeException("sourceIndex");
		}
		uint[] array = (uint[])sourceArray;
		length = Math.Min(length, longLength - sourceIndex);
		fixed (uint* ptr = array)
		{
			uint* ptr2 = (uint*)(void*)pDestination;
			for (ulong num = 0uL; num < length; num++)
			{
				ptr2[num] = ptr[sourceIndex + num];
			}
		}
		return length;
	}

	private unsafe static ulong WriteInt32ArrayToUnmanagedMemory(Array sourceArray, ulong sourceIndex, ulong length, IntPtr pDestination)
	{
		ulong longLength = (ulong)sourceArray.LongLength;
		if (sourceIndex >= longLength)
		{
			throw new ArgumentOutOfRangeException("sourceIndex");
		}
		int[] array = (int[])sourceArray;
		length = Math.Min(length, longLength - sourceIndex);
		try
		{
			VerifyMarshalCopyEnabled();
			Marshal.Copy(array, Convert.ToInt32(sourceIndex), pDestination, Convert.ToInt32(length));
		}
		catch (OverflowException)
		{
			fixed (int* ptr = array)
			{
				int* ptr2 = (int*)(void*)pDestination;
				for (ulong num = 0uL; num < length; num++)
				{
					ptr2[num] = ptr[sourceIndex + num];
				}
			}
		}
		return length;
	}

	private unsafe static ulong WriteSingleArrayToUnmanagedMemory(Array sourceArray, ulong sourceIndex, ulong length, IntPtr pDestination)
	{
		ulong longLength = (ulong)sourceArray.LongLength;
		if (sourceIndex >= longLength)
		{
			throw new ArgumentOutOfRangeException("sourceIndex");
		}
		float[] array = (float[])sourceArray;
		length = Math.Min(length, longLength - sourceIndex);
		try
		{
			VerifyMarshalCopyEnabled();
			Marshal.Copy(array, Convert.ToInt32(sourceIndex), pDestination, Convert.ToInt32(length));
		}
		catch (OverflowException)
		{
			fixed (float* ptr = array)
			{
				float* ptr2 = (float*)(void*)pDestination;
				for (ulong num = 0uL; num < length; num++)
				{
					ptr2[num] = ptr[sourceIndex + num];
				}
			}
		}
		return length;
	}

	private unsafe static ulong WriteDoubleArrayToUnmanagedMemory(Array sourceArray, ulong sourceIndex, ulong length, IntPtr pDestination)
	{
		ulong longLength = (ulong)sourceArray.LongLength;
		if (sourceIndex >= longLength)
		{
			throw new ArgumentOutOfRangeException("sourceIndex");
		}
		double[] array = (double[])sourceArray;
		length = Math.Min(length, longLength - sourceIndex);
		try
		{
			VerifyMarshalCopyEnabled();
			Marshal.Copy(array, Convert.ToInt32(sourceIndex), pDestination, Convert.ToInt32(length));
		}
		catch (OverflowException)
		{
			fixed (double* ptr = array)
			{
				double* ptr2 = (double*)(void*)pDestination;
				for (ulong num = 0uL; num < length; num++)
				{
					ptr2[num] = ptr[sourceIndex + num];
				}
			}
		}
		return length;
	}

	private static void VerifyMarshalCopyEnabled()
	{
		if (DisableMarshalCopy)
		{
			throw new OverflowException();
		}
	}
}
