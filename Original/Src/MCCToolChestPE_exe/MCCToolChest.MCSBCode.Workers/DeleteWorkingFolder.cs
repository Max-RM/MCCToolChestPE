using System;
using System.IO;
using System.Runtime.CompilerServices;
using MCCToolChest.model;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.MCSBCode.Workers;

public class DeleteWorkingFolder
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DoDelete(object threadContext)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		DeleteFolderParameter deleteFolderParameter = threadContext as DeleteFolderParameter;
		if (deleteFolderParameter != null && !string.IsNullOrWhiteSpace(deleteFolderParameter.OldFolderPath))
		{
			try
			{
				Directory.Delete(deleteFolderParameter.OldFolderPath, recursive: true);
			}
			catch (Exception)
			{
			}
		}
		deleteFolderParameter.DoneEvent.Set();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DeleteWorkingFolder()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}
}
