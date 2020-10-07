using System;

namespace Task3
{
    public interface ICar
    {
        String GetLabel();
        bool Drive(out String error);
        bool FuelUp(float amountOfFuel,out String error);
        bool ChangeTire(Wheel wheel,int id,out String error);
    }
}