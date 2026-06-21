using System.Runtime.CompilerServices;
using FastColoredTextBoxNS;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.scripting;

public class MethodAutocompleteItem2 : MethodAutocompleteItem
{
	private string yLjSLKxRTf8;

	private string issSLhg9jx5;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MethodAutocompleteItem2(string text) : base(text)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		int num = text.LastIndexOf('.');
		if (num < 0)
		{
			yLjSLKxRTf8 = text;
			return;
		}
		yLjSLKxRTf8 = text.Substring(0, num);
		issSLhg9jx5 = text.Substring(num + 1);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override CompareResult Compare(string fragmentText)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = fragmentText.LastIndexOf('.');
		if (num < 0)
		{
			if (yLjSLKxRTf8.StartsWith(fragmentText) && string.IsNullOrEmpty(issSLhg9jx5))
			{
				return CompareResult.VisibleAndSelected;
			}
		}
		else
		{
			string text = fragmentText.Substring(0, num);
			string text2 = fragmentText.Substring(num + 1);
			if (yLjSLKxRTf8 != text)
			{
				return CompareResult.Hidden;
			}
			if (issSLhg9jx5 != null && issSLhg9jx5.StartsWith(text2))
			{
				return CompareResult.VisibleAndSelected;
			}
			if (issSLhg9jx5 != null && issSLhg9jx5.ToLower().Contains(text2.ToLower()))
			{
				return CompareResult.Visible;
			}
		}
		return CompareResult.Hidden;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string GetTextForReplace()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (issSLhg9jx5 == null)
		{
			return yLjSLKxRTf8;
		}
		return yLjSLKxRTf8 + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13710) + issSLhg9jx5;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string ToString()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (issSLhg9jx5 == null)
		{
			return yLjSLKxRTf8;
		}
		return issSLhg9jx5;
	}
}
