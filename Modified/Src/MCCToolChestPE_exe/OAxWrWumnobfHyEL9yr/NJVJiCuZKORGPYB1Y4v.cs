using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using YBh7EaXMWmkFRJOX37M;

namespace OAxWrWumnobfHyEL9yr;

internal class NJVJiCuZKORGPYB1Y4v
{
	private bool fhASRYG1q5L;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NJVJiCuZKORGPYB1Y4v()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		fhASRYG1q5L = true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NJVJiCuZKORGPYB1Y4v(bool P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		fhASRYG1q5L = true;
		fhASRYG1q5L = P_0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	public bool xZ7SRPTWlgV()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return fhASRYG1q5L;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	public void S6FSRREan0P(bool P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		fhASRYG1q5L = P_0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal short eksSR0WUryc(Stream P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] array = woCSRXwBx5C(P_0, 2);
		if (BitConverter.IsLittleEndian && xZ7SRPTWlgV())
		{
			Array.Reverse(array);
		}
		return BitConverter.ToInt16(array, 0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal ushort WouSRBjkY9v(Stream P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] array = woCSRXwBx5C(P_0, 2);
		if (BitConverter.IsLittleEndian && xZ7SRPTWlgV())
		{
			Array.Reverse(array);
		}
		return BitConverter.ToUInt16(array, 0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal int PsDSRt4knGJ(Stream P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] array = woCSRXwBx5C(P_0, 4);
		if (BitConverter.IsLittleEndian && xZ7SRPTWlgV())
		{
			Array.Reverse(array);
		}
		return BitConverter.ToInt32(array, 0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal uint Wb4SRa9ZMf2(Stream P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] array = woCSRXwBx5C(P_0, 4);
		if (BitConverter.IsLittleEndian && xZ7SRPTWlgV())
		{
			Array.Reverse(array);
		}
		return BitConverter.ToUInt32(array, 0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private byte[] woCSRXwBx5C(Stream P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] array = new byte[P_1];
		P_0.Read(array, 0, P_1);
		return array;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal string fwsSRxNiNtD(Stream P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ushort num = WouSRBjkY9v(P_0);
		byte[] array = new byte[num];
		for (int i = 0; i < num; i++)
		{
			byte b = (byte)P_0.ReadByte();
			array[i] = b;
		}
		Encoding uTF = Encoding.UTF8;
		return uTF.GetString(array);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal int jNjSReVFIcn(Stream P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int result = PsDSRt4knGJ(P_0);
		P_0.Seek(-4L, SeekOrigin.Current);
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void CyBSRMDUOvV(short P_0, Stream P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] bytes = BitConverter.GetBytes(P_0);
		if (BitConverter.IsLittleEndian && xZ7SRPTWlgV())
		{
			Array.Reverse(bytes);
		}
		P_1.Write(bytes, 0, bytes.Length);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void aKxSRUQsOyk(int P_0, Stream P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] bytes = BitConverter.GetBytes(P_0);
		if (BitConverter.IsLittleEndian && xZ7SRPTWlgV())
		{
			Array.Reverse(bytes);
		}
		P_1.Write(bytes, 0, bytes.Length);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void EgaSRLjWsQY(uint P_0, Stream P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		byte[] bytes = BitConverter.GetBytes(P_0);
		if (BitConverter.IsLittleEndian && xZ7SRPTWlgV())
		{
			Array.Reverse(bytes);
		}
		P_1.Write(bytes, 0, bytes.Length);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void guMSRgZx1hs(string P_0, MemoryStream P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Encoding uTF = Encoding.UTF8;
		byte[] bytes = uTF.GetBytes(P_0);
		CyBSRMDUOvV((short)bytes.Length, P_1);
		P_1.Write(bytes, 0, bytes.Length);
	}
}
