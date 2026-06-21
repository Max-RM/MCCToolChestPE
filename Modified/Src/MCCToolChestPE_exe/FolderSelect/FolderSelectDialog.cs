using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace FolderSelect;

public class FolderSelectDialog
{
	private OpenFileDialog oNFVFWOJH2;

	public string InitialDirectory
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return oNFVFWOJH2.InitialDirectory;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			oNFVFWOJH2.InitialDirectory = ((value == null || value.Length == 0) ? Environment.CurrentDirectory : value);
		}
	}

	public string Title
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return oNFVFWOJH2.Title;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			oNFVFWOJH2.Title = ((value == null) ? Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13258) : value);
		}
	}

	public string FileName
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return oNFVFWOJH2.FileName;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public FolderSelectDialog()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		oNFVFWOJH2 = new OpenFileDialog();
		oNFVFWOJH2.Filter = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13236);
		oNFVFWOJH2.AddExtension = false;
		oNFVFWOJH2.CheckFileExists = false;
		oNFVFWOJH2.DereferenceLinks = true;
		oNFVFWOJH2.Multiselect = false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool ShowDialog()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return ShowDialog(IntPtr.Zero);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool ShowDialog(IntPtr hWndOwner)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bool result = false;
		if (Environment.OSVersion.Version.Major >= 6)
		{
			Reflector reflector = new Reflector(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13292));
			uint num = 0u;
			Type type = reflector.GetType(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13336));
			object obj = reflector.Call(oNFVFWOJH2, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13396));
			reflector.Call(oNFVFWOJH2, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13434), obj);
			uint num2 = (uint)reflector.CallAs(typeof(FileDialog), oNFVFWOJH2, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13476));
			num2 |= (uint)reflector.GetEnum(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13500), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13544));
			reflector.CallAs(type, obj, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13578), num2);
			object obj2 = reflector.New(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13602), oNFVFWOJH2);
			object[] array = new object[2] { obj2, num };
			reflector.CallAs2(type, obj, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13662), array);
			num = (uint)array[1];
			try
			{
				int num3 = (int)reflector.CallAs(type, obj, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13678), hWndOwner);
				result = 0 == num3;
			}
			finally
			{
				reflector.CallAs(type, obj, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13690), num);
				GC.KeepAlive(obj2);
			}
		}
		else
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			folderBrowserDialog.Description = Title;
			folderBrowserDialog.SelectedPath = InitialDirectory;
			folderBrowserDialog.ShowNewFolderButton = false;
			if (folderBrowserDialog.ShowDialog(new WindowWrapper(hWndOwner)) != DialogResult.OK)
			{
				return false;
			}
			oNFVFWOJH2.FileName = folderBrowserDialog.SelectedPath;
			result = true;
		}
		return result;
	}
}
