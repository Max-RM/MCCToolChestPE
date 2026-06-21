using System;
using System.Drawing;

namespace FastColoredTextBoxNS;

public class AutocompleteItem
{
	public string Text;

	public int ImageIndex = -1;

	public object Tag;

	private string toolTipTitle;

	private string toolTipText;

	private string menuText;

	public AutocompleteMenu Parent { get; internal set; }

	public virtual string ToolTipTitle
	{
		get
		{
			return toolTipTitle;
		}
		set
		{
			toolTipTitle = value;
		}
	}

	public virtual string ToolTipText
	{
		get
		{
			return toolTipText;
		}
		set
		{
			toolTipText = value;
		}
	}

	public virtual string MenuText
	{
		get
		{
			return menuText;
		}
		set
		{
			menuText = value;
		}
	}

	public virtual Color ForeColor
	{
		get
		{
			return Color.Transparent;
		}
		set
		{
			throw new NotImplementedException("Override this property to change color");
		}
	}

	public virtual Color BackColor
	{
		get
		{
			return Color.Transparent;
		}
		set
		{
			throw new NotImplementedException("Override this property to change color");
		}
	}

	public AutocompleteItem()
	{
	}

	public AutocompleteItem(string text)
	{
		Text = text;
	}

	public AutocompleteItem(string text, int imageIndex)
		: this(text)
	{
		ImageIndex = imageIndex;
	}

	public AutocompleteItem(string text, int imageIndex, string menuText)
		: this(text, imageIndex)
	{
		this.menuText = menuText;
	}

	public AutocompleteItem(string text, int imageIndex, string menuText, string toolTipTitle, string toolTipText)
		: this(text, imageIndex, menuText)
	{
		this.toolTipTitle = toolTipTitle;
		this.toolTipText = toolTipText;
	}

	public virtual string GetTextForReplace()
	{
		return Text;
	}

	public virtual CompareResult Compare(string fragmentText)
	{
		if (Text.StartsWith(fragmentText, StringComparison.InvariantCultureIgnoreCase) && Text != fragmentText)
		{
			return CompareResult.VisibleAndSelected;
		}
		return CompareResult.Hidden;
	}

	public override string ToString()
	{
		return menuText ?? Text;
	}

	public virtual void OnSelected(AutocompleteMenu popupMenu, SelectedEventArgs e)
	{
	}
}
