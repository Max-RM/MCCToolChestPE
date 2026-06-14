using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using NBTExplorer.Windows;

namespace NBTExplorer;

internal static class Program
{
	[STAThread]
	private static void Main(string[] args)
	{
		Application.ThreadException += AppThreadFailureHandler;
		Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
		AppDomain.CurrentDomain.UnhandledException += AppDomainFailureHandler;
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(defaultValue: false);
		Application.Run(new MainForm());
	}

	public static void StaticInitFailure(Exception e)
	{
		Console.WriteLine("Static Initialization Failure:");
		Exception ex = e;
		while (e != null)
		{
			Console.WriteLine(e.Message);
			Console.WriteLine(e.StackTrace);
			e = e.InnerException;
		}
		MessageBox.Show("Application failed during static initialization: " + ex.Message);
		Application.Exit();
	}

	private static void AppThreadFailureHandler(object sender, ThreadExceptionEventArgs e)
	{
		ProcessException(e.Exception);
	}

	private static void AppDomainFailureHandler(object sender, UnhandledExceptionEventArgs e)
	{
		if (e.ExceptionObject is Exception)
		{
			ProcessException(e.ExceptionObject as Exception);
		}
		else if (e.IsTerminating)
		{
			MessageBox.Show("NBTExplorer encountered an unknown exception object: " + e.ExceptionObject.GetType().FullName, "NBTExplorer failed to run", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			Application.Exit();
		}
	}

	private static void ProcessException(Exception ex)
	{
		if (IsMissingSubstrate(ex))
		{
			MessageBox.Show("NBTExplorer could not find required assembly \"Substrate.dll\".\n\nIf you obtained NBTExplorer from a ZIP distribution, make sure you've extracted NBTExplorer and all of its supporting files into another directory before running it.", "NBTExplorer failed to run", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			Application.Exit();
			return;
		}
		if (IsMissingNBTModel(ex))
		{
			MessageBox.Show("NBTExplorer could not find required assembly \"NBTModel.dll\".\n\nIf you obtained NBTExplorer from a ZIP distribution, make sure you've extracted NBTExplorer and all of its supporting files into another directory before running it.", "NBTExplorer failed to run", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			Application.Exit();
			return;
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("NBTExplorer encountered the following exception while trying to run: " + ex.GetType().Name);
		stringBuilder.AppendLine("Message: " + ex.Message);
		Exception ex2 = ex;
		while (ex2.InnerException != null)
		{
			ex2 = ex2.InnerException;
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("Caused by Inner Exception: " + ex.GetType().Name);
			stringBuilder.AppendLine("Message: " + ex.Message);
		}
		try
		{
			string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "NBTExplorer");
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			string text2 = Path.Combine(text, "error.log");
			using (StreamWriter streamWriter = new StreamWriter(text2, append: true))
			{
				streamWriter.WriteLine("NBTExplorer Error Report");
				streamWriter.WriteLine(DateTime.Now);
				streamWriter.WriteLine("-------");
				streamWriter.WriteLine(stringBuilder);
				streamWriter.WriteLine("-------");
				for (ex2 = ex; ex2 != null; ex2 = ex2.InnerException)
				{
					streamWriter.WriteLine(ex.StackTrace);
					streamWriter.WriteLine("-------");
				}
				streamWriter.WriteLine();
			}
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("Additional error detail has been written to:\n" + text2);
		}
		catch
		{
		}
		MessageBox.Show(stringBuilder.ToString(), "NBTExplorer failed to run", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		Application.Exit();
	}

	private static bool IsMissingSubstrate(Exception ex)
	{
		if (ex is TypeInitializationException && ex.InnerException != null)
		{
			ex = ex.InnerException;
		}
		if (ex is FileNotFoundException)
		{
			FileNotFoundException ex2 = ex as FileNotFoundException;
			if (ex2.FileName.Contains("Substrate"))
			{
				return true;
			}
		}
		return false;
	}

	private static bool IsMissingNBTModel(Exception ex)
	{
		if (ex is TypeInitializationException && ex.InnerException != null)
		{
			ex = ex.InnerException;
		}
		if (ex is FileNotFoundException)
		{
			FileNotFoundException ex2 = ex as FileNotFoundException;
			if (ex2.FileName.Contains("NBTModel"))
			{
				return true;
			}
		}
		return false;
	}
}
