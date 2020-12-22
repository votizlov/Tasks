using System;

namespace Task8
{
    public class Pedestrian:SimulatingObject
    {
        private bool isSafeToGo = false;
        public Pedestrian(float top, float left, float speedX, float speedY, float collisionWidth, float collisionHeight, string tag) : base(top, left, speedX, speedY, collisionWidth, collisionHeight, tag)
        {
        }

        public void toggleSafe()
        {
            isSafeToGo = !isSafeToGo;
        }

        public override void CalcNewPosition()
        {
            if(isSafeToGo)
                base.CalcNewPosition();
        }
    }
}