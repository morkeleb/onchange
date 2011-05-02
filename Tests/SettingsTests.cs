using NUnit.Framework;
using onchange;

namespace Tests
{
	[TestFixture]
	public class SettingsTests
	{
		[Test]
		public void the_last_parameter_is_the_program_to_run_on_change()
		{
			var settings = Settings.ParseArguments(new[] {"", "", "", "ab"});
			Assert.AreEqual(settings.Action, "ab");
		}
		[Test]
		public void the_f_character_is_used_to_set_filter()
		{
			var settings = Settings.ParseArguments(new[] {"-f", "*.pyc"});
			Assert.AreEqual("*.pyc", settings.Filter);
		}
		[Test]
		public void the_default_filter_is_all_files()
		{
			var settings = Settings.ParseArguments(new[] { "", "ab" });
			Assert.AreEqual("*.*", settings.Filter);
		}
		[Test]
		public void a_reaction_is_a_regex_and_a_program_colon_separated()
		{
			var settings = Settings.ParseArguments(new[] {"-r", ".*F.*:fail.bat"});
			Assert.AreEqual("fail.bat", settings.Reactions[0].Program);
			Assert.AreEqual(".*F.*", settings.Reactions[0].RegEx.ToString());

		}
	}
}
