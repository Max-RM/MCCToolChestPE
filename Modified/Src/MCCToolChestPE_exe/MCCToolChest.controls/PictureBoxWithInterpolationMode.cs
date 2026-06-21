using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls;

public class PictureBoxWithInterpolationMode : PictureBox
{
	[CompilerGenerated]
	private InterpolationMode mhTaw81B63;

	public InterpolationMode InterpolationMode
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return mhTaw81B63;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			mhTaw81B63 = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnPaint(PaintEventArgs paintEventArgs)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		paintEventArgs.Graphics.InterpolationMode = InterpolationMode;
		base.OnPaint(paintEventArgs);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PictureBoxWithInterpolationMode()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}
}
