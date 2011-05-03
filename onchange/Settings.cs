using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace onchange
{
	public class Settings
	{
		public static Settings ParseArguments(string[] args)
		{
			string filter=null;
			var reactions = new List<Reaction>();
			for (int i = 0; i < args.Length; i++)
			{
				switch (args[i])
				{
					case "-f":
						filter = args[++i];
						break;
					case "-r":
						reactions.Add(new Reaction(args[++i]));
						break;
				}
				Console.WriteLine(args[i]);
			}

			return new Settings
			       	{
			       		Action = args[args.Length - 1],
						Filter = filter ?? "*.*",
						Reactions = reactions.ToArray()
			       	};
		}


	

		public string Action { get; private set; }

		public string Filter { get; private set; }

		public Reaction[] Reactions
		{
			get; private set;
		}
	}

	public class Reaction
	{
		public Reaction(string input)
		{
			var i = input.Split(':');
			Program = i[1];
			RegEx = new Regex(i[0], RegexOptions.Multiline );
		}
		public String Program { get; private set; }

		public Regex RegEx { get; private set; }
	}
}