using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Ionic.Zlib;

namespace Substrate.Core;

public class RegionFile : IDisposable
{
	private class ChunkBuffer : MemoryStream
	{
		private int x;

		private int z;

		private RegionFile region;

		private int? _timestamp;

		public ChunkBuffer(RegionFile r, int x, int z)
			: base(8096)
		{
			region = r;
			this.x = x;
			this.z = z;
		}

		public ChunkBuffer(RegionFile r, int x, int z, int timestamp)
			: this(r, x, z)
		{
			_timestamp = timestamp;
		}

		public override void Close()
		{
			if (!_timestamp.HasValue)
			{
				region.Write(x, z, GetBuffer(), (int)Length);
			}
			else
			{
				region.Write(x, z, GetBuffer(), (int)Length, _timestamp.Value);
			}
		}
	}

	private const int VERSION_GZIP = 1;

	private const int VERSION_DEFLATE = 2;

	private const int SECTOR_BYTES = 4096;

	private const int SECTOR_INTS = 1024;

	private const int CHUNK_HEADER_SIZE = 5;

	private static Regex _namePattern = new Regex("r\\.(-?[0-9]+)\\.(-?[0-9]+)\\.mc[ar]$");

	private static byte[] emptySector = new byte[4096];

	protected string fileName;

	private FileStream file;

	private object fileLock = new object();

	private int[] offsets;

	private int[] chunkTimestamps;

	private List<bool> sectorFree;

	private int sizeDelta;

	private long lastModified;

	private bool _disposed;

	protected virtual int SectorBytes => 4096;

	protected virtual int SectorInts => 1024;

	protected virtual byte[] EmptySector => emptySector;

	public RegionFile(string path)
	{
		offsets = new int[SectorInts];
		chunkTimestamps = new int[SectorInts];
		fileName = path;
		Debugln("REGION LOAD " + fileName);
		sizeDelta = 0;
		ReadFile();
	}

	~RegionFile()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && file != null)
		{
			lock (fileLock)
			{
				file.Close();
				file = null;
			}
		}
		_disposed = true;
	}

	protected void ReadFile()
	{
		if (_disposed)
		{
			throw new ObjectDisposedException("RegionFile", "Attempting to use a RegionFile after it has been disposed.");
		}
		long num = -1L;
		try
		{
			if (File.Exists(fileName))
			{
				num = Timestamp(File.GetLastWriteTime(fileName));
			}
		}
		catch (UnauthorizedAccessException ex)
		{
			Console.WriteLine(ex.Message);
			return;
		}
		if (num == lastModified)
		{
			return;
		}
		try
		{
			lock (fileLock)
			{
				file = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
				if (file.Length < SectorBytes)
				{
					byte[] bytes = BitConverter.GetBytes(0);
					for (int i = 0; i < SectorInts; i++)
					{
						file.Write(bytes, 0, 4);
					}
					for (int j = 0; j < SectorInts; j++)
					{
						file.Write(bytes, 0, 4);
					}
					file.Flush();
					sizeDelta += SectorBytes * 2;
				}
				if ((file.Length & 0xFFF) != 0)
				{
					file.Seek(0L, SeekOrigin.End);
					for (int k = 0; k < (file.Length & 0xFFF); k++)
					{
						file.WriteByte(0);
					}
					file.Flush();
				}
				int num2 = (int)file.Length / SectorBytes;
				sectorFree = new List<bool>(num2);
				for (int l = 0; l < num2; l++)
				{
					sectorFree.Add(item: true);
				}
				sectorFree[0] = false;
				sectorFree[1] = false;
				file.Seek(0L, SeekOrigin.Begin);
				for (int m = 0; m < SectorInts; m++)
				{
					byte[] array = new byte[4];
					file.Read(array, 0, 4);
					if (BitConverter.IsLittleEndian)
					{
						Array.Reverse(array);
					}
					int num3 = BitConverter.ToInt32(array, 0);
					offsets[m] = num3;
					if (num3 != 0 && (num3 >> 8) + (num3 & 0xFF) <= sectorFree.Count)
					{
						for (int n = 0; n < (num3 & 0xFF); n++)
						{
							sectorFree[(num3 >> 8) + n] = false;
						}
					}
				}
				for (int num4 = 0; num4 < SectorInts; num4++)
				{
					byte[] array2 = new byte[4];
					file.Read(array2, 0, 4);
					if (BitConverter.IsLittleEndian)
					{
						Array.Reverse(array2);
					}
					int num5 = BitConverter.ToInt32(array2, 0);
					chunkTimestamps[num4] = num5;
				}
			}
		}
		catch (IOException ex2)
		{
			Console.WriteLine(ex2.Message);
			Console.WriteLine(ex2.StackTrace);
		}
	}

	public long LastModified()
	{
		return lastModified;
	}

	public int GetSizeDelta()
	{
		int result = sizeDelta;
		sizeDelta = 0;
		return result;
	}

	private void Debug(string str)
	{
	}

	private void Debugln(string str)
	{
		Debug(str + "\n");
	}

	private void Debug(string mode, int x, int z, string str)
	{
		Debug("REGION " + mode + " " + fileName + "[" + x + "," + z + "] = " + str);
	}

	private void Debug(string mode, int x, int z, int count, string str)
	{
		Debug("REGION " + mode + " " + fileName + "[" + x + "," + z + "] " + count + "B = " + str);
	}

	private void Debugln(string mode, int x, int z, string str)
	{
		Debug(mode, x, z, str + "\n");
	}

	public Stream GetChunkDataInputStream(int x, int z)
	{
		if (_disposed)
		{
			throw new ObjectDisposedException("RegionFile", "Attempting to use a RegionFile after it has been disposed.");
		}
		if (OutOfBounds(x, z))
		{
			Debugln("READ", x, z, "out of bounds");
			return null;
		}
		try
		{
			int offset = GetOffset(x, z);
			if (offset == 0)
			{
				return null;
			}
			int num = offset >> 8;
			int num2 = offset & 0xFF;
			lock (fileLock)
			{
				if (num + num2 > sectorFree.Count)
				{
					Debugln("READ", x, z, "invalid sector");
					return null;
				}
				file.Seek(num * SectorBytes, SeekOrigin.Begin);
				byte[] array = new byte[4];
				file.Read(array, 0, 4);
				if (BitConverter.IsLittleEndian)
				{
					Array.Reverse(array);
				}
				int num3 = BitConverter.ToInt32(array, 0);
				if (num3 > SectorBytes * num2)
				{
					Debugln("READ", x, z, "invalid length: " + num3 + " > 4096 * " + num2);
					return null;
				}
				byte b = (byte)file.ReadByte();
				switch (b)
				{
				case 1:
				{
					byte[] array3 = new byte[num3 - 1];
					file.Read(array3, 0, array3.Length);
					return new GZipStream(new MemoryStream(array3), CompressionMode.Decompress);
				}
				case 2:
				{
					byte[] array2 = new byte[num3 - 1];
					file.Read(array2, 0, array2.Length);
					return new ZlibStream(new MemoryStream(array2), CompressionMode.Decompress, leaveOpen: true);
				}
				default:
					Debugln("READ", x, z, "unknown version " + b);
					return null;
				}
			}
		}
		catch (IOException)
		{
			Debugln("READ", x, z, "exception");
			return null;
		}
	}

	public Stream GetChunkDataOutputStream(int x, int z)
	{
		if (OutOfBounds(x, z))
		{
			return null;
		}
		return new ZlibStream(new ChunkBuffer(this, x, z), CompressionMode.Compress);
	}

	public Stream GetChunkDataOutputStream(int x, int z, int timestamp)
	{
		if (OutOfBounds(x, z))
		{
			return null;
		}
		return new ZlibStream(new ChunkBuffer(this, x, z, timestamp), CompressionMode.Compress);
	}

	protected void Write(int x, int z, byte[] data, int length)
	{
		Write(x, z, data, length, Timestamp());
	}

	protected void Write(int x, int z, byte[] data, int length, int timestamp)
	{
		if (_disposed)
		{
			throw new ObjectDisposedException("RegionFile", "Attempting to use a RegionFile after it has been disposed.");
		}
		try
		{
			int offset = GetOffset(x, z);
			int num = offset >> 8;
			int num2 = offset & 0xFF;
			int num3 = (length + 5) / SectorBytes + 1;
			if (num3 >= 256)
			{
				return;
			}
			if (num != 0 && num2 == num3)
			{
				Debug("SAVE", x, z, length, "rewrite");
				Write(num, data, length);
			}
			else
			{
				lock (fileLock)
				{
					for (int i = 0; i < num2; i++)
					{
						sectorFree[num + i] = true;
					}
					int num4 = sectorFree.FindIndex((bool b) => b);
					int num5 = 0;
					if (num4 != -1)
					{
						for (int num6 = num4; num6 < sectorFree.Count; num6++)
						{
							if (num5 != 0)
							{
								num5 = (sectorFree[num6] ? (num5 + 1) : 0);
							}
							else if (sectorFree[num6])
							{
								num4 = num6;
								num5 = 1;
							}
							if (num5 >= num3)
							{
								break;
							}
						}
					}
					if (num5 >= num3)
					{
						Debug("SAVE", x, z, length, "reuse");
						num = num4;
						SetOffset(x, z, (num << 8) | num3);
						for (int num7 = 0; num7 < num3; num7++)
						{
							sectorFree[num + num7] = false;
						}
						Write(num, data, length);
					}
					else
					{
						Debug("SAVE", x, z, length, "grow");
						file.Seek(0L, SeekOrigin.End);
						num = sectorFree.Count;
						for (int num8 = 0; num8 < num3; num8++)
						{
							file.Write(emptySector, 0, emptySector.Length);
							sectorFree.Add(item: false);
						}
						sizeDelta += SectorBytes * num3;
						Write(num, data, length);
						SetOffset(x, z, (num << 8) | num3);
					}
				}
			}
			SetTimestamp(x, z, timestamp);
		}
		catch (IOException ex)
		{
			Console.WriteLine(ex.StackTrace);
		}
	}

	private void Write(int sectorNumber, byte[] data, int length)
	{
		lock (fileLock)
		{
			Debugln(" " + sectorNumber);
			file.Seek(sectorNumber * SectorBytes, SeekOrigin.Begin);
			byte[] bytes = BitConverter.GetBytes(length + 1);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(bytes);
			}
			file.Write(bytes, 0, 4);
			file.WriteByte(2);
			file.Write(data, 0, length);
		}
	}

	public void DeleteChunk(int x, int z)
	{
		lock (fileLock)
		{
			int offset = GetOffset(x, z);
			int num = offset >> 8;
			int num2 = offset & 0xFF;
			file.Seek(num * SectorBytes, SeekOrigin.Begin);
			for (int i = 0; i < num2; i++)
			{
				file.Write(emptySector, 0, SectorBytes);
			}
			SetOffset(x, z, 0);
			SetTimestamp(x, z, 0);
		}
	}

	private bool OutOfBounds(int x, int z)
	{
		if (x >= 0 && x < 32 && z >= 0)
		{
			return z >= 32;
		}
		return true;
	}

	private int GetOffset(int x, int z)
	{
		return offsets[x + z * 32];
	}

	public bool HasChunk(int x, int z)
	{
		return GetOffset(x, z) != 0;
	}

	private void SetOffset(int x, int z, int offset)
	{
		lock (fileLock)
		{
			offsets[x + z * 32] = offset;
			file.Seek((x + z * 32) * 4, SeekOrigin.Begin);
			byte[] bytes = BitConverter.GetBytes(offset);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(bytes);
			}
			file.Write(bytes, 0, 4);
		}
	}

	private int Timestamp()
	{
		DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
		return (int)((DateTime.UtcNow - dateTime).Ticks / 10000000);
	}

	private int Timestamp(DateTime time)
	{
		DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
		return (int)((time - dateTime).Ticks / 10000000);
	}

	public int GetTimestamp(int x, int z)
	{
		return chunkTimestamps[x + z * 32];
	}

	public void SetTimestamp(int x, int z, int value)
	{
		lock (fileLock)
		{
			chunkTimestamps[x + z * 32] = value;
			file.Seek(SectorBytes + (x + z * 32) * 4, SeekOrigin.Begin);
			byte[] bytes = BitConverter.GetBytes(value);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(bytes);
			}
			file.Write(bytes, 0, 4);
		}
	}

	public void Close()
	{
		lock (fileLock)
		{
			file.Close();
		}
	}

	public virtual RegionKey parseCoordinatesFromName()
	{
		int num = 0;
		int num2 = 0;
		Match match = _namePattern.Match(fileName);
		if (!match.Success)
		{
			return RegionKey.InvalidRegion;
		}
		num = Convert.ToInt32(match.Groups[1].Value);
		num2 = Convert.ToInt32(match.Groups[2].Value);
		return new RegionKey(num, num2);
	}
}
