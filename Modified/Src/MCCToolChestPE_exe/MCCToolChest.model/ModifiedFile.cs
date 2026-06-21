using System.Runtime.CompilerServices;
using System.Windows.Forms;
using NBTExplorer.Model;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.model;

public class ModifiedFile
{
	private TreeNode PfnSa5c9r43;

	private DataNode FhYSa6fWAeR;

	private object dGSSaNJ2Ztj;

	private FileStateType cs1SaDttWK6;

	public TreeNode Treenode
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return PfnSa5c9r43;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			PfnSa5c9r43 = value;
		}
	}

	public DataNode FileNode
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return FhYSa6fWAeR;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			FhYSa6fWAeR = value;
		}
	}

	public object Tag
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return dGSSaNJ2Ztj;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			dGSSaNJ2Ztj = value;
		}
	}

	public FileStateType FileState
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return cs1SaDttWK6;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			cs1SaDttWK6 = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string ToString()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string result = string.Empty;
		if (dGSSaNJ2Ztj != null)
		{
			if (dGSSaNJ2Ztj.GetType() == typeof(ChunkData))
			{
				result = ((ChunkData)dGSSaNJ2Ztj).Parent + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20100) + ((ChunkData)dGSSaNJ2Ztj).Text;
			}
			else if (dGSSaNJ2Ztj.GetType() == typeof(IndexEntry))
			{
				result = ((IndexEntry)dGSSaNJ2Ztj).FileName;
			}
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ModifiedFile()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}
}
