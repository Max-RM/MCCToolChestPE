namespace Substrate.Core;

public interface IDataBlock : IBlock
{
	int Data { get; set; }
}
