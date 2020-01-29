using System;
using System.Collections.Generic;
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

            var domains = new Dictionary<string, int>();
            foreach (Match match in matches)
            {
                var groups = match.Groups;
                var domain = groups[0].Value;

                if (domains.ContainsKey(domain))
                {
                    domains[domain]++;
                }
                else
                {
                    domains.Add(domain, 1);
                }
            }

            PrintDomains(domains);
        }

        private static void PrintDomains(Dictionary<string, int> dictionary)
        {
            foreach (var keyValuePair in dictionary)
            {
                Console.WriteLine($"{keyValuePair.Key}: {keyValuePair.Value}");
            }
        }
    }
}