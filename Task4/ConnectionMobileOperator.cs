namespace Task4
{
    public class ConnectionMobileOperator : MobileOperator
    {
        private bool isCostForConnection;

        public new float GetQuality()
        {
            if (isCostForConnection)
            {
                return 0.7f * GetQuality();
            }
            else
            {
                return 1.5f * GetQuality();
            }
        }

        public ConnectionMobileOperator(string name, float coverCange, float costOfMinute, bool isCostForConnection) :
            base(name, coverCange, costOfMinute)
        {
            this.isCostForConnection = isCostForConnection;
        }

        public new void PrintInfo()
        {
            
        }
    }
}