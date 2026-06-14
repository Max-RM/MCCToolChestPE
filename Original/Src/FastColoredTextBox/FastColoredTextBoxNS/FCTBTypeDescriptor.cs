using System.ComponentModel;
using System.Windows.Forms;

namespace FastColoredTextBoxNS;

internal class FCTBTypeDescriptor : CustomTypeDescriptor
{
	private ICustomTypeDescriptor parent;

	private object instance;

	public FCTBTypeDescriptor(ICustomTypeDescriptor parent, object instance)
		: base(parent)
	{
		this.parent = parent;
		this.instance = instance;
	}

	public override string GetComponentName()
	{
		return (!(instance is Control control)) ? null : control.Name;
	}

	public override EventDescriptorCollection GetEvents()
	{
		EventDescriptorCollection events = base.GetEvents();
		EventDescriptor[] array = new EventDescriptor[events.Count];
		for (int i = 0; i < events.Count; i++)
		{
			if (events[i].Name == "TextChanged")
			{
				array[i] = new FooTextChangedDescriptor(events[i]);
			}
			else
			{
				array[i] = events[i];
			}
		}
		return new EventDescriptorCollection(array);
	}
}
