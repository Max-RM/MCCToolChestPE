using System.Drawing;
using System.Runtime.CompilerServices;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls;

public class DropDownItem
{
	[CompilerGenerated]
	private string B3kyguurwu;

	[CompilerGenerated]
	private string CYIyPl7SCH;

	[CompilerGenerated]
	private string rIHyRvEEGr;

	[CompilerGenerated]
	private Image qPAykMs7rX;

	public string Value
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return B3kyguurwu;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			B3kyguurwu = value;
		}
	}

	public string Key
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return CYIyPl7SCH;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			CYIyPl7SCH = value;
		}
	}

	public string Text
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return rIHyRvEEGr;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			rIHyRvEEGr = value;
		}
	}

	public Image Image
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return qPAykMs7rX;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			qPAykMs7rX = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DropDownItem() : this("", "", "")
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DropDownItem(string key, string val, string text)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		Value = val;
		Key = key;
		Text = text;
		Image = new Bitmap(16, 16);
		using Graphics graphics = Graphics.FromImage(Image);
		using Brush brush = new SolidBrush(Color.FromName(val));
		graphics.DrawRectangle(Pens.White, 0, 0, Image.Width, Image.Height);
		graphics.FillRectangle(brush, 1, 1, Image.Width - 1, Image.Height - 1);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DropDownItem(int key, int val, string text)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		Value = val.ToString();
		Key = key.ToString();
		Text = text;
		Image = new Bitmap(16, 16);
		using Graphics graphics = Graphics.FromImage(Image);
		using Brush brush = new SolidBrush(Color.FromArgb((int)(4278190080u + val)));
		graphics.DrawRectangle(Pens.White, 0, 0, Image.Width, Image.Height);
		graphics.FillRectangle(brush, 1, 1, Image.Width - 1, Image.Height - 1);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string ToString()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return Value;
	}
}
