using System;
using System.Runtime.CompilerServices;
using FRf36gucTeRIo5eJcof;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.model;

[Serializable]
public class LayersClipboard
{
	private Ib8r6ijzN8XDyCxCIdE[] RZRSlZkeFyp;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LayersClipboard()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LayersClipboard(ChunkYLayer[] layers)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		RZRSlZkeFyp = new Ib8r6ijzN8XDyCxCIdE[layers.Length];
		for (int i = 0; i < layers.Length; i++)
		{
			RZRSlZkeFyp[i] = new Ib8r6ijzN8XDyCxCIdE(layers[i]);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ChunkYLayer[] ToChunkLayers()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ChunkYLayer[] array = new ChunkYLayer[RZRSlZkeFyp.Length];
		for (int i = 0; i < RZRSlZkeFyp.Length; i++)
		{
			array[i] = RZRSlZkeFyp[i].XBlSlTloAAP();
		}
		return array;
	}
}
