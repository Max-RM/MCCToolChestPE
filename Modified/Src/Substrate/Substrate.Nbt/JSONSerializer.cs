using System;
using System.Collections.Generic;
using System.Text;

namespace Substrate.Nbt;

public class JSONSerializer
{
	public static string Serialize(TagNode tag)
	{
		return Serialize(tag, 0);
	}

	public static string Serialize(TagNode tag, int level)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (tag.GetTagType() == TagType.TAG_COMPOUND)
		{
			SerializeCompound(tag as TagNodeCompound, stringBuilder, level);
		}
		else if (tag.GetTagType() == TagType.TAG_LIST)
		{
			SerializeList(tag as TagNodeList, stringBuilder, level);
		}
		else if (tag.GetTagType() == TagType.TAG_BYTE_ARRAY)
		{
			SerializeByteArray(tag as TagNodeByteArray, stringBuilder, level);
		}
		else if (tag.GetTagType() == TagType.TAG_INT_ARRAY)
		{
			SerializeIntArray(tag as TagNodeIntArray, stringBuilder, level);
		}
		else
		{
			SerializeScaler(tag, stringBuilder);
		}
		return stringBuilder.ToString();
	}

	private static void SerializeCompound(TagNodeCompound tag, StringBuilder str, int level)
	{
		if (tag.Count == 0)
		{
			str.Append("{ }");
			return;
		}
		str.AppendLine();
		AddLine(str, "{", level);
		IEnumerator<KeyValuePair<string, TagNode>> enumerator = tag.GetEnumerator();
		bool flag = true;
		while (enumerator.MoveNext())
		{
			if (!flag)
			{
				str.Append(",");
				str.AppendLine();
			}
			KeyValuePair<string, TagNode> current = enumerator.Current;
			Add(str, "\"" + current.Key + "\": ", level + 1);
			if (current.Value.GetTagType() == TagType.TAG_COMPOUND)
			{
				SerializeCompound(current.Value as TagNodeCompound, str, level + 1);
			}
			else if (current.Value.GetTagType() == TagType.TAG_LIST)
			{
				SerializeList(current.Value as TagNodeList, str, level + 1);
			}
			else if (current.Value.GetTagType() == TagType.TAG_BYTE_ARRAY)
			{
				SerializeByteArray(current.Value as TagNodeByteArray, str, level);
			}
			else if (current.Value.GetTagType() == TagType.TAG_INT_ARRAY)
			{
				SerializeIntArray(current.Value as TagNodeIntArray, str, level + 1);
			}
			else
			{
				SerializeScaler(current.Value, str);
			}
			flag = false;
		}
		str.AppendLine();
		Add(str, "}", level);
	}

	private static void SerializeList(TagNodeList tag, StringBuilder str, int level)
	{
		if (tag.Count == 0)
		{
			str.Append("[ ]");
			return;
		}
		str.AppendLine();
		AddLine(str, "[", level);
		IEnumerator<TagNode> enumerator = tag.GetEnumerator();
		bool flag = true;
		while (enumerator.MoveNext())
		{
			if (!flag)
			{
				str.Append(",");
			}
			TagNode current = enumerator.Current;
			if (current.GetTagType() == TagType.TAG_COMPOUND)
			{
				SerializeCompound(current as TagNodeCompound, str, level + 1);
			}
			else if (current.GetTagType() == TagType.TAG_LIST)
			{
				SerializeList(current as TagNodeList, str, level + 1);
			}
			else
			{
				if (!flag)
				{
					str.AppendLine();
				}
				Indent(str, level + 1);
				if (current.GetTagType() == TagType.TAG_INT_ARRAY)
				{
					SerializeIntArray(current as TagNodeIntArray, str, level);
				}
				else if (current.GetTagType() == TagType.TAG_BYTE_ARRAY)
				{
					SerializeByteArray(current as TagNodeByteArray, str, level);
				}
				else
				{
					SerializeScaler(current, str);
				}
			}
			flag = false;
		}
		str.AppendLine();
		Add(str, "]", level);
	}

	private static void SerializeByteArray(TagNodeByteArray tag, StringBuilder str, int level)
	{
		if (tag.Length == 0)
		{
			str.Append("[ ]");
			return;
		}
		str.Append("[ ");
		bool flag = true;
		for (int i = 0; i < tag.Length; i++)
		{
			if (!flag)
			{
				str.Append(", ");
			}
			str.Append(tag.Data[i]);
			flag = false;
		}
		str.Append(" ]");
	}

	private static void SerializeIntArray(TagNodeIntArray tag, StringBuilder str, int level)
	{
		if (tag.Length == 0)
		{
			str.Append("[ ]");
			return;
		}
		str.Append("[ ");
		bool flag = true;
		for (int i = 0; i < tag.Length; i++)
		{
			if (!flag)
			{
				str.Append(", ");
			}
			str.Append(tag.Data[i]);
			flag = false;
		}
		str.Append(" ]");
	}

	private static void SerializeScaler(TagNode tag, StringBuilder str)
	{
		switch (tag.GetTagType())
		{
		case TagType.TAG_STRING:
			str.Append("\"" + Escape(tag.ToTagString().Data) + "\"");
			break;
		case TagType.TAG_BYTE:
			str.Append(tag.ToTagByte().Data);
			break;
		case TagType.TAG_SHORT:
			str.Append(tag.ToTagShort().Data);
			break;
		case TagType.TAG_INT:
			str.Append(tag.ToTagInt().Data);
			break;
		case TagType.TAG_LONG:
			str.Append(tag.ToTagLong().Data);
			break;
		case TagType.TAG_FLOAT:
			str.Append(tag.ToTagFloat().Data);
			break;
		case TagType.TAG_DOUBLE:
			str.Append(tag.ToTagDouble().Data);
			break;
		case TagType.TAG_BYTE_ARRAY:
			str.Append(Convert.ToBase64String(tag.ToTagByteArray().Data));
			break;
		}
	}

	private static void AddLine(StringBuilder str, string line, int level)
	{
		Indent(str, level);
		str.AppendLine(line);
	}

	private static void Add(StringBuilder str, string line, int level)
	{
		Indent(str, level);
		str.Append(line);
	}

	private static void Indent(StringBuilder str, int count)
	{
		for (int i = 0; i < count; i++)
		{
			str.Append("\t");
		}
	}

	private static string Escape(string str)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (char c in str)
		{
			if (c < ' ')
			{
				stringBuilder.Append("\\u" + ((byte)c).ToString("x4"));
			}
			else if (c == '"')
			{
				stringBuilder.Append("\\\"");
			}
			else
			{
				stringBuilder.Append(c);
			}
		}
		return stringBuilder.ToString();
	}
}
