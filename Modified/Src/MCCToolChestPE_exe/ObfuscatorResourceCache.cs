using System.IO;
using System.Reflection;

internal static class ObfuscatorResourceCache
{
	internal const string UxxdnResourceName = "UXXDn3cvaSJiMtEimR.14FmER7TIdULJkLVey";

	internal const string VfxResourceName = "56VNfxQrwOeY2geE3i.76YChJEysnAtodwYU0";

	private static byte[] uxxdnPayload;

	private static byte[] vfxPayload;

	private static bool loaded;

	internal static void EnsureLoaded()
	{
		if (loaded)
		{
			return;
		}

		loaded = true;
		Assembly asm = typeof(ObfuscatorResourceCache).Assembly;
		uxxdnPayload = ReadResourceBytes(asm, UxxdnResourceName);
		vfxPayload = ReadResourceBytes(asm, VfxResourceName);
	}

	internal static Stream Open(string resourceName)
	{
		EnsureLoaded();
		if (resourceName == UxxdnResourceName && uxxdnPayload != null)
		{
			return new MemoryStream(uxxdnPayload, writable: false);
		}

		if (resourceName == VfxResourceName && vfxPayload != null)
		{
			return new MemoryStream(vfxPayload, writable: false);
		}

		return null;
	}

	private static byte[] ReadResourceBytes(Assembly asm, string resourceName)
	{
		using Stream stream = asm.GetManifestResourceStream(resourceName);
		if (stream == null)
		{
			return null;
		}

		byte[] buffer = new byte[stream.Length];
		int offset = 0;
		while (offset < buffer.Length)
		{
			int read = stream.Read(buffer, offset, buffer.Length - offset);
			if (read == 0)
			{
				break;
			}

			offset += read;
		}

		return buffer;
	}
}
