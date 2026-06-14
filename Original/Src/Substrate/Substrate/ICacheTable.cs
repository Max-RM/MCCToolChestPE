namespace Substrate;

public interface ICacheTable<T>
{
	T this[int index] { get; }
}
