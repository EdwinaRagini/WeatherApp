using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WeatherApp.Helpers
{
	public class FileHelper
	{

		public string GetWorkingDirectory()
		{
			string path = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
			path = Directory.GetParent(path).FullName;
			path = Directory.GetParent(Directory.GetParent(path).FullName).FullName;
			return path;
		}

		public void CreateAndWriteToFile(string filePath, string content)
		{
			using (StreamWriter sw = File.CreateText(filePath))
			{
				sw.WriteLine(content);
			}
		}

		public void DeleteFilesInFolder(string name)
		{
			string path = GetWorkingDirectory() + @"/" + name;
			string[] filePaths = Directory.GetFiles(path);
			foreach (string filePath in filePaths)
				File.Delete(filePath);
		}
	}
}