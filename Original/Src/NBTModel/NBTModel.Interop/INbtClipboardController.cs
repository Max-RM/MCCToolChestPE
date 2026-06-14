namespace NBTModel.Interop;

public interface INbtClipboardController
{
	bool ContainsData { get; }

	void CopyToClipboard(NbtClipboardData data);

	NbtClipboardData CopyFromClipboard();
}
