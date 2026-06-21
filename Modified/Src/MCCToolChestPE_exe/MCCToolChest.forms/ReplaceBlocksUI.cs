using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.controls;
using MCCToolChest.model;
using MCCToolChest.Properties;
using MCCToolChest.utils;
using MCCToolChest.workers;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.forms;

public class ReplaceBlocksUI : Form
{
	public BlocksReplaceDefinition blocksReplaceDefinition;

	private ConvertType U0ZjHgQ8iJ;

	private IContainer N6ujF0vp8S;

	private MenuStrip OGYjj0fKu3;

	private ToolStripMenuItem aU3j8jGKNd;

	private ToolStripMenuItem U4Cj9h2jtG;

	private ToolStripMenuItem gkVjIQafl4;

	private ToolStripMenuItem V9ejzNcfoA;

	private ToolStripMenuItem vHD8TtNaF8;

	private FlowLayoutPanel KRV8SGN5sH;

	private Panel wkP8GKqkAt;

	private Label pEf8bZDFxU;

	private Label llE8vmanVF;

	private Button Bg98wsxlCo;

	private Button RfS84uRwSp;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ReplaceBlocksUI(BlocksReplaceDefinition blocksReplaceDefinition, ConvertType convertType)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		vsejdwdqRy();
		this.blocksReplaceDefinition = blocksReplaceDefinition;
		U0ZjHgQ8iJ = convertType;
		if (blocksReplaceDefinition != null)
		{
			mPNjJHBkbd(blocksReplaceDefinition);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void C0hjDGXagO(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.Icon = Resources.usMSrbJo37S();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ygljc7rgI4(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (!OY3joaAixK())
		{
			return;
		}
		string blockReplaceDefFolder = Utils.GetBlockReplaceDefFolder();
		string text = FileUtils.BugSgNoWh4E(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29142), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29154), blockReplaceDefFolder);
		if (string.IsNullOrWhiteSpace(text) || !text.ToLower().EndsWith(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29142)))
		{
			return;
		}
		string json = File.ReadAllText(text);
		try
		{
			BlocksReplaceDefinition blocksReplaceDefinition = JsonDataConversion.Deserialize<BlocksReplaceDefinition>(json);
			if (blocksReplaceDefinition != null)
			{
				mPNjJHBkbd(blocksReplaceDefinition);
			}
		}
		catch (Exception)
		{
			throw;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void mPNjJHBkbd(BlocksReplaceDefinition P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		foreach (BlockTranslateDefinition blockReplacement in P_0.blockReplacements)
		{
			BlockReplaceUI value = new BlockReplaceUI(blockReplacement);
			KRV8SGN5sH.Controls.Add(value);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hOYjuoVTdj(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (OY3joaAixK())
		{
			string blockReplaceDefFolder = Utils.GetBlockReplaceDefFolder();
			string text = FileUtils.VXKSgcyptXi(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29142), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29154), blockReplaceDefFolder);
			if (!string.IsNullOrWhiteSpace(text) && text.ToLower().EndsWith(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29142)))
			{
				BlocksReplaceDefinition obj = i3DjA7pXsX();
				string contents = JsonDataConversion.Serialize(obj);
				File.WriteAllText(text, contents);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool OY3joaAixK()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		new Settings();
		string value = Utils.BRDPath();
		bool result = false;
		if (string.IsNullOrWhiteSpace(value))
		{
			MessageBox.Show(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29208) + Environment.NewLine + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29326), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29454));
		}
		else
		{
			result = true;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BbcjQqOZON(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BlockReplaceUI value = new BlockReplaceUI(new BlockTranslateDefinition(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9944), Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9944)));
		KRV8SGN5sH.Controls.Add(value);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void mWtjOqHK0f(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		KRV8SGN5sH.Controls.Clear();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void tcPjCipBE0(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Close();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void r2Nj7xJWdu(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		blocksReplaceDefinition = i3DjA7pXsX();
		base.DialogResult = DialogResult.OK;
		Close();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private BlocksReplaceDefinition i3DjA7pXsX()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		BlocksReplaceDefinition blocksReplaceDefinition = new BlocksReplaceDefinition();
		for (int i = 0; i < KRV8SGN5sH.Controls.Count; i++)
		{
			BlockReplaceUI blockReplaceUI = KRV8SGN5sH.Controls[i] as BlockReplaceUI;
			blocksReplaceDefinition.blockReplacements.Add(blockReplaceUI.BuildBlockTranslateDefinition());
		}
		return blocksReplaceDefinition;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && N6ujF0vp8S != null)
		{
			N6ujF0vp8S.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void vsejdwdqRy()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		OGYjj0fKu3 = new MenuStrip();
		aU3j8jGKNd = new ToolStripMenuItem();
		U4Cj9h2jtG = new ToolStripMenuItem();
		gkVjIQafl4 = new ToolStripMenuItem();
		V9ejzNcfoA = new ToolStripMenuItem();
		vHD8TtNaF8 = new ToolStripMenuItem();
		KRV8SGN5sH = new FlowLayoutPanel();
		wkP8GKqkAt = new Panel();
		pEf8bZDFxU = new Label();
		llE8vmanVF = new Label();
		Bg98wsxlCo = new Button();
		RfS84uRwSp = new Button();
		OGYjj0fKu3.SuspendLayout();
		wkP8GKqkAt.SuspendLayout();
		SuspendLayout();
		OGYjj0fKu3.Items.AddRange(new ToolStripItem[3] { aU3j8jGKNd, V9ejzNcfoA, vHD8TtNaF8 });
		OGYjj0fKu3.Location = new Point(0, 0);
		OGYjj0fKu3.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26656);
		OGYjj0fKu3.Size = new Size(593, 24);
		OGYjj0fKu3.TabIndex = 2;
		OGYjj0fKu3.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(26656);
		aU3j8jGKNd.DropDownItems.AddRange(new ToolStripItem[2] { U4Cj9h2jtG, gkVjIQafl4 });
		aU3j8jGKNd.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29486);
		aU3j8jGKNd.Size = new Size(37, 20);
		aU3j8jGKNd.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29532);
		U4Cj9h2jtG.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29544);
		U4Cj9h2jtG.Size = new Size(152, 22);
		U4Cj9h2jtG.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29568);
		U4Cj9h2jtG.Click += ygljc7rgI4;
		gkVjIQafl4.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29580);
		gkVjIQafl4.Size = new Size(152, 22);
		gkVjIQafl4.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(29604);
		gkVjIQafl4.Click += hOYjuoVTdj;
		V9ejzNcfoA.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28918);
		V9ejzNcfoA.Size = new Size(41, 20);
		V9ejzNcfoA.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(28934);
		V9ejzNcfoA.Click += BbcjQqOZON;
		vHD8TtNaF8.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(62154);
		vHD8TtNaF8.Size = new Size(46, 20);
		vHD8TtNaF8.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(58694);
		vHD8TtNaF8.Click += mWtjOqHK0f;
		KRV8SGN5sH.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		KRV8SGN5sH.AutoScroll = true;
		KRV8SGN5sH.BorderStyle = BorderStyle.FixedSingle;
		KRV8SGN5sH.Location = new Point(0, 66);
		KRV8SGN5sH.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(62174);
		KRV8SGN5sH.Size = new Size(593, 528);
		KRV8SGN5sH.TabIndex = 3;
		wkP8GKqkAt.BackColor = Color.FromArgb(224, 224, 224);
		wkP8GKqkAt.BorderStyle = BorderStyle.FixedSingle;
		wkP8GKqkAt.Controls.Add(pEf8bZDFxU);
		wkP8GKqkAt.Controls.Add(llE8vmanVF);
		wkP8GKqkAt.Location = new Point(0, 34);
		wkP8GKqkAt.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10398);
		wkP8GKqkAt.Size = new Size(593, 33);
		wkP8GKqkAt.TabIndex = 0;
		pEf8bZDFxU.AutoSize = true;
		pEf8bZDFxU.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
		pEf8bZDFxU.Location = new Point(295, 7);
		pEf8bZDFxU.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10482);
		pEf8bZDFxU.Size = new Size(70, 20);
		pEf8bZDFxU.TabIndex = 1;
		pEf8bZDFxU.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11214);
		llE8vmanVF.AutoSize = true;
		llE8vmanVF.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
		llE8vmanVF.Location = new Point(16, 7);
		llE8vmanVF.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10582);
		llE8vmanVF.Size = new Size(89, 20);
		llE8vmanVF.TabIndex = 0;
		llE8vmanVF.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11190);
		Bg98wsxlCo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		Bg98wsxlCo.Location = new Point(420, 604);
		Bg98wsxlCo.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34632);
		Bg98wsxlCo.Size = new Size(75, 23);
		Bg98wsxlCo.TabIndex = 5;
		Bg98wsxlCo.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34646);
		Bg98wsxlCo.UseVisualStyleBackColor = true;
		Bg98wsxlCo.Click += r2Nj7xJWdu;
		RfS84uRwSp.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		RfS84uRwSp.DialogResult = DialogResult.Cancel;
		RfS84uRwSp.Location = new Point(503, 604);
		RfS84uRwSp.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(34610);
		RfS84uRwSp.Size = new Size(75, 23);
		RfS84uRwSp.TabIndex = 4;
		RfS84uRwSp.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(20198);
		RfS84uRwSp.UseVisualStyleBackColor = true;
		RfS84uRwSp.Click += tcPjCipBE0;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(593, 636);
		base.Controls.Add(Bg98wsxlCo);
		base.Controls.Add(RfS84uRwSp);
		base.Controls.Add(wkP8GKqkAt);
		base.Controls.Add(KRV8SGN5sH);
		base.Controls.Add(OGYjj0fKu3);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(62202);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(62236);
		base.Load += C0hjDGXagO;
		OGYjj0fKu3.ResumeLayout(performLayout: false);
		OGYjj0fKu3.PerformLayout();
		wkP8GKqkAt.ResumeLayout(performLayout: false);
		wkP8GKqkAt.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
