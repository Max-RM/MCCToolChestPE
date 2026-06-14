namespace Substrate.Core;

public interface IDataArray3 : IDataArray
{
	int this[int x, int y, int z] { get; set; }

	int XDim { get; }

	int YDim { get; }

	int ZDim { get; }

	int GetIndex(int x, int y, int z);

	void GetMultiIndex(int index, out int x, out int y, out int z);
}
