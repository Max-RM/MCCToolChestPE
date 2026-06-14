using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using MCCToolChest.model;
using MCCToolChest.workers;
using MCCToolChestDB.Model;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace ceSmgmuGAR2IorKvvso;

internal class SNBte6usOpaAUe38VsS
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void DuRSYcMp4UC(List<string> P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string arg = JsonDataConversion.Serialize(P_0);
		string text = string.Format(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(246722), arg);
		Uri uri = new Uri(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(246744) + text);
		GWsSYONRsOe(uri);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void MJuSYJ0uex5(List<string> P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string arg = JsonDataConversion.Serialize(P_0);
		string text = string.Format(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(246722), arg);
		Uri uri = new Uri(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(246850) + text);
		GWsSYONRsOe(uri);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void TGNSYuMDruS(List<BedrockBlockState> P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = JsonDataConversion.Serialize(P_0);
		string.Format(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(246722), text);
		fUcSYQoLlOM(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(246962), text);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void ad0SYoOd8A5(ConversionCount P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		try
		{
			string text = JsonDataConversion.Serialize(P_0);
			fUcSYQoLlOM(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247084), text);
		}
		catch (Exception)
		{
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void fUcSYQoLlOM(string P_0, string P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		using WebClient webClient = new WebClient();
		webClient.Headers[HttpRequestHeader.ContentType] = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247200);
		webClient.UploadString(P_0, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(247236), P_1);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void GWsSYONRsOe(Uri P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(P_0);
		httpWebRequest.Method = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(246570);
		httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
		HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
		_ = string.Empty;
		using Stream stream = httpWebResponse.GetResponseStream();
		using StreamReader streamReader = new StreamReader(stream);
		streamReader.ReadToEnd();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SNBte6usOpaAUe38VsS()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}
}
