using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using ceSmgmuGAR2IorKvvso;
using MCCToolChest.Properties;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.model;

public class Telemetry
{
	private static List<string> ik1SV3OvivG;

	private static readonly object WlMSV1SyFYm;

	private static List<string> eqESVECRulH;

	private static readonly object cF8SVrHt7dV;

	private static Dictionary<int, BedrockBlockState> qcdSV5s2kbY;

	private static readonly object thkSV6sTwVn;

	public static List<string> MissingJavaBlockStates
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return ik1SV3OvivG;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			ik1SV3OvivG = value;
		}
	}

	public static List<string> MissingBedrockBlocks
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return eqESVECRulH;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			eqESVECRulH = value;
		}
	}

	public static Dictionary<int, BedrockBlockState> MissingBedrockBlockStates
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return qcdSV5s2kbY;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			qcdSV5s2kbY = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AddJavaMissingBlockState(string blockStateName)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		lock (WlMSV1SyFYm)
		{
			if (!ik1SV3OvivG.Contains(blockStateName))
			{
				ik1SV3OvivG.Add(blockStateName);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AddBedrockMissingBlock(string blockName)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		lock (cF8SVrHt7dV)
		{
			if (!eqESVECRulH.Contains(blockName))
			{
				eqESVECRulH.Add(blockName);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AddBedrockMissingBlockState(string blockName, string propertyName, string propertyValue, string dataType)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		lock (thkSV6sTwVn)
		{
			int hashCode = (blockName + propertyName + propertyValue).GetHashCode();
			if (!qcdSV5s2kbY.ContainsKey(hashCode))
			{
				BedrockBlockState value = new BedrockBlockState(blockName, propertyName, propertyValue, dataType);
				qcdSV5s2kbY.Add(hashCode, value);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CheckMissingJavaBlockStates()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Settings.Default.AllowTelemetry && MissingJavaBlockStates.Count > 0)
		{
			SNBte6usOpaAUe38VsS sNBte6usOpaAUe38VsS = new SNBte6usOpaAUe38VsS();
			try
			{
				sNBte6usOpaAUe38VsS.DuRSYcMp4UC(MissingJavaBlockStates);
			}
			catch (Exception)
			{
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CheckMissingBedrockBlockStates()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!Settings.Default.AllowTelemetry)
		{
			return;
		}
		SNBte6usOpaAUe38VsS sNBte6usOpaAUe38VsS = new SNBte6usOpaAUe38VsS();
		try
		{
			if (MissingBedrockBlocks.Count > 0)
			{
				sNBte6usOpaAUe38VsS.MJuSYJ0uex5(MissingBedrockBlocks);
			}
			List<BedrockBlockState> list = new List<BedrockBlockState>();
			foreach (BedrockBlockState value in MissingBedrockBlockStates.Values)
			{
				bool flag = false;
				if (BlockMaster.BedrockBlockStatesByName.ContainsKey(value.BlockName))
				{
					List<BlockState> list2 = BlockMaster.BedrockBlockStatesByName[value.BlockName].Values.ToList();
					foreach (BlockState item in list2)
					{
						string blockStates = item.masterBlock.blockStates;
						if (blockStates != null && BlockMaster.DataStates.ContainsKey(blockStates))
						{
							foreach (BlockStateDefinition blockState in BlockMaster.DataStates[blockStates].blockStates)
							{
								if (!(blockState.bedrockName == value.PropertyName))
								{
									continue;
								}
								BlockStateValue[] states = blockState.states;
								foreach (BlockStateValue blockStateValue in states)
								{
									if (blockStateValue.bedrockPropertyValue == value.PropertyValue)
									{
										flag = true;
										break;
									}
								}
								if (flag)
								{
									break;
								}
							}
						}
						if (flag)
						{
							continue;
						}
						if (item.properties != null && item.properties.Count > 0)
						{
							foreach (MasterBlockItemProperty property in item.properties)
							{
								if (property.name == value.PropertyName && property.value == value.PropertyValue)
								{
									flag = true;
									break;
								}
							}
						}
						if (flag)
						{
							break;
						}
					}
				}
				if (!flag)
				{
					list.Add(value);
				}
			}
			if (list.Count > 0)
			{
				sNBte6usOpaAUe38VsS.TGNSYuMDruS(list);
			}
		}
		catch (Exception)
		{
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Telemetry()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static Telemetry()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		ik1SV3OvivG = new List<string>();
		WlMSV1SyFYm = new object();
		eqESVECRulH = new List<string>();
		cF8SVrHt7dV = new object();
		qcdSV5s2kbY = new Dictionary<int, BedrockBlockState>();
		thkSV6sTwVn = new object();
	}
}
