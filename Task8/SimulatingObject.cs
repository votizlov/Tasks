

using System.Timers;

namespace Task8
{
    public class SimulatingObject
    {
        private float posX;
        private float posY;
        private float speedX;
        private float speedY;
        private float collisionWidth;
        private float collisionHeight;
        private string tag;
        

        public void CalcNewPosition()
        {
            posX += speedX;
            posY += speedY;
            
            
        }
    }
}