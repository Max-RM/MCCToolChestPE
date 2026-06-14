using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using MCCToolChest.utils;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace W7XEw1ukTn4yRrm2wV4;

internal class VrfLq3utcbtaHoMfeNR
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CUpload_003Ed__0 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public byte[] _003CfileData_003E5__1;

		public string _003Curl_003E5__2;

		public MultipartFormDataContent _003CrequestContent_003E5__3;

		public ByteArrayContent _003CimageContent_003E5__4;

		public HttpClient _003Cclient_003E5__5;

		public HttpResponseMessage _003Cmessage_003E5__6;

		public string _003Cinput_003E5__7;

		private TaskAwaiter<HttpResponseMessage> _003C_003Eu___0024awaiter8;

		private object _003C_003Et__stack;

		private TaskAwaiter<string> _003C_003Eu___0024awaiter9;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			try
			{
				bool flag = true;
				switch (_003C_003E1__state)
				{
				default:
					try
					{
						switch (_003C_003E1__state)
						{
						default:
							_003CfileData_003E5__1 = FileUtils.pURSg6Zk53A(gyxSYMsnsdp());
							_003Curl_003E5__2 = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(259138);
							_003CrequestContent_003E5__3 = new MultipartFormDataContent();
							_003CimageContent_003E5__4 = new ByteArrayContent(_003CfileData_003E5__1);
							_003CimageContent_003E5__4.Headers.ContentType = MediaTypeHeaderValue.Parse(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(259248));
							_003CrequestContent_003E5__3.Add(_003CimageContent_003E5__4, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(259290), FAISYYb5CqH.ToString() + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(259304));
							_003Cclient_003E5__5 = new HttpClient();
							break;
						case 0:
						case 1:
							break;
						}
						try
						{
							HttpResponseMessage result;
							TaskAwaiter<HttpResponseMessage> awaiter;
							HttpResponseMessage httpResponseMessage;
							switch (_003C_003E1__state)
							{
							default:
								awaiter = _003Cclient_003E5__5.PostAsync(_003Curl_003E5__2, _003CrequestContent_003E5__3).GetAwaiter();
								if (!awaiter.IsCompleted)
								{
									_003C_003E1__state = 0;
									_003C_003Eu___0024awaiter8 = awaiter;
									_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
									flag = false;
									return;
								}
								goto IL_0158;
							case 0:
								awaiter = _003C_003Eu___0024awaiter8;
								_003C_003Eu___0024awaiter8 = default(TaskAwaiter<HttpResponseMessage>);
								_003C_003E1__state = -1;
								goto IL_0158;
							case 1:
								break;
								IL_0158:
								result = awaiter.GetResult();
								awaiter = default(TaskAwaiter<HttpResponseMessage>);
								httpResponseMessage = result;
								_003Cmessage_003E5__6 = httpResponseMessage;
								break;
							}
							try
							{
								int num = _003C_003E1__state;
								TaskAwaiter<string> awaiter2;
								if (num != 1)
								{
									awaiter2 = _003Cmessage_003E5__6.Content.ReadAsStringAsync().GetAwaiter();
									if (!awaiter2.IsCompleted)
									{
										_003C_003E1__state = 1;
										_003C_003Eu___0024awaiter9 = awaiter2;
										_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter2, ref this);
										flag = false;
										return;
									}
								}
								else
								{
									awaiter2 = _003C_003Eu___0024awaiter9;
									_003C_003Eu___0024awaiter9 = default(TaskAwaiter<string>);
									_003C_003E1__state = -1;
								}
								string result2 = awaiter2.GetResult();
								awaiter2 = default(TaskAwaiter<string>);
								string text = result2;
								_003Cinput_003E5__7 = text;
							}
							finally
							{
								if (flag && _003Cmessage_003E5__6 != null)
								{
									((IDisposable)_003Cmessage_003E5__6).Dispose();
								}
							}
						}
						finally
						{
							if (flag && _003Cclient_003E5__5 != null)
							{
								((IDisposable)_003Cclient_003E5__5).Dispose();
							}
						}
					}
					catch (Exception)
					{
					}
					break;
				}
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine param0)
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			_003C_003Et__builder.SetStateMachine(param0);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine param0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(param0);
		}
	}

	private static string FAISYYb5CqH;

	[CompilerGenerated]
	private static Func<FileInfo, DateTime> erhSY3cdRn1;

	internal static string Id
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return FAISYYb5CqH;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			FAISYYb5CqH = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static string LHaSYxBsxpu()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string path = gyxSYMsnsdp();
		if (!File.Exists(path))
		{
			return "";
		}
		return File.ReadAllText(path);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void LTsSYeXGHCA(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string path = gyxSYMsnsdp();
		File.AppendAllText(path, P_0 + Environment.NewLine);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static string gyxSYMsnsdp()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return Path.Combine(Utils.ErrorPath(), FAISYYb5CqH + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69582));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[DebuggerStepThrough]
	[AsyncStateMachine(typeof(_003CUpload_003Ed__0))]
	internal static void lSHSYUfALyv()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		_003CUpload_003Ed__0 stateMachine = default(_003CUpload_003Ed__0);
		stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
		stateMachine._003C_003E1__state = -1;
		AsyncVoidMethodBuilder asyncVoidMethodBuilder = stateMachine._003C_003Et__builder;
		asyncVoidMethodBuilder.Start(ref stateMachine);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static FileInfo[] wjCSYLAx65I()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		try
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(Utils.ErrorPath());
			return directoryInfo.GetFiles().OrderByDescending([MethodImpl(MethodImplOptions.NoInlining)] (FileInfo P_0) =>
			{
				while (false)
				{
					_ = ((object[])null)[0];
				}
				return P_0.LastWriteTime;
			}).ToArray();
		}
		catch (Exception ex)
		{
			Console.WriteLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(246334), ex.ToString());
		}
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void n42SYgNaeyv()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		try
		{
			string[] files = Directory.GetFiles(Utils.ErrorPath());
			string[] array = files;
			foreach (string path in array)
			{
				File.Delete(path);
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(246334), ex.ToString());
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public VrfLq3utcbtaHoMfeNR()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static DateTime IGNSYPAcMIg(FileInfo P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0.LastWriteTime;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static VrfLq3utcbtaHoMfeNR()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		FAISYYb5CqH = Guid.NewGuid().ToString();
	}
}
