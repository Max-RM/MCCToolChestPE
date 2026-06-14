using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Microsoft.ClearScript.Util.Web;

internal sealed class WebContext
{
	public WebRequest Request { get; private set; }

	public WebResponse Response { get; private set; }

	private WebContext(Socket socket, Uri uri, NameValueCollection headers)
	{
		Request = new WebRequest(uri, headers);
		Response = new WebResponse(socket, 200);
	}

	public static async Task<WebContext> CreateAsync(Socket socket)
	{
		try
		{
			List<string> lines = new List<string>();
			while (true)
			{
				string text = await socket.ReceiveLineAsync().ConfigureAwait(continueOnCapturedContext: false);
				if (text.Length < 1)
				{
					break;
				}
				lines.Add(text);
			}
			if (lines.Count < 1)
			{
				throw new InvalidDataException("HTTP request line not found");
			}
			string[] array = lines[0].Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			if (array.Length < 2)
			{
				throw new InvalidDataException("Malformed HTTP request line");
			}
			string value = array[0].Trim().ToUpperInvariant();
			if (!WebRequest.Methods.Contains(value))
			{
				throw new InvalidDataException("Unrecognized HTTP method");
			}
			string text2 = array[1].Trim();
			if (string.IsNullOrEmpty(text2))
			{
				throw new InvalidDataException("Invalid HTTP request URI");
			}
			NameValueCollection nameValueCollection = new NameValueCollection(StringComparer.OrdinalIgnoreCase);
			for (int i = 1; i < lines.Count; i++)
			{
				string text3 = lines[i];
				int num = text3.IndexOf(':');
				if (num < 0)
				{
					throw new InvalidDataException("Malformed HTTP header line");
				}
				string text4 = text3.Substring(0, num).Trim();
				if (string.IsNullOrEmpty(text4))
				{
					throw new InvalidDataException("Malformed HTTP header line");
				}
				string value2 = text3.Substring(num + 1).Trim();
				if (string.IsNullOrEmpty(value2))
				{
					throw new InvalidDataException("Malformed HTTP header line");
				}
				nameValueCollection[text4] = value2;
			}
			string text5 = null;
			int num2 = -1;
			string text6 = nameValueCollection.Get("Host");
			if (!string.IsNullOrEmpty(text6))
			{
				int num3 = text6.IndexOf(':');
				if (num3 < 0)
				{
					text5 = text6.Trim();
				}
				else
				{
					text5 = text6.Substring(0, num3).Trim();
					if (int.TryParse(text6.Substring(num3 + 1), out var result))
					{
						num2 = result;
					}
				}
			}
			if (string.IsNullOrEmpty(text5))
			{
				text5 = Dns.GetHostName();
			}
			if (num2 < 1)
			{
				num2 = ((IPEndPoint)socket.LocalEndPoint).Port;
			}
			Uri uri = new Uri("http://" + text5 + ":" + num2 + "/");
			if (text2 != "*")
			{
				uri = new Uri(uri, text2);
			}
			return new WebContext(socket, uri, nameValueCollection);
		}
		catch (Exception)
		{
			Abort(socket, 400);
			throw;
		}
	}

	public async Task<WebSocket> AcceptWebSocketAsync()
	{
		if (!Request.IsWebSocketRequest)
		{
			throw new InvalidOperationException("The request is not a WebSocket handshake");
		}
		return await Response.AcceptWebSocketAsync(Request.Headers["Sec-WebSocket-Key"].Trim()).ConfigureAwait(continueOnCapturedContext: false);
	}

	private static void Abort(Socket socket, int statusCode)
	{
		using (new WebResponse(socket, statusCode))
		{
		}
	}
}
