using System;
using System.IO;
using System.IO.Compression;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using MCCToolChest.Forms;
using MCCToolChest.model;
using MCCToolChest.utils;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace MCCToolChest.workers;

public class ArchiveWorker
{
	private static string FAHSR5nMVQ8;

	private string Cq7SR6D7I77;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ArchiveWorld(Form pform)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		string text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(242644);
		if (!Directory.Exists(Utils.GetGetMCPESaveFolder()))
		{
			return;
		}
		MCPEFolder mCPEFolder = new MCPEFolder(PCSelectDisplayType.Source);
		DialogResult dialogResult = mCPEFolder.ShowDialog(pform);
		if (dialogResult != DialogResult.OK || mCPEFolder.q5UQiauCd2() != 0)
		{
			return;
		}
		string path = mCPEFolder.PEWorldFolder.Path;
		string name = mCPEFolder.PEWorldFolder.Name;
		saveFileDialog.Filter = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(242696);
		saveFileDialog.FileName = name;
		if (saveFileDialog.ShowDialog() == DialogResult.OK && saveFileDialog.FileName.Length > 0)
		{
			string fileName = saveFileDialog.FileName;
			File.Delete(fileName);
			if (!niVSR12kI8I(path, fileName))
			{
				text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(242818) + Environment.NewLine + Cq7SR6D7I77;
			}
			MessageBox.Show(text, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(242864));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExtractWorld()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(242908);
		OpenFileDialog openFileDialog = new OpenFileDialog();
		ArchiveWorker archiveWorker = new ArchiveWorker();
		openFileDialog.Filter = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(242696);
		if (openFileDialog.ShowDialog() == DialogResult.OK && openFileDialog.FileName.Length > 0)
		{
			string fileName = openFileDialog.FileName;
			string extractPath = EB2SR3EBhRA();
			if (!archiveWorker.ExtractZip(extractPath, fileName))
			{
				text = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(242960);
			}
			MessageBox.Show(text, Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(243006));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string EB2SR3EBhRA()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string getMCPESaveFolder = Utils.GetGetMCPESaveFolder();
		string empty = string.Empty;
		bool flag = false;
		do
		{
			empty = KZASREE7LEE();
		}
		while (File.Exists(Path.Combine(getMCPESaveFolder, empty)));
		return Path.Combine(getMCPESaveFolder, empty);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool niVSR12kI8I(string P_0, string P_1)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bool result = true;
		try
		{
			ZipFile.CreateFromDirectory(P_0, P_1, CompressionLevel.Fastest, includeBaseDirectory: false);
		}
		catch (Exception ex)
		{
			result = false;
			Cq7SR6D7I77 = ex.Message;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool ExtractZip(string extractPath, string zipPath)
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		bool result = true;
		try
		{
			ZipFile.ExtractToDirectory(zipPath, extractPath);
		}
		catch (Exception)
		{
			result = false;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string KZASREE7LEE()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		StringBuilder stringBuilder = new StringBuilder();
		Random random = new Random();
		for (int i = 0; i < 12; i++)
		{
			int index = random.Next(0, FAHSR5nMVQ8.Length);
			stringBuilder.Append(FAHSR5nMVQ8[index]);
		}
		return stringBuilder.ToString() + Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31730);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string f7lSRrPHGOC()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		string text = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
		Directory.CreateDirectory(text);
		return text;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ArchiveWorker()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		Cq7SR6D7I77 = string.Empty;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ArchiveWorker()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		FAHSR5nMVQ8 = Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(243050);
	}
}
