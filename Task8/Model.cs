using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Task8
{
    public class Model
    {
        public Action stepCallback;
        public Action greenLight;
        private List<SimulatingObject> objects;
        private bool isSimulating = false;

        public List<SimulatingObject> Objects => objects;

        public void StartSim()
        {
            objects = new List<SimulatingObject>();
            objects.Add(new SimulatingObject(0, 100, 1, 1, 1, 1, "Car"));
            isSimulating = true;
            
        }

        private async Task AsyncUpdate()
        {
            while (isSimulating)
            {
                Update();
            }
        }

        public void StopSim()
        {
            isSimulating = false;
        }

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
                for (int j = 1; j < objects.Count; j++)
                {
                    if (CheckCollision(objects[i], objects[j]))
                    {
                        if (objects[i].Tag.Equals("Pedestrian") && objects[j].Tag.Equals("Car") ||
                            objects[i].Tag.Equals("Car") && objects[j].Tag.Equals("Pedestrian"))
                        {
                            SpawnEmergencyCar();
                        }
                    }
                }
            }

            stepCallback?.Invoke();
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