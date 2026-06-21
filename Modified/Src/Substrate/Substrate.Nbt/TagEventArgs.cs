using System;

namespace Substrate.Nbt;

public class TagEventArgs : EventArgs
{
	private string _tagName;

	private TagNode _parent;

	private TagNode _tag;

	private SchemaNode _schema;

	public string TagName => _tagName;

	public TagNode Parent => _parent;

	public TagNode Tag => _tag;

	public SchemaNode Schema => _schema;

	public TagEventArgs(string tagName)
	{
		_tagName = tagName;
	}

	public TagEventArgs(string tagName, TagNode tag)
	{
		_tag = tag;
		_tagName = tagName;
	}

	public TagEventArgs(SchemaNode schema, TagNode tag)
	{
		_tag = tag;
		_schema = schema;
	}
}
