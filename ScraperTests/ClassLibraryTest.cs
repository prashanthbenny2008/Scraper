using NUnit.Framework;
using Scraper.ClassLibrary;

namespace ScraperTests
{
    public class FileOperatorTests
    {
         private readonly string _testFilePath = "test.txt";
        private readonly string _testContent = "This is a test content.";

        [SetUp]
        public void Setup()
        {
            // Delete the test file if it exists
            if (File.Exists(_testFilePath))
            {
                File.Delete(_testFilePath);
            }
        }

        [Test]
        public void WriteToFile_FileDoesNotExist_CreatesFileAndWritesContent()
        {
            // Arrange
            var fileOperator = new FileOperator();

            // Act
            var result = fileOperator.WriteToFile(_testFilePath, _testContent);

            // Assert
            Assert.AreEqual("success", result);
            Assert.IsTrue(File.Exists(_testFilePath));
            Assert.AreEqual(_testContent, File.ReadAllText(_testFilePath));
        }

        [Test]
        public void WriteToFile_EmptyPath_ReturnsErrorMessage()
        {
            // Arrange
            var fileOperator = new FileOperator();

            // Act
            var result = fileOperator.WriteToFile("", _testContent);

            // Assert
            Assert.AreNotEqual("success", result);
        }

        [Test]
        public void ReadFromFile_FileExists_ReturnsContent()
        {
            // Arrange
            var fileOperator = new FileOperator();
            File.WriteAllText(_testFilePath, _testContent);

            // Act
            var result = fileOperator.ReadFromFile(_testFilePath);

            // Assert
            Assert.AreEqual(_testContent, result);
        }

        [Test]
        public void ReadFromFile_FileDoesNotExist_ReturnsEmptyString()
        {
            // Arrange
            var fileOperator = new FileOperator();

            // Act
            var result = fileOperator.ReadFromFile(_testFilePath);

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        // [Test]
        // public async Task GetHtmlAsync_ValidUrl_ReturnsHtml()
        // {
        //     // Arrange
        //     var htmlOperations = new HtmlOperations();
        //     var url = "https://www.google.com";

        //     // Act
        //     var result = await htmlOperations.GetHtmlAsync(url);

        //     // Assert
        //     Assert.IsNotNull(result);
        //     Assert.IsTrue(result.Contains("<html"));
        // }

        // [Test]
        // public async Task GetHtmlAsync_InvalidUrl_ReturnsEmptyString()
        // {
        //     // Arrange
        //     var htmlOperations = new HtmlOperations();
        //     var url = "https://www.invalidurl.com";

        //     // Act
        //     var result = await htmlOperations.GetHtmlAsync(url);

        //     // Assert
        //     Assert.AreEqual(string.Empty, result);
        // }
    }
}