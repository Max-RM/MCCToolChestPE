namespace Substrate.Core;

public interface ILitBlock : IBlock
{
	int BlockLight { get; set; }

	int SkyLight { get; set; }
}
