using System.Drawing;
using System.Windows.Forms;

namespace NBTExplorer.Windows;

internal class ToolStripExplorerRenderer : ToolStripProfessionalRenderer
{
	protected override void OnRenderSplitButtonBackground(ToolStripItemRenderEventArgs e)
	{
		base.OnRenderSplitButtonBackground(e);
		ToolStripSplitButton toolStripSplitButton = e.Item as ToolStripSplitButton;
		Graphics graphics = e.Graphics;
		if (toolStripSplitButton != null)
		{
			new Rectangle(Point.Empty, toolStripSplitButton.Size);
			Rectangle rectangle = new Rectangle(toolStripSplitButton.DropDownButtonBounds.X + 1, toolStripSplitButton.DropDownButtonBounds.Y + 1, toolStripSplitButton.DropDownButtonBounds.Width - 2, toolStripSplitButton.DropDownButtonBounds.Height - 2);
			using (Brush brush = new SolidBrush(base.ColorTable.ToolStripGradientEnd))
			{
				graphics.FillRectangle(brush, rectangle);
			}
			if (toolStripSplitButton.Pressed)
			{
				DrawArrow(new ToolStripArrowRenderEventArgs(graphics, toolStripSplitButton, rectangle, SystemColors.ControlText, ArrowDirection.Down));
			}
			else
			{
				DrawArrow(new ToolStripArrowRenderEventArgs(graphics, toolStripSplitButton, rectangle, SystemColors.ControlText, ArrowDirection.Right));
			}
		}
	}

	protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
	{
		if (e.ToolStrip is ToolStripDropDown || e.ToolStrip is MenuStrip || e.ToolStrip is StatusStrip)
		{
			base.OnRenderToolStripBackground(e);
			return;
		}
		using Brush brush = new SolidBrush(base.ColorTable.ToolStripGradientEnd);
		e.Graphics.FillRectangle(brush, e.ToolStrip.Bounds);
	}

	protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
	{
		if (e.ToolStrip is ToolStripDropDown || e.ToolStrip is MenuStrip || e.ToolStrip is StatusStrip)
		{
			base.OnRenderToolStripBorder(e);
		}
	}
}
