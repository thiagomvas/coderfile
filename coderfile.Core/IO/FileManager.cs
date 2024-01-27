namespace coderfile.Core.IO
{
	public static class FileManager
	{
		public static bool CreateFile(string path, string content)
		{
			try
			{
				File.WriteAllText(path, content);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}
