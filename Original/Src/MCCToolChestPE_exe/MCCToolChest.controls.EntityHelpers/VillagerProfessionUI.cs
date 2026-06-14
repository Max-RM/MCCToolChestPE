using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCCToolChest.controllers;
using MCCToolChest.model;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.controls.EntityHelpers;

public class VillagerProfessionUI : UserControl
{
	private TagNodeCompound skBqzZDjON;

	private bool mQHKTeWAcs;

	private int PYoKSGulCZ;

	private int AxrKGHpuPc;

	private int satKbYwJoy;

	private List<string> Nv8KvTQEdR;

	private IContainer rlFKwfAY0m;

	private EntityHelperHeader vrZK4KuFfE;

	private RadioButton PQZKVfAwdl;

	private RadioButton a6eKWBoUJJ;

	private RadioButton qdUKpE95IJ;

	private RadioButton F3hKZaA0ib;

	private RadioButton otrKfhtOTQ;

	private RadioButton suSKi2OXXk;

	private PictureBoxWithInterpolationMode ePuKsvrXnD;

	private GroupBox p8EKqtT1h0;

	private GroupBox Q8tKKxYq4o;

	private RadioButton tcDKhMGjQs;

	private RadioButton XbrKm5X1W7;

	private RadioButton Pv6Kno7Dv0;

	private RadioButton q2ZKlLSQMu;

	private GroupBox xNuK2Bpdyc;

	private RadioButton Du3KyiU0dQ;

	private RadioButton ItdK0TBqo4;

	private GroupBox OjVKB56N1F;

	private RadioButton pssKtwIvqG;

	private RadioButton XoeKahCN72;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public VillagerProfessionUI(TagNodeCompound entity)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		Nv8KvTQEdR = new List<string>();
		s4NqICt9Je();
		skBqzZDjON = entity;
		utXqO7POa9();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void utXqO7POa9()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		mQHKTeWAcs = true;
		Tuple<int, int, MobAge, VillagerBehavior> tuple = Ul5qjxcuo1();
		AxrKGHpuPc = tuple.Item1;
		AOQqCsvk0d(AxrKGHpuPc);
		PQZKVfAwdl.Checked = AxrKGHpuPc == 0;
		a6eKWBoUJJ.Checked = AxrKGHpuPc == 1;
		F3hKZaA0ib.Checked = AxrKGHpuPc == 2;
		qdUKpE95IJ.Checked = AxrKGHpuPc == 3;
		suSKi2OXXk.Checked = AxrKGHpuPc == 4;
		otrKfhtOTQ.Checked = AxrKGHpuPc == 5;
		satKbYwJoy = tuple.Item2;
		P09qd2ONOE(AxrKGHpuPc, satKbYwJoy);
		if (tuple.Item3 == MobAge.Adult)
		{
			ItdK0TBqo4.Checked = true;
		}
		else
		{
			Du3KyiU0dQ.Checked = true;
		}
		if (tuple.Item4 == VillagerBehavior.Peasant)
		{
			pssKtwIvqG.Checked = true;
		}
		else
		{
			XoeKahCN72.Checked = true;
		}
		mQHKTeWAcs = false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AOQqCsvk0d(int P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (P_0 < 0 || P_0 > 5)
		{
			P_0 = 0;
		}
		ePuKsvrXnD.Image = ProfessionImageManager.ProfessionImages.Images[P_0];
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void W9Nq7TlKqB(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (vrZK4KuFfE.ViewState == EntityHelperViewState.Contracted)
		{
			PYoKSGulCZ = base.Height;
			base.Height = vrZK4KuFfE.Top + vrZK4KuFfE.Height;
		}
		else
		{
			base.Height = PYoKSGulCZ;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void eH4qAdyeKS(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		RadioButton radioButton = P_0 as RadioButton;
		string s = radioButton.Tag as string;
		int.TryParse(s, out var result);
		AOQqCsvk0d(result);
		AxrKGHpuPc = result;
		satKbYwJoy = 0;
		P09qd2ONOE(AxrKGHpuPc, satKbYwJoy);
		KosqFs7IIl();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void P09qd2ONOE(int P_0, int P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		List<string> list = Constants.careers[P_0];
		XbrKm5X1W7.Visible = list.Count > 0;
		Pv6Kno7Dv0.Visible = list.Count > 1;
		q2ZKlLSQMu.Visible = list.Count > 2;
		tcDKhMGjQs.Visible = list.Count > 3;
		XbrKm5X1W7.Text = ((list.Count > 0) ? list[0] : "");
		Pv6Kno7Dv0.Text = ((list.Count > 1) ? list[1] : "");
		q2ZKlLSQMu.Text = ((list.Count > 2) ? list[2] : "");
		tcDKhMGjQs.Text = ((list.Count > 3) ? list[3] : "");
		XbrKm5X1W7.Checked = P_1 == 0;
		Pv6Kno7Dv0.Checked = P_1 == 1;
		q2ZKlLSQMu.Checked = P_1 == 2;
		tcDKhMGjQs.Checked = P_1 == 3;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void QU4qHjGpXs(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (XbrKm5X1W7.Checked)
		{
			satKbYwJoy = 0;
		}
		if (Pv6Kno7Dv0.Checked)
		{
			satKbYwJoy = 1;
		}
		if (q2ZKlLSQMu.Checked)
		{
			satKbYwJoy = 2;
		}
		if (tcDKhMGjQs.Checked)
		{
			satKbYwJoy = 3;
		}
		KosqFs7IIl();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void KosqFs7IIl()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (mQHKTeWAcs)
		{
			return;
		}
		TagNodeList tagNodeList = new TagNodeList(TagType.TAG_STRING);
		tagNodeList.Add(new TagNodeString(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18944)));
		if (!ItdK0TBqo4.Checked)
		{
			tagNodeList.Add(new TagNodeString(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18986)));
			tagNodeList.Add(new TagNodeString(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19000)));
		}
		else
		{
			tagNodeList.Add(new TagNodeString(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19016)));
			tagNodeList.Add(new TagNodeString(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19032)));
		}
		tagNodeList.Add(new TagNodeString(Constants.professionNames[AxrKGHpuPc][satKbYwJoy]));
		if (pssKtwIvqG.Checked)
		{
			tagNodeList.Add(new TagNodeString(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19046)));
		}
		else
		{
			tagNodeList.Add(new TagNodeString(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19084)));
		}
		foreach (string item in Nv8KvTQEdR)
		{
			tagNodeList.Add(new TagNodeString(item));
		}
		skBqzZDjON[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19130)] = tagNodeList;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Tuple<int, int, MobAge, VillagerBehavior> Ul5qjxcuo1()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		int item = 0;
		int item2 = 0;
		MobAge item3 = MobAge.Adult;
		VillagerBehavior item4 = VillagerBehavior.Peasant;
		if (skBqzZDjON.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19130)))
		{
			TagNodeList tagNodeList = skBqzZDjON[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19130)] as TagNodeList;
			for (int i = 0; i < tagNodeList.Count; i++)
			{
				string text = tagNodeList[i] as TagNodeString;
				if (Constants.professionId.ContainsKey(text))
				{
					item = Constants.professionId[text];
					item2 = Constants.careerId[text];
				}
				else if (Constants.ageGroup.ContainsKey(text))
				{
					item3 = Constants.ageGroup[text];
				}
				else if (Constants.behaviorGroup.ContainsKey(text))
				{
					item4 = Constants.behaviorGroup[text];
				}
				else if (text != Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18944))
				{
					Nv8KvTQEdR.Add(text);
				}
			}
		}
		return new Tuple<int, int, MobAge, VillagerBehavior>(item, item2, item3, item4);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hJYq8ZYMF4(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		KosqFs7IIl();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ctXq9tGMQK(object P_0, EventArgs P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		KosqFs7IIl();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (disposing && rlFKwfAY0m != null)
		{
			rlFKwfAY0m.Dispose();
		}
		base.Dispose(disposing);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void s4NqICt9Je()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PQZKVfAwdl = new RadioButton();
		a6eKWBoUJJ = new RadioButton();
		qdUKpE95IJ = new RadioButton();
		F3hKZaA0ib = new RadioButton();
		otrKfhtOTQ = new RadioButton();
		suSKi2OXXk = new RadioButton();
		p8EKqtT1h0 = new GroupBox();
		Q8tKKxYq4o = new GroupBox();
		tcDKhMGjQs = new RadioButton();
		XbrKm5X1W7 = new RadioButton();
		Pv6Kno7Dv0 = new RadioButton();
		q2ZKlLSQMu = new RadioButton();
		xNuK2Bpdyc = new GroupBox();
		Du3KyiU0dQ = new RadioButton();
		ItdK0TBqo4 = new RadioButton();
		OjVKB56N1F = new GroupBox();
		pssKtwIvqG = new RadioButton();
		XoeKahCN72 = new RadioButton();
		ePuKsvrXnD = new PictureBoxWithInterpolationMode();
		vrZK4KuFfE = new EntityHelperHeader();
		p8EKqtT1h0.SuspendLayout();
		Q8tKKxYq4o.SuspendLayout();
		xNuK2Bpdyc.SuspendLayout();
		OjVKB56N1F.SuspendLayout();
		((ISupportInitialize)ePuKsvrXnD).BeginInit();
		SuspendLayout();
		PQZKVfAwdl.AutoSize = true;
		PQZKVfAwdl.Location = new Point(14, 19);
		PQZKVfAwdl.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19156);
		PQZKVfAwdl.Size = new Size(57, 17);
		PQZKVfAwdl.TabIndex = 1;
		PQZKVfAwdl.TabStop = true;
		PQZKVfAwdl.Tag = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10708);
		PQZKVfAwdl.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7820);
		PQZKVfAwdl.UseVisualStyleBackColor = true;
		PQZKVfAwdl.CheckedChanged += eH4qAdyeKS;
		a6eKWBoUJJ.AutoSize = true;
		a6eKWBoUJJ.Location = new Point(14, 42);
		a6eKWBoUJJ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19176);
		a6eKWBoUJJ.Size = new Size(65, 17);
		a6eKWBoUJJ.TabIndex = 2;
		a6eKWBoUJJ.TabStop = true;
		a6eKWBoUJJ.Tag = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(18714);
		a6eKWBoUJJ.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7836);
		a6eKWBoUJJ.UseVisualStyleBackColor = true;
		a6eKWBoUJJ.CheckedChanged += eH4qAdyeKS;
		qdUKpE95IJ.AutoSize = true;
		qdUKpE95IJ.Location = new Point(14, 88);
		qdUKpE95IJ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19202);
		qdUKpE95IJ.Size = new Size(76, 17);
		qdUKpE95IJ.TabIndex = 4;
		qdUKpE95IJ.TabStop = true;
		qdUKpE95IJ.Tag = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19230);
		qdUKpE95IJ.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7874);
		qdUKpE95IJ.UseVisualStyleBackColor = true;
		qdUKpE95IJ.CheckedChanged += eH4qAdyeKS;
		F3hKZaA0ib.AutoSize = true;
		F3hKZaA0ib.Location = new Point(14, 65);
		F3hKZaA0ib.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19236);
		F3hKZaA0ib.Size = new Size(51, 17);
		F3hKZaA0ib.TabIndex = 3;
		F3hKZaA0ib.TabStop = true;
		F3hKZaA0ib.Tag = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19256);
		F3hKZaA0ib.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7858);
		F3hKZaA0ib.UseVisualStyleBackColor = true;
		F3hKZaA0ib.CheckedChanged += eH4qAdyeKS;
		otrKfhtOTQ.AutoSize = true;
		otrKfhtOTQ.Location = new Point(14, 134);
		otrKfhtOTQ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19262);
		otrKfhtOTQ.Size = new Size(51, 17);
		otrKfhtOTQ.TabIndex = 6;
		otrKfhtOTQ.TabStop = true;
		otrKfhtOTQ.Tag = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19282);
		otrKfhtOTQ.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7916);
		otrKfhtOTQ.UseVisualStyleBackColor = true;
		otrKfhtOTQ.CheckedChanged += eH4qAdyeKS;
		suSKi2OXXk.AutoSize = true;
		suSKi2OXXk.Location = new Point(14, 111);
		suSKi2OXXk.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19288);
		suSKi2OXXk.Size = new Size(62, 17);
		suSKi2OXXk.TabIndex = 5;
		suSKi2OXXk.TabStop = true;
		suSKi2OXXk.Tag = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19310);
		suSKi2OXXk.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(7898);
		suSKi2OXXk.UseVisualStyleBackColor = true;
		suSKi2OXXk.CheckedChanged += eH4qAdyeKS;
		p8EKqtT1h0.Controls.Add(qdUKpE95IJ);
		p8EKqtT1h0.Controls.Add(PQZKVfAwdl);
		p8EKqtT1h0.Controls.Add(suSKi2OXXk);
		p8EKqtT1h0.Controls.Add(a6eKWBoUJJ);
		p8EKqtT1h0.Controls.Add(otrKfhtOTQ);
		p8EKqtT1h0.Controls.Add(F3hKZaA0ib);
		p8EKqtT1h0.Location = new Point(112, 62);
		p8EKqtT1h0.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19316);
		p8EKqtT1h0.Size = new Size(117, 160);
		p8EKqtT1h0.TabIndex = 0;
		p8EKqtT1h0.TabStop = false;
		p8EKqtT1h0.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19344);
		Q8tKKxYq4o.Controls.Add(tcDKhMGjQs);
		Q8tKKxYq4o.Controls.Add(XbrKm5X1W7);
		Q8tKKxYq4o.Controls.Add(Pv6Kno7Dv0);
		Q8tKKxYq4o.Controls.Add(q2ZKlLSQMu);
		Q8tKKxYq4o.Location = new Point(248, 62);
		Q8tKKxYq4o.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19368);
		Q8tKKxYq4o.Size = new Size(117, 160);
		Q8tKKxYq4o.TabIndex = 7;
		Q8tKKxYq4o.TabStop = false;
		Q8tKKxYq4o.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19388);
		tcDKhMGjQs.AutoSize = true;
		tcDKhMGjQs.Location = new Point(14, 88);
		tcDKhMGjQs.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19404);
		tcDKhMGjQs.Size = new Size(14, 13);
		tcDKhMGjQs.TabIndex = 11;
		tcDKhMGjQs.TabStop = true;
		tcDKhMGjQs.UseVisualStyleBackColor = true;
		tcDKhMGjQs.CheckedChanged += QU4qHjGpXs;
		XbrKm5X1W7.AutoSize = true;
		XbrKm5X1W7.Location = new Point(14, 19);
		XbrKm5X1W7.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19426);
		XbrKm5X1W7.Size = new Size(14, 13);
		XbrKm5X1W7.TabIndex = 8;
		XbrKm5X1W7.TabStop = true;
		XbrKm5X1W7.UseVisualStyleBackColor = true;
		XbrKm5X1W7.CheckedChanged += QU4qHjGpXs;
		Pv6Kno7Dv0.AutoSize = true;
		Pv6Kno7Dv0.Location = new Point(14, 42);
		Pv6Kno7Dv0.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19448);
		Pv6Kno7Dv0.Size = new Size(14, 13);
		Pv6Kno7Dv0.TabIndex = 9;
		Pv6Kno7Dv0.TabStop = true;
		Pv6Kno7Dv0.UseVisualStyleBackColor = true;
		Pv6Kno7Dv0.CheckedChanged += QU4qHjGpXs;
		q2ZKlLSQMu.AutoSize = true;
		q2ZKlLSQMu.Location = new Point(14, 65);
		q2ZKlLSQMu.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19470);
		q2ZKlLSQMu.Size = new Size(14, 13);
		q2ZKlLSQMu.TabIndex = 10;
		q2ZKlLSQMu.TabStop = true;
		q2ZKlLSQMu.UseVisualStyleBackColor = true;
		q2ZKlLSQMu.CheckedChanged += QU4qHjGpXs;
		xNuK2Bpdyc.Controls.Add(Du3KyiU0dQ);
		xNuK2Bpdyc.Controls.Add(ItdK0TBqo4);
		xNuK2Bpdyc.Location = new Point(384, 62);
		xNuK2Bpdyc.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19492);
		xNuK2Bpdyc.Size = new Size(107, 160);
		xNuK2Bpdyc.TabIndex = 12;
		xNuK2Bpdyc.TabStop = false;
		xNuK2Bpdyc.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19506);
		Du3KyiU0dQ.AutoSize = true;
		Du3KyiU0dQ.Location = new Point(14, 19);
		Du3KyiU0dQ.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19516);
		Du3KyiU0dQ.Size = new Size(49, 17);
		Du3KyiU0dQ.TabIndex = 8;
		Du3KyiU0dQ.TabStop = true;
		Du3KyiU0dQ.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19538);
		Du3KyiU0dQ.UseVisualStyleBackColor = true;
		Du3KyiU0dQ.CheckedChanged += hJYq8ZYMF4;
		ItdK0TBqo4.AutoSize = true;
		ItdK0TBqo4.Location = new Point(14, 42);
		ItdK0TBqo4.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19550);
		ItdK0TBqo4.Size = new Size(49, 17);
		ItdK0TBqo4.TabIndex = 9;
		ItdK0TBqo4.TabStop = true;
		ItdK0TBqo4.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19574);
		ItdK0TBqo4.UseVisualStyleBackColor = true;
		ItdK0TBqo4.CheckedChanged += hJYq8ZYMF4;
		OjVKB56N1F.Controls.Add(pssKtwIvqG);
		OjVKB56N1F.Controls.Add(XoeKahCN72);
		OjVKB56N1F.Location = new Point(511, 62);
		OjVKB56N1F.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19588);
		OjVKB56N1F.Size = new Size(109, 160);
		OjVKB56N1F.TabIndex = 13;
		OjVKB56N1F.TabStop = false;
		OjVKB56N1F.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19612);
		pssKtwIvqG.AutoSize = true;
		pssKtwIvqG.Location = new Point(14, 19);
		pssKtwIvqG.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19632);
		pssKtwIvqG.Size = new Size(64, 17);
		pssKtwIvqG.TabIndex = 8;
		pssKtwIvqG.TabStop = true;
		pssKtwIvqG.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19670);
		pssKtwIvqG.UseVisualStyleBackColor = true;
		XoeKahCN72.AutoSize = true;
		XoeKahCN72.Location = new Point(14, 42);
		XoeKahCN72.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19688);
		XoeKahCN72.Size = new Size(87, 17);
		XoeKahCN72.TabIndex = 9;
		XoeKahCN72.TabStop = true;
		XoeKahCN72.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19732);
		XoeKahCN72.UseVisualStyleBackColor = true;
		XoeKahCN72.CheckedChanged += ctXq9tGMQK;
		ePuKsvrXnD.InterpolationMode = InterpolationMode.NearestNeighbor;
		ePuKsvrXnD.Location = new Point(12, 62);
		ePuKsvrXnD.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19758);
		ePuKsvrXnD.Size = new Size(80, 160);
		ePuKsvrXnD.SizeMode = PictureBoxSizeMode.StretchImage;
		ePuKsvrXnD.TabIndex = 9;
		ePuKsvrXnD.TabStop = false;
		vrZK4KuFfE.BackColor = Color.Silver;
		vrZK4KuFfE.Dock = DockStyle.Top;
		vrZK4KuFfE.Font = new Font(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(10438), 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		vrZK4KuFfE.ForeColor = Color.Black;
		vrZK4KuFfE.Location = new Point(0, 0);
		vrZK4KuFfE.Margin = new Padding(4);
		vrZK4KuFfE.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(14148);
		vrZK4KuFfE.Size = new Size(667, 34);
		vrZK4KuFfE.TabIndex = 0;
		vrZK4KuFfE.Text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19344);
		vrZK4KuFfE.ViewState = EntityHelperViewState.Expanded;
		vrZK4KuFfE.ChangeViewState += W9Nq7TlKqB;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(OjVKB56N1F);
		base.Controls.Add(xNuK2Bpdyc);
		base.Controls.Add(Q8tKKxYq4o);
		base.Controls.Add(p8EKqtT1h0);
		base.Controls.Add(ePuKsvrXnD);
		base.Controls.Add(vrZK4KuFfE);
		base.Name = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(19796);
		base.Size = new Size(667, 237);
		p8EKqtT1h0.ResumeLayout(performLayout: false);
		p8EKqtT1h0.PerformLayout();
		Q8tKKxYq4o.ResumeLayout(performLayout: false);
		Q8tKKxYq4o.PerformLayout();
		xNuK2Bpdyc.ResumeLayout(performLayout: false);
		xNuK2Bpdyc.PerformLayout();
		OjVKB56N1F.ResumeLayout(performLayout: false);
		OjVKB56N1F.PerformLayout();
		((ISupportInitialize)ePuKsvrXnD).EndInit();
		ResumeLayout(performLayout: false);
	}
}
