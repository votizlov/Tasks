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
        public string PrintLabel()
        {
            throw new System.NotImplementedException();
        }

        public void Drive()
        {
            throw new System.NotImplementedException();
        }

        public void FuelUp(float amountOfFuel)
        {
            throw new System.NotImplementedException();
        }

        public void ChangeTire()
        {
            throw new System.NotImplementedException();
        }
    }
}