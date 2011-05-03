using NUnit.Framework;

namespace Tests
{
	[TestFixture]
	class OutputParsingTests
	{
		[Test]
		public void onchange_will_execute_a_reaction_on_matched_regex_in_output()
		{
			var p = new InMemoryProgram(new[]{"-r", "^\\.*(F|E)\\.*$:dd","ab"}, "--\n..F...\n---" );
			Assert.Contains("dd", p.Reactions);
		}
	}
}
