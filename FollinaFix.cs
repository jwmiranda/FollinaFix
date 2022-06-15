using System;
using System.IO;
using System.Diagnostics;


public class ff{
	public static void Main(string[] args){
		command(@"/c reg export HKEY_CLASSES_ROOT\ms-msdt C:\msdt_regkey_backup.reg");
		command(@"/c reg delete HKEY_CLASSES_ROOT\ms-msdt /f");
		Console.ReadKey();
	}
	
	static string command(string arg)
	{
		Process cmd;
		cmd = new Process();
        cmd.StartInfo.FileName = "cmd.exe";
		cmd.StartInfo.Arguments = arg;
        cmd.StartInfo.RedirectStandardInput = true;
        cmd.StartInfo.RedirectStandardOutput = true;
        cmd.StartInfo.CreateNoWindow = false;
        cmd.StartInfo.UseShellExecute = false;
        cmd.Start();
		StreamReader reader = cmd.StandardOutput;
		cmd.WaitForExit();
		return reader.ReadToEnd();
	}
}