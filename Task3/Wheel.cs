using System;

namespace Task3
{
    public class Wheel
    {
        private String WheelType;
        /// <summary>
        /// 0 - time to change, 1 - new tire
        /// </summary>
        private float wearFactor;

        Wheel(String wheelType)
        {
            this.WheelType = wheelType;
        }
    }
}