using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace FastColoredTextBoxNS;

public class MacrosManager
{
	private readonly List<object> macro = new List<object>();

	private bool isRecording;

	public bool AllowMacroRecordingByUser { get; set; }

	public bool IsRecording
	{
		get
		{
			return isRecording;
		}
		set
		{
			isRecording = value;
			UnderlayingControl.Invalidate();
		}
	}

	public FastColoredTextBox UnderlayingControl { get; private set; }

	public bool MacroIsEmpty => macro.Count == 0;

	public string Macros
	{
		get
		{
			CultureInfo currentUICulture = Thread.CurrentThread.CurrentUICulture;
			Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
			KeysConverter keysConverter = new KeysConverter();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("<macros>");
			foreach (object item in macro)
			{
				if (item is Keys)
				{
					stringBuilder.AppendFormat("<item key='{0}' />\r\n", keysConverter.ConvertToString((Keys)item));
				}
				else if (item is KeyValuePair<char, Keys> keyValuePair)
				{
					stringBuilder.AppendFormat("<item char='{0}' key='{1}' />\r\n", (int)keyValuePair.Key, keysConverter.ConvertToString(keyValuePair.Value));
				}
			}
			stringBuilder.AppendLine("</macros>");
			Thread.CurrentThread.CurrentUICulture = currentUICulture;
			return stringBuilder.ToString();
		}
		set
		{
			isRecording = false;
			ClearMacros();
			if (string.IsNullOrEmpty(value))
			{
				return;
			}
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(value);
			XmlNodeList xmlNodeList = xmlDocument.SelectNodes("./macros/item");
			CultureInfo currentUICulture = Thread.CurrentThread.CurrentUICulture;
			Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
			KeysConverter keysConverter = new KeysConverter();
			if (xmlNodeList != null)
			{
				foreach (XmlElement item in xmlNodeList)
				{
					XmlAttribute attributeNode = item.GetAttributeNode("char");
					XmlAttribute attributeNode2 = item.GetAttributeNode("key");
					if (attributeNode != null)
					{
						if (attributeNode2 != null)
						{
							AddCharToMacros((char)int.Parse(attributeNode.Value), (Keys)keysConverter.ConvertFromString(attributeNode2.Value));
						}
						else
						{
							AddCharToMacros((char)int.Parse(attributeNode.Value), Keys.None);
						}
					}
					else if (attributeNode2 != null)
					{
						AddKeyToMacros((Keys)keysConverter.ConvertFromString(attributeNode2.Value));
					}
				}
			}
			Thread.CurrentThread.CurrentUICulture = currentUICulture;
		}
	}

	internal MacrosManager(FastColoredTextBox ctrl)
	{
		UnderlayingControl = ctrl;
		AllowMacroRecordingByUser = true;
	}

	public void ExecuteMacros()
	{
		IsRecording = false;
		UnderlayingControl.BeginUpdate();
		UnderlayingControl.Selection.BeginUpdate();
		UnderlayingControl.BeginAutoUndo();
		foreach (object item in macro)
		{
			if (item is Keys)
			{
				UnderlayingControl.ProcessKey((Keys)item);
			}
			if (item is KeyValuePair<char, Keys> keyValuePair)
			{
				UnderlayingControl.ProcessKey(keyValuePair.Key, keyValuePair.Value);
			}
		}
		UnderlayingControl.EndAutoUndo();
		UnderlayingControl.Selection.EndUpdate();
		UnderlayingControl.EndUpdate();
	}

	public void AddCharToMacros(char c, Keys modifiers)
	{
		macro.Add(new KeyValuePair<char, Keys>(c, modifiers));
	}

	public void AddKeyToMacros(Keys keyData)
	{
		macro.Add(keyData);
	}

	public void ClearMacros()
	{
		macro.Clear();
	}

	internal void ProcessKey(Keys keyData)
	{
		if (IsRecording)
		{
			AddKeyToMacros(keyData);
		}
	}

	internal void ProcessKey(char c, Keys modifiers)
	{
		if (IsRecording)
		{
			AddCharToMacros(c, modifiers);
		}
	}
}
