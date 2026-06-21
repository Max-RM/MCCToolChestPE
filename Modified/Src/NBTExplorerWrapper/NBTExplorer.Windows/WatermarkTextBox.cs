using System;
using System.Drawing;
using System.Windows.Forms;

namespace NBTExplorer.Windows;

public class WatermarkTextBox : TextBox
{
	public string WatermarkText { get; set; }

	public bool WatermarkActive { get; set; }

	public WatermarkTextBox()
	{
		WatermarkText = "Type here";
		WatermarkActive = true;
		Text = WatermarkText;
		ForeColor = Color.Gray;
		EventHandler value = delegate
		{
			RemoveWatermak();
		};
		base.GotFocus += value;
		base.LostFocus += delegate
		{
			ApplyWatermark();
		};
	}

	public void RemoveWatermak()
	{
		if (WatermarkActive)
		{
			WatermarkActive = false;
			Text = "";
			ForeColor = Color.Black;
		}
	}

	public void ApplyWatermark()
	{
		if ((!WatermarkActive && string.IsNullOrEmpty(Text)) || ForeColor == Color.Gray)
		{
			WatermarkActive = true;
			Text = WatermarkText;
			ForeColor = Color.Gray;
		}
	}

	public void ApplyWatermark(string newText)
	{
		Text = "";
		WatermarkText = newText;
		ApplyWatermark();
	}

	public void ApplyText(string text)
	{
		RemoveWatermak();
		Text = text;
	}
}
