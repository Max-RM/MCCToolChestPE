using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace FastColoredTextBoxNS;

public abstract class Style : IDisposable
{
	public virtual bool IsExportable { get; set; }

	public event EventHandler<VisualMarkerEventArgs> VisualMarkerClick;

	public Style()
	{
		IsExportable = true;
	}

	public abstract void Draw(Graphics gr, Point position, Range range);

	public virtual void OnVisualMarkerClick(FastColoredTextBox tb, VisualMarkerEventArgs args)
	{
		if (this.VisualMarkerClick != null)
		{
			this.VisualMarkerClick(tb, args);
		}
	}

	protected virtual void AddVisualMarker(FastColoredTextBox tb, StyleVisualMarker marker)
	{
		tb.AddVisualMarker(marker);
	}

	public static Size GetSizeOfRange(Range range)
	{
		return new Size((range.End.iChar - range.Start.iChar) * range.tb.CharWidth, range.tb.CharHeight);
	}

	public static GraphicsPath GetRoundedRectangle(Rectangle rect, int d)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddArc(rect.X, rect.Y, d, d, 180f, 90f);
		graphicsPath.AddArc(rect.X + rect.Width - d, rect.Y, d, d, 270f, 90f);
		graphicsPath.AddArc(rect.X + rect.Width - d, rect.Y + rect.Height - d, d, d, 0f, 90f);
		graphicsPath.AddArc(rect.X, rect.Y + rect.Height - d, d, d, 90f, 90f);
		graphicsPath.AddLine(rect.X, rect.Y + rect.Height - d, rect.X, rect.Y + d / 2);
		return graphicsPath;
	}

	public virtual void Dispose()
	{
	}

	public virtual string GetCSS()
	{
		return "";
	}

	public virtual RTFStyleDescriptor GetRTF()
	{
		return new RTFStyleDescriptor();
	}
}
