using Substrate.Nbt;

namespace Substrate.Entities;

public class EntityArrow : EntityThrowable
{
	public static readonly SchemaNodeCompound ArrowSchema = EntityThrowable.ThrowableSchema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId),
		new SchemaNodeScaler("inData", TagType.TAG_BYTE, SchemaOptions.CREATE_ON_MISSING),
		new SchemaNodeScaler("player", TagType.TAG_BYTE, SchemaOptions.CREATE_ON_MISSING)
	});

	private byte _inData;

	private byte _player;

	public static string TypeId => "Arrow";

	public int InData
	{
		get
		{
			return _inData;
		}
		set
		{
			_inData = (byte)value;
		}
	}

	public bool IsPlayerArrow
	{
		get
		{
			return _player != 0;
		}
		set
		{
			_player = (byte)(value ? 1u : 0u);
		}
	}

	protected EntityArrow(string id)
		: base(id)
	{
	}

	public EntityArrow()
		: this(TypeId)
	{
	}

	public EntityArrow(TypedEntity e)
		: base(e)
	{
		if (e is EntityArrow entityArrow)
		{
			_inData = entityArrow._inData;
			_player = entityArrow._player;
		}
	}

	public override TypedEntity LoadTree(TagNode tree)
	{
		if (!(tree is TagNodeCompound tagNodeCompound) || base.LoadTree(tree) == null)
		{
			return null;
		}
		_inData = tagNodeCompound["inData"].ToTagByte();
		_player = tagNodeCompound["player"].ToTagByte();
		return this;
	}

	public override TagNode BuildTree()
	{
		TagNodeCompound tagNodeCompound = base.BuildTree() as TagNodeCompound;
		tagNodeCompound["inData"] = new TagNodeShort(_inData);
		tagNodeCompound["player"] = new TagNodeShort(_player);
		return tagNodeCompound;
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, ArrowSchema).Verify();
	}

	public override TypedEntity Copy()
	{
		return new EntityArrow(this);
	}
}
