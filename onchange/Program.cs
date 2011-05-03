using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace onchange
{
	public class Program
	{
		private readonly Settings _settings;
		private readonly FileSystemWatcher _watcher;

		static void Main(string[] args)
		{
			var program = new Program(args);
			program.WaitForFinish();
		}

		private void WaitForFinish()
		{
			_watcher.EnableRaisingEvents = true;
			Console.WriteLine("Started watcher " + Directory.GetCurrentDirectory());
			Console.WriteLine("Press return to stop watching for changes.");
			Console.ReadLine();
		}

		protected Program(string[] args)
		{
			_settings = Settings.ParseArguments(args);

			_watcher = new FileSystemWatcher(Directory.GetCurrentDirectory())
			           	{
			           		IncludeSubdirectories = true,
			           		Filter = _settings.Filter
			           	};
			_watcher.Changed += OnChange;
			
			
		}

		private void OnChange(object sender, FileSystemEventArgs e)
		{
			ExecuteAction(e.FullPath);
		}

		public void ExecuteAction(string fullPath)
		{
			Console.WriteLine("change: " + fullPath);
			var text = RunProcess(_settings.Action);
			Console.WriteLine(text);
			foreach (var reaction in _settings.Reactions.Where(reaction => reaction.RegEx.IsMatch(text)))
			{
				RunProcess(reaction.Program);
			}
		}

		protected virtual string RunProcess(string program)
		{
			var p = new Process
			{
				StartInfo =
				{
					FileName = program,
					RedirectStandardOutput = true,
					RedirectStandardError = true,
					UseShellExecute = false
				}
			};
			p.Start();
			p.WaitForExit();
			var text = p.StandardOutput.ReadToEnd() + "\n" + p.StandardError.ReadToEnd();
			return text;
			
		}
	}
}
