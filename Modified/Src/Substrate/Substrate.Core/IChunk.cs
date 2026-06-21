using System.IO;

namespace Substrate.Core;

public interface IChunk
{
	int X { get; }

	int Z { get; }

	AlphaBlockCollection Blocks { get; }

	EntityCollection Entities { get; }

	bool IsTerrainPopulated { get; set; }

	void SetLocation(int x, int z);

	bool Save(Stream outStream);
}
