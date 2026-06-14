using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using MCCToolChest.model.SearchReplace;
using MCCToolChest.Properties;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.forms;

public class FindReplaceResult : Form
{
	private IContainer RRjAgWxtFM;

	private TextBox sNuAP7DivV;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public FindReplaceResult(Dictionary<string, SearchReplaceResult> srResults)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		tNVAL0G8NO();
		StringBuilder stringBuilder = new StringBuilder();
		foreach (string key in srResults.Keys)
		{
			stringBuilder.AppendLine(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(58952) + key);
			stringBuilder.AppendLine(srResults[key].GetResuklts());
			stringBuilder.AppendLine();
		}
		sNuAP7DivV.Text = stringBuilder.ToString();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GISAUTEI6h(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.Icon = Resources.usMSrbJo37S();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && RRjAgWxtFM != null)
		{
			RRjAgWxtFM.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void tNVAL0G8NO()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		sNuAP7DivV = new TextBox();
		SuspendLayout();
		sNuAP7DivV.Location = new Point(13, 13);
		sNuAP7DivV.Multiline = true;
		sNuAP7DivV.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(52336);
		sNuAP7DivV.ScrollBars = ScrollBars.Vertical;
		sNuAP7DivV.Size = new Size(780, 547);
		sNuAP7DivV.TabIndex = 0;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(805, 572);
		base.Controls.Add(sNuAP7DivV);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(58970);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(59008);
		base.Load += GISAUTEI6h;
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
