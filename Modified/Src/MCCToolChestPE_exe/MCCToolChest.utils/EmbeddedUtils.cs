using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using NsF2F1XiJAVBnudIoxZ;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.utils;

public class EmbeddedUtils
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetResource(string fileName)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Assembly executingAssembly = Assembly.GetExecutingAssembly();
		string empty = string.Empty;
		yfs8Q5XRDNZPbwaTSae.F5YS5sHsi0L(executingAssembly);
		Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(214344) + fileName);
		StreamReader streamReader = new StreamReader(manifestResourceStream);
		empty = streamReader.ReadToEnd();
		streamReader.Close();
		return empty;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static byte[] GetResourceBytes(string fileName)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Assembly executingAssembly = Assembly.GetExecutingAssembly();
		_ = string.Empty;
		yfs8Q5XRDNZPbwaTSae.F5YS5sHsi0L(executingAssembly);
		Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(214344) + fileName);
		byte[] array = new byte[manifestResourceStream.Length];
		manifestResourceStream.Read(array, 0, array.Length);
		manifestResourceStream.Close();
		return array;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EmbeddedUtils()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}
}
