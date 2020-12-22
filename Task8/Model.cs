using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Task8
{
    public class Model
    {
        public Action stepCallback;
        public Action greenLight;
        private List<SimulatingObject> objects;
        /// <summary>
        /// time in ms
        /// </summary>
        private int timeStamp = 50;

        private DispatcherTimer mainTimer;
        private DispatcherTimer carSpawnerTimer;
        private DispatcherTimer pedSpawnerTimer;

        public List<SimulatingObject> Objects => objects;

        public void StartSim()
        {
            objects = new List<SimulatingObject>();
            
            mainTimer = new System.Windows.Threading.DispatcherTimer();
            mainTimer.Tick += new EventHandler(Update);
            mainTimer.Interval = new TimeSpan(0,0,0,0,timeStamp);
            mainTimer.Start();
            
            carSpawnerTimer = new System.Windows.Threading.DispatcherTimer();
            carSpawnerTimer.Tick += new EventHandler(Update);
            carSpawnerTimer.Interval = new TimeSpan(0,0,0,10,timeStamp);
            carSpawnerTimer.Start();
            
            pedSpawnerTimer = new System.Windows.Threading.DispatcherTimer();
            pedSpawnerTimer.Tick += new EventHandler(Update);
            pedSpawnerTimer.Interval = new TimeSpan(0,0,0,5,timeStamp);
            pedSpawnerTimer.Start();

        }

        public void StopSim()
        {
            mainTimer.Stop();
            pedSpawnerTimer.Stop();
            carSpawnerTimer.Stop();
        }

        private void Update(object sender, EventArgs e)
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

        private void SpawnCar(object sender, EventArgs e)
        {
            objects.Add(new SimulatingObject(0, 100, 0, 1, 1, 1, "Car"));
        }

        private void SpawnPedestrian(object sender, EventArgs e)
        {
            objects.Add(new SimulatingObject(50, 100, 1, 0, 1, 1, "Pedestrian"));
        }
    }
}