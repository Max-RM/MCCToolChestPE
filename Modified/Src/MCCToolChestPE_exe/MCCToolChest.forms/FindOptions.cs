using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.Properties;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.forms;

public class FindOptions : Form
{
	private FindOptionsAction kTOopBnY2O;

	private IContainer rkfoZ6fIBA;

	private Button EvKoflwUqC;

	private Button LqtoiBsRIn;

	private Button R0mosB9UvQ;

	private Button qN7FindLdbButton;

	public FindOptionsAction Action
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return kTOopBnY2O;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			while (false)
			{
				_ = ((object[])null)[0];
			}
			kTOopBnY2O = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public FindOptions()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		EdpoW9nrRk();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PHpob8iKVQ(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.Icon = Resources.usMSrbJo37S();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void g5Iovraytk(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		kTOopBnY2O = FindOptionsAction.FIND_CHUNK;
		ghRoVXKZYo();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void zQjoweZKl7(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		kTOopBnY2O = FindOptionsAction.FIND_ENTITY;
		ghRoVXKZYo();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AQVo4FPoie(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		kTOopBnY2O = FindOptionsAction.FIND_REPLACE;
		ghRoVXKZYo();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void qN7FindLdbClick(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		kTOopBnY2O = FindOptionsAction.FIND_LDB_KEY;
		ghRoVXKZYo();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ghRoVXKZYo()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		base.DialogResult = DialogResult.OK;
		Close();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && rkfoZ6fIBA != null)
		{
			rkfoZ6fIBA.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EdpoW9nrRk()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		EvKoflwUqC = new Button();
		LqtoiBsRIn = new Button();
		R0mosB9UvQ = new Button();
		qN7FindLdbButton = new Button();
		SuspendLayout();
		EvKoflwUqC.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		EvKoflwUqC.Image = Resources.I3wSEsrMLCN();
		EvKoflwUqC.ImageAlign = ContentAlignment.MiddleLeft;
		EvKoflwUqC.Location = new Point(18, 20);
		EvKoflwUqC.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(54460);
		EvKoflwUqC.Size = new Size(170, 41);
		EvKoflwUqC.TabIndex = 0;
		EvKoflwUqC.Text = "Find Chunk / Block";
		EvKoflwUqC.TextAlign = ContentAlignment.MiddleRight;
		EvKoflwUqC.TextImageRelation = TextImageRelation.ImageBeforeText;
		EvKoflwUqC.UseVisualStyleBackColor = true;
		EvKoflwUqC.Click += g5Iovraytk;
		LqtoiBsRIn.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		LqtoiBsRIn.Image = Resources.GSPSEmZwdCt();
		LqtoiBsRIn.ImageAlign = ContentAlignment.MiddleLeft;
		LqtoiBsRIn.Location = new Point(18, 73);
		LqtoiBsRIn.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(54512);
		LqtoiBsRIn.Size = new Size(170, 41);
		LqtoiBsRIn.TabIndex = 1;
		LqtoiBsRIn.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(54542);
		LqtoiBsRIn.TextAlign = ContentAlignment.MiddleRight;
		LqtoiBsRIn.TextImageRelation = TextImageRelation.ImageBeforeText;
		LqtoiBsRIn.UseVisualStyleBackColor = true;
		LqtoiBsRIn.Click += zQjoweZKl7;
		R0mosB9UvQ.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		R0mosB9UvQ.Image = Resources.fj2SEASwhLn();
		R0mosB9UvQ.ImageAlign = ContentAlignment.MiddleLeft;
		R0mosB9UvQ.Location = new Point(18, 126);
		R0mosB9UvQ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(54568);
		R0mosB9UvQ.Size = new Size(170, 41);
		R0mosB9UvQ.TabIndex = 2;
		R0mosB9UvQ.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(54600);
		R0mosB9UvQ.TextAlign = ContentAlignment.MiddleRight;
		R0mosB9UvQ.TextImageRelation = TextImageRelation.ImageBeforeText;
		R0mosB9UvQ.UseVisualStyleBackColor = true;
		R0mosB9UvQ.Click += AQVo4FPoie;
		qN7FindLdbButton.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		qN7FindLdbButton.Image = Resources.fj2SEASwhLn();
		qN7FindLdbButton.ImageAlign = ContentAlignment.MiddleLeft;
		qN7FindLdbButton.Location = new Point(18, 179);
		qN7FindLdbButton.Name = "qN7FindLdbButton";
		qN7FindLdbButton.Size = new Size(170, 41);
		qN7FindLdbButton.TabIndex = 3;
		qN7FindLdbButton.Text = "Find LDB Key";
		qN7FindLdbButton.TextAlign = ContentAlignment.MiddleRight;
		qN7FindLdbButton.TextImageRelation = TextImageRelation.ImageBeforeText;
		qN7FindLdbButton.UseVisualStyleBackColor = true;
		qN7FindLdbButton.Click += qN7FindLdbClick;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = SystemColors.Control;
		base.ClientSize = new Size(210, 238);
		base.Controls.Add(qN7FindLdbButton);
		base.Controls.Add(R0mosB9UvQ);
		base.Controls.Add(LqtoiBsRIn);
		base.Controls.Add(EvKoflwUqC);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(54636);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = "Find Data";
		base.Load += PHpob8iKVQ;
		ResumeLayout(performLayout: false);
	}
}
