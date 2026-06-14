using System;
using System.Runtime.CompilerServices;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.model;

public class BlockStateConfig
{
	public bool isRuntime;

	public int bitsPerBlock;

	public int blocksPerWord;

	public int wordCount;

	public uint mask;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BlockStateConfig(int bitIndicator, bool extractRuntime)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		isRuntime = (bitIndicator & 1) != 0;
		bitsPerBlock = bitIndicator >> 1;
		blocksPerWord = (int)Math.Floor((decimal)(32 / bitsPerBlock));
		wordCount = (int)Math.Ceiling(4096.0 / (double)blocksPerWord);
		mask = (uint)((1 << bitsPerBlock) - 1);
	}
}
