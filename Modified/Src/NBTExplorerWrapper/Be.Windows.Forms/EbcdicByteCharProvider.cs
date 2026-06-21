using System.Text;

namespace Be.Windows.Forms;

public class EbcdicByteCharProvider : IByteCharConverter
{
	private Encoding _ebcdicEncoding = Encoding.GetEncoding(500);

	public virtual char ToChar(byte b)
	{
		string text = _ebcdicEncoding.GetString(new byte[1] { b });
		if (text.Length <= 0)
		{
			return '.';
		}
		return text[0];
	}

	public virtual byte ToByte(char c)
	{
		byte[] bytes = _ebcdicEncoding.GetBytes(new char[1] { c });
		if (bytes.Length <= 0)
		{
			return 0;
		}
		return bytes[0];
	}

	public override string ToString()
	{
		return "EBCDIC (Code Page 500)";
	}
}
