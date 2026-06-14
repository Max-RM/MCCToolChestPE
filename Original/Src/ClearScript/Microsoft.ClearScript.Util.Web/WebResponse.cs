using System;
using System.IO;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Microsoft.ClearScript.Util.Web;

internal sealed class WebResponse : IDisposable
{
	private static class State
	{
		public const int Open = 0;

		public const int Upgraded = 1;

		public const int Closed = 2;
	}

	private readonly Socket socket;

	private int state;

	public int StatusCode { get; set; }

	public string ContentType { get; set; }

	public Stream OutputStream { get; private set; }

	internal WebResponse(Socket socket, int statusCode)
	{
		this.socket = socket;
		state = 0;
		StatusCode = statusCode;
		OutputStream = new MemoryStream();
	}

	internal async Task<WebSocket> AcceptWebSocketAsync(string key)
	{
		if (Interlocked.CompareExchange(ref state, 1, 0) == 0)
		{
			using (MemoryStream stream = CreateWebSocketResponseStream(key))
			{
				await socket.SendBytesAsync(stream.GetBuffer(), 0, Convert.ToInt32(stream.Length)).ConfigureAwait(continueOnCapturedContext: false);
			}
			return new WebSocket(socket, isServerSocket: true);
		}
		throw new InvalidOperationException("Cannot accept a WebSocket connection in the current state");
	}

	public void Close(int? overrideStatusCode = null)
	{
		if (Interlocked.CompareExchange(ref state, 2, 0) == 0)
		{
			CloseAsync(overrideStatusCode).ContinueWith((Task task) => MiscHelpers.Try(task.Wait));
		}
	}

	private async Task CloseAsync(int? overrideStatusCode)
	{
		using (socket)
		{
			using MemoryStream stream = CreateResponseStream(overrideStatusCode);
			await socket.SendBytesAsync(stream.GetBuffer(), 0, Convert.ToInt32(stream.Length)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	private MemoryStream CreateResponseStream(int? overrideStatusCode)
	{
		MemoryStream memoryStream = new MemoryStream();
		using (StreamWriter streamWriter = new StreamWriter(memoryStream, Encoding.ASCII, 16384, leaveOpen: true))
		{
			int num = overrideStatusCode ?? StatusCode;
			streamWriter.Write("HTTP/1.1 {0} {1}\r\n", num, HttpWorkerRequest.GetStatusDescription(num));
			if (!string.IsNullOrWhiteSpace(ContentType))
			{
				streamWriter.Write("Content-Type: {0}\r\n", ContentType);
			}
			if (OutputStream.Length > 0)
			{
				streamWriter.Write("Content-Length: {0}\r\n", OutputStream.Length);
			}
			streamWriter.Write("Cache-Control: no-cache, no-store, must-revalidate\r\n");
			streamWriter.Write("Connection: close\r\n");
			streamWriter.Write("\r\n");
			streamWriter.Flush();
		}
		if (OutputStream.Length > 0)
		{
			memoryStream.Write(((MemoryStream)OutputStream).GetBuffer(), 0, Convert.ToInt32(OutputStream.Length));
		}
		return memoryStream;
	}

	private static MemoryStream CreateWebSocketResponseStream(string key)
	{
		MemoryStream memoryStream = new MemoryStream();
		using StreamWriter streamWriter = new StreamWriter(memoryStream, Encoding.ASCII, 16384, leaveOpen: true);
		streamWriter.Write("HTTP/1.1 {0} {1}\r\n", 101, HttpWorkerRequest.GetStatusDescription(101));
		streamWriter.Write("Connection: Upgrade\r\n");
		streamWriter.Write("Upgrade: websocket\r\n");
		string arg = Convert.ToBase64String(SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(key + "258EAFA5-E914-47DA-95CA-C5AB0DC85B11")));
		streamWriter.Write("Sec-WebSocket-Accept: {0}\r\n", arg);
		streamWriter.Write("\r\n");
		streamWriter.Flush();
		return memoryStream;
	}

	public void Dispose()
	{
		Close();
	}
}
