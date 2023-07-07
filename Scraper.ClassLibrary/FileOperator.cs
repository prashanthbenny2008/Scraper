using System.IO;
using Scraper.ClassLibrary.Interfaces;

namespace Scraper.ClassLibrary
{
    public class FileOperator : IFileReadWrite
    {
        public void WriteToFile(string path, string content)
        {
            string directory = Path.GetDirectoryName(path);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            File.WriteAllText(path, content);
        }

        public string ReadFromFile(string path)
        {
            return File.ReadAllText(path);
        }
    }
}