using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.ClearScript.Util;

internal static class MiscHelpers
{
	private static readonly char[] searchPathSeparators = new char[1] { ';' };

	public static object CreateCOMObject(string progID, string serverName)
	{
		return Activator.CreateInstance(GetCOMType(progID, serverName));
	}

	public static object CreateCOMObject(Guid clsid, string serverName)
	{
		return Activator.CreateInstance(GetCOMType(clsid, serverName));
	}

	public static bool TryCreateCOMObject<T>(string progID, string serverName, out T obj) where T : class
	{
		if (!TryGetCOMType(progID, serverName, out var type))
		{
			obj = null;
			return false;
		}
		obj = Activator.CreateInstance(type) as T;
		return obj != null;
	}

	public static bool TryCreateCOMObject<T>(Guid clsid, string serverName, out T obj) where T : class
	{
		if (!TryGetCOMType(clsid, serverName, out var type))
		{
			obj = null;
			return false;
		}
		obj = Activator.CreateInstance(type) as T;
		return obj != null;
	}

	public static Type GetCOMType(string progID, string serverName)
	{
		VerifyNonBlankArgument(progID, "progID", "Invalid programmatic identifier (ProgID)");
		if (!TryGetCOMType(progID, serverName, out var type))
		{
			throw new TypeLoadException(FormatInvariant("Could not find a registered class for '{0}'", progID));
		}
		return type;
	}

	public static Type GetCOMType(Guid clsid, string serverName)
	{
		if (!TryGetCOMType(clsid, serverName, out var type))
		{
			throw new TypeLoadException(FormatInvariant("Could not find a registered class for '{0}'", clsid.ToString("B")));
		}
		return type;
	}

	public static bool TryGetCOMType(string progID, string serverName, out Type type)
	{
		type = (Guid.TryParseExact(progID, "B", out var result) ? Type.GetTypeFromCLSID(result, serverName) : Type.GetTypeFromProgID(progID, serverName));
		return type != null;
	}

	public static bool TryGetCOMType(Guid clsid, string serverName, out Type type)
	{
		type = Type.GetTypeFromCLSID(clsid, serverName);
		return type != null;
	}

	public static string GetDispIDName(int dispid)
	{
		return FormatInvariant("[DISPID={0}]", dispid);
	}

	public static void VerifyNonNullArgument(object value, string name)
	{
		if (value == null)
		{
			throw new ArgumentNullException(name);
		}
	}

	public static void VerifyNonBlankArgument(string value, string name, string message)
	{
		if (string.IsNullOrWhiteSpace(value))
		{
			throw new ArgumentException(message, name);
		}
	}

	public static string EnsureNonBlank(string input, string alternate)
	{
		if (!string.IsNullOrWhiteSpace(input))
		{
			return input;
		}
		return alternate;
	}

	public static string FormatInvariant(string format, params object[] args)
	{
		return string.Format(CultureInfo.InvariantCulture, format, args);
	}

	public static StringBuilder AppendInvariant(this StringBuilder builder, string format, params object[] args)
	{
		return builder.AppendFormat(CultureInfo.InvariantCulture, format, args);
	}

	public static string FormatCode(string code)
	{
		string[] source = (code ?? string.Empty).Replace("\r\n", "\n").Split('\n');
		source = source.SkipWhile(string.IsNullOrWhiteSpace).Reverse().SkipWhile(string.IsNullOrWhiteSpace)
			.Reverse()
			.ToArray();
		if (source.Length != 0)
		{
			string text = source[0];
			for (int num = text.TakeWhile(char.IsWhiteSpace).Count(); num > 0; num--)
			{
				string indent = text.Substring(0, num);
				if (source.Skip(1).All((string line) => string.IsNullOrWhiteSpace(line) || line.StartsWith(indent, StringComparison.Ordinal)))
				{
					source = source.Select((string line) => (!string.IsNullOrWhiteSpace(line)) ? line.Substring(indent.Length) : string.Empty).ToArray();
					break;
				}
			}
		}
		return string.Join("\n", source) + "\n";
	}

	public static string GetUrlOrPath(Uri uri, string alternate)
	{
		if (uri == null)
		{
			return alternate;
		}
		if (!uri.IsAbsoluteUri)
		{
			return uri.ToString();
		}
		if (uri.IsFile)
		{
			return uri.LocalPath;
		}
		return uri.AbsoluteUri;
	}

	public static string ToQuotedJson(this string value)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append('"');
		foreach (char c in value)
		{
			switch (c)
			{
			case '"':
				stringBuilder.Append("\\\"");
				break;
			case '\\':
				stringBuilder.Append("\\\\");
				break;
			default:
				stringBuilder.Append(c);
				break;
			}
		}
		stringBuilder.Append('"');
		return stringBuilder.ToString();
	}

	public static UIntPtr GetDigest(this string code)
	{
		if (UIntPtr.Size != 4)
		{
			return (UIntPtr)code.GetDigestAsUInt64();
		}
		return (UIntPtr)code.GetDigestAsUInt32();
	}

	public static uint GetDigestAsUInt32(this string code)
	{
		uint num = 2166136261u;
		byte[] bytes = Encoding.Unicode.GetBytes(code);
		for (int i = 0; i < bytes.Length; i++)
		{
			num ^= bytes[i];
			num *= 16777619;
		}
		return num;
	}

	public static ulong GetDigestAsUInt64(this string code)
	{
		ulong num = 14695981039346656037uL;
		byte[] bytes = Encoding.Unicode.GetBytes(code);
		for (int i = 0; i < bytes.Length; i++)
		{
			num ^= bytes[i];
			num *= 1099511628211L;
		}
		return num;
	}

	public static IEnumerable<string> SplitSearchPath(this string searchPath)
	{
		return searchPath.Split(searchPathSeparators, StringSplitOptions.RemoveEmptyEntries).Distinct(StringComparer.OrdinalIgnoreCase);
	}

	public static bool TryGetNumericIndex(object arg, out int index)
	{
		if (arg != null)
		{
			TypeCode typeCode = Type.GetTypeCode(arg.GetType());
			if ((uint)(typeCode - 5) <= 4u)
			{
				index = Convert.ToInt32(arg);
				return true;
			}
		}
		index = -1;
		return false;
	}

	public static bool TryGetNumericIndex(object arg, out long index)
	{
		if (arg != null)
		{
			TypeCode typeCode = Type.GetTypeCode(arg.GetType());
			if ((uint)(typeCode - 5) <= 6u)
			{
				index = Convert.ToInt64(arg);
				return true;
			}
		}
		index = -1L;
		return false;
	}

	public static bool Try(Action action)
	{
		try
		{
			action();
			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public static bool Try<T>(out T result, Func<T> func)
	{
		try
		{
			result = func();
			return true;
		}
		catch (Exception)
		{
			result = default(T);
			return false;
		}
	}

	public static async Task<bool> TryAsync(Task task)
	{
		try
		{
			await task.ConfigureAwait(continueOnCapturedContext: false);
			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public static async Task<bool> TryAsync<T>(Holder<T> holder, Task<T> task)
	{
		try
		{
			holder.Value = await task.ConfigureAwait(continueOnCapturedContext: false);
			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public static bool TryMarshalPrimitiveToHost(object obj, out object result)
	{
		if (obj is IConvertible convertible)
		{
			switch (convertible.GetTypeCode())
			{
			case TypeCode.Boolean:
			case TypeCode.String:
				result = obj;
				return true;
			case TypeCode.Single:
			case TypeCode.Double:
				result = MarshalDoubleToHost(convertible.ToDouble(CultureInfo.InvariantCulture));
				return true;
			case TypeCode.Char:
			case TypeCode.SByte:
			case TypeCode.Byte:
			case TypeCode.Int16:
			case TypeCode.UInt16:
			case TypeCode.Int32:
			case TypeCode.UInt32:
			case TypeCode.Int64:
			case TypeCode.UInt64:
			case TypeCode.Decimal:
				result = obj;
				return true;
			}
		}
		result = null;
		return false;
	}

	public static object MarshalDoubleToHost(double value)
	{
		if (Math.Round(value) == value)
		{
			if (Math.Abs(value) <= 9007199254740991.0)
			{
				long num = Convert.ToInt64(value);
				if (num >= int.MinValue && num <= int.MaxValue)
				{
					return (int)num;
				}
				return num;
			}
		}
		else
		{
			float num2 = Convert.ToSingle(value);
			if (value == (double)num2)
			{
				return num2;
			}
		}
		return value;
	}

	public static T Exchange<T>(ref T target, T value)
	{
		T result = target;
		target = value;
		return result;
	}

	public static bool IsX86InstructionSet()
	{
		SystemInfo info;
		try
		{
			NativeMethods.GetNativeSystemInfo(out info);
		}
		catch (EntryPointNotFoundException)
		{
			NativeMethods.GetSystemInfo(out info);
		}
		if (info.ProcessorArchitecture != 0)
		{
			return info.ProcessorArchitecture == 9;
		}
		return true;
	}

	public static void QueueNativeCallback(INativeCallback callback)
	{
		ThreadPool.QueueUserWorkItem(delegate
		{
			using (callback)
			{
				Try(callback.Invoke);
			}
		});
	}

	public static Random CreateSeededRandom()
	{
		return new Random(Convert.ToUInt32(DateTime.Now.Ticks.ToUnsigned() & 0xFFFFFFFFu).ToSigned());
	}

	public static async Task<IDisposable> CreateLockScopeAsync(this SemaphoreSlim semaphore)
	{
		await semaphore.WaitAsync().ConfigureAwait(continueOnCapturedContext: false);
		return Scope.Create(null, delegate
		{
			semaphore.Release();
		});
	}

	public static byte[] ReadToEnd(this Stream stream)
	{
		using MemoryStream memoryStream = new MemoryStream();
		stream.CopyTo(memoryStream);
		return memoryStream.ToArray();
	}

	public static string GetTextContents(this Document document)
	{
		using StreamReader streamReader = new StreamReader(document.Contents, document.Encoding ?? Encoding.UTF8);
		return streamReader.ReadToEnd();
	}

	public static void AssertUnreachable()
	{
	}
}
