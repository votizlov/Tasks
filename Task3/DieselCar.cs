using System;

namespace Task3
{
    public class DieselCar : ICar
    {
        private Engine Engine;
        private Wheel[] Wheels;
        /// <summary>
        /// 0 - empty, 1 - full
        /// </summary>
        private float fuelFactor;

        public DieselCar(Engine engine, Wheel[] wheels,String label)
        {
            this.Engine = engine;
            this.Wheels = wheels;
            this.label = label;
        }

        private String label;
        public string GetLabel()
        {
            return label;
        }

        public bool Drive(out String error)
        {
            if (fuelFactor > 0)
            {
                error = String.Empty;
                return true;
            }
            else
            {
                error = "No fuel";
                return false;
            }
        }

        public bool FuelUp(float amountOfFuel,out String error)
        {
            if (amountOfFuel + fuelFactor > 1)
            {
                error = "Too much fuel";
                return false;
            }
            else
            {
                fuelFactor += amountOfFuel;
                error = String.Empty;
                return true;
            }
        }

        public bool ChangeTire(Wheel wheel,int id,out String error)
        {
            if (id >= 0 && id < Wheels.Length)
            {
                Wheels[id] = wheel;
                error = String.Empty;
                return true;
            }
            else
            {
                error = "No such wheel";
                return false;
            }
        }
    }
}