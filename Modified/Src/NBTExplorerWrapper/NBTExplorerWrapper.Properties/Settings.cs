using System.CodeDom.Compiler;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NBTExplorerWrapper.Properties;

[CompilerGenerated]
[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
internal sealed class Settings : ApplicationSettingsBase
{
	private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());

	public static Settings Default => defaultInstance;

	[DebuggerNonUserCode]
	[UserScopedSetting]
	public StringCollection RecentFiles
	{
		get
		{
			return (StringCollection)this["RecentFiles"];
		}
		set
		{
			this["RecentFiles"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	public StringCollection RecentDirectories
	{
		get
		{
			return (StringCollection)this["RecentDirectories"];
		}
		set
		{
			this["RecentDirectories"] = value;
		}
	}
}
