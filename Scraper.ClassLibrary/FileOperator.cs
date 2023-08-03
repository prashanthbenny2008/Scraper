using Scraper.ClassLibrary.Interfaces;

namespace Scraper.ClassLibrary
{
    public class FileOperator : IFileReadWrite
    {
            /// <summary>
            /// Writes the specified content to a file at the specified path.
            /// </summary>
            /// <param name="path">The path of the file to write to.</param>
            /// <param name="content">The content to write to the file.</param>
            /// <returns>A string indicating the success or failure of the operation.</returns>
            public string WriteToFile(string path, string content)
            {
                if (string.IsNullOrEmpty(path))
                {
                    return "The value cannot be an empty string. (Parameter 'path')";
                }
                else
                {
                    try
                    {
                        string? directory = Path.GetDirectoryName(path);
                        Console.WriteLine(directory);
                        if (directory != null)
                        {
                            if (!Directory.Exists(directory))
                            {
                                Directory.CreateDirectory(directory);
                            }
                            File.WriteAllText(path, content);                        
                            return "success";
                        }
                        return "The directory is null.";
                    }
                    catch (Exception ex)
                    {
                        // Console.WriteLine(ex.Message);
                        return ex.Message;
                    }
                }
            }

            /// <summary>
            /// Reads the content of a file from the specified path.
            /// </summary>
            /// <param name="path">The path of the file to read.</param>
            /// <returns>The content of the file as a string.</returns>
            public string ReadFromFile(string path)
            {
                if (string.IsNullOrEmpty(path))
                {
                    return "The value cannot be an empty string. (Parameter 'path')";
                }
                else
                {
                    try
                    {
                        string? directory = Path.GetDirectoryName(path);
                        Console.WriteLine(directory);
                        if (directory != null)
                        {
                            if (!Directory.Exists(directory))
                            {
                                Directory.CreateDirectory(directory);
                            }
                            string content = File.ReadAllText(path);
                            return content;
                        }
                        return "The directory is null.";
                    }
                    catch (Exception ex)
                    {
                        // Console.WriteLine(ex.Message);
                        return ex.Message;
                    }
                }
            }
        }
}