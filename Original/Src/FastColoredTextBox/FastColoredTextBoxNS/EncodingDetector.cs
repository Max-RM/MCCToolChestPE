using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace FastColoredTextBoxNS;

public static class EncodingDetector
{
	private const long _defaultHeuristicSampleSize = 65536L;

	public static Encoding DetectTextFileEncoding(string InputFilename)
	{
		using FileStream inputFileStream = File.OpenRead(InputFilename);
		return DetectTextFileEncoding(inputFileStream, 65536L);
	}

	public static Encoding DetectTextFileEncoding(FileStream InputFileStream, long HeuristicSampleSize)
	{
		bool HasBOM = false;
		return DetectTextFileEncoding(InputFileStream, 65536L, out HasBOM);
	}

	public static Encoding DetectTextFileEncoding(FileStream InputFileStream, long HeuristicSampleSize, out bool HasBOM)
	{
		Encoding encoding = null;
		long position = InputFileStream.Position;
		InputFileStream.Position = 0L;
		byte[] array = new byte[(InputFileStream.Length > 4) ? 4 : InputFileStream.Length];
		InputFileStream.Read(array, 0, array.Length);
		encoding = DetectBOMBytes(array);
		if (encoding != null)
		{
			InputFileStream.Position = position;
			HasBOM = true;
			return encoding;
		}
		byte[] array2 = new byte[(HeuristicSampleSize > InputFileStream.Length) ? InputFileStream.Length : HeuristicSampleSize];
		Array.Copy(array, array2, array.Length);
		if (InputFileStream.Length > array.Length)
		{
			InputFileStream.Read(array2, array.Length, array2.Length - array.Length);
		}
		InputFileStream.Position = position;
		encoding = DetectUnicodeInByteSampleByHeuristics(array2);
		HasBOM = false;
		return encoding;
	}

	public static Encoding DetectBOMBytes(byte[] BOMBytes)
	{
		if (BOMBytes.Length < 2)
		{
			return null;
		}
		if (BOMBytes[0] == byte.MaxValue && BOMBytes[1] == 254 && (BOMBytes.Length < 4 || BOMBytes[2] != 0 || BOMBytes[3] != 0))
		{
			return Encoding.Unicode;
		}
		if (BOMBytes[0] == 254 && BOMBytes[1] == byte.MaxValue)
		{
			return Encoding.BigEndianUnicode;
		}
		if (BOMBytes.Length < 3)
		{
			return null;
		}
		if (BOMBytes[0] == 239 && BOMBytes[1] == 187 && BOMBytes[2] == 191)
		{
			return Encoding.UTF8;
		}
		if (BOMBytes[0] == 43 && BOMBytes[1] == 47 && BOMBytes[2] == 118)
		{
			return Encoding.UTF7;
		}
		if (BOMBytes.Length < 4)
		{
			return null;
		}
		if (BOMBytes[0] == byte.MaxValue && BOMBytes[1] == 254 && BOMBytes[2] == 0 && BOMBytes[3] == 0)
		{
			return Encoding.UTF32;
		}
		if (BOMBytes[0] == 0 && BOMBytes[1] == 0 && BOMBytes[2] == 254 && BOMBytes[3] == byte.MaxValue)
		{
			return Encoding.GetEncoding(12001);
		}
		return null;
	}

	public static Encoding DetectUnicodeInByteSampleByHeuristics(byte[] SampleBytes)
	{
		long num = 0L;
		long num2 = 0L;
		long num3 = 0L;
		long num4 = 0L;
		long num5 = 0L;
		long num6 = 0L;
		int num7 = 0;
		for (; num6 < SampleBytes.Length; num6++)
		{
			if (SampleBytes[num6] == 0)
			{
				if (num6 % 2 == 0)
				{
					num2++;
				}
				else
				{
					num++;
				}
			}
			if (IsCommonUSASCIIByte(SampleBytes[num6]))
			{
				num5++;
			}
			if (num7 == 0)
			{
				int num8 = DetectSuspiciousUTF8SequenceLength(SampleBytes, num6);
				if (num8 > 0)
				{
					num3++;
					num4 += num8;
					num7 = num8 - 1;
				}
			}
			else
			{
				num7--;
			}
		}
		if ((double)num2 * 2.0 / (double)SampleBytes.Length < 0.2 && (double)num * 2.0 / (double)SampleBytes.Length > 0.6)
		{
			return Encoding.Unicode;
		}
		if ((double)num * 2.0 / (double)SampleBytes.Length < 0.2 && (double)num2 * 2.0 / (double)SampleBytes.Length > 0.6)
		{
			return Encoding.BigEndianUnicode;
		}
		string input = Encoding.ASCII.GetString(SampleBytes);
		Regex regex = new Regex("\\A([\\x09\\x0A\\x0D\\x20-\\x7E]|[\\xC2-\\xDF][\\x80-\\xBF]|\\xE0[\\xA0-\\xBF][\\x80-\\xBF]|[\\xE1-\\xEC\\xEE\\xEF][\\x80-\\xBF]{2}|\\xED[\\x80-\\x9F][\\x80-\\xBF]|\\xF0[\\x90-\\xBF][\\x80-\\xBF]{2}|[\\xF1-\\xF3][\\x80-\\xBF]{3}|\\xF4[\\x80-\\x8F][\\x80-\\xBF]{2})*\\z");
		if (regex.IsMatch(input) && (double)num3 * 500000.0 / (double)SampleBytes.Length >= 1.0 && (SampleBytes.Length - num4 == 0L || (double)num5 * 1.0 / (double)(SampleBytes.Length - num4) >= 0.8))
		{
			return Encoding.UTF8;
		}
		return null;
	}

	private static bool IsCommonUSASCIIByte(byte testByte)
	{
		switch (testByte)
		{
		default:
			if ((testByte < 48 || testByte > 57) && (testByte < 58 || testByte > 64) && (testByte < 65 || testByte > 90) && (testByte < 91 || testByte > 96) && (testByte < 97 || testByte > 122) && (testByte < 123 || testByte > 126))
			{
				break;
			}
			goto case 9;
		case 9:
		case 10:
		case 13:
		case 32:
		case 33:
		case 34:
		case 35:
		case 36:
		case 37:
		case 38:
		case 39:
		case 40:
		case 41:
		case 42:
		case 43:
		case 44:
		case 45:
		case 46:
		case 47:
			return true;
		}
		return false;
	}

	private static int DetectSuspiciousUTF8SequenceLength(byte[] SampleBytes, long currentPos)
	{
		int result = 0;
		if (SampleBytes.Length >= currentPos + 1 && SampleBytes[currentPos] == 194)
		{
			if (SampleBytes[currentPos + 1] == 129 || SampleBytes[currentPos + 1] == 141 || SampleBytes[currentPos + 1] == 143)
			{
				result = 2;
			}
			else if (SampleBytes[currentPos + 1] == 144 || SampleBytes[currentPos + 1] == 157)
			{
				result = 2;
			}
			else if (SampleBytes[currentPos + 1] >= 160 && SampleBytes[currentPos + 1] <= 191)
			{
				result = 2;
			}
		}
		else if (SampleBytes.Length >= currentPos + 1 && SampleBytes[currentPos] == 195)
		{
			if (SampleBytes[currentPos + 1] >= 128 && SampleBytes[currentPos + 1] <= 191)
			{
				result = 2;
			}
		}
		else if (SampleBytes.Length >= currentPos + 1 && SampleBytes[currentPos] == 197)
		{
			if (SampleBytes[currentPos + 1] == 146 || SampleBytes[currentPos + 1] == 147)
			{
				result = 2;
			}
			else if (SampleBytes[currentPos + 1] == 160 || SampleBytes[currentPos + 1] == 161)
			{
				result = 2;
			}
			else if (SampleBytes[currentPos + 1] == 184 || SampleBytes[currentPos + 1] == 189 || SampleBytes[currentPos + 1] == 190)
			{
				result = 2;
			}
		}
		else if (SampleBytes.Length >= currentPos + 1 && SampleBytes[currentPos] == 198)
		{
			if (SampleBytes[currentPos + 1] == 146)
			{
				result = 2;
			}
		}
		else if (SampleBytes.Length >= currentPos + 1 && SampleBytes[currentPos] == 203)
		{
			if (SampleBytes[currentPos + 1] == 134 || SampleBytes[currentPos + 1] == 156)
			{
				result = 2;
			}
		}
		else if (SampleBytes.Length >= currentPos + 2 && SampleBytes[currentPos] == 226)
		{
			if (SampleBytes[currentPos + 1] == 128)
			{
				if (SampleBytes[currentPos + 2] == 147 || SampleBytes[currentPos + 2] == 148)
				{
					result = 3;
				}
				if (SampleBytes[currentPos + 2] == 152 || SampleBytes[currentPos + 2] == 153 || SampleBytes[currentPos + 2] == 154)
				{
					result = 3;
				}
				if (SampleBytes[currentPos + 2] == 156 || SampleBytes[currentPos + 2] == 157 || SampleBytes[currentPos + 2] == 158)
				{
					result = 3;
				}
				if (SampleBytes[currentPos + 2] == 160 || SampleBytes[currentPos + 2] == 161 || SampleBytes[currentPos + 2] == 162)
				{
					result = 3;
				}
				if (SampleBytes[currentPos + 2] == 166)
				{
					result = 3;
				}
				if (SampleBytes[currentPos + 2] == 176)
				{
					result = 3;
				}
				if (SampleBytes[currentPos + 2] == 185 || SampleBytes[currentPos + 2] == 186)
				{
					result = 3;
				}
			}
			else if (SampleBytes[currentPos + 1] == 130 && SampleBytes[currentPos + 2] == 172)
			{
				result = 3;
			}
			else if (SampleBytes[currentPos + 1] == 132 && SampleBytes[currentPos + 2] == 162)
			{
				result = 3;
			}
		}
		return result;
	}
}
