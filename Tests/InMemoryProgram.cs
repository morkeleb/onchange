using System.Collections.Generic;
using onchange;

namespace Tests
{
	/// <summary>
	/// This is a self-shunt of the program to allow testing of reactions
	/// </summary>
	internal class InMemoryProgram : Program
	{
		private readonly string _testText;
		private readonly List<string> _reactions = new List<string>();

		public InMemoryProgram(string[] args, string testText) : base(args)
		{
			_testText = testText;
			ExecuteAction("test");
		}

		protected override string RunProcess(string program)
		{
			switch (program)
			{
				case "ab":
					return _testText;
				default:
					_reactions.Add(program);
					return string.Empty;
			}
		}
		public List<string> Reactions
		{
			get { return _reactions; }
		}
	}
}