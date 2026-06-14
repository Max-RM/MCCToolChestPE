using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.scripting;

public class NBT2TextWriter
{
	private StringBuilder PGu9zJivdd;

	private static TagNodeNull QnuITS6nLD;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string ProcessNBT(TagNode node)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PGu9zJivdd.Clear();
		qpZ9IGfPUG(node);
		return PGu9zJivdd.ToString();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void yai9cbmCif(TagNode P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		switch (P_0.GetTagType())
		{
		case TagType.TAG_BYTE:
			lgq9JTf8O9(P_0.ToTagByte());
			break;
		case TagType.TAG_SHORT:
			pEr9u0ATaG(P_0.ToTagShort());
			break;
		case TagType.TAG_INT:
			dsR9ofmjNP(P_0.ToTagInt());
			break;
		case TagType.TAG_LONG:
			A6m9QywOqO(P_0.ToTagLong());
			break;
		case TagType.TAG_FLOAT:
			SFf9O1wtST(P_0.ToTagFloat());
			break;
		case TagType.TAG_DOUBLE:
			Kgu9C1Lros(P_0.ToTagDouble());
			break;
		case TagType.TAG_BYTE_ARRAY:
			xRR97jvOJg(P_0.ToTagByteArray());
			break;
		case TagType.TAG_STRING:
			ndH9A26LDj(P_0.ToTagString());
			break;
		case TagType.TAG_LIST:
			xNI9dRmscD(P_0.ToTagList());
			break;
		case TagType.TAG_COMPOUND:
			mIc9Hf5LDj(P_0.ToTagCompound());
			break;
		case TagType.TAG_INT_ARRAY:
			UO29Fye8EE(P_0.ToTagIntArray());
			break;
		case TagType.TAG_LONG_ARRAY:
			IPW9jnVGeW(P_0.ToTagLongArray());
			break;
		case TagType.TAG_SHORT_ARRAY:
			i3j98h02pa(P_0.ToTagShortArray());
			break;
		case TagType.TAG_END:
			break;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void lgq9JTf8O9(TagNodeByte P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PGu9zJivdd.Append(P_0.Data);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void pEr9u0ATaG(TagNodeShort P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PGu9zJivdd.Append(P_0.Data);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void dsR9ofmjNP(TagNodeInt P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PGu9zJivdd.Append(P_0.Data);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void A6m9QywOqO(TagNodeLong P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PGu9zJivdd.Append(P_0.Data);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SFf9O1wtST(TagNodeFloat P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PGu9zJivdd.Append(P_0.Data);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Kgu9C1Lros(TagNodeDouble P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PGu9zJivdd.Append(P_0.Data);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void xRR97jvOJg(TagNodeByteArray P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] bytes = BitConverter.GetBytes(P_0.Length);
		PGu9zJivdd.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63850));
		for (int i = 0; i < bytes.Length; i++)
		{
			if (i != 0)
			{
				PGu9zJivdd.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40710));
			}
			PGu9zJivdd.Append(bytes[i]);
		}
		PGu9zJivdd.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20542));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ndH9A26LDj(TagNodeString P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PGu9zJivdd.Append(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63856) + HttpUtility.JavaScriptStringEncode(P_0) + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63856));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void xNI9dRmscD(TagNodeList P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PGu9zJivdd.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63850));
		int num = 0;
		foreach (TagNode item in P_0)
		{
			if (num++ > 0)
			{
				PGu9zJivdd.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40710));
			}
			yai9cbmCif(item);
		}
		PGu9zJivdd.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20542));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void mIc9Hf5LDj(TagNodeCompound P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PGu9zJivdd.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63862));
		int num = 0;
		foreach (KeyValuePair<string, TagNode> item in P_0)
		{
			if (num++ > 0)
			{
				PGu9zJivdd.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40710));
			}
			Vtt99lGbkN(item.Key, item.Value);
		}
		PGu9zJivdd.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63868));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UO29Fye8EE(TagNodeIntArray P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PGu9zJivdd.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63850));
		_ = P_0.Length;
		for (int i = 0; i < P_0.Length; i++)
		{
			if (i != 0)
			{
				PGu9zJivdd.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40710));
			}
			PGu9zJivdd.Append(P_0.Data[i]);
		}
		PGu9zJivdd.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20542));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void IPW9jnVGeW(TagNodeLongArray P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PGu9zJivdd.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63850));
		_ = P_0.Length;
		for (int i = 0; i < P_0.Length; i++)
		{
			if (i != 0)
			{
				PGu9zJivdd.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40710));
			}
			PGu9zJivdd.Append(P_0.Data[i]);
		}
		PGu9zJivdd.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20542));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void i3j98h02pa(TagNodeShortArray P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PGu9zJivdd.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63850));
		_ = P_0.Length;
		for (int i = 0; i < P_0.Length; i++)
		{
			if (i != 0)
			{
				PGu9zJivdd.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40710));
			}
			PGu9zJivdd.Append(P_0.Data[i]);
		}
		PGu9zJivdd.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20542));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Vtt99lGbkN(string P_0, TagNode P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_1.GetTagType() != TagType.TAG_END)
		{
			ndH9A26LDj(P_0);
			PGu9zJivdd.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63874));
			PGu9zJivdd.AppendLine(string.Concat(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63884), P_1.GetTagType(), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63906)));
			if (P_1.GetTagType().ToString() == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(30156))
			{
				TagNodeList tagNodeList = P_1 as TagNodeList;
				PGu9zJivdd.AppendLine(string.Concat(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63914), tagNodeList.ValueType, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63906)));
			}
			PGu9zJivdd.Append(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63944));
			yai9cbmCif(P_1);
			PGu9zJivdd.AppendLine();
			PGu9zJivdd.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63868));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void qpZ9IGfPUG(TagNode P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0.GetTagType() != TagType.TAG_END)
		{
			PGu9zJivdd.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63862));
			PGu9zJivdd.AppendLine(string.Concat(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63884), P_0.GetTagType(), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63906)));
			if (P_0.GetTagType().ToString() == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(30156))
			{
				TagNodeList tagNodeList = P_0 as TagNodeList;
				PGu9zJivdd.AppendLine(string.Concat(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63914), tagNodeList.ValueType, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63906)));
			}
			PGu9zJivdd.Append(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63944));
			yai9cbmCif(P_0);
			PGu9zJivdd.AppendLine();
			PGu9zJivdd.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63868));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NBT2TextWriter()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		PGu9zJivdd = new StringBuilder();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static NBT2TextWriter()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		QnuITS6nLD = new TagNodeNull();
	}
}
