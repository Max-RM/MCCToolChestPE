using System;
using System.ComponentModel;

namespace FastColoredTextBoxNS;

internal class FooTextChangedDescriptor : EventDescriptor
{
	public override Type ComponentType => typeof(FastColoredTextBox);

	public override Type EventType => typeof(EventHandler);

	public override bool IsMulticast => true;

	public FooTextChangedDescriptor(MemberDescriptor desc)
		: base(desc)
	{
	}

	public override void AddEventHandler(object component, Delegate value)
	{
		(component as FastColoredTextBox).BindingTextChanged += value as EventHandler;
	}

	public override void RemoveEventHandler(object component, Delegate value)
	{
		(component as FastColoredTextBox).BindingTextChanged -= value as EventHandler;
	}
}
