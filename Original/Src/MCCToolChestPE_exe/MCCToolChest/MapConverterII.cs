using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using Substrate;
using Substrate.Data;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest;

public class MapConverterII
{
	private static Color[] HFPSvHaEsQG;

	private Color[] OYuSvFDKRXE;

	private BlockColorIndex[] iP0SvjBBsbQ;

	private int jkrSv8415DI;

	private Vector3[] zJ5Sv9KMhEf;

	public int ColorGroupSize
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return jkrSv8415DI;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			if (value <= 0)
			{
				throw new ArgumentOutOfRangeException(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(73020));
			}
			jkrSv8415DI = value;
		}
	}

	public Color[] ColorIndex
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return OYuSvFDKRXE;
		}
	}

	public BlockColorIndex[] BlockIndex
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return iP0SvjBBsbQ;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MapConverterII()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		jkrSv8415DI = 4;
		OYuSvFDKRXE = new Color[256];
		zJ5Sv9KMhEf = new Vector3[256];
		HFPSvHaEsQG.CopyTo(OYuSvFDKRXE, 0);
		RefreshColorCache();
		iP0SvjBBsbQ = new BlockColorIndex[4096];
		for (int i = 0; i < iP0SvjBBsbQ.Length; i++)
		{
			iP0SvjBBsbQ[i] = new BlockColorIndex();
		}
		iP0SvjBBsbQ[0].jVNSvOn9cu8(0, ColorGroup.Unexplored);
		iP0SvjBBsbQ[1].jVNSvOn9cu8(0, ColorGroup.Stone);
		iP0SvjBBsbQ[2].jVNSvOn9cu8(0, ColorGroup.Grass);
		iP0SvjBBsbQ[3].jVNSvOn9cu8(0, ColorGroup.Dirt);
		iP0SvjBBsbQ[4].jVNSvOn9cu8(0, ColorGroup.Stone);
		iP0SvjBBsbQ[5].jVNSvOn9cu8(0, ColorGroup.Wood);
		iP0SvjBBsbQ[6].jVNSvOn9cu8(0, ColorGroup.Plant);
		iP0SvjBBsbQ[7].jVNSvOn9cu8(0, ColorGroup.Stone);
		iP0SvjBBsbQ[8].jVNSvOn9cu8(0, ColorGroup.Water);
		iP0SvjBBsbQ[9].jVNSvOn9cu8(0, ColorGroup.Water);
		iP0SvjBBsbQ[10].jVNSvOn9cu8(0, ColorGroup.Lava);
		iP0SvjBBsbQ[11].jVNSvOn9cu8(0, ColorGroup.Lava);
		iP0SvjBBsbQ[12].jVNSvOn9cu8(0, ColorGroup.Sand);
		iP0SvjBBsbQ[13].jVNSvOn9cu8(0, ColorGroup.Sand);
		iP0SvjBBsbQ[14].jVNSvOn9cu8(0, ColorGroup.Stone);
		iP0SvjBBsbQ[15].jVNSvOn9cu8(0, ColorGroup.Stone);
		iP0SvjBBsbQ[16].jVNSvOn9cu8(0, ColorGroup.Stone);
		iP0SvjBBsbQ[17].jVNSvOn9cu8(0, ColorGroup.Wood);
		iP0SvjBBsbQ[18].jVNSvOn9cu8(0, ColorGroup.Plant);
		iP0SvjBBsbQ[19].jVNSvOn9cu8(0, ColorGroup.Yellow);
		iP0SvjBBsbQ[20].jVNSvOn9cu8(0, ColorGroup.Unexplored);
		iP0SvjBBsbQ[21].jVNSvOn9cu8(0, ColorGroup.Stone);
		iP0SvjBBsbQ[22].jVNSvOn9cu8(0, ColorGroup.Lapis);
		iP0SvjBBsbQ[23].jVNSvOn9cu8(0, ColorGroup.Stone);
		iP0SvjBBsbQ[24].jVNSvOn9cu8(0, ColorGroup.Sand);
		iP0SvjBBsbQ[25].jVNSvOn9cu8(0, ColorGroup.Wood);
		iP0SvjBBsbQ[26].jVNSvOn9cu8(0, ColorGroup.Other);
		iP0SvjBBsbQ[27].jVNSvOn9cu8(0, ColorGroup.Unexplored);
		iP0SvjBBsbQ[28].jVNSvOn9cu8(0, ColorGroup.Unexplored);
		iP0SvjBBsbQ[29].jVNSvOn9cu8(0, ColorGroup.Stone);
		iP0SvjBBsbQ[30].jVNSvOn9cu8(0, ColorGroup.Other);
		iP0SvjBBsbQ[31].jVNSvOn9cu8(0, ColorGroup.Plant);
		iP0SvjBBsbQ[32].jVNSvOn9cu8(0, ColorGroup.Plant);
		iP0SvjBBsbQ[33].jVNSvOn9cu8(0, ColorGroup.Stone);
		iP0SvjBBsbQ[34].jVNSvOn9cu8(0, ColorGroup.Stone);
		iP0SvjBBsbQ[35].jVNSvOn9cu8(0, ColorGroup.White);
		iP0SvjBBsbQ[35].jVNSvOn9cu8(1, ColorGroup.Orange);
		iP0SvjBBsbQ[35].jVNSvOn9cu8(2, ColorGroup.Magenta);
		iP0SvjBBsbQ[35].jVNSvOn9cu8(3, ColorGroup.LightBlue);
		iP0SvjBBsbQ[35].jVNSvOn9cu8(4, ColorGroup.Yellow);
		iP0SvjBBsbQ[35].jVNSvOn9cu8(5, ColorGroup.Lime);
		iP0SvjBBsbQ[35].jVNSvOn9cu8(6, ColorGroup.Pink);
		iP0SvjBBsbQ[35].jVNSvOn9cu8(7, ColorGroup.Grey);
		iP0SvjBBsbQ[35].jVNSvOn9cu8(8, ColorGroup.LightGrey);
		iP0SvjBBsbQ[35].jVNSvOn9cu8(9, ColorGroup.Cyan);
		iP0SvjBBsbQ[35].jVNSvOn9cu8(10, ColorGroup.Purple);
		iP0SvjBBsbQ[35].jVNSvOn9cu8(11, ColorGroup.Blue);
		iP0SvjBBsbQ[35].jVNSvOn9cu8(12, ColorGroup.Brown);
		iP0SvjBBsbQ[35].jVNSvOn9cu8(13, ColorGroup.Green);
		iP0SvjBBsbQ[35].jVNSvOn9cu8(14, ColorGroup.Red);
		iP0SvjBBsbQ[35].jVNSvOn9cu8(15, ColorGroup.Black);
		iP0SvjBBsbQ[36].jVNSvOn9cu8(0, ColorGroup.Stone);
		iP0SvjBBsbQ[37].jVNSvOn9cu8(0, ColorGroup.Plant);
		iP0SvjBBsbQ[38].jVNSvOn9cu8(0, ColorGroup.Plant);
		iP0SvjBBsbQ[39].jVNSvOn9cu8(0, ColorGroup.Wood);
		iP0SvjBBsbQ[40].jVNSvOn9cu8(0, ColorGroup.Red);
		iP0SvjBBsbQ[41].jVNSvOn9cu8(0, ColorGroup.Gold);
		iP0SvjBBsbQ[42].jVNSvOn9cu8(0, ColorGroup.Metal);
		iP0SvjBBsbQ[43].jVNSvOn9cu8(0, ColorGroup.Stone);
		iP0SvjBBsbQ[44].jVNSvOn9cu8(0, ColorGroup.Stone);
		iP0SvjBBsbQ[45].jVNSvOn9cu8(0, ColorGroup.Red);
		iP0SvjBBsbQ[46].jVNSvOn9cu8(0, ColorGroup.Lava);
		iP0SvjBBsbQ[47].jVNSvOn9cu8(0, ColorGroup.Wood);
		iP0SvjBBsbQ[48].jVNSvOn9cu8(0, ColorGroup.Stone);
		iP0SvjBBsbQ[49].jVNSvOn9cu8(0, ColorGroup.Black);
		iP0SvjBBsbQ[50].jVNSvOn9cu8(0, ColorGroup.Unexplored);
		iP0SvjBBsbQ[51].jVNSvOn9cu8(0, ColorGroup.Lava);
		iP0SvjBBsbQ[52].jVNSvOn9cu8(0, ColorGroup.Stone);
		iP0SvjBBsbQ[53].jVNSvOn9cu8(0, ColorGroup.Wood);
		iP0SvjBBsbQ[54].jVNSvOn9cu8(0, ColorGroup.Wood);
		iP0SvjBBsbQ[55].jVNSvOn9cu8(0, ColorGroup.Unexplored);
		iP0SvjBBsbQ[56].jVNSvOn9cu8(0, ColorGroup.Stone);
		iP0SvjBBsbQ[57].jVNSvOn9cu8(0, ColorGroup.Diamond);
		iP0SvjBBsbQ[58].jVNSvOn9cu8(0, ColorGroup.Wood);
		iP0SvjBBsbQ[59].jVNSvOn9cu8(0, ColorGroup.Plant);
		iP0SvjBBsbQ[60].jVNSvOn9cu8(0, ColorGroup.Dirt);
		iP0SvjBBsbQ[61].jVNSvOn9cu8(0, ColorGroup.Stone);
		iP0SvjBBsbQ[62].jVNSvOn9cu8(0, ColorGroup.Stone);
		iP0SvjBBsbQ[63].jVNSvOn9cu8(0, ColorGroup.Wood);
		iP0SvjBBsbQ[64].jVNSvOn9cu8(0, ColorGroup.Wood);
		iP0SvjBBsbQ[65].jVNSvOn9cu8(0, ColorGroup.Unexplored);
		iP0SvjBBsbQ[66].jVNSvOn9cu8(0, ColorGroup.Unexplored);
		iP0SvjBBsbQ[67].jVNSvOn9cu8(0, ColorGroup.Stone);
		iP0SvjBBsbQ[68].jVNSvOn9cu8(0, ColorGroup.Wood);
		iP0SvjBBsbQ[69].jVNSvOn9cu8(0, ColorGroup.Unexplored);
		iP0SvjBBsbQ[70].jVNSvOn9cu8(0, ColorGroup.Stone);
		iP0SvjBBsbQ[71].jVNSvOn9cu8(0, ColorGroup.Metal);
		iP0SvjBBsbQ[72].jVNSvOn9cu8(0, ColorGroup.Wood);
		iP0SvjBBsbQ[73].jVNSvOn9cu8(0, ColorGroup.Stone);
		iP0SvjBBsbQ[74].jVNSvOn9cu8(0, ColorGroup.Stone);
		iP0SvjBBsbQ[75].jVNSvOn9cu8(0, ColorGroup.Unexplored);
		iP0SvjBBsbQ[76].jVNSvOn9cu8(0, ColorGroup.Unexplored);
		iP0SvjBBsbQ[77].jVNSvOn9cu8(0, ColorGroup.Unexplored);
		iP0SvjBBsbQ[78].jVNSvOn9cu8(0, ColorGroup.White);
		iP0SvjBBsbQ[79].jVNSvOn9cu8(0, ColorGroup.Ice);
		iP0SvjBBsbQ[80].jVNSvOn9cu8(0, ColorGroup.White);
		iP0SvjBBsbQ[81].jVNSvOn9cu8(0, ColorGroup.Plant);
		iP0SvjBBsbQ[82].jVNSvOn9cu8(0, ColorGroup.Clay);
		iP0SvjBBsbQ[83].jVNSvOn9cu8(0, ColorGroup.Plant);
		iP0SvjBBsbQ[84].jVNSvOn9cu8(0, ColorGroup.Wood);
		iP0SvjBBsbQ[85].jVNSvOn9cu8(0, ColorGroup.Wood);
		iP0SvjBBsbQ[86].jVNSvOn9cu8(0, ColorGroup.Orange);
		iP0SvjBBsbQ[87].jVNSvOn9cu8(0, ColorGroup.Netherrack);
		iP0SvjBBsbQ[88].jVNSvOn9cu8(0, ColorGroup.Brown);
		iP0SvjBBsbQ[89].jVNSvOn9cu8(0, ColorGroup.Sand);
		iP0SvjBBsbQ[90].jVNSvOn9cu8(0, ColorGroup.Unexplored);
		iP0SvjBBsbQ[91].jVNSvOn9cu8(0, ColorGroup.Orange);
		iP0SvjBBsbQ[92].jVNSvOn9cu8(0, ColorGroup.Unexplored);
		iP0SvjBBsbQ[93].jVNSvOn9cu8(0, ColorGroup.Unexplored);
		iP0SvjBBsbQ[94].jVNSvOn9cu8(0, ColorGroup.Unexplored);
		iP0SvjBBsbQ[95].jVNSvOn9cu8(0, ColorGroup.Wood);
		iP0SvjBBsbQ[96].jVNSvOn9cu8(0, ColorGroup.Wood);
		iP0SvjBBsbQ[97].jVNSvOn9cu8(0, ColorGroup.Stone);
		iP0SvjBBsbQ[98].jVNSvOn9cu8(0, ColorGroup.Stone);
		iP0SvjBBsbQ[99].jVNSvOn9cu8(0, ColorGroup.Brown);
		iP0SvjBBsbQ[100].jVNSvOn9cu8(0, ColorGroup.Red);
		iP0SvjBBsbQ[101].jVNSvOn9cu8(0, ColorGroup.Metal);
		iP0SvjBBsbQ[102].jVNSvOn9cu8(0, ColorGroup.Unexplored);
		iP0SvjBBsbQ[103].jVNSvOn9cu8(0, ColorGroup.Lime);
		iP0SvjBBsbQ[104].jVNSvOn9cu8(0, ColorGroup.Plant);
		iP0SvjBBsbQ[105].jVNSvOn9cu8(0, ColorGroup.Plant);
		iP0SvjBBsbQ[106].jVNSvOn9cu8(0, ColorGroup.Plant);
		iP0SvjBBsbQ[107].jVNSvOn9cu8(0, ColorGroup.Wood);
		iP0SvjBBsbQ[108].jVNSvOn9cu8(0, ColorGroup.Red);
		iP0SvjBBsbQ[109].jVNSvOn9cu8(0, ColorGroup.Stone);
		iP0SvjBBsbQ[110].jVNSvOn9cu8(0, ColorGroup.Purple);
		iP0SvjBBsbQ[111].jVNSvOn9cu8(0, ColorGroup.Plant);
		iP0SvjBBsbQ[112].jVNSvOn9cu8(0, ColorGroup.Netherrack);
		iP0SvjBBsbQ[113].jVNSvOn9cu8(0, ColorGroup.Netherrack);
		iP0SvjBBsbQ[114].jVNSvOn9cu8(0, ColorGroup.Netherrack);
		iP0SvjBBsbQ[115].jVNSvOn9cu8(0, ColorGroup.Netherrack);
		iP0SvjBBsbQ[116].jVNSvOn9cu8(0, ColorGroup.Red);
		iP0SvjBBsbQ[117].jVNSvOn9cu8(0, ColorGroup.Metal);
		iP0SvjBBsbQ[118].jVNSvOn9cu8(0, ColorGroup.Grey);
		iP0SvjBBsbQ[119].jVNSvOn9cu8(0, ColorGroup.Black);
		iP0SvjBBsbQ[120].jVNSvOn9cu8(0, ColorGroup.Green);
		iP0SvjBBsbQ[121].jVNSvOn9cu8(0, ColorGroup.Yellow);
		iP0SvjBBsbQ[122].jVNSvOn9cu8(0, ColorGroup.Black);
		iP0SvjBBsbQ[123].jVNSvOn9cu8(0, ColorGroup.Unexplored);
		iP0SvjBBsbQ[124].jVNSvOn9cu8(0, ColorGroup.Unexplored);
		iP0SvjBBsbQ[125].jVNSvOn9cu8(0, ColorGroup.Wood);
		iP0SvjBBsbQ[126].jVNSvOn9cu8(0, ColorGroup.Wood);
		iP0SvjBBsbQ[127].jVNSvOn9cu8(0, ColorGroup.Brown);
		iP0SvjBBsbQ[128].jVNSvOn9cu8(0, ColorGroup.Sand);
		iP0SvjBBsbQ[129].jVNSvOn9cu8(0, ColorGroup.Stone);
		iP0SvjBBsbQ[130].jVNSvOn9cu8(0, ColorGroup.Stone);
		iP0SvjBBsbQ[131].jVNSvOn9cu8(0, ColorGroup.Unexplored);
		iP0SvjBBsbQ[132].jVNSvOn9cu8(0, ColorGroup.Unexplored);
		iP0SvjBBsbQ[133].jVNSvOn9cu8(0, ColorGroup.Emerald);
		iP0SvjBBsbQ[134].jVNSvOn9cu8(0, ColorGroup.Wood);
		iP0SvjBBsbQ[135].jVNSvOn9cu8(0, ColorGroup.Wood);
		iP0SvjBBsbQ[136].jVNSvOn9cu8(0, ColorGroup.Wood);
		iP0SvjBBsbQ[137].jVNSvOn9cu8(0, ColorGroup.Brown);
		iP0SvjBBsbQ[138].jVNSvOn9cu8(0, ColorGroup.Diamond);
		iP0SvjBBsbQ[139].jVNSvOn9cu8(0, ColorGroup.Stone);
		iP0SvjBBsbQ[140].jVNSvOn9cu8(0, ColorGroup.Unexplored);
		iP0SvjBBsbQ[141].jVNSvOn9cu8(0, ColorGroup.Plant);
		iP0SvjBBsbQ[142].jVNSvOn9cu8(0, ColorGroup.Plant);
		iP0SvjBBsbQ[143].jVNSvOn9cu8(0, ColorGroup.Unexplored);
		iP0SvjBBsbQ[144].jVNSvOn9cu8(0, ColorGroup.Unexplored);
		iP0SvjBBsbQ[145].jVNSvOn9cu8(0, ColorGroup.Metal);
		iP0SvjBBsbQ[146].jVNSvOn9cu8(0, ColorGroup.Wood);
		iP0SvjBBsbQ[147].jVNSvOn9cu8(0, ColorGroup.Gold);
		iP0SvjBBsbQ[148].jVNSvOn9cu8(0, ColorGroup.Metal);
		iP0SvjBBsbQ[149].jVNSvOn9cu8(0, ColorGroup.Unexplored);
		iP0SvjBBsbQ[150].jVNSvOn9cu8(0, ColorGroup.Unexplored);
		iP0SvjBBsbQ[151].jVNSvOn9cu8(0, ColorGroup.Wood);
		iP0SvjBBsbQ[152].jVNSvOn9cu8(0, ColorGroup.Red);
		iP0SvjBBsbQ[153].jVNSvOn9cu8(0, ColorGroup.Netherrack);
		iP0SvjBBsbQ[154].jVNSvOn9cu8(0, ColorGroup.Stone);
		iP0SvjBBsbQ[155].jVNSvOn9cu8(0, ColorGroup.White);
		iP0SvjBBsbQ[156].jVNSvOn9cu8(0, ColorGroup.White);
		iP0SvjBBsbQ[157].jVNSvOn9cu8(0, ColorGroup.Unexplored);
		iP0SvjBBsbQ[158].jVNSvOn9cu8(0, ColorGroup.Stone);
		iP0SvjBBsbQ[159].jVNSvOn9cu8(0, ColorGroup.White);
		iP0SvjBBsbQ[159].jVNSvOn9cu8(1, ColorGroup.Orange);
		iP0SvjBBsbQ[159].jVNSvOn9cu8(2, ColorGroup.Magenta);
		iP0SvjBBsbQ[159].jVNSvOn9cu8(3, ColorGroup.LightBlue);
		iP0SvjBBsbQ[159].jVNSvOn9cu8(4, ColorGroup.Yellow);
		iP0SvjBBsbQ[159].jVNSvOn9cu8(5, ColorGroup.Lime);
		iP0SvjBBsbQ[159].jVNSvOn9cu8(6, ColorGroup.Pink);
		iP0SvjBBsbQ[159].jVNSvOn9cu8(7, ColorGroup.Grey);
		iP0SvjBBsbQ[159].jVNSvOn9cu8(8, ColorGroup.LightGrey);
		iP0SvjBBsbQ[159].jVNSvOn9cu8(9, ColorGroup.Cyan);
		iP0SvjBBsbQ[159].jVNSvOn9cu8(10, ColorGroup.Purple);
		iP0SvjBBsbQ[159].jVNSvOn9cu8(11, ColorGroup.Blue);
		iP0SvjBBsbQ[159].jVNSvOn9cu8(12, ColorGroup.Brown);
		iP0SvjBBsbQ[159].jVNSvOn9cu8(13, ColorGroup.Green);
		iP0SvjBBsbQ[159].jVNSvOn9cu8(14, ColorGroup.Red);
		iP0SvjBBsbQ[159].jVNSvOn9cu8(15, ColorGroup.Black);
		iP0SvjBBsbQ[160].jVNSvOn9cu8(0, ColorGroup.White);
		iP0SvjBBsbQ[160].jVNSvOn9cu8(1, ColorGroup.Orange);
		iP0SvjBBsbQ[160].jVNSvOn9cu8(2, ColorGroup.Magenta);
		iP0SvjBBsbQ[160].jVNSvOn9cu8(3, ColorGroup.LightBlue);
		iP0SvjBBsbQ[160].jVNSvOn9cu8(4, ColorGroup.Yellow);
		iP0SvjBBsbQ[160].jVNSvOn9cu8(5, ColorGroup.Lime);
		iP0SvjBBsbQ[160].jVNSvOn9cu8(6, ColorGroup.Pink);
		iP0SvjBBsbQ[160].jVNSvOn9cu8(7, ColorGroup.Grey);
		iP0SvjBBsbQ[160].jVNSvOn9cu8(8, ColorGroup.LightGrey);
		iP0SvjBBsbQ[160].jVNSvOn9cu8(9, ColorGroup.Cyan);
		iP0SvjBBsbQ[160].jVNSvOn9cu8(10, ColorGroup.Purple);
		iP0SvjBBsbQ[160].jVNSvOn9cu8(11, ColorGroup.Blue);
		iP0SvjBBsbQ[160].jVNSvOn9cu8(12, ColorGroup.Brown);
		iP0SvjBBsbQ[160].jVNSvOn9cu8(13, ColorGroup.Green);
		iP0SvjBBsbQ[160].jVNSvOn9cu8(14, ColorGroup.Red);
		iP0SvjBBsbQ[160].jVNSvOn9cu8(15, ColorGroup.Black);
		iP0SvjBBsbQ[161].jVNSvOn9cu8(0, ColorGroup.Plant);
		iP0SvjBBsbQ[162].jVNSvOn9cu8(0, ColorGroup.Other);
		iP0SvjBBsbQ[163].jVNSvOn9cu8(0, ColorGroup.Orange);
		iP0SvjBBsbQ[164].jVNSvOn9cu8(0, ColorGroup.Brown);
		iP0SvjBBsbQ[165].jVNSvOn9cu8(0, ColorGroup.Lime);
		iP0SvjBBsbQ[166].jVNSvOn9cu8(0, ColorGroup.Unexplored);
		iP0SvjBBsbQ[167].jVNSvOn9cu8(0, ColorGroup.Metal);
		iP0SvjBBsbQ[168].jVNSvOn9cu8(0, ColorGroup.Diamond);
		iP0SvjBBsbQ[169].jVNSvOn9cu8(0, ColorGroup.Diamond);
		iP0SvjBBsbQ[170].jVNSvOn9cu8(0, ColorGroup.Gold);
		iP0SvjBBsbQ[171].jVNSvOn9cu8(0, ColorGroup.White);
		iP0SvjBBsbQ[171].jVNSvOn9cu8(1, ColorGroup.Orange);
		iP0SvjBBsbQ[171].jVNSvOn9cu8(2, ColorGroup.Magenta);
		iP0SvjBBsbQ[171].jVNSvOn9cu8(3, ColorGroup.LightBlue);
		iP0SvjBBsbQ[171].jVNSvOn9cu8(4, ColorGroup.Yellow);
		iP0SvjBBsbQ[171].jVNSvOn9cu8(5, ColorGroup.Lime);
		iP0SvjBBsbQ[171].jVNSvOn9cu8(6, ColorGroup.Pink);
		iP0SvjBBsbQ[171].jVNSvOn9cu8(7, ColorGroup.Grey);
		iP0SvjBBsbQ[171].jVNSvOn9cu8(8, ColorGroup.LightGrey);
		iP0SvjBBsbQ[171].jVNSvOn9cu8(9, ColorGroup.Cyan);
		iP0SvjBBsbQ[171].jVNSvOn9cu8(10, ColorGroup.Purple);
		iP0SvjBBsbQ[171].jVNSvOn9cu8(11, ColorGroup.Blue);
		iP0SvjBBsbQ[171].jVNSvOn9cu8(12, ColorGroup.Brown);
		iP0SvjBBsbQ[171].jVNSvOn9cu8(13, ColorGroup.Green);
		iP0SvjBBsbQ[171].jVNSvOn9cu8(14, ColorGroup.Red);
		iP0SvjBBsbQ[171].jVNSvOn9cu8(15, ColorGroup.Black);
		iP0SvjBBsbQ[172].jVNSvOn9cu8(0, ColorGroup.Orange);
		iP0SvjBBsbQ[173].jVNSvOn9cu8(0, ColorGroup.Black);
		iP0SvjBBsbQ[174].jVNSvOn9cu8(0, ColorGroup.Ice);
		iP0SvjBBsbQ[175].jVNSvOn9cu8(0, ColorGroup.Plant);
		iP0SvjBBsbQ[176].jVNSvOn9cu8(0, ColorGroup.Wood);
		iP0SvjBBsbQ[177].jVNSvOn9cu8(0, ColorGroup.Wood);
		iP0SvjBBsbQ[178].jVNSvOn9cu8(0, ColorGroup.Wood);
		iP0SvjBBsbQ[179].jVNSvOn9cu8(0, ColorGroup.Red);
		iP0SvjBBsbQ[180].jVNSvOn9cu8(0, ColorGroup.Red);
		iP0SvjBBsbQ[181].jVNSvOn9cu8(0, ColorGroup.Red);
		iP0SvjBBsbQ[182].jVNSvOn9cu8(0, ColorGroup.Red);
		iP0SvjBBsbQ[183].jVNSvOn9cu8(0, ColorGroup.Wood);
		iP0SvjBBsbQ[184].jVNSvOn9cu8(0, ColorGroup.Wood);
		iP0SvjBBsbQ[185].jVNSvOn9cu8(0, ColorGroup.Wood);
		iP0SvjBBsbQ[186].jVNSvOn9cu8(0, ColorGroup.Wood);
		iP0SvjBBsbQ[187].jVNSvOn9cu8(0, ColorGroup.Orange);
		iP0SvjBBsbQ[188].jVNSvOn9cu8(0, ColorGroup.Wood);
		iP0SvjBBsbQ[189].jVNSvOn9cu8(0, ColorGroup.Wood);
		iP0SvjBBsbQ[190].jVNSvOn9cu8(0, ColorGroup.Wood);
		iP0SvjBBsbQ[191].jVNSvOn9cu8(0, ColorGroup.Brown);
		iP0SvjBBsbQ[192].jVNSvOn9cu8(0, ColorGroup.Brown);
		iP0SvjBBsbQ[193].jVNSvOn9cu8(0, ColorGroup.Obsidian);
		iP0SvjBBsbQ[194].jVNSvOn9cu8(0, ColorGroup.Sand);
		iP0SvjBBsbQ[195].jVNSvOn9cu8(0, ColorGroup.Dirt);
		iP0SvjBBsbQ[196].jVNSvOn9cu8(0, ColorGroup.Orange);
		iP0SvjBBsbQ[197].jVNSvOn9cu8(0, ColorGroup.Brown);
		iP0SvjBBsbQ[198].jVNSvOn9cu8(0, ColorGroup.Unexplored);
		iP0SvjBBsbQ[199].jVNSvOn9cu8(0, ColorGroup.Purple);
		iP0SvjBBsbQ[200].jVNSvOn9cu8(0, ColorGroup.Purple);
		iP0SvjBBsbQ[201].jVNSvOn9cu8(0, ColorGroup.Purple);
		iP0SvjBBsbQ[202].jVNSvOn9cu8(0, ColorGroup.Purple);
		iP0SvjBBsbQ[203].jVNSvOn9cu8(0, ColorGroup.Purple);
		iP0SvjBBsbQ[204].jVNSvOn9cu8(0, ColorGroup.Purple);
		iP0SvjBBsbQ[205].jVNSvOn9cu8(0, ColorGroup.Purple);
		iP0SvjBBsbQ[206].jVNSvOn9cu8(0, ColorGroup.Lime);
		iP0SvjBBsbQ[207].jVNSvOn9cu8(0, ColorGroup.Plant);
		iP0SvjBBsbQ[208].jVNSvOn9cu8(0, ColorGroup.Grass);
		iP0SvjBBsbQ[209].jVNSvOn9cu8(0, ColorGroup.Other);
		iP0SvjBBsbQ[210].jVNSvOn9cu8(0, ColorGroup.Purple);
		iP0SvjBBsbQ[211].jVNSvOn9cu8(0, ColorGroup.Green);
		iP0SvjBBsbQ[212].jVNSvOn9cu8(0, ColorGroup.Ice);
		iP0SvjBBsbQ[213].jVNSvOn9cu8(0, ColorGroup.Lava);
		iP0SvjBBsbQ[214].jVNSvOn9cu8(0, ColorGroup.Netherrack);
		iP0SvjBBsbQ[215].jVNSvOn9cu8(0, ColorGroup.Netherrack);
		iP0SvjBBsbQ[216].jVNSvOn9cu8(0, ColorGroup.White);
		iP0SvjBBsbQ[217].jVNSvOn9cu8(0, ColorGroup.Unexplored);
		iP0SvjBBsbQ[218].jVNSvOn9cu8(0, ColorGroup.Stone);
		iP0SvjBBsbQ[219].jVNSvOn9cu8(0, ColorGroup.White);
		iP0SvjBBsbQ[220].jVNSvOn9cu8(0, ColorGroup.Orange);
		iP0SvjBBsbQ[221].jVNSvOn9cu8(0, ColorGroup.Magenta);
		iP0SvjBBsbQ[222].jVNSvOn9cu8(0, ColorGroup.LightBlue);
		iP0SvjBBsbQ[223].jVNSvOn9cu8(0, ColorGroup.Yellow);
		iP0SvjBBsbQ[224].jVNSvOn9cu8(0, ColorGroup.Lime);
		iP0SvjBBsbQ[225].jVNSvOn9cu8(0, ColorGroup.Pink);
		iP0SvjBBsbQ[226].jVNSvOn9cu8(0, ColorGroup.Grey);
		iP0SvjBBsbQ[227].jVNSvOn9cu8(0, ColorGroup.LightGrey);
		iP0SvjBBsbQ[228].jVNSvOn9cu8(0, ColorGroup.Cyan);
		iP0SvjBBsbQ[229].jVNSvOn9cu8(0, ColorGroup.Purple);
		iP0SvjBBsbQ[230].jVNSvOn9cu8(0, ColorGroup.Blue);
		iP0SvjBBsbQ[231].jVNSvOn9cu8(0, ColorGroup.Brown);
		iP0SvjBBsbQ[232].jVNSvOn9cu8(0, ColorGroup.Green);
		iP0SvjBBsbQ[233].jVNSvOn9cu8(0, ColorGroup.Red);
		iP0SvjBBsbQ[234].jVNSvOn9cu8(0, ColorGroup.Black);
		iP0SvjBBsbQ[252].jVNSvOn9cu8(0, ColorGroup.LightGrey);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int BlockToColorIndex(int blockId, int data)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return BlockToColorIndex(blockId, data, 0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int BlockToColorIndex(int blockId, int data, int level)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (level < 0 || level >= jkrSv8415DI)
		{
			throw new ArgumentOutOfRangeException(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(73132), level, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(73146) + (jkrSv8415DI - 1) + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20542));
		}
		if (blockId < 0 || blockId >= 4096)
		{
			throw new ArgumentOutOfRangeException(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(73226));
		}
		return (int)iP0SvjBBsbQ[blockId].GetColorIndex(data) * jkrSv8415DI + level;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Color BlockToColor(int blockId, int data)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return BlockToColor(blockId, data, 0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Color BlockToColor(int blockId, int data, int level)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = BlockToColorIndex(blockId, data, level);
		if (num < 0 || num >= 256)
		{
			throw new InvalidOperationException(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(73244));
		}
		return OYuSvFDKRXE[num];
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ColorGroup ColorIndexToGroup(int colorIndex)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int result = colorIndex / jkrSv8415DI;
		try
		{
			return (ColorGroup)result;
		}
		catch
		{
			return ColorGroup.Other;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GroupToColorIndex(ColorGroup group)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return GroupToColorIndex(group, 0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GroupToColorIndex(ColorGroup group, int level)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (level < 0 || level >= jkrSv8415DI)
		{
			throw new ArgumentOutOfRangeException(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(73132), level, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(73146) + (jkrSv8415DI - 1) + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20542));
		}
		return (int)group * jkrSv8415DI + level;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Color GroupToColor(ColorGroup group)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return GroupToColor(group, 0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Color GroupToColor(ColorGroup group, int level)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = GroupToColorIndex(group, level);
		if (num < 0 || num >= 256)
		{
			throw new InvalidOperationException(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(73360));
		}
		return OYuSvFDKRXE[num];
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RefreshColorCache()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		for (int i = 0; i < OYuSvFDKRXE.Length; i++)
		{
			zJ5Sv9KMhEf[i] = TyKSvdf7Nnh(OYuSvFDKRXE[i]);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int NearestColorIndex(Color color)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		double num = double.MaxValue;
		int result = 0;
		Vector3 vector = TyKSvdf7Nnh(color);
		for (int i = 0; i < OYuSvFDKRXE.Length; i++)
		{
			if (OYuSvFDKRXE[i].A != 0)
			{
				double num2 = vector.X - zJ5Sv9KMhEf[i].X;
				double num3 = vector.Y - zJ5Sv9KMhEf[i].Y;
				double num4 = vector.Z - zJ5Sv9KMhEf[i].Z;
				double num5 = num2 * num2 + num3 * num3 + num4 * num4;
				if (num5 < num)
				{
					num = num5;
					result = i;
				}
			}
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Color NearestColor(Color color)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return OYuSvFDKRXE[NearestColorIndex(color)];
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void BitmapToMap(Map map, Bitmap bmp)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (map.Width != bmp.Width || map.Height != bmp.Height)
		{
			throw new InvalidOperationException(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(73470));
		}
		for (int i = 0; i < map.Width; i++)
		{
			for (int j = 0; j < map.Height; j++)
			{
				Color pixel = bmp.GetPixel(i, j);
				byte value = 0;
				if (pixel.A > 0)
				{
					value = (byte)NearestColorIndex(pixel);
				}
				map[i, j] = value;
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Bitmap MapToBitmap(TagNodeCompound rawMap)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Map map = new Map();
		map.LoadTree(rawMap);
		Bitmap bitmap = new Bitmap(map.Width, map.Height, PixelFormat.Format32bppArgb);
		for (int i = 0; i < map.Width; i++)
		{
			for (int j = 0; j < map.Height; j++)
			{
				Color color = OYuSvFDKRXE[map[i, j]];
				bitmap.SetPixel(i, j, color);
			}
		}
		return bitmap;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Bitmap ConvertBitmap(Bitmap inBmp)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Bitmap bitmap = new Bitmap(inBmp.Width, inBmp.Height, PixelFormat.Format32bppArgb);
		for (int i = 0; i < inBmp.Width; i++)
		{
			for (int j = 0; j < inBmp.Height; j++)
			{
				Color pixel = inBmp.GetPixel(i, j);
				byte b = 0;
				if (pixel.A > 0)
				{
					b = (byte)NearestColorIndex(pixel);
				}
				pixel = OYuSvFDKRXE[b];
				bitmap.SetPixel(i, j, pixel);
			}
		}
		return bitmap;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Vector3 ISUSv77UCRy(Color P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		double num = (double)(int)P_0.R / 255.0;
		double num2 = (double)(int)P_0.G / 255.0;
		double num3 = (double)(int)P_0.B / 255.0;
		num = ((num > 0.04045) ? Math.Pow((num + 0.055) / 1.055, 2.4) : (num / 12.92));
		num2 = ((num2 > 0.04045) ? Math.Pow((num2 + 0.055) / 1.055, 2.4) : (num2 / 12.92));
		num3 = ((num3 > 0.04045) ? Math.Pow((num3 + 0.055) / 1.055, 2.4) : (num3 / 12.92));
		num *= 100.0;
		num2 *= 100.0;
		num3 *= 100.0;
		Vector3 vector = new Vector3();
		vector.X = num * 0.4124 + num2 * 0.3576 + num3 * 0.1805;
		vector.Y = num * 0.2126 + num2 * 0.7152 + num3 * 0.0722;
		vector.Z = num * 0.0193 + num2 * 0.1192 + num3 * 0.9505;
		return vector;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Vector3 fySSvA70KXB(Vector3 P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		double num = P_0.X / 95.047;
		double num2 = P_0.Y / 100.0;
		double num3 = P_0.Z / 108.883;
		num = ((num > 0.008856) ? Math.Pow(num, 1.0 / 3.0) : (7.787 * num + 0.13793103448275862));
		num2 = ((num2 > 0.008856) ? Math.Pow(num2, 1.0 / 3.0) : (7.787 * num2 + 0.13793103448275862));
		num3 = ((num3 > 0.008856) ? Math.Pow(num3, 1.0 / 3.0) : (7.787 * num3 + 0.13793103448275862));
		Vector3 vector = new Vector3();
		vector.X = 116.0 * num2 - 16.0;
		vector.Y = 500.0 * (num - num2);
		vector.Z = 200.0 * (num2 - num3);
		return vector;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Vector3 TyKSvdf7Nnh(Color P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return fySSvA70KXB(ISUSv77UCRy(P_0));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MapConverterII()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		HFPSvHaEsQG = new Color[144]
		{
			Color.FromArgb(0, 0, 0, 0),
			Color.FromArgb(0, 0, 0, 0),
			Color.FromArgb(0, 0, 0, 0),
			Color.FromArgb(0, 0, 0, 0),
			Color.FromArgb(88, 124, 39),
			Color.FromArgb(108, 151, 47),
			Color.FromArgb(125, 176, 55),
			Color.FromArgb(66, 93, 29),
			Color.FromArgb(172, 162, 114),
			Color.FromArgb(210, 199, 138),
			Color.FromArgb(244, 230, 161),
			Color.FromArgb(128, 122, 85),
			Color.FromArgb(138, 138, 138),
			Color.FromArgb(169, 169, 169),
			Color.FromArgb(197, 197, 197),
			Color.FromArgb(104, 104, 104),
			Color.FromArgb(178, 0, 0),
			Color.FromArgb(217, 0, 0),
			Color.FromArgb(252, 0, 0),
			Color.FromArgb(133, 0, 0),
			Color.FromArgb(111, 111, 178),
			Color.FromArgb(136, 136, 217),
			Color.FromArgb(158, 158, 252),
			Color.FromArgb(83, 83, 133),
			Color.FromArgb(116, 116, 116),
			Color.FromArgb(142, 142, 142),
			Color.FromArgb(165, 165, 165),
			Color.FromArgb(87, 87, 87),
			Color.FromArgb(0, 86, 0),
			Color.FromArgb(0, 105, 0),
			Color.FromArgb(0, 123, 0),
			Color.FromArgb(0, 64, 0),
			Color.FromArgb(178, 178, 178),
			Color.FromArgb(217, 217, 217),
			Color.FromArgb(252, 252, 252),
			Color.FromArgb(133, 133, 133),
			Color.FromArgb(114, 117, 127),
			Color.FromArgb(139, 142, 156),
			Color.FromArgb(162, 166, 182),
			Color.FromArgb(85, 87, 96),
			Color.FromArgb(105, 75, 53),
			Color.FromArgb(128, 93, 65),
			Color.FromArgb(149, 108, 76),
			Color.FromArgb(78, 56, 39),
			Color.FromArgb(78, 78, 78),
			Color.FromArgb(95, 95, 95),
			Color.FromArgb(111, 111, 111),
			Color.FromArgb(58, 58, 58),
			Color.FromArgb(44, 44, 178),
			Color.FromArgb(54, 54, 217),
			Color.FromArgb(63, 63, 252),
			Color.FromArgb(33, 33, 133),
			Color.FromArgb(99, 83, 49),
			Color.FromArgb(122, 101, 61),
			Color.FromArgb(141, 118, 71),
			Color.FromArgb(74, 62, 38),
			Color.FromArgb(178, 175, 170),
			Color.FromArgb(217, 214, 208),
			Color.FromArgb(252, 249, 242),
			Color.FromArgb(133, 131, 127),
			Color.FromArgb(150, 88, 36),
			Color.FromArgb(184, 108, 43),
			Color.FromArgb(213, 125, 50),
			Color.FromArgb(113, 66, 27),
			Color.FromArgb(124, 52, 150),
			Color.FromArgb(151, 64, 184),
			Color.FromArgb(176, 75, 213),
			Color.FromArgb(93, 39, 113),
			Color.FromArgb(71, 107, 150),
			Color.FromArgb(87, 130, 184),
			Color.FromArgb(101, 151, 213),
			Color.FromArgb(53, 80, 113),
			Color.FromArgb(159, 159, 36),
			Color.FromArgb(195, 195, 43),
			Color.FromArgb(226, 226, 50),
			Color.FromArgb(120, 120, 27),
			Color.FromArgb(88, 142, 17),
			Color.FromArgb(108, 174, 21),
			Color.FromArgb(125, 202, 25),
			Color.FromArgb(66, 107, 13),
			Color.FromArgb(168, 88, 115),
			Color.FromArgb(206, 108, 140),
			Color.FromArgb(239, 125, 163),
			Color.FromArgb(126, 66, 86),
			Color.FromArgb(52, 52, 52),
			Color.FromArgb(64, 64, 64),
			Color.FromArgb(75, 75, 75),
			Color.FromArgb(39, 39, 39),
			Color.FromArgb(107, 107, 107),
			Color.FromArgb(130, 130, 130),
			Color.FromArgb(151, 151, 151),
			Color.FromArgb(80, 80, 80),
			Color.FromArgb(52, 88, 107),
			Color.FromArgb(64, 108, 130),
			Color.FromArgb(75, 125, 151),
			Color.FromArgb(39, 66, 80),
			Color.FromArgb(88, 43, 124),
			Color.FromArgb(108, 53, 151),
			Color.FromArgb(125, 62, 176),
			Color.FromArgb(66, 33, 93),
			Color.FromArgb(36, 52, 124),
			Color.FromArgb(43, 64, 151),
			Color.FromArgb(50, 75, 176),
			Color.FromArgb(27, 39, 93),
			Color.FromArgb(71, 52, 36),
			Color.FromArgb(87, 64, 43),
			Color.FromArgb(101, 75, 50),
			Color.FromArgb(53, 39, 27),
			Color.FromArgb(71, 88, 36),
			Color.FromArgb(87, 108, 43),
			Color.FromArgb(101, 125, 50),
			Color.FromArgb(53, 66, 27),
			Color.FromArgb(107, 36, 36),
			Color.FromArgb(130, 43, 43),
			Color.FromArgb(151, 50, 50),
			Color.FromArgb(80, 27, 27),
			Color.FromArgb(17, 17, 17),
			Color.FromArgb(21, 21, 21),
			Color.FromArgb(25, 25, 25),
			Color.FromArgb(13, 13, 13),
			Color.FromArgb(174, 166, 53),
			Color.FromArgb(212, 203, 65),
			Color.FromArgb(247, 235, 76),
			Color.FromArgb(130, 125, 39),
			Color.FromArgb(63, 152, 148),
			Color.FromArgb(78, 186, 181),
			Color.FromArgb(91, 216, 210),
			Color.FromArgb(47, 114, 111),
			Color.FromArgb(51, 89, 178),
			Color.FromArgb(62, 109, 217),
			Color.FromArgb(73, 129, 252),
			Color.FromArgb(39, 66, 133),
			Color.FromArgb(0, 151, 39),
			Color.FromArgb(0, 185, 49),
			Color.FromArgb(0, 214, 57),
			Color.FromArgb(0, 113, 30),
			Color.FromArgb(90, 59, 34),
			Color.FromArgb(110, 73, 41),
			Color.FromArgb(127, 85, 48),
			Color.FromArgb(67, 44, 25),
			Color.FromArgb(78, 1, 0),
			Color.FromArgb(95, 1, 0),
			Color.FromArgb(111, 2, 0),
			Color.FromArgb(58, 1, 0)
		};
	}
}
