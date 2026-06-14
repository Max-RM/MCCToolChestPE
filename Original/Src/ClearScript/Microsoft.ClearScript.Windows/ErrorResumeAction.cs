namespace Microsoft.ClearScript.Windows;

internal enum ErrorResumeAction
{
	ReexecuteErrorStatement,
	AbortCallAndReturnErrorToCaller,
	SkipErrorStatement
}
