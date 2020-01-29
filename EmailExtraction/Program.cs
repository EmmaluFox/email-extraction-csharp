using System;
using System.IO;
using System.Linq;

namespace EmailExtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileContents = File.ReadAllText("Data/sample.txt");
            var searchTerm = "@softwire.com";

            var finalSubstringIndex = fileContents.Length - searchTerm.Length - 1;

            var numberOfMatches = 0;
            foreach (var index in Enumerable.Range(0, finalSubstringIndex))
            {
                if (fileContents.Substring(index, searchTerm.Length) == searchTerm)
                {
                    numberOfMatches++;
                }
            }

            Console.WriteLine($"Fount {numberOfMatches} matches for {searchTerm} in the file.");
        }
    }
}