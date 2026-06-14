using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using Microsoft.Win32;

namespace FastColoredTextBoxNS;

public class FastColoredTextBox : UserControl, ISupportInitialize
{
	private class LineYComparer : IComparer<LineInfo>
	{
		private readonly int Y;

		public LineYComparer(int Y)
		{
			this.Y = Y;
		}

		public int Compare(LineInfo x, LineInfo y)
		{
			if (x.startY == -10)
			{
				return -y.startY.CompareTo(Y);
			}
			return x.startY.CompareTo(Y);
		}
	}

	internal const int minLeftIndent = 8;

	private const int maxBracketSearchIterations = 1000;

	private const int maxLinesForFolding = 3000;

	private const int minLinesForAccuracy = 100000;

	private const int WM_IME_SETCONTEXT = 641;

	private const int WM_HSCROLL = 276;

	private const int WM_VSCROLL = 277;

	private const int SB_ENDSCROLL = 8;

	public readonly List<LineInfo> LineInfos = new List<LineInfo>();

	private readonly Range selection;

	private readonly System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

	private readonly System.Windows.Forms.Timer timer2 = new System.Windows.Forms.Timer();

	private readonly System.Windows.Forms.Timer timer3 = new System.Windows.Forms.Timer();

	private readonly List<VisualMarker> visibleMarkers = new List<VisualMarker>();

	public int TextHeight;

	public bool AllowInsertRemoveLines = true;

	private Brush backBrush;

	private BaseBookmarks bookmarks;

	private bool caretVisible;

	private Color changedLineColor;

	private int charHeight;

	private Color currentLineColor;

	private Cursor defaultCursor;

	private Range delayedTextChangedRange;

	private string descriptionFile;

	private int endFoldingLine = -1;

	private Color foldingIndicatorColor;

	protected Dictionary<int, int> foldingPairs = new Dictionary<int, int>();

	private bool handledChar;

	private bool highlightFoldingIndicator;

	private Hints hints;

	private Color indentBackColor;

	private bool isChanged;

	private bool isLineSelect;

	private bool isReplaceMode;

	private Language language;

	private Keys lastModifiers;

	private Point lastMouseCoord;

	private DateTime lastNavigatedDateTime;

	private Range leftBracketPosition;

	private Range leftBracketPosition2;

	private int leftPadding;

	private int lineInterval;

	private Color lineNumberColor;

	private uint lineNumberStartValue;

	private int lineSelectFrom;

	private TextSource lines;

	private IntPtr m_hImc;

	private int maxLineLength;

	private bool mouseIsDrag;

	private bool mouseIsDragDrop;

	private bool multiline;

	protected bool needRecalc;

	protected bool needRecalcWordWrap;

	private Point needRecalcWordWrapInterval;

	private bool needRecalcFoldingLines;

	private bool needRiseSelectionChangedDelayed;

	private bool needRiseTextChangedDelayed;

	private bool needRiseVisibleRangeChangedDelayed;

	private Color paddingBackColor;

	private int preferredLineWidth;

	private Range rightBracketPosition;

	private Range rightBracketPosition2;

	private bool scrollBars;

	private Color selectionColor;

	private Color serviceLinesColor;

	private bool showFoldingLines;

	private bool showLineNumbers;

	private FastColoredTextBox sourceTextBox;

	private int startFoldingLine = -1;

	private int updating;

	private Range updatingRange;

	private Range visibleRange;

	private bool wordWrap;

	private WordWrapMode wordWrapMode = WordWrapMode.WordWrapControlWidth;

	private int reservedCountOfLineNumberChars = 1;

	private int zoom = 100;

	private Size localAutoScrollMinSize;

	private char[] autoCompleteBracketsList = new char[10] { '(', ')', '{', '}', '[', ']', '"', '"', '\'', '\'' };

	private MacrosManager macrosManager;

	private Color textAreaBorderColor;

	private TextAreaBorderType textAreaBorder;

	private bool selectionHighlightingForLineBreaksEnabled;

	private Font baseFont;

	private Dictionary<System.Windows.Forms.Timer, System.Windows.Forms.Timer> timersToReset = new Dictionary<System.Windows.Forms.Timer, System.Windows.Forms.Timer>();

	private List<Control> tempHintsList = new List<Control>();

	private bool findCharMode;

	private static Dictionary<FCTBAction, bool> scrollActions = new Dictionary<FCTBAction, bool>
	{
		{
			FCTBAction.ScrollDown,
			true
		},
		{
			FCTBAction.ScrollUp,
			true
		},
		{
			FCTBAction.ZoomOut,
			true
		},
		{
			FCTBAction.ZoomIn,
			true
		},
		{
			FCTBAction.ZoomNormal,
			true
		}
	};

	private Font originalFont;

	private const int WM_CHAR = 258;

	private Rectangle prevCaretRect;

	protected Range draggedRange;

	private bool middleClickScrollingActivated;

	private Point middleClickScrollingOriginPoint;

	private Point middleClickScrollingOriginScroll;

	private readonly System.Windows.Forms.Timer middleClickScrollingTimer = new System.Windows.Forms.Timer();

	private ScrollDirection middleClickScollDirection = ScrollDirection.None;

	private const int WM_SETREDRAW = 11;

	public char[] AutoCompleteBracketsList
	{
		get
		{
			return autoCompleteBracketsList;
		}
		set
		{
			autoCompleteBracketsList = value;
		}
	}

	[DefaultValue(false)]
	[Description("AutoComplete brackets.")]
	public bool AutoCompleteBrackets { get; set; }

	[Browsable(true)]
	[Description("Colors of some service visual markers.")]
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public ServiceColors ServiceColors { get; set; }

	[Browsable(false)]
	public Dictionary<int, int> FoldedBlocks { get; private set; }

	[DefaultValue(typeof(BracketsHighlightStrategy), "Strategy1")]
	[Description("Strategy of search of brackets to highlighting.")]
	public BracketsHighlightStrategy BracketsHighlightStrategy { get; set; }

	[DefaultValue(true)]
	[Description("Automatically shifts secondary wordwrap lines on the shift amount of the first line.")]
	public bool WordWrapAutoIndent { get; set; }

	[DefaultValue(0)]
	[Description("Indent of secondary wordwrap lines (in chars).")]
	public int WordWrapIndent { get; set; }

	[Browsable(false)]
	public MacrosManager MacrosManager => macrosManager;

	[DefaultValue(true)]
	[Description("Allows drag and drop")]
	public override bool AllowDrop
	{
		get
		{
			return base.AllowDrop;
		}
		set
		{
			base.AllowDrop = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public Hints Hints
	{
		get
		{
			return hints;
		}
		set
		{
			hints = value;
		}
	}

	[Browsable(true)]
	[DefaultValue(500)]
	[Description("Delay(ms) of ToolTip.")]
	public int ToolTipDelay
	{
		get
		{
			return timer3.Interval;
		}
		set
		{
			timer3.Interval = value;
		}
	}

	[Browsable(true)]
	[Description("ToolTip component.")]
	public ToolTip ToolTip { get; set; }

	[Browsable(true)]
	[DefaultValue(typeof(Color), "PowderBlue")]
	[Description("Color of bookmarks.")]
	public Color BookmarkColor { get; set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public BaseBookmarks Bookmarks
	{
		get
		{
			return bookmarks;
		}
		set
		{
			bookmarks = value;
		}
	}

	[DefaultValue(false)]
	[Description("Enables virtual spaces.")]
	public bool VirtualSpace { get; set; }

	[DefaultValue(FindEndOfFoldingBlockStrategy.Strategy1)]
	[Description("Strategy of search of end of folding block.")]
	public FindEndOfFoldingBlockStrategy FindEndOfFoldingBlockStrategy { get; set; }

	[DefaultValue(true)]
	[Description("Indicates if tab characters are accepted as input.")]
	public bool AcceptsTab { get; set; }

	[DefaultValue(true)]
	[Description("Indicates if return characters are accepted as input.")]
	public bool AcceptsReturn { get; set; }

	[DefaultValue(true)]
	[Description("Shows or hides the caret")]
	public bool CaretVisible
	{
		get
		{
			return caretVisible;
		}
		set
		{
			caretVisible = value;
			Invalidate();
		}
	}

	[DefaultValue(true)]
	[Description("Enables caret blinking")]
	public bool CaretBlinking { get; set; }

	[DefaultValue(false)]
	public bool ShowCaretWhenInactive { get; set; }

	[DefaultValue(typeof(Color), "Black")]
	[Description("Color of border of text area")]
	public Color TextAreaBorderColor
	{
		get
		{
			return textAreaBorderColor;
		}
		set
		{
			textAreaBorderColor = value;
			Invalidate();
		}
	}

	[DefaultValue(typeof(TextAreaBorderType), "None")]
	[Description("Type of border of text area")]
	public TextAreaBorderType TextAreaBorder
	{
		get
		{
			return textAreaBorder;
		}
		set
		{
			textAreaBorder = value;
			Invalidate();
		}
	}

	[DefaultValue(typeof(Color), "Transparent")]
	[Description("Background color for current line. Set to Color.Transparent to hide current line highlighting")]
	public Color CurrentLineColor
	{
		get
		{
			return currentLineColor;
		}
		set
		{
			currentLineColor = value;
			Invalidate();
		}
	}

	[DefaultValue(typeof(Color), "Transparent")]
	[Description("Background color for highlighting of changed lines. Set to Color.Transparent to hide changed line highlighting")]
	public Color ChangedLineColor
	{
		get
		{
			return changedLineColor;
		}
		set
		{
			changedLineColor = value;
			Invalidate();
		}
	}

	public override Color ForeColor
	{
		get
		{
			return base.ForeColor;
		}
		set
		{
			base.ForeColor = value;
			lines.InitDefaultStyle();
			Invalidate();
		}
	}

	[Browsable(false)]
	public int CharHeight
	{
		get
		{
			return charHeight;
		}
		set
		{
			charHeight = value;
			NeedRecalc();
			OnCharSizeChanged();
		}
	}

	[Description("Interval between lines in pixels")]
	[DefaultValue(0)]
	public int LineInterval
	{
		get
		{
			return lineInterval;
		}
		set
		{
			lineInterval = value;
			SetFont(Font);
			Invalidate();
		}
	}

	[Browsable(false)]
	public int CharWidth { get; set; }

	[DefaultValue(4)]
	[Description("Spaces count for tab")]
	public int TabLength { get; set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool IsChanged
	{
		get
		{
			return isChanged;
		}
		set
		{
			if (!value)
			{
				lines.ClearIsChanged();
			}
			isChanged = value;
		}
	}

	[Browsable(false)]
	public int TextVersion { get; private set; }

	[DefaultValue(false)]
	public bool ReadOnly { get; set; }

	[DefaultValue(true)]
	[Description("Shows line numbers.")]
	public bool ShowLineNumbers
	{
		get
		{
			return showLineNumbers;
		}
		set
		{
			showLineNumbers = value;
			NeedRecalc();
			Invalidate();
		}
	}

	[DefaultValue(false)]
	[Description("Shows vertical lines between folding start line and folding end line.")]
	public bool ShowFoldingLines
	{
		get
		{
			return showFoldingLines;
		}
		set
		{
			showFoldingLines = value;
			Invalidate();
		}
	}

	[Browsable(false)]
	public Rectangle TextAreaRect
	{
		get
		{
			int val = LeftIndent + maxLineLength * CharWidth + Paddings.Left + 1;
			val = Math.Max(base.ClientSize.Width - Paddings.Right, val);
			int val2 = TextHeight + Paddings.Top;
			val2 = Math.Max(base.ClientSize.Height - Paddings.Bottom, val2);
			int top = Math.Max(0, Paddings.Top - 1) - base.VerticalScroll.Value;
			int left = LeftIndent - base.HorizontalScroll.Value - 2 + Math.Max(0, Paddings.Left - 1);
			return Rectangle.FromLTRB(left, top, val - base.HorizontalScroll.Value, val2 - base.VerticalScroll.Value);
		}
	}

	[DefaultValue(typeof(Color), "Teal")]
	[Description("Color of line numbers.")]
	public Color LineNumberColor
	{
		get
		{
			return lineNumberColor;
		}
		set
		{
			lineNumberColor = value;
			Invalidate();
		}
	}

	[DefaultValue(typeof(uint), "1")]
	[Description("Start value of first line number.")]
	public uint LineNumberStartValue
	{
		get
		{
			return lineNumberStartValue;
		}
		set
		{
			lineNumberStartValue = value;
			needRecalc = true;
			Invalidate();
		}
	}

	[DefaultValue(typeof(Color), "WhiteSmoke")]
	[Description("Background color of indent area")]
	public Color IndentBackColor
	{
		get
		{
			return indentBackColor;
		}
		set
		{
			indentBackColor = value;
			Invalidate();
		}
	}

	[DefaultValue(typeof(Color), "Transparent")]
	[Description("Background color of padding area")]
	public Color PaddingBackColor
	{
		get
		{
			return paddingBackColor;
		}
		set
		{
			paddingBackColor = value;
			Invalidate();
		}
	}

	[DefaultValue(typeof(Color), "100;180;180;180")]
	[Description("Color of disabled component")]
	public Color DisabledColor { get; set; }

	[DefaultValue(typeof(Color), "Black")]
	[Description("Color of caret.")]
	public Color CaretColor { get; set; }

	[DefaultValue(false)]
	[Description("Wide caret.")]
	public bool WideCaret { get; set; }

	[DefaultValue(typeof(Color), "Silver")]
	[Description("Color of service lines (folding lines, borders of blocks etc.)")]
	public Color ServiceLinesColor
	{
		get
		{
			return serviceLinesColor;
		}
		set
		{
			serviceLinesColor = value;
			Invalidate();
		}
	}

	[Browsable(true)]
	[Description("Paddings of text area.")]
	public Padding Paddings { get; set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new Padding Padding
	{
		get
		{
			throw new NotImplementedException();
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new bool RightToLeft
	{
		get
		{
			throw new NotImplementedException();
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	[DefaultValue(typeof(Color), "Green")]
	[Description("Color of folding area indicator.")]
	public Color FoldingIndicatorColor
	{
		get
		{
			return foldingIndicatorColor;
		}
		set
		{
			foldingIndicatorColor = value;
			Invalidate();
		}
	}

	[DefaultValue(true)]
	[Description("Enables folding indicator (left vertical line between folding bounds)")]
	public bool HighlightFoldingIndicator
	{
		get
		{
			return highlightFoldingIndicator;
		}
		set
		{
			highlightFoldingIndicator = value;
			Invalidate();
		}
	}

	[Browsable(false)]
	[Description("Left distance to text beginning.")]
	public int LeftIndent { get; private set; }

	[DefaultValue(0)]
	[Description("Width of left service area (in pixels)")]
	public int LeftPadding
	{
		get
		{
			return leftPadding;
		}
		set
		{
			leftPadding = value;
			Invalidate();
		}
	}

	[DefaultValue(0)]
	[Description("This property draws vertical line after defined char position. Set to 0 for disable drawing of vertical line.")]
	public int PreferredLineWidth
	{
		get
		{
			return preferredLineWidth;
		}
		set
		{
			preferredLineWidth = value;
			Invalidate();
		}
	}

	[Browsable(false)]
	public Style[] Styles => lines.Styles;

	[Description("Here you can change hotkeys for FastColoredTextBox.")]
	[Editor(typeof(HotkeysEditor), typeof(UITypeEditor))]
	[DefaultValue("Tab=IndentIncrease, Escape=ClearHints, PgUp=GoPageUp, PgDn=GoPageDown, End=GoEnd, Home=GoHome, Left=GoLeft, Up=GoUp, Right=GoRight, Down=GoDown, Ins=ReplaceMode, Del=DeleteCharRight, F3=FindNext, Shift+Tab=IndentDecrease, Shift+PgUp=GoPageUpWithSelection, Shift+PgDn=GoPageDownWithSelection, Shift+End=GoEndWithSelection, Shift+Home=GoHomeWithSelection, Shift+Left=GoLeftWithSelection, Shift+Up=GoUpWithSelection, Shift+Right=GoRightWithSelection, Shift+Down=GoDownWithSelection, Shift+Ins=Paste, Shift+Del=Cut, Ctrl+Back=ClearWordLeft, Ctrl+Space=AutocompleteMenu, Ctrl+End=GoLastLine, Ctrl+Home=GoFirstLine, Ctrl+Left=GoWordLeft, Ctrl+Up=ScrollUp, Ctrl+Right=GoWordRight, Ctrl+Down=ScrollDown, Ctrl+Ins=Copy, Ctrl+Del=ClearWordRight, Ctrl+0=ZoomNormal, Ctrl+A=SelectAll, Ctrl+B=BookmarkLine, Ctrl+C=Copy, Ctrl+E=MacroExecute, Ctrl+F=FindDialog, Ctrl+G=GoToDialog, Ctrl+H=ReplaceDialog, Ctrl+I=AutoIndentChars, Ctrl+M=MacroRecord, Ctrl+N=GoNextBookmark, Ctrl+R=Redo, Ctrl+U=UpperCase, Ctrl+V=Paste, Ctrl+X=Cut, Ctrl+Z=Undo, Ctrl+Add=ZoomIn, Ctrl+Subtract=ZoomOut, Ctrl+OemMinus=NavigateBackward, Ctrl+Shift+End=GoLastLineWithSelection, Ctrl+Shift+Home=GoFirstLineWithSelection, Ctrl+Shift+Left=GoWordLeftWithSelection, Ctrl+Shift+Right=GoWordRightWithSelection, Ctrl+Shift+B=UnbookmarkLine, Ctrl+Shift+C=CommentSelected, Ctrl+Shift+N=GoPrevBookmark, Ctrl+Shift+U=LowerCase, Ctrl+Shift+OemMinus=NavigateForward, Alt+Back=Undo, Alt+Up=MoveSelectedLinesUp, Alt+Down=MoveSelectedLinesDown, Alt+F=FindChar, Alt+Shift+Left=GoLeft_ColumnSelectionMode, Alt+Shift+Up=GoUp_ColumnSelectionMode, Alt+Shift+Right=GoRight_ColumnSelectionMode, Alt+Shift+Down=GoDown_ColumnSelectionMode")]
	public string Hotkeys
	{
		get
		{
			return HotkeysMapping.ToString();
		}
		set
		{
			HotkeysMapping = HotkeysMapping.Parse(value);
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public HotkeysMapping HotkeysMapping { get; set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public TextStyle DefaultStyle
	{
		get
		{
			return lines.DefaultStyle;
		}
		set
		{
			lines.DefaultStyle = value;
		}
	}

	[Browsable(false)]
	public SelectionStyle SelectionStyle { get; set; }

	[Browsable(false)]
	public TextStyle FoldedBlockStyle { get; set; }

	[Browsable(false)]
	public MarkerStyle BracketsStyle { get; set; }

	[Browsable(false)]
	public MarkerStyle BracketsStyle2 { get; set; }

	[DefaultValue('\0')]
	[Description("Opening bracket for brackets highlighting. Set to '\\x0' for disable brackets highlighting.")]
	public char LeftBracket { get; set; }

	[DefaultValue('\0')]
	[Description("Closing bracket for brackets highlighting. Set to '\\x0' for disable brackets highlighting.")]
	public char RightBracket { get; set; }

	[DefaultValue('\0')]
	[Description("Alternative opening bracket for brackets highlighting. Set to '\\x0' for disable brackets highlighting.")]
	public char LeftBracket2 { get; set; }

	[DefaultValue('\0')]
	[Description("Alternative closing bracket for brackets highlighting. Set to '\\x0' for disable brackets highlighting.")]
	public char RightBracket2 { get; set; }

	[DefaultValue("//")]
	[Description("Comment line prefix.")]
	public string CommentPrefix { get; set; }

	[DefaultValue(typeof(HighlightingRangeType), "ChangedRange")]
	[Description("This property specifies which part of the text will be highlighted as you type.")]
	public HighlightingRangeType HighlightingRangeType { get; set; }

	[Browsable(false)]
	public bool IsReplaceMode
	{
		get
		{
			return isReplaceMode && Selection.IsEmpty && !Selection.ColumnSelectionMode && Selection.Start.iChar < lines[Selection.Start.iLine].Count;
		}
		set
		{
			isReplaceMode = value;
		}
	}

	[Browsable(true)]
	[DefaultValue(false)]
	[Description("Allows text rendering several styles same time.")]
	public bool AllowSeveralTextStyleDrawing { get; set; }

	[Browsable(true)]
	[DefaultValue(true)]
	[Description("Allows to record macros.")]
	public bool AllowMacroRecording
	{
		get
		{
			return macrosManager.AllowMacroRecordingByUser;
		}
		set
		{
			macrosManager.AllowMacroRecordingByUser = value;
		}
	}

	[DefaultValue(true)]
	[Description("Allows auto indent. Inserts spaces before line chars.")]
	public bool AutoIndent { get; set; }

	[DefaultValue(true)]
	[Description("Does autoindenting in existing lines. It works only if AutoIndent is True.")]
	public bool AutoIndentExistingLines { get; set; }

	[Browsable(true)]
	[DefaultValue(100)]
	[Description("Minimal delay(ms) for delayed events (except TextChangedDelayed).")]
	public int DelayedEventsInterval
	{
		get
		{
			return timer.Interval;
		}
		set
		{
			timer.Interval = value;
		}
	}

	[Browsable(true)]
	[DefaultValue(100)]
	[Description("Minimal delay(ms) for TextChangedDelayed event.")]
	public int DelayedTextChangedInterval
	{
		get
		{
			return timer2.Interval;
		}
		set
		{
			timer2.Interval = value;
		}
	}

	[Browsable(true)]
	[DefaultValue(typeof(Language), "Custom")]
	[Description("Language for highlighting by built-in highlighter.")]
	public Language Language
	{
		get
		{
			return language;
		}
		set
		{
			language = value;
			if (SyntaxHighlighter != null)
			{
				SyntaxHighlighter.InitStyleSchema(language);
			}
			Invalidate();
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public SyntaxHighlighter SyntaxHighlighter { get; set; }

	[Browsable(true)]
	[DefaultValue(null)]
	[Editor(typeof(FileNameEditor), typeof(UITypeEditor))]
	[Description("XML file with description of syntax highlighting. This property works only with Language == Language.Custom.")]
	public string DescriptionFile
	{
		get
		{
			return descriptionFile;
		}
		set
		{
			descriptionFile = value;
			Invalidate();
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Range LeftBracketPosition => leftBracketPosition;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Range RightBracketPosition => rightBracketPosition;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Range LeftBracketPosition2 => leftBracketPosition2;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Range RightBracketPosition2 => rightBracketPosition2;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int StartFoldingLine => startFoldingLine;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int EndFoldingLine => endFoldingLine;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public TextSource TextSource
	{
		get
		{
			return lines;
		}
		set
		{
			InitTextSource(value);
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool HasSourceTextBox => SourceTextBox != null;

	[Browsable(true)]
	[DefaultValue(null)]
	[Description("Allows to get text from other FastColoredTextBox.")]
	public FastColoredTextBox SourceTextBox
	{
		get
		{
			return sourceTextBox;
		}
		set
		{
			if (value != sourceTextBox)
			{
				sourceTextBox = value;
				if (sourceTextBox == null)
				{
					InitTextSource(CreateTextSource());
					lines.InsertLine(0, TextSource.CreateLine());
					IsChanged = false;
				}
				else
				{
					InitTextSource(SourceTextBox.TextSource);
					isChanged = false;
				}
				Invalidate();
			}
		}
	}

	[Browsable(false)]
	public Range VisibleRange
	{
		get
		{
			if (visibleRange != null)
			{
				return visibleRange;
			}
			return GetRange(PointToPlace(new Point(LeftIndent, 0)), PointToPlace(new Point(base.ClientSize.Width, base.ClientSize.Height)));
		}
	}

	[Browsable(false)]
	public Range Selection
	{
		get
		{
			return selection;
		}
		set
		{
			if (value != selection)
			{
				selection.BeginUpdate();
				selection.Start = value.Start;
				selection.End = value.End;
				selection.EndUpdate();
				Invalidate();
			}
		}
	}

	[DefaultValue(typeof(Color), "White")]
	[Description("Background color.")]
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

	[Browsable(false)]
	public Brush BackBrush
	{
		get
		{
			return backBrush;
		}
		set
		{
			backBrush = value;
			Invalidate();
		}
	}

	[Browsable(true)]
	[DefaultValue(true)]
	[Description("Scollbars visibility.")]
	public bool ShowScrollBars
	{
		get
		{
			return scrollBars;
		}
		set
		{
			if (value != scrollBars)
			{
				scrollBars = value;
				needRecalc = true;
				Invalidate();
			}
		}
	}

	[Browsable(true)]
	[DefaultValue(true)]
	[Description("Multiline mode.")]
	public bool Multiline
	{
		get
		{
			return multiline;
		}
		set
		{
			if (multiline == value)
			{
				return;
			}
			multiline = value;
			needRecalc = true;
			if (multiline)
			{
				base.AutoScroll = true;
				ShowScrollBars = true;
			}
			else
			{
				base.AutoScroll = false;
				ShowScrollBars = false;
				if (lines.Count > 1)
				{
					lines.RemoveLine(1, lines.Count - 1);
				}
				lines.Manager.ClearHistory();
			}
			Invalidate();
		}
	}

	[Browsable(true)]
	[DefaultValue(false)]
	[Description("WordWrap.")]
	public bool WordWrap
	{
		get
		{
			return wordWrap;
		}
		set
		{
			if (wordWrap != value)
			{
				wordWrap = value;
				if (wordWrap)
				{
					Selection.ColumnSelectionMode = false;
				}
				NeedRecalc(forced: false, wordWrapRecalc: true);
				Invalidate();
			}
		}
	}

	[Browsable(true)]
	[DefaultValue(typeof(WordWrapMode), "WordWrapControlWidth")]
	[Description("WordWrap mode.")]
	public WordWrapMode WordWrapMode
	{
		get
		{
			return wordWrapMode;
		}
		set
		{
			if (wordWrapMode != value)
			{
				wordWrapMode = value;
				NeedRecalc(forced: false, wordWrapRecalc: true);
				Invalidate();
			}
		}
	}

	[DefaultValue(true)]
	[Description("If enabled then line ends included into the selection will be selected too. Then line ends will be shown as selected blank character.")]
	public bool SelectionHighlightingForLineBreaksEnabled
	{
		get
		{
			return selectionHighlightingForLineBreaksEnabled;
		}
		set
		{
			selectionHighlightingForLineBreaksEnabled = value;
			Invalidate();
		}
	}

	[Browsable(false)]
	public FindForm findForm { get; private set; }

	[Browsable(false)]
	public ReplaceForm replaceForm { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override bool AutoScroll
	{
		get
		{
			return base.AutoScroll;
		}
		set
		{
		}
	}

	[Browsable(false)]
	public int LinesCount => lines.Count;

	public Char this[Place place]
	{
		get
		{
			return lines[place.iLine][place.iChar];
		}
		set
		{
			lines[place.iLine][place.iChar] = value;
		}
	}

	public Line this[int iLine] => lines[iLine];

	[Browsable(true)]
	[Localizable(true)]
	[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[SettingsBindable(true)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	[Description("Text of the control.")]
	[Bindable(true)]
	public override string Text
	{
		get
		{
			if (LinesCount == 0)
			{
				return "";
			}
			Range range = new Range(this);
			range.SelectAll();
			return range.Text;
		}
		set
		{
			if (value == Text && value != "")
			{
				return;
			}
			SetAsCurrentTB();
			Selection.ColumnSelectionMode = false;
			Selection.BeginUpdate();
			try
			{
				Selection.SelectAll();
				InsertText(value);
				GoHome();
			}
			finally
			{
				Selection.EndUpdate();
			}
		}
	}

	public int TextLength
	{
		get
		{
			if (LinesCount == 0)
			{
				return 0;
			}
			Range range = new Range(this);
			range.SelectAll();
			return range.Length;
		}
	}

	[Browsable(false)]
	public IList<string> Lines => lines.GetLines();

	[Browsable(false)]
	public string Html
	{
		get
		{
			ExportToHTML exportToHTML = new ExportToHTML();
			exportToHTML.UseNbsp = false;
			exportToHTML.UseStyleTag = false;
			exportToHTML.UseBr = false;
			return "<pre>" + exportToHTML.GetHtml(this) + "</pre>";
		}
	}

	[Browsable(false)]
	public string Rtf
	{
		get
		{
			ExportToRTF exportToRTF = new ExportToRTF();
			return exportToRTF.GetRtf(this);
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string SelectedText
	{
		get
		{
			return Selection.Text;
		}
		set
		{
			InsertText(value);
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int SelectionStart
	{
		get
		{
			return Math.Min(PlaceToPosition(Selection.Start), PlaceToPosition(Selection.End));
		}
		set
		{
			Selection.Start = PositionToPlace(value);
		}
	}

	[Browsable(false)]
	[DefaultValue(0)]
	public int SelectionLength
	{
		get
		{
			return Selection.Length;
		}
		set
		{
			if (value > 0)
			{
				Selection.End = PositionToPlace(SelectionStart + value);
			}
		}
	}

	[DefaultValue(typeof(Font), "Courier New, 9.75")]
	public override Font Font
	{
		get
		{
			return BaseFont;
		}
		set
		{
			originalFont = (Font)value.Clone();
			SetFont(value);
		}
	}

	[DefaultValue(typeof(Font), "Courier New, 9.75")]
	private Font BaseFont
	{
		get
		{
			return baseFont;
		}
		set
		{
			baseFont = value;
		}
	}

	public new Size AutoScrollMinSize
	{
		get
		{
			if (scrollBars)
			{
				return base.AutoScrollMinSize;
			}
			return localAutoScrollMinSize;
		}
		set
		{
			if (scrollBars)
			{
				if (!base.AutoScroll)
				{
					base.AutoScroll = true;
				}
				Size autoScrollMinSize = value;
				if (WordWrap && WordWrapMode != WordWrapMode.Custom)
				{
					int maxLineWordWrapedWidth = GetMaxLineWordWrapedWidth();
					autoScrollMinSize = new Size(Math.Min(autoScrollMinSize.Width, maxLineWordWrapedWidth), autoScrollMinSize.Height);
				}
				base.AutoScrollMinSize = autoScrollMinSize;
			}
			else
			{
				if (base.AutoScroll)
				{
					base.AutoScroll = false;
				}
				base.AutoScrollMinSize = new Size(0, 0);
				base.VerticalScroll.Visible = false;
				base.HorizontalScroll.Visible = false;
				base.VerticalScroll.Maximum = Math.Max(0, value.Height - base.ClientSize.Height);
				base.HorizontalScroll.Maximum = Math.Max(0, value.Width - base.ClientSize.Width);
				localAutoScrollMinSize = value;
			}
		}
	}

	[Browsable(false)]
	public bool ImeAllowed => base.ImeMode != ImeMode.Disable && base.ImeMode != ImeMode.Off && base.ImeMode != ImeMode.NoControl;

	[Browsable(false)]
	public bool UndoEnabled => lines.Manager.UndoEnabled;

	[Browsable(false)]
	public bool RedoEnabled => lines.Manager.RedoEnabled;

	private int LeftIndentLine => LeftIndent - 4 - 3;

	[Browsable(false)]
	public Range Range => new Range(this, new Place(0, 0), new Place(lines[lines.Count - 1].Count, lines.Count - 1));

	[DefaultValue(typeof(Color), "Blue")]
	[Description("Color of selected area.")]
	public virtual Color SelectionColor
	{
		get
		{
			return selectionColor;
		}
		set
		{
			selectionColor = value;
			if (selectionColor.A == byte.MaxValue)
			{
				selectionColor = Color.FromArgb(60, selectionColor);
			}
			SelectionStyle = new SelectionStyle(new SolidBrush(selectionColor));
			Invalidate();
		}
	}

	public override Cursor Cursor
	{
		get
		{
			return base.Cursor;
		}
		set
		{
			defaultCursor = value;
			base.Cursor = value;
		}
	}

	[DefaultValue(1)]
	[Description("Reserved space for line number characters. If smaller than needed (e. g. line count >= 10 and this value set to 1) this value will have no impact. If you want to reserve space, e. g. for line numbers >= 10 or >= 100, than you can set this value to 2 or 3 or higher.")]
	public int ReservedCountOfLineNumberChars
	{
		get
		{
			return reservedCountOfLineNumberChars;
		}
		set
		{
			reservedCountOfLineNumberChars = value;
			NeedRecalc();
			Invalidate();
		}
	}

	[Description("Enables AutoIndentChars mode")]
	[DefaultValue(true)]
	public bool AutoIndentChars { get; set; }

	[Description("Regex patterns for AutoIndentChars (one regex per line)")]
	[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[DefaultValue("^\\s*[\\w\\.]+\\s*(?<range>=)\\s*(?<range>[^;]+);")]
	public string AutoIndentCharsPatterns { get; set; }

	[Browsable(false)]
	public int Zoom
	{
		get
		{
			return zoom;
		}
		set
		{
			zoom = value;
			DoZoom((float)zoom / 100f);
			OnZoomChanged();
		}
	}

	private bool IsDragDrop { get; set; }

	[Browsable(true)]
	[Description("Occurs when mouse is moving over text and tooltip is needed.")]
	public event EventHandler<ToolTipNeededEventArgs> ToolTipNeeded;

	[Browsable(true)]
	[Description("It occurs if user click on the hint.")]
	public event EventHandler<HintClickEventArgs> HintClick;

	[Browsable(true)]
	[Description("It occurs after insert, delete, clear, undo and redo operations.")]
	public new event EventHandler<TextChangedEventArgs> TextChanged;

	[Browsable(false)]
	internal event EventHandler BindingTextChanged;

	[Description("Occurs when user paste text from clipboard")]
	public event EventHandler<TextChangingEventArgs> Pasting;

	[Browsable(true)]
	[Description("It occurs before insert, delete, clear, undo and redo operations.")]
	public event EventHandler<TextChangingEventArgs> TextChanging;

	[Browsable(true)]
	[Description("It occurs after changing of selection.")]
	public event EventHandler SelectionChanged;

	[Browsable(true)]
	[Description("It occurs after changing of visible range.")]
	public event EventHandler VisibleRangeChanged;

	[Browsable(true)]
	[Description("It occurs after insert, delete, clear, undo and redo operations. This event occurs with a delay relative to TextChanged, and fires only once.")]
	public event EventHandler<TextChangedEventArgs> TextChangedDelayed;

	[Browsable(true)]
	[Description("It occurs after changing of selection. This event occurs with a delay relative to SelectionChanged, and fires only once.")]
	public event EventHandler SelectionChangedDelayed;

	[Browsable(true)]
	[Description("It occurs after changing of visible range. This event occurs with a delay relative to VisibleRangeChanged, and fires only once.")]
	public event EventHandler VisibleRangeChangedDelayed;

	[Browsable(true)]
	[Description("It occurs when user click on VisualMarker.")]
	public event EventHandler<VisualMarkerEventArgs> VisualMarkerClick;

	[Browsable(true)]
	[Description("It occurs when visible char is enetering (alphabetic, digit, punctuation, DEL, BACKSPACE).")]
	public event KeyPressEventHandler KeyPressing;

	[Browsable(true)]
	[Description("It occurs when visible char is enetered (alphabetic, digit, punctuation, DEL, BACKSPACE).")]
	public event KeyPressEventHandler KeyPressed;

	[Browsable(true)]
	[Description("It occurs when calculates AutoIndent for new line.")]
	public event EventHandler<AutoIndentEventArgs> AutoIndentNeeded;

	[Browsable(true)]
	[Description("It occurs when line background is painting.")]
	public event EventHandler<PaintLineEventArgs> PaintLine;

	[Browsable(true)]
	[Description("Occurs when line was inserted/added.")]
	public event EventHandler<LineInsertedEventArgs> LineInserted;

	[Browsable(true)]
	[Description("Occurs when line was removed.")]
	public event EventHandler<LineRemovedEventArgs> LineRemoved;

	[Browsable(true)]
	[Description("Occurs when current highlighted folding area is changed.")]
	public event EventHandler<EventArgs> FoldingHighlightChanged;

	[Browsable(true)]
	[Description("Occurs when undo/redo stack is changed.")]
	public event EventHandler<EventArgs> UndoRedoStateChanged;

	[Browsable(true)]
	[Description("Occurs when component was zoomed.")]
	public event EventHandler ZoomChanged;

	[Browsable(true)]
	[Description("Occurs when user pressed key, that specified as CustomAction.")]
	public event EventHandler<CustomActionEventArgs> CustomAction;

	[Browsable(true)]
	[Description("Occurs when scroolbars are updated.")]
	public event EventHandler ScrollbarsUpdated;

	[Browsable(true)]
	[Description("Occurs when custom wordwrap is needed.")]
	public event EventHandler<WordWrapNeededEventArgs> WordWrapNeeded;

	public FastColoredTextBox()
	{
		TypeDescriptionProvider provider = TypeDescriptor.GetProvider(GetType());
		object value = provider.GetType().GetField("Provider", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(provider);
		if (value.GetType() != typeof(FCTBDescriptionProvider))
		{
			TypeDescriptor.AddProvider(new FCTBDescriptionProvider(GetType()), GetType());
		}
		SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
		Font = new Font(FontFamily.GenericMonospace, 9.75f);
		InitTextSource(CreateTextSource());
		if (lines.Count == 0)
		{
			lines.InsertLine(0, lines.CreateLine());
		}
		selection = new Range(this)
		{
			Start = new Place(0, 0)
		};
		Cursor = Cursors.IBeam;
		BackColor = Color.White;
		LineNumberColor = Color.Teal;
		IndentBackColor = Color.WhiteSmoke;
		ServiceLinesColor = Color.Silver;
		FoldingIndicatorColor = Color.Green;
		CurrentLineColor = Color.Transparent;
		ChangedLineColor = Color.Transparent;
		HighlightFoldingIndicator = true;
		ShowLineNumbers = true;
		TabLength = 4;
		FoldedBlockStyle = new FoldedBlockStyle(Brushes.Gray, null, FontStyle.Regular);
		SelectionColor = Color.Blue;
		BracketsStyle = new MarkerStyle(new SolidBrush(Color.FromArgb(80, Color.Lime)));
		BracketsStyle2 = new MarkerStyle(new SolidBrush(Color.FromArgb(60, Color.Red)));
		DelayedEventsInterval = 100;
		DelayedTextChangedInterval = 100;
		AllowSeveralTextStyleDrawing = false;
		LeftBracket = '\0';
		RightBracket = '\0';
		LeftBracket2 = '\0';
		RightBracket2 = '\0';
		SyntaxHighlighter = new SyntaxHighlighter(this);
		language = Language.Custom;
		PreferredLineWidth = 0;
		needRecalc = true;
		lastNavigatedDateTime = DateTime.Now;
		AutoIndent = true;
		AutoIndentExistingLines = true;
		CommentPrefix = "//";
		lineNumberStartValue = 1u;
		multiline = true;
		scrollBars = true;
		AcceptsTab = true;
		AcceptsReturn = true;
		caretVisible = true;
		CaretColor = Color.Black;
		WideCaret = false;
		Paddings = new Padding(0, 0, 0, 0);
		PaddingBackColor = Color.Transparent;
		DisabledColor = Color.FromArgb(100, 180, 180, 180);
		needRecalcFoldingLines = true;
		AllowDrop = true;
		FindEndOfFoldingBlockStrategy = FindEndOfFoldingBlockStrategy.Strategy1;
		VirtualSpace = false;
		bookmarks = new Bookmarks(this);
		BookmarkColor = Color.PowderBlue;
		ToolTip = new ToolTip();
		timer3.Interval = 500;
		hints = new Hints(this);
		SelectionHighlightingForLineBreaksEnabled = true;
		textAreaBorder = TextAreaBorderType.None;
		textAreaBorderColor = Color.Black;
		macrosManager = new MacrosManager(this);
		HotkeysMapping = new HotkeysMapping();
		HotkeysMapping.InitDefault();
		WordWrapAutoIndent = true;
		FoldedBlocks = new Dictionary<int, int>();
		AutoCompleteBrackets = false;
		AutoIndentCharsPatterns = "^\\s*[\\w\\.]+\\s*(?<range>=)\\s*(?<range>[^;]+);";
		AutoIndentChars = true;
		CaretBlinking = true;
		ServiceColors = new ServiceColors();
		base.AutoScroll = true;
		timer.Tick += timer_Tick;
		timer2.Tick += timer2_Tick;
		timer3.Tick += timer3_Tick;
		middleClickScrollingTimer.Tick += middleClickScrollingTimer_Tick;
	}

	private void SetFont(Font newFont)
	{
		BaseFont = newFont;
		SizeF charSize = GetCharSize(BaseFont, 'M');
		SizeF charSize2 = GetCharSize(BaseFont, '.');
		if (charSize != charSize2)
		{
			BaseFont = new Font("Courier New", BaseFont.SizeInPoints, FontStyle.Regular, GraphicsUnit.Point);
		}
		SizeF charSize3 = GetCharSize(BaseFont, 'M');
		CharWidth = (int)Math.Round(charSize3.Width * 1f) - 1;
		CharHeight = lineInterval + (int)Math.Round(charSize3.Height * 1f) - 1;
		NeedRecalc(forced: false, wordWrap);
		Invalidate();
	}

	public void ClearHints()
	{
		if (Hints != null)
		{
			Hints.Clear();
		}
	}

	public virtual Hint AddHint(Range range, Control innerControl, bool scrollToHint, bool inline, bool dock)
	{
		Hint hint = new Hint(range, innerControl, inline, dock);
		Hints.Add(hint);
		if (scrollToHint)
		{
			hint.DoVisible();
		}
		return hint;
	}

	public Hint AddHint(Range range, Control innerControl)
	{
		return AddHint(range, innerControl, scrollToHint: true, inline: true, dock: true);
	}

	public virtual Hint AddHint(Range range, string text, bool scrollToHint, bool inline, bool dock)
	{
		Hint hint = new Hint(range, text, inline, dock);
		Hints.Add(hint);
		if (scrollToHint)
		{
			hint.DoVisible();
		}
		return hint;
	}

	public Hint AddHint(Range range, string text)
	{
		return AddHint(range, text, scrollToHint: true, inline: true, dock: true);
	}

	public virtual void OnHintClick(Hint hint)
	{
		if (this.HintClick != null)
		{
			this.HintClick(this, new HintClickEventArgs(hint));
		}
	}

	private void timer3_Tick(object sender, EventArgs e)
	{
		timer3.Stop();
		OnToolTip();
	}

	protected virtual void OnToolTip()
	{
		if (ToolTip == null || this.ToolTipNeeded == null)
		{
			return;
		}
		Place place = PointToPlace(lastMouseCoord);
		Point point = PlaceToPoint(place);
		if (Math.Abs(point.X - lastMouseCoord.X) <= CharWidth * 2 && Math.Abs(point.Y - lastMouseCoord.Y) <= CharHeight * 2)
		{
			Range range = new Range(this, place, place);
			string hoveredWord = range.GetFragment("[a-zA-Z]").Text;
			ToolTipNeededEventArgs e = new ToolTipNeededEventArgs(place, hoveredWord);
			this.ToolTipNeeded(this, e);
			if (e.ToolTipText != null)
			{
				ToolTip.ToolTipTitle = e.ToolTipTitle;
				ToolTip.ToolTipIcon = e.ToolTipIcon;
				ToolTip.Show(e.ToolTipText, this, new Point(lastMouseCoord.X, lastMouseCoord.Y + CharHeight));
			}
		}
	}

	public virtual void OnVisibleRangeChanged()
	{
		needRecalcFoldingLines = true;
		needRiseVisibleRangeChangedDelayed = true;
		ResetTimer(timer);
		if (this.VisibleRangeChanged != null)
		{
			this.VisibleRangeChanged(this, new EventArgs());
		}
	}

	public new void Invalidate()
	{
		if (base.InvokeRequired)
		{
			BeginInvoke(new MethodInvoker(Invalidate));
		}
		else
		{
			base.Invalidate();
		}
	}

	protected virtual void OnCharSizeChanged()
	{
		base.VerticalScroll.SmallChange = charHeight;
		base.VerticalScroll.LargeChange = 10 * charHeight;
		base.HorizontalScroll.SmallChange = CharWidth;
	}

	public List<Style> GetStylesOfChar(Place place)
	{
		List<Style> list = new List<Style>();
		if (place.iLine < LinesCount && place.iChar < this[place.iLine].Count)
		{
			ushort style = (ushort)this[place].style;
			for (int i = 0; i < 16; i++)
			{
				if ((style & (1 << i)) != 0)
				{
					list.Add(Styles[i]);
				}
			}
		}
		return list;
	}

	protected virtual TextSource CreateTextSource()
	{
		return new TextSource(this);
	}

	private void SetAsCurrentTB()
	{
		TextSource.CurrentTB = this;
	}

	protected virtual void InitTextSource(TextSource ts)
	{
		if (lines != null)
		{
			lines.LineInserted -= ts_LineInserted;
			lines.LineRemoved -= ts_LineRemoved;
			lines.TextChanged -= ts_TextChanged;
			lines.RecalcNeeded -= ts_RecalcNeeded;
			lines.RecalcWordWrap -= ts_RecalcWordWrap;
			lines.TextChanging -= ts_TextChanging;
			lines.Dispose();
		}
		LineInfos.Clear();
		ClearHints();
		if (Bookmarks != null)
		{
			Bookmarks.Clear();
		}
		lines = ts;
		if (ts != null)
		{
			ts.LineInserted += ts_LineInserted;
			ts.LineRemoved += ts_LineRemoved;
			ts.TextChanged += ts_TextChanged;
			ts.RecalcNeeded += ts_RecalcNeeded;
			ts.RecalcWordWrap += ts_RecalcWordWrap;
			ts.TextChanging += ts_TextChanging;
			while (LineInfos.Count < ts.Count)
			{
				LineInfos.Add(new LineInfo(-1));
			}
		}
		isChanged = false;
		needRecalc = true;
	}

	private void ts_RecalcWordWrap(object sender, TextSource.TextChangedEventArgs e)
	{
		RecalcWordWrap(e.iFromLine, e.iToLine);
	}

	private void ts_TextChanging(object sender, TextChangingEventArgs e)
	{
		if (TextSource.CurrentTB == this)
		{
			string insertingText = e.InsertingText;
			OnTextChanging(ref insertingText);
			e.InsertingText = insertingText;
		}
	}

	private void ts_RecalcNeeded(object sender, TextSource.TextChangedEventArgs e)
	{
		if (e.iFromLine == e.iToLine && !WordWrap && lines.Count > 100000)
		{
			RecalcScrollByOneLine(e.iFromLine);
		}
		else
		{
			NeedRecalc(forced: false, WordWrap);
		}
	}

	public void NeedRecalc()
	{
		NeedRecalc(forced: false);
	}

	public void NeedRecalc(bool forced)
	{
		NeedRecalc(forced, wordWrapRecalc: false);
	}

	public void NeedRecalc(bool forced, bool wordWrapRecalc)
	{
		needRecalc = true;
		if (wordWrapRecalc)
		{
			needRecalcWordWrapInterval = new Point(0, LinesCount - 1);
			needRecalcWordWrap = true;
		}
		if (forced)
		{
			Recalc();
		}
	}

	private void ts_TextChanged(object sender, TextSource.TextChangedEventArgs e)
	{
		if (e.iFromLine == e.iToLine && !WordWrap)
		{
			RecalcScrollByOneLine(e.iFromLine);
		}
		else
		{
			needRecalc = true;
		}
		Invalidate();
		if (TextSource.CurrentTB == this)
		{
			OnTextChanged(e.iFromLine, e.iToLine);
		}
	}

	private void ts_LineRemoved(object sender, LineRemovedEventArgs e)
	{
		LineInfos.RemoveRange(e.Index, e.Count);
		OnLineRemoved(e.Index, e.Count, e.RemovedLineUniqueIds);
	}

	private void ts_LineInserted(object sender, LineInsertedEventArgs e)
	{
		VisibleState visibleState = VisibleState.Visible;
		if (e.Index >= 0 && e.Index < LineInfos.Count && LineInfos[e.Index].VisibleState == VisibleState.Hidden)
		{
			visibleState = VisibleState.Hidden;
		}
		if (e.Count > 100000)
		{
			LineInfos.Capacity = LineInfos.Count + e.Count + 1000;
		}
		LineInfo[] array = new LineInfo[e.Count];
		for (int i = 0; i < e.Count; i++)
		{
			array[i].startY = -1;
			array[i].VisibleState = visibleState;
		}
		LineInfos.InsertRange(e.Index, array);
		if (e.Count > 1000000)
		{
			GC.Collect();
		}
		OnLineInserted(e.Index, e.Count);
	}

	public bool NavigateForward()
	{
		DateTime dateTime = DateTime.Now;
		int num = -1;
		for (int i = 0; i < LinesCount; i++)
		{
			if (lines.IsLineLoaded(i) && lines[i].LastVisit > lastNavigatedDateTime && lines[i].LastVisit < dateTime)
			{
				dateTime = lines[i].LastVisit;
				num = i;
			}
		}
		if (num >= 0)
		{
			Navigate(num);
			return true;
		}
		return false;
	}

	public bool NavigateBackward()
	{
		DateTime dateTime = default(DateTime);
		int num = -1;
		for (int i = 0; i < LinesCount; i++)
		{
			if (lines.IsLineLoaded(i) && lines[i].LastVisit < lastNavigatedDateTime && lines[i].LastVisit > dateTime)
			{
				dateTime = lines[i].LastVisit;
				num = i;
			}
		}
		if (num >= 0)
		{
			Navigate(num);
			return true;
		}
		return false;
	}

	public void Navigate(int iLine)
	{
		if (iLine < LinesCount)
		{
			lastNavigatedDateTime = lines[iLine].LastVisit;
			Selection.Start = new Place(0, iLine);
			DoSelectionVisible();
		}
	}

	protected override void OnLoad(EventArgs e)
	{
		base.OnLoad(e);
		m_hImc = ImmGetContext(base.Handle);
	}

	private void timer2_Tick(object sender, EventArgs e)
	{
		timer2.Enabled = false;
		if (needRiseTextChangedDelayed)
		{
			needRiseTextChangedDelayed = false;
			if (delayedTextChangedRange != null)
			{
				delayedTextChangedRange = Range.GetIntersectionWith(delayedTextChangedRange);
				delayedTextChangedRange.Expand();
				OnTextChangedDelayed(delayedTextChangedRange);
				delayedTextChangedRange = null;
			}
		}
	}

	public void AddVisualMarker(VisualMarker marker)
	{
		visibleMarkers.Add(marker);
	}

	private void timer_Tick(object sender, EventArgs e)
	{
		timer.Enabled = false;
		if (needRiseSelectionChangedDelayed)
		{
			needRiseSelectionChangedDelayed = false;
			OnSelectionChangedDelayed();
		}
		if (needRiseVisibleRangeChangedDelayed)
		{
			needRiseVisibleRangeChangedDelayed = false;
			OnVisibleRangeChangedDelayed();
		}
	}

	public virtual void OnTextChangedDelayed(Range changedRange)
	{
		if (this.TextChangedDelayed != null)
		{
			this.TextChangedDelayed(this, new TextChangedEventArgs(changedRange));
		}
	}

	public virtual void OnSelectionChangedDelayed()
	{
		RecalcScrollByOneLine(Selection.Start.iLine);
		ClearBracketsPositions();
		if (LeftBracket != 0 && RightBracket != 0)
		{
			HighlightBrackets(LeftBracket, RightBracket, ref leftBracketPosition, ref rightBracketPosition);
		}
		if (LeftBracket2 != 0 && RightBracket2 != 0)
		{
			HighlightBrackets(LeftBracket2, RightBracket2, ref leftBracketPosition2, ref rightBracketPosition2);
		}
		if (Selection.IsEmpty && Selection.Start.iLine < LinesCount && lastNavigatedDateTime != lines[Selection.Start.iLine].LastVisit)
		{
			lines[Selection.Start.iLine].LastVisit = DateTime.Now;
			lastNavigatedDateTime = lines[Selection.Start.iLine].LastVisit;
		}
		if (this.SelectionChangedDelayed != null)
		{
			this.SelectionChangedDelayed(this, new EventArgs());
		}
	}

	public virtual void OnVisibleRangeChangedDelayed()
	{
		if (this.VisibleRangeChangedDelayed != null)
		{
			this.VisibleRangeChangedDelayed(this, new EventArgs());
		}
	}

	private void ResetTimer(System.Windows.Forms.Timer timer)
	{
		if (base.InvokeRequired)
		{
			BeginInvoke((MethodInvoker)delegate
			{
				ResetTimer(timer);
			});
			return;
		}
		timer.Stop();
		if (base.IsHandleCreated)
		{
			timer.Start();
		}
		else
		{
			timersToReset[timer] = timer;
		}
	}

	protected override void OnHandleCreated(EventArgs e)
	{
		base.OnHandleCreated(e);
		foreach (System.Windows.Forms.Timer item in new List<System.Windows.Forms.Timer>(timersToReset.Keys))
		{
			ResetTimer(item);
		}
		timersToReset.Clear();
		OnScrollbarsUpdated();
	}

	public int AddStyle(Style style)
	{
		if (style == null)
		{
			return -1;
		}
		int styleIndex = GetStyleIndex(style);
		if (styleIndex >= 0)
		{
			return styleIndex;
		}
		styleIndex = CheckStylesBufferSize();
		Styles[styleIndex] = style;
		return styleIndex;
	}

	public int CheckStylesBufferSize()
	{
		int num = Styles.Length - 1;
		while (num >= 0 && Styles[num] == null)
		{
			num--;
		}
		num++;
		if (num >= Styles.Length)
		{
			throw new Exception("Maximum count of Styles is exceeded.");
		}
		return num;
	}

	public virtual void ShowFindDialog()
	{
		ShowFindDialog(null);
	}

	public virtual void ShowFindDialog(string findText)
	{
		if (findForm == null)
		{
			findForm = new FindForm(this);
		}
		if (findText != null)
		{
			findForm.tbFind.Text = findText;
		}
		else if (!Selection.IsEmpty && Selection.Start.iLine == Selection.End.iLine)
		{
			findForm.tbFind.Text = Selection.Text;
		}
		findForm.tbFind.SelectAll();
		findForm.Show();
		findForm.Focus();
	}

	public virtual void ShowReplaceDialog()
	{
		ShowReplaceDialog(null);
	}

	public virtual void ShowReplaceDialog(string findText)
	{
		if (!ReadOnly)
		{
			if (replaceForm == null)
			{
				replaceForm = new ReplaceForm(this);
			}
			if (findText != null)
			{
				replaceForm.tbFind.Text = findText;
			}
			else if (!Selection.IsEmpty && Selection.Start.iLine == Selection.End.iLine)
			{
				replaceForm.tbFind.Text = Selection.Text;
			}
			replaceForm.tbFind.SelectAll();
			replaceForm.Show();
			replaceForm.Focus();
		}
	}

	public int GetLineLength(int iLine)
	{
		if (iLine < 0 || iLine >= lines.Count)
		{
			throw new ArgumentOutOfRangeException("Line index out of range");
		}
		return lines[iLine].Count;
	}

	public Range GetLine(int iLine)
	{
		if (iLine < 0 || iLine >= lines.Count)
		{
			throw new ArgumentOutOfRangeException("Line index out of range");
		}
		Range range = new Range(this);
		range.Start = new Place(0, iLine);
		range.End = new Place(lines[iLine].Count, iLine);
		return range;
	}

	public virtual void Copy()
	{
		if (Selection.IsEmpty)
		{
			Selection.Expand();
		}
		if (!Selection.IsEmpty)
		{
			DataObject data = new DataObject();
			OnCreateClipboardData(data);
			Thread thread = new Thread((ThreadStart)delegate
			{
				SetClipboard(data);
			});
			thread.SetApartmentState(ApartmentState.STA);
			thread.Start();
			thread.Join();
		}
	}

	protected virtual void OnCreateClipboardData(DataObject data)
	{
		ExportToHTML exportToHTML = new ExportToHTML();
		exportToHTML.UseBr = false;
		exportToHTML.UseNbsp = false;
		exportToHTML.UseStyleTag = true;
		string html = "<pre>" + exportToHTML.GetHtml(Selection.Clone()) + "</pre>";
		data.SetData(DataFormats.UnicodeText, autoConvert: true, Selection.Text);
		data.SetData(DataFormats.Html, PrepareHtmlForClipboard(html));
		data.SetData(DataFormats.Rtf, new ExportToRTF().GetRtf(Selection.Clone()));
	}

	[DllImport("user32.dll")]
	private static extern IntPtr GetOpenClipboardWindow();

	[DllImport("user32.dll")]
	private static extern IntPtr CloseClipboard();

	protected void SetClipboard(DataObject data)
	{
		try
		{
			CloseClipboard();
			Clipboard.SetDataObject(data, copy: true, 5, 100);
		}
		catch (ExternalException)
		{
		}
	}

	public static MemoryStream PrepareHtmlForClipboard(string html)
	{
		Encoding uTF = Encoding.UTF8;
		string format = "Version:0.9\r\nStartHTML:{0:000000}\r\nEndHTML:{1:000000}\r\nStartFragment:{2:000000}\r\nEndFragment:{3:000000}\r\n";
		string text = "<html>\r\n<head>\r\n<meta http-equiv=\"Content-Type\" content=\"text/html; charset=" + uTF.WebName + "\">\r\n<title>HTML clipboard</title>\r\n</head>\r\n<body>\r\n<!--StartFragment-->";
		string text2 = "<!--EndFragment-->\r\n</body>\r\n</html>\r\n";
		string s = string.Format(format, 0, 0, 0, 0);
		int byteCount = uTF.GetByteCount(s);
		int byteCount2 = uTF.GetByteCount(text);
		int byteCount3 = uTF.GetByteCount(html);
		int byteCount4 = uTF.GetByteCount(text2);
		string s2 = string.Format(format, byteCount, byteCount + byteCount2 + byteCount3 + byteCount4, byteCount + byteCount2, byteCount + byteCount2 + byteCount3) + text + html + text2;
		return new MemoryStream(uTF.GetBytes(s2));
	}

	public virtual void Cut()
	{
		if (!Selection.IsEmpty)
		{
			Copy();
			ClearSelected();
			return;
		}
		if (LinesCount == 1)
		{
			Selection.SelectAll();
			Copy();
			ClearSelected();
			return;
		}
		DataObject data = new DataObject();
		OnCreateClipboardData(data);
		Thread thread = new Thread((ThreadStart)delegate
		{
			SetClipboard(data);
		});
		thread.SetApartmentState(ApartmentState.STA);
		thread.Start();
		thread.Join();
		if (Selection.Start.iLine >= 0 && Selection.Start.iLine < LinesCount)
		{
			int iLine = Selection.Start.iLine;
			RemoveLines(new List<int> { iLine });
			Selection.Start = new Place(0, Math.Max(0, Math.Min(iLine, LinesCount - 1)));
		}
	}

	public virtual void Paste()
	{
		string text = null;
		Thread thread = new Thread((ThreadStart)delegate
		{
			if (Clipboard.ContainsText())
			{
				text = Clipboard.GetText();
			}
		});
		thread.SetApartmentState(ApartmentState.STA);
		thread.Start();
		thread.Join();
		if (this.Pasting != null)
		{
			TextChangingEventArgs e = new TextChangingEventArgs
			{
				Cancel = false,
				InsertingText = text
			};
			this.Pasting(this, e);
			if (e.Cancel)
			{
				text = string.Empty;
			}
			else
			{
				text = e.InsertingText;
			}
		}
		if (!string.IsNullOrEmpty(text))
		{
			InsertText(text);
		}
	}

	public void SelectAll()
	{
		Selection.SelectAll();
	}

	public void GoEnd()
	{
		if (lines.Count > 0)
		{
			Selection.Start = new Place(lines[lines.Count - 1].Count, lines.Count - 1);
		}
		else
		{
			Selection.Start = new Place(0, 0);
		}
		DoCaretVisible();
	}

	public void GoHome()
	{
		Selection.Start = new Place(0, 0);
		DoCaretVisible();
	}

	public virtual void Clear()
	{
		Selection.BeginUpdate();
		try
		{
			Selection.SelectAll();
			ClearSelected();
			lines.Manager.ClearHistory();
			Invalidate();
		}
		finally
		{
			Selection.EndUpdate();
		}
	}

	public void ClearStylesBuffer()
	{
		for (int i = 0; i < Styles.Length; i++)
		{
			Styles[i] = null;
		}
	}

	public void ClearStyle(StyleIndex styleIndex)
	{
		foreach (Line line in lines)
		{
			line.ClearStyle(styleIndex);
		}
		for (int i = 0; i < LineInfos.Count; i++)
		{
			SetVisibleState(i, VisibleState.Visible);
		}
		Invalidate();
	}

	public void ClearUndo()
	{
		lines.Manager.ClearHistory();
	}

	public virtual void InsertText(string text)
	{
		InsertText(text, jumpToCaret: true);
	}

	public virtual void InsertText(string text, bool jumpToCaret)
	{
		if (text == null)
		{
			return;
		}
		if (text == "\r")
		{
			text = "\n";
		}
		lines.Manager.BeginAutoUndoCommands();
		try
		{
			if (!Selection.IsEmpty)
			{
				lines.Manager.ExecuteCommand(new ClearSelectedCommand(TextSource));
			}
			if (TextSource.Count > 0 && Selection.IsEmpty && Selection.Start.iChar > GetLineLength(Selection.Start.iLine) && VirtualSpace)
			{
				InsertVirtualSpaces();
			}
			lines.Manager.ExecuteCommand(new InsertTextCommand(TextSource, text));
			if (updating <= 0 && jumpToCaret)
			{
				DoCaretVisible();
			}
		}
		finally
		{
			lines.Manager.EndAutoUndoCommands();
		}
		Invalidate();
	}

	public virtual Range InsertText(string text, Style style)
	{
		return InsertText(text, style, jumpToCaret: true);
	}

	public virtual Range InsertText(string text, Style style, bool jumpToCaret)
	{
		if (text == null)
		{
			return null;
		}
		Place start = ((Selection.Start > Selection.End) ? Selection.End : Selection.Start);
		InsertText(text, jumpToCaret);
		Range range = new Range(this, start, Selection.Start)
		{
			ColumnSelectionMode = Selection.ColumnSelectionMode
		};
		range = range.GetIntersectionWith(Range);
		range.SetStyle(style);
		return range;
	}

	public virtual Range InsertTextAndRestoreSelection(Range replaceRange, string text, Style style)
	{
		if (text == null)
		{
			return null;
		}
		int num = PlaceToPosition(Selection.Start);
		int num2 = PlaceToPosition(Selection.End);
		int length = replaceRange.Text.Length;
		int num3 = PlaceToPosition(replaceRange.Start);
		Selection.BeginUpdate();
		Selection = replaceRange;
		Range range = InsertText(text, style);
		length = range.Text.Length - length;
		Selection.Start = PositionToPlace(num + ((num >= num3) ? length : 0));
		Selection.End = PositionToPlace(num2 + ((num2 >= num3) ? length : 0));
		Selection.EndUpdate();
		return range;
	}

	public virtual void AppendText(string text)
	{
		AppendText(text, null);
	}

	public virtual void AppendText(string text, Style style)
	{
		if (text == null)
		{
			return;
		}
		Selection.ColumnSelectionMode = false;
		Place start = Selection.Start;
		Place end = Selection.End;
		Selection.BeginUpdate();
		lines.Manager.BeginAutoUndoCommands();
		try
		{
			if (lines.Count > 0)
			{
				Selection.Start = new Place(lines[lines.Count - 1].Count, lines.Count - 1);
			}
			else
			{
				Selection.Start = new Place(0, 0);
			}
			Place start2 = Selection.Start;
			lines.Manager.ExecuteCommand(new InsertTextCommand(TextSource, text));
			if (style != null)
			{
				new Range(this, start2, Selection.Start).SetStyle(style);
			}
		}
		finally
		{
			lines.Manager.EndAutoUndoCommands();
			Selection.Start = start;
			Selection.End = end;
			Selection.EndUpdate();
		}
		Invalidate();
	}

	public int GetStyleIndex(Style style)
	{
		return Array.IndexOf(Styles, style);
	}

	public StyleIndex GetStyleIndexMask(Style[] styles)
	{
		StyleIndex styleIndex = StyleIndex.None;
		foreach (Style style in styles)
		{
			int styleIndex2 = GetStyleIndex(style);
			if (styleIndex2 >= 0)
			{
				styleIndex |= Range.ToStyleIndex(styleIndex2);
			}
		}
		return styleIndex;
	}

	internal int GetOrSetStyleLayerIndex(Style style)
	{
		int num = GetStyleIndex(style);
		if (num < 0)
		{
			num = AddStyle(style);
		}
		return num;
	}

	public static SizeF GetCharSize(Font font, char c)
	{
		Size size = TextRenderer.MeasureText("<" + c + ">", font);
		Size size2 = TextRenderer.MeasureText("<>", font);
		return new SizeF(size.Width - size2.Width + 1, font.Height);
	}

	[DllImport("Imm32.dll")]
	public static extern IntPtr ImmGetContext(IntPtr hWnd);

	[DllImport("Imm32.dll")]
	public static extern IntPtr ImmAssociateContext(IntPtr hWnd, IntPtr hIMC);

	protected override void WndProc(ref Message m)
	{
		if ((m.Msg == 276 || m.Msg == 277) && m.WParam.ToInt32() != 8)
		{
			Invalidate();
		}
		base.WndProc(ref m);
		if (ImeAllowed && m.Msg == 641 && m.WParam.ToInt32() == 1)
		{
			ImmAssociateContext(base.Handle, m_hImc);
		}
	}

	private void HideHints()
	{
		if (ShowScrollBars || Hints.Count <= 0)
		{
			return;
		}
		SuspendLayout();
		foreach (Control control in base.Controls)
		{
			tempHintsList.Add(control);
		}
		base.Controls.Clear();
	}

	private void RestoreHints()
	{
		if (ShowScrollBars || Hints.Count <= 0)
		{
			return;
		}
		foreach (Control tempHints in tempHintsList)
		{
			base.Controls.Add(tempHints);
		}
		tempHintsList.Clear();
		ResumeLayout(performLayout: false);
		if (!Focused)
		{
			Focus();
		}
	}

	public void OnScroll(ScrollEventArgs se, bool alignByLines)
	{
		HideHints();
		if (se.ScrollOrientation == ScrollOrientation.VerticalScroll)
		{
			int num = se.NewValue;
			if (alignByLines)
			{
				num = (int)(Math.Ceiling(1.0 * (double)num / (double)CharHeight) * (double)CharHeight);
			}
			base.VerticalScroll.Value = Math.Max(base.VerticalScroll.Minimum, Math.Min(base.VerticalScroll.Maximum, num));
		}
		if (se.ScrollOrientation == ScrollOrientation.HorizontalScroll)
		{
			base.HorizontalScroll.Value = Math.Max(base.HorizontalScroll.Minimum, Math.Min(base.HorizontalScroll.Maximum, se.NewValue));
		}
		UpdateScrollbars();
		RestoreHints();
		Invalidate();
		base.OnScroll(se);
		OnVisibleRangeChanged();
	}

	protected override void OnScroll(ScrollEventArgs se)
	{
		OnScroll(se, alignByLines: true);
	}

	protected virtual void InsertChar(char c)
	{
		lines.Manager.BeginAutoUndoCommands();
		try
		{
			if (!Selection.IsEmpty)
			{
				lines.Manager.ExecuteCommand(new ClearSelectedCommand(TextSource));
			}
			if (Selection.IsEmpty && Selection.Start.iChar > GetLineLength(Selection.Start.iLine) && VirtualSpace)
			{
				InsertVirtualSpaces();
			}
			lines.Manager.ExecuteCommand(new InsertCharCommand(TextSource, c));
		}
		finally
		{
			lines.Manager.EndAutoUndoCommands();
		}
		Invalidate();
	}

	private void InsertVirtualSpaces()
	{
		int lineLength = GetLineLength(Selection.Start.iLine);
		int count = Selection.Start.iChar - lineLength;
		Selection.BeginUpdate();
		try
		{
			Selection.Start = new Place(lineLength, Selection.Start.iLine);
			lines.Manager.ExecuteCommand(new InsertTextCommand(TextSource, new string(' ', count)));
		}
		finally
		{
			Selection.EndUpdate();
		}
	}

	public virtual void ClearSelected()
	{
		if (!Selection.IsEmpty)
		{
			lines.Manager.ExecuteCommand(new ClearSelectedCommand(TextSource));
			Invalidate();
		}
	}

	public void ClearCurrentLine()
	{
		Selection.Expand();
		lines.Manager.ExecuteCommand(new ClearSelectedCommand(TextSource));
		if (Selection.Start.iLine != 0 || Selection.GoRightThroughFolded())
		{
			if (Selection.Start.iLine > 0)
			{
				lines.Manager.ExecuteCommand(new InsertCharCommand(TextSource, '\b'));
			}
			Invalidate();
		}
	}

	private void Recalc()
	{
		if (!needRecalc)
		{
			return;
		}
		needRecalc = false;
		LeftIndent = LeftPadding;
		long num = LinesCount + lineNumberStartValue - 1;
		int num2 = 2 + ((num > 0) ? ((int)Math.Log10(num)) : 0);
		if (ReservedCountOfLineNumberChars + 1 > num2)
		{
			num2 = ReservedCountOfLineNumberChars + 1;
		}
		if (base.Created)
		{
			if (ShowLineNumbers)
			{
				LeftIndent += num2 * CharWidth + 8 + 1;
			}
			if (needRecalcWordWrap)
			{
				RecalcWordWrap(needRecalcWordWrapInterval.X, needRecalcWordWrapInterval.Y);
				needRecalcWordWrap = false;
			}
		}
		else
		{
			needRecalc = true;
		}
		TextHeight = 0;
		maxLineLength = RecalcMaxLineLength();
		CalcMinAutosizeWidth(out var minWidth, ref maxLineLength);
		AutoScrollMinSize = new Size(minWidth, TextHeight + Paddings.Top + Paddings.Bottom);
		UpdateScrollbars();
	}

	private void CalcMinAutosizeWidth(out int minWidth, ref int maxLineLength)
	{
		minWidth = LeftIndent + maxLineLength * CharWidth + 2 + Paddings.Left + Paddings.Right;
		if (wordWrap)
		{
			switch (WordWrapMode)
			{
			case WordWrapMode.WordWrapControlWidth:
			case WordWrapMode.CharWrapControlWidth:
				maxLineLength = Math.Min(maxLineLength, (base.ClientSize.Width - LeftIndent - Paddings.Left - Paddings.Right) / CharWidth);
				minWidth = 0;
				break;
			case WordWrapMode.WordWrapPreferredWidth:
			case WordWrapMode.CharWrapPreferredWidth:
				maxLineLength = Math.Min(maxLineLength, PreferredLineWidth);
				minWidth = LeftIndent + PreferredLineWidth * CharWidth + 2 + Paddings.Left + Paddings.Right;
				break;
			}
		}
	}

	private void RecalcScrollByOneLine(int iLine)
	{
		if (iLine < lines.Count)
		{
			int count = lines[iLine].Count;
			if (maxLineLength < count && !WordWrap)
			{
				maxLineLength = count;
			}
			CalcMinAutosizeWidth(out var minWidth, ref count);
			if (AutoScrollMinSize.Width < minWidth)
			{
				AutoScrollMinSize = new Size(minWidth, AutoScrollMinSize.Height);
			}
		}
	}

	private int RecalcMaxLineLength()
	{
		int num = 0;
		TextSource textSource = lines;
		int count = textSource.Count;
		int num2 = CharHeight;
		int num3 = (TextHeight = Paddings.Top);
		for (int i = 0; i < count; i++)
		{
			int lineLength = textSource.GetLineLength(i);
			LineInfo value = LineInfos[i];
			if (lineLength > num && value.VisibleState == VisibleState.Visible)
			{
				num = lineLength;
			}
			value.startY = TextHeight;
			TextHeight += value.WordWrapStringsCount * num2 + value.bottomPadding;
			LineInfos[i] = value;
		}
		TextHeight -= num3;
		return num;
	}

	private int GetMaxLineWordWrapedWidth()
	{
		if (wordWrap)
		{
			switch (wordWrapMode)
			{
			case WordWrapMode.WordWrapControlWidth:
			case WordWrapMode.CharWrapControlWidth:
				return base.ClientSize.Width;
			case WordWrapMode.WordWrapPreferredWidth:
			case WordWrapMode.CharWrapPreferredWidth:
				return LeftIndent + PreferredLineWidth * CharWidth + 2 + Paddings.Left + Paddings.Right;
			}
		}
		return int.MaxValue;
	}

	private void RecalcWordWrap(int fromLine, int toLine)
	{
		int num = 0;
		bool charWrap = false;
		toLine = Math.Min(LinesCount - 1, toLine);
		switch (WordWrapMode)
		{
		case WordWrapMode.WordWrapControlWidth:
			num = (base.ClientSize.Width - LeftIndent - Paddings.Left - Paddings.Right) / CharWidth;
			break;
		case WordWrapMode.CharWrapControlWidth:
			num = (base.ClientSize.Width - LeftIndent - Paddings.Left - Paddings.Right) / CharWidth;
			charWrap = true;
			break;
		case WordWrapMode.WordWrapPreferredWidth:
			num = PreferredLineWidth;
			break;
		case WordWrapMode.CharWrapPreferredWidth:
			num = PreferredLineWidth;
			charWrap = true;
			break;
		}
		for (int i = fromLine; i <= toLine; i++)
		{
			if (!lines.IsLineLoaded(i))
			{
				continue;
			}
			if (!wordWrap)
			{
				LineInfos[i].CutOffPositions.Clear();
				continue;
			}
			LineInfo value = LineInfos[i];
			value.wordWrapIndent = (WordWrapAutoIndent ? (lines[i].StartSpacesCount + WordWrapIndent) : WordWrapIndent);
			if (WordWrapMode == WordWrapMode.Custom)
			{
				if (this.WordWrapNeeded != null)
				{
					this.WordWrapNeeded(this, new WordWrapNeededEventArgs(value.CutOffPositions, ImeAllowed, lines[i]));
				}
			}
			else
			{
				CalcCutOffs(value.CutOffPositions, num, num - value.wordWrapIndent, ImeAllowed, charWrap, lines[i]);
			}
			LineInfos[i] = value;
		}
		needRecalc = true;
	}

	public static void CalcCutOffs(List<int> cutOffPositions, int maxCharsPerLine, int maxCharsPerSecondaryLine, bool allowIME, bool charWrap, Line line)
	{
		if (maxCharsPerSecondaryLine < 1)
		{
			maxCharsPerSecondaryLine = 1;
		}
		if (maxCharsPerLine < 1)
		{
			maxCharsPerLine = 1;
		}
		int num = 0;
		int num2 = 0;
		cutOffPositions.Clear();
		for (int i = 0; i < line.Count - 1; i++)
		{
			char c = line[i].c;
			if (charWrap)
			{
				num2 = i + 1;
			}
			else if (allowIME && IsCJKLetter(c))
			{
				num2 = i;
			}
			else if (!char.IsLetterOrDigit(c) && c != '_' && c != '\'' && c != '\u00a0' && ((c != '.' && c != ',') || !char.IsDigit(line[i + 1].c)))
			{
				num2 = Math.Min(i + 1, line.Count - 1);
			}
			num++;
			if (num == maxCharsPerLine)
			{
				if (num2 == 0 || (cutOffPositions.Count > 0 && num2 == cutOffPositions[cutOffPositions.Count - 1]))
				{
					num2 = i + 1;
				}
				cutOffPositions.Add(num2);
				num = 1 + i - num2;
				maxCharsPerLine = maxCharsPerSecondaryLine;
			}
		}
	}

	public static bool IsCJKLetter(char c)
	{
		int num = Convert.ToInt32(c);
		return (num >= 13056 && num <= 13311) || (num >= 65072 && num <= 65103) || (num >= 63744 && num <= 64255) || (num >= 11904 && num <= 12031) || (num >= 12736 && num <= 12783) || (num >= 19968 && num <= 40959) || (num >= 13312 && num <= 19903) || (num >= 12800 && num <= 13055) || (num >= 9312 && num <= 9471) || (num >= 12352 && num <= 12447) || (num >= 12032 && num <= 12255) || (num >= 12704 && num <= 12735) || (num >= 19904 && num <= 19967) || (num >= 12544 && num <= 12591) || (num >= 12448 && num <= 12543) || (num >= 12784 && num <= 12799) || (num >= 12272 && num <= 12287) || (num >= 4352 && num <= 4607) || (num >= 43360 && num <= 43391) || (num >= 55216 && num <= 55295) || (num >= 12592 && num <= 12687) || (num >= 44032 && num <= 55215);
	}

	protected override void OnClientSizeChanged(EventArgs e)
	{
		base.OnClientSizeChanged(e);
		if (WordWrap)
		{
			NeedRecalc(forced: false, wordWrapRecalc: true);
			Invalidate();
		}
		OnVisibleRangeChanged();
		UpdateScrollbars();
	}

	internal void DoVisibleRectangle(Rectangle rect)
	{
		HideHints();
		int value = base.VerticalScroll.Value;
		int num = base.VerticalScroll.Value;
		int num2 = base.HorizontalScroll.Value;
		if (rect.Bottom > base.ClientRectangle.Height)
		{
			num += rect.Bottom - base.ClientRectangle.Height;
		}
		else if (rect.Top < 0)
		{
			num += rect.Top;
		}
		if (rect.Right > base.ClientRectangle.Width)
		{
			num2 += rect.Right - base.ClientRectangle.Width;
		}
		else if (rect.Left < LeftIndent)
		{
			num2 += rect.Left - LeftIndent;
		}
		if (!Multiline)
		{
			num = 0;
		}
		num = Math.Max(base.VerticalScroll.Minimum, num);
		num2 = Math.Max(base.HorizontalScroll.Minimum, num2);
		try
		{
			if (base.VerticalScroll.Visible || !ShowScrollBars)
			{
				base.VerticalScroll.Value = Math.Min(num, base.VerticalScroll.Maximum);
			}
			if (base.HorizontalScroll.Visible || !ShowScrollBars)
			{
				base.HorizontalScroll.Value = Math.Min(num2, base.HorizontalScroll.Maximum);
			}
		}
		catch (ArgumentOutOfRangeException)
		{
		}
		UpdateScrollbars();
		RestoreHints();
		if (value != base.VerticalScroll.Value)
		{
			OnVisibleRangeChanged();
		}
	}

	public void UpdateScrollbars()
	{
		if (ShowScrollBars)
		{
			base.AutoScrollMinSize -= new Size(1, 0);
			base.AutoScrollMinSize += new Size(1, 0);
		}
		else
		{
			PerformLayout();
		}
		if (base.IsHandleCreated)
		{
			BeginInvoke(new MethodInvoker(OnScrollbarsUpdated));
		}
	}

	protected virtual void OnScrollbarsUpdated()
	{
		if (this.ScrollbarsUpdated != null)
		{
			this.ScrollbarsUpdated(this, EventArgs.Empty);
		}
	}

	public void DoCaretVisible()
	{
		Invalidate();
		Recalc();
		Point location = PlaceToPoint(Selection.Start);
		location.Offset(-CharWidth, 0);
		DoVisibleRectangle(new Rectangle(location, new Size(2 * CharWidth, 2 * CharHeight)));
	}

	public void ScrollLeft()
	{
		Invalidate();
		base.HorizontalScroll.Value = 0;
		AutoScrollMinSize -= new Size(1, 0);
		AutoScrollMinSize += new Size(1, 0);
	}

	public void DoSelectionVisible()
	{
		if (LineInfos[Selection.End.iLine].VisibleState != VisibleState.Visible)
		{
			ExpandBlock(Selection.End.iLine);
		}
		if (LineInfos[Selection.Start.iLine].VisibleState != VisibleState.Visible)
		{
			ExpandBlock(Selection.Start.iLine);
		}
		Recalc();
		DoVisibleRectangle(new Rectangle(PlaceToPoint(new Place(0, Selection.End.iLine)), new Size(2 * CharWidth, 2 * CharHeight)));
		Point location = PlaceToPoint(Selection.Start);
		Point point = PlaceToPoint(Selection.End);
		location.Offset(-CharWidth, -base.ClientSize.Height / 2);
		DoVisibleRectangle(new Rectangle(location, new Size(Math.Abs(point.X - location.X), base.ClientSize.Height)));
		Invalidate();
	}

	public void DoRangeVisible(Range range)
	{
		DoRangeVisible(range, tryToCentre: false);
	}

	public void DoRangeVisible(Range range, bool tryToCentre)
	{
		range = range.Clone();
		range.Normalize();
		range.End = new Place(range.End.iChar, Math.Min(range.End.iLine, range.Start.iLine + base.ClientSize.Height / CharHeight));
		if (LineInfos[range.End.iLine].VisibleState != VisibleState.Visible)
		{
			ExpandBlock(range.End.iLine);
		}
		if (LineInfos[range.Start.iLine].VisibleState != VisibleState.Visible)
		{
			ExpandBlock(range.Start.iLine);
		}
		Recalc();
		int num = (1 + range.End.iLine - range.Start.iLine) * CharHeight;
		Point location = PlaceToPoint(new Place(0, range.Start.iLine));
		if (tryToCentre)
		{
			location.Offset(0, -base.ClientSize.Height / 2);
			num = base.ClientSize.Height;
		}
		DoVisibleRectangle(new Rectangle(location, new Size(2 * CharWidth, num)));
		Invalidate();
	}

	protected override void OnKeyUp(KeyEventArgs e)
	{
		base.OnKeyUp(e);
		if (e.KeyCode == Keys.ShiftKey)
		{
			lastModifiers &= ~Keys.Shift;
		}
		if (e.KeyCode == Keys.Alt)
		{
			lastModifiers &= ~Keys.Alt;
		}
		if (e.KeyCode == Keys.ControlKey)
		{
			lastModifiers &= ~Keys.Control;
		}
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		if (!middleClickScrollingActivated)
		{
			base.OnKeyDown(e);
			if (Focused)
			{
				lastModifiers = e.Modifiers;
			}
			handledChar = false;
			if (e.Handled)
			{
				handledChar = true;
			}
			else if (!ProcessKey(e.KeyData))
			{
				e.Handled = true;
				DoCaretVisible();
				Invalidate();
			}
		}
	}

	protected override bool ProcessDialogKey(Keys keyData)
	{
		if ((keyData & Keys.Alt) > Keys.None && HotkeysMapping.ContainsKey(keyData))
		{
			ProcessKey(keyData);
			return true;
		}
		return base.ProcessDialogKey(keyData);
	}

	public virtual bool ProcessKey(Keys keyData)
	{
		KeyEventArgs e = new KeyEventArgs(keyData);
		if (e.KeyCode == Keys.Tab && !AcceptsTab)
		{
			return false;
		}
		if (macrosManager != null && (!HotkeysMapping.ContainsKey(keyData) || (HotkeysMapping[keyData] != FCTBAction.MacroExecute && HotkeysMapping[keyData] != FCTBAction.MacroRecord)))
		{
			macrosManager.ProcessKey(keyData);
		}
		if (HotkeysMapping.ContainsKey(keyData))
		{
			FCTBAction fCTBAction = HotkeysMapping[keyData];
			DoAction(fCTBAction);
			if (scrollActions.ContainsKey(fCTBAction))
			{
				return true;
			}
			if (keyData == Keys.Tab || keyData == (Keys.Tab | Keys.Shift))
			{
				handledChar = true;
				return true;
			}
		}
		else
		{
			if (e.KeyCode == Keys.Alt)
			{
				return true;
			}
			if ((e.Modifiers & Keys.Control) != Keys.None)
			{
				return true;
			}
			if ((e.Modifiers & Keys.Alt) != Keys.None)
			{
				if ((Control.MouseButtons & MouseButtons.Left) != MouseButtons.None)
				{
					CheckAndChangeSelectionType();
				}
				return true;
			}
			if (e.KeyCode == Keys.ShiftKey)
			{
				return true;
			}
		}
		return false;
	}

	private void DoAction(FCTBAction action)
	{
		switch (action)
		{
		case FCTBAction.ZoomIn:
			ChangeFontSize(2);
			break;
		case FCTBAction.ZoomOut:
			ChangeFontSize(-2);
			break;
		case FCTBAction.ZoomNormal:
			RestoreFontSize();
			break;
		case FCTBAction.ScrollDown:
			DoScrollVertical(1, -1);
			break;
		case FCTBAction.ScrollUp:
			DoScrollVertical(1, 1);
			break;
		case FCTBAction.GoToDialog:
			ShowGoToDialog();
			break;
		case FCTBAction.FindDialog:
			ShowFindDialog();
			break;
		case FCTBAction.FindChar:
			findCharMode = true;
			break;
		case FCTBAction.FindNext:
			if (findForm == null || findForm.tbFind.Text == "")
			{
				ShowFindDialog();
			}
			else
			{
				findForm.FindNext(findForm.tbFind.Text);
			}
			break;
		case FCTBAction.ReplaceDialog:
			ShowReplaceDialog();
			break;
		case FCTBAction.Copy:
			Copy();
			break;
		case FCTBAction.CommentSelected:
			CommentSelected();
			break;
		case FCTBAction.Cut:
			if (!Selection.ReadOnly)
			{
				Cut();
			}
			break;
		case FCTBAction.Paste:
			if (!Selection.ReadOnly)
			{
				Paste();
			}
			break;
		case FCTBAction.SelectAll:
			Selection.SelectAll();
			break;
		case FCTBAction.Undo:
			if (!ReadOnly)
			{
				Undo();
			}
			break;
		case FCTBAction.Redo:
			if (!ReadOnly)
			{
				Redo();
			}
			break;
		case FCTBAction.LowerCase:
			if (!Selection.ReadOnly)
			{
				LowerCase();
			}
			break;
		case FCTBAction.UpperCase:
			if (!Selection.ReadOnly)
			{
				UpperCase();
			}
			break;
		case FCTBAction.IndentDecrease:
		{
			if (Selection.ReadOnly)
			{
				break;
			}
			Range range = Selection.Clone();
			if (range.Start.iLine == range.End.iLine)
			{
				Line line = this[range.Start.iLine];
				if (range.Start.iChar == 0 && range.End.iChar == line.Count)
				{
					Selection = new Range(this, line.StartSpacesCount, range.Start.iLine, line.Count, range.Start.iLine);
				}
				else if (range.Start.iChar == line.Count && range.End.iChar == 0)
				{
					Selection = new Range(this, line.Count, range.Start.iLine, line.StartSpacesCount, range.Start.iLine);
				}
			}
			DecreaseIndent();
			break;
		}
		case FCTBAction.IndentIncrease:
		{
			if (Selection.ReadOnly)
			{
				break;
			}
			Range range2 = Selection.Clone();
			bool flag = range2.Start > range2.End;
			range2.Normalize();
			int startSpacesCount = this[range2.Start.iLine].StartSpacesCount;
			if (range2.Start.iLine != range2.End.iLine || (range2.Start.iChar <= startSpacesCount && range2.End.iChar == this[range2.Start.iLine].Count) || range2.End.iChar <= startSpacesCount)
			{
				IncreaseIndent();
				if (range2.Start.iLine == range2.End.iLine && !range2.IsEmpty)
				{
					Selection = new Range(this, this[range2.Start.iLine].StartSpacesCount, range2.End.iLine, this[range2.Start.iLine].Count, range2.End.iLine);
					if (flag)
					{
						Selection.Inverse();
					}
				}
			}
			else
			{
				ProcessKey('\t', Keys.None);
			}
			break;
		}
		case FCTBAction.AutoIndentChars:
			if (!Selection.ReadOnly)
			{
				DoAutoIndentChars(Selection.Start.iLine);
			}
			break;
		case FCTBAction.NavigateBackward:
			NavigateBackward();
			break;
		case FCTBAction.NavigateForward:
			NavigateForward();
			break;
		case FCTBAction.UnbookmarkLine:
			UnbookmarkLine(Selection.Start.iLine);
			break;
		case FCTBAction.BookmarkLine:
			BookmarkLine(Selection.Start.iLine);
			break;
		case FCTBAction.GoNextBookmark:
			GotoNextBookmark(Selection.Start.iLine);
			break;
		case FCTBAction.GoPrevBookmark:
			GotoPrevBookmark(Selection.Start.iLine);
			break;
		case FCTBAction.ClearWordLeft:
			if (OnKeyPressing('\b'))
			{
				break;
			}
			if (!Selection.ReadOnly)
			{
				if (!Selection.IsEmpty)
				{
					ClearSelected();
				}
				Selection.GoWordLeft(shift: true);
				if (!Selection.ReadOnly)
				{
					ClearSelected();
				}
			}
			OnKeyPressed('\b');
			break;
		case FCTBAction.ReplaceMode:
			if (!ReadOnly)
			{
				isReplaceMode = !isReplaceMode;
			}
			break;
		case FCTBAction.DeleteCharRight:
			if (Selection.ReadOnly || OnKeyPressing('ÿ'))
			{
				break;
			}
			if (!Selection.IsEmpty)
			{
				ClearSelected();
			}
			else
			{
				if (this[Selection.Start.iLine].StartSpacesCount == this[Selection.Start.iLine].Count)
				{
					RemoveSpacesAfterCaret();
				}
				if (!Selection.IsReadOnlyRightChar() && Selection.GoRightThroughFolded())
				{
					int iLine = Selection.Start.iLine;
					InsertChar('\b');
					if (iLine != Selection.Start.iLine && AutoIndent && Selection.Start.iChar > 0)
					{
						RemoveSpacesAfterCaret();
					}
				}
			}
			if (AutoIndentChars)
			{
				DoAutoIndentChars(Selection.Start.iLine);
			}
			OnKeyPressed('ÿ');
			break;
		case FCTBAction.ClearWordRight:
			if (OnKeyPressing('ÿ'))
			{
				break;
			}
			if (!Selection.ReadOnly)
			{
				if (!Selection.IsEmpty)
				{
					ClearSelected();
				}
				Selection.GoWordRight(shift: true);
				if (!Selection.ReadOnly)
				{
					ClearSelected();
				}
			}
			OnKeyPressed('ÿ');
			break;
		case FCTBAction.GoWordLeft:
			Selection.GoWordLeft(shift: false);
			break;
		case FCTBAction.GoWordLeftWithSelection:
			Selection.GoWordLeft(shift: true);
			break;
		case FCTBAction.GoLeft:
			Selection.GoLeft(shift: false);
			break;
		case FCTBAction.GoLeftWithSelection:
			Selection.GoLeft(shift: true);
			break;
		case FCTBAction.GoLeft_ColumnSelectionMode:
			CheckAndChangeSelectionType();
			if (Selection.ColumnSelectionMode)
			{
				Selection.GoLeft_ColumnSelectionMode();
			}
			Invalidate();
			break;
		case FCTBAction.GoWordRight:
			Selection.GoWordRight(shift: false, goToStartOfNextWord: true);
			break;
		case FCTBAction.GoWordRightWithSelection:
			Selection.GoWordRight(shift: true, goToStartOfNextWord: true);
			break;
		case FCTBAction.GoRight:
			Selection.GoRight(shift: false);
			break;
		case FCTBAction.GoRightWithSelection:
			Selection.GoRight(shift: true);
			break;
		case FCTBAction.GoRight_ColumnSelectionMode:
			CheckAndChangeSelectionType();
			if (Selection.ColumnSelectionMode)
			{
				Selection.GoRight_ColumnSelectionMode();
			}
			Invalidate();
			break;
		case FCTBAction.GoUp:
			Selection.GoUp(shift: false);
			ScrollLeft();
			break;
		case FCTBAction.GoUpWithSelection:
			Selection.GoUp(shift: true);
			ScrollLeft();
			break;
		case FCTBAction.GoUp_ColumnSelectionMode:
			CheckAndChangeSelectionType();
			if (Selection.ColumnSelectionMode)
			{
				Selection.GoUp_ColumnSelectionMode();
			}
			Invalidate();
			break;
		case FCTBAction.MoveSelectedLinesUp:
			if (!Selection.ColumnSelectionMode)
			{
				MoveSelectedLinesUp();
			}
			break;
		case FCTBAction.GoDown:
			Selection.GoDown(shift: false);
			ScrollLeft();
			break;
		case FCTBAction.GoDownWithSelection:
			Selection.GoDown(shift: true);
			ScrollLeft();
			break;
		case FCTBAction.GoDown_ColumnSelectionMode:
			CheckAndChangeSelectionType();
			if (Selection.ColumnSelectionMode)
			{
				Selection.GoDown_ColumnSelectionMode();
			}
			Invalidate();
			break;
		case FCTBAction.MoveSelectedLinesDown:
			if (!Selection.ColumnSelectionMode)
			{
				MoveSelectedLinesDown();
			}
			break;
		case FCTBAction.GoPageUp:
			Selection.GoPageUp(shift: false);
			ScrollLeft();
			break;
		case FCTBAction.GoPageUpWithSelection:
			Selection.GoPageUp(shift: true);
			ScrollLeft();
			break;
		case FCTBAction.GoPageDown:
			Selection.GoPageDown(shift: false);
			ScrollLeft();
			break;
		case FCTBAction.GoPageDownWithSelection:
			Selection.GoPageDown(shift: true);
			ScrollLeft();
			break;
		case FCTBAction.GoFirstLine:
			Selection.GoFirst(shift: false);
			break;
		case FCTBAction.GoFirstLineWithSelection:
			Selection.GoFirst(shift: true);
			break;
		case FCTBAction.GoHome:
			GoHome(shift: false);
			ScrollLeft();
			break;
		case FCTBAction.GoHomeWithSelection:
			GoHome(shift: true);
			ScrollLeft();
			break;
		case FCTBAction.GoLastLine:
			Selection.GoLast(shift: false);
			break;
		case FCTBAction.GoLastLineWithSelection:
			Selection.GoLast(shift: true);
			break;
		case FCTBAction.GoEnd:
			Selection.GoEnd(shift: false);
			break;
		case FCTBAction.GoEndWithSelection:
			Selection.GoEnd(shift: true);
			break;
		case FCTBAction.ClearHints:
			ClearHints();
			if (MacrosManager != null)
			{
				MacrosManager.IsRecording = false;
			}
			break;
		case FCTBAction.MacroRecord:
			if (MacrosManager != null)
			{
				if (MacrosManager.AllowMacroRecordingByUser)
				{
					MacrosManager.IsRecording = !MacrosManager.IsRecording;
				}
				if (MacrosManager.IsRecording)
				{
					MacrosManager.ClearMacros();
				}
			}
			break;
		case FCTBAction.MacroExecute:
			if (MacrosManager != null)
			{
				MacrosManager.IsRecording = false;
				MacrosManager.ExecuteMacros();
			}
			break;
		case FCTBAction.CustomAction1:
		case FCTBAction.CustomAction2:
		case FCTBAction.CustomAction3:
		case FCTBAction.CustomAction4:
		case FCTBAction.CustomAction5:
		case FCTBAction.CustomAction6:
		case FCTBAction.CustomAction7:
		case FCTBAction.CustomAction8:
		case FCTBAction.CustomAction9:
		case FCTBAction.CustomAction10:
		case FCTBAction.CustomAction11:
		case FCTBAction.CustomAction12:
		case FCTBAction.CustomAction13:
		case FCTBAction.CustomAction14:
		case FCTBAction.CustomAction15:
		case FCTBAction.CustomAction16:
		case FCTBAction.CustomAction17:
		case FCTBAction.CustomAction18:
		case FCTBAction.CustomAction19:
		case FCTBAction.CustomAction20:
			OnCustomAction(new CustomActionEventArgs(action));
			break;
		}
	}

	protected virtual void OnCustomAction(CustomActionEventArgs e)
	{
		if (this.CustomAction != null)
		{
			this.CustomAction(this, e);
		}
	}

	private void RestoreFontSize()
	{
		Zoom = 100;
	}

	public bool GotoNextBookmark(int iLine)
	{
		Bookmark bookmark = null;
		int num = int.MaxValue;
		Bookmark bookmark2 = null;
		int num2 = int.MaxValue;
		foreach (Bookmark bookmark3 in bookmarks)
		{
			if (bookmark3.LineIndex < num2)
			{
				num2 = bookmark3.LineIndex;
				bookmark2 = bookmark3;
			}
			if (bookmark3.LineIndex > iLine && bookmark3.LineIndex < num)
			{
				num = bookmark3.LineIndex;
				bookmark = bookmark3;
			}
		}
		if (bookmark != null)
		{
			bookmark.DoVisible();
			return true;
		}
		if (bookmark2 != null)
		{
			bookmark2.DoVisible();
			return true;
		}
		return false;
	}

	public bool GotoPrevBookmark(int iLine)
	{
		Bookmark bookmark = null;
		int num = -1;
		Bookmark bookmark2 = null;
		int num2 = -1;
		foreach (Bookmark bookmark3 in bookmarks)
		{
			if (bookmark3.LineIndex > num2)
			{
				num2 = bookmark3.LineIndex;
				bookmark2 = bookmark3;
			}
			if (bookmark3.LineIndex < iLine && bookmark3.LineIndex > num)
			{
				num = bookmark3.LineIndex;
				bookmark = bookmark3;
			}
		}
		if (bookmark != null)
		{
			bookmark.DoVisible();
			return true;
		}
		if (bookmark2 != null)
		{
			bookmark2.DoVisible();
			return true;
		}
		return false;
	}

	public virtual void BookmarkLine(int iLine)
	{
		if (!bookmarks.Contains(iLine))
		{
			bookmarks.Add(iLine);
		}
	}

	public virtual void UnbookmarkLine(int iLine)
	{
		bookmarks.Remove(iLine);
	}

	public virtual void MoveSelectedLinesDown()
	{
		Range range = Selection.Clone();
		Selection.Expand();
		if (!Selection.ReadOnly)
		{
			int iLine = Selection.Start.iLine;
			if (Selection.End.iLine >= LinesCount - 1)
			{
				Selection = range;
				return;
			}
			string selectedText = SelectedText;
			List<int> list = new List<int>();
			for (int i = Selection.Start.iLine; i <= Selection.End.iLine; i++)
			{
				list.Add(i);
			}
			RemoveLines(list);
			Selection.Start = new Place(GetLineLength(iLine), iLine);
			SelectedText = "\n" + selectedText;
			Selection.Start = new Place(range.Start.iChar, range.Start.iLine + 1);
			Selection.End = new Place(range.End.iChar, range.End.iLine + 1);
		}
		else
		{
			Selection = range;
		}
	}

	public virtual void MoveSelectedLinesUp()
	{
		Range range = Selection.Clone();
		Selection.Expand();
		if (!Selection.ReadOnly)
		{
			int iLine = Selection.Start.iLine;
			if (iLine == 0)
			{
				Selection = range;
				return;
			}
			string selectedText = SelectedText;
			List<int> list = new List<int>();
			for (int i = Selection.Start.iLine; i <= Selection.End.iLine; i++)
			{
				list.Add(i);
			}
			RemoveLines(list);
			Selection.Start = new Place(0, iLine - 1);
			SelectedText = selectedText + "\n";
			Selection.Start = new Place(range.Start.iChar, range.Start.iLine - 1);
			Selection.End = new Place(range.End.iChar, range.End.iLine - 1);
		}
		else
		{
			Selection = range;
		}
	}

	private void GoHome(bool shift)
	{
		Selection.BeginUpdate();
		try
		{
			int iLine = Selection.Start.iLine;
			int startSpacesCount = this[iLine].StartSpacesCount;
			if (Selection.Start.iChar <= startSpacesCount)
			{
				Selection.GoHome(shift);
				return;
			}
			Selection.GoHome(shift);
			for (int i = 0; i < startSpacesCount; i++)
			{
				Selection.GoRight(shift);
			}
		}
		finally
		{
			Selection.EndUpdate();
		}
	}

	public virtual void UpperCase()
	{
		Range range = Selection.Clone();
		SelectedText = SelectedText.ToUpper();
		Selection.Start = range.Start;
		Selection.End = range.End;
	}

	public virtual void LowerCase()
	{
		Range range = Selection.Clone();
		SelectedText = SelectedText.ToLower();
		Selection.Start = range.Start;
		Selection.End = range.End;
	}

	public virtual void TitleCase()
	{
		Range range = Selection.Clone();
		SelectedText = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(SelectedText.ToLower());
		Selection.Start = range.Start;
		Selection.End = range.End;
	}

	public virtual void SentenceCase()
	{
		Range range = Selection.Clone();
		string input = SelectedText.ToLower();
		Regex regex = new Regex("(^\\S)|[\\.\\?!:]\\s+(\\S)", RegexOptions.ExplicitCapture);
		SelectedText = regex.Replace(input, (Match s) => s.Value.ToUpper());
		Selection.Start = range.Start;
		Selection.End = range.End;
	}

	public void CommentSelected()
	{
		CommentSelected(CommentPrefix);
	}

	public virtual void CommentSelected(string commentPrefix)
	{
		if (!string.IsNullOrEmpty(commentPrefix))
		{
			Selection.Normalize();
			if (lines[Selection.Start.iLine].Text.TrimStart().StartsWith(commentPrefix))
			{
				RemoveLinePrefix(commentPrefix);
			}
			else
			{
				InsertLinePrefix(commentPrefix);
			}
		}
	}

	public void OnKeyPressing(KeyPressEventArgs args)
	{
		if (this.KeyPressing != null)
		{
			this.KeyPressing(this, args);
		}
	}

	private bool OnKeyPressing(char c)
	{
		if (findCharMode)
		{
			findCharMode = false;
			FindChar(c);
			return true;
		}
		KeyPressEventArgs e = new KeyPressEventArgs(c);
		OnKeyPressing(e);
		return e.Handled;
	}

	public void OnKeyPressed(char c)
	{
		KeyPressEventArgs e = new KeyPressEventArgs(c);
		if (this.KeyPressed != null)
		{
			this.KeyPressed(this, e);
		}
	}

	protected override bool ProcessMnemonic(char charCode)
	{
		if (middleClickScrollingActivated)
		{
			return false;
		}
		if (Focused)
		{
			return ProcessKey(charCode, lastModifiers) || base.ProcessMnemonic(charCode);
		}
		return false;
	}

	protected override bool ProcessKeyMessage(ref Message m)
	{
		if (m.Msg == 258)
		{
			ProcessMnemonic(Convert.ToChar(m.WParam.ToInt32()));
		}
		return base.ProcessKeyMessage(ref m);
	}

	public virtual bool ProcessKey(char c, Keys modifiers)
	{
		if (handledChar)
		{
			return true;
		}
		if (macrosManager != null)
		{
			macrosManager.ProcessKey(c, modifiers);
		}
		if (c == '\b' && (modifiers == Keys.None || modifiers == Keys.Shift || (modifiers & Keys.Alt) != Keys.None))
		{
			if (ReadOnly || !base.Enabled)
			{
				return false;
			}
			if (OnKeyPressing(c))
			{
				return true;
			}
			if (Selection.ReadOnly)
			{
				return false;
			}
			if (!Selection.IsEmpty)
			{
				ClearSelected();
			}
			else if (!Selection.IsReadOnlyLeftChar())
			{
				InsertChar('\b');
			}
			if (AutoIndentChars)
			{
				DoAutoIndentChars(Selection.Start.iLine);
			}
			OnKeyPressed('\b');
			return true;
		}
		if (char.IsControl(c) && c != '\r' && c != '\t')
		{
			return false;
		}
		if (ReadOnly || !base.Enabled)
		{
			return false;
		}
		if (modifiers != Keys.None && modifiers != Keys.Shift && modifiers != (Keys.Control | Keys.Alt) && modifiers != (Keys.Shift | Keys.Control | Keys.Alt) && (modifiers != Keys.Alt || char.IsLetterOrDigit(c)))
		{
			return false;
		}
		char c2 = c;
		if (OnKeyPressing(c2))
		{
			return true;
		}
		if (Selection.ReadOnly)
		{
			return false;
		}
		if (c == '\r' && !AcceptsReturn)
		{
			return false;
		}
		if (c == '\r')
		{
			c = '\n';
		}
		if (IsReplaceMode)
		{
			Selection.GoRight(shift: true);
			Selection.Inverse();
		}
		if (!Selection.ReadOnly && !DoAutocompleteBrackets(c))
		{
			InsertChar(c);
		}
		if (c == '\n' || AutoIndentExistingLines)
		{
			DoAutoIndentIfNeed();
		}
		if (AutoIndentChars)
		{
			DoAutoIndentChars(Selection.Start.iLine);
		}
		DoCaretVisible();
		Invalidate();
		OnKeyPressed(c2);
		return true;
	}

	public void DoAutoIndentChars(int iLine)
	{
		string[] array = AutoIndentCharsPatterns.Split(new char[2] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
		string[] array2 = array;
		foreach (string pattern in array2)
		{
			Match match = Regex.Match(this[iLine].Text, pattern);
			if (match.Success)
			{
				DoAutoIndentChars(iLine, new Regex(pattern));
				break;
			}
		}
	}

	protected void DoAutoIndentChars(int iLine, Regex regex)
	{
		Range range = Selection.Clone();
		SortedDictionary<int, CaptureCollection> sortedDictionary = new SortedDictionary<int, CaptureCollection>();
		SortedDictionary<int, string> sortedDictionary2 = new SortedDictionary<int, string>();
		int num = 0;
		int startSpacesCount = this[iLine].StartSpacesCount;
		int num2 = iLine;
		while (num2 >= 0 && startSpacesCount == this[num2].StartSpacesCount)
		{
			string text = this[num2].Text;
			Match match = regex.Match(text);
			if (match.Success)
			{
				sortedDictionary[num2] = match.Groups["range"].Captures;
				sortedDictionary2[num2] = text;
				if (sortedDictionary[num2].Count > num)
				{
					num = sortedDictionary[num2].Count;
				}
				num2--;
				continue;
			}
			break;
		}
		for (int i = iLine + 1; i < LinesCount && startSpacesCount == this[i].StartSpacesCount; i++)
		{
			string text2 = this[i].Text;
			Match match2 = regex.Match(text2);
			if (match2.Success)
			{
				sortedDictionary[i] = match2.Groups["range"].Captures;
				sortedDictionary2[i] = text2;
				if (sortedDictionary[i].Count > num)
				{
					num = sortedDictionary[i].Count;
				}
				continue;
			}
			break;
		}
		Dictionary<int, bool> dictionary = new Dictionary<int, bool>();
		bool flag = false;
		for (int num3 = num - 1; num3 >= 0; num3--)
		{
			int num4 = 0;
			foreach (int key in sortedDictionary.Keys)
			{
				CaptureCollection captureCollection = sortedDictionary[key];
				if (captureCollection.Count > num3)
				{
					int num5 = 0;
					Capture capture = captureCollection[num3];
					int num6 = capture.Index;
					string text3 = sortedDictionary2[key];
					while (num6 > 0 && text3[num6 - 1] == ' ')
					{
						num6--;
					}
					num5 = ((num3 != 0) ? (num6 - captureCollection[num3 - 1].Index - 1) : num6);
					if (num5 > num4)
					{
						num4 = num5;
					}
				}
			}
			foreach (int item in new List<int>(sortedDictionary2.Keys))
			{
				if (sortedDictionary[item].Count <= num3)
				{
					continue;
				}
				int num7 = 0;
				Capture capture2 = sortedDictionary[item][num3];
				num7 = ((num3 != 0) ? (capture2.Index - sortedDictionary[item][num3 - 1].Index - 1) : capture2.Index);
				int num8 = num4 - num7 + 1;
				if (num8 != 0)
				{
					if (range.Start.iLine == item && range.Start.iChar > capture2.Index)
					{
						range.Start = new Place(range.Start.iChar + num8, item);
					}
					if (num8 > 0)
					{
						sortedDictionary2[item] = sortedDictionary2[item].Insert(capture2.Index, new string(' ', num8));
					}
					else
					{
						sortedDictionary2[item] = sortedDictionary2[item].Remove(capture2.Index + num8, -num8);
					}
					dictionary[item] = true;
					flag = true;
				}
			}
		}
		if (!flag)
		{
			return;
		}
		Selection.BeginUpdate();
		BeginAutoUndo();
		BeginUpdate();
		TextSource.Manager.ExecuteCommand(new SelectCommand(TextSource));
		foreach (int key2 in sortedDictionary2.Keys)
		{
			if (dictionary.ContainsKey(key2))
			{
				Selection = new Range(this, 0, key2, this[key2].Count, key2);
				if (!Selection.ReadOnly)
				{
					InsertText(sortedDictionary2[key2]);
				}
			}
		}
		Selection = range;
		EndUpdate();
		EndAutoUndo();
		Selection.EndUpdate();
	}

	private bool DoAutocompleteBrackets(char c)
	{
		if (AutoCompleteBrackets)
		{
			if (!Selection.ColumnSelectionMode)
			{
				for (int i = 1; i < autoCompleteBracketsList.Length; i += 2)
				{
					if (c == autoCompleteBracketsList[i] && c == Selection.CharAfterStart)
					{
						Selection.GoRight();
						return true;
					}
				}
			}
			for (int j = 0; j < autoCompleteBracketsList.Length; j += 2)
			{
				if (c == autoCompleteBracketsList[j])
				{
					InsertBrackets(autoCompleteBracketsList[j], autoCompleteBracketsList[j + 1]);
					return true;
				}
			}
		}
		return false;
	}

	private bool InsertBrackets(char left, char right)
	{
		if (Selection.ColumnSelectionMode)
		{
			Range range = Selection.Clone();
			range.Normalize();
			Selection.BeginUpdate();
			BeginAutoUndo();
			Selection = new Range(this, range.Start.iChar, range.Start.iLine, range.Start.iChar, range.End.iLine)
			{
				ColumnSelectionMode = true
			};
			InsertChar(left);
			Selection = new Range(this, range.End.iChar + 1, range.Start.iLine, range.End.iChar + 1, range.End.iLine)
			{
				ColumnSelectionMode = true
			};
			InsertChar(right);
			if (range.IsEmpty)
			{
				Selection = new Range(this, range.End.iChar + 1, range.Start.iLine, range.End.iChar + 1, range.End.iLine)
				{
					ColumnSelectionMode = true
				};
			}
			EndAutoUndo();
			Selection.EndUpdate();
		}
		else if (Selection.IsEmpty)
		{
			InsertText(left.ToString() + right);
			Selection.GoLeft();
		}
		else
		{
			InsertText(left + SelectedText + right);
		}
		return true;
	}

	protected virtual void FindChar(char c)
	{
		if (c == '\r')
		{
			c = '\n';
		}
		Range range = Selection.Clone();
		while (range.GoRight())
		{
			if (range.CharBeforeStart == c)
			{
				Selection = range;
				DoCaretVisible();
				break;
			}
		}
	}

	public virtual void DoAutoIndentIfNeed()
	{
		if (!Selection.ColumnSelectionMode && AutoIndent)
		{
			DoCaretVisible();
			int num = CalcAutoIndent(Selection.Start.iLine);
			if (this[Selection.Start.iLine].AutoIndentSpacesNeededCount != num)
			{
				DoAutoIndent(Selection.Start.iLine);
				this[Selection.Start.iLine].AutoIndentSpacesNeededCount = num;
			}
		}
	}

	private void RemoveSpacesAfterCaret()
	{
		if (Selection.IsEmpty)
		{
			Place start = Selection.Start;
			while (Selection.CharAfterStart == ' ')
			{
				Selection.GoRight(shift: true);
			}
			ClearSelected();
		}
	}

	public virtual void DoAutoIndent(int iLine)
	{
		if (Selection.ColumnSelectionMode)
		{
			return;
		}
		Place start = Selection.Start;
		int num = CalcAutoIndent(iLine);
		int startSpacesCount = lines[iLine].StartSpacesCount;
		int num2 = num - startSpacesCount;
		if (num2 < 0)
		{
			num2 = -Math.Min(-num2, startSpacesCount);
		}
		if (num2 != 0)
		{
			Selection.Start = new Place(0, iLine);
			if (num2 > 0)
			{
				InsertText(new string(' ', num2));
			}
			else
			{
				Selection.Start = new Place(0, iLine);
				Selection.End = new Place(-num2, iLine);
				ClearSelected();
			}
			Selection.Start = new Place(Math.Min(lines[iLine].Count, Math.Max(0, start.iChar + num2)), iLine);
		}
	}

	public virtual int CalcAutoIndent(int iLine)
	{
		if (iLine < 0 || iLine >= LinesCount)
		{
			return 0;
		}
		EventHandler<AutoIndentEventArgs> eventHandler = this.AutoIndentNeeded;
		if (eventHandler == null)
		{
			eventHandler = ((Language == Language.Custom || SyntaxHighlighter == null) ? new EventHandler<AutoIndentEventArgs>(CalcAutoIndentShiftByCodeFolding) : new EventHandler<AutoIndentEventArgs>(SyntaxHighlighter.AutoIndentNeeded));
		}
		int num = 0;
		Stack<AutoIndentEventArgs> stack = new Stack<AutoIndentEventArgs>();
		int num2;
		for (num2 = iLine - 1; num2 >= 0; num2--)
		{
			AutoIndentEventArgs e = new AutoIndentEventArgs(num2, lines[num2].Text, (num2 > 0) ? lines[num2 - 1].Text : "", TabLength, 0);
			eventHandler(this, e);
			stack.Push(e);
			if (e.Shift == 0 && e.AbsoluteIndentation == 0 && e.LineText.Trim() != "")
			{
				break;
			}
		}
		int num3 = lines[(num2 >= 0) ? num2 : 0].StartSpacesCount;
		while (stack.Count != 0)
		{
			AutoIndentEventArgs e2 = stack.Pop();
			num3 = ((e2.AbsoluteIndentation == 0) ? (num3 + e2.ShiftNextLines) : (e2.AbsoluteIndentation + e2.ShiftNextLines));
		}
		AutoIndentEventArgs e3 = new AutoIndentEventArgs(iLine, lines[iLine].Text, (iLine > 0) ? lines[iLine - 1].Text : "", TabLength, num3);
		eventHandler(this, e3);
		return e3.AbsoluteIndentation + e3.Shift;
	}

	internal virtual void CalcAutoIndentShiftByCodeFolding(object sender, AutoIndentEventArgs args)
	{
		if (string.IsNullOrEmpty(lines[args.iLine].FoldingEndMarker) && !string.IsNullOrEmpty(lines[args.iLine].FoldingStartMarker))
		{
			args.ShiftNextLines = TabLength;
		}
		else if (!string.IsNullOrEmpty(lines[args.iLine].FoldingEndMarker) && string.IsNullOrEmpty(lines[args.iLine].FoldingStartMarker))
		{
			args.Shift = -TabLength;
			args.ShiftNextLines = -TabLength;
		}
	}

	protected int GetMinStartSpacesCount(int fromLine, int toLine)
	{
		if (fromLine > toLine)
		{
			return 0;
		}
		int num = int.MaxValue;
		for (int i = fromLine; i <= toLine; i++)
		{
			int startSpacesCount = lines[i].StartSpacesCount;
			if (startSpacesCount < num)
			{
				num = startSpacesCount;
			}
		}
		return num;
	}

	protected int GetMaxStartSpacesCount(int fromLine, int toLine)
	{
		if (fromLine > toLine)
		{
			return 0;
		}
		int num = 0;
		for (int i = fromLine; i <= toLine; i++)
		{
			int startSpacesCount = lines[i].StartSpacesCount;
			if (startSpacesCount > num)
			{
				num = startSpacesCount;
			}
		}
		return num;
	}

	public virtual void Undo()
	{
		lines.Manager.Undo();
		DoCaretVisible();
		Invalidate();
	}

	public virtual void Redo()
	{
		lines.Manager.Redo();
		DoCaretVisible();
		Invalidate();
	}

	protected override bool IsInputKey(Keys keyData)
	{
		if (keyData == Keys.Tab && !AcceptsTab)
		{
			return false;
		}
		if (keyData == Keys.Return && !AcceptsReturn)
		{
			return false;
		}
		if ((keyData & Keys.Alt) == 0)
		{
			Keys keys = keyData & Keys.KeyCode;
			if (keys == Keys.Return)
			{
				return true;
			}
		}
		if ((keyData & Keys.Alt) != Keys.Alt)
		{
			switch (keyData & Keys.KeyCode)
			{
			case Keys.Prior:
			case Keys.Next:
			case Keys.End:
			case Keys.Home:
			case Keys.Left:
			case Keys.Up:
			case Keys.Right:
			case Keys.Down:
				return true;
			case Keys.Escape:
				return false;
			case Keys.Tab:
				return (keyData & Keys.Control) == 0;
			}
		}
		return base.IsInputKey(keyData);
	}

	[DllImport("User32.dll")]
	private static extern bool CreateCaret(IntPtr hWnd, int hBitmap, int nWidth, int nHeight);

	[DllImport("User32.dll")]
	private static extern bool SetCaretPos(int x, int y);

	[DllImport("User32.dll")]
	private static extern bool DestroyCaret();

	[DllImport("User32.dll")]
	private static extern bool ShowCaret(IntPtr hWnd);

	[DllImport("User32.dll")]
	private static extern bool HideCaret(IntPtr hWnd);

	protected override void OnPaintBackground(PaintEventArgs e)
	{
		if (BackBrush == null)
		{
			base.OnPaintBackground(e);
		}
		else
		{
			e.Graphics.FillRectangle(BackBrush, base.ClientRectangle);
		}
	}

	public void DrawText(Graphics gr, Place start, Size size)
	{
		if (needRecalc)
		{
			Recalc();
		}
		if (needRecalcFoldingLines)
		{
			RecalcFoldingLines();
		}
		Point point = PlaceToPoint(start);
		int num = point.Y + base.VerticalScroll.Value;
		int num2 = point.X + base.HorizontalScroll.Value - LeftIndent - Paddings.Left;
		int iChar = start.iChar;
		int lastChar = (num2 + size.Width) / CharWidth;
		int iLine = start.iLine;
		for (int i = iLine; i < lines.Count; i++)
		{
			Line line = lines[i];
			LineInfo lineInfo = LineInfos[i];
			if (lineInfo.startY > num + size.Height)
			{
				break;
			}
			if (lineInfo.startY + lineInfo.WordWrapStringsCount * CharHeight >= num && lineInfo.VisibleState != VisibleState.Hidden)
			{
				int num3 = lineInfo.startY - num;
				gr.SmoothingMode = SmoothingMode.None;
				if (lineInfo.VisibleState == VisibleState.Visible && line.BackgroundBrush != null)
				{
					gr.FillRectangle(line.BackgroundBrush, new Rectangle(0, num3, size.Width, CharHeight * lineInfo.WordWrapStringsCount));
				}
				gr.SmoothingMode = SmoothingMode.AntiAlias;
				for (int j = 0; j < lineInfo.WordWrapStringsCount; j++)
				{
					num3 = lineInfo.startY + j * CharHeight - num;
					int num4 = ((j != 0) ? (lineInfo.wordWrapIndent * CharWidth) : 0);
					DrawLineChars(gr, iChar, lastChar, i, j, -num2 + num4, num3);
				}
			}
		}
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		if (needRecalc)
		{
			Recalc();
		}
		if (needRecalcFoldingLines)
		{
			RecalcFoldingLines();
		}
		visibleMarkers.Clear();
		e.Graphics.SmoothingMode = SmoothingMode.None;
		Pen pen = new Pen(ServiceLinesColor);
		Brush brush = new SolidBrush(ChangedLineColor);
		Brush brush2 = new SolidBrush(IndentBackColor);
		Brush brush3 = new SolidBrush(PaddingBackColor);
		Brush brush4 = new SolidBrush(Color.FromArgb((CurrentLineColor.A == byte.MaxValue) ? 50 : CurrentLineColor.A, CurrentLineColor));
		Rectangle textAreaRect = TextAreaRect;
		e.Graphics.FillRectangle(brush3, 0, -base.VerticalScroll.Value, base.ClientSize.Width, Math.Max(0, Paddings.Top - 1));
		e.Graphics.FillRectangle(brush3, 0, textAreaRect.Bottom, base.ClientSize.Width, base.ClientSize.Height);
		e.Graphics.FillRectangle(brush3, textAreaRect.Right, 0, base.ClientSize.Width, base.ClientSize.Height);
		e.Graphics.FillRectangle(brush3, LeftIndentLine, 0, LeftIndent - LeftIndentLine - 1, base.ClientSize.Height);
		if (base.HorizontalScroll.Value <= Paddings.Left)
		{
			e.Graphics.FillRectangle(brush3, LeftIndent - base.HorizontalScroll.Value - 2, 0, Math.Max(0, Paddings.Left - 1), base.ClientSize.Height);
		}
		int num = Math.Max(LeftIndent, LeftIndent + Paddings.Left - base.HorizontalScroll.Value);
		int num2 = textAreaRect.Width;
		e.Graphics.FillRectangle(brush2, 0, 0, LeftIndentLine, base.ClientSize.Height);
		if (LeftIndent > 8)
		{
			e.Graphics.DrawLine(pen, LeftIndentLine, 0, LeftIndentLine, base.ClientSize.Height);
		}
		if (PreferredLineWidth > 0)
		{
			e.Graphics.DrawLine(pen, new Point(LeftIndent + Paddings.Left + PreferredLineWidth * CharWidth - base.HorizontalScroll.Value + 1, textAreaRect.Top + 1), new Point(LeftIndent + Paddings.Left + PreferredLineWidth * CharWidth - base.HorizontalScroll.Value + 1, textAreaRect.Bottom - 1));
		}
		DrawTextAreaBorder(e.Graphics);
		int num3 = Math.Max(0, base.HorizontalScroll.Value - Paddings.Left) / CharWidth;
		int lastChar = (base.HorizontalScroll.Value + base.ClientSize.Width) / CharWidth;
		int num4 = LeftIndent + Paddings.Left - base.HorizontalScroll.Value;
		if (num4 < LeftIndent)
		{
			num3++;
		}
		Dictionary<int, Bookmark> dictionary = new Dictionary<int, Bookmark>();
		foreach (Bookmark bookmark in bookmarks)
		{
			dictionary[bookmark.LineIndex] = bookmark;
		}
		int num5 = YtoLineIndex(base.VerticalScroll.Value);
		e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
		int i;
		for (i = num5; i < lines.Count; i++)
		{
			Line line = lines[i];
			LineInfo lineInfo = LineInfos[i];
			if (lineInfo.startY > base.VerticalScroll.Value + base.ClientSize.Height)
			{
				break;
			}
			if (lineInfo.startY + lineInfo.WordWrapStringsCount * CharHeight < base.VerticalScroll.Value || lineInfo.VisibleState == VisibleState.Hidden)
			{
				continue;
			}
			int num6 = lineInfo.startY - base.VerticalScroll.Value;
			e.Graphics.SmoothingMode = SmoothingMode.None;
			if (lineInfo.VisibleState == VisibleState.Visible && line.BackgroundBrush != null)
			{
				e.Graphics.FillRectangle(line.BackgroundBrush, new Rectangle(textAreaRect.Left, num6, textAreaRect.Width, CharHeight * lineInfo.WordWrapStringsCount));
			}
			if (CurrentLineColor != Color.Transparent && i == Selection.Start.iLine && Selection.IsEmpty)
			{
				e.Graphics.FillRectangle(brush4, new Rectangle(textAreaRect.Left, num6, textAreaRect.Width, CharHeight));
			}
			if (ChangedLineColor != Color.Transparent && line.IsChanged)
			{
				e.Graphics.FillRectangle(brush, new RectangleF(-10f, num6, LeftIndent - 8 - 2 + 10, CharHeight + 1));
			}
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			if (dictionary.ContainsKey(i))
			{
				dictionary[i].Paint(e.Graphics, new Rectangle(LeftIndent, num6, base.Width, CharHeight * lineInfo.WordWrapStringsCount));
			}
			if (lineInfo.VisibleState == VisibleState.Visible)
			{
				OnPaintLine(new PaintLineEventArgs(i, new Rectangle(LeftIndent, num6, base.Width, CharHeight * lineInfo.WordWrapStringsCount), e.Graphics, e.ClipRectangle));
			}
			if (ShowLineNumbers)
			{
				using SolidBrush brush5 = new SolidBrush(LineNumberColor);
				e.Graphics.DrawString((i + lineNumberStartValue).ToString(), Font, brush5, new RectangleF(-10f, num6, LeftIndent - 8 - 2 + 10, CharHeight + (int)((float)lineInterval * 0.5f)), new StringFormat(StringFormatFlags.DirectionRightToLeft)
				{
					LineAlignment = StringAlignment.Center
				});
			}
			if (lineInfo.VisibleState == VisibleState.StartOfHiddenBlock)
			{
				visibleMarkers.Add(new ExpandFoldingMarker(i, new Rectangle(LeftIndentLine - 4, num6 + CharHeight / 2 - 3, 8, 8)));
			}
			if (!string.IsNullOrEmpty(line.FoldingStartMarker) && lineInfo.VisibleState == VisibleState.Visible && string.IsNullOrEmpty(line.FoldingEndMarker))
			{
				visibleMarkers.Add(new CollapseFoldingMarker(i, new Rectangle(LeftIndentLine - 4, num6 + CharHeight / 2 - 3, 8, 8)));
			}
			if (lineInfo.VisibleState == VisibleState.Visible && !string.IsNullOrEmpty(line.FoldingEndMarker) && string.IsNullOrEmpty(line.FoldingStartMarker))
			{
				e.Graphics.DrawLine(pen, LeftIndentLine, num6 + CharHeight * lineInfo.WordWrapStringsCount - 1, LeftIndentLine + 4, num6 + CharHeight * lineInfo.WordWrapStringsCount - 1);
			}
			for (int j = 0; j < lineInfo.WordWrapStringsCount; j++)
			{
				num6 = lineInfo.startY + j * CharHeight - base.VerticalScroll.Value;
				if (num6 > base.VerticalScroll.Value + base.ClientSize.Height)
				{
					break;
				}
				if (lineInfo.startY + j * CharHeight >= base.VerticalScroll.Value)
				{
					int num7 = ((j != 0) ? (lineInfo.wordWrapIndent * CharWidth) : 0);
					DrawLineChars(e.Graphics, num3, lastChar, i, j, num4 + num7, num6);
				}
			}
		}
		int endLine = i - 1;
		if (ShowFoldingLines)
		{
			DrawFoldingLines(e, num5, endLine);
		}
		if (Selection.ColumnSelectionMode && SelectionStyle.BackgroundBrush is SolidBrush)
		{
			Color color = ((SolidBrush)SelectionStyle.BackgroundBrush).Color;
			Point point = PlaceToPoint(Selection.Start);
			Point point2 = PlaceToPoint(Selection.End);
			using Pen pen2 = new Pen(color);
			e.Graphics.DrawRectangle(pen2, Rectangle.FromLTRB(Math.Min(point.X, point2.X) - 1, Math.Min(point.Y, point2.Y), Math.Max(point.X, point2.X), Math.Max(point.Y, point2.Y) + CharHeight));
		}
		if (BracketsStyle != null && leftBracketPosition != null && rightBracketPosition != null)
		{
			BracketsStyle.Draw(e.Graphics, PlaceToPoint(leftBracketPosition.Start), leftBracketPosition);
			BracketsStyle.Draw(e.Graphics, PlaceToPoint(rightBracketPosition.Start), rightBracketPosition);
		}
		if (BracketsStyle2 != null && leftBracketPosition2 != null && rightBracketPosition2 != null)
		{
			BracketsStyle2.Draw(e.Graphics, PlaceToPoint(leftBracketPosition2.Start), leftBracketPosition2);
			BracketsStyle2.Draw(e.Graphics, PlaceToPoint(rightBracketPosition2.Start), rightBracketPosition2);
		}
		e.Graphics.SmoothingMode = SmoothingMode.None;
		if ((startFoldingLine >= 0 || endFoldingLine >= 0) && Selection.Start == Selection.End && endFoldingLine < LineInfos.Count)
		{
			int y = ((startFoldingLine >= 0) ? LineInfos[startFoldingLine].startY : 0) - base.VerticalScroll.Value + CharHeight / 2;
			int y2 = ((endFoldingLine >= 0) ? (LineInfos[endFoldingLine].startY + (LineInfos[endFoldingLine].WordWrapStringsCount - 1) * CharHeight) : (TextHeight + CharHeight)) - base.VerticalScroll.Value + CharHeight;
			using Pen pen3 = new Pen(Color.FromArgb(100, FoldingIndicatorColor), 4f);
			e.Graphics.DrawLine(pen3, LeftIndent - 5, y, LeftIndent - 5, y2);
		}
		PaintHintBrackets(e.Graphics);
		DrawMarkers(e, pen);
		Point point3 = PlaceToPoint(Selection.Start);
		int num8 = CharHeight - lineInterval;
		point3.Offset(0, lineInterval / 2);
		if ((Focused || IsDragDrop || ShowCaretWhenInactive) && point3.X >= LeftIndent && CaretVisible)
		{
			int nWidth = ((!IsReplaceMode && !WideCaret) ? 1 : CharWidth);
			if (WideCaret)
			{
				using SolidBrush brush6 = new SolidBrush(CaretColor);
				e.Graphics.FillRectangle(brush6, point3.X, point3.Y, nWidth, num8 + 1);
			}
			else
			{
				using Pen pen4 = new Pen(CaretColor);
				e.Graphics.DrawLine(pen4, point3.X, point3.Y, point3.X, point3.Y + num8);
			}
			Rectangle rectangle = new Rectangle(base.HorizontalScroll.Value + point3.X, base.VerticalScroll.Value + point3.Y, nWidth, num8 + 1);
			if (CaretBlinking && (prevCaretRect != rectangle || !ShowScrollBars))
			{
				CreateCaret(base.Handle, 0, nWidth, num8 + 1);
				SetCaretPos(point3.X, point3.Y);
				ShowCaret(base.Handle);
			}
			prevCaretRect = rectangle;
		}
		else
		{
			HideCaret(base.Handle);
			prevCaretRect = Rectangle.Empty;
		}
		if (!base.Enabled)
		{
			using SolidBrush brush7 = new SolidBrush(DisabledColor);
			e.Graphics.FillRectangle(brush7, base.ClientRectangle);
		}
		if (MacrosManager.IsRecording)
		{
			DrawRecordingHint(e.Graphics);
		}
		if (middleClickScrollingActivated)
		{
			DrawMiddleClickScrolling(e.Graphics);
		}
		pen.Dispose();
		brush.Dispose();
		brush2.Dispose();
		brush4.Dispose();
		brush3.Dispose();
		base.OnPaint(e);
	}

	private void DrawMarkers(PaintEventArgs e, Pen servicePen)
	{
		foreach (VisualMarker visibleMarker in visibleMarkers)
		{
			if (visibleMarker is CollapseFoldingMarker)
			{
				using SolidBrush backgroundBrush = new SolidBrush(ServiceColors.CollapseMarkerBackColor);
				using Pen forePen = new Pen(ServiceColors.CollapseMarkerForeColor);
				using Pen pen = new Pen(ServiceColors.CollapseMarkerBorderColor);
				(visibleMarker as CollapseFoldingMarker).Draw(e.Graphics, pen, backgroundBrush, forePen);
			}
			else if (visibleMarker is ExpandFoldingMarker)
			{
				using SolidBrush backgroundBrush2 = new SolidBrush(ServiceColors.ExpandMarkerBackColor);
				using Pen forePen2 = new Pen(ServiceColors.ExpandMarkerForeColor);
				using Pen pen2 = new Pen(ServiceColors.ExpandMarkerBorderColor);
				(visibleMarker as ExpandFoldingMarker).Draw(e.Graphics, pen2, backgroundBrush2, forePen2);
			}
			else
			{
				visibleMarker.Draw(e.Graphics, servicePen);
			}
		}
	}

	private void DrawRecordingHint(Graphics graphics)
	{
		Rectangle rect = new Rectangle(base.ClientRectangle.Right - 75, base.ClientRectangle.Bottom - 13, 75, 13);
		Rectangle rect2 = new Rectangle(-3, -3, 6, 6);
		GraphicsState gstate = graphics.Save();
		graphics.SmoothingMode = SmoothingMode.HighQuality;
		graphics.TranslateTransform(rect.Left + 6, rect.Top + 6);
		TimeSpan timeSpan = new TimeSpan(DateTime.Now.Ticks);
		graphics.RotateTransform(180f * ((float)DateTime.Now.Millisecond / 1000f));
		using (Pen pen = new Pen(Color.Red, 2f))
		{
			graphics.DrawArc(pen, rect2, 0f, 90f);
			graphics.DrawArc(pen, rect2, 180f, 90f);
		}
		graphics.DrawEllipse(Pens.Red, rect2);
		graphics.Restore(gstate);
		using (Font font = new Font(FontFamily.GenericSansSerif, 8f))
		{
			graphics.DrawString("Recording...", font, Brushes.Red, new PointF(rect.Left + 13, rect.Top));
		}
		System.Threading.Timer tm = null;
		tm = new System.Threading.Timer(delegate
		{
			Invalidate(rect);
			tm.Dispose();
		}, null, 200, -1);
	}

	private void DrawTextAreaBorder(Graphics graphics)
	{
		if (TextAreaBorder == TextAreaBorderType.None)
		{
			return;
		}
		Rectangle textAreaRect = TextAreaRect;
		if (TextAreaBorder == TextAreaBorderType.Shadow)
		{
			Rectangle rect = new Rectangle(textAreaRect.Left + 4, textAreaRect.Bottom, textAreaRect.Width - 4, 4);
			Rectangle rect2 = new Rectangle(textAreaRect.Right, textAreaRect.Bottom, 4, 4);
			Rectangle rect3 = new Rectangle(textAreaRect.Right, textAreaRect.Top + 4, 4, textAreaRect.Height - 4);
			using SolidBrush brush = new SolidBrush(Color.FromArgb(80, TextAreaBorderColor));
			graphics.FillRectangle(brush, rect);
			graphics.FillRectangle(brush, rect3);
			graphics.FillRectangle(brush, rect2);
		}
		using Pen pen = new Pen(TextAreaBorderColor);
		graphics.DrawRectangle(pen, textAreaRect);
	}

	private void PaintHintBrackets(Graphics gr)
	{
		foreach (Hint hint in hints)
		{
			Range range = hint.Range.Clone();
			range.Normalize();
			Point point = PlaceToPoint(range.Start);
			Point point2 = PlaceToPoint(range.End);
			if (GetVisibleState(range.Start.iLine) != VisibleState.Visible || GetVisibleState(range.End.iLine) != VisibleState.Visible)
			{
				continue;
			}
			using Pen pen = new Pen(hint.BorderColor);
			pen.DashStyle = DashStyle.Dash;
			if (range.IsEmpty)
			{
				point.Offset(1, -1);
				gr.DrawLines(pen, new Point[2]
				{
					point,
					new Point(point.X, point.Y + charHeight + 2)
				});
				continue;
			}
			point.Offset(-1, -1);
			point2.Offset(1, -1);
			gr.DrawLines(pen, new Point[4]
			{
				new Point(point.X + CharWidth / 2, point.Y),
				point,
				new Point(point.X, point.Y + charHeight + 2),
				new Point(point.X + CharWidth / 2, point.Y + charHeight + 2)
			});
			gr.DrawLines(pen, new Point[4]
			{
				new Point(point2.X - CharWidth / 2, point2.Y),
				point2,
				new Point(point2.X, point2.Y + charHeight + 2),
				new Point(point2.X - CharWidth / 2, point2.Y + charHeight + 2)
			});
		}
	}

	protected virtual void DrawFoldingLines(PaintEventArgs e, int startLine, int endLine)
	{
		e.Graphics.SmoothingMode = SmoothingMode.None;
		using Pen pen = new Pen(Color.FromArgb(200, ServiceLinesColor))
		{
			DashStyle = DashStyle.Dot
		};
		foreach (KeyValuePair<int, int> foldingPair in foldingPairs)
		{
			if (foldingPair.Key >= endLine || foldingPair.Value <= startLine)
			{
				continue;
			}
			Line line = lines[foldingPair.Key];
			int num = LineInfos[foldingPair.Key].startY - base.VerticalScroll.Value + CharHeight;
			num += num % 2;
			int num2;
			if (foldingPair.Value >= LinesCount)
			{
				num2 = LineInfos[LinesCount - 1].startY + CharHeight - base.VerticalScroll.Value;
			}
			else
			{
				if (LineInfos[foldingPair.Value].VisibleState != VisibleState.Visible)
				{
					continue;
				}
				int num3 = 0;
				int startSpacesCount = line.StartSpacesCount;
				if (lines[foldingPair.Value].Count <= startSpacesCount || lines[foldingPair.Value][startSpacesCount].c == ' ')
				{
					num3 = CharHeight;
				}
				num2 = LineInfos[foldingPair.Value].startY - base.VerticalScroll.Value + num3;
			}
			int num4 = LeftIndent + Paddings.Left + line.StartSpacesCount * CharWidth - base.HorizontalScroll.Value;
			if (num4 >= LeftIndent + Paddings.Left)
			{
				e.Graphics.DrawLine(pen, num4, (num >= 0) ? num : 0, num4, (num2 < base.ClientSize.Height) ? num2 : base.ClientSize.Height);
			}
		}
	}

	private void DrawLineChars(Graphics gr, int firstChar, int lastChar, int iLine, int iWordWrapLine, int startX, int y)
	{
		Line line = lines[iLine];
		LineInfo lineInfo = LineInfos[iLine];
		int wordWrapStringStartPosition = lineInfo.GetWordWrapStringStartPosition(iWordWrapLine);
		int wordWrapStringFinishPosition = lineInfo.GetWordWrapStringFinishPosition(iWordWrapLine, line);
		lastChar = Math.Min(wordWrapStringFinishPosition - wordWrapStringStartPosition, lastChar);
		gr.SmoothingMode = SmoothingMode.AntiAlias;
		if (lineInfo.VisibleState == VisibleState.StartOfHiddenBlock)
		{
			FoldedBlockStyle.Draw(gr, new Point(startX + firstChar * CharWidth, y), new Range(this, wordWrapStringStartPosition + firstChar, iLine, wordWrapStringStartPosition + lastChar + 1, iLine));
		}
		else
		{
			StyleIndex styleIndex = StyleIndex.None;
			int num = firstChar - 1;
			for (int i = firstChar; i <= lastChar; i++)
			{
				StyleIndex style = line[wordWrapStringStartPosition + i].style;
				if (styleIndex != style)
				{
					FlushRendering(gr, styleIndex, new Point(startX + (num + 1) * CharWidth, y), new Range(this, wordWrapStringStartPosition + num + 1, iLine, wordWrapStringStartPosition + i, iLine));
					num = i - 1;
					styleIndex = style;
				}
			}
			FlushRendering(gr, styleIndex, new Point(startX + (num + 1) * CharWidth, y), new Range(this, wordWrapStringStartPosition + num + 1, iLine, wordWrapStringStartPosition + lastChar + 1, iLine));
		}
		if (SelectionHighlightingForLineBreaksEnabled && iWordWrapLine == lineInfo.WordWrapStringsCount - 1)
		{
			lastChar++;
		}
		if (!Selection.IsEmpty && lastChar >= firstChar)
		{
			gr.SmoothingMode = SmoothingMode.None;
			Range range = new Range(this, wordWrapStringStartPosition + firstChar, iLine, wordWrapStringStartPosition + lastChar + 1, iLine);
			range = Selection.GetIntersectionWith(range);
			if (range != null && SelectionStyle != null)
			{
				SelectionStyle.Draw(gr, new Point(startX + (range.Start.iChar - wordWrapStringStartPosition) * CharWidth, 1 + y), range);
			}
		}
	}

	private void FlushRendering(Graphics gr, StyleIndex styleIndex, Point pos, Range range)
	{
		if (!(range.End > range.Start))
		{
			return;
		}
		int num = 1;
		bool flag = false;
		for (int i = 0; i < Styles.Length; i++)
		{
			if (Styles[i] != null && ((uint)styleIndex & (uint)num) != 0)
			{
				Style style = Styles[i];
				bool flag2 = style is TextStyle;
				if (!flag || !flag2 || AllowSeveralTextStyleDrawing)
				{
					style.Draw(gr, pos, range);
				}
				flag = flag || flag2;
			}
			num <<= 1;
		}
		if (!flag)
		{
			DefaultStyle.Draw(gr, pos, range);
		}
	}

	protected override void OnEnter(EventArgs e)
	{
		base.OnEnter(e);
		mouseIsDrag = false;
		mouseIsDragDrop = false;
		draggedRange = null;
	}

	protected override void OnMouseUp(MouseEventArgs e)
	{
		base.OnMouseUp(e);
		isLineSelect = false;
		if (e.Button == MouseButtons.Left && mouseIsDragDrop)
		{
			OnMouseClickText(e);
		}
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		base.OnMouseDown(e);
		if (middleClickScrollingActivated)
		{
			DeactivateMiddleClickScrollingMode();
			mouseIsDrag = false;
			if (e.Button == MouseButtons.Middle)
			{
				RestoreScrollsAfterMiddleClickScrollingMode();
			}
			return;
		}
		MacrosManager.IsRecording = false;
		Select();
		base.ActiveControl = null;
		if (e.Button == MouseButtons.Left)
		{
			VisualMarker visualMarker = FindVisualMarkerForPoint(e.Location);
			if (visualMarker != null)
			{
				mouseIsDrag = false;
				mouseIsDragDrop = false;
				draggedRange = null;
				OnMarkerClick(e, visualMarker);
				return;
			}
			mouseIsDrag = true;
			mouseIsDragDrop = false;
			draggedRange = null;
			isLineSelect = e.Location.X < LeftIndentLine;
			if (!isLineSelect)
			{
				Place place = PointToPlace(e.Location);
				if (e.Clicks == 2)
				{
					mouseIsDrag = false;
					mouseIsDragDrop = false;
					draggedRange = null;
					SelectWord(place);
				}
				else if (Selection.IsEmpty || !Selection.Contains(place) || this[place.iLine].Count <= place.iChar || ReadOnly)
				{
					OnMouseClickText(e);
				}
				else
				{
					mouseIsDragDrop = true;
					mouseIsDrag = false;
				}
			}
			else
			{
				CheckAndChangeSelectionType();
				Selection.BeginUpdate();
				int iLine = (lineSelectFrom = PointToPlaceSimple(e.Location).iLine);
				Selection.Start = new Place(0, iLine);
				Selection.End = new Place(GetLineLength(iLine), iLine);
				Selection.EndUpdate();
				Invalidate();
			}
		}
		else if (e.Button == MouseButtons.Middle)
		{
			ActivateMiddleClickScrollingMode(e);
		}
	}

	private void OnMouseClickText(MouseEventArgs e)
	{
		Place end = Selection.End;
		Selection.BeginUpdate();
		if (Selection.ColumnSelectionMode)
		{
			Selection.Start = PointToPlaceSimple(e.Location);
			Selection.ColumnSelectionMode = true;
		}
		else if (VirtualSpace)
		{
			Selection.Start = PointToPlaceSimple(e.Location);
		}
		else
		{
			Selection.Start = PointToPlace(e.Location);
		}
		if ((lastModifiers & Keys.Shift) != Keys.None)
		{
			Selection.End = end;
		}
		CheckAndChangeSelectionType();
		Selection.EndUpdate();
		Invalidate();
	}

	protected virtual void CheckAndChangeSelectionType()
	{
		if ((Control.ModifierKeys & Keys.Alt) != Keys.None && !WordWrap)
		{
			Selection.ColumnSelectionMode = true;
		}
		else
		{
			Selection.ColumnSelectionMode = false;
		}
	}

	protected override void OnMouseWheel(MouseEventArgs e)
	{
		Invalidate();
		if (lastModifiers == Keys.Control)
		{
			ChangeFontSize(2 * Math.Sign(e.Delta));
			((HandledMouseEventArgs)e).Handled = true;
		}
		else if (base.VerticalScroll.Visible || !ShowScrollBars)
		{
			int controlPanelWheelScrollLinesValue = GetControlPanelWheelScrollLinesValue();
			DoScrollVertical(controlPanelWheelScrollLinesValue, e.Delta);
			((HandledMouseEventArgs)e).Handled = true;
		}
		DeactivateMiddleClickScrollingMode();
	}

	private void DoScrollVertical(int countLines, int direction)
	{
		if (base.VerticalScroll.Visible || !ShowScrollBars)
		{
			int num = base.ClientSize.Height / CharHeight;
			int num2 = ((countLines != -1 && countLines <= num) ? (CharHeight * countLines) : (CharHeight * num));
			int newValue = base.VerticalScroll.Value - Math.Sign(direction) * num2;
			ScrollEventArgs se = new ScrollEventArgs((direction <= 0) ? ScrollEventType.SmallIncrement : ScrollEventType.SmallDecrement, base.VerticalScroll.Value, newValue, ScrollOrientation.VerticalScroll);
			OnScroll(se);
		}
	}

	private static int GetControlPanelWheelScrollLinesValue()
	{
		try
		{
			using RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop", writable: false);
			return Convert.ToInt32(registryKey.GetValue("WheelScrollLines"));
		}
		catch
		{
			return 1;
		}
	}

	public void ChangeFontSize(int step)
	{
		float sizeInPoints = Font.SizeInPoints;
		using Graphics graphics = Graphics.FromHwnd(base.Handle);
		float dpiY = graphics.DpiY;
		float num = sizeInPoints + (float)step * 72f / dpiY;
		if (!(num < 1f))
		{
			float num2 = num / originalFont.SizeInPoints;
			Zoom = (int)(100f * num2);
		}
	}

	protected virtual void OnZoomChanged()
	{
		if (this.ZoomChanged != null)
		{
			this.ZoomChanged(this, EventArgs.Empty);
		}
	}

	private void DoZoom(float koeff)
	{
		int num = YtoLineIndex(base.VerticalScroll.Value);
		float sizeInPoints = originalFont.SizeInPoints;
		sizeInPoints *= koeff;
		if (!(sizeInPoints < 1f) && !(sizeInPoints > 300f))
		{
			Font font = Font;
			SetFont(new Font(Font.FontFamily, sizeInPoints, Font.Style, GraphicsUnit.Point));
			font.Dispose();
			NeedRecalc(forced: true);
			if (num < LinesCount)
			{
				base.VerticalScroll.Value = Math.Min(base.VerticalScroll.Maximum, LineInfos[num].startY - Paddings.Top);
			}
			UpdateScrollbars();
			Invalidate();
			OnVisibleRangeChanged();
		}
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		base.OnMouseLeave(e);
		CancelToolTip();
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		base.OnMouseMove(e);
		if (middleClickScrollingActivated)
		{
			return;
		}
		if (lastMouseCoord != e.Location)
		{
			CancelToolTip();
			timer3.Start();
		}
		lastMouseCoord = e.Location;
		if (e.Button == MouseButtons.Left && mouseIsDragDrop)
		{
			draggedRange = Selection.Clone();
			DoDragDrop(SelectedText, DragDropEffects.Copy);
			draggedRange = null;
			return;
		}
		if (e.Button == MouseButtons.Left && mouseIsDrag)
		{
			Place place = ((!Selection.ColumnSelectionMode && !VirtualSpace) ? PointToPlace(e.Location) : PointToPlaceSimple(e.Location));
			if (isLineSelect)
			{
				Selection.BeginUpdate();
				int iLine = place.iLine;
				if (iLine < lineSelectFrom)
				{
					Selection.Start = new Place(0, iLine);
					Selection.End = new Place(GetLineLength(lineSelectFrom), lineSelectFrom);
				}
				else
				{
					Selection.Start = new Place(GetLineLength(iLine), iLine);
					Selection.End = new Place(0, lineSelectFrom);
				}
				Selection.EndUpdate();
				DoCaretVisible();
				base.HorizontalScroll.Value = 0;
				UpdateScrollbars();
				Invalidate();
			}
			else if (place != Selection.Start)
			{
				Place end = Selection.End;
				Selection.BeginUpdate();
				if (Selection.ColumnSelectionMode)
				{
					Selection.Start = place;
					Selection.ColumnSelectionMode = true;
				}
				else
				{
					Selection.Start = place;
				}
				Selection.End = end;
				Selection.EndUpdate();
				DoCaretVisible();
				Invalidate();
				return;
			}
		}
		VisualMarker visualMarker = FindVisualMarkerForPoint(e.Location);
		if (visualMarker != null)
		{
			base.Cursor = visualMarker.Cursor;
		}
		else if (e.Location.X < LeftIndentLine || isLineSelect)
		{
			base.Cursor = Cursors.Arrow;
		}
		else
		{
			base.Cursor = defaultCursor;
		}
	}

	private void CancelToolTip()
	{
		timer3.Stop();
		if (ToolTip != null && !string.IsNullOrEmpty(ToolTip.GetToolTip(this)))
		{
			ToolTip.Hide(this);
			ToolTip.SetToolTip(this, null);
		}
	}

	protected override void OnMouseDoubleClick(MouseEventArgs e)
	{
		base.OnMouseDoubleClick(e);
		VisualMarker visualMarker = FindVisualMarkerForPoint(e.Location);
		if (visualMarker != null)
		{
			OnMarkerDoubleClick(visualMarker);
		}
	}

	private void SelectWord(Place p)
	{
		int iEndChar = p.iChar;
		int iStartChar = p.iChar;
		for (int i = p.iChar; i < lines[p.iLine].Count; i++)
		{
			char c = lines[p.iLine][i].c;
			if (char.IsLetterOrDigit(c) || c == '_')
			{
				iStartChar = i + 1;
				continue;
			}
			break;
		}
		int num = p.iChar - 1;
		while (num >= 0)
		{
			char c2 = lines[p.iLine][num].c;
			if (char.IsLetterOrDigit(c2) || c2 == '_')
			{
				iEndChar = num;
				num--;
				continue;
			}
			break;
		}
		Selection = new Range(this, iStartChar, p.iLine, iEndChar, p.iLine);
	}

	public int YtoLineIndex(int y)
	{
		int num = LineInfos.BinarySearch(new LineInfo(-10), new LineYComparer(y));
		num = ((num < 0) ? (-num - 2) : num);
		if (num < 0)
		{
			return 0;
		}
		if (num > lines.Count - 1)
		{
			return lines.Count - 1;
		}
		return num;
	}

	public Place PointToPlace(Point point)
	{
		point.Offset(base.HorizontalScroll.Value, base.VerticalScroll.Value);
		point.Offset(-LeftIndent - Paddings.Left, 0);
		int i = YtoLineIndex(point.Y);
		if (i < 0)
		{
			return Place.Empty;
		}
		int num = 0;
		for (; i < lines.Count; i++)
		{
			num = LineInfos[i].startY + LineInfos[i].WordWrapStringsCount * CharHeight;
			if (num > point.Y && LineInfos[i].VisibleState == VisibleState.Visible)
			{
				break;
			}
		}
		if (i >= lines.Count)
		{
			i = lines.Count - 1;
		}
		if (LineInfos[i].VisibleState != VisibleState.Visible)
		{
			i = FindPrevVisibleLine(i);
		}
		int num2 = LineInfos[i].WordWrapStringsCount;
		if (num > point.Y)
		{
			int num3 = (num - point.Y - CharHeight) / CharHeight;
			num -= num3 * CharHeight;
			num2 -= num3;
		}
		do
		{
			num2--;
			num -= CharHeight;
		}
		while (num > point.Y);
		if (num2 < 0)
		{
			num2 = 0;
		}
		int wordWrapStringStartPosition = LineInfos[i].GetWordWrapStringStartPosition(num2);
		int wordWrapStringFinishPosition = LineInfos[i].GetWordWrapStringFinishPosition(num2, lines[i]);
		int num4 = (int)Math.Round((float)point.X / (float)CharWidth);
		if (num2 > 0)
		{
			num4 -= LineInfos[i].wordWrapIndent;
		}
		num4 = ((num4 < 0) ? wordWrapStringStartPosition : (wordWrapStringStartPosition + num4));
		if (num4 > wordWrapStringFinishPosition)
		{
			num4 = wordWrapStringFinishPosition + 1;
		}
		if (num4 > lines[i].Count)
		{
			num4 = lines[i].Count;
		}
		return new Place(num4, i);
	}

	private Place PointToPlaceSimple(Point point)
	{
		point.Offset(base.HorizontalScroll.Value, base.VerticalScroll.Value);
		point.Offset(-LeftIndent - Paddings.Left, 0);
		int iLine = YtoLineIndex(point.Y);
		int num = (int)Math.Round((float)point.X / (float)CharWidth);
		if (num < 0)
		{
			num = 0;
		}
		return new Place(num, iLine);
	}

	public int PointToPosition(Point point)
	{
		return PlaceToPosition(PointToPlace(point));
	}

	public virtual void OnTextChanging(ref string text)
	{
		ClearBracketsPositions();
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

	public virtual void OnTextChanging()
	{
		string text = null;
		OnTextChanging(ref text);
	}

	public virtual void OnTextChanged()
	{
		Range range = new Range(this);
		range.SelectAll();
		OnTextChanged(new TextChangedEventArgs(range));
	}

	public virtual void OnTextChanged(int fromLine, int toLine)
	{
		Range range = new Range(this);
		range.Start = new Place(0, Math.Min(fromLine, toLine));
		range.End = new Place(lines[Math.Max(fromLine, toLine)].Count, Math.Max(fromLine, toLine));
		OnTextChanged(new TextChangedEventArgs(range));
	}

	public virtual void OnTextChanged(Range r)
	{
		OnTextChanged(new TextChangedEventArgs(r));
	}

	public void BeginUpdate()
	{
		if (updating == 0)
		{
			updatingRange = null;
		}
		updating++;
	}

	public void EndUpdate()
	{
		updating--;
		if (updating == 0 && updatingRange != null)
		{
			updatingRange.Expand();
			OnTextChanged(updatingRange);
		}
	}

	protected virtual void OnTextChanged(TextChangedEventArgs args)
	{
		args.ChangedRange.Normalize();
		if (updating > 0)
		{
			if (updatingRange == null)
			{
				updatingRange = args.ChangedRange.Clone();
				return;
			}
			if (updatingRange.Start.iLine > args.ChangedRange.Start.iLine)
			{
				updatingRange.Start = new Place(0, args.ChangedRange.Start.iLine);
			}
			if (updatingRange.End.iLine < args.ChangedRange.End.iLine)
			{
				updatingRange.End = new Place(lines[args.ChangedRange.End.iLine].Count, args.ChangedRange.End.iLine);
			}
			updatingRange = updatingRange.GetIntersectionWith(Range);
			return;
		}
		CancelToolTip();
		ClearHints();
		IsChanged = true;
		TextVersion++;
		MarkLinesAsChanged(args.ChangedRange);
		ClearFoldingState(args.ChangedRange);
		if (wordWrap)
		{
			RecalcWordWrap(args.ChangedRange.Start.iLine, args.ChangedRange.End.iLine);
		}
		base.OnTextChanged(args);
		if (delayedTextChangedRange == null)
		{
			delayedTextChangedRange = args.ChangedRange.Clone();
		}
		else
		{
			delayedTextChangedRange = delayedTextChangedRange.GetUnionWith(args.ChangedRange);
		}
		needRiseTextChangedDelayed = true;
		ResetTimer(timer2);
		OnSyntaxHighlight(args);
		if (this.TextChanged != null)
		{
			this.TextChanged(this, args);
		}
		if (this.BindingTextChanged != null)
		{
			this.BindingTextChanged(this, EventArgs.Empty);
		}
		base.OnTextChanged(EventArgs.Empty);
		OnVisibleRangeChanged();
	}

	private void ClearFoldingState(Range range)
	{
		for (int i = range.Start.iLine; i <= range.End.iLine; i++)
		{
			if (i >= 0 && i < lines.Count)
			{
				FoldedBlocks.Remove(this[i].UniqueId);
			}
		}
	}

	private void MarkLinesAsChanged(Range range)
	{
		for (int i = range.Start.iLine; i <= range.End.iLine; i++)
		{
			if (i >= 0 && i < lines.Count)
			{
				lines[i].IsChanged = true;
			}
		}
	}

	public virtual void OnSelectionChanged()
	{
		if (HighlightFoldingIndicator)
		{
			HighlightFoldings();
		}
		needRiseSelectionChangedDelayed = true;
		ResetTimer(timer);
		if (this.SelectionChanged != null)
		{
			this.SelectionChanged(this, new EventArgs());
		}
	}

	private void HighlightFoldings()
	{
		if (LinesCount == 0)
		{
			return;
		}
		int num = startFoldingLine;
		int num2 = endFoldingLine;
		startFoldingLine = -1;
		endFoldingLine = -1;
		int num3 = 0;
		for (int num4 = Selection.Start.iLine; num4 >= Math.Max(Selection.Start.iLine - 3000, 0); num4--)
		{
			bool flag = lines.LineHasFoldingStartMarker(num4);
			bool flag2 = lines.LineHasFoldingEndMarker(num4);
			if (!(flag2 && flag))
			{
				if (flag)
				{
					num3--;
					if (num3 == -1)
					{
						startFoldingLine = num4;
						break;
					}
				}
				if (flag2 && num4 != Selection.Start.iLine)
				{
					num3++;
				}
			}
		}
		if (startFoldingLine >= 0)
		{
			endFoldingLine = FindEndOfFoldingBlock(startFoldingLine, 3000);
			if (endFoldingLine == startFoldingLine)
			{
				endFoldingLine = -1;
			}
		}
		if (startFoldingLine != num || endFoldingLine != num2)
		{
			OnFoldingHighlightChanged();
		}
	}

	protected virtual void OnFoldingHighlightChanged()
	{
		if (this.FoldingHighlightChanged != null)
		{
			this.FoldingHighlightChanged(this, EventArgs.Empty);
		}
	}

	protected override void OnGotFocus(EventArgs e)
	{
		SetAsCurrentTB();
		base.OnGotFocus(e);
		Invalidate();
	}

	protected override void OnLostFocus(EventArgs e)
	{
		lastModifiers = Keys.None;
		DeactivateMiddleClickScrollingMode();
		base.OnLostFocus(e);
		Invalidate();
	}

	public int PlaceToPosition(Place point)
	{
		if (point.iLine < 0 || point.iLine >= lines.Count || point.iChar >= lines[point.iLine].Count + Environment.NewLine.Length)
		{
			return -1;
		}
		int num = 0;
		for (int i = 0; i < point.iLine; i++)
		{
			num += lines[i].Count + Environment.NewLine.Length;
		}
		return num + point.iChar;
	}

	public Place PositionToPlace(int pos)
	{
		if (pos < 0)
		{
			return new Place(0, 0);
		}
		for (int i = 0; i < lines.Count; i++)
		{
			int num = lines[i].Count + Environment.NewLine.Length;
			if (pos < lines[i].Count)
			{
				return new Place(pos, i);
			}
			if (pos < num)
			{
				return new Place(lines[i].Count, i);
			}
			pos -= num;
		}
		if (lines.Count > 0)
		{
			return new Place(lines[lines.Count - 1].Count, lines.Count - 1);
		}
		return new Place(0, 0);
	}

	public Point PositionToPoint(int pos)
	{
		return PlaceToPoint(PositionToPlace(pos));
	}

	public Point PlaceToPoint(Place place)
	{
		if (place.iLine >= LineInfos.Count)
		{
			return default(Point);
		}
		int startY = LineInfos[place.iLine].startY;
		int wordWrapStringIndex = LineInfos[place.iLine].GetWordWrapStringIndex(place.iChar);
		startY += wordWrapStringIndex * CharHeight;
		int num = (place.iChar - LineInfos[place.iLine].GetWordWrapStringStartPosition(wordWrapStringIndex)) * CharWidth;
		if (wordWrapStringIndex > 0)
		{
			num += LineInfos[place.iLine].wordWrapIndent * CharWidth;
		}
		startY -= base.VerticalScroll.Value;
		num = LeftIndent + Paddings.Left + num - base.HorizontalScroll.Value;
		return new Point(num, startY);
	}

	public Range GetRange(int fromPos, int toPos)
	{
		Range range = new Range(this);
		range.Start = PositionToPlace(fromPos);
		range.End = PositionToPlace(toPos);
		return range;
	}

	public Range GetRange(Place fromPlace, Place toPlace)
	{
		return new Range(this, fromPlace, toPlace);
	}

	public IEnumerable<Range> GetRanges(string regexPattern)
	{
		Range range = new Range(this);
		range.SelectAll();
		foreach (Range range2 in range.GetRanges(regexPattern, RegexOptions.None))
		{
			yield return range2;
		}
	}

	public IEnumerable<Range> GetRanges(string regexPattern, RegexOptions options)
	{
		Range range = new Range(this);
		range.SelectAll();
		foreach (Range range2 in range.GetRanges(regexPattern, options))
		{
			yield return range2;
		}
	}

	public string GetLineText(int iLine)
	{
		if (iLine < 0 || iLine >= lines.Count)
		{
			throw new ArgumentOutOfRangeException("Line index out of range");
		}
		StringBuilder stringBuilder = new StringBuilder(lines[iLine].Count);
		foreach (Char item in lines[iLine])
		{
			stringBuilder.Append(item.c);
		}
		return stringBuilder.ToString();
	}

	public virtual void ExpandFoldedBlock(int iLine)
	{
		if (iLine < 0 || iLine >= lines.Count)
		{
			throw new ArgumentOutOfRangeException("Line index out of range");
		}
		int i;
		for (i = iLine; i < LinesCount - 1 && LineInfos[i + 1].VisibleState == VisibleState.Hidden; i++)
		{
		}
		ExpandBlock(iLine, i);
		FoldedBlocks.Remove(this[iLine].UniqueId);
		AdjustFolding();
	}

	public virtual void AdjustFolding()
	{
		for (int i = 0; i < LinesCount; i++)
		{
			if (LineInfos[i].VisibleState == VisibleState.Visible && FoldedBlocks.ContainsKey(this[i].UniqueId))
			{
				CollapseFoldingBlock(i);
			}
		}
	}

	public virtual void ExpandBlock(int fromLine, int toLine)
	{
		int num = Math.Min(fromLine, toLine);
		int num2 = Math.Max(fromLine, toLine);
		for (int i = num; i <= num2; i++)
		{
			SetVisibleState(i, VisibleState.Visible);
		}
		needRecalc = true;
		Invalidate();
		OnVisibleRangeChanged();
	}

	public void ExpandBlock(int iLine)
	{
		if (LineInfos[iLine].VisibleState != VisibleState.Visible)
		{
			for (int i = iLine; i < LinesCount && LineInfos[i].VisibleState != VisibleState.Visible; i++)
			{
				SetVisibleState(i, VisibleState.Visible);
				needRecalc = true;
			}
			int num = iLine - 1;
			while (num >= 0 && LineInfos[num].VisibleState != VisibleState.Visible)
			{
				SetVisibleState(num, VisibleState.Visible);
				needRecalc = true;
				num--;
			}
			Invalidate();
			OnVisibleRangeChanged();
		}
	}

	public virtual void CollapseAllFoldingBlocks()
	{
		for (int i = 0; i < LinesCount; i++)
		{
			if (lines.LineHasFoldingStartMarker(i))
			{
				int num = FindEndOfFoldingBlock(i);
				if (num >= 0)
				{
					CollapseBlock(i, num);
					i = num;
				}
			}
		}
		OnVisibleRangeChanged();
		UpdateScrollbars();
	}

	public virtual void ExpandAllFoldingBlocks()
	{
		for (int i = 0; i < LinesCount; i++)
		{
			SetVisibleState(i, VisibleState.Visible);
		}
		FoldedBlocks.Clear();
		OnVisibleRangeChanged();
		Invalidate();
		UpdateScrollbars();
	}

	public virtual void CollapseFoldingBlock(int iLine)
	{
		if (iLine < 0 || iLine >= lines.Count)
		{
			throw new ArgumentOutOfRangeException("Line index out of range");
		}
		if (string.IsNullOrEmpty(lines[iLine].FoldingStartMarker))
		{
			throw new ArgumentOutOfRangeException("This line is not folding start line");
		}
		int num = FindEndOfFoldingBlock(iLine);
		if (num >= 0)
		{
			CollapseBlock(iLine, num);
			int uniqueId = this[iLine].UniqueId;
			FoldedBlocks[uniqueId] = uniqueId;
		}
	}

	private int FindEndOfFoldingBlock(int iStartLine)
	{
		return FindEndOfFoldingBlock(iStartLine, int.MaxValue);
	}

	protected virtual int FindEndOfFoldingBlock(int iStartLine, int maxLines)
	{
		string foldingStartMarker = lines[iStartLine].FoldingStartMarker;
		Stack<string> stack = new Stack<string>();
		switch (FindEndOfFoldingBlockStrategy)
		{
		case FindEndOfFoldingBlockStrategy.Strategy1:
		{
			for (int i = iStartLine; i < LinesCount; i++)
			{
				if (lines.LineHasFoldingStartMarker(i))
				{
					stack.Push(lines[i].FoldingStartMarker);
				}
				if (lines.LineHasFoldingEndMarker(i))
				{
					string foldingEndMarker2 = lines[i].FoldingEndMarker;
					while (stack.Count > 0 && stack.Pop() != foldingEndMarker2)
					{
					}
					if (stack.Count == 0)
					{
						return i;
					}
				}
				maxLines--;
				if (maxLines < 0)
				{
					return i;
				}
			}
			break;
		}
		case FindEndOfFoldingBlockStrategy.Strategy2:
		{
			for (int i = iStartLine; i < LinesCount; i++)
			{
				if (lines.LineHasFoldingEndMarker(i))
				{
					string foldingEndMarker = lines[i].FoldingEndMarker;
					while (stack.Count > 0 && stack.Pop() != foldingEndMarker)
					{
					}
					if (stack.Count == 0)
					{
						return i;
					}
				}
				if (lines.LineHasFoldingStartMarker(i))
				{
					stack.Push(lines[i].FoldingStartMarker);
				}
				maxLines--;
				if (maxLines < 0)
				{
					return i;
				}
			}
			break;
		}
		}
		return LinesCount - 1;
	}

	public string GetLineFoldingStartMarker(int iLine)
	{
		if (lines.LineHasFoldingStartMarker(iLine))
		{
			return lines[iLine].FoldingStartMarker;
		}
		return null;
	}

	public string GetLineFoldingEndMarker(int iLine)
	{
		if (lines.LineHasFoldingEndMarker(iLine))
		{
			return lines[iLine].FoldingEndMarker;
		}
		return null;
	}

	protected virtual void RecalcFoldingLines()
	{
		if (!needRecalcFoldingLines)
		{
			return;
		}
		needRecalcFoldingLines = false;
		if (!ShowFoldingLines)
		{
			return;
		}
		foldingPairs.Clear();
		Range range = VisibleRange;
		int num = Math.Max(range.Start.iLine - 3000, 0);
		int num2 = Math.Min(range.End.iLine + 3000, Math.Max(range.End.iLine, LinesCount - 1));
		Stack<int> stack = new Stack<int>();
		for (int i = num; i <= num2; i++)
		{
			bool flag = lines.LineHasFoldingStartMarker(i);
			bool flag2 = lines.LineHasFoldingEndMarker(i);
			if (flag2 && flag)
			{
				continue;
			}
			if (flag)
			{
				stack.Push(i);
			}
			if (!flag2)
			{
				continue;
			}
			string foldingEndMarker = lines[i].FoldingEndMarker;
			while (stack.Count > 0)
			{
				int num3 = stack.Pop();
				foldingPairs[num3] = i;
				if (foldingEndMarker == lines[num3].FoldingStartMarker)
				{
					break;
				}
			}
		}
		while (stack.Count > 0)
		{
			foldingPairs[stack.Pop()] = num2 + 1;
		}
	}

	public virtual void CollapseBlock(int fromLine, int toLine)
	{
		int i = Math.Min(fromLine, toLine);
		int num = Math.Max(fromLine, toLine);
		if (i == num)
		{
			return;
		}
		for (; i <= num; i++)
		{
			if (GetLineText(i).Trim().Length > 0)
			{
				for (int j = i + 1; j <= num; j++)
				{
					SetVisibleState(j, VisibleState.Hidden);
				}
				SetVisibleState(i, VisibleState.StartOfHiddenBlock);
				Invalidate();
				break;
			}
		}
		i = Math.Min(fromLine, toLine);
		num = Math.Max(fromLine, toLine);
		int num2 = FindNextVisibleLine(num);
		if (num2 == num)
		{
			num2 = FindPrevVisibleLine(i);
		}
		Selection.Start = new Place(0, num2);
		needRecalc = true;
		Invalidate();
		OnVisibleRangeChanged();
	}

	internal int FindNextVisibleLine(int iLine)
	{
		if (iLine >= lines.Count - 1)
		{
			return iLine;
		}
		int result = iLine;
		do
		{
			iLine++;
		}
		while (iLine < lines.Count - 1 && LineInfos[iLine].VisibleState != VisibleState.Visible);
		if (LineInfos[iLine].VisibleState != VisibleState.Visible)
		{
			return result;
		}
		return iLine;
	}

	internal int FindPrevVisibleLine(int iLine)
	{
		if (iLine <= 0)
		{
			return iLine;
		}
		int result = iLine;
		do
		{
			iLine--;
		}
		while (iLine > 0 && LineInfos[iLine].VisibleState != VisibleState.Visible);
		if (LineInfos[iLine].VisibleState != VisibleState.Visible)
		{
			return result;
		}
		return iLine;
	}

	private VisualMarker FindVisualMarkerForPoint(Point p)
	{
		foreach (VisualMarker visibleMarker in visibleMarkers)
		{
			if (visibleMarker.rectangle.Contains(p))
			{
				return visibleMarker;
			}
		}
		return null;
	}

	public virtual void IncreaseIndent()
	{
		if (Selection.Start == Selection.End)
		{
			if (Selection.ReadOnly)
			{
				return;
			}
			Selection.Start = new Place(this[Selection.Start.iLine].StartSpacesCount, Selection.Start.iLine);
			int num = TabLength - Selection.Start.iChar % TabLength;
			if (IsReplaceMode)
			{
				for (int i = 0; i < num; i++)
				{
					Selection.GoRight(shift: true);
				}
				Selection.Inverse();
			}
			InsertText(new string(' ', num));
			return;
		}
		bool flag = Selection.Start > Selection.End && !Selection.ColumnSelectionMode;
		int iChar = 0;
		if (Selection.ColumnSelectionMode)
		{
			iChar = Math.Min(Selection.End.iChar, Selection.Start.iChar);
		}
		BeginUpdate();
		Selection.BeginUpdate();
		lines.Manager.BeginAutoUndoCommands();
		Range range = Selection.Clone();
		lines.Manager.ExecuteCommand(new SelectCommand(TextSource));
		Selection.Normalize();
		Range range2 = Selection.Clone();
		int iLine = Selection.Start.iLine;
		int num2 = Selection.End.iLine;
		if (!Selection.ColumnSelectionMode && Selection.End.iChar == 0)
		{
			num2--;
		}
		for (int j = iLine; j <= num2; j++)
		{
			if (lines[j].Count != 0)
			{
				Selection.Start = new Place(iChar, j);
				lines.Manager.ExecuteCommand(new InsertTextCommand(TextSource, new string(' ', TabLength)));
			}
		}
		if (!Selection.ColumnSelectionMode)
		{
			int iChar2 = range2.Start.iChar + TabLength;
			int iChar3 = range2.End.iChar + ((range2.End.iLine == num2) ? TabLength : 0);
			Selection.Start = new Place(iChar2, range2.Start.iLine);
			Selection.End = new Place(iChar3, range2.End.iLine);
		}
		else
		{
			Selection = range;
		}
		lines.Manager.EndAutoUndoCommands();
		if (flag)
		{
			Selection.Inverse();
		}
		needRecalc = true;
		Selection.EndUpdate();
		EndUpdate();
		Invalidate();
	}

	public virtual void DecreaseIndent()
	{
		if (Selection.Start.iLine == Selection.End.iLine)
		{
			DecreaseIndentOfSingleLine();
			return;
		}
		int num = 0;
		if (Selection.ColumnSelectionMode)
		{
			num = Math.Min(Selection.End.iChar, Selection.Start.iChar);
		}
		BeginUpdate();
		Selection.BeginUpdate();
		lines.Manager.BeginAutoUndoCommands();
		Range range = Selection.Clone();
		lines.Manager.ExecuteCommand(new SelectCommand(TextSource));
		Range range2 = Selection.Clone();
		Selection.Normalize();
		int iLine = Selection.Start.iLine;
		int num2 = Selection.End.iLine;
		if (!Selection.ColumnSelectionMode && Selection.End.iChar == 0)
		{
			num2--;
		}
		int num3 = 0;
		int num4 = 0;
		for (int i = iLine; i <= num2; i++)
		{
			if (num <= lines[i].Count)
			{
				int num5 = Math.Min(lines[i].Count, num + TabLength);
				string text = lines[i].Text.Substring(num, num5 - num);
				num5 = Math.Min(num5, num + text.Length - text.TrimStart().Length);
				Selection = new Range(this, new Place(num, i), new Place(num5, i));
				int num6 = num5 - num;
				if (i == range2.Start.iLine)
				{
					num3 = num6;
				}
				if (i == range2.End.iLine)
				{
					num4 = num6;
				}
				if (!Selection.IsEmpty)
				{
					ClearSelected();
				}
			}
		}
		if (!Selection.ColumnSelectionMode)
		{
			int iChar = Math.Max(0, range2.Start.iChar - num3);
			int iChar2 = Math.Max(0, range2.End.iChar - num4);
			Selection.Start = new Place(iChar, range2.Start.iLine);
			Selection.End = new Place(iChar2, range2.End.iLine);
		}
		else
		{
			Selection = range;
		}
		lines.Manager.EndAutoUndoCommands();
		needRecalc = true;
		Selection.EndUpdate();
		EndUpdate();
		Invalidate();
	}

	protected virtual void DecreaseIndentOfSingleLine()
	{
		if (Selection.Start.iLine == Selection.End.iLine)
		{
			Range range = Selection.Clone();
			int iLine = Selection.Start.iLine;
			int num = Math.Min(Selection.Start.iChar, Selection.End.iChar);
			string input = lines[iLine].Text;
			Match match = new Regex("\\s*", RegexOptions.RightToLeft).Match(input, num);
			int index = match.Index;
			int length = match.Length;
			int num2 = 0;
			if (length > 0)
			{
				int num3 = ((TabLength > 0) ? (num % TabLength) : 0);
				num2 = ((num3 != 0) ? Math.Min(num3, length) : Math.Min(TabLength, length));
			}
			if (num2 > 0)
			{
				BeginUpdate();
				Selection.BeginUpdate();
				lines.Manager.BeginAutoUndoCommands();
				lines.Manager.ExecuteCommand(new SelectCommand(TextSource));
				Selection.Start = new Place(index, iLine);
				Selection.End = new Place(index + num2, iLine);
				ClearSelected();
				int iChar = range.Start.iChar - num2;
				int iChar2 = range.End.iChar - num2;
				Selection.Start = new Place(iChar, iLine);
				Selection.End = new Place(iChar2, iLine);
				lines.Manager.ExecuteCommand(new SelectCommand(TextSource));
				lines.Manager.EndAutoUndoCommands();
				Selection.EndUpdate();
				EndUpdate();
			}
			Invalidate();
		}
	}

	public virtual void DoAutoIndent()
	{
		if (!Selection.ColumnSelectionMode)
		{
			Range range = Selection.Clone();
			range.Normalize();
			BeginUpdate();
			Selection.BeginUpdate();
			lines.Manager.BeginAutoUndoCommands();
			for (int i = range.Start.iLine; i <= range.End.iLine; i++)
			{
				DoAutoIndent(i);
			}
			lines.Manager.EndAutoUndoCommands();
			Selection.Start = range.Start;
			Selection.End = range.End;
			Selection.Expand();
			Selection.EndUpdate();
			EndUpdate();
		}
	}

	public virtual void InsertLinePrefix(string prefix)
	{
		Range range = Selection.Clone();
		int num = Math.Min(Selection.Start.iLine, Selection.End.iLine);
		int num2 = Math.Max(Selection.Start.iLine, Selection.End.iLine);
		BeginUpdate();
		Selection.BeginUpdate();
		lines.Manager.BeginAutoUndoCommands();
		lines.Manager.ExecuteCommand(new SelectCommand(TextSource));
		int minStartSpacesCount = GetMinStartSpacesCount(num, num2);
		for (int i = num; i <= num2; i++)
		{
			Selection.Start = new Place(minStartSpacesCount, i);
			lines.Manager.ExecuteCommand(new InsertTextCommand(TextSource, prefix));
		}
		Selection.Start = new Place(0, num);
		Selection.End = new Place(lines[num2].Count, num2);
		needRecalc = true;
		lines.Manager.EndAutoUndoCommands();
		Selection.EndUpdate();
		EndUpdate();
		Invalidate();
	}

	public virtual void RemoveLinePrefix(string prefix)
	{
		Range range = Selection.Clone();
		int num = Math.Min(Selection.Start.iLine, Selection.End.iLine);
		int num2 = Math.Max(Selection.Start.iLine, Selection.End.iLine);
		BeginUpdate();
		Selection.BeginUpdate();
		lines.Manager.BeginAutoUndoCommands();
		lines.Manager.ExecuteCommand(new SelectCommand(TextSource));
		for (int i = num; i <= num2; i++)
		{
			string text = lines[i].Text;
			string text2 = text.TrimStart();
			if (text2.StartsWith(prefix))
			{
				int num3 = text.Length - text2.Length;
				Selection.Start = new Place(num3, i);
				Selection.End = new Place(num3 + prefix.Length, i);
				ClearSelected();
			}
		}
		Selection.Start = new Place(0, num);
		Selection.End = new Place(lines[num2].Count, num2);
		needRecalc = true;
		lines.Manager.EndAutoUndoCommands();
		Selection.EndUpdate();
		EndUpdate();
	}

	public void BeginAutoUndo()
	{
		lines.Manager.BeginAutoUndoCommands();
	}

	public void EndAutoUndo()
	{
		lines.Manager.EndAutoUndoCommands();
	}

	public virtual void OnVisualMarkerClick(MouseEventArgs args, StyleVisualMarker marker)
	{
		if (this.VisualMarkerClick != null)
		{
			this.VisualMarkerClick(this, new VisualMarkerEventArgs(marker.Style, marker, args));
		}
		marker.Style.OnVisualMarkerClick(this, new VisualMarkerEventArgs(marker.Style, marker, args));
	}

	protected virtual void OnMarkerClick(MouseEventArgs args, VisualMarker marker)
	{
		if (marker is StyleVisualMarker)
		{
			OnVisualMarkerClick(args, marker as StyleVisualMarker);
		}
		else if (marker is CollapseFoldingMarker)
		{
			CollapseFoldingBlock((marker as CollapseFoldingMarker).iLine);
		}
		else if (marker is ExpandFoldingMarker)
		{
			ExpandFoldedBlock((marker as ExpandFoldingMarker).iLine);
		}
		else if (marker is FoldedAreaMarker)
		{
			int iLine = (marker as FoldedAreaMarker).iLine;
			int num = FindEndOfFoldingBlock(iLine);
			if (num >= 0)
			{
				Selection.BeginUpdate();
				Selection.Start = new Place(0, iLine);
				Selection.End = new Place(lines[num].Count, num);
				Selection.EndUpdate();
				Invalidate();
			}
		}
	}

	protected virtual void OnMarkerDoubleClick(VisualMarker marker)
	{
		if (marker is FoldedAreaMarker)
		{
			ExpandFoldedBlock((marker as FoldedAreaMarker).iLine);
			Invalidate();
		}
	}

	private void ClearBracketsPositions()
	{
		leftBracketPosition = null;
		rightBracketPosition = null;
		leftBracketPosition2 = null;
		rightBracketPosition2 = null;
	}

	private void HighlightBrackets(char LeftBracket, char RightBracket, ref Range leftBracketPosition, ref Range rightBracketPosition)
	{
		switch (BracketsHighlightStrategy)
		{
		case BracketsHighlightStrategy.Strategy1:
			HighlightBrackets1(LeftBracket, RightBracket, ref leftBracketPosition, ref rightBracketPosition);
			break;
		case BracketsHighlightStrategy.Strategy2:
			HighlightBrackets2(LeftBracket, RightBracket, ref leftBracketPosition, ref rightBracketPosition);
			break;
		}
	}

	private void HighlightBrackets1(char LeftBracket, char RightBracket, ref Range leftBracketPosition, ref Range rightBracketPosition)
	{
		if (Selection.IsEmpty && LinesCount != 0)
		{
			Range range = leftBracketPosition;
			Range range2 = rightBracketPosition;
			Range bracketsRange = GetBracketsRange(Selection.Start, LeftBracket, RightBracket, includeBrackets: true);
			if (bracketsRange != null)
			{
				leftBracketPosition = new Range(this, bracketsRange.Start, new Place(bracketsRange.Start.iChar + 1, bracketsRange.Start.iLine));
				rightBracketPosition = new Range(this, new Place(bracketsRange.End.iChar - 1, bracketsRange.End.iLine), bracketsRange.End);
			}
			if (range != leftBracketPosition || range2 != rightBracketPosition)
			{
				Invalidate();
			}
		}
	}

	public Range GetBracketsRange(Place placeInsideBrackets, char leftBracket, char rightBracket, bool includeBrackets)
	{
		Range range = new Range(this, placeInsideBrackets, placeInsideBrackets);
		Range range2 = range.Clone();
		Range range3 = null;
		Range range4 = null;
		int num = 0;
		int num2 = 1000;
		while (range2.GoLeftThroughFolded())
		{
			if (range2.CharAfterStart == leftBracket)
			{
				num++;
			}
			if (range2.CharAfterStart == rightBracket)
			{
				num--;
			}
			if (num == 1)
			{
				range2.Start = new Place(range2.Start.iChar + ((!includeBrackets) ? 1 : 0), range2.Start.iLine);
				range3 = range2;
				break;
			}
			num2--;
			if (num2 <= 0)
			{
				break;
			}
		}
		range2 = range.Clone();
		num = 0;
		num2 = 1000;
		do
		{
			if (range2.CharAfterStart == leftBracket)
			{
				num++;
			}
			if (range2.CharAfterStart == rightBracket)
			{
				num--;
			}
			if (num == -1)
			{
				range2.End = new Place(range2.Start.iChar + (includeBrackets ? 1 : 0), range2.Start.iLine);
				range4 = range2;
				break;
			}
			num2--;
		}
		while (num2 > 0 && range2.GoRightThroughFolded());
		if (range3 != null && range4 != null)
		{
			return new Range(this, range3.Start, range4.End);
		}
		return null;
	}

	private void HighlightBrackets2(char LeftBracket, char RightBracket, ref Range leftBracketPosition, ref Range rightBracketPosition)
	{
		if (!Selection.IsEmpty || LinesCount == 0)
		{
			return;
		}
		Range range = leftBracketPosition;
		Range range2 = rightBracketPosition;
		Range range3 = Selection.Clone();
		bool flag = false;
		int num = 0;
		int num2 = 1000;
		if (range3.CharBeforeStart == RightBracket)
		{
			rightBracketPosition = new Range(this, range3.Start.iChar - 1, range3.Start.iLine, range3.Start.iChar, range3.Start.iLine);
			while (range3.GoLeftThroughFolded())
			{
				if (range3.CharAfterStart == LeftBracket)
				{
					num++;
				}
				if (range3.CharAfterStart == RightBracket)
				{
					num--;
				}
				if (num == 0)
				{
					range3.End = new Place(range3.Start.iChar + 1, range3.Start.iLine);
					leftBracketPosition = range3;
					flag = true;
					break;
				}
				num2--;
				if (num2 <= 0)
				{
					break;
				}
			}
		}
		range3 = Selection.Clone();
		num = 0;
		num2 = 1000;
		if (!flag && range3.CharAfterStart == LeftBracket)
		{
			leftBracketPosition = new Range(this, range3.Start.iChar, range3.Start.iLine, range3.Start.iChar + 1, range3.Start.iLine);
			do
			{
				if (range3.CharAfterStart == LeftBracket)
				{
					num++;
				}
				if (range3.CharAfterStart == RightBracket)
				{
					num--;
				}
				if (num == 0)
				{
					range3.End = new Place(range3.Start.iChar + 1, range3.Start.iLine);
					rightBracketPosition = range3;
					flag = true;
					break;
				}
				num2--;
			}
			while (num2 > 0 && range3.GoRightThroughFolded());
		}
		if (range != leftBracketPosition || range2 != rightBracketPosition)
		{
			Invalidate();
		}
	}

	public bool SelectNext(string regexPattern, bool backward = false, RegexOptions options = RegexOptions.None)
	{
		Range range = Selection.Clone();
		range.Normalize();
		Range range2 = (backward ? new Range(this, Range.Start, range.Start) : new Range(this, range.End, Range.End));
		Range range3 = null;
		foreach (Range range4 in range2.GetRanges(regexPattern, options))
		{
			range3 = range4;
			if (!backward)
			{
				break;
			}
		}
		if (range3 == null)
		{
			return false;
		}
		Selection = range3;
		Invalidate();
		return true;
	}

	public virtual void OnSyntaxHighlight(TextChangedEventArgs args)
	{
		Range range = HighlightingRangeType switch
		{
			HighlightingRangeType.VisibleRange => VisibleRange.GetUnionWith(args.ChangedRange), 
			HighlightingRangeType.AllTextRange => Range, 
			_ => args.ChangedRange, 
		};
		if (SyntaxHighlighter != null)
		{
			if (Language == Language.Custom && !string.IsNullOrEmpty(DescriptionFile))
			{
				SyntaxHighlighter.HighlightSyntax(DescriptionFile, range);
			}
			else
			{
				SyntaxHighlighter.HighlightSyntax(Language, range);
			}
		}
	}

	private void InitializeComponent()
	{
		base.SuspendLayout();
		base.Name = "FastColoredTextBox";
		base.ResumeLayout(false);
	}

	public virtual void Print(Range range, PrintDialogSettings settings)
	{
		ExportToHTML exportToHTML = new ExportToHTML();
		exportToHTML.UseBr = true;
		exportToHTML.UseForwardNbsp = true;
		exportToHTML.UseNbsp = true;
		exportToHTML.UseStyleTag = false;
		exportToHTML.IncludeLineNumbers = settings.IncludeLineNumbers;
		if (range == null)
		{
			range = Range;
		}
		if (range.Text == string.Empty)
		{
			return;
		}
		visibleRange = range;
		try
		{
			if (this.VisibleRangeChanged != null)
			{
				this.VisibleRangeChanged(this, new EventArgs());
			}
			if (this.VisibleRangeChangedDelayed != null)
			{
				this.VisibleRangeChangedDelayed(this, new EventArgs());
			}
		}
		finally
		{
			visibleRange = null;
		}
		string html = exportToHTML.GetHtml(range);
		html = "<META HTTP-EQUIV=\"Content-Type\" CONTENT=\"text/html; charset=UTF-8\"><head><title>" + PrepareHtmlText(settings.Title) + "</title></head>" + html + "<br>" + SelectHTMLRangeScript();
		string text = Path.GetTempPath() + "fctb.html";
		File.WriteAllText(text, html);
		SetPageSetupSettings(settings);
		WebBrowser webBrowser = new WebBrowser();
		webBrowser.Tag = settings;
		webBrowser.Visible = false;
		webBrowser.Location = new Point(-1000, -1000);
		webBrowser.Parent = this;
		webBrowser.StatusTextChanged += wb_StatusTextChanged;
		webBrowser.Navigate(text);
	}

	protected virtual string PrepareHtmlText(string s)
	{
		return s.Replace("<", "&lt;").Replace(">", "&gt;").Replace("&", "&amp;");
	}

	private void wb_StatusTextChanged(object sender, EventArgs e)
	{
		WebBrowser webBrowser = sender as WebBrowser;
		if (!webBrowser.StatusText.Contains("#print"))
		{
			return;
		}
		PrintDialogSettings printDialogSettings = webBrowser.Tag as PrintDialogSettings;
		try
		{
			if (printDialogSettings.ShowPrintPreviewDialog)
			{
				webBrowser.ShowPrintPreviewDialog();
				return;
			}
			if (printDialogSettings.ShowPageSetupDialog)
			{
				webBrowser.ShowPageSetupDialog();
			}
			if (printDialogSettings.ShowPrintDialog)
			{
				webBrowser.ShowPrintDialog();
			}
			else
			{
				webBrowser.Print();
			}
		}
		finally
		{
			webBrowser.Parent = null;
			webBrowser.Dispose();
		}
	}

	public void Print(PrintDialogSettings settings)
	{
		Print(Range, settings);
	}

	public void Print()
	{
		Print(Range, new PrintDialogSettings
		{
			ShowPageSetupDialog = false,
			ShowPrintDialog = false,
			ShowPrintPreviewDialog = false
		});
	}

	private string SelectHTMLRangeScript()
	{
		Range range = Selection.Clone();
		range.Normalize();
		int num = PlaceToPosition(range.Start) - range.Start.iLine;
		int num2 = range.Text.Length - (range.End.iLine - range.Start.iLine);
		return $"<script type=\"text/javascript\">\r\ntry{{\r\n    var sel = document.selection;\r\n    var rng = sel.createRange();\r\n    rng.moveStart(\"character\", {num});\r\n    rng.moveEnd(\"character\", {num2});\r\n    rng.select();\r\n}}catch(ex){{}}\r\nwindow.status = \"#print\";\r\n</script>";
	}

	private static void SetPageSetupSettings(PrintDialogSettings settings)
	{
		RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Internet Explorer\\PageSetup", writable: true);
		if (registryKey != null)
		{
			registryKey.SetValue("footer", settings.Footer);
			registryKey.SetValue("header", settings.Header);
		}
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
		if (disposing)
		{
			if (SyntaxHighlighter != null)
			{
				SyntaxHighlighter.Dispose();
			}
			timer.Dispose();
			timer2.Dispose();
			middleClickScrollingTimer.Dispose();
			if (findForm != null)
			{
				findForm.Dispose();
			}
			if (replaceForm != null)
			{
				replaceForm.Dispose();
			}
			if (TextSource != null)
			{
				TextSource.Dispose();
			}
			if (ToolTip != null)
			{
				ToolTip.Dispose();
			}
		}
	}

	protected virtual void OnPaintLine(PaintLineEventArgs e)
	{
		if (this.PaintLine != null)
		{
			this.PaintLine(this, e);
		}
	}

	internal void OnLineInserted(int index)
	{
		OnLineInserted(index, 1);
	}

	internal void OnLineInserted(int index, int count)
	{
		if (this.LineInserted != null)
		{
			this.LineInserted(this, new LineInsertedEventArgs(index, count));
		}
	}

	internal void OnLineRemoved(int index, int count, List<int> removedLineIds)
	{
		if (count > 0 && this.LineRemoved != null)
		{
			this.LineRemoved(this, new LineRemovedEventArgs(index, count, removedLineIds));
		}
	}

	public void OpenFile(string fileName, Encoding enc)
	{
		TextSource ts = CreateTextSource();
		try
		{
			InitTextSource(ts);
			Text = File.ReadAllText(fileName, enc);
			ClearUndo();
			IsChanged = false;
			OnVisibleRangeChanged();
		}
		catch
		{
			InitTextSource(CreateTextSource());
			lines.InsertLine(0, TextSource.CreateLine());
			IsChanged = false;
			throw;
		}
		Selection.Start = Place.Empty;
		DoSelectionVisible();
	}

	public void OpenFile(string fileName)
	{
		try
		{
			Encoding encoding = EncodingDetector.DetectTextFileEncoding(fileName);
			if (encoding != null)
			{
				OpenFile(fileName, encoding);
			}
			else
			{
				OpenFile(fileName, Encoding.Default);
			}
		}
		catch
		{
			InitTextSource(CreateTextSource());
			lines.InsertLine(0, TextSource.CreateLine());
			IsChanged = false;
			throw;
		}
	}

	public void OpenBindingFile(string fileName, Encoding enc)
	{
		FileTextSource fileTextSource = new FileTextSource(this);
		try
		{
			InitTextSource(fileTextSource);
			fileTextSource.OpenFile(fileName, enc);
			IsChanged = false;
			OnVisibleRangeChanged();
		}
		catch
		{
			fileTextSource.CloseFile();
			InitTextSource(CreateTextSource());
			lines.InsertLine(0, TextSource.CreateLine());
			IsChanged = false;
			throw;
		}
		Invalidate();
	}

	public void CloseBindingFile()
	{
		if (lines is FileTextSource)
		{
			FileTextSource fileTextSource = lines as FileTextSource;
			fileTextSource.CloseFile();
			InitTextSource(CreateTextSource());
			lines.InsertLine(0, TextSource.CreateLine());
			IsChanged = false;
			Invalidate();
		}
	}

	public void SaveToFile(string fileName, Encoding enc)
	{
		lines.SaveToFile(fileName, enc);
		IsChanged = false;
		OnVisibleRangeChanged();
		UpdateScrollbars();
	}

	public void SetVisibleState(int iLine, VisibleState state)
	{
		LineInfo value = LineInfos[iLine];
		value.VisibleState = state;
		LineInfos[iLine] = value;
		needRecalc = true;
	}

	public VisibleState GetVisibleState(int iLine)
	{
		return LineInfos[iLine].VisibleState;
	}

	public void ShowGoToDialog()
	{
		GoToForm goToForm = new GoToForm();
		goToForm.TotalLineCount = LinesCount;
		goToForm.SelectedLineNumber = Selection.Start.iLine + 1;
		if (goToForm.ShowDialog() == DialogResult.OK)
		{
			int num = Math.Min(LinesCount - 1, Math.Max(0, goToForm.SelectedLineNumber - 1));
			Selection = new Range(this, 0, num, 0, num);
			DoSelectionVisible();
		}
	}

	public void OnUndoRedoStateChanged()
	{
		if (this.UndoRedoStateChanged != null)
		{
			this.UndoRedoStateChanged(this, EventArgs.Empty);
		}
	}

	public List<int> FindLines(string searchPattern, RegexOptions options)
	{
		List<int> list = new List<int>();
		foreach (Range rangesByLine in Range.GetRangesByLines(searchPattern, options))
		{
			list.Add(rangesByLine.Start.iLine);
		}
		return list;
	}

	public void RemoveLines(List<int> iLines)
	{
		TextSource.Manager.ExecuteCommand(new RemoveLinesCommand(TextSource, iLines));
		if (iLines.Count > 0)
		{
			IsChanged = true;
		}
		if (LinesCount == 0)
		{
			Text = "";
		}
		NeedRecalc();
		Invalidate();
	}

	void ISupportInitialize.BeginInit()
	{
	}

	void ISupportInitialize.EndInit()
	{
		OnTextChanged();
		Selection.Start = Place.Empty;
		DoCaretVisible();
		IsChanged = false;
		ClearUndo();
	}

	protected override void OnDragEnter(DragEventArgs e)
	{
		if (e.Data.GetDataPresent(DataFormats.Text) && AllowDrop)
		{
			e.Effect = DragDropEffects.Copy;
			IsDragDrop = true;
		}
		base.OnDragEnter(e);
	}

	protected override void OnDragDrop(DragEventArgs e)
	{
		if (ReadOnly || !AllowDrop)
		{
			IsDragDrop = false;
			return;
		}
		if (e.Data.GetDataPresent(DataFormats.Text))
		{
			if (base.ParentForm != null)
			{
				base.ParentForm.Activate();
			}
			Focus();
			Point point = PointToClient(new Point(e.X, e.Y));
			string text = e.Data.GetData(DataFormats.Text).ToString();
			Place place = PointToPlace(point);
			DoDragDrop(place, text);
			IsDragDrop = false;
		}
		base.OnDragDrop(e);
	}

	private void DoDragDrop_old(Place place, string text)
	{
		Range range = new Range(this, place, place);
		if (range.ReadOnly || (draggedRange != null && draggedRange.Contains(place)))
		{
			return;
		}
		bool flag = draggedRange == null || draggedRange.ReadOnly || (Control.ModifierKeys & Keys.Control) != 0;
		if (draggedRange == null)
		{
			Selection.BeginUpdate();
			Selection.Start = place;
			InsertText(text);
			Selection = new Range(this, place, Selection.Start);
			Selection.EndUpdate();
			return;
		}
		BeginAutoUndo();
		Selection.BeginUpdate();
		Selection = draggedRange;
		lines.Manager.ExecuteCommand(new SelectCommand(lines));
		if (draggedRange.ColumnSelectionMode)
		{
			draggedRange.Normalize();
			range = new Range(this, place, new Place(place.iChar, place.iLine + draggedRange.End.iLine - draggedRange.Start.iLine))
			{
				ColumnSelectionMode = true
			};
			for (int i = LinesCount; i <= range.End.iLine; i++)
			{
				Selection.GoLast(shift: false);
				InsertChar('\n');
			}
		}
		if (!range.ReadOnly)
		{
			Place start;
			if (place < draggedRange.Start)
			{
				if (!flag)
				{
					Selection = draggedRange;
					ClearSelected();
				}
				Selection = range;
				Selection.ColumnSelectionMode = range.ColumnSelectionMode;
				InsertText(text);
				start = Selection.Start;
			}
			else
			{
				Selection = range;
				Selection.ColumnSelectionMode = range.ColumnSelectionMode;
				InsertText(text);
				start = Selection.Start;
				int count = this[start.iLine].Count;
				if (!flag)
				{
					Selection = draggedRange;
					ClearSelected();
				}
				int num = count - this[start.iLine].Count;
				start.iChar -= num;
				place.iChar -= num;
			}
			if (!draggedRange.ColumnSelectionMode)
			{
				Selection = new Range(this, place, start);
			}
			else
			{
				draggedRange.Normalize();
				Selection = new Range(this, place, new Place(place.iChar + draggedRange.End.iChar - draggedRange.Start.iChar, place.iLine + draggedRange.End.iLine - draggedRange.Start.iLine))
				{
					ColumnSelectionMode = true
				};
			}
		}
		Selection.EndUpdate();
		EndAutoUndo();
		draggedRange = null;
	}

	protected virtual void DoDragDrop(Place place, string text)
	{
		Range range = new Range(this, place, place);
		if (range.ReadOnly || (draggedRange != null && draggedRange.Contains(place)))
		{
			return;
		}
		bool flag = draggedRange == null || draggedRange.ReadOnly || (Control.ModifierKeys & Keys.Control) != 0;
		if (draggedRange == null)
		{
			Selection.BeginUpdate();
			Selection.Start = place;
			InsertText(text);
			Selection = new Range(this, place, Selection.Start);
			Selection.EndUpdate();
		}
		else
		{
			if (!draggedRange.Contains(place))
			{
				BeginAutoUndo();
				Selection = draggedRange;
				lines.Manager.ExecuteCommand(new SelectCommand(lines));
				if (draggedRange.ColumnSelectionMode)
				{
					draggedRange.Normalize();
					range = new Range(this, place, new Place(place.iChar, place.iLine + draggedRange.End.iLine - draggedRange.Start.iLine))
					{
						ColumnSelectionMode = true
					};
					for (int i = LinesCount; i <= range.End.iLine; i++)
					{
						Selection.GoLast(shift: false);
						InsertChar('\n');
					}
				}
				if (!range.ReadOnly)
				{
					if (place < draggedRange.Start)
					{
						if (!flag)
						{
							Selection = draggedRange;
							ClearSelected();
						}
						Selection = range;
						Selection.ColumnSelectionMode = range.ColumnSelectionMode;
						InsertText(text);
					}
					else
					{
						Selection = range;
						Selection.ColumnSelectionMode = range.ColumnSelectionMode;
						InsertText(text);
						if (!flag)
						{
							Selection = draggedRange;
							ClearSelected();
						}
					}
				}
				Place start = place;
				Place end = Selection.Start;
				Range range2 = ((draggedRange.End > draggedRange.Start) ? GetRange(draggedRange.Start, draggedRange.End) : GetRange(draggedRange.End, draggedRange.Start));
				Place place2 = place;
				if (place > draggedRange.Start && !flag && !draggedRange.ColumnSelectionMode)
				{
					int iChar;
					int iChar2;
					if (range2.Start.iLine != range2.End.iLine)
					{
						iChar = ((range2.End.iLine != place2.iLine) ? place2.iChar : (range2.Start.iChar + (place2.iChar - range2.End.iChar)));
						iChar2 = range2.End.iChar;
					}
					else if (range2.End.iLine == place2.iLine)
					{
						iChar = place2.iChar - range2.Text.Length;
						iChar2 = place2.iChar;
					}
					else
					{
						iChar = place2.iChar;
						iChar2 = place2.iChar + range2.Text.Length;
					}
					int iLine;
					int iLine2;
					if (range2.End.iLine != place2.iLine)
					{
						iLine = place2.iLine - (range2.End.iLine - range2.Start.iLine);
						iLine2 = place2.iLine;
					}
					else
					{
						iLine = range2.Start.iLine;
						iLine2 = range2.End.iLine;
					}
					start = new Place(iChar, iLine);
					end = new Place(iChar2, iLine2);
				}
				if (!draggedRange.ColumnSelectionMode)
				{
					Selection = new Range(this, start, end);
				}
				else
				{
					int iChar;
					int iChar2;
					if (!flag && place.iLine >= range2.Start.iLine && place.iLine <= range2.End.iLine && place.iChar >= range2.End.iChar)
					{
						iChar = place2.iChar - (range2.End.iChar - range2.Start.iChar);
						iChar2 = place2.iChar;
					}
					else
					{
						iChar = place2.iChar;
						iChar2 = place2.iChar + (range2.End.iChar - range2.Start.iChar);
					}
					int iLine = place2.iLine;
					int iLine2 = place2.iLine + (range2.End.iLine - range2.Start.iLine);
					start = new Place(iChar, iLine);
					end = new Place(iChar2, iLine2);
					Selection = new Range(this, start, end)
					{
						ColumnSelectionMode = true
					};
				}
				EndAutoUndo();
			}
			selection.Inverse();
			OnSelectionChanged();
		}
		draggedRange = null;
	}

	protected override void OnDragOver(DragEventArgs e)
	{
		if (e.Data.GetDataPresent(DataFormats.Text))
		{
			Point point = PointToClient(new Point(e.X, e.Y));
			Selection.Start = PointToPlace(point);
			if (point.Y < 6 && base.VerticalScroll.Visible && base.VerticalScroll.Value > 0)
			{
				base.VerticalScroll.Value = Math.Max(0, base.VerticalScroll.Value - charHeight);
			}
			DoCaretVisible();
			Invalidate();
		}
		base.OnDragOver(e);
	}

	protected override void OnDragLeave(EventArgs e)
	{
		IsDragDrop = false;
		base.OnDragLeave(e);
	}

	private void ActivateMiddleClickScrollingMode(MouseEventArgs e)
	{
		if (!middleClickScrollingActivated && (base.HorizontalScroll.Visible || base.VerticalScroll.Visible || !ShowScrollBars))
		{
			middleClickScrollingActivated = true;
			middleClickScrollingOriginPoint = e.Location;
			middleClickScrollingOriginScroll = new Point(base.HorizontalScroll.Value, base.VerticalScroll.Value);
			middleClickScrollingTimer.Interval = 50;
			middleClickScrollingTimer.Enabled = true;
			base.Capture = true;
			Refresh();
			SendMessage(base.Handle, 11, 0, 0);
		}
	}

	private void DeactivateMiddleClickScrollingMode()
	{
		if (middleClickScrollingActivated)
		{
			middleClickScrollingActivated = false;
			middleClickScrollingTimer.Enabled = false;
			base.Capture = false;
			base.Cursor = defaultCursor;
			SendMessage(base.Handle, 11, 1, 0);
			Invalidate();
		}
	}

	private void RestoreScrollsAfterMiddleClickScrollingMode()
	{
		ScrollEventArgs se = new ScrollEventArgs(ScrollEventType.ThumbPosition, base.HorizontalScroll.Value, middleClickScrollingOriginScroll.X, ScrollOrientation.HorizontalScroll);
		OnScroll(se);
		ScrollEventArgs se2 = new ScrollEventArgs(ScrollEventType.ThumbPosition, base.VerticalScroll.Value, middleClickScrollingOriginScroll.Y, ScrollOrientation.VerticalScroll);
		OnScroll(se2);
	}

	[DllImport("user32.dll")]
	private static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

	private void middleClickScrollingTimer_Tick(object sender, EventArgs e)
	{
		if (base.IsDisposed || !middleClickScrollingActivated)
		{
			return;
		}
		Point point = PointToClient(Cursor.Position);
		base.Capture = true;
		int num = middleClickScrollingOriginPoint.X - point.X;
		int num2 = middleClickScrollingOriginPoint.Y - point.Y;
		if (!base.VerticalScroll.Visible && ShowScrollBars)
		{
			num2 = 0;
		}
		if (!base.HorizontalScroll.Visible && ShowScrollBars)
		{
			num = 0;
		}
		double num3 = 180.0 - Math.Atan2(num2, num) * 180.0 / Math.PI;
		double num4 = Math.Sqrt(Math.Pow(num, 2.0) + Math.Pow(num2, 2.0));
		if (num4 > 10.0)
		{
			if (num3 >= 325.0 || num3 <= 35.0)
			{
				middleClickScollDirection = ScrollDirection.Right;
			}
			else if (num3 <= 55.0)
			{
				middleClickScollDirection = ScrollDirection.Right | ScrollDirection.Up;
			}
			else if (num3 <= 125.0)
			{
				middleClickScollDirection = ScrollDirection.Up;
			}
			else if (num3 <= 145.0)
			{
				middleClickScollDirection = ScrollDirection.Left | ScrollDirection.Up;
			}
			else if (num3 <= 215.0)
			{
				middleClickScollDirection = ScrollDirection.Left;
			}
			else if (num3 <= 235.0)
			{
				middleClickScollDirection = ScrollDirection.Left | ScrollDirection.Down;
			}
			else if (num3 <= 305.0)
			{
				middleClickScollDirection = ScrollDirection.Down;
			}
			else
			{
				middleClickScollDirection = ScrollDirection.Right | ScrollDirection.Down;
			}
		}
		else
		{
			middleClickScollDirection = ScrollDirection.None;
		}
		switch (middleClickScollDirection)
		{
		case ScrollDirection.Right:
			base.Cursor = Cursors.PanEast;
			break;
		case ScrollDirection.Right | ScrollDirection.Up:
			base.Cursor = Cursors.PanNE;
			break;
		case ScrollDirection.Up:
			base.Cursor = Cursors.PanNorth;
			break;
		case ScrollDirection.Left | ScrollDirection.Up:
			base.Cursor = Cursors.PanNW;
			break;
		case ScrollDirection.Left:
			base.Cursor = Cursors.PanWest;
			break;
		case ScrollDirection.Left | ScrollDirection.Down:
			base.Cursor = Cursors.PanSW;
			break;
		case ScrollDirection.Down:
			base.Cursor = Cursors.PanSouth;
			break;
		case ScrollDirection.Right | ScrollDirection.Down:
			base.Cursor = Cursors.PanSE;
			break;
		default:
			base.Cursor = defaultCursor;
			return;
		}
		int num5 = (int)((double)(-num) / 5.0);
		int num6 = (int)((double)(-num2) / 5.0);
		ScrollEventArgs se = new ScrollEventArgs((num5 < 0) ? ScrollEventType.SmallIncrement : ScrollEventType.SmallDecrement, base.HorizontalScroll.Value, base.HorizontalScroll.Value + num5, ScrollOrientation.HorizontalScroll);
		ScrollEventArgs se2 = new ScrollEventArgs((num6 >= 0) ? ScrollEventType.SmallIncrement : ScrollEventType.SmallDecrement, base.VerticalScroll.Value, base.VerticalScroll.Value + num6, ScrollOrientation.VerticalScroll);
		if ((int)(middleClickScollDirection & (ScrollDirection.Up | ScrollDirection.Down)) > 0)
		{
			OnScroll(se2, alignByLines: false);
		}
		if ((int)(middleClickScollDirection & (ScrollDirection.Left | ScrollDirection.Right)) > 0)
		{
			OnScroll(se);
		}
		SendMessage(base.Handle, 11, 1, 0);
		Refresh();
		SendMessage(base.Handle, 11, 0, 0);
	}

	private void DrawMiddleClickScrolling(Graphics gr)
	{
		bool flag = base.VerticalScroll.Visible || !ShowScrollBars;
		bool flag2 = base.HorizontalScroll.Visible || !ShowScrollBars;
		Color color = Color.FromArgb(100, (byte)(~BackColor.R), (byte)(~BackColor.G), (byte)(~BackColor.B));
		using SolidBrush brush = new SolidBrush(color);
		Point point = middleClickScrollingOriginPoint;
		GraphicsState gstate = gr.Save();
		gr.SmoothingMode = SmoothingMode.HighQuality;
		gr.TranslateTransform(point.X, point.Y);
		gr.FillEllipse(brush, -2, -2, 4, 4);
		if (flag)
		{
			DrawTriangle(gr, brush);
		}
		gr.RotateTransform(90f);
		if (flag2)
		{
			DrawTriangle(gr, brush);
		}
		gr.RotateTransform(90f);
		if (flag)
		{
			DrawTriangle(gr, brush);
		}
		gr.RotateTransform(90f);
		if (flag2)
		{
			DrawTriangle(gr, brush);
		}
		gr.Restore(gstate);
	}

	private void DrawTriangle(Graphics g, Brush brush)
	{
		Point[] points = new Point[3]
		{
			new Point(5, 10),
			new Point(0, 15),
			new Point(-5, 10)
		};
		g.FillPolygon(brush, points);
	}
}
