namespace Substrate.Core;

public interface IBlock
{
	BlockInfo Info { get; }

	int ID { get; set; }
}
