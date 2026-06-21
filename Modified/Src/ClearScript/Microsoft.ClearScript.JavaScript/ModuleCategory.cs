namespace Microsoft.ClearScript.JavaScript;

public static class ModuleCategory
{
	private sealed class StandardModule : DocumentCategory
	{
		public static readonly StandardModule Instance = new StandardModule();

		internal override string DefaultName => "Module";

		private StandardModule()
		{
		}

		public override string ToString()
		{
			return "ECMAScript Module";
		}
	}

	private sealed class CommonJSModule : DocumentCategory
	{
		public static readonly CommonJSModule Instance = new CommonJSModule();

		internal override string DefaultName => "Module";

		private CommonJSModule()
		{
		}

		public override string ToString()
		{
			return "CommonJS Module";
		}
	}

	public static DocumentCategory Standard => StandardModule.Instance;

	public static DocumentCategory CommonJS => CommonJSModule.Instance;
}
