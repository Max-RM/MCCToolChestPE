using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using MCCToolChest.events;
using MCCToolChest.model;
using uL2B6CXB2hZQU16Di7r;
using uP7B13T5waxVpI3AEv;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls;

public class BlockSettingsUI : UserControl
{
	private EventHandler ELKvDJQrT7;

	private Block Y4mvc63JIc;

	private IContainer phPvJjRqum;

	private TextBox qrBvupvxUo;

	private Label lKyvoKGVIi;

	private PictureBox dqbvQsMDKM;

	private ComboBox wx5vOVFk1o;

	private Label JjbvCNxIge;

	internal Block Block
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return Y4mvc63JIc;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			Y4mvc63JIc = value;
			UpdateSettingsUI();
		}
	}

	[EditorBrowsable(EditorBrowsableState.Always)]
	[Bindable(true)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	[Browsable(true)]
	public override string Text
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return JjbvCNxIge.Text;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			JjbvCNxIge.Text = value;
		}
	}

	public event EventHandler BlockChanged
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = ELKvDJQrT7;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref ELKvDJQrT7, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		remove
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = ELKvDJQrT7;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref ELKvDJQrT7, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BlockSettingsUI()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		MZcv5TWUWY();
		M2Ov3jr4ea();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void M2Ov3jr4ea()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		wx5vOVFk1o.ValueMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10196);
		wx5vOVFk1o.DisplayMember = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11830);
		wx5vOVFk1o.DataSource = BFRL2f2UoG7tBGIHJF.mAVSRPT1qd().Values.ToList();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateSettingsUI()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string name = BlockMaster.GetBedrockBlockState(Y4mvc63JIc.Id, (short)Y4mvc63JIc.Data).masterBlock.Name;
		UpdateBlockImage();
		wx5vOVFk1o.SelectedValue = name;
		qrBvupvxUo.Text = Y4mvc63JIc.Data.ToString();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateBlockImage()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Image image = BFRL2f2UoG7tBGIHJF.xRoSMGJq48(Y4mvc63JIc.Id, Y4mvc63JIc.Data);
		dqbvQsMDKM.Image = image;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void wJDv1ivmdS()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int result = 0;
		int.TryParse(qrBvupvxUo.Text, out result);
		Y4mvc63JIc.Data = result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void zejvEh0FrC(object P_0, KeyEventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		wJDv1ivmdS();
		UpdateBlockImage();
		OnBlockChanged(this, new BlockChangedEventArgs(Y4mvc63JIc.Copy()));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void WTNvrDnR76(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (Y4mvc63JIc != null && (string)wx5vOVFk1o.SelectedValue != null)
		{
			string key = (string)wx5vOVFk1o.SelectedValue;
			int value = BlockMaster.Blocks[key].bedrock.id.Value;
			int value2 = BlockMaster.Blocks[key].bedrock.data.Value;
			Y4mvc63JIc.Id = value;
			Y4mvc63JIc.Data = value2;
			UpdateBlockImage();
			OnBlockChanged(this, new BlockChangedEventArgs(Y4mvc63JIc.Copy()));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnBlockChanged(object sender, BlockChangedEventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		ELKvDJQrT7?.Invoke(this, e);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && phPvJjRqum != null)
		{
			phPvJjRqum.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MZcv5TWUWY()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		qrBvupvxUo = new TextBox();
		lKyvoKGVIi = new Label();
		dqbvQsMDKM = new PictureBox();
		wx5vOVFk1o = new ComboBox();
		JjbvCNxIge = new Label();
		((ISupportInitialize)dqbvQsMDKM).BeginInit();
		SuspendLayout();
		qrBvupvxUo.Location = new Point(33, 45);
		qrBvupvxUo.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11856);
		qrBvupvxUo.Size = new Size(42, 20);
		qrBvupvxUo.TabIndex = 10;
		qrBvupvxUo.KeyUp += zejvEh0FrC;
		lKyvoKGVIi.AutoSize = true;
		lKyvoKGVIi.Location = new Point(1, 49);
		lKyvoKGVIi.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10482);
		lKyvoKGVIi.Size = new Size(30, 13);
		lKyvoKGVIi.TabIndex = 9;
		lKyvoKGVIi.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11178);
		dqbvQsMDKM.Location = new Point(3, 19);
		dqbvQsMDKM.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11872);
		dqbvQsMDKM.Size = new Size(25, 25);
		dqbvQsMDKM.SizeMode = PictureBoxSizeMode.StretchImage;
		dqbvQsMDKM.TabIndex = 7;
		dqbvQsMDKM.TabStop = false;
		wx5vOVFk1o.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		wx5vOVFk1o.DropDownStyle = ComboBoxStyle.DropDownList;
		wx5vOVFk1o.FormattingEnabled = true;
		wx5vOVFk1o.Location = new Point(33, 20);
		wx5vOVFk1o.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11900);
		wx5vOVFk1o.Size = new Size(114, 21);
		wx5vOVFk1o.TabIndex = 12;
		wx5vOVFk1o.SelectedIndexChanged += WTNvrDnR76;
		JjbvCNxIge.AutoSize = true;
		JjbvCNxIge.Location = new Point(3, 2);
		JjbvCNxIge.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		JjbvCNxIge.Size = new Size(0, 13);
		JjbvCNxIge.TabIndex = 13;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(JjbvCNxIge);
		base.Controls.Add(wx5vOVFk1o);
		base.Controls.Add(qrBvupvxUo);
		base.Controls.Add(lKyvoKGVIi);
		base.Controls.Add(dqbvQsMDKM);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(11918);
		base.Size = new Size(150, 68);
		((ISupportInitialize)dqbvQsMDKM).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
