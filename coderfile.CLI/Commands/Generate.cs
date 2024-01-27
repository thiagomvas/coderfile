using Cocona;
using coderfile.CLI.Common.Templates;
using coderfile.Core.IO;
using System.Reflection;

namespace coderfile.CLI.Commands
{
	public class Generate
	{

		[Command("readme", Description = "Generate README.md file.")]
		public void README([Option(new char[] { 't' })] string? template)
		{
			string content = Readme.GetTemplate(template ?? "basic");
			string path = Path.Combine(Directory.GetCurrentDirectory(), "README.md");
			if (FileManager.CreateFile(path, content))
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.Write("✓ ");
				Console.ResetColor();
				Console.WriteLine($"README.md: Created file at {path}");
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.Write("X ");
				Console.ResetColor();
				Console.WriteLine($"README.md: Failed to create file at {path}");
			}
		}
	}
}
