using System;
using System.IO;
using Ionic.Zlib;
using Substrate.Nbt;

namespace Substrate.Core;

public class NBTFile
{
	private class NBTBuffer : MemoryStream
	{
		private NBTFile file;

		public NBTBuffer(NBTFile c)
			: base(8096)
		{
			file = c;
		}

		public override void Close()
		{
			FileStream fileStream;
			try
			{
				fileStream = new FileStream(file._filename, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
			}
			catch (Exception innerException)
			{
				throw new NbtIOException("Failed to open NBT data stream for output.", innerException);
			}
			try
			{
				fileStream.Write(GetBuffer(), 0, (int)Length);
				fileStream.Close();
			}
			catch (Exception innerException2)
			{
				throw new NbtIOException("Failed to write out NBT data stream.", innerException2);
			}
		}
	}

	private string _filename;

	public string FileName
	{
		get
		{
			return _filename;
		}
		protected set
		{
			_filename = value;
		}
	}

	public NBTFile(string path)
	{
		_filename = path;
	}

	public bool Exists()
	{
		return File.Exists(_filename);
	}

	public void Delete()
	{
		File.Delete(_filename);
	}

	public int GetModifiedTime()
	{
		return Timestamp(File.GetLastWriteTime(_filename));
	}

	public Stream GetDataInputStream()
	{
		return GetDataInputStream(CompressionType.GZip);
	}

	public virtual Stream GetDataInputStream(CompressionType compression)
	{
		try
		{
			FileStream fileStream = new FileStream(_filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			long num = fileStream.Seek(0L, SeekOrigin.End);
			fileStream.Seek(0L, SeekOrigin.Begin);
			byte[] array = new byte[num];
			fileStream.Read(array, 0, array.Length);
			fileStream.Close();
			return compression switch
			{
				CompressionType.None => new MemoryStream(array), 
				CompressionType.GZip => new GZipStream(new MemoryStream(array), CompressionMode.Decompress), 
				CompressionType.Zlib => new ZlibStream(new MemoryStream(array), CompressionMode.Decompress), 
				CompressionType.Deflate => new DeflateStream(new MemoryStream(array), CompressionMode.Decompress), 
				_ => throw new ArgumentException("Invalid CompressionType specified", "compression"), 
			};
		}
		catch (Exception innerException)
		{
			throw new NbtIOException("Failed to open compressed NBT data stream for input.", innerException);
		}
	}

	public Stream GetDataOutputStream()
	{
		return GetDataOutputStream(CompressionType.GZip);
	}

	public virtual Stream GetDataOutputStream(CompressionType compression)
	{
		try
		{
			return compression switch
			{
				CompressionType.None => new NBTBuffer(this), 
				CompressionType.GZip => new GZipStream(new NBTBuffer(this), CompressionMode.Compress), 
				CompressionType.Zlib => new ZlibStream(new NBTBuffer(this), CompressionMode.Compress), 
				CompressionType.Deflate => new DeflateStream(new NBTBuffer(this), CompressionMode.Compress), 
				_ => throw new ArgumentException("Invalid CompressionType specified", "compression"), 
			};
		}
		catch (Exception innerException)
		{
			throw new NbtIOException("Failed to initialize compressed NBT data stream for output.", innerException);
		}
	}

	private int Timestamp(DateTime time)
	{
		DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
		return (int)((time - dateTime).Ticks / 10000000);
	}
}
