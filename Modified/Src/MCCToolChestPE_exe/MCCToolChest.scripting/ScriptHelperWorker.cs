using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web;
using MCCToolChest.PECode;
using MCPELevelDBI.workers;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.scripting;

public class ScriptHelperWorker
{
	private StringBuilder Ql5SgecPxsw;

	private static TagNodeNull k5FSgMBUV0I;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string ReadEntities(int dimension, int xChunk, int zChunk, LevelDBWorker dbWorker)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] array = PEUtility.BuildChunkKey(dimension, xChunk, zChunk, 50);
		GwTSgfo7m2G(array, dbWorker);
		return Ql5SgecPxsw.ToString();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string ReadTileEntities(int dimension, int xChunk, int zChunk, LevelDBWorker dbWorker)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] array = PEUtility.BuildChunkKey(dimension, xChunk, zChunk, 49);
		GwTSgfo7m2G(array, dbWorker);
		return Ql5SgecPxsw.ToString();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GwTSgfo7m2G(byte[] P_0, LevelDBWorker P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNodeList tagNodeList = null;
		byte[] blockEntity = P_1.ReadDbValue(P_0);
		tagNodeList = PEUtility.ExtractTileEntities(blockEntity);
		Ql5SgecPxsw.Clear();
		K6FSgx5pS7l(tagNodeList);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void A6vSgiXIs8L(TagNode P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		switch (P_0.GetTagType())
		{
		case TagType.TAG_BYTE:
			NvbSgs6p8gp(P_0.ToTagByte());
			break;
		case TagType.TAG_SHORT:
			qAOSgqrbtPX(P_0.ToTagShort());
			break;
		case TagType.TAG_INT:
			RFwSgK1i8TP(P_0.ToTagInt());
			break;
		case TagType.TAG_LONG:
			LG9Sgh1VGKy(P_0.ToTagLong());
			break;
		case TagType.TAG_FLOAT:
			YmPSgmPC5gt(P_0.ToTagFloat());
			break;
		case TagType.TAG_DOUBLE:
			o0hSgnjKEjw(P_0.ToTagDouble());
			break;
		case TagType.TAG_BYTE_ARRAY:
			wG0SglHTkd5(P_0.ToTagByteArray());
			break;
		case TagType.TAG_STRING:
			KpMSg2bNIui(P_0.ToTagString());
			break;
		case TagType.TAG_LIST:
			qX4SgyMZVMe(P_0.ToTagList());
			break;
		case TagType.TAG_COMPOUND:
			hftSg0CuI17(P_0.ToTagCompound());
			break;
		case TagType.TAG_INT_ARRAY:
			ByESgBnUZ20(P_0.ToTagIntArray());
			break;
		case TagType.TAG_LONG_ARRAY:
			mXVSgtPJYtA(P_0.ToTagLongArray());
			break;
		case TagType.TAG_SHORT_ARRAY:
			pvrSgaDKHIW(P_0.ToTagShortArray());
			break;
		case TagType.TAG_END:
			break;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void NvbSgs6p8gp(TagNodeByte P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Ql5SgecPxsw.Append(P_0.Data);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void qAOSgqrbtPX(TagNodeShort P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Ql5SgecPxsw.Append(P_0.Data);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RFwSgK1i8TP(TagNodeInt P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Ql5SgecPxsw.Append(P_0.Data);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LG9Sgh1VGKy(TagNodeLong P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Ql5SgecPxsw.Append(P_0.Data);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YmPSgmPC5gt(TagNodeFloat P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Ql5SgecPxsw.Append(P_0.Data);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void o0hSgnjKEjw(TagNodeDouble P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Ql5SgecPxsw.Append(P_0.Data);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void wG0SglHTkd5(TagNodeByteArray P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] bytes = BitConverter.GetBytes(P_0.Length);
		Ql5SgecPxsw.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63850));
		for (int i = 0; i < bytes.Length; i++)
		{
			if (i != 0)
			{
				Ql5SgecPxsw.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40710));
			}
			Ql5SgecPxsw.Append(bytes[i]);
		}
		Ql5SgecPxsw.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20542));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void KpMSg2bNIui(TagNodeString P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Ql5SgecPxsw.Append(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63856) + HttpUtility.JavaScriptStringEncode(P_0) + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63856));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void qX4SgyMZVMe(TagNodeList P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Ql5SgecPxsw.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63850));
		int num = 0;
		foreach (TagNode item in P_0)
		{
			if (num++ > 0)
			{
				Ql5SgecPxsw.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40710));
			}
			A6vSgiXIs8L(item);
		}
		Ql5SgecPxsw.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20542));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hftSg0CuI17(TagNodeCompound P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Ql5SgecPxsw.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63862));
		int num = 0;
		foreach (KeyValuePair<string, TagNode> item in P_0)
		{
			if (num++ > 0)
			{
				Ql5SgecPxsw.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40710));
			}
			EMESgXiUiXC(item.Key, item.Value);
		}
		Ql5SgecPxsw.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63868));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ByESgBnUZ20(TagNodeIntArray P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Ql5SgecPxsw.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63850));
		_ = P_0.Length;
		for (int i = 0; i < P_0.Length; i++)
		{
			if (i != 0)
			{
				Ql5SgecPxsw.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40710));
			}
			Ql5SgecPxsw.Append(P_0.Data[i]);
		}
		Ql5SgecPxsw.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20542));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void mXVSgtPJYtA(TagNodeLongArray P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Ql5SgecPxsw.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63850));
		_ = P_0.Length;
		for (int i = 0; i < P_0.Length; i++)
		{
			if (i != 0)
			{
				Ql5SgecPxsw.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40710));
			}
			Ql5SgecPxsw.Append(P_0.Data[i]);
		}
		Ql5SgecPxsw.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20542));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void pvrSgaDKHIW(TagNodeShortArray P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Ql5SgecPxsw.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63850));
		_ = P_0.Length;
		for (int i = 0; i < P_0.Length; i++)
		{
			if (i != 0)
			{
				Ql5SgecPxsw.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40710));
			}
			Ql5SgecPxsw.Append(P_0.Data[i]);
		}
		Ql5SgecPxsw.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20542));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EMESgXiUiXC(string P_0, TagNode P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_1.GetTagType() != TagType.TAG_END)
		{
			KpMSg2bNIui(P_0);
			Ql5SgecPxsw.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63874));
			Ql5SgecPxsw.AppendLine(string.Concat(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63884), P_1.GetTagType(), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63906)));
			if (P_1.GetTagType().ToString() == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(30156))
			{
				TagNodeList tagNodeList = P_1 as TagNodeList;
				Ql5SgecPxsw.AppendLine(string.Concat(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63914), tagNodeList.ValueType, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63906)));
			}
			Ql5SgecPxsw.Append(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63944));
			A6vSgiXIs8L(P_1);
			Ql5SgecPxsw.AppendLine();
			Ql5SgecPxsw.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63868));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void K6FSgx5pS7l(TagNode P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0.GetTagType() != TagType.TAG_END)
		{
			Ql5SgecPxsw.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63862));
			Ql5SgecPxsw.AppendLine(string.Concat(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63884), P_0.GetTagType(), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63906)));
			if (P_0.GetTagType().ToString() == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(30156))
			{
				TagNodeList tagNodeList = P_0 as TagNodeList;
				Ql5SgecPxsw.AppendLine(string.Concat(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63914), tagNodeList.ValueType, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63906)));
			}
			Ql5SgecPxsw.Append(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63944));
			A6vSgiXIs8L(P_0);
			Ql5SgecPxsw.AppendLine();
			Ql5SgecPxsw.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63868));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptHelperWorker()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		Ql5SgecPxsw = new StringBuilder();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ScriptHelperWorker()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		k5FSgMBUV0I = new TagNodeNull();
	}
}
