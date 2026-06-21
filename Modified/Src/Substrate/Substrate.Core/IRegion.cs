using System.IO;
using Substrate.Nbt;

namespace Substrate.Core;

public interface IRegion : IChunkContainer
{
	int X { get; }

	int Z { get; }

	string GetFileName();

	string GetFilePath();

	NbtTree GetChunkTree(int lcx, int lcz);

	bool SaveChunkTree(int lcx, int lcz, NbtTree tree);

	bool SaveChunkTree(int lcx, int lcz, NbtTree tree, int timestamp);

	Stream GetChunkOutStream(int lcx, int lcz);

	int ChunkCount();

	new ChunkRef GetChunkRef(int lcx, int lcz);

	new ChunkRef CreateChunk(int lcx, int lcz);

	int GetChunkTimestamp(int lcx, int lcz);

	void SetChunkTimestamp(int lcx, int lcz, int timestamp);
}
