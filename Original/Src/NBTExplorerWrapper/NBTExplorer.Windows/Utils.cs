using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace NBTExplorer.Windows;

public class Utils
{
	public static bool IsHex(IEnumerable<char> chars)
	{
		foreach (char @char in chars)
		{
			if ((@char < '0' || @char > '9') && (@char < 'a' || @char > 'f') && (@char < 'A' || @char > 'F'))
			{
				return false;
			}
		}
		return true;
	}

	public static string ConvertByteToHexString(byte b)
	{
		return $"{b:x2}";
	}

	public static string ConvertByteArrayToHexString(byte[] ba)
	{
		StringBuilder stringBuilder = new StringBuilder(ba.Length * 2);
		foreach (byte b in ba)
		{
			stringBuilder.AppendFormat("{0:x2}", b);
		}
		return stringBuilder.ToString();
	}

	public static byte[] ConvertHexStringToByteArray(string hexString)
	{
		byte[] array = null;
		try
		{
			if (hexString.Length % 2 == 0)
			{
				array = new byte[hexString.Length / 2];
				for (int i = 0; i < array.Length; i++)
				{
					string s = hexString.Substring(i * 2, 2);
					array[i] = byte.Parse(s, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
				}
			}
		}
		catch (Exception)
		{
		}
		return array;
	}
}
