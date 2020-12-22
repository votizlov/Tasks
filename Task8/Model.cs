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
        public Action<string> textCallback;
        public Action toggleGreenLight;
        private List<SimulatingObject> objects;
        private List<SimulatingObject> destroyedObjectsBuffer;

        /// <summary>
        /// time in ms
        /// </summary>
        private int timeStamp = 50;

        private DispatcherTimer mainTimer;
        private DispatcherTimer carSpawnerTimer;
        private DispatcherTimer pedSpawnerTimer;
        private DispatcherTimer trafficLightTimer;

        public List<SimulatingObject> Objects => objects;

        public void StartSim()
        {
            objects = new List<SimulatingObject>();
            destroyedObjectsBuffer = new List<SimulatingObject>();

            mainTimer = new System.Windows.Threading.DispatcherTimer();
            mainTimer.Tick += new EventHandler(Update);
            mainTimer.Interval = new TimeSpan(0, 0, 0, 0, timeStamp);
            mainTimer.Start();

            carSpawnerTimer = new System.Windows.Threading.DispatcherTimer();
            carSpawnerTimer.Tick += new EventHandler(SpawnCar);
            carSpawnerTimer.Interval = new TimeSpan(0, 0, 0, 10, timeStamp);
            carSpawnerTimer.Start();

            pedSpawnerTimer = new System.Windows.Threading.DispatcherTimer();
            pedSpawnerTimer.Tick += new EventHandler(SpawnPedestrian);
            pedSpawnerTimer.Interval = new TimeSpan(0, 0, 0, 5, timeStamp);
            pedSpawnerTimer.Start();

            trafficLightTimer = new System.Windows.Threading.DispatcherTimer();
            trafficLightTimer.Tick += new EventHandler(ToggleTrafficLight);
            trafficLightTimer.Interval = new TimeSpan(0, 0, 0, 3, timeStamp);
            trafficLightTimer.Start();
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
            foreach (var obj in objects.ToArray())
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
            
            //destroy collided
            foreach (var o in destroyedObjectsBuffer)
            {
                textCallback?.Invoke("Destroyed " + o.Tag);
                OnObjectDestroy(o);
            }
            destroyedObjectsBuffer.Clear();

            stepCallback?.Invoke();
        }

        private bool CheckCollision(SimulatingObject o1, SimulatingObject o2)
        {
            if (destroyedObjectsBuffer.Contains(o1) || destroyedObjectsBuffer.Contains(o2))
                return false;
            if (o2.Top > o1.Top && o2.Top < o1.Top + o1.CollisionHeight && o2.Left > o1.Left &&
                o2.Left < o2.Left + o2.CollisionWidth ||
                o1.Top > o2.Top && o1.Top < o2.Top + o2.CollisionHeight && o1.Left > o2.Left &&
                o1.Left < o2.Left + o2.CollisionWidth)
            {
                destroyedObjectsBuffer.Add(o1);
                destroyedObjectsBuffer.Add(o2);
                return true;
            }
            return false;
        }

        private void SpawnEmergencyCar()
        {
            SimulatingObject o = new SimulatingObject(70, 0, 2, 1, 1, 1, "EmergencyCar");
            o.OnDestroy += OnObjectDestroy;
            objects.Add(o);
        }

        private void SpawnCar(object sender, EventArgs e)
        {
            SimulatingObject o = new SimulatingObject(-50, 100, 0, 1, 50, 10, "Car");
            o.OnDestroy += OnObjectDestroy;
            objects.Add(o);
        }

        private void SpawnPedestrian(object sender, EventArgs e)
        {
            Pedestrian o = new Pedestrian(50, 0, 1, 0, 1, 1, "Pedestrian");
            toggleGreenLight += o.toggleSafe;
            o.OnDestroy += OnObjectDestroy;
            objects.Add(o);
        }

        private void ToggleTrafficLight(object sender, EventArgs e)
        {
            textCallback?.Invoke("Traffic light changed");
            toggleGreenLight?.Invoke();
        }

        private void OnObjectDestroy(SimulatingObject o)
        {
            objects.Remove(o);
        }
    }
}