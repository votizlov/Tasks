using System;
using System.IO;

namespace Task4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            MobileOperator o1 = new MobileOperator("MTS",100,2);
            Console.WriteLine(o1.GetQuality());
            o1.PrintInfo();
            MobileOperator o2 = new ConnectionMobileOperator("beeline",100,3,true);
            Console.WriteLine(o2.GetQuality());
            o2.PrintInfo();
        }
    }
}