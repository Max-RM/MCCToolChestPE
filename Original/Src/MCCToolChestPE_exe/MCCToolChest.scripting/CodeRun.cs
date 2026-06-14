using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.Properties;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.scripting;

public class CodeRun : Form
{
	private DateTime dW7SLXrYnVD;

	private string ThaSLxHlV5X;

	private string yeFSLesjboB;

	private BackgroundWorker t7xSLMLe2Gl;

	private IContainer w4TSLU9yUeM;

	private TextBox Yy2SLLrEqLC;

	private Timer YbTSLgMICP6;

	private Panel Oc0SLP50S5r;

	private Label hElSLRSSTX1;

	private ProgressBar BA0SLkL85jG;

	private Button vbfSLY1T7Lj;

	private Label SgVSL3TRtd6;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CodeRun(string name, CodeRunType codeRunType, string codeData)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		ThaSLxHlV5X = string.Empty;
		yeFSLesjboB = string.Empty;
		t7xSLMLe2Gl = new BackgroundWorker();
		DPgSLaFrpvN();
		ThaSLxHlV5X = name;
		yeFSLesjboB = codeData;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void M3MSLmpqwq8(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.Icon = Resources.usMSrbJo37S();
		doESLl23Gxe();
		hgpSL2LTwWF(ThaSLxHlV5X, yeFSLesjboB);
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(212958) + ThaSLxHlV5X;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void l0JSLnsL0OQ(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int num = (int)(DateTime.Now - dW7SLXrYnVD).TotalSeconds;
		string text = TimeSpan.FromSeconds(num).ToString(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(212974));
		SgVSL3TRtd6.Text = text;
		SgVSL3TRtd6.Refresh();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void doESLl23Gxe()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		t7xSLMLe2Gl.DoWork += Y9fSLyOxa4C;
		t7xSLMLe2Gl.ProgressChanged += PswSL0Jxthk;
		t7xSLMLe2Gl.RunWorkerCompleted += SeeSLBpJPZS;
		t7xSLMLe2Gl.WorkerReportsProgress = true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hgpSL2LTwWF(string P_0, string P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		RunCodeParameters runCodeParameters = new RunCodeParameters();
		runCodeParameters.name = P_0;
		runCodeParameters.code = P_1;
		t7xSLMLe2Gl.RunWorkerAsync(runCodeParameters);
		Yy2SLLrEqLC.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(212998);
		YbTSLgMICP6.Start();
		dW7SLXrYnVD = DateTime.Now;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Y9fSLyOxa4C(object P_0, DoWorkEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		RunCodeParameters runCodeParameters = P_1.Argument as RunCodeParameters;
		if (runCodeParameters.code.Length > 0)
		{
			ScriptProcessor scriptProcessor = new ScriptProcessor(t7xSLMLe2Gl);
			object obj = scriptProcessor.Process(runCodeParameters.name, runCodeParameters.code);
			if (obj != null)
			{
				P_1.Result = obj.ToString();
			}
			else
			{
				P_1.Result = "";
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PswSL0Jxthk(object P_0, ProgressChangedEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = P_1.UserState as string;
		Yy2SLLrEqLC.AppendText(Environment.NewLine + text);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SeeSLBpJPZS(object P_0, RunWorkerCompletedEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Yy2SLLrEqLC.AppendText(Environment.NewLine + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(213026));
		BA0SLkL85jG.Value = 0;
		hElSLRSSTX1.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(213058) + P_1.Result;
		hElSLRSSTX1.Visible = true;
		vbfSLY1T7Lj.Visible = true;
		BA0SLkL85jG.Visible = false;
		YbTSLgMICP6.Stop();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YBpSLt9FPne(object P_0, FormClosingEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_1.Cancel = t7xSLMLe2Gl.IsBusy;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && w4TSLU9yUeM != null)
		{
			w4TSLU9yUeM.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DPgSLaFrpvN()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		w4TSLU9yUeM = new Container();
		Yy2SLLrEqLC = new TextBox();
		YbTSLgMICP6 = new Timer(w4TSLU9yUeM);
		Oc0SLP50S5r = new Panel();
		SgVSL3TRtd6 = new Label();
		hElSLRSSTX1 = new Label();
		BA0SLkL85jG = new ProgressBar();
		vbfSLY1T7Lj = new Button();
		Oc0SLP50S5r.SuspendLayout();
		SuspendLayout();
		Yy2SLLrEqLC.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Yy2SLLrEqLC.Location = new Point(13, 13);
		Yy2SLLrEqLC.Multiline = true;
		Yy2SLLrEqLC.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(213078);
		Yy2SLLrEqLC.ScrollBars = ScrollBars.Vertical;
		Yy2SLLrEqLC.Size = new Size(700, 205);
		Yy2SLLrEqLC.TabIndex = 0;
		YbTSLgMICP6.Interval = 500;
		YbTSLgMICP6.Tick += l0JSLnsL0OQ;
		Oc0SLP50S5r.Controls.Add(SgVSL3TRtd6);
		Oc0SLP50S5r.Controls.Add(hElSLRSSTX1);
		Oc0SLP50S5r.Controls.Add(BA0SLkL85jG);
		Oc0SLP50S5r.Controls.Add(vbfSLY1T7Lj);
		Oc0SLP50S5r.Dock = DockStyle.Bottom;
		Oc0SLP50S5r.Location = new Point(0, 218);
		Oc0SLP50S5r.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10398);
		Oc0SLP50S5r.Size = new Size(725, 34);
		Oc0SLP50S5r.TabIndex = 2;
		SgVSL3TRtd6.AutoSize = true;
		SgVSL3TRtd6.Location = new Point(4, 12);
		SgVSL3TRtd6.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(213110);
		SgVSL3TRtd6.Size = new Size(49, 13);
		SgVSL3TRtd6.TabIndex = 4;
		SgVSL3TRtd6.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(213142);
		hElSLRSSTX1.AutoSize = true;
		hElSLRSSTX1.Location = new Point(64, 12);
		hElSLRSSTX1.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37114);
		hElSLRSSTX1.Size = new Size(19, 13);
		hElSLRSSTX1.TabIndex = 3;
		hElSLRSSTX1.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28858);
		hElSLRSSTX1.Visible = false;
		BA0SLkL85jG.Location = new Point(67, 6);
		BA0SLkL85jG.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37136);
		BA0SLkL85jG.Size = new Size(265, 23);
		BA0SLkL85jG.Style = ProgressBarStyle.Marquee;
		BA0SLkL85jG.TabIndex = 2;
		vbfSLY1T7Lj.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		vbfSLY1T7Lj.Location = new Point(637, 6);
		vbfSLY1T7Lj.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38508);
		vbfSLY1T7Lj.Size = new Size(75, 23);
		vbfSLY1T7Lj.TabIndex = 0;
		vbfSLY1T7Lj.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(38528);
		vbfSLY1T7Lj.UseVisualStyleBackColor = true;
		vbfSLY1T7Lj.Visible = false;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = vbfSLY1T7Lj;
		base.ClientSize = new Size(725, 252);
		base.Controls.Add(Oc0SLP50S5r);
		base.Controls.Add(Yy2SLLrEqLC);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(213162);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28806);
		base.FormClosing += YBpSLt9FPne;
		base.Load += M3MSLmpqwq8;
		Oc0SLP50S5r.ResumeLayout(performLayout: false);
		Oc0SLP50S5r.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
