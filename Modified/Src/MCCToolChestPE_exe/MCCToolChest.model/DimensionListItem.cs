namespace MCCToolChest.model;

public class DimensionListItem
{
	public int DimensionId { get; }

	public string DisplayName { get; }

	public string FolderKey => Constants.GetDimensionFolderName(DimensionId);

	public DimensionListItem(int dimensionId, string displayName)
	{
		DimensionId = dimensionId;
		DisplayName = displayName;
	}

	public override string ToString()
	{
		return DisplayName;
	}
}
