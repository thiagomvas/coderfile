namespace coderfile.Core
{
	public static class CLILogger
	{
		public static void LogSuccess(string message)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("V");
			Console.ResetColor();
			Console.WriteLine(message);
		}

		public static void LogWarning(string message)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write("! ");
			Console.ResetColor();
			Console.WriteLine(message);
		}

		public static void LogError(string message)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("X ");
			Console.ResetColor();
			Console.WriteLine(message);
		}

		public static void LogInfo(string message)
		{
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.Write("Info: ");
			Console.ResetColor();
			Console.WriteLine(message);
		}


	}
}
