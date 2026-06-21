using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Be.Windows.Forms;

[ToolboxBitmap(typeof(HexBox), "HexBox.bmp")]
public class HexBox : Control
{
	private interface IKeyInterpreter
	{
		void Activate();

		void Deactivate();

		bool PreProcessWmKeyUp(ref Message m);

		bool PreProcessWmChar(ref Message m);

		bool PreProcessWmKeyDown(ref Message m);

		PointF GetCaretPointF(long byteIndex);
	}

	private class EmptyKeyInterpreter : IKeyInterpreter
	{
		private HexBox _hexBox;

		public EmptyKeyInterpreter(HexBox hexBox)
		{
			_hexBox = hexBox;
		}

		public void Activate()
		{
		}

		public void Deactivate()
		{
		}

		public bool PreProcessWmKeyUp(ref Message m)
		{
			return _hexBox.BasePreProcessMessage(ref m);
		}

		public bool PreProcessWmChar(ref Message m)
		{
			return _hexBox.BasePreProcessMessage(ref m);
		}

		public bool PreProcessWmKeyDown(ref Message m)
		{
			return _hexBox.BasePreProcessMessage(ref m);
		}

		public PointF GetCaretPointF(long byteIndex)
		{
			return default(PointF);
		}
	}

	private class KeyInterpreter : IKeyInterpreter
	{
		private delegate bool MessageDelegate(ref Message m);

		protected HexBox _hexBox;

		protected bool _shiftDown;

		private bool _mouseDown;

		private BytePositionInfo _bpiStart;

		private BytePositionInfo _bpi;

		private Dictionary<Keys, MessageDelegate> _messageHandlers;

		private Dictionary<Keys, MessageDelegate> MessageHandlers
		{
			get
			{
				if (_messageHandlers == null)
				{
					_messageHandlers = new Dictionary<Keys, MessageDelegate>();
					_messageHandlers.Add(Keys.Left, PreProcessWmKeyDown_Left);
					_messageHandlers.Add(Keys.Up, PreProcessWmKeyDown_Up);
					_messageHandlers.Add(Keys.Right, PreProcessWmKeyDown_Right);
					_messageHandlers.Add(Keys.Down, PreProcessWmKeyDown_Down);
					_messageHandlers.Add(Keys.Prior, PreProcessWmKeyDown_PageUp);
					_messageHandlers.Add(Keys.Next, PreProcessWmKeyDown_PageDown);
					_messageHandlers.Add(Keys.Left | Keys.Shift, PreProcessWmKeyDown_ShiftLeft);
					_messageHandlers.Add(Keys.Up | Keys.Shift, PreProcessWmKeyDown_ShiftUp);
					_messageHandlers.Add(Keys.Right | Keys.Shift, PreProcessWmKeyDown_ShiftRight);
					_messageHandlers.Add(Keys.Down | Keys.Shift, PreProcessWmKeyDown_ShiftDown);
					_messageHandlers.Add(Keys.Tab, PreProcessWmKeyDown_Tab);
					_messageHandlers.Add(Keys.Back, PreProcessWmKeyDown_Back);
					_messageHandlers.Add(Keys.Delete, PreProcessWmKeyDown_Delete);
					_messageHandlers.Add(Keys.Home, PreProcessWmKeyDown_Home);
					_messageHandlers.Add(Keys.End, PreProcessWmKeyDown_End);
					_messageHandlers.Add(Keys.ShiftKey | Keys.Shift, PreProcessWmKeyDown_ShiftShiftKey);
					_messageHandlers.Add(Keys.C | Keys.Control, PreProcessWmKeyDown_ControlC);
					_messageHandlers.Add(Keys.X | Keys.Control, PreProcessWmKeyDown_ControlX);
					_messageHandlers.Add(Keys.V | Keys.Control, PreProcessWmKeyDown_ControlV);
				}
				return _messageHandlers;
			}
		}

		public KeyInterpreter(HexBox hexBox)
		{
			_hexBox = hexBox;
		}

		public virtual void Activate()
		{
			_hexBox.MouseDown += BeginMouseSelection;
			_hexBox.MouseMove += UpdateMouseSelection;
			_hexBox.MouseUp += EndMouseSelection;
		}

		public virtual void Deactivate()
		{
			_hexBox.MouseDown -= BeginMouseSelection;
			_hexBox.MouseMove -= UpdateMouseSelection;
			_hexBox.MouseUp -= EndMouseSelection;
		}

		private void BeginMouseSelection(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				_mouseDown = true;
				if (!_shiftDown)
				{
					_bpiStart = new BytePositionInfo(_hexBox._bytePos, _hexBox._byteCharacterPos);
					_hexBox.ReleaseSelection();
				}
				else
				{
					UpdateMouseSelection(this, e);
				}
			}
		}

		private void UpdateMouseSelection(object sender, MouseEventArgs e)
		{
			if (_mouseDown)
			{
				_bpi = GetBytePositionInfo(new Point(e.X, e.Y));
				long index = _bpi.Index;
				long num;
				long num2;
				if (index < _bpiStart.Index)
				{
					num = index;
					num2 = _bpiStart.Index - index;
				}
				else if (index > _bpiStart.Index)
				{
					num = _bpiStart.Index;
					num2 = index - num;
				}
				else
				{
					num = _hexBox._bytePos;
					num2 = 0L;
				}
				if (num != _hexBox._bytePos || num2 != _hexBox._selectionLength)
				{
					_hexBox.InternalSelect(num, num2);
					_hexBox.ScrollByteIntoView(_bpi.Index);
				}
			}
		}

		private void EndMouseSelection(object sender, MouseEventArgs e)
		{
			_mouseDown = false;
		}

		public virtual bool PreProcessWmKeyDown(ref Message m)
		{
			Keys keys = (Keys)m.WParam.ToInt32();
			Keys keys2 = keys | Control.ModifierKeys;
			bool flag = MessageHandlers.ContainsKey(keys2);
			if (flag && RaiseKeyDown(keys2))
			{
				return true;
			}
			MessageDelegate messageDelegate = (flag ? MessageHandlers[keys2] : (messageDelegate = PreProcessWmKeyDown_Default));
			return messageDelegate(ref m);
		}

		protected bool PreProcessWmKeyDown_Default(ref Message m)
		{
			_hexBox.ScrollByteIntoView();
			return _hexBox.BasePreProcessMessage(ref m);
		}

		protected bool RaiseKeyDown(Keys keyData)
		{
			KeyEventArgs e = new KeyEventArgs(keyData);
			_hexBox.OnKeyDown(e);
			return e.Handled;
		}

		protected virtual bool PreProcessWmKeyDown_Left(ref Message m)
		{
			return PerformPosMoveLeft();
		}

		protected virtual bool PreProcessWmKeyDown_Up(ref Message m)
		{
			long bytePos = _hexBox._bytePos;
			int byteCharacterPos = _hexBox._byteCharacterPos;
			if (bytePos != 0 || byteCharacterPos != 0)
			{
				bytePos = Math.Max(-1L, bytePos - _hexBox._iHexMaxHBytes);
				if (bytePos == -1)
				{
					return true;
				}
				_hexBox.SetPosition(bytePos);
				if (bytePos < _hexBox._startByte)
				{
					_hexBox.PerformScrollLineUp();
				}
				_hexBox.UpdateCaret();
				_hexBox.Invalidate();
			}
			_hexBox.ScrollByteIntoView();
			_hexBox.ReleaseSelection();
			return true;
		}

		protected virtual bool PreProcessWmKeyDown_Right(ref Message m)
		{
			return PerformPosMoveRight();
		}

		protected virtual bool PreProcessWmKeyDown_Down(ref Message m)
		{
			long bytePos = _hexBox._bytePos;
			int num = _hexBox._byteCharacterPos;
			if (bytePos == _hexBox._byteProvider.Length && num == 0)
			{
				return true;
			}
			bytePos = Math.Min(_hexBox._byteProvider.Length, bytePos + _hexBox._iHexMaxHBytes);
			if (bytePos == _hexBox._byteProvider.Length)
			{
				num = 0;
			}
			_hexBox.SetPosition(bytePos, num);
			if (bytePos > _hexBox._endByte - 1)
			{
				_hexBox.PerformScrollLineDown();
			}
			_hexBox.UpdateCaret();
			_hexBox.ScrollByteIntoView();
			_hexBox.ReleaseSelection();
			_hexBox.Invalidate();
			return true;
		}

		protected virtual bool PreProcessWmKeyDown_PageUp(ref Message m)
		{
			long bytePos = _hexBox._bytePos;
			int byteCharacterPos = _hexBox._byteCharacterPos;
			if (bytePos == 0 && byteCharacterPos == 0)
			{
				return true;
			}
			bytePos = Math.Max(0L, bytePos - _hexBox._iHexMaxBytes);
			if (bytePos == 0)
			{
				return true;
			}
			_hexBox.SetPosition(bytePos);
			if (bytePos < _hexBox._startByte)
			{
				_hexBox.PerformScrollPageUp();
			}
			_hexBox.ReleaseSelection();
			_hexBox.UpdateCaret();
			_hexBox.Invalidate();
			return true;
		}

		protected virtual bool PreProcessWmKeyDown_PageDown(ref Message m)
		{
			long bytePos = _hexBox._bytePos;
			int num = _hexBox._byteCharacterPos;
			if (bytePos == _hexBox._byteProvider.Length && num == 0)
			{
				return true;
			}
			bytePos = Math.Min(_hexBox._byteProvider.Length, bytePos + _hexBox._iHexMaxBytes);
			if (bytePos == _hexBox._byteProvider.Length)
			{
				num = 0;
			}
			_hexBox.SetPosition(bytePos, num);
			if (bytePos > _hexBox._endByte - 1)
			{
				_hexBox.PerformScrollPageDown();
			}
			_hexBox.ReleaseSelection();
			_hexBox.UpdateCaret();
			_hexBox.Invalidate();
			return true;
		}

		protected virtual bool PreProcessWmKeyDown_ShiftLeft(ref Message m)
		{
			long num = _hexBox._bytePos;
			long selectionLength = _hexBox._selectionLength;
			if (num + selectionLength < 1)
			{
				return true;
			}
			if (num + selectionLength <= _bpiStart.Index)
			{
				if (num == 0)
				{
					return true;
				}
				num--;
				selectionLength++;
			}
			else
			{
				selectionLength = Math.Max(0L, selectionLength - 1);
			}
			_hexBox.ScrollByteIntoView();
			_hexBox.InternalSelect(num, selectionLength);
			return true;
		}

		protected virtual bool PreProcessWmKeyDown_ShiftUp(ref Message m)
		{
			long bytePos = _hexBox._bytePos;
			long selectionLength = _hexBox._selectionLength;
			if (bytePos - _hexBox._iHexMaxHBytes < 0 && bytePos <= _bpiStart.Index)
			{
				return true;
			}
			if (_bpiStart.Index >= bytePos + selectionLength)
			{
				bytePos -= _hexBox._iHexMaxHBytes;
				selectionLength += _hexBox._iHexMaxHBytes;
				_hexBox.InternalSelect(bytePos, selectionLength);
				_hexBox.ScrollByteIntoView();
			}
			else
			{
				selectionLength -= _hexBox._iHexMaxHBytes;
				if (selectionLength < 0)
				{
					bytePos = _bpiStart.Index + selectionLength;
					selectionLength = -selectionLength;
					_hexBox.InternalSelect(bytePos, selectionLength);
					_hexBox.ScrollByteIntoView();
				}
				else
				{
					selectionLength -= _hexBox._iHexMaxHBytes;
					_hexBox.InternalSelect(bytePos, selectionLength);
					_hexBox.ScrollByteIntoView(bytePos + selectionLength);
				}
			}
			return true;
		}

		protected virtual bool PreProcessWmKeyDown_ShiftRight(ref Message m)
		{
			long bytePos = _hexBox._bytePos;
			long selectionLength = _hexBox._selectionLength;
			if (bytePos + selectionLength >= _hexBox._byteProvider.Length)
			{
				return true;
			}
			if (_bpiStart.Index <= bytePos)
			{
				selectionLength++;
				_hexBox.InternalSelect(bytePos, selectionLength);
				_hexBox.ScrollByteIntoView(bytePos + selectionLength);
			}
			else
			{
				bytePos++;
				selectionLength = Math.Max(0L, selectionLength - 1);
				_hexBox.InternalSelect(bytePos, selectionLength);
				_hexBox.ScrollByteIntoView();
			}
			return true;
		}

		protected virtual bool PreProcessWmKeyDown_ShiftDown(ref Message m)
		{
			long bytePos = _hexBox._bytePos;
			long selectionLength = _hexBox._selectionLength;
			long length = _hexBox._byteProvider.Length;
			if (bytePos + selectionLength + _hexBox._iHexMaxHBytes > length)
			{
				return true;
			}
			if (_bpiStart.Index <= bytePos)
			{
				selectionLength += _hexBox._iHexMaxHBytes;
				_hexBox.InternalSelect(bytePos, selectionLength);
				_hexBox.ScrollByteIntoView(bytePos + selectionLength);
			}
			else
			{
				selectionLength -= _hexBox._iHexMaxHBytes;
				if (selectionLength < 0)
				{
					bytePos = _bpiStart.Index;
					selectionLength = -selectionLength;
				}
				else
				{
					bytePos += _hexBox._iHexMaxHBytes;
				}
				_hexBox.InternalSelect(bytePos, selectionLength);
				_hexBox.ScrollByteIntoView();
			}
			return true;
		}

		protected virtual bool PreProcessWmKeyDown_Tab(ref Message m)
		{
			if (_hexBox._stringViewVisible && _hexBox._keyInterpreter.GetType() == typeof(KeyInterpreter))
			{
				_hexBox.ActivateStringKeyInterpreter();
				_hexBox.ScrollByteIntoView();
				_hexBox.ReleaseSelection();
				_hexBox.UpdateCaret();
				_hexBox.Invalidate();
				return true;
			}
			if (_hexBox.Parent == null)
			{
				return true;
			}
			_hexBox.Parent.SelectNextControl(_hexBox, forward: true, tabStopOnly: true, nested: true, wrap: true);
			return true;
		}

		protected virtual bool PreProcessWmKeyDown_ShiftTab(ref Message m)
		{
			if (_hexBox._keyInterpreter is StringKeyInterpreter)
			{
				_shiftDown = false;
				_hexBox.ActivateKeyInterpreter();
				_hexBox.ScrollByteIntoView();
				_hexBox.ReleaseSelection();
				_hexBox.UpdateCaret();
				_hexBox.Invalidate();
				return true;
			}
			if (_hexBox.Parent == null)
			{
				return true;
			}
			_hexBox.Parent.SelectNextControl(_hexBox, forward: false, tabStopOnly: true, nested: true, wrap: true);
			return true;
		}

		protected virtual bool PreProcessWmKeyDown_Back(ref Message m)
		{
			if (!_hexBox._byteProvider.SupportsDeleteBytes())
			{
				return true;
			}
			if (_hexBox.ReadOnly)
			{
				return true;
			}
			long bytePos = _hexBox._bytePos;
			long selectionLength = _hexBox._selectionLength;
			long num = ((_hexBox._byteCharacterPos == 0 && selectionLength == 0) ? (bytePos - 1) : bytePos);
			if (num < 0 && selectionLength < 1)
			{
				return true;
			}
			long length = ((selectionLength > 0) ? selectionLength : 1);
			_hexBox._byteProvider.DeleteBytes(Math.Max(0L, num), length);
			_hexBox.UpdateScrollSize();
			if (selectionLength == 0)
			{
				PerformPosMoveLeftByte();
			}
			_hexBox.ReleaseSelection();
			_hexBox.Invalidate();
			return true;
		}

		protected virtual bool PreProcessWmKeyDown_Delete(ref Message m)
		{
			if (!_hexBox._byteProvider.SupportsDeleteBytes())
			{
				return true;
			}
			if (_hexBox.ReadOnly)
			{
				return true;
			}
			long bytePos = _hexBox._bytePos;
			long selectionLength = _hexBox._selectionLength;
			if (bytePos >= _hexBox._byteProvider.Length)
			{
				return true;
			}
			long length = ((selectionLength > 0) ? selectionLength : 1);
			_hexBox._byteProvider.DeleteBytes(bytePos, length);
			_hexBox.UpdateScrollSize();
			_hexBox.ReleaseSelection();
			_hexBox.Invalidate();
			return true;
		}

		protected virtual bool PreProcessWmKeyDown_Home(ref Message m)
		{
			long bytePos = _hexBox._bytePos;
			int byteCharacterPos = _hexBox._byteCharacterPos;
			if (bytePos < 1)
			{
				return true;
			}
			bytePos = 0L;
			byteCharacterPos = 0;
			_hexBox.SetPosition(bytePos, byteCharacterPos);
			_hexBox.ScrollByteIntoView();
			_hexBox.UpdateCaret();
			_hexBox.ReleaseSelection();
			return true;
		}

		protected virtual bool PreProcessWmKeyDown_End(ref Message m)
		{
			long bytePos = _hexBox._bytePos;
			int byteCharacterPos = _hexBox._byteCharacterPos;
			if (bytePos >= _hexBox._byteProvider.Length - 1)
			{
				return true;
			}
			bytePos = _hexBox._byteProvider.Length;
			byteCharacterPos = 0;
			_hexBox.SetPosition(bytePos, byteCharacterPos);
			_hexBox.ScrollByteIntoView();
			_hexBox.UpdateCaret();
			_hexBox.ReleaseSelection();
			return true;
		}

		protected virtual bool PreProcessWmKeyDown_ShiftShiftKey(ref Message m)
		{
			if (_mouseDown)
			{
				return true;
			}
			if (_shiftDown)
			{
				return true;
			}
			_shiftDown = true;
			if (_hexBox._selectionLength > 0)
			{
				return true;
			}
			_bpiStart = new BytePositionInfo(_hexBox._bytePos, _hexBox._byteCharacterPos);
			return true;
		}

		protected virtual bool PreProcessWmKeyDown_ControlC(ref Message m)
		{
			_hexBox.Copy();
			return true;
		}

		protected virtual bool PreProcessWmKeyDown_ControlX(ref Message m)
		{
			_hexBox.Cut();
			return true;
		}

		protected virtual bool PreProcessWmKeyDown_ControlV(ref Message m)
		{
			_hexBox.Paste();
			return true;
		}

		public virtual bool PreProcessWmChar(ref Message m)
		{
			if (Control.ModifierKeys == Keys.Control)
			{
				return _hexBox.BasePreProcessMessage(ref m);
			}
			bool flag = _hexBox._byteProvider.SupportsWriteByte();
			bool flag2 = _hexBox._byteProvider.SupportsInsertBytes();
			bool flag3 = _hexBox._byteProvider.SupportsDeleteBytes();
			long bytePos = _hexBox._bytePos;
			long selectionLength = _hexBox._selectionLength;
			int num = _hexBox._byteCharacterPos;
			if ((!flag && bytePos != _hexBox._byteProvider.Length) || (!flag2 && bytePos == _hexBox._byteProvider.Length))
			{
				return _hexBox.BasePreProcessMessage(ref m);
			}
			char c = (char)m.WParam.ToInt32();
			if (Uri.IsHexDigit(c))
			{
				if (RaiseKeyPress(c))
				{
					return true;
				}
				if (_hexBox.ReadOnly)
				{
					return true;
				}
				bool flag4 = bytePos == _hexBox._byteProvider.Length;
				if (!flag4 && flag2 && _hexBox.InsertActive && num == 0)
				{
					flag4 = true;
				}
				if (flag3 && flag2 && selectionLength > 0)
				{
					_hexBox._byteProvider.DeleteBytes(bytePos, selectionLength);
					flag4 = true;
					num = 0;
					_hexBox.SetPosition(bytePos, num);
				}
				_hexBox.ReleaseSelection();
				string text = ((byte)((!flag4) ? _hexBox._byteProvider.ReadByte(bytePos) : 0)).ToString("X", Thread.CurrentThread.CurrentCulture);
				if (text.Length == 1)
				{
					text = "0" + text;
				}
				string text2 = c.ToString();
				text2 = ((num != 0) ? (text.Substring(0, 1) + text2) : (text2 + text.Substring(1, 1)));
				byte b = byte.Parse(text2, NumberStyles.AllowHexSpecifier, Thread.CurrentThread.CurrentCulture);
				if (flag4)
				{
					_hexBox._byteProvider.InsertBytes(bytePos, new byte[1] { b });
				}
				else
				{
					_hexBox._byteProvider.WriteByte(bytePos, b);
				}
				PerformPosMoveRight();
				_hexBox.Invalidate();
				return true;
			}
			return _hexBox.BasePreProcessMessage(ref m);
		}

		protected bool RaiseKeyPress(char keyChar)
		{
			KeyPressEventArgs e = new KeyPressEventArgs(keyChar);
			_hexBox.OnKeyPress(e);
			return e.Handled;
		}

		public virtual bool PreProcessWmKeyUp(ref Message m)
		{
			Keys keys = (Keys)m.WParam.ToInt32();
			Keys keys2 = keys | Control.ModifierKeys;
			Keys keys3 = keys2;
			if ((keys3 == Keys.ShiftKey || keys3 == Keys.Insert) && RaiseKeyUp(keys2))
			{
				return true;
			}
			switch (keys2)
			{
			case Keys.ShiftKey:
				_shiftDown = false;
				return true;
			case Keys.Insert:
				return PreProcessWmKeyUp_Insert(ref m);
			default:
				return _hexBox.BasePreProcessMessage(ref m);
			}
		}

		protected virtual bool PreProcessWmKeyUp_Insert(ref Message m)
		{
			_hexBox.InsertActive = !_hexBox.InsertActive;
			return true;
		}

		protected bool RaiseKeyUp(Keys keyData)
		{
			KeyEventArgs e = new KeyEventArgs(keyData);
			_hexBox.OnKeyUp(e);
			return e.Handled;
		}

		protected virtual bool PerformPosMoveLeft()
		{
			long num = _hexBox._bytePos;
			long selectionLength = _hexBox._selectionLength;
			int byteCharacterPos = _hexBox._byteCharacterPos;
			if (selectionLength != 0)
			{
				byteCharacterPos = 0;
				_hexBox.SetPosition(num, byteCharacterPos);
				_hexBox.ReleaseSelection();
			}
			else
			{
				if (num == 0 && byteCharacterPos == 0)
				{
					return true;
				}
				if (byteCharacterPos > 0)
				{
					byteCharacterPos--;
				}
				else
				{
					num = Math.Max(0L, num - 1);
					byteCharacterPos++;
				}
				_hexBox.SetPosition(num, byteCharacterPos);
				if (num < _hexBox._startByte)
				{
					_hexBox.PerformScrollLineUp();
				}
				_hexBox.UpdateCaret();
				_hexBox.Invalidate();
			}
			_hexBox.ScrollByteIntoView();
			return true;
		}

		protected virtual bool PerformPosMoveRight()
		{
			long num = _hexBox._bytePos;
			int byteCharacterPos = _hexBox._byteCharacterPos;
			long selectionLength = _hexBox._selectionLength;
			if (selectionLength != 0)
			{
				num += selectionLength;
				byteCharacterPos = 0;
				_hexBox.SetPosition(num, byteCharacterPos);
				_hexBox.ReleaseSelection();
			}
			else if (num != _hexBox._byteProvider.Length || byteCharacterPos != 0)
			{
				if (byteCharacterPos > 0)
				{
					num = Math.Min(_hexBox._byteProvider.Length, num + 1);
					byteCharacterPos = 0;
				}
				else
				{
					byteCharacterPos++;
				}
				_hexBox.SetPosition(num, byteCharacterPos);
				if (num > _hexBox._endByte - 1)
				{
					_hexBox.PerformScrollLineDown();
				}
				_hexBox.UpdateCaret();
				_hexBox.Invalidate();
			}
			_hexBox.ScrollByteIntoView();
			return true;
		}

		protected virtual bool PerformPosMoveLeftByte()
		{
			long bytePos = _hexBox._bytePos;
			int byteCharacterPos = _hexBox._byteCharacterPos;
			if (bytePos == 0)
			{
				return true;
			}
			bytePos = Math.Max(0L, bytePos - 1);
			byteCharacterPos = 0;
			_hexBox.SetPosition(bytePos, byteCharacterPos);
			if (bytePos < _hexBox._startByte)
			{
				_hexBox.PerformScrollLineUp();
			}
			_hexBox.UpdateCaret();
			_hexBox.ScrollByteIntoView();
			_hexBox.Invalidate();
			return true;
		}

		protected virtual bool PerformPosMoveRightByte()
		{
			long bytePos = _hexBox._bytePos;
			int byteCharacterPos = _hexBox._byteCharacterPos;
			if (bytePos == _hexBox._byteProvider.Length)
			{
				return true;
			}
			bytePos = Math.Min(_hexBox._byteProvider.Length, bytePos + 1);
			byteCharacterPos = 0;
			_hexBox.SetPosition(bytePos, byteCharacterPos);
			if (bytePos > _hexBox._endByte - 1)
			{
				_hexBox.PerformScrollLineDown();
			}
			_hexBox.UpdateCaret();
			_hexBox.ScrollByteIntoView();
			_hexBox.Invalidate();
			return true;
		}

		public virtual PointF GetCaretPointF(long byteIndex)
		{
			return _hexBox.GetBytePointF(byteIndex);
		}

		protected virtual BytePositionInfo GetBytePositionInfo(Point p)
		{
			return _hexBox.GetHexBytePositionInfo(p);
		}
	}

	private class StringKeyInterpreter : KeyInterpreter
	{
		public StringKeyInterpreter(HexBox hexBox)
			: base(hexBox)
		{
			_hexBox._byteCharacterPos = 0;
		}

		public override bool PreProcessWmKeyDown(ref Message m)
		{
			Keys keys = (Keys)m.WParam.ToInt32();
			Keys keys2 = keys | Control.ModifierKeys;
			Keys keys3 = keys2;
			if ((keys3 == Keys.Tab || keys3 == (Keys.Tab | Keys.Shift)) && RaiseKeyDown(keys2))
			{
				return true;
			}
			return keys2 switch
			{
				Keys.Tab | Keys.Shift => PreProcessWmKeyDown_ShiftTab(ref m), 
				Keys.Tab => PreProcessWmKeyDown_Tab(ref m), 
				_ => base.PreProcessWmKeyDown(ref m), 
			};
		}

		protected override bool PreProcessWmKeyDown_Left(ref Message m)
		{
			return PerformPosMoveLeftByte();
		}

		protected override bool PreProcessWmKeyDown_Right(ref Message m)
		{
			return PerformPosMoveRightByte();
		}

		public override bool PreProcessWmChar(ref Message m)
		{
			if (Control.ModifierKeys == Keys.Control)
			{
				return _hexBox.BasePreProcessMessage(ref m);
			}
			bool flag = _hexBox._byteProvider.SupportsWriteByte();
			bool flag2 = _hexBox._byteProvider.SupportsInsertBytes();
			bool flag3 = _hexBox._byteProvider.SupportsDeleteBytes();
			long bytePos = _hexBox._bytePos;
			long selectionLength = _hexBox._selectionLength;
			int byteCharacterPos = _hexBox._byteCharacterPos;
			if ((!flag && bytePos != _hexBox._byteProvider.Length) || (!flag2 && bytePos == _hexBox._byteProvider.Length))
			{
				return _hexBox.BasePreProcessMessage(ref m);
			}
			char c = (char)m.WParam.ToInt32();
			if (RaiseKeyPress(c))
			{
				return true;
			}
			if (_hexBox.ReadOnly)
			{
				return true;
			}
			bool flag4 = bytePos == _hexBox._byteProvider.Length;
			if (!flag4 && flag2 && _hexBox.InsertActive)
			{
				flag4 = true;
			}
			if (flag3 && flag2 && selectionLength > 0)
			{
				_hexBox._byteProvider.DeleteBytes(bytePos, selectionLength);
				flag4 = true;
				byteCharacterPos = 0;
				_hexBox.SetPosition(bytePos, byteCharacterPos);
			}
			_hexBox.ReleaseSelection();
			byte b = _hexBox.ByteCharConverter.ToByte(c);
			if (flag4)
			{
				_hexBox._byteProvider.InsertBytes(bytePos, new byte[1] { b });
			}
			else
			{
				_hexBox._byteProvider.WriteByte(bytePos, b);
			}
			PerformPosMoveRightByte();
			_hexBox.Invalidate();
			return true;
		}

		public override PointF GetCaretPointF(long byteIndex)
		{
			Point gridBytePoint = _hexBox.GetGridBytePoint(byteIndex);
			return _hexBox.GetByteStringPointF(gridBytePoint);
		}

		protected override BytePositionInfo GetBytePositionInfo(Point p)
		{
			return _hexBox.GetStringBytePositionInfo(p);
		}
	}

	private const int THUMPTRACKDELAY = 50;

	private Rectangle _recContent;

	private Rectangle _recLineInfo;

	private Rectangle _recHex;

	private Rectangle _recStringView;

	private StringFormat _stringFormat;

	private SizeF _charSize;

	private int _iHexMaxHBytes;

	private int _iHexMaxVBytes;

	private int _iHexMaxBytes;

	private long _scrollVmin;

	private long _scrollVmax;

	private long _scrollVpos;

	private VScrollBar _vScrollBar;

	private System.Windows.Forms.Timer _thumbTrackTimer = new System.Windows.Forms.Timer();

	private long _thumbTrackPosition;

	private int _lastThumbtrack;

	private int _recBorderLeft = SystemInformation.Border3DSize.Width;

	private int _recBorderRight = SystemInformation.Border3DSize.Width;

	private int _recBorderTop = SystemInformation.Border3DSize.Height;

	private int _recBorderBottom = SystemInformation.Border3DSize.Height;

	private long _startByte;

	private long _endByte;

	private long _bytePos = -1L;

	private int _byteCharacterPos;

	private string _hexStringFormat = "X";

	private IKeyInterpreter _keyInterpreter;

	private EmptyKeyInterpreter _eki;

	private KeyInterpreter _ki;

	private StringKeyInterpreter _ski;

	private bool _caretVisible;

	private bool _abortFind;

	private long _findingPos;

	private bool _insertActive;

	private Color _backColorDisabled = Color.FromName("WhiteSmoke");

	private bool _readOnly;

	private int _bytesPerLine = 16;

	private bool _useFixedBytesPerLine;

	private bool _vScrollBarVisible;

	private IByteProvider _byteProvider;

	private bool _lineInfoVisible;

	private long _lineInfoOffset;

	private BorderStyle _borderStyle = BorderStyle.Fixed3D;

	private bool _stringViewVisible;

	private long _selectionLength;

	private Color _lineInfoForeColor = Color.Empty;

	private Color _selectionBackColor = Color.Blue;

	private Color _selectionForeColor = Color.White;

	private bool _shadowSelectionVisible = true;

	private Color _shadowSelectionColor = Color.FromArgb(100, 60, 188, 255);

	private long _currentLine;

	private int _currentPositionInLine;

	private BuiltInContextMenu _builtInContextMenu;

	private IByteCharConverter _byteCharConverter;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public long CurrentFindingPosition => _findingPos;

	[DefaultValue(typeof(Color), "White")]
	public override Color BackColor
	{
		get
		{
			return base.BackColor;
		}
		set
		{
			base.BackColor = value;
		}
	}

	public override Font Font
	{
		get
		{
			return base.Font;
		}
		set
		{
			base.Font = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Bindable(false)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override string Text
	{
		get
		{
			return base.Text;
		}
		set
		{
			base.Text = value;
		}
	}

	[Browsable(false)]
	[Bindable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override RightToLeft RightToLeft
	{
		get
		{
			return base.RightToLeft;
		}
		set
		{
			base.RightToLeft = value;
		}
	}

	[DefaultValue(typeof(Color), "WhiteSmoke")]
	[Category("Appearance")]
	public Color BackColorDisabled
	{
		get
		{
			return _backColorDisabled;
		}
		set
		{
			_backColorDisabled = value;
		}
	}

	[DefaultValue(false)]
	[Description("Gets or sets if the count of bytes in one line is fix.")]
	[Category("Hex")]
	public bool ReadOnly
	{
		get
		{
			return _readOnly;
		}
		set
		{
			if (_readOnly != value)
			{
				_readOnly = value;
				OnReadOnlyChanged(EventArgs.Empty);
				Invalidate();
			}
		}
	}

	[Description("Gets or sets the maximum count of bytes in one line.")]
	[DefaultValue(16)]
	[Category("Hex")]
	public int BytesPerLine
	{
		get
		{
			return _bytesPerLine;
		}
		set
		{
			if (_bytesPerLine != value)
			{
				_bytesPerLine = value;
				OnBytesPerLineChanged(EventArgs.Empty);
				UpdateRectanglePositioning();
				Invalidate();
			}
		}
	}

	[Description("Gets or sets if the count of bytes in one line is fix.")]
	[DefaultValue(false)]
	[Category("Hex")]
	public bool UseFixedBytesPerLine
	{
		get
		{
			return _useFixedBytesPerLine;
		}
		set
		{
			if (_useFixedBytesPerLine != value)
			{
				_useFixedBytesPerLine = value;
				OnUseFixedBytesPerLineChanged(EventArgs.Empty);
				UpdateRectanglePositioning();
				Invalidate();
			}
		}
	}

	[DefaultValue(false)]
	[Category("Hex")]
	[Description("Gets or sets the visibility of a vertical scroll bar.")]
	public bool VScrollBarVisible
	{
		get
		{
			return _vScrollBarVisible;
		}
		set
		{
			if (_vScrollBarVisible != value)
			{
				_vScrollBarVisible = value;
				if (_vScrollBarVisible)
				{
					base.Controls.Add(_vScrollBar);
				}
				else
				{
					base.Controls.Remove(_vScrollBar);
				}
				UpdateRectanglePositioning();
				UpdateScrollSize();
				OnVScrollBarVisibleChanged(EventArgs.Empty);
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public IByteProvider ByteProvider
	{
		get
		{
			return _byteProvider;
		}
		set
		{
			if (_byteProvider == value)
			{
				return;
			}
			if (value == null)
			{
				ActivateEmptyKeyInterpreter();
			}
			else
			{
				ActivateKeyInterpreter();
			}
			if (_byteProvider != null)
			{
				_byteProvider.LengthChanged -= _byteProvider_LengthChanged;
			}
			_byteProvider = value;
			if (_byteProvider != null)
			{
				_byteProvider.LengthChanged += _byteProvider_LengthChanged;
			}
			OnByteProviderChanged(EventArgs.Empty);
			if (value == null)
			{
				_bytePos = -1L;
				_byteCharacterPos = 0;
				_selectionLength = 0L;
				DestroyCaret();
			}
			else
			{
				SetPosition(0L, 0);
				SetSelectionLength(0L);
				if (_caretVisible && Focused)
				{
					UpdateCaret();
				}
				else
				{
					CreateCaret();
				}
			}
			CheckCurrentLineChanged();
			CheckCurrentPositionInLineChanged();
			_scrollVpos = 0L;
			UpdateVisibilityBytes();
			UpdateRectanglePositioning();
			Invalidate();
		}
	}

	[Description("Gets or sets the visibility of a line info.")]
	[Category("Hex")]
	[DefaultValue(false)]
	public bool LineInfoVisible
	{
		get
		{
			return _lineInfoVisible;
		}
		set
		{
			if (_lineInfoVisible != value)
			{
				_lineInfoVisible = value;
				OnLineInfoVisibleChanged(EventArgs.Empty);
				UpdateRectanglePositioning();
				Invalidate();
			}
		}
	}

	[Description("Gets or sets the offset of the line info.")]
	[Category("Hex")]
	[DefaultValue(0L)]
	public long LineInfoOffset
	{
		get
		{
			return _lineInfoOffset;
		}
		set
		{
			if (_lineInfoOffset != value)
			{
				_lineInfoOffset = value;
				Invalidate();
			}
		}
	}

	[Category("Hex")]
	[Description("Gets or sets the hex box\u00b4s border style.")]
	[DefaultValue(typeof(BorderStyle), "Fixed3D")]
	public BorderStyle BorderStyle
	{
		get
		{
			return _borderStyle;
		}
		set
		{
			if (_borderStyle != value)
			{
				_borderStyle = value;
				switch (_borderStyle)
				{
				case BorderStyle.None:
					_recBorderLeft = (_recBorderTop = (_recBorderRight = (_recBorderBottom = 0)));
					break;
				case BorderStyle.Fixed3D:
					_recBorderLeft = (_recBorderRight = SystemInformation.Border3DSize.Width);
					_recBorderTop = (_recBorderBottom = SystemInformation.Border3DSize.Height);
					break;
				case BorderStyle.FixedSingle:
					_recBorderLeft = (_recBorderTop = (_recBorderRight = (_recBorderBottom = 1)));
					break;
				}
				UpdateRectanglePositioning();
				OnBorderStyleChanged(EventArgs.Empty);
			}
		}
	}

	[Description("Gets or sets the visibility of the string view.")]
	[DefaultValue(false)]
	[Category("Hex")]
	public bool StringViewVisible
	{
		get
		{
			return _stringViewVisible;
		}
		set
		{
			if (_stringViewVisible != value)
			{
				_stringViewVisible = value;
				OnStringViewVisibleChanged(EventArgs.Empty);
				UpdateRectanglePositioning();
				Invalidate();
			}
		}
	}

	[Category("Hex")]
	[DefaultValue(typeof(HexCasing), "Upper")]
	[Description("Gets or sets whether the HexBox control displays the hex characters in upper or lower case.")]
	public HexCasing HexCasing
	{
		get
		{
			if (_hexStringFormat == "X")
			{
				return HexCasing.Upper;
			}
			return HexCasing.Lower;
		}
		set
		{
			string text = ((value != HexCasing.Upper) ? "x" : "X");
			if (!(_hexStringFormat == text))
			{
				_hexStringFormat = text;
				OnHexCasingChanged(EventArgs.Empty);
				Invalidate();
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public long SelectionStart
	{
		get
		{
			return _bytePos;
		}
		set
		{
			SetPosition(value, 0);
			ScrollByteIntoView();
			Invalidate();
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public long SelectionLength
	{
		get
		{
			return _selectionLength;
		}
		set
		{
			SetSelectionLength(value);
			ScrollByteIntoView();
			Invalidate();
		}
	}

	[Description("Gets or sets the line info color. When this property is null, then ForeColor property is used.")]
	[DefaultValue(typeof(Color), "Empty")]
	[Category("Hex")]
	public Color LineInfoForeColor
	{
		get
		{
			return _lineInfoForeColor;
		}
		set
		{
			_lineInfoForeColor = value;
			Invalidate();
		}
	}

	[DefaultValue(typeof(Color), "Blue")]
	[Description("Gets or sets the background color for the selected bytes.")]
	[Category("Hex")]
	public Color SelectionBackColor
	{
		get
		{
			return _selectionBackColor;
		}
		set
		{
			_selectionBackColor = value;
			Invalidate();
		}
	}

	[Description("Gets or sets the foreground color for the selected bytes.")]
	[DefaultValue(typeof(Color), "White")]
	[Category("Hex")]
	public Color SelectionForeColor
	{
		get
		{
			return _selectionForeColor;
		}
		set
		{
			_selectionForeColor = value;
			Invalidate();
		}
	}

	[Description("Gets or sets the visibility of a shadow selection.")]
	[DefaultValue(true)]
	[Category("Hex")]
	public bool ShadowSelectionVisible
	{
		get
		{
			return _shadowSelectionVisible;
		}
		set
		{
			if (_shadowSelectionVisible != value)
			{
				_shadowSelectionVisible = value;
				Invalidate();
			}
		}
	}

	[Category("Hex")]
	[Description("Gets or sets the color of the shadow selection.")]
	public Color ShadowSelectionColor
	{
		get
		{
			return _shadowSelectionColor;
		}
		set
		{
			_shadowSelectionColor = value;
			Invalidate();
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int HorizontalByteCount => _iHexMaxHBytes;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public int VerticalByteCount => _iHexMaxVBytes;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public long CurrentLine => _currentLine;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public long CurrentPositionInLine => _currentPositionInLine;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool InsertActive
	{
		get
		{
			return _insertActive;
		}
		set
		{
			if (_insertActive != value)
			{
				_insertActive = value;
				DestroyCaret();
				CreateCaret();
				OnInsertActiveChanged(EventArgs.Empty);
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public BuiltInContextMenu BuiltInContextMenu => _builtInContextMenu;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public IByteCharConverter ByteCharConverter
	{
		get
		{
			if (_byteCharConverter == null)
			{
				_byteCharConverter = new DefaultByteCharConverter();
			}
			return _byteCharConverter;
		}
		set
		{
			if (value != null && value != _byteCharConverter)
			{
				_byteCharConverter = value;
				Invalidate();
			}
		}
	}

	[Description("Occurs, when the value of InsertActive property has changed.")]
	public event EventHandler InsertActiveChanged;

	[Description("Occurs, when the value of ReadOnly property has changed.")]
	public event EventHandler ReadOnlyChanged;

	[Description("Occurs, when the value of ByteProvider property has changed.")]
	public event EventHandler ByteProviderChanged;

	[Description("Occurs, when the value of SelectionStart property has changed.")]
	public event EventHandler SelectionStartChanged;

	[Description("Occurs, when the value of SelectionLength property has changed.")]
	public event EventHandler SelectionLengthChanged;

	[Description("Occurs, when the value of LineInfoVisible property has changed.")]
	public event EventHandler LineInfoVisibleChanged;

	[Description("Occurs, when the value of StringViewVisible property has changed.")]
	public event EventHandler StringViewVisibleChanged;

	[Description("Occurs, when the value of BorderStyle property has changed.")]
	public event EventHandler BorderStyleChanged;

	[Description("Occurs, when the value of BytesPerLine property has changed.")]
	public event EventHandler BytesPerLineChanged;

	[Description("Occurs, when the value of UseFixedBytesPerLine property has changed.")]
	public event EventHandler UseFixedBytesPerLineChanged;

	[Description("Occurs, when the value of VScrollBarVisible property has changed.")]
	public event EventHandler VScrollBarVisibleChanged;

	[Description("Occurs, when the value of HexCasing property has changed.")]
	public event EventHandler HexCasingChanged;

	[Description("Occurs, when the value of HorizontalByteCount property has changed.")]
	public event EventHandler HorizontalByteCountChanged;

	[Description("Occurs, when the value of VerticalByteCount property has changed.")]
	public event EventHandler VerticalByteCountChanged;

	[Description("Occurs, when the value of CurrentLine property has changed.")]
	public event EventHandler CurrentLineChanged;

	[Description("Occurs, when the value of CurrentPositionInLine property has changed.")]
	public event EventHandler CurrentPositionInLineChanged;

	[Description("Occurs, when Copy method was invoked and ClipBoardData changed.")]
	public event EventHandler Copied;

	[Description("Occurs, when CopyHex method was invoked and ClipBoardData changed.")]
	public event EventHandler CopiedHex;

	public HexBox()
	{
		_vScrollBar = new VScrollBar();
		_vScrollBar.Scroll += _vScrollBar_Scroll;
		_builtInContextMenu = new BuiltInContextMenu(this);
		BackColor = Color.White;
		Font = new Font("Courier New", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		_stringFormat = new StringFormat(StringFormat.GenericTypographic);
		_stringFormat.FormatFlags = StringFormatFlags.MeasureTrailingSpaces;
		ActivateEmptyKeyInterpreter();
		SetStyle(ControlStyles.UserPaint, value: true);
		SetStyle(ControlStyles.DoubleBuffer, value: true);
		SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
		SetStyle(ControlStyles.ResizeRedraw, value: true);
		_thumbTrackTimer.Interval = 50;
		_thumbTrackTimer.Tick += PerformScrollThumbTrack;
	}

	private void _vScrollBar_Scroll(object sender, ScrollEventArgs e)
	{
		switch (e.Type)
		{
		case ScrollEventType.SmallIncrement:
			PerformScrollLineDown();
			break;
		case ScrollEventType.SmallDecrement:
			PerformScrollLineUp();
			break;
		case ScrollEventType.LargeIncrement:
			PerformScrollPageDown();
			break;
		case ScrollEventType.LargeDecrement:
			PerformScrollPageUp();
			break;
		case ScrollEventType.ThumbPosition:
		{
			long pos = FromScrollPos(e.NewValue);
			PerformScrollThumpPosition(pos);
			break;
		}
		case ScrollEventType.ThumbTrack:
		{
			if (_thumbTrackTimer.Enabled)
			{
				_thumbTrackTimer.Enabled = false;
			}
			int tickCount = Environment.TickCount;
			if (tickCount - _lastThumbtrack > 50)
			{
				PerformScrollThumbTrack(null, null);
				_lastThumbtrack = tickCount;
			}
			else
			{
				_thumbTrackPosition = FromScrollPos(e.NewValue);
				_thumbTrackTimer.Enabled = true;
			}
			break;
		}
		}
		e.NewValue = ToScrollPos(_scrollVpos);
	}

	private void PerformScrollThumbTrack(object sender, EventArgs e)
	{
		_thumbTrackTimer.Enabled = false;
		PerformScrollThumpPosition(_thumbTrackPosition);
		_lastThumbtrack = Environment.TickCount;
	}

	private void UpdateScrollSize()
	{
		if (VScrollBarVisible && _byteProvider != null && _byteProvider.Length > 0 && _iHexMaxHBytes != 0)
		{
			long val = (long)Math.Ceiling((double)(_byteProvider.Length + 1) / (double)_iHexMaxHBytes - (double)_iHexMaxVBytes);
			val = Math.Max(0L, val);
			long num = _startByte / _iHexMaxHBytes;
			if (val < _scrollVmax && _scrollVpos == _scrollVmax)
			{
				PerformScrollLineUp();
			}
			if (val != _scrollVmax || num != _scrollVpos)
			{
				_scrollVmin = 0L;
				_scrollVmax = val;
				_scrollVpos = Math.Min(num, val);
				UpdateVScroll();
			}
		}
		else if (VScrollBarVisible)
		{
			_scrollVmin = 0L;
			_scrollVmax = 0L;
			_scrollVpos = 0L;
			UpdateVScroll();
		}
	}

	private void UpdateVScroll()
	{
		int num = ToScrollMax(_scrollVmax);
		if (num > 0)
		{
			_vScrollBar.Minimum = 0;
			_vScrollBar.Maximum = num;
			_vScrollBar.Value = ToScrollPos(_scrollVpos);
			_vScrollBar.Enabled = true;
		}
		else
		{
			_vScrollBar.Enabled = false;
		}
	}

	private int ToScrollPos(long value)
	{
		int num = 65535;
		if (_scrollVmax < num)
		{
			return (int)value;
		}
		double num2 = (double)value / (double)_scrollVmax * 100.0;
		int num3 = (int)Math.Floor((double)num / 100.0 * num2);
		num3 = (int)Math.Max(_scrollVmin, num3);
		return (int)Math.Min(_scrollVmax, num3);
	}

	private long FromScrollPos(int value)
	{
		int num = 65535;
		if (_scrollVmax < num)
		{
			return value;
		}
		double num2 = (double)value / (double)num * 100.0;
		return (int)Math.Floor((double)_scrollVmax / 100.0 * num2);
	}

	private int ToScrollMax(long value)
	{
		long num = 65535L;
		if (value > num)
		{
			return (int)num;
		}
		return (int)value;
	}

	private void PerformScrollToLine(long pos)
	{
		if (pos >= _scrollVmin && pos <= _scrollVmax && pos != _scrollVpos)
		{
			_scrollVpos = pos;
			UpdateVScroll();
			UpdateVisibilityBytes();
			UpdateCaret();
			Invalidate();
		}
	}

	private void PerformScrollLines(int lines)
	{
		long pos;
		if (lines > 0)
		{
			pos = Math.Min(_scrollVmax, _scrollVpos + lines);
		}
		else
		{
			if (lines >= 0)
			{
				return;
			}
			pos = Math.Max(_scrollVmin, _scrollVpos + lines);
		}
		PerformScrollToLine(pos);
	}

	private void PerformScrollLineDown()
	{
		PerformScrollLines(1);
	}

	private void PerformScrollLineUp()
	{
		PerformScrollLines(-1);
	}

	private void PerformScrollPageDown()
	{
		PerformScrollLines(_iHexMaxVBytes);
	}

	private void PerformScrollPageUp()
	{
		PerformScrollLines(-_iHexMaxVBytes);
	}

	private void PerformScrollThumpPosition(long pos)
	{
		int num = ((_scrollVmax > 65535) ? 10 : 9);
		if (ToScrollPos(pos) == ToScrollMax(_scrollVmax) - num)
		{
			pos = _scrollVmax;
		}
		PerformScrollToLine(pos);
	}

	public void ScrollByteIntoView()
	{
		ScrollByteIntoView(_bytePos);
	}

	public void ScrollByteIntoView(long index)
	{
		if (_byteProvider != null && _keyInterpreter != null)
		{
			if (index < _startByte)
			{
				long pos = (long)Math.Floor((double)index / (double)_iHexMaxHBytes);
				PerformScrollThumpPosition(pos);
			}
			else if (index > _endByte)
			{
				long num = (long)Math.Floor((double)index / (double)_iHexMaxHBytes);
				num -= _iHexMaxVBytes - 1;
				PerformScrollThumpPosition(num);
			}
		}
	}

	private void ReleaseSelection()
	{
		if (_selectionLength != 0)
		{
			_selectionLength = 0L;
			OnSelectionLengthChanged(EventArgs.Empty);
			if (!_caretVisible)
			{
				CreateCaret();
			}
			else
			{
				UpdateCaret();
			}
			Invalidate();
		}
	}

	public bool CanSelectAll()
	{
		if (!base.Enabled)
		{
			return false;
		}
		if (_byteProvider == null)
		{
			return false;
		}
		return true;
	}

	public void SelectAll()
	{
		if (ByteProvider != null)
		{
			Select(0L, ByteProvider.Length);
		}
	}

	public void Select(long start, long length)
	{
		if (ByteProvider != null && base.Enabled)
		{
			InternalSelect(start, length);
			ScrollByteIntoView();
		}
	}

	private void InternalSelect(long start, long length)
	{
		int byteCharacterPos = 0;
		if (length > 0 && _caretVisible)
		{
			DestroyCaret();
		}
		else if (length == 0 && !_caretVisible)
		{
			CreateCaret();
		}
		SetPosition(start, byteCharacterPos);
		SetSelectionLength(length);
		UpdateCaret();
		Invalidate();
	}

	private void ActivateEmptyKeyInterpreter()
	{
		if (_eki == null)
		{
			_eki = new EmptyKeyInterpreter(this);
		}
		if (_eki != _keyInterpreter)
		{
			if (_keyInterpreter != null)
			{
				_keyInterpreter.Deactivate();
			}
			_keyInterpreter = _eki;
			_keyInterpreter.Activate();
		}
	}

	private void ActivateKeyInterpreter()
	{
		if (_ki == null)
		{
			_ki = new KeyInterpreter(this);
		}
		if (_ki != _keyInterpreter)
		{
			if (_keyInterpreter != null)
			{
				_keyInterpreter.Deactivate();
			}
			_keyInterpreter = _ki;
			_keyInterpreter.Activate();
		}
	}

	private void ActivateStringKeyInterpreter()
	{
		if (_ski == null)
		{
			_ski = new StringKeyInterpreter(this);
		}
		if (_ski != _keyInterpreter)
		{
			if (_keyInterpreter != null)
			{
				_keyInterpreter.Deactivate();
			}
			_keyInterpreter = _ski;
			_keyInterpreter.Activate();
		}
	}

	private void CreateCaret()
	{
		if (_byteProvider != null && _keyInterpreter != null && !_caretVisible && Focused)
		{
			int nWidth = (InsertActive ? 1 : ((int)_charSize.Width));
			int nHeight = (int)_charSize.Height;
			NativeMethods.CreateCaret(base.Handle, IntPtr.Zero, nWidth, nHeight);
			UpdateCaret();
			NativeMethods.ShowCaret(base.Handle);
			_caretVisible = true;
		}
	}

	private void UpdateCaret()
	{
		if (_byteProvider != null && _keyInterpreter != null)
		{
			long byteIndex = _bytePos - _startByte;
			PointF caretPointF = _keyInterpreter.GetCaretPointF(byteIndex);
			caretPointF.X += (float)_byteCharacterPos * _charSize.Width;
			NativeMethods.SetCaretPos((int)caretPointF.X, (int)caretPointF.Y);
		}
	}

	private void DestroyCaret()
	{
		if (_caretVisible)
		{
			NativeMethods.DestroyCaret();
			_caretVisible = false;
		}
	}

	private void SetCaretPosition(Point p)
	{
		if (_byteProvider != null && _keyInterpreter != null)
		{
			long bytePos = _bytePos;
			int byteCharacterPos = _byteCharacterPos;
			if (_recHex.Contains(p))
			{
				BytePositionInfo hexBytePositionInfo = GetHexBytePositionInfo(p);
				bytePos = hexBytePositionInfo.Index;
				byteCharacterPos = hexBytePositionInfo.CharacterPosition;
				SetPosition(bytePos, byteCharacterPos);
				ActivateKeyInterpreter();
				UpdateCaret();
				Invalidate();
			}
			else if (_recStringView.Contains(p))
			{
				BytePositionInfo stringBytePositionInfo = GetStringBytePositionInfo(p);
				bytePos = stringBytePositionInfo.Index;
				byteCharacterPos = stringBytePositionInfo.CharacterPosition;
				SetPosition(bytePos, byteCharacterPos);
				ActivateStringKeyInterpreter();
				UpdateCaret();
				Invalidate();
			}
		}
	}

	private BytePositionInfo GetHexBytePositionInfo(Point p)
	{
		float num = (float)(p.X - _recHex.X) / _charSize.Width;
		float num2 = (float)(p.Y - _recHex.Y) / _charSize.Height;
		int num3 = (int)num;
		int num4 = (int)num2;
		int num5 = num3 / 3 + 1;
		long num6 = Math.Min(_byteProvider.Length, _startByte + (_iHexMaxHBytes * (num4 + 1) - _iHexMaxHBytes) + num5 - 1);
		int num7 = num3 % 3;
		if (num7 > 1)
		{
			num7 = 1;
		}
		if (num6 == _byteProvider.Length)
		{
			num7 = 0;
		}
		if (num6 < 0)
		{
			return new BytePositionInfo(0L, 0);
		}
		return new BytePositionInfo(num6, num7);
	}

	private BytePositionInfo GetStringBytePositionInfo(Point p)
	{
		float num = (float)(p.X - _recStringView.X) / _charSize.Width;
		float num2 = (float)(p.Y - _recStringView.Y) / _charSize.Height;
		int num3 = (int)num;
		int num4 = (int)num2;
		int num5 = num3 + 1;
		long num6 = Math.Min(_byteProvider.Length, _startByte + (_iHexMaxHBytes * (num4 + 1) - _iHexMaxHBytes) + num5 - 1);
		int characterPosition = 0;
		if (num6 < 0)
		{
			return new BytePositionInfo(0L, 0);
		}
		return new BytePositionInfo(num6, characterPosition);
	}

	[SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
	[SecurityPermission(SecurityAction.InheritanceDemand, UnmanagedCode = true)]
	public override bool PreProcessMessage(ref Message m)
	{
		return m.Msg switch
		{
			256 => _keyInterpreter.PreProcessWmKeyDown(ref m), 
			258 => _keyInterpreter.PreProcessWmChar(ref m), 
			257 => _keyInterpreter.PreProcessWmKeyUp(ref m), 
			_ => base.PreProcessMessage(ref m), 
		};
	}

	private bool BasePreProcessMessage(ref Message m)
	{
		return base.PreProcessMessage(ref m);
	}

	public long Find(byte[] bytes, long startIndex)
	{
		int num = 0;
		int num2 = bytes.Length;
		_abortFind = false;
		for (long num3 = startIndex; num3 < _byteProvider.Length; num3++)
		{
			if (_abortFind)
			{
				return -2L;
			}
			if (num3 % 1000 == 0)
			{
				Application.DoEvents();
			}
			if (_byteProvider.ReadByte(num3) != bytes[num])
			{
				num3 -= num;
				num = 0;
				_findingPos = num3;
				continue;
			}
			num++;
			if (num == num2)
			{
				long num4 = num3 - num2 + 1;
				Select(num4, num2);
				ScrollByteIntoView(_bytePos + _selectionLength);
				ScrollByteIntoView(_bytePos);
				return num4;
			}
		}
		return -1L;
	}

	public void AbortFind()
	{
		_abortFind = true;
	}

	private byte[] GetCopyData()
	{
		if (!CanCopy())
		{
			return new byte[0];
		}
		byte[] array = new byte[_selectionLength];
		int num = -1;
		for (long num2 = _bytePos; num2 < _bytePos + _selectionLength; num2++)
		{
			num++;
			array[num] = _byteProvider.ReadByte(num2);
		}
		return array;
	}

	public void Copy()
	{
		if (CanCopy())
		{
			byte[] copyData = GetCopyData();
			DataObject dataObject = new DataObject();
			string data = Encoding.ASCII.GetString(copyData, 0, copyData.Length);
			dataObject.SetData(typeof(string), data);
			MemoryStream data2 = new MemoryStream(copyData, 0, copyData.Length, writable: false, publiclyVisible: true);
			dataObject.SetData("BinaryData", data2);
			Clipboard.SetDataObject(dataObject, copy: true);
			UpdateCaret();
			ScrollByteIntoView();
			Invalidate();
			OnCopied(EventArgs.Empty);
		}
	}

	public bool CanCopy()
	{
		if (_selectionLength < 1 || _byteProvider == null)
		{
			return false;
		}
		return true;
	}

	public void Cut()
	{
		if (CanCut())
		{
			Copy();
			_byteProvider.DeleteBytes(_bytePos, _selectionLength);
			_byteCharacterPos = 0;
			UpdateCaret();
			ScrollByteIntoView();
			ReleaseSelection();
			Invalidate();
			Refresh();
		}
	}

	public bool CanCut()
	{
		if (ReadOnly || !base.Enabled)
		{
			return false;
		}
		if (_byteProvider == null)
		{
			return false;
		}
		if (_selectionLength < 1 || !_byteProvider.SupportsDeleteBytes())
		{
			return false;
		}
		return true;
	}

	public void Paste()
	{
		if (!CanPaste())
		{
			return;
		}
		if (_selectionLength > 0)
		{
			_byteProvider.DeleteBytes(_bytePos, _selectionLength);
		}
		byte[] array = null;
		IDataObject dataObject = Clipboard.GetDataObject();
		if (dataObject.GetDataPresent("BinaryData"))
		{
			MemoryStream memoryStream = (MemoryStream)dataObject.GetData("BinaryData");
			array = new byte[memoryStream.Length];
			memoryStream.Read(array, 0, array.Length);
		}
		else
		{
			if (!dataObject.GetDataPresent(typeof(string)))
			{
				return;
			}
			string s = (string)dataObject.GetData(typeof(string));
			array = Encoding.ASCII.GetBytes(s);
		}
		_byteProvider.InsertBytes(_bytePos, array);
		SetPosition(_bytePos + array.Length, 0);
		ReleaseSelection();
		ScrollByteIntoView();
		UpdateCaret();
		Invalidate();
	}

	public bool CanPaste()
	{
		if (ReadOnly || !base.Enabled)
		{
			return false;
		}
		if (_byteProvider == null || !_byteProvider.SupportsInsertBytes())
		{
			return false;
		}
		if (!_byteProvider.SupportsDeleteBytes() && _selectionLength > 0)
		{
			return false;
		}
		IDataObject dataObject = Clipboard.GetDataObject();
		if (dataObject.GetDataPresent("BinaryData"))
		{
			return true;
		}
		if (dataObject.GetDataPresent(typeof(string)))
		{
			return true;
		}
		return false;
	}

	public bool CanPasteHex()
	{
		if (!CanPaste())
		{
			return false;
		}
		byte[] array = null;
		IDataObject dataObject = Clipboard.GetDataObject();
		if (dataObject.GetDataPresent(typeof(string)))
		{
			string hex = (string)dataObject.GetData(typeof(string));
			array = ConvertHexToBytes(hex);
			return array != null;
		}
		return false;
	}

	public void PasteHex()
	{
		if (!CanPaste())
		{
			return;
		}
		byte[] array = null;
		IDataObject dataObject = Clipboard.GetDataObject();
		if (!dataObject.GetDataPresent(typeof(string)))
		{
			return;
		}
		string hex = (string)dataObject.GetData(typeof(string));
		array = ConvertHexToBytes(hex);
		if (array != null)
		{
			if (_selectionLength > 0)
			{
				_byteProvider.DeleteBytes(_bytePos, _selectionLength);
			}
			_byteProvider.InsertBytes(_bytePos, array);
			SetPosition(_bytePos + array.Length, 0);
			ReleaseSelection();
			ScrollByteIntoView();
			UpdateCaret();
			Invalidate();
		}
	}

	public void CopyHex()
	{
		if (CanCopy())
		{
			byte[] copyData = GetCopyData();
			DataObject dataObject = new DataObject();
			string data = ConvertBytesToHex(copyData);
			dataObject.SetData(typeof(string), data);
			MemoryStream data2 = new MemoryStream(copyData, 0, copyData.Length, writable: false, publiclyVisible: true);
			dataObject.SetData("BinaryData", data2);
			Clipboard.SetDataObject(dataObject, copy: true);
			UpdateCaret();
			ScrollByteIntoView();
			Invalidate();
			OnCopiedHex(EventArgs.Empty);
		}
	}

	protected override void OnPaintBackground(PaintEventArgs e)
	{
		switch (_borderStyle)
		{
		case BorderStyle.Fixed3D:
			if (TextBoxRenderer.IsSupported)
			{
				VisualStyleElement element = VisualStyleElement.TextBox.TextEdit.Normal;
				Color color = BackColor;
				if (base.Enabled)
				{
					if (ReadOnly)
					{
						element = VisualStyleElement.TextBox.TextEdit.ReadOnly;
					}
					else if (Focused)
					{
						element = VisualStyleElement.TextBox.TextEdit.Focused;
					}
				}
				else
				{
					element = VisualStyleElement.TextBox.TextEdit.Disabled;
					color = BackColorDisabled;
				}
				VisualStyleRenderer visualStyleRenderer = new VisualStyleRenderer(element);
				visualStyleRenderer.DrawBackground(e.Graphics, base.ClientRectangle);
				Rectangle backgroundContentRectangle = visualStyleRenderer.GetBackgroundContentRectangle(e.Graphics, base.ClientRectangle);
				e.Graphics.FillRectangle(new SolidBrush(color), backgroundContentRectangle);
			}
			else
			{
				e.Graphics.FillRectangle(new SolidBrush(BackColor), base.ClientRectangle);
				ControlPaint.DrawBorder3D(e.Graphics, base.ClientRectangle, Border3DStyle.Sunken);
			}
			break;
		case BorderStyle.FixedSingle:
			e.Graphics.FillRectangle(new SolidBrush(BackColor), base.ClientRectangle);
			ControlPaint.DrawBorder(e.Graphics, base.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
			break;
		default:
			e.Graphics.FillRectangle(new SolidBrush(BackColor), base.ClientRectangle);
			break;
		}
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);
		if (_byteProvider == null)
		{
			return;
		}
		Region region = new Region(base.ClientRectangle);
		region.Exclude(_recContent);
		e.Graphics.ExcludeClip(region);
		UpdateVisibilityBytes();
		if (_lineInfoVisible)
		{
			PaintLineInfo(e.Graphics, _startByte, _endByte);
		}
		if (!_stringViewVisible)
		{
			PaintHex(e.Graphics, _startByte, _endByte);
			return;
		}
		PaintHexAndStringView(e.Graphics, _startByte, _endByte);
		if (_shadowSelectionVisible)
		{
			PaintCurrentBytesSign(e.Graphics);
		}
	}

	private void PaintLineInfo(Graphics g, long startByte, long endByte)
	{
		endByte = Math.Min(_byteProvider.Length - 1, endByte);
		Color color = ((LineInfoForeColor != Color.Empty) ? LineInfoForeColor : ForeColor);
		Brush brush = new SolidBrush(color);
		int num = GetGridBytePoint(endByte - startByte).Y + 1;
		for (int i = 0; i < num; i++)
		{
			long num2 = startByte + _iHexMaxHBytes * i + _lineInfoOffset;
			PointF bytePointF = GetBytePointF(new Point(0, i));
			string text = num2.ToString(_hexStringFormat, Thread.CurrentThread.CurrentCulture);
			int num3 = 8 - text.Length;
			string s = ((num3 <= -1) ? new string('~', 8) : (new string('0', 8 - text.Length) + text));
			g.DrawString(s, Font, brush, new PointF(_recLineInfo.X, bytePointF.Y), _stringFormat);
		}
	}

	private void PaintHex(Graphics g, long startByte, long endByte)
	{
		Brush brush = new SolidBrush(GetDefaultForeColor());
		Brush brush2 = new SolidBrush(_selectionForeColor);
		Brush brushBack = new SolidBrush(_selectionBackColor);
		int num = -1;
		long num2 = Math.Min(_byteProvider.Length - 1, endByte + _iHexMaxHBytes);
		bool flag = _keyInterpreter == null || _keyInterpreter.GetType() == typeof(KeyInterpreter);
		for (long num3 = startByte; num3 < num2 + 1; num3++)
		{
			num++;
			Point gridBytePoint = GetGridBytePoint(num);
			byte b = _byteProvider.ReadByte(num3);
			if (num3 >= _bytePos && num3 <= _bytePos + _selectionLength - 1 && _selectionLength != 0 && flag)
			{
				PaintHexStringSelected(g, b, brush2, brushBack, gridBytePoint);
			}
			else
			{
				PaintHexString(g, b, brush, gridBytePoint);
			}
		}
	}

	private void PaintHexString(Graphics g, byte b, Brush brush, Point gridPoint)
	{
		PointF bytePointF = GetBytePointF(gridPoint);
		string text = ConvertByteToHex(b);
		g.DrawString(text.Substring(0, 1), Font, brush, bytePointF, _stringFormat);
		bytePointF.X += _charSize.Width;
		g.DrawString(text.Substring(1, 1), Font, brush, bytePointF, _stringFormat);
	}

	private void PaintHexStringSelected(Graphics g, byte b, Brush brush, Brush brushBack, Point gridPoint)
	{
		string text = b.ToString(_hexStringFormat, Thread.CurrentThread.CurrentCulture);
		if (text.Length == 1)
		{
			text = "0" + text;
		}
		PointF bytePointF = GetBytePointF(gridPoint);
		float num = ((gridPoint.X + 1 == _iHexMaxHBytes) ? (_charSize.Width * 2f) : (_charSize.Width * 3f));
		g.FillRectangle(brushBack, bytePointF.X, bytePointF.Y, num, _charSize.Height);
		g.DrawString(text.Substring(0, 1), Font, brush, bytePointF, _stringFormat);
		bytePointF.X += _charSize.Width;
		g.DrawString(text.Substring(1, 1), Font, brush, bytePointF, _stringFormat);
	}

	private void PaintHexAndStringView(Graphics g, long startByte, long endByte)
	{
		Brush brush = new SolidBrush(GetDefaultForeColor());
		Brush brush2 = new SolidBrush(_selectionForeColor);
		Brush brush3 = new SolidBrush(_selectionBackColor);
		int num = -1;
		long num2 = Math.Min(_byteProvider.Length - 1, endByte + _iHexMaxHBytes);
		bool flag = _keyInterpreter == null || _keyInterpreter.GetType() == typeof(KeyInterpreter);
		bool flag2 = _keyInterpreter != null && _keyInterpreter.GetType() == typeof(StringKeyInterpreter);
		for (long num3 = startByte; num3 < num2 + 1; num3++)
		{
			num++;
			Point gridBytePoint = GetGridBytePoint(num);
			PointF byteStringPointF = GetByteStringPointF(gridBytePoint);
			byte b = _byteProvider.ReadByte(num3);
			bool flag3 = num3 >= _bytePos && num3 <= _bytePos + _selectionLength - 1 && _selectionLength != 0;
			if (flag3 && flag)
			{
				PaintHexStringSelected(g, b, brush2, brush3, gridBytePoint);
			}
			else
			{
				PaintHexString(g, b, brush, gridBytePoint);
			}
			string s = new string(ByteCharConverter.ToChar(b), 1);
			if (flag3 && flag2)
			{
				g.FillRectangle(brush3, byteStringPointF.X, byteStringPointF.Y, _charSize.Width, _charSize.Height);
				g.DrawString(s, Font, brush2, byteStringPointF, _stringFormat);
			}
			else
			{
				g.DrawString(s, Font, brush, byteStringPointF, _stringFormat);
			}
		}
	}

	private void PaintCurrentBytesSign(Graphics g)
	{
		if (_keyInterpreter == null || !Focused || _bytePos == -1 || !base.Enabled)
		{
			return;
		}
		if (_keyInterpreter.GetType() == typeof(KeyInterpreter))
		{
			if (_selectionLength == 0)
			{
				Point gridBytePoint = GetGridBytePoint(_bytePos - _startByte);
				PointF byteStringPointF = GetByteStringPointF(gridBytePoint);
				Size size = new Size((int)_charSize.Width, (int)_charSize.Height);
				Rectangle rec = new Rectangle((int)byteStringPointF.X, (int)byteStringPointF.Y, size.Width, size.Height);
				if (rec.IntersectsWith(_recStringView))
				{
					rec.Intersect(_recStringView);
					PaintCurrentByteSign(g, rec);
				}
				return;
			}
			int num = (int)((float)_recStringView.Width - _charSize.Width);
			Point gridBytePoint2 = GetGridBytePoint(_bytePos - _startByte);
			PointF byteStringPointF2 = GetByteStringPointF(gridBytePoint2);
			Point gridBytePoint3 = GetGridBytePoint(_bytePos - _startByte + _selectionLength - 1);
			PointF byteStringPointF3 = GetByteStringPointF(gridBytePoint3);
			int num2 = gridBytePoint3.Y - gridBytePoint2.Y;
			if (num2 == 0)
			{
				Rectangle rec2 = new Rectangle((int)byteStringPointF2.X, (int)byteStringPointF2.Y, (int)(byteStringPointF3.X - byteStringPointF2.X + _charSize.Width), (int)_charSize.Height);
				if (rec2.IntersectsWith(_recStringView))
				{
					rec2.Intersect(_recStringView);
					PaintCurrentByteSign(g, rec2);
				}
				return;
			}
			Rectangle rec3 = new Rectangle((int)byteStringPointF2.X, (int)byteStringPointF2.Y, (int)((float)(_recStringView.X + num) - byteStringPointF2.X + _charSize.Width), (int)_charSize.Height);
			if (rec3.IntersectsWith(_recStringView))
			{
				rec3.Intersect(_recStringView);
				PaintCurrentByteSign(g, rec3);
			}
			if (num2 > 1)
			{
				Rectangle rec4 = new Rectangle(_recStringView.X, (int)(byteStringPointF2.Y + _charSize.Height), _recStringView.Width, (int)(_charSize.Height * (float)(num2 - 1)));
				if (rec4.IntersectsWith(_recStringView))
				{
					rec4.Intersect(_recStringView);
					PaintCurrentByteSign(g, rec4);
				}
			}
			Rectangle rec5 = new Rectangle(_recStringView.X, (int)byteStringPointF3.Y, (int)(byteStringPointF3.X - (float)_recStringView.X + _charSize.Width), (int)_charSize.Height);
			if (rec5.IntersectsWith(_recStringView))
			{
				rec5.Intersect(_recStringView);
				PaintCurrentByteSign(g, rec5);
			}
			return;
		}
		if (_selectionLength == 0)
		{
			Point gridBytePoint4 = GetGridBytePoint(_bytePos - _startByte);
			PointF bytePointF = GetBytePointF(gridBytePoint4);
			Size size2 = new Size((int)_charSize.Width * 2, (int)_charSize.Height);
			Rectangle rec6 = new Rectangle((int)bytePointF.X, (int)bytePointF.Y, size2.Width, size2.Height);
			PaintCurrentByteSign(g, rec6);
			return;
		}
		int num3 = (int)((float)_recHex.Width - _charSize.Width * 5f);
		Point gridBytePoint5 = GetGridBytePoint(_bytePos - _startByte);
		PointF bytePointF2 = GetBytePointF(gridBytePoint5);
		Point gridBytePoint6 = GetGridBytePoint(_bytePos - _startByte + _selectionLength - 1);
		PointF bytePointF3 = GetBytePointF(gridBytePoint6);
		int num4 = gridBytePoint6.Y - gridBytePoint5.Y;
		if (num4 == 0)
		{
			Rectangle rec7 = new Rectangle((int)bytePointF2.X, (int)bytePointF2.Y, (int)(bytePointF3.X - bytePointF2.X + _charSize.Width * 2f), (int)_charSize.Height);
			if (rec7.IntersectsWith(_recHex))
			{
				rec7.Intersect(_recHex);
				PaintCurrentByteSign(g, rec7);
			}
			return;
		}
		Rectangle rec8 = new Rectangle((int)bytePointF2.X, (int)bytePointF2.Y, (int)((float)(_recHex.X + num3) - bytePointF2.X + _charSize.Width * 2f), (int)_charSize.Height);
		if (rec8.IntersectsWith(_recHex))
		{
			rec8.Intersect(_recHex);
			PaintCurrentByteSign(g, rec8);
		}
		if (num4 > 1)
		{
			Rectangle rec9 = new Rectangle(_recHex.X, (int)(bytePointF2.Y + _charSize.Height), (int)((float)num3 + _charSize.Width * 2f), (int)(_charSize.Height * (float)(num4 - 1)));
			if (rec9.IntersectsWith(_recHex))
			{
				rec9.Intersect(_recHex);
				PaintCurrentByteSign(g, rec9);
			}
		}
		Rectangle rec10 = new Rectangle(_recHex.X, (int)bytePointF3.Y, (int)(bytePointF3.X - (float)_recHex.X + _charSize.Width * 2f), (int)_charSize.Height);
		if (rec10.IntersectsWith(_recHex))
		{
			rec10.Intersect(_recHex);
			PaintCurrentByteSign(g, rec10);
		}
	}

	private void PaintCurrentByteSign(Graphics g, Rectangle rec)
	{
		if (rec.Top >= 0 && rec.Left >= 0 && rec.Width > 0 && rec.Height > 0)
		{
			Bitmap image = new Bitmap(rec.Width, rec.Height);
			Graphics graphics = Graphics.FromImage(image);
			SolidBrush brush = new SolidBrush(_shadowSelectionColor);
			graphics.FillRectangle(brush, 0, 0, rec.Width, rec.Height);
			g.CompositingQuality = CompositingQuality.GammaCorrected;
			g.DrawImage(image, rec.Left, rec.Top);
		}
	}

	private Color GetDefaultForeColor()
	{
		if (base.Enabled)
		{
			return ForeColor;
		}
		return Color.Gray;
	}

	private void UpdateVisibilityBytes()
	{
		if (_byteProvider != null && _byteProvider.Length != 0)
		{
			_startByte = (_scrollVpos + 1) * _iHexMaxHBytes - _iHexMaxHBytes;
			_endByte = Math.Min(_byteProvider.Length - 1, _startByte + _iHexMaxBytes);
		}
	}

	private void UpdateRectanglePositioning()
	{
		SizeF sizeF = CreateGraphics().MeasureString("A", Font, 100, _stringFormat);
		_charSize = new SizeF((float)Math.Ceiling(sizeF.Width), (float)Math.Ceiling(sizeF.Height));
		_recContent = base.ClientRectangle;
		_recContent.X += _recBorderLeft;
		_recContent.Y += _recBorderTop;
		_recContent.Width -= _recBorderRight + _recBorderLeft;
		_recContent.Height -= _recBorderBottom + _recBorderTop;
		if (_vScrollBarVisible)
		{
			_recContent.Width -= _vScrollBar.Width;
			_vScrollBar.Left = _recContent.X + _recContent.Width;
			_vScrollBar.Top = _recContent.Y;
			_vScrollBar.Height = _recContent.Height;
		}
		int num = 4;
		if (_lineInfoVisible)
		{
			_recLineInfo = new Rectangle(_recContent.X + num, _recContent.Y, (int)(_charSize.Width * 10f), _recContent.Height);
		}
		else
		{
			_recLineInfo = Rectangle.Empty;
			_recLineInfo.X = num;
		}
		_recHex = new Rectangle(_recLineInfo.X + _recLineInfo.Width, _recLineInfo.Y, _recContent.Width - _recLineInfo.Width, _recContent.Height);
		if (UseFixedBytesPerLine)
		{
			SetHorizontalByteCount(_bytesPerLine);
			_recHex.Width = (int)Math.Floor((double)_iHexMaxHBytes * (double)_charSize.Width * 3.0 + (double)(2f * _charSize.Width));
		}
		else
		{
			int num2 = (int)Math.Floor((double)_recHex.Width / (double)_charSize.Width);
			if (num2 > 1)
			{
				SetHorizontalByteCount((int)Math.Floor((double)num2 / 3.0));
			}
			else
			{
				SetHorizontalByteCount(num2);
			}
		}
		if (_stringViewVisible)
		{
			_recStringView = new Rectangle(_recHex.X + _recHex.Width, _recHex.Y, (int)(_charSize.Width * (float)_iHexMaxHBytes), _recHex.Height);
		}
		else
		{
			_recStringView = Rectangle.Empty;
		}
		int verticalByteCount = (int)Math.Floor((double)_recHex.Height / (double)_charSize.Height);
		SetVerticalByteCount(verticalByteCount);
		_iHexMaxBytes = _iHexMaxHBytes * _iHexMaxVBytes;
		UpdateScrollSize();
	}

	private PointF GetBytePointF(long byteIndex)
	{
		Point gridBytePoint = GetGridBytePoint(byteIndex);
		return GetBytePointF(gridBytePoint);
	}

	private PointF GetBytePointF(Point gp)
	{
		float num = 3f * _charSize.Width * (float)gp.X + (float)_recHex.X;
		float num2 = (float)(gp.Y + 1) * _charSize.Height - _charSize.Height + (float)_recHex.Y;
		return new PointF(num, num2);
	}

	private PointF GetByteStringPointF(Point gp)
	{
		float num = _charSize.Width * (float)gp.X + (float)_recStringView.X;
		float num2 = (float)(gp.Y + 1) * _charSize.Height - _charSize.Height + (float)_recStringView.Y;
		return new PointF(num, num2);
	}

	private Point GetGridBytePoint(long byteIndex)
	{
		int num = (int)Math.Floor((double)byteIndex / (double)_iHexMaxHBytes);
		int num2 = (int)(byteIndex + _iHexMaxHBytes - _iHexMaxHBytes * (num + 1));
		return new Point(num2, num);
	}

	private string ConvertBytesToHex(byte[] data)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (byte b in data)
		{
			string value = ConvertByteToHex(b);
			stringBuilder.Append(value);
			stringBuilder.Append(" ");
		}
		if (stringBuilder.Length > 0)
		{
			stringBuilder.Remove(stringBuilder.Length - 1, 1);
		}
		return stringBuilder.ToString();
	}

	private string ConvertByteToHex(byte b)
	{
		string text = b.ToString(_hexStringFormat, Thread.CurrentThread.CurrentCulture);
		if (text.Length == 1)
		{
			text = "0" + text;
		}
		return text;
	}

	private byte[] ConvertHexToBytes(string hex)
	{
		if (string.IsNullOrEmpty(hex))
		{
			return null;
		}
		hex = hex.Trim();
		string[] array = hex.Split(' ');
		byte[] array2 = new byte[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			string hex2 = array[i];
			if (!ConvertHexToByte(hex2, out var b))
			{
				return null;
			}
			array2[i] = b;
		}
		return array2;
	}

	private bool ConvertHexToByte(string hex, out byte b)
	{
		return byte.TryParse(hex, NumberStyles.HexNumber, Thread.CurrentThread.CurrentCulture, out b);
	}

	private void SetPosition(long bytePos)
	{
		SetPosition(bytePos, _byteCharacterPos);
	}

	private void SetPosition(long bytePos, int byteCharacterPos)
	{
		if (_byteCharacterPos != byteCharacterPos)
		{
			_byteCharacterPos = byteCharacterPos;
		}
		if (bytePos != _bytePos)
		{
			_bytePos = bytePos;
			CheckCurrentLineChanged();
			CheckCurrentPositionInLineChanged();
			OnSelectionStartChanged(EventArgs.Empty);
		}
	}

	private void SetSelectionLength(long selectionLength)
	{
		if (selectionLength != _selectionLength)
		{
			_selectionLength = selectionLength;
			OnSelectionLengthChanged(EventArgs.Empty);
		}
	}

	private void SetHorizontalByteCount(int value)
	{
		if (_iHexMaxHBytes != value)
		{
			_iHexMaxHBytes = value;
			OnHorizontalByteCountChanged(EventArgs.Empty);
		}
	}

	private void SetVerticalByteCount(int value)
	{
		if (_iHexMaxVBytes != value)
		{
			_iHexMaxVBytes = value;
			OnVerticalByteCountChanged(EventArgs.Empty);
		}
	}

	private void CheckCurrentLineChanged()
	{
		long num = (long)Math.Floor((double)_bytePos / (double)_iHexMaxHBytes) + 1;
		if (_byteProvider == null && _currentLine != 0)
		{
			_currentLine = 0L;
			OnCurrentLineChanged(EventArgs.Empty);
		}
		else if (num != _currentLine)
		{
			_currentLine = num;
			OnCurrentLineChanged(EventArgs.Empty);
		}
	}

	private void CheckCurrentPositionInLineChanged()
	{
		int num = GetGridBytePoint(_bytePos).X + 1;
		if (_byteProvider == null && _currentPositionInLine != 0)
		{
			_currentPositionInLine = 0;
			OnCurrentPositionInLineChanged(EventArgs.Empty);
		}
		else if (num != _currentPositionInLine)
		{
			_currentPositionInLine = num;
			OnCurrentPositionInLineChanged(EventArgs.Empty);
		}
	}

	protected virtual void OnInsertActiveChanged(EventArgs e)
	{
		if (this.InsertActiveChanged != null)
		{
			this.InsertActiveChanged(this, e);
		}
	}

	protected virtual void OnReadOnlyChanged(EventArgs e)
	{
		if (this.ReadOnlyChanged != null)
		{
			this.ReadOnlyChanged(this, e);
		}
	}

	protected virtual void OnByteProviderChanged(EventArgs e)
	{
		if (this.ByteProviderChanged != null)
		{
			this.ByteProviderChanged(this, e);
		}
	}

	protected virtual void OnSelectionStartChanged(EventArgs e)
	{
		if (this.SelectionStartChanged != null)
		{
			this.SelectionStartChanged(this, e);
		}
	}

	protected virtual void OnSelectionLengthChanged(EventArgs e)
	{
		if (this.SelectionLengthChanged != null)
		{
			this.SelectionLengthChanged(this, e);
		}
	}

	protected virtual void OnLineInfoVisibleChanged(EventArgs e)
	{
		if (this.LineInfoVisibleChanged != null)
		{
			this.LineInfoVisibleChanged(this, e);
		}
	}

	protected virtual void OnStringViewVisibleChanged(EventArgs e)
	{
		if (this.StringViewVisibleChanged != null)
		{
			this.StringViewVisibleChanged(this, e);
		}
	}

	protected virtual void OnBorderStyleChanged(EventArgs e)
	{
		if (this.BorderStyleChanged != null)
		{
			this.BorderStyleChanged(this, e);
		}
	}

	protected virtual void OnUseFixedBytesPerLineChanged(EventArgs e)
	{
		if (this.UseFixedBytesPerLineChanged != null)
		{
			this.UseFixedBytesPerLineChanged(this, e);
		}
	}

	protected virtual void OnBytesPerLineChanged(EventArgs e)
	{
		if (this.BytesPerLineChanged != null)
		{
			this.BytesPerLineChanged(this, e);
		}
	}

	protected virtual void OnVScrollBarVisibleChanged(EventArgs e)
	{
		if (this.VScrollBarVisibleChanged != null)
		{
			this.VScrollBarVisibleChanged(this, e);
		}
	}

	protected virtual void OnHexCasingChanged(EventArgs e)
	{
		if (this.HexCasingChanged != null)
		{
			this.HexCasingChanged(this, e);
		}
	}

	protected virtual void OnHorizontalByteCountChanged(EventArgs e)
	{
		if (this.HorizontalByteCountChanged != null)
		{
			this.HorizontalByteCountChanged(this, e);
		}
	}

	protected virtual void OnVerticalByteCountChanged(EventArgs e)
	{
		if (this.VerticalByteCountChanged != null)
		{
			this.VerticalByteCountChanged(this, e);
		}
	}

	protected virtual void OnCurrentLineChanged(EventArgs e)
	{
		if (this.CurrentLineChanged != null)
		{
			this.CurrentLineChanged(this, e);
		}
	}

	protected virtual void OnCurrentPositionInLineChanged(EventArgs e)
	{
		if (this.CurrentPositionInLineChanged != null)
		{
			this.CurrentPositionInLineChanged(this, e);
		}
	}

	protected virtual void OnCopied(EventArgs e)
	{
		if (this.Copied != null)
		{
			this.Copied(this, e);
		}
	}

	protected virtual void OnCopiedHex(EventArgs e)
	{
		if (this.CopiedHex != null)
		{
			this.CopiedHex(this, e);
		}
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		if (!Focused)
		{
			Focus();
		}
		if (e.Button == MouseButtons.Left)
		{
			SetCaretPosition(new Point(e.X, e.Y));
		}
		base.OnMouseDown(e);
	}

	protected override void OnMouseWheel(MouseEventArgs e)
	{
		int lines = -(e.Delta * SystemInformation.MouseWheelScrollLines / 120);
		PerformScrollLines(lines);
		base.OnMouseWheel(e);
	}

	protected override void OnResize(EventArgs e)
	{
		base.OnResize(e);
		UpdateRectanglePositioning();
	}

	protected override void OnGotFocus(EventArgs e)
	{
		base.OnGotFocus(e);
		CreateCaret();
	}

	protected override void OnLostFocus(EventArgs e)
	{
		base.OnLostFocus(e);
		DestroyCaret();
	}

	private void _byteProvider_LengthChanged(object sender, EventArgs e)
	{
		UpdateScrollSize();
	}
}
