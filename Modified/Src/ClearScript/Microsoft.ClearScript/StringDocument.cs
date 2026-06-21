using System.IO;
using System.Text;

namespace Microsoft.ClearScript;

public class StringDocument : Document
{
	private readonly DocumentInfo info;

	private readonly byte[] contents;

	public override DocumentInfo Info => info;

	public override Stream Contents => new MemoryStream(contents, writable: false);

	public override Encoding Encoding => Encoding.UTF8;

	public StringDocument(DocumentInfo info, string contents)
	{
		this.info = info;
		this.contents = Encoding.UTF8.GetBytes(contents);
	}
}
