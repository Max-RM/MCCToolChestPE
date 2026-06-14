namespace Substrate.Core;

public interface IActiveBlock : IBlock
{
	int TileTickValue { get; set; }

	TileTick GetTileTick();

	void SetTileTick(TileTick tt);

	void CreateTileTick();

	void ClearTileTick();
}
