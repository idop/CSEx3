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

            public FuelCar(string i_ModelName, string i_LicensePlate, int i_NumberOfTires, Tier i_Tier, eFuelType i_FuelType, float i_MaxFuelCapacity, eNumberOfDoors i_NumberOfDoors, eColors i_Color) 
                : base(i_ModelName, i_LicensePlate, i_NumberOfTires, i_Tier, i_FuelType, i_MaxFuelCapacity)
            {
                m_NumberOfDoors = i_NumberOfDoors;
                m_Color = i_Color;
            }

            public FuelCar(string i_ModelName, string i_LicensePlate, int i_NumberOfTires, Tier i_Tier, eFuelType i_FuelType, float i_MaxFuelCapacity,float i_initialFuel,  eNumberOfDoors i_NumberOfDoors, eColors i_Color)
    : base(i_ModelName, i_LicensePlate, i_NumberOfTires, i_Tier, i_FuelType, i_MaxFuelCapacity , i_initialFuel)
            {
                m_NumberOfDoors = i_NumberOfDoors;
                m_Color = i_Color;
            }
        }

        public class ElectricCar : ElectricVehicle
        {
            private eNumberOfDoors m_NumberOfDoors;
            private eColors m_Color;

            public ElectricCar(string i_ModelName, string i_LicensePlate, int i_NumberOfTires, Tier i_Tier, float i_MaxHoursOfPower, eNumberOfDoors i_NumberOfDoors, eColors i_Color)
            : base(i_ModelName, i_LicensePlate, i_NumberOfTires, i_Tier, i_MaxHoursOfPower)
            {
                m_NumberOfDoors = i_NumberOfDoors;
                m_Color = i_Color;
            }
            public ElectricCar(string i_ModelName, string i_LicensePlate, int i_NumberOfTires, Tier i_Tier, float i_MaxHoursOfPower, float i_InitalHoursOfPower, eNumberOfDoors i_NumberOfDoors, eColors i_Color)
            : base(i_ModelName, i_LicensePlate, i_NumberOfTires, i_Tier, i_MaxHoursOfPower, i_InitalHoursOfPower)
            {
                m_NumberOfDoors = i_NumberOfDoors;
                m_Color = i_Color;
            }
        }
    }
}
