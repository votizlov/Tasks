using System;

namespace Task3
{
    public class Wheel
    {
        private WheelType _wheelType;
        /// <summary>
        /// 0 - time to change, 1 - new tire
        /// </summary>
        private float wearFactor;

        public Wheel(WheelType wheelType)
        {
            _wheelType = wheelType;
        }

        public enum WheelType
        {
            Summer,
            Winter,
            Track
        }
    }
}