using System.Collections.Generic;

namespace Scraper.ClassLibrary.Interfaces
{
    public interface IFileReadWrite
    {
        /// <summary>
        /// Reads the content of a file
        /// </summary>
        /// <param name="path">The path to the file</param>
        string ReadFromFile(string path);

        /// <summary>
        /// Writes the content to a file
        /// </summary>
        /// <param name="path">The path to the file</param>
        /// <param name="content">The content to write</param>
        void WriteToFile(string path, string content);
    }
}