using Cocona;
using coderfile.Core;
using coderfile.Core.IO;

namespace coderfile.CLI.Commands
{
	public class Generate
	{

		[Command("readme", Description = "Generate a README.md file.")]
		public void README(TemplateParams templateParams)
		{
			if (!templateParams.Preview)
				TemplateGenerator.Generate(Path.Combine(templateParams.Output, "README.md"), "Readme", templateParams.Template ?? "basic");
			else
			{
				var content = TemplateGenerator.GetTemplateContent("Readme", templateParams.Template ?? "basic");
				CLILogger.LogInfo("Previewing template...");
				Console.WriteLine(content);
				CLILogger.LogInfo($"File would be generated at {Path.Combine(Directory.GetCurrentDirectory(), templateParams.Output, "README.md")}");
			}
		}

		[Command("license", Description = "Generate a LICENSE file.")]
		public void License(TemplateParams templateParams, string fullname)
		{
			string? path = TemplateGenerator.FindTemplateFile("Licenses", templateParams.Template ?? "mit");
			if (path is not null)
			{
				string content = File.ReadAllText(path);
				content = content.Replace("{{fullname}}", fullname).Replace("{{year}}", DateTime.Now.Year.ToString());
				if (!templateParams.Preview)
					TemplateGenerator.GenerateFile("LICENSE", content);
				else
				{
					CLILogger.LogInfo("Previewing template...");
					Console.WriteLine(content);
					CLILogger.LogInfo($"File would be generated at {Path.Combine(Directory.GetCurrentDirectory(), templateParams.Output, "LICENSE")}");
				}
			}
		}

		[Command("codeofconduct", Aliases = ["conduct"], Description = "Generate a Code Of Conduct file.")]
		public void CodeOfConduct(TemplateParams templateParams, string contact)
		{
			string? path = TemplateGenerator.FindTemplateFile("CodeOfConduct", templateParams.Template ?? "contributor-covenant");
			if (path is not null)
			{
				string content = File.ReadAllText(path);
				content = content.Replace("{{contact}}", contact);
				if (!templateParams.Preview)
					TemplateGenerator.GenerateFile("CODE_OF_CONDUCT.md", content);
				else
				{
					CLILogger.LogInfo("Previewing template...");
					Console.WriteLine(content);
					CLILogger.LogInfo($"File would be generated at {Path.Combine(Directory.GetCurrentDirectory(), templateParams.Output, "CODE_OF_CONDUCT.md")}");
				}
			}
		}

		[Command("gitkeep", Description = "Generate an empty .gitkeep file to track an empty directory")]
		public void Gitkeep([Option('o', Description = "The relative path to the target folder to add the gitkeep")] string? output)
		{
			TemplateGenerator.GenerateFile(output is not null ? Path.Combine(output, ".gitkeep") : ".gitkeep", "");
		}

		public void Contributing(TemplateParams templateParams)
		{
			if (!templateParams.Preview)
				TemplateGenerator.Generate("CONTRIBUTING.md", "Contributing", templateParams.Template ?? "basic");
			else
			{
				var content = TemplateGenerator.GetTemplateContent("Contributing", templateParams.Template ?? "basic");
				CLILogger.LogInfo("Previewing template...");
				Console.WriteLine(content);
				CLILogger.LogInfo($"File would be generated at {Path.Combine(Directory.GetCurrentDirectory(), templateParams.Output, "CONTRIBUTING.md")}");
			}
		}

	}

	public class TemplateParams : ICommandParameterSet
	{
		[HasDefaultValue()]
		[Option('t', Description = "The template file to use. (For information, use \"coderfile templates list\")")]
		public string? Template { get; set; } = null;

		[HasDefaultValue()]
		[Option('o', Description = "The output file path.")]
		public string Output { get; set; } = "";

		[HasDefaultValue()]
		[Option('p', Description = "Preview the file content.")]
		public bool Preview { get; set; } = false;
	}
}
