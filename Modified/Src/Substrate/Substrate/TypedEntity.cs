using Substrate.Core;
using Substrate.Nbt;

namespace Substrate;

public class TypedEntity : Entity, INbtObject<TypedEntity>, ICopyable<TypedEntity>
{
	private static readonly SchemaNodeCompound _schema = Entity.Schema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeScaler("id", TagType.TAG_STRING)
	});

	private string _id;

	public string ID => _id;

	public new static SchemaNodeCompound Schema => _schema;

	public TypedEntity(string id)
	{
		_id = id;
	}

	protected TypedEntity(TypedEntity e)
		: base(e)
	{
		_id = e._id;
	}

	public new virtual TypedEntity LoadTree(TagNode tree)
	{
		if (!(tree is TagNodeCompound tagNodeCompound) || base.LoadTree(tree) == null)
		{
			return null;
		}
		_id = tagNodeCompound["id"].ToTagString();
		return this;
	}

	public new virtual TypedEntity LoadTreeSafe(TagNode tree)
	{
		if (!ValidateTree(tree))
		{
			return null;
		}
		return LoadTree(tree);
	}

	public new virtual TagNode BuildTree()
	{
		TagNodeCompound tagNodeCompound = base.BuildTree() as TagNodeCompound;
		tagNodeCompound["id"] = new TagNodeString(_id);
		return tagNodeCompound;
	}

	public new virtual bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, _schema).Verify();
	}

	public new virtual TypedEntity Copy()
	{
		return new TypedEntity(this);
	}
}
