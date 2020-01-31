using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace EmailExtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileContents = File.ReadAllText("Data/sample.txt");
            const string pattern = @"\S+@(?<domain>\S+)\b";
            var searchRegex = new Regex(pattern);

            var matches = searchRegex.Matches(fileContents);

            var domains = new Dictionary<string, int>();
            foreach (Match match in matches)
            {
                var groups = match.Groups;
                var domain = groups["domain"].Value;

                if (domains.ContainsKey(domain))
                {
                    domains[domain]++;
                }
                else
                {
                    domains.Add(domain, 1);
                }
            }

            var domainList = domains.ToList();
            domainList.Sort((left, right) => right.Value.CompareTo(left.Value));
            
            PrintDomains(domainList);
        }

        private static void PrintDomains(IEnumerable<KeyValuePair<string, int>> domains)
        {
            foreach (var (key, value) in domains)
            {
                Console.WriteLine($"{key}: {value}");
            }
        }
    }
}