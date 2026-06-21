using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using MCCToolChest.controllers;
using MCCToolChest.model;
using uP7B13T5waxVpI3AEv;
using YBh7EaXMWmkFRJOX37M;

namespace dJ9gJMugJCIyCsx5I39;

internal class bBZMC0uOW5A7L8yvqOi
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Dictionary<string, Image> gBgSkEDKNoT()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		EntityLookup entityLookup = new EntityLookup();
		Dictionary<string, Image> dictionary = new Dictionary<string, Image>();
		foreach (string key2 in MobImageManager.SOLG0vnEyp().Keys)
		{
			Image value = MobImageManager.MobImages.Images[MobImageManager.SOLG0vnEyp()[key2].ImageId];
			string key = key2;
			if (entityLookup.PCEntities.ContainsKey(key2))
			{
				key = entityLookup.PCEntities[key2].PCName;
			}
			if (!dictionary.ContainsKey(key))
			{
				dictionary.Add(key, value);
			}
		}
		foreach (string key3 in Constants.BEDROCK_ENTITY_BLOCKS_BY_NAME.Keys)
		{
			int num = Constants.BEDROCK_ENTITY_BLOCKS_BY_NAME[key3];
			Image value2 = BFRL2f2UoG7tBGIHJF.xRoSMGJq48(num, 0);
			if (!dictionary.ContainsKey(key3))
			{
				dictionary.Add(key3, value2);
			}
		}
		return dictionary;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bBZMC0uOW5A7L8yvqOi()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}
}
