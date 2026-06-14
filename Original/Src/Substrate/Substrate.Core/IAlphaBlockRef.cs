namespace Substrate.Core;

public interface IAlphaBlockRef : IDataBlock, ILitBlock, IPropertyBlock, IBlock
{
	bool IsValid { get; }
}
