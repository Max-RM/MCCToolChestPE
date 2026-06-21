using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FastColoredTextBoxNS;

public class FileTextSource : TextSource, IDisposable
{
	private List<int> sourceFileLinePositions = new List<int>();

	private FileStream fs;

	private Encoding fileEncoding;

	private Timer timer = new Timer();

	public string SaveEOL { get; set; }

	public override Line this[int i]
	{
		get
		{
			if (lines[i] != null)
			{
				return lines[i];
			}
			LoadLineFromSourceFile(i);
			return lines[i];
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public event EventHandler<LineNeededEventArgs> LineNeeded;

	public event EventHandler<LinePushedEventArgs> LinePushed;

	public FileTextSource(FastColoredTextBox currentTB)
		: base(currentTB)
	{
		timer.Interval = 10000;
		timer.Tick += timer_Tick;
		timer.Enabled = true;
		SaveEOL = Environment.NewLine;
	}

	private void timer_Tick(object sender, EventArgs e)
	{
		timer.Enabled = false;
		try
		{
			UnloadUnusedLines();
		}
		finally
		{
			timer.Enabled = true;
		}
	}

	private void UnloadUnusedLines()
	{
		int iLine = base.CurrentTB.VisibleRange.Start.iLine;
		int iLine2 = base.CurrentTB.VisibleRange.End.iLine;
		int num = 0;
		for (int i = 0; i < Count; i++)
		{
			if (lines[i] != null && !lines[i].IsChanged && Math.Abs(i - iLine2) > 2000)
			{
				lines[i] = null;
				num++;
			}
		}
	}

	public void OpenFile(string fileName, Encoding enc)
	{
		Clear();
		if (fs != null)
		{
			fs.Dispose();
		}
		SaveEOL = Environment.NewLine;
		fs = new FileStream(fileName, FileMode.Open);
		long length = fs.Length;
		enc = DefineEncoding(enc, fs);
		int num = DefineShift(enc);
		sourceFileLinePositions.Add((int)fs.Position);
		lines.Add(null);
		sourceFileLinePositions.Capacity = (int)(length / 7 + 1000);
		int num2 = 0;
		int item = 0;
		BinaryReader binaryReader = new BinaryReader(fs, enc);
		while (fs.Position < length)
		{
			item = (int)fs.Position;
			char c = binaryReader.ReadChar();
			if (c == '\n')
			{
				sourceFileLinePositions.Add((int)fs.Position);
				lines.Add(null);
			}
			else if (num2 == 13)
			{
				sourceFileLinePositions.Add(item);
				lines.Add(null);
				SaveEOL = "\r";
			}
			num2 = c;
		}
		if (num2 == 13)
		{
			sourceFileLinePositions.Add(item);
			lines.Add(null);
		}
		if (length > 2000000)
		{
			GC.Collect();
		}
		Line[] array = new Line[100];
		int count = lines.Count;
		lines.AddRange(array);
		lines.TrimExcess();
		lines.RemoveRange(count, array.Length);
		int[] collection = new int[100];
		count = lines.Count;
		sourceFileLinePositions.AddRange(collection);
		sourceFileLinePositions.TrimExcess();
		sourceFileLinePositions.RemoveRange(count, array.Length);
		fileEncoding = enc;
		OnLineInserted(0, Count);
		int num3 = Math.Min(lines.Count, base.CurrentTB.ClientRectangle.Height / base.CurrentTB.CharHeight);
		for (int i = 0; i < num3; i++)
		{
			LoadLineFromSourceFile(i);
		}
		NeedRecalc(new TextChangedEventArgs(0, num3 - 1));
		if (base.CurrentTB.WordWrap)
		{
			OnRecalcWordWrap(new TextChangedEventArgs(0, num3 - 1));
		}
	}

	private int DefineShift(Encoding enc)
	{
		if (enc.IsSingleByte)
		{
			return 0;
		}
		if (enc.HeaderName == "unicodeFFFE")
		{
			return 0;
		}
		if (enc.HeaderName == "utf-16")
		{
			return 1;
		}
		if (enc.HeaderName == "utf-32BE")
		{
			return 0;
		}
		if (enc.HeaderName == "utf-32")
		{
			return 3;
		}
		return 0;
	}

	private static Encoding DefineEncoding(Encoding enc, FileStream fs)
	{
		int num = 0;
		byte[] array = new byte[4];
		int num2 = fs.Read(array, 0, 4);
		if (array[0] == byte.MaxValue && array[1] == 254 && array[2] == 0 && array[3] == 0 && num2 >= 4)
		{
			enc = Encoding.UTF32;
			num = 4;
		}
		else if (array[0] == 0 && array[1] == 0 && array[2] == 254 && array[3] == byte.MaxValue)
		{
			enc = new UTF32Encoding(bigEndian: true, byteOrderMark: true);
			num = 4;
		}
		else if (array[0] == 239 && array[1] == 187 && array[2] == 191)
		{
			enc = Encoding.UTF8;
			num = 3;
		}
		else if (array[0] == 254 && array[1] == byte.MaxValue)
		{
			enc = Encoding.BigEndianUnicode;
			num = 2;
		}
		else if (array[0] == byte.MaxValue && array[1] == 254)
		{
			enc = Encoding.Unicode;
			num = 2;
		}
		fs.Seek(num, SeekOrigin.Begin);
		return enc;
	}

	public void CloseFile()
	{
		if (fs != null)
		{
			try
			{
				fs.Dispose();
			}
			catch
			{
			}
		}
		fs = null;
	}

	public override void SaveToFile(string fileName, Encoding enc)
	{
		List<int> list = new List<int>(Count);
		string directoryName = Path.GetDirectoryName(fileName);
		string text = Path.Combine(directoryName, Path.GetFileNameWithoutExtension(fileName) + ".tmp");
		StreamReader streamReader = new StreamReader(fs, fileEncoding);
		using (FileStream fileStream = new FileStream(text, FileMode.Create))
		{
			using StreamWriter streamWriter = new StreamWriter(fileStream, enc);
			streamWriter.Flush();
			for (int i = 0; i < Count; i++)
			{
				list.Add((int)fileStream.Length);
				string text2 = ReadLine(streamReader, i);
				bool flag = lines[i] != null && lines[i].IsChanged;
				string text3 = ((!flag) ? text2 : lines[i].Text);
				if (this.LinePushed != null)
				{
					LinePushedEventArgs e = new LinePushedEventArgs(text2, i, flag ? text3 : null);
					this.LinePushed(this, e);
					if (e.SavedText != null)
					{
						text3 = e.SavedText;
					}
				}
				streamWriter.Write(text3);
				if (i < Count - 1)
				{
					streamWriter.Write(SaveEOL);
				}
				streamWriter.Flush();
			}
		}
		for (int j = 0; j < Count; j++)
		{
			lines[j] = null;
		}
		streamReader.Dispose();
		fs.Dispose();
		if (File.Exists(fileName))
		{
			File.Delete(fileName);
		}
		File.Move(text, fileName);
		sourceFileLinePositions = list;
		fs = new FileStream(fileName, FileMode.Open);
		fileEncoding = enc;
	}

	private string ReadLine(StreamReader sr, int i)
	{
		int num = sourceFileLinePositions[i];
		if (num < 0)
		{
			return "";
		}
		fs.Seek(num, SeekOrigin.Begin);
		sr.DiscardBufferedData();
		return sr.ReadLine();
	}

	public override void ClearIsChanged()
	{
		foreach (Line line in lines)
		{
			if (line != null)
			{
				line.IsChanged = false;
			}
		}
	}

	private void LoadLineFromSourceFile(int i)
	{
		Line line = CreateLine();
		fs.Seek(sourceFileLinePositions[i], SeekOrigin.Begin);
		StreamReader streamReader = new StreamReader(fs, fileEncoding);
		string text = streamReader.ReadLine();
		if (text == null)
		{
			text = "";
		}
		if (this.LineNeeded != null)
		{
			LineNeededEventArgs e = new LineNeededEventArgs(text, i);
			this.LineNeeded(this, e);
			text = e.DisplayedLineText;
			if (text == null)
			{
				return;
			}
		}
		string text2 = text;
		foreach (char c in text2)
		{
			line.Add(new Char(c));
		}
		lines[i] = line;
		if (base.CurrentTB.WordWrap)
		{
			OnRecalcWordWrap(new TextChangedEventArgs(i, i));
		}
	}

	public override void InsertLine(int index, Line line)
	{
		sourceFileLinePositions.Insert(index, -1);
		base.InsertLine(index, line);
	}

	public override void RemoveLine(int index, int count)
	{
		sourceFileLinePositions.RemoveRange(index, count);
		base.RemoveLine(index, count);
	}

	public override void Clear()
	{
		base.Clear();
	}

	public override int GetLineLength(int i)
	{
		if (lines[i] == null)
		{
			return 0;
		}
		return lines[i].Count;
	}

	public override bool LineHasFoldingStartMarker(int iLine)
	{
		if (lines[iLine] == null)
		{
			return false;
		}
		return !string.IsNullOrEmpty(lines[iLine].FoldingStartMarker);
	}

	public override bool LineHasFoldingEndMarker(int iLine)
	{
		if (lines[iLine] == null)
		{
			return false;
		}
		return !string.IsNullOrEmpty(lines[iLine].FoldingEndMarker);
	}

	public override void Dispose()
	{
		if (fs != null)
		{
			fs.Dispose();
		}
		timer.Dispose();
	}

	internal void UnloadLine(int iLine)
	{
		if (lines[iLine] != null && !lines[iLine].IsChanged)
		{
			lines[iLine] = null;
		}
	}
}
