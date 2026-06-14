using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using MCCToolChest.model;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.Logic;

public class CombineItems
{
	private string Gls9fY1xty;

	private string aZS9iJpLRY;

	private string HRa9sjHPAN;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CheckJavaItems()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = new StringBuilder();
		string[] array = File.ReadAllLines(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63224));
		foreach (string text in array)
		{
			string[] array2 = text.Split(',');
			if (array2.Length <= 0)
			{
				continue;
			}
			string text2 = array2[0].Trim();
			string arg = array2[1].Trim();
			if (!ItemTranslations.JavaItemsByName.ContainsKey(text2))
			{
				string value = string.Format(aZS9iJpLRY, text2, 0, arg);
				if (text2.IndexOf(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63322)) > 0)
				{
					stringBuilder2.AppendLine(value);
				}
				else
				{
					stringBuilder.AppendLine(value);
				}
			}
		}
		stringBuilder.AppendLine();
		stringBuilder.AppendLine();
		stringBuilder.AppendLine();
		stringBuilder.AppendLine(stringBuilder2.ToString());
		stringBuilder.ToString();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CombineItems()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		Gls9fY1xty = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63332);
		aZS9iJpLRY = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63436);
		HRa9sjHPAN = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63534);
	}
}
