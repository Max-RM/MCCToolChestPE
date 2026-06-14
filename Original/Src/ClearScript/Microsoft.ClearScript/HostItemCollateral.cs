using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using Microsoft.ClearScript.Util;

namespace Microsoft.ClearScript;

internal sealed class HostItemCollateral
{
	public class CollateralObject<T> : CollateralObject<HostItem, T> where T : class
	{
	}

	public class ListDataFields
	{
		public int[] PropertyIndices;

		public int CachedCount;
	}

	public readonly CollateralObject<IDynamic> TargetDynamic = new CollateralObject<IDynamic>();

	public readonly CollateralObject<IPropertyBag> TargetPropertyBag = new CollateralObject<IPropertyBag>();

	public readonly CollateralObject<IHostList> TargetList = new CollateralObject<IHostList>();

	public readonly CollateralObject<DynamicMetaObject> TargetDynamicMetaObject = new CollateralObject<DynamicMetaObject>();

	public readonly CollateralObject<IEnumerator> TargetEnumerator = new CollateralObject<IEnumerator>();

	public readonly CollateralObject<HashSet<string>> ExpandoMemberNames = new CollateralObject<HashSet<string>>();

	public readonly CollateralObject<ListDataFields> ListData = new CollateralObject<ListDataFields>();

	public readonly CollateralObject<Dictionary<string, HostMethod>> HostMethodMap = new CollateralObject<Dictionary<string, HostMethod>>();

	public readonly CollateralObject<Dictionary<string, HostIndexedProperty>> HostIndexedPropertyMap = new CollateralObject<Dictionary<string, HostIndexedProperty>>();
}
