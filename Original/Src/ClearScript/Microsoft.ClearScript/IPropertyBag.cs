using System.Collections;
using System.Collections.Generic;

namespace Microsoft.ClearScript;

public interface IPropertyBag : IDictionary<string, object>, ICollection<KeyValuePair<string, object>>, IEnumerable<KeyValuePair<string, object>>, IEnumerable
{
}
