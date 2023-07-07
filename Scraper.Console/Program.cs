using System;

class Program
{
    static void Main(string[] args)
    {
        if(args.Length == 0){
            Console.WriteLine("Enter parametes as arguments to the program like this: dotnet run --project Scraper.Console Google https://www.google.com");
            return;
        }
        
        string SiteName = args[0]; //get the website name to create a folder
        string url = args[1]; //get the url as an argument

        //initialize and get the html from the url
        var scraper = new Scraper.ClassLibrary.HtmlOperations();
        string html = scraper.GetHtml(url).Result;
        
        if(string.IsNullOrEmpty(html)){
            Console.WriteLine("No html found");
            return;
        }

        //write the homepage
        var fileOperator = new Scraper.ClassLibrary.FileOperator();
        fileOperator.WriteToFile( SiteName + "/home.txt", html);
        
        //Get all the links from the html
        var links = scraper.GetLinks(html, url);
        foreach(var link in links){
            Console.WriteLine(link);
            
            //TODO: Filter the neccessary links, get the html from the link, Write to file

        }
    }
}
