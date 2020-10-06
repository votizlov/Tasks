using System;

namespace Task3
{
    public interface ICar
    {
        String PrintLabel();
        void Drive();
        void FuelUp(float amountOfFuel);
        void ChangeTire();
    }
}