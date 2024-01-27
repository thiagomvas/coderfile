using Cocona;
using coderfile.CLI.Commands;

[HasSubCommands(typeof(Generate), Description = "Generate code files.")]
class Program
{
	static void Main(string[] args) => CoconaApp.Run<Program>(args);
}