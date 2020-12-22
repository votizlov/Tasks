using System;

namespace Task4
{
    public class ConnectionMobileOperator : MobileOperator
    {
        private bool isCostForConnection;

        public override float GetQuality()
        {
            if (isCostForConnection)
            {
                return 0.7f * 100 * coverCange / costOfMinute;;
            }

            return 1.5f * 100 * coverCange / costOfMinute;;
        }

        public ConnectionMobileOperator(string name, float coverCange, float costOfMinute, bool isCostForConnection) :
            base(name, coverCange, costOfMinute)
        {
            this.isCostForConnection = isCostForConnection;
        }

        public override void PrintInfo()
        {
            Console.WriteLine(name + " " + coverCange+ " "  + costOfMinute+" "+isCostForConnection);
        }
    }
}