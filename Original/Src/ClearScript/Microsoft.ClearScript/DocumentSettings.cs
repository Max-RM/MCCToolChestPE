namespace Microsoft.ClearScript;

public class DocumentSettings
{
	private DocumentLoader loader;

	public DocumentLoader Loader
	{
		get
		{
			return loader ?? DocumentLoader.Default;
		}
		set
		{
			loader = value;
		}
	}

	public DocumentAccessFlags AccessFlags { get; set; }

	public string SearchPath { get; set; }

	public string FileNameExtensions { get; set; }

	public DocumentLoadCallback LoadCallback { get; set; }

	public DocumentContextCallback ContextCallback { get; set; }
}
