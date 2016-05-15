
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.CarModels
{
    public class FuelCar : FuelVehicle
    {
        private CarProperties m_CarProperties;

        public FuelCar(string i_LicensePlate, string i_ModelName, List<Tire> i_Tires, FuelTypes.eFuelType i_FuelType, float i_MaxFuelCapacity, float i_initialFuel, CarProperties.eNumberOfDoors i_NumberOfDoors, CarProperties.eColors i_Color)
: base(i_LicensePlate, i_ModelName, i_Tires, i_FuelType, i_MaxFuelCapacity, i_initialFuel)
        {
            m_CarProperties = new CarProperties(i_NumberOfDoors, i_Color);
        }
    }
}

