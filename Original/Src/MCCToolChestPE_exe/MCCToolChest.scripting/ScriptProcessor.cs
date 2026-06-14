using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.model;
using MCCToolChest.utils;
using MCCToolChest.workers;
using Microsoft.ClearScript.V8;
using Microsoft.CSharp.RuntimeBinder;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.scripting;

public class ScriptProcessor
{
	[CompilerGenerated]
	private static class _003CProcess_003Eo__SiteContainer0
	{
		public static CallSite<Action<CallSite, object, string, string, string>> _003C_003Ep__Site1;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__Site2;
	}

	[CompilerGenerated]
	private static class _003CExecuteCommand_003Eo__SiteContainer3
	{
		public static CallSite<Action<CallSite, object, string>> _003C_003Ep__Site4;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__Site5;
	}

	private BackgroundWorker lEISgRluraa;

	private static string oNUSgkpgCU4;

	private V8ScriptEngine NHXSgYkcckQ;

	private string pA7Sg3Nkg1H;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptProcessor()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		pA7Sg3Nkg1H = "";
		KC4SgUrUDMe();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptProcessor(BackgroundWorker bw)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		pA7Sg3Nkg1H = "";
		KC4SgUrUDMe();
		lEISgRluraa = bw;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void KC4SgUrUDMe()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (oNUSgkpgCU4 == null)
		{
			oNUSgkpgCU4 = EmbeddedUtils.GetResource(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(214220));
		}
		NHXSgYkcckQ = new V8ScriptEngine(V8ScriptEngineFlags.EnableDebugging);
		KFySgLYA5oG(NHXSgYkcckQ);
		NHXSgYkcckQ.Evaluate(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(214274), oNUSgkpgCU4);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public object Process(string name, string script)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		object result = null;
		try
		{
			if (_003CProcess_003Eo__SiteContainer0._003C_003Ep__Site1 == null)
			{
				_003CProcess_003Eo__SiteContainer0._003C_003Ep__Site1 = CallSite<Action<CallSite, object, string, string, string>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(214288), null, typeof(ScriptProcessor), new CSharpArgumentInfo[4]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
				}));
			}
			Action<CallSite, object, string, string, string> target = _003CProcess_003Eo__SiteContainer0._003C_003Ep__Site1.Target;
			CallSite<Action<CallSite, object, string, string, string>> _003C_003Ep__Site = _003CProcess_003Eo__SiteContainer0._003C_003Ep__Site1;
			if (_003CProcess_003Eo__SiteContainer0._003C_003Ep__Site2 == null)
			{
				_003CProcess_003Eo__SiteContainer0._003C_003Ep__Site2 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(212562), typeof(ScriptProcessor), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			target(_003C_003Ep__Site, _003CProcess_003Eo__SiteContainer0._003C_003Ep__Site2.Target(_003CProcess_003Eo__SiteContainer0._003C_003Ep__Site2, (object)NHXSgYkcckQ.Script), pA7Sg3Nkg1H, Utils.ScriptPath(), Utils.OutputPath());
			result = NHXSgYkcckQ.Evaluate(name, script);
			ScriptDBWorker.CheckBatch(force: true);
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public object ExecuteCommand(string script)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		object result = null;
		try
		{
			if (_003CExecuteCommand_003Eo__SiteContainer3._003C_003Ep__Site4 == null)
			{
				_003CExecuteCommand_003Eo__SiteContainer3._003C_003Ep__Site4 = CallSite<Action<CallSite, object, string>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(214288), null, typeof(ScriptProcessor), new CSharpArgumentInfo[2]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
				}));
			}
			Action<CallSite, object, string> target = _003CExecuteCommand_003Eo__SiteContainer3._003C_003Ep__Site4.Target;
			CallSite<Action<CallSite, object, string>> _003C_003Ep__Site = _003CExecuteCommand_003Eo__SiteContainer3._003C_003Ep__Site4;
			if (_003CExecuteCommand_003Eo__SiteContainer3._003C_003Ep__Site5 == null)
			{
				_003CExecuteCommand_003Eo__SiteContainer3._003C_003Ep__Site5 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(212562), typeof(ScriptProcessor), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			target(_003C_003Ep__Site, _003CExecuteCommand_003Eo__SiteContainer3._003C_003Ep__Site5.Target(_003CExecuteCommand_003Eo__SiteContainer3._003C_003Ep__Site5, (object)NHXSgYkcckQ.Script), pA7Sg3Nkg1H);
			result = NHXSgYkcckQ.ExecuteCommand(script);
			ScriptDBWorker.CheckBatch(force: true);
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void KFySgLYA5oG(V8ScriptEngine P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		QBPSgPadeIT();
		ScriptHelpers target = new ScriptHelpers(e01SggmXw77);
		P_0.AddHostObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(214274), target);
		P_0.AddHostType(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(214310), typeof(File));
		P_0.AddHostType(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(214322), typeof(Directory));
		P_0.AllowReflection = true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void e01SggmXw77(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (lEISgRluraa != null)
		{
			lEISgRluraa.ReportProgress(0, P_0);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private World QBPSgPadeIT()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		World world = new World();
		List<PEDimension> pEDimensions = Working.PEDimensions;
		foreach (PEDimension item in pEDimensions)
		{
			string text = Constants.scriptDimensionNames[item.Dimension];
			Dimension dimension = new Dimension();
			dimension.id = text;
			foreach (string key in item.Region.Keys)
			{
				PERegion pERegion = item.Region[key];
				Region region = new Region(text, pERegion.RX, pERegion.RZ, pERegion.Chunks);
				region.dimension = text;
				dimension.region.Add(region);
			}
			if (text == Constants.scriptDimensionNames[0])
			{
				world.overworld = dimension;
			}
			else if (text == Constants.scriptDimensionNames[1])
			{
				world.nether = dimension;
			}
			else if (text == Constants.scriptDimensionNames[2])
			{
				world.theend = dimension;
			}
		}
		pA7Sg3Nkg1H = JsonDataConversion.Serialize(world);
		return world;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ScriptProcessor()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}
}
