
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.CarModels
{
    public class FuelCar : FuelVehicle
    {
        private CarProperties m_CarProperties;

        public FuelCar(string i_ModelName, string i_LicensePlate, int i_NumberOfTires, Tire i_Tire, eFuelType i_FuelType, float i_MaxFuelCapacity, CarProperties.eNumberOfDoors i_NumberOfDoors, CarProperties.eColors i_Color)
            : base(i_ModelName, i_LicensePlate, i_NumberOfTires, i_Tire, i_FuelType, i_MaxFuelCapacity)
        {
            m_CarProperties = new CarProperties(i_NumberOfDoors, i_Color);
        }

        public FuelCar(string i_ModelName, string i_LicensePlate, int i_NumberOfTires, Tire i_Tire, eFuelType i_FuelType, float i_MaxFuelCapacity, float i_initialFuel, CarProperties.eNumberOfDoors i_NumberOfDoors, CarProperties.eColors i_Color)
: base(i_ModelName, i_LicensePlate, i_NumberOfTires, i_Tire, i_FuelType, i_MaxFuelCapacity, i_initialFuel)
        {
            m_CarProperties = new CarProperties(i_NumberOfDoors, i_Color);
        }
    }
}

