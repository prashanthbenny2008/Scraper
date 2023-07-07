using System.Collections.Generic;

namespace Scraper.ClassLibrary.Interfaces
{
    public interface IHtmlParser
    {
        /// <summary>
        /// Returns all links from the given html
        /// </summary>
        /// <param name="html">The html to parse</param>
        List<string> GetLinks(string html, string url);
    }
}