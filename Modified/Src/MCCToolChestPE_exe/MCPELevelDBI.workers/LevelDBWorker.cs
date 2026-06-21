using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using MCCToolChest.events;
using MCCToolChest.model;
using MCCToolChest.PECode;
using MCCToolChest.PECode.model;
using MCCToolChest.utils;
using MCPELevelDBI.model;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCPELevelDBI.workers;

public class LevelDBWorker
{
	private static object xR5SMtNONeX;

	private BackgroundWorker H1ySMafSNKO;

	private string WFYSMXuL0aR;

	private static byte[] yhoSMxIkudk;

	private static int[] ssaSMetnCTb;

	[CompilerGenerated]
	private IntPtr c6SSMM3U4mj;

	[CompilerGenerated]
	private IntPtr vtdSMUTdTwt;

	[CompilerGenerated]
	private IntPtr w4kSML72vOw;

	[CompilerGenerated]
	private static Func<string, Exception> YXMSMgO8b8r;

	public string DBPath
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return WFYSMXuL0aR;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			WFYSMXuL0aR = value;
		}
	}

	public IntPtr Handle
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return c6SSMM3U4mj;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		protected set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			c6SSMM3U4mj = value;
		}
	}

	public IntPtr readOptions
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return vtdSMUTdTwt;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		protected set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			vtdSMUTdTwt = value;
		}
	}

	public IntPtr writeOptions
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return w4kSML72vOw;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		protected set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			w4kSML72vOw = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LevelDBWorker()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LevelDBWorker(BackgroundWorker bw)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		H1ySMafSNKO = bw;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OpenDB(string path, bool createIfNotExist = false)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		IntPtr options = LevelDBInterop.leveldb_options_create();
		if (createIfNotExist)
		{
			LevelDBInterop.leveldb_options_set_create_if_missing(options, 1);
		}
		LevelDBInterop.leveldb_options_set_compression(options, 4);
		Handle = LevelDBInterop.leveldb_open(options, path, out var error);
		I7dSMwwWVEK(error);
		readOptions = LevelDBInterop.leveldb_readoptions_create();
		writeOptions = LevelDBInterop.leveldb_writeoptions_create();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CloseDB()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LevelDBInterop.leveldb_close(Handle);
		LevelDBInterop.leveldb_readoptions_destroy(readOptions);
		LevelDBInterop.leveldb_writeoptions_destroy(writeOptions);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public byte[] ReadDbValue(string key)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return ReadDbValue(Encoding.ASCII.GetBytes(key));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public byte[] ReadDbValue(byte[] key)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		lock (xR5SMtNONeX)
		{
			IntPtr vallen;
			IntPtr errptr;
			IntPtr intPtr = LevelDBInterop.leveldb_get(Handle, readOptions, key, (IntPtr)key.LongLength, out vallen, out errptr);
			I7dSMwwWVEK(errptr);
			if (intPtr != IntPtr.Zero)
			{
				try
				{
					byte[] array = new byte[(long)vallen];
					Marshal.Copy(intPtr, array, 0, (int)vallen);
					return array;
				}
				finally
				{
					LevelDBInterop.leveldb_free(intPtr);
				}
			}
		}
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Put(string key, string value)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Put(Encoding.ASCII.GetBytes(key), Encoding.ASCII.GetBytes(value));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Put(byte[] key, byte[] value)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LevelDBInterop.leveldb_put(Handle, writeOptions, key, (IntPtr)key.LongLength, value, (IntPtr)value.LongLength, out var errptr);
		I7dSMwwWVEK(errptr);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Put(int key, int[] value)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LevelDBInterop.leveldb_put(Handle, writeOptions, ref key, (IntPtr)4, value, (IntPtr)checked(value.LongLength * 4), out var errptr);
		I7dSMwwWVEK(errptr);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public byte[] Get(byte[] key)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		IntPtr vallen;
		IntPtr errptr;
		IntPtr intPtr = LevelDBInterop.leveldb_get(Handle, readOptions, key, (IntPtr)key.LongLength, out vallen, out errptr);
		I7dSMwwWVEK(errptr);
		if (intPtr != IntPtr.Zero)
		{
			try
			{
				byte[] array = new byte[(long)vallen];
				Marshal.Copy(intPtr, array, 0, (int)vallen);
				return array;
			}
			finally
			{
				LevelDBInterop.leveldb_free(intPtr);
			}
		}
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void leveldb_compact_range(byte[] start_key, byte[] limit_key)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LevelDBInterop.leveldb_compact_range(Handle, start_key, (IntPtr)0, limit_key, (IntPtr)0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Delete(byte[] key)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LevelDBInterop.leveldb_delete(Handle, writeOptions, key, (IntPtr)key.LongLength, out var errptr);
		I7dSMwwWVEK(errptr);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IntPtr CreateWriteBatch()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return LevelDBInterop.leveldb_writebatch_create();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DestroyWriteBatch(IntPtr batch)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LevelDBInterop.leveldb_writebatch_destroy(batch);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void WriteBatch(IntPtr batch)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LevelDBInterop.leveldb_write(Handle, writeOptions, batch, out var errptr);
		I7dSMwwWVEK(errptr);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void WriteBatchDelete(IntPtr batch, byte[] key)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LevelDBInterop.leveldb_writebatch_delete(batch, key, (IntPtr)key.LongLength);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void WriteBatchPut(IntPtr batch, byte[] key, byte[] value)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LevelDBInterop.leveldb_writebatch_put(batch, key, (IntPtr)key.LongLength, value, (IntPtr)value.LongLength);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void I7dSMwwWVEK(IntPtr P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		dHNSM4JeLhF(P_0, [MethodImpl(MethodImplOptions.NoInlining)] (string message) =>
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return new Exception(message);
		});
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void dHNSM4JeLhF(IntPtr P_0, Func<string, Exception> P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0 != IntPtr.Zero)
		{
			try
			{
				string arg = Marshal.PtrToStringAnsi(P_0);
				throw P_1(arg);
			}
			finally
			{
				LevelDBInterop.leveldb_free(P_0);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<DBRecord> JqiSMVeC9C5(IntPtr P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<DBRecord> list = new List<DBRecord>();
		using Iterator iterator = CreateIterator(LevelDBInterop.leveldb_readoptions_create());
		iterator.SeekToFirst();
		while (iterator.IsValid())
		{
			DBRecord item = new DBRecord(iterator.Key(), iterator.Value());
			list.Add(item);
			iterator.Next();
		}
		return list;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Iterator CreateIterator(IntPtr readOptions)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return new Iterator(LevelDBInterop.leveldb_create_iterator(Handle, readOptions));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void BuildAnalysis(string path)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<DBRecord> list = JqiSMVeC9C5(readOptions);
		PxpSMWHQ0nG(list, path);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string PxpSMWHQ0nG(List<DBRecord> P_0, string P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		foreach (DBRecord item in P_0)
		{
			byte[] key = item.Key;
			int num2 = 0;
			int num3 = 0;
			if (key.Length >= 8)
			{
				num2 = BitConverter.ToInt32(key, 0);
				num3 = BitConverter.ToInt32(key, 4);
			}
			int num4 = key[key.Length - 1];
			int num5 = -1;
			int num6 = 0;
			if (key.Length >= 13)
			{
				num6 = BitConverter.ToInt32(key, 8);
			}
			if (num4 <= 15)
			{
				num5 = num4;
				num4 = key[key.Length - 2];
			}
			string empty = string.Empty;
			string text = "";
			if (ssaSMetnCTb.Contains(num4))
			{
				if (num4 == 47)
				{
					empty = string.Format(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(209734), key.Length, item.Value.Length, num2, num3, num6, num4, num5);
					text = string.Format(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(209898), num2, num3, num6, num4, num5, num);
				}
				else
				{
					empty = string.Format(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(209948), key.Length, item.Value.Length, num2, num3, num6, num4);
					text = string.Format(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(210086), num2, num3, num6, num4, num);
				}
				try
				{
					string text2 = Path.Combine(P_1, num6.ToString());
					Directory.CreateDirectory(text2);
					text2 = Path.Combine(text2, text);
					FileUtils.WriteFile(item.Value, text2);
				}
				catch (Exception)
				{
				}
			}
			else
			{
				empty = Encoding.ASCII.GetString(key);
				text = empty;
				try
				{
					string filename = Path.Combine(P_1, text + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22554));
					FileUtils.WriteFile(item.Value, filename);
				}
				catch (Exception)
				{
				}
			}
			stringBuilder.AppendLine(empty);
			num++;
		}
		return stringBuilder.ToString();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<DBRecord> GetMaps()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return g8FSMpngZve(readOptions);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<DBRecord> g8FSMpngZve(IntPtr P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<DBRecord> list = new List<DBRecord>();
		using (Iterator iterator = CreateIterator(LevelDBInterop.leveldb_readoptions_create()))
		{
			iterator.Seek(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(210128));
			while (iterator.IsValid())
			{
				DBRecord item = new DBRecord(iterator.Key(), iterator.Value());
				if (iterator.KeyAsString().StartsWith(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(210128)))
				{
					list.Add(item);
					iterator.Next();
					continue;
				}
				break;
			}
		}
		return list;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<string> GetMaps(string path)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return YEDSMZ8eFZt(readOptions, path);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<string> YEDSMZ8eFZt(IntPtr P_0, string P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<string> list = new List<string>();
		DBRecord dBRecord = null;
		using (Iterator iterator = CreateIterator(LevelDBInterop.leveldb_readoptions_create()))
		{
			iterator.Seek(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(210128));
			while (iterator.IsValid())
			{
				dBRecord = new DBRecord(iterator.Key(), iterator.Value());
				if (iterator.KeyAsString().StartsWith(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(210128)))
				{
					string text = Encoding.ASCII.GetString(dBRecord.Key);
					string filename = Path.Combine(P_1, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55206), text + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22554));
					FileUtils.WriteFile(dBRecord.Value, filename);
					list.Add(text);
					iterator.Next();
					continue;
				}
				break;
			}
		}
		return list;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<DBRecord> GetWildCardRecords(string wildCard)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return Ns6SMf3Xso8(readOptions, wildCard);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<DBRecord> Ns6SMf3Xso8(IntPtr P_0, string P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<DBRecord> list = new List<DBRecord>();
		using (Iterator iterator = CreateIterator(LevelDBInterop.leveldb_readoptions_create()))
		{
			iterator.Seek(P_1);
			while (iterator.IsValid())
			{
				DBRecord item = new DBRecord(iterator.Key(), iterator.Value());
				if (iterator.KeyAsString().StartsWith(P_1))
				{
					list.Add(item);
					iterator.Next();
					continue;
				}
				break;
			}
		}
		return list;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<PEDimension> GetAvailableChunks()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<DBRecord> list = JqiSMVeC9C5(readOptions);
		return QviSMKHrybW(list);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<DBRecord> o9QSMiFbMqs(IntPtr P_0, object P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<DBRecord> list = new List<DBRecord>();
		IntPtr options = LevelDBInterop.leveldb_readoptions_create();
		LevelDBInterop.leveldb_readoptions_set_fill_cache(options, 0);
		using (Iterator iterator = CreateIterator(options))
		{
			iterator.SeekToFirst();
			while (iterator.IsValid())
			{
				byte[] array = iterator.Key();
				if (array[array.Length - 1] == 118)
				{
					DBRecord item = new DBRecord(iterator.Key(), iterator.Value());
					list.Add(item);
				}
				iterator.Next();
			}
		}
		LevelDBInterop.leveldb_readoptions_destroy(options);
		return list;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<DBRecord> fIvSMsbT3Dk(IntPtr P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<DBRecord> list = new List<DBRecord>();
		IntPtr options = LevelDBInterop.leveldb_readoptions_create();
		LevelDBInterop.leveldb_readoptions_set_fill_cache(options, 0);
		using (Iterator iterator = CreateIterator(options))
		{
			iterator.SeekToFirst();
			while (iterator.IsValid())
			{
				byte[] array = iterator.Key();
				int num = vqVSMq9Uo2d(array);
				if (ssaSMetnCTb.Contains(num))
				{
					if (num != 118)
					{
						array[array.Length - 1] = 118;
						iterator.Seek(array);
					}
					else
					{
						DBRecord item = new DBRecord(iterator.Key(), null);
						list.Add(item);
						iterator.Next();
					}
				}
				else
				{
					iterator.Next();
				}
			}
		}
		LevelDBInterop.leveldb_readoptions_destroy(options);
		return list;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int vqVSMq9Uo2d(byte[] P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0 == null || P_0.Length < 9)
		{
			return -1;
		}
		int num = P_0[P_0.Length - 1];
		if (num <= 15 && P_0.Length >= 10)
		{
			num = P_0[P_0.Length - 2];
		}
		return num;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EnsureDimensionSlot(List<PEDimension> dimensions, int dimensionId)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		while (dimensions.Count <= dimensionId)
		{
			dimensions.Add(new PEDimension(dimensions.Count));
		}
	}

	private bool TryParseBedrockChunkKey(byte[] key, out int dimension, out int chunkX, out int chunkZ, out int tag)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		dimension = 0;
		chunkX = 0;
		chunkZ = 0;
		tag = -1;
		if (key == null || key.Length < 9)
		{
			return false;
		}
		if (key.Length != 9 && key.Length != 10 && key.Length != 13 && key.Length != 14)
		{
			return false;
		}
		chunkX = BitConverter.ToInt32(key, 0);
		chunkZ = BitConverter.ToInt32(key, 4);
		tag = key[key.Length - 1];
		int tagIndex = key.Length - 1;
		if (tag <= 15 && key.Length >= 10)
		{
			tag = key[key.Length - 2];
			tagIndex = key.Length - 2;
		}
		if (!ssaSMetnCTb.Contains(tag))
		{
			return false;
		}
		int num = tagIndex - 8;
		if (num >= 4)
		{
			dimension = BitConverter.ToInt32(key, 8);
		}
		else if (num == 1)
		{
			dimension = key[8];
		}
		else if (num == 0)
		{
			dimension = 0;
		}
		else
		{
			return false;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool TryParseColumnVersionKey(byte[] key, out int dimension, out int chunkX, out int chunkZ)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!TryParseBedrockChunkKey(key, out dimension, out chunkX, out chunkZ, out int tag) || tag != 118)
		{
			dimension = 0;
			chunkX = 0;
			chunkZ = 0;
			return false;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<PEDimension> QviSMKHrybW(List<DBRecord> P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<PEDimension> list = new List<PEDimension>();
		list.Add(new PEDimension(0));
		list.Add(new PEDimension(1));
		list.Add(new PEDimension(2));
		foreach (DBRecord item in P_0)
		{
			byte[] key = item.Key;
			if (!TryParseBedrockChunkKey(key, out int dimension, out int num, out int num2, out _))
			{
				continue;
			}
			EnsureDimensionSlot(list, dimension);
			if (dimension >= 3)
			{
				Constants.EnsureCustomDimensionRegistered(dimension);
			}
			int x = (int)Math.Floor((double)num / 32.0);
			int z = (int)Math.Floor((double)num2 / 32.0);
			string key2 = x + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13710) + z;
			if (!list[dimension].Region.ContainsKey(key2))
			{
				list[dimension].Region[key2] = new PERegion(dimension, x, z);
			}
			int num5 = (num & 0x1F) + (num2 & 0x1F) * 32;
			list[dimension].Region[key2].Chunks[num5] = 1;
		}
		return list;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<PEDimension> i35SMhA2yWL(byte[] P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<PEDimension> list = new List<PEDimension>();
		list.Add(new PEDimension(0));
		list.Add(new PEDimension(1));
		list.Add(new PEDimension(2));
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		while (num < P_0.Length)
		{
			num2 = BitConverter.ToInt32(P_0, num);
			num += 4;
			num3 = BitConverter.ToInt32(P_0, num);
			num += 4;
			num4 = BitConverter.ToInt32(P_0, num);
			num += 4;
			EnsureDimensionSlot(list, num4);
			if (num4 >= 3)
			{
				Constants.EnsureCustomDimensionRegistered(num4);
			}
			string key = num2 + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13710) + num3;
			if (!list[num4].Region.ContainsKey(key))
			{
				list[num4].Region[key] = new PERegion(num4, num2, num3);
			}
			for (int i = 0; i < 1024; i++)
			{
				list[num4].Region[key].Chunks[i] = P_0[num + i];
			}
			num += 1024;
		}
		return list;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PEWorldChunks GetWorldChunks()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PEWorldChunks pEWorldChunks = new PEWorldChunks();
		List<DBRecord> list = JqiSMVeC9C5(readOptions);
		foreach (DBRecord item in list)
		{
			if (!xvySMnZ7Das(item.Key))
			{
				int dimension = 0;
				int x = 0;
				int z = 0;
				int num = 0;
				int section = 0;
				aRvSMmrvS2h(item.Key, out dimension, out x, out z, out num, out section);
				if (ssaSMetnCTb.Contains(num))
				{
					pEWorldChunks.AddRecord(dimension, x, z, num, section, item.Value);
				}
			}
		}
		return pEWorldChunks;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void aRvSMmrvS2h(byte[] P_0, out int P_1, out int P_2, out int P_3, out int P_4, out int P_5)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_2 = 0;
		P_3 = 0;
		if (P_0.Length >= 8)
		{
			P_2 = BitConverter.ToInt32(P_0, 0);
			P_3 = BitConverter.ToInt32(P_0, 4);
		}
		P_4 = P_0[P_0.Length - 1];
		P_5 = -1;
		P_1 = 0;
		int tagIndex = P_0.Length - 1;
		if (P_4 <= 15 && P_0.Length >= 10)
		{
			P_5 = P_4;
			P_4 = P_0[P_0.Length - 2];
			tagIndex = P_0.Length - 2;
		}
		int num = tagIndex - 8;
		if (num >= 4)
		{
			P_1 = BitConverter.ToInt32(P_0, 8);
		}
		else if (num == 1)
		{
			P_1 = P_0[8];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool xvySMnZ7Das(byte[] P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = ((P_0.Length < yhoSMxIkudk.Length) ? P_0.Length : yhoSMxIkudk.Length);
		if (P_0.Length != yhoSMxIkudk.Length + 1)
		{
			return false;
		}
		for (int i = 0; i < num; i++)
		{
			if (P_0[i] != yhoSMxIkudk[i])
			{
				return false;
			}
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DeleteRegionChunks(PERegion regionData)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LevelDBInterop.leveldb_writeoptions_set_sync(writeOptions, 1);
		IntPtr intPtr = LevelDBInterop.leveldb_writebatch_create();
		int num = regionData.RX * 32;
		int num2 = regionData.RZ * 32;
		for (int i = 0; i < 1024; i++)
		{
			if (regionData.Chunks[i] == 1)
			{
				int num3 = i % 32;
				int num4 = i / 32;
				e68SMlhAbZg(regionData.Dimension, num + num3, num2 + num4, intPtr);
			}
		}
		WriteBatch(intPtr);
		LevelDBInterop.leveldb_writebatch_destroy(intPtr);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DeleteRegionChunks(List<ChunkData> deletedChunks)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LevelDBInterop.leveldb_writeoptions_set_sync(writeOptions, 1);
		IntPtr intPtr = LevelDBInterop.leveldb_writebatch_create();
		foreach (ChunkData deletedChunk in deletedChunks)
		{
			int xWorldCoords = deletedChunk.XWorldCoords;
			int zWorldCoords = deletedChunk.ZWorldCoords;
			e68SMlhAbZg(deletedChunk.Dimension, xWorldCoords, zWorldCoords, intPtr);
		}
		WriteBatch(intPtr);
		LevelDBInterop.leveldb_writebatch_destroy(intPtr);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DeleteChunks(int dimension, int[] coords)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LevelDBInterop.leveldb_writeoptions_set_sync(writeOptions, 1);
		IntPtr intPtr = LevelDBInterop.leveldb_writebatch_create();
		for (int i = 0; i < coords.Length; i += 2)
		{
			e68SMlhAbZg(dimension, coords[i], coords[i + 1], intPtr);
		}
		WriteBatch(intPtr);
		LevelDBInterop.leveldb_writebatch_destroy(intPtr);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void e68SMlhAbZg(int P_0, int P_1, int P_2, IntPtr P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] array = PEUtility.BuildChunkKey(P_0, P_1, P_2, 0);
		int[] array2 = ssaSMetnCTb;
		foreach (int num in array2)
		{
			if (num != 47)
			{
				array[array.Length - 1] = (byte)num;
				WriteBatchDelete(P_3, array);
			}
		}
		array = PEUtility.BuildChunkKey(P_0, P_1, P_2, 47, 0);
		for (int j = 0; j < 16; j++)
		{
			array[array.Length - 1] = (byte)j;
			WriteBatchDelete(P_3, array);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PEWorldChunks GetWorldChunksForConversion(GeneratePCFilesFromPE generatePCFiles)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return mFpSM2lrFx9(readOptions, generatePCFiles);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private PEWorldChunks mFpSM2lrFx9(IntPtr P_0, GeneratePCFilesFromPE P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = 0;
		PEWorldChunks pEWorldChunks = new PEWorldChunks();
		bool flag = false;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		IntPtr options = LevelDBInterop.leveldb_readoptions_create();
		LevelDBInterop.leveldb_readoptions_set_fill_cache(options, 0);
		using (Iterator iterator = CreateIterator(options))
		{
			iterator.SeekToFirst();
			while (iterator.IsValid())
			{
				byte[] array = iterator.Key();
				int num5 = 0;
				int num6 = 0;
				int num7 = 0;
				int num8 = 0;
				int section = 0;
				aRvSMmrvS2h(array, out num5, out num6, out num7, out num8, out section);
				if (ssaSMetnCTb.Contains(num8))
				{
					DBRecord dBRecord = new DBRecord(array, iterator.Value());
					int num9 = (int)Math.Floor((double)num6 / 32.0);
					int num10 = (int)Math.Floor((double)num7 / 32.0);
					if (flag && num > 40000 && (num2 != num9 || num3 != num10 || num4 != num5))
					{
						P_1(pEWorldChunks);
						num = 0;
						flag = false;
						pEWorldChunks = new PEWorldChunks();
					}
					flag = true;
					num2 = num9;
					num3 = num10;
					num4 = num5;
					num++;
					pEWorldChunks.AddRecord(num5, num6, num7, num8, section, dBRecord.Value);
				}
				iterator.Next();
			}
		}
		LevelDBInterop.leveldb_readoptions_destroy(options);
		return pEWorldChunks;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<DBRecord> GetSubChunksForProcessing()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return J4MSMywm20W(readOptions);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<DBRecord> J4MSMywm20W(IntPtr P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<DBRecord> list = new List<DBRecord>();
		using Iterator iterator = CreateIterator(LevelDBInterop.leveldb_readoptions_create());
		iterator.SeekToFirst();
		while (iterator.IsValid())
		{
			byte[] array = iterator.Key();
			int num = vqVSMq9Uo2d(array);
			if (num == 47)
			{
				DBRecord item = new DBRecord(iterator.Key(), iterator.Value());
				list.Add(item);
			}
			iterator.Next();
		}
		return list;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void cynSM0hkspO(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (H1ySMafSNKO != null)
		{
			H1ySMafSNKO.ReportProgress(0, P_0);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static Exception mDXSMBWm2DT(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return new Exception(P_0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static LevelDBWorker()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		xR5SMtNONeX = new object();
		yhoSMxIkudk = Encoding.ASCII.GetBytes(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(73586));
		ssaSMetnCTb = new int[11]
		{
			45, 46, 47, 48, 49, 50, 51, 52, 53, 54,
			118
		};
	}
}
