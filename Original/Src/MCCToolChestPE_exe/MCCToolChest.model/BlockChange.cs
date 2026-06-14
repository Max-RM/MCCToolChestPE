using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web.Script.Serialization;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.model;

public class BlockChange
{
	private int InQSBUh1L6j;

	private List<int> ernSBLnCL5u;

	private int fOWSBgMQRUv;

	private int M7cSBPn90EW;

	private int emwSBRDBX2V;

	private List<int> MpASBkXIXiF;

	private int IxiSBYRLtVa;

	private int mNdSB34KiJO;

	public int FromBlock
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return InQSBUh1L6j;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			InQSBUh1L6j = value;
		}
	}

	public List<int> FromData
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return ernSBLnCL5u;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			ernSBLnCL5u = value;
		}
	}

	public int ToBlock
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return fOWSBgMQRUv;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			fOWSBgMQRUv = value;
		}
	}

	public int ToData
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return M7cSBPn90EW;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			M7cSBPn90EW = value;
		}
	}

	public int ToBlockLight
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return emwSBRDBX2V;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			emwSBRDBX2V = value;
		}
	}

	public List<int> Layers
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return MpASBkXIXiF;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			MpASBkXIXiF = value;
		}
	}

	public int Layer2Block
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return IxiSBYRLtVa;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			IxiSBYRLtVa = value;
		}
	}

	public int Layer2Data
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return mNdSB34KiJO;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			mNdSB34KiJO = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string ToString()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return InQSBUh1L6j + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40710) + ypZSBepiwOK() + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40710) + fOWSBgMQRUv + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40710) + M7cSBPn90EW + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40710) + emwSBRDBX2V + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40710) + IxiSBYRLtVa + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40710) + mNdSB34KiJO + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10366) + ISwSBxdcAOo() + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(189678);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static BlockChange FromString(string changeStr)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BlockChange blockChange = null;
		string[] array = changeStr.Split('*');
		string[] array2 = array[0].Split(',');
		if (array2.Length >= 4)
		{
			int result = 0;
			int result2 = 0;
			int result3 = 0;
			int result4 = -1;
			int result5 = 0;
			int result6 = 0;
			int.TryParse(array2[0], out result);
			List<int> list = RnZSBMRmYaF(array2[1], ':');
			int.TryParse(array2[2], out result2);
			int.TryParse(array2[3], out result3);
			if (array2.Length == 5)
			{
				int.TryParse(array2[4], out result4);
			}
			if (array2.Length == 7)
			{
				int.TryParse(array2[5], out result5);
				int.TryParse(array2[6], out result6);
			}
			BlockChange blockChange2 = new BlockChange();
			blockChange2.FromBlock = result;
			blockChange2.ernSBLnCL5u = list;
			blockChange2.ToBlock = result2;
			blockChange2.ToData = result3;
			blockChange2.ToBlockLight = result4;
			blockChange2.Layer2Block = result5;
			blockChange2.Layer2Data = result6;
			blockChange = blockChange2;
			if (array.Length > 1)
			{
				blockChange.Layers = RnZSBMRmYaF(array[1], ',');
			}
			else
			{
				blockChange.Layers.Add(-1);
			}
		}
		return blockChange;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string ISwSBxdcAOo()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		StringBuilder stringBuilder = new StringBuilder();
		foreach (int item in MpASBkXIXiF)
		{
			stringBuilder.Append((stringBuilder.Length > 0) ? (Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40710) + item) : item.ToString());
		}
		return stringBuilder.ToString();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string ypZSBepiwOK()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		StringBuilder stringBuilder = new StringBuilder();
		foreach (int item in ernSBLnCL5u)
		{
			stringBuilder.Append((stringBuilder.Length > 0) ? (Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(12654) + item) : item.ToString());
		}
		return stringBuilder.ToString();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static List<int> RnZSBMRmYaF(string P_0, char P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<int> list = new List<int>();
		int result = 0;
		string[] array = P_0.Split(P_1);
		string[] array2 = array;
		foreach (string text in array2)
		{
			if (int.TryParse(text.Trim(), out result))
			{
				list.Add(result);
			}
		}
		return list;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<BlockChange> DeserializeJSON(string jsonData)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<BlockChange> list = null;
		try
		{
			JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
			return javaScriptSerializer.Deserialize<List<BlockChange>>(jsonData);
		}
		catch (Exception)
		{
			throw;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BlockChange()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		ernSBLnCL5u = new List<int> { -1 };
		emwSBRDBX2V = -1;
		MpASBkXIXiF = new List<int> { -1 };
	}
}
