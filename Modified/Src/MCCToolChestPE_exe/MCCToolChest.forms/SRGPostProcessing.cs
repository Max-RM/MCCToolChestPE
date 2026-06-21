using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.MCSBCode;
using MCCToolChest.model;
using MCCToolChest.model.SearchReplace;
using MCCToolChest.Properties;
using MCCToolChest.utils;
using MCCToolChest.workers;
using Nx4UsGjcTfu4A5sG0RR;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.forms;

public class SRGPostProcessing : Form
{
	private List<lT2JrgzWyWufsFQAS0> RiU8u4ujrd;

	private string La58oLII47;

	private string qhX8QgcrZ5;

	private BackgroundWorker HNb8OVvpfH;

	private bool b8S8Cvvt28;

	private bool h3287nTQSv;

	private IContainer kcx8AiVFBE;

	private Label tEF8dCPqRT;

	private ProgressBar Gx18H7lLMW;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SRGPostProcessing(string workingFolder)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		HNb8OVvpfH = new BackgroundWorker();
		K3y8J9LbE6();
		qhX8QgcrZ5 = workingFolder;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void daO83aFXbO(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.Icon = Resources.usMSrbJo37S();
		DG28521IqL();
		CuF81GFfgv();
		BaU8EqAN9p();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CuF81GFfgv()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		RiU8u4ujrd = new List<lT2JrgzWyWufsFQAS0>();
		Dictionary<string, PostProcessingSRG> dictionary = new Dictionary<string, PostProcessingSRG>();
		string postProcessingSRG = Settings.Default.PostProcessingSRG;
		if (string.IsNullOrWhiteSpace(postProcessingSRG))
		{
			return;
		}
		dictionary = JsonDataConversion.Deserialize<Dictionary<string, PostProcessingSRG>>(postProcessingSRG);
		foreach (PostProcessingSRG value in dictionary.Values)
		{
			if (value.M9DSVPAge8G())
			{
				if (value.overworld)
				{
					RiU8u4ujrd.Add(new lT2JrgzWyWufsFQAS0
					{
						ulu8YdvuM0 = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(21936),
						pmS8koyupM = value
					});
				}
				if (value.nether)
				{
					RiU8u4ujrd.Add(new lT2JrgzWyWufsFQAS0
					{
						ulu8YdvuM0 = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43780),
						pmS8koyupM = value
					});
				}
				if (value.theEnd)
				{
					RiU8u4ujrd.Add(new lT2JrgzWyWufsFQAS0
					{
						ulu8YdvuM0 = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43794),
						pmS8koyupM = value
					});
				}
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BaU8EqAN9p()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string path = Utils.SRGPath();
		if (RiU8u4ujrd.Count > 0)
		{
			lT2JrgzWyWufsFQAS0 lT2JrgzWyWufsFQAS1 = RiU8u4ujrd[0];
			RiU8u4ujrd.Remove(lT2JrgzWyWufsFQAS1);
			La58oLII47 = lT2JrgzWyWufsFQAS1.pmS8koyupM.name;
			string text = Path.Combine(path, lT2JrgzWyWufsFQAS1.pmS8koyupM.name);
			SearchReplaceGroup searchReplaceGroup = JoQ8rPZwUv(text);
			if (searchReplaceGroup != null)
			{
				Rv486nb3K0(searchReplaceGroup, lT2JrgzWyWufsFQAS1.ulu8YdvuM0);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private SearchReplaceGroup JoQ8rPZwUv(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		SearchReplaceGroup searchReplaceGroup = null;
		using StreamReader streamReader = new StreamReader(P_0);
		string xml = streamReader.ReadToEnd();
		return DataConversion.Deserialize<SearchReplaceGroup>(xml);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DG28521IqL()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		HNb8OVvpfH.DoWork += AnU8NCF1hg;
		HNb8OVvpfH.ProgressChanged += AcC8DiQa0R;
		HNb8OVvpfH.RunWorkerCompleted += QjL8cbNoV6;
		HNb8OVvpfH.WorkerReportsProgress = true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Rv486nb3K0(SearchReplaceGroup P_0, string P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		SearchReplaceParameter argument = new SearchReplaceParameter(P_1, P_0, qhX8QgcrZ5);
		HNb8OVvpfH.RunWorkerAsync(argument);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AnU8NCF1hg(object P_0, DoWorkEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BackgroundWorker backgroundWorker = P_0 as BackgroundWorker;
		SearchReplaceParameter searchReplaceParameter = P_1.Argument as SearchReplaceParameter;
		SearchReplaceWorkerPE searchReplaceWorkerPE = new SearchReplaceWorkerPE(backgroundWorker);
		Dictionary<string, SearchReplaceResult> result = searchReplaceWorkerPE.DoSearchReplace(searchReplaceParameter.Dimension, searchReplaceParameter.Group, searchReplaceParameter.OutFolderPath);
		P_1.Result = result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AcC8DiQa0R(object P_0, ProgressChangedEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		tEF8dCPqRT.Text = La58oLII47 + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13740) + P_1.UserState;
		if (P_1.ProgressPercentage > 0)
		{
			Gx18H7lLMW.Value = P_1.ProgressPercentage;
		}
		Gx18H7lLMW.Refresh();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void QjL8cbNoV6(object P_0, RunWorkerCompletedEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (RiU8u4ujrd.Count > 0)
		{
			BaU8EqAN9p();
		}
		else
		{
			Close();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && kcx8AiVFBE != null)
		{
			kcx8AiVFBE.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void K3y8J9LbE6()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		tEF8dCPqRT = new Label();
		Gx18H7lLMW = new ProgressBar();
		SuspendLayout();
		tEF8dCPqRT.AutoSize = true;
		tEF8dCPqRT.Location = new Point(12, 47);
		tEF8dCPqRT.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37114);
		tEF8dCPqRT.Size = new Size(37, 13);
		tEF8dCPqRT.TabIndex = 0;
		tEF8dCPqRT.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(62604);
		Gx18H7lLMW.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		Gx18H7lLMW.Location = new Point(12, 12);
		Gx18H7lLMW.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(37366);
		Gx18H7lLMW.Size = new Size(382, 23);
		Gx18H7lLMW.TabIndex = 3;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(406, 79);
		base.Controls.Add(Gx18H7lLMW);
		base.Controls.Add(tEF8dCPqRT);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(62620);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(62658);
		base.Load += daO83aFXbO;
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
