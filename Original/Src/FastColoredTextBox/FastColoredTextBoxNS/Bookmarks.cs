using System.Collections.Generic;

namespace FastColoredTextBoxNS;

public class Bookmarks : BaseBookmarks
{
	protected FastColoredTextBox tb;

	protected List<Bookmark> items = new List<Bookmark>();

	protected int counter;

	public override int Count => items.Count;

	public override bool IsReadOnly => false;

	public Bookmarks(FastColoredTextBox tb)
	{
		this.tb = tb;
		tb.LineInserted += tb_LineInserted;
		tb.LineRemoved += tb_LineRemoved;
	}

	protected virtual void tb_LineRemoved(object sender, LineRemovedEventArgs e)
	{
		for (int i = 0; i < Count; i++)
		{
			if (items[i].LineIndex < e.Index)
			{
				continue;
			}
			if (items[i].LineIndex >= e.Index + e.Count)
			{
				items[i].LineIndex = items[i].LineIndex - e.Count;
				continue;
			}
			bool flag = e.Index <= 0;
			foreach (Bookmark item in items)
			{
				if (item.LineIndex == e.Index - 1)
				{
					flag = true;
				}
			}
			if (flag)
			{
				items.RemoveAt(i);
				i--;
			}
			else
			{
				items[i].LineIndex = e.Index - 1;
			}
		}
	}

	protected virtual void tb_LineInserted(object sender, LineInsertedEventArgs e)
	{
		for (int i = 0; i < Count; i++)
		{
			if (items[i].LineIndex >= e.Index)
			{
				items[i].LineIndex = items[i].LineIndex + e.Count;
			}
			else if (items[i].LineIndex == e.Index - 1 && e.Count == 1 && tb[e.Index - 1].StartSpacesCount == tb[e.Index - 1].Count)
			{
				items[i].LineIndex = items[i].LineIndex + e.Count;
			}
		}
	}

	public override void Dispose()
	{
		tb.LineInserted -= tb_LineInserted;
		tb.LineRemoved -= tb_LineRemoved;
	}

	public override IEnumerator<Bookmark> GetEnumerator()
	{
		foreach (Bookmark item in items)
		{
			yield return item;
		}
	}

	public override void Add(int lineIndex, string bookmarkName)
	{
		Add(new Bookmark(tb, bookmarkName ?? ("Bookmark " + counter), lineIndex));
	}

	public override void Add(int lineIndex)
	{
		Add(new Bookmark(tb, "Bookmark " + counter, lineIndex));
	}

	public override void Clear()
	{
		items.Clear();
		counter = 0;
	}

	public override void Add(Bookmark bookmark)
	{
		foreach (Bookmark item in items)
		{
			if (item.LineIndex == bookmark.LineIndex)
			{
				return;
			}
		}
		items.Add(bookmark);
		counter++;
		tb.Invalidate();
	}

	public override bool Contains(Bookmark item)
	{
		return items.Contains(item);
	}

	public override bool Contains(int lineIndex)
	{
		foreach (Bookmark item in items)
		{
			if (item.LineIndex == lineIndex)
			{
				return true;
			}
		}
		return false;
	}

	public override void CopyTo(Bookmark[] array, int arrayIndex)
	{
		items.CopyTo(array, arrayIndex);
	}

	public override bool Remove(Bookmark item)
	{
		tb.Invalidate();
		return items.Remove(item);
	}

	public override bool Remove(int lineIndex)
	{
		bool result = false;
		for (int i = 0; i < Count; i++)
		{
			if (items[i].LineIndex == lineIndex)
			{
				items.RemoveAt(i);
				i--;
				result = true;
			}
		}
		tb.Invalidate();
		return result;
	}

	public override Bookmark GetBookmark(int i)
	{
		return items[i];
	}
}
