namespace Microsoft.ClearScript;

internal interface IHostList
{
	int Count { get; }

	object this[int index] { get; set; }
}
