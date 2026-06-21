using System;
using System.Collections.Concurrent;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ClearScript.Util;
using Microsoft.ClearScript.Util.Web;

namespace Microsoft.ClearScript.V8;

internal sealed class V8DebugClient
{
	private readonly V8DebugAgent agent;

	private readonly WebSocket webSocket;

	private readonly ConcurrentQueue<string> queue = new ConcurrentQueue<string>();

	private readonly SemaphoreSlim sendSemaphore = new SemaphoreSlim(1);

	private readonly InterlockedOneWayFlag disposedFlag = new InterlockedOneWayFlag();

	public V8DebugClient(V8DebugAgent agent, WebSocket webSocket)
	{
		this.agent = agent;
		this.webSocket = webSocket;
	}

	public void Start()
	{
		StartReceiveMessage();
	}

	private void StartReceiveMessage()
	{
		webSocket.ReceiveMessageAsync().ContinueWith(OnMessageReceived);
	}

	private void OnMessageReceived(Task<WebSocket.Message> task)
	{
		try
		{
			WebSocket.Message result = task.Result;
			if (!disposedFlag.IsSet)
			{
				if (result.IsBinary)
				{
					OnFailed(WebSocket.ErrorCode.InvalidMessageType, "Received unexpected binary message from WebSocket");
					return;
				}
				agent.SendCommand(this, Encoding.UTF8.GetString(result.Payload));
				StartReceiveMessage();
			}
		}
		catch (AggregateException ex)
		{
			ex.Handle(delegate(Exception exception)
			{
				if (!disposedFlag.IsSet)
				{
					if (exception is WebSocket.Exception ex2)
					{
						OnFailed(ex2.ErrorCode, ex2.Message);
					}
					else
					{
						OnFailed(WebSocket.ErrorCode.ProtocolError, "Could not receive message from WebSocket");
					}
				}
				return true;
			});
		}
	}

	public void SendMessage(string message)
	{
		if (!disposedFlag.IsSet)
		{
			queue.Enqueue(message);
			SendMessagesAsync().ContinueWith(OnMessagesSent);
		}
	}

	private async Task SendMessagesAsync()
	{
		using (await sendSemaphore.CreateLockScopeAsync().ConfigureAwait(continueOnCapturedContext: false))
		{
			string result;
			while (queue.TryDequeue(out result))
			{
				await webSocket.SendMessageAsync(Encoding.UTF8.GetBytes(result)).ConfigureAwait(continueOnCapturedContext: false);
			}
		}
	}

	private void OnMessagesSent(Task task)
	{
		try
		{
			task.Wait();
		}
		catch (AggregateException ex)
		{
			ex.Handle(delegate(Exception exception)
			{
				if (!disposedFlag.IsSet)
				{
					if (exception is WebSocket.Exception ex2)
					{
						OnFailed(ex2.ErrorCode, ex2.Message);
					}
					else
					{
						OnFailed(WebSocket.ErrorCode.ProtocolError, "Could not send message to WebSocket");
					}
				}
				return true;
			});
		}
	}

	private void OnFailed(WebSocket.ErrorCode errorCode, string message)
	{
		Dispose(errorCode, message);
		agent.OnClientFailed(this);
	}

	public void Dispose(WebSocket.ErrorCode errorCode, string message)
	{
		if (disposedFlag.Set())
		{
			webSocket.Close(errorCode, message);
			sendSemaphore.Dispose();
		}
	}
}
