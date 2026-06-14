using System;
using System.IO;
using System.Security.Cryptography;

namespace NAppUpdate.Framework.Utils;

public static class FileChecksum
{
	public static string GetSHA256Checksum(string filePath)
	{
		using FileStream inputStream = File.OpenRead(filePath);
		SHA256Managed sHA256Managed = new SHA256Managed();
		byte[] array = sHA256Managed.ComputeHash(inputStream);
		return BitConverter.ToString(array).Replace("-", string.Empty);
	}

	public static string GetSHA256Checksum(byte[] fileData)
	{
		SHA256Managed sHA256Managed = new SHA256Managed();
		byte[] array = sHA256Managed.ComputeHash(fileData);
		return BitConverter.ToString(array).Replace("-", string.Empty);
	}
}
