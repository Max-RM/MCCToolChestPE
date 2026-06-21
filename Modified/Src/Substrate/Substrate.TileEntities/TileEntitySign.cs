using Substrate.Nbt;

namespace Substrate.TileEntities;

public class TileEntitySign : TileEntity
{
	public static readonly SchemaNodeCompound SignSchema = TileEntity.Schema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId),
		new SchemaNodeScaler("Text1", TagType.TAG_STRING),
		new SchemaNodeScaler("Text2", TagType.TAG_STRING),
		new SchemaNodeScaler("Text3", TagType.TAG_STRING),
		new SchemaNodeScaler("Text4", TagType.TAG_STRING)
	});

	private string _text1 = "";

	private string _text2 = "";

	private string _text3 = "";

	private string _text4 = "";

	public static string TypeId => "Sign";

	public string Text1
	{
		get
		{
			return _text1;
		}
		set
		{
			_text1 = ((value.Length > 14) ? value.Substring(0, 14) : value);
		}
	}

	public string Text2
	{
		get
		{
			return _text2;
		}
		set
		{
			_text2 = ((value.Length > 14) ? value.Substring(0, 14) : value);
		}
	}

	public string Text3
	{
		get
		{
			return _text3;
		}
		set
		{
			_text3 = ((value.Length > 14) ? value.Substring(0, 14) : value);
		}
	}

	public string Text4
	{
		get
		{
			return _text4;
		}
		set
		{
			_text4 = ((value.Length > 14) ? value.Substring(0, 14) : value);
		}
	}

	protected TileEntitySign(string id)
		: base(id)
	{
	}

	public TileEntitySign()
		: this(TypeId)
	{
	}

	public TileEntitySign(TileEntity te)
		: base(te)
	{
		if (te is TileEntitySign tileEntitySign)
		{
			_text1 = tileEntitySign._text1;
			_text2 = tileEntitySign._text2;
			_text3 = tileEntitySign._text3;
			_text4 = tileEntitySign._text4;
		}
	}

	public override TileEntity Copy()
	{
		return new TileEntitySign(this);
	}

	public override TileEntity LoadTree(TagNode tree)
	{
		if (!(tree is TagNodeCompound tagNodeCompound) || base.LoadTree(tree) == null)
		{
			return null;
		}
		_text1 = tagNodeCompound["Text1"].ToTagString();
		_text2 = tagNodeCompound["Text2"].ToTagString();
		_text3 = tagNodeCompound["Text3"].ToTagString();
		_text4 = tagNodeCompound["Text4"].ToTagString();
		return this;
	}

	public override TagNode BuildTree()
	{
		TagNodeCompound tagNodeCompound = base.BuildTree() as TagNodeCompound;
		tagNodeCompound["Text1"] = new TagNodeString(_text1);
		tagNodeCompound["Text2"] = new TagNodeString(_text2);
		tagNodeCompound["Text3"] = new TagNodeString(_text3);
		tagNodeCompound["Text4"] = new TagNodeString(_text4);
		return tagNodeCompound;
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, SignSchema).Verify();
	}
}
