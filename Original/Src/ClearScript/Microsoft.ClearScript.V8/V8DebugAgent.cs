using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ClearScript.Util;
using Microsoft.ClearScript.Util.Web;

namespace Microsoft.ClearScript.V8;

internal sealed class V8DebugAgent : IDisposable
{
	private const string faviconUrl = "https://microsoft.github.io/ClearScript/favicon.png";

	private readonly Guid targetId = Guid.NewGuid();

	private readonly string name;

	private readonly string version;

	private readonly IV8DebugListener listener;

	private TcpListener tcpListener;

	private V8DebugClient activeClient;

	private readonly InterlockedOneWayFlag disposedFlag = new InterlockedOneWayFlag();

	public V8DebugAgent(string name, string version, int port, bool remote, IV8DebugListener listener)
	{
		V8DebugAgent v8DebugAgent = this;
		this.name = name;
		this.version = version;
		this.listener = listener;
		bool flag = false;
		if (remote)
		{
			flag = MiscHelpers.Try(delegate
			{
				v8DebugAgent.tcpListener = new TcpListener(IPAddress.Any, port);
				v8DebugAgent.tcpListener.Start();
			});
		}
		if (!flag)
		{
			flag = MiscHelpers.Try(delegate
			{
				v8DebugAgent.tcpListener = new TcpListener(IPAddress.Loopback, port);
				v8DebugAgent.tcpListener.Start();
			});
		}
		if (flag)
		{
			StartAcceptWebClient();
		}
	}

	public void SendCommand(V8DebugClient client, string command)
	{
		if (client == activeClient)
		{
			listener.SendCommand(command);
		}
	}

	public void SendMessage(string message)
	{
		if (!disposedFlag.IsSet)
		{
			activeClient?.SendMessage(message);
		}
	}

	public void OnClientFailed(V8DebugClient client)
	{
		if (Interlocked.CompareExchange(ref activeClient, null, client) == client)
		{
			listener.DisconnectClient();
		}
	}

	private void StartAcceptWebClient()
	{
		tcpListener.AcceptSocketAsync().ContinueWith(OnWebClientAccepted);
	}

	private void OnWebClientAccepted(Task<Socket> task)
	{
		Socket result;
		bool flag = MiscHelpers.Try(out result, () => task.Result);
		if (!disposedFlag.IsSet)
		{
			if (flag)
			{
				WebContext.CreateAsync(result).ContinueWith(OnWebContextCreated);
			}
			StartAcceptWebClient();
		}
	}

	private void OnWebContextCreated(Task<WebContext> task)
	{
		if (MiscHelpers.Try(out var result, () => task.Result) && !disposedFlag.IsSet)
		{
			if (!result.Request.IsWebSocketRequest)
			{
				HandleWebRequest(result);
			}
			else if (!result.Request.RawUrl.Equals("/" + targetId, StringComparison.OrdinalIgnoreCase))
			{
				result.Response.Close(404);
			}
			else
			{
				StartAcceptWebSocket(result);
			}
		}
	}

	private void HandleWebRequest(WebContext webContext)
	{
		if (webContext.Request.RawUrl.Equals("/json", StringComparison.OrdinalIgnoreCase) || webContext.Request.RawUrl.Equals("/json/list", StringComparison.OrdinalIgnoreCase))
		{
			if (activeClient != null)
			{
				SendWebResponse(webContext, MiscHelpers.FormatInvariant("[ {{\r\n  \"id\": \"{0}\",\r\n  \"type\": \"node\",\r\n  \"description\": \"ClearScript V8 runtime: {1}\",\r\n  \"title\": \"{2}\",\r\n  \"url\": \"{3}\",\r\n  \"faviconUrl\": \"{4}\"\r\n}} ]\r\n", targetId, JsonEscape(name), JsonEscape(AppDomain.CurrentDomain.FriendlyName), JsonEscape(new Uri(Process.GetCurrentProcess().MainModule.FileName)), "https://microsoft.github.io/ClearScript/favicon.png"));
			}
			else
			{
				SendWebResponse(webContext, MiscHelpers.FormatInvariant("[ {{\r\n  \"id\": \"{0}\",\r\n  \"type\": \"node\",\r\n  \"description\": \"ClearScript V8 runtime: {1}\",\r\n  \"title\": \"{2}\",\r\n  \"url\": \"{3}\",\r\n  \"faviconUrl\": \"{6}\",\r\n  \"devtoolsFrontendUrl\": \"chrome-devtools://devtools/bundled/inspector.html?experiments=true&v8only=true&ws={4}:{5}/{0}\",\r\n  \"webSocketDebuggerUrl\": \"ws://{4}:{5}/{0}\"\r\n}} ]\r\n", targetId, JsonEscape(name), JsonEscape(AppDomain.CurrentDomain.FriendlyName), JsonEscape(new Uri(Process.GetCurrentProcess().MainModule.FileName)), webContext.Request.Uri.Host, webContext.Request.Uri.Port, "https://microsoft.github.io/ClearScript/favicon.png"));
			}
		}
		else if (webContext.Request.RawUrl.Equals("/json/version", StringComparison.OrdinalIgnoreCase))
		{
			SendWebResponse(webContext, MiscHelpers.FormatInvariant("{{\r\n  \"Browser\": \"ClearScript {0} [V8 {1}]\",\r\n  \"Protocol-Version\": \"1.1\"\r\n}}\r\n", "5.6.0.0", version));
		}
		else if (webContext.Request.RawUrl.StartsWith("/json/activate/", StringComparison.OrdinalIgnoreCase))
		{
			string text = webContext.Request.RawUrl.Substring(15);
			if (text.Equals(targetId.ToString(), StringComparison.OrdinalIgnoreCase))
			{
				SendWebResponse(webContext, "Target activated", "text/plain");
			}
			else
			{
				SendWebResponse(webContext, "No such target id: " + text, "text/plain", 404);
			}
		}
		else if (webContext.Request.RawUrl.StartsWith("/json/close/", StringComparison.OrdinalIgnoreCase))
		{
			string text2 = webContext.Request.RawUrl.Substring(12);
			if (text2.Equals(targetId.ToString(), StringComparison.OrdinalIgnoreCase))
			{
				SendWebResponse(webContext, "Target is closing", "text/plain");
			}
			else
			{
				SendWebResponse(webContext, "No such target id: " + text2, "text/plain", 404);
			}
		}
		else if (webContext.Request.RawUrl.StartsWith("/json/new?", StringComparison.OrdinalIgnoreCase) || webContext.Request.RawUrl.Equals("/json/protocol", StringComparison.OrdinalIgnoreCase))
		{
			webContext.Response.Close(501);
		}
		else
		{
			webContext.Response.Close(404);
		}
	}

	private void StartAcceptWebSocket(WebContext webContext)
	{
		webContext.AcceptWebSocketAsync().ContinueWith(delegate(Task<WebSocket> task)
		{
			OnWebSocketAccepted(webContext, task);
		});
	}

	private void OnWebSocketAccepted(WebContext webContext, Task<WebSocket> task)
	{
		if (MiscHelpers.Try(out var result, () => task.Result))
		{
			if (!ConnectClient(result))
			{
				result.Close(WebSocket.ErrorCode.PolicyViolation, "A debugger is already connected");
			}
		}
		else
		{
			webContext.Response.Close(500);
		}
	}

	private bool ConnectClient(WebSocket webSocket)
	{
		V8DebugClient v8DebugClient = new V8DebugClient(this, webSocket);
		if (Interlocked.CompareExchange(ref activeClient, v8DebugClient, null) == null)
		{
			listener.ConnectClient();
			v8DebugClient.Start();
			return true;
		}
		return false;
	}

	private void DisconnectClient(WebSocket.ErrorCode errorCode, string message)
	{
		V8DebugClient v8DebugClient = Interlocked.Exchange(ref activeClient, null);
		if (v8DebugClient != null)
		{
			v8DebugClient.Dispose(errorCode, message);
			listener.DisconnectClient();
		}
	}

	public void Dispose()
	{
		if (disposedFlag.Set())
		{
			MiscHelpers.Try(tcpListener.Stop);
			DisconnectClient(WebSocket.ErrorCode.EndpointUnavailable, "The V8 runtime has been destroyed");
			listener.Dispose();
		}
	}

	private static void SendWebResponse(WebContext webContext, string content, string contentType = "application/json", int statusCode = 200)
	{
		using (webContext.Response)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(content);
			webContext.Response.ContentType = contentType + "; charset=UTF-8";
			webContext.Response.OutputStream.Write(bytes, 0, bytes.Length);
			webContext.Response.StatusCode = statusCode;
		}
	}

	private static string JsonEscape(object value)
	{
		return new string((from ch in value.ToString()
			select (ch != '"' && ch != '\\') ? ch : '_').ToArray());
	}
}
