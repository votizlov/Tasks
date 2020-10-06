using System;
using System.Text.RegularExpressions;

namespace Task2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string pattern = @"\b(\w+?)\s\1\b";
            string text = System.IO.File.ReadAllText(@"Input\Input.txt");
            
            foreach (Match match in Regex.Matches(text, pattern, RegexOptions.IgnoreCase))
                Console.WriteLine("{0} (duplicates '{1}') at position {2}",
                    match.Value, match.Groups[1].Value, match.Index);
        }
    }
}