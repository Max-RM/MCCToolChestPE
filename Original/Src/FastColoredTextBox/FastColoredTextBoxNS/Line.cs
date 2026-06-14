using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace FastColoredTextBoxNS;

public class Line : IList<Char>, ICollection<Char>, IEnumerable<Char>, IEnumerable
{
	protected List<Char> chars;

	public string FoldingStartMarker { get; set; }

	public string FoldingEndMarker { get; set; }

	public bool IsChanged { get; set; }

	public DateTime LastVisit { get; set; }

	public Brush BackgroundBrush { get; set; }

	public int UniqueId { get; private set; }

	public int AutoIndentSpacesNeededCount { get; set; }

	public virtual string Text
	{
		get
		{
			StringBuilder stringBuilder = new StringBuilder(Count);
			using (IEnumerator<Char> enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					stringBuilder.Append(enumerator.Current.c);
				}
			}
			return stringBuilder.ToString();
		}
	}

	public int StartSpacesCount
	{
		get
		{
			int num = 0;
			for (int i = 0; i < Count && this[i].c == ' '; i++)
			{
				num++;
			}
			return num;
		}
	}

	public Char this[int index]
	{
		get
		{
			return chars[index];
		}
		set
		{
			chars[index] = value;
		}
	}

	public int Count => chars.Count;

	public bool IsReadOnly => false;

	internal Line(int uid)
	{
		UniqueId = uid;
		chars = new List<Char>();
	}

	public void ClearStyle(StyleIndex styleIndex)
	{
		FoldingStartMarker = null;
		FoldingEndMarker = null;
		for (int i = 0; i < Count; i++)
		{
			Char value = this[i];
			value.style &= (StyleIndex)(ushort)(~(int)styleIndex);
			this[i] = value;
		}
	}

	public void ClearFoldingMarkers()
	{
		FoldingStartMarker = null;
		FoldingEndMarker = null;
	}

	public int IndexOf(Char item)
	{
		return chars.IndexOf(item);
	}

	public void Insert(int index, Char item)
	{
		chars.Insert(index, item);
	}

	public void RemoveAt(int index)
	{
		chars.RemoveAt(index);
	}

	public void Add(Char item)
	{
		chars.Add(item);
	}

	public void Clear()
	{
		chars.Clear();
	}

	public bool Contains(Char item)
	{
		return chars.Contains(item);
	}

	public void CopyTo(Char[] array, int arrayIndex)
	{
		chars.CopyTo(array, arrayIndex);
	}

	public bool Remove(Char item)
	{
		return chars.Remove(item);
	}

	public IEnumerator<Char> GetEnumerator()
	{
		return chars.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return chars.GetEnumerator();
	}

	public virtual void RemoveRange(int index, int count)
	{
		if (index < Count)
		{
			chars.RemoveRange(index, Math.Min(Count - index, count));
		}
	}

	public virtual void TrimExcess()
	{
		chars.TrimExcess();
	}

	public virtual void AddRange(IEnumerable<Char> collection)
	{
		chars.AddRange(collection);
	}
}
