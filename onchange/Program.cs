using System;
using System.Diagnostics;
using System.IO;

namespace onchange
{
	class Program
	{
		private static string _response;

		static void Main(string[] args)
		{
			var settings = Settings.ParseArguments(args);
			_response = settings.Action;

			var watcher = new FileSystemWatcher(Directory.GetCurrentDirectory())
			              	{
			              		IncludeSubdirectories = true, 
								Filter = settings.Filter
			              	};
			watcher.Changed += ExecuteProgram;
			watcher.EnableRaisingEvents = true;
			Console.WriteLine("Started watcher " + Directory.GetCurrentDirectory());
			Console.ReadLine();
		}

		private static void ExecuteProgram(object sender, FileSystemEventArgs e)
		{
			Console.WriteLine("change: " + e.FullPath);
			var p = new Process
			        	{
			        		StartInfo =
			        			{
			        				FileName = _response, 
									RedirectStandardOutput = true, 
									UseShellExecute = false
			        			}
			        	};
			p.Start();
			p.StandardOutput.ReadToEnd();
		}
	}
}
