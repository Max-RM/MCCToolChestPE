using System.Collections.Generic;

namespace MCCToolChest.model;

/// <summary>
/// Built-in Bedrock world save roots. Edit this file to add compile-time paths.
/// Custom paths are stored at runtime in %AppData%\MCCToolChestPE\custom_world_save_paths.json
/// </summary>
public static class PeWorldSavePathDefinitions
{
	public static readonly IReadOnlyList<PeWorldSavePathTemplate> BuiltInTemplates = new List<PeWorldSavePathTemplate>
	{
		new PeWorldSavePathTemplate("Bedrock UWP", PeWorldSavePathKind.BedrockUwp, @"Packages\Microsoft.MinecraftUWP_8wekyb3d8bbwe\LocalState\games\com.mojang\minecraftWorlds"),
		new PeWorldSavePathTemplate("Bedrock UWP Preview", PeWorldSavePathKind.BedrockUwpPreview, @"Packages\Microsoft.MinecraftWindowsBeta_8wekyb3d8bbwe\LocalState\games\com.mojang\minecraftWorlds"),
		new PeWorldSavePathTemplate("Bedrock (Netease)", PeWorldSavePathKind.Netease, @"Roaming\MinecraftPE_Netease\minecraftWorlds"),
		new PeWorldSavePathTemplate("Bedrock (Netease 2)", PeWorldSavePathKind.Netease2, @"Roaming\MinecraftPC_Netease\minecraftWorlds"),
		new PeWorldSavePathTemplate("Education Edition Win32", PeWorldSavePathKind.Other, @"Roaming\Minecraft Education Edition\games\com.mojang\minecraftWorlds"),
		new PeWorldSavePathTemplate("Education Edition UWP", PeWorldSavePathKind.EducationUwp, @"Packages\Microsoft.MinecraftEducationEdition_8wekyb3d8bbwe\LocalState\games\com.mojang\minecraftWorlds"),
		new PeWorldSavePathTemplate("OptiCraft Win32", PeWorldSavePathKind.Other, @"Roaming\OptiCraft\games\com.mojang\minecraftWorlds"),
		new PeWorldSavePathTemplate("Minecraft Legends (Legacy)", PeWorldSavePathKind.Other, @"Roaming\MinecraftPE\games\com.mojang\minecraftWorlds"),
		new PeWorldSavePathTemplate("Bedrock GDK Shared", PeWorldSavePathKind.BedrockGdkShared, @"Roaming\Minecraft Bedrock\Users\Shared\games\com.mojang\minecraftWorlds"),
		new PeWorldSavePathTemplate("Bedrock GDK Preview Shared", PeWorldSavePathKind.BedrockGdkPreviewShared, @"Roaming\Minecraft Bedrock Preview\Users\Shared\games\com.mojang\minecraftWorlds")
	};
}

public enum PeWorldSavePathKind
{
	Fixed,
	BedrockUwp,
	BedrockUwpPreview,
	BedrockUwpCloned,
	BedrockGdkShared,
	BedrockGdkUser,
	BedrockGdkPreviewShared,
	BedrockGdkPreviewUser,
	Custom,
	Netease,
	Netease2,
	EducationUwp,
	EducationUwpCloned,
	Other
}

public class PeWorldSavePathTemplate
{
	public string Label { get; }

	public PeWorldSavePathKind Kind { get; }

	public string RelativePath { get; }

	public PeWorldSavePathTemplate(string label, PeWorldSavePathKind kind, string relativePath)
	{
		Label = label;
		Kind = kind;
		RelativePath = relativePath;
	}
}

public class PeWorldSavePathItem
{
	public string Label { get; set; }

	public string Path { get; set; }

	public bool IsCustom { get; set; }

	public PeWorldSavePathKind Kind { get; set; }

	public override string ToString()
	{
		return Label;
	}
}
