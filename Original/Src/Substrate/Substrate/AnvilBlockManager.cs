using Substrate.Core;

namespace Substrate;

public class AnvilBlockManager : BlockManager
{
	public AnvilBlockManager(IChunkManager cm)
		: base(cm)
	{
		IChunk chunk = AnvilChunk.Create(0, 0);
		chunkXDim = chunk.Blocks.XDim;
		chunkYDim = chunk.Blocks.YDim;
		chunkZDim = chunk.Blocks.ZDim;
		chunkXMask = chunkXDim - 1;
		chunkYMask = chunkYDim - 1;
		chunkZMask = chunkZDim - 1;
		chunkXLog = Log2(chunkXDim);
		chunkYLog = Log2(chunkYDim);
		chunkZLog = Log2(chunkZDim);
	}
}
