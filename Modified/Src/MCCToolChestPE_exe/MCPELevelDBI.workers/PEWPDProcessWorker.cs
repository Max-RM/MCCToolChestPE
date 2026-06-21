using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using MCCToolChest.model;
using MCCToolChest.PECode;
using MCCToolChest.PECode.model;
using MCCToolChest.utils;
using MCPELevelDBI.model;
using PortableDevices;
using Save_Manager.model;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCPELevelDBI.workers;

public class PEWPDProcessWorker
{
	private BackgroundWorker WmTSpPyau84;

	[CompilerGenerated]
	private static Func<PERegion, int> BGYSpRg1vcY;

	[CompilerGenerated]
	private static Func<PERegion, int> AlNSpklweux;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PEWPDProcessWorker()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PEWPDProcessWorker(BackgroundWorker bw)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		WmTSpPyau84 = bw;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DoPEStaging(PEWorldFolder worldFolder, string workingFolderPath)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Directory.CreateDirectory(Path.Combine(workingFolderPath, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64270)));
		TWNSpaSLC3k(worldFolder, workingFolderPath);
		pk2SpMcIl8a(workingFolderPath);
		GetMaps(workingFolderPath);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TWNSpaSLC3k(PEWorldFolder P_0, string P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		PortableDevice portableDevice = new PortableDevice(P_0.DeviceId);
		PortableDeviceFolder portableDeviceFolder = new PortableDeviceFolder(P_0.FolderId, P_0.Name);
		Dictionary<string, Tuple<PortableDevice, PortableDeviceObject>> dictionary = T6ESpeOnvUZ(portableDevice, portableDeviceFolder);
		if (dictionary.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64270)))
		{
			oftSpX5AST0(portableDevice, dictionary[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64270)].Item2 as PortableDeviceFolder, Path.Combine(P_1, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(64270)));
		}
		if (dictionary.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(86052)))
		{
			oftSpX5AST0(portableDevice, dictionary[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(86052)].Item2 as PortableDeviceFolder, Path.Combine(P_1, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(86052)));
		}
		if (dictionary.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43516)))
		{
			lgNSpx784QI(portableDevice, dictionary[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(43516)].Item2 as PortableDeviceFile, P_1, 8);
		}
		if (dictionary.ContainsKey(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(52810)))
		{
			lgNSpx784QI(portableDevice, dictionary[Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(52810)].Item2 as PortableDeviceFile, P_1);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void oftSpX5AST0(PortableDevice P_0, PortableDeviceFolder P_1, string P_2)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Directory.CreateDirectory(P_2);
		P_0.Connect();
		P_0.GetContents(P_1);
		P_0.Disconnect();
		foreach (PortableDeviceObject file in P_1.Files)
		{
			if (file is PortableDeviceFile)
			{
				lgNSpx784QI(P_0, file as PortableDeviceFile, P_2);
			}
			else if (file is PortableDeviceFolder)
			{
				PortableDeviceFolder portableDeviceFolder = file as PortableDeviceFolder;
				oftSpX5AST0(P_0, portableDeviceFolder, Path.Combine(P_2, portableDeviceFolder.Name));
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void lgNSpx784QI(PortableDevice P_0, PortableDeviceFile P_1, string P_2, int P_3 = 0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_0.Connect();
		byte[] array = P_0.DownloadFile(P_1);
		P_0.Disconnect();
		if (P_3 > 0)
		{
			array = array.Skip(P_3).ToArray();
		}
		FileUtils.WriteFile(array, Path.Combine(P_2, P_1.Name));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Dictionary<string, Tuple<PortableDevice, PortableDeviceObject>> T6ESpeOnvUZ(PortableDevice P_0, PortableDeviceFolder P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		P_0.Connect();
		P_0.GetContents(P_1);
		P_0.Disconnect();
		Dictionary<string, Tuple<PortableDevice, PortableDeviceObject>> dictionary = new Dictionary<string, Tuple<PortableDevice, PortableDeviceObject>>();
		foreach (PortableDeviceObject file in P_1.Files)
		{
			P_0.Connect();
			dictionary.Add(file.Name, new Tuple<PortableDevice, PortableDeviceObject>(P_0, file));
			P_0.Disconnect();
		}
		return dictionary;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void pk2SpMcIl8a(string P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LevelDBWorker levelDBWorker = PEUtility.OpenDBWorker(P_0);
		string[] peFiles = PEConsts.peFiles;
		foreach (string text in peFiles)
		{
			string[] array = text.Split('\\');
			byte[] array2 = levelDBWorker.ReadDbValue(array[1]);
			Directory.CreateDirectory(P_0 + array[0]);
			if (array2 != null && array2.Length > 0)
			{
				string text2 = (PEConsts.txtFiles.Contains(array[1]) ? Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(69582) : Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22554));
				FileUtils.WriteFile(array2, P_0 + text + text2);
			}
		}
		levelDBWorker.CloseDB();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetMaps(string path)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LevelDBWorker levelDBWorker = PEUtility.OpenDBWorker(path);
		List<DBRecord> maps = levelDBWorker.GetMaps();
		foreach (DBRecord item in maps)
		{
			string text = Encoding.ASCII.GetString(item.Key);
			string filename = Path.Combine(path, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(55206), text + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(22554));
			FileUtils.WriteFile(item.Value, filename);
		}
		levelDBWorker.CloseDB();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<PEDimension> GetAvailableChunks(string path)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		LevelDBWorker levelDBWorker = PEUtility.OpenDBWorker(path);
		List<PEDimension> availableChunks = levelDBWorker.GetAvailableChunks();
		levelDBWorker.CloseDB();
		for (int i = 0; i < 3; i++)
		{
			List<PERegion> source = availableChunks[i].Region.Values.ToList();
			source = source.OrderBy([MethodImpl(MethodImplOptions.NoInlining)] (PERegion P_0) =>
			{
				while (false)
				{
					_ = ((object[])null)[0];
				}
				return P_0.RX;
			}).ThenBy([MethodImpl(MethodImplOptions.NoInlining)] (PERegion P_0) =>
			{
				while (false)
				{
					_ = ((object[])null)[0];
				}
				return P_0.RZ;
			}).ToList();
			availableChunks[i].Region.Clear();
			foreach (PERegion item in source)
			{
				availableChunks[i].Region.Add(item.RX + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(13710) + item.RZ, item);
			}
		}
		return availableChunks;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void qP6SpUWNgUN(string P_0, int P_1 = 0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		if (WmTSpPyau84 != null)
		{
			WmTSpPyau84.ReportProgress(P_1, P_0);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static int rd0SpLc2PFj(PERegion P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0.RX;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private static int L0qSpgY1aiF(PERegion P_0)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		return P_0.RZ;
	}
}
