namespace Substrate.Core;

public interface IChunkContainer
{
	bool CanDelegateCoordinates { get; }

	int ChunkGlobalX(int cx);

	int ChunkGlobalZ(int cz);

	int ChunkLocalX(int cx);

	int ChunkLocalZ(int cz);

	IChunk GetChunk(int cx, int cz);

	ChunkRef GetChunkRef(int cx, int cz);

	ChunkRef CreateChunk(int cx, int cz);

	ChunkRef SetChunk(int cx, int cz, IChunk chunk);

	bool ChunkExists(int cx, int cz);

	bool DeleteChunk(int cx, int cz);

	int Save();

	bool SaveChunk(IChunk chunk);
}
