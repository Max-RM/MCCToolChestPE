using System;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web.Script.Serialization;
using MCCToolChest.model;
using MCCToolChest.PECode;
using MCCToolChest.workers;
using MCPELevelDBI.workers;
using Microsoft.CSharp.RuntimeBinder;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.scripting;

public class ScriptHelpers
{
	[CompilerGenerated]
	private static class _003CParseChunkData_003Eo__SiteContainer0
	{
		public static CallSite<Func<CallSite, object, TagNode>> _003C_003Ep__Site1;

		public static CallSite<Func<CallSite, ScriptHelperJSNBTParser, object, object, object>> _003C_003Ep__Site2;

		public static CallSite<Func<CallSite, object, string, object>> _003C_003Ep__Site3;
	}

	private Logger ej0SgZwRsgG;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptHelpers(Logger logger)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		ej0SgZwRsgG = logger;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string loadChunk(string dimension, int x, int z)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int dimension2 = tUXSgWSlN6b(dimension);
		LevelDBWorker levelDBWorker = PEUtility.OpenDBWorker(Working.T92StMGt1p4());
		ScriptHelperWorker scriptHelperWorker = new ScriptHelperWorker();
		string text = scriptHelperWorker.ReadEntities(dimension2, x, z, levelDBWorker);
		string text2 = scriptHelperWorker.ReadTileEntities(dimension2, x, z, levelDBWorker);
		levelDBWorker.CloseDB();
		return Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(213876) + dimension + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(213908) + x + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(213924) + z + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(213938) + text + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(213968) + text2 + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63868);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string loadChunkEntities(int dimension, int x, int z)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LevelDBWorker levelDBWorker = PEUtility.OpenDBWorker(Working.T92StMGt1p4());
		ScriptHelperWorker scriptHelperWorker = new ScriptHelperWorker();
		string text = scriptHelperWorker.ReadEntities(dimension, x, z, null);
		levelDBWorker.CloseDB();
		return Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(213876) + dimension + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(213908) + x.ToString() + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(213924) + z.ToString() + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(214006) + text + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(214038);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string loadChunkBlockEntities(int dimension, int x, int z)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LevelDBWorker levelDBWorker = PEUtility.OpenDBWorker(Working.T92StMGt1p4());
		ScriptHelperWorker scriptHelperWorker = new ScriptHelperWorker();
		string text = scriptHelperWorker.ReadEntities(dimension, x, z, null);
		levelDBWorker.CloseDB();
		return Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(213876) + dimension + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(213908) + x.ToString() + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(213924) + z.ToString() + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(214046) + text + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(214038);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SaveNBTData(string metaData, string data)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
		KeyData keyData = null;
		TagNode tagNode = null;
		if (metaData != null)
		{
			keyData = javaScriptSerializer.Deserialize<KeyData>(metaData);
		}
		tagNode = mYiSgpMXEiV(data, javaScriptSerializer);
		if (keyData != null && tagNode != null)
		{
			ScriptDBWorker scriptDBWorker = new ScriptDBWorker();
			int dimension = tUXSgWSlN6b(keyData.dimension);
			if (keyData.dataType == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(214086))
			{
				scriptDBWorker.WriteTileEntities(dimension, keyData.x, keyData.z, (TagNodeList)tagNode);
			}
			else if (keyData.dataType == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(54980))
			{
				scriptDBWorker.WriteEntities(dimension, keyData.x, keyData.z, (TagNodeList)tagNode);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int tUXSgWSlN6b(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int result = 0;
		if (Constants.scriptDimensionXref.ContainsKey(P_0))
		{
			result = Constants.scriptDimensionXref[P_0];
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TagNode mYiSgpMXEiV(string P_0, JavaScriptSerializer P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		TagNode result = null;
		if (P_0 != null)
		{
			dynamic val = P_1.Deserialize<object>(P_0);
			ScriptHelperJSNBTParser arg = new ScriptHelperJSNBTParser();
			if (_003CParseChunkData_003Eo__SiteContainer0._003C_003Ep__Site2 == null)
			{
				_003CParseChunkData_003Eo__SiteContainer0._003C_003Ep__Site2 = CallSite<Func<CallSite, ScriptHelperJSNBTParser, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(213848), null, typeof(ScriptHelpers), new CSharpArgumentInfo[3]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			result = (dynamic)_003CParseChunkData_003Eo__SiteContainer0._003C_003Ep__Site2.Target(_003CParseChunkData_003Eo__SiteContainer0._003C_003Ep__Site2, arg, (object)val[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17982)], (object)val);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string showDialog(string ui)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ScriptUI scriptUI = JsonDataConversion.Deserialize<ScriptUI>(ui);
		ScriptDataEntry scriptDataEntry = new ScriptDataEntry(scriptUI);
		scriptDataEntry.ShowDialog();
		UIResult uiResult = scriptDataEntry.uiResult;
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63862));
		stringBuilder.AppendFormat(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(214114), uiResult.status);
		for (int i = 0; i < uiResult.items.Count; i++)
		{
			stringBuilder.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40710));
			stringBuilder.AppendFormat(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(214146), uiResult.items[i].id, uiResult.items[i].value);
		}
		stringBuilder.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(63868));
		return stringBuilder.ToString();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void log(string msg)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (ej0SgZwRsgG != null)
		{
			ej0SgZwRsgG(msg);
		}
	}
}
