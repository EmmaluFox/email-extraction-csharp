using System;
using System.IO;
using System.Text.RegularExpressions;

namespace EmailExtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileContents = File.ReadAllText("Data/sample.txt");
            const string pattern = @"\S+@softwire.com\b";
            var searchRegex = new Regex(pattern);

            var matches = searchRegex.Matches(fileContents);

            Console.WriteLine($"Fount {matches.Count} matches for {pattern} in the file.");
        }
    }
}