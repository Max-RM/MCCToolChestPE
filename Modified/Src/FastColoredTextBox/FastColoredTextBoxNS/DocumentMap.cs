using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FastColoredTextBoxNS;

public class DocumentMap : Control
{
	public EventHandler TargetChanged;

	private FastColoredTextBox target;

	private float scale = 0.3f;

	private bool needRepaint = true;

	private Place startPlace = Place.Empty;

	private bool scrollbarVisible = true;

	[Description("Target FastColoredTextBox")]
	public FastColoredTextBox Target
	{
		get
		{
			return target;
		}
		set
		{
			if (target != null)
			{
				UnSubscribe(target);
			}
			target = value;
			if (value != null)
			{
				Subscribe(target);
			}
			OnTargetChanged();
		}
	}

	[Description("Scale")]
	[DefaultValue(0.3f)]
	public new float Scale
	{
		get
		{
			return scale;
		}
		set
		{
			scale = value;
			NeedRepaint();
		}
	}

	[Description("Scrollbar visibility")]
	[DefaultValue(true)]
	public bool ScrollbarVisible
	{
		get
		{
			return scrollbarVisible;
		}
		set
		{
			scrollbarVisible = value;
			NeedRepaint();
		}
	}

	public DocumentMap()
	{
		ForeColor = Color.Maroon;
		SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
		Application.Idle += Application_Idle;
	}

	private void Application_Idle(object sender, EventArgs e)
	{
		if (needRepaint)
		{
			Invalidate();
		}
	}

	protected virtual void OnTargetChanged()
	{
		NeedRepaint();
		if (TargetChanged != null)
		{
			TargetChanged(this, EventArgs.Empty);
		}
	}

	protected virtual void UnSubscribe(FastColoredTextBox target)
	{
		target.Scroll -= Target_Scroll;
		target.SelectionChangedDelayed -= Target_SelectionChanged;
		target.VisibleRangeChanged -= Target_VisibleRangeChanged;
	}

	protected virtual void Subscribe(FastColoredTextBox target)
	{
		target.Scroll += Target_Scroll;
		target.SelectionChangedDelayed += Target_SelectionChanged;
		target.VisibleRangeChanged += Target_VisibleRangeChanged;
	}

	protected virtual void Target_VisibleRangeChanged(object sender, EventArgs e)
	{
		NeedRepaint();
	}

	protected virtual void Target_SelectionChanged(object sender, EventArgs e)
	{
		NeedRepaint();
	}

	protected virtual void Target_Scroll(object sender, ScrollEventArgs e)
	{
		NeedRepaint();
	}

	protected override void OnResize(EventArgs e)
	{
		base.OnResize(e);
		NeedRepaint();
	}

	public void NeedRepaint()
	{
		needRepaint = true;
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		if (target == null)
		{
			return;
		}
		float num = Scale * 100f / (float)target.Zoom;
		if (num <= float.Epsilon)
		{
			return;
		}
		Range visibleRange = target.VisibleRange;
		if (startPlace.iLine > visibleRange.Start.iLine)
		{
			startPlace.iLine = visibleRange.Start.iLine;
		}
		else
		{
			Point point = target.PlaceToPoint(visibleRange.End);
			point.Offset(0, -(int)((float)base.ClientSize.Height / num) + target.CharHeight);
			Place place = target.PointToPlace(point);
			if (place.iLine > startPlace.iLine)
			{
				startPlace.iLine = place.iLine;
			}
		}
		startPlace.iChar = 0;
		int count = target.Lines.Count;
		float num2 = (float)visibleRange.Start.iLine / (float)count;
		float num3 = (float)visibleRange.End.iLine / (float)count;
		e.Graphics.ScaleTransform(num, num);
		SizeF sizeF = new SizeF((float)base.ClientSize.Width / num, (float)base.ClientSize.Height / num);
		target.DrawText(e.Graphics, startPlace, sizeF.ToSize());
		Point point2 = target.PlaceToPoint(startPlace);
		Point point3 = target.PlaceToPoint(visibleRange.Start);
		Point point4 = target.PlaceToPoint(visibleRange.End);
		int num4 = point3.Y - point2.Y;
		int num5 = point4.Y + target.CharHeight - point2.Y;
		e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
		using (SolidBrush brush = new SolidBrush(Color.FromArgb(50, ForeColor)))
		{
			using Pen pen = new Pen(brush, 1f / num);
			Rectangle rect = new Rectangle(0, num4, (int)((float)(base.ClientSize.Width - 1) / num), num5 - num4);
			e.Graphics.FillRectangle(brush, rect);
			e.Graphics.DrawRectangle(pen, rect);
		}
		if (scrollbarVisible)
		{
			e.Graphics.ResetTransform();
			e.Graphics.SmoothingMode = SmoothingMode.None;
			using SolidBrush brush2 = new SolidBrush(Color.FromArgb(200, ForeColor));
			RectangleF rect2 = new RectangleF(base.ClientSize.Width - 3, (float)base.ClientSize.Height * num2, 2f, (float)base.ClientSize.Height * (num3 - num2));
			e.Graphics.FillRectangle(brush2, rect2);
		}
		needRepaint = false;
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left)
		{
			Scroll(e.Location);
		}
		base.OnMouseDown(e);
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left)
		{
			Scroll(e.Location);
		}
		base.OnMouseMove(e);
	}

	private void Scroll(Point point)
	{
		if (target != null)
		{
			float num = Scale * 100f / (float)target.Zoom;
			if (!(num <= float.Epsilon))
			{
				Point point2 = new Point(0, target.PlaceToPoint(startPlace).Y + (int)((float)point.Y / num));
				Place place = target.PointToPlace(point2);
				target.DoRangeVisible(new Range(target, place, place), tryToCentre: true);
				BeginInvoke(new MethodInvoker(OnScroll));
			}
		}
	}

	private void OnScroll()
	{
		Refresh();
		target.Refresh();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			Application.Idle -= Application_Idle;
			if (target != null)
			{
				UnSubscribe(target);
			}
		}
		base.Dispose(disposing);
	}
}
