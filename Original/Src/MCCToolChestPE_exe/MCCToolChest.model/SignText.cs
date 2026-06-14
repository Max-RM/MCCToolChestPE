using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.model;

[DataContract]
public class SignText
{
	private static Dictionary<string, string> BAlS2Nvwo0r;

	private bool nU9S2D0ioY1;

	private bool XQuS2cNHYNF;

	private bool H3ZS2JAlak3;

	private bool tacS2u7s9m3;

	private bool b6NS2oGp0lM;

	private string RJES2QICOUB;

	private string WVHS2OENfF1;

	private List<SignText> VybS2CPrsh1;

	public bool italic
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return XQuS2cNHYNF;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			XQuS2cNHYNF = value;
		}
	}

	public bool underlined
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return H3ZS2JAlak3;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			H3ZS2JAlak3 = value;
		}
	}

	public bool strikethrough
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return tacS2u7s9m3;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			tacS2u7s9m3 = value;
		}
	}

	public bool obfuscated
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return b6NS2oGp0lM;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			b6NS2oGp0lM = value;
		}
	}

	public bool bold
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return nU9S2D0ioY1;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			nU9S2D0ioY1 = value;
		}
	}

	public string color
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return RJES2QICOUB;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			RJES2QICOUB = value;
		}
	}

	public string text
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return WVHS2OENfF1;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			WVHS2OENfF1 = value;
		}
	}

	public List<SignText> extra
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return VybS2CPrsh1;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			VybS2CPrsh1 = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string ToConsole()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(GurS26tp9IC());
		stringBuilder.Append(text);
		if (extra != null && extra.Count > 0)
		{
			foreach (SignText item in extra)
			{
				string value = item.ToConsole();
				stringBuilder.Append(value);
			}
		}
		return stringBuilder.ToString();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string GurS26tp9IC()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		StringBuilder stringBuilder = new StringBuilder();
		if (nU9S2D0ioY1)
		{
			stringBuilder.Append(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17522));
		}
		if (XQuS2cNHYNF)
		{
			stringBuilder.Append(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17530));
		}
		if (H3ZS2JAlak3)
		{
			stringBuilder.Append(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17538));
		}
		if (tacS2u7s9m3)
		{
			stringBuilder.Append(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17546));
		}
		if (b6NS2oGp0lM)
		{
			stringBuilder.Append(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(99294));
		}
		if (RJES2QICOUB != null && BAlS2Nvwo0r.ContainsKey(RJES2QICOUB))
		{
			stringBuilder.Append(BAlS2Nvwo0r[RJES2QICOUB]);
		}
		return stringBuilder.ToString();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SignText()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static SignText()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		BAlS2Nvwo0r = new Dictionary<string, string>
		{
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(99302),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(3436)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(99316),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(3478)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(99338),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(3528)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(99362),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(3580)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(99384),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(3630)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(99404),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(3678)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(99430),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(3732)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(99442),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(3772)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(99454),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(3812)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(99476),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(3862)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(3910),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(99488)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(99496),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(99508)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(99516),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(99526)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(99534),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(99562)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(99570),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(99586)
			},
			{
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(99594),
				Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(99608)
			}
		};
	}
}
