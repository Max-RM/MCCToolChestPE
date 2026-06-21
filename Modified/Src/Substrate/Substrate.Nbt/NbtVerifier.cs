using System;
using System.Collections.Generic;

namespace Substrate.Nbt;

public class NbtVerifier
{
	private TagNode _root;

	private SchemaNode _schema;

	public static event VerifierEventHandler MissingTag;

	public static event VerifierEventHandler InvalidTagType;

	public static event VerifierEventHandler InvalidTagValue;

	public NbtVerifier(TagNode root, SchemaNode schema)
	{
		_root = root;
		_schema = schema;
	}

	public virtual bool Verify()
	{
		return Verify(null, _root, _schema);
	}

	private bool Verify(TagNode parent, TagNode tag, SchemaNode schema)
	{
		if (tag == null)
		{
			return OnMissingTag(new TagEventArgs(schema.Name));
		}
		if (schema is SchemaNodeScaler schema2)
		{
			return VerifyScaler(tag, schema2);
		}
		if (schema is SchemaNodeString schema3)
		{
			return VerifyString(tag, schema3);
		}
		if (schema is SchemaNodeArray schema4)
		{
			return VerifyArray(tag, schema4);
		}
		if (schema is SchemaNodeIntArray schema5)
		{
			return VerifyIntArray(tag, schema5);
		}
		if (schema is SchemaNodeLongArray schema6)
		{
			return VerifyLongArray(tag, schema6);
		}
		if (schema is SchemaNodeShortArray schema7)
		{
			return VerifyShortArray(tag, schema7);
		}
		if (schema is SchemaNodeList schema8)
		{
			return VerifyList(tag, schema8);
		}
		if (schema is SchemaNodeCompound schema9)
		{
			return VerifyCompound(tag, schema9);
		}
		return OnInvalidTagType(new TagEventArgs(schema.Name, tag));
	}

	private bool VerifyScaler(TagNode tag, SchemaNodeScaler schema)
	{
		if (!tag.IsCastableTo(schema.Type) && !OnInvalidTagType(new TagEventArgs(schema.Name, tag)))
		{
			return false;
		}
		return true;
	}

	private bool VerifyString(TagNode tag, SchemaNodeString schema)
	{
		TagNodeString tagNodeString = tag as TagNodeString;
		if (tagNodeString == null && !OnInvalidTagType(new TagEventArgs(schema, tag)))
		{
			return false;
		}
		if (schema.Length > 0 && tagNodeString.Length > schema.Length && !OnInvalidTagValue(new TagEventArgs(schema, tag)))
		{
			return false;
		}
		if (schema.Value != null && tagNodeString.Data != schema.Value && !OnInvalidTagValue(new TagEventArgs(schema, tag)))
		{
			return false;
		}
		return true;
	}

	private bool VerifyArray(TagNode tag, SchemaNodeArray schema)
	{
		TagNodeByteArray tagNodeByteArray = tag as TagNodeByteArray;
		if (tagNodeByteArray == null && !OnInvalidTagType(new TagEventArgs(schema, tag)))
		{
			return false;
		}
		if (schema.Length > 0 && tagNodeByteArray.Length != schema.Length && !OnInvalidTagValue(new TagEventArgs(schema, tag)))
		{
			return false;
		}
		return true;
	}

	private bool VerifyIntArray(TagNode tag, SchemaNodeIntArray schema)
	{
		TagNodeIntArray tagNodeIntArray = tag as TagNodeIntArray;
		if (tagNodeIntArray == null && !OnInvalidTagType(new TagEventArgs(schema, tag)))
		{
			return false;
		}
		if (schema.Length > 0 && tagNodeIntArray.Length != schema.Length && !OnInvalidTagValue(new TagEventArgs(schema, tag)))
		{
			return false;
		}
		return true;
	}

	private bool VerifyLongArray(TagNode tag, SchemaNodeLongArray schema)
	{
		TagNodeLongArray tagNodeLongArray = tag as TagNodeLongArray;
		if (tagNodeLongArray == null && !OnInvalidTagType(new TagEventArgs(schema, tag)))
		{
			return false;
		}
		if (schema.Length > 0 && tagNodeLongArray.Length != schema.Length && !OnInvalidTagValue(new TagEventArgs(schema, tag)))
		{
			return false;
		}
		return true;
	}

	private bool VerifyShortArray(TagNode tag, SchemaNodeShortArray schema)
	{
		TagNodeShortArray tagNodeShortArray = tag as TagNodeShortArray;
		if (tagNodeShortArray == null && !OnInvalidTagType(new TagEventArgs(schema, tag)))
		{
			return false;
		}
		if (schema.Length > 0 && tagNodeShortArray.Length != schema.Length && !OnInvalidTagValue(new TagEventArgs(schema, tag)))
		{
			return false;
		}
		return true;
	}

	private bool VerifyList(TagNode tag, SchemaNodeList schema)
	{
		TagNodeList tagNodeList = tag as TagNodeList;
		if (tagNodeList == null && !OnInvalidTagType(new TagEventArgs(schema, tag)))
		{
			return false;
		}
		if (tagNodeList.Count > 0 && tagNodeList.ValueType != schema.Type && !OnInvalidTagValue(new TagEventArgs(schema, tag)))
		{
			return false;
		}
		if (schema.Length > 0 && tagNodeList.Count != schema.Length && !OnInvalidTagValue(new TagEventArgs(schema, tag)))
		{
			return false;
		}
		bool flag = true;
		if (schema.SubSchema != null)
		{
			foreach (TagNode item in tagNodeList)
			{
				flag = Verify(tag, item, schema.SubSchema) && flag;
			}
		}
		return flag;
	}

	private bool VerifyCompound(TagNode tag, SchemaNodeCompound schema)
	{
		TagNodeCompound tagNodeCompound = tag as TagNodeCompound;
		if (tagNodeCompound == null && !OnInvalidTagType(new TagEventArgs(schema, tag)))
		{
			return false;
		}
		bool flag = true;
		Dictionary<string, TagNode> dictionary = new Dictionary<string, TagNode>();
		foreach (SchemaNode item in schema)
		{
			tagNodeCompound.TryGetValue(item.Name, out var value);
			if (value == null)
			{
				if ((item.Options & SchemaOptions.CREATE_ON_MISSING) == SchemaOptions.CREATE_ON_MISSING)
				{
					dictionary[item.Name] = item.BuildDefaultTree();
					continue;
				}
				if ((item.Options & SchemaOptions.OPTIONAL) == SchemaOptions.OPTIONAL)
				{
					continue;
				}
			}
			flag = Verify(tag, value, item) && flag;
		}
		foreach (KeyValuePair<string, TagNode> item2 in dictionary)
		{
			tagNodeCompound[item2.Key] = item2.Value;
		}
		dictionary.Clear();
		return flag;
	}

	protected virtual bool OnMissingTag(TagEventArgs e)
	{
		if (NbtVerifier.MissingTag != null)
		{
			Delegate[] invocationList = NbtVerifier.MissingTag.GetInvocationList();
			for (int i = 0; i < invocationList.Length; i++)
			{
				VerifierEventHandler verifierEventHandler = (VerifierEventHandler)invocationList[i];
				switch (verifierEventHandler(e))
				{
				case TagEventCode.FAIL:
					return false;
				case TagEventCode.PASS:
					return true;
				}
			}
		}
		return false;
	}

	protected virtual bool OnInvalidTagType(TagEventArgs e)
	{
		if (NbtVerifier.InvalidTagType != null)
		{
			Delegate[] invocationList = NbtVerifier.InvalidTagType.GetInvocationList();
			for (int i = 0; i < invocationList.Length; i++)
			{
				VerifierEventHandler verifierEventHandler = (VerifierEventHandler)invocationList[i];
				switch (verifierEventHandler(e))
				{
				case TagEventCode.FAIL:
					return false;
				case TagEventCode.PASS:
					return true;
				}
			}
		}
		return false;
	}

	protected virtual bool OnInvalidTagValue(TagEventArgs e)
	{
		if (NbtVerifier.InvalidTagValue != null)
		{
			Delegate[] invocationList = NbtVerifier.InvalidTagValue.GetInvocationList();
			for (int i = 0; i < invocationList.Length; i++)
			{
				VerifierEventHandler verifierEventHandler = (VerifierEventHandler)invocationList[i];
				switch (verifierEventHandler(e))
				{
				case TagEventCode.FAIL:
					return false;
				case TagEventCode.PASS:
					return true;
				}
			}
		}
		return false;
	}
}
