using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using MCCToolChest.PECode;
using MCCToolChest.workers;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.model;

public class BlockMaster
{
	private static Dictionary<string, MasterBlock> wHVSQhJZ2j;

	private static Dictionary<string, BlockStateGroup> RrnSO4SKP9;

	private static List<MasterBlock> DquSCs8SK3;

	private static Dictionary<int, MasterBlock> jDBS7Yxo0t;

	private static Dictionary<string, MasterBlock> BAdSARjqPH;

	private static Dictionary<string, MasterBlock> uELSdCR73v;

	private static List<MasterBlock> pHUSH5HVMa;

	private static Dictionary<int, MasterBlock> zEpSFE0ueF;

	private static Dictionary<int, List<MasterBlock>> U0uSjOj8V3;

	private static Dictionary<string, MasterBlock> LUTS83hcbO;

	private static Dictionary<int, MasterBlock> ksQS9Gh61J;

	private static List<BlockState> STWSI4s9TX;

	private static Dictionary<string, SortedDictionary<short, BlockState>> qmhSzhanPF;

	private static Dictionary<int, SortedDictionary<short, BlockState>> RUQGTND1Td;

	private static Dictionary<string, Dictionary<short, BlockState>> YpJGSR1QHA;

	private static Dictionary<int, Dictionary<short, BlockState>> b1PGGtoV7c;

	private static int Mu1GbO4cAi;

	[CompilerGenerated]
	private static Func<MasterBlock, string> xhKGvA2SNl;

	[CompilerGenerated]
	private static Func<List<int>, int> IfjGwJVnQj;

	[CompilerGenerated]
	private static Func<MasterBlock, string> EXnG4TeTBX;

	[CompilerGenerated]
	private static Func<List<int>, int> MsQGVnilfj;

	public static int NewBlockId
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return Mu1GbO4cAi++;
		}
	}

	public static Dictionary<int, MasterBlock> MasterBlocksByHash
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return ksQS9Gh61J;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			ksQS9Gh61J = value;
		}
	}

	public static Dictionary<string, MasterBlock> Blocks
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return wHVSQhJZ2j;
		}
	}

	public static Dictionary<string, BlockStateGroup> DataStates
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return RrnSO4SKP9;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			RrnSO4SKP9 = value;
		}
	}

	public static Dictionary<int, MasterBlock> PCBlocksById
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return jDBS7Yxo0t;
		}
	}

	public static Dictionary<string, MasterBlock> PCBlocksByName
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return BAdSARjqPH;
		}
	}

	public static Dictionary<string, MasterBlock> PCBlocksByNameOld
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return uELSdCR73v;
		}
	}

	public static Dictionary<int, MasterBlock> PEBlocksById
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return zEpSFE0ueF;
		}
	}

	public static Dictionary<string, MasterBlock> PEBlocksByName
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return LUTS83hcbO;
		}
	}

	public static List<BlockState> BlockStates
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return STWSI4s9TX;
		}
	}

	public static Dictionary<int, SortedDictionary<short, BlockState>> BedrockBlockStatesById
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return RUQGTND1Td;
		}
	}

	public static Dictionary<string, SortedDictionary<short, BlockState>> BedrockBlockStatesByName
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return qmhSzhanPF;
		}
	}

	public static Dictionary<int, Dictionary<short, BlockState>> JavaBlockStatesById
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return b1PGGtoV7c;
		}
	}

	public static Dictionary<string, Dictionary<short, BlockState>> JavaBlockStatesByName
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return YpJGSR1QHA;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void InitBlockManager()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string path = AppDomain.CurrentDomain.BaseDirectory + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9642);
		string path2 = Path.Combine(path, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9882));
		string json = File.ReadAllText(path2);
		wHVSQhJZ2j = JsonDataConversion.Deserialize<Dictionary<string, MasterBlock>>(json);
		string path3 = Path.Combine(path, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9908));
		string json2 = File.ReadAllText(path3);
		RrnSO4SKP9 = JsonDataConversion.Deserialize<Dictionary<string, BlockStateGroup>>(json2);
		ksQS9Gh61J = new Dictionary<int, MasterBlock>();
		jDBS7Yxo0t = new Dictionary<int, MasterBlock>();
		BAdSARjqPH = new Dictionary<string, MasterBlock>();
		uELSdCR73v = new Dictionary<string, MasterBlock>();
		zEpSFE0ueF = new Dictionary<int, MasterBlock>();
		LUTS83hcbO = new Dictionary<string, MasterBlock>();
		foreach (string key in wHVSQhJZ2j.Keys)
		{
			MasterBlock masterBlock = wHVSQhJZ2j[key];
			if (masterBlock.java.id.HasValue && !jDBS7Yxo0t.ContainsKey(masterBlock.java.id.Value))
			{
				jDBS7Yxo0t.Add(masterBlock.java.id.Value, masterBlock);
			}
			if (!string.IsNullOrWhiteSpace(masterBlock.java.name) && !BAdSARjqPH.ContainsKey(masterBlock.java.name))
			{
				BAdSARjqPH.Add(masterBlock.java.name, masterBlock);
			}
			if (!string.IsNullOrWhiteSpace(masterBlock.java.nameOld) && !uELSdCR73v.ContainsKey(masterBlock.java.nameOld))
			{
				uELSdCR73v.Add(masterBlock.java.nameOld, masterBlock);
			}
			if (masterBlock.bedrock.id.HasValue && !zEpSFE0ueF.ContainsKey(masterBlock.bedrock.id.Value))
			{
				zEpSFE0ueF.Add(masterBlock.bedrock.id.Value, masterBlock);
			}
			if (!string.IsNullOrWhiteSpace(masterBlock.bedrock.name) && !LUTS83hcbO.ContainsKey(masterBlock.bedrock.name))
			{
				LUTS83hcbO.Add(masterBlock.bedrock.name, masterBlock);
			}
			int hashCode = key.GetHashCode();
			if (!ksQS9Gh61J.ContainsKey(hashCode))
			{
				ksQS9Gh61J.Add(hashCode, masterBlock);
			}
		}
		J8YSrgBOkq();
		KUiS6Ot778();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void J8YSrgBOkq()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		qmhSzhanPF = new Dictionary<string, SortedDictionary<short, BlockState>>();
		RUQGTND1Td = new Dictionary<int, SortedDictionary<short, BlockState>>();
		STWSI4s9TX = new List<BlockState>();
		STWSI4s9TX.Add(new BlockState
		{
			name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9944),
			id = 0,
			data = 0
		});
		List<MasterBlock> list = wHVSQhJZ2j.Values.OrderBy([MethodImpl(MethodImplOptions.NoInlining)] (MasterBlock P_0) =>
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return P_0.bedrock.name;
		}).ToList();
		BlockState blockState = null;
		foreach (MasterBlock item in list)
		{
			if (string.IsNullOrWhiteSpace(item.bedrock.name))
			{
				continue;
			}
			BlockState blockState2 = new BlockState();
			blockState2.name = item.bedrock.name;
			blockState2.id = item.bedrock.id;
			blockState2.data = (short)(item.bedrock.data.HasValue ? item.bedrock.data.Value : 0);
			blockState2.masterBlock = item;
			blockState2.properties = item.bedrock.properties;
			blockState = blockState2;
			if (!blockState.id.HasValue)
			{
				if (!dictionary.ContainsKey(blockState.name))
				{
					dictionary[blockState.name] = NewBlockId;
				}
				blockState.id = dictionary[blockState.name];
			}
			int value = blockState.id.Value;
			if (!qmhSzhanPF.ContainsKey(blockState.name))
			{
				qmhSzhanPF.Add(blockState.name, new SortedDictionary<short, BlockState>());
			}
			if (!qmhSzhanPF[blockState.name].ContainsKey(blockState.data))
			{
				qmhSzhanPF[blockState.name][blockState.data] = blockState;
			}
			if (!RUQGTND1Td.ContainsKey(value))
			{
				RUQGTND1Td.Add(value, new SortedDictionary<short, BlockState>());
			}
			if (!RUQGTND1Td[value].ContainsKey(blockState.data))
			{
				RUQGTND1Td[value][blockState.data] = blockState;
			}
		}
		foreach (MasterBlock item2 in list)
		{
			int value2 = item2.bedrock.id.Value;
			if (string.IsNullOrWhiteSpace(item2.bedrock.name) || string.IsNullOrWhiteSpace(item2.blockStates))
			{
				continue;
			}
			List<int> list2 = X5ES50RcjI(item2.blockStates);
			for (int num = 0; num < list2.Count; num++)
			{
				int num2 = list2[num] + (item2.bedrock.data.HasValue ? item2.bedrock.data.Value : 0);
				BlockState blockState3 = new BlockState();
				blockState3.name = item2.bedrock.name;
				blockState3.id = item2.bedrock.id;
				blockState3.data = (short)num2;
				blockState3.masterBlock = item2;
				blockState3.properties = item2.bedrock.properties;
				blockState = blockState3;
				if (!qmhSzhanPF[blockState.name].ContainsKey((short)num2))
				{
					qmhSzhanPF[blockState.name].Add((short)num2, blockState);
				}
				if (!RUQGTND1Td[value2].ContainsKey((short)num2))
				{
					RUQGTND1Td[value2].Add((short)num2, blockState);
				}
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static List<int> X5ES50RcjI(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<int> list = new List<int>();
		List<List<int>> list2 = new List<List<int>>();
		if (RrnSO4SKP9.ContainsKey(P_0))
		{
			BlockStateGroup blockStateGroup = RrnSO4SKP9[P_0];
			foreach (BlockStateDefinition blockState in blockStateGroup.blockStates)
			{
				if (blockState.bedrockMask > 0)
				{
					List<int> list3 = new List<int>();
					BlockStateValue[] states = blockState.states;
					foreach (BlockStateValue blockStateValue in states)
					{
						list3.Add(blockStateValue.bedrock);
					}
					list2.Add(list3);
				}
			}
		}
		list2 = list2.OrderByDescending([MethodImpl(MethodImplOptions.NoInlining)] (List<int> list4) =>
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return list4.Count;
		}).ToList();
		if (list2.Count > 0)
		{
			Og5SD6xqes(list2, 0, new int[list2.Count], list);
		}
		return list;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void KUiS6Ot778()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		YpJGSR1QHA = new Dictionary<string, Dictionary<short, BlockState>>();
		b1PGGtoV7c = new Dictionary<int, Dictionary<short, BlockState>>();
		STWSI4s9TX = new List<BlockState>();
		STWSI4s9TX.Add(new BlockState
		{
			name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9944),
			id = 0,
			data = 0
		});
		List<MasterBlock> list = wHVSQhJZ2j.Values.OrderBy([MethodImpl(MethodImplOptions.NoInlining)] (MasterBlock P_0) =>
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return P_0.java.name;
		}).ToList();
		foreach (MasterBlock item in list)
		{
			if (string.IsNullOrWhiteSpace(item.java.name))
			{
				continue;
			}
			BlockState blockState = new BlockState();
			blockState.name = item.java.name;
			blockState.id = item.java.id;
			blockState.data = (short)(item.java.data.HasValue ? item.java.data.Value : 0);
			blockState.masterBlock = item;
			blockState.properties = item.java.properties;
			BlockState blockState2 = blockState;
			if (!blockState2.id.HasValue)
			{
				if (!dictionary.ContainsKey(blockState2.name))
				{
					dictionary[blockState2.name] = NewBlockId;
				}
				blockState2.id = dictionary[blockState2.name];
			}
			int value = blockState2.id.Value;
			if (!YpJGSR1QHA.ContainsKey(blockState2.name))
			{
				YpJGSR1QHA.Add(blockState2.name, new Dictionary<short, BlockState>());
			}
			YpJGSR1QHA[blockState2.name][blockState2.data] = blockState2;
			if (!b1PGGtoV7c.ContainsKey(value))
			{
				b1PGGtoV7c.Add(value, new Dictionary<short, BlockState>());
			}
			b1PGGtoV7c[value][blockState2.data] = blockState2;
			if (string.IsNullOrWhiteSpace(item.blockStates))
			{
				continue;
			}
			List<int> list2 = KJESNQUYvX(item.blockStates);
			for (int num = 0; num < list2.Count; num++)
			{
				int num2 = list2[num] + (item.java.data.HasValue ? item.java.data.Value : 0);
				BlockState blockState3 = new BlockState();
				blockState3.name = item.java.name;
				blockState3.id = item.java.id;
				blockState3.data = (short)num2;
				blockState3.masterBlock = item;
				blockState3.properties = item.java.properties;
				blockState2 = blockState3;
				if (!YpJGSR1QHA[blockState2.name].ContainsKey((short)num2))
				{
					YpJGSR1QHA[blockState2.name].Add((short)num2, blockState2);
				}
				if (!b1PGGtoV7c[value].ContainsKey((short)num2))
				{
					b1PGGtoV7c[value].Add((short)num2, blockState2);
				}
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static List<int> KJESNQUYvX(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<int> list = new List<int>();
		List<List<int>> list2 = new List<List<int>>();
		if (RrnSO4SKP9.ContainsKey(P_0))
		{
			BlockStateGroup blockStateGroup = RrnSO4SKP9[P_0];
			foreach (BlockStateDefinition blockState in blockStateGroup.blockStates)
			{
				if (blockState.javaMask > 0)
				{
					List<int> list3 = new List<int>();
					BlockStateValue[] states = blockState.states;
					foreach (BlockStateValue blockStateValue in states)
					{
						list3.Add(blockStateValue.java);
					}
					list2.Add(list3);
				}
			}
		}
		list2 = list2.OrderByDescending([MethodImpl(MethodImplOptions.NoInlining)] (List<int> list4) =>
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return list4.Count;
		}).ToList();
		if (list2.Count > 0)
		{
			Og5SD6xqes(list2, 0, new int[list2.Count], list);
		}
		return list;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void Og5SD6xqes(List<List<int>> P_0, int P_1, int[] P_2, List<int> P_3)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<int> list = P_0[P_1];
		for (int i = 0; i < list.Count; i++)
		{
			P_2[P_1] = list[i];
			if (P_1 < P_0.Count - 1)
			{
				Og5SD6xqes(P_0, P_1 + 1, P_2, P_3);
				continue;
			}
			int num = 0;
			for (int j = 0; j < P_1 + 1; j++)
			{
				num |= P_2[j];
			}
			if (!P_3.Contains(num))
			{
				P_3.Add(num);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static BlockState GetBedrockBlockState(string name, short val)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!name.StartsWith(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9974)))
		{
			name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9974) + name;
		}
		if (BedrockBlockStatesByName.ContainsKey(name))
		{
			if (BedrockBlockStatesByName[name].ContainsKey(val))
			{
				return BedrockBlockStatesByName[name][val].Copy(0);
			}
			if (BedrockBlockStatesByName[name].Count > 0)
			{
				return BedrockBlockStatesByName[name].Values.First().Copy(0);
			}
		}
		Telemetry.AddBedrockMissingBlock(name);
		return RUQGTND1Td[0].Values.First().Copy(0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static BlockState GetBedrockBlockState(int id, short val)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (BedrockBlockStatesById.ContainsKey(id))
		{
			if (RUQGTND1Td[id].ContainsKey(val))
			{
				return RUQGTND1Td[id][val].Copy(0);
			}
			if (RUQGTND1Td[id].Count > 0)
			{
				return RUQGTND1Td[id].Values.First().Copy(0);
			}
		}
		return RUQGTND1Td[0].Values.First().Copy(0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static BlockState GetBedrockBlockState(string name, TagNodeCompound values)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Dictionary<string, MasterBlockItemProperty> dictionary = PEUtility.ExtractBedrockPropertyStates(values);
		if (!name.StartsWith(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9974)))
		{
			name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9974) + name;
		}
		foreach (string key in values.Keys)
		{
			Telemetry.AddBedrockMissingBlockState(name, key, values[key].ToString(), values[key].GetTagType().ToString());
		}
		if (BedrockBlockStatesByName.ContainsKey(name))
		{
			SortedDictionary<short, BlockState> sortedDictionary = BedrockBlockStatesByName[name];
			foreach (BlockState value in sortedDictionary.Values)
			{
				bool flag = true;
				if (value.properties != null)
				{
					foreach (MasterBlockItemProperty property in value.properties)
					{
						if (property.name == null || !dictionary.ContainsKey(property.name) || property.value != dictionary[property.name].value)
						{
							flag = false;
							break;
						}
					}
				}
				else
				{
					flag = false;
				}
				if (flag)
				{
					BlockState blockState = value.Copy(0);
					blockState.properties = dictionary.Values.ToList();
					blockState.useProperties = true;
					return blockState;
				}
			}
			if (BedrockBlockStatesByName[name].Count > 0)
			{
				BlockState blockState2 = BedrockBlockStatesByName[name].Values.First().Copy(0);
				blockState2.properties = dictionary.Values.ToList();
				blockState2.useProperties = true;
				return blockState2;
			}
		}
		Telemetry.AddBedrockMissingBlock(name);
		return RUQGTND1Td[0].Values.First().Copy(0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static BlockState GetJavaBlockState(int id, short val)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (JavaBlockStatesById.ContainsKey(id))
		{
			if (b1PGGtoV7c[id].ContainsKey(val))
			{
				return b1PGGtoV7c[id][val].Copy(0);
			}
			if (b1PGGtoV7c[id].Count > 0)
			{
				return b1PGGtoV7c[id].Values.First().Copy(0);
			}
		}
		return b1PGGtoV7c[0].Values.First().Copy(0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int ConvertBedrockDataToJava(MasterBlock mb, int data)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = 0;
		if (mb.blockStates != null && DataStates.ContainsKey(mb.blockStates))
		{
			List<BlockStateDefinition> blockStates = DataStates[mb.blockStates].blockStates;
			foreach (BlockStateDefinition item in blockStates)
			{
				if (item.bedrockMask <= 0)
				{
					continue;
				}
				int num2 = data & item.bedrockMask;
				for (int i = 0; i < item.states.Length; i++)
				{
					if (num2 == item.states[i].bedrock)
					{
						num |= item.states[i].java;
						break;
					}
				}
			}
		}
		return num;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int ConvertJavaDataToBedrock(MasterBlock mb, int data)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = 0;
		if (mb.blockStates != null && DataStates.ContainsKey(mb.blockStates))
		{
			List<BlockStateDefinition> blockStates = DataStates[mb.blockStates].blockStates;
			foreach (BlockStateDefinition item in blockStates)
			{
				if (item.javaMask <= 0)
				{
					continue;
				}
				int num2 = data & item.javaMask;
				for (int i = 0; i < item.states.Length; i++)
				{
					if (num2 == item.states[i].java)
					{
						num |= item.states[i].bedrock;
						break;
					}
				}
			}
		}
		return num;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static BlockConversionDefinition JavaFromBedrockBlock(int inBlock, int inData)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BlockState bedrockBlockState = GetBedrockBlockState(inBlock, (short)inData);
		int id = (bedrockBlockState.masterBlock.java.id.HasValue ? bedrockBlockState.masterBlock.java.id.Value : 0);
		int num = (bedrockBlockState.masterBlock.java.data.HasValue ? bedrockBlockState.masterBlock.java.data.Value : 0);
		string name = ((bedrockBlockState.masterBlock.java.name != null) ? bedrockBlockState.masterBlock.java.name : Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9944));
		num |= ConvertBedrockDataToJava(bedrockBlockState.masterBlock, bedrockBlockState.data);
		return new BlockConversionDefinition(id, num, name);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static BlockConversionDefinition BedrockFromJavaBlock(int inBlock, int inData)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BlockState javaBlockState = GetJavaBlockState(inBlock, (short)inData);
		int id = (javaBlockState.masterBlock.bedrock.id.HasValue ? javaBlockState.masterBlock.bedrock.id.Value : 0);
		int num = (javaBlockState.masterBlock.bedrock.data.HasValue ? javaBlockState.masterBlock.bedrock.data.Value : 0);
		string name = ((javaBlockState.masterBlock.bedrock.name != null) ? javaBlockState.masterBlock.bedrock.name : Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9944));
		num |= ConvertJavaDataToBedrock(javaBlockState.masterBlock, javaBlockState.data);
		return new BlockConversionDefinition(id, num, name);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BlockMaster()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static string qPbSckbFdx(MasterBlock P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0.bedrock.name;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static int SEOSJtMpCc(List<int> P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0.Count;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static string OudSuDOwhe(MasterBlock P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0.java.name;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static int NIoSoPj3Vn(List<int> P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0.Count;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static BlockMaster()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		wHVSQhJZ2j = new Dictionary<string, MasterBlock>();
		RrnSO4SKP9 = new Dictionary<string, BlockStateGroup>();
		DquSCs8SK3 = null;
		jDBS7Yxo0t = null;
		BAdSARjqPH = null;
		uELSdCR73v = null;
		pHUSH5HVMa = null;
		zEpSFE0ueF = null;
		U0uSjOj8V3 = null;
		LUTS83hcbO = null;
		ksQS9Gh61J = null;
		STWSI4s9TX = null;
		qmhSzhanPF = null;
		RUQGTND1Td = null;
		YpJGSR1QHA = null;
		b1PGGtoV7c = null;
		Mu1GbO4cAi = 256;
	}
}
