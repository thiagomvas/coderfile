using Cocona;
using coderfile.Core.IO;

namespace coderfile.CLI.Commands
{
    public class Generate
	{

		[Command("readme", Description = "Generate README.md file.")]
		public void README([Option(new char[] { 't' })] string? template)
		{

			TemplateGenerator.Generate("README.md", "Readme", template ?? "basic");
		}
	}
}
