using System;
using System.ComponentModel;

namespace FastColoredTextBoxNS;

internal class FCTBDescriptionProvider : TypeDescriptionProvider
{
	public FCTBDescriptionProvider(Type type)
		: base(GetDefaultTypeProvider(type))
	{
	}

	private static TypeDescriptionProvider GetDefaultTypeProvider(Type type)
	{
		return TypeDescriptor.GetProvider(type);
	}

	public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance)
	{
		ICustomTypeDescriptor typeDescriptor = base.GetTypeDescriptor(objectType, instance);
		return new FCTBTypeDescriptor(typeDescriptor, instance);
	}
}
