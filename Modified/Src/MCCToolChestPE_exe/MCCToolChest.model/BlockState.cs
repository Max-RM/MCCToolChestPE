using System.Collections.Generic;
using System.Runtime.CompilerServices;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.model;

public class BlockState
{
	public int? id;

	public short data;

	public string name;

	public int runtimeID;

	public int paletteIndex;

	public MasterBlock masterBlock;

	public List<MasterBlockItemProperty> properties;

	public bool useProperties;

	public bool isDoor;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BlockState Copy(int paletteIndex)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BlockState blockState = new BlockState();
		blockState.data = data;
		blockState.id = id;
		blockState.name = name;
		blockState.runtimeID = runtimeID;
		blockState.paletteIndex = paletteIndex;
		blockState.masterBlock = masterBlock;
		blockState.properties = properties;
		blockState.useProperties = useProperties;
		blockState.isDoor = isDoor;
		return blockState;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BlockState()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		id = null;
		name = string.Empty;
	}
}
