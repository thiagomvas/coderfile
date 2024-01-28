using Cocona;
using coderfile.Core.IO;

namespace coderfile.CLI.Commands
{
    public class Generate
	{

		[Command("readme", Description = "Generate README.md file.")]
		public void README([Option(['t'])] string? template)
		{
			TemplateGenerator.Generate("README.md", "Readme", template ?? "basic");
		}

		public void License([Option(['t'])] string? template, string fullname)
		{
			string? path = TemplateGenerator.FindTemplateFile("Licenses", template ?? "mit");
			if(path is not null)
			{
				string content = File.ReadAllText(path);
				content = content.Replace("{{fullname}}", fullname).Replace("{{year}}", DateTime.Now.Year.ToString());
				TemplateGenerator.GenerateFile("LICENSE", content);
			}

		}
	}
}
