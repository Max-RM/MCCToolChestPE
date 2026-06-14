using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.model;
using MCCToolChest.Properties;
using MCCToolChest.utils;
using MCCToolChest.workers;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls;

public class PostProcessingSRGListUI : UserControl
{
	private IContainer PG6aQlfp21;

	private FlowLayoutPanel f5maOVD8UR;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PostProcessingSRGListUI()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		ljSaoYUydW();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Dictionary<string, PostProcessingSRG> jHBauohZwL()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Dictionary<string, PostProcessingSRG> result = new Dictionary<string, PostProcessingSRG>();
		string postProcessingSRG = Settings.Default.PostProcessingSRG;
		if (!string.IsNullOrWhiteSpace(postProcessingSRG))
		{
			result = JsonDataConversion.Deserialize<Dictionary<string, PostProcessingSRG>>(postProcessingSRG);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DisplayList()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Dictionary<string, PostProcessingSRG> dictionary = jHBauohZwL();
		string path = Utils.SRGPath();
		string[] files = Directory.GetFiles(path, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28538));
		string[] array = files;
		foreach (string path2 in array)
		{
			string fileName = Path.GetFileName(path2);
			PostProcessingSRGUI postProcessingSRGUI = null;
			if (dictionary.ContainsKey(fileName))
			{
				postProcessingSRGUI = new PostProcessingSRGUI(dictionary[fileName]);
			}
			else
			{
				PostProcessingSRG postProcessingSRG = new PostProcessingSRG();
				postProcessingSRG.name = fileName;
				postProcessingSRGUI = new PostProcessingSRGUI(postProcessingSRG);
			}
			f5maOVD8UR.Controls.Add(postProcessingSRGUI);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SavePostProcessingList()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Dictionary<string, PostProcessingSRG> dictionary = new Dictionary<string, PostProcessingSRG>();
		foreach (Control control in f5maOVD8UR.Controls)
		{
			PostProcessingSRGUI postProcessingSRGUI = control as PostProcessingSRGUI;
			postProcessingSRGUI.UpdatePostProcessingSRG();
			dictionary.Add(postProcessingSRGUI.postProcessingSRG.name, postProcessingSRGUI.postProcessingSRG);
		}
		string postProcessingSRG = JsonDataConversion.Serialize(dictionary);
		Settings.Default.PostProcessingSRG = postProcessingSRG;
		Settings.Default.Save();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && PG6aQlfp21 != null)
		{
			PG6aQlfp21.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ljSaoYUydW()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		f5maOVD8UR = new FlowLayoutPanel();
		SuspendLayout();
		f5maOVD8UR.AutoScroll = true;
		f5maOVD8UR.Dock = DockStyle.Fill;
		f5maOVD8UR.Location = new Point(0, 0);
		f5maOVD8UR.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28552);
		f5maOVD8UR.Padding = new Padding(0, 6, 0, 6);
		f5maOVD8UR.Size = new Size(455, 526);
		f5maOVD8UR.TabIndex = 2;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(f5maOVD8UR);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28576);
		base.Size = new Size(455, 526);
		ResumeLayout(performLayout: false);
	}
}
