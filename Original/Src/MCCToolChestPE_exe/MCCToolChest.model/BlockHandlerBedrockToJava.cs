using System.Collections.Generic;

namespace MCCToolChest.model;

public delegate void BlockHandlerBedrockToJava(int x, int y, int z, int val, Dictionary<string, BlockStateProperty> properties, WorkingEntitiesData workingEntitiesData);
