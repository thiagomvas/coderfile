using Cocona;
using coderfile.Core.IO;
using System.Diagnostics;

namespace coderfile.CLI.Commands
{
	public class Templates
	{
		[Command("open")]
		public void OpenTemplateFolder()
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("Opening template folder...");
			Console.ResetColor();
			Process.Start("explorer.exe", TemplateGenerator.templateFolder);
		}
	}
}
