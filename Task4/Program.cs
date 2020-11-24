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


            int sum = 0;
            for (int i = 100; i < 999; i++)
            {
                if (isRightNumber(i))
                {
                    sum += i;
                }
            }
            // sout i
        }

        public static bool isRightNumber(int i)
        {
            int num1;
            num1 = i / 100;
            num2 = i / 10;
            num3 = Math.i / 1;
            {
                
            }
        }
    }
}