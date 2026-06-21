using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;

namespace FastColoredTextBoxNS;

public class SyntaxHighlighter : IDisposable
{
	private class XmlFoldingTag
	{
		public string Name;

		public int id;

		public int startLine;

		public string Marker => Name + id;
	}

	protected static readonly Platform platformType = PlatformType.GetOperationSystemPlatform();

	public readonly Style BlueBoldStyle = new TextStyle(Brushes.Blue, null, FontStyle.Bold);

	public readonly Style BlueStyle = new TextStyle(Brushes.Blue, null, FontStyle.Regular);

	public readonly Style BoldStyle = new TextStyle(null, null, FontStyle.Bold | FontStyle.Underline);

	public readonly Style BrownStyle = new TextStyle(Brushes.Brown, null, FontStyle.Italic);

	public readonly Style GrayStyle = new TextStyle(Brushes.Gray, null, FontStyle.Regular);

	public readonly Style GreenStyle = new TextStyle(Brushes.Green, null, FontStyle.Italic);

	public readonly Style MagentaStyle = new TextStyle(Brushes.Magenta, null, FontStyle.Regular);

	public readonly Style MaroonStyle = new TextStyle(Brushes.Maroon, null, FontStyle.Regular);

	public readonly Style RedStyle = new TextStyle(Brushes.Red, null, FontStyle.Regular);

	public readonly Style BlackStyle = new TextStyle(Brushes.Black, null, FontStyle.Regular);

	protected readonly Dictionary<string, SyntaxDescriptor> descByXMLfileNames = new Dictionary<string, SyntaxDescriptor>();

	protected readonly List<Style> resilientStyles = new List<Style>(5);

	protected Regex CSharpAttributeRegex;

	protected Regex CSharpClassNameRegex;

	protected Regex CSharpCommentRegex1;

	protected Regex CSharpCommentRegex2;

	protected Regex CSharpCommentRegex3;

	protected Regex CSharpKeywordRegex;

	protected Regex CSharpNumberRegex;

	protected Regex CSharpStringRegex;

	protected Regex HTMLAttrRegex;

	protected Regex HTMLAttrValRegex;

	protected Regex HTMLCommentRegex1;

	protected Regex HTMLCommentRegex2;

	protected Regex HTMLEndTagRegex;

	protected Regex HTMLEntityRegex;

	protected Regex HTMLTagContentRegex;

	protected Regex HTMLTagNameRegex;

	protected Regex HTMLTagRegex;

	protected Regex XMLAttrRegex;

	protected Regex XMLAttrValRegex;

	protected Regex XMLCommentRegex1;

	protected Regex XMLCommentRegex2;

	protected Regex XMLEndTagRegex;

	protected Regex XMLEntityRegex;

	protected Regex XMLTagContentRegex;

	protected Regex XMLTagNameRegex;

	protected Regex XMLTagRegex;

	protected Regex XMLCDataRegex;

	protected Regex XMLFoldingRegex;

	protected Regex JScriptCommentRegex1;

	protected Regex JScriptCommentRegex2;

	protected Regex JScriptCommentRegex3;

	protected Regex JScriptKeywordRegex;

	protected Regex JScriptNumberRegex;

	protected Regex JScriptStringRegex;

	protected Regex LuaCommentRegex1;

	protected Regex LuaCommentRegex2;

	protected Regex LuaCommentRegex3;

	protected Regex LuaKeywordRegex;

	protected Regex LuaNumberRegex;

	protected Regex LuaStringRegex;

	protected Regex LuaFunctionsRegex;

	protected Regex PHPCommentRegex1;

	protected Regex PHPCommentRegex2;

	protected Regex PHPCommentRegex3;

	protected Regex PHPKeywordRegex1;

	protected Regex PHPKeywordRegex2;

	protected Regex PHPKeywordRegex3;

	protected Regex PHPNumberRegex;

	protected Regex PHPStringRegex;

	protected Regex PHPVarRegex;

	protected Regex SQLCommentRegex1;

	protected Regex SQLCommentRegex2;

	protected Regex SQLCommentRegex3;

	protected Regex SQLCommentRegex4;

	protected Regex SQLFunctionsRegex;

	protected Regex SQLKeywordsRegex;

	protected Regex SQLNumberRegex;

	protected Regex SQLStatementsRegex;

	protected Regex SQLStringRegex;

	protected Regex SQLTypesRegex;

	protected Regex SQLVarRegex;

	protected Regex VBClassNameRegex;

	protected Regex VBCommentRegex;

	protected Regex VBKeywordRegex;

	protected Regex VBNumberRegex;

	protected Regex VBStringRegex;

	protected FastColoredTextBox currentTb;

	public static RegexOptions RegexCompiledOption
	{
		get
		{
			if (platformType == Platform.X86)
			{
				return RegexOptions.Compiled;
			}
			return RegexOptions.None;
		}
	}

	public Style StringStyle { get; set; }

	public Style CommentStyle { get; set; }

	public Style NumberStyle { get; set; }

	public Style AttributeStyle { get; set; }

	public Style ClassNameStyle { get; set; }

	public Style KeywordStyle { get; set; }

	public Style CommentTagStyle { get; set; }

	public Style AttributeValueStyle { get; set; }

	public Style TagBracketStyle { get; set; }

	public Style TagNameStyle { get; set; }

	public Style HtmlEntityStyle { get; set; }

	public Style XmlAttributeStyle { get; set; }

	public Style XmlAttributeValueStyle { get; set; }

	public Style XmlTagBracketStyle { get; set; }

	public Style XmlTagNameStyle { get; set; }

	public Style XmlEntityStyle { get; set; }

	public Style XmlCDataStyle { get; set; }

	public Style VariableStyle { get; set; }

	public Style KeywordStyle2 { get; set; }

	public Style KeywordStyle3 { get; set; }

	public Style StatementsStyle { get; set; }

	public Style FunctionsStyle { get; set; }

	public Style TypesStyle { get; set; }

	public SyntaxHighlighter(FastColoredTextBox currentTb)
	{
		this.currentTb = currentTb;
	}

	public void Dispose()
	{
		foreach (SyntaxDescriptor value in descByXMLfileNames.Values)
		{
			value.Dispose();
		}
	}

	public virtual void HighlightSyntax(Language language, Range range)
	{
		switch (language)
		{
		case Language.CSharp:
			CSharpSyntaxHighlight(range);
			break;
		case Language.VB:
			VBSyntaxHighlight(range);
			break;
		case Language.HTML:
			HTMLSyntaxHighlight(range);
			break;
		case Language.XML:
			XMLSyntaxHighlight(range);
			break;
		case Language.SQL:
			SQLSyntaxHighlight(range);
			break;
		case Language.PHP:
			PHPSyntaxHighlight(range);
			break;
		case Language.JS:
			JScriptSyntaxHighlight(range);
			break;
		case Language.Lua:
			LuaSyntaxHighlight(range);
			break;
		}
	}

	public virtual void HighlightSyntax(string XMLdescriptionFile, Range range)
	{
		SyntaxDescriptor value = null;
		if (!descByXMLfileNames.TryGetValue(XMLdescriptionFile, out value))
		{
			XmlDocument xmlDocument = new XmlDocument();
			string path = XMLdescriptionFile;
			if (!File.Exists(path))
			{
				path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Path.GetFileName(path));
			}
			xmlDocument.LoadXml(File.ReadAllText(path));
			value = ParseXmlDescription(xmlDocument);
			descByXMLfileNames[XMLdescriptionFile] = value;
		}
		HighlightSyntax(value, range);
	}

	public virtual void AutoIndentNeeded(object sender, AutoIndentEventArgs args)
	{
		FastColoredTextBox fastColoredTextBox = sender as FastColoredTextBox;
		switch (fastColoredTextBox.Language)
		{
		case Language.CSharp:
			CSharpAutoIndentNeeded(sender, args);
			break;
		case Language.VB:
			VBAutoIndentNeeded(sender, args);
			break;
		case Language.HTML:
			HTMLAutoIndentNeeded(sender, args);
			break;
		case Language.XML:
			XMLAutoIndentNeeded(sender, args);
			break;
		case Language.SQL:
			SQLAutoIndentNeeded(sender, args);
			break;
		case Language.PHP:
			PHPAutoIndentNeeded(sender, args);
			break;
		case Language.JS:
			CSharpAutoIndentNeeded(sender, args);
			break;
		case Language.Lua:
			LuaAutoIndentNeeded(sender, args);
			break;
		}
	}

	protected void PHPAutoIndentNeeded(object sender, AutoIndentEventArgs args)
	{
		if (!Regex.IsMatch(args.LineText, "^[^\"']*\\{.*\\}[^\"']*$"))
		{
			if (Regex.IsMatch(args.LineText, "^[^\"']*\\{"))
			{
				args.ShiftNextLines = args.TabLength;
			}
			else if (Regex.IsMatch(args.LineText, "}[^\"']*$"))
			{
				args.Shift = -args.TabLength;
				args.ShiftNextLines = -args.TabLength;
			}
			else if (Regex.IsMatch(args.PrevLineText, "^\\s*(if|for|foreach|while|[\\}\\s]*else)\\b[^{]*$") && !Regex.IsMatch(args.PrevLineText, "(;\\s*$)|(;\\s*//)"))
			{
				args.Shift = args.TabLength;
			}
		}
	}

	protected void SQLAutoIndentNeeded(object sender, AutoIndentEventArgs args)
	{
		FastColoredTextBox fastColoredTextBox = sender as FastColoredTextBox;
		fastColoredTextBox.CalcAutoIndentShiftByCodeFolding(sender, args);
	}

	protected void HTMLAutoIndentNeeded(object sender, AutoIndentEventArgs args)
	{
		FastColoredTextBox fastColoredTextBox = sender as FastColoredTextBox;
		fastColoredTextBox.CalcAutoIndentShiftByCodeFolding(sender, args);
	}

	protected void XMLAutoIndentNeeded(object sender, AutoIndentEventArgs args)
	{
		FastColoredTextBox fastColoredTextBox = sender as FastColoredTextBox;
		fastColoredTextBox.CalcAutoIndentShiftByCodeFolding(sender, args);
	}

	protected void VBAutoIndentNeeded(object sender, AutoIndentEventArgs args)
	{
		if (Regex.IsMatch(args.LineText, "^\\s*(End|EndIf|Next|Loop)\\b", RegexOptions.IgnoreCase))
		{
			args.Shift = -args.TabLength;
			args.ShiftNextLines = -args.TabLength;
		}
		else if (Regex.IsMatch(args.LineText, "\\b(Class|Property|Enum|Structure|Sub|Function|Namespace|Interface|Get)\\b|(Set\\s*\\()", RegexOptions.IgnoreCase))
		{
			args.ShiftNextLines = args.TabLength;
		}
		else if (!Regex.IsMatch(args.LineText, "\\b(Then)\\s*\\S+", RegexOptions.IgnoreCase))
		{
			if (Regex.IsMatch(args.LineText, "^\\s*(If|While|For|Do|Try|With|Using|Select)\\b", RegexOptions.IgnoreCase))
			{
				args.ShiftNextLines = args.TabLength;
			}
			else if (Regex.IsMatch(args.LineText, "^\\s*(Else|ElseIf|Case|Catch|Finally)\\b", RegexOptions.IgnoreCase))
			{
				args.Shift = -args.TabLength;
			}
			else if (args.PrevLineText.TrimEnd().EndsWith("_"))
			{
				args.Shift = args.TabLength;
			}
		}
	}

	protected void CSharpAutoIndentNeeded(object sender, AutoIndentEventArgs args)
	{
		if (!Regex.IsMatch(args.LineText, "^[^\"']*\\{.*\\}[^\"']*$"))
		{
			if (Regex.IsMatch(args.LineText, "^[^\"']*\\{"))
			{
				args.ShiftNextLines = args.TabLength;
			}
			else if (Regex.IsMatch(args.LineText, "}[^\"']*$"))
			{
				args.Shift = -args.TabLength;
				args.ShiftNextLines = -args.TabLength;
			}
			else if (Regex.IsMatch(args.LineText, "^\\s*\\w+\\s*:\\s*($|//)") && !Regex.IsMatch(args.LineText, "^\\s*default\\s*:"))
			{
				args.Shift = -args.TabLength;
			}
			else if (Regex.IsMatch(args.LineText, "^\\s*(case|default)\\b.*:\\s*($|//)"))
			{
				args.Shift = -args.TabLength / 2;
			}
			else if (Regex.IsMatch(args.PrevLineText, "^\\s*(if|for|foreach|while|[\\}\\s]*else)\\b[^{]*$") && !Regex.IsMatch(args.PrevLineText, "(;\\s*$)|(;\\s*//)"))
			{
				args.Shift = args.TabLength;
			}
		}
	}

	public virtual void AddXmlDescription(string descriptionFileName, XmlDocument doc)
	{
		SyntaxDescriptor value = ParseXmlDescription(doc);
		descByXMLfileNames[descriptionFileName] = value;
	}

	public virtual void AddResilientStyle(Style style)
	{
		if (!resilientStyles.Contains(style))
		{
			currentTb.CheckStylesBufferSize();
			resilientStyles.Add(style);
		}
	}

	public static SyntaxDescriptor ParseXmlDescription(XmlDocument doc)
	{
		SyntaxDescriptor syntaxDescriptor = new SyntaxDescriptor();
		XmlNode xmlNode = doc.SelectSingleNode("doc/brackets");
		if (xmlNode != null)
		{
			if (xmlNode.Attributes["left"] == null || xmlNode.Attributes["right"] == null || xmlNode.Attributes["left"].Value == "" || xmlNode.Attributes["right"].Value == "")
			{
				syntaxDescriptor.leftBracket = '\0';
				syntaxDescriptor.rightBracket = '\0';
			}
			else
			{
				syntaxDescriptor.leftBracket = xmlNode.Attributes["left"].Value[0];
				syntaxDescriptor.rightBracket = xmlNode.Attributes["right"].Value[0];
			}
			if (xmlNode.Attributes["left2"] == null || xmlNode.Attributes["right2"] == null || xmlNode.Attributes["left2"].Value == "" || xmlNode.Attributes["right2"].Value == "")
			{
				syntaxDescriptor.leftBracket2 = '\0';
				syntaxDescriptor.rightBracket2 = '\0';
			}
			else
			{
				syntaxDescriptor.leftBracket2 = xmlNode.Attributes["left2"].Value[0];
				syntaxDescriptor.rightBracket2 = xmlNode.Attributes["right2"].Value[0];
			}
			if (xmlNode.Attributes["strategy"] == null || xmlNode.Attributes["strategy"].Value == "")
			{
				syntaxDescriptor.bracketsHighlightStrategy = BracketsHighlightStrategy.Strategy2;
			}
			else
			{
				syntaxDescriptor.bracketsHighlightStrategy = (BracketsHighlightStrategy)Enum.Parse(typeof(BracketsHighlightStrategy), xmlNode.Attributes["strategy"].Value);
			}
		}
		Dictionary<string, Style> dictionary = new Dictionary<string, Style>();
		foreach (XmlNode item in doc.SelectNodes("doc/style"))
		{
			Style style = ParseStyle(item);
			dictionary[item.Attributes["name"].Value] = style;
			syntaxDescriptor.styles.Add(style);
		}
		foreach (XmlNode item2 in doc.SelectNodes("doc/rule"))
		{
			syntaxDescriptor.rules.Add(ParseRule(item2, dictionary));
		}
		foreach (XmlNode item3 in doc.SelectNodes("doc/folding"))
		{
			syntaxDescriptor.foldings.Add(ParseFolding(item3));
		}
		return syntaxDescriptor;
	}

	protected static FoldingDesc ParseFolding(XmlNode foldingNode)
	{
		FoldingDesc foldingDesc = new FoldingDesc();
		foldingDesc.startMarkerRegex = foldingNode.Attributes["start"].Value;
		foldingDesc.finishMarkerRegex = foldingNode.Attributes["finish"].Value;
		XmlAttribute xmlAttribute = foldingNode.Attributes["options"];
		if (xmlAttribute != null)
		{
			foldingDesc.options = (RegexOptions)Enum.Parse(typeof(RegexOptions), xmlAttribute.Value);
		}
		return foldingDesc;
	}

	protected static RuleDesc ParseRule(XmlNode ruleNode, Dictionary<string, Style> styles)
	{
		RuleDesc ruleDesc = new RuleDesc();
		ruleDesc.pattern = ruleNode.InnerText;
		XmlAttribute xmlAttribute = ruleNode.Attributes["style"];
		XmlAttribute xmlAttribute2 = ruleNode.Attributes["options"];
		if (xmlAttribute == null)
		{
			throw new Exception("Rule must contain style name.");
		}
		if (!styles.ContainsKey(xmlAttribute.Value))
		{
			throw new Exception("Style '" + xmlAttribute.Value + "' is not found.");
		}
		ruleDesc.style = styles[xmlAttribute.Value];
		if (xmlAttribute2 != null)
		{
			ruleDesc.options = (RegexOptions)Enum.Parse(typeof(RegexOptions), xmlAttribute2.Value);
		}
		return ruleDesc;
	}

	protected static Style ParseStyle(XmlNode styleNode)
	{
		XmlAttribute xmlAttribute = styleNode.Attributes["type"];
		XmlAttribute xmlAttribute2 = styleNode.Attributes["color"];
		XmlAttribute xmlAttribute3 = styleNode.Attributes["backColor"];
		XmlAttribute xmlAttribute4 = styleNode.Attributes["fontStyle"];
		XmlAttribute xmlAttribute5 = styleNode.Attributes["name"];
		SolidBrush foreBrush = null;
		if (xmlAttribute2 != null)
		{
			foreBrush = new SolidBrush(ParseColor(xmlAttribute2.Value));
		}
		SolidBrush backgroundBrush = null;
		if (xmlAttribute3 != null)
		{
			backgroundBrush = new SolidBrush(ParseColor(xmlAttribute3.Value));
		}
		FontStyle fontStyle = FontStyle.Regular;
		if (xmlAttribute4 != null)
		{
			fontStyle = (FontStyle)Enum.Parse(typeof(FontStyle), xmlAttribute4.Value);
		}
		return new TextStyle(foreBrush, backgroundBrush, fontStyle);
	}

	protected static Color ParseColor(string s)
	{
		if (s.StartsWith("#"))
		{
			if (s.Length <= 7)
			{
				return Color.FromArgb(255, Color.FromArgb(int.Parse(s.Substring(1), NumberStyles.AllowHexSpecifier)));
			}
			return Color.FromArgb(int.Parse(s.Substring(1), NumberStyles.AllowHexSpecifier));
		}
		return Color.FromName(s);
	}

	public void HighlightSyntax(SyntaxDescriptor desc, Range range)
	{
		range.tb.ClearStylesBuffer();
		for (int i = 0; i < desc.styles.Count; i++)
		{
			range.tb.Styles[i] = desc.styles[i];
		}
		int count = desc.styles.Count;
		for (int j = 0; j < resilientStyles.Count; j++)
		{
			range.tb.Styles[count + j] = resilientStyles[j];
		}
		char[] oldBrackets = RememberBrackets(range.tb);
		range.tb.LeftBracket = desc.leftBracket;
		range.tb.RightBracket = desc.rightBracket;
		range.tb.LeftBracket2 = desc.leftBracket2;
		range.tb.RightBracket2 = desc.rightBracket2;
		range.ClearStyle(desc.styles.ToArray());
		foreach (RuleDesc rule in desc.rules)
		{
			range.SetStyle(rule.style, rule.Regex);
		}
		range.ClearFoldingMarkers();
		foreach (FoldingDesc folding in desc.foldings)
		{
			range.SetFoldingMarkers(folding.startMarkerRegex, folding.finishMarkerRegex, folding.options);
		}
		RestoreBrackets(range.tb, oldBrackets);
	}

	protected void RestoreBrackets(FastColoredTextBox tb, char[] oldBrackets)
	{
		tb.LeftBracket = oldBrackets[0];
		tb.RightBracket = oldBrackets[1];
		tb.LeftBracket2 = oldBrackets[2];
		tb.RightBracket2 = oldBrackets[3];
	}

	protected char[] RememberBrackets(FastColoredTextBox tb)
	{
		return new char[4] { tb.LeftBracket, tb.RightBracket, tb.LeftBracket2, tb.RightBracket2 };
	}

	protected void InitCShaprRegex()
	{
		CSharpStringRegex = new Regex("\r\n                            # Character definitions:\r\n                            '\r\n                            (?> # disable backtracking\r\n                              (?:\r\n                                \\\\[^\\r\\n]|    # escaped meta char\r\n                                [^'\\r\\n]      # any character except '\r\n                              )*\r\n                            )\r\n                            '?\r\n                            |\r\n                            # Normal string & verbatim strings definitions:\r\n                            (?<verbatimIdentifier>@)?         # this group matches if it is an verbatim string\r\n                            \"\r\n                            (?> # disable backtracking\r\n                              (?:\r\n                                # match and consume an escaped character including escaped double quote (\") char\r\n                                (?(verbatimIdentifier)        # if it is a verbatim string ...\r\n                                  \"\"|                         #   then: only match an escaped double quote (\") char\r\n                                  \\\\.                         #   else: match an escaped sequence\r\n                                )\r\n                                | # OR\r\n            \r\n                                # match any char except double quote char (\")\r\n                                [^\"]\r\n                              )*\r\n                            )\r\n                            \"\r\n                        ", RegexOptions.ExplicitCapture | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace | RegexCompiledOption);
		CSharpCommentRegex1 = new Regex("//.*$", RegexOptions.Multiline | RegexCompiledOption);
		CSharpCommentRegex2 = new Regex("(/\\*.*?\\*/)|(/\\*.*)", RegexOptions.Singleline | RegexCompiledOption);
		CSharpCommentRegex3 = new Regex("(/\\*.*?\\*/)|(.*\\*/)", RegexOptions.Singleline | RegexOptions.RightToLeft | RegexCompiledOption);
		CSharpNumberRegex = new Regex("\\b\\d+[\\.]?\\d*([eE]\\-?\\d+)?[lLdDfF]?\\b|\\b0x[a-fA-F\\d]+\\b", RegexCompiledOption);
		CSharpAttributeRegex = new Regex("^\\s*(?<range>\\[.+?\\])\\s*$", RegexOptions.Multiline | RegexCompiledOption);
		CSharpClassNameRegex = new Regex("\\b(class|struct|enum|interface)\\s+(?<range>\\w+?)\\b", RegexCompiledOption);
		CSharpKeywordRegex = new Regex("\\b(abstract|as|base|bool|break|byte|case|catch|char|checked|class|const|continue|decimal|default|delegate|do|double|else|enum|event|explicit|extern|false|finally|fixed|float|for|foreach|goto|if|implicit|in|int|interface|internal|is|lock|long|namespace|new|null|object|operator|out|override|params|private|protected|public|readonly|ref|return|sbyte|sealed|short|sizeof|stackalloc|static|string|struct|switch|this|throw|true|try|typeof|uint|ulong|unchecked|unsafe|ushort|using|virtual|void|volatile|while|add|alias|ascending|descending|dynamic|from|get|global|group|into|join|let|orderby|partial|remove|select|set|value|var|where|yield)\\b|#region\\b|#endregion\\b", RegexCompiledOption);
	}

	public void InitStyleSchema(Language lang)
	{
		switch (lang)
		{
		case Language.CSharp:
			StringStyle = BrownStyle;
			CommentStyle = GreenStyle;
			NumberStyle = MagentaStyle;
			AttributeStyle = GreenStyle;
			ClassNameStyle = BoldStyle;
			KeywordStyle = BlueStyle;
			CommentTagStyle = GrayStyle;
			break;
		case Language.VB:
			StringStyle = BrownStyle;
			CommentStyle = GreenStyle;
			NumberStyle = MagentaStyle;
			ClassNameStyle = BoldStyle;
			KeywordStyle = BlueStyle;
			break;
		case Language.HTML:
			CommentStyle = GreenStyle;
			TagBracketStyle = BlueStyle;
			TagNameStyle = MaroonStyle;
			AttributeStyle = RedStyle;
			AttributeValueStyle = BlueStyle;
			HtmlEntityStyle = RedStyle;
			break;
		case Language.XML:
			CommentStyle = GreenStyle;
			XmlTagBracketStyle = BlueStyle;
			XmlTagNameStyle = MaroonStyle;
			XmlAttributeStyle = RedStyle;
			XmlAttributeValueStyle = BlueStyle;
			XmlEntityStyle = RedStyle;
			XmlCDataStyle = BlackStyle;
			break;
		case Language.JS:
			StringStyle = BrownStyle;
			CommentStyle = GreenStyle;
			NumberStyle = MagentaStyle;
			KeywordStyle = BlueStyle;
			break;
		case Language.Lua:
			StringStyle = BrownStyle;
			CommentStyle = GreenStyle;
			NumberStyle = MagentaStyle;
			KeywordStyle = BlueBoldStyle;
			FunctionsStyle = MaroonStyle;
			break;
		case Language.PHP:
			StringStyle = RedStyle;
			CommentStyle = GreenStyle;
			NumberStyle = RedStyle;
			VariableStyle = MaroonStyle;
			KeywordStyle = MagentaStyle;
			KeywordStyle2 = BlueStyle;
			KeywordStyle3 = GrayStyle;
			break;
		case Language.SQL:
			StringStyle = RedStyle;
			CommentStyle = GreenStyle;
			NumberStyle = MagentaStyle;
			KeywordStyle = BlueBoldStyle;
			StatementsStyle = BlueBoldStyle;
			FunctionsStyle = MaroonStyle;
			VariableStyle = MaroonStyle;
			TypesStyle = BrownStyle;
			break;
		}
	}

	public virtual void CSharpSyntaxHighlight(Range range)
	{
		range.tb.CommentPrefix = "//";
		range.tb.LeftBracket = '(';
		range.tb.RightBracket = ')';
		range.tb.LeftBracket2 = '{';
		range.tb.RightBracket2 = '}';
		range.tb.BracketsHighlightStrategy = BracketsHighlightStrategy.Strategy2;
		range.tb.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\r\n^\\s*(case|default)\\s*[^:]*(?<range>:)\\s*(?<range>[^;]+);\r\n";
		range.ClearStyle(StringStyle, CommentStyle, NumberStyle, AttributeStyle, ClassNameStyle, KeywordStyle);
		if (CSharpStringRegex == null)
		{
			InitCShaprRegex();
		}
		range.SetStyle(StringStyle, CSharpStringRegex);
		range.SetStyle(CommentStyle, CSharpCommentRegex1);
		range.SetStyle(CommentStyle, CSharpCommentRegex2);
		range.SetStyle(CommentStyle, CSharpCommentRegex3);
		range.SetStyle(NumberStyle, CSharpNumberRegex);
		range.SetStyle(AttributeStyle, CSharpAttributeRegex);
		range.SetStyle(ClassNameStyle, CSharpClassNameRegex);
		range.SetStyle(KeywordStyle, CSharpKeywordRegex);
		foreach (Range range2 in range.GetRanges("^\\s*///.*$", RegexOptions.Multiline))
		{
			range2.ClearStyle(StyleIndex.All);
			if (HTMLTagRegex == null)
			{
				InitHTMLRegex();
			}
			range2.SetStyle(CommentStyle);
			foreach (Range range3 in range2.GetRanges(HTMLTagContentRegex))
			{
				range3.ClearStyle(StyleIndex.All);
				range3.SetStyle(CommentTagStyle);
			}
			foreach (Range range4 in range2.GetRanges("^\\s*///", RegexOptions.Multiline))
			{
				range4.ClearStyle(StyleIndex.All);
				range4.SetStyle(CommentTagStyle);
			}
		}
		range.ClearFoldingMarkers();
		range.SetFoldingMarkers("{", "}");
		range.SetFoldingMarkers("#region\\b", "#endregion\\b");
		range.SetFoldingMarkers("/\\*", "\\*/");
	}

	protected void InitVBRegex()
	{
		VBStringRegex = new Regex("\"\"|\".*?[^\\\\]\"", RegexCompiledOption);
		VBCommentRegex = new Regex("'.*$", RegexOptions.Multiline | RegexCompiledOption);
		VBNumberRegex = new Regex("\\b\\d+[\\.]?\\d*([eE]\\-?\\d+)?\\b", RegexCompiledOption);
		VBClassNameRegex = new Regex("\\b(Class|Structure|Enum|Interface)[ ]+(?<range>\\w+?)\\b", RegexOptions.IgnoreCase | RegexCompiledOption);
		VBKeywordRegex = new Regex("\\b(AddHandler|AddressOf|Alias|And|AndAlso|As|Boolean|ByRef|Byte|ByVal|Call|Case|Catch|CBool|CByte|CChar|CDate|CDbl|CDec|Char|CInt|Class|CLng|CObj|Const|Continue|CSByte|CShort|CSng|CStr|CType|CUInt|CULng|CUShort|Date|Decimal|Declare|Default|Delegate|Dim|DirectCast|Do|Double|Each|Else|ElseIf|End|EndIf|Enum|Erase|Error|Event|Exit|False|Finally|For|Friend|Function|Get|GetType|GetXMLNamespace|Global|GoSub|GoTo|Handles|If|Implements|Imports|In|Inherits|Integer|Interface|Is|IsNot|Let|Lib|Like|Long|Loop|Me|Mod|Module|MustInherit|MustOverride|MyBase|MyClass|Namespace|Narrowing|New|Next|Not|Nothing|NotInheritable|NotOverridable|Object|Of|On|Operator|Option|Optional|Or|OrElse|Overloads|Overridable|Overrides|ParamArray|Partial|Private|Property|Protected|Public|RaiseEvent|ReadOnly|ReDim|REM|RemoveHandler|Resume|Return|SByte|Select|Set|Shadows|Shared|Short|Single|Static|Step|Stop|String|Structure|Sub|SyncLock|Then|Throw|To|True|Try|TryCast|TypeOf|UInteger|ULong|UShort|Using|Variant|Wend|When|While|Widening|With|WithEvents|WriteOnly|Xor|Region)\\b|(#Const|#Else|#ElseIf|#End|#If|#Region)\\b", RegexOptions.IgnoreCase | RegexCompiledOption);
	}

	public virtual void VBSyntaxHighlight(Range range)
	{
		range.tb.CommentPrefix = "'";
		range.tb.LeftBracket = '(';
		range.tb.RightBracket = ')';
		range.tb.LeftBracket2 = '\0';
		range.tb.RightBracket2 = '\0';
		range.tb.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.\\(\\)]+\\s*(?<range>=)\\s*(?<range>.+)\r\n";
		range.ClearStyle(StringStyle, CommentStyle, NumberStyle, ClassNameStyle, KeywordStyle);
		if (VBStringRegex == null)
		{
			InitVBRegex();
		}
		range.SetStyle(StringStyle, VBStringRegex);
		range.SetStyle(CommentStyle, VBCommentRegex);
		range.SetStyle(NumberStyle, VBNumberRegex);
		range.SetStyle(ClassNameStyle, VBClassNameRegex);
		range.SetStyle(KeywordStyle, VBKeywordRegex);
		range.ClearFoldingMarkers();
		range.SetFoldingMarkers("#Region\\b", "#End\\s+Region\\b", RegexOptions.IgnoreCase);
		range.SetFoldingMarkers("\\b(Class|Property|Enum|Structure|Interface)[ \\t]+\\S+", "\\bEnd (Class|Property|Enum|Structure|Interface)\\b", RegexOptions.IgnoreCase);
		range.SetFoldingMarkers("^\\s*(?<range>While)[ \\t]+\\S+", "^\\s*(?<range>End While)\\b", RegexOptions.IgnoreCase | RegexOptions.Multiline);
		range.SetFoldingMarkers("\\b(Sub|Function)[ \\t]+[^\\s']+", "\\bEnd (Sub|Function)\\b", RegexOptions.IgnoreCase);
		range.SetFoldingMarkers("(\\r|\\n|^)[ \\t]*(?<range>Get|Set)[ \\t]*(\\r|\\n|$)", "\\bEnd (Get|Set)\\b", RegexOptions.IgnoreCase);
		range.SetFoldingMarkers("^\\s*(?<range>For|For\\s+Each)\\b", "^\\s*(?<range>Next)\\b", RegexOptions.IgnoreCase | RegexOptions.Multiline);
		range.SetFoldingMarkers("^\\s*(?<range>Do)\\b", "^\\s*(?<range>Loop)\\b", RegexOptions.IgnoreCase | RegexOptions.Multiline);
	}

	protected void InitHTMLRegex()
	{
		HTMLCommentRegex1 = new Regex("(<!--.*?-->)|(<!--.*)", RegexOptions.Singleline | RegexCompiledOption);
		HTMLCommentRegex2 = new Regex("(<!--.*?-->)|(.*-->)", RegexOptions.Singleline | RegexOptions.RightToLeft | RegexCompiledOption);
		HTMLTagRegex = new Regex("<|/>|</|>", RegexCompiledOption);
		HTMLTagNameRegex = new Regex("<(?<range>[!\\w:]+)", RegexCompiledOption);
		HTMLEndTagRegex = new Regex("</(?<range>[\\w:]+)>", RegexCompiledOption);
		HTMLTagContentRegex = new Regex("<[^>]+>", RegexCompiledOption);
		HTMLAttrRegex = new Regex("(?<range>[\\w\\d\\-]{1,20}?)='[^']*'|(?<range>[\\w\\d\\-]{1,20})=\"[^\"]*\"|(?<range>[\\w\\d\\-]{1,20})=[\\w\\d\\-]{1,20}", RegexCompiledOption);
		HTMLAttrValRegex = new Regex("[\\w\\d\\-]{1,20}?=(?<range>'[^']*')|[\\w\\d\\-]{1,20}=(?<range>\"[^\"]*\")|[\\w\\d\\-]{1,20}=(?<range>[\\w\\d\\-]{1,20})", RegexCompiledOption);
		HTMLEntityRegex = new Regex("\\&(amp|gt|lt|nbsp|quot|apos|copy|reg|#[0-9]{1,8}|#x[0-9a-f]{1,8});", RegexCompiledOption | RegexOptions.IgnoreCase);
	}

	public virtual void HTMLSyntaxHighlight(Range range)
	{
		range.tb.CommentPrefix = null;
		range.tb.LeftBracket = '<';
		range.tb.RightBracket = '>';
		range.tb.LeftBracket2 = '(';
		range.tb.RightBracket2 = ')';
		range.tb.AutoIndentCharsPatterns = "";
		range.ClearStyle(CommentStyle, TagBracketStyle, TagNameStyle, AttributeStyle, AttributeValueStyle, HtmlEntityStyle);
		if (HTMLTagRegex == null)
		{
			InitHTMLRegex();
		}
		range.SetStyle(CommentStyle, HTMLCommentRegex1);
		range.SetStyle(CommentStyle, HTMLCommentRegex2);
		range.SetStyle(TagBracketStyle, HTMLTagRegex);
		range.SetStyle(TagNameStyle, HTMLTagNameRegex);
		range.SetStyle(TagNameStyle, HTMLEndTagRegex);
		range.SetStyle(AttributeStyle, HTMLAttrRegex);
		range.SetStyle(AttributeValueStyle, HTMLAttrValRegex);
		range.SetStyle(HtmlEntityStyle, HTMLEntityRegex);
		range.ClearFoldingMarkers();
		range.SetFoldingMarkers("<head", "</head>", RegexOptions.IgnoreCase);
		range.SetFoldingMarkers("<body", "</body>", RegexOptions.IgnoreCase);
		range.SetFoldingMarkers("<table", "</table>", RegexOptions.IgnoreCase);
		range.SetFoldingMarkers("<form", "</form>", RegexOptions.IgnoreCase);
		range.SetFoldingMarkers("<div", "</div>", RegexOptions.IgnoreCase);
		range.SetFoldingMarkers("<script", "</script>", RegexOptions.IgnoreCase);
		range.SetFoldingMarkers("<tr", "</tr>", RegexOptions.IgnoreCase);
	}

	protected void InitXMLRegex()
	{
		XMLCommentRegex1 = new Regex("(<!--.*?-->)|(<!--.*)", RegexOptions.Singleline | RegexCompiledOption);
		XMLCommentRegex2 = new Regex("(<!--.*?-->)|(.*-->)", RegexOptions.Singleline | RegexOptions.RightToLeft | RegexCompiledOption);
		XMLTagRegex = new Regex("<\\?|<|/>|</|>|\\?>", RegexCompiledOption);
		XMLTagNameRegex = new Regex("<[?](?<range1>[x][m][l]{1})|<(?<range>[!\\w:]+)", RegexCompiledOption);
		XMLEndTagRegex = new Regex("</(?<range>[\\w:]+)>", RegexCompiledOption);
		XMLTagContentRegex = new Regex("<[^>]+>", RegexCompiledOption);
		XMLAttrRegex = new Regex("(?<range>[\\w\\d\\-\\:]+)[ ]*=[ ]*'[^']*'|(?<range>[\\w\\d\\-\\:]+)[ ]*=[ ]*\"[^\"]*\"|(?<range>[\\w\\d\\-\\:]+)[ ]*=[ ]*[\\w\\d\\-\\:]+", RegexCompiledOption);
		XMLAttrValRegex = new Regex("[\\w\\d\\-]+?=(?<range>'[^']*')|[\\w\\d\\-]+[ ]*=[ ]*(?<range>\"[^\"]*\")|[\\w\\d\\-]+[ ]*=[ ]*(?<range>[\\w\\d\\-]+)", RegexCompiledOption);
		XMLEntityRegex = new Regex("\\&(amp|gt|lt|nbsp|quot|apos|copy|reg|#[0-9]{1,8}|#x[0-9a-f]{1,8});", RegexCompiledOption | RegexOptions.IgnoreCase);
		XMLCDataRegex = new Regex("<!\\s*\\[CDATA\\s*\\[(?<text>(?>[^]]+|](?!]>))*)]]>", RegexCompiledOption | RegexOptions.IgnoreCase);
		XMLFoldingRegex = new Regex("<(?<range>/?\\w+)\\s[^>]*?[^/]>|<(?<range>/?\\w+)\\s*>", RegexOptions.Singleline | RegexCompiledOption);
	}

	public virtual void XMLSyntaxHighlight(Range range)
	{
		range.tb.CommentPrefix = null;
		range.tb.LeftBracket = '<';
		range.tb.RightBracket = '>';
		range.tb.LeftBracket2 = '(';
		range.tb.RightBracket2 = ')';
		range.tb.AutoIndentCharsPatterns = "";
		range.ClearStyle(CommentStyle, XmlTagBracketStyle, XmlTagNameStyle, XmlAttributeStyle, XmlAttributeValueStyle, XmlEntityStyle, XmlCDataStyle);
		if (XMLTagRegex == null)
		{
			InitXMLRegex();
		}
		range.SetStyle(XmlCDataStyle, XMLCDataRegex);
		range.SetStyle(CommentStyle, XMLCommentRegex1);
		range.SetStyle(CommentStyle, XMLCommentRegex2);
		range.SetStyle(XmlTagBracketStyle, XMLTagRegex);
		range.SetStyle(XmlTagNameStyle, XMLTagNameRegex);
		range.SetStyle(XmlTagNameStyle, XMLEndTagRegex);
		range.SetStyle(XmlAttributeStyle, XMLAttrRegex);
		range.SetStyle(XmlAttributeValueStyle, XMLAttrValRegex);
		range.SetStyle(XmlEntityStyle, XMLEntityRegex);
		range.ClearFoldingMarkers();
		XmlFolding(range);
	}

	private void XmlFolding(Range range)
	{
		Stack<XmlFoldingTag> stack = new Stack<XmlFoldingTag>();
		int num = 0;
		FastColoredTextBox tb = range.tb;
		foreach (Range range2 in range.GetRanges(XMLFoldingRegex))
		{
			string text = range2.Text;
			int iLine = range2.Start.iLine;
			if (text[0] != '/')
			{
				XmlFoldingTag xmlFoldingTag = new XmlFoldingTag
				{
					Name = text,
					id = num++,
					startLine = range2.Start.iLine
				};
				stack.Push(xmlFoldingTag);
				if (string.IsNullOrEmpty(tb[iLine].FoldingStartMarker))
				{
					tb[iLine].FoldingStartMarker = xmlFoldingTag.Marker;
				}
			}
			else
			{
				if (stack.Count <= 0)
				{
					continue;
				}
				XmlFoldingTag xmlFoldingTag2 = stack.Pop();
				if (iLine == xmlFoldingTag2.startLine)
				{
					if (tb[iLine].FoldingStartMarker == xmlFoldingTag2.Marker)
					{
						tb[iLine].FoldingStartMarker = null;
					}
				}
				else if (string.IsNullOrEmpty(tb[iLine].FoldingEndMarker))
				{
					tb[iLine].FoldingEndMarker = xmlFoldingTag2.Marker;
				}
			}
		}
	}

	protected void InitSQLRegex()
	{
		SQLStringRegex = new Regex("\"\"|''|\".*?[^\\\\]\"|'.*?[^\\\\]'", RegexCompiledOption);
		SQLNumberRegex = new Regex("\\b\\d+[\\.]?\\d*([eE]\\-?\\d+)?\\b", RegexCompiledOption);
		SQLCommentRegex1 = new Regex("--.*$", RegexOptions.Multiline | RegexCompiledOption);
		SQLCommentRegex2 = new Regex("(/\\*.*?\\*/)|(/\\*.*)", RegexOptions.Singleline | RegexCompiledOption);
		SQLCommentRegex3 = new Regex("(/\\*.*?\\*/)|(.*\\*/)", RegexOptions.Singleline | RegexOptions.RightToLeft | RegexCompiledOption);
		SQLCommentRegex4 = new Regex("#.*$", RegexOptions.Multiline | RegexCompiledOption);
		SQLVarRegex = new Regex("@[a-zA-Z_\\d]*\\b", RegexCompiledOption);
		SQLStatementsRegex = new Regex("\\b(ALTER APPLICATION ROLE|ALTER ASSEMBLY|ALTER ASYMMETRIC KEY|ALTER AUTHORIZATION|ALTER BROKER PRIORITY|ALTER CERTIFICATE|ALTER CREDENTIAL|ALTER CRYPTOGRAPHIC PROVIDER|ALTER DATABASE|ALTER DATABASE AUDIT SPECIFICATION|ALTER DATABASE ENCRYPTION KEY|ALTER ENDPOINT|ALTER EVENT SESSION|ALTER FULLTEXT CATALOG|ALTER FULLTEXT INDEX|ALTER FULLTEXT STOPLIST|ALTER FUNCTION|ALTER INDEX|ALTER LOGIN|ALTER MASTER KEY|ALTER MESSAGE TYPE|ALTER PARTITION FUNCTION|ALTER PARTITION SCHEME|ALTER PROCEDURE|ALTER QUEUE|ALTER REMOTE SERVICE BINDING|ALTER RESOURCE GOVERNOR|ALTER RESOURCE POOL|ALTER ROLE|ALTER ROUTE|ALTER SCHEMA|ALTER SERVER AUDIT|ALTER SERVER AUDIT SPECIFICATION|ALTER SERVICE|ALTER SERVICE MASTER KEY|ALTER SYMMETRIC KEY|ALTER TABLE|ALTER TRIGGER|ALTER USER|ALTER VIEW|ALTER WORKLOAD GROUP|ALTER XML SCHEMA COLLECTION|BULK INSERT|CREATE AGGREGATE|CREATE APPLICATION ROLE|CREATE ASSEMBLY|CREATE ASYMMETRIC KEY|CREATE BROKER PRIORITY|CREATE CERTIFICATE|CREATE CONTRACT|CREATE CREDENTIAL|CREATE CRYPTOGRAPHIC PROVIDER|CREATE DATABASE|CREATE DATABASE AUDIT SPECIFICATION|CREATE DATABASE ENCRYPTION KEY|CREATE DEFAULT|CREATE ENDPOINT|CREATE EVENT NOTIFICATION|CREATE EVENT SESSION|CREATE FULLTEXT CATALOG|CREATE FULLTEXT INDEX|CREATE FULLTEXT STOPLIST|CREATE FUNCTION|CREATE INDEX|CREATE LOGIN|CREATE MASTER KEY|CREATE MESSAGE TYPE|CREATE PARTITION FUNCTION|CREATE PARTITION SCHEME|CREATE PROCEDURE|CREATE QUEUE|CREATE REMOTE SERVICE BINDING|CREATE RESOURCE POOL|CREATE ROLE|CREATE ROUTE|CREATE RULE|CREATE SCHEMA|CREATE SERVER AUDIT|CREATE SERVER AUDIT SPECIFICATION|CREATE SERVICE|CREATE SPATIAL INDEX|CREATE STATISTICS|CREATE SYMMETRIC KEY|CREATE SYNONYM|CREATE TABLE|CREATE TRIGGER|CREATE TYPE|CREATE USER|CREATE VIEW|CREATE WORKLOAD GROUP|CREATE XML INDEX|CREATE XML SCHEMA COLLECTION|DELETE|DISABLE TRIGGER|DROP AGGREGATE|DROP APPLICATION ROLE|DROP ASSEMBLY|DROP ASYMMETRIC KEY|DROP BROKER PRIORITY|DROP CERTIFICATE|DROP CONTRACT|DROP CREDENTIAL|DROP CRYPTOGRAPHIC PROVIDER|DROP DATABASE|DROP DATABASE AUDIT SPECIFICATION|DROP DATABASE ENCRYPTION KEY|DROP DEFAULT|DROP ENDPOINT|DROP EVENT NOTIFICATION|DROP EVENT SESSION|DROP FULLTEXT CATALOG|DROP FULLTEXT INDEX|DROP FULLTEXT STOPLIST|DROP FUNCTION|DROP INDEX|DROP LOGIN|DROP MASTER KEY|DROP MESSAGE TYPE|DROP PARTITION FUNCTION|DROP PARTITION SCHEME|DROP PROCEDURE|DROP QUEUE|DROP REMOTE SERVICE BINDING|DROP RESOURCE POOL|DROP ROLE|DROP ROUTE|DROP RULE|DROP SCHEMA|DROP SERVER AUDIT|DROP SERVER AUDIT SPECIFICATION|DROP SERVICE|DROP SIGNATURE|DROP STATISTICS|DROP SYMMETRIC KEY|DROP SYNONYM|DROP TABLE|DROP TRIGGER|DROP TYPE|DROP USER|DROP VIEW|DROP WORKLOAD GROUP|DROP XML SCHEMA COLLECTION|ENABLE TRIGGER|EXEC|EXECUTE|REPLACE|FROM|INSERT|MERGE|OPTION|OUTPUT|SELECT|TOP|TRUNCATE TABLE|UPDATE|UPDATE STATISTICS|WHERE|WITH|INTO|IN|SET)\\b", RegexOptions.IgnoreCase | RegexCompiledOption);
		SQLKeywordsRegex = new Regex("\\b(ADD|ALL|AND|ANY|AS|ASC|AUTHORIZATION|BACKUP|BEGIN|BETWEEN|BREAK|BROWSE|BY|CASCADE|CHECK|CHECKPOINT|CLOSE|CLUSTERED|COLLATE|COLUMN|COMMIT|COMPUTE|CONSTRAINT|CONTAINS|CONTINUE|CROSS|CURRENT|CURRENT_DATE|CURRENT_TIME|CURSOR|DATABASE|DBCC|DEALLOCATE|DECLARE|DEFAULT|DENY|DESC|DISK|DISTINCT|DISTRIBUTED|DOUBLE|DUMP|ELSE|END|ERRLVL|ESCAPE|EXCEPT|EXISTS|EXIT|EXTERNAL|FETCH|FILE|FILLFACTOR|FOR|FOREIGN|FREETEXT|FULL|FUNCTION|GOTO|GRANT|GROUP|HAVING|HOLDLOCK|IDENTITY|IDENTITY_INSERT|IDENTITYCOL|IF|INDEX|INNER|INTERSECT|IS|JOIN|KEY|KILL|LIKE|LINENO|LOAD|NATIONAL|NOCHECK|NONCLUSTERED|NOT|NULL|OF|OFF|OFFSETS|ON|OPEN|OR|ORDER|OUTER|OVER|PERCENT|PIVOT|PLAN|PRECISION|PRIMARY|PRINT|PROC|PROCEDURE|PUBLIC|RAISERROR|READ|READTEXT|RECONFIGURE|REFERENCES|REPLICATION|RESTORE|RESTRICT|RETURN|REVERT|REVOKE|ROLLBACK|ROWCOUNT|ROWGUIDCOL|RULE|SAVE|SCHEMA|SECURITYAUDIT|SHUTDOWN|SOME|STATISTICS|TABLE|TABLESAMPLE|TEXTSIZE|THEN|TO|TRAN|TRANSACTION|TRIGGER|TSEQUAL|UNION|UNIQUE|UNPIVOT|UPDATETEXT|USE|USER|VALUES|VARYING|VIEW|WAITFOR|WHEN|WHILE|WRITETEXT)\\b", RegexOptions.IgnoreCase | RegexCompiledOption);
		SQLFunctionsRegex = new Regex("(@@CONNECTIONS|@@CPU_BUSY|@@CURSOR_ROWS|@@DATEFIRST|@@DATEFIRST|@@DBTS|@@ERROR|@@FETCH_STATUS|@@IDENTITY|@@IDLE|@@IO_BUSY|@@LANGID|@@LANGUAGE|@@LOCK_TIMEOUT|@@MAX_CONNECTIONS|@@MAX_PRECISION|@@NESTLEVEL|@@OPTIONS|@@PACKET_ERRORS|@@PROCID|@@REMSERVER|@@ROWCOUNT|@@SERVERNAME|@@SERVICENAME|@@SPID|@@TEXTSIZE|@@TRANCOUNT|@@VERSION)\\b|\\b(ABS|ACOS|APP_NAME|ASCII|ASIN|ASSEMBLYPROPERTY|AsymKey_ID|ASYMKEY_ID|asymkeyproperty|ASYMKEYPROPERTY|ATAN|ATN2|AVG|CASE|CAST|CEILING|Cert_ID|Cert_ID|CertProperty|CHAR|CHARINDEX|CHECKSUM_AGG|COALESCE|COL_LENGTH|COL_NAME|COLLATIONPROPERTY|COLLATIONPROPERTY|COLUMNPROPERTY|COLUMNS_UPDATED|COLUMNS_UPDATED|CONTAINSTABLE|CONVERT|COS|COT|COUNT|COUNT_BIG|CRYPT_GEN_RANDOM|CURRENT_TIMESTAMP|CURRENT_TIMESTAMP|CURRENT_USER|CURRENT_USER|CURSOR_STATUS|DATABASE_PRINCIPAL_ID|DATABASE_PRINCIPAL_ID|DATABASEPROPERTY|DATABASEPROPERTYEX|DATALENGTH|DATALENGTH|DATEADD|DATEDIFF|DATENAME|DATEPART|DAY|DB_ID|DB_NAME|DECRYPTBYASYMKEY|DECRYPTBYCERT|DECRYPTBYKEY|DECRYPTBYKEYAUTOASYMKEY|DECRYPTBYKEYAUTOCERT|DECRYPTBYPASSPHRASE|DEGREES|DENSE_RANK|DIFFERENCE|ENCRYPTBYASYMKEY|ENCRYPTBYCERT|ENCRYPTBYKEY|ENCRYPTBYPASSPHRASE|ERROR_LINE|ERROR_MESSAGE|ERROR_NUMBER|ERROR_PROCEDURE|ERROR_SEVERITY|ERROR_STATE|EVENTDATA|EXP|FILE_ID|FILE_IDEX|FILE_NAME|FILEGROUP_ID|FILEGROUP_NAME|FILEGROUPPROPERTY|FILEPROPERTY|FLOOR|fn_helpcollations|fn_listextendedproperty|fn_servershareddrives|fn_virtualfilestats|fn_virtualfilestats|FORMATMESSAGE|FREETEXTTABLE|FULLTEXTCATALOGPROPERTY|FULLTEXTSERVICEPROPERTY|GETANSINULL|GETDATE|GETUTCDATE|GROUPING|HAS_PERMS_BY_NAME|HOST_ID|HOST_NAME|IDENT_CURRENT|IDENT_CURRENT|IDENT_INCR|IDENT_INCR|IDENT_SEED|IDENTITY\\(|INDEX_COL|INDEXKEY_PROPERTY|INDEXPROPERTY|IS_MEMBER|IS_OBJECTSIGNED|IS_SRVROLEMEMBER|ISDATE|ISDATE|ISNULL|ISNUMERIC|Key_GUID|Key_GUID|Key_ID|Key_ID|KEY_NAME|KEY_NAME|LEFT|LEN|LOG|LOG10|LOWER|LTRIM|MAX|MIN|MONTH|NCHAR|NEWID|NTILE|NULLIF|OBJECT_DEFINITION|OBJECT_ID|OBJECT_NAME|OBJECT_SCHEMA_NAME|OBJECTPROPERTY|OBJECTPROPERTYEX|OPENDATASOURCE|OPENQUERY|OPENROWSET|OPENXML|ORIGINAL_LOGIN|ORIGINAL_LOGIN|PARSENAME|PATINDEX|PATINDEX|PERMISSIONS|PI|POWER|PUBLISHINGSERVERNAME|PWDCOMPARE|PWDENCRYPT|QUOTENAME|RADIANS|RAND|RANK|REPLICATE|REVERSE|RIGHT|ROUND|ROW_NUMBER|ROWCOUNT_BIG|RTRIM|SCHEMA_ID|SCHEMA_ID|SCHEMA_NAME|SCHEMA_NAME|SCOPE_IDENTITY|SERVERPROPERTY|SESSION_USER|SESSION_USER|SESSIONPROPERTY|SETUSER|SIGN|SignByAsymKey|SignByCert|SIN|SOUNDEX|SPACE|SQL_VARIANT_PROPERTY|SQRT|SQUARE|STATS_DATE|STDEV|STDEVP|STR|STUFF|SUBSTRING|SUM|SUSER_ID|SUSER_NAME|SUSER_SID|SUSER_SNAME|SWITCHOFFSET|SYMKEYPROPERTY|symkeyproperty|sys\\.dm_db_index_physical_stats|sys\\.fn_builtin_permissions|sys\\.fn_my_permissions|SYSDATETIME|SYSDATETIMEOFFSET|SYSTEM_USER|SYSTEM_USER|SYSUTCDATETIME|TAN|TERTIARY_WEIGHTS|TEXTPTR|TODATETIMEOFFSET|TRIGGER_NESTLEVEL|TYPE_ID|TYPE_NAME|TYPEPROPERTY|UNICODE|UPDATE\\(|UPPER|USER_ID|USER_NAME|USER_NAME|VAR|VARP|VerifySignedByAsymKey|VerifySignedByCert|XACT_STATE|YEAR)\\b", RegexOptions.IgnoreCase | RegexCompiledOption);
		SQLTypesRegex = new Regex("\\b(BIGINT|NUMERIC|BIT|SMALLINT|DECIMAL|SMALLMONEY|INT|TINYINT|MONEY|FLOAT|REAL|DATE|DATETIMEOFFSET|DATETIME2|SMALLDATETIME|DATETIME|TIME|CHAR|VARCHAR|TEXT|NCHAR|NVARCHAR|NTEXT|BINARY|VARBINARY|IMAGE|TIMESTAMP|HIERARCHYID|TABLE|UNIQUEIDENTIFIER|SQL_VARIANT|XML)\\b", RegexOptions.IgnoreCase | RegexCompiledOption);
	}

	public virtual void SQLSyntaxHighlight(Range range)
	{
		range.tb.CommentPrefix = "--";
		range.tb.LeftBracket = '(';
		range.tb.RightBracket = ')';
		range.tb.LeftBracket2 = '\0';
		range.tb.RightBracket2 = '\0';
		range.tb.AutoIndentCharsPatterns = "";
		range.ClearStyle(CommentStyle, StringStyle, NumberStyle, VariableStyle, StatementsStyle, KeywordStyle, FunctionsStyle, TypesStyle);
		if (SQLStringRegex == null)
		{
			InitSQLRegex();
		}
		range.SetStyle(CommentStyle, SQLCommentRegex1);
		range.SetStyle(CommentStyle, SQLCommentRegex2);
		range.SetStyle(CommentStyle, SQLCommentRegex3);
		range.SetStyle(CommentStyle, SQLCommentRegex4);
		range.SetStyle(StringStyle, SQLStringRegex);
		range.SetStyle(NumberStyle, SQLNumberRegex);
		range.SetStyle(TypesStyle, SQLTypesRegex);
		range.SetStyle(VariableStyle, SQLVarRegex);
		range.SetStyle(StatementsStyle, SQLStatementsRegex);
		range.SetStyle(KeywordStyle, SQLKeywordsRegex);
		range.SetStyle(FunctionsStyle, SQLFunctionsRegex);
		range.ClearFoldingMarkers();
		range.SetFoldingMarkers("\\bBEGIN\\b", "\\bEND\\b", RegexOptions.IgnoreCase);
		range.SetFoldingMarkers("/\\*", "\\*/");
	}

	protected void InitPHPRegex()
	{
		PHPStringRegex = new Regex("\"\"|''|\".*?[^\\\\]\"|'.*?[^\\\\]'", RegexCompiledOption);
		PHPNumberRegex = new Regex("\\b\\d+[\\.]?\\d*\\b", RegexCompiledOption);
		PHPCommentRegex1 = new Regex("(//|#).*$", RegexOptions.Multiline | RegexCompiledOption);
		PHPCommentRegex2 = new Regex("(/\\*.*?\\*/)|(/\\*.*)", RegexOptions.Singleline | RegexCompiledOption);
		PHPCommentRegex3 = new Regex("(/\\*.*?\\*/)|(.*\\*/)", RegexOptions.Singleline | RegexOptions.RightToLeft | RegexCompiledOption);
		PHPVarRegex = new Regex("\\$[a-zA-Z_\\d]*\\b", RegexCompiledOption);
		PHPKeywordRegex1 = new Regex("\\b(die|echo|empty|exit|eval|include|include_once|isset|list|require|require_once|return|print|unset)\\b", RegexCompiledOption);
		PHPKeywordRegex2 = new Regex("\\b(abstract|and|array|as|break|case|catch|cfunction|class|clone|const|continue|declare|default|do|else|elseif|enddeclare|endfor|endforeach|endif|endswitch|endwhile|extends|final|for|foreach|function|global|goto|if|implements|instanceof|interface|namespace|new|or|private|protected|public|static|switch|throw|try|use|var|while|xor)\\b", RegexCompiledOption);
		PHPKeywordRegex3 = new Regex("__CLASS__|__DIR__|__FILE__|__LINE__|__FUNCTION__|__METHOD__|__NAMESPACE__", RegexCompiledOption);
	}

	public virtual void PHPSyntaxHighlight(Range range)
	{
		range.tb.CommentPrefix = "//";
		range.tb.LeftBracket = '(';
		range.tb.RightBracket = ')';
		range.tb.LeftBracket2 = '{';
		range.tb.RightBracket2 = '}';
		range.tb.BracketsHighlightStrategy = BracketsHighlightStrategy.Strategy2;
		range.ClearStyle(StringStyle, CommentStyle, NumberStyle, VariableStyle, KeywordStyle, KeywordStyle2, KeywordStyle3);
		range.tb.AutoIndentCharsPatterns = "\r\n^\\s*\\$[\\w\\.\\[\\]\\'\\\"]+\\s*(?<range>=)\\s*(?<range>[^;]+);\r\n";
		if (PHPStringRegex == null)
		{
			InitPHPRegex();
		}
		range.SetStyle(StringStyle, PHPStringRegex);
		range.SetStyle(CommentStyle, PHPCommentRegex1);
		range.SetStyle(CommentStyle, PHPCommentRegex2);
		range.SetStyle(CommentStyle, PHPCommentRegex3);
		range.SetStyle(NumberStyle, PHPNumberRegex);
		range.SetStyle(VariableStyle, PHPVarRegex);
		range.SetStyle(KeywordStyle, PHPKeywordRegex1);
		range.SetStyle(KeywordStyle2, PHPKeywordRegex2);
		range.SetStyle(KeywordStyle3, PHPKeywordRegex3);
		range.ClearFoldingMarkers();
		range.SetFoldingMarkers("{", "}");
		range.SetFoldingMarkers("/\\*", "\\*/");
	}

	protected void InitJScriptRegex()
	{
		JScriptStringRegex = new Regex("\"\"|''|\".*?[^\\\\]\"|'.*?[^\\\\]'", RegexCompiledOption);
		JScriptCommentRegex1 = new Regex("//.*$", RegexOptions.Multiline | RegexCompiledOption);
		JScriptCommentRegex2 = new Regex("(/\\*.*?\\*/)|(/\\*.*)", RegexOptions.Singleline | RegexCompiledOption);
		JScriptCommentRegex3 = new Regex("(/\\*.*?\\*/)|(.*\\*/)", RegexOptions.Singleline | RegexOptions.RightToLeft | RegexCompiledOption);
		JScriptNumberRegex = new Regex("\\b\\d+[\\.]?\\d*([eE]\\-?\\d+)?[lLdDfF]?\\b|\\b0x[a-fA-F\\d]+\\b", RegexCompiledOption);
		JScriptKeywordRegex = new Regex("\\b(true|false|break|case|catch|const|continue|default|delete|do|else|export|for|function|if|in|instanceof|new|null|return|switch|this|throw|try|var|void|while|with|typeof)\\b", RegexCompiledOption);
	}

	public virtual void JScriptSyntaxHighlight(Range range)
	{
		range.tb.CommentPrefix = "//";
		range.tb.LeftBracket = '(';
		range.tb.RightBracket = ')';
		range.tb.LeftBracket2 = '{';
		range.tb.RightBracket2 = '}';
		range.tb.BracketsHighlightStrategy = BracketsHighlightStrategy.Strategy2;
		range.tb.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\r\n";
		range.ClearStyle(StringStyle, CommentStyle, NumberStyle, KeywordStyle);
		if (JScriptStringRegex == null)
		{
			InitJScriptRegex();
		}
		range.SetStyle(StringStyle, JScriptStringRegex);
		range.SetStyle(CommentStyle, JScriptCommentRegex1);
		range.SetStyle(CommentStyle, JScriptCommentRegex2);
		range.SetStyle(CommentStyle, JScriptCommentRegex3);
		range.SetStyle(NumberStyle, JScriptNumberRegex);
		range.SetStyle(KeywordStyle, JScriptKeywordRegex);
		range.ClearFoldingMarkers();
		range.SetFoldingMarkers("{", "}");
		range.SetFoldingMarkers("/\\*", "\\*/");
	}

	protected void InitLuaRegex()
	{
		LuaStringRegex = new Regex("\"\"|''|\".*?[^\\\\]\"|'.*?[^\\\\]'", RegexCompiledOption);
		LuaCommentRegex1 = new Regex("--.*$", RegexOptions.Multiline | RegexCompiledOption);
		LuaCommentRegex2 = new Regex("(--\\[\\[.*?\\]\\])|(--\\[\\[.*)", RegexOptions.Singleline | RegexCompiledOption);
		LuaCommentRegex3 = new Regex("(--\\[\\[.*?\\]\\])|(.*\\]\\])", RegexOptions.Singleline | RegexOptions.RightToLeft | RegexCompiledOption);
		LuaNumberRegex = new Regex("\\b\\d+[\\.]?\\d*([eE]\\-?\\d+)?[lLdDfF]?\\b|\\b0x[a-fA-F\\d]+\\b", RegexCompiledOption);
		LuaKeywordRegex = new Regex("\\b(and|break|do|else|elseif|end|false|for|function|if|in|local|nil|not|or|repeat|return|then|true|until|while)\\b", RegexCompiledOption);
		LuaFunctionsRegex = new Regex("\\b(assert|collectgarbage|dofile|error|getfenv|getmetatable|ipairs|load|loadfile|loadstring|module|next|pairs|pcall|print|rawequal|rawget|rawset|require|select|setfenv|setmetatable|tonumber|tostring|type|unpack|xpcall)\\b", RegexCompiledOption);
	}

	public virtual void LuaSyntaxHighlight(Range range)
	{
		range.tb.CommentPrefix = "--";
		range.tb.LeftBracket = '(';
		range.tb.RightBracket = ')';
		range.tb.LeftBracket2 = '{';
		range.tb.RightBracket2 = '}';
		range.tb.BracketsHighlightStrategy = BracketsHighlightStrategy.Strategy2;
		range.tb.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>.+)\r\n";
		range.ClearStyle(StringStyle, CommentStyle, NumberStyle, KeywordStyle, FunctionsStyle);
		if (LuaStringRegex == null)
		{
			InitLuaRegex();
		}
		range.SetStyle(StringStyle, LuaStringRegex);
		range.SetStyle(CommentStyle, LuaCommentRegex1);
		range.SetStyle(CommentStyle, LuaCommentRegex2);
		range.SetStyle(CommentStyle, LuaCommentRegex3);
		range.SetStyle(NumberStyle, LuaNumberRegex);
		range.SetStyle(KeywordStyle, LuaKeywordRegex);
		range.SetStyle(FunctionsStyle, LuaFunctionsRegex);
		range.ClearFoldingMarkers();
		range.SetFoldingMarkers("{", "}");
		range.SetFoldingMarkers("--\\[\\[", "\\]\\]");
	}

	protected void LuaAutoIndentNeeded(object sender, AutoIndentEventArgs args)
	{
		if (Regex.IsMatch(args.LineText, "^\\s*(end|until)\\b"))
		{
			args.Shift = -args.TabLength;
			args.ShiftNextLines = -args.TabLength;
		}
		else if (!Regex.IsMatch(args.LineText, "\\b(then)\\s*\\S+"))
		{
			if (Regex.IsMatch(args.LineText, "^\\s*(function|do|for|while|repeat|if)\\b"))
			{
				args.ShiftNextLines = args.TabLength;
			}
			else if (Regex.IsMatch(args.LineText, "^\\s*(else|elseif)\\b", RegexOptions.IgnoreCase))
			{
				args.Shift = -args.TabLength;
			}
		}
	}
}
