using Substrate.Core;
using Substrate.Nbt;

namespace Substrate;

public class Enchantment : INbtObject<Enchantment>, ICopyable<Enchantment>
{
	private static readonly SchemaNodeCompound _schema = new SchemaNodeCompound("")
	{
		new SchemaNodeScaler("id", TagType.TAG_SHORT),
		new SchemaNodeScaler("lvl", TagType.TAG_SHORT)
	};

	private TagNodeCompound _source;

	private short _id;

	private short _level;

	public EnchantmentInfo Info => EnchantmentInfo.EnchantmentTable[_id];

	public int Id
	{
		get
		{
			return _id;
		}
		set
		{
			_id = (short)value;
		}
	}

	public int Level
	{
		get
		{
			return _level;
		}
		set
		{
			_level = (short)value;
		}
	}

	public static SchemaNodeCompound Schema => _schema;

	public Enchantment()
	{
	}

	public Enchantment(int id, int level)
	{
		_id = (short)id;
		_level = (short)level;
	}

	public Enchantment LoadTree(TagNode tree)
	{
		if (!(tree is TagNodeCompound tagNodeCompound))
		{
			return null;
		}
		_id = tagNodeCompound["id"].ToTagShort();
		_level = tagNodeCompound["lvl"].ToTagShort();
		_source = tagNodeCompound.Copy() as TagNodeCompound;
		return this;
	}

	public Enchantment LoadTreeSafe(TagNode tree)
	{
		if (!ValidateTree(tree))
		{
			return null;
		}
		return LoadTree(tree);
	}

	public TagNode BuildTree()
	{
		TagNodeCompound tagNodeCompound = new TagNodeCompound();
		tagNodeCompound["id"] = new TagNodeShort(_id);
		tagNodeCompound["lvl"] = new TagNodeShort(_level);
		if (_source != null)
		{
			tagNodeCompound.MergeFrom(_source);
		}
		return tagNodeCompound;
	}

	public bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, _schema).Verify();
	}

	public Enchantment Copy()
	{
		Enchantment enchantment = new Enchantment(_id, _level);
		if (_source != null)
		{
			enchantment._source = _source.Copy() as TagNodeCompound;
		}
		return enchantment;
	}
}
