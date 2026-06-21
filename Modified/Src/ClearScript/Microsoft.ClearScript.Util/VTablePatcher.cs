using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Microsoft.ClearScript.Util;

internal abstract class VTablePatcher
{
	private sealed class VTablePatcher32 : VTablePatcher
	{
		public static readonly VTablePatcher Instance = new VTablePatcher32();

		private VTablePatcher32()
		{
		}

		public override void PatchDispatchEx(IntPtr pDispatchEx)
		{
			ApplyVTablePatches(pDispatchEx, new VTablePatch
			{
				SlotIndex = 7,
				ThunkBytes = new byte[18]
				{
					85, 139, 236, 129, 101, 16, 255, 255, 255, 15,
					184, 13, 240, 173, 186, 93, 255, 224
				},
				TargetOffset = 11
			}, new VTablePatch
			{
				SlotIndex = 9,
				ThunkBytes = new byte[22]
				{
					85, 139, 236, 139, 69, 16, 37, 255, 255, 255,
					15, 137, 69, 16, 184, 13, 240, 173, 186, 93,
					255, 224
				},
				TargetOffset = 15
			}, new VTablePatch
			{
				SlotIndex = 13,
				ThunkBytes = new byte[18]
				{
					85, 139, 236, 129, 101, 12, 255, 255, 255, 15,
					184, 13, 240, 173, 186, 93, 255, 224
				},
				TargetOffset = 11
			});
		}
	}

	private sealed class VTablePatcher64 : VTablePatcher
	{
		public static readonly VTablePatcher Instance = new VTablePatcher64();

		private VTablePatcher64()
		{
		}

		public override void PatchDispatchEx(IntPtr pDispatchEx)
		{
			ApplyVTablePatches(pDispatchEx, new VTablePatch
			{
				SlotIndex = 7,
				ThunkBytes = new byte[20]
				{
					65, 129, 224, 255, 255, 255, 15, 72, 184, 13,
					240, 173, 186, 13, 240, 173, 186, 72, 255, 224
				},
				TargetOffset = 9
			}, new VTablePatch
			{
				SlotIndex = 9,
				ThunkBytes = new byte[20]
				{
					65, 129, 224, 255, 255, 255, 15, 72, 184, 13,
					240, 173, 186, 13, 240, 173, 186, 72, 255, 224
				},
				TargetOffset = 9
			}, new VTablePatch
			{
				SlotIndex = 13,
				ThunkBytes = new byte[19]
				{
					129, 226, 255, 255, 255, 15, 72, 184, 13, 240,
					173, 186, 13, 240, 173, 186, 72, 255, 224
				},
				TargetOffset = 8
			});
		}
	}

	private sealed class VTablePatch
	{
		public int SlotIndex;

		public byte[] ThunkBytes;

		public int TargetOffset;
	}

	private static readonly object dataLock = new object();

	private static readonly HashSet<IntPtr> patchedVTables = new HashSet<IntPtr>();

	private static IntPtr hHeap;

	public static VTablePatcher GetInstance()
	{
		if (!Environment.Is64BitProcess)
		{
			return VTablePatcher32.Instance;
		}
		return VTablePatcher64.Instance;
	}

	public abstract void PatchDispatchEx(IntPtr pDispatchEx);

	private static void ApplyVTablePatches(IntPtr pInterface, params VTablePatch[] patches)
	{
		lock (dataLock)
		{
			IntPtr intPtr = Marshal.ReadIntPtr(pInterface);
			if (patchedVTables.Contains(intPtr))
			{
				return;
			}
			patchedVTables.Add(intPtr);
			EnsureHeap();
			foreach (VTablePatch vTablePatch in patches)
			{
				IntPtr intPtr2 = intPtr + vTablePatch.SlotIndex * IntPtr.Size;
				IntPtr val = Marshal.ReadIntPtr(intPtr2);
				int num = vTablePatch.ThunkBytes.Length;
				IntPtr intPtr3 = NativeMethods.HeapAlloc(hHeap, 0u, (UIntPtr)(ulong)num);
				if (intPtr3 != IntPtr.Zero)
				{
					for (int j = 0; j < num; j++)
					{
						Marshal.WriteByte(intPtr3 + j, vTablePatch.ThunkBytes[j]);
					}
					Marshal.WriteIntPtr(intPtr3 + vTablePatch.TargetOffset, val);
					if (NativeMethods.VirtualProtect(intPtr2, (UIntPtr)(ulong)IntPtr.Size, 4u, out var oldProtect))
					{
						Marshal.WriteIntPtr(intPtr2, intPtr3);
						NativeMethods.VirtualProtect(intPtr2, (UIntPtr)(ulong)IntPtr.Size, oldProtect, out oldProtect);
					}
					else
					{
						NativeMethods.HeapFree(hHeap, 0u, intPtr3);
					}
				}
			}
		}
	}

	private static void EnsureHeap()
	{
		if (hHeap == IntPtr.Zero)
		{
			hHeap = NativeMethods.HeapCreate(262145u, UIntPtr.Zero, UIntPtr.Zero);
			if (hHeap == IntPtr.Zero)
			{
				throw new Win32Exception();
			}
		}
	}
}
