using System;
using System.IO;
using System.Runtime.CompilerServices;
using MCCToolChest.utils;
using pdmCJqu7Vy6R8l3B4bD;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.worker;

public class DeleteFolderWorker
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DoDelete(object threadContext)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		b9JNX7uNnV588Slcyuy b9JNX7uNnV588Slcyuy2 = threadContext as b9JNX7uNnV588Slcyuy;
		try
		{
			DateTime dateTime = DateTime.Now.AddDays(-1.0);
			string path = FileUtils.CheckFolderSep(Path.GetTempPath()) + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(246304);
			DirectoryInfo directoryInfo = new DirectoryInfo(path);
			if (directoryInfo != null)
			{
				DirectoryInfo[] directories = directoryInfo.GetDirectories();
				DirectoryInfo[] array = directories;
				foreach (DirectoryInfo directoryInfo2 in array)
				{
					if (directoryInfo2.CreationTime < dateTime)
					{
						directoryInfo2.Delete(recursive: true);
					}
				}
			}
		}
		catch (Exception)
		{
		}
		b9JNX7uNnV588Slcyuy2.IN7SYfi6jwg().Set();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DeleteFolderWorker()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}
}
