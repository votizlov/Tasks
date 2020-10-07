using System;

namespace Task3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ICar dieselCar =
                new DieselCar(new Engine(Engine.EngineType.Diesel),
                    new Wheel[4]
                    {
                        new Wheel(Wheel.WheelType.Summer), new Wheel(Wheel.WheelType.Summer),
                        new Wheel(Wheel.WheelType.Summer), new Wheel(Wheel.WheelType.Summer)
                    },"AUDI");
            String error = String.Empty;
            if (!dieselCar.Drive(out error))
            {
                Console.WriteLine(error);
            }

            if (!dieselCar.FuelUp(0.9f,out error))
            {
                Console.WriteLine(error);
            }

            if (!dieselCar.FuelUp(0.9f,out error))
            {
                Console.WriteLine(error);
            }

            if (!dieselCar.ChangeTire(new Wheel(Wheel.WheelType.Summer), 10,out error))
            {
                Console.WriteLine(error);
            }
            
            Console.WriteLine(dieselCar.GetLabel());
        }
    }
}