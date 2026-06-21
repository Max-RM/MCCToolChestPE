using System;

namespace Microsoft.ClearScript.Util;

internal sealed class CoTaskMemArrayBlock : CoTaskMemBlock
{
	private readonly int elementSize;

	private readonly int length;

	public CoTaskMemArrayBlock(int elementSize, int length)
		: base(elementSize * length)
	{
		this.elementSize = elementSize;
		this.length = length;
	}

	public IntPtr GetAddr(int index)
	{
		if (index < 0 || index >= length)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		if (base.Addr == IntPtr.Zero)
		{
			throw new ObjectDisposedException(ToString());
		}
		return GetAddrInternal(index);
	}

	private IntPtr GetAddrInternal(int index)
	{
		return base.Addr + index * elementSize;
	}
}
