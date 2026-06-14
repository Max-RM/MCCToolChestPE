namespace Be.Windows.Forms;

public interface IByteCharConverter
{
	char ToChar(byte b);

	byte ToByte(char c);
}
