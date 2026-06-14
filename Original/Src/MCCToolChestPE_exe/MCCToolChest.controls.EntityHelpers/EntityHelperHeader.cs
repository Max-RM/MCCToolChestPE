using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using MCCToolChest.Properties;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls.EntityHelpers;

public class EntityHelperHeader : UserControl
{
	private EventHandler eUHiDm5Rou;

	private EntityHelperViewState Hgeicjt2OY;

	private IContainer sXEiJiXRAF;

	private Label e2aiuoGfNA;

	private PictureBox pKCioJgapG;

	public EntityHelperViewState ViewState
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return Hgeicjt2OY;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			Hgeicjt2OY = value;
		}
	}

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
			return e2aiuoGfNA.Text;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			e2aiuoGfNA.Text = value;
		}
	}

	public event EventHandler ChangeViewState
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			EventHandler eventHandler = eUHiDm5Rou;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eUHiDm5Rou, value2, eventHandler2);
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
			EventHandler eventHandler = eUHiDm5Rou;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eUHiDm5Rou, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EntityHelperHeader()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		UEeiN2uLOv();
		e3Ji5bQWd4();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnChangeViewState(object sender, EventArgs e)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		eUHiDm5Rou?.Invoke(this, e);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RQJircHZL9(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hgeicjt2OY = ((Hgeicjt2OY != EntityHelperViewState.Contracted) ? EntityHelperViewState.Contracted : EntityHelperViewState.Expanded);
		e3Ji5bQWd4();
		OnChangeViewState(this, null);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void e3Ji5bQWd4()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		pKCioJgapG.BackgroundImage = ((Hgeicjt2OY == EntityHelperViewState.Expanded) ? Resources.gJmS1frBZV5() : Resources.OwTS1Kk3wBq());
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnTextChanged(EventArgs eventArgs)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		e2aiuoGfNA.Text = eventArgs.ToString();
		base.OnTextChanged(eventArgs);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void dgQi689YPm(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int left = base.Width - (pKCioJgapG.Width + 20);
		pKCioJgapG.Left = left;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && sXEiJiXRAF != null)
		{
			sXEiJiXRAF.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UEeiN2uLOv()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		e2aiuoGfNA = new Label();
		pKCioJgapG = new PictureBox();
		((ISupportInitialize)pKCioJgapG).BeginInit();
		SuspendLayout();
		e2aiuoGfNA.AutoSize = true;
		e2aiuoGfNA.Location = new Point(12, 9);
		e2aiuoGfNA.Margin = new Padding(4, 0, 4, 0);
		e2aiuoGfNA.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17886);
		e2aiuoGfNA.Size = new Size(46, 18);
		e2aiuoGfNA.TabIndex = 0;
		e2aiuoGfNA.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10714);
		e2aiuoGfNA.Click += RQJircHZL9;
		pKCioJgapG.BackColor = Color.Transparent;
		pKCioJgapG.BackgroundImage = Resources.OwTS1Kk3wBq();
		pKCioJgapG.Location = new Point(723, 5);
		pKCioJgapG.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17916);
		pKCioJgapG.Size = new Size(25, 25);
		pKCioJgapG.TabIndex = 2;
		pKCioJgapG.TabStop = false;
		pKCioJgapG.Click += RQJircHZL9;
		base.AutoScaleDimensions = new SizeF(9f, 18f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.Silver;
		base.Controls.Add(pKCioJgapG);
		base.Controls.Add(e2aiuoGfNA);
		Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		ForeColor = Color.Black;
		base.Margin = new Padding(4);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(17942);
		base.Size = new Size(764, 35);
		base.Click += RQJircHZL9;
		base.Resize += dgQi689YPm;
		((ISupportInitialize)pKCioJgapG).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
