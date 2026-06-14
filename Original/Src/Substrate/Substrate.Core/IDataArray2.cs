namespace Substrate.Core;

public interface IDataArray2 : IDataArray
{
	int this[int x, int z] { get; set; }

	int XDim { get; }

	int ZDim { get; }
}
