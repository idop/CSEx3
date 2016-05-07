using System;
using System.Collections.Generic;
using System.Text;

namespace Ex3.GarageLogic
{
    public static class CarModels 
    {
        public enum eColors
        {
            Yellow,
            White,
            Red,
            Black
        }

        public enum eNumberOfDoors
        {
            TwoDoors = 2,
            ThreeDoors = 3,
            FourDoors = 4,
            FiveDoors = 5
        }

        public class FuelCar : FuelVehicle
        {
            private eNumberOfDoors m_NumberOfDoors;
            private eColors m_Color;

        }

        public class ElectricCar : ElectricVehicle
        {
            private eNumberOfDoors m_NumberOfDoors;
            private eColors m_Color;

        }
    }
}
