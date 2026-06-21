using System.Runtime.CompilerServices;
using DekWW8jSE3fVOo1d5ao;
using MCCToolChest.model;
using Substrate.Nbt;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.workers;

public class PETileEntityConverters
{
	private EntityLookup OtZS3Uu928v;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ProcessMobSpawner(TagNodeCompound pcTE, TagNodeCompound peTE)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(83434);
		if (pcTE.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(16378)) && OtZS3Uu928v.PCEntities.ContainsKey((TagNodeString)pcTE[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(16378)]))
		{
			text = new TagNodeString(OtZS3Uu928v.PCEntities[(TagNodeString)pcTE[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(16378)]].PCName);
		}
		if (pcTE.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(255752)) && ((TagNodeCompound)pcTE[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(255752)]).ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)) && OtZS3Uu928v.PCEntities.ContainsKey((TagNodeString)((TagNodeCompound)pcTE[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(255752)])[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)]))
		{
			text = new TagNodeString(OtZS3Uu928v.PCEntities[(TagNodeString)((TagNodeCompound)pcTE[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(255752)])[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(9634)]].PCName);
		}
		string d = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(83434);
		if (hvd0XujpavSpj5UhiI6.lfnSVhSnc0q().ContainsKey(text))
		{
			d = text;
		}
		peTE.Remove(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(16378));
		peTE[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(16398)] = new TagNodeString(d);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PETileEntityConverters()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		OtZS3Uu928v = new EntityLookup();
	}
}
