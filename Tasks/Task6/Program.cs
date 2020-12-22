using System.Collections.Generic;

namespace Task6
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<Abitur> abiturs = new List<Abitur>();
            abiturs.Add(new PartTimeStudent("csf","amm",1));
            PartTimeStudent student = (PartTimeStudent)abiturs[0];
            student.PrintInfo();
        }
    }
}