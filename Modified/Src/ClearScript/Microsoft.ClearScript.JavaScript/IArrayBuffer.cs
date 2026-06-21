namespace Microsoft.ClearScript.JavaScript;

public interface IArrayBuffer
{
	ulong Size { get; }

	byte[] GetBytes();

	ulong ReadBytes(ulong offset, ulong count, byte[] destination, ulong destinationIndex);

	ulong WriteBytes(byte[] source, ulong sourceIndex, ulong count, ulong offset);
}
