using System;
using System.Runtime.CompilerServices;
using YBh7EaXMWmkFRJOX37M;

namespace MCPELevelDBI;

public abstract class LevelDBHandle : IDisposable
{
	private bool diESeou54tj;

	[CompilerGenerated]
	private IntPtr TrPSeQbMGm6;

	public IntPtr Handle
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return TrPSeQbMGm6;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		protected set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			TrPSeQbMGm6 = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Dispose()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		NBMSeuXJEfr(true);
		GC.SuppressFinalize(this);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void FreeManagedObjects()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void FreeUnManagedObjects()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void NBMSeuXJEfr(bool P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!diESeou54tj)
		{
			if (P_0)
			{
				FreeManagedObjects();
			}
			if (Handle != IntPtr.Zero)
			{
				FreeUnManagedObjects();
				Handle = IntPtr.Zero;
			}
			diESeou54tj = true;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	~LevelDBHandle()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		try
		{
			NBMSeuXJEfr(false);
		}
		catch
		{
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected LevelDBHandle()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}
}
