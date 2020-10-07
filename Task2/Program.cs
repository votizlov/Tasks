using System;
using System.Text.RegularExpressions;

namespace Task2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string pattern = @"[^.]* наказываются|наказывается [^.]*\.";
            string text = System.IO.File.ReadAllText(@"Input\Input.txt");
            
            foreach (Match match in Regex.Matches(text, pattern, RegexOptions.IgnoreCase))
                Console.WriteLine("{0} at position {1}",
                    match.Value,  match.Index);
        }
    }
}