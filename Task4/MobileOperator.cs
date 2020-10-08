using System;

namespace Task4
{
    public class MobileOperator
    {
        private String name;
        private float costOfMinute;
        private float coverCange;

        public MobileOperator(String name,float coverCange,float costOfMinute)
        {
            this.name = name;
            this.coverCange = coverCange;
            this.costOfMinute = costOfMinute;
        }

        public float GetQuality()
        {
            return 100 * coverCange / costOfMinute;
        }

        public void PrintInfo()
        {
            Console.WriteLine(name + coverCange + costOfMinute);
        }
    }
}