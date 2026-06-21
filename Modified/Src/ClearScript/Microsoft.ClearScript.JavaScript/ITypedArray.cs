namespace Microsoft.ClearScript.JavaScript;

public interface ITypedArray : IArrayBufferView
{
	ulong Length { get; }
}
public interface ITypedArray<T> : ITypedArray, IArrayBufferView
{
	T[] ToArray();

	ulong Read(ulong index, ulong length, T[] destination, ulong destinationIndex);

	ulong Write(T[] source, ulong sourceIndex, ulong length, ulong index);
}
