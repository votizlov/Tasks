using System;

namespace Task4
{
    public class MobileOperator
    {
        protected String name;
        protected float costOfMinute;
        protected float coverCange;

        public MobileOperator(String name,float coverCange,float costOfMinute)
        {
            this.name = name;
            this.coverCange = coverCange;
            this.costOfMinute = costOfMinute;
        }

        public virtual float GetQuality()
        {
            return 100 * coverCange / costOfMinute;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine(name + " " + coverCange+ " "  + costOfMinute);
        }
    }
}