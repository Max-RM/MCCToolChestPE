using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PortableDeviceApiLib;

[ComImport]
[InterfaceType(1)]
[Guid("0000000B-0000-0000-C000-000000000046")]
public interface IStorage
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void CreateStream([In][MarshalAs(UnmanagedType.LPWStr)] string pwcsName, [In] uint grfMode, [In] uint reserved1, [In] uint reserved2, [MarshalAs(UnmanagedType.Interface)] out IStream ppstm);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void RemoteOpenStream([In][MarshalAs(UnmanagedType.LPWStr)] string pwcsName, [In] uint cbReserved1, [In] ref byte reserved1, [In] uint grfMode, [In] uint reserved2, [MarshalAs(UnmanagedType.Interface)] out IStream ppstm);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void CreateStorage([In][MarshalAs(UnmanagedType.LPWStr)] string pwcsName, [In] uint grfMode, [In] uint reserved1, [In] uint reserved2, [MarshalAs(UnmanagedType.Interface)] out IStorage ppstg);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void OpenStorage([In][MarshalAs(UnmanagedType.LPWStr)] string pwcsName, [In][MarshalAs(UnmanagedType.Interface)] IStorage pstgPriority, [In] uint grfMode, [In][ComAliasName("PortableDeviceApiLib.wireSNB")] ref tagRemSNB snbExclude, [In] uint reserved, [MarshalAs(UnmanagedType.Interface)] out IStorage ppstg);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void RemoteCopyTo([In] uint ciidExclude, [In] ref Guid rgiidExclude, [In][ComAliasName("PortableDeviceApiLib.wireSNB")] ref tagRemSNB snbExclude, [In][MarshalAs(UnmanagedType.Interface)] IStorage pstgDest);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void MoveElementTo([In][MarshalAs(UnmanagedType.LPWStr)] string pwcsName, [In][MarshalAs(UnmanagedType.Interface)] IStorage pstgDest, [In][MarshalAs(UnmanagedType.LPWStr)] string pwcsNewName, [In] uint grfFlags);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void Commit([In] uint grfCommitFlags);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void Revert();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void RemoteEnumElements([In] uint reserved1, [In] uint cbReserved2, [In] ref byte reserved2, [In] uint reserved3, [MarshalAs(UnmanagedType.Interface)] out IEnumSTATSTG ppenum);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void DestroyElement([In][MarshalAs(UnmanagedType.LPWStr)] string pwcsName);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void RenameElement([In][MarshalAs(UnmanagedType.LPWStr)] string pwcsOldName, [In][MarshalAs(UnmanagedType.LPWStr)] string pwcsNewName);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void SetElementTimes([In][MarshalAs(UnmanagedType.LPWStr)] string pwcsName, [In] ref _FILETIME pctime, [In] ref _FILETIME patime, [In] ref _FILETIME pmtime);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void SetClass([In] ref Guid clsid);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void SetStateBits([In] uint grfStateBits, [In] uint grfMask);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void Stat(out tagSTATSTG pstatstg, [In] uint grfStatFlag);
}
