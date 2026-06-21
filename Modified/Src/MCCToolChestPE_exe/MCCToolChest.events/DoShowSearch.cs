using System.Collections.Generic;
using MCCToolChest.model;

namespace MCCToolChest.events;

public delegate void DoShowSearch(string dimension, Dictionary<string, List<EntitySearchResult>> searchResults);
