using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;

namespace NAppUpdate.Framework.Utils;

public static class PermissionsCheck
{
	private static readonly IdentityReferenceCollection groups = WindowsIdentity.GetCurrent().Groups;

	private static readonly string sidCurrentUser = WindowsIdentity.GetCurrent().User.Value;

	public static bool IsDirectory(string path)
	{
		if (!Directory.Exists(path))
		{
			return false;
		}
		FileAttributes attributes = File.GetAttributes(path);
		return (attributes & FileAttributes.Directory) == FileAttributes.Directory;
	}

	public static bool HaveWritePermissionsForFolder(string path)
	{
		string path2 = (IsDirectory(path) ? path : Path.GetDirectoryName(path));
		return HaveWritePermissionsForFileOrFolder(path2);
	}

	public static bool HaveWritePermissionsForFileOrFolder(string path)
	{
		AuthorizationRuleCollection accessRules = Directory.GetAccessControl(path).GetAccessRules(includeExplicit: true, includeInherited: true, typeof(SecurityIdentifier));
		bool flag = false;
		bool flag2 = false;
		foreach (FileSystemAccessRule item in accessRules)
		{
			if (item.AccessControlType == AccessControlType.Deny && (item.FileSystemRights & FileSystemRights.WriteData) == FileSystemRights.WriteData && (groups.Contains(item.IdentityReference) || item.IdentityReference.Value == sidCurrentUser))
			{
				flag2 = true;
			}
			if (item.AccessControlType == AccessControlType.Allow && (item.FileSystemRights & FileSystemRights.WriteData) == FileSystemRights.WriteData && (groups.Contains(item.IdentityReference) || item.IdentityReference.Value == sidCurrentUser))
			{
				flag = true;
			}
		}
		if (flag && !flag2)
		{
			return true;
		}
		return false;
	}
}
