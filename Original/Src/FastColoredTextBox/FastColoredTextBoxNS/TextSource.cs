using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace FastColoredTextBoxNS;

public class TextSource : IList<Line>, ICollection<Line>, IEnumerable<Line>, IEnumerable, IDisposable
{
	public class TextChangedEventArgs : EventArgs
	{
		public int iFromLine;

		public int iToLine;

		public TextChangedEventArgs(int iFromLine, int iToLine)
		{
			this.iFromLine = iFromLine;
			this.iToLine = iToLine;
		}
	}

	protected readonly List<Line> lines = new List<Line>();

	protected LinesAccessor linesAccessor;

	private int lastLineUniqueId;

	private FastColoredTextBox currentTB;

	public readonly Style[] Styles;

	public CommandManager Manager { get; set; }

	public FastColoredTextBox CurrentTB
	{
		get
		{
			return currentTB;
		}
		set
		{
			if (currentTB != value)
			{
				currentTB = value;
				OnCurrentTBChanged();
			}
		}
	}

	public TextStyle DefaultStyle { get; set; }

	public virtual Line this[int i]
	{
		get
		{
			return lines[i];
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public virtual bool IsNeedBuildRemovedLineIds => this.LineRemoved != null;

	public virtual int Count => lines.Count;

	public virtual bool IsReadOnly => false;

	public event EventHandler<LineInsertedEventArgs> LineInserted;

	public event EventHandler<LineRemovedEventArgs> LineRemoved;

	public event EventHandler<TextChangedEventArgs> TextChanged;

	public event EventHandler<TextChangedEventArgs> RecalcNeeded;

	public event EventHandler<TextChangedEventArgs> RecalcWordWrap;

	public event EventHandler<TextChangingEventArgs> TextChanging;

	public event EventHandler CurrentTBChanged;

	public virtual void ClearIsChanged()
	{
		foreach (Line line in lines)
		{
			line.IsChanged = false;
		}
	}

	public virtual Line CreateLine()
	{
		return new Line(GenerateUniqueLineId());
	}

	private void OnCurrentTBChanged()
	{
		if (this.CurrentTBChanged != null)
		{
			this.CurrentTBChanged(this, EventArgs.Empty);
		}
	}

	public TextSource(FastColoredTextBox currentTB)
	{
		CurrentTB = currentTB;
		linesAccessor = new LinesAccessor(this);
		Manager = new CommandManager(this);
		if (Enum.GetUnderlyingType(typeof(StyleIndex)) == typeof(uint))
		{
			Styles = new Style[32];
		}
		else
		{
			Styles = new Style[16];
		}
		InitDefaultStyle();
	}

	public virtual void InitDefaultStyle()
	{
		DefaultStyle = new TextStyle(null, null, FontStyle.Regular);
	}

	public virtual bool IsLineLoaded(int iLine)
	{
		return lines[iLine] != null;
	}

	public virtual IList<string> GetLines()
	{
		return linesAccessor;
	}

	public IEnumerator<Line> GetEnumerator()
	{
		return lines.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return lines as IEnumerator;
	}

	public virtual int BinarySearch(Line item, IComparer<Line> comparer)
	{
		return lines.BinarySearch(item, comparer);
	}

	public virtual int GenerateUniqueLineId()
	{
		return lastLineUniqueId++;
	}

	public virtual void InsertLine(int index, Line line)
	{
		lines.Insert(index, line);
		OnLineInserted(index);
	}

	public virtual void OnLineInserted(int index)
	{
		OnLineInserted(index, 1);
	}

	public virtual void OnLineInserted(int index, int count)
	{
		if (this.LineInserted != null)
		{
			this.LineInserted(this, new LineInsertedEventArgs(index, count));
		}
	}

	public virtual void RemoveLine(int index)
	{
		RemoveLine(index, 1);
	}

	public virtual void RemoveLine(int index, int count)
	{
		List<int> list = new List<int>();
		if (count > 0 && IsNeedBuildRemovedLineIds)
		{
			for (int i = 0; i < count; i++)
			{
				list.Add(this[index + i].UniqueId);
			}
		}
		lines.RemoveRange(index, count);
		OnLineRemoved(index, count, list);
	}

	public virtual void OnLineRemoved(int index, int count, List<int> removedLineIds)
	{
		if (count > 0 && this.LineRemoved != null)
		{
			this.LineRemoved(this, new LineRemovedEventArgs(index, count, removedLineIds));
		}
	}

	public virtual void OnTextChanged(int fromLine, int toLine)
	{
		if (this.TextChanged != null)
		{
			this.TextChanged(this, new TextChangedEventArgs(Math.Min(fromLine, toLine), Math.Max(fromLine, toLine)));
		}
	}

	public virtual int IndexOf(Line item)
	{
		return lines.IndexOf(item);
	}

	public virtual void Insert(int index, Line item)
	{
		InsertLine(index, item);
	}

	public virtual void RemoveAt(int index)
	{
		RemoveLine(index);
	}

	public virtual void Add(Line item)
	{
		InsertLine(Count, item);
	}

	public virtual void Clear()
	{
		RemoveLine(0, Count);
	}

	public virtual bool Contains(Line item)
	{
		return lines.Contains(item);
	}

	public virtual void CopyTo(Line[] array, int arrayIndex)
	{
		lines.CopyTo(array, arrayIndex);
	}

	public virtual bool Remove(Line item)
	{
		int num = IndexOf(item);
		if (num >= 0)
		{
			RemoveLine(num);
			return true;
		}
		return false;
	}

	public virtual void NeedRecalc(TextChangedEventArgs args)
	{
		if (this.RecalcNeeded != null)
		{
			this.RecalcNeeded(this, args);
		}
	}

	public virtual void OnRecalcWordWrap(TextChangedEventArgs args)
	{
		if (this.RecalcWordWrap != null)
		{
			this.RecalcWordWrap(this, args);
		}
	}

	public virtual void OnTextChanging()
	{
		string text = null;
		OnTextChanging(ref text);
	}

	public virtual void OnTextChanging(ref string text)
	{
		if (this.TextChanging != null)
		{
			TextChangingEventArgs e = new TextChangingEventArgs
			{
				InsertingText = text
			};
			this.TextChanging(this, e);
			text = e.InsertingText;
			if (e.Cancel)
			{
				text = string.Empty;
			}
		}
	}

	public virtual int GetLineLength(int i)
	{
		return lines[i].Count;
	}

	public virtual bool LineHasFoldingStartMarker(int iLine)
	{
		return !string.IsNullOrEmpty(lines[iLine].FoldingStartMarker);
	}

	public virtual bool LineHasFoldingEndMarker(int iLine)
	{
		return !string.IsNullOrEmpty(lines[iLine].FoldingEndMarker);
	}

	public virtual void Dispose()
	{
	}

	public virtual void SaveToFile(string fileName, Encoding enc)
	{
		using StreamWriter streamWriter = new StreamWriter(fileName, append: false, enc);
		for (int i = 0; i < Count - 1; i++)
		{
			streamWriter.WriteLine(lines[i].Text);
		}
		streamWriter.Write(lines[Count - 1].Text);
	}
}
