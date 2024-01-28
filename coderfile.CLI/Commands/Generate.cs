using Cocona;
using coderfile.Core.IO;

namespace coderfile.CLI.Commands
{
    public class Generate
	{

		[Command("readme", Description = "Generate a README.md file.")]
		public void README(TemplateParams templateParams)
		{
			TemplateGenerator.Generate("README.md", "Readme", templateParams.Template ?? "basic");
		}

		[Command("license", Description = "Generate a LICENSE file.")]
		public void License(TemplateParams templateParams, string fullname)
		{
			string? path = TemplateGenerator.FindTemplateFile("Licenses", templateParams.Template ?? "mit");
			if(path is not null)
			{
				string content = File.ReadAllText(path);
				content = content.Replace("{{fullname}}", fullname).Replace("{{year}}", DateTime.Now.Year.ToString());
				TemplateGenerator.GenerateFile("LICENSE", content);
			}
		}

		[Command("codeofconduct", Aliases = ["conduct"], Description = "Generate a Code Of Conduct file.")]
		public void CodeOfConduct(TemplateParams templateParams, string contact)
		{
			string? path = TemplateGenerator.FindTemplateFile("CodeOfConduct", templateParams.Template ?? "contributor-covenant");
			if(path is not null)
			{
				string content = File.ReadAllText(path);
				content = content.Replace("{{contact}}", contact);
				TemplateGenerator.GenerateFile("CODE_OF_CONDUCT.md", content);
			}
		}

		[Command("gitkeep", Description = "Generate an empty .gitkeep file to track an empty directory")]
		public void Gitkeep([Option('o', Description = "The relative path to the target folder to add the gitkeep")] string? output)
		{
			TemplateGenerator.GenerateFile(output is not null ? Path.Combine(output, ".gitkeep") : ".gitkeep", "");
		}

	}

	public class TemplateParams : ICommandParameterSet
	{
		[HasDefaultValue()]
		[Option('t', Description = "The template file to use. (For information, use \"coderfile templates list\")")]
		public string? Template { get; set; } = "";
	}
}
