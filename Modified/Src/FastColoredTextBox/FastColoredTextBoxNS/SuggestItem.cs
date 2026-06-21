namespace FastColoredTextBoxNS;

public class SuggestItem : AutocompleteItem
{
	public SuggestItem(string text, int imageIndex)
		: base(text, imageIndex)
	{
	}

	public override CompareResult Compare(string fragmentText)
	{
		return CompareResult.Visible;
	}
}
