using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.ClearScript.Util;

internal static class SocketHelpers
{
	public static Task SendStringAsync(this Socket socket, string value, Encoding encoding = null)
	{
		return socket.SendBytesAsync((encoding ?? Encoding.UTF8).GetBytes(value));
	}

	public static async Task<string> ReceiveLineAsync(this Socket socket, Encoding encoding = null)
	{
		List<byte> lineBytes = new List<byte>(1024);
		byte[] bytes = new byte[1];
		int num;
		while (true)
		{
			await socket.ReceiveBytesAsync(bytes, 0, 1).ConfigureAwait(continueOnCapturedContext: false);
			num = lineBytes.Count - 1;
			if (num >= 0 && lineBytes[num] == Convert.ToByte('\r') && bytes[0] == Convert.ToByte('\n'))
			{
				break;
			}
			lineBytes.Add(bytes[0]);
		}
		lineBytes.RemoveAt(num);
		return (encoding ?? Encoding.UTF8).GetString(lineBytes.ToArray());
	}

	public static Task SendBytesAsync(this Socket socket, byte[] bytes)
	{
		return socket.SendBytesAsync(bytes, 0, bytes.Length);
	}

	public static async Task SendBytesAsync(this Socket socket, byte[] bytes, int offset, int count)
	{
		while (count > 0)
		{
			int num = await socket.SendAsync(bytes, offset, count).ConfigureAwait(continueOnCapturedContext: false);
			if (num < 1)
			{
				throw new IOException("Failed to send data to socket");
			}
			offset += num;
			count -= num;
		}
	}

	public static async Task<byte[]> ReceiveBytesAsync(this Socket socket, int count)
	{
		byte[] bytes = new byte[count];
		await socket.ReceiveBytesAsync(bytes, 0, count).ConfigureAwait(continueOnCapturedContext: false);
		return bytes;
	}

	public static async Task ReceiveBytesAsync(this Socket socket, byte[] bytes, int offset, int count)
	{
		while (count > 0)
		{
			int num = await socket.ReceiveAsync(bytes, offset, count).ConfigureAwait(continueOnCapturedContext: false);
			if (num < 1)
			{
				throw new IOException("Failed to receive data from socket");
			}
			offset += num;
			count -= num;
		}
	}

	private static Task<int> SendAsync(this Socket socket, byte[] bytes, int offset, int count)
	{
		return Task<int>.Factory.FromAsync((AsyncCallback callback, object state) => socket.BeginSend(bytes, offset, count, SocketFlags.None, callback, state), socket.EndSend, null);
	}

	private static Task<int> ReceiveAsync(this Socket socket, byte[] bytes, int offset, int count)
	{
		return Task<int>.Factory.FromAsync((AsyncCallback callback, object state) => socket.BeginReceive(bytes, offset, count, SocketFlags.None, callback, state), socket.EndReceive, null);
	}
}
