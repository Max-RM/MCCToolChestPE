using System;
using System.Runtime.InteropServices;

namespace Microsoft.ClearScript.Util;

internal static class RawCOMHelpers
{
	public static class HResult
	{
		public const int SEVERITY_SUCCESS = 0;

		public const int SEVERITY_ERROR = 1;

		public const int FACILITY_NULL = 0;

		public const int FACILITY_RPC = 1;

		public const int FACILITY_DISPATCH = 2;

		public const int FACILITY_STORAGE = 3;

		public const int FACILITY_ITF = 4;

		public const int FACILITY_WIN32 = 7;

		public const int FACILITY_WINDOWS = 8;

		public const int FACILITY_CONTROL = 10;

		public const int FACILITY_INTERNET = 12;

		public const int FACILITY_URT = 19;

		public const int S_OK = 0;

		public const int S_FALSE = 1;

		public static readonly int E_NOINTERFACE = 2147500034u.ToSigned();

		public static readonly int E_ABORT = 2147500036u.ToSigned();

		public static readonly int E_FAIL = 2147500037u.ToSigned();

		public static readonly int E_INVALIDARG = 2147942487u.ToSigned();

		public static readonly int DISP_E_UNKNOWNNAME = 2147614726u.ToSigned();

		public static readonly int DISP_E_MEMBERNOTFOUND = 2147614723u.ToSigned();

		public static readonly int SCRIPT_E_REPORTED = 2147614977u.ToSigned();

		public static readonly int CLEARSCRIPT_E_HOSTEXCEPTION = MakeResult(1, 19, 47871);

		public static readonly int CLEARSCRIPT_E_SCRIPTITEMEXCEPTION = MakeResult(1, 19, 45311);

		public static void Check(uint result)
		{
			Check(result.ToSigned());
		}

		public static void Check(int result)
		{
			Marshal.ThrowExceptionForHR(result);
		}

		public static bool Succeeded(uint result)
		{
			return GetSeverity(result) == 0;
		}

		public static bool Succeeded(int result)
		{
			return GetSeverity(result) == 0;
		}

		public static int GetSeverity(uint result)
		{
			return GetSeverity(result.ToSigned());
		}

		public static int GetSeverity(int result)
		{
			return (result >> 31) & 1;
		}

		public static int GetFacility(uint result)
		{
			return GetFacility(result.ToSigned());
		}

		public static int GetFacility(int result)
		{
			return (result >> 16) & 0x1FFF;
		}

		public static int GetCode(uint result)
		{
			return GetCode(result.ToSigned());
		}

		public static int GetCode(int result)
		{
			return result & 0xFFFF;
		}

		public static int MakeResult(int severity, int facility, int code)
		{
			return ((uint)((code & 0xFFFF) | ((facility & 0x1FFF) << 16) | ((severity & 1) << 31))).ToSigned();
		}
	}

	public static readonly int VariantSize = 8 + IntPtr.Size * 2;

	public static IntPtr CreateInstance<T>(string progID)
	{
		Guid clsid = CLSIDFromProgID(progID);
		Guid iid = typeof(T).GUID;
		HResult.Check(NativeMethods.CoCreateInstance(ref clsid, IntPtr.Zero, 1u, ref iid, out var pInterface));
		return pInterface;
	}

	public static IntPtr QueryInterface<T>(IntPtr pUnknown)
	{
		Guid iid = typeof(T).GUID;
		HResult.Check(Marshal.QueryInterface(pUnknown, ref iid, out var ppv));
		return ppv;
	}

	public static IntPtr QueryInterfaceNoThrow<T>(IntPtr pUnknown)
	{
		Guid iid = typeof(T).GUID;
		if (Marshal.QueryInterface(pUnknown, ref iid, out var ppv) != 0)
		{
			return IntPtr.Zero;
		}
		return ppv;
	}

	public static T GetMethodDelegate<T>(IntPtr pInterface, int methodIndex) where T : class
	{
		IntPtr intPtr = Marshal.ReadIntPtr(pInterface);
		IntPtr ptr = Marshal.ReadIntPtr(intPtr + methodIndex * IntPtr.Size);
		return Marshal.GetDelegateForFunctionPointer(ptr, typeof(T)) as T;
	}

	public static void ReleaseAndEmpty(ref IntPtr pInterface)
	{
		if (pInterface != IntPtr.Zero)
		{
			Marshal.Release(pInterface);
			pInterface = IntPtr.Zero;
		}
	}

	private static Guid CLSIDFromProgID(string progID)
	{
		if (!Guid.TryParseExact(progID, "B", out var result))
		{
			HResult.Check(NativeMethods.CLSIDFromProgID(progID, out result));
		}
		return result;
	}
}
