using System;
using System.Collections.Generic;
using System.IO;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace NsF2F1XiJAVBnudIoxZ;

internal class yfs8Q5XRDNZPbwaTSae
{
	private enum shBqIBXvG9nuLwwEKef
	{

	}

	internal class EaavQkXf0krpBhnhsdS
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		private unsafe static uint DiuS5l5yDHn(void* P_0, uint P_1)
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			uint result = 0u;
			if (BitConverter.IsLittleEndian)
			{
				result = *(uint*)P_0;
			}
			else
			{
				switch (P_1)
				{
				case 4u:
					result = (uint)(*(byte*)P_0 | (((byte*)P_0)[1] << 8) | (((byte*)P_0)[2] << 16) | (((byte*)P_0)[3] << 24));
					break;
				case 3u:
					result = (uint)(*(byte*)P_0 | (((byte*)P_0)[1] << 8) | (((byte*)P_0)[2] << 16));
					break;
				case 2u:
					result = (uint)(*(byte*)P_0 | (((byte*)P_0)[1] << 8));
					break;
				case 1u:
					result = *(byte*)P_0;
					break;
				}
			}
			return result;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private unsafe static void buXS52VvhuD(uint P_0, void* P_1, uint P_2)
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			if (BitConverter.IsLittleEndian)
			{
				switch (P_2)
				{
				case 2u:
				case 3u:
				case 4u:
					*(uint*)P_1 = P_0;
					break;
				case 1u:
					*(byte*)P_1 = (byte)P_0;
					break;
				}
				return;
			}
			switch (P_2)
			{
			case 4u:
				*(byte*)P_1 = (byte)P_0;
				((sbyte*)P_1)[1] = (sbyte)(byte)(P_0 >> 8);
				((sbyte*)P_1)[2] = (sbyte)(byte)(P_0 >> 16);
				((sbyte*)P_1)[3] = (sbyte)(byte)(P_0 >> 24);
				break;
			case 3u:
				*(byte*)P_1 = (byte)P_0;
				((sbyte*)P_1)[1] = (sbyte)(byte)(P_0 >> 8);
				((sbyte*)P_1)[2] = (sbyte)(byte)(P_0 >> 16);
				break;
			case 2u:
				*(byte*)P_1 = (byte)P_0;
				((sbyte*)P_1)[1] = (sbyte)(byte)(P_0 >> 8);
				break;
			case 1u:
				*(byte*)P_1 = (byte)P_0;
				break;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private unsafe static bool L4fS5yiWQgU(void* P_0, void* P_1, uint P_2)
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			bool flag = true;
			uint num = 0u;
			while (flag && num < P_2)
			{
				flag = ((byte*)P_0)[(int)num] == ((byte*)P_1)[(int)num];
				num++;
			}
			return flag;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private unsafe static bool rVeS5044ANF(void* P_0, string P_1)
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			byte[] bytes = Encoding.ASCII.GetBytes(P_1);
			fixed (byte* ptr = bytes)
			{
				return L4fS5yiWQgU(P_0, ptr, (uint)bytes.Length);
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private unsafe static void mhGS5BSty8a(void* P_0, byte P_1, uint P_2)
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			for (uint num = 0u; num < P_2; num++)
			{
				((sbyte*)P_0)[(int)num] = (sbyte)P_1;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private unsafe static void gWcS5tIiASm(void* P_0, void* P_1, uint P_2)
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			for (uint num = 0u; num < P_2; num++)
			{
				((sbyte*)P_0)[(int)num] = ((sbyte*)P_1)[(int)num];
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private unsafe static void iowS5aAAHb0(void* P_0, string P_1)
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			byte[] bytes = Encoding.ASCII.GetBytes(P_1);
			fixed (byte* ptr = bytes)
			{
				gWcS5tIiASm(P_0, ptr, (uint)bytes.Length);
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private unsafe static void dlqS5XUqVND(byte* P_0, byte* P_1, uint P_2)
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			if (BitConverter.IsLittleEndian)
			{
				if (P_2 < 5)
				{
					*(int*)P_0 = *(int*)P_1;
					return;
				}
				byte* ptr = P_0 + (int)P_2;
				while (P_0 < ptr)
				{
					*(int*)P_0 = *(int*)P_1;
					P_0 += 4;
					P_1 += 4;
				}
			}
			else if (P_2 > 8 && P_1 + (int)P_2 < P_0)
			{
				gWcS5tIiASm(P_0, P_1, P_2);
			}
			else
			{
				byte* ptr2 = P_0 + (int)P_2;
				while (P_0 < ptr2)
				{
					*P_0 = *P_1;
					P_0++;
					P_1++;
				}
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private unsafe static uint T08S5xwoNqc(byte[] P_0, uint P_1, shBqIBXvG9nuLwwEKef P_2)
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			uint result = 0u;
			fixed (byte* ptr = P_0)
			{
				if (rVeS5044ANF(ptr + (int)P_1, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(259398)))
				{
					result = ((uint*)(ptr + (int)P_1))[(int)P_2];
				}
			}
			return result;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static uint NAdS5e2roFV(byte[] P_0)
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return T08S5xwoNqc(P_0, 0u, (shBqIBXvG9nuLwwEKef)2);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static uint KoXS5MUlTPZ(byte[] P_0, uint P_1)
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return T08S5xwoNqc(P_0, P_1, (shBqIBXvG9nuLwwEKef)3);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private unsafe static uint EhVS5Ug5eB5(byte[] P_0, uint P_1, byte[] P_2, uint P_3)
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			fixed (byte* ptr = P_0)
			{
				fixed (byte* ptr2 = P_2)
				{
					byte* ptr3 = ptr + (int)P_1;
					uint num = 32u;
					byte* ptr4 = ptr3 + (int)P_3 - 1;
					byte* ptr5 = ptr3 + 1;
					byte** ptr6 = (byte**)(ptr2 + (int)P_3 + 36000 - (nint)sizeof(byte*) * (nint)4096 - (long)(ptr2 + (int)P_3) % 8L);
					byte* ptr7 = ptr2 + (int)num;
					byte* ptr8 = ptr2 + (int)num + 4 + 1;
					byte* ptr9 = ptr8;
					byte* ptr10 = ptr5;
					uint num2 = 1073741824u;
					uint* ptr11 = (uint*)ptr2;
					byte* ptr12 = ptr4 - 16;
					iowS5aAAHb0(ptr11, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(259398));
					*ptr2 = 81;
					ptr2[1] = 67;
					ptr2[2] = 76;
					ptr2[3] = 90;
					buXS52VvhuD(3u, ptr11 + 1, 4u);
					buXS52VvhuD(P_3, ptr11 + 3, 4u);
					for (uint num3 = 0u; num3 < 4096; num3++)
					{
						ptr6[num3] = ptr3;
					}
					(ptr2 + (int)num)[4] = *ptr3;
					while (ptr5 < ptr12 - 2050u)
					{
						if ((num2 & 1) == 1)
						{
							if (ptr8 + 2050u + 128 > ptr2 + (int)P_3 + 2050u + 256)
							{
								gWcS5tIiASm(ptr2 + (int)num, ptr3, P_3);
								buXS52VvhuD(0u, ptr11 + 4, 4u);
								buXS52VvhuD(P_3 + num + 4, ptr11 + 2, 4u);
								iowS5aAAHb0(ptr2 + (int)DiuS5l5yDHn(ptr11 + 2, 4u) - 4, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(259398));
								return DiuS5l5yDHn(ptr11 + 2, 4u);
							}
							buXS52VvhuD((uint)((num2 >> 1) | int.MinValue), ptr7, 4u);
							ptr7 = ptr8;
							ptr8 += 4;
							num2 = 2147483648u;
							if (ptr8 - ptr9 > ptr5 - ptr10 && ptr5 + 4100u < ptr12)
							{
								for (; ptr5 < ptr10 + 2050u - 32; ptr5 += 31)
								{
									buXS52VvhuD(2147483648u, ptr8 - 4, 4u);
									dlqS5XUqVND(ptr8, ptr5, 31u);
									ptr8 += 35;
								}
								ptr10 = ptr5;
								ptr9 = ptr8;
								ptr7 = ptr8 - 4;
							}
						}
						uint num4;
						if (DiuS5l5yDHn(ptr5, 4u) == DiuS5l5yDHn(ptr5 + 1, 4u))
						{
							num4 = DiuS5l5yDHn(ptr5, 4u);
							byte* ptr13 = ptr5;
							for (ptr5 += 5; num4 == DiuS5l5yDHn(ptr5, 4u) && ptr5 < ptr13 + 2050u - 4; ptr5 += 4)
							{
							}
							buXS52VvhuD(((num4 & 0xFF) << 16) | (uint)(int)(ptr5 - ptr13 << 4) | 0xF, ptr8, 4u);
							ptr8 += 3;
							num2 = (num2 >> 1) | 0x80000000u;
							continue;
						}
						num4 = DiuS5l5yDHn(ptr5, 4u);
						uint num3 = ((num4 >> 12) ^ num4) & 0xFFF;
						byte* ptr14 = ptr6[num3];
						ptr6[num3] = ptr5;
						if ((!BitConverter.IsLittleEndian) ? (ptr5 - ptr14 <= 131071 && ptr5 - ptr14 > 3 && *ptr5 == *ptr14 && ptr5[1] == ptr14[1] && ptr5[2] == ptr14[2]) : (ptr5 - ptr14 <= 131071 && ptr5 - ptr14 > 3 && ((*(uint*)ptr14 ^ *(uint*)ptr5) & 0xFFFFFF) == 0))
						{
							uint num5 = (uint)(ptr5 - ptr14);
							if ((!BitConverter.IsLittleEndian) ? (ptr14[3] != ptr5[3]) : (*(uint*)ptr14 != *(uint*)ptr5))
							{
								if (num5 <= 63)
								{
									*ptr8 = (byte)(num5 << 2);
									ptr8++;
									num2 = (num2 >> 1) | 0x80000000u;
									ptr5 += 3;
								}
								else if (num5 <= 16383)
								{
									uint num6 = (num5 << 2) | 1;
									buXS52VvhuD(num6, ptr8, 2u);
									ptr8 += 2;
									num2 = (num2 >> 1) | 0x80000000u;
									ptr5 += 3;
								}
								else
								{
									*ptr8 = *ptr5;
									ptr8++;
									ptr5++;
									num2 >>= 1;
								}
								continue;
							}
							num2 = (num2 >> 1) | 0x80000000u;
							uint num7;
							for (num7 = 3u; ptr14[(int)num7] == ptr5[(int)num7] && num7 < 2050; num7++)
							{
							}
							ptr5 += (int)num7;
							if (num7 <= 18 && num5 <= 1023)
							{
								uint num8 = (num7 - 3 << 2) | (num5 << 6) | 2;
								buXS52VvhuD(num8, ptr8, 2u);
								ptr8 += 2;
							}
							else if (num7 <= 34 && num5 <= 65535)
							{
								uint num9 = (num7 - 3 << 3) | (num5 << 8) | 3;
								buXS52VvhuD(num9, ptr8, 3u);
								ptr8 += 3;
							}
							else if (num7 >= 3)
							{
								uint num10 = (num7 - 3 << 4) | (num5 << 15) | 7;
								buXS52VvhuD(num10, ptr8, 4u);
								ptr8 += 4;
							}
						}
						else
						{
							*ptr8 = *ptr5;
							ptr8++;
							ptr5++;
							num2 >>= 1;
						}
					}
					while (ptr5 <= ptr4)
					{
						if ((num2 & 1) == 1)
						{
							buXS52VvhuD((num2 >> 1) | 0x80000000u, ptr7, 4u);
							ptr7 = ptr8;
							ptr8 += 4;
							num2 = 2147483648u;
						}
						*ptr8 = *ptr5;
						ptr8++;
						ptr5++;
						num2 >>= 1;
					}
					while ((num2 & 1) != 1)
					{
						num2 >>= 1;
					}
					buXS52VvhuD((num2 >> 1) | 0x80000000u, ptr7, 4u);
					ptr8 += 4;
					buXS52VvhuD(1u, ptr11 + 4, 4u);
					buXS52VvhuD((uint)(ptr8 - ptr2 - 1 + 4), ptr11 + 2, 4u);
					iowS5aAAHb0(ptr2 + (int)DiuS5l5yDHn(ptr11 + 2, 4u) - 4, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(259398));
				}
			}
			return NAdS5e2roFV(P_2);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private unsafe static uint MSZS5LbhRnU(byte[] P_0, uint P_1, byte[] P_2)
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			fixed (byte* ptr = P_0)
			{
				fixed (byte* ptr2 = P_2)
				{
					byte* ptr3 = ptr + (int)P_1;
					uint num = 32u;
					byte* ptr4 = ptr3 + (int)num;
					byte* ptr5 = ptr2;
					uint* ptr6 = (uint*)ptr3;
					byte* ptr7 = ptr2 + (int)DiuS5l5yDHn(ptr6 + 3, 4u);
					uint num2 = 1u;
					uint[] array = new uint[16]
					{
						4u, 0u, 1u, 0u, 2u, 0u, 1u, 0u, 3u, 0u,
						1u, 0u, 2u, 0u, 1u, 0u
					};
					byte* ptr8 = ptr7 - 4;
					if (!rVeS5044ANF(ptr6, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(259398)))
					{
						return 0u;
					}
					if (DiuS5l5yDHn(ptr6 + 1, 4u) != 3)
					{
						return 0u;
					}
					if (!rVeS5044ANF(ptr3 + (int)DiuS5l5yDHn(ptr6 + 2, 4u) - 4, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(259398)))
					{
						return 0u;
					}
					if (DiuS5l5yDHn(ptr6 + 4, 4u) != 1)
					{
						gWcS5tIiASm(ptr2, ptr3 + (int)num, DiuS5l5yDHn(ptr6 + 3, 4u));
						return DiuS5l5yDHn(ptr6 + 3, 4u);
					}
					if (ptr5 >= ptr8)
					{
						ptr4 += 4;
						while (ptr5 < ptr7)
						{
							*ptr5 = *ptr4;
							ptr5++;
							ptr4++;
						}
						return (uint)(ptr5 - ptr2);
					}
					while (true)
					{
						if (num2 == 1)
						{
							num2 = DiuS5l5yDHn(ptr4, 4u);
							ptr4 += 4;
						}
						uint num3 = DiuS5l5yDHn(ptr4, 4u);
						if ((num2 & 1) == 1)
						{
							num2 >>= 1;
							if ((num3 & 3) == 0)
							{
								uint num4 = (num3 & 0xFF) >> 2;
								dlqS5XUqVND(ptr5, ptr5 - (int)num4, 3u);
								ptr5 += 3;
								ptr4++;
							}
							else if ((num3 & 2) == 0)
							{
								uint num4 = (num3 & 0xFFFF) >> 2;
								dlqS5XUqVND(ptr5, ptr5 - (int)num4, 3u);
								ptr5 += 3;
								ptr4 += 2;
							}
							else if ((num3 & 1) == 0)
							{
								uint num4 = (num3 & 0xFFFF) >> 6;
								uint num5 = ((num3 >> 2) & 0xF) + 3;
								dlqS5XUqVND(ptr5, ptr5 - (int)num4, num5);
								ptr5 += (int)num5;
								ptr4 += 2;
							}
							else if ((num3 & 4) == 0)
							{
								uint num4 = (num3 & 0xFFFFFF) >> 8;
								uint num5 = ((num3 >> 3) & 0x1F) + 3;
								dlqS5XUqVND(ptr5, ptr5 - (int)num4, num5);
								ptr5 += (int)num5;
								ptr4 += 3;
							}
							else if ((num3 & 8) == 0)
							{
								uint num4 = num3 >> 15;
								uint num5 = ((num3 >> 4) & 0x7FF) + 3;
								dlqS5XUqVND(ptr5, ptr5 - (int)num4, num5);
								ptr5 += (int)num5;
								ptr4 += 4;
							}
							else
							{
								byte b = (byte)(num3 >> 16);
								uint num5 = (num3 >> 4) & 0xFFF;
								mhGS5BSty8a(ptr5, b, num5);
								ptr5 += (int)num5;
								ptr4 += 3;
							}
						}
						else
						{
							dlqS5XUqVND(ptr5, ptr4, 4u);
							ptr5 += (int)array[num2 & 0xF];
							ptr4 += (int)array[num2 & 0xF];
							num2 >>= (int)(byte)array[num2 & 0xF];
							if (ptr5 >= ptr8)
							{
								break;
							}
						}
					}
					while (ptr5 < ptr7)
					{
						if (num2 == 1)
						{
							ptr4 += 4;
							num2 = 2147483648u;
						}
						*ptr5 = *ptr4;
						ptr5++;
						ptr4++;
						num2 >>= 1;
					}
					return (uint)(ptr5 - ptr2);
				}
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static byte[] CRbS5gvF9rx(string P_0)
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			byte[] array = null;
			FileStream fileStream = File.Open(P_0, FileMode.Open, FileAccess.Read, FileShare.Read);
			try
			{
				array = new byte[fileStream.Length];
				fileStream.Read(array, 0, array.Length);
				return array;
			}
			finally
			{
				fileStream.Close();
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static byte[] zehS5PdCTSF(string P_0)
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			byte[] array = CRbS5gvF9rx(P_0);
			return Uf8S5kdARLe(array);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static byte[] YjCS5RAWfBu(string P_0)
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			byte[] array = CRbS5gvF9rx(P_0);
			return FIWS5YAyLpb(array);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static byte[] Uf8S5kdARLe(byte[] P_0)
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return wn3S512jv21(P_0, 0u, Convert.ToUInt32(P_0.Length));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static byte[] FIWS5YAyLpb(byte[] P_0)
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return oNsS5Es3Xki(P_0, 0u);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object HEnS53Rv51R(byte[] P_0)
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return typeof(Assembly).GetMethod(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(259410), new Type[1] { typeof(byte[]) }).Invoke(null, new object[1] { P_0 });
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static byte[] wn3S512jv21(byte[] P_0, uint P_1, uint P_2)
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			byte[] array = new byte[P_2 + 36000];
			uint num = EhVS5Ug5eB5(P_0, P_1, array, P_2);
			byte[] array2 = new byte[num];
			for (uint num2 = 0u; num2 < num; num2++)
			{
				array2[num2] = array[num2];
			}
			return array2;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static byte[] oNsS5Es3Xki(byte[] P_0, uint P_1)
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			uint num = KoXS5MUlTPZ(P_0, P_1);
			byte[] array = null;
			if (num != 0)
			{
				array = new byte[num];
				MSZS5LbhRnU(P_0, P_1, array);
			}
			return array;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public EaavQkXf0krpBhnhsdS()
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		}
	}

	private static string[] HhyS5KDwgY8;

	private static object gG3S5hlWvLZ;

	private static bool NjbS5my4jGQ;

	private static bool B9DS5nLEXFy;

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void mmmS5icfu0g()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (NjbS5my4jGQ)
		{
			return;
		}
		if (TryLoadStoredPayload())
		{
			return;
		}
		byte[] array = new byte[0];
		byte[] array2 = null;
		int num = 286;
		if (1 == 0)
		{
			goto IL_001d;
		}
		goto IL_0341;
		IL_001d:
		array = array2 ?? new byte[0];
		int num2 = 278;
		goto IL_0345;
		IL_0341:
		num2 = num;
		goto IL_0345;
		IL_0345:
		int num18 = default(int);
		int num28 = default(int);
		int num4 = default(int);
		byte[] array3 = default(byte[]);
		byte[] array7 = default(byte[]);
		byte[] array4 = default(byte[]);
		int num3 = default(int);
		BinaryReader binaryReader;
		Stream bootstrapStream = ObfuscatorResourceCache.Open(ObfuscatorResourceCache.UxxdnResourceName);
		binaryReader = bootstrapStream != null ? new BinaryReader(bootstrapStream) : null;
		uint num17 = default(uint);
		uint num20 = default(uint);
		uint num21 = default(uint);
		byte[] array5 = default(byte[]);
		int num22 = default(int);
		byte[] array8 = default(byte[]);
		int num24 = default(int);
		uint num25 = default(uint);
		uint num33 = default(uint);
		int num29 = default(int);
		uint num26 = default(uint);
		int num30 = default(int);
		byte[] array6 = default(byte[]);
		uint num27 = default(uint);
		int num32 = default(int);
		int num31 = default(int);
		int num19 = default(int);
		int num23 = default(int);
		uint num7 = default(uint);
		while (true)
		{
			int num5;
			switch (num2)
			{
			case 224:
				break;
			case 335:
				num18 = 0;
				num2 = 289;
				continue;
			case 265:
			case 372:
				num28++;
				num2 = 66;
				continue;
			case 18:
			case 245:
				num4 = 87 + 49;
				num2 = 297;
				continue;
			case 272:
				array3[6] = (byte)num4;
				num = 269;
				if (!gBdPHkPmFjCL6Up8JC())
				{
					goto case 223;
				}
				goto IL_0341;
			case 223:
				array3[10] = (byte)num4;
				num = 74;
				if (false)
				{
					goto case 20;
				}
				goto IL_0341;
			case 20:
				array7 = array3;
				num5 = 200;
				goto IL_033d;
			case 1:
				array4[3] = (byte)num3;
				num = 175;
				if (1 == 0)
				{
					goto case 30;
				}
				goto IL_0341;
			case 30:
				num4 = 7 + 53;
				num2 = 152;
				continue;
			case 127:
				array4[1] = (byte)num3;
				num = 89;
				if (1 == 0)
				{
					goto case 174;
				}
				goto IL_0341;
			case 174:
				array4[11] = (byte)num3;
				num = 40;
				goto IL_0341;
			case 232:
				array4[14] = 140;
				num2 = 95;
				continue;
			case 164:
				array3[4] = 130;
				num5 = 185;
				goto IL_033d;
			case 311:
				num4 = 97 + 23;
				num = 276;
				goto IL_0341;
			case 19:
				array2 = (byte[])iT7sMbouZd6LXXuCxk(binaryReader, (int)nqvBH8Xo1HO3NVeQbN(XfLisNxjV7l205TyvQ(binaryReader)));
				num2 = 202;
				continue;
			case 327:
				array3[0] = 123;
				num = 56;
				goto IL_0341;
			case 292:
				array3[5] = 166;
				num = 4;
				if (false)
				{
					goto case 271;
				}
				goto IL_0341;
			case 271:
				num4 = 126 - 42;
				num = 141;
				goto IL_0341;
			case 315:
				num4 = 45 + 123;
				num = 156;
				goto IL_0341;
			case 256:
				num17 = 0u;
				num = 47;
				if (!gBdPHkPmFjCL6Up8JC())
				{
					goto case 212;
				}
				goto IL_0341;
			case 212:
				array4[8] = (byte)num3;
				num5 = 383;
				goto IL_033d;
			case 80:
				array4[3] = (byte)num3;
				num2 = 21;
				continue;
			case 118:
				array4[6] = 189;
				num5 = 187;
				goto IL_033d;
			case 86:
				num4 = 54 + 66;
				num = 31;
				if (1 == 0)
				{
					goto case 313;
				}
				goto IL_0341;
			case 313:
				num4 = 162 - 54;
				num2 = 386;
				continue;
			case 179:
				num20 += num21;
				num = 335;
				goto IL_0341;
			case 69:
				num4 = 85 + 108;
				num2 = 102;
				continue;
			case 320:
				array5 = new byte[array.Length];
				num = 159;
				goto IL_0341;
			case 6:
				array4[8] = 89;
				num = 42;
				if (fULtPsE9laIdUAd9DX())
				{
					goto case 41;
				}
				goto IL_0341;
			case 41:
				array3[27] = (byte)num4;
				goto case 147;
			default:
				num = 147;
				goto IL_0341;
			case 94:
				array4[10] = (byte)num3;
				num = 248;
				if (!fULtPsE9laIdUAd9DX())
				{
					goto IL_0341;
				}
				goto case 297;
			case 297:
				array3[1] = (byte)num4;
				num5 = 354;
				goto IL_033d;
			case 138:
				num4 = 16 + 21;
				num2 = 62;
				continue;
			case 148:
				array3[31] = 169;
				num2 = 20;
				continue;
			case 65:
				array3[26] = (byte)num4;
				num2 = 131;
				continue;
			case 57:
				array3[4] = 69;
				num = 292;
				goto IL_0341;
			case 105:
				array3[12] = (byte)num4;
				num2 = 351;
				continue;
			case 106:
				array3[23] = 102;
				num = 27;
				if (true)
				{
					goto IL_0341;
				}
				goto case 73;
			case 73:
				array4[6] = (byte)num3;
				num = 364;
				if (true)
				{
					goto IL_0341;
				}
				goto case 17;
			case 17:
			case 242:
				if (num22 >= array8.Length)
				{
					num = 224;
					if (!gBdPHkPmFjCL6Up8JC())
					{
						goto case 216;
					}
				}
				else
				{
					array7[num22] ^= array8[num22];
					num = 388;
					if (fULtPsE9laIdUAd9DX())
					{
						goto case 85;
					}
				}
				goto IL_0341;
			case 355:
				num4 = 121 - 48;
				num5 = 349;
				goto IL_033d;
			case 362:
				array4[5] = (byte)num3;
				num2 = 84;
				continue;
			case 284:
				num4 = 254 - 84;
				num = 275;
				if (gBdPHkPmFjCL6Up8JC())
				{
					goto IL_0341;
				}
				goto case 352;
			case 35:
				array5[num24 + 2] = (byte)((num25 & 0xFF0000) >> 16);
				num5 = 72;
				goto IL_033d;
			case 182:
				num4 = 209 - 69;
				num5 = 43;
				goto IL_033d;
			case 333:
				array3[1] = (byte)num4;
				fULtPsE9laIdUAd9DX();
				if (gBdPHkPmFjCL6Up8JC())
				{
					num = 245;
				}
				else
				{
					num = 211;
					if (!gBdPHkPmFjCL6Up8JC())
					{
						goto case 192;
					}
				}
				goto IL_0341;
			case 348:
				array3[31] = 128;
				num5 = 369;
				goto IL_033d;
			case 338:
				array3[0] = (byte)num4;
				num = 327;
				goto IL_0341;
			case 14:
				NjbS5my4jGQ = true;
				num2 = 392;
				continue;
			case 146:
				array3[3] = 142;
				num2 = 332;
				continue;
			case 99:
				array3[11] = 189;
				num2 = 323;
				continue;
			case 296:
				num3 = 19 + 36;
				num5 = 5;
				goto IL_033d;
			case 180:
				num4 = 65 + 96;
				num = 109;
				goto IL_0341;
			case 337:
				num33 = num20 ^ num17;
				num5 = 357;
				goto IL_033d;
			case 384:
				array4[10] = 146;
				num = 234;
				if (true)
				{
					goto IL_0341;
				}
				goto case 281;
			case 281:
				array3[25] = 209;
				num2 = 326;
				continue;
			case 43:
				array3[23] = (byte)num4;
				num2 = 106;
				continue;
			case 198:
				num29 = array.Length / 4;
				num5 = 320;
				goto IL_033d;
			case 222:
				num26 = (uint)(num30 * 4);
				num2 = 250;
				continue;
			case 101:
				array3[30] = 71;
				num = 52;
				if (gBdPHkPmFjCL6Up8JC())
				{
					goto IL_0341;
				}
				goto case 44;
			case 111:
				array3[27] = 86;
				num = 236;
				if (!fULtPsE9laIdUAd9DX())
				{
					goto IL_0341;
				}
				goto case 234;
			case 234:
				num3 = 53 + 115;
				num2 = 110;
				continue;
			case 351:
				array3[12] = 108;
				num2 = 302;
				continue;
			case 131:
				array3[26] = 156;
				num5 = 111;
				goto IL_033d;
			case 300:
				array3[0] = (byte)num4;
				num5 = 144;
				goto IL_033d;
			case 376:
				array4[13] = (byte)num3;
				num2 = 330;
				continue;
			case 213:
				array3[10] = (byte)num4;
				num2 = 341;
				continue;
			case 167:
				array4[1] = 145;
				num5 = 172;
				goto IL_033d;
			case 227:
				array3[18] = (byte)num4;
				num = 126;
				goto IL_0341;
			case 275:
				array3[22] = (byte)num4;
				num2 = 266;
				continue;
			case 382:
				num4 = 216 - 72;
				num = 26;
				if (true)
				{
					goto IL_0341;
				}
				goto case 121;
			case 121:
				num4 = 108 + 69;
				num2 = 288;
				continue;
			case 251:
				array4[12] = 148;
				num5 = 329;
				goto IL_033d;
			case 162:
				array3[5] = (byte)num4;
				num = 280;
				goto IL_0341;
			case 28:
				array3[31] = (byte)num4;
				num = 348;
				goto IL_0341;
			case 44:
				array3[5] = (byte)num4;
				num = 207;
				goto IL_0341;
			case 70:
				array4[7] = (byte)num3;
				num = 375;
				if (!fULtPsE9laIdUAd9DX())
				{
					goto IL_0341;
				}
				goto case 107;
			case 151:
				array3[25] = 160;
				num = 281;
				goto IL_0341;
			case 254:
				array4[15] = 238;
				num2 = 22;
				continue;
			case 389:
				num4 = 251 - 83;
				num5 = 205;
				goto IL_033d;
			case 98:
				array3[11] = (byte)num4;
				num = 99;
				goto IL_0341;
			case 119:
				array4[9] = (byte)num3;
				num2 = 157;
				continue;
			case 137:
				array4[7] = (byte)num3;
				num = 158;
				if (gBdPHkPmFjCL6Up8JC())
				{
					goto IL_0341;
				}
				goto case 307;
			case 54:
				num21 = 0u;
				num2 = 256;
				continue;
			case 124:
				num3 = 210 - 70;
				num = 11;
				if (true)
				{
					goto IL_0341;
				}
				goto case 37;
			case 37:
				num18++;
				num = 361;
				if (0 == 0)
				{
					goto IL_0341;
				}
				goto case 136;
			case 136:
				array3[20] = 146;
				num = 368;
				if (gBdPHkPmFjCL6Up8JC())
				{
					goto IL_0341;
				}
				goto case 92;
			case 92:
				gG3S5hlWvLZ = heRQMvMwcde814t6pG(rFAyDw0AyBY1DPYZZ6(array6));
				num2 = 299;
				continue;
			case 219:
				array4[14] = 142;
				num = 283;
				if (true)
				{
					goto IL_0341;
				}
				goto case 8;
			case 8:
				array3[13] = (byte)num4;
				num = 77;
				if (!fULtPsE9laIdUAd9DX())
				{
					goto IL_0341;
				}
				goto case 184;
			case 184:
				array3[4] = (byte)num4;
				num5 = 30;
				goto IL_033d;
			case 332:
				num4 = 150 + 71;
				num = 160;
				goto IL_0341;
			case 231:
				num4 = 165 - 107;
				num5 = 59;
				goto IL_033d;
			case 236:
				num4 = 140 - 46;
				num = 194;
				if (!fULtPsE9laIdUAd9DX())
				{
					goto IL_0341;
				}
				goto case 340;
			case 340:
				num4 = 158 - 52;
				num5 = 216;
				goto IL_033d;
			case 312:
				num29++;
				num2 = 178;
				continue;
			case 149:
				num3 = 118 + 108;
				num = 376;
				if (gBdPHkPmFjCL6Up8JC())
				{
					goto IL_0341;
				}
				goto case 301;
			case 301:
				array3[1] = 59;
				num = 34;
				goto IL_0341;
			case 141:
				array3[23] = (byte)num4;
				num5 = 182;
				goto IL_033d;
			case 88:
				num27 <<= 8;
				num = 199;
				if (!fULtPsE9laIdUAd9DX())
				{
					goto IL_0341;
				}
				goto case 304;
			case 304:
				array4[1] = (byte)num3;
				num5 = 45;
				goto IL_033d;
			case 357:
				num32 = 0;
				num2 = 68;
				continue;
			case 123:
				array3[18] = (byte)num4;
				num = 176;
				goto IL_0341;
			case 135:
				array4[11] = 179;
				num = 251;
				goto IL_0341;
			case 288:
				array3[25] = (byte)num4;
				num = 151;
				if (0 == 0)
				{
					goto IL_0341;
				}
				goto case 263;
			case 263:
				array3[7] = 130;
				num2 = 10;
				continue;
			case 142:
				num4 = 159 - 108;
				num2 = 325;
				continue;
			case 181:
				array4[4] = 140;
				num = 140;
				goto IL_0341;
			case 0:
				array3[10] = (byte)num4;
				num5 = 336;
				goto IL_033d;
			case 336:
				num4 = 41 + 115;
				num = 223;
				if (gBdPHkPmFjCL6Up8JC())
				{
					goto IL_0341;
				}
				goto case 370;
			case 370:
				num4 = 144 - 48;
				num2 = 44;
				continue;
			case 276:
				array3[29] = (byte)num4;
				num = 305;
				if (!fULtPsE9laIdUAd9DX())
				{
					goto IL_0341;
				}
				goto case 151;
			case 346:
				array4[9] = 126;
				num5 = 96;
				goto IL_033d;
			case 196:
				num4 = 140 - 42;
				num = 60;
				if (0 == 0)
				{
					goto IL_0341;
				}
				goto case 103;
			case 103:
				array3[30] = 101;
				num2 = 101;
				continue;
			case 144:
				num4 = 212 + 5;
				num = 298;
				if (gBdPHkPmFjCL6Up8JC())
				{
					goto IL_0341;
				}
				goto case 208;
			case 120:
				array4[4] = 164;
				num2 = 342;
				continue;
			case 147:
				num4 = 218 - 72;
				num2 = 25;
				continue;
			case 50:
				num28 = 0;
				num2 = 171;
				continue;
			case 11:
				array4[5] = (byte)num3;
				num = 215;
				if (0 == 0)
				{
					goto IL_0341;
				}
				goto case 67;
			case 67:
				num17 = 0u;
				num2 = 179;
				continue;
			case 154:
				array3[23] = (byte)num4;
				num5 = 358;
				goto IL_033d;
			case 274:
				num3 = 68 + 66;
				num = 24;
				goto IL_0341;
			case 258:
				num4 = 157 - 52;
				num5 = 75;
				goto IL_033d;
			case 385:
				array3[25] = 118;
				num2 = 201;
				continue;
			case 169:
				array3[8] = (byte)num4;
				num5 = 264;
				goto IL_033d;
			case 322:
				array3[17] = (byte)num4;
				num5 = 204;
				goto IL_033d;
			case 356:
				num4 = 5 + 80;
				num = 123;
				if (true)
				{
					goto IL_0341;
				}
				goto case 299;
			case 299:
				HhyS5KDwgY8 = (string[])SPxZHieGmikOhlJ2CI((Assembly)gG3S5hlWvLZ);
				num5 = 14;
				goto IL_033d;
			case 266:
				array3[22] = 162;
				num5 = 241;
				goto IL_033d;
			case 82:
				array6 = array5;
				num = 92;
				goto IL_0341;
			case 210:
				num4 = 118 + 47;
				num5 = 8;
				goto IL_033d;
			case 391:
				WdArUEHfxDVkKaXw6S(XfLisNxjV7l205TyvQ(binaryReader), 0L);
				num2 = 225;
				continue;
			case 359:
				binaryReader = new BinaryReader((Stream)mnslfOglR4uNIRLqd6(X5ovUUcqiqRww82f2M(typeof(Ne4dSgXrbYTX6VcmT1p).TypeHandle).Assembly, "UXXDn3cvaSJiMtEimR.14FmER7TIdULJkLVey"));
				num2 = 391;
				continue;
			case 157:
				num3 = 189 - 63;
				num2 = 94;
				continue;
			case 76:
				array3[19] = 80;
				num5 = 197;
				goto IL_033d;
			case 59:
				array3[16] = (byte)num4;
				num2 = 253;
				continue;
			case 145:
				array3[17] = 70;
				num = 389;
				if (!fULtPsE9laIdUAd9DX())
				{
					goto IL_0341;
				}
				goto case 24;
			case 24:
				array4[9] = (byte)num3;
				num = 346;
				goto IL_0341;
			case 114:
				goto IL_15ad;
			case 22:
				array8 = array4;
				num = 166;
				goto IL_0341;
			case 358:
				array3[24] = 127;
				num5 = 381;
				goto IL_033d;
			case 369:
				num4 = 59 + 20;
				num = 163;
				if (true)
				{
					goto IL_0341;
				}
				goto case 112;
			case 112:
				array3[15] = 186;
				num2 = 307;
				continue;
			case 216:
				array3[8] = (byte)num4;
				num = 261;
				if (0 == 0)
				{
					goto IL_0341;
				}
				goto case 84;
			case 84:
				array4[5] = 104;
				num2 = 124;
				continue;
			case 270:
				array3[2] = 141;
				num5 = 339;
				goto IL_033d;
			case 318:
				array3[10] = (byte)num4;
				num = 38;
				goto IL_0341;
			case 96:
				num3 = 79 - 24;
				num2 = 119;
				continue;
			case 244:
				array3[14] = 144;
				num = 138;
				goto IL_0341;
			case 159:
				num31 = array7.Length / 4;
				num5 = 373;
				goto IL_033d;
			case 375:
				array4[7] = 127;
				num = 239;
				if (gBdPHkPmFjCL6Up8JC())
				{
					goto IL_0341;
				}
				goto case 218;
			case 27:
				array3[23] = 177;
				num5 = 206;
				goto IL_033d;
			case 77:
				num4 = 49 + 42;
				num = 170;
				goto IL_0341;
			case 334:
				array4[8] = (byte)num3;
				num5 = 91;
				goto IL_033d;
			case 187:
				num3 = 87 + 39;
				num5 = 70;
				goto IL_033d;
			case 47:
				if (num19 > 0)
				{
					num2 = 312;
					continue;
				}
				goto case 178;
			case 133:
				num4 = 225 - 117;
				num = 272;
				if (gBdPHkPmFjCL6Up8JC())
				{
					goto IL_0341;
				}
				goto case 376;
			case 116:
				num3 = 251 - 83;
				num5 = 352;
				goto IL_033d;
			case 150:
				num17 |= array[array.Length - (1 + num18)];
				num2 = 37;
				continue;
			case 386:
				array3[9] = (byte)num4;
				num = 195;
				goto IL_0341;
			case 58:
				array4[13] = 134;
				num2 = 233;
				continue;
			case 374:
				num4 = 44 + 97;
				num = 227;
				if (0 == 0)
				{
					goto IL_0341;
				}
				goto case 303;
			case 303:
				array4[1] = (byte)num3;
				num5 = 291;
				goto IL_033d;
			case 55:
				num3 = 3 + 33;
				num = 362;
				if (0 == 0)
				{
					goto IL_0341;
				}
				goto case 298;
			case 298:
				array3[0] = (byte)num4;
				num2 = 214;
				continue;
			case 26:
				array3[21] = (byte)num4;
				num5 = 12;
				goto IL_033d;
			case 29:
				num4 = 149 - 49;
				num5 = 105;
				goto IL_033d;
			case 379:
				num3 = 105 + 118;
				num5 = 81;
				goto IL_033d;
			case 132:
				array3[30] = (byte)num4;
				num5 = 238;
				goto IL_033d;
			case 13:
				goto IL_191e;
			case 218:
				array4[0] = (byte)num3;
				num2 = 378;
				continue;
			case 12:
				array3[21] = 107;
				num2 = 282;
				continue;
			case 201:
				array3[26] = 162;
				num = 321;
				if (fULtPsE9laIdUAd9DX())
				{
					goto case 256;
				}
				goto IL_0341;
			case 31:
				array3[29] = (byte)num4;
				num = 311;
				if (!fULtPsE9laIdUAd9DX())
				{
					goto IL_0341;
				}
				goto case 46;
			case 205:
				array3[17] = (byte)num4;
				num5 = 180;
				goto IL_033d;
			case 279:
				num4 = 79 + 4;
				num2 = 333;
				continue;
			case 161:
				if (num28 == num29 - 1)
				{
					num5 = 122;
					goto IL_033d;
				}
				goto IL_0981;
			case 325:
				array3[20] = (byte)num4;
				num = 267;
				goto IL_0341;
			case 293:
				num24 = num28 * 4;
				num = 222;
				if (true)
				{
					goto IL_0341;
				}
				goto case 339;
			case 339:
				array3[2] = 201;
				num = 48;
				if (0 == 0)
				{
					goto IL_0341;
				}
				goto case 247;
			case 247:
				num4 = 125 + 116;
				num = 7;
				if (gBdPHkPmFjCL6Up8JC())
				{
					goto IL_0341;
				}
				goto case 67;
			case 366:
				num3 = 125 - 41;
				num5 = 218;
				goto IL_033d;
			case 250:
				num21 = (uint)((array7[num26 + 3] << 24) | (array7[num26 + 2] << 16) | (array7[num26 + 1] << 8) | array7[num26]);
				num2 = 257;
				continue;
			case 62:
				array3[14] = (byte)num4;
				num = 252;
				if (0 == 0)
				{
					goto IL_0341;
				}
				goto case 373;
			case 373:
				num20 = 0u;
				num = 54;
				if (0 == 0)
				{
					goto IL_0341;
				}
				goto case 102;
			case 102:
				array3[18] = (byte)num4;
				num = 356;
				goto IL_0341;
			case 39:
				array3[11] = (byte)num4;
				num = 287;
				goto IL_0341;
			case 199:
				num23 += 8;
				num2 = 328;
				continue;
			case 230:
				num4 = 251 - 83;
				num = 98;
				goto IL_0341;
			case 226:
				array3[2] = 173;
				num5 = 270;
				goto IL_033d;
			case 203:
				num32++;
				num2 = 3;
				continue;
			case 36:
				array3[13] = 152;
				num5 = 377;
				goto IL_033d;
			case 278:
				num19 = array.Length % 4;
				num = 198;
				if (gBdPHkPmFjCL6Up8JC())
				{
					goto IL_0341;
				}
				goto case 138;
			case 200:
				array4 = new byte[16];
				num2 = 366;
				continue;
			case 53:
				num4 = 62 + 118;
				num2 = 371;
				continue;
			case 267:
				array3[21] = 124;
				num2 = 191;
				continue;
			case 16:
				array3[5] = (byte)num4;
				num = 370;
				if (0 == 0)
				{
					goto IL_0341;
				}
				goto case 309;
			case 309:
				num4 = 56 + 84;
				num = 314;
				if (!fULtPsE9laIdUAd9DX())
				{
					goto IL_0341;
				}
				goto case 166;
			case 166:
				num22 = 0;
				num = 17;
				goto IL_0341;
			case 128:
				num4 = 192 - 64;
				num = 85;
				if (gBdPHkPmFjCL6Up8JC())
				{
					goto IL_0341;
				}
				goto case 7;
			case 60:
				array3[22] = (byte)num4;
				num2 = 271;
				continue;
			case 33:
				num4 = 112 - 107;
				num = 220;
				goto IL_0341;
			case 197:
				array3[20] = 138;
				num = 136;
				if (!fULtPsE9laIdUAd9DX())
				{
					goto IL_0341;
				}
				goto case 246;
			case 246:
				num4 = 78 + 11;
				num = 41;
				if (true)
				{
					goto IL_0341;
				}
				goto case 183;
			case 183:
				array4[6] = (byte)num3;
				num = 64;
				if (true)
				{
					goto IL_0341;
				}
				goto case 383;
			case 383:
				num3 = 58 + 39;
				num5 = 334;
				goto IL_033d;
			case 107:
				array3[19] = (byte)num4;
				num5 = 76;
				goto IL_033d;
			case 368:
				num4 = 82 + 91;
				num5 = 360;
				goto IL_033d;
			case 248:
				array4[10] = 170;
				num = 384;
				if (true)
				{
					goto IL_0341;
				}
				goto case 9;
			case 9:
				array4[12] = (byte)num3;
				num = 58;
				goto IL_0341;
			case 282:
				array3[22] = 156;
				num = 284;
				goto IL_0341;
			case 239:
				array4[7] = 114;
				num2 = 63;
				continue;
			case 125:
				num3 = 220 - 73;
				num2 = 262;
				continue;
			case 85:
				array3[13] = (byte)num4;
				num2 = 210;
				continue;
			case 360:
				array3[20] = (byte)num4;
				num2 = 142;
				continue;
			case 310:
				array3[22] = 18;
				num = 196;
				goto IL_0341;
			case 378:
				array4[0] = 141;
				num5 = 296;
				goto IL_033d;
			case 286:
				if (!NjbS5my4jGQ)
				{
					num = 359;
					goto IL_0341;
				}
				return;
			case 225:
				array6 = new byte[0];
				num5 = 19;
				goto IL_033d;
			case 3:
			case 68:
				if (num32 >= num19)
				{
					num5 = 372;
					goto IL_033d;
				}
				if (num32 > 0)
				{
					num = 88;
					goto IL_0341;
				}
				goto case 328;
			case 354:
				num4 = 223 - 74;
				num2 = 188;
				continue;
			case 66:
			case 171:
				if (num28 >= num29)
				{
					num = 82;
					if (gBdPHkPmFjCL6Up8JC())
					{
						goto IL_0341;
					}
					goto case 128;
				}
				num30 = num28 % num31;
				num2 = 293;
				continue;
			case 71:
				array3[4] = 163;
				num5 = 57;
				goto IL_033d;
			case 269:
				num4 = 136 - 45;
				num2 = 90;
				continue;
			case 168:
				array3[30] = (byte)num4;
				num2 = 129;
				continue;
			case 365:
				array4[2] = (byte)num3;
				num2 = 240;
				continue;
			case 134:
				num3 = 227 - 117;
				num = 363;
				goto IL_0341;
			case 243:
				array4[11] = 122;
				num = 165;
				goto IL_0341;
			case 64:
				num3 = 112 + 60;
				num5 = 73;
				goto IL_033d;
			case 260:
				array4[1] = 92;
				num = 115;
				if (0 == 0)
				{
					goto IL_0341;
				}
				goto case 51;
			case 51:
				array3[9] = (byte)num4;
				num = 33;
				goto IL_0341;
			case 165:
				num3 = 101 + 76;
				num = 387;
				goto IL_0341;
			case 352:
				array4[2] = (byte)num3;
				num = 380;
				if (!fULtPsE9laIdUAd9DX())
				{
					goto IL_0341;
				}
				goto case 219;
			case 89:
				array4[1] = 80;
				num = 260;
				if (true)
				{
					goto IL_0341;
				}
				goto case 176;
			case 176:
				num4 = 206 - 68;
				num = 367;
				if (!fULtPsE9laIdUAd9DX())
				{
					goto IL_0341;
				}
				goto case 235;
			case 235:
				array3[28] = 66;
				num = 86;
				goto IL_0341;
			case 241:
				num4 = 99 + 105;
				num2 = 192;
				continue;
			case 139:
				num20 = 255u;
				num = 100;
				if (!fULtPsE9laIdUAd9DX())
				{
					goto IL_0341;
				}
				goto case 280;
			case 280:
				array3[5] = 35;
				num2 = 87;
				continue;
			case 229:
				array4[15] = 160;
				num2 = 125;
				continue;
			case 326:
				array3[25] = 217;
				num2 = 385;
				continue;
			case 72:
				array5[num24 + 3] = (byte)((num25 & 0xFF000000u) >> 24);
				num = 265;
				if (true)
				{
					goto IL_0341;
				}
				goto case 257;
			case 257:
				num27 = 255u;
				num2 = 186;
				continue;
			case 15:
				num17 = (uint)((array[num26 + 3] << 24) | (array[num26 + 2] << 16) | (array[num26 + 1] << 8) | array[num26]);
				num = 277;
				goto IL_0341;
			case 126:
				array3[18] = 56;
				num = 193;
				if (true)
				{
					goto IL_0341;
				}
				goto case 240;
			case 240:
				array4[2] = 138;
				num5 = 116;
				goto IL_033d;
			case 21:
				num3 = 116 + 39;
				num5 = 1;
				goto IL_033d;
			case 160:
				array3[3] = (byte)num4;
				num = 228;
				goto IL_0341;
			case 188:
				array3[1] = (byte)num4;
				num5 = 301;
				goto IL_033d;
			case 253:
				num4 = 115 + 117;
				num = 322;
				if (!fULtPsE9laIdUAd9DX())
				{
					goto IL_0341;
				}
				goto case 221;
			case 221:
				array3[24] = (byte)num4;
				num5 = 121;
				goto IL_033d;
			case 56:
				num4 = 43 + 57;
				num = 300;
				if (gBdPHkPmFjCL6Up8JC())
				{
					goto IL_0341;
				}
				goto case 276;
			case 155:
				array4[8] = 134;
				num2 = 6;
				continue;
			case 342:
				array4[5] = 177;
				num5 = 379;
				goto IL_033d;
			case 321:
				num4 = 13 + 58;
				num = 65;
				goto IL_0341;
			case 330:
				array4[14] = 84;
				num5 = 113;
				goto IL_033d;
			case 294:
				array4[11] = 88;
				num2 = 46;
				continue;
			case 122:
				if (num19 > 0)
				{
					num = 337;
					goto IL_0341;
				}
				goto IL_0981;
			case 192:
				array3[22] = (byte)num4;
				num = 310;
				if (0 == 0)
				{
					goto IL_0341;
				}
				goto case 268;
			case 268:
				array3[28] = 224;
				num = 235;
				if (true)
				{
					goto IL_0341;
				}
				goto case 307;
			case 307:
				array3[16] = 131;
				num = 97;
				goto IL_0341;
			case 209:
				array3[14] = (byte)num4;
				num = 390;
				if (!fULtPsE9laIdUAd9DX())
				{
					goto IL_0341;
				}
				goto case 336;
			case 38:
				num4 = 122 + 51;
				num = 213;
				if (gBdPHkPmFjCL6Up8JC())
				{
					goto IL_0341;
				}
				goto case 233;
			case 233:
				array4[13] = 119;
				num = 149;
				goto IL_0341;
			case 249:
				array4[9] = 122;
				num5 = 274;
				goto IL_033d;
			case 34:
				array3[2] = 90;
				num5 = 226;
				goto IL_033d;
			case 115:
				num3 = 134 + 33;
				num = 303;
				if (true)
				{
					goto IL_0341;
				}
				goto case 215;
			case 215:
				array4[5] = 150;
				num = 32;
				if (!fULtPsE9laIdUAd9DX())
				{
					goto IL_0341;
				}
				goto case 170;
			case 170:
				array3[14] = (byte)num4;
				num5 = 244;
				goto IL_033d;
			case 173:
				num4 = 154 - 37;
				goto case 61;
			case 364:
				array4[6] = 91;
				num2 = 118;
				continue;
			case 140:
				array4[4] = 166;
				num2 = 120;
				continue;
			case 328:
				array5[num24 + num32] = (byte)((num33 & num27) >> num23);
				num = 203;
				goto IL_0341;
			case 191:
				array3[21] = 86;
				num = 347;
				if (gBdPHkPmFjCL6Up8JC())
				{
					goto IL_0341;
				}
				goto case 123;
			case 324:
				array3[6] = 95;
				num = 53;
				goto IL_0341;
			case 93:
				array5[num24] = (byte)(num25 & 0xFF);
				num = 143;
				goto IL_0341;
			case 261:
				array3[8] = 45;
				num5 = 313;
				goto IL_033d;
			case 5:
				array4[0] = (byte)num3;
				num = 134;
				if (gBdPHkPmFjCL6Up8JC())
				{
					goto IL_0341;
				}
				goto case 349;
			case 349:
				array3[14] = (byte)num4;
				num2 = 117;
				continue;
			case 130:
				array4[2] = (byte)num3;
				num5 = 316;
				goto IL_033d;
			case 343:
				array3[16] = (byte)num4;
				num = 190;
				if (!fULtPsE9laIdUAd9DX())
				{
					goto IL_0341;
				}
				goto case 10;
			case 10:
				num4 = 2 + 64;
				num5 = 177;
				goto IL_033d;
			case 317:
				array4[14] = (byte)num3;
				num = 219;
				if (0 == 0)
				{
					goto IL_0341;
				}
				goto case 110;
			case 110:
				array4[10] = (byte)num3;
				num2 = 243;
				continue;
			case 252:
				num4 = 121 + 107;
				num5 = 209;
				goto IL_033d;
			case 143:
				array5[num24 + 1] = (byte)((num25 & 0xFF00) >> 8);
				num2 = 35;
				continue;
			case 178:
				num26 = 0u;
				num = 50;
				if (0 == 0)
				{
					goto IL_0341;
				}
				goto case 25;
			case 25:
				array3[27] = (byte)num4;
				num = 108;
				if (gBdPHkPmFjCL6Up8JC())
				{
					goto IL_0341;
				}
				goto case 323;
			case 323:
				array3[11] = 91;
				num5 = 315;
				goto IL_033d;
			case 189:
				num3 = 113 + 40;
				num2 = 9;
				continue;
			case 371:
				array3[6] = (byte)num4;
				num5 = 133;
				goto IL_033d;
			case 45:
				num3 = 219 - 73;
				num5 = 127;
				goto IL_033d;
			case 204:
				array3[17] = 158;
				num5 = 145;
				goto IL_033d;
			case 381:
				array3[24] = 135;
				num2 = 83;
				continue;
			case 277:
			case 308:
				num7 = num20;
				num2 = 139;
				continue;
			case 331:
				array4[14] = (byte)num3;
				num = 232;
				if (true)
				{
					goto IL_0341;
				}
				goto case 61;
			case 61:
			case 211:
				array3[7] = (byte)num4;
				num = 345;
				goto IL_0341;
			case 262:
				array4[15] = (byte)num3;
				num = 254;
				goto IL_0341;
			case 287:
				array3[11] = 151;
				num5 = 230;
				goto IL_033d;
			case 186:
				num23 = 0;
				num = 114;
				if (gBdPHkPmFjCL6Up8JC())
				{
					goto IL_0341;
				}
				goto case 196;
			case 238:
				num4 = 217 + 16;
				num2 = 168;
				continue;
			case 295:
				num4 = 112 + 99;
				num2 = 107;
				continue;
			case 329:
				array4[12] = 172;
				num5 = 189;
				goto IL_033d;
			case 7:
				array3[12] = (byte)num4;
				num5 = 36;
				goto IL_033d;
			case 108:
				array3[27] = 2;
				num = 78;
				if (0 == 0)
				{
					goto IL_0341;
				}
				goto case 353;
			case 353:
				num4 = 155 - 51;
				num5 = 16;
				goto IL_033d;
			case 23:
				array3[4] = (byte)num4;
				num5 = 164;
				goto IL_033d;
			case 97:
				num4 = 169 - 56;
				num5 = 343;
				goto IL_033d;
			case 113:
				num3 = 217 - 72;
				num2 = 317;
				continue;
			case 81:
				array4[5] = (byte)num3;
				num = 55;
				goto IL_0341;
			case 347:
				array3[21] = 143;
				num = 382;
				if (!fULtPsE9laIdUAd9DX())
				{
					goto IL_0341;
				}
				goto case 198;
			case 220:
				array3[9] = (byte)num4;
				num2 = 153;
				continue;
			case 40:
				array4[11] = 48;
				num2 = 135;
				continue;
			case 283:
				array4[14] = 167;
				num2 = 49;
				continue;
			case 75:
				array3[0] = (byte)num4;
				num2 = 290;
				continue;
			case 217:
				num20 = num7;
				num = 161;
				goto IL_0341;
			case 207:
				num4 = 150 - 50;
				num = 162;
				if (gBdPHkPmFjCL6Up8JC())
				{
					goto IL_0341;
				}
				goto case 388;
			case 388:
				num22++;
				num5 = 242;
				goto IL_033d;
			case 52:
				num4 = 156 - 52;
				num5 = 132;
				goto IL_033d;
			case 177:
				array3[7] = (byte)num4;
				num5 = 173;
				goto IL_033d;
			case 90:
				array3[7] = (byte)num4;
				num = 263;
				goto IL_0341;
			case 350:
				num3 = 72 - 7;
				num5 = 137;
				goto IL_033d;
			case 42:
				array4[9] = 125;
				num2 = 249;
				continue;
			case 190:
				num4 = 77 + 105;
				num = 237;
				if (!fULtPsE9laIdUAd9DX())
				{
					goto IL_0341;
				}
				goto case 246;
			case 49:
				num3 = 247 - 82;
				num2 = 331;
				continue;
			case 345:
				num4 = 87 + 67;
				num = 169;
				if (0 == 0)
				{
					goto IL_0341;
				}
				goto case 259;
			case 259:
				num20 += num21;
				num = 15;
				goto IL_0341;
			case 83:
				num4 = 117 + 113;
				num2 = 221;
				continue;
			case 255:
				array4[7] = (byte)num3;
				num5 = 344;
				goto IL_033d;
			case 289:
			case 361:
				if (num18 < num19)
				{
					if (num18 <= 0)
					{
						goto case 150;
					}
					num5 = 2;
				}
				else
				{
					num5 = 308;
				}
				goto IL_033d;
			case 285:
				array4[3] = (byte)num3;
				num2 = 181;
				continue;
			case 363:
				array4[0] = (byte)num3;
				num2 = 167;
				continue;
			case 158:
				num3 = 173 - 57;
				num5 = 212;
				goto IL_033d;
			case 302:
				array3[12] = 147;
				num2 = 247;
				continue;
			case 228:
				num4 = 117 + 116;
				num = 23;
				if (0 == 0)
				{
					goto IL_0341;
				}
				goto case 3;
			case 2:
				num17 <<= 8;
				num = 150;
				if (gBdPHkPmFjCL6Up8JC())
				{
					goto IL_0341;
				}
				goto case 189;
			case 163:
				array3[31] = (byte)num4;
				num2 = 148;
				continue;
			case 264:
				num4 = 177 - 59;
				num2 = 104;
				continue;
			case 344:
				array4[7] = 132;
				num = 350;
				goto IL_0341;
			case 208:
				array3[8] = 134;
				num = 340;
				if (true)
				{
					goto IL_0341;
				}
				goto case 46;
			case 46:
				num3 = 234 - 78;
				num2 = 174;
				continue;
			case 306:
				array3[15] = 97;
				num5 = 112;
				goto IL_033d;
			case 91:
				array4[8] = 146;
				num5 = 155;
				goto IL_033d;
			case 316:
				num3 = 16 + 114;
				num = 80;
				if (!fULtPsE9laIdUAd9DX())
				{
					goto IL_0341;
				}
				goto case 366;
			case 390:
				array3[14] = 98;
				num5 = 355;
				goto IL_033d;
			case 87:
				array3[6] = 136;
				num2 = 324;
				continue;
			case 63:
				num3 = 22 + 26;
				num = 255;
				if (0 == 0)
				{
					goto IL_0341;
				}
				goto case 319;
			case 319:
				array3[18] = 184;
				num2 = 374;
				continue;
			case 380:
				num3 = 239 - 119;
				num = 130;
				if (0 == 0)
				{
					goto IL_0341;
				}
				goto case 214;
			case 214:
				array3[1] = 137;
				num = 279;
				if (0 == 0)
				{
					goto IL_0341;
				}
				goto case 104;
			case 104:
				array3[8] = (byte)num4;
				num2 = 208;
				continue;
			case 290:
				num4 = 116 + 104;
				num5 = 338;
				goto IL_033d;
			case 202:
				array3 = new byte[32];
				num2 = 258;
				continue;
			case 156:
				array3[11] = (byte)num4;
				num = 29;
				goto IL_0341;
			case 100:
			{
				uint num6 = num7;
				uint num8 = num7;
				uint num9 = 2114504228u;
				uint num10 = 1887517160u;
				uint num11 = 1581138661u;
				uint num12 = 2104350670u;
				uint num13 = num8;
				uint num14 = 120358113u;
				num12 = 627 * (num12 & 0x7FFFF) - (num12 >> 19);
				num10 = 5938 * (num10 & 0x7FFFF) + (num10 >> 19);
				num9 = 34501 * num9 + num11;
				num11 = (num12 - num12) ^ 0x2ABC1C77;
				if ((double)num9 == 0.0)
				{
					num9--;
				}
				uint num15 = (uint)(22905.0 / (double)num9 + (double)num9);
				if (num15 == 0)
				{
					num15--;
				}
				num9 = 3880793791u / num15 + 268849241;
				if ((double)num12 == 0.0)
				{
					num12--;
				}
				uint num16 = (uint)(1614496742.0 / (double)num12 + (double)num12);
				num12 = (uint)((double)(128025 + num16) + 2116642502.0);
				num14 = (1521545187 - num10) ^ 0x158B01E9;
				num13 ^= num13 >> 13;
				num13 += num9;
				num13 ^= num13 << 5;
				num13 += num12;
				num13 ^= num13 >> 19;
				num13 += num14;
				num13 = (((num10 << 17) + num11) ^ num12) - num13;
				num7 = num6 + (uint)(double)num13;
				num = 217;
				if (true)
				{
					goto IL_0341;
				}
				goto case 117;
			}
			case 117:
				array3[15] = 119;
				num = 306;
				if (!fULtPsE9laIdUAd9DX())
				{
					goto IL_0341;
				}
				goto case 270;
			case 195:
				num4 = 102 + 14;
				num = 51;
				if (true)
				{
					goto IL_0341;
				}
				goto case 185;
			case 185:
				num4 = 119 + 103;
				num = 184;
				goto IL_0341;
			case 194:
				array3[27] = (byte)num4;
				num2 = 79;
				continue;
			case 305:
				array3[29] = 189;
				num2 = 103;
				continue;
			case 95:
				array4[15] = 94;
				num2 = 229;
				continue;
			case 153:
				num4 = 219 - 73;
				num2 = 318;
				continue;
			case 78:
				array3[28] = 146;
				num = 309;
				goto IL_0341;
			case 109:
				array3[17] = (byte)num4;
				num = 69;
				goto IL_0341;
			case 79:
				array3[27] = 120;
				num = 246;
				if (!fULtPsE9laIdUAd9DX())
				{
					goto IL_0341;
				}
				goto case 255;
			case 172:
				num3 = 171 - 57;
				num2 = 304;
				continue;
			case 193:
				array3[19] = 105;
				num = 295;
				if (true)
				{
					goto IL_0341;
				}
				goto case 152;
			case 152:
				array3[4] = (byte)num4;
				num = 71;
				goto IL_0341;
			case 367:
				array3[18] = (byte)num4;
				num2 = 319;
				continue;
			case 387:
				array4[11] = (byte)num3;
				num = 294;
				if (!fULtPsE9laIdUAd9DX())
				{
					goto IL_0341;
				}
				goto case 175;
			case 175:
				num3 = 93 - 28;
				num2 = 285;
				continue;
			case 237:
				array3[16] = (byte)num4;
				num5 = 231;
				goto IL_033d;
			case 74:
				num4 = 131 - 43;
				num5 = 39;
				goto IL_033d;
			case 273:
				array3[28] = 164;
				num2 = 268;
				continue;
			case 4:
				array3[5] = 156;
				num5 = 353;
				goto IL_033d;
			case 48:
				array3[3] = 114;
				num = 146;
				if (gBdPHkPmFjCL6Up8JC())
				{
					goto IL_0341;
				}
				goto case 70;
			case 314:
				array3[28] = (byte)num4;
				num = 273;
				goto IL_0341;
			case 377:
				array3[13] = 96;
				num = 128;
				goto IL_0341;
			case 129:
				num4 = 179 - 59;
				num2 = 28;
				continue;
			case 341:
				num4 = 146 - 48;
				num2 = 0;
				continue;
			case 206:
				num4 = 157 - 56;
				num = 154;
				goto IL_0341;
			case 291:
				num3 = 30 + 0;
				num = 365;
				goto IL_0341;
			case 32:
				num3 = 29 + 18;
				num2 = 183;
				continue;
			case 392:
				return;
				IL_0981:
				num25 = num20 ^ num17;
				num = 93;
				goto IL_0341;
				IL_033d:
				num = num5;
				goto IL_0341;
			}
			break;
			IL_191e:
			if (num19 > 0)
			{
				num2 = 67;
				continue;
			}
			goto IL_183e;
			IL_183e:
			num26 = (uint)num24;
			num = 259;
			goto IL_0341;
			IL_15ad:
			if (num28 == num29 - 1)
			{
				num2 = 13;
				continue;
			}
			goto IL_183e;
		}
		goto IL_001d;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static string[] F5YS5sHsi0L(Assembly P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0 == typeof(yfs8Q5XRDNZPbwaTSae).Assembly)
		{
			if (!NjbS5my4jGQ)
			{
				mmmS5icfu0g();
			}
			List<string> list = new List<string>();
			list.AddRange(P_0.GetManifestResourceNames());
			list.AddRange(((Assembly)gG3S5hlWvLZ).GetManifestResourceNames());
			return list.ToArray();
		}
		return P_0.GetManifestResourceNames();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Assembly olRS5qpZ4RF(object P_0, ResolveEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!NjbS5my4jGQ)
		{
			mmmS5icfu0g();
		}
		string name = P_1.Name;
		for (int i = 0; i < HhyS5KDwgY8.Length; i++)
		{
			if (HhyS5KDwgY8[i] == name)
			{
				return (Assembly)gG3S5hlWvLZ;
			}
		}
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public yfs8Q5XRDNZPbwaTSae()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		AppDomain.CurrentDomain.ResourceResolve += olRS5qpZ4RF;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void kLjw4iIsCLsZtxc4lksN0j()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!B9DS5nLEXFy)
		{
			B9DS5nLEXFy = true;
			ObfuscatorResourceCache.EnsureLoaded();
			new yfs8Q5XRDNZPbwaTSae();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static yfs8Q5XRDNZPbwaTSae()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		HhyS5KDwgY8 = new string[0];
		gG3S5hlWvLZ = null;
		NjbS5my4jGQ = false;
		B9DS5nLEXFy = false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Type X5ovUUcqiqRww82f2M(RuntimeTypeHandle P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return Type.GetTypeFromHandle(P_0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object mnslfOglR4uNIRLqd6(object P_0, object P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string resourceName = (string)P_1;
		Stream cached = ObfuscatorResourceCache.Open(resourceName);
		if (cached != null)
		{
			return cached;
		}

		return ((Assembly)P_0).GetManifestResourceStream(resourceName);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object XfLisNxjV7l205TyvQ(object P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return ((BinaryReader)P_0).BaseStream;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void WdArUEHfxDVkKaXw6S(object P_0, long P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		((Stream)P_0).Position = P_1;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static long nqvBH8Xo1HO3NVeQbN(object P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return ((Stream)P_0).Length;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object iT7sMbouZd6LXXuCxk(object P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return ((BinaryReader)P_0).ReadBytes(P_1);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object rFAyDw0AyBY1DPYZZ6(object P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return EaavQkXf0krpBhnhsdS.FIWS5YAyLpb((byte[])P_0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object heRQMvMwcde814t6pG(object P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return EaavQkXf0krpBhnhsdS.HEnS53Rv51R((byte[])P_0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object SPxZHieGmikOhlJ2CI(object P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return ((Assembly)P_0).GetManifestResourceNames();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool gBdPHkPmFjCL6Up8JC()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool fULtPsE9laIdUAd9DX()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool TryLoadStoredPayload()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		try
		{
			string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "obfuscator_payload.dll");
			if (!File.Exists(path))
			{
				return false;
			}
			byte[] assemblyBytes = File.ReadAllBytes(path);
			Assembly loaded = Assembly.Load(assemblyBytes);
			gG3S5hlWvLZ = loaded;
			List<string> list = new List<string>();
			list.AddRange(typeof(yfs8Q5XRDNZPbwaTSae).Assembly.GetManifestResourceNames());
			list.AddRange(loaded.GetManifestResourceNames());
			HhyS5KDwgY8 = list.ToArray();
			NjbS5my4jGQ = true;
			return true;
		}
		catch
		{
			return false;
		}
	}
}
