using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.ClearScript.Util.Web;

internal sealed class WebSocket
{
	public sealed class Message
	{
		public bool IsBinary;

		public byte[] Payload;
	}

	internal enum ErrorCode
	{
		NormalClosure = 1000,
		EndpointUnavailable = 1001,
		ProtocolError = 1002,
		InvalidMessageType = 1003,
		InvalidPayloadData = 1007,
		PolicyViolation = 1008,
		MessageTooBig = 1009
	}

	[Serializable]
	public sealed class Exception : System.Exception
	{
		public ErrorCode ErrorCode { get; private set; }

		public Exception(ErrorCode errorCode, string message)
			: base(message)
		{
			ErrorCode = errorCode;
		}
	}

	private static class HeaderBits
	{
		public const byte Final = 128;

		public const byte OpCodeMask = 15;

		public const byte Masked = 128;

		public const byte LengthMask = 127;
	}

	private static class OpCodes
	{
		public const byte Continuation = 0;

		public const byte Text = 1;

		public const byte Binary = 2;

		public const byte Close = 8;

		public const byte Ping = 9;

		public const byte Pong = 10;
	}

	private sealed class Frame
	{
		public bool Final;

		public byte OpCode;

		public byte[] Payload;
	}

	private readonly Socket socket;

	private readonly bool isServerSocket;

	private readonly Random random = MiscHelpers.CreateSeededRandom();

	private readonly SemaphoreSlim receiveSemaphore = new SemaphoreSlim(1);

	private readonly SemaphoreSlim sendSemaphore = new SemaphoreSlim(1);

	private readonly InterlockedOneWayFlag closedFlag = new InterlockedOneWayFlag();

	internal WebSocket(Socket socket, bool isServerSocket)
	{
		this.socket = socket;
		this.isServerSocket = isServerSocket;
	}

	public async Task<Message> ReceiveMessageAsync()
	{
		using (await receiveSemaphore.CreateLockScopeAsync().ConfigureAwait(continueOnCapturedContext: false))
		{
			bool? isBinary = null;
			List<byte[]> payloads = new List<byte[]>();
			while (true)
			{
				Frame frame = await ReceiveFrameAsync().ConfigureAwait(continueOnCapturedContext: false);
				if (frame.OpCode == 1)
				{
					if (isBinary.HasValue)
					{
						throw new Exception(ErrorCode.ProtocolError, "Received unexpected text frame from WebSocket");
					}
					isBinary = false;
					payloads.Add(frame.Payload);
					if (frame.Final)
					{
						break;
					}
				}
				else if (frame.OpCode == 2)
				{
					if (isBinary.HasValue)
					{
						throw new Exception(ErrorCode.ProtocolError, "Received unexpected binary frame from WebSocket");
					}
					isBinary = true;
					payloads.Add(frame.Payload);
					if (frame.Final)
					{
						break;
					}
				}
				else if (frame.OpCode == 0)
				{
					if (!isBinary.HasValue)
					{
						throw new Exception(ErrorCode.ProtocolError, "Received unexpected continuation frame from WebSocket");
					}
					payloads.Add(frame.Payload);
					if (frame.Final)
					{
						break;
					}
				}
				else if (frame.OpCode == 9)
				{
					Frame frame2 = new Frame
					{
						Final = true,
						OpCode = 10,
						Payload = frame.Payload
					};
					await SendFrameAsync(frame2).ConfigureAwait(continueOnCapturedContext: false);
				}
				else
				{
					if (frame.OpCode == 10)
					{
						continue;
					}
					if (frame.OpCode == 8)
					{
						ErrorCode errorCode = ErrorCode.NormalClosure;
						string message = "The WebSocket was closed by the remote endpoint";
						if (frame.Payload.Length >= 2)
						{
							errorCode = (ErrorCode)frame.Payload.ToHostUInt16();
							if (frame.Payload.Length > 2)
							{
								message = Encoding.UTF8.GetString(frame.Payload, 2, frame.Payload.Length - 2);
							}
						}
						throw new Exception(errorCode, message);
					}
					throw new Exception(ErrorCode.ProtocolError, "Received unrecognized frame from WebSocket");
				}
			}
			long num = 0L;
			bool flag = false;
			try
			{
				num = payloads.Aggregate(0L, (long tempLength, byte[] segment) => checked(tempLength + segment.LongLength));
			}
			catch (OverflowException)
			{
				flag = true;
			}
			if (flag || num > 67108864)
			{
				throw new Exception(ErrorCode.MessageTooBig, "Incoming WebSocket message payload is too large");
			}
			byte[] array = new byte[num];
			long num2 = 0L;
			foreach (byte[] item in payloads)
			{
				Array.Copy(item, 0L, array, num2, item.LongLength);
				num2 += item.LongLength;
			}
			return new Message
			{
				IsBinary = isBinary.Value,
				Payload = array
			};
		}
	}

	public Task SendMessageAsync(byte[] payload, bool isBinary = false)
	{
		Frame frame = new Frame
		{
			Final = true,
			OpCode = (byte)((!isBinary) ? 1 : 2),
			Payload = payload
		};
		return SendFrameAsync(frame);
	}

	private async Task<Frame> ReceiveFrameAsync()
	{
		byte[] array = await socket.ReceiveBytesAsync(2).ConfigureAwait(continueOnCapturedContext: false);
		bool final = array[0].Has(128);
		byte opCode = array[0].And(15);
		bool masked = array[1].Has(128);
		ulong length = array[1].And(127);
		switch (length)
		{
		case 126uL:
			length = (await socket.ReceiveBytesAsync(2).ConfigureAwait(continueOnCapturedContext: false)).ToHostUInt16();
			break;
		case 127uL:
			length = (await socket.ReceiveBytesAsync(8).ConfigureAwait(continueOnCapturedContext: false)).ToHostUInt64() & 0x7FFFFFFFFFFFFFFFL;
			break;
		}
		byte[] key = null;
		if (masked)
		{
			key = await socket.ReceiveBytesAsync(4).ConfigureAwait(continueOnCapturedContext: false);
		}
		if (length > 67108864)
		{
			throw new Exception(ErrorCode.MessageTooBig, "Incoming WebSocket frame payload is too large");
		}
		byte[] payload = new byte[length];
		if (length <= int.MaxValue)
		{
			await socket.ReceiveBytesAsync(payload, 0, Convert.ToInt32(length)).ConfigureAwait(continueOnCapturedContext: false);
		}
		else
		{
			byte[] segment = new byte[1048576];
			long index = 0L;
			while (length > 1048576)
			{
				await socket.ReceiveBytesAsync(segment, 0, 1048576).ConfigureAwait(continueOnCapturedContext: false);
				Array.Copy(segment, 0L, payload, index, 1048576L);
				length -= 1048576;
				index += 1048576;
			}
			int remainingLength = Convert.ToInt32(length);
			if (remainingLength > 0)
			{
				await socket.ReceiveBytesAsync(segment, 0, remainingLength).ConfigureAwait(continueOnCapturedContext: false);
				Array.Copy(segment, 0L, payload, index, remainingLength);
			}
		}
		if (masked)
		{
			for (long num = 0L; num < payload.LongLength; num++)
			{
				payload[num] ^= key[num % 4];
			}
		}
		return new Frame
		{
			Final = final,
			OpCode = opCode,
			Payload = payload
		};
	}

	private async Task SendFrameAsync(Frame frame)
	{
		using (await sendSemaphore.CreateLockScopeAsync().ConfigureAwait(continueOnCapturedContext: false))
		{
			byte[] array = new byte[2];
			bool masked = !isServerSocket;
			array[0] = frame.OpCode.And(15);
			if (masked)
			{
				array[1] = 128;
			}
			if (frame.Final)
			{
				array[0] = array[0].Or(128);
			}
			long length = frame.Payload.LongLength;
			byte[] lengthBytes = null;
			if (length <= 125)
			{
				array[1] = array[1].Or(Convert.ToByte(length));
			}
			else if (length <= 65535)
			{
				array[1] = array[1].Or(126);
				lengthBytes = Convert.ToUInt16(length).ToNetworkBytes();
			}
			else
			{
				array[1] = array[1].Or(127);
				lengthBytes = Convert.ToUInt64(length).ToNetworkBytes();
			}
			await socket.SendBytesAsync(array).ConfigureAwait(continueOnCapturedContext: false);
			if (lengthBytes != null)
			{
				await socket.SendBytesAsync(lengthBytes).ConfigureAwait(continueOnCapturedContext: false);
			}
			byte[] key = null;
			if (masked)
			{
				key = new byte[4];
				random.NextBytes(key);
				await socket.SendBytesAsync(key).ConfigureAwait(continueOnCapturedContext: false);
			}
			byte[] segment = new byte[1048576];
			long index = 0L;
			while (length > 1048576)
			{
				Array.Copy(frame.Payload, index, segment, 0L, 1048576L);
				if (masked)
				{
					for (int i = 0; i < 1048576; i++)
					{
						segment[i] ^= key[i % 4];
					}
				}
				await socket.SendBytesAsync(segment).ConfigureAwait(continueOnCapturedContext: false);
				length -= 1048576;
				index += 1048576;
			}
			int num = Convert.ToInt32(length);
			if (num <= 0)
			{
				return;
			}
			Array.Copy(frame.Payload, index, segment, 0L, num);
			if (masked)
			{
				for (int j = 0; j < num; j++)
				{
					segment[j] ^= key[j % 4];
				}
			}
			await socket.SendBytesAsync(segment, 0, num).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	private void SendFrameAsync(Frame frame, Action<bool> callback)
	{
		SendFrameAsync(frame).ContinueWith(delegate(Task task)
		{
			callback(MiscHelpers.Try(task.Wait));
		});
	}

	public void Close(ErrorCode errorCode, string message)
	{
		if (closedFlag.Set())
		{
			byte[] array = ((ushort)errorCode).ToNetworkBytes();
			if (!string.IsNullOrEmpty(message))
			{
				array = array.Concat(Encoding.UTF8.GetBytes(message)).ToArray();
			}
			Frame frame = new Frame
			{
				Final = true,
				OpCode = 8,
				Payload = array
			};
			SendFrameAsync(frame, delegate
			{
				socket.Close();
				receiveSemaphore.Dispose();
				sendSemaphore.Dispose();
			});
		}
	}
}
