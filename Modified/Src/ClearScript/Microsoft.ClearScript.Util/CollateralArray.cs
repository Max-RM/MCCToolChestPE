namespace Microsoft.ClearScript.Util;

internal sealed class CollateralArray<THolder, TElement> : CollateralObject<THolder, TElement[]> where THolder : class
{
	public override void Set(THolder holder, TElement[] value)
	{
		if (value == null)
		{
			Clear(holder);
		}
		else if (value.Length != 0)
		{
			base.Set(holder, value);
		}
		else
		{
			base.Set(holder, ArrayHelpers.GetEmptyArray<TElement>());
		}
	}
}
