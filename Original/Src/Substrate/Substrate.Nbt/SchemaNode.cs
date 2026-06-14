namespace Substrate.Nbt;

public abstract class SchemaNode
{
	private string _name;

	private SchemaOptions _options;

	public string Name => _name;

	public SchemaOptions Options => _options;

	protected SchemaNode(string name)
	{
		_name = name;
	}

	protected SchemaNode(string name, SchemaOptions options)
	{
		_name = name;
		_options = options;
	}

	public virtual TagNode BuildDefaultTree()
	{
		return null;
	}
}
