using Substrate.Nbt;

namespace NBTExplorer.Model;

public class RootDataNode : TagCompoundDataNode
{
	private string _name = "Root";

	private string _display = "";

	public override string NodeName => _name;

	public override string NodeDisplay => _display;

	public RootDataNode()
		: base(new TagNodeCompound())
	{
	}

	public void SetNodeName(string name)
	{
		_name = name;
	}

	public void SetDisplayName(string name)
	{
		_display = name;
	}
}
