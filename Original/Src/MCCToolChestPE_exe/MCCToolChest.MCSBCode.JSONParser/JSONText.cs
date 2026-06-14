using System;
using System.Runtime.CompilerServices;
using System.Web.Script.Serialization;
using MCCToolChest.model;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.MCSBCode.JSONParser;

public class JSONText
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public string ParseJSONText(string jsonTxt)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string result = "";
		try
		{
			JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
			SignText signText = javaScriptSerializer.Deserialize<SignText>(jsonTxt);
			result = signText.ToConsole();
		}
		catch (Exception)
		{
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public JSONText()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}
}
