using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FastColoredTextBoxNS;
using MCCToolChest.Properties;
using MCCToolChest.utils;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.scripting;

public class CodeEditor : Form
{
	private ScriptProcessor aCrSU6OYQAt;

	private AutocompleteMenu fiKSUNNFoEP;

	private string fcNSUDJS3uF;

	private bool AxTSUc9X2Xa;

	private static readonly string[] v1SSUJ0piwj;

	private IContainer wpwSUuU80Dg;

	private FastColoredTextBox J2aSUoJIUpw;

	private MenuStrip MvcSUQ8QX1F;

	private ToolStripMenuItem PmPSUOqBTmI;

	private ToolStripMenuItem GJkSUCVdmRV;

	private ToolStripMenuItem OnaSU7ZTqTA;

	private ToolStripSeparator M4fSUAqx91u;

	private ToolStripMenuItem n6ESUd45u2n;

	private ToolStripSeparator VF9SUHnSpVK;

	private ToolStripMenuItem hfDSUFI7BP9;

	private ToolStripMenuItem pwlSUjKPJhc;

	private ToolStripMenuItem buHSU8jG7nq;

	private ToolStripMenuItem S8jSU9NOP5Z;

	private ToolStripMenuItem g3OSUIbulZH;

	private ToolStripMenuItem fDjSUzgi4Bh;

	private ToolStripSeparator CeoSLTwvNR2;

	private ToolStripSeparator D5HSLSOErXR;

	private ToolStripMenuItem pYgSLGx0U9M;

	private ToolStripSeparator rtoSLbDJOEV;

	private ToolStripMenuItem XkoSLvHR7oy;

	private ToolStripMenuItem MFCSLwZeFgq;

	private StatusStrip EChSL4eSvc2;

	private ToolStripStatusLabel c78SLVrg7Lt;

	private ToolStripStatusLabel Ky7SLWHdoPc;

	private ToolStripStatusLabel sOgSLpkv4QC;

	private ToolStripMenuItem To9SLZtHlXB;

	private TextBox W42SLfDRB8g;

	private TextBox xCTSLi8dJMK;

	private Button NpISLsKRAQC;

	private ToolStripComboBox J2hSLqkJwpS;

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	private string mABSUEUKAO3()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return fcNSUDJS3uF;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	private void fAwSUrV30uq(string value)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		fcNSUDJS3uF = value;
		Ky7SLWHdoPc.Text = Path.GetFileName(fcNSUDJS3uF);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CodeEditor()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		aCrSU6OYQAt = new ScriptProcessor();
		fcNSUDJS3uF = "";
		AZ0SU1NooCu();
		fiKSUNNFoEP = new AutocompleteMenu(J2aSUoJIUpw);
		fiKSUNNFoEP.SearchPattern = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(210704);
		List<AutocompleteItem> list = new List<AutocompleteItem>();
		string[] array = v1SSUJ0piwj;
		foreach (string text in array)
		{
			list.Add(new MethodAutocompleteItem2(text));
		}
		fiKSUNNFoEP.Items.SetAutocompleteItems(list);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void IdmSUwd8A3g(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.Icon = Resources.usMSrbJo37S();
		J2aSUoJIUpw.Language = Language.JS;
		AxTSUc9X2Xa = false;
		J2hSLqkJwpS.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(210720);
		QbcSU4XkDS5();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void QbcSU4XkDS5()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		StringCollection recentScripts = Settings.Default.RecentScripts;
		if (recentScripts != null)
		{
			XkoSLvHR7oy.DropDownItems.Clear();
			for (int num = recentScripts.Count - 1; num >= 0; num--)
			{
				string fileName = Path.GetFileName(recentScripts[num]);
				ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(fileName, null, wy9SUVUfl0h);
				toolStripMenuItem.Tag = recentScripts[num];
				XkoSLvHR7oy.DropDownItems.Add(toolStripMenuItem);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void wy9SUVUfl0h(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = ((ToolStripMenuItem)P_0).Tag as string;
		if (File.Exists(text))
		{
			cKZSUt67yLl(text);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void p9iSUWGaSgc(object P_0, TextChangedEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		AxTSUc9X2Xa = true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void X7ISUpujhKw(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		J2aSUoJIUpw.ShowFindDialog();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void fu9SUZX4x86(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		J2aSUoJIUpw.ShowReplaceDialog();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TSHSUf6ZA5P(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		J2aSUoJIUpw.DoAutoIndent();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YsGSUippQO4(object P_0, AutoIndentEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!Regex.IsMatch(P_1.LineText, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(210738)))
		{
			if (Regex.IsMatch(P_1.LineText, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(210782)))
			{
				P_1.ShiftNextLines = P_1.TabLength;
			}
			else if (Regex.IsMatch(P_1.LineText, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(210804)))
			{
				P_1.Shift = -P_1.TabLength;
				P_1.ShiftNextLines = -P_1.TabLength;
			}
			else if (Regex.IsMatch(P_1.LineText, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(210824)) && !Regex.IsMatch(P_1.LineText, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(210868)))
			{
				P_1.Shift = -P_1.TabLength;
			}
			else if (Regex.IsMatch(P_1.LineText, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(210902)))
			{
				P_1.Shift = -P_1.TabLength / 2;
			}
			else if (Regex.IsMatch(P_1.PrevLineText, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(210970)) && !Regex.IsMatch(P_1.PrevLineText, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(211066)))
			{
				P_1.Shift = P_1.TabLength;
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void VkLSUstDPi5(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		J2aSUoJIUpw.Print(new PrintDialogSettings
		{
			ShowPrintPreviewDialog = true
		});
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void wNLSUqLjEDA(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		J2aSUoJIUpw.Selection.ReadOnly = true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ePySUKLPZf4(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		J2aSUoJIUpw.Selection.ReadOnly = false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Es4SUhSuNox(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		J2aSUoJIUpw.MacrosManager.IsRecording = !J2aSUoJIUpw.MacrosManager.IsRecording;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void a4wSUmevohd(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		J2aSUoJIUpw.MacrosManager.ExecuteMacros();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AN1SUnsUAKe(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		HotkeysEditorForm hotkeysEditorForm = new HotkeysEditorForm(J2aSUoJIUpw.HotkeysMapping);
		if (hotkeysEditorForm.ShowDialog() == DialogResult.OK)
		{
			J2aSUoJIUpw.HotkeysMapping = hotkeysEditorForm.GetHotkeys();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void T30SUlBtdvi(object P_0, CustomActionEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		MessageBox.Show(P_1.Action.ToString());
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void U4NSU2NJsr6(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		J2aSUoJIUpw.InsertLinePrefix(J2aSUoJIUpw.CommentPrefix);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void JkOSUy3dLil(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		J2aSUoJIUpw.RemoveLinePrefix(J2aSUoJIUpw.CommentPrefix);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void sa0SU0wNsq4(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (HMOSUU6Rr1E())
		{
			fAwSUrV30uq("");
			J2aSUoJIUpw.Text = "";
			AxTSUc9X2Xa = false;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ORISUB9ks2a(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = Utils.ScriptPath();
		if (HMOSUU6Rr1E())
		{
			string text2 = FileUtils.BugSgNoWh4E(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(211102), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(211112), text);
			if (!string.IsNullOrWhiteSpace(text2) && text2.ToLower().EndsWith(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(211102)))
			{
				cKZSUt67yLl(text2);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void cKZSUt67yLl(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		fAwSUrV30uq(P_0);
		string text = File.ReadAllText(P_0);
		J2aSUoJIUpw.Text = text;
		AxTSUc9X2Xa = false;
		p3kSUMUnIao(P_0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void v5OSUagj4dU(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = J2aSUoJIUpw.Text;
		if (!string.IsNullOrWhiteSpace(mABSUEUKAO3()) && mABSUEUKAO3().ToLower().EndsWith(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(211102)))
		{
			File.WriteAllText(mABSUEUKAO3(), text);
			AxTSUc9X2Xa = false;
		}
		else if (text.Length > 0)
		{
			F0lSUX2I5Nd(P_0, P_1);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void F0lSUX2I5Nd(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = J2aSUoJIUpw.Text;
		string text2 = ((!string.IsNullOrWhiteSpace(mABSUEUKAO3())) ? mABSUEUKAO3() : Utils.ScriptPath());
		if (text.Length > 0)
		{
			string text3 = FileUtils.VXKSgcyptXi(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(211102), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(211112), text2);
			if (!string.IsNullOrWhiteSpace(text3) && text3.ToLower().EndsWith(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(211102)))
			{
				fAwSUrV30uq(text3);
				File.WriteAllText(text3, text);
				AxTSUc9X2Xa = false;
				p3kSUMUnIao(text3);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void NF9SUxpog8a(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		sOgSLpkv4QC.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28806);
		EChSL4eSvc2.Refresh();
		string text = string.Empty;
		string name = ((!string.IsNullOrWhiteSpace(fcNSUDJS3uF)) ? Path.GetFileNameWithoutExtension(fcNSUDJS3uF) : Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(211160));
		string text2 = J2aSUoJIUpw.Text;
		if (text2.Length > 0)
		{
			if (J2hSLqkJwpS.Text == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(210720))
			{
				CodeRun codeRun = new CodeRun(name, CodeRunType.CODE_STRING, text2);
				codeRun.ShowDialog(this);
			}
			else
			{
				text = aCrSU6OYQAt.Process(name, text2).ToString();
			}
		}
		sOgSLpkv4QC.Text = text;
		EChSL4eSvc2.Refresh();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BY8SUeUSr9G(object P_0, FormClosingEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!HMOSUU6Rr1E())
		{
			P_1.Cancel = true;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void p3kSUMUnIao(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		StringCollection stringCollection = Settings.Default.RecentScripts;
		if (stringCollection == null)
		{
			stringCollection = new StringCollection();
		}
		stringCollection.Remove(P_0);
		if (stringCollection.Count >= 10)
		{
			stringCollection.Remove(stringCollection[9]);
		}
		stringCollection.Add(P_0);
		Settings.Default.RecentScripts = stringCollection;
		Settings.Default.Save();
		QbcSU4XkDS5();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HMOSUU6Rr1E()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bool result = true;
		DialogResult dialogResult = DialogResult.OK;
		if (AxTSUc9X2Xa)
		{
			dialogResult = MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(211184), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(211244), MessageBoxButtons.YesNoCancel);
			if (dialogResult == DialogResult.Yes)
			{
				v5OSUagj4dU(null, null);
			}
		}
		if (dialogResult == DialogResult.Cancel)
		{
			result = false;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void rYVSULPMdFR(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AhoSUgQnQ37(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		aCrSU6OYQAt = new ScriptProcessor();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void B9pSUPQF5h6(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		try
		{
			string text = aCrSU6OYQAt.ExecuteCommand(P_0).ToString();
			if (text != Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(211262))
			{
				xCTSLi8dJMK.Text = text + Environment.NewLine + xCTSLi8dJMK.Text;
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void IrISURQPyaX(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		B9pSUPQF5h6(W42SLfDRB8g.Text);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void xVBSUkXQKr0(object P_0, KeyPressEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_1.KeyChar == '\r')
		{
			B9pSUPQF5h6(W42SLfDRB8g.Text);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void awnSUYbDVuK(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void zySSU3oEROi(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (J2hSLqkJwpS.Text == Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(210720))
		{
			J2aSUoJIUpw.Height = EChSL4eSvc2.Top - (J2aSUoJIUpw.Top + 4);
		}
		else
		{
			J2aSUoJIUpw.Height = W42SLfDRB8g.Top - (J2aSUoJIUpw.Top + 4);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && wpwSUuU80Dg != null)
		{
			wpwSUuU80Dg.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AZ0SU1NooCu()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		wpwSUuU80Dg = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(CodeEditor));
		MvcSUQ8QX1F = new MenuStrip();
		buHSU8jG7nq = new ToolStripMenuItem();
		fDjSUzgi4Bh = new ToolStripMenuItem();
		CeoSLTwvNR2 = new ToolStripSeparator();
		S8jSU9NOP5Z = new ToolStripMenuItem();
		D5HSLSOErXR = new ToolStripSeparator();
		g3OSUIbulZH = new ToolStripMenuItem();
		pYgSLGx0U9M = new ToolStripMenuItem();
		rtoSLbDJOEV = new ToolStripSeparator();
		XkoSLvHR7oy = new ToolStripMenuItem();
		PmPSUOqBTmI = new ToolStripMenuItem();
		GJkSUCVdmRV = new ToolStripMenuItem();
		OnaSU7ZTqTA = new ToolStripMenuItem();
		VF9SUHnSpVK = new ToolStripSeparator();
		hfDSUFI7BP9 = new ToolStripMenuItem();
		pwlSUjKPJhc = new ToolStripMenuItem();
		M4fSUAqx91u = new ToolStripSeparator();
		n6ESUd45u2n = new ToolStripMenuItem();
		MFCSLwZeFgq = new ToolStripMenuItem();
		J2hSLqkJwpS = new ToolStripComboBox();
		To9SLZtHlXB = new ToolStripMenuItem();
		J2aSUoJIUpw = new FastColoredTextBox();
		EChSL4eSvc2 = new StatusStrip();
		c78SLVrg7Lt = new ToolStripStatusLabel();
		Ky7SLWHdoPc = new ToolStripStatusLabel();
		sOgSLpkv4QC = new ToolStripStatusLabel();
		W42SLfDRB8g = new TextBox();
		xCTSLi8dJMK = new TextBox();
		NpISLsKRAQC = new Button();
		MvcSUQ8QX1F.SuspendLayout();
		((ISupportInitialize)J2aSUoJIUpw).BeginInit();
		EChSL4eSvc2.SuspendLayout();
		SuspendLayout();
		MvcSUQ8QX1F.Items.AddRange(new ToolStripItem[5] { buHSU8jG7nq, PmPSUOqBTmI, MFCSLwZeFgq, J2hSLqkJwpS, To9SLZtHlXB });
		MvcSUQ8QX1F.Location = new Point(0, 0);
		MvcSUQ8QX1F.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26656);
		MvcSUQ8QX1F.Size = new Size(690, 27);
		MvcSUQ8QX1F.TabIndex = 4;
		MvcSUQ8QX1F.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26656);
		buHSU8jG7nq.DropDownItems.AddRange(new ToolStripItem[8] { fDjSUzgi4Bh, CeoSLTwvNR2, S8jSU9NOP5Z, D5HSLSOErXR, g3OSUIbulZH, pYgSLGx0U9M, rtoSLbDJOEV, XkoSLvHR7oy });
		buHSU8jG7nq.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29486);
		buHSU8jG7nq.Size = new Size(37, 23);
		buHSU8jG7nq.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29532);
		fDjSUzgi4Bh.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57976);
		fDjSUzgi4Bh.Size = new Size(114, 22);
		fDjSUzgi4Bh.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57992);
		fDjSUzgi4Bh.Click += sa0SU0wNsq4;
		CeoSLTwvNR2.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(211288);
		CeoSLTwvNR2.Size = new Size(111, 6);
		S8jSU9NOP5Z.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(58002);
		S8jSU9NOP5Z.Size = new Size(114, 22);
		S8jSU9NOP5Z.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29568);
		S8jSU9NOP5Z.Click += ORISUB9ks2a;
		D5HSLSOErXR.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(211330);
		D5HSLSOErXR.Size = new Size(111, 6);
		g3OSUIbulZH.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(58020);
		g3OSUIbulZH.Size = new Size(114, 22);
		g3OSUIbulZH.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29604);
		g3OSUIbulZH.Click += v5OSUagj4dU;
		pYgSLGx0U9M.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(57954);
		pYgSLGx0U9M.Size = new Size(114, 22);
		pYgSLGx0U9M.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(58088);
		pYgSLGx0U9M.Click += F0lSUX2I5Nd;
		rtoSLbDJOEV.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(211372);
		rtoSLbDJOEV.Size = new Size(111, 6);
		XkoSLvHR7oy.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(211414);
		XkoSLvHR7oy.Size = new Size(114, 22);
		XkoSLvHR7oy.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(211436);
		PmPSUOqBTmI.DropDownItems.AddRange(new ToolStripItem[7] { GJkSUCVdmRV, OnaSU7ZTqTA, VF9SUHnSpVK, hfDSUFI7BP9, pwlSUjKPJhc, M4fSUAqx91u, n6ESUd45u2n });
		PmPSUOqBTmI.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26680);
		PmPSUOqBTmI.Size = new Size(39, 23);
		PmPSUOqBTmI.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26726);
		GJkSUCVdmRV.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(211452);
		GJkSUCVdmRV.Size = new Size(214, 22);
		GJkSUCVdmRV.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(211498);
		GJkSUCVdmRV.Click += X7ISUpujhKw;
		OnaSU7ZTqTA.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(94340);
		OnaSU7ZTqTA.Size = new Size(214, 22);
		OnaSU7ZTqTA.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(211530);
		OnaSU7ZTqTA.Click += fu9SUZX4x86;
		VF9SUHnSpVK.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(96490);
		VF9SUHnSpVK.Size = new Size(211, 6);
		hfDSUFI7BP9.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(211568);
		hfDSUFI7BP9.Size = new Size(214, 22);
		hfDSUFI7BP9.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(211646);
		hfDSUFI7BP9.Click += U4NSU2NJsr6;
		pwlSUjKPJhc.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(211694);
		pwlSUjKPJhc.Size = new Size(214, 22);
		pwlSUjKPJhc.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(211776);
		pwlSUjKPJhc.Click += JkOSUy3dLil;
		M4fSUAqx91u.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(94674);
		M4fSUAqx91u.Size = new Size(211, 6);
		n6ESUd45u2n.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(211828);
		n6ESUd45u2n.Size = new Size(214, 22);
		n6ESUd45u2n.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(211886);
		n6ESUd45u2n.Click += TSHSUf6ZA5P;
		MFCSLwZeFgq.AutoToolTip = true;
		MFCSLwZeFgq.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(211940);
		MFCSLwZeFgq.Padding = new Padding(4, 0, 0, 0);
		MFCSLwZeFgq.ShortcutKeys = Keys.R | Keys.Control;
		MFCSLwZeFgq.Size = new Size(36, 23);
		MFCSLwZeFgq.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(211964);
		MFCSLwZeFgq.ToolTipText = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(211976);
		MFCSLwZeFgq.Click += NF9SUxpog8a;
		J2hSLqkJwpS.AutoSize = false;
		J2hSLqkJwpS.Items.AddRange(new object[2]
		{
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(210720),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(212002)
		});
		J2hSLqkJwpS.Margin = new Padding(0, 0, 8, 0);
		J2hSLqkJwpS.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(212016);
		J2hSLqkJwpS.Size = new Size(65, 23);
		J2hSLqkJwpS.Click += awnSUYbDVuK;
		J2hSLqkJwpS.TextChanged += zySSU3oEROi;
		To9SLZtHlXB.AutoToolTip = true;
		To9SLZtHlXB.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(212040);
		To9SLZtHlXB.Size = new Size(47, 23);
		To9SLZtHlXB.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29636);
		To9SLZtHlXB.ToolTipText = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(212086);
		To9SLZtHlXB.Click += AhoSUgQnQ37;
		J2aSUoJIUpw.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		J2aSUoJIUpw.AutoCompleteBracketsList = new char[10] { '(', ')', '{', '}', '[', ']', '"', '"', '\'', '\'' };
		J2aSUoJIUpw.AutoIndentCharsPatterns = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(212130);
		J2aSUoJIUpw.AutoIndentExistingLines = false;
		J2aSUoJIUpw.AutoScrollMinSize = new Size(32, 15);
		J2aSUoJIUpw.BackBrush = null;
		J2aSUoJIUpw.BorderStyle = BorderStyle.FixedSingle;
		J2aSUoJIUpw.BracketsHighlightStrategy = BracketsHighlightStrategy.Strategy2;
		J2aSUoJIUpw.CharHeight = 15;
		J2aSUoJIUpw.CharWidth = 7;
		J2aSUoJIUpw.Cursor = Cursors.IBeam;
		J2aSUoJIUpw.DelayedEventsInterval = 200;
		J2aSUoJIUpw.DelayedTextChangedInterval = 500;
		J2aSUoJIUpw.DisabledColor = Color.FromArgb(100, 180, 180, 180);
		J2aSUoJIUpw.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(212246), 9.75f);
		J2aSUoJIUpw.ImeMode = ImeMode.Off;
		J2aSUoJIUpw.IsReplaceMode = false;
		J2aSUoJIUpw.Language = Language.JS;
		J2aSUoJIUpw.LeftBracket = '(';
		J2aSUoJIUpw.LeftBracket2 = '{';
		J2aSUoJIUpw.Location = new Point(0, 24);
		J2aSUoJIUpw.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(212266);
		J2aSUoJIUpw.Paddings = new Padding(0);
		J2aSUoJIUpw.ReservedCountOfLineNumberChars = 2;
		J2aSUoJIUpw.RightBracket = ')';
		J2aSUoJIUpw.RightBracket2 = '}';
		J2aSUoJIUpw.SelectionColor = Color.FromArgb(60, 0, 0, 255);
		J2aSUoJIUpw.ServiceColors = (ServiceColors)componentResourceManager.GetObject(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(212278));
		J2aSUoJIUpw.Size = new Size(690, 528);
		J2aSUoJIUpw.TabIndex = 3;
		J2aSUoJIUpw.Zoom = 100;
		J2aSUoJIUpw.TextChanged += p9iSUWGaSgc;
		J2aSUoJIUpw.AutoIndentNeeded += YsGSUippQO4;
		J2aSUoJIUpw.CustomAction += T30SUlBtdvi;
		EChSL4eSvc2.Items.AddRange(new ToolStripItem[3] { c78SLVrg7Lt, Ky7SLWHdoPc, sOgSLpkv4QC });
		EChSL4eSvc2.Location = new Point(0, 555);
		EChSL4eSvc2.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37836);
		EChSL4eSvc2.Size = new Size(690, 22);
		EChSL4eSvc2.TabIndex = 5;
		EChSL4eSvc2.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37836);
		c78SLVrg7Lt.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(212318);
		c78SLVrg7Lt.Size = new Size(28, 17);
		c78SLVrg7Lt.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(212364);
		Ky7SLWHdoPc.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(212378);
		Ky7SLWHdoPc.Size = new Size(628, 17);
		Ky7SLWHdoPc.Spring = true;
		Ky7SLWHdoPc.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22744);
		Ky7SLWHdoPc.TextAlign = ContentAlignment.MiddleLeft;
		sOgSLpkv4QC.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(58860);
		sOgSLpkv4QC.Size = new Size(19, 17);
		sOgSLpkv4QC.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28858);
		W42SLfDRB8g.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		W42SLfDRB8g.Location = new Point(0, 378);
		W42SLfDRB8g.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(212406);
		W42SLfDRB8g.Size = new Size(614, 20);
		W42SLfDRB8g.TabIndex = 6;
		W42SLfDRB8g.KeyPress += xVBSUkXQKr0;
		xCTSLi8dJMK.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		xCTSLi8dJMK.Location = new Point(0, 405);
		xCTSLi8dJMK.Multiline = true;
		xCTSLi8dJMK.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(212428);
		xCTSLi8dJMK.ScrollBars = ScrollBars.Vertical;
		xCTSLi8dJMK.Size = new Size(690, 147);
		xCTSLi8dJMK.TabIndex = 7;
		NpISLsKRAQC.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		NpISLsKRAQC.Location = new Point(626, 378);
		NpISLsKRAQC.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(212452);
		NpISLsKRAQC.Size = new Size(56, 23);
		NpISLsKRAQC.TabIndex = 8;
		NpISLsKRAQC.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(212490);
		NpISLsKRAQC.UseVisualStyleBackColor = true;
		NpISLsKRAQC.Click += IrISURQPyaX;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(690, 577);
		base.Controls.Add(J2aSUoJIUpw);
		base.Controls.Add(NpISLsKRAQC);
		base.Controls.Add(xCTSLi8dJMK);
		base.Controls.Add(W42SLfDRB8g);
		base.Controls.Add(EChSL4eSvc2);
		base.Controls.Add(MvcSUQ8QX1F);
		base.ImeMode = ImeMode.Hiragana;
		base.MainMenuStrip = MvcSUQ8QX1F;
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(212508);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(212532);
		base.FormClosing += BY8SUeUSr9G;
		base.Load += IdmSUwd8A3g;
		MvcSUQ8QX1F.ResumeLayout(performLayout: false);
		MvcSUQ8QX1F.PerformLayout();
		((ISupportInitialize)J2aSUoJIUpw).EndInit();
		EChSL4eSvc2.ResumeLayout(performLayout: false);
		EChSL4eSvc2.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static CodeEditor()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		v1SSUJ0piwj = new string[11]
		{
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(212562),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(212588),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(212628),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(212676),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(212722),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(212736),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(212770),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(212798),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(212826),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(212874),
			Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(212916)
		};
	}
}
