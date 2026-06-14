using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using YBh7EaXMWmkFRJOX37M;

namespace Save_Manager.model;

public class PS3GameFile
{
	private string ybQSe2qiHP8;

	private string FAUSeyAR6eo;

	private byte[] n7pSe065YWd;

	private long uAJSeB1ZnR8;

	private MemoryStream tD3Sets4n6F;

	public string Name
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return ybQSe2qiHP8;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			ybQSe2qiHP8 = value;
		}
	}

	public byte[] ImageBytes
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return n7pSe065YWd;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			n7pSe065YWd = value;
			tD3Sets4n6F = new MemoryStream(n7pSe065YWd);
		}
	}

	public Image Image
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return Image.FromStream(tD3Sets4n6F);
		}
	}

	public string Path
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return FAUSeyAR6eo;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			FAUSeyAR6eo = value;
		}
	}

	public long Size
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return uAJSeB1ZnR8;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			uAJSeB1ZnR8 = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PS3GameFile()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}
}
