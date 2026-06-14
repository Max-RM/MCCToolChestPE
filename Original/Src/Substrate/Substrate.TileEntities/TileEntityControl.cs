using Substrate.Nbt;

namespace Substrate.TileEntities;

public class TileEntityControl : TileEntity
{
	public static readonly SchemaNodeCompound ControlSchema = TileEntity.Schema.MergeInto(new SchemaNodeCompound("")
	{
		new SchemaNodeString("id", TypeId),
		new SchemaNodeScaler("Command", TagType.TAG_STRING)
	});

	private string _command;

	public static string TypeId => "Control";

	public string Command
	{
		get
		{
			return _command;
		}
		set
		{
			_command = value;
		}
	}

	protected TileEntityControl(string id)
		: base(id)
	{
	}

	public TileEntityControl()
		: this(TypeId)
	{
	}

	public TileEntityControl(TileEntity te)
		: base(te)
	{
		if (te is TileEntityControl tileEntityControl)
		{
			_command = tileEntityControl._command;
		}
	}

	public override TileEntity Copy()
	{
		return new TileEntityControl(this);
	}

	public override TileEntity LoadTree(TagNode tree)
	{
		if (!(tree is TagNodeCompound tagNodeCompound) || base.LoadTree(tree) == null)
		{
			return null;
		}
		_command = tagNodeCompound["Command"].ToTagString();
		return this;
	}

	public override TagNode BuildTree()
	{
		TagNodeCompound tagNodeCompound = base.BuildTree() as TagNodeCompound;
		tagNodeCompound["Command"] = new TagNodeString(_command);
		return tagNodeCompound;
	}

	public override bool ValidateTree(TagNode tree)
	{
		return new NbtVerifier(tree, ControlSchema).Verify();
	}
}
