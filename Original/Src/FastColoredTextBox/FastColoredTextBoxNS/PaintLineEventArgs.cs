using System.Drawing;
using System.Windows.Forms;

namespace FastColoredTextBoxNS;

public class PaintLineEventArgs : PaintEventArgs
{
	public int LineIndex { get; private set; }

	public Rectangle LineRect { get; private set; }

	public PaintLineEventArgs(int iLine, Rectangle rect, Graphics gr, Rectangle clipRect)
		: base(gr, clipRect)
	{
		LineIndex = iLine;
		LineRect = rect;
	}
}
