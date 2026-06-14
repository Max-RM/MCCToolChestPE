using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.utils;

public static class IntSringConverter
{
	[CompilerGenerated]
	private sealed class _003CParseIntString_003Ed__2 : IEnumerable<int>, IEnumerable, IEnumerator<int>, IEnumerator, IDisposable
	{
		private int _003C_003E2__current;

		private int _003C_003E1__state;

		private int _003C_003El__initialThreadId;

		public string intstring;

		public string _003C_003E3__intstring;

		public string _003Cs_003E5__3;

		public int _003Cnum_003E5__4;

		public string[] _003Csubs_003E5__5;

		public int _003Cstart_003E5__6;

		public int _003Cend_003E5__7;

		public int _003CrangeLength_003E5__8;

		public int _003Ci_003E5__9;

		public string[] _003C_003E7__wrapb;

		public int _003C_003E7__wrapc;

		public IEnumerator<int> _003C_003E7__wrapd;

		int IEnumerator<int>.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			get
			{
				while (false)
				{
					_ = ((object[])null)[0];
				}
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			get
			{
				while (false)
				{
					_ = ((object[])null)[0];
				}
				return _003C_003E2__current;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator<int> IEnumerable<int>.GetEnumerator()
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			_003CParseIntString_003Ed__2 _003CParseIntString_003Ed__3;
			if (Environment.CurrentManagedThreadId == _003C_003El__initialThreadId && _003C_003E1__state == -2)
			{
				_003C_003E1__state = 0;
				_003CParseIntString_003Ed__3 = this;
			}
			else
			{
				_003CParseIntString_003Ed__3 = new _003CParseIntString_003Ed__2(0);
			}
			_003CParseIntString_003Ed__3.intstring = _003C_003E3__intstring;
			return _003CParseIntString_003Ed__3;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return ((IEnumerable<int>)this).GetEnumerator();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool MoveNext()
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			try
			{
				switch (_003C_003E1__state)
				{
				case 0:
					_003C_003E1__state = -1;
					_003C_003E1__state = 1;
					_003C_003E7__wrapb = intstring.Split(',');
					_003C_003E7__wrapc = 0;
					goto IL_01bb;
				case 2:
					_003C_003E1__state = 1;
					goto IL_01ad;
				case 4:
					{
						_003C_003E1__state = 3;
						goto IL_0197;
					}
					IL_01bb:
					if (_003C_003E7__wrapc < _003C_003E7__wrapb.Length)
					{
						_003Cs_003E5__3 = _003C_003E7__wrapb[_003C_003E7__wrapc];
						if (int.TryParse(_003Cs_003E5__3, out _003Cnum_003E5__4))
						{
							_003C_003E2__current = _003Cnum_003E5__4;
							_003C_003E1__state = 2;
							return true;
						}
						_003Csubs_003E5__5 = _003Cs_003E5__3.Split('-');
						if (_003Csubs_003E5__5.Length > 1 && int.TryParse(_003Csubs_003E5__5[0], out _003Cstart_003E5__6) && int.TryParse(_003Csubs_003E5__5[1], out _003Cend_003E5__7) && _003Cend_003E5__7 >= _003Cstart_003E5__6)
						{
							_003CrangeLength_003E5__8 = _003Cend_003E5__7 - _003Cstart_003E5__6 + 1;
							_003C_003E7__wrapd = Enumerable.Range(_003Cstart_003E5__6, _003CrangeLength_003E5__8).GetEnumerator();
							_003C_003E1__state = 3;
							goto IL_0197;
						}
						goto IL_01ad;
					}
					_003C_003Em__Finallya();
					break;
					IL_0197:
					if (_003C_003E7__wrapd.MoveNext())
					{
						_003Ci_003E5__9 = _003C_003E7__wrapd.Current;
						_003C_003E2__current = _003Ci_003E5__9;
						_003C_003E1__state = 4;
						return true;
					}
					_003C_003Em__Finallye();
					goto IL_01ad;
					IL_01ad:
					_003C_003E7__wrapc++;
					goto IL_01bb;
				}
				return false;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			throw new NotSupportedException();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		void IDisposable.Dispose()
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			switch (_003C_003E1__state)
			{
			case 1:
			case 2:
			case 3:
			case 4:
				switch (_003C_003E1__state)
				{
				case 3:
				case 4:
					try
					{
					}
					finally
					{
						_003C_003Em__Finallye();
					}
					break;
				}
				_003C_003Em__Finallya();
				break;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		public _003CParseIntString_003Ed__2(int _003C_003E1__state)
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _003C_003Em__Finallya()
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			_003C_003E1__state = -1;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _003C_003Em__Finallye()
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			_003C_003E1__state = 1;
			if (_003C_003E7__wrapd != null)
			{
				_003C_003E7__wrapd.Dispose();
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003CnumListToPossiblyDegenerateRanges_003Ed__11 : IEnumerable<Tuple<int, int>>, IEnumerable, IEnumerator<Tuple<int, int>>, IEnumerator, IDisposable
	{
		private Tuple<int, int> _003C_003E2__current;

		private int _003C_003E1__state;

		private int _003C_003El__initialThreadId;

		public IEnumerable<int> numList;

		public IEnumerable<int> _003C_003E3__numList;

		public Tuple<int, int> _003CcurrentRange_003E5__12;

		public int _003Cnum_003E5__13;

		public IEnumerator<int> _003C_003E7__wrap14;

		Tuple<int, int> IEnumerator<Tuple<int, int>>.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			get
			{
				while (false)
				{
					_ = ((object[])null)[0];
				}
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			get
			{
				while (false)
				{
					_ = ((object[])null)[0];
				}
				return _003C_003E2__current;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator<Tuple<int, int>> IEnumerable<Tuple<int, int>>.GetEnumerator()
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			_003CnumListToPossiblyDegenerateRanges_003Ed__11 _003CnumListToPossiblyDegenerateRanges_003Ed__12;
			if (Environment.CurrentManagedThreadId == _003C_003El__initialThreadId && _003C_003E1__state == -2)
			{
				_003C_003E1__state = 0;
				_003CnumListToPossiblyDegenerateRanges_003Ed__12 = this;
			}
			else
			{
				_003CnumListToPossiblyDegenerateRanges_003Ed__12 = new _003CnumListToPossiblyDegenerateRanges_003Ed__11(0);
			}
			_003CnumListToPossiblyDegenerateRanges_003Ed__12.numList = _003C_003E3__numList;
			return _003CnumListToPossiblyDegenerateRanges_003Ed__12;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return ((IEnumerable<Tuple<int, int>>)this).GetEnumerator();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool MoveNext()
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			try
			{
				switch (_003C_003E1__state)
				{
				case 0:
					_003C_003E1__state = -1;
					_003CcurrentRange_003E5__12 = null;
					_003C_003E7__wrap14 = numList.GetEnumerator();
					_003C_003E1__state = 1;
					goto IL_0104;
				case 2:
					_003C_003E1__state = 1;
					_003CcurrentRange_003E5__12 = Tuple.Create(_003Cnum_003E5__13, _003Cnum_003E5__13);
					goto IL_0104;
				case 3:
					{
						_003C_003E1__state = -1;
						break;
					}
					IL_0104:
					while (_003C_003E7__wrap14.MoveNext())
					{
						_003Cnum_003E5__13 = _003C_003E7__wrap14.Current;
						if (_003CcurrentRange_003E5__12 == null)
						{
							_003CcurrentRange_003E5__12 = Tuple.Create(_003Cnum_003E5__13, _003Cnum_003E5__13);
							continue;
						}
						if (_003CcurrentRange_003E5__12.Item2 == _003Cnum_003E5__13 - 1)
						{
							_003CcurrentRange_003E5__12 = Tuple.Create(_003CcurrentRange_003E5__12.Item1, _003Cnum_003E5__13);
							continue;
						}
						_003C_003E2__current = _003CcurrentRange_003E5__12;
						_003C_003E1__state = 2;
						return true;
					}
					_003C_003Em__Finally15();
					if (_003CcurrentRange_003E5__12 != null)
					{
						_003C_003E2__current = _003CcurrentRange_003E5__12;
						_003C_003E1__state = 3;
						return true;
					}
					break;
				}
				return false;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			throw new NotSupportedException();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		void IDisposable.Dispose()
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			switch (_003C_003E1__state)
			{
			case 1:
			case 2:
				try
				{
					break;
				}
				finally
				{
					_003C_003Em__Finally15();
				}
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		public _003CnumListToPossiblyDegenerateRanges_003Ed__11(int _003C_003E1__state)
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _003C_003Em__Finally15()
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			_003C_003E1__state = -1;
			if (_003C_003E7__wrap14 != null)
			{
				_003C_003E7__wrap14.Dispose();
			}
		}
	}

	[CompilerGenerated]
	private static Func<Tuple<int, int>, string> xU6SRsd1p18;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<int> ConvertFromString(string intstring)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return hVCSRpXlFWR(intstring).ToList();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string ConvertToString(int[] numList)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return AbMSRZfyohL(numList).Select([MethodImpl(MethodImplOptions.NoInlining)] (Tuple<int, int> P_0) =>
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return l5OSRfsClG1(P_0);
		}).Intersperse(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(40710));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static IEnumerable<int> hVCSRpXlFWR(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		_003CParseIntString_003Ed__2 _003CParseIntString_003Ed__3 = new _003CParseIntString_003Ed__2(-2);
		_003CParseIntString_003Ed__3._003C_003E3__intstring = P_0;
		return _003CParseIntString_003Ed__3;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static IEnumerable<Tuple<int, int>> AbMSRZfyohL(IEnumerable<int> P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		_003CnumListToPossiblyDegenerateRanges_003Ed__11 _003CnumListToPossiblyDegenerateRanges_003Ed__12 = new _003CnumListToPossiblyDegenerateRanges_003Ed__11(-2);
		_003CnumListToPossiblyDegenerateRanges_003Ed__12._003C_003E3__numList = P_0;
		return _003CnumListToPossiblyDegenerateRanges_003Ed__12;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static string l5OSRfsClG1(Tuple<int, int> P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0.Item1 == P_0.Item2)
		{
			return P_0.Item1.ToString();
		}
		return string.Format(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(214628), P_0.Item1, P_0.Item2);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string Intersperse(this IEnumerable<string> items, string interspersand)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string value = "";
		StringBuilder stringBuilder = new StringBuilder();
		foreach (string item in items)
		{
			stringBuilder.Append(value);
			stringBuilder.Append(item);
			value = interspersand;
		}
		return stringBuilder.ToString();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static string PRgSRiTY5EC(Tuple<int, int> P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return l5OSRfsClG1(P_0);
	}
}
