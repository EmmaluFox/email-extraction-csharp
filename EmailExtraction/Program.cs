using System;
using System.IO;

namespace EmailExtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileContents = File.ReadAllText("Data/sample.txt");
            Console.WriteLine(fileContents);
        }
    }
}