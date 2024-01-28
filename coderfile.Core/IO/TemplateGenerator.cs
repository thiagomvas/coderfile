using System.Reflection;

namespace coderfile.Core.IO
{
	public class TemplateGenerator
	{
		public static string templateFolder => Path.Combine(Assembly.GetExecutingAssembly().Location,@"..\..\..\..\contentFiles\any\any\Templates");

		/// <summary>
		/// Shorthand for calling both <see cref="FindTemplateFile(string, string)"/> and <see cref="CloneTemplateFile(string, string)"/>
		/// </summary>
		/// <param name="filename"></param>
		/// <param name="folderPath"></param>
		/// <param name="template"></param>
		public static void Generate(string filename, string folderPath, string template)
		{
			string? path = FindTemplateFile(folderPath, template);

			if (path == null)
			{
				CLILogger.LogError($"Could not find template file {template} in {folderPath}");
			}
			else
				CloneTemplateFile(filename, path);
		}

		public static string? FindTemplateFile(string folderPath, string partialFileName)
		{
			string path = Path.Combine(templateFolder, folderPath);

			string[] allFiles = Directory.GetFiles(path, "*", SearchOption.AllDirectories);

			string? matchingFile = allFiles.FirstOrDefault(file =>
				Path.GetFileNameWithoutExtension(file)
				.StartsWith(partialFileName, StringComparison.OrdinalIgnoreCase));

			if(matchingFile is null)
			{
				CLILogger.LogError($"Could not find template file {partialFileName} in {folderPath}");
			}

			return matchingFile;
		}

		public static void CloneTemplateFile(string name, string templatePath)
		{
			string content = File.ReadAllText(templatePath);
			string path = Path.Combine(Directory.GetCurrentDirectory(), name);

			if (FileManager.CreateFile(path, content))
			{
				CLILogger.LogSuccess($"Created {name} file at {path}");
			}
			else
			{
				CLILogger.LogError($"Failed to create {name} file at {path}");
			}
		}

		public static void GenerateFile(string name, string content)
		{
			string path = Path.Combine(Directory.GetCurrentDirectory(), name);

			if (FileManager.CreateFile(path, content))
			{
				CLILogger.LogSuccess($"Created {name} file at {path}");
			}
			else
			{
				CLILogger.LogError($"Failed to create {name} file at {path}");
			}
		}
	}
}
