namespace onchange
{
	public class Settings
	{
		public static Settings ParseArguments(string[] args)
		{
			string filter=null;
			for (int i = 0; i < args.Length; i++)
			{
				switch (args[i])
				{
					case "-f":
						filter = args[++i];
						break;
				}
			}

			return new Settings
			       	{
			       		Action = args[args.Length - 1],
						Filter = filter ?? "*.*"
			       	};
		}


	

		public string Action { get; private set; }

		public string Filter { get; private set; }
	}
}