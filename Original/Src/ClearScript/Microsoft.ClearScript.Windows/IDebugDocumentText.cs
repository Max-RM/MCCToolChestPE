using System;
using System.Runtime.InteropServices;

namespace Microsoft.ClearScript.Windows;

[ComImport]
[Guid("51973c22-cb0c-11d0-b5c9-00a0244a0e7a")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IDebugDocumentText
{
	[PreserveSig]
	uint GetName([In] DocumentNameType type, [MarshalAs(UnmanagedType.BStr)] out string name);

	void GetDocumentClassId(out Guid clsid);

	void GetDocumentAttributes(out TextDocAttrs attrs);

	void GetSize(out uint numLines, out uint length);

	void GetPositionOfLine([In] uint lineNumber, out uint position);

	void GetLineOfPosition([In] uint position, out uint lineNumber, out uint offsetInLine);

	void GetText([In] uint position, [In] IntPtr pChars, [In] IntPtr pAttrs, [In][Out] ref uint length, [In] uint maxChars);

	void GetPositionOfContext([In][MarshalAs(UnmanagedType.Interface)] IDebugDocumentContext context, out uint position, out uint length);

	void GetContextOfPosition([In] uint position, [In] uint length, [MarshalAs(UnmanagedType.Interface)] out IDebugDocumentContext context);
}
