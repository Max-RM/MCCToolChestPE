namespace Be.Windows.Forms;

public class DefaultByteCharConverter : IByteCharConverter
{
	public virtual char ToChar(byte b)
	{
		if (b <= 31 || (b > 126 && b < 160))
		{
			return '.';
		}
		return (char)b;
	}

	public virtual byte ToByte(char c)
	{
		return (byte)c;
	}

	public override string ToString()
	{
		return "Default";
	}
}
