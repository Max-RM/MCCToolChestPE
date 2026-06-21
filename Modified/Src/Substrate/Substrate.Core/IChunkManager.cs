using System.Collections;
using System.Collections.Generic;

namespace Substrate.Core;

public interface IChunkManager : IChunkContainer, IEnumerable<ChunkRef>, IEnumerable
{
}
