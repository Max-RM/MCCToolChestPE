using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCPELevelDBI;

public class LevelDBInterop
{
	static LevelDBInterop()
	{
		LevelDBNativeLoader.EnsureLoaded();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IntPtr leveldb_options_create()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		try
		{
			if (Environment.Is64BitProcess)
			{
				return leveldb_64_options_create();
			}
			return leveldb_32_options_create();
		}
		catch (Exception)
		{
			MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(209552), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(209692));
			throw;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void leveldb_options_destroy(IntPtr options)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Environment.Is64BitProcess)
		{
			leveldb_64_options_destroy(options);
		}
		else
		{
			leveldb_32_options_destroy(options);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void leveldb_options_set_create_if_missing(IntPtr options, byte o)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Environment.Is64BitProcess)
		{
			leveldb_64_options_set_create_if_missing(options, o);
		}
		else
		{
			leveldb_32_options_set_create_if_missing(options, o);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void leveldb_options_set_compression(IntPtr options, int compressionType)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Environment.Is64BitProcess)
		{
			leveldb_64_options_set_compression(options, compressionType);
		}
		else
		{
			leveldb_32_options_set_compression(options, compressionType);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IntPtr leveldb_readoptions_create()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Environment.Is64BitProcess)
		{
			return leveldb_64_readoptions_create();
		}
		return leveldb_32_readoptions_create();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void leveldb_readoptions_destroy(IntPtr options)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Environment.Is64BitProcess)
		{
			leveldb_64_readoptions_destroy(options);
		}
		else
		{
			leveldb_32_readoptions_destroy(options);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void leveldb_readoptions_set_fill_cache(IntPtr options, byte o)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Environment.Is64BitProcess)
		{
			leveldb_64_readoptions_set_fill_cache(options, o);
		}
		else
		{
			leveldb_32_readoptions_set_fill_cache(options, o);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IntPtr leveldb_writeoptions_create()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Environment.Is64BitProcess)
		{
			return leveldb_64_writeoptions_create();
		}
		return leveldb_32_writeoptions_create();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void leveldb_writeoptions_destroy(IntPtr options)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Environment.Is64BitProcess)
		{
			leveldb_64_writeoptions_destroy(options);
		}
		else
		{
			leveldb_32_writeoptions_destroy(options);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void leveldb_writeoptions_set_sync(IntPtr options, byte o)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Environment.Is64BitProcess)
		{
			n0LSMTn2lE6(options, o);
		}
		else
		{
			luZSMGCOONE(options, 0);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IntPtr leveldb_open(IntPtr options, string name, out IntPtr error)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Environment.Is64BitProcess)
		{
			return leveldb_64_open(options, name, out error);
		}
		return leveldb_32_open(options, name, out error);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void leveldb_close(IntPtr db)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Environment.Is64BitProcess)
		{
			leveldb_64_close(db);
		}
		else
		{
			leveldb_32_close(db);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IntPtr leveldb_get(IntPtr db, IntPtr options, byte[] key, IntPtr keylen, out IntPtr vallen, out IntPtr errptr)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Environment.Is64BitProcess)
		{
			return leveldb_64_get(db, options, key, keylen, out vallen, out errptr);
		}
		return leveldb_32_get(db, options, key, keylen, out vallen, out errptr);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IntPtr leveldb_get(IntPtr db, IntPtr options, ref int key, IntPtr keylen, out IntPtr vallen, out IntPtr errptr)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Environment.Is64BitProcess)
		{
			return leveldb_64_get(db, options, ref key, keylen, out vallen, out errptr);
		}
		return leveldb_32_get(db, options, ref key, keylen, out vallen, out errptr);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IntPtr leveldb_get(IntPtr db, IntPtr options, IntPtr key, IntPtr keylen, out IntPtr vallen, out IntPtr errptr)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Environment.Is64BitProcess)
		{
			return leveldb_64_get(db, options, key, keylen, out vallen, out errptr);
		}
		return leveldb_32_get(db, options, key, keylen, out vallen, out errptr);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void leveldb_put(IntPtr db, IntPtr options, byte[] key, IntPtr keylen, byte[] val, IntPtr vallen, out IntPtr errptr)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Environment.Is64BitProcess)
		{
			leveldb_64_put(db, options, key, keylen, val, vallen, out errptr);
		}
		else
		{
			leveldb_32_put(db, options, key, keylen, val, vallen, out errptr);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void leveldb_put(IntPtr db, IntPtr options, ref int key, IntPtr keylen, int[] val, IntPtr vallen, out IntPtr errptr)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Environment.Is64BitProcess)
		{
			leveldb_64_put(db, options, ref key, keylen, val, vallen, out errptr);
		}
		else
		{
			leveldb_32_put(db, options, ref key, keylen, val, vallen, out errptr);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void leveldb_delete(IntPtr db, IntPtr options, byte[] key, IntPtr keylen, out IntPtr errptr)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Environment.Is64BitProcess)
		{
			xrrSMSEaAAk(db, options, key, keylen, out errptr);
		}
		else
		{
			leveldb_32_delete(db, options, key, keylen, out errptr);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void leveldb_free(IntPtr ptr)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Environment.Is64BitProcess)
		{
			leveldb_64_free(ptr);
		}
		else
		{
			leveldb_32_free(ptr);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IntPtr leveldb_create_iterator(IntPtr db, IntPtr options)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Environment.Is64BitProcess)
		{
			return leveldb_64_create_iterator(db, options);
		}
		return leveldb_32_create_iterator(db, options);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void leveldb_iter_destroy(IntPtr iterator)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Environment.Is64BitProcess)
		{
			leveldb_64_iter_destroy(iterator);
		}
		else
		{
			leveldb_32_iter_destroy(iterator);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static byte leveldb_iter_valid(IntPtr iterator)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Environment.Is64BitProcess)
		{
			return leveldb_64_iter_valid(iterator);
		}
		return leveldb_32_iter_valid(iterator);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void leveldb_iter_seek_to_first(IntPtr iterator)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Environment.Is64BitProcess)
		{
			leveldb_64_iter_seek_to_first(iterator);
		}
		else
		{
			leveldb_32_iter_seek_to_first(iterator);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void leveldb_iter_seek_to_last(IntPtr iterator)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Environment.Is64BitProcess)
		{
			leveldb_64_iter_seek_to_last(iterator);
		}
		else
		{
			leveldb_32_iter_seek_to_last(iterator);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void leveldb_iter_seek(IntPtr iterator, byte[] key, int length)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Environment.Is64BitProcess)
		{
			leveldb_64_iter_seek(iterator, key, length);
		}
		else
		{
			leveldb_32_iter_seek(iterator, key, length);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void leveldb_iter_seek(IntPtr iterator, ref int key, int length)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Environment.Is64BitProcess)
		{
			leveldb_64_iter_seek(iterator, ref key, length);
		}
		else
		{
			leveldb_32_iter_seek(iterator, ref key, length);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void leveldb_iter_next(IntPtr iterator)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Environment.Is64BitProcess)
		{
			leveldb_64_iter_next(iterator);
		}
		else
		{
			leveldb_32_iter_next(iterator);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void leveldb_iter_prev(IntPtr iterator)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Environment.Is64BitProcess)
		{
			leveldb_64_iter_prev(iterator);
		}
		else
		{
			leveldb_32_iter_prev(iterator);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IntPtr leveldb_iter_key(IntPtr iterator, out int length)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Environment.Is64BitProcess)
		{
			return leveldb_64_iter_key(iterator, out length);
		}
		return leveldb_32_iter_key(iterator, out length);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IntPtr leveldb_iter_value(IntPtr iterator, out int length)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Environment.Is64BitProcess)
		{
			return leveldb_64_iter_value(iterator, out length);
		}
		return leveldb_32_iter_value(iterator, out length);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void leveldb_iter_get_error(IntPtr iterator, out IntPtr error)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Environment.Is64BitProcess)
		{
			leveldb_64_iter_get_error(iterator, out error);
		}
		else
		{
			leveldb_32_iter_get_error(iterator, out error);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IntPtr leveldb_compact_range(IntPtr db, byte[] start_key, IntPtr start_key_len, byte[] limit_key, IntPtr limit_key_len)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Environment.Is64BitProcess)
		{
			return leveldb_64_compact_range(db, start_key, start_key_len, limit_key, limit_key_len);
		}
		return leveldb_32_compact_range(db, start_key, start_key_len, limit_key, limit_key_len);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IntPtr leveldb_writebatch_create()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Environment.Is64BitProcess)
		{
			return leveldb_64_writebatch_create();
		}
		return leveldb_32_writebatch_create();
	}

	[DllImport("LevelDB-MCPE-64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "leveldb_writebatch_create")]
	public static extern IntPtr leveldb_64_writebatch_create();

	[DllImport("LevelDB-MCPE-32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "leveldb_writebatch_create")]
	public static extern IntPtr leveldb_32_writebatch_create();

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void leveldb_writebatch_destroy(IntPtr writebatch)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Environment.Is64BitProcess)
		{
			leveldb_64_writebatch_destroy(writebatch);
		}
		else
		{
			leveldb_32_writebatch_destroy(writebatch);
		}
	}

	[DllImport("LevelDB-MCPE-64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_writebatch_destroy")]
	public static extern void leveldb_64_writebatch_destroy(IntPtr writebatch);

	[DllImport("LevelDB-MCPE-32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_writebatch_destroy")]
	public static extern void leveldb_32_writebatch_destroy(IntPtr writebatch);

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void leveldb_writebatch_clear(IntPtr writebatch)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Environment.Is64BitProcess)
		{
			leveldb_64_writebatch_clear(writebatch);
		}
		else
		{
			leveldb_32_writebatch_clear(writebatch);
		}
	}

	[DllImport("LevelDB-MCPE-64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_writebatch_clear")]
	public static extern void leveldb_64_writebatch_clear(IntPtr writebatch);

	[DllImport("LevelDB-MCPE-32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_writebatch_clear")]
	public static extern void leveldb_32_writebatch_clear(IntPtr writebatch);

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void leveldb_writebatch_delete(IntPtr writebatch, byte[] key, IntPtr keylen)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Environment.Is64BitProcess)
		{
			JSnSed51AwN(writebatch, key, keylen);
		}
		else
		{
			aLwSeHQT9k3(writebatch, key, keylen);
		}
	}

	[DllImport("LevelDB-MCPE-64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_writebatch_delete")]
	private static extern void JSnSed51AwN(IntPtr P_0, byte[] P_1, IntPtr P_2);

	[DllImport("LevelDB-MCPE-32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_writebatch_delete")]
	private static extern void aLwSeHQT9k3(IntPtr P_0, byte[] P_1, IntPtr P_2);

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void leveldb_write(IntPtr db, IntPtr options, IntPtr writebatch, out IntPtr errptr)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Environment.Is64BitProcess)
		{
			hyPSeFJKjEG(db, options, writebatch, out errptr);
		}
		else
		{
			iJvSejDypOA(db, options, writebatch, out errptr);
		}
	}

	[DllImport("LevelDB-MCPE-64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_write")]
	private static extern void hyPSeFJKjEG(IntPtr P_0, IntPtr P_1, IntPtr P_2, out IntPtr P_3);

	[DllImport("LevelDB-MCPE-32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_write")]
	private static extern void iJvSejDypOA(IntPtr P_0, IntPtr P_1, IntPtr P_2, out IntPtr P_3);

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void leveldb_writebatch_put(IntPtr writebatch, byte[] key, IntPtr keylen, byte[] val, IntPtr vallen)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Environment.Is64BitProcess)
		{
			leveldb_64_writebatch_put(writebatch, key, keylen, val, vallen);
		}
		else
		{
			leveldb_32_writebatch_put(writebatch, key, keylen, val, vallen);
		}
	}

	[DllImport("LevelDB-MCPE-64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_writebatch_put")]
	public static extern void leveldb_64_writebatch_put(IntPtr writebatch, byte[] key, IntPtr keylen, byte[] val, IntPtr vallen);

	[DllImport("LevelDB-MCPE-32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_writebatch_put")]
	public static extern void leveldb_32_writebatch_put(IntPtr writebatch, byte[] key, IntPtr keylen, byte[] val, IntPtr vallen);

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void leveldb_SuspendCompaction(IntPtr db)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Environment.Is64BitProcess)
		{
			RMBSe8puThc(db);
		}
		else
		{
			CLQSe9wdWnu(db);
		}
	}

	[DllImport("LevelDB-MCPE-64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_SuspendCompaction")]
	private static extern void RMBSe8puThc(IntPtr P_0);

	[DllImport("LevelDB-MCPE-32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_SuspendCompaction")]
	private static extern void CLQSe9wdWnu(IntPtr P_0);

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void leveldb_ResumeCompaction(IntPtr db)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Environment.Is64BitProcess)
		{
			qdTSeIJOCHn(db);
		}
		else
		{
			CY6SezrKliX(db);
		}
	}

	[DllImport("LevelDB-MCPE-64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_ResumeCompaction")]
	private static extern void qdTSeIJOCHn(IntPtr P_0);

	[DllImport("LevelDB-MCPE-32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_ResumeCompaction")]
	private static extern void CY6SezrKliX(IntPtr P_0);

	[DllImport("LevelDB-MCPE-64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "leveldb_options_create")]
	public static extern IntPtr leveldb_64_options_create();

	[DllImport("LevelDB-MCPE-64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_options_destroy")]
	public static extern void leveldb_64_options_destroy(IntPtr options);

	[DllImport("LevelDB-MCPE-64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_options_set_create_if_missing")]
	public static extern void leveldb_64_options_set_create_if_missing(IntPtr options, byte o);

	[DllImport("LevelDB-MCPE-64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "leveldb_options_set_compression")]
	public static extern void leveldb_64_options_set_compression(IntPtr options, int compressionType);

	[DllImport("LevelDB-MCPE-64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "leveldb_readoptions_create")]
	public static extern IntPtr leveldb_64_readoptions_create();

	[DllImport("LevelDB-MCPE-64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_readoptions_destroy")]
	public static extern void leveldb_64_readoptions_destroy(IntPtr options);

	[DllImport("LevelDB-MCPE-64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_readoptions_set_fill_cache")]
	public static extern void leveldb_64_readoptions_set_fill_cache(IntPtr options, byte o);

	[DllImport("LevelDB-MCPE-64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_writeoptions_create")]
	public static extern IntPtr leveldb_64_writeoptions_create();

	[DllImport("LevelDB-MCPE-64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_writeoptions_destroy")]
	public static extern void leveldb_64_writeoptions_destroy(IntPtr options);

	[DllImport("LevelDB-MCPE-64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_writeoptions_set_sync")]
	private static extern void n0LSMTn2lE6(IntPtr P_0, byte P_1);

	[DllImport("LevelDB-MCPE-64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_open")]
	public static extern IntPtr leveldb_64_open(IntPtr options, string name, out IntPtr error);

	[DllImport("LevelDB-MCPE-64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_close")]
	public static extern void leveldb_64_close(IntPtr db);

	[DllImport("LevelDB-MCPE-64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_get")]
	public static extern IntPtr leveldb_64_get(IntPtr db, IntPtr options, byte[] key, IntPtr keylen, out IntPtr vallen, out IntPtr errptr);

	[DllImport("LevelDB-MCPE-64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "leveldb_get")]
	public static extern IntPtr leveldb_64_get(IntPtr db, IntPtr options, ref int key, IntPtr keylen, out IntPtr vallen, out IntPtr errptr);

	[DllImport("LevelDB-MCPE-64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "leveldb_get")]
	public static extern IntPtr leveldb_64_get(IntPtr db, IntPtr options, IntPtr key, IntPtr keylen, out IntPtr vallen, out IntPtr errptr);

	[DllImport("LevelDB-MCPE-64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_put")]
	public static extern void leveldb_64_put(IntPtr db, IntPtr options, byte[] key, IntPtr keylen, byte[] val, IntPtr vallen, out IntPtr errptr);

	[DllImport("LevelDB-MCPE-64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_put")]
	public static extern void leveldb_64_put(IntPtr db, IntPtr options, ref int key, IntPtr keylen, int[] val, IntPtr vallen, out IntPtr errptr);

	[DllImport("LevelDB-MCPE-64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_delete")]
	private static extern void xrrSMSEaAAk(IntPtr P_0, IntPtr P_1, byte[] P_2, IntPtr P_3, out IntPtr P_4);

	[DllImport("LevelDB-MCPE-64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_free")]
	public static extern void leveldb_64_free(IntPtr ptr);

	[DllImport("LevelDB-MCPE-64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_create_iterator")]
	public static extern IntPtr leveldb_64_create_iterator(IntPtr db, IntPtr options);

	[DllImport("LevelDB-MCPE-64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_iter_destroy")]
	public static extern void leveldb_64_iter_destroy(IntPtr iterator);

	[DllImport("LevelDB-MCPE-64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_iter_valid")]
	public static extern byte leveldb_64_iter_valid(IntPtr iterator);

	[DllImport("LevelDB-MCPE-64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_iter_seek_to_first")]
	public static extern void leveldb_64_iter_seek_to_first(IntPtr iterator);

	[DllImport("LevelDB-MCPE-64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_iter_seek_to_last")]
	public static extern void leveldb_64_iter_seek_to_last(IntPtr iterator);

	[DllImport("LevelDB-MCPE-64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_iter_seek")]
	public static extern void leveldb_64_iter_seek(IntPtr iterator, byte[] key, int length);

	[DllImport("LevelDB-MCPE-64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_iter_seek")]
	public static extern void leveldb_64_iter_seek(IntPtr iterator, ref int key, int length);

	[DllImport("LevelDB-MCPE-64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_iter_next")]
	public static extern void leveldb_64_iter_next(IntPtr iterator);

	[DllImport("LevelDB-MCPE-64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_iter_prev")]
	public static extern void leveldb_64_iter_prev(IntPtr iterator);

	[DllImport("LevelDB-MCPE-64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_iter_key")]
	public static extern IntPtr leveldb_64_iter_key(IntPtr iterator, out int length);

	[DllImport("LevelDB-MCPE-64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_iter_value")]
	public static extern IntPtr leveldb_64_iter_value(IntPtr iterator, out int length);

	[DllImport("LevelDB-MCPE-64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_iter_get_error")]
	public static extern void leveldb_64_iter_get_error(IntPtr iterator, out IntPtr error);

	[DllImport("LevelDB-MCPE-64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "leveldb_compact_range")]
	public static extern IntPtr leveldb_64_compact_range(IntPtr db, byte[] start_key, IntPtr start_key_len, byte[] limit_key, IntPtr limit_key_len);

	[DllImport("LevelDB-MCPE-32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "leveldb_options_create")]
	public static extern IntPtr leveldb_32_options_create();

	[DllImport("LevelDB-MCPE-32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_options_destroy")]
	public static extern void leveldb_32_options_destroy(IntPtr options);

	[DllImport("LevelDB-MCPE-32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_options_set_create_if_missing")]
	public static extern void leveldb_32_options_set_create_if_missing(IntPtr options, byte o);

	[DllImport("LevelDB-MCPE-32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "leveldb_options_set_compression")]
	public static extern void leveldb_32_options_set_compression(IntPtr options, int compressionType);

	[DllImport("LevelDB-MCPE-32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "leveldb_readoptions_create")]
	public static extern IntPtr leveldb_32_readoptions_create();

	[DllImport("LevelDB-MCPE-32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_readoptions_destroy")]
	public static extern void leveldb_32_readoptions_destroy(IntPtr options);

	[DllImport("LevelDB-MCPE-32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_readoptions_set_fill_cache")]
	public static extern void leveldb_32_readoptions_set_fill_cache(IntPtr options, byte o);

	[DllImport("LevelDB-MCPE-32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_writeoptions_create")]
	public static extern IntPtr leveldb_32_writeoptions_create();

	[DllImport("LevelDB-MCPE-32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_writeoptions_destroy")]
	public static extern void leveldb_32_writeoptions_destroy(IntPtr options);

	[DllImport("LevelDB-MCPE-32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_writeoptions_set_sync")]
	private static extern void luZSMGCOONE(IntPtr P_0, byte P_1);

	[DllImport("LevelDB-MCPE-32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_open")]
	public static extern IntPtr leveldb_32_open(IntPtr options, string name, out IntPtr error);

	[DllImport("LevelDB-MCPE-32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_close")]
	public static extern void leveldb_32_close(IntPtr db);

	[DllImport("LevelDB-MCPE-32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_get")]
	public static extern IntPtr leveldb_32_get(IntPtr db, IntPtr options, byte[] key, IntPtr keylen, out IntPtr vallen, out IntPtr errptr);

	[DllImport("LevelDB-MCPE-32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "leveldb_get")]
	public static extern IntPtr leveldb_32_get(IntPtr db, IntPtr options, ref int key, IntPtr keylen, out IntPtr vallen, out IntPtr errptr);

	[DllImport("LevelDB-MCPE-32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "leveldb_get")]
	public static extern IntPtr leveldb_32_get(IntPtr db, IntPtr options, IntPtr key, IntPtr keylen, out IntPtr vallen, out IntPtr errptr);

	[DllImport("LevelDB-MCPE-32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_put")]
	public static extern void leveldb_32_put(IntPtr db, IntPtr options, byte[] key, IntPtr keylen, byte[] val, IntPtr vallen, out IntPtr errptr);

	[DllImport("LevelDB-MCPE-32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_put")]
	public static extern void leveldb_32_put(IntPtr db, IntPtr options, ref int key, IntPtr keylen, int[] val, IntPtr vallen, out IntPtr errptr);

	[DllImport("LevelDB-MCPE-32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_delete")]
	public static extern void leveldb_32_delete(IntPtr db, IntPtr options, byte[] key, IntPtr keylen, out IntPtr errptr);

	[DllImport("LevelDB-MCPE-32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_free")]
	public static extern void leveldb_32_free(IntPtr ptr);

	[DllImport("LevelDB-MCPE-32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_create_iterator")]
	public static extern IntPtr leveldb_32_create_iterator(IntPtr db, IntPtr options);

	[DllImport("LevelDB-MCPE-32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_iter_destroy")]
	public static extern void leveldb_32_iter_destroy(IntPtr iterator);

	[DllImport("LevelDB-MCPE-32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_iter_valid")]
	public static extern byte leveldb_32_iter_valid(IntPtr iterator);

	[DllImport("LevelDB-MCPE-32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_iter_seek_to_first")]
	public static extern void leveldb_32_iter_seek_to_first(IntPtr iterator);

	[DllImport("LevelDB-MCPE-32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_iter_seek_to_last")]
	public static extern void leveldb_32_iter_seek_to_last(IntPtr iterator);

	[DllImport("LevelDB-MCPE-32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_iter_seek")]
	public static extern void leveldb_32_iter_seek(IntPtr iterator, byte[] key, int length);

	[DllImport("LevelDB-MCPE-32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_iter_seek")]
	public static extern void leveldb_32_iter_seek(IntPtr iterator, ref int key, int length);

	[DllImport("LevelDB-MCPE-32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_iter_next")]
	public static extern void leveldb_32_iter_next(IntPtr iterator);

	[DllImport("LevelDB-MCPE-32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_iter_prev")]
	public static extern void leveldb_32_iter_prev(IntPtr iterator);

	[DllImport("LevelDB-MCPE-32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_iter_key")]
	public static extern IntPtr leveldb_32_iter_key(IntPtr iterator, out int length);

	[DllImport("LevelDB-MCPE-32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_iter_value")]
	public static extern IntPtr leveldb_32_iter_value(IntPtr iterator, out int length);

	[DllImport("LevelDB-MCPE-32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "leveldb_iter_get_error")]
	public static extern void leveldb_32_iter_get_error(IntPtr iterator, out IntPtr error);

	[DllImport("LevelDB-MCPE-32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "leveldb_compact_range")]
	public static extern IntPtr leveldb_32_compact_range(IntPtr db, byte[] start_key, IntPtr start_key_len, byte[] limit_key, IntPtr limit_key_len);

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LevelDBInterop()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}
}
