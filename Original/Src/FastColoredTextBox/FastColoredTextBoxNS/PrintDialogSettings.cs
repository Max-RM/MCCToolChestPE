namespace FastColoredTextBoxNS;

public class PrintDialogSettings
{
	public bool ShowPageSetupDialog { get; set; }

	public bool ShowPrintDialog { get; set; }

	public bool ShowPrintPreviewDialog { get; set; }

	public string Title { get; set; }

	public string Footer { get; set; }

	public string Header { get; set; }

	public bool IncludeLineNumbers { get; set; }

	public PrintDialogSettings()
	{
		ShowPrintPreviewDialog = true;
		Title = "";
		Footer = "";
		Header = "";
	}
}
