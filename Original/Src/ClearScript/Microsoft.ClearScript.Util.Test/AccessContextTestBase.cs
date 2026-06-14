using System;

namespace Microsoft.ClearScript.Util.Test;

internal class AccessContextTestBase
{
	public class PublicNestedType
	{
	}

	internal sealed class InternalNestedType
	{
	}

	protected class ProtectedNestedType
	{
	}

	protected internal sealed class ProtectedInternalNestedType
	{
	}

	private sealed class PrivateNestedType
	{
	}

	public string PublicField;

	internal string InternalField;

	protected string ProtectedField;

	protected internal string ProtectedInternalField;

	private string privateField;

	public string PublicProperty { get; set; }

	internal string InternalProperty { get; set; }

	protected string ProtectedProperty { get; set; }

	protected internal string ProtectedInternalProperty { get; set; }

	private string PrivateProperty { get; set; }

	public event EventHandler PublicEvent;

	internal event EventHandler InternalEvent;

	protected event EventHandler ProtectedEvent;

	protected internal event EventHandler ProtectedInternalEvent;

	private event EventHandler PrivateEvent;

	public AccessContextTestBase()
	{
	}

	internal AccessContextTestBase(int arg)
	{
	}

	protected AccessContextTestBase(string arg)
	{
	}

	protected internal AccessContextTestBase(DateTime arg)
	{
	}

	private AccessContextTestBase(TimeSpan arg)
	{
	}

	public void PublicMethod()
	{
	}

	internal void InternalMethod()
	{
	}

	protected void ProtectedMethod()
	{
	}

	protected internal void ProtectedInternalMethod()
	{
	}

	private void PrivateMethod()
	{
	}
}
