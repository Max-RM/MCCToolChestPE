namespace Substrate.Core;

public interface IDataArray
{
	int this[int i] { get; set; }

	int Length { get; }

	int DataWidth { get; }

	void Clear();
}
