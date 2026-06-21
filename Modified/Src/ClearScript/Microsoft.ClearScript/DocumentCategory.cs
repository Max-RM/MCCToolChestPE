namespace Microsoft.ClearScript;

public abstract class DocumentCategory
{
	private sealed class ScriptDocument : DocumentCategory
	{
		public static readonly ScriptDocument Instance = new ScriptDocument();

		internal override string DefaultName => "Script";

		private ScriptDocument()
		{
		}

		public override string ToString()
		{
			return "Script";
		}
	}

	public static DocumentCategory Script => ScriptDocument.Instance;

	internal abstract string DefaultName { get; }

	internal DocumentCategory()
	{
	}
}
