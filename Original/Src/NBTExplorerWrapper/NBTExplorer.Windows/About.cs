using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace NBTExplorer.Windows;

public class About : Form
{
	private IContainer components;

	private LinkLabel linkLabel1;

	private PictureBox pictureBox1;

	public About()
	{
		InitializeComponent();
		int length = linkLabel1.Text.Length;
		Version version = typeof(About).Assembly.GetName().Version;
		linkLabel1.Text = linkLabel1.Text.Replace("{ver}", version.Major + "." + version.Minor + "." + version.Build);
		int num = linkLabel1.Text.Length - length;
		linkLabel1.LinkArea = new LinkArea(linkLabel1.LinkArea.Start + num, linkLabel1.LinkArea.Length);
	}

	private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		Process.Start("https://github.com/jaquadro/NBTExplorer");
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NBTExplorer.Windows.About));
		this.linkLabel1 = new System.Windows.Forms.LinkLabel();
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		base.SuspendLayout();
		this.linkLabel1.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.linkLabel1.LinkArea = new System.Windows.Forms.LinkArea(171, 31);
		this.linkLabel1.Location = new System.Drawing.Point(96, 12);
		this.linkLabel1.Name = "linkLabel1";
		this.linkLabel1.Size = new System.Drawing.Size(272, 133);
		this.linkLabel1.TabIndex = 0;
		this.linkLabel1.TabStop = true;
		this.linkLabel1.Text = resources.GetString("linkLabel1.Text");
		this.linkLabel1.UseCompatibleTextRendering = true;
		this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel1_LinkClicked);
		this.pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
		this.pictureBox1.Location = new System.Drawing.Point(12, 12);
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.Size = new System.Drawing.Size(78, 78);
		this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.pictureBox1.TabIndex = 1;
		this.pictureBox1.TabStop = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(380, 144);
		base.Controls.Add(this.pictureBox1);
		base.Controls.Add(this.linkLabel1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "About";
		this.Text = "About NBTExplorer";
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		base.ResumeLayout(false);
	}
}
