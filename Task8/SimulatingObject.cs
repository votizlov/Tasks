

using System;
using System.Timers;

namespace Task8
{
    public class SimulatingObject
    {
        public Action<SimulatingObject> OnDestroy;
        private float top;
        private float left;
        private float speedX;
        private float speedY;
        private float collisionWidth;
        private float collisionHeight;
        private string tag;

        public SimulatingObject(float top, float left, float speedX, float speedY, float collisionWidth, float collisionHeight, string tag)
        {
            this.top = top;
            this.left = left;
            this.speedX = speedX;
            this.speedY = speedY;
            this.collisionWidth = collisionWidth;
            this.collisionHeight = collisionHeight;
            this.tag = tag;
        }

        public string Tag => tag;

        public float Left => left;

        public float Top => top;

        public float CollisionWidth => collisionWidth;

        public float CollisionHeight => collisionHeight;

        public virtual void CalcNewPosition()
        {
            if (left > 200 || top > 200)
            {
                OnDestroy?.Invoke(this);
            }
            left += speedX;
            top += speedY;
        }
    }
}