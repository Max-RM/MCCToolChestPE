using System.IO;
using System.Text;

namespace Microsoft.ClearScript;

public abstract class Document
{
	public abstract DocumentInfo Info { get; }

	public abstract Stream Contents { get; }

	public virtual Encoding Encoding => null;
}
