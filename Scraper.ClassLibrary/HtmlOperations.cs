using HtmlAgilityPack;
using Scraper.ClassLibrary.Interfaces;

namespace Scraper.ClassLibrary;

public class HtmlOperations: IHtmlParser
{
    /// <summary>
    /// Returns all links from the given html
    /// </summary>
    /// <param name="html">The html to parse</param>
    /// <param name="url">The url to use as a base for relative links</param>
    public List<string> GetLinks(string html, string url)
    {
        var htmlDoc = new HtmlDocument();
        htmlDoc.LoadHtml(html);
        var links = htmlDoc.DocumentNode.SelectNodes("//a[@href]")
            .Select(x => x.Attributes["href"].Value)
            .ToList();

        // TODO: make all links absolute
        //links = links.Select(x => x.StartsWith("http") ? x : new Uri(url, x)).ToList();
        
        return links;
    }

    /// <summary>
    /// Returns the html from the given url
    /// </summary>
    /// <param name="url">The url to get the html from</param>
    public async Task<string> GetHtml(string url)
    {
        var httpClient = new HttpClient();
        try{
        var html = await httpClient.GetStringAsync(url);
        return html;
        }
        catch(Exception ex){
            Console.WriteLine(ex.Message);
            return string.Empty;
        }
    }
}
