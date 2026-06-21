using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls;

public class PeDataButtonsFrame : UserControl
{
	private EventHandler _editorHandler;

	private IContainer _components;

	private Button _editorButton;

	public event EventHandler DataEditor
	{
		add
		{
			_editorHandler = (EventHandler)Delegate.Combine(_editorHandler, value);
		}
		remove
		{
			_editorHandler = (EventHandler)Delegate.Remove(_editorHandler, value);
		}
	}

	public PeDataButtonsFrame()
	{
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		InitializeComponent();
	}

	protected virtual void OnDataEditor()
	{
		_editorHandler?.Invoke(this, EventArgs.Empty);
	}

	private void EditorButtonClick(object sender, EventArgs e)
	{
		OnDataEditor();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _components != null)
		{
			_components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		_editorButton = new Button();
		SuspendLayout();
		_editorButton.BackColor = Color.LightGray;
		_editorButton.BackgroundImageLayout = ImageLayout.Zoom;
		_editorButton.FlatStyle = FlatStyle.Popup;
		_editorButton.Location = new Point(4, 26);
		_editorButton.Name = "editorButton";
		_editorButton.Size = new Size(64, 64);
		_editorButton.TabIndex = 0;
		_editorButton.UseVisualStyleBackColor = false;
		_editorButton.Click += EditorButtonClick;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.Gainsboro;
		base.Controls.Add(_editorButton);
		base.Name = "PeDataButtonsFrame";
		base.Size = new Size(72, 470);
		ResumeLayout(performLayout: false);
	}

	public void SetButtonImage(Image image)
	{
		_editorButton.BackgroundImage = image;
	}
}
