using System.Collections.Generic;
using System.Threading.Tasks;

namespace Task8
{
    public class Model
    {
        private List<SimulatingObject> objects;

        private void Update()
        {
            //update position
            foreach (var obj in objects)
            {
                obj.CalcNewPosition();
            }
            //check collision
            for (int i = 0; i < objects.Count; i++)
            {
                for (int j = 0; j<objects.Count;j++)
                {
                    
                }
            }
        }

        private bool CheckCollision(SimulatingObject o1, SimulatingObject o2)
        {
            return false;
        }

        private void SpawnEmergencyCar()
        {
            
        }

        private void SpawnCar()
        {
            
        }

        private void SpawnPedestrian()
        {
            
        }
    }
}