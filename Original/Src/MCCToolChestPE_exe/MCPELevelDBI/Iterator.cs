using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCPELevelDBI;

public class Iterator : LevelDBHandle
{
	[CompilerGenerated]
	private static Func<string, Exception> krnSeAhFck7;

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal Iterator(IntPtr Handle)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		base.Handle = Handle;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsValid()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return LevelDBInterop.leveldb_iter_valid(base.Handle) != 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SeekToFirst()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LevelDBInterop.leveldb_iter_seek_to_first(base.Handle);
		a4aSeOBFCQF();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SeekToLast()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LevelDBInterop.leveldb_iter_seek_to_last(base.Handle);
		a4aSeOBFCQF();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Seek(byte[] key)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LevelDBInterop.leveldb_iter_seek(base.Handle, key, key.Length);
		a4aSeOBFCQF();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Seek(string key)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Seek(Encoding.ASCII.GetBytes(key));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Seek(int key)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LevelDBInterop.leveldb_iter_seek(base.Handle, ref key, 4);
		a4aSeOBFCQF();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Next()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LevelDBInterop.leveldb_iter_next(base.Handle);
		a4aSeOBFCQF();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Prev()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LevelDBInterop.leveldb_iter_prev(base.Handle);
		a4aSeOBFCQF();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int KeyAsInt()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int length;
		IntPtr ptr = LevelDBInterop.leveldb_iter_key(base.Handle, out length);
		a4aSeOBFCQF();
		if (length != 4)
		{
			throw new Exception(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(209506));
		}
		return Marshal.ReadInt32(ptr);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string KeyAsString()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return Encoding.ASCII.GetString(Key());
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public byte[] Key()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int length;
		IntPtr source = LevelDBInterop.leveldb_iter_key(base.Handle, out length);
		a4aSeOBFCQF();
		byte[] array = new byte[length];
		Marshal.Copy(source, array, 0, length);
		return array;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int[] ValueAsInts()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int length;
		IntPtr source = LevelDBInterop.leveldb_iter_value(base.Handle, out length);
		a4aSeOBFCQF();
		int[] array = new int[length / 4];
		Marshal.Copy(source, array, 0, length / 4);
		return array;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string ValueAsString()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return Encoding.ASCII.GetString(Value());
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public byte[] Value()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int length;
		IntPtr source = LevelDBInterop.leveldb_iter_value(base.Handle, out length);
		a4aSeOBFCQF();
		byte[] array = new byte[length];
		Marshal.Copy(source, array, 0, length);
		return array;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void a4aSeOBFCQF()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		HCpSeC67Zrm([MethodImpl(MethodImplOptions.NoInlining)] (string P_0) =>
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return new Exception(P_0);
		});
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HCpSeC67Zrm(Func<string, Exception> P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LevelDBInterop.leveldb_iter_get_error(base.Handle, out var error);
		if (error != IntPtr.Zero)
		{
			throw P_0(Marshal.PtrToStringAnsi(error));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void FreeUnManagedObjects()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LevelDBInterop.leveldb_iter_destroy(base.Handle);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static Exception WQsSe7QPaoc(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return new Exception(P_0);
	}
}
