using System.Collections.Generic;
using Substrate.Nbt;

namespace MCCToolChest.model;

public delegate void BlockHandlerJavaToBedrock(int x, int y, int z, int val, Dictionary<string, BlockStateProperty> properties, TagNodeList tileEntities);
